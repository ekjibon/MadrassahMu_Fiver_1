var adminSidebarController = /** @class */ (function () {
    function adminSidebarController($scope) {
        $scope.footerController = this;
        this.$scope = $scope;
        this.baseController = this.$scope.baseController;
        this.initVariables();
    }
    adminSidebarController.prototype.initVariables = function () {
        var self = this;
    };
    adminSidebarController.prototype.setInfo = function () {
        var self = this;
        self.baseController.addLoadedControllerInstance({ controllerName: "adminSidebarController", instance: self });
    };
    return adminSidebarController;
}());
//# sourceMappingURL=admin-sidebar.js.map