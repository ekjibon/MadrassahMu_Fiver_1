var paymentModule = angular.module("paymentModule", []);
paymentModule.service("subscriptionWebService", ["genericWebConnectionService",
    "globalVariableFactory",
    subscriptionWebService]);
baseModule.requires.push('paymentModule');
//# sourceMappingURL=payment-module.js.map