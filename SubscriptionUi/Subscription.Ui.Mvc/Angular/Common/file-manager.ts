class fileReturnType {
    fileUrl: string;
    fileUrls: string[];
}

class uploadDocumentReturnType {
    documents: documentModel[];
}

class fileWebService {
    genericWebConnectionService: genericWebConnectionService;
    Upload;
    constructor($window, genericWebConnectionService, private globalVariableFactory, _Upload) {
        this.genericWebConnectionService = genericWebConnectionService;
        this.Upload = _Upload;
    }

    public uploadFiles(files) {
        var serviceUrl = 'File/UploadFiles';
        var url = this.globalVariableFactory.serverUrl + serviceUrl;
        return this.Upload.upload({
            url: url,
            file: files,
        })
    }

    public uploadDocuments(files) {
        var serviceUrl = 'File/UploadDocuments';
        var url = this.globalVariableFactory.serverUrl + serviceUrl;
        return this.Upload.upload({
            url: url,
            file: files,
        })
    }


    public downloadFile(attachmentCode: string) {
        var url = 'File/DownloadFile/' + attachmentCode;
        var data = {

        };
        return this.genericWebConnectionService.downloadRequest(url, data);
    }

    public getFileType(): ng.IPromise<baseResultReturnType<fileTypeReturnType[]>> {
        var url = 'File/GetFileType';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    }
}

class fileTypeReturnType {
    extension: string;
    serverUrl: string
}

class fileManager {
    q: ng.IQService;
    fileWebService: fileWebService;
    globalVariableFactory;
    Upload;
    $rootScope;
    constructor(
        $http: ng.IHttpService,
        public $q,
        private rootScope,
        fileWebService: fileWebService,
        private globalFactory,
        public _Upload
    ) {
        this.fileWebService = fileWebService;
        this.q = $q;
        this.$rootScope = rootScope;
        this.globalVariableFactory = globalFactory;
        this.Upload = _Upload;
    }

    public uploadFileList(files: any[]): ng.IPromise<string[]> {
        var self = this;
        let deferred: angular.IDeferred<string[]> = self.$q.defer();

        self.fileWebService.uploadFiles(files)
            .progress(function (evt: any) {
                var progressPercentage = parseInt((100 * (evt.loaded / evt.total)) + "");
                progressPercentage = progressPercentage;
            })
            .success(function (returnData: baseReturnType<fileReturnType>, status, headers, config) {
                deferred.resolve(returnData.result.fileUrls);
            })
            .error(function (data, status, headers, config) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    public uploadFileListPerFile(files: any[], data: any[] = [], position: number = 0, deferred = null): ng.IPromise<string[]> {
        var self = this;
        if (deferred == null && position != 0)
            return self.$q.defer().reject('PARAMETERS ERROR');

        if (position == 0 && deferred == null)
            deferred = self.$q.defer();

        if (files.length > 0) {
            self.fileWebService.uploadFiles(files[position])
                .progress(function (evt: any) {
                    var progressPercentage = parseInt((100 * (evt.loaded / evt.total)) + "");
                    progressPercentage = progressPercentage / (files.length - position)
                })
                .success(function (returnData: baseResultReturnType<fileReturnType>, status, headers, config) {
                    if (returnData.status == STATUS_MESSAGE.SUCCESS) {
                        data = data.concat(returnData.result.fileUrls);

                        position = position + 1;
                        if (position < files.length) {
                            self.uploadFileListPerFile(files, data, position, deferred);
                        }
                        else
                            deferred.resolve(data);
                    } else {
                        deferred.reject(returnData.errorMessage);
                    }

                })
                .error(function (data, status, headers, config) {
                    deferred.reject(data);
                });
        } else {
            deferred.resolve([]);
        }
        return deferred.promise;
    }

    public uploadDocumentListPerFile(files: uploadDocumentListPerFileDto[], data: uploadDocumentListPerFileReturnType[] = [], position: number = 0, deferred = null, customUploadService = null): ng.IPromise<uploadDocumentListPerFileReturnType[]> {
        var self = this;
        if (deferred == null && position != 0)
            return self.$q.defer().reject('PARAMETERS ERROR');

        if (position == 0 && deferred == null)
            deferred = self.$q.defer();

        var genericFunction = function (file) {
            return self.fileWebService.uploadDocuments(file);
        }

        var service = customUploadService == null ? genericFunction : customUploadService;

        if (files.length > 0 && files[position].file != null) {
            service(files[position])
                .progress(function (evt: any) {
                    var progressPercentage = parseInt((100 * (evt.loaded / evt.total)) + "");
                    progressPercentage = progressPercentage / (files.length - position)
                })
                .success(function (returnData: baseResultReturnType<uploadDocumentReturnType>, status, headers, config) {
                    if (returnData.status == STATUS_MESSAGE.SUCCESS) {
                        var uploadDocumentListPerFile: uploadDocumentListPerFileReturnType = new uploadDocumentListPerFileReturnType();
                        uploadDocumentListPerFile.id = files[position].id;
                        uploadDocumentListPerFile.document = returnData.result.documents[0];
                        data.push(uploadDocumentListPerFile);

                        position = position + 1;
                        if (position < files.length) {
                            self.uploadFileListPerFile(files, data, position, deferred);
                        }
                        else
                            deferred.resolve(data);
                    } else {
                        deferred.reject(returnData.errorMessage);
                    }

                })
                .error(function (data, status, headers, config) {
                    console.log('error')
                    deferred.reject(data);
                });
            //upload.catch(angular.noop);
            //upload.finally(angular.noop);
        } else {
            deferred.resolve([]);
        }
        return deferred.promise;
    }



    public downloadFile(attachmentCode: string): ng.IPromise<string> {
        var deferred = this.$q.defer();
        var self = this;
        self.fileWebService.downloadFile(attachmentCode)
            .then(function (response: any) {
                var isDownloadSuccessfull = new downloadResponseService().manageReponse(response);
                isDownloadSuccessfull ? deferred.resolve() : deferred.reject();
            })
            .catch(function (error) {
                deferred.reject(error);
            })
        return deferred.promise;
    }
}


var fileUploadModule = angular.module("fileUploadModule", []);

fileUploadModule
    .service("fileWebService",
        [
            "$window",
            "genericWebConnectionService",
            "globalVariableFactory",
            "Upload",
            fileWebService
        ]);


fileUploadModule
    .service(
        "fileManager", [
        "$http",
        "$q",
        "$rootScope",
        "fileWebService",
        "globalVariableFactory",
        "Upload",
        fileManager
    ]);


class uploadDocumentListPerFileDto {
    file: File;
    id: string;
}

class uploadDocumentListPerFileReturnType {
    id: string;
    document: documentModel;
}