class authenticationController {
    scope;
    baseController: baseController;
    $controller;
    authenticationEnums;
    //toaster;
    test: string = "yooooooooooooooooo";
    preloadedData: {} = {};
    authDto: {
        email: string,
        password: string,
        confirmPassword: string,
        firstname: string,
        lastname: string
    }
        = {
            email: "stestportal@gmail.com",
            password: "rE!U[DE",
            confirmPassword: "rE!U[DE",
            firstname: "Samim",
            lastname: "Mohabuth"
        };
    formValidator: formValidator;
    formName: string = "authForm";
    authScreenStateEnum;
    authScreenState;
    token: string;
    IdWorkstation: string;
    constructor($scope
        , $controller
        , $window) {
        var self = this;

        $scope.controller = this;
        this.$controller = $controller;
        this.scope = $scope;
        this.baseController = this.scope.baseController;
        this.initVariables();
        console.log("wawawa " + self.authScreenState);
        //this.toaster = toaster;
    }

    public initVariables() {
        var self = this;
        this.baseController = this.scope.baseController;
        this.authScreenStateEnum = authScreenStateEnum;
        this.authScreenState = authScreenStateEnum.LOGIN;
        console.log("wawawa " + self.authScreenState);
    }

    public setInfo(token: string, action: number, message: string) {
        var self = this;
        console.log("wawawa " + self.authScreenState);
        console.log("token " + token);
        console.log("action " + action);
        self.token = token;
        if (!self.baseController.isNullOrUndefined(self.token) && self.token != '') {
            self.authScreenState = authScreenStateEnum.RESETPASSWORD;
        }

        if (action != -1) {
            self.authScreenState = action;
        }
        self.registerValidations();
        if (!self.baseController.isNullOrUndefined(message) && message != "") {
            self.baseController.showMessage(message, "", ALERT_MESSAGE_TYPE.ERROR)
        }
    }

    public authScreenToggle(authScreenState: authScreenStateEnum) {
        var self = this;
        self.authScreenState = authScreenState;
        self.registerValidations();
    }

    private registerValidations() {
        var self = this;
        self.formValidator = new formValidator(self.baseController.$parse, self.baseController.toaster, self.scope, self.formName);

        if (self.authScreenState == authScreenStateEnum.REGISTER) {
            self.formValidator.registerValidationForMandatory(self.scope, 'registerFirstname', 'First Name');
            self.formValidator.registerValidationForMandatory(self.scope, 'registerLastname', 'Last Name');
            self.formValidator.registerValidationForEmail(self.scope, 'registerEmail', 'Email');
            self.formValidator.registerValidationForMandatory(self.scope, 'registerPassword', 'Password');
            self.registerConfirmPasswordValidation('registerConfirmPassword');
        }
        else if (self.authScreenState == authScreenStateEnum.LOGIN) {
            self.formValidator.registerValidationForEmail(self.scope, 'loginEmail', 'Email');
            self.formValidator.registerValidationForMandatory(self.scope, 'loginPassword', 'Password');
            self.formValidator.registerValidationForMandatory(self.scope, 'workstationId', 'Workstation Id');
        }
        else if (self.authScreenState == authScreenStateEnum.FORGOTPASSWORD) {
            self.formValidator.registerValidationForEmail(self.scope, 'forgotPasswordEmail', 'Email');
        }
        else if (self.authScreenState == authScreenStateEnum.RESETPASSWORD) {

            self.formValidator.registerValidationForMandatory(self.scope, 'resetPasswordPassword', 'Password');
            self.registerConfirmPasswordValidation('resetPasswordConfirmPassword');
        }
    }

    public registerConfirmPasswordValidation(fieldName: string) {
        var self = this;
        self.formValidator.registerValidation("controller.authDto.confirmPassword", "Confirm password does not match", function () {
            if (self.authDto.password != self.authDto.confirmPassword) {
                return false;
            }
            return true;
        });
    }

    public login(authenticationType: authenticationTypeEnum) {
      
        var self = this;
        //self.baseController.showMessage("redirecting", "tttt", ALERT_MESSAGE_TYPE.ERROR);
        //self.baseController.showToast("info", "redirecting","Login successful");
        var isValid: boolean = self.formValidator.validateForm(true);
        if (!isValid)
            return;

        var _authenticationDetail: authenticationUserDetail = new authenticationUserDetail();
        _authenticationDetail.provider = authenticationType;

        if (authenticationType == authenticationTypeEnum.IDENTITY) {
            _authenticationDetail.email = self.authDto.email;
            _authenticationDetail.password = self.authDto.password;
        }
        self.baseController.showLoading();
        self.baseController.authenticationFactory.getAuthenticationInstance(_authenticationDetail).login()
            .then(function (userDetail: authenticationReturnType) {
                self.baseController.$localStorage.setItem(localStorageKey.IdWorkstation, self.IdWorkstation);
                self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Login successful, redirecting...");
                self.baseController.redirectToUrlFromBase(URL_LIST.TRANSACTION);
            }).catch(function (error) {
                self.baseController.showMessage(error, "", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            })
    }

    public register() {
        var self = this;
        var isValid: boolean = self.formValidator.validateForm(true);
        if (!isValid)
            return;

        var data = { email: self.authDto.email, password: self.authDto.password };
        self.baseController.showLoading();
        self.baseController.authenticationFactory.register(data)
            .then(function (userDetail: authenticationReturnType) {
                self.baseController.redirectToUrlFromBase(URL_LIST.TRANSACTION);
                self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Registration successfull, redirecting...");
            }).catch(function (error) {
                self.baseController.showMessage(error, "", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            })
    }

    public forgotPassword() {
        var self = this;
        var isValid: boolean = self.formValidator.validateForm(true);
        if (!isValid)
            return;

        var data = { email: self.authDto.email };
        self.baseController.showLoading();
        self.baseController.authenticationFactory.forgotPassword(data)
            .then(function (response: forgotPasswordReturnType) {
                self.baseController.showMessage("Please check your mail for further instructions to reset your password", "", ALERT_MESSAGE_TYPE.WARNING);
                self.baseController.redirectToUrlFromBase(URL_LIST.AUTH);
            }).catch(function (error) {
                self.baseController.showMessage(error, "", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            })
    }

    public resetPassword() {
        var self = this;
        var isValid: boolean = self.formValidator.validateForm(true);
        if (!isValid)
            return;

        var data = { token: self.token, password: self.authDto.password }
        self.baseController.showLoading();
        self.baseController.authenticationFactory.resetPasswordExternal(data)
            .then(function () {
                self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Password reset, please login with your new password, redirecting...");
                self.baseController.redirectToUrlFromBase(URL_LIST.AUTH);
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
    }
}

authModule.controller("authenticationController"
    , ["$scope"
        , "$controller"
        , "$window"
        , authenticationController
    ]);