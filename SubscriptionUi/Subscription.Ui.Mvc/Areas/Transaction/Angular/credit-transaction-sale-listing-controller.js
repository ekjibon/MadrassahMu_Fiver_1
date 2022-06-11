var creditTransactionSaleListingController = /** @class */ (function () {
    function creditTransactionSaleListingController($scope, transactionSaleWebService) {
        this.selectedTransactions = [];
        this.transactionSelected = false; //Added by Bilaal 28/01/21
        this.sum = 0;
        this.tess = "waaaaa";
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.transactionSaleWebService = transactionSaleWebService;
        this.initialize();
    }
    creditTransactionSaleListingController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.loadTransactions();
    };
    creditTransactionSaleListingController.prototype.test = function () {
        console.log("Wawawawaaaa");
    };
    creditTransactionSaleListingController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new transactionListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdTransaction";
        self.paging.sortColumn = "IdTransaction";
        self.paging.sortByDesc = true;
        if (search != null)
            this.paging.search = search;
    };
    creditTransactionSaleListingController.prototype.loadTransactions = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.idTransactionType = 1;
        sorting.currentPageIndex--;
        self.transactionSaleWebService.getTransactionList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.gridTransactions = response.result.entityList;
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
        });
    };
    creditTransactionSaleListingController.prototype.onGridLoaded = function () {
        var self = this;
    };
    creditTransactionSaleListingController.prototype.showMyTransactionReport = function () {
        var self = this;
        self.transactionSaleWebService.showMyTransaction()
            .then(function (response) {
            new downloadResponseService().manageReponse(response);
        })
            .catch(function (error) {
            self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
        })
            .finally(function () {
        });
    };
    creditTransactionSaleListingController.prototype.calculateSelectedTransactionSum = function (item) {
        var self = this;
        return Enumerable.From(self.selectedTransactions).Sum(function (item) {
            return item.totalAmount;
        });
    };
    creditTransactionSaleListingController.prototype.selectTransaction = function (transaction, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    creditTransactionSaleListingController.prototype.viewTransaction = function (transaction, screenMode) {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.VIEW + "/";
    };
    creditTransactionSaleListingController.prototype.calculateRemaining = function (item) {
        var self = this;
        console.log(item);
        var amountPaid = item.totalAmount;
        var totalAmount = 0;
        item.transactionDetails.forEach(function (td) {
            totalAmount += td.quantity * td.rate;
        });
        return totalAmount - amountPaid;
    };
    creditTransactionSaleListingController.prototype.createNewTransaction = function () {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
    };
    creditTransactionSaleListingController.prototype.removeSelectedItem = function (item) {
        var self = this;
        var position = self.baseController.searchForEntityInList("idTransaction", self.selectedTransactions, item, null);
        self.selectedTransactions.splice(position, 1);
    };
    creditTransactionSaleListingController.prototype.removeAllSelectedItem = function () {
        var self = this;
        self.selectedTransactions.length = 0;
    };
    return creditTransactionSaleListingController;
}());
transactionModule.controller("creditTransactionSaleListingController", ["$scope",
    "transactionSaleWebService",
    creditTransactionSaleListingController
]);
//# sourceMappingURL=credit-transaction-sale-listing-controller.js.map