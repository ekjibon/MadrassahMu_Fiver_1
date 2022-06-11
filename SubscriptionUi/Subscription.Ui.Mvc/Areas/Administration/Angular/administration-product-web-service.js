var administrationProductWebService = (function () {
    function administrationProductWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    administrationProductWebService.prototype.getProductList = function (productListSortingPagingInfo) {
        var url = 'Administration/AdministrationProduct/LoadList';
        var data = productListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationProductWebService.prototype.saveProduct = function (saveAdministrationProductDto) {
        var url = 'Administration/AdministrationProduct/SaveAdministrationProduct';
        var data = saveAdministrationProductDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationProductWebService.prototype.getAdministrationProduct = function (getAdministrationProductDto) {
        var url = 'Administration/AdministrationProduct/GetAdministrationProduct';
        var data = getAdministrationProductDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return administrationProductWebService;
}());
//# sourceMappingURL=administration-product-web-service.js.map