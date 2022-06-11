var administrationProductController = /** @class */ (function () {
    function administrationProductController($scope, administrationProductWebService) {
        this.selectedTransactions = [];
        this.transactionSelected = false; //Added by Bilaal 28/01/21
        this.sum = 0;
        this.tess = "waaaaa";
        $scope.controller = this;
        this.scope = $scope;
        this.baseController = $scope.baseController;
        this.administrationProductWebService = administrationProductWebService;
        this.initialize();
    }
    administrationProductController.prototype.registerNewProductController = function (administrationNewProductController) {
        this.administrationNewProductController = administrationNewProductController;
    };
    administrationProductController.prototype.initialize = function () {
        var self = this;
    };
    administrationProductController.prototype.test = function () {
        console.log("Wawawawaaaa");
    };
    administrationProductController.prototype.saveProduct = function () {
        var self = this;
        var _saveAdministrationProductDto = new saveAdministrationProductDto();
        _saveAdministrationProductDto.product = self.product;
        self.administrationProductWebService.saveProduct(_saveAdministrationProductDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.baseController.showMessage('Success', 'Product Created Successfully', ALERT_MESSAGE_TYPE.SUCCESS, null, function () {
                    window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Administration/AdministrationProduct/AdministrationProductListing/";
                });
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            }
        })
            .catch(function (error) {
            self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
        })
            .finally(function () {
        });
    };
    administrationProductController.prototype.setInfo = function (id, mode) {
        var self = this;
        console.log('id: ' + id + ', mode: ' + mode);
        //self.screenModeManager.currentMode = mode;
        if (id !== -1 && id > 0) {
            self.idProduct = id;
            self.loadEntity();
        }
    };
    administrationProductController.prototype.loadEntity = function () {
        var self = this;
        self.baseController.showLoading();
        var _getAdministrationProductDto = new getAdministrationProductDto();
        _getAdministrationProductDto.idProduct = self.idProduct;
        self.administrationProductWebService.getAdministrationProduct(_getAdministrationProductDto)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.product = response.result.product;
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
            }
        }).catch(function (errorMsg) {
            self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
        }).finally(function () {
            self.baseController.hideLoading();
        });
    };
    return administrationProductController;
}());
administrationProductModule.controller("administrationProductController", ["$scope",
    "administrationProductWebService",
    administrationProductController
]);
//# sourceMappingURL=administration-product-controller.js.map