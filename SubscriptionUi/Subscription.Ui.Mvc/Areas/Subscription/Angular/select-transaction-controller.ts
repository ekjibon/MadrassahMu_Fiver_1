class selectTransactionController implements ICommonChildControllerCaller {
    scope;
    baseController: baseController;
    callerController: ISelectTransactionControllerCaller;
    subscriptionWebService: subscriptionWebService;
    selectedTransactionDetail: transactionDetailModel;
    productList: productModel[];
    customerList: customerModel[];
    productPaging: productListSortingPagingInfo;
    customerPaging: customerListSortingPagingInfo;
    onPageLoaded: boolean = true;
    mode;
    filter;

    formName: string;

    formValidator: formValidator;
    //groupName: string = selectCustomerTabNameFromEnum.getName(subscriptionTab.TRANSACTION);
    groupName: Menu = Menu.SELECT_TRANSACTION;

    seeMore: boolean = false;

    constructor($scope
        , private $filter
        , private $parse
        , private toaster
        , subscriptionWebService) {
        $scope.controller = this;
        this.scope = $scope;
        this.filter = $filter;
        this.baseController = $scope.baseController;
        this.callerController = $scope.indexController;
        this.subscriptionWebService = subscriptionWebService;
        this.initialize();
    }

    public initialize() {
        var self = this;
        //self.callerController.screenModeManager.setEntity(self.transactionDetails);
        var _product: productModel = new productModel();
        if (self.selectedTransactionDetail != null) {
            self.selectedTransactionDetail.product = _product;
            self.selectedTransactionDetail.quantity = 1;
        }

        self.intializeCustomerFlipBookPagingInfo();
        self.intializeFlipBookPagingInfo();

        //self.getCustomerList();
        //self.getProductList();
        self.callerController.registerSelectTransactionController(this);
        self.mode = SCREEN_MODE;
        //document.getElementById("productName").focus();
    }

    public registerValidation() {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        self.formValidator.registerValidation('transactionDetail', 'Please enter at least one detail item', function () {
            return self.transactionDetails.length > 0
        });
        self.formValidator.registerGroupValidation(self.groupName.toString(), ['transactionDetail'])

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

    get receiptNo(): string {
        return this.callerController.transaction.receiptNo;
    }

    set receiptNo(receiptNo: string) {
        this.receiptNo = receiptNo;
    }

    get transactionDetails(): transactionDetailModel[] {
        return this.callerController.transaction.transactionDetails;
    }

    set transactionDetails(transactionDetailModel: transactionDetailModel[]) {
        this.callerController.transaction.transactionDetails = transactionDetailModel;
    }

    get transaction(): transactionModel {
        return this.callerController.transaction;
    }

    set transaction(transactionModel: transactionModel) {
        this.callerController.transaction = transactionModel;
    }

    get selectedCustomer(): customerModel {
        return this.callerController.selectedCustomer;
    }

    get currentMode(): SCREEN_MODE {
        return this.callerController.currentMode;
    }

    get customerAddress(): string {
        if (this.callerController.selectedCustomer != null && this.callerController.selectedCustomer.person != null && this.callerController.selectedCustomer.person.person_Address.length > 0) {
            return this.callerController.selectedCustomer.person.person_Address[0].address.addressLine1 + ", " + this.callerController.selectedCustomer.person.person_Address[0].address.city;
        }
    }

    set selectedCustomer(customerModel: customerModel) {
        this.callerController.selectedCustomer = customerModel;
    }

    public totalTransactionAmount(): number {
        if (this.callerController !== undefined) {
            return this.callerController.totalTransactionAmount();
        } else {
            return 0;
        }
    }

    public intializeCustomerFlipBookPagingInfo(search: string = null) {
        var self = this;
        self.customerPaging = new customerListSortingPagingInfo();
        self.customerPaging.currentPageIndex = 1;
        self.customerPaging.pageSize = 10;
        self.customerPaging.pageCount = 0;
        self.customerPaging.sortField = "IdCustomer";
        self.customerPaging.sortColumn = "idCustomer";

        self.customerPaging.sortByDesc = false;
        if (search != null)
            this.customerPaging.search = search;
    }

    public intializeFlipBookPagingInfo(search: string = null) {
        var self = this;
        self.productPaging = new productListSortingPagingInfo();
        self.productPaging.currentPageIndex = 1;
        self.productPaging.pageSize = 10;
        self.productPaging.pageCount = 0;
        self.productPaging.sortField = "IdProduct";
        self.productPaging.sortColumn = "idProduct";

        self.productPaging.sortByDesc = false;
        if (search != null)
            this.productPaging.search = search;
    }

    public getCustomerList() {
        var self = this;
        var sorting: customerListSortingPagingInfo = self.baseController.cloneObject(self.customerPaging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getCustomerList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<customerModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.customerPaging.pageCount = response.result.totalCount;
                    self.customerList = response.result.entityList;
                } else {
                }
            })
    }

    public getProductList() {
        var self = this;
        var sorting: productListSortingPagingInfo = self.baseController.cloneObject(self.productPaging);
        sorting.currentPageIndex--;
        self.subscriptionWebService.getProductList(sorting)
            .then(function (response: baseResultReturnType<baseListReturnType<productModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.productPaging.pageCount = response.result.totalCount;
                    self.productList = response.result.entityList;
                } else {
                }
            })
    }

    public onProductTypeIn(userInputString, event) {
        var self = this;

        if (event.keyCode == 13) {
            var sorting: productListSortingPagingInfo = self.baseController.cloneObject(self.productPaging);
            sorting.currentPageIndex--;
            sorting.search = userInputString;
            sorting.currentPageIndex = 0;
            sorting.pageSize = 15;
            self.subscriptionWebService.getProductList(sorting)
                .then(function (response: baseResultReturnType<baseListReturnType<any[]>>) {
                    if (response.status == STATUS_MESSAGE.SUCCESS) {
                        self.productList = response.result.entityList;
                        self.productPaging.pageCount = response.result.totalCount;
                        self.refreshProductListWithAddedItem();
                    } else {

                    }
                }).catch(function (errorMsg) {


                }).finally(function () {
                });
        }
    }

    public refreshProductListWithAddedItem() {
        var self = this;
        if (!self.baseController.isNullOrUndefined(self.customerList) && self.selectedTransactionDetail.product != null) {
            //remove any added customer from list
            self.productList = Enumerable.From(self.productList).Where(function (product: productModel) {
                return product.idProduct != null;
            }).ToArray();
            self.productList.unshift(self.selectedTransactionDetail.product);
        }
    }

    public addProduct() {
        var self = this;
        if (self.selectedTransactionDetail.product == null) {
            self.baseController.showMessage("Please enter product.", "", ALERT_MESSAGE_TYPE.WARNING);
            return
        }
        if (self.selectedTransactionDetail.rate == null) {
            self.baseController.showMessage("Please enter rate.", "", ALERT_MESSAGE_TYPE.WARNING);
            return
        }
        if (self.selectedTransactionDetail.quantity == null) {
            self.baseController.showMessage("Please enter quantity.", "", ALERT_MESSAGE_TYPE.WARNING);
            return
        }
        if (self.selectedTransactionDetail != null) {
            self.transactionDetails.push(self.selectedTransactionDetail);
            self.selectedTransactionDetail = new transactionDetailModel();
            self.selectedTransactionDetail.quantity = 1;
        } else {
            self.baseController.showMessage("Please enter product, amount and quantity.", "", ALERT_MESSAGE_TYPE.WARNING);
        }

        var result = document.getElementById("productName");
        var uiSelect = angular.element(result).controller('uiSelect');
        uiSelect.focusser[0].focus();
        uiSelect.activate();
    }

    public checkIfAvailableInScheduledTransactions(): boolean {
        var self = this;
        var arrayOfExistingTransactionDetails: transactionDetailModel[] = [];
        if (self.callerController.scheduledTransactionsForCustomer != undefined) {
            self.callerController.scheduledTransactionsForCustomer.forEach((t) => {
                t.transactionDetails.forEach((td) => {
                    if (!self.baseController.isNullOrUndefined(self.selectedTransactionDetail.product)) {
                        if (td.idProduct == self.selectedTransactionDetail.product.idProduct) {
                            arrayOfExistingTransactionDetails.push(td);
                        }
                    }
                });
            });
        }
        if (arrayOfExistingTransactionDetails != undefined && arrayOfExistingTransactionDetails.length > 0) {
            return true;
        }

        return false;
    }

    public searchProduct() {
        var self = this;
        self.baseController.showCustomModal(productSearchPopupModalController,
            self.baseController.globalVariableFactory.baseServerUrl + 'Subscription/Subscription/ProductSearchPopup',
            self,
            {
                $scope: self.scope
            },
            self.onSearchProductOk,
            () => { }
        );
    }

    public onSearchProductOk(product: { model: productModel, caller: any }) {
        var self = product.caller;
        self.selectedTransactionDetail.product = product.model;
        console.log(self.selectedCustomer)
    }

    public isSeeMoreClicked() {
        var self = this;
        self.seeMore = !self.seeMore;
    }

    public onCustomerTypeIn(userInputString, event) {
        var self = this;

        if (event.keyCode == 13) {
            var sorting: customerListSortingPagingInfo = self.baseController.cloneObject(self.customerPaging);
            sorting.currentPageIndex--;
            sorting.search = userInputString;
            sorting.currentPageIndex = 0;
            sorting.pageSize = 15;
            self.subscriptionWebService.getCustomerList(sorting)
                .then(function (response: baseResultReturnType<baseListReturnType<any[]>>) {
                    if (response.status == STATUS_MESSAGE.SUCCESS) {
                        self.customerList = response.result.entityList;
                        self.customerPaging.pageCount = response.result.totalCount;
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

    public removeTransactionDetail(transactionDetail: transactionDetailModel) {
        var self = this;
        self.transactionDetails.splice(self.transactionDetails.indexOf(transactionDetail), 1);
    }
}

selectTransactionModule.controller("selectTransactionController"
    , ["$scope"
        , "$filter"
        , "$parse"
        , "toaster"
        , "subscriptionWebService"
        , selectTransactionController
    ]);