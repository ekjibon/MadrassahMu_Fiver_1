class administrationWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }

    public getProductList(productListSortingPagingInfo: productListSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<productModel[]>>> {
        var url = 'Administration/AdministrationProduct/LoadList';
        var data = productListSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public saveProduct(saveAdministrationProductDto: saveAdministrationProductDto): ng.IPromise<baseResultReturnType<saveAdministrationProductReturnType>> {
        var url = 'Administration/AdministrationProduct/SaveAdministrationProduct';
        var data = saveAdministrationProductDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getAdministrationProduct(getAdministrationProductDto: getAdministrationProductDto): ng.IPromise<baseResultReturnType<getAdministrationProductReturnType>> {
        var url = 'Administration/AdministrationProduct/GetAdministrationProduct';
        var data = getAdministrationProductDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

}
