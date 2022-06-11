class loadingController<Y> {
    baseController: baseController;
    $uibModalInstance;
    $controller;
    $scope;
    caller:Y ;

    constructor($scope
        , $uibModalInstance
        , $controller
        , caller: Y
        , dataToPass: { }) {
        this.$uibModalInstance = $uibModalInstance;
        this.$controller = $controller;
        this.$scope = $scope;
        $scope.loadingController = this;
        this.caller = caller;
        this.initVariables();
    }

    public initVariables() {
        var self = this;
        self.$controller(baseController, {
            $scope: self.$scope
        });
        self.baseController = self.$scope.baseController;
    }


    public close() {
        this.$uibModalInstance.dismiss('cancel');
    }
}