var transactionModule = angular.module("transactionModule", ['validator', 'angular.filter', 'ngQuill']);

transactionModule.service("transactionSaleWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , transactionSaleWebService]);



baseModule.requires.push("transactionModule");