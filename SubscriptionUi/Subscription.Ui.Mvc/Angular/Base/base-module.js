var baseModule = angular.module("baseModule", [
    'uiSwitch',
    'angularMoment',
    'ngAnimate',
    'toaster',
    'oitozero.ngSweetAlert',
    'truncate',
    'angular-notification-icons',
    'ngCookies',
    'ngStorage',
    'ui.select',
    'ngSanitize',
    'ngTouch',
    'ui.bootstrap',
    'ngFileUpload',
    'trNgGrid',
    'xeditable',
    'initFromForm',
    'angucomplete-alt',
    'fileUploadModule',
    'authenticationModule',
    'ngTable'
]);
baseModule.service("globalVariableFactory", [
    '$rootScope',
    '$window',
    globalVariableFactory
]);
baseModule.service("genericWebConnectionService", ["$http",
    "$window",
    "$q",
    "globalVariableFactory",
    genericWebConnectionService
]);
baseModule.service("permissionManager", ["globalVariableFactory",
    "$window",
    permissionManager]);
baseModule.controller("baseController", ["$scope",
    "$rootScope",
    "$location",
    "$anchorScroll",
    "$localStorage",
    "$window",
    "$timeout",
    "$uibModal",
    "$q",
    "$document",
    "$parse",
    "SweetAlert",
    "toaster",
    "moment",
    "globalVariableFactory",
    "permissionManager",
    "authenticationFactory",
    "fileWebService",
    "fileManager"
    //, "signalR"
    ,
    baseController
]);
baseModule.directive('resize', ['$rootScope', '$window', function ($rootScope, $window) {
        return {
            link: function (scope, element, attrs) {
                function onResize(e) {
                    $rootScope.$broadcast('resize::resize');
                }
                function cleanUp() {
                    angular.element($window).off('resize', onResize);
                }
                angular.element($window).on('resize', onResize);
                scope.$on('$destroy', cleanUp);
            }
        };
    }]);
baseModule.directive("disableAnimate", ['$animate', function ($animate) {
        return function (scope, element) {
            $animate.enabled(false, element);
        };
    }]);
baseModule.directive('refreshOnUpload', ['$timeout', function ($timeout) {
        return {
            restrict: 'A',
            link: function (scope, elem, attrs) {
                scope.$watch(attrs['ngModel'], function (v) {
                    if (elem.width() > 0) {
                        elem.css('width', elem.width() + 'px');
                    }
                });
            }
        };
    }]);
baseModule.directive('myEnter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.ngEnter, { 'event': event });
                });
                event.preventDefault();
            }
        });
    };
});
baseModule.directive('uiSelectOpened', function ($timeout) {
    return {
        restrict: 'A',
        require: 'uiSelect',
        link: function (scope, element, attrs, uiSelect) {
            $timeout(function () { return uiSelect.toggle(); });
        }
    };
});
/*baseModule.factory("signalR", function () {
    var factory: any = {};

    factory.url = function (url) {
        $.connection.hub.url = url;
    }

    factory.setHubName = function (hubName) {
        factory.hub = hubName;
    }

    factory.connectToHub = function () {
        factory.connectedHub = $.connection[factory.hub];

        if (factory.connectedHub != null || factory.connectedHub != undefined) {
            factory.isServerUp = true;
        }
    }

    factory.client = function () {
        return factory.connectedHub.client;
    }

    factory.server = function () {
        return factory.connectedHub.server;
    }

    factory.start = function (fn) {
        return $.connection.hub.start().done(fn);
    }

    return factory;
});*/
/*
baseModule.run(['$rootScope', 'editableOptions', 'signalR',
    function ($rootScope, editableOptions, signalR) {
        FastClick.attach(document.body);

        // GLOBAL APP SCOPE
        // set below basic information
        $rootScope.app = {
            name: 'The Hub', // name of your project
            author: 'The Hub Business Solutions Ltd', // author's name or company name
            description: '', // brief description
            version: '2.0', // current version
            year: ((new Date()).getFullYear()), // automatic current year (for copyright information)
            isMobile: (function () {// true if the browser is a mobile device
                var check = false;
                if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
                    check = true;
                };
                return check;
            })()
        };
        signalR.url(signalRUrl + "/signalr");
    }]);
    */
