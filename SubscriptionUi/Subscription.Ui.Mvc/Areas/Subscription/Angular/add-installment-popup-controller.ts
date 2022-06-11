class addInstallmentPopupController<Y> {
    baseController: baseController;
    installment: installmentModel;
    $uibModalInstance;
    $scope;
    caller: Y;

    constructor($scope, $uibModalInstance, $controller, caller: Y, dataToPass: { $scope },) {
        $scope.modalController = this;
        this.$uibModalInstance = $uibModalInstance;
        this.$scope = $scope;
        this.baseController = dataToPass.$scope.baseController;
        this.caller = caller;
    }

    public cancel() {
        this.$uibModalInstance.dismiss('cancel');
    }

    public onOk(action: any) {
        var self = this;
        self.$uibModalInstance.close({ model: self.installment, caller: self.caller });
    }
}

scheduleTransactionModule.controller("addInstallmentPopupController"
    , ["$scope"
        , "$uibModalInstance"
        , "dataToPass"
        , addInstallmentPopupController
    ]);