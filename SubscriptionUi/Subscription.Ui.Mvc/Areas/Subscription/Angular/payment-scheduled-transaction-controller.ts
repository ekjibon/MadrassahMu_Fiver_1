class paymentScheduledTransactionController {
    scope;
    baseController: baseController;
    subscriptionWebService: subscriptionWebService;
    callerController: IViewTransactionDuesCaller;
    menuEnum;
    selectedMenu: Menu;
    transactionDues: transactionDueModel[];
    payment: paymentModel;
    test: string = "waaaaaaaaaaaa";

    constructor($scope, subscriptionWebService) {
        $scope.controller = this;
        this.scope = $scope;
        this.subscriptionWebService = subscriptionWebService;
        this.callerController = $scope.indexController;
        this.baseController = $scope.baseController;
        //this.initialize();
    }

    public initialize() {
        var self = this;
        self.callerController.registerPaymentScheduledTransactionController(this);
        self.loadScheduledTransactions();
    }

    public selectMenu(getMenu: Menu) {
        var self = this;
        switch (getMenu) {
            case Menu.SUMMARY:
                self.selectedMenu = Menu.SUMMARY;
                break
            case Menu.PAYMENT_SCHEDULE_DETAILS:
                self.selectedMenu = Menu.PAYMENT_SCHEDULE_DETAILS;
                break;
            case Menu.DEFINE_PAYMENT:
                self.selectedMenu = Menu.DEFINE_PAYMENT;
                console.log('p rentrer')
                break;
        }
    }

    public loadScheduledTransactions() {
        var self = this;
        console.log(self.callerController.transactionDues);
        self.transactionDues = self.callerController.transactionDues;
    }

    public settlePayment(transactionDue: transactionDueModel, screenMode: SCREEN_MODE) {
        var self = this;
        /* var _savePaymentForTransactionDueDto = new savePaymentForTransactionDueDto();
         _savePaymentForTransactionDueDto.transactionDues = new Array<transactionDueModel>();
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

    }

    public calculateArrears(_transactionDue: transactionDueModel): number {
        var self = this;

        var _amountDue = _transactionDue.amountDue;
        // var _amountPaid = _transactionDue.transaction.totalAmount;
        //var _arrears = _amountPaid - _amountDue;

        return self.callerController.transaction.totalAmount - _transactionDue.amountDue;
    }

    public getTotalArrearsToDate(): number {
        var self = this;
        // return self.callerController.transactionDues.entityList.filter(due => new Date(due.dueDate).getDate() <= new Date().getDate()).reduce((prev, curr) => prev + curr.amountRemaining, 0);
        return 0;
    }

    public getLastPaymentDate(): string {
        var self = this;
        if (self.callerController.lastPaymentDate == null) {
            return 'No Payment Done Till Date.';
        }

        return self.callerController.lastPaymentDate.toString();
        
    }

    public calculateTotalAmountDue(): number {
        var self = this;
        return self.callerController.transactionDues.reduce((prev, curr) => prev + curr.amountDue, 0);
        // return 0;
    }

    public calculateTotalAmountRemaining(): number {
        var self = this;
        return self.callerController.transactionDues.reduce((prev, curr) => prev + curr.amountRemaining, 0);
        //return 0;
    }

    public selectTransaction(transaction: transactionModel, screenMode: SCREEN_MODE) {
        var self = this;
        if (screenMode == SCREEN_MODE.EDIT)
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/Index/" + transaction.idTransaction + "/" + SCREEN_MODE.EDIT + "/";
        else {
            window.location.href = self.baseController.globalVariableFactory.baseServerUrl + "Subscription/Subscription/Index/-1/" + SCREEN_MODE.ADD + "/";
        }
    }

    public isTransactionScheduled(): boolean {
        var self = this;
        if (self.callerController.transaction.idTransactionType == 2) {
            return false;
        }
        return true;
    }
}

paymentScheduledTransactionModule.controller("paymentScheduledTransactionController"
    , ["$scope"
        , "subscriptionWebService"
        , paymentScheduledTransactionController
    ]);