var viewAllScheduledTransactionModule = angular.module("viewAllScheduledTransactionModule", []);

viewAllScheduledTransactionModule.service("subscriptionWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , subscriptionWebService]);

baseModule.requires.push('viewAllScheduledTransactionModule');