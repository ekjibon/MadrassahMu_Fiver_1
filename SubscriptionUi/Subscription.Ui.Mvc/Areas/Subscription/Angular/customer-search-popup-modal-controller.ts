class customerSearchPopupModalController<Y> {
    $scope;
    $uibModalInstance;
    $controller;
    baseController: baseController;
    customerList: customerModel[];
    selectedCustomer: customerModel;
    subscriptionWebService: subscriptionWebService;
    paging: customerListSortingPagingInfo;
    caller: Y;

    constructor($scope, $uibModalInstance, $controller, caller: Y, dataToPass: { $scope }, subscriptionWebService) {
        $scope.controller = this;
        this.$scope = $scope;
        this.$uibModalInstance = $uibModalInstance;
        this.$controller = $controller;
        this.baseController = dataToPass.$scope.baseController;
        this.subscriptionWebService = subscriptionWebService;
        this.caller = caller;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo()
        self.getCustomerList();
        //this.initVariables();
    }

    public intializeFlipBookPagingInfo(search: string = null) {
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
    }

    public getCustomerList() {
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
    }

    public selectCustomer(customer: customerModel) {
        var self = this;
        self.selectedCustomer = customer;
        self.$uibModalInstance.close({ model: self.selectedCustomer, caller: self.caller });
    }

    public cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }

    /*public onOk(action: any) {
        var self = this;
        self.$uibModalInstance.close({ model: self.selectedCustomer, caller: self.caller });
    }*/

}

scheduleTransactionModule.controller("customerSearchPopupModalController"
    , ["$scope"
        , "$uibModalInstance"
        , "$controller"
        , "caller"
        , "dataToPass"
        , "subscriptionWebService"
        , customerSearchPopupModalController
    ]);