using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType.BankReconciliation
{
    public class ReconcileBankOrderReturnType
    {
        public List<ReconcileBankOrderStagingDetailReturnType> StagingDetails { get; set; }
    }
    public class ReconcileBankOrderStagingDetailReturnType
    {
        public long IdBankStatementStagingDetail { get; set; }
        public DateTime? ValueDate { get; set; }
        public string BranchCode { get; set; }
        public string Remarks { get; set; }
        public double DebitAmount { get; set; }
        public double CreditAmount { get; set; }
        public double Balance { get; set; }
        public long? IdOrder { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public long? IdOrderConcept { get; set; }
        public long? IdOrderCompany { get; set; }
        public long? IdOrderPerson { get; set; }
        public long? IdBankReconOrderType { get; set; }
        public string OrderConceptName { get; set; }
        public List<ReconcileBankOrderDetailReturnType> OrderDetails { get; set; }
        public List<ReconcileBankOrderContactTypeReturnType> ContactTypes { get; set; }
        public List<ReconcileBankOrderAddressReturnType> Addresses { get; set; }

    }
    public class ReconcileBankOrderDetailReturnType
    {
        public long IdOrderDetail { get; set; }
        public long IdOrder { get; set; }
        public long IdProduct { get; set; }
        public double? Quantity { get; set; }
        public double? Rate { get; set; }
        public string Description { get; set; }
    }
    public class ReconcileBankOrderContactTypeReturnType
    {
        public string ContactType { get; set; }
        public string Description { get; set; }
    }

    public class ReconcileBankOrderAddressReturnType
    {
        public string Address { get; set; }
    }
}
