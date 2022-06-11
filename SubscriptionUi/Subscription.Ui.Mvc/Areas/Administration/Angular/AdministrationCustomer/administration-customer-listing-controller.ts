class administrationCustomerListingController {
    scope;
    baseController: baseController;
    paging: administrationCustomerListingSortingPagingInfo;
    administrationCustomerWebService: administrationCustomerWebService;
    customers: customerModel[];
    test: string = "administrationCustomerListingController administrationCustomerListingController administrationCustomerListingController";

    constructor($scope
        , administrationCustomerWebService
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.administrationCustomerWebService = administrationCustomerWebService;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.gridLoad();
    }

    public intializeFlipBookPagingInfo(search: string = null) {
        var self = this;
        self.paging = new administrationCustomerListingSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = 10;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdCustomer";
        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    }

    public gridLoad() {
        var self = this;
        var sorting: administrationCustomerListingSortingPagingInfo = self.baseController.cloneObject(self.paging);
        sorting.currentPageIndex--;
        self.administrationCustomerWebService.loadList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<customerModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.paging.pageCount = response.result.totalCount;
                    self.customers = response.result.entityList;
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

    public addEditItem(item: customerModel, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationCustomer/AdministrationCustomer/" + item.idCustomer + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationCustomer/AdministrationCustomer/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

    public deleteItem(item: customerModel) {
        var self = this;
        var deferred = self.baseController.q.defer();
        self.baseController.showLoading();

        self.administrationCustomerWebService.deleteCustomer(item)
            .then(function (response: baseResultReturnType<customerModel>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.intializeFlipBookPagingInfo();
                    self.gridLoad();
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
                }
            })
            .catch(function (error) {
                self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            })
            .finally(function () {
                self.baseController.hideLoading();
            });
    }
}

administrationCustomerModule.controller("administrationCustomerListingController"
    , ["$scope"
        , "administrationCustomerWebService"
        , administrationCustomerListingController
    ]);