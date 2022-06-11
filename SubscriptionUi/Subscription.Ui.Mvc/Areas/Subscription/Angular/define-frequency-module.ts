var defineFrequencyModule = angular.module("defineFrequencyModule", ['angularMoment']);

defineFrequencyModule.service("subscriptionWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , subscriptionWebService]);

baseModule.requires.push('defineFrequencyModule');