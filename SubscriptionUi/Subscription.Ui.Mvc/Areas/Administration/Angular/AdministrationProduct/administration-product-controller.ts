class administrationProductController {
    scope;
    baseController: baseController;
    administrationProductWebService: administrationProductWebService;
    selectedTransactions: transactionModel[] = [];
    product: productModel;
    administrationNewProductController: administrationNewProductController;
    idProduct: number;
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

    registerNewProductController(administrationNewProductController: administrationNewProductController) {
        this.administrationNewProductController = administrationNewProductController;
    }

    public initialize() {
        var self = this;

    }

    public test() {
        console.log("Wawawawaaaa");
    }

    public saveProduct() {
        var self = this;
        var _saveAdministrationProductDto: saveAdministrationProductDto = new saveAdministrationProductDto();
        _saveAdministrationProductDto.product = self.product;
        self.administrationProductWebService.saveProduct(_saveAdministrationProductDto)
            .then(function (response: baseResultReturnType<saveAdministrationProductReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.baseController.showMessage('Success', 'Product Created Successfully', ALERT_MESSAGE_TYPE.SUCCESS, null, () => {
                        window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProductListing/";
                    })
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

    public setInfo(id: number, mode: SCREEN_MODE) {
        var self = this;
        console.log('id: ' + id + ', mode: ' + mode);
        //self.screenModeManager.currentMode = mode;
        if (id !== -1 && id > 0) {
            self.idProduct = id;
            self.loadEntity();
        }
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

administrationProductModule.controller("administrationProductController"
    , ["$scope"
        , "administrationProductWebService"
        , administrationProductController
    ]);