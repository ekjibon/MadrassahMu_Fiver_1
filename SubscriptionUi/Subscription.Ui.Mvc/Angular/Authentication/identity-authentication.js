var identityAuthentication = /** @class */ (function () {
    function identityAuthentication($q, authenticationDetail, authenticationWebService) {
        this.$q = $q;
        this.authenticationDetail = authenticationDetail;
        this.authenticationWebService = authenticationWebService;
        this.initializeAuthentication();
    }
    identityAuthentication.prototype.initializeAuthentication = function () {
        var self = this;
    };
    identityAuthentication.prototype.login = function () {
        var self = this;
        var deferred = self.$q.defer();
        console.log("lkllllllllllll");
        self.authenticationWebService.login(self.authenticationDetail).then(function (response) {
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
        return deferred.promise;
    };
    identityAuthentication.prototype.fetchUserDetails = function () {
        var self = this;
        var deferred = self.$q.defer();
        return deferred.promise;
    };
    identityAuthentication.prototype.logout = function () {
        var self = this;
        var deferred = self.$q.defer();
        return deferred.promise;
    };
    identityAuthentication.prototype.register = function () {
        throw "Cannot Implement";
    };
    return identityAuthentication;
}());
//# sourceMappingURL=identity-authentication.js.map