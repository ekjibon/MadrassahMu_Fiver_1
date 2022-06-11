var summaryModule = angular.module("summaryModule", []);

summaryModule.service("subscriptionWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , subscriptionWebService]);

baseModule.requires.push('summaryModule');