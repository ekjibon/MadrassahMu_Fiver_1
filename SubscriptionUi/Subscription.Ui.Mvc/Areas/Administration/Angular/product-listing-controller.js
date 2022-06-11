var productListingController = (function () {
    function productListingController($scope, transactionSaleWebService) {
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
    productListingController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    };
    productListingController.prototype.test = function () {
        console.log("Wawawawaaaa");
    };
    productListingController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new transactionSaleListingSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "CapturedDate";
        self.paging.sortColumn = "capturedDate";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    productListingController.prototype.gridLoad = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.transactionSaleWebService.loadList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.gridTransactions = response.result.entityList;
                self.onGridLoaded();
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            }
        })
            .catch(function (error) {
            self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
        })
            .finally(function () {
        });
    };
    productListingController.prototype.onGridLoaded = function () {
        var self = this;
    };
    productListingController.prototype.addEditItem = function (item, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSaleDetail/" + item.idTransaction + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/TransactionSale/TransactionSaleDetail/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    /*public showMyTransactionReport() {
        var self = this;
        self.transactionSaleWebService.showMyTransaction()
            .then(function (response: any) {
                new downloadResponseService().manageReponse(response);
            })
            .catch(function (error) {
                self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            })
            .finally(function () {
            });
    }*/
    productListingController.prototype.calculateSelectedTransactionSum = function (item) {
        var self = this;
        return Enumerable.From(self.selectedTransactions).Sum(function (item) {
            return item.totalAmount;
        });
    };
    productListingController.prototype.selectTransaction = function (item) {
        var self = this;
        if (self.selectedTransactions.indexOf(item) == -1) {
            self.selectedTransactions.push(item);
        }
    };
    productListingController.prototype.removeSelectedItem = function (item) {
        var self = this;
        var position = self.baseController.searchForEntityInList("idTransaction", self.selectedTransactions, item, null);
        self.selectedTransactions.splice(position, 1);
    };
    productListingController.prototype.removeAllSelectedItem = function () {
        var self = this;
        self.selectedTransactions.length = 0;
    };
    return productListingController;
}());
administrationModule.controller("productListingController", ["$scope",
    "administrationWebService",
    productListingController
]);
//# sourceMappingURL=product-listing-controller.js.map