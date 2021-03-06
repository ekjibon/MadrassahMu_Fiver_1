angular.module('ui-leaflet').service('leafletHelpers', function ($q, $log, $timeout) {
    var _errorHeader = '[ui-leaflet] ';
    var _copy = angular.copy;
    var _clone = _copy;
    /*
    For parsing paths to a field in an object

    Example:
    var obj = {
        bike:{
         1: 'hi'
         2: 'foo'
        }
    };
    _getObjectValue(obj,"bike.1") returns 'hi'
    this is getPath in ui-gmap

    like _.get
    http://stackoverflow.com/questions/2631001/javascript-test-for-existence-of-nested-object-key?page=1&tab=active#tab-top
     */
    var _getObjectValue = function (object, path) {
        if (!object)
            return;
        path = path.split('.');
        var obj = object[path.shift()];
        while (obj && path.length)
            obj = obj[path.shift()];
        return obj;
    };
    /*
     Object Array Notation
     _getObjectArrayPath("bike.one.two")
     returns:
     'bike["one"]["two"]'
     */
    var _getObjectArrayPath = function (pathStr) {
        return pathStr.split('.').reduce(function (previous, current) {
            return previous + '["' + current + '"]';
        });
    };
    /* Object Dot Notation
     _getObjectPath(["bike","one","two"])
     returns:
     "bike.one.two"
     */
    var _getObjectDotPath = function (arrayOfStrings) {
        return arrayOfStrings.reduce(function (previous, current) {
            return previous + '.' + current;
        });
    };
    function _obtainEffectiveMapId(d, mapId) {
        var id, keys = Object.keys(d);
        if (!angular.isDefined(mapId)) {
            if (keys.length === 0 || (keys.length === 1 && keys[0] === 'main')) {
                //default non id attribute map
                // OR one key 'main'
                /*
                    Main Reason:
                    Initally if we have only one map and no "id" then d will be undefined initially.
                    On subsequent runs it will be just d.main so we need to return the last map.
                */
                id = "main";
            }
            else {
                throw new Error(_errorHeader + "- You have more than 1 map on the DOM, you must provide the map ID to the leafletData.getXXX call. Where one of the following mapIds " + Object.keys(d).join(',') + ' are available.');
            }
        }
        else {
            id = mapId;
        }
        return id;
    }
    function _getUnresolvedDefer(d, mapId) {
        var id = _obtainEffectiveMapId(d, mapId), defer;
        if (!angular.isDefined(d[id]) || d[id].resolvedDefer === true) {
            defer = $q.defer();
            d[id] = {
                defer: defer,
                resolvedDefer: false
            };
        }
        else {
            defer = d[id].defer;
        }
        return defer;
    }
    var _isDefined = function (value) {
        return angular.isDefined(value) && value !== null;
    };
    var _isUndefined = function (value) {
        return !_isDefined(value);
    };
    // BEGIN DIRECT PORT FROM AngularJS code base
    var SPECIAL_CHARS_REGEXP = /([\:\-\_]+(.))/g;
    var MOZ_HACK_REGEXP = /^moz([A-Z])/;
    var PREFIX_REGEXP = /^((?:x|data)[\:\-_])/i;
    /**
    Converts snake_case to camelCase.
    Also there is special case for Moz prefix starting with upper case letter.
    @param name Name to normalize
     */
    var camelCase = function (name) {
        return name.replace(SPECIAL_CHARS_REGEXP, function (_, separator, letter, offset) {
            if (offset) {
                return letter.toUpperCase();
            }
            else {
                return letter;
            }
        }).replace(MOZ_HACK_REGEXP, "Moz$1");
    };
    /**
        Converts all accepted directives format into proper directive name.
        @param name Name to normalize
    */
    var directiveNormalize = function (name) {
        return camelCase(name.replace(PREFIX_REGEXP, ""));
    };
    // END AngularJS port
    var _watchTrapDelayMilliSec = 10;
    var _modelChangeInDirective = function (trapObj, trapField, cbToExec) {
        if (!trapObj)
            throw new Error(_errorHeader + 'trapObj is undefined');
        if (!trapField)
            throw new Error(_errorHeader + 'trapField is undefined');
        trapObj[trapField] = true;
        var ret = cbToExec();
        $timeout(function () {
            trapObj[trapField] = false;
        }, _watchTrapDelayMilliSec);
        return ret;
    };
    return {
        watchTrapDelayMilliSec: _watchTrapDelayMilliSec,
        modelChangeInDirective: _modelChangeInDirective,
        camelCase: camelCase,
        directiveNormalize: directiveNormalize,
        copy: _copy,
        clone: _clone,
        errorHeader: _errorHeader,
        getObjectValue: _getObjectValue,
        get: _getObjectValue,
        getObjectArrayPath: _getObjectArrayPath,
        getObjectDotPath: _getObjectDotPath,
        defaultTo: function (val, _default) {
            return _isDefined(val) ? val : _default;
        },
        //mainly for checking attributes of directives lets keep this minimal (on what we accept)
        isTruthy: function (val) {
            return val === 'true' || val === true;
        },
        //Determine if a reference is {}
        isEmpty: function (value) {
            return Object.keys(value).length === 0;
        },
        //Determine if a reference is undefined or {}
        isUndefinedOrEmpty: function (value) {
            return (angular.isUndefined(value) || value === null) || Object.keys(value).length === 0;
        },
        // Determine if a reference is defined
        isDefined: _isDefined,
        isUndefined: _isUndefined,
        isNumber: angular.isNumber,
        isString: angular.isString,
        isArray: angular.isArray,
        isObject: angular.isObject,
        isFunction: angular.isFunction,
        equals: angular.equals,
        isValidCenter: function (center) {
            return angular.isDefined(center) && angular.isNumber(center.lat) &&
                angular.isNumber(center.lng) && angular.isNumber(center.zoom);
        },
        isValidPoint: function (point) {
            if (!angular.isDefined(point)) {
                return false;
            }
            if (angular.isArray(point)) {
                return point.length === 2 && angular.isNumber(point[0]) && angular.isNumber(point[1]);
            }
            return angular.isNumber(point.lat) && angular.isNumber(point.lng);
        },
        isSameCenterOnMap: function (centerModel, map) {
            var mapCenter = map.getCenter();
            var zoom = map.getZoom();
            if (centerModel.lat && centerModel.lng &&
                mapCenter.lat.toFixed(4) === centerModel.lat.toFixed(4) &&
                mapCenter.lng.toFixed(4) === centerModel.lng.toFixed(4) &&
                zoom === centerModel.zoom) {
                return true;
            }
            return false;
        },
        safeApply: function ($scope, fn) {
            var phase = $scope.$root.$$phase;
            if (phase === '$apply' || phase === '$digest') {
                $scope.$eval(fn);
            }
            else {
                $scope.$evalAsync(fn);
            }
        },
        obtainEffectiveMapId: _obtainEffectiveMapId,
        getDefer: function (d, mapId) {
            var id = _obtainEffectiveMapId(d, mapId), defer;
            if (!angular.isDefined(d[id]) || d[id].resolvedDefer === false) {
                defer = _getUnresolvedDefer(d, mapId);
            }
            else {
                defer = d[id].defer;
            }
            return defer;
        },
        getUnresolvedDefer: _getUnresolvedDefer,
        setResolvedDefer: function (d, mapId) {
            var id = _obtainEffectiveMapId(d, mapId);
            d[id].resolvedDefer = true;
        },
        rangeIsSupported: function () {
            var testrange = document.createElement('input');
            testrange.setAttribute('type', 'range');
            return testrange.type === 'range';
        },
        FullScreenControlPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.Control.Fullscreen);
            }
        },
        MiniMapControlPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.Control.MiniMap);
            }
        },
        AwesomeMarkersPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.AwesomeMarkers) && angular.isDefined(L.AwesomeMarkers.Icon);
            },
            is: function (icon) {
                if (this.isLoaded()) {
                    return icon instanceof L.AwesomeMarkers.Icon;
                }
                else {
                    return false;
                }
            },
            equal: function (iconA, iconB) {
                if (!this.isLoaded()) {
                    return false;
                }
                if (this.is(iconA)) {
                    return angular.equals(iconA, iconB);
                }
                else {
                    return false;
                }
            }
        },
        VectorMarkersPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.VectorMarkers) && angular.isDefined(L.VectorMarkers.Icon);
            },
            is: function (icon) {
                if (this.isLoaded()) {
                    return icon instanceof L.VectorMarkers.Icon;
                }
                else {
                    return false;
                }
            },
            equal: function (iconA, iconB) {
                if (!this.isLoaded()) {
                    return false;
                }
                if (this.is(iconA)) {
                    return angular.equals(iconA, iconB);
                }
                else {
                    return false;
                }
            }
        },
        DomMarkersPlugin: {
            isLoaded: function () {
                if (angular.isDefined(L.DomMarkers) && angular.isDefined(L.DomMarkers.Icon)) {
                    return true;
                }
                else {
                    return false;
                }
            },
            is: function (icon) {
                if (this.isLoaded()) {
                    return icon instanceof L.DomMarkers.Icon;
                }
                else {
                    return false;
                }
            },
            equal: function (iconA, iconB) {
                if (!this.isLoaded()) {
                    return false;
                }
                if (this.is(iconA)) {
                    return angular.equals(iconA, iconB);
                }
                else {
                    return false;
                }
            }
        },
        PolylineDecoratorPlugin: {
            isLoaded: function () {
                if (angular.isDefined(L.PolylineDecorator)) {
                    return true;
                }
                else {
                    return false;
                }
            },
            is: function (decoration) {
                if (this.isLoaded()) {
                    return decoration instanceof L.PolylineDecorator;
                }
                else {
                    return false;
                }
            },
            equal: function (decorationA, decorationB) {
                if (!this.isLoaded()) {
                    return false;
                }
                if (this.is(decorationA)) {
                    return angular.equals(decorationA, decorationB);
                }
                else {
                    return false;
                }
            }
        },
        MakiMarkersPlugin: {
            isLoaded: function () {
                if (angular.isDefined(L.MakiMarkers) && angular.isDefined(L.MakiMarkers.Icon)) {
                    return true;
                }
                else {
                    return false;
                }
            },
            is: function (icon) {
                if (this.isLoaded()) {
                    return icon instanceof L.MakiMarkers.Icon;
                }
                else {
                    return false;
                }
            },
            equal: function (iconA, iconB) {
                if (!this.isLoaded()) {
                    return false;
                }
                if (this.is(iconA)) {
                    return angular.equals(iconA, iconB);
                }
                else {
                    return false;
                }
            }
        },
        ExtraMarkersPlugin: {
            isLoaded: function () {
                if (angular.isDefined(L.ExtraMarkers) && angular.isDefined(L.ExtraMarkers.Icon)) {
                    return true;
                }
                else {
                    return false;
                }
            },
            is: function (icon) {
                if (this.isLoaded()) {
                    return icon instanceof L.ExtraMarkers.Icon;
                }
                else {
                    return false;
                }
            },
            equal: function (iconA, iconB) {
                if (!this.isLoaded()) {
                    return false;
                }
                if (this.is(iconA)) {
                    return angular.equals(iconA, iconB);
                }
                else {
                    return false;
                }
            }
        },
        LabelPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.Label);
            },
            is: function (layer) {
                if (this.isLoaded()) {
                    return layer instanceof L.MarkerClusterGroup;
                }
                else {
                    return false;
                }
            }
        },
        MarkerClusterPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.MarkerClusterGroup);
            },
            is: function (layer) {
                if (this.isLoaded()) {
                    return layer instanceof L.MarkerClusterGroup;
                }
                else {
                    return false;
                }
            }
        },
        GeoJSONPlugin: {
            isLoaded: function () {
                return angular.isDefined(L.TileLayer.GeoJSON);
            },
            is: function (layer) {
                if (this.isLoaded()) {
                    return layer instanceof L.TileLayer.GeoJSON;
                }
                else {
                    return false;
                }
            }
        },
        CartoDB: {
            isLoaded: function () {
                return cartodb;
            },
            is: function () {
                return true;
                /*
                if (this.isLoaded()) {
                    return layer instanceof L.TileLayer.GeoJSON;
                } else {
                    return false;
                }*/
            }
        },
        Leaflet: {
            DivIcon: {
                is: function (icon) {
                    return icon instanceof L.DivIcon;
                },
                equal: function (iconA, iconB) {
                    if (this.is(iconA)) {
                        return angular.equals(iconA, iconB);
                    }
                    else {
                        return false;
                    }
                }
            },
            Icon: {
                is: function (icon) {
                    return icon instanceof L.Icon;
                },
                equal: function (iconA, iconB) {
                    if (this.is(iconA)) {
                        return angular.equals(iconA, iconB);
                    }
                    else {
                        return false;
                    }
                }
            }
        },
        /*
         watchOptions - object to set deep nested watches and turn off watches all together
         (rely on control / functional updates)
         watchOptions - Object
             type: string. //One of ['watch', 'watchCollection', 'watchDeep', null]
             individual
                 type: string
         */
        //legacy defaults
        watchOptions: {
            type: 'watchDeep',
            individual: {
                type: 'watchDeep'
            }
        }
    };
});
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map 
//# sourceMappingURL=leafletHelpers.js.map