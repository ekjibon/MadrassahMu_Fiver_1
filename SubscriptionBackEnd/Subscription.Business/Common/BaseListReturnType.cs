using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Common
{
    public class BaseListReturnType<T>
    {
        public List<T> EntityList { get; set; }
        public int TotalCount { get; set; }
    }
}
