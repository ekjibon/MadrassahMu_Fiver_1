using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class ExecuteExternalTransitionDto
    {
        public string Token { get; set; }
        public object JsonContentToPass { get; set; }
    }
}
