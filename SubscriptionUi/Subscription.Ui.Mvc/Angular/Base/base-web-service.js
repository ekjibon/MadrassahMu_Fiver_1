var baseWebService = /** @class */ (function () {
    function baseWebService(genericWebConnectionService, saveUrl, loadUrl, deleteUrl) {
        if (saveUrl === void 0) { saveUrl = ""; }
        if (loadUrl === void 0) { loadUrl = ""; }
        if (deleteUrl === void 0) { deleteUrl = ""; }
        this.genericWebConnectionService = genericWebConnectionService;
        this.saveUrl = saveUrl;
        this.loadUrl = loadUrl;
        this.deleteUrl = deleteUrl;
    }
    baseWebService.prototype.saveItem = function (data) {
        return this.genericWebConnectionService.postRequest(this.saveUrl, data);
    };
    baseWebService.prototype.loadList = function (data) {
        return this.genericWebConnectionService.postRequest(this.loadUrl, data);
    };
    baseWebService.prototype.deleteItem = function (data) {
        return this.genericWebConnectionService.postRequest(this.deleteUrl, data);
    };
    return baseWebService;
}());
//# sourceMappingURL=base-web-service.js.map