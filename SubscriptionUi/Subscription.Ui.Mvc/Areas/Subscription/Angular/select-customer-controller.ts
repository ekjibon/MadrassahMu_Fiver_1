class selectCustomerController implements ICommonChildControllerCaller {
    scope;
    baseController: baseController;
    callerController: ISelectCustomerControllerCaller;
    customerList: customerModel[];
    paging: customerListSortingPagingInfo;
    subscriptionWebService: subscriptionWebService;
    transactionSaleWebService: transactionSaleWebService;

    formValidator: formValidator;
    //groupName: string = selectCustomerTabNameFromEnum.getName(subscriptionTab.CUSTOMER);
    groupName: Menu = Menu.SELECT_CUSTOMER;
    mode;

    formName: string;


    pagingTransaction: transactionListSortingPagingInfo;
    scheduledTransactions: transactionModel[];
    $sce;

    constructor($scope
        , private $parse
        , private toaster
        , subscriptionWebService
        , transactionSaleWebService
        , $sce
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.$sce = $sce;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.transactionSaleWebService = transactionSaleWebService;
        this.baseController = $scope.baseController;
        this.initialize();
    }

    public initialize() {
        var self = this;
        self.intializeFlipBookPagingInfo();
        self.intializeFlipBookPagingForTransactionInfo();
        //self.getCustomerList();
        self.callerController.registerSelectCustomerController(this);
        self.mode = SCREEN_MODE;
    }

    public registerValidation() {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        self.formValidator.registerValidationForMandatory(self.scope, 'customerName', 'Select Customer');
        self.formValidator.registerGroupValidation(self.groupName.toString(), ['customerName'])
    }

    public validateForGroup(): boolean {
        var self = this;
        var isValid: boolean = true;
        var formScope = self.scope[self.formName];

        var errorMessages: string[] = [];

        isValid = isValid && self.formValidator.validateGroup(self.groupName.toString(), false, true);
        errorMessages = errorMessages.concat(self.formValidator.getAllValidationMessagesForGroup(self.groupName.toString()));

        if (errorMessages.length > 0) {
            self.baseController.showMessage(
                errorMessages.join('\n'),
                'ERROR',
                ALERT_MESSAGE_TYPE.ERROR
            );
        }

        return isValid;
    }

    get selectedCustomer(): customerModel {
        return this.callerController.selectedCustomer;
    }

    get currentMode(): SCREEN_MODE {
        return this.callerController.currentMode;
    }

    set selectedCustomer(customerModel: customerModel) {
        this.callerController.selectedCustomer = customerModel;
    }

    public intializeFlipBookPagingInfo(search: string = null) {
        var self = this;
        self.paging = new customerListSortingPagingInfo();
        self.paging.currentPageIndex = 1;
        self.paging.pageSize = -1;
        self.paging.pageCount = 0;
        self.paging.sortField = "IdCustomer";
        self.paging.sortColumn = "IdCustomer";

        self.paging.sortByDesc = false;
        if (search != null)
            this.paging.search = search;
    }

    /*public getCustomerList() {
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
    }*/

    public intializeFlipBookPagingForTransactionInfo(search: string = null) {
        var self = this;
        self.pagingTransaction = new transactionListSortingPagingInfo();
        self.pagingTransaction.currentPageIndex = 1;
        self.pagingTransaction.pageSize = 10;
        self.pagingTransaction.pageCount = 0;
        self.pagingTransaction.sortField = "idTransaction";
        self.pagingTransaction.sortColumn = "idTransaction";

        self.pagingTransaction.sortByDesc = false;
        if (search != null)
            this.pagingTransaction.search = search;
    }

    public loadTransactionsPerCustomer() {
        var self = this;
        self.baseController.showLoading();
        self.pagingTransaction.idCustomer = self.selectedCustomer.idCustomer;
        if (self.selectedCustomer.idCustomer != null) {
            self.transactionSaleWebService.getAllTransactionListPerCustomer(self.pagingTransaction)
                .then(function (response: baseResultReturnType<baseListReturnType<transactionModel[]>>) {
                    if (response.status == STATUS_MESSAGE.SUCCESS) {
                        self.pagingTransaction.pageCount = response.result.totalCount;
                        self.callerController.transactionsForCustomer = response.result.entityList;
                    }
                    self.baseController.hideLoading();
                }).catch(function (errorMsg) {
                    self.baseController.hideLoading();
                    self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
                }).finally(function () {
                    self.baseController.hideLoading();
                });
        }
    }

    public onCustomerTypeIn(userInputString, event) {
        var self = this;

        if (event.keyCode == 13) {
            var sorting: customerListSortingPagingInfo = self.baseController.cloneObject(self.paging);
            sorting.currentPageIndex--;
            sorting.search = userInputString;
            sorting.currentPageIndex = 0;
            sorting.pageSize = 15;
            self.subscriptionWebService.getCustomerList(sorting)
                .then(function (response: baseResultReturnType<baseListReturnType<any[]>>) {
                    if (response.status == STATUS_MESSAGE.SUCCESS) {
                        self.customerList = response.result.entityList;
                        self.paging.pageCount = response.result.totalCount;
                        self.refreshCustomerListWithAddedItem();
                    } else {

                    }
                }).catch(function (errorMsg) {


                }).finally(function () {
                });
        }        
    }

    public refreshCustomerListWithAddedItem() {
        var self = this;
        if (!self.baseController.isNullOrUndefined(self.customerList) && self.selectedCustomer != null) {
            //remove any added customer from list
            self.customerList = Enumerable.From(self.customerList).Where(function (customer: customerModel) {
                return customer.idCustomer != null;
            }).ToArray();
            self.customerList.unshift(self.selectedCustomer);
        }
    }

    public loadScheduledTransactionsPerCustomer() {
        var self = this;
        self.pagingTransaction.idCustomer = self.selectedCustomer.idCustomer;
        if (self.selectedCustomer.idCustomer != null) {
            self.transactionSaleWebService.getAllScheduledTransactionListPerCustomer(self.pagingTransaction)
                .then(function (response: baseResultReturnType<baseListReturnType<transactionModel[]>>) {
                    if (response.status == STATUS_MESSAGE.SUCCESS) {
                        self.pagingTransaction.pageCount = response.result.totalCount;
                        self.callerController.scheduledTransactionsForCustomer = response.result.entityList;
                    }
                }).catch(function (errorMsg) {
                    self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
                }).finally(function () {
                });
        }
    }

    public searchCustomer() {
        var self = this;
        self.$sce.trustAsUrl(self.baseController.globalVariableFactory.currentBaseServerUrl + 'Subscription/Subscription/CustomerSearchPopup');
        self.baseController.showCustomModal(customerSearchPopupModalController,
            self.baseController.globalVariableFactory.currentBaseServerUrl + 'Subscription/Subscription/CustomerSearchPopup',
            self,
            {
                $scope: self.scope
            },
            self.onSearchCustomerOk,
            () => { }
        );
    }

    public onSearchCustomerOk(customer: { model: customerModel, caller: any }) {
        var self = customer.caller;
        self.selectedCustomer = customer.model;
        console.log(self.selectedCustomer)
    }

    public selectTransaction(transaction: transactionModel, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

    public onCustomerSelected() {
        var self = this;
        self.callerController.next();
    }

    public viewTransaction(transaction: transactionModel, screenMode: SCREEN_MODE) {
        var self = this;
        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transaction.idTransaction + "/-1/" + SCREEN_MODE.VIEW + "/";
    }

    public test() {
        this.scope.$broadcast('UiSelectDemo1');
    }
}

selectCustomerModule.controller("selectCustomerController"
    , ["$scope"
        , "$parse"
        , "toaster"
        , "subscriptionWebService"
        , "transactionSaleWebService"
        , "$sce"
        , selectCustomerController
    ]);