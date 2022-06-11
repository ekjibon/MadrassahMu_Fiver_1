class bankReconciliationController {
    scope;
    baseController: baseController;
    bankReconciliationWebService: bankReconciliationWebService;
    transactionSaleWebService: transactionSaleWebService;
    preloadedData: {
        banks: bankModel[]
    } =
        {
            banks: [],
        };

    screenState: bankReconciliationScreenState = bankReconciliationScreenState.TO_LOAD_RAW_FILE;
    bankReconOrderProcessStateEnum;
    //screenState: bankReconciliationScreenState = bankReconciliationScreenState.FILE_ANALYSED;

    bankReconciliationScreenStateEnum;

    selectedBank: bankModel = null;
    selectedDocument: documentModel;

    fileContent: bankStatementStagingModel;

    processedFile: bankReconProcessedMainFile[] = [];

    idBankStatementStaging: number;
    hasSavedBeenRequested: boolean = false;

    screenMode: SCREEN_MODE;

    bankStatementStagingDetailBatches: bankStatementStagingDetailBatchModel[] = [];
    bankStatementStaging: bankStatementStagingModel;

    selectedBatch: bankStatementStagingDetailBatchModel;

    bankStatementStagingStateEnum;

    constructor($scope
        , bankReconciliationWebService
        , transactionSaleWebService
    ) {
        var self = this;

        $scope.controller = this;
        this.bankReconciliationWebService = bankReconciliationWebService;
        this.transactionSaleWebService = transactionSaleWebService;
        this.scope = $scope;

        this.baseController = this.scope.baseController;

    }

    public initVariables() {
        var self = this;
        this.baseController = this.scope.baseController;
        self.bankReconciliationScreenStateEnum = bankReconciliationScreenState;
        self.bankStatementStagingStateEnum = bankStatementStagingStateEnum;
        self.bankReconOrderProcessStateEnum = bankReconOrderProcessStateEnum;
        if (self.screenMode == SCREEN_MODE.EDIT) {
            self.loadBatches();
            //screenState: bankReconciliationScreenState = bankReconciliationScreenState.TO_LOAD_RAW_FILE;
        }

        //self.selectedBank = new bankModel();
        //self.selectedBank.idBank = 1
        //self.selectedDocument = JSON.parse('{"fileExtension":".csv","fileName":"d9fe62f8-5d41-4997-9860-9956ad1e4ee1","idParameterBasePhysicalFilePath":8,"idParameterBaseServerUrl":9,"parameter1":{"idParameter":9,"paramaterValue":"https://connectus.mu/Uploads/","isDeactivated":null,"code":null,"documents":[],"documents1":[]},"physicalFilePath":"d9fe62f8-5d41-4997-9860-9956ad1e4ee1.csv","serverFilePath":"d9fe62f8-5d41-4997-9860-9956ad1e4ee1.csv"}');
        //self.analyseFile();

        //self.processedFile = JSON.parse(analysedfile);
        //self.screenState = bankReconciliationScreenState.FILE_ANALYSED;
    }

    public setInfo(id: number, mode: SCREEN_MODE) {
        var self = this;
        self.idBankStatementStaging = id;
        self.screenMode = mode;

        self.loadScreenConstants();
        this.initVariables();

    }

    public loadScreenConstants() {
        var self = this;
        self.bankReconciliationWebService.getBankReconciliationScreenConstant()
            .then(function (response: baseResultReturnType<getBankReconciliationScreenConstantReturnType>) {
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.preloadedData.banks = response.result.banks;
                    self.onScreenDetailLoaded();
                }
            }).catch(function (errorMsg) {
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    }
    public onScreenDetailLoaded() {

    }
    public initialize() {
        var self = this;
    }

    public loadBatches() {
        var self = this;
        self.baseController.showLoading();
        var _loadBankStatementStagingDetailBatchDto: loadBankStatementStagingDetailBatchDto = new loadBankStatementStagingDetailBatchDto();
        _loadBankStatementStagingDetailBatchDto.idBankStatementStaging = self.idBankStatementStaging;

        self.bankReconciliationWebService.loadBankStatementStagingDetailBatch(_loadBankStatementStagingDetailBatchDto)
            .then(function (response: baseResultReturnType<loadBankStatementStagingDetailBatchReturnType>) {
                self.baseController.hideLoading();
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.bankStatementStagingDetailBatches = response.result.batches.entityList;
                    self.bankStatementStaging = response.result.bankStatementStaging;
                    self.screenState = bankReconciliationScreenState.BATCH_LOADED;
                } else {
                    self.baseController.showMessage(response.errorMessage, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.hideLoading();
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    }

    public loadFile(files: File[]) {
        var self = this;
        if (self.baseController.isNullOrUndefined(self.selectedBank)) {
            self.baseController.showToast(TOASTER_TYPE.ERROR, 'Please select bank');
            return;
        }

        self.screenState = bankReconciliationScreenState.UPLOADING_RAW_FILE;

        if (files.length == 0)
            return;

        var onPictureAddeds: onPictureAddedDto[] = [];
        var onPictureAdded: onPictureAddedDto = new onPictureAddedDto();
        onPictureAdded.file = files[0];
        onPictureAdded.document = new documentModel();
        onPictureAddeds.push(onPictureAdded);

        self.baseController.onPictureAdded(onPictureAddeds)
            .then(function (response: onPictureAddedDto[]) {

                self.screenState = bankReconciliationScreenState.RAW_FILE_UPLOADED;

                self.selectedDocument = response[0].document;
                self.loadFileContent();
            })
            .catch(function (error: string) {

                self.screenState = bankReconciliationScreenState.TO_LOAD_RAW_FILE;
                self.baseController.showMessage(error, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            })
    }

    public loadFileContent() {
        var self = this;
        self.screenState = bankReconciliationScreenState.PARSING_RAW_FILE;

        var _loadBankReconciliationContentDto: loadBankReconciliationContentDto = new loadBankReconciliationContentDto();
        _loadBankReconciliationContentDto.idBank = self.selectedBank.idBank;
        _loadBankReconciliationContentDto.document = self.selectedDocument;

        self.baseController.showLoading();

        self.bankReconciliationWebService.loadBankReconciliationContent(_loadBankReconciliationContentDto)
            .then(function (response: baseResultReturnType<loadBankRreconciliationContentReturnType>) {
                self.baseController.hideLoading();
                self.screenState = bankReconciliationScreenState.RAW_FILE_PARSED;
                self.fileContent = response.result.bankStatementStaging;
                self.showWarningMessages(response.result.warningMessages);
            })
            .catch(function (error: string) {
                self.baseController.hideLoading();
                self.screenState = bankReconciliationScreenState.TO_LOAD_RAW_FILE;
                self.baseController.showMessage(error, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            })
    }

    public showWarningMessages(messages: string[]) {
        var self = this;
        if (messages.length > 0) {
            self.baseController.showToast(TOASTER_TYPE.WARNING, messages.join("<br/>"));
        }
    }

    public analyseFile() {
        var self = this;
        self.screenState = bankReconciliationScreenState.ANALYSING_FILE;
        var _analyseBankReconciliationFileDto: analyseBankReconciliationFileDto = new analyseBankReconciliationFileDto();
        _analyseBankReconciliationFileDto.idBank = self.selectedBank.idBank;
        _analyseBankReconciliationFileDto.document = self.selectedDocument;

        self.baseController.showLoading();
        self.bankReconciliationWebService.analyseBankReconciliationFile(_analyseBankReconciliationFileDto)
            .then(function (response: baseResultReturnType<analyseBankReconciliationFileReturnType>) {
                self.baseController.hideLoading();

                self.screenState = bankReconciliationScreenState.BATCH_LOADED;

                self.idBankStatementStaging = response.result.idBankStatementStaging;
                self.bankStatementStaging = response.result.bankStatementStaging;
                self.bankStatementStagingDetailBatches = response.result.bankStatementStagingDetailBatches;

            })
            .catch(function (error: string) {
                self.baseController.hideLoading();

                bankReconciliationScreenState.TO_LOAD_RAW_FILE;
                self.baseController.showMessage(error, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            })
    }

    public analyseBatch(batch: bankStatementStagingDetailBatchModel) {
        var self = this;

        if (batch.idBankStatementStagingState == bankStatementStagingStateEnum.PROCESSING_DONE) {
            self.baseController.showToast(TOASTER_TYPE.ERROR, 'Batch already processed');
            return;
        }

        self.selectedBatch = batch;
        var _analyseBankReconciliationFileForBatchDto: analyseBankReconciliationFileForBatchDto = new analyseBankReconciliationFileForBatchDto();
        _analyseBankReconciliationFileForBatchDto.idBankStatementStaging = self.idBankStatementStaging;
        _analyseBankReconciliationFileForBatchDto.idBatch = batch.idBankStatementStagingDetailBatch;

        self.baseController.showLoading();
        self.bankReconciliationWebService.analyseBankReconciliationFileForBatch(_analyseBankReconciliationFileForBatchDto)
            .then(function (response: baseResultReturnType<analyseBankReconciliationFileForBatchReturnType>) {
                self.baseController.hideLoading();

                self.screenState = bankReconciliationScreenState.FILE_ANALYSED;
                self.processAnalysedFile(response.result);
            })
            .catch(function (error: string) {
                self.baseController.hideLoading();

                bankReconciliationScreenState.TO_LOAD_RAW_FILE;
                self.baseController.showMessage(error, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            })

    }

    public processAnalysedFile(_analyseBankReconciliationFileForBatchReturnType: analyseBankReconciliationFileForBatchReturnType) {
        var self = this;
        self.selectedBank = _analyseBankReconciliationFileForBatchReturnType.bank;
        self.processedFile = [];

        Enumerable.From(_analyseBankReconciliationFileForBatchReturnType.bankStatementStagingDetails).ForEach(function (bankStatementStagingDetail: bankStatementStagingDetailModel) {
            var _bankReconProcessFileViewModel: bankReconProcessFileViewModel = new bankReconProcessFileViewModel();
            var hitTypes: number[] = [];
            _bankReconProcessFileViewModel.hits = [];
            _bankReconProcessFileViewModel.validationErrors = [];
            _bankReconProcessFileViewModel.isValid = false;
            _bankReconProcessFileViewModel.currentTotal = 0;

            _bankReconProcessFileViewModel.valueDate = bankStatementStagingDetail.valueDate;
            _bankReconProcessFileViewModel.branchCode = bankStatementStagingDetail.branchCode;
            _bankReconProcessFileViewModel.remarks = bankStatementStagingDetail.remarks;
            _bankReconProcessFileViewModel.debitAmount = bankStatementStagingDetail.debitAmount;
            _bankReconProcessFileViewModel.creditAmount = bankStatementStagingDetail.creditAmount;
            _bankReconProcessFileViewModel.idBankStatementStagingDetail = bankStatementStagingDetail.idBankStatementStagingDetail;
            _bankReconProcessFileViewModel.transactions = [];
            bankStatementStagingDetail.bankStatementStagingHits.forEach(function (bankStatementStagingHit: bankStatementStagingHitModel) {

                var _bankReconProcessFileHitViewModel: bankReconProcessFileHitViewModel = new bankReconProcessFileHitViewModel();
                _bankReconProcessFileHitViewModel.hitCount = bankStatementStagingHit.hitCount;

                _bankReconProcessFileHitViewModel.hitType = bankStatementStagingHit.idBankReconHitType;
                _bankReconProcessFileHitViewModel.idBankStatementStagingHit = bankStatementStagingHit.idBankStatementStagingHit;
                _bankReconProcessFileHitViewModel.idBankStatementHitList = bankStatementStagingHit.idBankStatementHitList;
                _bankReconProcessFileHitViewModel.hitDetails = [];

                bankStatementStagingHit.bankStatementStagingHit_TransactionPreset.forEach(function (bankStatementStagingHitDetail: bankStatementStagingHit_TransactionPresetModel) {
                    var _bankReconProcessFileHitTransactionPresetViewModel: bankReconProcessFileHitTransactionPresetViewModel = new bankReconProcessFileHitTransactionPresetViewModel();
                    _bankReconProcessFileHitTransactionPresetViewModel.customer = bankStatementStagingHitDetail.transactionPreset.customer.fullName;
                    _bankReconProcessFileHitTransactionPresetViewModel.customerObject = bankStatementStagingHitDetail.transactionPreset.customer;
                    _bankReconProcessFileHitTransactionPresetViewModel.idCustomer = bankStatementStagingHitDetail.transactionPreset.idCustomer;
                    _bankReconProcessFileHitTransactionPresetViewModel.idTransactionAccount = bankStatementStagingHitDetail.transactionPreset.idTransactionAccount;
                    _bankReconProcessFileHitTransactionPresetViewModel.idTransactionClass = bankStatementStagingHitDetail.transactionPreset.idTransactionClass;
                    _bankReconProcessFileHitTransactionPresetViewModel.idTransactionPreset = bankStatementStagingHitDetail.transactionPreset.idTransactionPreset;
                    _bankReconProcessFileHitTransactionPresetViewModel.idTransactionTemplate = bankStatementStagingHitDetail.transactionPreset.idTransactionTemplate;
                    _bankReconProcessFileHitTransactionPresetViewModel.totalAmount = bankStatementStagingHitDetail.transactionPreset.totalAmount;
                    _bankReconProcessFileHitTransactionPresetViewModel.details = [];

                    bankStatementStagingHitDetail.transactionPreset.transactionDetailPresets.forEach(function (transactionDetailPreset: transactionDetailPresetModel) {
                        var _bankReconProcessFileHitTransactionPresetDetailViewModel: bankReconProcessFileHitTransactionPresetDetailViewModel = new bankReconProcessFileHitTransactionPresetDetailViewModel();
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.description = transactionDetailPreset.description;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.product = transactionDetailPreset.product.description;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.productObject = transactionDetailPreset.product;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.idProduct = transactionDetailPreset.product.idProduct;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.idTransactionClass = transactionDetailPreset.idTransactionClass;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.transactionClassObject = transactionDetailPreset.transactionClass;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.idTransactionDetailPreset = transactionDetailPreset.idTransactionDetailPreset;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.quantity = transactionDetailPreset.quantity;
                        _bankReconProcessFileHitTransactionPresetDetailViewModel.rate = transactionDetailPreset.rate;
                        _bankReconProcessFileHitTransactionPresetViewModel.details.push(_bankReconProcessFileHitTransactionPresetDetailViewModel);
                    })
                    _bankReconProcessFileHitViewModel.hitDetails.push(_bankReconProcessFileHitTransactionPresetViewModel);
                });

                hitTypes.push(_bankReconProcessFileHitViewModel.hitType);
                _bankReconProcessFileViewModel.hits.push(_bankReconProcessFileHitViewModel);
            })

            if (hitTypes.length == 0) {
                _bankReconProcessFileViewModel.hitType = 0;
            }
            else if (Enumerable.From(hitTypes).Where(function (hit: number) { return hit == 1 }).Count() == hitTypes.length) {
                _bankReconProcessFileViewModel.hitType = 1;
            } else {
                _bankReconProcessFileViewModel.hitType = 2;
            }

            var dataFromProcessedFile = Enumerable.From(self.processedFile).Where(function (bankReconProcessFile) {
                return bankReconProcessFile.idHitType == _bankReconProcessFileViewModel.hitType
            }).FirstOrDefault(null);

            if (dataFromProcessedFile == null) {
                dataFromProcessedFile = {
                    type: self.getHitTypeName(_bankReconProcessFileViewModel.hitType),
                    idHitType: _bankReconProcessFileViewModel.hitType,
                    data: [_bankReconProcessFileViewModel]
                };
                self.processedFile.push(dataFromProcessedFile);
            } else {
                dataFromProcessedFile.data.push(_bankReconProcessFileViewModel);
            }
        });
    }

    public getHitTypeName(hitType: number) {
        switch (hitType) {
            case 0:
                return "No Match";
            case 1:
                return "Exact Match";
            case 2:
                return "Multiple Probable Matches"
        }
    }

    public addNewTransaction(idHitType: number, idBankStatementStagingDetail: number, transaction: transactionModel = null) {
        var self = this;
        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CONTROLLER, "CONTROLLER", self)
        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CURRENT_LINE_ID,
            "BANK_RECONCILIATION_CURRENT_LINE_ID", { idBankStatementStagingDetail: idBankStatementStagingDetail, idHitType: idHitType });

        var bankReconProcessFile: bankReconProcessFileViewModel = self.getBankStagingDetailFromProcessedFile(idHitType, idBankStatementStagingDetail);

        var _transaction: transactionModel

        if (transaction == null) {

            _transaction = new transactionModel();
            _transaction.payment = new paymentModel();
            _transaction.payment.paymentDetails = [];
            var _paymentDetail: paymentDetailModel = new paymentDetailModel();
            if (!self.baseController.isNullOrUndefined(self.selectedBank.paymentMethod)) {
                _paymentDetail.idPaymentMethod = self.selectedBank.paymentMethod.idPaymentMethod;
            }
            _paymentDetail.paymentMethod = self.selectedBank.paymentMethod;
            _transaction.payment.paymentDetails.push(_paymentDetail);
            _transaction.transactionDate = bankReconProcessFile.valueDate;
            _transaction.idTransactionTemplate = self.selectedBank.transactionTemplate.idTransactionTemplate;
            _transaction.transactionTemplate = self.selectedBank.transactionTemplate;
            _transaction.transactionDetails = [];
            if (!self.baseController.isNullOrUndefined(self.selectedBank.transactionAccount)) {
                _transaction.idTransactionAccount = self.selectedBank.transactionAccount.idTransactionAccount;
            }            
            _transaction.transactionAccount = self.selectedBank.transactionAccount;
        } else {
            _transaction = transaction;
        }

        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.TRANSACTION_INITIALIZER,
            "TRANSACTION_INITIALIZER", _transaction);

        self.baseController.showCustomModal('',
            
            //self.baseController.globalVariableFactory.baseServerUrl + '/Transaction/TransactionSale/TransactionSaleDetail/-1/1/1',
            self.baseController.globalVariableFactory.baseServerUrl + '/Transaction/Transaction/TransactionSale/-1/-1/1/1',
            self,
            {
                $scope: self.scope,
                transactionSaleWebService: self.transactionSaleWebService,
            },
            self.onAddNewTransactionOk,
            () => { },
            'lg', '', 'bank-recon-modal', true);
    }

    public onAddNewTransactionOk(sessionVariables: sessionVariables) {
        var self: bankReconciliationController = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CONTROLLER, "CONTROLLER");
        var transactionEntity: transactionEntityModel = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.TRANSFER, "TRANSACTION");
        var dataTransffered = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CURRENT_LINE_ID, "BANK_RECONCILIATION_CURRENT_LINE_ID");

        transactionEntity.transaction.totalAmount = Enumerable.From(transactionEntity.transaction.transactionDetails).Sum(function (transactionDetail: transactionDetailModel) {
            return (self.baseController.isNullOrUndefined(transactionDetail.rate) ? 0 : transactionDetail.rate) * (self.baseController.isNullOrUndefined(transactionDetail.quantity) ? 0 : transactionDetail.quantity)
        })

        var idBankStatementStagingDetail: number = dataTransffered.idBankStatementStagingDetail;
        var idHitType: number = dataTransffered.idHitType;

        var bankReconProcessFileData = Enumerable.From(self.processedFile).Where(function (bankReconProcessFile) {
            return bankReconProcessFile.idHitType == idHitType
        }).FirstOrDefault(null);

        var bankReconProcessFile: bankReconProcessFileViewModel = self.getBankStagingDetailFromProcessedFile(idHitType, idBankStatementStagingDetail);

        bankReconProcessFile.transactions.push(transactionEntity);
        self.isProcessedFileLineItemValid(bankReconProcessFile);
    }

    public removeTransaction(idHitType: number, idBankStatementStagingDetail: number, idLocalTransaction: string) {
        var self = this;

        var bankReconProcessFile: bankReconProcessFileViewModel = self.getBankStagingDetailFromProcessedFile(idHitType, idBankStatementStagingDetail);

        var position: number = self.baseController.searchForEntityInList("idTransaction", bankReconProcessFile.transactions, transactionModel, "idLocalTransaction");
        bankReconProcessFile.transactions.splice(position, 1);
    }

    public getBankStagingDetailFromProcessedFile(idHitType: number, idBankStatementStagingDetail: number): bankReconProcessFileViewModel {
        var self = this;

        var bankReconProcessFileData = Enumerable.From(self.processedFile).Where(function (bankReconProcessFile) {
            return bankReconProcessFile.idHitType == idHitType
        }).FirstOrDefault(null);

        var bankReconProcessFile: bankReconProcessFileViewModel = Enumerable.From(bankReconProcessFileData.data).Where(function (bankReconProcessFile: bankReconProcessFileViewModel) {
            return bankReconProcessFile.idBankStatementStagingDetail == idBankStatementStagingDetail
        }).FirstOrDefault(null);

        return bankReconProcessFile;
    }

    public saveBankRecon() {
        var self = this;
        self.hasSavedBeenRequested = true;
        if (!self.validateForSave()) {
            self.baseController.showToast(TOASTER_TYPE.ERROR, 'Please correct validation errors');
            return;
        }

        self.baseController.showLoading();
        var _saveBankReconciliationFileDto: saveBankReconciliationFileDto = self.formatProcessedFileForSave();
        self.bankReconciliationWebService.saveBankReconciliationFile(_saveBankReconciliationFileDto)
            .then(function (response: baseResultReturnType<saveBankReconciliationFileReturnType>) {
                self.baseController.hideLoading();
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.baseController.showMessage("Save Successfully", "", ALERT_MESSAGE_TYPE.SUCCESS);
                    self.screenState = bankReconciliationScreenState.ANALYSING_FILE;
                    self.loadBatches();
                    self.hasSavedBeenRequested = false;
                } else {
                    self.baseController.showMessage(response.errorMessage, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.hideLoading();
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });

    }

    public validateForSave(): boolean {
        var self = this;
        var invalidIds = [];
        Enumerable.From(self.processedFile).ForEach(function (processedFile: bankReconProcessedMainFile) {
            Enumerable.From(processedFile.data).ForEach(function (processedFileData: bankReconProcessFileViewModel) {
                if (!processedFileData.isValid) {
                    invalidIds.push(processedFileData.idBankStatementStagingDetail)
                }
            });
        });

        if (invalidIds.length > 0) {
            //document.getElementById(invalidIds[0]).scrollIntoView();
            self.baseController.$location.hash("#" + invalidIds[0]);
            self.baseController.$anchorScroll();
            return false;
        }

        return true;
    }

    public isProcessedFileLineItemValid(processedFileData: bankReconProcessFileViewModel) {
        var self = this;
        processedFileData.validationErrors = [];
        var total = 0;
        total += Enumerable.From(processedFileData.transactions).Sum(function (transactionEntity: transactionEntityModel) {
            return transactionEntity.transaction.totalAmount;
        });

        Enumerable.From(processedFileData.hits).Where(function (bankReconProcessFileHit: bankReconProcessFileHitViewModel) {
            return bankReconProcessFileHit.isSelected
        })
            .ForEach(function (bankReconProcessFileHit: bankReconProcessFileHitViewModel) {
                total += Enumerable.From(bankReconProcessFileHit.hitDetails).Sum(function (hitDetail: bankReconProcessFileHitTransactionPresetViewModel) {
                    return hitDetail.totalAmount
                });
            });

        processedFileData.currentTotal = total;

        if (processedFileData.currentTotal != processedFileData.creditAmount) {
            processedFileData.isValid = false;
            processedFileData.validationErrors.push("Total not matching");
        } else {
            processedFileData.isValid = true;
        }
        return processedFileData.isValid;
    }

    public formatProcessedFileForSave(): saveBankReconciliationFileDto {
        var self = this;

        var _saveBankReconciliationFileDto: saveBankReconciliationFileDto = new saveBankReconciliationFileDto();
        _saveBankReconciliationFileDto.idBankStatementStaging = self.idBankStatementStaging;
        _saveBankReconciliationFileDto.idBatch = self.selectedBatch.idBankStatementStagingDetailBatch;

        _saveBankReconciliationFileDto.bankStatements = [];
        Enumerable.From(self.processedFile).ForEach(function (processedFile: bankReconProcessedMainFile) {
            Enumerable.From(processedFile.data).ForEach(function (processedFileData: bankReconProcessFileViewModel) {
                var _saveBankReconciliationFileBankStatementDto: saveBankReconciliationFileBankStatementDto = new saveBankReconciliationFileBankStatementDto();
                _saveBankReconciliationFileBankStatementDto.idBankStatementStagingDetail = processedFileData.idBankStatementStagingDetail;
                _saveBankReconciliationFileBankStatementDto.transactions = [];

                Enumerable.From(processedFileData.hits).ForEach(function (bankReconProcessFileHit: bankReconProcessFileHitViewModel) {
                    if (bankReconProcessFileHit.isSelected) {
                        Enumerable.From(bankReconProcessFileHit.hitDetails).ForEach(function (hitDetail: bankReconProcessFileHitTransactionPresetViewModel) {
                            var _transaction: saveBankReconciliationFileBankStatementTransactionDto = new saveBankReconciliationFileBankStatementTransactionDto();
                            _transaction.idCustomer = hitDetail.idCustomer;
                            _transaction.idTransactionAccount = hitDetail.idTransactionAccount;
                            _transaction.idTransactionClass = hitDetail.idTransactionClass;
                            _transaction.idTransactionTemplate = hitDetail.idTransactionTemplate;
                            _transaction.transactionDate = processedFileData.valueDate;
                            _transaction.totalAmount = hitDetail.totalAmount;
                            _transaction.payment = new paymentModel();
                            _transaction.payment.paymentDetails = [];
                            _transaction.idBankStatementHitList = bankReconProcessFileHit.idBankStatementHitList;
                            _transaction.idBankStatementStagingHit = bankReconProcessFileHit.idBankStatementStagingHit;

                            var _paymentDetail: paymentDetailModel = new paymentDetailModel();
                            _paymentDetail.idPaymentMethod = self.selectedBank.idBankTransferPaymentMethod;
                            _transaction.payment.paymentDetails.push(_paymentDetail);

                            _transaction.capturedDate = new Date();
                            _transaction.transactionDate = processedFileData.valueDate;
                            _transaction.transactionDetails = [];
                            Enumerable.From(hitDetail.details).ForEach(function (transactionPreset: bankReconProcessFileHitTransactionPresetDetailViewModel) {
                                var _transactionDetail: transactionDetailModel = new transactionDetailModel();
                                _transactionDetail.description = transactionPreset.description;
                                _transactionDetail.idProduct = transactionPreset.idProduct;
                                _transactionDetail.idTransactionClass = transactionPreset.idTransactionClass;
                                _transactionDetail.quantity = transactionPreset.quantity;
                                _transactionDetail.rate = transactionPreset.rate;
                                _transaction.transactionDetails.push(_transactionDetail);
                            })
                            _saveBankReconciliationFileBankStatementDto.transactions.push(_transaction);
                        })
                    }
                })

                Enumerable.From(processedFileData.transactions).ForEach(function (transactionEntity: transactionEntityModel) {
                    var _transaction: saveBankReconciliationFileBankStatementTransactionDto = new saveBankReconciliationFileBankStatementTransactionDto();
                    _transaction.idCustomer = transactionEntity.transaction.idCustomer;
                    _transaction.idTransactionAccount = transactionEntity.transaction.idTransactionAccount;
                    _transaction.idTransactionClass = transactionEntity.transaction.idTransactionClass;
                    _transaction.idTransactionTemplate = transactionEntity.transaction.idTransactionTemplate;
                    _transaction.transactionDate = transactionEntity.transaction.transactionDate;
                    _transaction.totalAmount = transactionEntity.transaction.totalAmount;

                    _transaction.payment = new paymentModel();
                    _transaction.payment.paymentDetails = [];

                    Enumerable.From(transactionEntity.paymentDetails).ForEach(function (paymentDetail: paymentDetailModel) {
                        var _paymentDetail: paymentDetailModel = new paymentDetailModel();
                        _paymentDetail.chequeNo = paymentDetail.chequeNo;
                        _paymentDetail.idPaymentMethod = paymentDetail.idPaymentMethod;
                        _transaction.payment.paymentDetails.push(_paymentDetail);
                    })

                    _transaction.transactionDetails = [];
                    Enumerable.From(transactionEntity.transaction.transactionDetails).ForEach(function (transactionDetail: transactionDetailModel) {
                        var _transactionDetail: transactionDetailModel = new transactionDetailModel();
                        _transactionDetail.description = transactionDetail.description;
                        _transactionDetail.idProduct = transactionDetail.idProduct;
                        _transactionDetail.idTransactionClass = transactionDetail.idTransactionClass;
                        _transactionDetail.quantity = transactionDetail.quantity;
                        _transactionDetail.rate = transactionDetail.rate;
                        _transaction.transactionDetails.push(_transactionDetail);
                    })
                    _saveBankReconciliationFileBankStatementDto.transactions.push(_transaction);
                });
                _saveBankReconciliationFileDto.bankStatements.push(_saveBankReconciliationFileBankStatementDto);
            });

        });


        console.log(_saveBankReconciliationFileDto);
        return _saveBankReconciliationFileDto;
    }
    /**
     Added by Bilaal 11/02/21
     **/

    public printBatch(batch: bankStatementStagingDetailBatchModel) {
        var self = this;

        if (batch.idBankStatementStagingState == bankStatementStagingStateEnum.AWAITING_PROCESS) {
            self.baseController.showToast(TOASTER_TYPE.ERROR, 'Batch not yet processed');
            return;
        }

        self.selectedBatch = batch;
        var _analyseBankReconciliationFileForBatchDto: analyseBankReconciliationFileForBatchDto = new analyseBankReconciliationFileForBatchDto();
        _analyseBankReconciliationFileForBatchDto.idBatch = batch.idBankStatementStagingDetailBatch;

        self.baseController.showLoading();
        self.bankReconciliationWebService.printTransactionReceiptsForBatch(_analyseBankReconciliationFileForBatchDto)
            .then(function (response: any) {
                self.baseController.hideLoading();
                new downloadResponseService().manageReponse(response);
            })
            .catch(function (error: string) {
                self.baseController.hideLoading();
                bankReconciliationScreenState.TO_LOAD_RAW_FILE;
                self.baseController.showMessage(error, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            })
    }

    public copyTransaction(hit: bankReconProcessFileHitTransactionPresetViewModel, idHitType: number, processedFileData: bankReconProcessFileViewModel) {
        var self = this;
        var _transaction = new transactionModel();
        _transaction.idLocalTransaction = self.baseController.generateUUID();
        _transaction.payment = new paymentModel();
        _transaction.payment.paymentDetails = [];
        var _paymentDetail = new paymentDetailModel();
        _paymentDetail.idPaymentMethod = self.selectedBank.paymentMethod.idPaymentMethod;
        _paymentDetail.paymentMethod = self.selectedBank.paymentMethod;
        _transaction.payment.paymentDetails.push(_paymentDetail);
        _transaction.transactionDate = processedFileData.valueDate;
        _transaction.idTransactionTemplate = self.selectedBank.transactionTemplate.idTransactionTemplate;
        _transaction.transactionTemplate = self.selectedBank.transactionTemplate;
        _transaction.transactionDetails = [];
        Enumerable.From(hit.details).ForEach(function (transactionProduct) {
            var transactionDetail = new transactionDetailModel();
            transactionDetail.description = transactionProduct.description;
            transactionDetail.idLocalTransactionDetail = self.baseController.generateUUID();
            transactionDetail.idProduct = transactionProduct.idProduct;
            transactionDetail.idTransactionClass = transactionProduct.idTransactionClass;
            transactionDetail.product = transactionProduct.productObject;
            transactionDetail.quantity = transactionProduct.quantity;
            transactionDetail.rate = transactionProduct.rate;
            transactionDetail.transactionClass = transactionProduct.transactionClassObject;
            _transaction.transactionDetails.push(transactionDetail);
        });
        _transaction.idTransactionAccount = self.selectedBank.transactionAccount.idTransactionAccount;
        _transaction.transactionAccount = self.selectedBank.transactionAccount;
        _transaction.customer = hit.customerObject;
        _transaction.idCustomer = hit.idCustomer;
        self.addNewTransaction(idHitType, processedFileData.idBankStatementStagingDetail, _transaction);
    };

    public removeTransactionFromFile(processedFile: bankReconProcessedMainFile, idBankStatementStagingDetail: number) {
        var self = this;
        var _deleteBankReconciliationStagingDetailDto = new deleteBankReconciliationStagingDetailDto();
        _deleteBankReconciliationStagingDetailDto.idBankStatementStagingDetail = idBankStatementStagingDetail;
        self.bankReconciliationWebService.deleteBankReconciliationStagingDetail(_deleteBankReconciliationStagingDetailDto)
            .then(function (response) {
                self.baseController.hideLoading();
                if (response.status == STATUS_MESSAGE.SUCCESS) {
                    self.baseController.showMessage("Item removed", "", ALERT_MESSAGE_TYPE.SUCCESS);
                    self.removeBankStatementStagingDetailFromProcessedFile(processedFile, idBankStatementStagingDetail);
                }
                else {
                    self.baseController.showMessage(response.errorMessage, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
                }
            }).catch(function (errorMsg) {
                self.baseController.hideLoading();
                self.baseController.showMessage(errorMsg, "An Error Has Occured On Server, Please Contact Server Admin", ALERT_MESSAGE_TYPE.ERROR);
            }).finally(function () {
            });
    };

    public removeBankStatementStagingDetailFromProcessedFile(processedFile: bankReconProcessedMainFile, idBankStatementStagingDetail: number) {
        var self = this;
        var position = self.baseController.searchForEntityInList("idBankStatementStagingDetail", processedFile.data, { "idBankStatementStagingDetail": idBankStatementStagingDetail });
        processedFile.data.splice(position, 1);
    };

    public emailBatch(batch: bankStatementStagingDetailBatchModel) {
        var self = this;
        if (batch.idBankStatementStagingState == bankStatementStagingStateEnum.AWAITING_PROCESS) {
            self.baseController.showToast(TOASTER_TYPE.ERROR, 'Batch not yet processed');
            return;
        }

        self.selectedBatch = batch;

        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.EMAIL_BATCH_DETAIL_BATCH,
            "EMAIL_BATCH_DETAIL_BATCH", self.selectedBatch);

        self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CONTROLLER, "CONTROLLER", self)

        self.baseController.showCustomModal('',
            self.baseController.globalVariableFactory.baseServerUrl + 'Transaction/TransactionSale/EmailForTransaction/' + self.selectedBatch.idBankStatementStagingDetailBatch + '/1/1',
            self,
            {
                $scope: self.scope,
                transactionSaleWebService: self.transactionSaleWebService
            },
            self.onEmailBatchOk,
            () => { },
            'lg', '', '', true);
    }

    public onEmailBatchOk(sessionVariables: sessionVariables) {
        var self: bankReconciliationController = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CONTROLLER, "CONTROLLER");
        var data: transactionModel = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.TRANSFER, "EMAIL_BATCH_DETAIL_BATCH_DATA");
    }

    //public reconcileBankOrder() {
    //    var self = this;
    //    if (self.bankStatementStaging.idBankReconOrderProcessState == bankReconOrderProcessStateEnum.PROCESSED) {
    //        self.baseController.showToast(TOASTER_TYPE.WARNING, "Orders have already been processed");
    //        return;
    //    }
    //    self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CONTROLLER, "CONTROLLER", self)
    //    self.baseController.globalVariableFactory.sessionVariables.putVariableInSessionSpace(sessionVariableSpaceEnum.TRANSFER, "IDBANKSTATEMENTSTAGING", self.idBankStatementStaging)

    //    self.baseController.showCustomModal(reconcileBankOrderPopupController,
    //        self.baseController.globalVariableFactory.baseServerUrl + '/BankReconciliation/BankReconciliation/ReconcileBankOrderPopup/-1/-1/1',
    //        self,
    //        {
    //            $scope: self.scope,
    //            bankReconciliationWebService: self.bankReconciliationWebService,
    //        },
    //        self.onReconcileBankOrderOk,
    //        () => { },
    //        'lg', '', '', true);
    //}

    //public onReconcileBankOrderOk(sessionVariables: sessionVariables) {
    //    var self: bankReconciliationController = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.BANK_RECONCILIATION_CONTROLLER, "CONTROLLER");
    //    var _reconcileBankOrderViewModel: reconcileBankOrderViewModel = sessionVariables.getVariableFromSessionSpace(sessionVariableSpaceEnum.TRANSFER, "RECONCILEBANKORDER");
    //    self.bankStatementStaging.idBankReconOrderProcessState = bankReconOrderProcessStateEnum.PROCESSED;
    //}
}

class bankReconProcessedMainFile {
    type: string;
    idHitType: number;
    data: bankReconProcessFileViewModel[]
}

class bankReconProcessFileViewModel {
    idBankStatementStagingDetail: number;
    valueDate: Date;
    branchCode: string;
    remarks: string;
    debitAmount: number;
    creditAmount: number;
    hits: bankReconProcessFileHitViewModel[];
    transactions: transactionEntityModel[];
    hitType: number;
    isValid: boolean;
    validationErrors: string[];
    currentTotal: number;
}

class bankReconProcessFileHitViewModel {
    hitCount: number;
    hitType: number;
    idBankStatementHitList: number;
    idBankStatementStagingHit: number;
    isSelected: boolean;
    hitDetails: bankReconProcessFileHitTransactionPresetViewModel[];
}

class bankReconProcessFileHitTransactionPresetViewModel {
    customer: string;
    customerObject: customerModel;
    idCustomer: number;
    idTransactionAccount: number;
    idTransactionClass: number;
    idTransactionPreset: number;
    idTransactionTemplate: number;
    totalAmount: number;
    details: bankReconProcessFileHitTransactionPresetDetailViewModel[];
}

class bankReconProcessFileHitTransactionPresetDetailViewModel {
    description: string;
    product: string;
    productObject: productModel;
    idProduct: number;
    idTransactionClass: number;
    transactionClassObject: transactionClassModel;
    idTransactionDetailPreset: number;
    quantity: number;
    rate: number;
}



bankReconciliationModule.controller("bankReconciliationController"
    , ["$scope"
        , "bankReconciliationWebService"
        , "transactionSaleWebService"
        , bankReconciliationController
    ]);

enum bankReconciliationScreenState {
    TO_LOAD_RAW_FILE = 1,
    UPLOADING_RAW_FILE = 2,
    RAW_FILE_UPLOADED = 3,
    PARSING_RAW_FILE = 4,
    RAW_FILE_PARSED = 5,
    ANALYSING_FILE = 6,
    BATCH_LOADED = 7,
    FILE_ANALYSED = 8,
}


var analysedfile: any = '[{"type":"Exact match","idHitType":1,"data":[{"valueDate":"2020-07-01T00:00:00","branchCode":"INTERNET BANKING","remarks":"Testing 1 customer 1 line","debitAmount":0,"creditAmount":1000,"idBankStatementStagingDetail":6470,"hitType":1,"hits":[{"hitCount":5,"hitType":1,"idBankStatementStagingHit":1,"hitDetails":[{"customer":"testing multiple line","idCustomer":1,"idTransactionAccount":1,"idTransactionClass":1,"idTransactionPreset":1,"idTransactionTemplate":1,"totalAmount":100,"details":[{"description":"Product 1","product":"Product 1","idProduct":1,"idTransactionClass":1,"idTransactionDetailPreset":1,"quantity":1,"rate":200}]}]}],"transactions":[]},{"valueDate":"2020-07-01T00:00:00","branchCode":"INTERNET BANKING","remarks":"Testing 1 customer 2 lines","debitAmount":0,"creditAmount":1000,"idBankStatementStagingDetail":6472,"hitType":1,"hits":[{"hitCount":5,"hitType":1,"idBankStatementStagingHit":1,"hitDetails":[{"customer":"1 customer","idCustomer":1,"idTransactionAccount":1,"idTransactionClass":1,"idTransactionPreset":1,"idTransactionTemplate":1,"totalAmount":100,"details":[{"description":"Product 1","product":"Product 1","idProduct":1,"idTransactionClass":1,"idTransactionDetailPreset":1,"quantity":1,"rate":200}]}]},{"hitCount":5,"hitType":1,"idBankStatementStagingHit":1,"hitDetails":[{"customer":"2 cuctomer","idCustomer":1,"idTransactionAccount":1,"idTransactionClass":1,"idTransactionPreset":1,"idTransactionTemplate":1,"totalAmount":100,"details":[{"description":"Product 2","product":"Product 2","idProduct":1,"idTransactionClass":1,"idTransactionDetailPreset":1,"quantity":1,"rate":200}]}]}],"transactions":[]},{"valueDate":"2020-07-01T00:00:00","branchCode":"INTERNET BANKING","remarks":"Testing 2 customers with a single select","debitAmount":0,"creditAmount":1000,"idBankStatementStagingDetail":6471,"hitType":1,"hits":[{"hitCount":5,"hitType":1,"idBankStatementStagingHit":1,"hitDetails":[{"customer":"testing multiple line","idCustomer":1,"idTransactionAccount":1,"idTransactionClass":1,"idTransactionPreset":1,"idTransactionTemplate":1,"totalAmount":100,"details":[{"description":"Product 1","product":"Product 1","idProduct":1,"idTransactionClass":1,"idTransactionDetailPreset":1,"quantity":1,"rate":200}]},{"customer":"testing multiple line","idCustomer":1,"idTransactionAccount":1,"idTransactionClass":1,"idTransactionPreset":1,"idTransactionTemplate":1,"totalAmount":100,"details":[{"description":"Product 1","product":"Product 1","idProduct":1,"idTransactionClass":1,"idTransactionDetailPreset":1,"quantity":1,"rate":200}]}]}],"transactions":[]},{"valueDate":"2020-07-01T00:00:00","branchCode":"INTERNET BANKING","remarks":"Np hits transaction","debitAmount":0,"creditAmount":1000,"idBankStatementStagingDetail":6474,"hitType":1,"hits":[],"transactions":[]}]}]';



