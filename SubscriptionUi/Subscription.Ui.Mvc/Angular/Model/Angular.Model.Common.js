var ValidationResult = /** @class */ (function () {
    function ValidationResult() {
    }
    return ValidationResult;
}());
var sortingPagingInfoModel = /** @class */ (function () {
    function sortingPagingInfoModel(sortField, pageSize, pageCount, currentPageIndex, search, sortByDesc) {
        if (sortField === void 0) { sortField = null; }
        if (pageSize === void 0) { pageSize = 0; }
        if (pageCount === void 0) { pageCount = 0; }
        if (currentPageIndex === void 0) { currentPageIndex = 0; }
        if (search === void 0) { search = ""; }
        if (sortByDesc === void 0) { sortByDesc = false; }
        this.sortByDesc = sortByDesc;
        this.sortField = sortField;
        this.pageSize = pageSize;
        this.pageCount = pageCount;
        this.currentPageIndex = currentPageIndex;
        this.search = search;
    }
    return sortingPagingInfoModel;
}());
var ROLE;
(function (ROLE) {
    ROLE[ROLE["Site_Admin"] = 1] = "Site_Admin";
    ROLE[ROLE["Meridian_User"] = 2] = "Meridian_User";
    ROLE[ROLE["System"] = 3] = "System";
})(ROLE || (ROLE = {}));
var fileUploadStateModel = /** @class */ (function () {
    function fileUploadStateModel() {
    }
    return fileUploadStateModel;
}());
//# sourceMappingURL=Angular.Model.Common.js.map