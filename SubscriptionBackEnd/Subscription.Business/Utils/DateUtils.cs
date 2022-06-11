using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Utils
{
    public static class DateUtils
    {
        public static string GetDateDifference(DateTime dateFrom, DateTime? dateTo = null)
        {
            if (!dateTo.HasValue)
            {
                dateTo = DateTime.Now;
            }

            TimeSpan dateDiffTimeSpan = dateTo.Value.Subtract(dateFrom);
            var dateDiff = new DateTime(dateDiffTimeSpan.Ticks);
            string dateDiffString = +dateDiff.Year + " year(s)";
            if (dateDiff.Month > 0)
                dateDiffString += " " + dateDiff.Month + " month(s)";
            return dateDiffString;
        }
    }
}
