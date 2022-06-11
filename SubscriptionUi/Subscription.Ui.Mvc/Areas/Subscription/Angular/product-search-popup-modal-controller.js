var productSearchPopupModalController = /** @class */ (function () {
    function productSearchPopupModalController($scope, $uibModalInstance, $controller, caller, dataToPass, subscriptionWebService) {
        $scope.controller = this;
        this.$scope = $scope;
        this.$uibModalInstance = $uibModalInstance;
        this.$controller = $controller;
        this.baseController = dataToPass.$scope.baseController;
        this.subscriptionWebService = subscriptionWebService;
        this.caller = caller;
        this.initialize();
    }
    productSearchPopupModalController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.getProductList();
        //this.initVariables();
    };
    productSearchPopupModalController.prototype.intializeFlipBookPagingInfo = function (search) {
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
    productSearchPopupModalController.prototype.getProductList = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getProductList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.productList = response.result.entityList;
            }
            else {
            }
        });
    };
    productSearchPopupModalController.prototype.selectProduct = function (product) {
        var self = this;
        self.selectedProduct = product;
        self.$uibModalInstance.close({ model: self.selectedProduct, caller: self.caller });
    };
    productSearchPopupModalController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return productSearchPopupModalController;
}());
scheduleTransactionModule.controller("productSearchPopupModalController", ["$scope",
    "$uibModalInstance",
    "$controller",
    "caller",
    "dataToPass",
    "subscriptionWebService",
    productSearchPopupModalController
]);
//# sourceMappingURL=product-search-popup-modal-controller.js.map