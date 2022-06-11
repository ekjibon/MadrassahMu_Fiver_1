class simpleEntityPopupController<K, Y> {
    baseController: baseController;
    service: baseWebService<K>;
    $uibModalInstance;
    $controller;
    $scope;
    caller: Y;
    model: K;
    screenMode: SCREEN_MODE;
    constructor($scope
        , $uibModalInstance
        , $controller
        , caller: Y
        , dataToPass: { model: K, mode: SCREEN_MODE, service: baseWebService<K> }) {
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

    public initVariables() {
        var self = this;
        self.$controller(baseController, {
            $scope: self.$scope
        });
        this.baseController = this.$scope.baseController;
    }

    public close() {
        this.$uibModalInstance.dismiss('cancel');
    }
    public ok() {
        var self = this;
        if (self.baseController.validateForm(self.$scope.simpleEntityPopupForm)) {
            self.baseController.showLoading();
            self.service.saveItem(self.model)
                .then(function (response: baseResultReturnType<K>) {
                    if (response.status == STATUS_MESSAGE.SUCCESS) {
                        self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Item Saved");
                        self.$uibModalInstance.close({ model: response.result, caller: self.caller, mode: self.screenMode });
                    } else {
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
    }
}
