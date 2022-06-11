var subscriptionWebService = /** @class */ (function () {
    function subscriptionWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    subscriptionWebService.prototype.getCustomerList = function (customerListSortingPagingInfo) {
        var url = 'Subscription/Subscription/GetCustomerList';
        var data = customerListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.getProductList = function (productListSortingPagingInfo) {
        var url = 'Subscription/Subscription/GetProductList';
        var data = productListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.getPaymentDueDetails = function (getPaymentDueDetailDto) {
        var url = 'Subscription/Subscription/GetPaymentDueDetail';
        var data = getPaymentDueDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.getScheduledTransaction = function (getPaymentDueDetailDto) {
        var url = 'Transaction/Transaction/GetScheduledTransaction';
        var data = getPaymentDueDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.getLastPaymentDateForCustomer = function (getLastPaymentDateForCustomerDto) {
        var url = 'Subscription/Subscription/GetLastPaymentDateForCustomer';
        var data = getLastPaymentDateForCustomerDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.getScheduledTransactionPayments = function (getPaymentDueDetailDto) {
        var url = 'Transaction/Transaction/GetScheduledTransactionPayments';
        var data = getPaymentDueDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.savePaymentForTransactionDue = function (savePaymentForTransactionDueDto) {
        var url = 'Transaction/Transaction/SavePaymentForTransactionDue';
        var data = savePaymentForTransactionDueDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.saveTransactionPayment = function (saveTransactionPaymentDto) {
        var url = 'Transaction/Transaction/SaveTransactionPayment';
        var data = saveTransactionPaymentDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.saveScheduledTransaction = function (saveScheduledTransactionDto) {
        var url = 'Transaction/Transaction/SaveScheduledTransaction';
        var data = saveScheduledTransactionDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    subscriptionWebService.prototype.getTransactionList = function (transactionListSortingPagingInfo) {
        var url = 'Transaction/Transaction/GetAllScheduledTransactionList';
        var data = transactionListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return subscriptionWebService;
}());
//# sourceMappingURL=subscription-web-service.js.map