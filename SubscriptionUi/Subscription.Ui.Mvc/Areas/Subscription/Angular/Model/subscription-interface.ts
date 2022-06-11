interface ICommonChildControllerCaller {
    formName: string;
    formValidator: formValidator;
    groupName: Menu;
    registerValidation();
    validateForGroup();
    currentMode: SCREEN_MODE;
}

interface ISelectCustomerControllerCaller {
    next();
    selectedCustomer: customerModel;
    registerSelectCustomerController(selectCustomerController: selectCustomerController);
    currentMode: SCREEN_MODE;
    scheduledTransactionsForCustomer: transactionModel[];
    transactionsForCustomer: transactionModel[];
}

interface ISelectTransactionControllerCaller {
    next();
    selectedCustomer: customerModel;
    transaction: transactionModel;
    registerSelectTransactionController(selectTransactionController: selectTransactionController);
    currentMode: SCREEN_MODE;
    totalTransactionAmount();
    scheduledTransactionsForCustomer: transactionModel[];
}

interface IDefineFrequencyControllerCaller {
    next();
    back();
    selectedCustomer: customerModel;
    currentMode: SCREEN_MODE;
    frequency: defineFrequencyModel;
    registerDefineFrequencyController(defineFrequencyController: defineFrequencyController);
}

interface ISummaryControllerCaller {
    next();
    back();
    transaction: transactionModel;
    frequency: defineFrequencyModel;
    totalTransactionAmount();
    currentMode: SCREEN_MODE;
    registerSummaryController(summaryController: summaryController);
}

interface IViewTransactionDuesCaller {
    transactionDues: transactionDueModel[];
    lastPaymentDate: Date;
    transaction: transactionModel;
    registerPaymentScheduledTransactionController(paymentScheduledTransactionController: paymentScheduledTransactionController);
}

interface IDefinePaymentCaller {
    next();
    back();
    selectedCustomer: customerModel;
    transaction: transactionModel;
    paymentDetails: paymentDetailModel[];
    registerDefinePaymentController(paymentController: paymentController);
    totalTransactionAmount();
    currentMode: SCREEN_MODE;
    totalAmountPaid();
}