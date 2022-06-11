var selectCustomerModule = angular.module("selectCustomerModule", []);

selectCustomerModule.service("subscriptionWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , subscriptionWebService
    ]);

selectCustomerModule.service("transactionSaleWebService"
    , ["genericWebConnectionService"
        , "globalVariableFactory"
        , transactionSaleWebService
    ]);

scheduleTransactionModule.requires.push('selectCustomerModule');