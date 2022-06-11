var transactionSaleWebService = /** @class */ (function () {
    function transactionSaleWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    /*public getTransactionSaleScreenConstant(): ng.IPromise<baseResultReturnType<transactionSaleScreenContantReturnType>> {
        var url = 'Transaction/TransactionSale/GetTransactionSaleScreenConstant';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getTransactionSale(getTransactionSaleDto: getTransactionSaleDto): ng.IPromise<baseResultReturnType<getTransactionSaleReturnType>> {
        var url = 'Transaction/TransactionSale/GetTransactionSale';
        var data = getTransactionSaleDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadNextTrasactionId(getTransactionSaleDto: getTransactionSaleDto): ng.IPromise<baseResultReturnType<loadNextTrasactionIdReturnType>> {
        var url = 'Transaction/TransactionSale/LoadNextTrasactionId';
        var data = getTransactionSaleDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public saveTransactionSale(saveTransactionSaleDto: saveTransactionSaleDto): ng.IPromise<baseResultReturnType<saveTransactionSaleReturnType>> {
        var url = 'Transaction/TransactionSale/SaveTransactionSale';
        var data = saveTransactionSaleDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }*/
    transactionSaleWebService.prototype.loadList = function (transactionSaleListingSortingPagingInfo) {
        var url = 'Transaction/TransactionSale/LoadList';
        var data = transactionSaleListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.loadListPerCustomer = function (transactionSaleListingSortingPagingInfo) {
        var url = 'Transaction/TransactionSale/LoadListPerCustomer';
        var data = transactionSaleListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.getTransactionList = function (transactionListSortingPagingInfo) {
        var url = 'Transaction/Transaction/GetAllScheduledTransactionList';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.getAllTransactionListPerCustomer = function (transactionListSortingPagingInfo) {
        var url = 'Transaction/Transaction/GetAllTransactionsPerCustomer';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.getAllScheduledTransactionListPerCustomer = function (transactionListSortingPagingInfo) {
        var url = 'Transaction/Transaction/GetAllScheduledTransactionsPerCustomer';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.sendEmailToClient = function (sendEmailToClientDto) {
        var url = 'Transaction/Transaction/SendEmailToClient';
        var data = sendEmailToClientDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.showMyTransaction = function () {
        var url = 'Transaction/Transaction/GetTransactionTotalForDate';
        return this.genericWebConnectionService.downloadRequest(url, {});
    };
    transactionSaleWebService.prototype.saveTemporaryTransaction = function (saveTemporaryTransactionDto) {
        var url = 'Transaction/Transaction/SaveTemporaryTransaction';
        var data = saveTemporaryTransactionDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.getTemporaryTransactionOrderForWorkstation = function (getTemporaryTransactionSignatureForWorkstationDto) {
        var url = 'Transaction/Transaction/GetTemporaryTransactionOrderForWorkstation';
        var data = getTemporaryTransactionSignatureForWorkstationDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.getSignatureForTemporaryTransactionSignature = function (getSignatureForTemporaryTransactionSignatureDto) {
        var url = 'Transaction/Transaction/GetSignatureForTemporaryTransactionSignature';
        var data = getSignatureForTemporaryTransactionSignatureDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    transactionSaleWebService.prototype.getEmailForTransaction = function (getEmailForTransaction) {
        var url = 'Transaction/Transaction/GetEmailForTransaction';
        var data = getEmailForTransaction;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    ;
    transactionSaleWebService.prototype.saveEmailForTransaction = function (saveEmailForTransactionDto) {
        var url = 'Transaction/Transaction/SaveEmailForTransaction';
        var data = saveEmailForTransactionDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    ;
    return transactionSaleWebService;
}());
//# sourceMappingURL=transaction-sale-web-service.js.map