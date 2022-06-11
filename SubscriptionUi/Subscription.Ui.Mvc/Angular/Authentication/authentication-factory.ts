class authenticationFactory {
    $window
    $rootScope
    $q: ng.IQService;
    globalVariableFactory: globalVariableFactory;
    authenticationWebService: authenticationWebService;
    socialProvider;
    constructor($window, $rootScope, $q, globalVariableFactory, authenticationWebService, socialProvider) {
        this.$window = $window;
        this.$rootScope = $rootScope;
        this.$q = $q;
        this.globalVariableFactory = globalVariableFactory;
        this.authenticationWebService = authenticationWebService;
        this.socialProvider = socialProvider;
    }

    public getAuthenticationInstance(_authenticationUserDetail: authenticationUserDetail) {
        var self = this;
        switch (_authenticationUserDetail.provider) {
            case authenticationTypeEnum.FACEBOOK:
                return new facebookAuthentication(self.$q, self.authenticationWebService);
            case authenticationTypeEnum.GOOGLE:
                return new googleAuthentication(self.$q, self.authenticationWebService);
            case authenticationTypeEnum.LINKEDIN:
                return new linkedinAuthentication(self.$q, self.authenticationWebService, self.socialProvider);
            case authenticationTypeEnum.IDENTITY:
                return new identityAuthentication(self.$q, _authenticationUserDetail, self.authenticationWebService);
        }
    }

    public register(data): ng.IPromise<authenticationReturnType> {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();
        self.authenticationWebService.register(data)
            .then(function (response: baseResultReturnType<authenticationReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    if (response.result.signInStatus == LOGIN_STATUS.Success) {
                        deferred.resolve(response.result);
                    } else {
                        deferred.reject("User not found or email and password combination invalid");
                    }
                } else {
                    deferred.reject(response.errorMessage);
                }
            }).catch(function (error) {
                deferred.reject(error);
            })

        return deferred.promise;
    }

    public forgotPassword(data): ng.IPromise<forgotPasswordReturnType> {
        var self = this;
        let deferred: angular.IDeferred<forgotPasswordReturnType> = self.$q.defer();

        self.authenticationWebService.forgotPassword(data)
            .then(function (response: baseResultReturnType<forgotPasswordReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    deferred.resolve(response.result);
                } else {
                    deferred.reject(response.errorMessage);
                }
            }).catch(function (error) {
                deferred.reject(error);
            })

        return deferred.promise;
    }

    public resetPasswordExternal(data): ng.IPromise<string> {
        var self = this;
        let deferred: angular.IDeferred<string> = self.$q.defer();

        self.authenticationWebService.resetPasswordExternal(data)
            .then(function (response: baseResultReturnType<boolean>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    deferred.resolve();
                } else {
                    deferred.reject(response.errorMessage);
                }
            }).catch(function (error) {
                deferred.reject(error);
            })

        return deferred.promise;
    }

    public logOff(): ng.IPromise<boolean> {
        var self = this;
        let deferred: angular.IDeferred<boolean> = self.$q.defer();

        self.authenticationWebService.logOff()
            .then(function (response: baseResultReturnType<boolean>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    deferred.resolve(true);
                } else {
                    deferred.reject(response.errorMessage);
                }
            }).catch(function (error) {
                deferred.reject(error);
            })

        return deferred.promise;
    }

    public getLoggedUser(): ng.IPromise<userWithoutConfidentialInfo> {
        var self = this;
        let deferred: angular.IDeferred<userWithoutConfidentialInfo> = self.$q.defer();

        self.authenticationWebService.getLoggedUser()
            .then(function (response: baseResultReturnType<userWithoutConfidentialInfo>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    deferred.resolve(response.result);
                } else {
                    deferred.reject(response.errorMessage);
                }
            }).catch(function (error) {
                deferred.reject(error);
            })

        return deferred.promise;
    }
}

declare var gapi;
declare var FB;
declare var IN;

