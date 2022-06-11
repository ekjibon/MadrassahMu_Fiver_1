var authModule = angular.module("authModule", []);
authModule.service("authentication2WebService", ["genericWebConnectionService",
    "globalVariableFactory",
    authModule]);
baseModule.requires.push("authModule");
//# sourceMappingURL=auth-module.js.map