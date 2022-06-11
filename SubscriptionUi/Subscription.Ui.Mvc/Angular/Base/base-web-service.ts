class baseWebService<K> {
    public genericWebConnectionService;
    saveUrl: string;
    loadUrl: string;
    deleteUrl: string;

    constructor(genericWebConnectionService, saveUrl = "", loadUrl = "", deleteUrl = "") {
        this.genericWebConnectionService = genericWebConnectionService;
        this.saveUrl = saveUrl;
        this.loadUrl = loadUrl;
        this.deleteUrl = deleteUrl;
    }

    public saveItem(data: K): ng.IPromise<baseResultReturnType<K>> {
        return this.genericWebConnectionService.postRequest(this.saveUrl, data);
    }

    public loadList(data): ng.IPromise<baseResultReturnType<baseListReturnType<K[]>>> {
        return this.genericWebConnectionService.postRequest(this.loadUrl, data);
    }

    public deleteItem(data: K): ng.IPromise<baseResultReturnType<K>> {
        return this.genericWebConnectionService.postRequest(this.deleteUrl, data);
    }
}

interface IBaseWebService<K> {
    saveItem(model: K, url: string): ng.IPromise<baseReturnType<K>>;
}
