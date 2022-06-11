


//class bankWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllBanks(): ng.IPromise<getAllBanksReturnType> {
//        var url = getAllBanksUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllBanksByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllBanksByPageReturnType> {
//        var url = getAllBanksByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getBank(idBank): ng.IPromise<getBankReturnType> {
//        var url = getBankUrl;
//        var data =  idBank;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(bank:bankModel): ng.IPromise<boolean> {
//        var url = saveBankUrl;
//        var data = bank;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteBank(bank:bankModel): ng.IPromise<boolean> {
//        var url = deleteBankUrl;
//        var data = bank;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("BankWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        bankWebService]);


//class bankRefWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllBankRefs(): ng.IPromise<getAllBankRefsReturnType> {
//        var url = getAllBankRefsUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllBankRefsByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllBankRefsByPageReturnType> {
//        var url = getAllBankRefsByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getBankRef(idBankRef): ng.IPromise<getBankRefReturnType> {
//        var url = getBankRefUrl;
//        var data =  idBankRef;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(bankRef:bankRefModel): ng.IPromise<boolean> {
//        var url = saveBankRefUrl;
//        var data = bankRef;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteBankRef(bankRef:bankRefModel): ng.IPromise<boolean> {
//        var url = deleteBankRefUrl;
//        var data = bankRef;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("BankRefWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        bankRefWebService]);


//class contractWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllContracts(): ng.IPromise<getAllContractsReturnType> {
//        var url = getAllContractsUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllContractsByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllContractsByPageReturnType> {
//        var url = getAllContractsByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getContract(idContract): ng.IPromise<getContractReturnType> {
//        var url = getContractUrl;
//        var data =  idContract;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(contract:contractModel): ng.IPromise<boolean> {
//        var url = saveContractUrl;
//        var data = contract;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteContract(contract:contractModel): ng.IPromise<boolean> {
//        var url = deleteContractUrl;
//        var data = contract;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("ContractWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        contractWebService]);


//class countryWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllCountries(): ng.IPromise<getAllCountriesReturnType> {
//        var url = getAllCountriesUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllCountriesByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllCountriesByPageReturnType> {
//        var url = getAllCountriesByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getCountry(idCountry): ng.IPromise<getCountryReturnType> {
//        var url = getCountryUrl;
//        var data =  idCountry;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(country:countryModel): ng.IPromise<boolean> {
//        var url = saveCountryUrl;
//        var data = country;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteCountry(country:countryModel): ng.IPromise<boolean> {
//        var url = deleteCountryUrl;
//        var data = country;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("CountryWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        countryWebService]);


//class purchaseWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllPurchases(): ng.IPromise<getAllPurchasesReturnType> {
//        var url = getAllPurchasesUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllPurchasesByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllPurchasesByPageReturnType> {
//        var url = getAllPurchasesByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getPurchase(idPurchase): ng.IPromise<getPurchaseReturnType> {
//        var url = getPurchaseUrl;
//        var data =  idPurchase;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(purchase:purchaseModel): ng.IPromise<boolean> {
//        var url = savePurchaseUrl;
//        var data = purchase;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deletePurchase(purchase:purchaseModel): ng.IPromise<boolean> {
//        var url = deletePurchaseUrl;
//        var data = purchase;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("PurchaseWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        purchaseWebService]);


//class purchase_PurchaseCostWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllPurchase_PurchaseCost(): ng.IPromise<getAllPurchase_PurchaseCostReturnType> {
//        var url = getAllPurchase_PurchaseCostUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllPurchase_PurchaseCostByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllPurchase_PurchaseCostByPageReturnType> {
//        var url = getAllPurchase_PurchaseCostByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getPurchase_PurchaseCost(idPurchase_PurchaseCost): ng.IPromise<getPurchase_PurchaseCostReturnType> {
//        var url = getPurchase_PurchaseCostUrl;
//        var data =  idPurchase_PurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(purchase_PurchaseCost:purchase_PurchaseCostModel): ng.IPromise<boolean> {
//        var url = savePurchase_PurchaseCostUrl;
//        var data = purchase_PurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deletePurchase_PurchaseCost(purchase_PurchaseCost:purchase_PurchaseCostModel): ng.IPromise<boolean> {
//        var url = deletePurchase_PurchaseCostUrl;
//        var data = purchase_PurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("Purchase_PurchaseCostWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        purchase_PurchaseCostWebService]);


