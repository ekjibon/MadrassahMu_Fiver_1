var administrationModule = angular.module("administrationModule", ['validator', 'angular.filter', 'ngQuill']);

administrationModule.service("administrationWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , administrationWebService]);



baseModule.requires.push("administrationModule");