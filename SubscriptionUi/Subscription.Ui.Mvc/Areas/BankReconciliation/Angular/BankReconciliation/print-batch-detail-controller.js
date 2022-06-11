var printBatchDetailDetailController = (function () {
    function printBatchDetailDetailController($scope, transactionSaleWebService) {
        this.shouldReloadScreen = false;
        this.preloadedData = {
            transactionClasses: [],
            transactionTemplates: [],
            transactionAccounts: [],
            paymentMethods: []
        };
        this.childControllers = [];
        this.hasTransactionDetailBeenLoaded = false;
        this.hasScreenDetailBeenLoaded = false;
        this.currentTabShown = transactionSaleTab.BASIC;
        this.formName = 'transactionForm';
        this.printUrl = "";
        this.isPrintingEnabled = false;
        this.isProductEditable = true;
        this.isCustomerEditable = true;
        this.isSubSection = false;
        this.temporaryTransactionSignature = null;
        var self = this;
        $scope.controller = this;
        this.transactionSaleWebService = transactionSaleWebService;
        this.scope = $scope;
        this.baseController = this.scope.baseController;
        this.initVariables();
        this.registerValidations();
        self.baseController.initializeSignalR(self.baseController.globalVariableFactory.loggedInUserDetail.idUser + "", SIGNALR_CONNECTION_TYPE.USER);
    }
    Object.defineProperty(printBatchDetailDetailController.prototype, "screenMode", {
        get: function () {
            return this.screenModeManager.currentMode;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(printBatchDetailDetailController.prototype, "customer", {
        get: function () {
            return this.callerController.screenModeManager.entity;
        },
        enumerable: true,
        configurable: true
    });
    printBatchDetailDetailController.prototype.registerTransactionSaleDetailBasicInfoController = function (transactionSaleDetailBasicInfoController) {
        this.transactionSaleDetailBasicInfoController = transactionSaleDetailBasicInfoController;
        this.childControllers.push(transactionSaleDetailBasicInfoController);
    };
    printBatchDetailDetailController.prototype.initVariables = function () {
        var self = this;
        this.baseController = this.scope.baseController;
        self.profileTabEnum = transactionSaleTab;
    };
    printBatchDetailDetailController.prototype.setInfo = function (id, mode, isSubSection) {
        if (isSubSection === void 0) { isSubSection = false; }
        var self = this;
        self.idTransaction = id;
        self.isSubSection = isSubSection;
        self.screenModeManager = new screenModeManager(self, self.saveMethod, false);
        self.screenModeManager.currentMode = mode;
        self.loadScreenConstants();
        self.initialize();
    };
    printBatchDetailDetailController.prototype.initialize = function () {
        var self = this;
        if (self.screenModeManager.currentMode == SCREEN_MODE.ADD) {
            var transaction;
            var _transaction = self.baseController.globalVariableFactory.sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.TRANSACTION_INITIALIZER, "TRANSACTION_INITIALIZER");
            if (!self.baseController.isNullOrUndefined(_transaction)) {
                transaction = _transaction;
            }
            else {
                transaction = new transactionModel();
                transaction.transactionDetails = [];
                transaction.payment = new paymentModel();
                transaction.payment.paymentDetails = [];
                transaction.payment.paymentDetails[0] = new paymentDetailModel();
                transaction.transactionDate = new Date();
            }
            self.screenModeManager.setEntity(transaction);
            self.onTransactionDetailLoaded();
        }
        else {
            self.loadEntity();
            self.getNextTransactionId();
        }
        if (self.isSubSection) {
            self.isCustomerEditable = false;
            self.isProductEditable = false;
        }
    };
    printBatchDetailDetailController.prototype.loadEntity = function () {
        var self = this;
        self.baseController.showLoading();
        var _getTransactionSaleDto = new getTransactionSaleDto();
        _getTransactionSaleDto.idTransaction = self.idTransaction;
        self.transactionSaleWebService.getTransactionSale(_getTransactionSaleDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.screenModeManager.setEntity(response.result.transaction);
                self.onTransactionDetailLoaded();
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
    printBatchDetailDetailController.prototype.getNextTransactionId = function () {
        var self = this;
        var _getTransactionSaleDto = new getTransactionSaleDto();
        _getTransactionSaleDto.idTransaction = self.idTransaction;
        self.transactionSaleWebService.loadNextTrasactionId(_getTransactionSaleDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.nextTransactionId = response.result.nextIdTransaction;
                self.previousTransactionId = response.result.previousIdTransaction;
            }
        }).catch(function (errorMsg) {
        }).finally(function () {
        });
    };
    printBatchDetailDetailController.prototype.saveMethod = function (modifiedEntity, caller) {
        var self = caller;
        self.registerValidations();
        if (!self.validateForGroups()) {
            self.screenModeManager.setMode(SCREEN_MODE.EDIT);
            return;
        }
        var _saveTransactionSaleDto = new saveTransactionSaleDto();
        _saveTransactionSaleDto.transaction = self.screenModeManager.entity;
        _saveTransactionSaleDto.isUpdatingCustomer = self.isUpdatingCustomer;
        _saveTransactionSaleDto.isSavingNewCustomer = self.isSavingNewCustomer;
        self.baseController.showLoading();
        self.transactionSaleWebService.saveTransactionSale(_saveTransactionSaleDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.screenModeManager.setEntity(response.result.transaction);
                self.onTransactionDetailLoaded();
                //location.reload();
                //self.onSaveAndPrint();
                if (self.shouldReloadScreen) {
                    window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSaleDetail/-1/" + SCREEN_MODE.ADD + "/";
                }
                else {
                    self.temporaryTransactionSignature = null;
                    self.printReceipt();
                }
                //self.baseController.showMessage("Saved successfully, Do you want to create a new transaction?", "", ALERT_MESSAGE_TYPE.SUCCESS, true, self.onSaveAndPrint, true, "Save & Print", "Save & New", self.onSaveAndNew, self);
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            self.screenModeManager.setMode(SCREEN_MODE.EDIT);
        }).finally(function () {
            self.baseController.hideLoading();
        });
        self.screenModeManager.setMode(SCREEN_MODE.EDIT);
    };
    printBatchDetailDetailController.prototype.onSaveAndPrint = function () {
        this.shouldReloadScreen = false;
        this.saveMethod(this.screenModeManager.entity, this);
    };
    printBatchDetailDetailController.prototype.onSaveAndNew = function () {
        this.shouldReloadScreen = true;
        this.saveMethod(this.screenModeManager.entity, this);
        //location.reload();
    };
    printBatchDetailDetailController.prototype.registerValidations = function () {
        var self = this;
        for (var i = 0; i < self.childControllers.length; i++) {
            var currentChild = self.childControllers[i];
            currentChild.registerValidations();
        }
    };
    printBatchDetailDetailController.prototype.validateForGroups = function () {
        var self = this;
        var isValid = true;
        var formScope = self.scope['transactionForm'];
        var errorMessages = [];
        for (var i = 0; i < self.childControllers.length; i++) {
            var currentChild = self.childControllers[i];
            isValid = isValid && currentChild.formValidator.validateGroup(currentChild.groupName, false, true);
            errorMessages = errorMessages.concat(currentChild.formValidator.getAllValidationMessagesForGroup(currentChild.groupName));
        }
        if (errorMessages.length > 0) {
            self.baseController.toaster.pop({
                type: 'error',
                body: errorMessages.join('</br>'),
                bodyOutputType: 'trustedHtml'
            });
        }
        return isValid;
    };
    printBatchDetailDetailController.prototype.idGroupValid = function (profileTab) {
        var self = this;
        var isValid = true;
        var groupName = transactionSaleTabNameFromEnum.getName(profileTab);
        var childValidator = Enumerable.From(self.childControllers).Where(function (childController) {
            return childController.groupName == groupName;
        }).FirstOrDefault(null);
        if (childValidator != null && childValidator.hasTransactionDetailBeenLoaded) {
            isValid = childValidator.formValidator.validateGroup(groupName, false);
        }
        return isValid;
    };
    printBatchDetailDetailController.prototype.loadScreenConstants = function () {
        var self = this;
        self.transactionSaleWebService.getTransactionSaleScreenConstant()
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.preloadedData.transactionClasses = response.result.transactionClassHierarchyReturnType;
                self.preloadedData.transactionAccounts = response.result.transactionAccounts;
                self.preloadedData.transactionTemplates = response.result.transactionTemplates;
                self.preloadedData.paymentMethods = response.result.paymentMethods;
                self.onScreenDetailLoaded();
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
        });
    };
    printBatchDetailDetailController.prototype.assignValuesToCustomer = function (customer) {
        var self = this;
        return customer;
    };
    printBatchDetailDetailController.prototype.onTransactionDetailLoaded = function () {
        var self = this;
        self.hasTransactionDetailBeenLoaded = true;
        self.onAllDetailLoaded();
        if (!self.baseController.isNullOrUndefined(self.screenModeManager.entity.idTransaction) && self.screenModeManager.entity.idTransaction > 0) {
            //self.printUrl = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSalePrint/" + self.screenModeManager.entity.idTransaction + "/0/"
            self.isPrintingEnabled = true;
        }
    };
    printBatchDetailDetailController.prototype.printReceipt = function () {
        var self = this;
        var printUrl = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSalePrint/" + self.screenModeManager.entity.idTransaction + "/0/";
        var printWindow = window.open(printUrl, "printWindow", "width=1000,height=650");
        printWindow.print();
    };
    printBatchDetailDetailController.prototype.onScreenDetailLoaded = function () {
        var self = this;
        self.hasScreenDetailBeenLoaded = true;
        self.onAllDetailLoaded();
    };
    printBatchDetailDetailController.prototype.onAllDetailLoaded = function () {
        var self = this;
        if (self.hasTransactionDetailBeenLoaded && self.hasScreenDetailBeenLoaded) {
            self.childControllers.forEach(function (controller) {
                controller.onDetailLoaded();
            });
        }
    };
    printBatchDetailDetailController.prototype.sendEmail = function () {
        var self = this;
        var _sendEmailToClientDto = new sendEmailToClientDto();
        _sendEmailToClientDto.idTransaction = self.screenModeManager.entity.idTransaction;
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
    printBatchDetailDetailController.prototype.onNextClick = function () {
        var self = this;
        var url = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSaleDetail/" + self.nextTransactionId + "/2/";
        window.location.href = url;
    };
    printBatchDetailDetailController.prototype.onPreviousClick = function () {
        var self = this;
        var url = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSaleDetail/" + self.previousTransactionId + "/2/";
        window.location.href = url;
    };
    printBatchDetailDetailController.prototype.onOkToModal = function () {
        var self = this;
        self.registerValidations();
        if (!self.validateForGroups()) {
            self.screenModeManager.setMode(SCREEN_MODE.EDIT);
            return;
        }
        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.TRANSFER, "TRANSACTION", self.screenModeManager.entity);
        self.scope.$close(self.baseController.globalVariableFactory.sessionVariables);
    };
    printBatchDetailDetailController.prototype.onCancelToModal = function () {
        var self = this;
        self.scope.$dismiss();
    };
    printBatchDetailDetailController.prototype.signReceipt = function () {
        var self = this;
        var idWorkstation = self.baseController.$localStorage.getItem(localStorageKey.IdWorkstation);
        if (self.baseController.isNullOrUndefined(idWorkstation)) {
            self.baseController.showMessage("Cannot perform signature connection to device. No workstation id is set. Please log out and login again to set workstation id", "", ALERT_MESSAGE_TYPE.ERROR);
            return;
        }
        self.baseController.showLoading();
        var _saveTemporaryTransactionDto = new saveTemporaryTransactionDto();
        _saveTemporaryTransactionDto.temporaryTransactionSignature = new temporaryTransactionSignatureModel();
        _saveTemporaryTransactionDto.temporaryTransactionSignature.idSignatureState = signatureStateEnum.AWAITING_SIGNATURE;
        _saveTemporaryTransactionDto.temporaryTransactionSignature.temporaryTransactionSignatureDate = new Date();
        _saveTemporaryTransactionDto.temporaryTransactionSignature.idWorkstation = idWorkstation;
        _saveTemporaryTransactionDto.temporaryTransactionSignature.transactionJson = JSON.stringify(self.screenModeManager.entity);
        self.transactionSaleWebService.saveTemporaryTransaction(_saveTemporaryTransactionDto)
            .then(function (response) {
            self.baseController.hideLoading();
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.baseController.showMessage("Your order id is " + response.result.temporaryTransactionSignature.idTemporaryTransactionSignature, "", ALERT_MESSAGE_TYPE.SUCCESS);
                self.temporaryTransactionSignature = response.result.temporaryTransactionSignature;
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
    printBatchDetailDetailController.prototype.reloadSignature = function () {
        var self = this;
        if (self.baseController.isNullOrUndefined(self.temporaryTransactionSignature)) {
            self.baseController.showMessage("No signature has been initialized, please click on sign in to proceed", "", ALERT_MESSAGE_TYPE.ERROR);
            return;
        }
        self.baseController.showLoading();
        var _getSignatureForTemporaryTransactionSignature = new getSignatureForTemporaryTransactionSignatureDto();
        _getSignatureForTemporaryTransactionSignature.idTemporaryTransactionSignature = self.temporaryTransactionSignature.idTemporaryTransactionSignature;
        self.transactionSaleWebService.getSignatureForTemporaryTransactionSignature(_getSignatureForTemporaryTransactionSignature)
            .then(function (response) {
            self.baseController.hideLoading();
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.temporaryTransactionSignature.signatureImage = response.result.signature;
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
    return printBatchDetailDetailController;
}());
bankReconciliationModule.controller("printBatchDetailDetailController", ["$scope",
    "bankReconciliationWebService",
    printBatchDetailDetailController
]);
//# sourceMappingURL=print-batch-detail-controller.js.map