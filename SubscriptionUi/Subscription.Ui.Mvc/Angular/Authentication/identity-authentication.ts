class identityAuthentication implements authenticationInterface{
    $q: ng.IQService;
    authenticationDetail: authenticationUserDetail;
    authenticationWebService: authenticationWebService
    constructor($q, authenticationDetail: authenticationUserDetail, authenticationWebService) {
        this.$q = $q;
        this.authenticationDetail = authenticationDetail;
        this.authenticationWebService = authenticationWebService;
        this.initializeAuthentication();
    }

    private initializeAuthentication() {
        var self = this;
    }

    public login(): ng.IPromise<authenticationReturnType> {
        var self = this;
        let deferred: angular.IDeferred<authenticationReturnType> = self.$q.defer();
        console.log("lkllllllllllll");
        self.authenticationWebService.login(self.authenticationDetail).then(function (response: baseResultReturnType<authenticationReturnType>) {
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
        return deferred.promise;
    }

    private fetchUserDetails(): ng.IPromise<authenticationUserDetail> {
        var self = this;
        let deferred: angular.IDeferred<authenticationUserDetail> = self.$q.defer();


        return deferred.promise;
    }

    public logout(): ng.IPromise<boolean> {
        var self = this;
        let deferred: angular.IDeferred<boolean> = self.$q.defer();


        return deferred.promise;
    }

    public register(): ng.IPromise<authenticationReturnType> {
        throw "Cannot Implement";
    }

    //public register(): ng.IPromise<authenticationReturnType> {
    //    var self = this;
    //    var deferred = self.$q.defer();
    //    self.authenticationWebService.register(self.authenticationDetail).then(function (response: baseResultReturnType<authenticationReturnType>) {
    //        if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus == LOGIN_STATUS.Success) {
    //            deferred.resolve(response.result);
    //        }

    //        if (response.status == STATUS_MESSAGE.FAILURE) {
    //            deferred.reject(response.errorMessage);
    //        }

    //        if (response.status == STATUS_MESSAGE.SUCCESS && response.result.signInStatus != LOGIN_STATUS.Success) {
    //            deferred.reject("Invalid credentials supplied");
    //        }
    //    }).catch(function (error) {
    //        deferred.reject(error)
    //        })

    //    return deferred.promise;
    //}


}