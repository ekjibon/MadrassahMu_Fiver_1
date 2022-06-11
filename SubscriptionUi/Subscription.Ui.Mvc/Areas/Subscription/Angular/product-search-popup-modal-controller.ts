class productSearchPopupModalController<Y> {
    $scope;
    $uibModalInstance;
    $controller;
    baseController: baseController;
    productList: productModel[];
    selectedProduct: productModel;
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
        self.getProductList();
        //this.initVariables();
    }

    public intializeFlipBookPagingInfo(search: string = null) {
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
    }

    public getProductList() {
        var self = this;
        var sorting: productListSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getProductList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<productModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.productList = response.result.entityList;
                } else {
                }
            })
    }

    public selectProduct(product: productModel) {
        var self = this;
        self.selectedProduct = product;
        self.$uibModalInstance.close({ model: self.selectedProduct, caller: self.caller });
    }

    public cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }

    /*public onOk(action: any) {
        var self = this;
        self.$uibModalInstance.close({ model: self.selectedCustomer, caller: self.caller });
    }*/

}

scheduleTransactionModule.controller("productSearchPopupModalController"
    , ["$scope"
        , "$uibModalInstance"
        , "$controller"
        , "caller"
        , "dataToPass"
        , "subscriptionWebService"
        , productSearchPopupModalController
    ]);