var bankReconciliationModule = angular.module("bankReconciliationModule", ['validator', 'angular.filter', 'ngQuill']);

bankReconciliationModule.service("bankReconciliationWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , bankReconciliationWebService]);



baseModule.requires.push("bankReconciliationModule");