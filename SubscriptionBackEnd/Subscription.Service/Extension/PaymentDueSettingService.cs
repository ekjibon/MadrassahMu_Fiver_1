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
    public partial class PaymentDueSettingService : BaseService
    {

        public BusinessResponse<BaseListReturnType<ScheduleSetting>> GetPaymentDueSettingList(TransactionListSortingPagingInfo sortingPagingInfo)
        {
            BusinessResponse<BaseListReturnType<ScheduleSetting>> response = new BusinessResponse<BaseListReturnType<ScheduleSetting>>();

            try
            {
                response.Result = GetPaymentDueSettingListRaw(sortingPagingInfo);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<ScheduleSetting> GetPaymentDueSettingListRaw(TransactionListSortingPagingInfo sortingPagingInfo)
        {

            BaseListReturnType<ScheduleSetting> loadPaymentDueSettingsReturnType = new BaseListReturnType<ScheduleSetting>();
            loadPaymentDueSettingsReturnType.EntityList = new List<ScheduleSetting>();

            List<string> includes = new List<string>()
                {
                    ScheduleSettingDatabaseReferences.FREQUENCY,
                    ScheduleSettingDatabaseReferences.TRANSACTION,
                    String.Format("{0}.{1}",ScheduleSettingDatabaseReferences.TRANSACTION,TransactionDatabaseReferences.TRANSACTIONDETAILS),
                };

            BaseListReturnType<ScheduleSetting> dbPaymentDueSale = ServiceFactory.Instance.ScheduleSettingService.GetAllScheduleSettingsByPageRaw(sortingPagingInfo, null, includes,true);
            dbPaymentDueSale.EntityList = dbPaymentDueSale.EntityList.Where(e => e.IsDeactivated != true).ToList();

            dbPaymentDueSale.EntityList.ForEach((d) =>
            {
                //d.PaymentDues = d.PaymentDues.Where(e => e.IsDeactivated != true).ToList();
               /*d.TransactionDetails = d.TransactionDetails.Where(e => e.IsDeactivated != true).ToList();*/
                /*d.PaymentDues.ToList().ForEach((paymentDue) => {
                    paymentDue.Transaction.TransactionDetails = paymentDue.Transaction.TransactionDetails.Where(e => e.IsDeactivated != true).ToList();
                    paymentDue.Transaction = RemapTransaction(paymentDue.Transaction);
                    
                });*/
                //d.TransactionDetails = d.TransactionDetails.Where(e => e.IsDeactivated != true).ToList();
                //loadPaymentDueSettingsReturnType.EntityList.Add(d);
            });

            loadPaymentDueSettingsReturnType.EntityList = dbPaymentDueSale.EntityList;
            loadPaymentDueSettingsReturnType.TotalCount = dbPaymentDueSale.TotalCount;

            return loadPaymentDueSettingsReturnType;

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