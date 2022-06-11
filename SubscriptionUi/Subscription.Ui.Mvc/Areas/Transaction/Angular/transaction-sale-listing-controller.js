var transactionSaleListingController = /** @class */ (function () {
    function transactionSaleListingController($scope, transactionSaleWebService) {
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
    transactionSaleListingController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.loadTransactions();
    };
    transactionSaleListingController.prototype.test = function () {
        console.log("Wawawawaaaa");
    };
    transactionSaleListingController.prototype.intializeFlipBookPagingInfo = function (search) {
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
    transactionSaleListingController.prototype.loadTransactions = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.idTransactionType = 2;
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
    transactionSaleListingController.prototype.onGridLoaded = function () {
        var self = this;
    };
    transactionSaleListingController.prototype.showMyTransactionReport = function () {
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
    transactionSaleListingController.prototype.calculateSelectedTransactionSum = function (item) {
        var self = this;
        return Enumerable.From(self.selectedTransactions).Sum(function (item) {
            return item.totalAmount;
        });
    };
    transactionSaleListingController.prototype.selectTransaction = function (transaction, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    transactionSaleListingController.prototype.viewTransaction = function (transaction, screenMode) {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.VIEW + "/";
    };
    transactionSaleListingController.prototype.createNewTransaction = function () {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
    };
    transactionSaleListingController.prototype.removeSelectedItem = function (item) {
        var self = this;
        var position = self.baseController.searchForEntityInList("idTransaction", self.selectedTransactions, item, null);
        self.selectedTransactions.splice(position, 1);
    };
    transactionSaleListingController.prototype.removeAllSelectedItem = function () {
        var self = this;
        self.selectedTransactions.length = 0;
    };
    return transactionSaleListingController;
}());
var transactionSaleListingViewModel = /** @class */ (function () {
    function transactionSaleListingViewModel() {
    }
    return transactionSaleListingViewModel;
}());
transactionModule.controller("transactionSaleListingController", ["$scope",
    "transactionSaleWebService",
    transactionSaleListingController
]);
//# sourceMappingURL=transaction-sale-listing-controller.js.map