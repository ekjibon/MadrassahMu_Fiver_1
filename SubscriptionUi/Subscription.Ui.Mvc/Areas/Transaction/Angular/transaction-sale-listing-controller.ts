class transactionSaleListingController {
    scope;
    baseController: baseController;
    paging: transactionListSortingPagingInfo; //transactionSaleListingSortingPagingInfo
    transactionSaleWebService: transactionSaleWebService;
    selectedTransactions: transactionModel[] = [];
    subscriptionWebService: subscriptionWebService;
    gridTransactions: transactionModel[];
    transactionSelected: boolean = false; //Added by Bilaal 28/01/21
    sum: number = 0;
    tess: string = "waaaaa";

    constructor($scope
        , transactionSaleWebService
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.transactionSaleWebService = transactionSaleWebService;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.loadTransactions();
    }

    public test() {
        console.log("Wawawawaaaa");
    }

    public intializeFlipBookPagingInfo(search: string = null) {
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
    }

    public loadTransactions() {
        var self = this;
        var sorting: transactionListSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.idTransactionType = 2;
        sorting.currentPageIndex--;
        self.transactionSaleWebService.getTransactionList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<transactionModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.gridTransactions = response.result.entityList;
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    }

    public onGridLoaded() {
        var self = this;

    }

    public showMyTransactionReport() {
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
    }

    public calculateSelectedTransactionSum(item: transactionModel) {
        var self = this;
        return Enumerable.From(self.selectedTransactions).Sum(function (item: transactionModel) {
            return item.totalAmount;
        })
    }

    public selectTransaction(transaction: transactionModel, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

    public viewTransaction(transaction: transactionModel, screenMode: SCREEN_MODE) {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.VIEW + "/";
    }

    public createNewTransaction() {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
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

class transactionSaleListingViewModel {
    transaction: transactionModel;
    selected: boolean;
}

transactionModule.controller("transactionSaleListingController"
    , ["$scope"
        , "transactionSaleWebService"
        , transactionSaleListingController
    ]);