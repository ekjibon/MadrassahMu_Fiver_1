var transactionSaleController = /** @class */ (function () {
    function transactionSaleController($scope, subscriptionWebService, transactionSaleWebService) {
        this.menuList = [Menu.SELECT_TRANSACTION, Menu.DEFINE_PAYMENT, Menu.SUMMARY];
        this.isCustomerNull = true;
        this.formName = "transactionSaleForm";
        this.childControllers = [];
        this.temporaryTransactionOrder = null;
        this.signatureImage = null;
        $scope.indexController = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.subscriptionWebService = subscriptionWebService;
        this.transactionSaleWebService = transactionSaleWebService;
        this.initialize();
        this.registerValidations();
    }
    transactionSaleController.prototype.registerSelectCustomerController = function (selectCustomerController) {
        var self = this;
        self.selectCustomerController = selectCustomerController;
        self.selectCustomerController.formName = self.formName;
        self.selectCustomerController.registerValidation();
        self.childControllers.push(self.selectCustomerController);
    };
    transactionSaleController.prototype.registerSelectTransactionController = function (selectTransactionController) {
        var self = this;
        self.selectTransactionController = selectTransactionController;
        self.selectTransactionController.formName = self.formName;
        self.selectTransactionController.registerValidation();
        self.childControllers.push(self.selectTransactionController);
    };
    transactionSaleController.prototype.registerDefinePaymentController = function (paymentController) {
        var self = this;
        self.paymentController = paymentController;
        self.paymentController.formName = self.formName;
        self.paymentController.registerValidation();
        self.childControllers.push(self.paymentController);
    };
    transactionSaleController.prototype.registerSummaryController = function (summaryController) {
        var self = this;
        self.summaryController = summaryController;
    };
    transactionSaleController.prototype.totalTransactionAmount = function () {
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
    transactionSaleController.prototype.totalAmountPaid = function () {
        var self = this;
        var amountPaid = 0;
        if (self.paymentController !== undefined) {
            for (var i = 0; i < self.paymentController.paymentDetails.length; i++) {
                amountPaid += self.paymentController.paymentDetails[i].paymentAmount;
            }
        }
        return amountPaid;
    };
    transactionSaleController.prototype.initialize = function () {
        var self = this;
        self.screenModeManager = new screenModeManager(self, null, false);
        self.screenModeManager.entity = new transactionEntityModel();
        var transaction = new transactionModel();
        transaction.transactionDate = dateParser.dateParserScreenMode(null, new Date());
        var transactionDetails = new Array();
        transaction.transactionDetails = transactionDetails;
        transaction.idTransactionType = 2;
        self.screenModeManager.entity.transaction = transaction;
        var payment = new paymentModel();
        var paymentDetails = new Array();
        self.screenModeManager.entity.paymentDetails = paymentDetails;
        self.menuEnum = Menu;
        self.selectedMenu = Menu.SELECT_TRANSACTION;
        self.mode = SCREEN_MODE;
    };
    Object.defineProperty(transactionSaleController.prototype, "transaction", {
        get: function () {
            return this.screenModeManager.entity.transaction;
        },
        set: function (transactionModel) {
            this.screenModeManager.entity.transaction = transactionModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(transactionSaleController.prototype, "transactionDue", {
        get: function () {
            return this.screenModeManager.entity.transactionDue;
        },
        set: function (transactionDue) {
            this.screenModeManager.entity.transactionDue = transactionDue;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(transactionSaleController.prototype, "selectedCustomer", {
        get: function () {
            return this.screenModeManager.entity.transaction.customer;
        },
        set: function (customerModel) {
            this.screenModeManager.entity.transaction.customer = customerModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(transactionSaleController.prototype, "paymentDetails", {
        get: function () {
            return this.screenModeManager.entity.paymentDetails;
        },
        set: function (paymentDetailModel) {
            this.screenModeManager.entity.paymentDetails = paymentDetailModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(transactionSaleController.prototype, "currentMode", {
        get: function () {
            return this.screenModeManager.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    transactionSaleController.prototype.setInfo = function (idTransaction, idTransactionDue, mode) {
        var self = this;
        self.screenModeManager.currentMode = mode;
        if (self.screenModeManager.currentMode == SCREEN_MODE.VIEW) {
            self.selectedMenu = Menu.SUMMARY;
        }
        if (idTransaction !== -1 && idTransaction >= 0) {
            self.idTransaction = idTransaction;
            self.idTransactionDue = idTransactionDue;
            self.loadEntity();
        }
    };
    transactionSaleController.prototype.loadEntity = function () {
        var self = this;
        self.baseController.showLoading();
        var _getPaymentDueDetailDto = new getPaymentDueDetailDto();
        _getPaymentDueDetailDto.idTransaction = self.idTransaction;
        self.subscriptionWebService.getScheduledTransaction(_getPaymentDueDetailDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.transaction = response.result.transaction;
                self.transaction.idTransactionType = 2; //Converts the scheduled transaction into a transaction
                self.transaction.transactionDate = dateParser.dateParserScreenMode(null, response.result.transaction.transactionDate);
                self.transaction.transactionDues.forEach(function (transactionDue) {
                    if (transactionDue.idTransactionDue == self.idTransactionDue) {
                        self.transactionDue = transactionDue;
                    }
                });
                if (response.result.transaction.payments.length != 0) {
                    self.paymentDetails = response.result.transaction.payments[0].paymentDetails;
                }
                self.selectedCustomer = response.result.transaction.customer;
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
    transactionSaleController.prototype.selectMenu = function (getMenu) {
        var self = this;
        switch (getMenu) {
            /*case Menu.SELECT_CUSTOMER:
                self.selectedMenu = Menu.SELECT_CUSTOMER;
                break*/
            case Menu.SELECT_TRANSACTION:
                self.selectedMenu = Menu.SELECT_TRANSACTION;
                break;
            case Menu.DEFINE_PAYMENT:
                self.selectedMenu = Menu.DEFINE_PAYMENT;
                break;
            case Menu.SUMMARY:
                self.selectedMenu = Menu.SUMMARY;
                break;
        }
    };
    transactionSaleController.prototype.registerValidations = function () {
        var self = this;
        /*for (var i = 0; i < self.childControllers.length; i++) {
            var currentChild = self.childControllers[i];
            currentChild.registerValidations();
        }*/
    };
    transactionSaleController.prototype.validateForGroups = function () {
        var self = this;
        var isValid = true;
        var formScope = self.scope['scheduledTransactionForm'];
        var errorMessages = [];
        /*for (var i = 0; i < self.childControllers.length; i++) {
            var currentChild = self.childControllers[i];
            isValid = isValid && currentChild.formValidator.validateGroup(currentChild.groupName, false, true);
            errorMessages = errorMessages.concat(currentChild.formValidator.getAllValidationMessagesForGroup(currentChild.groupName));
        }*/
        if (errorMessages.length > 0) {
            //self.baseController.toaster.pop({
            //   type: 'error',
            //   body: errorMessages.join('</br>'),
            //   bodyOutputType: 'trustedHtml'
            //});
            self.baseController.showMessage(errorMessages.join('\n'), 'ERROR', ALERT_MESSAGE_TYPE.ERROR);
            console.log("PAS BONNN");
        }
        return isValid;
    };
    transactionSaleController.prototype.validateChild = function (selectedMenu) {
        var self = this;
        /*if (selectedMenu == Menu.SELECT_CUSTOMER) {
            return self.selectCustomerController.validateForGroup();
        }*/
        if (selectedMenu == Menu.SELECT_TRANSACTION) {
            return self.selectTransactionController.validateForGroup();
        }
        if (selectedMenu == Menu.DEFINE_PAYMENT) {
            return self.paymentController.validateForGroup();
        }
    };
    transactionSaleController.prototype.back = function () {
        var self = this;
        if (self.menuList.indexOf(self.selectedMenu) !== 0) {
            self.selectedMenu = self.menuList[self.menuList.indexOf(self.selectedMenu) - 1];
        }
    };
    transactionSaleController.prototype.next = function () {
        var self = this;
        if (self.validateChild(self.selectedMenu)) {
            self.selectedMenu = self.menuList[self.menuList.indexOf(self.selectedMenu) + 1];
        }
    };
    transactionSaleController.prototype.printReceipt = function () {
        var self = this;
        var printUrl = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSalePrint/" + self.transaction.idTransaction + "/0/";
        var printWindow = window.open(printUrl, "printWindow", "width=1000,height=650");
        printWindow.print();
    };
    transactionSaleController.prototype.signReceipt = function () {
        var self = this;
        console.log(JSON.stringify(self.screenModeManager.entity));
        var idWorkstation = self.baseController.$localStorage.getItem(localStorageKey.IdWorkstation);
        if (self.baseController.isNullOrUndefined(idWorkstation)) {
            self.baseController.showMessage("Cannot perform signature connection to device. No workstation id is set. Please log out and login again to set workstation id", "", ALERT_MESSAGE_TYPE.ERROR);
            return;
        }
        self.baseController.showLoading();
        var _saveTemporaryTransactionDto = new saveTemporaryTransactionDto();
        _saveTemporaryTransactionDto.temporaryTransaction = new temporaryTransactionOrderModel();
        _saveTemporaryTransactionDto.temporaryTransaction.idTemporaryTransactionOrderState = signatureStateEnum.AWAITING_SIGNATURE;
        _saveTemporaryTransactionDto.temporaryTransaction.temporaryTransactionOrderDate = new Date();
        _saveTemporaryTransactionDto.temporaryTransaction.idWorkstation = idWorkstation;
        _saveTemporaryTransactionDto.temporaryTransaction.transactionJson = JSON.stringify(self.screenModeManager.entity);
        self.transactionSaleWebService.saveTemporaryTransaction(_saveTemporaryTransactionDto)
            .then(function (response) {
            self.baseController.hideLoading();
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.baseController.showMessage("Your order id is " + response.result.temporaryTransaction.idTemporaryTransactionOrder, "", ALERT_MESSAGE_TYPE.SUCCESS);
                self.temporaryTransactionOrder = response.result.temporaryTransaction;
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.hideLoading();
            self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
        });
    };
    transactionSaleController.prototype.reloadSignature = function () {
        var self = this;
        if (self.baseController.isNullOrUndefined(self.temporaryTransactionOrder)) {
            self.baseController.showMessage("No signature has been initialized, please click on sign in to proceed", "", ALERT_MESSAGE_TYPE.ERROR);
            return;
        }
        self.baseController.showLoading();
        var _getSignatureForTemporaryTransactionSignature = new getSignatureForTemporaryTransactionSignatureDto();
        _getSignatureForTemporaryTransactionSignature.idTemporaryTransaction = self.temporaryTransactionOrder.idTemporaryTransactionOrder;
        self.transactionSaleWebService.getSignatureForTemporaryTransactionSignature(_getSignatureForTemporaryTransactionSignature)
            .then(function (response) {
            self.baseController.hideLoading();
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.temporaryTransactionOrder.document = response.result.signatureDocument;
                self.signatureImage = self.baseController.getGenericFileThumbnailFromExtension(self.temporaryTransactionOrder.document);
                //document.getElementById("signaturePreview").setAttribute('src', self.baseController.getGenericFileThumbnailFromExtension(self.temporaryTransactionSignature.document));
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.hideLoading();
            self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    transactionSaleController.prototype.sendEmail = function () {
        var self = this;
        var _sendEmailToClientDto = new sendEmailToClientDto();
        _sendEmailToClientDto.idTransaction = self.screenModeManager.entity.transaction.idTransaction;
        self.baseController.showLoading();
        self.transactionSaleWebService.sendEmailToClient(_sendEmailToClientDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.baseController.showMessage("", "Email sent", ALERT_MESSAGE_TYPE.SUCCESS);
            }
            else {
                self.baseController.showMessage(response.errorMessage, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }
            self.baseController.hideLoading();
        }).catch(function (errorMsg) {
            self.baseController.hideLoading();
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
        });
    };
    transactionSaleController.prototype.submit = function () {
        var self = this;
        self.baseController.showLoading();
        self.validateForGroups();
        var _saveTransactionPaymentDto = new saveTransactionPaymentDto();
        _saveTransactionPaymentDto.paymentDetails = self.paymentDetails;
        _saveTransactionPaymentDto.transaction = self.transaction;
        if (!self.baseController.isNullOrUndefined(self.temporaryTransactionOrder) && !self.baseController.isNullOrUndefined(self.temporaryTransactionOrder.idTemporaryTransactionOrder)) {
            _saveTransactionPaymentDto.idTemporaryTransactionSignature = self.temporaryTransactionOrder.idTemporaryTransactionOrder;
        }
        if (self.transactionDue == null || self.transaction == undefined) {
            _saveTransactionPaymentDto.transactionDue = null;
        }
        else {
            _saveTransactionPaymentDto.transactionDue = self.transactionDue;
        }
        self.subscriptionWebService.saveTransactionPayment(_saveTransactionPaymentDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.saveTransactionPaymentReturnType = response.result; //To evaluate whether is important
                self.transaction.idTransaction = response.result.transaction.idTransaction;
                self.printReceipt();
                self.baseController.showMessage('Save Successful', 'Success', ALERT_MESSAGE_TYPE.SUCCESS, null, function () {
                    self.sendEmail();
                    window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/" + SCREEN_MODE.ADD + "/";
                });
            }
            else {
            }
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    transactionSaleController.prototype.onOkToModal = function () {
        var self = this;
        self.registerValidations();
        if (!self.validateForGroups()) {
            self.screenModeManager.setMode(SCREEN_MODE.EDIT);
            return;
        }
        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.TRANSFER, "TRANSACTION", self.screenModeManager.entity);
        self.scope.$close(self.baseController.globalVariableFactory.sessionVariables);
    };
    transactionSaleController.prototype.onCancelToModal = function () {
        var self = this;
        self.scope.$dismiss();
    };
    return transactionSaleController;
}());
transactionModule.controller("transactionSaleController", ["$scope",
    "subscriptionWebService",
    "transactionSaleWebService",
    transactionSaleController
]);
//# sourceMappingURL=transaction-sale-controller.js.map