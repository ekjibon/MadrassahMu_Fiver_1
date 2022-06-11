using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;

namespace Subscription.Business.ReturnType
{
    public class GetEmailForTransactionReturnType
    {
        public BaseListReturnType<GetEmailForTransactionEmailDetailReturnType> Transactions { get; set; }
    }

    public class GetEmailForTransactionEmailDetailReturnType
    {
        public long? IdTransaction { get; set; }
        public string ReceiptNo { get; set; }
        public long? IdCustomer { get; set; }
        public long? IdCustomerType { get; set; }
        public long? IdPerson { get; set; }
        public long? IdCompany { get; set; }
        public DateTime TransactionDate { get; set; }
        public string FullName { get; set; }
        public long? IdBankStatementStaging { get; set; }
        public string Account { get; set; }
        public DateTime? BankStatementDateFrom { get; set; }
        public DateTime? BankStatementDateTo { get; set; }
        public long? IdBankStatementStagingState { get; set; }
        public string Remarks { get; set; }
        public string BranchCode { get; set; }
        public double? CreditAmount { get; set; }
        public long? IdBankStatementStagingDetail { get; set; }
        public long? IdBankStatementStagingDetailBatch { get; set; }
        public long? IdBankStatementStagingStateBatch { get; set; }
        public List<GetEmailForTransactionEmailDetailListReturnType> EmailDetails { get; set; }
    }

    public class GetEmailForTransactionEmailDetailListReturnType
    {
        public long? IdMailToSend { get; set; }
        public long? IdEmailStatus { get; set; }
        public string EmailAddress { get; set; }
    }
}
