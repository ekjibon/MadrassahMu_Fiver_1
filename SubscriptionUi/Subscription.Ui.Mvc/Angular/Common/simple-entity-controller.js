var simpleEntityController = /** @class */ (function () {
    function simpleEntityController(scope, service, primaryKey, _sortingPagingInfo, broadcastRefreshId) {
        if (_sortingPagingInfo === void 0) { _sortingPagingInfo = null; }
        if (broadcastRefreshId === void 0) { broadcastRefreshId = null; }
        this.scope = scope;
        this.service = service;
        this.baseController = this.scope.baseController;
        this.primaryKey = primaryKey;
        this.sortingPagingInfo = _sortingPagingInfo;
        this.broadcastRefreshId = broadcastRefreshId;
        this.initVariables();
    }
    ;
    simpleEntityController.prototype.initVariables = function () {
        var self = this;
        if (self.sortingPagingInfo == null)
            self.sortingPagingInfo = new sortingPagingInfoModel();
        self.restartPagination();
        self.listing = new Array();
        self.scope.$on(self.broadcastRefreshId, function ($event, message) {
            self.onRefreshBroadcasted($event, message, self);
        });
    };
    simpleEntityController.prototype.restartPagination = function () {
        this.sortingPagingInfo.currentPageIndex = 0;
        this.sortingPagingInfo.pageSize = 10;
        this.sortingPagingInfo.pageCount = 0;
        this.sortingPagingInfo.sortField = this.primaryKey;
        this.sortingPagingInfo.sortByDesc = false;
        this.totalCount = 0;
        this.currentPage = 1;
    };
    simpleEntityController.prototype.gridLoad = function () {
        var self = this;
        var deferred = self.baseController.q.defer();
        self.baseController.showLoading();
        self.service.loadList(self.sortingPagingInfo)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.sortingPagingInfo.pageCount = response.result.totalCount;
                self.listing = response.result.entityList;
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            }
        })
            .catch(function (error) {
            self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
        })
            .finally(function () {
            self.baseController.hideLoading();
        });
    };
    simpleEntityController.prototype.startSearch = function () {
        var self = this;
        if (self.baseController.isNullOrUndefined(self.sortingPagingInfo.search) || self.sortingPagingInfo.search.length == 0) {
            self.baseController.showToast(TOASTER_TYPE.WARNING, "", "Please Input a Value in the Search Field");
            return;
        }
        this.restartPagination();
        this.gridLoad();
    };
    simpleEntityController.prototype.onRefreshBroadcasted = function ($event, message, caller) {
        var self = caller;
        self.restartPagination();
        self.gridLoad();
    };
    simpleEntityController.prototype.addEditItem = function (mode, item) {
        var self = this;
        self.baseController.showCustomModal(simpleEntityPopupController, self.baseController.globalVariableFactory.baseServerUrl + '/Common/SimpleEntityPopup', self, { model: item, mode: mode, service: self.service }, self.onOk, function () { }, 'lg');
    };
    simpleEntityController.prototype.onOk = function (dataToPass) {
        var self = dataToPass.caller;
        if (dataToPass.mode == SCREEN_MODE.EDIT) {
            var positionOfItemInList = self.baseController.searchForEntityInList(self.primaryKey, self.listing, self.primaryKey);
            if (positionOfItemInList != null) {
                self.listing[positionOfItemInList] = dataToPass.model;
            }
        }
        else {
            if (self.listing.length < self.sortingPagingInfo.pageSize) {
                self.listing.push(dataToPass.model);
            }
        }
        //saveOnPopupCompleted
    };
    simpleEntityController.prototype.deleteItem = function (item) {
        var self = this;
        self.baseController.showMessage("Confirm Delete", "Delete Confirmation", ALERT_MESSAGE_TYPE.WARNING, true, self.onDeleteConfirm, true, "Ok", "Cancel", null, self, item);
    };
    simpleEntityController.prototype.onDeleteConfirm = function (caller, item) {
        var self = caller;
        var deferred = self.baseController.q.defer();
        self.baseController.showLoading();
        self.service.deleteItem(item)
            .then(function (response) {
            if (response.status == STATUS_MESSAGE.SUCCESS) {
                self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Item Deleted");
                var positionOfItemInList = self.baseController.searchForEntityInList(self.primaryKey, self.listing, response.result);
                if (positionOfItemInList != null) {
                    self.listing.splice(positionOfItemInList, 1);
                }
            }
            else {
                self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            }
        })
            .catch(function (errorMsg) {
            self.baseController.showToast(TOASTER_TYPE.ERROR, errorMsg);
            deferred.resolve(errorMsg);
        })
            .finally(function () {
            self.baseController.hideLoading();
        });
        return deferred.promise;
    };
    return simpleEntityController;
}());
//# sourceMappingURL=simple-entity-controller.js.map