var addInstallmentPopupController = /** @class */ (function () {
    function addInstallmentPopupController($scope, $uibModalInstance, $controller, caller, dataToPass) {
        $scope.modalController = this;
        this.$uibModalInstance = $uibModalInstance;
        this.$scope = $scope;
        this.baseController = dataToPass.$scope.baseController;
        this.caller = caller;
    }
    addInstallmentPopupController.prototype.cancel = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    addInstallmentPopupController.prototype.onOk = function (action) {
        var self = this;
        self.$uibModalInstance.close({ model: self.installment, caller: self.caller });
    };
    return addInstallmentPopupController;
}());
scheduleTransactionModule.controller("addInstallmentPopupController", ["$scope",
    "$uibModalInstance",
    "dataToPass",
    addInstallmentPopupController
]);
//# sourceMappingURL=add-installment-popup-controller.js.map