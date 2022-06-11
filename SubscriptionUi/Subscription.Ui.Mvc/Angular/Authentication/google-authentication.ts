class googleAuthentication implements authenticationInterface {

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


        if (gapi == undefined || gapi == null) {
            deferred.reject("Google libraries not yet initialized, please try in 5 secs");
        }

        var gauth = gapi.auth2.getAuthInstance();
        if (!gauth.isSignedIn.get()) {
            gauth.signIn().then(function (googleUser) {
                self.fetchUserDetailAndLoginToServer(gauth).then(function (userDetails: authenticationReturnType) {
                    deferred.resolve(userDetails);
                }).catch(function (err) {
                    deferred.reject(err);
                })

            }, function (err) {
                deferred.reject(err);
            });
        } else {
            self.fetchUserDetailAndLoginToServer(gauth).then(function (userDetails: authenticationReturnType) {
                deferred.resolve(userDetails);
            }).catch(function (err) {
                deferred.reject(err);
            })
        }

        return deferred.promise;
    }


    private fetchUserDetailAndLoginToServer(gauth): ng.IPromise<authenticationReturnType> {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();

        var authenticationUserDetail: authenticationUserDetail = self.fetchUserDetails(gauth);

        self.authenticationWebService.registerOrLogin(authenticationUserDetail).then(function (response: baseResultReturnType<authenticationReturnType>) {
            if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus == LOGIN_STATUS.Success) {
                deferred.resolve(response.result);
            } else {
                deferred.reject(response.errorMessage);
            }

        }).catch(function (error) {
            deferred.reject(error)
        })
        return deferred.promise;
    }

    private loginToServer(authenticationUser: authenticationReturnType): ng.IPromise<authenticationReturnType> {
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



    private fetchUserDetails(gauth): authenticationUserDetail {
        var self = this;
        var currentUser = gauth.currentUser.get();
        var profile = currentUser.getBasicProfile();
        var idToken = currentUser.getAuthResponse().id_token;
        var accessToken = currentUser.getAuthResponse().access_token;

        var _authenticationUserDetail: authenticationUserDetail = new authenticationUserDetail();
        _authenticationUserDetail.token = accessToken;
        _authenticationUserDetail.firstname = profile.getGivenName();
        _authenticationUserDetail.lastname = profile.getFamilyName();
        _authenticationUserDetail.email = profile.getEmail();
        _authenticationUserDetail.uid = profile.getId();
        _authenticationUserDetail.provider = authenticationTypeEnum.GOOGLE;
        _authenticationUserDetail.imageUrl = profile.getImageUrl();
        return _authenticationUserDetail;
    }

    public logout(): ng.IPromise<boolean> {
        var self = this;
        let deferred: angular.IDeferred<boolean> = self.$q.defer();

        try {
            //its a hack need to find better solution.
            var gElement = document.getElementById("gSignout");
            if (typeof (gElement) != 'undefined' && gElement != null) {
                gElement.remove();
            }
            var d = document, gSignout, ref = d.getElementsByTagName('script')[0];
            gSignout = d.createElement('script');
            gSignout.src = "https://accounts.google.com/Logout";
            gSignout.type = "text/html";
            gSignout.id = "gSignout";
            ref.parentNode.insertBefore(gSignout, ref);
            deferred.resolve(true)
        } catch (error) {
            deferred.reject(error)
        }

        return deferred.promise;

    }
    public register(): ng.IPromise<authenticationReturnType> {
        throw "Cannot Implement";
    }
}