// Angular-Loading-Bar
// configuration
//baseModule.config(['cfpLoadingBarProvider',
//    function (cfpLoadingBarProvider) {
//        cfpLoadingBarProvider.includeBar = true;
//        cfpLoadingBarProvider.includeSpinner = false;
//    }]);
baseModule.constant('APP_MEDIAQUERY', {
    'desktopXL': 1200,
    'desktop': 992,
    'tablet': 768,
    'mobile': 480
});
baseModule.filter("trustUrl", ['$sce', function ($sce) {
        return function (recordingUrl) {
            return $sce.trustAsResourceUrl(recordingUrl);
        };
    }]);
baseModule.config(['socialProvider', function (socialProvider) {
        socialProvider.setLinkedInKey({ clientId: "81pt9ayatue58t", secret: "KQGtWCPN0FdLN3Sm", redirectUrl: "https://moprofil.com/public/security/linkedinCallback" });
        //socialProvider.setLinkedInKey("81pt9ayatue58t");
        socialProvider.setGoogleKey("827960015269-0khvan9hpj53ur6vbl4s4sd2ovl6sfvv.apps.googleusercontent.com");
        socialProvider.setFbKey({ appId: "254974195200276", apiVersion: "v3.2" });
        socialProvider.setIdentityKey({ loginUrl: "", registerUrl: "v2.8" });
    }]);
baseModule.directive('googleplace', function () {
    return {
        require: 'ngModel',
        scope: {
            updateFn: '&'
        },
        link: function (scope, element, attrs, model) {
            var options = {
                types: ['geocode']
            };
            scope.gPlace = new google.maps.places.Autocomplete(element[0], options);
            scope.gPlace.setFields(['address_component', 'geometry']);
            google.maps.event.addListener(scope.gPlace, 'place_changed', function () {
                scope.$apply(function () {
                    var place = scope.gPlace.getPlace();
                    model.$setViewValue(place);
                    scope.updateFn();
                });
            });
            element[0].onfocus = function () {
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        var geolocation = {
                            lat: position.coords.latitude,
                            lng: position.coords.longitude
                        };
                        var circle = new google.maps.Circle({ center: geolocation, radius: position.coords.accuracy });
                        scope.gPlace.setBounds(circle.getBounds());
                    });
                }
            };
        }
    };
});
//declare var signalRUrl: any;
/*baseModule.filter('propsFilter', function () {
    return function (items, props) {
        var out = [];

        if (angular.isArray(items)) {
            items.forEach(function (item) {
                //var itemMatches = false;

                var keys = Object.keys(props);
                for (var i = 0; i < keys.length; i++) {
                    var prop = keys[i];
                    var text = props[prop].toString().toLowerCase();
                    if (item[prop] != null) {
                        if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                            //itemMatches = true;
                            out.push(item);
                            //break;
                        }
                    }
                }

                //if (itemMatches) {
                    out.push(item);
                //}
            });
        } else {
            // Let the output be the input untouched
            out = items;
        }

        return out;
    }
});*/
baseModule.filter('propsFilter', function () {
    return function (items, props) {
        var out = [];
        if (angular.isArray(items)) {
            items.forEach(function (item) {
                var itemMatches = false;
                var keys = Object.keys(props);
                for (var i = 0; i < keys.length; i++) {
                    var prop = keys[i];
                    var text = props[prop].toLowerCase();
                    if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                        itemMatches = true;
                        break;
                    }
                }
                if (itemMatches) {
                    out.push(item);
                }
            });
        }
        else {
            // Let the output be the input untouched
            out = items;
        }
        return out;
    };
});
/*baseModule.filter('propsFilter', function ($log) {
    return function (items, props) {
        var out = [];
        if (angular.isArray(items)) {
            items.forEach(function (item) {
                var itemMatches = false;
                var keys = Object.keys(props);
                var optionValue = '';
                for (var i = 0; i < keys.length; i++) {
                    optionValue = item[keys[i]] ? optionValue + item[keys[i]].toString().toLowerCase().replace(/ /g, '') : '';
                }
                for (var j = 0; j < keys.length; j++) {
                    var text = props[keys[j]].toString().toLowerCase().replace(/ /g, '');
                    if (optionValue.indexOf(text) !== -1) {
                        itemMatches = true;
                        break;
                    }
                }
                if (itemMatches) {
                    out.push(item);
                }
            });
        } else {
            // Let the output be the input untouched
            out = items;
        }

        return out;
    };
})*/ 
//# sourceMappingURL=base-module.js.map