using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class GetTransactionTotalForDateDto : BaseReportDto
    {
        public long IdUser { get; set; }
        public DateTime Date { get; set; }
    }
}
