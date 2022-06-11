var paymentScheduledTransactionController = /** @class */ (function () {
    function paymentScheduledTransactionController($scope, subscriptionWebService) {
        this.test = "waaaaaaaaaaaa";
        $scope.controller = this;
        this.scope = $scope;
        this.subscriptionWebService = subscriptionWebService;
        this.callerController = $scope.indexController;
        this.baseController = $scope.baseController;
        //this.initialize();
    }
    paymentScheduledTransactionController.prototype.initialize = function () {
        var self = this;
        self.callerController.registerPaymentScheduledTransactionController(this);
        self.loadScheduledTransactions();
    };
    paymentScheduledTransactionController.prototype.selectMenu = function (getMenu) {
        var self = this;
        switch (getMenu) {
            case Menu.SUMMARY:
                self.selectedMenu = Menu.SUMMARY;
                break;
            case Menu.PAYMENT_SCHEDULE_DETAILS:
                self.selectedMenu = Menu.PAYMENT_SCHEDULE_DETAILS;
                break;
            case Menu.DEFINE_PAYMENT:
                self.selectedMenu = Menu.DEFINE_PAYMENT;
                console.log('p rentrer');
                break;
        }
    };
    paymentScheduledTransactionController.prototype.loadScheduledTransactions = function () {
        var self = this;
        console.log(self.callerController.transactionDues);
        self.transactionDues = self.callerController.transactionDues;
    };
    paymentScheduledTransactionController.prototype.settlePayment = function (transactionDue, screenMode) {
        var self = this;
        /* var _savePaymentForTransactionDueDto = new savePaymentForTransactionDueDto();
         _savePaymentForTransactionDueDto.transactionDues = new Array<transactionDueModel>();
         self.subscriptionWebService.savePaymentForTransactionDue(_savePaymentForTransactionDueDto)
             .then(function (response: baseResultReturnType<paymentModel>) {
                 if (response.status == STATUS_MESSAGE.SUCCESS) {
                     self.payment = response.result;
                     console.log(self.payment);
                 }
             }).catch(function (errorMsg) {
                 self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
             }).finally(function () {
             });*/
    };
    paymentScheduledTransactionController.prototype.calculateArrears = function (_transactionDue) {
        var self = this;
        var _amountDue = _transactionDue.amountDue;
        // var _amountPaid = _transactionDue.transaction.totalAmount;
        //var _arrears = _amountPaid - _amountDue;
        return self.callerController.transaction.totalAmount - _transactionDue.amountDue;
    };
    paymentScheduledTransactionController.prototype.getTotalArrearsToDate = function () {
        var self = this;
        // return self.callerController.transactionDues.entityList.filter(due => new Date(due.dueDate).getDate() <= new Date().getDate()).reduce((prev, curr) => prev + curr.amountRemaining, 0);
        return 0;
    };
    paymentScheduledTransactionController.prototype.getLastPaymentDate = function () {
        var self = this;
        if (self.callerController.lastPaymentDate == null) {
            return 'No Payment Done Till Date.';
        }
        return self.callerController.lastPaymentDate.toString();
    };
    paymentScheduledTransactionController.prototype.calculateTotalAmountDue = function () {
        var self = this;
        return self.callerController.transactionDues.reduce(function (prev, curr) { return prev + curr.amountDue; }, 0);
        // return 0;
    };
    paymentScheduledTransactionController.prototype.calculateTotalAmountRemaining = function () {
        var self = this;
        return self.callerController.transactionDues.reduce(function (prev, curr) { return prev + curr.amountRemaining; }, 0);
        //return 0;
    };
    paymentScheduledTransactionController.prototype.selectTransaction = function (transaction, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/Index/" + transaction.idTransaction + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/Index/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    paymentScheduledTransactionController.prototype.isTransactionScheduled = function () {
        var self = this;
        if (self.callerController.transaction.idTransactionType == 2) {
            return false;
        }
        return true;
    };
    return paymentScheduledTransactionController;
}());
paymentScheduledTransactionModule.controller("paymentScheduledTransactionController", ["$scope",
    "subscriptionWebService",
    paymentScheduledTransactionController
]);
//# sourceMappingURL=payment-scheduled-transaction-controller.js.map