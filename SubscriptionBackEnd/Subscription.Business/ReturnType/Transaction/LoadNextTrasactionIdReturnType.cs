using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.ReturnType
{
    public class LoadNextTrasactionIdReturnType
    {
        public long? NextIdTransaction { get; set; }
        public long? PreviousIdTransaction { get; set; }
    }
}
