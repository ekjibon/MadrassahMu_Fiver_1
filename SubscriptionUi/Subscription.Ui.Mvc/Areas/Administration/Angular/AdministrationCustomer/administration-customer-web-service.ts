class administrationCustomerWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }

    public getAdministrationCustomerScreenConstant(): ng.IPromise<baseResultReturnType<administrationCustomerScreenContantReturnType>> {
        var url = 'Administration/AdministrationCustomer/GetAdministrationCustomerScreenConstant';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getAdministrationCustomer(getAdministrationCustomerDto: getAdministrationCustomerDto): ng.IPromise<baseResultReturnType<getAdministrationCustomerReturnType>> {
        var url = 'Administration/AdministrationCustomer/GetAdministrationCustomer';
        var data = getAdministrationCustomerDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public saveAdministrationCustomer(saveAdministrationCustomerDto: saveAdministrationCustomerDto): ng.IPromise<baseResultReturnType<saveAdministrationCustomerReturnType>> {
        var url = 'Administration/AdministrationCustomer/SaveAdministrationCustomer';
        var data = saveAdministrationCustomerDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadList(administrationCustomerListingSortingPagingInfo: administrationCustomerListingSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<customerModel[]>>> {
        var url = 'Administration/AdministrationCustomer/LoadList';
        var data = administrationCustomerListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadListByNameAndAddress(administrationCustomerListingSortingPagingInfo: administrationCustomerListingSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<any[]>>> {
        var url = 'Administration/AdministrationCustomer/LoadListByNameAndAddress';
        var data = administrationCustomerListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadListByName(administrationCustomerListingSortingPagingInfo: administrationCustomerListingSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<customerModel[]>>> {
        var url = 'Administration/AdministrationCustomer/LoadListByName';
        var data = administrationCustomerListingSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public deleteCustomer(data: customerModel): ng.IPromise<baseResultReturnType<customerModel>> {
        var url = 'Administration/AdministrationCustomer/DeleteCustomer';
        return this.genericWebConnectionService.postRequest(url, data);
    }
}
