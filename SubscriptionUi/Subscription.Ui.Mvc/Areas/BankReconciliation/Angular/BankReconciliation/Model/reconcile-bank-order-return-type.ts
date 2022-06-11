class reconcileBankOrderReturnType {
     stagingDetails: reconcileBankOrderStagingDetailReturnType[]
}


 class reconcileBankOrderStagingDetailReturnType {
     idBankStatementStagingDetail: number;
     valueDate: Date;
     branchCode: string
     remarks: string
     debitAmount: string
     creditAmount: number
     balance: number
     idOrder: number
     orderDate: Date
     orderNumber: string
     idOrderConcept: number
     idOrderCompany: number
     idOrderPerson: number
     idBankReconOrderType: number
     orderConceptName: string
     reconcileBankOrderDetailReturnType: reconcileBankOrderDetailReturnType[]
     reconcileBankOrderContactTypeReturnType: reconcileBankOrderContactTypeReturnType[]
     reconcileBankOrderAddressReturnType: reconcileBankOrderAddressReturnType[]

}
 class reconcileBankOrderDetailReturnType {
     idOrderDetail: number
     idOrder: number
     idProduct: number
     quantity: number
     rate: number
     description: string
}
 class reconcileBankOrderContactTypeReturnType {
     contactType: string
     description: string
}

 class reconcileBankOrderAddressReturnType {
     address: string
}