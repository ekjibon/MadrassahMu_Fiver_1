var simpleEntityPopupController = /** @class */ (function () {
    function simpleEntityPopupController($scope, $uibModalInstance, $controller, caller, dataToPass) {
        this.$uibModalInstance = $uibModalInstance;
        this.$controller = $controller;
        this.$scope = $scope;
        $scope.modalController = this;
        this.caller = caller;
        this.service = dataToPass.service;
        this.model = dataToPass.model;
        this.screenMode = dataToPass.mode;
        this.initVariables();
    }
    simpleEntityPopupController.prototype.initVariables = function () {
        var self = this;
        self.$controller(baseController, {
            $scope: self.$scope
        });
        this.baseController = this.$scope.baseController;
    };
    simpleEntityPopupController.prototype.close = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    simpleEntityPopupController.prototype.ok = function () {
        var self = this;
        if (self.baseController.validateForm(self.$scope.simpleEntityPopupForm)) {
            self.baseController.showLoading();
            self.service.saveItem(self.model)
                .then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Item Saved");
                    self.$uibModalInstance.close({ model: response.result, caller: self.caller, mode: self.screenMode });
                }
                else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
                }
            })
                .catch(function (errorMsg) {
                self.baseController.showToast(TOASTER_TYPE.ERROR, errorMsg);
            })
                .finally(function () {
                self.baseController.hideLoading();
            });
        }
        else {
            self.baseController.showToast(TOASTER_TYPE.ERROR, "Validation Errors");
        }
    };
    return simpleEntityPopupController;
}());
//# sourceMappingURL=simple-entity-popup-controller.js.map