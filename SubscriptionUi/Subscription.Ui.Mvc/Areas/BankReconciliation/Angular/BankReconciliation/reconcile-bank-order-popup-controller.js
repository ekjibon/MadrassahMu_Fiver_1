////class reconcileBankOrderPopupController<Y> {
////    baseController: baseController;
////    bankReconciliationWebService: bankReconciliationWebService;
////    idBankStatementStaging: number;
////    reconcileBankOrderViewModel: reconcileBankOrderViewModel[];
////    scope;
////    administrationCustomerWebService: administrationCustomerWebService;
////    screenModeManager: screenModeManager<customerModel, administrationCustomerDetailController>;
////    callerController: IAdministrationCustomerDetailBasicInfoCaller;
////    constructor($scope
////        , bankReconciliationWebService: bankReconciliationWebService) {
////        var self = this;
////        $scope.controller = this;
////        this.callerController = $scope.$parent.controller;
////        this.bankReconciliationWebService = bankReconciliationWebService;
////        this.scope = $scope;
////        this.baseController = this.scope.baseController;
////        this.initVariables();
////        this.initialize();
////    }
////    public initVariables() {
////        var self = this;
////        self.idBankStatementStaging = self.baseController.globalVariableFactory.sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.TRANSFER, "IDBANKSTATEMENTSTAGING");
////        console.log(self.idBankStatementStaging);
////    }
////    public initialize() {
////        var self = this;
////        self.gridLoad();
////    }
////    public gridLoad() {
////        var self = this;
////        var _reconcileBankOrderDto: reconcileBankOrderDto = new reconcileBankOrderDto();
////        _reconcileBankOrderDto.idBankStatementStaging = self.idBankStatementStaging;
////        self.bankReconciliationWebService.reconcileBankOrder(_reconcileBankOrderDto)
////            .then(function (response: baseResultReturnType<reconcileBankOrderReturnType>) {
////                self.baseController.hideLoading();
////                if (response.status == STATUS_MESSAGE.SUCCESS) {
////                    self.reconcileBankOrderViewModel = self.convertReconcileBankOrderToViewModel(response.result.stagingDetails);
////                }
////                else {
////                    self.baseController.showMessage(response.errorMessage, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
////                }
////            }).catch(function (errorMsg) {
////                self.baseController.hideLoading();
////                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
////            }).finally(function () {
////            });
////    }
////    public convertReconcileBankOrderToViewModel(_reconcileBankOrderStagingDetailReturnType: reconcileBankOrderStagingDetailReturnType[]): reconcileBankOrderViewModel[] {
////        var self = this;
////        var _reconcileBankOrderViewModels: reconcileBankOrderViewModel[] = []
////        Enumerable.From(_reconcileBankOrderStagingDetailReturnType).ForEach(function (reconcileBankOrder: reconcileBankOrderStagingDetailReturnType) {
////            var _reconcileBankOrderViewModel: reconcileBankOrderViewModel =
////                Enumerable.From(_reconcileBankOrderViewModels).Where(function (_reconcileBankOrderViewModel: reconcileBankOrderViewModel) {
////                    return _reconcileBankOrderViewModel.idMatchType == reconcileBankOrder.idBankReconOrderType
////                }).FirstOrDefault(null);
////            if (_reconcileBankOrderViewModel == null) {
////                _reconcileBankOrderViewModel = new reconcileBankOrderViewModel();
////                _reconcileBankOrderViewModel.bankStagings = [];
////                _reconcileBankOrderViewModel.groupName = self.getMatchName(reconcileBankOrder.idBankReconOrderType);
////                _reconcileBankOrderViewModel.idMatchType = reconcileBankOrder.idBankReconOrderType;
////                _reconcileBankOrderViewModels.push(_reconcileBankOrderViewModel);
////            }
////            var _reconcileBankOrderDetailViewModel: reconcileBankOrderDetailViewModel = JSON.parse(JSON.stringify(reconcileBankOrder));
////            _reconcileBankOrderDetailViewModel.totalAmount = Enumerable.From(reconcileBankOrder.reconcileBankOrderDetailReturnType).Sum(function (_reconcileBankOrderDetailReturnType: reconcileBankOrderDetailReturnType) {
////                return _reconcileBankOrderDetailReturnType.quantity * _reconcileBankOrderDetailReturnType.rate;
////            })
////            _reconcileBankOrderViewModel.bankStagings.push(_reconcileBankOrderDetailViewModel);
////        })
////        return _reconcileBankOrderViewModels;
////    }
////    public onOkToModal() {
////        var self = this;
////        self.saveReconcileBankOrder();
////    }
////    public saveReconcileBankOrder() {
////        var self = this;
////        var _saveReconcileBankOrderDto: saveReconcileBankOrderDto = new saveReconcileBankOrderDto();
////        _saveReconcileBankOrderDto.idBankStatementStagingDetails = [];
////        var exactMatches: reconcileBankOrderViewModel = Enumerable.From(self.reconcileBankOrderViewModel).Where(function (_reconcileBankOrderViewModel: reconcileBankOrderViewModel) {
////            return _reconcileBankOrderViewModel.idMatchType == 1
////        }).FirstOrDefault(null);
////        if (exactMatches != null) {
////            Enumerable.From(exactMatches.bankStagings).ForEach(function (_reconcileBankOrderDetailViewModel: reconcileBankOrderDetailViewModel) {
////                if (_reconcileBankOrderDetailViewModel.isSelected == true) {
////                    _saveReconcileBankOrderDto.idBankStatementStagingDetails.push(_reconcileBankOrderDetailViewModel.idBankStatementStagingDetail);
////                }
////            })
////        }
////        console.log(_saveReconcileBankOrderDto);
////        self.bankReconciliationWebService.saveReconcileBankOrder(_saveReconcileBankOrderDto)
////            .then(function (response: baseResultReturnType<boolean>) {
////                self.baseController.hideLoading();
////                if (response.status == STATUS_MESSAGE.SUCCESS) {
////                    self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.TRANSFER, "RECONCILEBANKORDER", self.reconcileBankOrderViewModel)
////                    self.scope.$close(self.baseController.globalVariableFactory.sessionVariables);
////                }
////                else {
////                    self.baseController.showMessage(response.errorMessage, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
////                }
////            }).catch(function (errorMsg) {
////                self.baseController.hideLoading();
////                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
////            }).finally(function () {
////            });
////    }
////    public onCancelToModal() {
////        var self = this;
////        self.scope.$dismiss();
////    }
////    public getMatchName(hitType: number) {
////        switch (hitType) {
////            case 3:
////                return "Not Applicable";
////            case 1:
////                return "Exact Match";
////            case 2:
////                return "Not Matched"
////        }
////    }
////}
////bankReconciliationModule.controller("reconcileBankOrderPopupController"
////    , ["$scope"
////        , "bankReconciliationWebService"
////        , reconcileBankOrderPopupController
////    ]);
////class reconcileBankOrderViewModel {
////    groupName: string;
////    idMatchType: number;
////    bankStagings: reconcileBankOrderDetailViewModel[]
////}
////class reconcileBankOrderDetailViewModel extends reconcileBankOrderStagingDetailReturnType {
////    totalAmount: number;
////    isSelected: boolean;
////}
//# sourceMappingURL=reconcile-bank-order-popup-controller.js.map