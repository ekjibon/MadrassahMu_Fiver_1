using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Dto.BankReconciliation;
using Subscription.Business.Enums;
using Subscription.Business.Report.Transaction;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.BankReconciliation;
using Subscription.Business.Utils;
using Subscription.Data;
using Subscription.Service.MEFLoader;

namespace Subscription.Service
{
    public partial class BankReconciliationService : BaseService
    {

        public BusinessResponse<BaseListReturnType<BankReconciliationListReturnType>> LoadList(BankReconciliationSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<BankReconciliationListReturnType>> response = new BusinessResponse<BaseListReturnType<BankReconciliationListReturnType>>();

            try
            {
                response.Result = LoadListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }
        internal BaseListReturnType<BankReconciliationListReturnType> LoadListRaw(BankReconciliationSortingPagingInfo sortingPagingInfo)
        {
            BaseListReturnType<BankReconciliationListReturnType> returnList = new BaseListReturnType<BankReconciliationListReturnType>();
            List<string> includes = new List<string>() { BankStatementStagingDatabaseReferences.BANKSTATEMENTSTAGINGDETAILS };
            BaseListReturnType<BankStatementStaging> dbBankStatements = ServiceFactory.Instance.BankStatementStagingService.GetAllBankStatementStagingsByPageRaw(sortingPagingInfo, null, includes);

            List<BankReconciliationListReturnType> list = new List<BankReconciliationListReturnType>();
            dbBankStatements.EntityList.ForEach(bs =>
            {
                BankReconciliationListReturnType bankReconciliationListReturnType = new BankReconciliationListReturnType();
                bankReconciliationListReturnType.Account = bs.Account;
                bankReconciliationListReturnType.BankStatementDateFrom = bs.BankStatementDateFrom;
                bankReconciliationListReturnType.BankStatementDateTo = bs.BankStatementDateTo;
                bankReconciliationListReturnType.IdBankStatementStaging = bs.IdBankStatementStaging;
                bankReconciliationListReturnType.UploadDate = bs.UploadDate;
                bankReconciliationListReturnType.TotalTransaction = bs.BankStatementStagingDetails.Count();
                list.Add(bankReconciliationListReturnType);
            });

            returnList.TotalCount = dbBankStatements.TotalCount;
            returnList.EntityList = list;
            return returnList;
        }


        public BusinessResponse<BankReconciliationScreenConstantReturnType> GetBankReconciliationScreenConstant()
        {
            BusinessResponse<BankReconciliationScreenConstantReturnType> response = new BusinessResponse<BankReconciliationScreenConstantReturnType>();

            try
            {
                response.Result = GetBankReconciliationScreenConstantRaw();
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BankReconciliationScreenConstantReturnType GetBankReconciliationScreenConstantRaw()
        {
            BankReconciliationScreenConstantReturnType bankReconciliationScreenConstantReturnType = new BankReconciliationScreenConstantReturnType();
            bankReconciliationScreenConstantReturnType.Banks = new List<Bank>();

            List<Bank> dbBanks = daoFactory.BankDao.GetBankCustomList(b => b.IdBank != null, new List<string>()
            {
                BankDatabaseReferences.PAYMENTMETHOD,
                BankDatabaseReferences.TRANSACTIONACCOUNT,
                BankDatabaseReferences.TRANSACTIONTEMPLATE
            }).EntityList;

            dbBanks.ForEach(b =>
            {
                Bank bank = Mapper.MapBankSingle(b, true);
                if (b.TransactionTemplate != null)
                {
                    bank.TransactionTemplate = Mapper.MapTransactionTemplateSingle(b.TransactionTemplate, true);
                }

                if (b.TransactionAccount != null)
                {
                    bank.TransactionAccount = Mapper.MapTransactionAccountSingle(b.TransactionAccount, true);
                }

                if (b.PaymentMethod != null)
                {
                    bank.PaymentMethod = Mapper.MapPaymentMethodSingle(b.PaymentMethod, true);
                }

                bankReconciliationScreenConstantReturnType.Banks.Add(bank);
            });

            return bankReconciliationScreenConstantReturnType;

        }


        public BusinessResponse<LoadBankReconciliationContentReturnType> LoadBankReconciliationContent(LoadBankReconciliationContentDto loadBankReconciliationContentDto)
        {
            BusinessResponse<LoadBankReconciliationContentReturnType> response = new BusinessResponse<LoadBankReconciliationContentReturnType>();

            try
            {
                response.Result = LoadBankReconciliationContentRaw(loadBankReconciliationContentDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal LoadBankReconciliationContentReturnType LoadBankReconciliationContentRaw(LoadBankReconciliationContentDto loadBankReconciliationContentDto)
        {
            LoadBankReconciliationContentReturnType loadBankReconciliationContentReturnType = new LoadBankReconciliationContentReturnType();
            loadBankReconciliationContentReturnType.WarningMessages = new List<string>();
            BankStatementReaderInitializer<Object> reportInitializer = new BankStatementReaderInitializer<Object>();

            Document sameDocument = daoFactory.DocumentDao.GetDocumentCustom(d => d.FileName.Contains(loadBankReconciliationContentDto.Document.FileName));
            if (sameDocument != null)
            {
                loadBankReconciliationContentReturnType.WarningMessages.Add("Document of the same name has already been uploaded.");
            }

            var report = reportInitializer.reports.Where(r => r.Metadata.IdBank == loadBankReconciliationContentDto.IdBank.ToString()).FirstOrDefault();
            BankStatementStaging bankStatementStaging = report.Value.ProcessStatement(loadBankReconciliationContentDto.Document);

            loadBankReconciliationContentReturnType.BankStatementStaging = bankStatementStaging;

            return loadBankReconciliationContentReturnType;
        }

        public BusinessResponse<AnalyseBankReconciliationFileReturnType> PrintBankReconciliationFileForBatch(AnalyseBankReconciliationFileDto analyseBankReconciliationFileDto)
        {
            BusinessResponse<AnalyseBankReconciliationFileReturnType> response = new BusinessResponse<AnalyseBankReconciliationFileReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();
            try
            {
                unitOfWork.Begin();
                response.Result = AnalyseBankReconciliationFileRaw(analyseBankReconciliationFileDto, unitOfWork);
                unitOfWork.Commit();

            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal AnalyseBankReconciliationFileReturnType AnalyseBankReconciliationFileRaw(AnalyseBankReconciliationFileDto analyseBankReconciliationFileDto, UnitOfWork unitOfWork)
        {
            AnalyseBankReconciliationFileReturnType analyseBankReconciliationFileReturnType = new AnalyseBankReconciliationFileReturnType();

            LoadBankReconciliationContentReturnType loadBankReconciliationContentReturnType = LoadBankReconciliationContentRaw(new LoadBankReconciliationContentDto()
            {
                Document = analyseBankReconciliationFileDto.Document,
                IdBank = analyseBankReconciliationFileDto.IdBank
            });

            daoFactory.DocumentDao.SaveOnlyDocument(analyseBankReconciliationFileDto.Document, unitOfWork.Db);
            loadBankReconciliationContentReturnType.BankStatementStaging.IdDocument = analyseBankReconciliationFileDto.Document.IdDocument;
            loadBankReconciliationContentReturnType.BankStatementStaging.UploadDate = DateTime.Now;
            loadBankReconciliationContentReturnType.BankStatementStaging.IdUserUploadedBy = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdUser.Value;
            loadBankReconciliationContentReturnType.BankStatementStaging.IdBankStatementStagingState = (long)BankStatementStagingStateEnum.AWAITING_PROCESS;
            loadBankReconciliationContentReturnType.BankStatementStaging.IdBank = analyseBankReconciliationFileDto.IdBank;
            daoFactory.BankStatementStagingDao.SaveOnlyBankStatementStaging(loadBankReconciliationContentReturnType.BankStatementStaging, unitOfWork.Db);

            //load batches
            int batchSize = analyseBankReconciliationFileDto.BatchSize ?? 10;
            double pageCount = Math.Ceiling((double)loadBankReconciliationContentReturnType.BankStatementStaging.BankStatementStagingDetails.Count() / batchSize);
            List<BankStatementStagingDetailBatch> bankStatementStagingDetailBatches = new List<BankStatementStagingDetailBatch>();
            Enumerable.Range(1, (int)pageCount).ToList().ForEach(c =>
            {
                BankStatementStagingDetailBatch bankStatementStagingDetailBatch = new BankStatementStagingDetailBatch()
                {
                    IdBankStatementStagingState = (long)BankStatementStagingStateEnum.AWAITING_PROCESS,
                    BatchNumber = c
                };
                bankStatementStagingDetailBatches.Add(bankStatementStagingDetailBatch);
            });
            daoFactory.BankStatementStagingDetailBatchDao.SaveBankStatementStagingDetailBatchList(bankStatementStagingDetailBatches, unitOfWork.Db);

            int currentBankStatementStagingDetail = 1;
            loadBankReconciliationContentReturnType.BankStatementStaging.BankStatementStagingDetails.ToList().ForEach(b =>
            {
                int batchPositiom = (int)((Math.Ceiling((double)currentBankStatementStagingDetail / batchSize)) - 1);
                b.IdBankStatementStagingDetailBatch = bankStatementStagingDetailBatches.ElementAt(batchPositiom).IdBankStatementStagingDetailBatch;
                b.IdBankStatementStaging = loadBankReconciliationContentReturnType.BankStatementStaging.IdBankStatementStaging;
                currentBankStatementStagingDetail++;
            });

            daoFactory.BankStatementStagingDetailDao.SaveBankStatementStagingDetailList(loadBankReconciliationContentReturnType.BankStatementStaging.BankStatementStagingDetails.ToList(), unitOfWork.Db);

            List<BankStatementStagingState> bankStatementStagingStates = daoFactory.BankStatementStagingStateDao.GetAllBankStatementStagingStates(true);

            bankStatementStagingDetailBatches.ToList().ForEach(b =>
            {
                b.BankStatementStagingState = bankStatementStagingStates.Where(s => s.IdBankStatementStagingState == b.IdBankStatementStagingState).FirstOrDefault();
            });

            analyseBankReconciliationFileReturnType.BankStatementStagingDetailBatches = new List<BankStatementStagingDetailBatch>();
            bankStatementStagingDetailBatches.ForEach(b =>
            {
                BankStatementStagingDetailBatch bankStatementStagingDetailBatch = Mapper.MapBankStatementStagingDetailBatchSingle(b, true);
                if (b.BankStatementStagingState != null)
                {
                    bankStatementStagingDetailBatch.BankStatementStagingState = Mapper.MapBankStatementStagingStateSingle(b.BankStatementStagingState, true);
                }
                analyseBankReconciliationFileReturnType.BankStatementStagingDetailBatches.Add(bankStatementStagingDetailBatch);
            });

            analyseBankReconciliationFileReturnType.IdBankStatementStaging = loadBankReconciliationContentReturnType.BankStatementStaging.IdBankStatementStaging.Value;
            //here
            analyseBankReconciliationFileReturnType.BankStatementStaging = Mapper.MapBankStatementStagingSingle(loadBankReconciliationContentReturnType.BankStatementStaging, true);

            return analyseBankReconciliationFileReturnType;
        }


        public BusinessResponse<AnalyseBankReconciliationFileForBatchReturnType> AnalyseBankReconciliationFileForBatch(AnalyseBankReconciliationFileForBatchDto analyseBankReconciliationFileForBatchDto)
        {
            BusinessResponse<AnalyseBankReconciliationFileForBatchReturnType> response = new BusinessResponse<AnalyseBankReconciliationFileForBatchReturnType>();
            try
            {
                response.Result = AnalyseBankReconciliationFileForBatchRaw(analyseBankReconciliationFileForBatchDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal AnalyseBankReconciliationFileForBatchReturnType AnalyseBankReconciliationFileForBatchRaw(AnalyseBankReconciliationFileForBatchDto analyseBankReconciliationFileForBatchDto)
        {
            AnalyseBankReconciliationFileForBatchReturnType analyseBankReconciliationFileForBatchReturnType = new AnalyseBankReconciliationFileForBatchReturnType();
            analyseBankReconciliationFileForBatchReturnType.BankStatementStagingDetails = new List<BankStatementStagingDetail>();


            BankStatementStagingDetailBatch bankStatementStagingDetailBatch = daoFactory.BankStatementStagingDetailBatchDao.GetBankStatementStagingDetailBatch(analyseBankReconciliationFileForBatchDto.IdBatch);

            if (bankStatementStagingDetailBatch.IdBankStatementStagingState == (long)BankStatementStagingStateEnum.PROCESSING_DONE)
            {
                throw new Exception("Batch already processed");
            }

            List<BankStatementStagingHit> bankStatementStagingHits = daoFactory.BankReconciliationDao
                .ReconcialeBankStatement(analyseBankReconciliationFileForBatchDto.IdBankStatementStaging, analyseBankReconciliationFileForBatchDto.IdBatch);

            //List<long> bankStatementStagingHitIds = bankStatementStagingHits.Select(s => s.IdBankStatementStagingHit.Value).ToList();

            //List<BankStatementStagingHit_TransactionPreset> bankStatementStagingHitDetails = daoFactory.BankStatementStagingHit_TransactionPresetDao
            //     .GetBankStatementStagingHit_TransactionPresetCustomList(s => bankStatementStagingHitIds.Contains(s.IdBankStatementStagingHit.Value), new List<string>() {
            //       BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,
            //        string.Format("{0}.{1}",BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.CUSTOMER),
            //        string.Format("{0}.{1}",BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.TRANSACTIONDETAILPRESETS),
            //        string.Format("{0}.{1}.{2}",BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.TRANSACTIONDETAILPRESETS,TransactionDetailPresetDatabaseReferences.PRODUCT)
            //     }).EntityList;

            List<BankStatementStagingDetail> bankStatementStagingDetails = daoFactory.BankStatementStagingDetailDao
                .GetBankStatementStagingDetailCustomList(s => s.IdBankStatementStagingDetailBatch == analyseBankReconciliationFileForBatchDto.IdBatch,
                 new List<string>()
                 {
                     BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,
                    string.Format("{0}.{1}",BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,BankStatementStagingHitDatabaseReferences.BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET),
                    string.Format("{0}.{1}.{2}",BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,BankStatementStagingHitDatabaseReferences.BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET,BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET),
                    string.Format("{0}.{1}.{2}.{3}",BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,BankStatementStagingHitDatabaseReferences.BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET,BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.CUSTOMER),
                    string.Format("{0}.{1}.{2}.{3}",BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,BankStatementStagingHitDatabaseReferences.BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET,BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.TRANSACTIONDETAILPRESETS),
                    string.Format("{0}.{1}.{2}.{3}.{4}",BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,BankStatementStagingHitDatabaseReferences.BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET,BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.TRANSACTIONDETAILPRESETS,TransactionDetailPresetDatabaseReferences.PRODUCT),
                    string.Format("{0}.{1}.{2}.{3}.{4}",BankStatementStagingDetailDatabaseReferences.BANKSTATEMENTSTAGINGHITS,BankStatementStagingHitDatabaseReferences.BANKSTATEMENTSTAGINGHIT_TRANSACTIONPRESET,BankStatementStagingHit_TransactionPresetDatabaseReferences.TRANSACTIONPRESET,TransactionPresetDatabaseReferences.TRANSACTIONDETAILPRESETS,TransactionDetailDatabaseReferences.TRANSACTIONCLASS),
                 }).EntityList;

            bankStatementStagingDetails.Where(b => b.IsDeactivated != true).ToList().ForEach(bs =>
            {
                BankStatementStagingDetail bankStatementStagingDetail = Mapper.MapBankStatementStagingDetailSingle(bs, true);
                bankStatementStagingDetail.BankStatementStagingHits = new List<BankStatementStagingHit>();
                bs.BankStatementStagingHits.ToList().ForEach(h =>
                {
                    BankStatementStagingHit bankStatementStagingHit = Mapper.MapBankStatementStagingHitSingle(h, true);
                    bankStatementStagingHit.BankStatementStagingHit_TransactionPreset = new List<BankStatementStagingHit_TransactionPreset>();
                    h.BankStatementStagingHit_TransactionPreset.ToList().ForEach(hd =>
                    {
                        BankStatementStagingHit_TransactionPreset bankStatementStagingHitDetail = Mapper.MapBankStatementStagingHit_TransactionPresetSingle(hd, true);
                        bankStatementStagingHitDetail.TransactionPreset = Mapper.MapTransactionPresetSingle(hd.TransactionPreset, true);
                        bankStatementStagingHitDetail.TransactionPreset.Customer = Mapper.MapCustomerSingle(hd.TransactionPreset.Customer, true);
                        bankStatementStagingHitDetail.TransactionPreset.TransactionDetailPresets = new List<TransactionDetailPreset>();

                        hd.TransactionPreset.TransactionDetailPresets.ToList().ForEach(tdp =>
                        {
                            TransactionDetailPreset transactionDetailPreset = Mapper.MapTransactionDetailPresetSingle(tdp, true);
                            transactionDetailPreset.Product = Mapper.MapProductSingle(tdp.Product, true);
                            transactionDetailPreset.TransactionClass = Mapper.MapTransactionClassSingle(tdp.TransactionClass, true);
                            bankStatementStagingHitDetail.TransactionPreset.TransactionDetailPresets.Add(transactionDetailPreset);
                        });
                        bankStatementStagingHit.BankStatementStagingHit_TransactionPreset.Add(bankStatementStagingHitDetail);
                    });

                    bankStatementStagingDetail.BankStatementStagingHits.Add(bankStatementStagingHit);
                });

                analyseBankReconciliationFileForBatchReturnType.BankStatementStagingDetails.Add(bankStatementStagingDetail);
            });

            BankStatementStaging dbBankStatementStaging = daoFactory.BankStatementStagingDao.GetBankStatementStagingCustom(s => s.IdBankStatementStaging == analyseBankReconciliationFileForBatchDto.IdBankStatementStaging, new List<string>()
            {
                BankStatementStagingDatabaseReferences.BANK,
                string.Format("{0}.{1}", BankStatementStagingDatabaseReferences.BANK,BankDatabaseReferences.PAYMENTMETHOD),
                string.Format("{0}.{1}", BankStatementStagingDatabaseReferences.BANK,BankDatabaseReferences.TRANSACTIONACCOUNT),
                string.Format("{0}.{1}", BankStatementStagingDatabaseReferences.BANK,BankDatabaseReferences.TRANSACTIONTEMPLATE)
            });
            analyseBankReconciliationFileForBatchReturnType.Bank = Mapper.MapBankSingle(dbBankStatementStaging.Bank, true);
            if (dbBankStatementStaging.Bank.PaymentMethod != null)
                analyseBankReconciliationFileForBatchReturnType.Bank.PaymentMethod = Mapper.MapPaymentMethodSingle(dbBankStatementStaging.Bank.PaymentMethod, true);
            if (dbBankStatementStaging.Bank.TransactionTemplate != null)
                analyseBankReconciliationFileForBatchReturnType.Bank.TransactionTemplate = Mapper.MapTransactionTemplateSingle(dbBankStatementStaging.Bank.TransactionTemplate, true);
            if (dbBankStatementStaging.Bank.TransactionAccount != null)
                analyseBankReconciliationFileForBatchReturnType.Bank.TransactionAccount = Mapper.MapTransactionAccountSingle(dbBankStatementStaging.Bank.TransactionAccount, true);
            return analyseBankReconciliationFileForBatchReturnType;
        }



        public BusinessResponse<LoadBankStatementStagingDetailBatchReturnType> LoadBankStatementStagingDetailBatch(LoadBankStatementStagingDetailBatchDto loadBankStatementStagingDetailBatchDto)
        {
            BusinessResponse<LoadBankStatementStagingDetailBatchReturnType> response = new BusinessResponse<LoadBankStatementStagingDetailBatchReturnType>();
            try
            {
                response.Result = LoadBankStatementStagingDetailBatchRaw(loadBankStatementStagingDetailBatchDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal LoadBankStatementStagingDetailBatchReturnType LoadBankStatementStagingDetailBatchRaw(LoadBankStatementStagingDetailBatchDto loadBankStatementStagingDetailBatchDto)
        {
            LoadBankStatementStagingDetailBatchReturnType loadBankStatementStagingDetailBatchReturnType = new LoadBankStatementStagingDetailBatchReturnType();

            List<BankStatementStagingDetailBatch> bankStatementStagingDetailBatches = daoFactory.BankReconciliationDao.GetBatchesForBankStatmentStaging(loadBankStatementStagingDetailBatchDto.IdBankStatementStaging);

            loadBankStatementStagingDetailBatchReturnType.Batches = new BaseListReturnType<BankStatementStagingDetailBatch>();
            loadBankStatementStagingDetailBatchReturnType.Batches.EntityList = bankStatementStagingDetailBatches;
            loadBankStatementStagingDetailBatchReturnType.Batches.TotalCount = bankStatementStagingDetailBatches.Count;

            loadBankStatementStagingDetailBatchReturnType.BankStatementStaging = Mapper.MapBankStatementStagingSingle(daoFactory.BankStatementStagingDao.GetBankStatementStaging(loadBankStatementStagingDetailBatchDto.IdBankStatementStaging), true);

            return loadBankStatementStagingDetailBatchReturnType;
        }

        public BusinessResponse<SaveBankReconciliationFileReturnType> SaveBankReconciliationFile(SaveBankReconciliationFileDto saveBankReconciliationFileDto)
        {
            BusinessResponse<SaveBankReconciliationFileReturnType> response = new BusinessResponse<SaveBankReconciliationFileReturnType>();
            try
            {
                response.Result = SaveBankReconciliationFileRaw(saveBankReconciliationFileDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
                RevertSaveBankReconciliationFileRaw(saveBankReconciliationFileDto.IdBankStatementStaging);
            }

            return response;
        }

        internal void RevertSaveBankReconciliationFileRaw(long idBankStatementStaging)
        {
            daoFactory.TemporaryTransactionDao.DeleteTemporaryTransactionForBankStatement(idBankStatementStaging);
        }

        internal SaveBankReconciliationFileReturnType SaveBankReconciliationFileRaw(SaveBankReconciliationFileDto saveBankReconciliationFileDto)
        {
            BankStatementStagingDetailBatch bankStatementStagingDetailBatch = daoFactory.BankStatementStagingDetailBatchDao.GetBankStatementStagingDetailBatch(saveBankReconciliationFileDto.IdBatch);

            if (bankStatementStagingDetailBatch.IdBankStatementStagingState == (long)BankStatementStagingStateEnum.PROCESSING_DONE)
            {
                throw new Exception("Batch already processed");
            }


            SaveBankReconciliationFileReturnType saveBankReconciliationFileReturnType = new SaveBankReconciliationFileReturnType();
            DateTime nowDate = DateTime.Now;
            long? idUserAuthor = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdUser.Value;

            List<TemporaryTransaction> temporaryTransactions = new List<TemporaryTransaction>();
            saveBankReconciliationFileDto.BankStatements.ForEach(b =>
            {
                b.Transactions.ForEach(t =>
                {
                    TemporaryTransaction temporaryTransaction = new TemporaryTransaction()
                    {
                        CapturedDate = nowDate,
                        IdCustomer = t.IdCustomer,
                        IdTransactionAccount = t.IdTransactionAccount,
                        IdTransactionClass = t.IdTransactionClass,
                        IdTransactionTemplate = t.IdTransactionTemplate,
                        IdTransactionType = (long)TransactionTypeEnum.BANK_RECONCILIATION,
                        IdUserAuthor = idUserAuthor,
                        TotalAmount = t.TotalAmount,
                        Memo = t.Memo,
                        TransactionDate = t.TransactionDate,
                        TemporaryTransactionDetails = new List<TemporaryTransactionDetail>(),
                        IdBankStatementStagingDetail = b.IdBankStatementStagingDetail,
                        IdBankStatementStagingHit = t.IdBankStatementStagingHit,
                        IdBankStatementHitList = t.IdBankStatementHitList,
                    };

                    t.TransactionDetails.ToList().ForEach(td =>
                    {
                        TemporaryTransactionDetail temporaryTransactionDetail = new TemporaryTransactionDetail()
                        {
                            Description = td.Description,
                            IdProduct = td.IdProduct,
                            IdTransactionClass = td.IdTransactionClass,
                            Quantity = td.Quantity,
                            Rate = td.Rate
                        };
                        temporaryTransaction.TemporaryTransactionDetails.Add(temporaryTransactionDetail);
                    });

                    temporaryTransaction.TemporaryPayment = new TemporaryPayment()
                    {
                        TemporaryPaymentDetails = new List<TemporaryPaymentDetail>()
                    };

                    t.Payment.PaymentDetails.ToList().ForEach(pd =>
                    {
                        TemporaryPaymentDetail temporaryPaymentDetail = new TemporaryPaymentDetail()
                        {
                            IdPaymentMethod = pd.IdPaymentMethod
                        };
                        temporaryTransaction.TemporaryPayment.TemporaryPaymentDetails.Add(temporaryPaymentDetail);
                    });

                    temporaryTransactions.Add(temporaryTransaction);
                });
            });

            daoFactory.TemporaryTransactionDao.SaveBulkTemporaryTransaction(temporaryTransactions);
            bool isProcessSuccessful = daoFactory.TemporaryTransactionDao.ProcessTemporaryTransactionForBankStatement(saveBankReconciliationFileDto.IdBatch);

            if (!isProcessSuccessful)
            {
                throw new Exception("Could not save bulk transaction");
            }
            return saveBankReconciliationFileReturnType;
        }

        public BusinessResponse<PrintTransactionReceiptsForBatchReturnType> PrintTransactionReceiptsForBatch(AnalyseBankReconciliationFileForBatchDto analyseBankReconciliationFileForBatchDto)
        {
            BusinessResponse<PrintTransactionReceiptsForBatchReturnType> response = new BusinessResponse<PrintTransactionReceiptsForBatchReturnType>();
            try
            {
                response.Result = PrintTransactionReceiptsForBatchRaw(analyseBankReconciliationFileForBatchDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal PrintTransactionReceiptsForBatchReturnType PrintTransactionReceiptsForBatchRaw(AnalyseBankReconciliationFileForBatchDto analyseBankReconciliationFileForBatchDto)
        {
            PrintTransactionReceiptsForBatchReturnType printTransactionReceiptsForBatchReturnType = new PrintTransactionReceiptsForBatchReturnType();

            BankStatementStagingDetailBatch bankStatementStagingDetailBatch = daoFactory.BankStatementStagingDetailBatchDao.GetBankStatementStagingDetailBatch(analyseBankReconciliationFileForBatchDto.IdBatch);

            if (bankStatementStagingDetailBatch.IdBankStatementStagingState == (long)BankStatementStagingStateEnum.PROCESSING_DONE)
            {
                List<BankStatementStagingDetail> bankStatementStagingDetails = daoFactory.BankStatementStagingDetailDao
                .GetBankStatementStagingDetailCustomList(s => s.IdBankStatementStagingDetailBatch == analyseBankReconciliationFileForBatchDto.IdBatch,
                 new List<string>()
                 {
                     BankStatementStagingDetailDatabaseReferences.TRANSACTION_BANKSTATEMENTSTAGINGDETAIL

                 }).EntityList;

                List<long> idTransactions = new List<long>();

                bankStatementStagingDetails.ToList().ForEach(bankStatementStagingDetail =>
                {
                    idTransactions.AddRange(bankStatementStagingDetail.Transaction_BankStatementStagingDetail.Select(s => s.IdTransaction.Value).ToList());
                }
                );

                List<FileToZipInfo> reports = new List<FileToZipInfo>();

                List<GetTransactionSaleForPrintReturnType> getTransactionSaleForPrintReturnTypes = daoFactory.TransactionDao.GetTransactionSaleForPrint(idTransactions);

                idTransactions.ForEach(idTransaction =>
                {
                    GetTransactionSaleForPrintReturnType getTransactionSaleForPrintReturnType = getTransactionSaleForPrintReturnTypes.Where(t => t.IdTransaction == idTransaction).FirstOrDefault();
                    if (getTransactionSaleForPrintReturnType == null)
                    {
                        throw new Exception("Could not fetch detail for transaction");
                    }

                    BusinessResponse<BaseReportReturnType> reportGenerator = new ReportService().GenerateReport(new TransactionReceiptDto()
                    {
                        ReportCode = "5015d08d-8d55-4657-b06c-aed1a56274ce",
                        ReportFormat = "PDF",
                        IdTransaction = idTransaction,
                        GetTransactionSaleForPrintReturnType = getTransactionSaleForPrintReturnType,
                        ReportName = getTransactionSaleForPrintReturnType.ReceiptNo
                    });

                    if (reportGenerator.HasException())
                    {
                        throw new Exception("Could not generate receipt");
                    }

                    reports.Add(new FileToZipInfo()
                    {
                        FileExtension = reportGenerator.Result.FileExtension,
                        FileName = reportGenerator.Result.FileName,
                        FileNameWithExtension = reportGenerator.Result.FileNameWithExtension,
                        FilePath = reportGenerator.Result.FilePath,
                        ZipFileName = reportGenerator.Result.ReportName,
                    });
                });

                string combinedPdfOutputFileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), "pdf");
                string combinedPdfOutputFilePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("generatedFiles"), combinedPdfOutputFileName);

                ServiceFactory.Instance.PdfService.CombinePdfFileListRaw(new CombinePdfFileListDto()
                {
                    FilePaths = reports.Select(r => r.FilePath).ToList(),
                    OutputFilePath = combinedPdfOutputFilePath
                });

                string outputFilePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("generatedFiles"));

                reports.Add(new FileToZipInfo()
                {
                    FileExtension = "pdf",
                    FileName = "Combined Receipts",
                    FileNameWithExtension = "Combined Receipts.pdf",
                    FilePath = combinedPdfOutputFilePath,
                    ZipFileName = "Combined Receipts.pdf",
                });

                ZipFileReturnType zipFileReturnType = ServiceFactory.Instance.ZipFileService.ZipFilesRaw(new ZipFileDto()
                {
                    FilesToZip = reports,
                    OutputFilePath = outputFilePath
                });
                printTransactionReceiptsForBatchReturnType.BatchFilePath = zipFileReturnType.FullOutputPath;
                printTransactionReceiptsForBatchReturnType.FileNameWithExtension = string.Format("Batch Report.zip");
                return printTransactionReceiptsForBatchReturnType;
            }
            else
            {
                throw new Exception("Batch not yet processed");
            }
        }

        public BusinessResponse<bool> DeleteBankReconciliationStagingDetail(DeleteBankReconciliationStagingDetailDto deleteBankReconciliationStagingDetailDto)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            try
            {
                response.Result = DeleteBankReconciliationStagingDetailRaw(deleteBankReconciliationStagingDetailDto);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal bool DeleteBankReconciliationStagingDetailRaw(DeleteBankReconciliationStagingDetailDto deleteBankReconciliationStagingDetailDto)
        {
            daoFactory.BankStatementStagingDetailDao.DeleteBankStatementStagingDetail(new BankStatementStagingDetail() { IdBankStatementStagingDetail = deleteBankReconciliationStagingDetailDto.IdBankStatementStagingDetail });
            return true;
        }


        public BusinessResponse<ReconcileBankOrderReturnType> ReconcileBankOrder(ReconcileBankOrderDto reconcileBankOrderDto)
        {
            BusinessResponse<ReconcileBankOrderReturnType> response = new BusinessResponse<ReconcileBankOrderReturnType>();
            try
            {
                response.Result = ReconcileBankOrderRaw(reconcileBankOrderDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal ReconcileBankOrderReturnType ReconcileBankOrderRaw(ReconcileBankOrderDto reconcileBankOrderDto)
        {
            return daoFactory.BankReconciliationDao.ReconcileBankOrder(reconcileBankOrderDto.IdBankStatementStaging);
        }

        public BusinessResponse<bool> SaveReconcileBankOrder(SaveReconcileBankOrderDto saveReconcileBankOrderDto)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();
            try
            {
                response.Result = SaveReconcileBankOrderRaw(saveReconcileBankOrderDto);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal bool SaveReconcileBankOrderRaw(SaveReconcileBankOrderDto saveReconcileBankOrderDto)
        {
            return daoFactory.BankReconciliationDao.SaveReconcileBankOrder(saveReconcileBankOrderDto.IdBankStatementStagingDetails);
        }
    }
}