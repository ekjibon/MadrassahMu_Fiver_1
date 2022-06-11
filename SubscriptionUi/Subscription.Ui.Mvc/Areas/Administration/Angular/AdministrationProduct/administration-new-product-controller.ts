class administrationNewProductController {
    scope;
    baseController: baseController;
    administrationProductWebService: administrationProductWebService;
    selectedTransactions: transactionModel[] = [];
    idProduct: number;
    transactionSelected: boolean = false; //Added by Bilaal 28/01/21
    sum: number = 0;
    tess: string = "waaaaa";
    callerController;
    paymentAccounts = [
        { 'id': 1, 'description': 'Service' },
        { 'id': 2, 'description': 'Non Inventory' },
        { 'id': 3, 'description': 'Stock Asset' },
    ];
    productTypes = [
        { 'id': 1, 'description': 'Barclays' },
        { 'id': 2, 'description': 'Cash Account' },
        { 'id': 3, 'description': 'Stock Asset' },
    ];

    constructor($scope
        , administrationProductWebService
    ) {
        $scope.controller = this;
        this.scope = $scope;
        this.callerController = $scope.$parent.controller;
        this.baseController = $scope.baseController;
        this.administrationProductWebService = administrationProductWebService;
        this.callerController.registerNewProductController(this);
        this.initialize();
    }

    public initialize() {
        var self = this;
    }

    public test() {
        console.log("Wawawawaaaa");
    }

    public setInfo(id: number, mode: SCREEN_MODE) {
        var self = this;
        console.log('id: ' + id + ', mode: ' + mode);
        //self.screenModeManager.currentMode = mode;
        if (id !== -1 && id > 0) {
            self.idProduct = id;
            self.loadEntity();
        }
    }

    get product(): productModel {
        return this.callerController.product;
    }

    set product(product: productModel) {
        this.callerController.product = product;
    }

    public loadEntity() {
        var self = this;
        self.baseController.showLoading();
        var _getAdministrationProductDto = new getAdministrationProductDto();
        _getAdministrationProductDto.idProduct = self.idProduct;
        self.administrationProductWebService.getAdministrationProduct(_getAdministrationProductDto)
            .then(function (response: baseResultReturnType<getAdministrationProductReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.product = response.result.product;
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
    }
}

administrationProductModule.controller("administrationNewProductController"
    , ["$scope"
        , "administrationProductWebService"
        , administrationNewProductController
    ]);