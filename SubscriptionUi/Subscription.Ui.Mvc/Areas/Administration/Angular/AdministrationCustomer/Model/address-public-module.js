var addressPublicModule = angular.module("addressPublicModule", []);
addressPublicModule.service("addressPublicWebService", ["genericWebConnectionService",
    "globalVariableFactory",
    addressPublicWebService]);
addressPublicModule.service("addressPublicUtilityService", ["addressPublicWebService",
    "$q",
    addressPublicUtilityService]);
baseModule.requires.push("addressPublicModule");
//# sourceMappingURL=address-public-module.js.map