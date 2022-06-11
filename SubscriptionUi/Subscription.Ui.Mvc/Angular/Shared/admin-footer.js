var adminFooterController = /** @class */ (function () {
    function adminFooterController($scope) {
        $scope.footerController = this;
        this.$scope = $scope;
        this.baseController = this.$scope.baseController;
        this.initVariables();
    }
    adminFooterController.prototype.initVariables = function () {
        var self = this;
    };
    adminFooterController.prototype.setInfo = function () {
        var self = this;
        self.baseController.addLoadedControllerInstance({ controllerName: "adminFooterController", instance: self });
    };
    return adminFooterController;
}());
//# sourceMappingURL=admin-footer.js.map