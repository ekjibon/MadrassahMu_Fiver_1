var administrationNewProductController = /** @class */ (function () {
    function administrationNewProductController($scope, administrationProductWebService) {
        this.selectedTransactions = [];
        this.transactionSelected = false; //Added by Bilaal 28/01/21
        this.sum = 0;
        this.tess = "waaaaa";
        this.paymentAccounts = [
            { 'id': 1, 'description': 'Service' },
            { 'id': 2, 'description': 'Non Inventory' },
            { 'id': 3, 'description': 'Stock Asset' },
        ];
        this.productTypes = [
            { 'id': 1, 'description': 'Barclays' },
            { 'id': 2, 'description': 'Cash Account' },
            { 'id': 3, 'description': 'Stock Asset' },
        ];
        $scope.controller = this;
        this.scope = $scope;
        this.callerController = $scope.$parent.controller;
        this.baseController = $scope.baseController;
        this.administrationProductWebService = administrationProductWebService;
        this.callerController.registerNewProductController(this);
        this.initialize();
    }
    administrationNewProductController.prototype.initialize = function () {
        var self = this;
    };
    administrationNewProductController.prototype.test = function () {
        console.log("Wawawawaaaa");
    };
    administrationNewProductController.prototype.setInfo = function (id, mode) {
        var self = this;
        console.log('id: ' + id + ', mode: ' + mode);
        //self.screenModeManager.currentMode = mode;
        if (id !== -1 && id > 0) {
            self.idProduct = id;
            self.loadEntity();
        }
    };
    Object.defineProperty(administrationNewProductController.prototype, "product", {
        get: function () {
            return this.callerController.product;
        },
        set: function (product) {
            this.callerController.product = product;
        },
        enumerable: false,
        configurable: true
    });
    administrationNewProductController.prototype.loadEntity = function () {
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
    return administrationNewProductController;
}());
administrationProductModule.controller("administrationNewProductController", ["$scope",
    "administrationProductWebService",
    administrationNewProductController
]);
//# sourceMappingURL=administration-new-product-controller.js.map