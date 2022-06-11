class adminHeaderController {
    $scope;
    baseController: baseController;
    constructor($scope) {
        $scope.headerController = this;
        this.$scope = $scope;
        this.baseController = this.$scope.baseController;
        this.initVariables();
    }

    public initVariables() {
        var self = this;
    }

    public setInfo() {
        var self = this;
        self.baseController.addLoadedControllerInstance({ controllerName: "adminHeaderController", instance: self })
    }

    public toggleSidebar() {
        var self = this;
        if (!self.baseController.layoutCustomisation.layout.isSidebarToggable) {
            self.baseController.showToast(TOASTER_TYPE.WARNING, "Sidebar Not Enabled In This View");
        } else {
            self.baseController.layoutCustomisation.layout.isSidebarClosed = !self.baseController.layoutCustomisation.layout.isSidebarClosed;
            self.baseController.saveTemplateLayout();
        }
    }
}