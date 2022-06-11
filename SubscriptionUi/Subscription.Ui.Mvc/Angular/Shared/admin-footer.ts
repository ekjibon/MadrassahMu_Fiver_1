class adminFooterController {
    $scope;
    baseController: baseController;
    constructor($scope) {
        $scope.footerController = this;
        this.$scope = $scope;
        this.baseController = this.$scope.baseController;
        this.initVariables();
    }

    public initVariables() {
        var self = this;
    }

    public setInfo() {
        var self = this;
        self.baseController.addLoadedControllerInstance({ controllerName: "adminFooterController", instance: self })
    }
}