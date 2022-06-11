class globalVariableFactory {
    public baseServerUrl = eval('globalBaseServerUrl');//api url

    public currentBaseServerUrl = eval('currentBaseServerUrl');

    public serverUrl: string = this.baseServerUrl;

    public sessionVariables: sessionVariables;

    public $window;

    public isUserLoggedIn: boolean = eval('isUserLoggedIn');
    public loggedInUserDetail: userWithoutConfidentialInfo = eval('loggedInUserDetail');

    public static instance: globalVariableFactory;

    constructor($rootScope, $window) {
        this.sessionVariables = new sessionVariables();
        this.$window = $window;
        $rootScope.globalVariableFactory = this;
        globalVariableFactory.instance = this;
    }

    public clearSession() {

    }
}
