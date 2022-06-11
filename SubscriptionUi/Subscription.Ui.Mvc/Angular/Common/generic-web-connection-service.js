var genericWebConnectionService = /** @class */ (function () {
    function genericWebConnectionService($http, $window, $q, globalVariableFactory) {
        this.$q = $q;
        this.globalVariableFactory = globalVariableFactory;
        this.http = $http;
        this.q = $q;
    }
    genericWebConnectionService.prototype.postRequest = function (url, data) {
        return this.loadRequest('POST', url, data);
    };
    genericWebConnectionService.prototype.downloadRequest = function (url, data) {
        return this.loadDownloadRequest('POST', url, data);
    };
    genericWebConnectionService.prototype.loadRequest = function (method, url, data) {
        console.log(url);
        var deferred = this.q.defer();
        this.http({
            method: method,
            url: this.globalVariableFactory.serverUrl + url,
            dataType: 'json',
            contentType: 'application/json',
            timeout: 600000,
            data: data
        })
            .then(function (response) {
            console.log(response.data);
            deferred.resolve(response.data);
        })
            .catch(function (err) {
            console.log(err);
            deferred.reject(err);
        })
            .finally(function () {
            console.log(deferred.finally());
            if (deferred.finally)
                deferred.finally();
        });
        return deferred.promise;
    };
    genericWebConnectionService.prototype.loadDownloadRequest = function (method, url, data) {
        var deferred = this.q.defer();
        this.http({
            method: method,
            url: this.globalVariableFactory.serverUrl + url,
            dataType: 'json',
            contentType: 'application/json',
            timeout: 600000,
            cache: false,
            data: data,
            responseType: 'arraybuffer'
        })
            .then(function (response) {
            deferred.resolve(response);
        })
            .catch(function (err) {
            deferred.reject(err);
        })
            .finally(function () {
            deferred.finally();
        });
        return deferred.promise;
    };
    return genericWebConnectionService;
}());
//# sourceMappingURL=generic-web-connection-service.js.map