using CoreWeb.Business.Common;
using Newtonsoft.Json;
using System.IO;
using Subscription.Business;
using Subscription.Business.Report.Transaction;
using Subscription.Business.Common;
using Subscription.Business.Custom;
using Subscription.Business.Dto;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType;
using Subscription.Business.ReturnType.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.ExtensionMethod;

namespace Subscription.Service
{
    public partial class TransactionService : BaseService
    {

        public BusinessResponse<SaveScheduledTransactionReturnType> SaveScheduledTransaction(SaveScheduledTransactionDto saveScheduledTransactionDto)
        {
            BusinessResponse<SaveScheduledTransactionReturnType> response = new BusinessResponse<SaveScheduledTransactionReturnType>();

            try
            {
                response.Result = SaveScheduledTransactionRaw(saveScheduledTransactionDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal SaveScheduledTransactionReturnType SaveScheduledTransactionRaw(SaveScheduledTransactionDto saveScheduledTransactionDto)
        {
            SaveScheduledTransactionReturnType saveScheduledTransactionReturnType = new SaveScheduledTransactionReturnType();
            DateGenerator dateGenerator = new DateGenerator();
            List<DateTime> generatedDates = new List<DateTime>();
            saveScheduledTransactionReturnType.Transaction = new Transaction();
            saveScheduledTransactionReturnType.Transaction.TransactionDetails = new List<TransactionDetail>();
            saveScheduledTransactionReturnType.ScheduleSetting = new ScheduleSetting();
            saveScheduledTransactionReturnType.ScheduleSetting.Frequency = new Frequency();
            saveScheduledTransactionReturnType.TransactionDues = new List<TransactionDue>();

            daoFactory.TransactionDao.SaveOnlyTransaction(saveScheduledTransactionDto.Transaction);

            saveScheduledTransactionDto.Transaction.TransactionDetails.ToList().ForEach((td) =>
            {
                td.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                td.IdProduct = td.Product.IdProduct;
                td.Description = td.Product.Description;
                daoFactory.TransactionDetailDao.SaveTransactionDetail(td);
            });

            switch (saveScheduledTransactionDto.Frequency.Frequency)
            {
                case 1:
                    generatedDates.Add(saveScheduledTransactionDto.Frequency.StartDate);
                    break;
                case 2:
                    generatedDates = dateGenerator.GenerateDaily(saveScheduledTransactionDto.Frequency.StartDate, saveScheduledTransactionDto.Frequency.EndDate);
                    break;
                case 3:
                    List<int> selectedWeeklyDays = saveScheduledTransactionDto.Frequency.WeeklyDaysSelected.Split(',').Select(Int32.Parse).ToList();
                    generatedDates = dateGenerator.GenerateWeekly(saveScheduledTransactionDto.Frequency.StartDate, saveScheduledTransactionDto.Frequency.EndDate, int.Parse(saveScheduledTransactionDto.Frequency.RecurEvery), selectedWeeklyDays);
                    break;
                case 4:
                    List<int> selectedMonths = saveScheduledTransactionDto.Frequency.SelectedMonths.Split(',').Select(Int32.Parse).ToList();
                    List<int> selectedDates = saveScheduledTransactionDto.Frequency.SelectedMonthlyDates.Split(',').Select(Int32.Parse).ToList();
                    generatedDates = dateGenerator.GenerateMonthly(saveScheduledTransactionDto.Frequency.StartDate, saveScheduledTransactionDto.Frequency.EndDate, selectedMonths, selectedDates);

                    break;
            }

            List<TransactionDue> transactionDues = saveScheduledTransactionDto.Transaction.TransactionDues.ToList();

            if (transactionDues.Count > 0)
            {
                List<TransactionDue> transactionDuesToInsert = new List<TransactionDue>();
                List<TransactionDue> transactionDuesToDelete = new List<TransactionDue>();
                List<TransactionDue> transactionDuesToUpdate = new List<TransactionDue>();

                MergeTransactionDuesWithNewGeneratedDates(transactionDues, generatedDates, (long)saveScheduledTransactionDto.Transaction.TotalAmount, (long)saveScheduledTransactionDto.Transaction.IdTransaction, out transactionDuesToDelete, out transactionDuesToUpdate, out transactionDuesToInsert);

                // perform delete
                transactionDues.RemoveAll(td => transactionDuesToDelete.Contains(td));
                transactionDuesToDelete.ToList().ForEach((td) =>
                {
                    daoFactory.TransactionDueDao.DeleteTransactionDue(td);
                });

                //perform insert
                transactionDues.AddRange(transactionDuesToInsert.ToList());
                transactionDuesToInsert.ToList().ForEach((td) =>
                {
                    daoFactory.TransactionDueDao.SaveTransactionDue(td);
                });

                //perform update
                transactionDues.RemoveAll(td => transactionDuesToUpdate.Select(t => t.IdTransactionDue).Contains(td.IdTransactionDue));
                transactionDues.AddRange(transactionDuesToUpdate.ToList());
                transactionDues.ToList().ForEach((td) =>
                {
                    daoFactory.TransactionDueDao.SaveTransactionDue(td);
                });

                /*transactionDuesToDelete = transactionDues.Where(td => td.AmountDue == td.AmountRemaining).ToList();
                transactionDuesToInsert = generatedDates.Select(td =>
                    new TransactionDue()
                    {
                        IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction,
                        DueDate = td.Date,
                        AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount,
                        AmountRemaining = getAmountRemaining(transactionDues, td.Date, saveScheduledTransactionDto.Transaction.TotalAmount),
                    }
               ).ToList();

                transactionDuesToDelete.ToList().ForEach((td) => {
                    daoFactory.TransactionDueDao.DeleteTransactionDue(td); 
                });

                transactionDuesToInsert.ToList().ForEach((td) =>
                {
                    daoFactory.TransactionDueDao.SaveTransactionDue(td);
                });*/
            }
            else
            {
                generatedDates.ToList().ForEach((date) =>
                {
                    TransactionDue _transactionDue = new TransactionDue();
                    _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                    _transactionDue.DueDate = date;
                    _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                    _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                    daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                });
            }

            /*
            //If no transaction dues are available, create all dues
            if (saveScheduledTransactionDto.Transaction.TransactionDues.Count == 0)
            {
                generatedDates.ToList().ForEach((date) =>
                {
                    TransactionDue _transactionDue = new TransactionDue();
                    _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                    _transactionDue.DueDate = date;
                    _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                    _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                    daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                });
            }
            //If already available
            else
            {
                generatedDates.ToList().ForEach((date) =>
                {
                    int index = saveScheduledTransactionDto.Transaction.TransactionDues.ToList().FindIndex(td => td.DueDate == date); //indexOf
                    //Create transaction due if date is not available in the list
                    if (index < 0)
                    {
                        TransactionDue _transactionDue = new TransactionDue();
                        _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                        _transactionDue.DueDate = date;
                        _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                        _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                        daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                    }
                    //If available, if amount remaining 0, calculate difference, else overwrite
                    else
                    {
                        long? idTransactionDue = saveScheduledTransactionDto.Transaction.TransactionDues.Where(td => td.DueDate == date).FirstOrDefault().IdTransactionDue;
                        if (idTransactionDue != null)
                        {
                            TransactionDue _transactionDue = daoFactory.TransactionDueDao.GetTransactionDue((long)idTransactionDue);
                            if ((_transactionDue.AmountDue != saveScheduledTransactionDto.Transaction.TransactionDues.Where(td => td.IdTransactionDue == idTransactionDue).FirstOrDefault().AmountDue) && (_transactionDue.AmountRemaining == _transactionDue.AmountDue))
                            {
                                _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TransactionDues.Where(td => td.IdTransactionDue == idTransactionDue).FirstOrDefault().AmountDue;
                                _transactionDue.AmountRemaining = _transactionDue.AmountDue;
                                daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                            } else if ((_transactionDue.AmountDue != saveScheduledTransactionDto.Transaction.TransactionDues.Where(td => td.IdTransactionDue == idTransactionDue).FirstOrDefault().AmountDue) && (_transactionDue.AmountRemaining != 0))
                            {
                                _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TransactionDues.Where(td => td.IdTransactionDue == idTransactionDue).FirstOrDefault().AmountDue;
                                _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TransactionDues.Where(td => td.IdTransactionDue == idTransactionDue).FirstOrDefault().AmountDue - _transactionDue.AmountDue;
                                daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                            }
                        }
                    }
                });
            }*/

            ScheduleSetting scheduleSetting = new ScheduleSetting();
            scheduleSetting.IdFrequency = saveScheduledTransactionDto.Frequency.Frequency;
            scheduleSetting.ReccurEvery = saveScheduledTransactionDto.Frequency.RecurEvery;
            scheduleSetting.WeekOccursOnDays = saveScheduledTransactionDto.Frequency.WeeklyDaysSelected;
            scheduleSetting.StartDate = saveScheduledTransactionDto.Frequency.StartDate;
            if (saveScheduledTransactionDto.Frequency.EndDate != DateTime.MinValue)
                scheduleSetting.EndDate = saveScheduledTransactionDto.Frequency.EndDate;
            scheduleSetting.MonthOccurs = saveScheduledTransactionDto.Frequency.SelectedMonths;
            scheduleSetting.MonthOnSpecificDays = saveScheduledTransactionDto.Frequency.SelectedMonthlyDays;
            scheduleSetting.MonthEveryOrdinal = saveScheduledTransactionDto.Frequency.SelectedMonthlyEvery;
            scheduleSetting.MonthOnSpecificDays = saveScheduledTransactionDto.Frequency.SelectedMonthlyDates;
            scheduleSetting.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
            if (saveScheduledTransactionDto.Transaction.ScheduleSettings.Count > 0)
            {
                scheduleSetting.IdScheduleSetting = saveScheduledTransactionDto.Transaction.ScheduleSettings.FirstOrDefault().IdScheduleSetting;
            }

            daoFactory.ScheduleSettingDao.SaveOnlyScheduleSetting(scheduleSetting);

            saveScheduledTransactionReturnType.Transaction = saveScheduledTransactionDto.Transaction;
            saveScheduledTransactionReturnType.ScheduleSetting = scheduleSetting;

            return saveScheduledTransactionReturnType;
        }

        internal SaveScheduledTransactionReturnType SaveScheduledTransactionRaw1(SaveScheduledTransactionDto saveScheduledTransactionDto)
        {

            SaveScheduledTransactionReturnType saveScheduledTransactionReturnType = new SaveScheduledTransactionReturnType();
            List<DateTime> generatedDates = new List<DateTime>();
            List<TransactionDue> transactionDues = saveScheduledTransactionDto.Transaction.TransactionDues.ToList();

            List<TransactionDue> transactionDuesToInsert = new List<TransactionDue>();
            List<TransactionDue> transactionDuesToDelete = new List<TransactionDue>();

            transactionDuesToDelete = transactionDues.Where(td => td.AmountDue == td.AmountRemaining).ToList();
            transactionDuesToInsert = generatedDates.Select(td =>
                new TransactionDue()
                {
                    IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction,
                    DueDate = td.Date,
                    AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount,
                    AmountRemaining = getAmountRemaining(transactionDues, td.Date, saveScheduledTransactionDto.Transaction.TotalAmount),
                }
           ).ToList();
            //transactionDuesToInsert = transactionDuesToInsert.Where(td => td.AmountRemaining != td.AmountDue);
            return saveScheduledTransactionReturnType;
        }

        public BusinessResponse<GetTransactionSaleForPrintReturnType> GetTransactionSaleForPrint(long idTransactionSale)
        {
            BusinessResponse<GetTransactionSaleForPrintReturnType> response = new BusinessResponse<GetTransactionSaleForPrintReturnType>();

            try
            {
                response.Result = GetTransactionSaleForPrintRaw(idTransactionSale);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetTransactionSaleForPrintReturnType GetTransactionSaleForPrintRaw(long idTransaction)
        {
            GetTransactionSaleForPrintReturnType getTransactionSaleForPrintReturnType = new GetTransactionSaleForPrintReturnType();

            Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.IdTransaction == idTransaction;
            List<string> includes = new List<string>()
            {
                String.Format("{0}.{1}.{2}.{3}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANYLOCATIONS,CompanyLocationDatabaseReferences.ADDRESS),
                String.Format("{0}.{1}.{2}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.COMPANY,CompanyDatabaseReferences.COMPANY_CONTACTTYPE),
                String.Format("{0}.{1}.{2}.{3}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS,Person_AddressDatabaseReferences.ADDRESS),
                String.Format("{0}.{1}.{2}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_CONTACTTYPE),
                //TransactionDatabaseReferences.TRANSACTIONCLASS,
                //TransactionDatabaseReferences.TRANSACTIONACCOUNT,
                //TransactionDatabaseReferences.TRANSACTIONTEMPLATE,
                String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
                //String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.TRANSACTIONCLASS),
                String.Format("{0}.{1}.{2}",TransactionDatabaseReferences.PAYMENT,PaymentDatabaseReferences.PAYMENTDETAILS,PaymentDetailDatabaseReferences.PAYMENTMETHOD),
                String.Format("{0}.{1}",TransactionDatabaseReferences.DOCUMENT,DocumentDatabaseReferences.PARAMETER)
            };

            Transaction dbTransactionSale = daoFactory.TransactionDao.GetTransactionCustom(expression, includes);
            if (dbTransactionSale != null)
            {
                getTransactionSaleForPrintReturnType.IdTransaction = dbTransactionSale.IdTransaction;
                getTransactionSaleForPrintReturnType.IdTransactionType = dbTransactionSale.IdTransactionType.Value;
                getTransactionSaleForPrintReturnType.ReceiptNo = dbTransactionSale.ReceiptNo;
                getTransactionSaleForPrintReturnType.CustomerName = dbTransactionSale.Customer.FullName;
                getTransactionSaleForPrintReturnType.Address = "";
                getTransactionSaleForPrintReturnType.TransactionDetails = new List<GetTransactionSaleForPrintTransactionDetailReturnType>();
                getTransactionSaleForPrintReturnType.TransactionDate = dbTransactionSale.TransactionDate.Value.ToString("dd MMMM yyyy");

                if (dbTransactionSale.Document != null)
                {
                    getTransactionSaleForPrintReturnType.SignatureFilePath = String.Format("file:///{0}", ServiceFactory.Instance.DocumentService.GetDocumentPhysicalPath(dbTransactionSale.Document));
                }

                //getTransactionSaleForPrintReturnType.SignatureFilePath = @"file:///C:\Projects\ComputerSync\IslamicRelief\04.Implementation\TheHub\TheHub.Ui.Mvc\Images\sign-in-up.png";

                Address address = null;

                if (dbTransactionSale.Customer.IdCustomerType == (long)CustomerTypeEnum.COMPANY)
                {
                    address = dbTransactionSale.Customer.Company?.CompanyLocations?.FirstOrDefault()?.Address;
                    List<Company_ContactType> contactTypes = dbTransactionSale.Customer.Company.Company_ContactType.Where(c => c.IdContactType == (long)ContactTypeEnum.EMAIL_ADDRESS).ToList();
                    if (contactTypes.Count() > 0)
                    {
                        getTransactionSaleForPrintReturnType.EmailAddresses = contactTypes.Select(c => c.Description).ToList();
                    }
                }
                else
                {
                    address = dbTransactionSale.Customer.Person?.Person_Address?.FirstOrDefault()?.Address;
                    if(dbTransactionSale.Customer.Person != null)
                    {
                        List<Person_ContactType> contactTypes = dbTransactionSale.Customer.Person.Person_ContactType.Where(c => c.IdContactType == (long)ContactTypeEnum.EMAIL_ADDRESS).ToList();
                        if (contactTypes.Count() > 0)
                        {
                            getTransactionSaleForPrintReturnType.EmailAddresses = contactTypes.Select(c => c.Description).ToList();
                        }
                    }
                }
                if (address != null)
                    getTransactionSaleForPrintReturnType.Address = ServiceFactory.Instance.AddressService.FormatAddressForView(address);

                if (dbTransactionSale.Payment != null)
                {
                    getTransactionSaleForPrintReturnType.PaymentMethod = String.Join("<br />", dbTransactionSale.Payment.PaymentDetails.Where(p => p.PaymentMethod != null).Select(p => p.PaymentMethod.Description).ToArray());
                    getTransactionSaleForPrintReturnType.ChequeNo = String.Join("<br />", dbTransactionSale.Payment.PaymentDetails.Where(p => !String.IsNullOrEmpty(p.ChequeNo)).Select(p => p.ChequeNo).ToArray());
                } else
                {
                    getTransactionSaleForPrintReturnType.PaymentMethod = "";
                    getTransactionSaleForPrintReturnType.ChequeNo = "";
                }
                    dbTransactionSale.TransactionDetails.Where(t => t.IsDeactivated != true).ToList().ForEach(td =>
                {
                    GetTransactionSaleForPrintTransactionDetailReturnType getTransactionSaleForPrintTransactionDetailReturnType = new GetTransactionSaleForPrintTransactionDetailReturnType();
                    getTransactionSaleForPrintTransactionDetailReturnType.Name = td.Product.Name;
                    getTransactionSaleForPrintTransactionDetailReturnType.Description = td.Description;
                    getTransactionSaleForPrintTransactionDetailReturnType.Quantity = (td.Quantity ?? 0).ToString();
                    getTransactionSaleForPrintTransactionDetailReturnType.Rate = String.Format("{0:0,0.00}", td.Rate ?? 0);
                    getTransactionSaleForPrintTransactionDetailReturnType.Amount = String.Format("{0:0,0.00}", (td.Quantity ?? 0) * (td.Rate ?? 0));
                    getTransactionSaleForPrintReturnType.TransactionDetails.Add(getTransactionSaleForPrintTransactionDetailReturnType);
                });

                if (dbTransactionSale.IdTransactionType == 1)
                {
                    getTransactionSaleForPrintReturnType.Total = String.Format("{0:0,0.00}", dbTransactionSale.TransactionDetails.Sum(t => t.Quantity * t.Rate) ?? 0);
                    getTransactionSaleForPrintReturnType.AmountPaid = String.Format("{0:0,0.00}", dbTransactionSale.Payment.PaymentDetails.Sum(t => t.PaymentAmount));
                    getTransactionSaleForPrintReturnType.AmountRemaining = String.Format("{0:0,0.00}", dbTransactionSale.TransactionDetails.Sum(t => t.Quantity * t.Rate) - dbTransactionSale.Payment.PaymentDetails.Sum(t => t.PaymentAmount));
                }

                if (dbTransactionSale.IdTransactionType == 2)
                {
                    getTransactionSaleForPrintReturnType.Total = String.Format("{0:0,0.00}", dbTransactionSale.TotalAmount ?? 0);
                }

            }
            else
            {
                throw new Exception("TransactionSale cannot be found");
            }
            return getTransactionSaleForPrintReturnType;
        }

        private static void MergeTransactionDuesWithNewGeneratedDates(List<TransactionDue> transactionDues, List<DateTime> generatedDates, double totalAmount, long idTransaction, out List<TransactionDue> transactionDuesToDelete, out List<TransactionDue> transactionDuesToUpdate, out List<TransactionDue> transactionDuesToInsert)
        {
            var transactionDuesDates = transactionDues.Select(t => t.DueDate).ToList();
            transactionDuesToInsert = generatedDates.Where(d => !transactionDuesDates.Contains(d))
                .Select(td =>
                new TransactionDue()
                {
                    IdTransaction = idTransaction,
                    DueDate = td.Date,
                    AmountDue = totalAmount,
                    AmountRemaining = totalAmount,//getAmountRemaining(transactionDues, td.Date, totalAmount),
                }
            ).ToList();

            transactionDuesToDelete = transactionDues.Where(td => td.AmountRemaining != 0 && !generatedDates.Contains(td.DueDate.Value)).ToList();
            transactionDuesToUpdate = transactionDues.Where(td => generatedDates.Contains(td.DueDate.Value))
                .Select(td =>
                    new TransactionDue()
                    {
                        IdTransaction = idTransaction,
                        IdTransactionDue = td.IdTransactionDue,
                        DueDate = td.DueDate,
                        AmountDue = totalAmount,
                        AmountRemaining = totalAmount - td.AmountDue + td.AmountRemaining,// getAmountRemaining(transactionDues, td.DueDate.Value, totalAmount),
                    }
             ).ToList();
            transactionDuesToUpdate.RemoveAll(td => td.AmountRemaining < 0);
        }

        private double? getAmountRemaining(List<TransactionDue> transactionDues, DateTime date, double? totalAmount)
        {
            double? amount;
            var transactionDue = transactionDues.Where(td => td.DueDate == date).FirstOrDefault();
            if (transactionDue != null)
            {
                amount = totalAmount - (transactionDue.AmountDue - transactionDue.AmountRemaining);
            }
            else
            {
                amount = totalAmount;
            }
            return amount;
        }

        public BusinessResponse<BaseListReturnType<Transaction>> GetAllScheduledTransactionList(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<Transaction>> response = new BusinessResponse<BaseListReturnType<Transaction>>();

            try
            {
                response.Result = GetAllScheduledTransactionListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Transaction> GetAllScheduledTransactionListRaw(TransactionListSortingPagingInfo sortingPagingInfo)
        {

            BaseListReturnType<Transaction> dbScheduleSettingsReturnType = new BaseListReturnType<Transaction>();
            dbScheduleSettingsReturnType.EntityList = new List<Transaction>();
            Expression<Func<Transaction, bool>> expression;
            //Expression<Func<Transaction, bool>> expressionBuilder = expression;
            //var idTransactionTypeSchedule = TransactionTy
            /*if (sortingPagingInfo.IdCustomer as int? != 0)
            {
                expression = property => property.IsDeactivated != true && property.IdTransactionType == sortingPagingInfo.IdTransactionType && property.IdCustomer == sortingPagingInfo.IdCustomer; //enum
            }
            else
            {
                expression = property => property.IsDeactivated != true && property.IdTransactionType == sortingPagingInfo.IdTransactionType;
                //expression = property => property.IsDeactivated != true && property.IdTransactionType == sortingPagingInfo.IdTransactionType && property.Customer.FullName.Trim().ToLower().Contains(sortingPagingInfo.Search.Trim().ToLower());
                
            }*/
            expression = property => property.IsDeactivated != true && property.IdTransactionType == sortingPagingInfo.IdTransactionType;

            if (sortingPagingInfo.IdCustomer as int? != 0)
            {
                expression = expression.CombineWithAndAlso(property => property.IdCustomer == sortingPagingInfo.IdCustomer); //enum
            }

            if (!String.IsNullOrWhiteSpace(sortingPagingInfo.Search))
            {
                expression = expression.CombineWithAndAlso(property => property.Customer.FullName.Trim().ToLower().Contains(sortingPagingInfo.Search.Trim().ToLower()));
            }




            List<string> includes = new List<string>()
                {
                    TransactionDatabaseReferences.SCHEDULESETTINGS,
                    TransactionDatabaseReferences.TRANSACTIONDUES,
                    TransactionDatabaseReferences.TRANSACTIONDETAILS,
                    TransactionDatabaseReferences.PAYMENTS,
                    TransactionDatabaseReferences.CUSTOMER,
                    String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
                };

            BaseListReturnType<Transaction> dbTransaction = ServiceFactory.Instance.TransactionService.GetAllTransactionsByPageRaw(sortingPagingInfo, /*expression*/ expression, includes);
            dbTransaction.EntityList = dbTransaction.EntityList.Where(e => e.IsDeactivated != true && e.ScheduleSettings != null).ToList();

            BaseListReturnType<Transaction> transactionList = new BaseListReturnType<Transaction>();
            transactionList.EntityList = new List<Transaction>();
            transactionList.TotalCount = dbTransaction.TotalCount;

            /*if (sortingPagingInfo.IdCustomer as int? != null)
            {
                List<List<TransactionDetail>> _transactionDetails = new List<List<TransactionDetail>>();
                dbTransaction.EntityList.ForEach((tran) => {
                    _transactionDetails.Add(tran.TransactionDetails.Where(td => td.IdProduct == sortingPagingInfo.IdProduct).ToList());
                });
                dbTransaction.EntityList = dbTransaction.EntityList.Where(t => t.TransactionDetails == _transactionDetails).ToList();
            }*/

            dbTransaction.EntityList.ForEach((d) =>
            {
                Transaction _transaction = Mapper.MapTransactionSingle(d, true);
                if (d != null)
                {
                    _transaction = RemapTransaction(d);
                }
                transactionList.EntityList.Add(_transaction);

            });

            return transactionList;

        }

        public BusinessResponse<BaseListReturnType<Transaction>> GetAllTransactionsPerCustomer(long idCustomer)
        {
            BusinessResponse<BaseListReturnType<Transaction>> response = new BusinessResponse<BaseListReturnType<Transaction>>();

            try
            {
                response.Result = GetAllTransactionsPerCustomerRaw(idCustomer);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Transaction> GetAllTransactionsPerCustomerRaw(long idCustomer)
        {

            BaseListReturnType<Transaction> dbScheduleSettingsReturnType = new BaseListReturnType<Transaction>();
            dbScheduleSettingsReturnType.EntityList = new List<Transaction>();
            Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.IdTransactionType == 2 && property.IdCustomer == idCustomer; //enum

            List<string> includes = new List<string>()
                {
                    TransactionDatabaseReferences.SCHEDULESETTINGS,
                    TransactionDatabaseReferences.TRANSACTIONDUES,
                    TransactionDatabaseReferences.TRANSACTIONDETAILS,
                    TransactionDatabaseReferences.PAYMENTS,
                    TransactionDatabaseReferences.CUSTOMER,
                    String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
                };

            BusinessResponse<BaseListReturnType<Transaction>> dbTransaction = GetTransactionCustomList(expression, includes);
            dbTransaction.Result.EntityList = dbTransaction.Result.EntityList.Where(e => e.IsDeactivated != true && e.ScheduleSettings != null).ToList();

            BaseListReturnType<Transaction> transactionList = new BaseListReturnType<Transaction>();
            transactionList.EntityList = new List<Transaction>();
            transactionList.TotalCount = dbTransaction.Result.TotalCount;

            dbTransaction.Result.EntityList.ForEach((d) =>
            {
                Transaction _transaction = Mapper.MapTransactionSingle(d, true);
                if (d != null)
                {
                    _transaction = RemapTransaction(d);
                }
                transactionList.EntityList.Add(_transaction);

            });

            return transactionList;

        }

        public BusinessResponse<BaseListReturnType<Transaction>> GetAllScheduledTransactionsPerCustomer(long idCustomer)
        {
            BusinessResponse<BaseListReturnType<Transaction>> response = new BusinessResponse<BaseListReturnType<Transaction>>();

            try
            {
                response.Result = GetAllScheduledTransactionsPerCustomerRaw(idCustomer);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Transaction> GetAllScheduledTransactionsPerCustomerRaw(long idCustomer)
        {

            BaseListReturnType<Transaction> dbScheduleSettingsReturnType = new BaseListReturnType<Transaction>();
            dbScheduleSettingsReturnType.EntityList = new List<Transaction>();
            Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.IdTransactionType == 3 && property.IdCustomer == idCustomer; //enum
            
            List<string> includes = new List<string>()
                {
                    TransactionDatabaseReferences.SCHEDULESETTINGS,
                    TransactionDatabaseReferences.TRANSACTIONDUES,
                    TransactionDatabaseReferences.TRANSACTIONDETAILS,
                    TransactionDatabaseReferences.PAYMENTS,
                    TransactionDatabaseReferences.CUSTOMER,
                    String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
                };

            BusinessResponse<BaseListReturnType<Transaction>> dbTransaction = GetTransactionCustomList(expression,includes);
            dbTransaction.Result.EntityList = dbTransaction.Result.EntityList.Where(e => e.IsDeactivated != true && e.ScheduleSettings != null).ToList();

            BaseListReturnType<Transaction> transactionList = new BaseListReturnType<Transaction>();
            transactionList.EntityList = new List<Transaction>();
            transactionList.TotalCount = dbTransaction.Result.TotalCount;

            dbTransaction.Result.EntityList.ForEach((d) =>
            {
                Transaction _transaction = Mapper.MapTransactionSingle(d, true);
                if (d != null)
                {
                    _transaction = RemapTransaction(d);
                }
                transactionList.EntityList.Add(_transaction);

            });

            return transactionList;

        }

        public BusinessResponse<GetScheduledTransactionReturnType> GetScheduledTransaction(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<GetScheduledTransactionReturnType> response = new BusinessResponse<GetScheduledTransactionReturnType>();

            try
            {
                response.Result = GetScheduledTransactionRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetScheduledTransactionReturnType GetScheduledTransactionRaw(TransactionListSortingPagingInfo sortingPagingInfo)
        {

            GetScheduledTransactionReturnType getScheduledTransactionReturnType = new GetScheduledTransactionReturnType();
            Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.IdTransaction == sortingPagingInfo.IdTransaction; //enum
            List<string> includes = new List<string>()
                {
                    TransactionDatabaseReferences.SCHEDULESETTINGS,
                    TransactionDatabaseReferences.TRANSACTIONDUES,
                    TransactionDatabaseReferences.TRANSACTIONDETAILS,
                    TransactionDatabaseReferences.CUSTOMER,
                    TransactionDatabaseReferences.PAYMENTS,
                    String.Format("{0}.{1}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.PERSON),
                    String.Format("{0}.{1}.{2}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS),
                    String.Format("{0}.{1}.{2}.{3}",TransactionDatabaseReferences.CUSTOMER,CustomerDatabaseReferences.PERSON,PersonDatabaseReferences.PERSON_ADDRESS, Person_AddressDatabaseReferences.ADDRESS),
                    String.Format("{0}.{1}",TransactionDatabaseReferences.PAYMENTS,PaymentDatabaseReferences.PAYMENTDETAILS),
                    String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
                };

            BusinessResponse<Transaction> dbTransaction = GetTransactionCustom(expression, includes);            
           
            Transaction _transaction = new Transaction();
            if (dbTransaction.Result != null)
            {
                Mapper.MapTransactionSingle(dbTransaction.Result);
                _transaction = RemapTransaction(dbTransaction.Result);
                if (dbTransaction.Result.Customer != null)
                {
                    _transaction.Customer = ServiceFactory.Instance.CustomerService.RemapCustomer(dbTransaction.Result.Customer);
                }
                /* _transaction.Payments.ToList().ForEach(tp => {
                     tp = RemapPayment(tp);
                 });*/
            }

            BaseListReturnType<TransactionDue> _transactionDues = new BaseListReturnType<TransactionDue>();
            _transactionDues.EntityList = new List<TransactionDue>();

            _transaction.TransactionDues.ToList().ForEach((td) =>
            {
                if (td.IsDeactivated != true)
                {
                    _transactionDues.EntityList.Add(td);
                }
            });
            _transactionDues.TotalCount = _transaction.TransactionDues.Count;

            getScheduledTransactionReturnType.Transaction = _transaction;
            getScheduledTransactionReturnType.TransactionDues = _transactionDues;

            return getScheduledTransactionReturnType;

        }

        public BusinessResponse<Transaction> GetScheduledTransactionPayments(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<Transaction> response = new BusinessResponse<Transaction>();

            try
            {
                response.Result = GetScheduledTransactionRawPayments(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal Transaction GetScheduledTransactionRawPayments(TransactionListSortingPagingInfo sortingPagingInfo)
        {

            Transaction dbScheduleSettingsReturnType = new Transaction();
            Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.IdTransactionOriginal == sortingPagingInfo.IdTransaction; //enum
            List<string> includes = new List<string>()
                {
                    TransactionDatabaseReferences.SCHEDULESETTINGS,
                    TransactionDatabaseReferences.TRANSACTIONDUES,
                    TransactionDatabaseReferences.TRANSACTIONDETAILS,
                    TransactionDatabaseReferences.CUSTOMER,
                    TransactionDatabaseReferences.PAYMENTS,
                    String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
                };

            BusinessResponse<Transaction> dbTransaction = GetTransactionCustom(expression, includes);

            Transaction _transaction = Mapper.MapTransactionSingle(dbTransaction.Result, true);
            if (dbTransaction.Result != null)
            {
                _transaction = RemapTransaction(dbTransaction.Result);
            }
            else
            {
                _transaction = new Transaction();
                _transaction.Payments = new List<Payment>();
            }

            return _transaction;

        }

        public BusinessResponse<GetTransactionTotalForDateReturnType> GetTransactionTotalForDate(GetTransactionTotalForDateDto getTransactionTotalForDateDto)
        {
            BusinessResponse<GetTransactionTotalForDateReturnType> response = new BusinessResponse<GetTransactionTotalForDateReturnType>();

            try
            {
                response.Result = GetTransactionTotalForDateRaw(getTransactionTotalForDateDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetTransactionTotalForDateReturnType GetTransactionTotalForDateRaw(GetTransactionTotalForDateDto getTransactionTotalForDateDto)
        {
            GetTransactionTotalForDateReturnType getTransactionTotalForDateReturnType = daoFactory.TransactionDao.GetTransactionTotalForDate(getTransactionTotalForDateDto.IdUser, getTransactionTotalForDateDto.Date);

            getTransactionTotalForDateReturnType.Date = getTransactionTotalForDateDto.Date.ToString("dd MMMM yyyy");
            return getTransactionTotalForDateReturnType;
        }

        public BusinessResponse<bool> SendEmailToClient(SendEmailToClientDto sendEmailToClientDto)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();

            try
            {
                response.Result = SendEmailToClientRaw(sendEmailToClientDto);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal bool SendEmailToClientRaw(SendEmailToClientDto sendEmailToClientDto)
        {
            GetTransactionSaleForPrintReturnType getTransactionSaleForPrintReturnType = GetTransactionSaleForPrintRaw(sendEmailToClientDto.IdTransaction);
            if (getTransactionSaleForPrintReturnType.EmailAddresses == null || getTransactionSaleForPrintReturnType.EmailAddresses.Count == 0)
            {
                throw new Exception("No email addresses for client found, please add email address for client and try again");
            }
            BusinessResponse<BaseReportReturnType> response = new ReportService().GenerateReport(new TransactionReceiptDto()
            {
                ReportCode = "5015d08d-8d55-4657-b06c-aed1a56274ce",
                ReportFormat = "PDF",
                IdTransaction = sendEmailToClientDto.IdTransaction,
                GetTransactionSaleForPrintReturnType = getTransactionSaleForPrintReturnType
            });

            if (response.HasException())
                throw new Exception("Receipt could not be generated");

            List<Parameter> parameters = GetEmailParameters();

            MailToSend mailToSend = GetFormattedMailToSend(parameters, getTransactionSaleForPrintReturnType, new List<string>() { response.Result.FilePath });

            BusinessResponse<MailToSend> mailToSendResponse = ServiceFactory.Instance.MailToSendService.SaveMailToSendCustom(mailToSend);

            if (mailToSendResponse.HasException())
                throw new Exception("Could not generate email");

            ServiceFactory.Instance.MailToSendService.SendMailRaw(mailToSend);
            mailToSend.IdEmailStatus = (long)MailStatusEnum.SUCCESS;
            ServiceFactory.Instance.MailToSendService.SaveOnlyMailToSend(mailToSend);

            return false;
        }

        private List<Parameter> GetEmailParameters()
        {
            List<long> idParameters = new List<long>()
            {
                (long)ParameterEnum.TRANSACTION_RECEIPT_BODY,
                (long)ParameterEnum.TRANSACTION_RECEIPT_SUBJECT,
                (long)ParameterEnum.TRANSACTION_RECEIPT_COPY,
                (long)ParameterEnum.TRANSACTION_RECEIPT_NAME
            };

            List<Parameter> parameters = ServiceFactory.Instance.ParameterService.GetParameterCustomListRaw(p => idParameters.Contains(p.IdParameter.Value)).EntityList;
            return parameters;
        }

        private MailToSend GetFormattedMailToSend(List<Parameter> parameters, GetTransactionSaleForPrintReturnType getTransactionSaleForPrintReturnType, List<string> documentPaths)
        {
            string mailBody = parameters.Where(p => p.IdParameter == (long)ParameterEnum.TRANSACTION_RECEIPT_BODY).First().ParamaterValue;
            string mailSubject = parameters.Where(p => p.IdParameter == (long)ParameterEnum.TRANSACTION_RECEIPT_SUBJECT).First().ParamaterValue;
            string mailCC = parameters.Where(p => p.IdParameter == (long)ParameterEnum.TRANSACTION_RECEIPT_COPY).First().ParamaterValue;
            string documentName = parameters.Where(p => p.IdParameter == (long)ParameterEnum.TRANSACTION_RECEIPT_NAME).First().ParamaterValue;

            mailSubject = mailSubject.Replace("##{{receiptNo}}##", getTransactionSaleForPrintReturnType.ReceiptNo);

            mailBody = mailBody.Replace("##{{fullName}}##", getTransactionSaleForPrintReturnType.CustomerName);
            //receiptNo
            MailToSend mailToSend = new MailToSend();
            mailToSend.EmailSubject = mailSubject;
            mailToSend.EmailBody = mailBody;
            mailToSend.MailRecipients = new List<MailRecipient>();
            mailToSend.MailToSendDocuments = new List<MailToSendDocument>();

            mailToSend.MailToSendDocuments = documentPaths.Select(d => new MailToSendDocument()
            {
                DocumentName = String.Format("{0}{1}", documentName.Replace("##{{receiptNo}}##", getTransactionSaleForPrintReturnType.ReceiptNo), Path.GetExtension(d)),
                RelativeDocumentPath = d
            }).ToList();

            getTransactionSaleForPrintReturnType.EmailAddresses.ForEach(e =>
            {
                mailToSend.MailRecipients.Add(new MailRecipient()
                {
                    EmailAddress = e,
                    IdMailRecipientType = (long)MailRecipientTypeEnum.TO,
                    Name = getTransactionSaleForPrintReturnType.CustomerName
                });
            });

            mailToSend.MailRecipients.Add(new MailRecipient()
            {
                EmailAddress = mailCC,
                IdMailRecipientType = (long)MailRecipientTypeEnum.CC,
            });

            mailToSend.Transaction_MailToSend = new List<Transaction_MailToSend>();
            mailToSend.Transaction_MailToSend.Add(new Transaction_MailToSend() { IdMailToSend = mailToSend.IdMailToSend, IdTransaction = getTransactionSaleForPrintReturnType.IdTransaction });
            return mailToSend;
        }

        public BusinessResponse<GetEmailForTransactionReturnType> GetEmailForTransaction(GetEmailForTransactionDto getEmailForTransactionDto)
        {
            BusinessResponse<GetEmailForTransactionReturnType> response = new BusinessResponse<GetEmailForTransactionReturnType>();
            try
            {
                response.Result = GetEmailForTransactionRaw(getEmailForTransactionDto);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetEmailForTransactionReturnType GetEmailForTransactionRaw(GetEmailForTransactionDto getEmailForTransactionDto)
        {
            GetEmailForTransactionReturnType getEmailForTransactionReturnType = daoFactory.TransactionDao.GetEmailForTransaction(getEmailForTransactionDto);

            return getEmailForTransactionReturnType;
        }

        public BusinessResponse<SaveEmailForTransactionReturnType> SaveEmailForTransaction(SaveEmailForTransactionDto saveEmailForTransactionDto)
        {
            BusinessResponse<SaveEmailForTransactionReturnType> response = new BusinessResponse<SaveEmailForTransactionReturnType>();
            try
            {
                response.Result = SaveEmailForTransactionRaw(saveEmailForTransactionDto);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal SaveEmailForTransactionReturnType SaveEmailForTransactionRaw(SaveEmailForTransactionDto saveEmailForTransactionDto)
        {
            SaveEmailForTransactionReturnType saveEmailForTransactionReturnType = new SaveEmailForTransactionReturnType();

            List<long> idTransactions = saveEmailForTransactionDto.Transactions.Where(t => t.Emails != null && t.Emails.Where(e => e.Length > 0).Count() > 0)
                .Select(t => t.IdTransaction).ToList();
            List<GetTransactionSaleForPrintReturnType> getTransactionSaleForPrintReturnTypes = daoFactory.TransactionDao.GetTransactionSaleForPrint(idTransactions);
            List<Parameter> parameters = GetEmailParameters();

            List<MailToSend> mailToSends = new List<MailToSend>();
            getTransactionSaleForPrintReturnTypes.ForEach(p =>
            {
                BusinessResponse<BaseReportReturnType> response = new ReportService().GenerateReport(new TransactionReceiptDto()
                {
                    ReportCode = "5015d08d-8d55-4657-b06c-aed1a56274ce",
                    ReportFormat = "PDF",
                    IdTransaction = p.IdTransaction.Value,
                    GetTransactionSaleForPrintReturnType = p
                });
                SaveEmailForTransactionDetailDto saveEmailForTransactionDetailDto = saveEmailForTransactionDto.Transactions.Where(t => t.IdTransaction == p.IdTransaction.Value).FirstOrDefault();
                p.EmailAddresses = saveEmailForTransactionDetailDto.Emails.Where(e => e != null && e.Length > 0).ToList();
                MailToSend mailToSend = GetFormattedMailToSend(parameters, p, new List<string>() { response.Result.FilePath });
                mailToSends.Add(mailToSend);
            });
            daoFactory.MailToSendDao.SaveBulkMailToSend(mailToSends);
            return saveEmailForTransactionReturnType;
        }

        public Transaction RemapTransaction(Transaction transaction)
        {
            Transaction remappedTransaction = Mapper.MapTransactionSingle(transaction, true);
            remappedTransaction.TransactionDetails = new List<TransactionDetail>();

            if (transaction.TransactionDetails != null)
            {
                transaction.TransactionDetails.ToList().ForEach(td =>
                {
                    TransactionDetail transactionDetail = Mapper.MapTransactionDetailSingle(td, true);

                    if (td.Product != null)
                    {
                        transactionDetail.Product = Mapper.MapProductSingle(td.Product, true);
                    }
                    remappedTransaction.TransactionDetails.Add(transactionDetail);
                });
            }

            remappedTransaction.ScheduleSettings = new List<ScheduleSetting>();
            if (transaction.ScheduleSettings != null)
            {
                transaction.ScheduleSettings.ToList().ForEach(ss =>
                {
                    ScheduleSetting scheduleSetting = Mapper.MapScheduleSettingSingle(ss, true);
                    remappedTransaction.ScheduleSettings.Add(scheduleSetting);
                });
            }

            remappedTransaction.TransactionDues = new List<TransactionDue>();
            if (transaction.TransactionDues != null)
            {
                transaction.TransactionDues.ToList().ForEach(td =>
                {
                    TransactionDue transactionDue = Mapper.MapTransactionDueSingle(td, true);
                    remappedTransaction.TransactionDues.Add(transactionDue);
                });
            }

            remappedTransaction.Payments = new List<Payment>();
            if (transaction.Payments != null)
            {
                transaction.Payments.ToList().ForEach(td =>
                {
                    
                    Payment payment = Mapper.MapPaymentSingle(td, true);

                    td.PaymentDetails.ToList().ForEach(pd => {
                        PaymentDetail paymentDetail = Mapper.MapPaymentDetailSingle(pd, true);
                        payment.PaymentDetails.Add(paymentDetail);
                    });

                    remappedTransaction.Payments.Add(payment);

                });
            }

            if (transaction.Customer != null)
            {
                remappedTransaction.Customer = Mapper.MapCustomerSingle(transaction.Customer, true);
            }
            return remappedTransaction;
        }

        public Payment RemapPayment(Payment payment)
        {
            Payment remappedPayment = Mapper.MapPaymentSingle(payment, true);
            remappedPayment.PaymentDetails = new List<PaymentDetail>();

            if (remappedPayment.PaymentDetails != null)
            {
                remappedPayment.PaymentDetails.ToList().ForEach(pd =>
                {
                    PaymentDetail paymentDetail = Mapper.MapPaymentDetailSingle(pd, true);

                    remappedPayment.PaymentDetails.Add(paymentDetail);
                });
            }

            return remappedPayment;
        }
    }

}

/*
 var datesWeekly = Enumerable.Range(0, 1 + (saveScheduledTransactionDto.Frequency.EndDate - saveScheduledTransactionDto.Frequency.StartDate).Days)
                        .Select(offset => saveScheduledTransactionDto.Frequency.StartDate.AddDays(offset))
                        .ToArray();
                    //String arrayToSplit = "[" + saveScheduledTransactionDto.Frequency.WeeklyDaysSelected + "]";
                    //List<int> numbers = new List<int>(Array.ConvertAll(arrayToSplit.Split(','), int.Parse));
                    int[] numbers = saveScheduledTransactionDto.Frequency.WeeklyDaysSelected.Split(',').Select(Int32.Parse).ToArray();
                    datesWeekly.ToList().ForEach((date) =>
                        {
                            weeklyDaysFromFrontEnd.ForEach((selectedDates) =>
                            {
                                if (selectedDates == (long)date.DayOfWeek)
                                {
                                    _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                                    _transactionDue.DueDate = date;
                                    _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                                    _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                                    daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                                }
                            });
                        });
*/

/*
case 2:
                    var datesDaily = Enumerable.Range(0, 1 + (saveScheduledTransactionDto.Frequency.EndDate - saveScheduledTransactionDto.Frequency.StartDate).Days)
                        .Select(offset => saveScheduledTransactionDto.Frequency.StartDate.AddDays(offset))
                        .ToArray();
                    if (saveScheduledTransactionDto.Transaction.TransactionDues.Count == 0)
                    {
                        datesDaily.ToList().ForEach((date) =>
                        {
                            TransactionDue _transactionDue = new TransactionDue();
                            _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                            _transactionDue.DueDate = date;
                            _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                            _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                            daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                        });
                    }
                    else
                    {
                        datesDaily.ToList().ForEach((date) =>
                        {
                            int index = saveScheduledTransactionDto.Transaction.TransactionDues.ToList().FindIndex(td => td.DueDate == date);
                            if (!(index >= 0)){

                                TransactionDue _transactionDue = new TransactionDue();
                                _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                                _transactionDue.DueDate = date;
                                _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                                _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                                daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue); 
                            }
                        });
                    }
                    break;
                case 3:
                    //List<DayOfWeek> selectedWeeklyDays = new List<DayOfWeek>(){	DayOfWeek.Friday ,DayOfWeek.Saturday};
                    List<int> selectedWeeklyDays = saveScheduledTransactionDto.Frequency.WeeklyDaysSelected.Split(',').Select(Int32.Parse).ToList();
                    //get all days between start date and end date
                    var datesWeekly = Enumerable.Range(0, 1 + (saveScheduledTransactionDto.Frequency.EndDate - saveScheduledTransactionDto.Frequency.StartDate).Days)
                                .Select(offset => saveScheduledTransactionDto.Frequency.StartDate.AddDays(offset))
                                .Where(day => selectedWeeklyDays.Contains((int)day.DayOfWeek))
                                .ToList();

                    List<DateTime> dueDates = new List<DateTime>();

                    while (datesWeekly.Count > 0)
                    {
                        dueDates.AddRange(datesWeekly.Take(selectedWeeklyDays.Count));
                        if (datesWeekly.Count >= selectedWeeklyDays.Count * int.Parse(saveScheduledTransactionDto.Frequency.RecurEvery))
                            datesWeekly.RemoveRange(0, selectedWeeklyDays.Count * int.Parse(saveScheduledTransactionDto.Frequency.RecurEvery));
                        //else
                        //datesWeekly.RemoveRange(0, datesWeekly.Count);
                    }

                    datesWeekly.ToList().ForEach((date) =>
                    {
                        if (saveScheduledTransactionDto.Transaction.TransactionDues.Count == 0)
                        {
                            TransactionDue _transactionDue = new TransactionDue();
                            _transactionDue.IdTransaction = saveScheduledTransactionDto.Transaction.IdTransaction;
                            _transactionDue.DueDate = date;
                            _transactionDue.AmountDue = saveScheduledTransactionDto.Transaction.TotalAmount;
                            _transactionDue.AmountRemaining = saveScheduledTransactionDto.Transaction.TotalAmount;

                            daoFactory.TransactionDueDao.SaveTransactionDue(_transactionDue);
                        }
                    });

                    break;
                case 4:
                    break;
 */