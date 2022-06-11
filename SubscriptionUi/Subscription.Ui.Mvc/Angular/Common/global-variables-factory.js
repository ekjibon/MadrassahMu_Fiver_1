var globalVariableFactory = /** @class */ (function () {
    function globalVariableFactory($rootScope, $window) {
        this.baseServerUrl = eval('globalBaseServerUrl'); //api url
        this.currentBaseServerUrl = eval('currentBaseServerUrl');
        this.serverUrl = this.baseServerUrl;
        this.isUserLoggedIn = eval('isUserLoggedIn');
        this.loggedInUserDetail = eval('loggedInUserDetail');
        this.sessionVariables = new sessionVariables();
        this.$window = $window;
        $rootScope.globalVariableFactory = this;
        globalVariableFactory.instance = this;
    }
    globalVariableFactory.prototype.clearSession = function () {
    };
    return globalVariableFactory;
}());
//# sourceMappingURL=global-variables-factory.js.map