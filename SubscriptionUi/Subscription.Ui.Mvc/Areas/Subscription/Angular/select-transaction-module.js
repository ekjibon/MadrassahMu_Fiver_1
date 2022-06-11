var selectTransactionModule = angular.module("selectTransactionModule", []);
selectTransactionModule.service("subscriptionWebService", ["genericWebConnectionService",
    "globalVariableFactory",
    subscriptionWebService]);
baseModule.requires.push('selectTransactionModule');
//# sourceMappingURL=select-transaction-module.js.map