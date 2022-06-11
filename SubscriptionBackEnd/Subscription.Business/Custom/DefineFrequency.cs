using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Custom
{
    public class DefineFrequency
    {
        public long Frequency { get; set; }
        public String RecurEvery { get; set; }
        public String WeeklyDaysSelected { get; set; }
        public String SelectedMonths { get; set; }
        public String SelectedMonthlyDays { get; set; }
        public String SelectedMonthlyEvery { get; set; }
        public String SelectedMonthlyDates { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
