class genericWebConnectionService {
    http: ng.IHttpService;
    q: ng.IQService;
    sessionVariable: any;


    constructor($http: ng.IHttpService, $window, private $q: ng.IQService, private globalVariableFactory: globalVariableFactory) {
        this.http = $http;
        this.q = $q;
    }

    public postRequest<T>(url: string, data: any): ng.IPromise<T> {
        return this.loadRequest('POST', url, data);
    }
    public downloadRequest(url: string, data: any): any {
        return this.loadDownloadRequest('POST', url, data);
    }
    public loadRequest<T>(method: string, url: string, data: any): ng.IPromise<T> {
        console.log(url);
        var deferred: any = this.q.defer();
        this.http({
            method: method,
            url: this.globalVariableFactory.serverUrl + url,
            dataType: 'json',
            contentType: 'application/json',
            timeout: 600000,
            data: data
        })
            .then(function (response: any) { // success function
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
    }

    public loadDownloadRequest(method: string, url: string, data: any): any {
        var deferred: any = this.q.defer();

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
            .then(function (response: any) { // success function
                deferred.resolve(response);
            })
            .catch(function (err) {
                deferred.reject(err);
            })
            .finally(function () {
                deferred.finally();
            });

        return deferred.promise;
    }

}
