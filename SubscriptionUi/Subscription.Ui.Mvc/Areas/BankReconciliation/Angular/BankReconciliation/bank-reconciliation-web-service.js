var bankReconciliationWebService = /** @class */ (function () {
    function bankReconciliationWebService(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }
    bankReconciliationWebService.prototype.loadBankReconciliationContent = function (loadBankReconciliationContentDto) {
        var url = 'BankReconciliation/BankReconciliation/LoadBankReconciliationContent';
        var data = loadBankReconciliationContentDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.analyseBankReconciliationFile = function (analyseBankReconciliationFileDto) {
        var url = 'BankReconciliation/BankReconciliation/AnalyseBankReconciliationFile';
        var data = analyseBankReconciliationFileDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.getBankReconciliationScreenConstant = function () {
        var url = 'BankReconciliation/BankReconciliation/GetBankReconciliationScreenConstant';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.saveBankReconciliationFile = function (saveBankReconciliationFileDto) {
        var url = 'BankReconciliation/BankReconciliation/SaveBankReconciliationFile';
        var data = saveBankReconciliationFileDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.loadList = function (bankReconciliationSortingPagingInfo) {
        var url = 'BankReconciliation/BankReconciliation/LoadList';
        var data = bankReconciliationSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.loadBankStatementStagingDetailBatch = function (loadBankStatementStagingDetailBatchDto) {
        var url = 'BankReconciliation/BankReconciliation/LoadBankStatementStagingDetailBatch';
        var data = loadBankStatementStagingDetailBatchDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.analyseBankReconciliationFileForBatch = function (analyseBankReconciliationFileForBatchDto) {
        var url = 'BankReconciliation/BankReconciliation/AnalyseBankReconciliationFileForBatch';
        var data = analyseBankReconciliationFileForBatchDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    bankReconciliationWebService.prototype.printTransactionReceiptsForBatch = function (analyseBankReconciliationFileForBatchDto) {
        var url = 'BankReconciliation/BankReconciliation/PrintTransactionReceiptsForBatch';
        var data = analyseBankReconciliationFileForBatchDto;
        return this.genericWebConnectionService.downloadRequest(url, data);
    };
    bankReconciliationWebService.prototype.deleteBankReconciliationStagingDetail = function (deleteBankReconciliationStagingDetailDto) {
        var url = 'BankReconciliation/BankReconciliation/DeleteBankReconciliationStagingDetail';
        var data = deleteBankReconciliationStagingDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    ;
    bankReconciliationWebService.prototype.reconcileBankOrder = function (reconcileBankOrderDto) {
        var url = 'BankReconciliation/BankReconciliation/ReconcileBankOrder';
        var data = reconcileBankOrderDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    ;
    bankReconciliationWebService.prototype.saveReconcileBankOrder = function (saveReconcileBankOrderDto) {
        var url = 'BankReconciliation/BankReconciliation/SaveReconcileBankOrder';
        var data = saveReconcileBankOrderDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
    ;
    return bankReconciliationWebService;
}());
//# sourceMappingURL=bank-reconciliation-web-service.js.map