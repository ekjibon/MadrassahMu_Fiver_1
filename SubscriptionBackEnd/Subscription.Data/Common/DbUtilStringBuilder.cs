using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data.Common
{
   public  class DbUtilStringBuilder
    {
        public static string BuildSortString(string column, Enum order)
        {
            return column + " " + order.ToString().ToLower();
        }
    }
}