var authenticationModule = angular.module('authenticationModule', []);
authenticationModule
    .provider("social", function () {
        var fbKey, fbApiV, googleKey, linkedInKey, identityLoginUrl, identityRegisterUrl
        return {
            setFbKey: function (obj) {
                fbKey = obj.appId;
                fbApiV = obj.apiVersion;
                var d = document, fbJs, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
                fbJs = d.createElement('script');
                fbJs.id = id;
                fbJs.async = true;
                fbJs.src = "//connect.facebook.net/en_US/sdk.js";

                fbJs.onload = function () {
                    FB.init({
                        appId: fbKey,
                        status: true,
                        cookie: true,
                        xfbml: true,
                        version: fbApiV
                    });
                };

                ref.parentNode.insertBefore(fbJs, ref);
            },
            setGoogleKey: function (value) {
                googleKey = value;
                var d = document, gJs, ref = d.getElementsByTagName('script')[0];
                gJs = d.createElement('script');
                gJs.async = true;
                gJs.src = "//apis.google.com/js/platform.js"

                gJs.onload = function () {
                    var params = {
                        client_id: value,
                        scope: 'email'
                    }
                    gapi.load('auth2', function () {
                        gapi.auth2.init(params);
                    });
                };

                ref.parentNode.insertBefore(gJs, ref);
            },

            setLinkedInKey: function (obj) {
                linkedInKey = obj;
                //var lIN, d = document, ref = d.getElementsByTagName('script')[0];
                //lIN = d.createElement('script');
                //lIN.async = false;
                //lIN.src = "//platform.linkedin.com/in.js";
                //lIN.text = ("api_key: " + linkedInKey).replace("\"", "");
                //ref.parentNode.insertBefore(lIN, ref);
            },
            setIdentityKey: function (obj) {
                identityLoginUrl = obj.loginUrl;
                identityRegisterUrl = obj.registerUrl;
            },
            $get: function () {
                return {
                    fbKey: fbKey,
                    googleKey: googleKey,
                    linkedInKey: linkedInKey,
                    fbApiV: fbApiV
                }
            }
        }
    });

authenticationModule
    .factory("authenticationFactory", ["$window", "$rootScope", "$q", "globalVariableFactory", "authenticationWebService", "social", function ($window, $rootScope, $q, globalVariableFactory, authenticationWebService, socialProvider) { return new authenticationFactory($window, $rootScope, $q, globalVariableFactory, authenticationWebService, socialProvider); }]);

class authenticationWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService, globalVariableFactory) {
        this.genericWebConnectionService = genericWebConnectionService;
    }

    public register(data): ng.IPromise<baseResultReturnType<authenticationReturnType>> {
        var url = 'Authentication/Authentication/RegisterWithCredential';
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public login(data): ng.IPromise<baseResultReturnType<authenticationReturnType>> {
        var url = 'Authentication/Authentication/LoginWithCredential';
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public registerOrLogin(data): ng.IPromise<baseResultReturnType<authenticationReturnType>> {
        var url = 'Authentication/Authentication/RegisterOrLoginWithSocial';
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public forgotPassword(data): ng.IPromise<baseResultReturnType<forgotPasswordReturnType>> {
        var url = 'Authentication/Authentication/ForgotPassword';
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public resetPasswordExternal(data): ng.IPromise<baseResultReturnType<boolean>> {
        var url = 'Authentication/Authentication/ResetPasswordExternal';
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public logOff(): ng.IPromise<baseResultReturnType<boolean>> {
        var url = 'Authentication/Authentication/LogOut';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getLoggedUser(): ng.IPromise<baseResultReturnType<userWithoutConfidentialInfo>> {
        var url = 'Authentication/Authentication/GetLoggedUser';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getLinkedInUserDetailFromCode(code: string): ng.IPromise<baseResultReturnType<authenticationUserDetail>> {
        var url = 'Authentication/Authentication/GetLinkedInUserDetailFromCode';
        var data = {
            "code": code
        };
        return this.genericWebConnectionService.postRequest(url, data);
    }
}

authenticationModule
    .service("authenticationWebService", [
        "genericWebConnectionService"
        , "globalVariableFactory"
        , authenticationWebService
    ]);

//CLASSES
interface authenticationInterface {
    login(): ng.IPromise<authenticationReturnType>
    logout(): ng.IPromise<boolean>
    register(): ng.IPromise<authenticationReturnType>
}

class authenticationUserDetail {
    public firstname: string;
    public lastname: string;
    public email: string;
    public password: string;
    public uid: string;
    public provider: authenticationTypeEnum;
    public imageUrl: string;
    public token: string;
}

enum authenticationTypeEnum {
    FACEBOOK = 1,
    GOOGLE = 2,
    LINKEDIN = 3,
    IDENTITY = 4
}

class authenticationReturnType {
    public signInStatus: LOGIN_STATUS;
    public needPasswordChange: boolean;
    public userWithoutConfidentialInfo: userWithoutConfidentialInfo;
}

class userWithoutConfidentialInfo {
    public username: string;
    public email: string;
    public firstname: string;
    public lastname: string;
    public idUser: number;
    public idPerson: number;
    public idLoginProvider: number;
    public roles: roleModel[];
    public combinedPermission: combinedPermissionModel[];
}

