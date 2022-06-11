var administrationCustomerModule = angular.module("administrationCustomerModule", []); //['validator', 'angular.filter', 'ngQuill']
administrationCustomerModule.service("administrationCustomerWebService", ["genericWebConnectionService",
    "globalVariableFactory",
    administrationCustomerWebService]);
baseModule.requires.push("administrationCustomerModule");
//# sourceMappingURL=administration-customer-module.js.map