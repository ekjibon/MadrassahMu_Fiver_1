var facebookAuthentication = /** @class */ (function () {
    function facebookAuthentication($q, authenticationWebService) {
        this.$q = $q;
        this.authenticationWebService = authenticationWebService;
        this.initializeAuthentication();
    }
    facebookAuthentication.prototype.initializeAuthentication = function () {
        var self = this;
    };
    facebookAuthentication.prototype.login = function () {
        var self = this;
        var deferred = self.$q.defer();
        if (FB == undefined || FB == null) {
            deferred.reject("Facebook libraries not yet initialized, please try in 5 secs");
        }
        FB.getLoginStatus(function (response) {
            if (response.status == "connected") {
                self.fetchUserDetailAndLoginToServer(response.authResponse.accessToken).then(function (userDetails) {
                    deferred.resolve(userDetails);
                }).catch(function (err) {
                    deferred.reject(err);
                });
            }
            else {
                FB.login(function (response) {
                    if (response.status === "connected") {
                        self.fetchUserDetailAndLoginToServer(response.authResponse.accessToken).then(function (userDetails) {
                            deferred.resolve(userDetails);
                        }).catch(function (err) {
                            deferred.reject(err);
                        });
                    }
                    else {
                        deferred.reject("Error occured while autenticating");
                    }
                }, { scope: 'public_profile,email', auth_type: 'rerequest' });
            }
        });
        return deferred.promise;
    };
    facebookAuthentication.prototype.fetchUserDetailAndLoginToServer = function (accessToken) {
        var self = this;
        var deferred = self.$q.defer();
        self.fetchUserDetails().then(function (userDetails) {
            userDetails.token = accessToken;
            self.authenticationWebService.registerOrLogin(userDetails).then(function (response) {
                if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus == LOGIN_STATUS.Success) {
                    deferred.resolve(response.result);
                }
                if (response.status == STATUS_MESSAGE.FAILURE) {
                    deferred.reject(response.errorMessage);
                }
                if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus != LOGIN_STATUS.Success) {
                    deferred.reject("Invalid credentials supplied");
                }
            }).catch(function (error) {
                deferred.reject(error);
            });
        }).catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    facebookAuthentication.prototype.loginToServer = function (authenticationUser) {
        var self = this;
        var deferred = self.$q.defer();
        self.authenticationWebService.registerOrLogin(authenticationUser).then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus == LOGIN_STATUS.Success) {
                deferred.resolve(response.result);
            }
            else {
                deferred.reject(response.errorMessage);
            }
        });
        return deferred.promise;
    };
    facebookAuthentication.prototype.fetchUserDetails = function () {
        var self = this;
        var deferred = self.$q.defer();
        FB.api('/me?fields=first_name,last_name,email,picture', function (res) {
            if (!res || res.error) {
                deferred.reject('Error occured while fetching user details.');
            }
            else {
                var _authenticationUserDetail = new authenticationUserDetail();
                _authenticationUserDetail.firstname = res.first_name;
                _authenticationUserDetail.lastname = res.last_name;
                _authenticationUserDetail.email = res.email;
                _authenticationUserDetail.uid = res.id;
                _authenticationUserDetail.provider = authenticationTypeEnum.FACEBOOK;
                _authenticationUserDetail.imageUrl = res.picture.data.url;
                deferred.resolve(_authenticationUserDetail);
            }
        });
        return deferred.promise;
    };
    facebookAuthentication.prototype.logout = function () {
        var self = this;
        var deferred = self.$q.defer();
        FB.logout(function (res) {
            deferred.resolve(true);
        });
        return deferred.promise;
    };
    facebookAuthentication.prototype.register = function () {
        throw "Cannot Implement";
    };
    return facebookAuthentication;
}());
//# sourceMappingURL=facebook-authentication.js.map