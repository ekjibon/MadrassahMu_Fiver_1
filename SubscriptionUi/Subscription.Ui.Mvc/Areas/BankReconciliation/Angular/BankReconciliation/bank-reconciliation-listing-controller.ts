class bankReconciliationListingController {
    scope;
    baseController: baseController;
    paging: bankReconciliationSortingPagingInfo;
    bankReconciliationWebService: bankReconciliationWebService;
    bankStagingStatements: bankReconciliationListReturnType[];

    constructor($scope
        , bankReconciliationWebService
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.bankReconciliationWebService = bankReconciliationWebService;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    }

    public intializeFlipBookPagingInfo(search: string = null) {
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
    }

    public gridLoad() {
        var self = this;
        console.log('test')
        var sorting: bankReconciliationSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.bankReconciliationWebService.loadList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<bankReconciliationListReturnType[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.bankStagingStatements = response.result.entityList;
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

    public addEditItem(item: bankReconciliationListReturnType, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "BankReconciliation/BankReconciliation/Index/" + item.idBankStatementStaging + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "BankReconciliation/BankReconciliation/Index/-1/" + SCREEN_MODE.ADD + "/";
        }
    }
}


bankReconciliationModule.controller("bankReconciliationListingController"
    , ["$scope"
        , "bankReconciliationWebService"
        , bankReconciliationListingController
    ]);
