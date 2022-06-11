var administrationProductModule = angular.module("administrationProductModule", ['validator', 'angular.filter', 'ngQuill']);

administrationProductModule.service("administrationProductWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , administrationProductWebService]);



baseModule.requires.push("administrationProductModule");