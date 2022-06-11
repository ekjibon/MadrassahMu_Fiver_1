class getEmailForTransactionReturnType {
    transactions: baseListReturnType<getEmailForTransactionEmailDetailReturnType[]>;
}

class getEmailForTransactionEmailDetailReturnType {
    idTransaction: number
    receiptNo: string
    idCustomer: number
    idCustomerType: number
    idPerson: number
    idCompany: number
    transactionDate: Date
    fullName: string
    idBankStatementStaging: number
    account: string
    bankStatementDateFrom: Date
    bankStatementDateTo: Date
    idBankStatementStagingState: number
    remarks: number
    branchCode: number
    creditAmount: number
    idBankStatementStagingDetail: number
    idBankStatementStagingDetailBatch: number
    idBankStatementStagingStateBatch: number
    emailDetails: getEmailForTransactionEmailDetailListReturnType[]
}

class getEmailForTransactionEmailDetailListReturnType {
    idMailToSend: number
    idEmailStatus: number
    emailAddress: string
}