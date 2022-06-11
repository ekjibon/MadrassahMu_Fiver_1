class paymentController implements ICommonChildControllerCaller {
    scope;
    baseController: baseController;
    indexController: scheduleTransactionController;
    subscriptionWebService: subscriptionWebService;
    callerController: IDefinePaymentCaller;
    generatedDates: Date[];
    isPaymentSelected: boolean = false;
    installmentAmount: number = 0;
    selectedPaymentDetail: paymentDetailModel;
    payment: paymentModel;
    transactionDue: transactionDueModel;
    isCashOrCredit: string = "cash";
    mode;

    formName: string;

    formValidator: formValidator;
    groupName: Menu = Menu.SELECT_TRANSACTION;

    constructor($scope
        , private $parse
        , private toaster,
        subscriptionWebService) {
        $scope.controller = this;
        this.scope = $scope;
        this.subscriptionWebService = subscriptionWebService;
        this.baseController = $scope.baseController;
        this.callerController = $scope.indexController;
        this.initialize();
    }

    get selectedCustomer(): customerModel {
        return this.callerController.selectedCustomer;
    }

    get customerAddress(): string {
        if (this.callerController.selectedCustomer != null && this.callerController.selectedCustomer.person != null && this.callerController.selectedCustomer.person.person_Address.length > 0) {
            return this.callerController.selectedCustomer.person.person_Address[0].address.addressLine1 + ", " + this.callerController.selectedCustomer.person.person_Address[0].address.city;
        }
    }

    get paymentDetails(): paymentDetailModel[] {
        return this.callerController.paymentDetails;
    }

    set paymentDetails(paymentDetailModel: paymentDetailModel[]) {
        this.callerController.paymentDetails = paymentDetailModel;
    }

    get currentMode(): SCREEN_MODE {
        return this.callerController.currentMode;
    }

    get transaction(): transactionModel {
        return this.callerController.transaction;
    }

    public totalTransactionAmount(): number {
        return this.callerController.totalTransactionAmount();
    }

    public totalAmountPaid(): number {
        return this.callerController.totalAmountPaid();
    }

    public totalAmountRemaining(): number {
        return this.totalTransactionAmount() - this.totalAmountPaid();
    }

    public initialize() {
        var self = this;
        //self.callerController.screenModeManager.setEntity(self.transactionDetails);
        var _paymentDetail: paymentDetailModel = new paymentDetailModel()
        if (self.paymentDetails != null) {
            self.selectedPaymentDetail = _paymentDetail;
        }
        self.callerController.registerDefinePaymentController(this);
        self.mode = SCREEN_MODE;
    }

    public registerValidation() {
        var self = this;
        if (self.formValidator != null) {
            self.formValidator.deRegister();
        }
        self.formValidator = new formValidator(this.$parse, this.toaster, self.scope, self.formName);
        self.formValidator.registerValidation('paymentMethod', 'Please enter at least one payment method.', function () {
            return self.paymentDetails.length > 0
        });
        self.formValidator.registerGroupValidation(self.groupName.toString(), ['paymentMethod'])

    }

    public validateForGroup(): boolean {
        var self = this;
        var isValid: boolean = true;
        var formScope = self.scope[self.formName];

        var errorMessages: string[] = [];

        isValid = isValid && self.formValidator.validateGroup(self.groupName.toString(), false, true);
        errorMessages = errorMessages.concat(self.formValidator.getAllValidationMessagesForGroup(self.groupName.toString()));

        if (errorMessages.length > 0) {
            self.baseController.showMessage(
                errorMessages.join('\n'),
                'ERROR',
                ALERT_MESSAGE_TYPE.ERROR
            );
        }

        return isValid;
    }

    public cashPayment() {
        var self = this;
        self.isPaymentSelected = false;
        var _paymentDetail: paymentDetailModel = new paymentDetailModel();
        self.paymentDetails = [];
        _paymentDetail.idPaymentMethod = 1;
        _paymentDetail.description = "Cash"; //self.selectedPaymentDetail.description
        _paymentDetail.paymentAmount = self.totalTransactionAmount();

        self.paymentDetails.push(_paymentDetail);
        self.selectedPaymentDetail = new paymentDetailModel();
    }

    public customPayment() {
        var self = this;
        self.paymentDetails = [];
        self.isPaymentSelected = true;
    }

    public removePaymentDetail(paymentDetail: paymentDetailModel) {
        var self = this;
        self.paymentDetails.splice(self.paymentDetails.indexOf(paymentDetail), 1);
    }

    public addPayment() {
        var self = this;
        var _paymentDetail: paymentDetailModel = new paymentDetailModel();
        _paymentDetail.idPaymentMethod = self.selectedPaymentDetail.idPaymentMethod;
        _paymentDetail.paymentAmount = self.selectedPaymentDetail.paymentAmount;
        _paymentDetail.chequeNo = self.selectedPaymentDetail.chequeNo;
        _paymentDetail.description = 'Cash';
        _paymentDetail.bankAccountNo = self.selectedPaymentDetail.bankAccountNo;

        if (self.paymentDetails.reduce((sum, current) => sum + current.paymentAmount, 0) + _paymentDetail.paymentAmount > self.totalTransactionAmount()) {
            self.baseController.showMessage('Number of payment methods exceeds total transaction amount.', 'Warning', ALERT_MESSAGE_TYPE.WARNING);
            return;
        }

        if (self.paymentDetails.reduce((sum, current) => sum + current.paymentAmount, 0) + _paymentDetail.paymentAmount <= self.totalTransactionAmount()) {
            self.baseController.showMessage('Do you confirm that this is a credit transaction?', 'Warning', ALERT_MESSAGE_TYPE.WARNING, true, () => {
                self.isCashOrCredit = 'credit';
                self.transaction.idTransactionType = 1;
                _paymentDetail.description = 'Credit';
                self.paymentDetails.push(_paymentDetail);
            }, null, "Confirm", "No", () => {
                    self.baseController.showMessage('Please give the exact total transaction amount.', 'Warning', ALERT_MESSAGE_TYPE.WARNING, false, () => { return; });
            });
        }

        //if (self.paymentDetails.reduce((sum, current) => sum + current.paymentAmount, 0) + _paymentDetail.paymentAmount == self.totalTransactionAmount()) {
        //    self.paymentDetails.push(_paymentDetail);
        //}

        
        /*if (self.paymentDetails.reduce((sum, current) => sum + current.paymentAmount, 0) + _paymentDetail.paymentAmount < self.totalTransactionAmount()) {
            self.baseController.showMessage('Do you confirm that this is a credit transaction?', 'Warning', ALERT_MESSAGE_TYPE.WARNING, true, () => {
                self.isCashOrCredit == 'credit';
                self.transaction.idTransactionType = 1;
            }, null, "Confirm", "No", () => {
                self.isCashOrCredit == 'cash';
            });
            self.paymentDetails.push(_paymentDetail);
        }*/

        self.selectedPaymentDetail = new paymentDetailModel();
    }

    /*public totalAmountPaid(): number {
        var self = this;
        return self.callerController.screenModeManager.entity.totalAmountPaid();
    }*/

    /*public amountRemainingToBePaid(): number {
        var self = this;
        return self.callerController.screenModeManager.entity.amountRemainingToBePaid() - self.installmentAmount;
    }*/

    /*public searchCustomer() {
        var self = this;
        self.baseController.showCustomModal(customerSearchPopupModalController,
            self.baseController.globalVariableFactory.baseServerUrl + 'Subscription/Subscription/AddInstallmentPopup',
            self,
            {
                model: self.selectedCustomer
            },
            self.onSearchCustomerOk,
            () => { }
        );
    }

    public onSearchCustomerOk(dataToPass) {
        var self = this;
        self.selectedCustomer = dataToPass.model;
        console.log(self.selectedCustomer)
    }*/

    public openInstallmentModal() {
        var self = this;
        var installment: installmentModel;
        //console.log(self.baseController.globalVariableFactory.baseServerUrl + 'Subscription/Subscription/Index/AddInstallmentPopup.cshtml');
        //self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.PAYMENT_CONTROLLER, "CONTROLLER", self)
        self.baseController.showCustomModal(addInstallmentPopupController,
            self.baseController.globalVariableFactory.baseServerUrl + 'Subscription/Subscription/AddInstallmentPopup',
            self,
            {
                $scope: self.scope
            },
            self.openInstallmentModalOK,
            () => { },
            'lg', '', '', true);
    }

    public openInstallmentModalOK(dataToPass: { model: installmentModel, caller: any }) {
        var self = dataToPass.caller;
        //self.installment = dataToPass.model;
        //console.log(self.installment);
        self.calculateInstallmentDates(dataToPass.model);
    }

    public calculateInstallmentDates(installment: installmentModel) {
        var self = this;
        switch (installment.frequency) {
            case 'day':
                self.generatedDates = [];
                self.generatedDates.push(installment.startDate);
                var newDate: Date = new Date();
                for (var i = 0; i < installment.noOfInstallment - 1; i++) {
                    //Adding Days
                    newDate = self.generatedDates[i];
                    newDate.setDate(newDate.getDate() + installment.frequencyNumber);
                    self.generatedDates.push(newDate);

                    newDate = new Date();
                }

                break;
        }
    }

    public settlePayment(transactionDue: transactionDueModel) {
        var self = this;
        var _savePaymentForTransactionDueDto = new savePaymentForTransactionDueDto();
        _savePaymentForTransactionDueDto.transactionDues = new Array<transactionDueModel>();
        // _savePaymentForTransactionDueDto.transactionDues = transactionDue;
        self.subscriptionWebService.savePaymentForTransactionDue(_savePaymentForTransactionDueDto)
            .then(function (response: baseResultReturnType<paymentModel>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.payment = response.result;
                    console.log(self.payment);
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    }

    /*public calculateInstallmentAmount() {
        var self = this;
        self.installmentAmount = self.totalAmountPaid() / self.generatedDates.length;
    }

    public assignPaymentDueSetting(installment: installmentModel) {
        var self = this;
        if (installment.frequency == 'day') {
            self.paymentDueSetting.idPaymentDueFrequency = 1;
        }
        self.paymentDueSetting.recurringWeekOrDayOrMonthAmount = self.amountRemainingToBePaid() / installment.noOfInstallment;
        self.paymentDueSetting.datePosition = self.generatedDates[self.generatedDates.length - 1].getDate();
        self.paymentDueSetting.month = self.generatedDates[self.generatedDates.length - 1].getMonth();
        self.paymentDueSetting.startDate = self.generatedDates[1];
        self.paymentDueSetting.endDate = self.generatedDates[self.generatedDates.length - 1];
    }*/

    public setRadioButton(typeOfPayment: string) {
        var self = this;
        if (typeOfPayment == 'cash') {
            self.isCashOrCredit = 'cash';
        } else {
            self.isCashOrCredit = 'credit';
        }
    }

    public back() {
        var self = this;
        self.indexController.selectMenu(2);
    }

}

class installmentModel {
    noOfInstallment: number;
    startDate: Date;
    frequencyNumber: number;
    frequency: string;
}

paymentModule.controller("paymentController"
    , ["$scope"
        , "subscriptionWebService"
        , paymentController
    ]);