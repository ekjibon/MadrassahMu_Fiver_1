var loadingController = /** @class */ (function () {
    function loadingController($scope, $uibModalInstance, $controller, caller, dataToPass) {
        this.$uibModalInstance = $uibModalInstance;
        this.$controller = $controller;
        this.$scope = $scope;
        $scope.loadingController = this;
        this.caller = caller;
        this.initVariables();
    }
    loadingController.prototype.initVariables = function () {
        var self = this;
        self.$controller(baseController, {
            $scope: self.$scope
        });
        self.baseController = self.$scope.baseController;
    };
    loadingController.prototype.close = function () {
        this.$uibModalInstance.dismiss('cancel');
    };
    return loadingController;
}());
//# sourceMappingURL=loading-controller.js.map