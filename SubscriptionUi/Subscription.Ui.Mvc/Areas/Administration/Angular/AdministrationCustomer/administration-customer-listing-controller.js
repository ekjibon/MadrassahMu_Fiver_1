var administrationCustomerListingController = /** @class */ (function () {
    function administrationCustomerListingController($scope, administrationCustomerWebService) {
        this.test = "administrationCustomerListingController administrationCustomerListingController administrationCustomerListingController";
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.administrationCustomerWebService = administrationCustomerWebService;
        this.initialize();
    }
    administrationCustomerListingController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    };
    administrationCustomerListingController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new administrationCustomerListingSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdCustomer";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    administrationCustomerListingController.prototype.gridLoad = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.administrationCustomerWebService.loadList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.customers = response.result.entityList;
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
    administrationCustomerListingController.prototype.onGridLoaded = function () {
        var self = this;
    };
    administrationCustomerListingController.prototype.addEditItem = function (item, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationCustomer/AdministrationCustomer/" + item.idCustomer + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationCustomer/AdministrationCustomer/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    administrationCustomerListingController.prototype.deleteItem = function (item) {
        var self = this;
        var deferred = self.baseController.q.defer();
        self.baseController.showLoading();
        self.administrationCustomerWebService.deleteCustomer(item)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.intializeFlipBookPagingInfo();
                self.gridLoad();
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            }
        })
            .catch(function (error) {
            self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
        })
            .finally(function () {
            self.baseController.hideLoading();
        });
    };
    return administrationCustomerListingController;
}());
administrationCustomerModule.controller("administrationCustomerListingController", ["$scope",
    "administrationCustomerWebService",
    administrationCustomerListingController
]);
//# sourceMappingURL=administration-customer-listing-controller.js.map