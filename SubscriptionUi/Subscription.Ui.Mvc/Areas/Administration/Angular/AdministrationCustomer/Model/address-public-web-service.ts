class addressPublicWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }

    public getAddressPublicCountry(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<baseResultReturnType<baseListReturnType<countryModel[]>>> {
        var url = 'Address/AddressPublic/GetAddressPublicCountry';
        var data = sortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getAddressPublicCity(citySortingPagingInfo: citySortingPagingInfoModel): ng.IPromise<baseResultReturnType<baseListReturnType<cityModel[]>>> {
        var url = 'Address/AddressPublic/GetAddressPublicCity';
        var data = citySortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }
}