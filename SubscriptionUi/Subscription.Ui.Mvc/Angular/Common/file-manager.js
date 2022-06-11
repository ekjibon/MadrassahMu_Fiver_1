var fileReturnType = /** @class */ (function () {
    function fileReturnType() {
    }
    return fileReturnType;
}());
var uploadDocumentReturnType = /** @class */ (function () {
    function uploadDocumentReturnType() {
    }
    return uploadDocumentReturnType;
}());
var fileWebService = /** @class */ (function () {
    function fileWebService($window, genericWebConnectionService, globalVariableFactory, _Upload) {
        this.globalVariableFactory = globalVariableFactory;
        this.genericWebConnectionService = genericWebConnectionService;
        this.Upload = _Upload;
    }
    fileWebService.prototype.uploadFiles = function (files) {
        var serviceUrl = 'File/UploadFiles';
        var url = this.globalVariableFactory.serverUrl + serviceUrl;
        return this.Upload.upload({
            url: url,
            file: files,
        });
    };
    fileWebService.prototype.uploadDocuments = function (files) {
        var serviceUrl = 'File/UploadDocuments';
        var url = this.globalVariableFactory.serverUrl + serviceUrl;
        return this.Upload.upload({
            url: url,
            file: files,
        });
    };
    fileWebService.prototype.downloadFile = function (attachmentCode) {
        var url = 'File/DownloadFile/' + attachmentCode;
        var data = {};
        return this.genericWebConnectionService.downloadRequest(url, data);
    };
    fileWebService.prototype.getFileType = function () {
        var url = 'File/GetFileType';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return fileWebService;
}());
var fileTypeReturnType = /** @class */ (function () {
    function fileTypeReturnType() {
    }
    return fileTypeReturnType;
}());
var fileManager = /** @class */ (function () {
    function fileManager($http, $q, rootScope, fileWebService, globalFactory, _Upload) {
        this.$q = $q;
        this.rootScope = rootScope;
        this.globalFactory = globalFactory;
        this._Upload = _Upload;
        this.fileWebService = fileWebService;
        this.q = $q;
        this.$rootScope = rootScope;
        this.globalVariableFactory = globalFactory;
        this.Upload = _Upload;
    }
    fileManager.prototype.uploadFileList = function (files) {
        var self = this;
        var deferred = self.$q.defer();
        self.fileWebService.uploadFiles(files)
            .progress(function (evt) {
            var progressPercentage = parseInt((100 * (evt.loaded / evt.total)) + "");
            progressPercentage = progressPercentage;
        })
            .success(function (returnData, status, headers, config) {
            deferred.resolve(returnData.result.fileUrls);
        })
            .error(function (data, status, headers, config) {
            deferred.reject(data);
        });
        return deferred.promise;
    };
    fileManager.prototype.uploadFileListPerFile = function (files, data, position, deferred) {
        if (data === void 0) { data = []; }
        if (position === void 0) { position = 0; }
        if (deferred === void 0) { deferred = null; }
        var self = this;
        if (deferred == null && position != 0)
            return self.$q.defer().reject('PARAMETERS ERROR');
        if (position == 0 && deferred == null)
            deferred = self.$q.defer();
        if (files.length > 0) {
            self.fileWebService.uploadFiles(files[position])
                .progress(function (evt) {
                var progressPercentage = parseInt((100 * (evt.loaded / evt.total)) + "");
                progressPercentage = progressPercentage / (files.length - position);
            })
                .success(function (returnData, status, headers, config) {
                if (returnData.status == STATUS_MESSAGE.SUCCESS) {
                    data = data.concat(returnData.result.fileUrls);
                    position = position + 1;
                    if (position < files.length) {
                        self.uploadFileListPerFile(files, data, position, deferred);
                    }
                    else
                        deferred.resolve(data);
                }
                else {
                    deferred.reject(returnData.errorMessage);
                }
            })
                .error(function (data, status, headers, config) {
                deferred.reject(data);
            });
        }
        else {
            deferred.resolve([]);
        }
        return deferred.promise;
    };
    fileManager.prototype.uploadDocumentListPerFile = function (files, data, position, deferred, customUploadService) {
        if (data === void 0) { data = []; }
        if (position === void 0) { position = 0; }
        if (deferred === void 0) { deferred = null; }
        if (customUploadService === void 0) { customUploadService = null; }
        var self = this;
        if (deferred == null && position != 0)
            return self.$q.defer().reject('PARAMETERS ERROR');
        if (position == 0 && deferred == null)
            deferred = self.$q.defer();
        var genericFunction = function (file) {
            return self.fileWebService.uploadDocuments(file);
        };
        var service = customUploadService == null ? genericFunction : customUploadService;
        if (files.length > 0 && files[position].file != null) {
            service(files[position])
                .progress(function (evt) {
                var progressPercentage = parseInt((100 * (evt.loaded / evt.total)) + "");
                progressPercentage = progressPercentage / (files.length - position);
            })
                .success(function (returnData, status, headers, config) {
                if (returnData.status == STATUS_MESSAGE.SUCCESS) {
                    var uploadDocumentListPerFile = new uploadDocumentListPerFileReturnType();
                    uploadDocumentListPerFile.id = files[position].id;
                    uploadDocumentListPerFile.document = returnData.result.documents[0];
                    data.push(uploadDocumentListPerFile);
                    position = position + 1;
                    if (position < files.length) {
                        self.uploadFileListPerFile(files, data, position, deferred);
                    }
                    else
                        deferred.resolve(data);
                }
                else {
                    deferred.reject(returnData.errorMessage);
                }
            })
                .error(function (data, status, headers, config) {
                console.log('error');
                deferred.reject(data);
            });
            //upload.catch(angular.noop);
            //upload.finally(angular.noop);
        }
        else {
            deferred.resolve([]);
        }
        return deferred.promise;
    };
    fileManager.prototype.downloadFile = function (attachmentCode) {
        var deferred = this.$q.defer();
        var self = this;
        self.fileWebService.downloadFile(attachmentCode)
            .then(function (response) {
            var isDownloadSuccessfull = new downloadResponseService().manageReponse(response);
            isDownloadSuccessfull ? deferred.resolve() : deferred.reject();
        })
            .catch(function (error) {
            deferred.reject(error);
        });
        return deferred.promise;
    };
    return fileManager;
}());
var fileUploadModule = angular.module("fileUploadModule", []);
fileUploadModule
    .service("fileWebService", [
    "$window",
    "genericWebConnectionService",
    "globalVariableFactory",
    "Upload",
    fileWebService
]);
fileUploadModule
    .service("fileManager", [
    "$http",
    "$q",
    "$rootScope",
    "fileWebService",
    "globalVariableFactory",
    "Upload",
    fileManager
]);
var uploadDocumentListPerFileDto = /** @class */ (function () {
    function uploadDocumentListPerFileDto() {
    }
    return uploadDocumentListPerFileDto;
}());
var uploadDocumentListPerFileReturnType = /** @class */ (function () {
    function uploadDocumentListPerFileReturnType() {
    }
    return uploadDocumentListPerFileReturnType;
}());
//# sourceMappingURL=file-manager.js.map