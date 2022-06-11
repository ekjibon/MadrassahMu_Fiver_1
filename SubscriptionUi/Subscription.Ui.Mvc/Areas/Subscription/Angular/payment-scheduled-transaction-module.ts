var paymentScheduledTransactionModule = angular.module("paymentScheduledTransactionModule", []);

paymentScheduledTransactionModule.service("subscriptionWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , subscriptionWebService]);

baseModule.requires.push('paymentScheduledTransactionModule');