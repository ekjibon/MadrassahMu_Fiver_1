using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Custom
{
    public class RequestWorkflowToken
    {
        public long IdWorkflowTransition { get; set; }
        public long IdRequest { get; set; }
        public long IdUser { get; set; }
    }
}
