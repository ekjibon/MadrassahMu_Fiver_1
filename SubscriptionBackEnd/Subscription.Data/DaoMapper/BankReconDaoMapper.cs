using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.ReturnType.BankReconciliation;
using Subscription.Business.ReturnType.BankReconciliation.Data;
using Subscription.Data.EntityFramework;

namespace Subscription.Data.DaoMapper
{
    class BankReconDaoMapper
    {
        public ReconcileBankOrderReturnType MapReconcileBankOrder(SubscriptionEntities db, DbDataReader reader)
        {
            ReconcileBankOrderReturnType reconcileBankOrderReturnType = new ReconcileBankOrderReturnType();

            List<ReconcileBankOrderDataReturnType> bankStaging = ((IObjectContextAdapter)db)
               .ObjectContext
               .Translate<ReconcileBankOrderDataReturnType>(reader).ToList();

            reader.NextResult();

            List<ReconcileBankOrderDetailDataReturnType> orderDetail = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<ReconcileBankOrderDetailDataReturnType>(reader).ToList();

            reader.NextResult();

            List<ReconcileBankOrderContactTypeDataReturnType> contactTypes = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<ReconcileBankOrderContactTypeDataReturnType>(reader).ToList();

            reader.NextResult();

            List<ReconcileBankOrderAddressDataReturnType> addresses = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<ReconcileBankOrderAddressDataReturnType>(reader).ToList();

            reconcileBankOrderReturnType.StagingDetails = new List<ReconcileBankOrderStagingDetailReturnType>();

            reconcileBankOrderReturnType.StagingDetails.AddRange(bankStaging.Select(b => new ReconcileBankOrderStagingDetailReturnType
            {
                IdBankStatementStagingDetail = b.IdBankStatementStagingDetail,
                ValueDate = b.ValueDate,
                BranchCode = b.BranchCode,
                Remarks = b.Remarks,
                DebitAmount = b.DebitAmount,
                CreditAmount = b.CreditAmount,
                Balance = b.Balance,
                IdOrder = b.IdOrder,
                OrderDate = b.OrderDate,
                OrderNumber = b.OrderNumber,
                IdOrderConcept = b.IdOrderConcept,
                IdOrderCompany = b.IdOrderCompany,
                IdOrderPerson = b.IdOrderPerson,
                IdBankReconOrderType = b.IdBankReconOrderType,
                OrderConceptName = b.OrderConceptName,
                Addresses = addresses.Where(a => a.IdOrderConcept == b.IdOrderConcept).Select(o => new ReconcileBankOrderAddressReturnType()
                {
                    Address = o.Address
                }).ToList(),
                ContactTypes = contactTypes.Where(c => c.IdOrderConcept == b.IdOrderConcept).Select(o => new ReconcileBankOrderContactTypeReturnType
                {
                    Description = o.Description,
                    ContactType = o.ContactType
                }).ToList(),
                OrderDetails = orderDetail.Where(o => o.IdOrder == b.IdOrder).Select(o => new ReconcileBankOrderDetailReturnType()
                {
                    IdOrder = o.IdOrder,
                    IdOrderDetail = o.IdOrderDetail,
                    IdProduct = o.IdProduct,
                    Quantity = o.Quantity,
                    Rate = o.Rate,
                    Description = o.Description
                }).ToList()
            }).ToList());

            return reconcileBankOrderReturnType;
        }
    }
}
