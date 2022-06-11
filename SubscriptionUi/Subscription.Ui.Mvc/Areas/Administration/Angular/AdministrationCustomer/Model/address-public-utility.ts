﻿class addressPublicUtilityService {
    addressPublicWebService: addressPublicWebService;
    q: ng.IQService;
    constructor(addressPublicWebService, $q) {
        this.addressPublicWebService = addressPublicWebService;
        this.q = $q;

    }

    public countryTagTransform(newTag, item) {
        var country: countryModel = new countryModel();
        country.idLocalCountry = commonUtility.generateUUID();
        country.description = newTag;
        return country;
    }

    public cityTagTransform(newTag, item) {
        var city: cityModel = new cityModel();
        city.idLocalCity = commonUtility.generateUUID();
        city.description = newTag;
        return city;
    }

    public onCountryTypeIn(userInputString): ng.IPromise<countryModel[]> {
        var self = this;
        var deffered: angular.IDeferred<countryModel[]> = self.q.defer();

        var sortingPagingInfo: sortingPagingInfoModel = new sortingPagingInfoModel();
        sortingPagingInfo.search = userInputString;
        sortingPagingInfo.currentPageIndex = 0;
        sortingPagingInfo.pageSize = 15;
        self.addressPublicWebService.getAddressPublicCountry(sortingPagingInfo)
            .then(function (response: baseResultReturnType<baseListReturnType<countryModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    deffered.resolve(response.result.entityList);
                } else {
                    deffered.reject(response.errorMessage);
                }
            }).catch(function (errorMsg) {
                deffered.reject(errorMsg);

            }).finally(function () {
            });

        return deffered.promise;
    }

    public onCityTypeIn(userInputString: string, idCountry: number = null): ng.IPromise<cityModel[]> {
        var self = this;
        var deffered: angular.IDeferred<cityModel[]> = self.q.defer();

        //manually add user input and set selection
        var userInputItem: any = {
            idLocalCity: commonUtility.generateUUID(),
            description: userInputString,
            tag: " (new)"
        };

        var sortingPagingInfo: citySortingPagingInfoModel = new citySortingPagingInfoModel();
        sortingPagingInfo.search = userInputString;
        sortingPagingInfo.currentPageIndex = 0;
        sortingPagingInfo.pageSize = 15;
        if (idCountry != null && idCountry != undefined && idCountry > 0) {
            sortingPagingInfo.idCountry = idCountry
        } else {
            sortingPagingInfo.idCountry = null;
        }

        self.addressPublicWebService.getAddressPublicCity(sortingPagingInfo)
            .then(function (response: baseResultReturnType<baseListReturnType<cityModel[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    if (userInputString != null && userInputString != undefined && userInputString.length > 4) {
                        var city: cityModel = Enumerable.From(response.result.entityList).Where(function (city: cityModel) {
                            return city.description.toLowerCase() == userInputString.toLowerCase()
                        }).FirstOrDefault(null);

                        if (city == null) {
                            response.result.entityList = [userInputItem].concat(response.result.entityList);
                        }
                    }


                    deffered.resolve(response.result.entityList);
                } else {
                    deffered.reject(response.errorMessage);
                }
            }).catch(function (errorMsg) {
                deffered.reject(errorMsg);
            }).finally(function () {
            });

        return deffered.promise;
    }

    public onGooglePlaceAcquired(place, address: addressModel): ng.IPromise<addressModel> {
        var self = this;
        var deffered: angular.IDeferred<addressModel> = self.q.defer();

        if (address == null || address == undefined) {
            address = new addressModel();
        }

        for (var i = 0; i < place.address_components.length; i++) {
            var addressType = place.address_components[i].types[0];
            if (componentForm[addressType]) {
                var val = place.address_components[i][componentForm[addressType]];
                address[addressExtension.getAddressType(addressType)] = val;
            }
        }

        if (address["tempCountry"] != null && address["tempCountry"] != undefined) {
            var country = address["tempCountry"];
            self.onCountryTypeIn(country).then(function (countries: countryModel[]) {
                var countryObject: countryModel = Enumerable.From(countries).Where(function (_country: countryModel) {
                    return _country.description == country
                }).FirstOrDefault(null);

                if (countryObject != null) {
                    address.country = countryObject;
                    address.idCountry = countryObject.idCountry;
                }

                deffered.resolve(address);
            }).catch(function (errorMsg) {
                deffered.resolve(address);
            })
        } else {
            deffered.resolve(address);
        }
        return deffered.promise;
    }
}

var componentForm = {
    street_number: 'short_name',
    route: 'long_name',
    locality: 'long_name',
    administrative_area_level_1: 'short_name',
    country: 'long_name',
    postal_code: 'short_name'
};

class addressExtension {

    static getAddressType(type) {
        var classItemType;
        if (type == "locality") {
            classItemType = "addressLine1";
        }
        else if (type == "route") {
            classItemType = "addressLine2";
        }
        else if (type == "street_number") {
            classItemType = "addressLine3";
        }
        else if (type == "administrative_area_level_1") {
            classItemType = "city";
        }
        else if (type == "country") {
            classItemType = "tempCountry";
        }
        else if (type == "postal_code") {
            classItemType = "postcode";
        }
        return classItemType;
    }
}