var administrationCustomerWebService = /** @class */ (function () {
    function administrationCustomerWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    administrationCustomerWebService.prototype.getAdministrationCustomerScreenConstant = function () {
        var url = 'Administration/AdministrationCustomer/GetAdministrationCustomerScreenConstant';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationCustomerWebService.prototype.getAdministrationCustomer = function (getAdministrationCustomerDto) {
        var url = 'Administration/AdministrationCustomer/GetAdministrationCustomer';
        var data = getAdministrationCustomerDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationCustomerWebService.prototype.saveAdministrationCustomer = function (saveAdministrationCustomerDto) {
        var url = 'Administration/AdministrationCustomer/SaveAdministrationCustomer';
        var data = saveAdministrationCustomerDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationCustomerWebService.prototype.loadList = function (administrationCustomerListingSortingPagingInfo) {
        var url = 'Administration/AdministrationCustomer/LoadList';
        var data = administrationCustomerListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationCustomerWebService.prototype.loadListByNameAndAddress = function (administrationCustomerListingSortingPagingInfo) {
        var url = 'Administration/AdministrationCustomer/LoadListByNameAndAddress';
        var data = administrationCustomerListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationCustomerWebService.prototype.loadListByName = function (administrationCustomerListingSortingPagingInfo) {
        var url = 'Administration/AdministrationCustomer/LoadListByName';
        var data = administrationCustomerListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    administrationCustomerWebService.prototype.deleteCustomer = function (data) {
        var url = 'Administration/AdministrationCustomer/DeleteCustomer';
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return administrationCustomerWebService;
}());
//# sourceMappingURL=administration-customer-web-service.js.map