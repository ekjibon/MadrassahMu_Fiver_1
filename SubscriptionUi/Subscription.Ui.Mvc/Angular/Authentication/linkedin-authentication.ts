class linkedinAuthentication implements authenticationInterface {
    $q: ng.IQService;
    authenticationWebService: authenticationWebService
    socialProvider;
    constructor($q, authenticationWebService, socialProvider) {
        this.$q = $q;
        this.authenticationWebService = authenticationWebService;
        this.socialProvider = socialProvider;
        this.initializeAuthentication();
    }

    private initializeAuthentication() {
        var self = this;
    }

    public login(): ng.IPromise<authenticationReturnType> {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();

        var linkedInKey = self.socialProvider.linkedInKey;
        var url = "https://www.linkedin.com/oauth/v2/authorization?response_type=code&client_id=" + linkedInKey.clientId + "&redirect_uri=" + linkedInKey.redirectUrl + "&state=fooobar&scope=r_liteprofile%20r_emailaddress%20w_member_social";
        var child = window.open(url, '', 'toolbar=0,status=0,width=626,height=436');
        var timer = setInterval(checkChild, 500);

        function checkChild() {
            var code = null;
            var canProceedWithCheck = true;
            try {
                canProceedWithCheck = child.location.href != undefined;
            }
            catch (err) {
                canProceedWithCheck = false;
            }

            if (canProceedWithCheck && child.location.href.indexOf(linkedInKey.redirectUrl) > -1) {
                var redirectedUrl = new URL(child.location.href);
                clearInterval(timer);
                child.close();

                code = redirectedUrl.searchParams.get("code");
                if (code == null || code == undefined || code == "") {
                    var error = redirectedUrl.searchParams.get("error_description");
                    deferred.reject(error);
                } else {
                    self.fetchUserDetails(code).then(function (authenticationUser: authenticationUserDetail) {
                        self.authenticationWebService.registerOrLogin(authenticationUser).then(function (response: baseResultReturnType<authenticationReturnType>) {
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
                    }).catch(function () {
                        deferred.reject("Error occured while fetching user details.");
                    })
                }
            }
            else if (child.closed && code == null) {
                clearInterval(timer);
                deferred.reject("User cancelled authorization");
            }
        }

        return deferred.promise;
    }

    //public login(): ng.IPromise<authenticationReturnType> {
    //    var self = this;
    //    var deferred = self.$q.defer();

    //    if (IN == undefined || IN == null) {
    //        deferred.reject("Linkedin libraries not yet initialized, please try in 5 secs");
    //    }

    //    IN.User.authorize(function () {
    //        self.fetchUserDetails().then(function (authenticationUser: authenticationUserDetail) {
    //            self.authenticationWebService.registerOrLogin(authenticationUser).then(function (response: baseResultReturnType<authenticationReturnType>) {
    //                if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus == LOGIN_STATUS.Success) {
    //                    deferred.resolve(response.result);
    //                }

    //                if (response.status == STATUS_MESSAGE.FAILURE) {
    //                    deferred.reject(response.errorMessage);
    //                }

    //                if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus != LOGIN_STATUS.Success) {
    //                    deferred.reject("Invalid credentials supplied");
    //                }
    //            }).catch(function (error) {
    //                deferred.reject(error)
    //            })
    //        }).catch(function () {
    //            deferred.resolve("Error occured while fetching user details.");
    //        })
    //    });

    //    return deferred.promise;
    //}

    private fetchUserDetails(code: string): ng.IPromise<authenticationUserDetail> {
        var self = this;
        let deferred: angular.IDeferred<authenticationUserDetail> = self.$q.defer();

        self.authenticationWebService.getLinkedInUserDetailFromCode(code).then(function (response: baseResultReturnType<authenticationUserDetail>) {
            response.result.provider = authenticationTypeEnum.LINKEDIN;
            deferred.resolve(response.result);

        }).catch(function (error) {
            deferred.reject(error)
        })

        //IN.API.Raw("/people/~:(id,first-name,last-name,email-address,picture-url)")
        //    .result(function (res) {
        //        var _authenticationUserDetail: authenticationUserDetail = new authenticationUserDetail();
        //        _authenticationUserDetail.firstname = res.firstName;
        //        _authenticationUserDetail.lastname = res.lastName;
        //        _authenticationUserDetail.email = res.emailAddress;
        //        _authenticationUserDetail.uid = res.id;
        //        _authenticationUserDetail.provider = authenticationTypeEnum.LINKEDIN;
        //        _authenticationUserDetail.imageUrl = res.pictureUrl;
        //        deferred.resolve(_authenticationUserDetail);
        //    });

        return deferred.promise;
    }

    public logout(): ng.IPromise<boolean> {
        var self = this;
        let deferred: angular.IDeferred<boolean> = self.$q.defer();

        IN.User.logout(function () {
            deferred.resolve(true);
        }, {});
        return deferred.promise;
    }

    public register(): ng.IPromise<authenticationReturnType> {
        throw "Cannot Implement";
    }
}

