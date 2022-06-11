class subscriptionWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }

    public getCustomerList(customerListSortingPagingInfo: customerListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<customerModel[]>>> {
        var url = 'Subscription/Subscription/GetCustomerList';
        var data = customerListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getProductList(productListSortingPagingInfo: productListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<productModel[]>>> {
        var url = 'Subscription/Subscription/GetProductList';
        var data = productListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getPaymentDueDetails(getPaymentDueDetailDto: getPaymentDueDetailDto): ng.IPromise<baseResultReturnType<getPaymentDueDetailReturnType>> {
        var url = 'Subscription/Subscription/GetPaymentDueDetail';
        var data = getPaymentDueDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getScheduledTransaction(getPaymentDueDetailDto: getScheduledTransactionDto): ng.IPromise<baseResultReturnType<getScheduledTransactionReturnType>> {
        var url = 'Transaction/Transaction/GetScheduledTransaction';
        var data = getPaymentDueDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getLastPaymentDateForCustomer(getLastPaymentDateForCustomerDto: getLastPaymentDateForCustomerDto): ng.IPromise<baseResultReturnType<getLastPaymentDateForCustomerReturnType>> {
        var url = 'Subscription/Subscription/GetLastPaymentDateForCustomer';
        var data = getLastPaymentDateForCustomerDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getScheduledTransactionPayments(getPaymentDueDetailDto: getScheduledTransactionDto): ng.IPromise<baseResultReturnType<transactionModel>> {
        var url = 'Transaction/Transaction/GetScheduledTransactionPayments';
        var data = getPaymentDueDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public savePaymentForTransactionDue(savePaymentForTransactionDueDto: savePaymentForTransactionDueDto): ng.IPromise<baseResultReturnType<paymentModel>> {
        var url = 'Transaction/Transaction/SavePaymentForTransactionDue';
        var data = savePaymentForTransactionDueDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public saveTransactionPayment(saveTransactionPaymentDto: saveTransactionPaymentDto): ng.IPromise<baseResultReturnType<saveTransactionPaymentReturnType>> {
        var url = 'Transaction/Transaction/SaveTransactionPayment';
        var data = saveTransactionPaymentDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public saveScheduledTransaction(saveScheduledTransactionDto: saveScheduledTransactionDto): ng.IPromise<baseResultReturnType<saveScheduledTransactionReturnType>> {
        var url = 'Transaction/Transaction/SaveScheduledTransaction';
        var data = saveScheduledTransactionDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getTransactionList(transactionListSortingPagingInfo: transactionListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<transactionModel[]>>> {
        var url = 'Transaction/Transaction/GetAllScheduledTransactionList';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }
}