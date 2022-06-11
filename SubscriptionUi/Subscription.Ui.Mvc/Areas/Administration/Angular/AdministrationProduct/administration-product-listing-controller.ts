class administrationProductListingController {
    scope;
    baseController: baseController;
    paging: productListSortingPagingInfo;
    administrationProductWebService: administrationProductWebService;
    selectedTransactions: transactionModel[] = [];
    gridProducts: productModel[];
    transactionSelected: boolean = false; //Added by Bilaal 28/01/21
    sum: number = 0;
    tess: string = "waaaaa";

    constructor($scope
        , administrationProductWebService
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.administrationProductWebService = administrationProductWebService;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    }

    public test() {
        console.log("Wawawawaaaa");
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

    public gridLoad() {
        var self = this;
        var sorting: productListSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.administrationProductWebService.getProductList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<productModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.gridProducts = response.result.entityList;
                    self.onGridLoaded();
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
                }
            })
            .catch(function (error) {
                self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            })
            .finally(function () {
            });
    }

    public onGridLoaded() {
        var self = this;

    }

    public addEditItem(item: productModel, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProduct/" + item.idProduct + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProduct/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

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

    public createNewProduct() {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProduct/";
    }

    public calculateSelectedTransactionSum(item: transactionModel) {
        var self = this;
        return Enumerable.From(self.selectedTransactions).Sum(function (item: transactionModel) {
            return item.totalAmount;
        })
    }

    public selectTransaction(item: transactionModel) {
        var self = this;
        if (self.selectedTransactions.indexOf(item) == -1) {
            self.selectedTransactions.push(item);
        }
    }

    public removeSelectedItem(item: transactionModel) {
        var self = this;
        var position: number = self.baseController.searchForEntityInList("idTransaction", self.selectedTransactions, item, null);
        self.selectedTransactions.splice(position, 1);
    }

    public removeAllSelectedItem() {
        var self = this;
        self.selectedTransactions.length = 0;
    }
}

administrationProductModule.controller("administrationProductListingController"
    , ["$scope"
        , "administrationProductWebService"
        , administrationProductListingController
    ]);