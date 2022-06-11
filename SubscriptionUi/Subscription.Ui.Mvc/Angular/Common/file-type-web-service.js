var fileTypeWebService = (function () {
    function fileTypeWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    fileTypeWebService.prototype.getFileType = function () {
        var url = 'File/GetFileType';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return fileTypeWebService;
}());
//# sourceMappingURL=file-type-web-service.js.map