var viewScheduledTransactionController = /** @class */ (function () {
    function viewScheduledTransactionController($scope, subscriptionWebService) {
        this.testa = "vstcontroller";
        $scope.indexController = this;
        this.scope = $scope;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.initialize();
    }
    viewScheduledTransactionController.prototype.registerSummaryController = function (summaryController) {
        var self = this;
        self.summaryController = summaryController;
    };
    viewScheduledTransactionController.prototype.registerPaymentScheduledTransactionController = function (paymentScheduledTransactionController) {
        var self = this;
        self.paymentScheduledTransactionController = paymentScheduledTransactionController;
    };
    viewScheduledTransactionController.prototype.totalTransactionAmount = function () {
        var self = this;
        var total = 0;
        if (self.transaction !== undefined && self.transaction.transactionDetails !== undefined) {
            for (var i = 0; i < self.transaction.transactionDetails.length; i++) {
                var product = self.transaction.transactionDetails[i];
                total += (product.rate * product.quantity);
            }
        }
        return total;
    };
    Object.defineProperty(viewScheduledTransactionController.prototype, "transaction", {
        get: function () {
            return this.screenModeManager.entity.transaction;
        },
        set: function (transactionModel) {
            this.screenModeManager.entity.transaction = transactionModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(viewScheduledTransactionController.prototype, "payments", {
        get: function () {
            if (this.screenModeManager.entity.payments != undefined)
                return this.screenModeManager.entity.payments;
        },
        set: function (paymentModel) {
            if (paymentModel != undefined)
                this.screenModeManager.entity.payments = paymentModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(viewScheduledTransactionController.prototype, "frequency", {
        get: function () {
            return this.screenModeManager.entity.frequency;
        },
        set: function (frequency) {
            this.screenModeManager.entity.frequency = frequency;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(viewScheduledTransactionController.prototype, "currentMode", {
        get: function () {
            return this.screenModeManager.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(viewScheduledTransactionController.prototype, "transactionDues", {
        get: function () {
            return this.screenModeManager.entity.transactionDues;
        },
        set: function (transactionDues) {
            this.screenModeManager.entity.transactionDues = transactionDues;
        },
        enumerable: false,
        configurable: true
    });
    viewScheduledTransactionController.prototype.initialize = function () {
        var self = this;
        self.screenModeManager = new screenModeManager(self, null, false);
        self.screenModeManager.entity = new subscriptionModel();
        var transaction = new transactionModel();
        var transactionDetails = new Array();
        transaction.transactionDetails = transactionDetails;
        self.screenModeManager.entity.transaction = transaction;
        var transactionDues = new Array();
        self.screenModeManager.entity.transaction.transactionDues = transactionDues;
        var transactionDues2 = new Array();
        self.screenModeManager.entity.transactionDues = transactionDues2;
        var payments = new Array();
        payments.push(new paymentModel());
        payments[0].paymentDetails = new Array();
        self.screenModeManager.entity.transaction.payments = payments;
        var paymentsForScheduledTransaction = new Array();
        self.screenModeManager.entity.payments = paymentsForScheduledTransaction;
        var frequency = new defineFrequencyModel();
        self.screenModeManager.entity.frequency = frequency;
        self.menuEnum = Menu;
        self.selectedMenu = Menu.SUMMARY;
    };
    viewScheduledTransactionController.prototype.setInfo = function (id, mode) {
        var self = this;
        self.screenModeManager.currentMode = mode;
        if (id !== -1 && id >= 0) {
            self.idTransaction = id;
            self.loadEntity();
            self.loadPaymentEntity();
        }
        console.log('id: ' + id);
    };
    viewScheduledTransactionController.prototype.selectMenu = function (getMenu) {
        var self = this;
        switch (getMenu) {
            case Menu.SUMMARY:
                self.selectedMenu = Menu.SUMMARY;
                break;
            case Menu.PAYMENT_SCHEDULE_DETAILS:
                self.selectedMenu = Menu.PAYMENT_SCHEDULE_DETAILS;
                console.log('p rentrer');
                break;
            case Menu.DEFINE_PAYMENT:
                self.selectedMenu = Menu.DEFINE_PAYMENT;
                console.log('p rentrer');
                break;
        }
    };
    viewScheduledTransactionController.prototype.loadEntity = function () {
        var self = this;
        self.baseController.showLoading();
        var _getPaymentDueDetailDto = new getScheduledTransactionDto();
        _getPaymentDueDetailDto.idTransaction = self.idTransaction;
        self.subscriptionWebService.getScheduledTransaction(_getPaymentDueDetailDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.screenModeManager.entity.transaction = response.result.transaction;
                self.screenModeManager.entity.transaction.transactionDate = dateParser.dateParserScreenMode(null, response.result.transaction.transactionDate);
                self.screenModeManager.entity.transactionDues = response.result.transactionDues.entityList;
                if (response.result.transaction.scheduleSettings.length > 0) {
                    self.screenModeManager.entity.frequency.selectedmonthlyDates = response.result.transaction.scheduleSettings[0].monthOnSpecificDays;
                    self.screenModeManager.entity.frequency.recurEvery = response.result.transaction.scheduleSettings[0].reccurEvery;
                    self.screenModeManager.entity.frequency.selectedMonths = response.result.transaction.scheduleSettings[0].monthOccurs;
                    self.screenModeManager.entity.frequency.frequency = response.result.transaction.scheduleSettings[0].idFrequency;
                    self.screenModeManager.entity.frequency.startDate = response.result.transaction.scheduleSettings[0].startDate;
                    self.screenModeManager.entity.frequency.endDate = response.result.transaction.scheduleSettings[0].endDate;
                }
                if (self.paymentScheduledTransactionController != undefined) {
                    self.paymentScheduledTransactionController.loadScheduledTransactions();
                }
                self.loadLastPaymentDateForCustomer(self.screenModeManager.entity.transaction.customer.idCustomer, self.screenModeManager.entity.transaction.idTransaction);
                console.log(response.result);
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    viewScheduledTransactionController.prototype.loadPaymentEntity = function () {
        var self = this;
        self.baseController.showLoading();
        var _getPaymentDueDetailDto = new getScheduledTransactionDto();
        _getPaymentDueDetailDto.idTransaction = self.idTransaction;
        self.subscriptionWebService.getScheduledTransactionPayments(_getPaymentDueDetailDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.screenModeManager.entity.payments = response.result.payments;
                console.log(response.result);
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    viewScheduledTransactionController.prototype.loadLastPaymentDateForCustomer = function (idCustomer, idTransaction) {
        var self = this;
        self.baseController.showLoading();
        var _getLastPaymentDateForCustomerDto = new getLastPaymentDateForCustomerDto();
        _getLastPaymentDateForCustomerDto.idCustomer = self.transaction.idCustomer;
        _getLastPaymentDateForCustomerDto.idTransaction = self.transaction.idTransaction;
        self.subscriptionWebService.getLastPaymentDateForCustomer(_getLastPaymentDateForCustomerDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.lastPaymentDate = response.result.capturedDate;
                console.log(response.result);
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    viewScheduledTransactionController.prototype.editTransaction = function (idTransaction, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ScheduleTransactionSale/" + idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ScheduleTransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    viewScheduledTransactionController.prototype.goToPaymentScreen = function (transactionDue, screenMode) {
        var self = this;
        console.log(transactionDue);
        //self.screenModeManager.entity.transaction.transactionDues[0] = transactionDue;
        //self.selectMenu(Menu.DEFINE_PAYMENT);
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transactionDue.idTransaction + "/" + transactionDue.idTransactionDue + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    viewScheduledTransactionController.prototype.settlePayment = function (idTransaction, idTransactionDue, screenMode) {
        var self = this;
        /* var _savePaymentForTransactionDueDto = new savePaymentForTransactionDueDto();
         _savePaymentForTransactionDueDto.transactionDues = new Array<transactionDueModel>();
         _savePaymentForTransactionDueDto.transactionDues = self.screenModeManager.entity.transaction.transactionDues;
         _savePaymentForTransactionDueDto.paymentDetails = self.screenModeManager.entity.transaction.payments[0].paymentDetails;
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
        /*if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + idTransaction + "/" + idTransactionDue + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/Index/-1/-1/" + SCREEN_MODE.ADD + "/";
        }*/
    };
    viewScheduledTransactionController.prototype.back = function () {
    };
    viewScheduledTransactionController.prototype.next = function () {
    };
    return viewScheduledTransactionController;
}());
viewScheduledTransactionModule.controller("viewScheduledTransactionController", ["$scope",
    "subscriptionWebService",
    viewScheduledTransactionController
]);
//# sourceMappingURL=view-scheduled-transactions-controller.js.map