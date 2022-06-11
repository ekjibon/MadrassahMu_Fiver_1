using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Dto;
using Subscription.Business.ReturnType;

namespace Subscription.Business.Report.Transaction
{
    public class TransactionReceiptDto : BaseReportDto
    {
        public long IdTransaction { get; set; }

        public GetTransactionSaleForPrintReturnType GetTransactionSaleForPrintReturnType { get; set; }
    }
}