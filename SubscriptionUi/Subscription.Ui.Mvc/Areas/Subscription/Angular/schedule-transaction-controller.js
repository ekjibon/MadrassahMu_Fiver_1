var scheduleTransactionController = /** @class */ (function () {
    function scheduleTransactionController($scope, subscriptionWebService) {
        this.menuList = [Menu.SELECT_CUSTOMER, Menu.SELECT_TRANSACTION, Menu.DEFINE_FREQUENCY, Menu.SUMMARY];
        this.formName = "scheduledTransactionForm";
        this.childControllers = [];
        $scope.indexController = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.subscriptionWebService = subscriptionWebService;
        this.initialize();
    }
    //currentMode: SCREEN_MODE;
    scheduleTransactionController.prototype.registerSelectCustomerController = function (selectCustomerController) {
        var self = this;
        self.selectCustomerController = selectCustomerController;
        self.selectCustomerController.formName = self.formName;
        self.selectCustomerController.registerValidation();
        self.childControllers.push(self.selectCustomerController);
    };
    scheduleTransactionController.prototype.registerSelectTransactionController = function (selectTransactionController) {
        var self = this;
        self.selectTransactionController = selectTransactionController;
        self.selectTransactionController.formName = self.formName;
        self.selectTransactionController.registerValidation();
        self.childControllers.push(self.selectTransactionController);
    };
    scheduleTransactionController.prototype.registerDefineFrequencyController = function (defineFrequencyController) {
        var self = this;
        self.defineFrequencyController = defineFrequencyController;
        self.defineFrequencyController.formName = self.formName;
        self.defineFrequencyController.registerValidation();
        self.childControllers.push(self.defineFrequencyController);
    };
    scheduleTransactionController.prototype.registerSummaryController = function (summaryController) {
        var self = this;
        self.summaryController = summaryController;
    };
    scheduleTransactionController.prototype.totalTransactionAmount = function () {
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
    scheduleTransactionController.prototype.initialize = function () {
        var self = this;
        self.screenModeManager = new screenModeManager(self, null, false);
        self.screenModeManager.entity = new subscriptionModel();
        var transaction = new transactionModel();
        transaction.transactionDate = dateParser.dateParserScreenMode(null, new Date());
        var transactionDetails = new Array();
        transaction.transactionDetails = transactionDetails;
        transaction.idTransactionType = 2;
        self.screenModeManager.entity.transaction = transaction;
        var frequency = new defineFrequencyModel();
        self.screenModeManager.entity.frequency = frequency;
        self.menuEnum = Menu;
        self.selectedMenu = Menu.SELECT_CUSTOMER;
        self.mode = SCREEN_MODE;
    };
    Object.defineProperty(scheduleTransactionController.prototype, "selectedCustomer", {
        get: function () {
            return this.screenModeManager.entity.transaction.customer;
        },
        set: function (customerModel) {
            this.screenModeManager.entity.transaction.customer = customerModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(scheduleTransactionController.prototype, "transaction", {
        get: function () {
            return this.screenModeManager.entity.transaction;
        },
        set: function (transactionModel) {
            this.screenModeManager.entity.transaction = transactionModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(scheduleTransactionController.prototype, "frequency", {
        get: function () {
            return this.screenModeManager.entity.frequency;
        },
        set: function (defineFrequencyModel) {
            this.screenModeManager.entity.frequency = defineFrequencyModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(scheduleTransactionController.prototype, "currentMode", {
        get: function () {
            return this.screenModeManager.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    scheduleTransactionController.prototype.setInfo = function (id, mode) {
        var self = this;
        self.screenModeManager.currentMode = mode;
        if (id !== -1 && id > 0) {
            self.idTransaction = id;
            self.loadEntity();
        }
    };
    scheduleTransactionController.prototype.loadEntity = function () {
        var self = this;
        self.baseController.showLoading();
        var _getPaymentDueDetailDto = new getPaymentDueDetailDto();
        _getPaymentDueDetailDto.idTransaction = self.idTransaction;
        self.subscriptionWebService.getScheduledTransaction(_getPaymentDueDetailDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.transaction = response.result.transaction;
                self.selectedCustomer = response.result.transaction.customer;
                self.frequency.startDate = dateParser.dateParserScreenMode(null, response.result.transaction.scheduleSettings[0].startDate);
                self.frequency.endDate = dateParser.dateParserScreenMode(null, response.result.transaction.scheduleSettings[0].endDate);
                self.frequency.frequency = response.result.transaction.scheduleSettings[0].idFrequency;
                self.frequency.recurEvery = response.result.transaction.scheduleSettings[0].reccurEvery;
                self.frequency.weeklyDaysSelected = JSON.parse(JSON.stringify(response.result.transaction.scheduleSettings[0].weekOccursOnDays));
                if (self.frequency.weeklyDaysSelected != null || self.frequency.weeklyDaysSelected != undefined) {
                    self.frequency.weeklyDaysSelected.split(',').map(Number).forEach(function (number) {
                        self.frequency.weeklyDaysSelectedFromServer[number] = true;
                    });
                }
                self.frequency.selectedMonths = JSON.parse(JSON.stringify(response.result.transaction.scheduleSettings[0].monthOccurs));
                if (self.frequency.selectedMonths != null || self.frequency.selectedMonths != undefined) {
                    self.frequency.selectedMonths.split(',').map(Number).forEach(function (number) {
                        self.frequency.selectedMonthsFromServer[number] = true;
                    });
                }
                self.frequency.selectedmonthlyDates = JSON.parse(JSON.stringify(response.result.transaction.scheduleSettings[0].monthOnSpecificDays));
                if (self.frequency.selectedmonthlyDates != null || self.frequency.selectedmonthlyDates != undefined) {
                    self.frequency.selectedmonthlyDates.split(',').map(Number).forEach(function (number) {
                        self.frequency.selectedMonthlyDatesFromServer[number] = true;
                    });
                }
                self.frequency.selectedMonthlyEvery = JSON.parse(JSON.stringify(response.result.transaction.scheduleSettings[0].monthEveryOrdinal));
                if (self.frequency.selectedMonthlyEvery != null || self.frequency.selectedMonthlyEvery != undefined) {
                    self.frequency.selectedMonthlyEvery.split(',').map(Number).forEach(function (number) {
                        self.frequency.selectedMonthlyEveryFromServer[number] = true;
                    });
                }
                self.frequency.selectedMonthlyDays = JSON.parse(JSON.stringify(response.result.transaction.scheduleSettings[0].monthEveryDays));
                if (self.frequency.selectedMonthlyDays != null || self.frequency.selectedMonthlyDays != undefined) {
                    self.frequency.selectedMonthlyDays.split(',').map(Number).forEach(function (number) {
                        self.frequency.selectedMonthlyDaysFromServer[number] = true;
                    });
                }
                console.log(self.frequency.weeklyDaysSelected);
                console.log(self.frequency.weeklyDaysSelectedFromServer);
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
    scheduleTransactionController.prototype.selectMenu = function (getMenu) {
        var self = this;
        switch (getMenu) {
            case Menu.SELECT_CUSTOMER:
                self.selectedMenu = Menu.SELECT_CUSTOMER;
                break;
            case Menu.SELECT_TRANSACTION:
                self.selectedMenu = Menu.SELECT_TRANSACTION;
                break;
            case Menu.DEFINE_FREQUENCY:
                self.selectedMenu = Menu.DEFINE_FREQUENCY;
                break;
            case Menu.SUMMARY:
                self.selectedMenu = Menu.SUMMARY;
                break;
            case Menu.VIEW_SCHEDULED_TRANSACTIONS:
                self.selectedMenu = Menu.VIEW_SCHEDULED_TRANSACTIONS;
                break;
        }
    };
    scheduleTransactionController.prototype.validateChild = function (selectedMenu) {
        var self = this;
        if (selectedMenu == Menu.SELECT_CUSTOMER) {
            return self.selectCustomerController.validateForGroup();
        }
        if (selectedMenu == Menu.SELECT_TRANSACTION) {
            return self.selectTransactionController.validateForGroup();
        }
        if (selectedMenu == Menu.DEFINE_FREQUENCY) {
            return self.defineFrequencyController.validateForGroup();
        }
    };
    scheduleTransactionController.prototype.back = function () {
        var self = this;
        if (self.menuList.indexOf(self.selectedMenu) !== 0) {
            self.selectedMenu = self.menuList[self.menuList.indexOf(self.selectedMenu) - 1];
        }
    };
    scheduleTransactionController.prototype.next = function () {
        var self = this;
        if (self.selectedMenu == Menu.DEFINE_FREQUENCY) {
            console.log("Freq");
            console.log(self.baseController.isNullOrUndefined(self.defineFrequencyController.frequency.selectedDaysOrEveryForMonthlyFrequency));
            /*if (self.baseController.isNullOrUndefined(self.defineFrequencyController.frequency.startDate)) {
                self.baseController.showMessage("Please select start date", "Warning", ALERT_MESSAGE_TYPE.WARNING, null, () => {
                    return;
                })
            } else if (self.baseController.isNullOrUndefined(self.defineFrequencyController.frequency.endDate)) {
                self.baseController.showMessage("Please select end date", "Warning", ALERT_MESSAGE_TYPE.WARNING, null, () => {
                    return;
                })
            }*/
        }
        if (self.validateChild(self.selectedMenu)) {
            self.selectedMenu = self.menuList[self.menuList.indexOf(self.selectedMenu) + 1];
        }
    };
    scheduleTransactionController.prototype.submit = function () {
        var self = this;
        self.baseController.showLoading();
        self.transaction.idTransactionType = 3;
        self.transaction.transactionDate = new Date();
        if (self.screenModeManager.entity.transaction.customer !== undefined) {
            self.transaction.idCustomer = self.screenModeManager.entity.transaction.customer.idCustomer;
        }
        if (self.screenModeManager.entity.transaction.scheduleSettings !== undefined) {
            self.transaction.scheduleSettings[0].idScheduleSetting = self.screenModeManager.entity.transaction.scheduleSettings[0].idScheduleSetting;
        }
        self.transaction.totalAmount = self.totalTransactionAmount();
        var _saveScheduledTransactionDto = new saveScheduledTransactionDto();
        _saveScheduledTransactionDto.transaction = self.transaction;
        _saveScheduledTransactionDto.frequency = self.screenModeManager.entity.frequency;
        self.subscriptionWebService.saveScheduledTransaction(_saveScheduledTransactionDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.saveScheduledTransactionReturnType = response.result;
                var transaction = new transactionModel();
                var transactionDetails = new Array();
                transaction.transactionDetails = transactionDetails;
                self.screenModeManager.entity.transaction = transaction;
                var frequency = new defineFrequencyModel();
                self.screenModeManager.entity.frequency = frequency;
                self.selectedMenu = Menu.SELECT_CUSTOMER;
                self.baseController.showMessage('Save Successful', 'Success', ALERT_MESSAGE_TYPE.SUCCESS, null, function () {
                    window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ScheduleTransactionSale/-1/" + SCREEN_MODE.ADD + "/";
                });
            }
            else {
            }
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    return scheduleTransactionController;
}());
scheduleTransactionModule.controller("scheduleTransactionController", ["$scope",
    "subscriptionWebService",
    scheduleTransactionController
]);
//# sourceMappingURL=schedule-transaction-controller.js.map