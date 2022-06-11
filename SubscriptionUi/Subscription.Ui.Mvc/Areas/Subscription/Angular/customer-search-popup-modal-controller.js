var customerSearchPopupModalController = /** @class */ (function () {
    function customerSearchPopupModalController($scope, $uibModalInstance, $controller, caller, dataToPass, subscriptionWebService) {
        $scope.controller = this;
        this.$scope = $scope;
        this.$uibModalInstance = $uibModalInstance;
        this.$controller = $controller;
        this.baseController = dataToPass.$scope.baseController;
        this.subscriptionWebService = subscriptionWebService;
        this.caller = caller;
        this.initialize();
    }
    customerSearchPopupModalController.prototype.initialize = function () {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.getCustomerList();
        //this.initVariables();
    };
    customerSearchPopupModalController.prototype.intializeFlipBookPagingInfo = function (search) {
        if (search === void 0) { search = null; }
        var self = this;
        self.paging = new customerListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdCustomer";
        self.paging.sortColumn = "idCustomer";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    };
    customerSearchPopupModalController.prototype.getCustomerList = function () {
        var self = this;
        var sorting = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getCustomerList(sorting)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.paging.pageCount = response.result.totalCount;
                self.customerList = response.result.entityList;
            }
            else {
            }
        });
    };
    customerSearchPopupModalController.prototype.selectCustomer = function (customer) {
        var self = this;
        self.selectedCustomer = customer;
        self.$uibModalInstance.close({ model: self.selectedCustomer, caller: self.caller });
    };
    customerSearchPopupModalController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return customerSearchPopupModalController;
}());
scheduleTransactionModule.controller("customerSearchPopupModalController", ["$scope",
    "$uibModalInstance",
    "$controller",
    "caller",
    "dataToPass",
    "subscriptionWebService",
    customerSearchPopupModalController
]);
//# sourceMappingURL=customer-search-popup-modal-controller.js.map