//class purchaseCostWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllPurchaseCosts(): ng.IPromise<getAllPurchaseCostsReturnType> {
//        var url = getAllPurchaseCostsUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllPurchaseCostsByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllPurchaseCostsByPageReturnType> {
//        var url = getAllPurchaseCostsByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getPurchaseCost(idPurchaseCost): ng.IPromise<getPurchaseCostReturnType> {
//        var url = getPurchaseCostUrl;
//        var data =  idPurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(purchaseCost:purchaseCostModel): ng.IPromise<boolean> {
//        var url = savePurchaseCostUrl;
//        var data = purchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deletePurchaseCost(purchaseCost:purchaseCostModel): ng.IPromise<boolean> {
//        var url = deletePurchaseCostUrl;
//        var data = purchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("PurchaseCostWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        purchaseCostWebService]);


//class purchaseSplitWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllPurchaseSplits(): ng.IPromise<getAllPurchaseSplitsReturnType> {
//        var url = getAllPurchaseSplitsUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllPurchaseSplitsByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllPurchaseSplitsByPageReturnType> {
//        var url = getAllPurchaseSplitsByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getPurchaseSplit(idPurchaseSplit): ng.IPromise<getPurchaseSplitReturnType> {
//        var url = getPurchaseSplitUrl;
//        var data =  idPurchaseSplit;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(purchaseSplit:purchaseSplitModel): ng.IPromise<boolean> {
//        var url = savePurchaseSplitUrl;
//        var data = purchaseSplit;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deletePurchaseSplit(purchaseSplit:purchaseSplitModel): ng.IPromise<boolean> {
//        var url = deletePurchaseSplitUrl;
//        var data = purchaseSplit;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("PurchaseSplitWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        purchaseSplitWebService]);


//class purchaseSplit_PurchaseCostWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllPurchaseSplit_PurchaseCost(): ng.IPromise<getAllPurchaseSplit_PurchaseCostReturnType> {
//        var url = getAllPurchaseSplit_PurchaseCostUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllPurchaseSplit_PurchaseCostByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllPurchaseSplit_PurchaseCostByPageReturnType> {
//        var url = getAllPurchaseSplit_PurchaseCostByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getPurchaseSplit_PurchaseCost(idPurchaseSplit_PurchaseCost): ng.IPromise<getPurchaseSplit_PurchaseCostReturnType> {
//        var url = getPurchaseSplit_PurchaseCostUrl;
//        var data =  idPurchaseSplit_PurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(purchaseSplit_PurchaseCost:purchaseSplit_PurchaseCostModel): ng.IPromise<boolean> {
//        var url = savePurchaseSplit_PurchaseCostUrl;
//        var data = purchaseSplit_PurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deletePurchaseSplit_PurchaseCost(purchaseSplit_PurchaseCost:purchaseSplit_PurchaseCostModel): ng.IPromise<boolean> {
//        var url = deletePurchaseSplit_PurchaseCostUrl;
//        var data = purchaseSplit_PurchaseCost;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("PurchaseSplit_PurchaseCostWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        purchaseSplit_PurchaseCostWebService]);


//class purchaseStateWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllPurchaseStates(): ng.IPromise<getAllPurchaseStatesReturnType> {
//        var url = getAllPurchaseStatesUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllPurchaseStatesByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllPurchaseStatesByPageReturnType> {
//        var url = getAllPurchaseStatesByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getPurchaseState(idPurchaseState): ng.IPromise<getPurchaseStateReturnType> {
//        var url = getPurchaseStateUrl;
//        var data =  idPurchaseState;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(purchaseState:purchaseStateModel): ng.IPromise<boolean> {
//        var url = savePurchaseStateUrl;
//        var data = purchaseState;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deletePurchaseState(purchaseState:purchaseStateModel): ng.IPromise<boolean> {
//        var url = deletePurchaseStateUrl;
//        var data = purchaseState;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("PurchaseStateWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        purchaseStateWebService]);


//class roleWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllRoles(): ng.IPromise<getAllRolesReturnType> {
//        var url = getAllRolesUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllRolesByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllRolesByPageReturnType> {
//        var url = getAllRolesByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getRole(idRole): ng.IPromise<getRoleReturnType> {
//        var url = getRoleUrl;
//        var data =  idRole;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(role:roleModel): ng.IPromise<boolean> {
//        var url = saveRoleUrl;
//        var data = role;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteRole(role:roleModel): ng.IPromise<boolean> {
//        var url = deleteRoleUrl;
//        var data = role;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("RoleWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        roleWebService]);


//class stockWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllStocks(): ng.IPromise<getAllStocksReturnType> {
//        var url = getAllStocksUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllStocksByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllStocksByPageReturnType> {
//        var url = getAllStocksByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getStock(idStock): ng.IPromise<getStockReturnType> {
//        var url = getStockUrl;
//        var data =  idStock;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(stock:stockModel): ng.IPromise<boolean> {
//        var url = saveStockUrl;
//        var data = stock;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteStock(stock:stockModel): ng.IPromise<boolean> {
//        var url = deleteStockUrl;
//        var data = stock;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("StockWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        stockWebService]);


