class transactionSaleWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService) {
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

    public loadList(transactionSaleListingSortingPagingInfo: transactionSaleListingSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<transactionModel[]>>> {
        var url = 'Transaction/TransactionSale/LoadList';
        var data = transactionSaleListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadListPerCustomer(transactionSaleListingSortingPagingInfo: transactionSaleListingSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<transactionModel[]>>> {
        var url = 'Transaction/TransactionSale/LoadListPerCustomer';
        var data = transactionSaleListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getTransactionList(transactionListSortingPagingInfo: transactionListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<transactionModel[]>>> {
        var url = 'Transaction/Transaction/GetAllScheduledTransactionList';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getAllTransactionListPerCustomer(transactionListSortingPagingInfo: transactionListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<transactionModel[]>>> {
        var url = 'Transaction/Transaction/GetAllTransactionsPerCustomer';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getAllScheduledTransactionListPerCustomer(transactionListSortingPagingInfo: transactionListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<transactionModel[]>>> {
        var url = 'Transaction/Transaction/GetAllScheduledTransactionsPerCustomer';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public sendEmailToClient(sendEmailToClientDto: sendEmailToClientDto): ng.IPromise<baseResultReturnType<boolean>> {
        var url = 'Transaction/Transaction/SendEmailToClient';
        var data = sendEmailToClientDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public showMyTransaction() {
        var url = 'Transaction/Transaction/GetTransactionTotalForDate';
        return this.genericWebConnectionService.downloadRequest(url, {});
    }

    public saveTemporaryTransaction(saveTemporaryTransactionDto: saveTemporaryTransactionDto): ng.IPromise<baseResultReturnType<saveTemporaryTransactionReturnType>> {
        var url = 'Transaction/Transaction/SaveTemporaryTransaction';
        var data = saveTemporaryTransactionDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getTemporaryTransactionOrderForWorkstation(getTemporaryTransactionSignatureForWorkstationDto: getTemporaryTransactionSignatureForWorkstationDto): ng.IPromise<baseResultReturnType<getTemporaryTransactionSignatureForWorkstationReturnType>> {
        var url = 'Transaction/Transaction/GetTemporaryTransactionOrderForWorkstation';
        var data = getTemporaryTransactionSignatureForWorkstationDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getSignatureForTemporaryTransactionSignature(getSignatureForTemporaryTransactionSignatureDto: getSignatureForTemporaryTransactionSignatureDto): ng.IPromise<baseResultReturnType<getSignatureForTemporaryTransactionSignatureReturnType>> {
        var url = 'Transaction/Transaction/GetSignatureForTemporaryTransactionSignature';
        var data = getSignatureForTemporaryTransactionSignatureDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getEmailForTransaction(getEmailForTransaction: getEmailForTransactionDto): ng.IPromise<baseResultReturnType<getEmailForTransactionReturnType>> {
        var url = 'Transaction/Transaction/GetEmailForTransaction';
        var data = getEmailForTransaction;
        return this.genericWebConnectionService.postRequest(url, data);
    };

    public saveEmailForTransaction(saveEmailForTransactionDto: saveEmailForTransactionDto): ng.IPromise<baseResultReturnType<saveEmailForTransactionReturnType>> {
        var url = 'Transaction/Transaction/SaveEmailForTransaction';
        var data = saveEmailForTransactionDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
}
