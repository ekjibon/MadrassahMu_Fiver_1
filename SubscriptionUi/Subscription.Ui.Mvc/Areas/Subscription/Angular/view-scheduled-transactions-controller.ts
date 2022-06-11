class viewScheduledTransactionController implements ISummaryControllerCaller, IViewTransactionDuesCaller{
    scope;
    baseController: baseController;
    subscriptionWebService: subscriptionWebService;
    menuEnum;
    selectedMenu: Menu;
    idTransaction: number;
    scheduledTransactions: transactionModel[];
    testa: string = "vstcontroller";
    lastPaymentDate: Date;
    summaryController: summaryController;
    paymentScheduledTransactionController: paymentScheduledTransactionController;
    defineFrequencyController: defineFrequencyController;
    

    screenModeManager: screenModeManager<subscriptionModel, viewScheduledTransactionController>;

    registerSummaryController(summaryController: summaryController) {
        var self = this;
        self.summaryController = summaryController;
    }

    registerPaymentScheduledTransactionController(paymentScheduledTransactionController: paymentScheduledTransactionController) {
        var self = this;
        self.paymentScheduledTransactionController = paymentScheduledTransactionController;
    }

    totalTransactionAmount(): number {
        var self = this;
        var total = 0;
        if (self.transaction !== undefined && self.transaction.transactionDetails !== undefined) {
            for (var i = 0; i < self.transaction.transactionDetails.length; i++) {
                var product = self.transaction.transactionDetails[i];
                total += (product.rate * product.quantity);
            }
        }
        return total;
    }

    constructor($scope, subscriptionWebService) {
        $scope.indexController = this;
        this.scope = $scope;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.initialize();
    }

    get transaction(): transactionModel {
        return this.screenModeManager.entity.transaction;
    }

    set transaction(transactionModel: transactionModel) {
        this.screenModeManager.entity.transaction = transactionModel;
    }

    get payments(): paymentModel[] {
        if (this.screenModeManager.entity.payments != undefined)
            return this.screenModeManager.entity.payments;
    }

    set payments(paymentModel: paymentModel[]) {
        if (paymentModel != undefined)
            this.screenModeManager.entity.payments = paymentModel;
    }

    get frequency(): defineFrequencyModel {
        return this.screenModeManager.entity.frequency;
    }

    get currentMode(): SCREEN_MODE {
        return this.screenModeManager.currentMode;
    }

    set frequency(frequency: defineFrequencyModel) {
        this.screenModeManager.entity.frequency = frequency;
    }

    get transactionDues(): transactionDueModel[] {
        return this.screenModeManager.entity.transactionDues;
    }

    set transactionDues(transactionDues: transactionDueModel[]) {
        this.screenModeManager.entity.transactionDues = transactionDues;
    }

    public initialize() {
        var self = this;
        self.screenModeManager = new screenModeManager<subscriptionModel, viewScheduledTransactionController>(self, null, false);
        self.screenModeManager.entity = new subscriptionModel();
        var transaction: transactionModel = new transactionModel();
        var transactionDetails = new Array<transactionDetailModel>();
        transaction.transactionDetails = transactionDetails;
        self.screenModeManager.entity.transaction = transaction;
        var transactionDues: transactionDueModel[] = new Array<transactionDueModel>();
        self.screenModeManager.entity.transaction.transactionDues = transactionDues;
        var transactionDues2: transactionDueModel[] = new Array<transactionDueModel>();
        self.screenModeManager.entity.transactionDues = transactionDues2;
        var payments = new Array<paymentModel>();
        payments.push(new paymentModel());
        payments[0].paymentDetails = new Array<paymentDetailModel>();
        self.screenModeManager.entity.transaction.payments = payments;
        var paymentsForScheduledTransaction = new Array<paymentModel>();
        self.screenModeManager.entity.payments = paymentsForScheduledTransaction;
        var frequency = new defineFrequencyModel();
        self.screenModeManager.entity.frequency = frequency;
        self.menuEnum = Menu;
        self.selectedMenu = Menu.SUMMARY;
    }

    public setInfo(id: number, mode: SCREEN_MODE) {
        var self = this;
        self.screenModeManager.currentMode = mode;
        if (id !== -1 && id >= 0) {
            self.idTransaction = id;
            self.loadEntity();
            self.loadPaymentEntity();
        }
        console.log('id: ' + id)
    }

    public selectMenu(getMenu: Menu) {
        var self = this;
        switch (getMenu) {
            case Menu.SUMMARY:
                self.selectedMenu = Menu.SUMMARY;
                break
            case Menu.PAYMENT_SCHEDULE_DETAILS:
                self.selectedMenu = Menu.PAYMENT_SCHEDULE_DETAILS;
                console.log('p rentrer')
                break;
            case Menu.DEFINE_PAYMENT:
                self.selectedMenu = Menu.DEFINE_PAYMENT;
                console.log('p rentrer')
                break;
        }
    }

    public loadEntity() {
        var self = this;
        self.baseController.showLoading();
        var _getPaymentDueDetailDto = new getScheduledTransactionDto();
        _getPaymentDueDetailDto.idTransaction = self.idTransaction;
        self.subscriptionWebService.getScheduledTransaction(_getPaymentDueDetailDto)
            .then(function (response: baseResultReturnType<getScheduledTransactionReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.screenModeManager.entity.transaction = response.result.transaction;
                    self.screenModeManager.entity.transaction.transactionDate = dateParser.dateParserScreenMode(null, response.result.transaction.transactionDate);
                    self.screenModeManager.entity.transactionDues = response.result.transactionDues.entityList;
                    if (response.result.transaction.scheduleSettings.length > 0) {
                        self.screenModeManager.entity.frequency.selectedmonthlyDates = response.result.transaction.scheduleSettings[0].monthOnSpecificDays;
                        self.screenModeManager.entity.frequency.recurEvery = response.result.transaction.scheduleSettings[0].reccurEvery;
                        self.screenModeManager.entity.frequency.selectedMonths = response.result.transaction.scheduleSettings[0].monthOccurs;
                        self.screenModeManager.entity.frequency.frequency = response.result.transaction.scheduleSettings[0].idFrequency;
                        self.screenModeManager.entity.frequency.startDate = response.result.transaction.scheduleSettings[0].startDate;
                        self.screenModeManager.entity.frequency.endDate = response.result.transaction.scheduleSettings[0].endDate;
                    }
                    if (self.paymentScheduledTransactionController != undefined) {
                        self.paymentScheduledTransactionController.loadScheduledTransactions();
                    }
                    self.loadLastPaymentDateForCustomer(self.screenModeManager.entity.transaction.customer.idCustomer, self.screenModeManager.entity.transaction.idTransaction);
                    console.log(response.result);
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
    }

    public loadPaymentEntity() {
        var self = this;
        self.baseController.showLoading();
        var _getPaymentDueDetailDto = new getScheduledTransactionDto();
        _getPaymentDueDetailDto.idTransaction = self.idTransaction;
        self.subscriptionWebService.getScheduledTransactionPayments(_getPaymentDueDetailDto)
            .then(function (response: baseResultReturnType<transactionModel>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.screenModeManager.entity.payments = response.result.payments;
                    console.log(response.result);
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
    }

    public loadLastPaymentDateForCustomer(idCustomer: number, idTransaction: number) {
        var self = this;
        self.baseController.showLoading();
        var _getLastPaymentDateForCustomerDto = new getLastPaymentDateForCustomerDto();
        _getLastPaymentDateForCustomerDto.idCustomer = self.transaction.idCustomer;
        _getLastPaymentDateForCustomerDto.idTransaction = self.transaction.idTransaction;
        self.subscriptionWebService.getLastPaymentDateForCustomer(_getLastPaymentDateForCustomerDto)
            .then(function (response: baseResultReturnType<getLastPaymentDateForCustomerReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.lastPaymentDate = response.result.capturedDate;
                    console.log(response.result);
                } else {
                    self.baseController.showMessage(response.errorMessage, "", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
                self.baseController.hideLoading();
            });
    }

    public editTransaction(idTransaction: number, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ScheduleTransactionSale/" + idTransaction + "/-1/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/ScheduleTransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

    public goToPaymentScreen(transactionDue: transactionDueModel, screenMode: SCREEN_MODE) {
        var self = this;
        console.log(transactionDue);
        //self.screenModeManager.entity.transaction.transactionDues[0] = transactionDue;
        //self.selectMenu(Menu.DEFINE_PAYMENT);
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + transactionDue.idTransaction + "/" + transactionDue.idTransactionDue + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/-1/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

    public settlePayment(idTransaction: number, idTransactionDue: number, screenMode: SCREEN_MODE) {
        var self = this;
       /* var _savePaymentForTransactionDueDto = new savePaymentForTransactionDueDto();
        _savePaymentForTransactionDueDto.transactionDues = new Array<transactionDueModel>();
        _savePaymentForTransactionDueDto.transactionDues = self.screenModeManager.entity.transaction.transactionDues;
        _savePaymentForTransactionDueDto.paymentDetails = self.screenModeManager.entity.transaction.payments[0].paymentDetails;
        self.subscriptionWebService.savePaymentForTransactionDue(_savePaymentForTransactionDueDto)
            .then(function (response: baseResultReturnType<paymentModel>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.payment = response.result;
                    console.log(self.payment);
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });*/
        /*if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Transaction/Transaction/TransactionSale/" + idTransaction + "/" + idTransactionDue + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/Index/-1/-1/" + SCREEN_MODE.ADD + "/";
        }*/
    }

    public back() {
        
    }

    public next() {
        
    }

}

viewScheduledTransactionModule.controller("viewScheduledTransactionController"
    , ["$scope"
        , "subscriptionWebService"
        , viewScheduledTransactionController
    ]);