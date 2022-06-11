class ValidationResult {
    public errorMessages: string[];
    public field: string;
}

class sortingPagingInfoModel {
    constructor(sortField: string = null, pageSize: number = 0, pageCount: number = 0, currentPageIndex: number = 0, search: string = "", sortByDesc: boolean = false) {
        this.sortByDesc = sortByDesc;
        this.sortField = sortField;
        this.pageSize = pageSize;
        this.pageCount = pageCount;
        this.currentPageIndex = currentPageIndex;
        this.search = search;
    }
    public idCustomer: number
    public sortField: string
    public sortColumn: string
    public sortByDesc: boolean
    public pageSize: number
    public pageCount: number
    public currentPageIndex: number
    public search: string;
}

enum ROLE {
    Site_Admin = 1,
    Meridian_User = 2,
    System = 3
}

class fileUploadStateModel {
    id: string;
    isUploaded: boolean;
}