class saveBankReconciliationFileDto {
    bankStatements: saveBankReconciliationFileBankStatementDto[];
    idBankStatementStaging: number;
    idBatch: number;
}

class saveBankReconciliationFileBankStatementDto {
    idBankStatementStagingDetail: number;
    transactions: saveBankReconciliationFileBankStatementTransactionDto[];
}

class saveBankReconciliationFileBankStatementTransactionDto extends transactionModel{
    idBankStatementHitList: number;
    idBankStatementStagingHit: number;
}

class deleteBankReconciliationStagingDetailDto {
    idBankStatementStagingDetail: number;
}

class reconcileBankOrderDto {
    idBankStatementStaging: number;
}