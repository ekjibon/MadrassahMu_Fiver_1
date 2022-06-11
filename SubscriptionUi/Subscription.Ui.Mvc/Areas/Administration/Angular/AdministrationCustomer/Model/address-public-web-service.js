var addressPublicWebService = /** @class */ (function () {
    function addressPublicWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    addressPublicWebService.prototype.getAddressPublicCountry = function (sortingPagingInfo) {
        var url = 'Address/AddressPublic/GetAddressPublicCountry';
        var data = sortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    addressPublicWebService.prototype.getAddressPublicCity = function (citySortingPagingInfo) {
        var url = 'Address/AddressPublic/GetAddressPublicCity';
        var data = citySortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    return addressPublicWebService;
}());
//# sourceMappingURL=address-public-web-service.js.map