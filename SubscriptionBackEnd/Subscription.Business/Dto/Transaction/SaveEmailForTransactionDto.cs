using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class SaveEmailForTransactionDto
    {
        public List<SaveEmailForTransactionDetailDto> Transactions { get; set; }
    }

    public class SaveEmailForTransactionDetailDto
    {
        public long IdTransaction { get; set; }
        public List<string> Emails { get; set; }
    }

}

