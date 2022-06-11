using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class LoadBankReconciliationContentDto
    {
        public long IdBank { get; set; }
        public Document Document { get; set; }
    }
}
