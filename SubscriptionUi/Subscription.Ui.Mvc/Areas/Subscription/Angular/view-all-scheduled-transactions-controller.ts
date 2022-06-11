class viewAllScheduledTransactionController {
    scope;
    baseController: baseController;
    subscriptionWebService: subscriptionWebService;
    paging: transactionListSortingPagingInfo;
    //paymentDueSettings: paymentDueSettingModel[];
    scheduledTransactions: transactionModel[];
    test: string = "waaaaaaaaaaaa";

    constructor($scope, subscriptionWebService) {
        $scope.controller = this;
        this.scope = $scope;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.loadScheduledTransactions();
    }

    public intializeFlipBookPagingInfo(search: string = null) {
        var self = this;
        self.paging = new transactionListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "idTransaction";
        self.paging.sortColumn = "idTransaction";

        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    }

    public loadScheduledTransactions() {
        var self = this;
        var sorting: transactionListSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.idTransactionType = 3;
        sorting.currentPageIndex--;
        self.subscriptionWebService.getTransactionList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<transactionModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.scheduledTransactions = response.result.entityList;
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    }

    public selectTransaction(transaction: transactionModel, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ViewScheduledTransaction/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ViewScheduledTransaction/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    }
}

viewAllScheduledTransactionModule.controller("viewAllScheduledTransactionController"
    , ["$scope"
        , "subscriptionWebService"
        , viewAllScheduledTransactionController
    ]);