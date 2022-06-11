var selectTransactionController = /** @class */ (function () {
    function selectTransactionController($scope, $filter, $parse, toaster, subscriptionWebService) {
        this.$filter = $filter;
        this.$parse = $parse;
        this.toaster = toaster;
        this.onPageLoaded = true;
        //groupName: string = selectCustomerTabNameFromEnum.getName(subscriptionTab.TRANSACTION);
        this.groupName = Menu.SELECT_TRANSACTION;
        this.seeMore = false;
        $scope.controller = this;
        this.scope = $scope;
        this.filter = $filter;
        this.baseController = $scope.baseController;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.initialize();
    }
    selectTransactionController.prototype.initialize = function () {
        var self = this;
        //self.callerController.screenModeManager.setEntity(self.transactionDetails);
        var _product = new productModel();
        if (self.selectedTransactionDetail != null) {
            self.selectedTransactionDetail.product = _product;
            self.selectedTransactionDetail.quantity = 1;
        }
        self.intializeCustomerFlipBookPagingInfo();
        self.intializeFlipBookPagingInfo();
        //self.getCustomerList();
        //self.getProductList();
        self.callerController.registerSelectTransactionController(this);
        self.mode = SCREEN_MODE;
        //document.getElementById("productName").focus();
    };
    selectTransactionController.prototype.registerValidation = function () {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        self.formValidator.registerValidation('transactionDetail', 'Please enter at least one detail item', function () {
            return self.transactionDetails.length > 0;
        });
        self.formValidator.registerGroupValidation(self.groupName.toString(), ['transactionDetail']);
    };
    selectTransactionController.prototype.validateForGroup = function () {
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
    Object.defineProperty(selectTransactionController.prototype, "receiptNo", {
        get: function () {
            return this.callerController.transaction.receiptNo;
        },
        set: function (receiptNo) {
            this.receiptNo = receiptNo;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(selectTransactionController.prototype, "transactionDetails", {
        get: function () {
            return this.callerController.transaction.transactionDetails;
        },
        set: function (transactionDetailModel) {
            this.callerController.transaction.transactionDetails = transactionDetailModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(selectTransactionController.prototype, "transaction", {
        get: function () {
            return this.callerController.transaction;
        },
        set: function (transactionModel) {
            this.callerController.transaction = transactionModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(selectTransactionController.prototype, "selectedCustomer", {
        get: function () {
            return this.callerController.selectedCustomer;
        },
        set: function (customerModel) {
            this.callerController.selectedCustomer = customerModel;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(selectTransactionController.prototype, "currentMode", {
        get: function () {
            return this.callerController.currentMode;
        },
        enumerable: false,
        configurable: true
    });
    Object.defineProperty(selectTransactionController.prototype, "customerAddress", {
        get: function () {
            if (this.callerController.selectedCustomer != null && this.callerController.selectedCustomer.person != null && this.callerController.selectedCustomer.person.person_Address.length > 0) {
                return this.callerController.selectedCustomer.person.person_Address[0].address.addressLine1 + ", " + this.callerController.selectedCustomer.person.person_Address[0].address.city;
            }
        },
        enumerable: false,
        configurable: true
    });
    selectTransactionController.prototype.totalTransactionAmount = function () {
        if (this.callerController !== undefined) {
            return this.callerController.totalTransactionAmount();
        }
        else {
            return 0;
        }
    };
    selectTransactionController.prototype.intializeCustomerFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.customerPaging = new customerListSortingPagingInfo();
        self.customerPaging.currentPageIndex = 1;
        self.customerPaging.pageSize = 10;
        self.customerPaging.pageCount = 0;
        self.customerPaging.sortField = "IdCustomer";
        self.customerPaging.sortColumn = "idCustomer";
        self.customerPaging.sortByDesc = false;
        if (search != null)
            this.customerPaging.search = search;
    };
    selectTransactionController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.productPaging = new productListSortingPagingInfo();
        self.productPaging.currentPageIndex = 1;
        self.productPaging.pageSize = 10;
        self.productPaging.pageCount = 0;
        self.productPaging.sortField = "IdProduct";
        self.productPaging.sortColumn = "idProduct";
        self.productPaging.sortByDesc = false;
        if (search != null)
            this.productPaging.search = search;
    };
    selectTransactionController.prototype.getCustomerList = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.customerPaging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getCustomerList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.customerPaging.pageCount = response.result.totalCount;
                self.customerList = response.result.entityList;
            }
            else {
            }
        });
    };
    selectTransactionController.prototype.getProductList = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.productPaging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getProductList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.productPaging.pageCount = response.result.totalCount;
                self.productList = response.result.entityList;
            }
            else {
            }
        });
    };
    selectTransactionController.prototype.onProductTypeIn = function (userInputString, event) {
        var self = this;
        if (event.keyCode == 13) {
            var sorting = self.baseController.cloneObject(self.productPaging);
            sorting.currentPageIndex--;
            sorting.search = userInputString;
            sorting.currentPageIndex = 0;
            sorting.pageSize = 15;
            self.subscriptionWebService.getProductList(sorting)
                .then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.productList = response.result.entityList;
                    self.productPaging.pageCount = response.result.totalCount;
                    self.refreshProductListWithAddedItem();
                }
                else {
                }
            }).catch(function (errorMsg) {
            }).finally(function () {
            });
        }
    };
    selectTransactionController.prototype.refreshProductListWithAddedItem = function () {
        var self = this;
        if (!self.baseController.isNullOrUndefined(self.customerList) && self.selectedTransactionDetail.product != null) {
            //remove any added customer from list
            self.productList = Enumerable.From(self.productList).Where(function (product) {
                return product.idProduct != null;
            }).ToArray();
            self.productList.unshift(self.selectedTransactionDetail.product);
        }
    };
    selectTransactionController.prototype.addProduct = function () {
        var self = this;
        if (self.selectedTransactionDetail.product == null) {
            self.baseController.showMessage("Please enter product.", "", ALERT_MESSAGE_TYPE.WARNING);
            return;
        }
        if (self.selectedTransactionDetail.rate == null) {
            self.baseController.showMessage("Please enter rate.", "", ALERT_MESSAGE_TYPE.WARNING);
            return;
        }
        if (self.selectedTransactionDetail.quantity == null) {
            self.baseController.showMessage("Please enter quantity.", "", ALERT_MESSAGE_TYPE.WARNING);
            return;
        }
        if (self.selectedTransactionDetail != null) {
            self.transactionDetails.push(self.selectedTransactionDetail);
            self.selectedTransactionDetail = new transactionDetailModel();
            self.selectedTransactionDetail.quantity = 1;
        }
        else {
            self.baseController.showMessage("Please enter product, amount and quantity.", "", ALERT_MESSAGE_TYPE.WARNING);
        }
        var result = document.getElementById("productName");
        var uiSelect = angular.element(result).controller('uiSelect');
        uiSelect.focusser[0].focus();
        uiSelect.activate();
    };
    selectTransactionController.prototype.checkIfAvailableInScheduledTransactions = function () {
        var self = this;
        var arrayOfExistingTransactionDetails = [];
        if (self.callerController.scheduledTransactionsForCustomer != undefined) {
            self.callerController.scheduledTransactionsForCustomer.forEach(function (t) {
                t.transactionDetails.forEach(function (td) {
                    if (!self.baseController.isNullOrUndefined(self.selectedTransactionDetail.product)) {
                        if (td.idProduct == self.selectedTransactionDetail.product.idProduct) {
                            arrayOfExistingTransactionDetails.push(td);
                        }
                    }
                });
            });
        }
        if (arrayOfExistingTransactionDetails != undefined && arrayOfExistingTransactionDetails.length > 0) {
            return true;
        }
        return false;
    };
    selectTransactionController.prototype.searchProduct = function () {
        var self = this;
        self.baseController.showCustomModal(productSearchPopupModalController, self.baseController.globalVariableFactory.baseServerUrl + 'Subscription/Subscription/ProductSearchPopup', self, {
            $scope: self.scope
        }, self.onSearchProductOk, function () { });
    };
    selectTransactionController.prototype.onSearchProductOk = function (product) {
        var self = product.caller;
        self.selectedTransactionDetail.product = product.model;
        console.log(self.selectedCustomer);
    };
    selectTransactionController.prototype.isSeeMoreClicked = function () {
        var self = this;
        self.seeMore = !self.seeMore;
    };
    selectTransactionController.prototype.onCustomerTypeIn = function (userInputString, event) {
        var self = this;
        if (event.keyCode == 13) {
            var sorting = self.baseController.cloneObject(self.customerPaging);
            sorting.currentPageIndex--;
            sorting.search = userInputString;
            sorting.currentPageIndex = 0;
            sorting.pageSize = 15;
            self.subscriptionWebService.getCustomerList(sorting)
                .then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.customerList = response.result.entityList;
                    self.customerPaging.pageCount = response.result.totalCount;
                    self.refreshCustomerListWithAddedItem();
                }
                else {
                }
            }).catch(function (errorMsg) {
            }).finally(function () {
            });
        }
    };
    selectTransactionController.prototype.refreshCustomerListWithAddedItem = function () {
        var self = this;
        if (!self.baseController.isNullOrUndefined(self.customerList) && self.selectedCustomer != null) {
            //remove any added customer from list
            self.customerList = Enumerable.From(self.customerList).Where(function (customer) {
                return customer.idCustomer != null;
            }).ToArray();
            self.customerList.unshift(self.selectedCustomer);
        }
    };
    selectTransactionController.prototype.removeTransactionDetail = function (transactionDetail) {
        var self = this;
        self.transactionDetails.splice(self.transactionDetails.indexOf(transactionDetail), 1);
    };
    return selectTransactionController;
}());
selectTransactionModule.controller("selectTransactionController", ["$scope",
    "$filter",
    "$parse",
    "toaster",
    "subscriptionWebService",
    selectTransactionController
]);
//# sourceMappingURL=select-transaction-controller.js.map