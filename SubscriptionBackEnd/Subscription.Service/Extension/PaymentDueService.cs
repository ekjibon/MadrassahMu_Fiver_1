using CoreWeb.Business.Common;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Dto.Subscription;
using Subscription.Business.Enums;
using Subscription.Business.ReturnType.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Service
{
    public partial class PaymentDueService : BaseService
    {

        public BusinessResponse<BaseListReturnType<Transaction>> GetTransactionList(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<Transaction>> response = new BusinessResponse<BaseListReturnType<Transaction>>();

            try
            {
                response.Result = GetTransactionListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Transaction> GetTransactionListRaw(TransactionListSortingPagingInfo sortingPagingInfo)
        {

            BaseListReturnType<Transaction> loadScheduledTransactionsReturnType = new BaseListReturnType<Transaction>();
            loadScheduledTransactionsReturnType.EntityList = new List<Transaction>();

            //List<string> includes = new List<string>()
            //    {
            //        TransactionDatabaseReferences.CUSTOMER,
            //        TransactionDatabaseReferences.PAYMENTDUES,
            //        String.Format("{0}.{1}",TransactionDatabaseReferences.PAYMENTDUES,PaymentDueDatabaseReferences.PAYMENTDUESETTING),
            //        String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
            //    };

            //BaseListReturnType<Transaction> dbTransactionSale = ServiceFactory.Instance.TransactionService.GetAllTransactionsByPageRaw(sortingPagingInfo, null, includes);

            //dbTransactionSale.EntityList.ForEach((d) => {
            //    d.PaymentDues = d.PaymentDues.Where(e => e.IsDeactivated != true).ToList();
            //    d.TransactionDetails = d.TransactionDetails.Where(e => e.IsDeactivated != true).ToList();
            //    loadScheduledTransactionsReturnType.EntityList.Add(RemapTransaction(d));
            //});

            //loadScheduledTransactionsReturnType.TotalCount = dbTransactionSale.TotalCount;

            return loadScheduledTransactionsReturnType;

        }

        public BusinessResponse<GetPaymentDueDetailReturnType> GetPaymentDueDetail(GetScheduledTransactionDetailDto getPaymentDueDetailDto)
        {
            BusinessResponse<GetPaymentDueDetailReturnType> response = new BusinessResponse<GetPaymentDueDetailReturnType>();

            try
            {
                response.Result = GetPaymentDueDetailRaw(getPaymentDueDetailDto);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetPaymentDueDetailReturnType GetPaymentDueDetailRaw(GetScheduledTransactionDetailDto getPaymentDueDetailDto)
        {
            GetPaymentDueDetailReturnType getPaymentDueDetailReturnType = new GetPaymentDueDetailReturnType();

            //Expression<Func<Transaction, bool>> expression = property => property.IsDeactivated != true && property.IdTransaction == getPaymentDueDetailDto.IdTransaction;
            //List<string> includes = new List<string>()
            //    {
            //        TransactionDatabaseReferences.CUSTOMER,
            //        TransactionDatabaseReferences.PAYMENTDUES,
            //        String.Format("{0}.{1}",TransactionDatabaseReferences.PAYMENTDUES,PaymentDueDatabaseReferences.PAYMENTDUESETTING),
            //        String.Format("{0}.{1}",TransactionDatabaseReferences.TRANSACTIONDETAILS,TransactionDetailDatabaseReferences.PRODUCT),
            //    };

            //Transaction dbTransactionSale = daoFactory.TransactionDao.GetTransactionCustom(expression, includes);

            //dbTransactionSale.PaymentDues = dbTransactionSale.PaymentDues.Where(d => d.IsDeactivated != true).ToList();
            //dbTransactionSale.TransactionDetails = dbTransactionSale.TransactionDetails.Where(d => d.IsDeactivated != true).ToList();

            //if (dbTransactionSale != null)
            //{
            //    getPaymentDueDetailReturnType.Transaction = RemapTransaction(dbTransactionSale);
            //}           

            return getPaymentDueDetailReturnType;
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

            //remappedTransaction.PaymentDues = new List<PaymentDue>();

            //if (transaction.PaymentDues != null)
            //{
            //    transaction.PaymentDues.ToList().ForEach(td =>
            //    {
            //        PaymentDue paymentDue = Mapper.MapPaymentDueSingle(td, true);

            //        if (td.PaymentDueSetting != null)
            //        {
            //            paymentDue.PaymentDueSetting = Mapper.MapPaymentDueSettingSingle(td.PaymentDueSetting, true);
            //        }
            //        remappedTransaction.PaymentDues.Add(paymentDue);
            //    });
            //}

            if (transaction.Customer != null)
            {
                remappedTransaction.Customer = Mapper.MapCustomerSingle(transaction.Customer, true);
            }
            return remappedTransaction;
        }
    }

}

/*
         public BusinessResponse<LoadScheduledTransactionsReturnType> GetScheduledTransactions()
        {
            BusinessResponse<LoadScheduledTransactionsReturnType> response = new BusinessResponse<LoadScheduledTransactionsReturnType>();

            try
            {
                response.Result = GetScheduledTransactionsRaw();
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal LoadScheduledTransactionsReturnType GetScheduledTransactionsRaw()
        {
            LoadScheduledTransactionsReturnType loadScheduledTransactionsReturnType = new LoadScheduledTransactionsReturnType();

            List<Transaction> dbTransactions = daoFactory.TransactionDao.GetAllTransactions(true);
            List<BaseListReturnType<PaymentDue>> paymentDues = new List<BaseListReturnType<PaymentDue>>();

            dbTransactions.ForEach((transaction) =>
            {
                Expression<Func<PaymentDue, bool>> expression = property => property.IsDeactivated != true && property.IdTransaction == transaction.IdTransaction;
                List<string> includes = new List<string>()
                {
                    PaymentDueDatabaseReferences.PAYMENTDUESETTING,
                    PaymentDueDatabaseReferences.TRANSACTION,
                    String.Format("{0}.{1}",PaymentDueDatabaseReferences.TRANSACTION,TransactionDatabaseReferences.TRANSACTIONDETAILS)
                };

                BaseListReturnType<PaymentDue> dbPaymentDue = daoFactory.PaymentDueDao.GetPaymentDueCustomList(expression,includes, true);

                paymentDues.Add(dbPaymentDue);

            });

            loadScheduledTransactionsReturnType.PaymentDues = paymentDues;

            return loadScheduledTransactionsReturnType;
        }
 */