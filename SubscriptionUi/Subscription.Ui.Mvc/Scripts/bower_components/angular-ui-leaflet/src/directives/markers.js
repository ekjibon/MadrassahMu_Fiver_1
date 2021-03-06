angular.module('ui-leaflet').directive('markers', function (leafletLogger, $rootScope, $q, leafletData, leafletHelpers, leafletMapDefaults, leafletMarkersHelpers, leafletMarkerEvents, leafletIterators, leafletWatchHelpers, leafletDirectiveControlsHelpers) {
    //less terse vars to helpers
    var isDefined = leafletHelpers.isDefined, errorHeader = leafletHelpers.errorHeader, Helpers = leafletHelpers, isString = leafletHelpers.isString, addMarkerWatcher = leafletMarkersHelpers.addMarkerWatcher, updateMarker = leafletMarkersHelpers.updateMarker, listenMarkerEvents = leafletMarkersHelpers.listenMarkerEvents, addMarkerToGroup = leafletMarkersHelpers.addMarkerToGroup, createMarker = leafletMarkersHelpers.createMarker, deleteMarker = leafletMarkersHelpers.deleteMarker, getModelFromModels = leafletMarkersHelpers.getModelFromModels, getLayerModels = leafletMarkersHelpers.getLayerModels, resetUnusedMarkerGroups = leafletMarkersHelpers.resetUnusedMarkerGroups, $it = leafletIterators, _defaultWatchOptions = leafletHelpers.watchOptions, maybeWatch = leafletWatchHelpers.maybeWatch, extendDirectiveControls = leafletDirectiveControlsHelpers.extend, $log = leafletLogger, watchTrap = { changeFromDirective: false };
    var _getLMarker = function (leafletMarkers, name, maybeLayerName) {
        if (!Object.keys(leafletMarkers).length)
            return;
        if (maybeLayerName && isString(maybeLayerName)) {
            if (!leafletMarkers[maybeLayerName] || !Object.keys(leafletMarkers[maybeLayerName]).length)
                return;
            return leafletMarkers[maybeLayerName][name];
        }
        return leafletMarkers[name];
    };
    var _setLMarker = function (lObject, leafletMarkers, name, maybeLayerName) {
        if (maybeLayerName && isString(maybeLayerName)) {
            if (!isDefined(leafletMarkers[maybeLayerName]))
                leafletMarkers[maybeLayerName] = {};
            leafletMarkers[maybeLayerName][name] = lObject;
        }
        else
            leafletMarkers[name] = lObject;
        return lObject;
    };
    var _maybeAddMarkerToLayer = function (layerName, layers, model, marker, watchType, map) {
        if (!isString(layerName)) {
            $log.error(errorHeader + ' A layername must be a string');
            return false;
        }
        if (!isDefined(layers)) {
            $log.error(errorHeader + ' You must add layers to the directive if the markers are going to use this functionality.');
            return false;
        }
        if (!isDefined(layers.overlays) || !isDefined(layers.overlays[layerName])) {
            $log.error(errorHeader + ' A marker can only be added to a layer of type "group"');
            return false;
        }
        var layerGroup = layers.overlays[layerName];
        if (!(layerGroup instanceof L.LayerGroup || layerGroup instanceof L.FeatureGroup)) {
            $log.error(errorHeader + ' Adding a marker to an overlay needs a overlay of the type "group" or "featureGroup"');
            return false;
        }
        // The marker goes to a correct layer group, so first of all we add it
        layerGroup.addLayer(marker);
        // The marker is automatically added to the map depending on the visibility
        // of the layer, so we only have to open the popup if the marker is in the map
        if (watchType === null && map.hasLayer(marker) && model.focus === true) {
            marker.openPopup();
        }
        return true;
    };
    //TODO: move to leafletMarkersHelpers??? or make a new class/function file (leafletMarkersHelpers is large already)
    var _addMarkers = function (mapId, markersToRender, oldModels, map, layers, leafletMarkers, leafletScope, watchOptions, maybeLayerName, skips) {
        $it.each(markersToRender, function (model, newName) {
            if (skips[newName])
                return;
            if (newName.search("-") !== -1) {
                $log.error('The marker can\'t use a "-" on his key name: "' + newName + '".');
                return;
            }
            var pathToMarker = Helpers.getObjectDotPath(maybeLayerName ? [maybeLayerName, newName] : [newName]);
            var maybeLMarker = _getLMarker(leafletMarkers, newName, maybeLayerName);
            Helpers.modelChangeInDirective(watchTrap, "changeFromDirective", function () {
                if (!isDefined(maybeLMarker)) {
                    var marker = createMarker(model);
                    var layerName = (model ? model.layer : undefined) || maybeLayerName; //original way takes pref
                    if (!isDefined(marker)) {
                        $log.error(errorHeader + ' Received invalid data on the marker ' + newName + '.');
                        return;
                    }
                    _setLMarker(marker, leafletMarkers, newName, maybeLayerName);
                    // Bind message
                    if (isDefined(model.message)) {
                        marker.bindPopup(model.message, model.popupOptions);
                    }
                    // Add the marker to a cluster group if needed
                    if (isDefined(model.group)) {
                        var groupOptions = isDefined(model.groupOption) ? model.groupOption : null;
                        addMarkerToGroup(marker, model.group, groupOptions, map);
                    }
                    // Show label if defined
                    if (Helpers.LabelPlugin.isLoaded() && isDefined(model.label) && isDefined(model.label.message)) {
                        marker.bindLabel(model.label.message, model.label.options);
                    }
                    // Check if the marker should be added to a layer
                    if (isDefined(model) && (isDefined(model.layer) || isDefined(maybeLayerName))) {
                        var pass = _maybeAddMarkerToLayer(layerName, layers, model, marker, watchOptions.individual.type, map);
                        if (!pass)
                            return; //something went wrong move on in the loop
                    }
                    else if (!isDefined(model.group)) {
                        // We do not have a layer attr, so the marker goes to the map layer
                        map.addLayer(marker);
                        if (watchOptions.individual.type === null && model.focus === true) {
                            marker.openPopup();
                        }
                    }
                    if (watchOptions.individual.type !== null) {
                        addMarkerWatcher(marker, pathToMarker, leafletScope, layers, map, watchOptions.individual);
                    }
                    listenMarkerEvents(marker, model, leafletScope, watchOptions.individual.type, map);
                    leafletMarkerEvents.bindEvents(mapId, marker, pathToMarker, model, leafletScope, layerName);
                }
                else {
                    var oldModel = getModelFromModels(oldModels, newName, maybeLayerName);
                    updateMarker(model, oldModel, maybeLMarker, pathToMarker, leafletScope, layers, map);
                }
            });
        });
    };
    var _seeWhatWeAlreadyHave = function (markerModels, oldMarkerModels, lMarkers, isEqual, cb) {
        var hasLogged = false, equals = false, oldMarker, newMarker;
        var doCheckOldModel = isDefined(oldMarkerModels);
        for (var name in lMarkers) {
            if (!hasLogged) {
                $log.debug(errorHeader + "[markers] destroy: ");
                hasLogged = true;
            }
            if (doCheckOldModel) {
                //might want to make the option (in watch options) to disable deep checking
                //ie the options to only check !== (reference check) instead of angular.equals (slow)
                newMarker = markerModels[name];
                oldMarker = oldMarkerModels[name];
                equals = isEqual && angular.equals(newMarker, oldMarker);
            }
            if (!isDefined(markerModels) ||
                !Object.keys(markerModels).length ||
                !isDefined(markerModels[name]) ||
                !Object.keys(markerModels[name]).length ||
                equals) {
                if (cb && Helpers.isFunction(cb))
                    cb(newMarker, oldMarker, name);
            }
        }
    };
    var _destroy = function (markerModels, oldMarkerModels, lMarkers, map, layers) {
        _seeWhatWeAlreadyHave(markerModels, oldMarkerModels, lMarkers, false, function (newMarker, oldMarker, lMarkerName) {
            $log.debug(errorHeader + '[marker] is deleting marker: ' + lMarkerName);
            deleteMarker(lMarkers[lMarkerName], map, layers);
            delete lMarkers[lMarkerName];
        });
    };
    var _getNewModelsToSkipp = function (newModels, oldModels, lMarkers) {
        var skips = {};
        _seeWhatWeAlreadyHave(newModels, oldModels, lMarkers, true, function (newMarker, oldMarker, lMarkerName) {
            $log.debug(errorHeader + '[marker] is already rendered, marker: ' + lMarkerName);
            skips[lMarkerName] = newMarker;
        });
        return skips;
    };
    return {
        restrict: "A",
        scope: false,
        replace: false,
        require: ['leaflet', '?layers'],
        link: function (scope, element, attrs, controller) {
            var mapController = controller[0], leafletScope = mapController.getLeafletScope();
            mapController.getMap().then(function (map) {
                var leafletMarkers = {}, getLayers;
                // If the layers attribute is used, we must wait until the layers are created
                if (isDefined(controller[1])) {
                    getLayers = controller[1].getLayers;
                }
                else {
                    getLayers = function () {
                        var deferred = $q.defer();
                        deferred.resolve();
                        return deferred.promise;
                    };
                }
                var watchOptions;
                if (leafletScope.watchOptions && leafletScope.watchOptions.markers) {
                    watchOptions = leafletScope.watchOptions.markers;
                }
                else {
                    watchOptions = _defaultWatchOptions;
                }
                var isNested = (isDefined(attrs.markersNested) && Helpers.isTruthy(attrs.markersNested));
                getLayers().then(function (layers) {
                    var _clean = function (models, oldModels) {
                        resetUnusedMarkerGroups();
                        if (isNested) {
                            $it.each(models, function (markerToMaybeDel, layerName) {
                                var oldLayerModels = getLayerModels(oldModels, layerName);
                                _destroy(markerToMaybeDel, oldLayerModels, leafletMarkers[layerName], map, layers);
                            });
                            return;
                        }
                        _destroy(models, oldModels, leafletMarkers, map, layers);
                    };
                    var _create = function (models, oldModels) {
                        _clean(models, oldModels);
                        var skips = null;
                        if (isNested) {
                            $it.each(models, function (markersToAdd, layerName) {
                                var oldLayerModels = getLayerModels(oldModels, layerName);
                                var newlayerModels = getLayerModels(models, layerName);
                                skips = _getNewModelsToSkipp(newlayerModels, oldLayerModels, leafletMarkers[layerName]);
                                _addMarkers(attrs.id, markersToAdd, oldModels, map, layers, leafletMarkers, leafletScope, watchOptions, layerName, skips);
                            });
                            return;
                        }
                        skips = _getNewModelsToSkipp(models, oldModels, leafletMarkers);
                        _addMarkers(attrs.id, models, oldModels, map, layers, leafletMarkers, leafletScope, watchOptions, undefined, skips);
                    };
                    extendDirectiveControls(attrs.id, 'markers', _create, _clean);
                    leafletData.setMarkers(leafletMarkers, attrs.id);
                    maybeWatch(leafletScope, 'markers', watchOptions, function (newMarkers, oldMarkers) {
                        if (watchTrap.changeFromDirective)
                            return;
                        _create(newMarkers, oldMarkers);
                    });
                    scope.$on('$destroy', function () {
                        _destroy(leafletScope.markers, {}, leafletMarkers, map, layers);
                    });
                });
            });
        }
    };
});
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map 
//# sourceMappingURL=markers.js.map