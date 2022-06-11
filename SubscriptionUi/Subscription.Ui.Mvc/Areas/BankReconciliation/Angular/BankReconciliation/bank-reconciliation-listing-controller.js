var bankReconciliationListingController = /** @class */ (function () {
    function bankReconciliationListingController($scope, bankReconciliationWebService) {
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.bankReconciliationWebService = bankReconciliationWebService;
        this.initialize();
    }
    bankReconciliationListingController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    };
    bankReconciliationListingController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new bankReconciliationSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "UploadDate";
        self.paging.sortColumn = "UploadDate";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    bankReconciliationListingController.prototype.gridLoad = function () {
        var self = this;
        console.log('test');
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.bankReconciliationWebService.loadList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.bankStagingStatements = response.result.entityList;
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
    bankReconciliationListingController.prototype.onGridLoaded = function () {
        var self = this;
    };
    bankReconciliationListingController.prototype.addEditItem = function (item, screenMode) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "BankReconciliation/BankReconciliation/Index/" + item.idBankStatementStaging + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "BankReconciliation/BankReconciliation/Index/-1/" + SCREEN_MODE.ADD + "/";
        }
    };
    return bankReconciliationListingController;
}());
bankReconciliationModule.controller("bankReconciliationListingController", ["$scope",
    "bankReconciliationWebService",
    bankReconciliationListingController
]);
//# sourceMappingURL=bank-reconciliation-listing-controller.js.map