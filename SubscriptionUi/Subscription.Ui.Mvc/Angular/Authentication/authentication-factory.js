var authenticationFactory = /** @class */ (function () {
    function authenticationFactory($window, $rootScope, $q, globalVariableFactory, authenticationWebService, socialProvider) {
        this.$window = $window;
        this.$rootScope = $rootScope;
        this.$q = $q;
        this.globalVariableFactory = globalVariableFactory;
        this.authenticationWebService = authenticationWebService;
        this.socialProvider = socialProvider;
    }
    authenticationFactory.prototype.getAuthenticationInstance = function (_authenticationUserDetail) {
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
    };
    authenticationFactory.prototype.register = function (data) {
        var self = this;
        var deferred = self.$q.defer();
        self.authenticationWebService.register(data)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                if (response.result.signInStatus == LOGIN_STATUS.Success) {
                    deferred.resolve(response.result);
                }
                else {
                    deferred.reject("User not found or email and password combination invalid");
                }
            }
            else {
                deferred.reject(response.errorMessage);
            }
        }).catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    authenticationFactory.prototype.forgotPassword = function (data) {
        var self = this;
        var deferred = self.$q.defer();
        self.authenticationWebService.forgotPassword(data)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                deferred.resolve(response.result);
            }
            else {
                deferred.reject(response.errorMessage);
            }
        }).catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    authenticationFactory.prototype.resetPasswordExternal = function (data) {
        var self = this;
        var deferred = self.$q.defer();
        self.authenticationWebService.resetPasswordExternal(data)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                deferred.resolve();
            }
            else {
                deferred.reject(response.errorMessage);
            }
        }).catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    authenticationFactory.prototype.logOff = function () {
        var self = this;
        var deferred = self.$q.defer();
        self.authenticationWebService.logOff()
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                deferred.resolve(true);
            }
            else {
                deferred.reject(response.errorMessage);
            }
        }).catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    authenticationFactory.prototype.getLoggedUser = function () {
        var self = this;
        var deferred = self.$q.defer();
        self.authenticationWebService.getLoggedUser()
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                deferred.resolve(response.result);
            }
            else {
                deferred.reject(response.errorMessage);
            }
        }).catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    return authenticationFactory;
}());
var authenticationModule = angular.module('authenticationModule', []);
authenticationModule
    .provider("social", function () {
    var fbKey, fbApiV, googleKey, linkedInKey, identityLoginUrl, identityRegisterUrl;
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
            gJs.src = "//apis.google.com/js/platform.js";
            gJs.onload = function () {
                var params = {
                    client_id: value,
                    scope: 'email'
                };
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
            };
        }
    };
});
authenticationModule
    .factory("authenticationFactory", ["$window", "$rootScope", "$q", "globalVariableFactory", "authenticationWebService", "social", function ($window, $rootScope, $q, globalVariableFactory, authenticationWebService, socialProvider) { return new authenticationFactory($window, $rootScope, $q, globalVariableFactory, authenticationWebService, socialProvider); }]);
var authenticationWebService = /** @class */ (function () {
    function authenticationWebService(genericWebConnectionService, globalVariableFactory) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    authenticationWebService.prototype.register = function (data) {
        var url = 'Authentication/Authentication/RegisterWithCredential';
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.login = function (data) {
        var url = 'Authentication/Authentication/LoginWithCredential';
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.registerOrLogin = function (data) {
        var url = 'Authentication/Authentication/RegisterOrLoginWithSocial';
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.forgotPassword = function (data) {
        var url = 'Authentication/Authentication/ForgotPassword';
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.resetPasswordExternal = function (data) {
        var url = 'Authentication/Authentication/ResetPasswordExternal';
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.logOff = function () {
        var url = 'Authentication/Authentication/LogOut';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.getLoggedUser = function () {
        var url = 'Authentication/Authentication/GetLoggedUser';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    };
    authenticationWebService.prototype.getLinkedInUserDetailFromCode = function (code) {
        var url = 'Authentication/Authentication/GetLinkedInUserDetailFromCode';
        var data = {
            "code": code
        };
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return authenticationWebService;
}());
authenticationModule
    .service("authenticationWebService", [
    "genericWebConnectionService",
    "globalVariableFactory",
    authenticationWebService
]);
var authenticationUserDetail = /** @class */ (function () {
    function authenticationUserDetail() {
    }
    return authenticationUserDetail;
}());
var authenticationTypeEnum;
(function (authenticationTypeEnum) {
    authenticationTypeEnum[authenticationTypeEnum["FACEBOOK"] = 1] = "FACEBOOK";
    authenticationTypeEnum[authenticationTypeEnum["GOOGLE"] = 2] = "GOOGLE";
    authenticationTypeEnum[authenticationTypeEnum["LINKEDIN"] = 3] = "LINKEDIN";
    authenticationTypeEnum[authenticationTypeEnum["IDENTITY"] = 4] = "IDENTITY";
})(authenticationTypeEnum || (authenticationTypeEnum = {}));
var authenticationReturnType = /** @class */ (function () {
    function authenticationReturnType() {
    }
    return authenticationReturnType;
}());
var userWithoutConfidentialInfo = /** @class */ (function () {
    function userWithoutConfidentialInfo() {
    }
    return userWithoutConfidentialInfo;
}());
//# sourceMappingURL=authentication-factory.js.map