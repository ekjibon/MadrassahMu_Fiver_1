class bankReconciliationWebService {
    genericWebConnectionService: genericWebConnectionService;

    constructor(genericWebConnectionService) {
        this.genericWebConnectionService = genericWebConnectionService;
    }

    public loadBankReconciliationContent(loadBankReconciliationContentDto: loadBankReconciliationContentDto): ng.IPromise<baseResultReturnType<loadBankRreconciliationContentReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/LoadBankReconciliationContent';
        var data = loadBankReconciliationContentDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public analyseBankReconciliationFile(analyseBankReconciliationFileDto: analyseBankReconciliationFileDto): ng.IPromise<baseResultReturnType<analyseBankReconciliationFileReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/AnalyseBankReconciliationFile';
        var data = analyseBankReconciliationFileDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public getBankReconciliationScreenConstant(): ng.IPromise<baseResultReturnType<getBankReconciliationScreenConstantReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/GetBankReconciliationScreenConstant';
        var data = {};
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public saveBankReconciliationFile(saveBankReconciliationFileDto: saveBankReconciliationFileDto): ng.IPromise<baseResultReturnType<saveBankReconciliationFileReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/SaveBankReconciliationFile';
        var data = saveBankReconciliationFileDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadList(bankReconciliationSortingPagingInfo: bankReconciliationSortingPagingInfo): ng.IPromise<baseResultReturnType<baseListReturnType<bankReconciliationListReturnType[]>>> {
        var url = 'BankReconciliation/BankReconciliation/LoadList';
        var data = bankReconciliationSortingPagingInfo;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public loadBankStatementStagingDetailBatch(loadBankStatementStagingDetailBatchDto: loadBankStatementStagingDetailBatchDto): ng.IPromise<baseResultReturnType<loadBankStatementStagingDetailBatchReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/LoadBankStatementStagingDetailBatch';
        var data = loadBankStatementStagingDetailBatchDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public analyseBankReconciliationFileForBatch(analyseBankReconciliationFileForBatchDto: analyseBankReconciliationFileForBatchDto): ng.IPromise<baseResultReturnType<analyseBankReconciliationFileForBatchReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/AnalyseBankReconciliationFileForBatch';
        var data = analyseBankReconciliationFileForBatchDto;
        return this.genericWebConnectionService.postRequest(url, data);
    }

    public printTransactionReceiptsForBatch(analyseBankReconciliationFileForBatchDto: analyseBankReconciliationFileForBatchDto) {
        var url = 'BankReconciliation/BankReconciliation/PrintTransactionReceiptsForBatch';
        var data = analyseBankReconciliationFileForBatchDto;
        return this.genericWebConnectionService.downloadRequest(url, data);
    } 

    public deleteBankReconciliationStagingDetail(deleteBankReconciliationStagingDetailDto: deleteBankReconciliationStagingDetailDto): ng.IPromise<baseResultReturnType<boolean>> {
        var url = 'BankReconciliation/BankReconciliation/DeleteBankReconciliationStagingDetail';
        var data = deleteBankReconciliationStagingDetailDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };

    public reconcileBankOrder(reconcileBankOrderDto: reconcileBankOrderDto): ng.IPromise<baseResultReturnType<reconcileBankOrderReturnType>> {
        var url = 'BankReconciliation/BankReconciliation/ReconcileBankOrder';
        var data = reconcileBankOrderDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };

    public saveReconcileBankOrder(saveReconcileBankOrderDto: saveReconcileBankOrderDto): ng.IPromise<baseResultReturnType<boolean>> {
        var url = 'BankReconciliation/BankReconciliation/SaveReconcileBankOrder';
        var data = saveReconcileBankOrderDto;
        return this.genericWebConnectionService.postRequest(url, data);
    };
}

