var adminHeaderController = /** @class */ (function () {
    function adminHeaderController($scope) {
        $scope.headerController = this;
        this.$scope = $scope;
        this.baseController = this.$scope.baseController;
        this.initVariables();
    }
    adminHeaderController.prototype.initVariables = function () {
        var self = this;
    };
    adminHeaderController.prototype.setInfo = function () {
        var self = this;
        self.baseController.addLoadedControllerInstance({ controllerName: "adminHeaderController", instance: self });
    };
    adminHeaderController.prototype.toggleSidebar = function () {
        var self = this;
        if (!self.baseController.layoutCustomisation.layout.isSidebarToggable) {
            self.baseController.showToast(TOASTER_TYPE.WARNING, "Sidebar Not Enabled In This View");
        }
        else {
            self.baseController.layoutCustomisation.layout.isSidebarClosed = !self.baseController.layoutCustomisation.layout.isSidebarClosed;
            self.baseController.saveTemplateLayout();
        }
    };
    return adminHeaderController;
}());
//# sourceMappingURL=admin-header.js.map