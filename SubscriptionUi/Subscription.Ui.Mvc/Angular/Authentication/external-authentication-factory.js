var authenticationFactory = (function () {
    function authenticationFactory() {
    }
    authenticationFactory.prototype.getAuthenticationInstance = function (_authenticationType, _externalAuthenticationDetail) {
        switch (_authenticationType) {
            case authenticationType.FACEBOOK:
                return new facebookAuthentication(_externalAuthenticationDetail);
            case authenticationType.GOOGLE:
                return new googleAuthentication();
            case authenticationType.IDENTITY:
                return new identityAuthentication();
        }
    };
    return authenticationFactory;
}());
var externalAuthenticationDetail = (function () {
    function externalAuthenticationDetail() {
    }
    return externalAuthenticationDetail;
}());
var authenticationType;
(function (authenticationType) {
    authenticationType[authenticationType["FACEBOOK"] = 1] = "FACEBOOK";
    authenticationType[authenticationType["GOOGLE"] = 2] = "GOOGLE";
    authenticationType[authenticationType["IDENTITY"] = 3] = "IDENTITY";
})(authenticationType || (authenticationType = {}));
//# sourceMappingURL=external-authentication-factory.js.map