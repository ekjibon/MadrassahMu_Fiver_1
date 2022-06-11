var selectCustomerController = /** @class */ (function () {
    function selectCustomerController($scope, $parse, toaster, subscriptionWebService, transactionSaleWebService, $sce) {
        this.$parse = $parse;
        this.toaster = toaster;
        //groupName: string = selectCustomerTabNameFromEnum.getName(subscriptionTab.CUSTOMER);
        this.groupName = Menu.SELECT_CUSTOMER;
        $scope.controller = this;
        this.scope = $scope;
        this.$sce = $sce;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.transactionSaleWebService = transactionSaleWebService;
        this.baseController = $scope.baseController;
        this.initialize();
    }
    selectCustomerController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.intializeFlipBookPagingForTransactionInfo();
        //self.getCustomerList();
        self.callerController.registerSelectCustomerController(this);
        self.mode = SCREEN_MODE;
    };
    selectCustomerController.prototype.registerValidation = function () {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        self.formValidator.registerValidationForMandatory(self.scope, 'customerName', 'Select Customer');
        self.formValidator.registerGroupValidation(self.groupName.toString(), ['customerName']);
    };
    selectCustomerController.prototype.validateForGroup = function () {
        var self = this;
        var isValid = true;
        var formScope = self.scope[self.formName];
        var errorMessages = [];
        isValid = isValid && self.formValidator.validateGroup(self.groupName.toString(), false, true);
        errorMessages = errorMessages.concat(self.formValidator.getAllValidationMessagesForGroup(self.groupName.toString()));
        if (errorMessages.length > 0) {
            self.baseController.showMessage(errorMessages.join('\n'), 'ERROR', ALERT_MESSAGE_TYPE.ERROR);
        }
        return isValid;
    };
    Object.defineProperty(selectCustomerController.prototype, "selectedCustomer", {
        get: function () {
            return this.callerController.selectedCustomer;
        },
        set: function (customerModel) {
            this.callerController.selectedCustomer = customerModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(selectCustomerController.prototype, "currentMode", {
        get: function () {
            return this.callerController.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    selectCustomerController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new customerListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = -1;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdCustomer";
        self.paging.sortColumn = "IdCustomer";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    /*public getCustomerList() {
        var self = this;
        var sorting: customerListSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getCustomerList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<customerModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.customerList = response.result.entityList;
                } else {
                }
            })
    }*/
    selectCustomerController.prototype.intializeFlipBookPagingForTransactionInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.pagingTransaction = new transactionListSortingPagingInfo();
        self.pagingTransaction.currentPageIndex = 1;
        self.pagingTransaction.pageSize = 10;
        self.pagingTransaction.pageCount = 0;
        self.pagingTransaction.sortField = "idTransaction";
        self.pagingTransaction.sortColumn = "idTransaction";
        self.pagingTransaction.sortByDesc = false;
        if (search != null)
            this.pagingTransaction.search = search;
    };
    selectCustomerController.prototype.loadTransactionsPerCustomer = function () {
        var self = this;
        self.baseController.showLoading();
        self.pagingTransaction.idCustomer = self.selectedCustomer.idCustomer;
        if (self.selectedCustomer.idCustomer != null) {
            self.transactionSaleWebService.getAllTransactionListPerCustomer(self.pagingTransaction)
                .then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.pagingTransaction.pageCount = response.result.totalCount;
                    self.callerController.transactionsForCustomer = response.result.entityList;
                }
                self.baseController.hideLoading();
            }).catch(function (errorMsg) {
                self.baseController.hideLoading();
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
        }
    };
    selectCustomerController.prototype.onCustomerTypeIn = function (userInputString, event) {
        var self = this;
        if (event.keyCode == 13) {
            var sorting = self.baseController.cloneObject(self.paging);
            sorting.currentPageIndex--;
            sorting.search = userInputString;
            sorting.currentPageIndex = 0;
            sorting.pageSize = 15;
            self.subscriptionWebService.getCustomerList(sorting)
                .then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.customerList = response.result.entityList;
                    self.paging.pageCount = response.result.totalCount;
                    self.refreshCustomerListWithAddedItem();
                }
                else {
                }
            }).catch(function (errorMsg) {
            }).finally(function () {
            });
        }
    };
    selectCustomerController.prototype.refreshCustomerListWithAddedItem = function () {
        var self = this;
        if (!self.baseController.isNullOrUndefined(self.customerList) && self.selectedCustomer != null) {
            //remove any added customer from list
            self.customerList = Enumerable.From(self.customerList).Where(function (customer) {
                return customer.idCustomer != null;
            }).ToArray();
            self.customerList.unshift(self.selectedCustomer);
        }
    };
    selectCustomerController.prototype.loadScheduledTransactionsPerCustomer = function () {
        var self = this;
        self.pagingTransaction.idCustomer = self.selectedCustomer.idCustomer;
        if (self.selectedCustomer.idCustomer != null) {
            self.transactionSaleWebService.getAllScheduledTransactionListPerCustomer(self.pagingTransaction)
                .then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.pagingTransaction.pageCount = response.result.totalCount;
                    self.callerController.scheduledTransactionsForCustomer = response.result.entityList;
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
        }
    };
    selectCustomerController.prototype.searchCustomer = function () {
        var self = this;
        self.$sce.trustAsUrl(self.baseController.globalVariableFactory.currentBaseServerUrl + 'Subscription/Subscription/CustomerSearchPopup');
        self.baseController.showCustomModal(customerSearchPopupModalController, self.baseController.globalVariableFactory.currentBaseServerUrl + 'Subscription/Subscription/CustomerSearchPopup', self, {
            $scope: self.scope
        }, self.onSearchCustomerOk, function () { });
    };
    selectCustomerController.prototype.onSearchCustomerOk = function (customer) {
        var self = customer.caller;
        self.selectedCustomer = customer.model;
        console.log(self.selectedCustomer);
    };
    selectCustomerController.prototype.selectTransaction = function (transaction, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    selectCustomerController.prototype.onCustomerSelected = function () {
        var self = this;
        self.callerController.next();
    };
    selectCustomerController.prototype.viewTransaction = function (transaction, screenMode) {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.VIEW + "/";
    };
    selectCustomerController.prototype.test = function () {
        this.scope.$broadcast('UiSelectDemo1');
    };
    return selectCustomerController;
}());
selectCustomerModule.controller("selectCustomerController", ["$scope",
    "$parse",
    "toaster",
    "subscriptionWebService",
    "transactionSaleWebService",
    "$sce",
    selectCustomerController
]);
//# sourceMappingURL=select-customer-controller.js.map