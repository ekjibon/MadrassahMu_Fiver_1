var administrationProductListingController = /** @class */ (function () {
    function administrationProductListingController($scope, administrationProductWebService) {
        this.selectedTransactions = [];
        this.transactionSelected = false; //Added by Bilaal 28/01/21
        this.sum = 0;
        this.tess = "waaaaa";
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.administrationProductWebService = administrationProductWebService;
        this.initialize();
    }
    administrationProductListingController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    };
    administrationProductListingController.prototype.test = function () {
        console.log("Wawawawaaaa");
    };
    administrationProductListingController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new productListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdProduct";
        self.paging.sortColumn = "idProduct";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    administrationProductListingController.prototype.gridLoad = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.administrationProductWebService.getProductList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.gridProducts = response.result.entityList;
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
    administrationProductListingController.prototype.onGridLoaded = function () {
        var self = this;
    };
    administrationProductListingController.prototype.addEditItem = function (item, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProduct/" + item.idProduct + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProduct/-1/" + SCREEN_MODE.ADD + "/";
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
    administrationProductListingController.prototype.createNewProduct = function () {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProduct/";
    };
    administrationProductListingController.prototype.calculateSelectedTransactionSum = function (item) {
        var self = this;
        return Enumerable.From(self.selectedTransactions).Sum(function (item) {
            return item.totalAmount;
        });
    };
    administrationProductListingController.prototype.selectTransaction = function (item) {
        var self = this;
        if (self.selectedTransactions.indexOf(item) == -1) {
            self.selectedTransactions.push(item);
        }
    };
    administrationProductListingController.prototype.removeSelectedItem = function (item) {
        var self = this;
        var position = self.baseController.searchForEntityInList("idTransaction", self.selectedTransactions, item, null);
        self.selectedTransactions.splice(position, 1);
    };
    administrationProductListingController.prototype.removeAllSelectedItem = function () {
        var self = this;
        self.selectedTransactions.length = 0;
    };
    return administrationProductListingController;
}());
administrationProductModule.controller("administrationProductListingController", ["$scope",
    "administrationProductWebService",
    administrationProductListingController
]);
//# sourceMappingURL=administration-product-listing-controller.js.map