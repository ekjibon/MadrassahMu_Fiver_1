class facebookAuthentication implements authenticationInterface {
    $q: ng.IQService;
    authenticationWebService: authenticationWebService
    constructor($q, authenticationWebService) {
        this.$q = $q;
        this.authenticationWebService = authenticationWebService;
        this.initializeAuthentication();
    }

    private initializeAuthentication() {
        var self = this;
    }

    public login(): ng.IPromise<authenticationReturnType> {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();

        if (FB == undefined || FB == null) {
            deferred.reject("Facebook libraries not yet initialized, please try in 5 secs");
        }
        FB.getLoginStatus(function (response:any) {
            if (response.status == "connected") {
                self.fetchUserDetailAndLoginToServer(response.authResponse.accessToken).then(function (userDetails: authenticationReturnType) {
                    deferred.resolve(userDetails);
                }).catch(function (err) {
                    deferred.reject(err);
                })
            } else {
                FB.login(function (response) {
                    if (response.status === "connected") {
                        self.fetchUserDetailAndLoginToServer(response.authResponse.accessToken).then(function (userDetails: authenticationReturnType) {
                            deferred.resolve(userDetails);
                        }).catch(function (err) {
                            deferred.reject(err);
                        })
                    } else {
                        deferred.reject("Error occured while autenticating");
                    }
                }, { scope: 'public_profile,email', auth_type: 'rerequest' });
            }
        });
        return deferred.promise;
    }

    private fetchUserDetailAndLoginToServer(accessToken: string): ng.IPromise<authenticationReturnType>  {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();

        self.fetchUserDetails().then(function (userDetails: authenticationUserDetail) {
            userDetails.token = accessToken;
            self.authenticationWebService.registerOrLogin(userDetails).then(function (response: baseResultReturnType<authenticationReturnType>) {

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
                deferred.reject(error)
            })
        }).catch(function (error) {
            deferred.reject(error)
        })
        return deferred.promise;
    }

    private loginToServer(authenticationUser: authenticationUserDetail): ng.IPromise<authenticationReturnType> {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();

        self.authenticationWebService.registerOrLogin(authenticationUser).then(function (response: baseResultReturnType<authenticationReturnType>) {
            if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus == LOGIN_STATUS.Success) {
                deferred.resolve(response.result);
            } else {
                deferred.reject(response.errorMessage);
            }
        });
        return deferred.promise;
    }

    private fetchUserDetails(): ng.IPromise<authenticationUserDetail> {
        var self = this;
        let deferred: angular.IDeferred<authenticationUserDetail> = self.$q.defer();

        FB.api('/me?fields=first_name,last_name,email,picture', function (res) {
            if (!res || res.error) {
                deferred.reject('Error occured while fetching user details.');
            } else {
                var _authenticationUserDetail: authenticationUserDetail = new authenticationUserDetail();
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
    }

    public logout(): ng.IPromise<boolean> {
        var self = this;
        let deferred: angular.IDeferred<boolean> = self.$q.defer();

        FB.logout(function (res) {
            deferred.resolve(true);
        });
        return deferred.promise;

    }

    public register(): ng.IPromise<authenticationReturnType> {
        throw "Cannot Implement";
    }
}

declare var FB;
