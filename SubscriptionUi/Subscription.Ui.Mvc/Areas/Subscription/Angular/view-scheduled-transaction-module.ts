var viewScheduledTransactionModule = angular.module("viewScheduledTransactionModule", []);

viewScheduledTransactionModule.service("subscriptionWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , subscriptionWebService]);

baseModule.requires.push('viewScheduledTransactionModule');