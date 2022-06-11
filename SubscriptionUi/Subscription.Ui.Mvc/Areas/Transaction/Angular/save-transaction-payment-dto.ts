class saveTransactionPaymentDto {
    transaction: transactionModel;
    transactionDue: transactionDueModel;
    paymentDetails: paymentDetailModel[];
    idTemporaryTransactionSignature: number;
}