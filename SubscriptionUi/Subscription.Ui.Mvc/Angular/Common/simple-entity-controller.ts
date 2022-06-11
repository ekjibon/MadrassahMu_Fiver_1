abstract class simpleEntityController<S, C, M> {
    scope;
    baseController: baseController;
    service: baseWebService<M>;;
    controller: C;
    listing: M[];
    public sortingPagingInfo;
    totalCount: number;
    currentPage: number;
    sortField: string;
    primaryKey: string;
    broadcastRefreshId: string;
    constructor(scope, service: baseWebService<M>, primaryKey: string, _sortingPagingInfo = null, broadcastRefreshId = null) {
        this.scope = scope;
        this.service = service;
        this.baseController = this.scope.baseController;
        this.primaryKey = primaryKey;
        this.sortingPagingInfo = _sortingPagingInfo;
        this.broadcastRefreshId = broadcastRefreshId;
        this.initVariables();
    }
    abstract broadcastfinishOk();
    abstract broadcastBeforeOk();
    public initVariables() {
        var self = this;
        if (self.sortingPagingInfo == null)
            self.sortingPagingInfo = new sortingPagingInfoModel();
        self.restartPagination();
        self.listing = new Array();
        self.scope.$on(self.broadcastRefreshId, function ($event, message) {
            self.onRefreshBroadcasted($event, message, self);
        });
    }

    public restartPagination() {
        this.sortingPagingInfo.currentPageIndex = 0;
        this.sortingPagingInfo.pageSize = 10;
        this.sortingPagingInfo.pageCount = 0;
        this.sortingPagingInfo.sortField = this.primaryKey;
        this.sortingPagingInfo.sortByDesc = false;
        this.totalCount = 0;
        this.currentPage = 1;
    }
    public gridLoad() {
        var self = this;
        var deferred = self.baseController.q.defer();
        self.baseController.showLoading();

        self.service.loadList(self.sortingPagingInfo)
            .then(function (response: baseResultReturnType<baseListReturnType<M[]>>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.sortingPagingInfo.pageCount = response.result.totalCount;
                    self.listing = response.result.entityList;
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
                }
            })
            .catch(function (error) {
                self.baseController.showMessage("An Error Has Occured On Server, Please Contact Server Admin", error, ALERT_MESSAGE_TYPE.ERROR, false, null, true);
            })
            .finally(function () {
                self.baseController.hideLoading();
            });
    }
    public startSearch() {
        var self = this;
        if (self.baseController.isNullOrUndefined(self.sortingPagingInfo.search) || self.sortingPagingInfo.search.length == 0) {
            self.baseController.showToast(TOASTER_TYPE.WARNING, "", "Please Input a Value in the Search Field");
            return;
        }    
        this.restartPagination();
        this.gridLoad();
    }

    public onRefreshBroadcasted($event, message, caller: simpleEntityController<S, C, M>) {
        var self = caller;
        self.restartPagination();
        self.gridLoad();
    }

    public addEditItem(mode: SCREEN_MODE, item: M) {
        var self = this;
        self.baseController.showCustomModal(simpleEntityPopupController,
            self.baseController.globalVariableFactory.baseServerUrl + '/Common/SimpleEntityPopup',
            self,
            { model: item, mode: mode, service: self.service },
            self.onOk,
            () => { },
            'lg');
    }

    public onOk(dataToPass: { model: M, mode: SCREEN_MODE, caller: simpleEntityController<S, C, M> }) {
        var self = dataToPass.caller;
        if (dataToPass.mode == SCREEN_MODE.EDIT) {
            var positionOfItemInList = self.baseController.searchForEntityInList(self.primaryKey, self.listing, self.primaryKey);
            if (positionOfItemInList != null) {
                self.listing[positionOfItemInList] = dataToPass.model;
            }
        } else {
            if (self.listing.length < self.sortingPagingInfo.pageSize) {
                self.listing.push(dataToPass.model)
            }
        }
        //saveOnPopupCompleted
    }

    public deleteItem(item: M) {
        var self = this;
        self.baseController.showMessage("Confirm Delete", "Delete Confirmation", ALERT_MESSAGE_TYPE.WARNING, true, self.onDeleteConfirm, true, "Ok", "Cancel", null, self, item);
    }

    private onDeleteConfirm(caller: simpleEntityController<S, C, M>, item: M) {
        var self = caller;
        var deferred = self.baseController.q.defer();
        self.baseController.showLoading();
        self.service.deleteItem(item)
            .then(function (response: baseResultReturnType<M>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.baseController.showToast(TOASTER_TYPE.SUCCESS, "Item Deleted");
                    var positionOfItemInList = self.baseController.searchForEntityInList(self.primaryKey, self.listing, response.result);
                    if (positionOfItemInList != null) {
                        self.listing.splice(positionOfItemInList, 1);
                    }
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR, false, null, true);
                }
            })
            .catch(function (errorMsg) {
                self.baseController.showToast(TOASTER_TYPE.ERROR, errorMsg);
                deferred.resolve(errorMsg)
            })
            .finally(function () {
                self.baseController.hideLoading();
            });
        return deferred.promise;
    }
}