//class supplierWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllSuppliers(): ng.IPromise<getAllSuppliersReturnType> {
//        var url = getAllSuppliersUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllSuppliersByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllSuppliersByPageReturnType> {
//        var url = getAllSuppliersByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getSupplier(idSupplier): ng.IPromise<getSupplierReturnType> {
//        var url = getSupplierUrl;
//        var data =  idSupplier;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(supplier:supplierModel): ng.IPromise<boolean> {
//        var url = saveSupplierUrl;
//        var data = supplier;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteSupplier(supplier:supplierModel): ng.IPromise<boolean> {
//        var url = deleteSupplierUrl;
//        var data = supplier;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("SupplierWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        supplierWebService]);


//class userWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllUsers(): ng.IPromise<getAllUsersReturnType> {
//        var url = getAllUsersUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllUsersByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllUsersByPageReturnType> {
//        var url = getAllUsersByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getUser(idUser): ng.IPromise<getUserReturnType> {
//        var url = getUserUrl;
//        var data =  idUser;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(user:userModel): ng.IPromise<boolean> {
//        var url = saveUserUrl;
//        var data = user;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteUser(user:userModel): ng.IPromise<boolean> {
//        var url = deleteUserUrl;
//        var data = user;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("UserWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        userWebService]);


//class warehouseWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllWarehouses(): ng.IPromise<getAllWarehousesReturnType> {
//        var url = getAllWarehousesUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllWarehousesByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllWarehousesByPageReturnType> {
//        var url = getAllWarehousesByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getWarehouse(idWarehouse): ng.IPromise<getWarehouseReturnType> {
//        var url = getWarehouseUrl;
//        var data =  idWarehouse;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(warehouse:warehouseModel): ng.IPromise<boolean> {
//        var url = saveWarehouseUrl;
//        var data = warehouse;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteWarehouse(warehouse:warehouseModel): ng.IPromise<boolean> {
//        var url = deleteWarehouseUrl;
//        var data = warehouse;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("WarehouseWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        warehouseWebService]);


//class warehouse_BankWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllWarehouse_Bank(): ng.IPromise<getAllWarehouse_BankReturnType> {
//        var url = getAllWarehouse_BankUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllWarehouse_BankByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllWarehouse_BankByPageReturnType> {
//        var url = getAllWarehouse_BankByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getWarehouse_Bank(idWarehouse_Bank): ng.IPromise<getWarehouse_BankReturnType> {
//        var url = getWarehouse_BankUrl;
//        var data =  idWarehouse_Bank;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(warehouse_Bank:warehouse_BankModel): ng.IPromise<boolean> {
//        var url = saveWarehouse_BankUrl;
//        var data = warehouse_Bank;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteWarehouse_Bank(warehouse_Bank:warehouse_BankModel): ng.IPromise<boolean> {
//        var url = deleteWarehouse_BankUrl;
//        var data = warehouse_Bank;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("Warehouse_BankWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        warehouse_BankWebService]);


//class warehouseTypeWebService {
//    genericWebConnectionService: genericWebConnectionService;

//    constructor($window, genericWebConnectionService, private globalVariableFactory) {
//        this.genericWebConnectionService = genericWebConnectionService;
//    }

//    public getAllWarehouseTypes(): ng.IPromise<getAllWarehouseTypesReturnType> {
//        var url = getAllWarehouseTypesUrl;
//        var data = {};
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getAllWarehouseTypesByPage(sortingPagingInfo: sortingPagingInfoModel): ng.IPromise<getAllWarehouseTypesByPageReturnType> {
//        var url = getAllWarehouseTypesByPageUrl;
//        var data = sortingPagingInfo;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public getWarehouseType(idWarehouseType): ng.IPromise<getWarehouseTypeReturnType> {
//        var url = getWarehouseTypeUrl;
//        var data =  idWarehouseType;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public saveAuction(warehouseType:warehouseTypeModel): ng.IPromise<boolean> {
//        var url = saveWarehouseTypeUrl;
//        var data = warehouseType;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }

//    public deleteWarehouseType(warehouseType:warehouseTypeModel): ng.IPromise<boolean> {
//        var url = deleteWarehouseTypeUrl;
//        var data = warehouseType;
//        return this.genericWebConnectionService.postRequest(url, data);
//    }
//}


//angular.module('baseModule').service("WarehouseTypeWebService",
//    ["$window",
//        "genericWebConnectionService",
//        "globalVariableFactory",
//        warehouseTypeWebService]);


