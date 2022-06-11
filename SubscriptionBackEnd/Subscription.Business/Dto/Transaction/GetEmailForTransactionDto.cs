using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Common;

namespace Subscription.Business.Dto
{
    public class GetEmailForTransactionDto : SortingPagingInfo
    {
        public long? IdBankStatementStaging { get; set; }
        public long? IdBankStatementStagingDetailBatch { get; set; }
        public string ReceiptNo { get; set; }
    }
}
