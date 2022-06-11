using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Custom
{
    public class DateGenerator
    {
        public List<DateTime> GenerateDaily(DateTime startDate, DateTime endDate)
        {
            var dates = new List<DateTime>();
            var differenceBetween2Dates = endDate - startDate;
            dates.AddRange(Enumerable.Range(0, differenceBetween2Dates.Days + 1)
                .Select(i => startDate.AddDays(i))
                .ToList());

            return dates;
        }

        public List<DateTime> GenerateWeekly(DateTime startDate, DateTime endDate, int recurEvery, List<int> applicableDaysIndex)
        {
            var dates = new List<DateTime>();
            var differenceBetween2Dates = endDate - startDate;
            dates.AddRange(Enumerable.Range(0, differenceBetween2Dates.Days + 1)
                .Select(i => startDate.AddDays(i))
                .Where(d => ((int)(d - startDate).Days / 7) % recurEvery == 0)
                .Where(d => applicableDaysIndex.Contains((int)d.DayOfWeek))
                .ToList());

            return dates;
        }

        /*public List<DateTime> GenerateMonthly(DateTime startDate, DateTime endDate, List<int> applicableMonthsIndex, List<int> applicableDatesInMonths, bool applicableOnLastDayOfMonth = false)
        {
            var dates = new List<DateTime>();
            var differenceBetween2Dates = endDate - startDate;
            dates.AddRange(Enumerable.Range(0, differenceBetween2Dates.Days + 1)
                .Select(i => startDate.AddDays(i))
                .Where(d => applicableMonthsIndex.Contains((int)d.Month))
                .Where(d => (applicableDatesInMonths.Contains((int)d.Day)) && (!applicableOnLastDayOfMonth && (d.AddDays(1).Month != d.Month)))

                .ToList());

            return dates;
        }*/

        public List<DateTime> GenerateMonthly(DateTime startDate, DateTime endDate, List<int> applicableMonthsIndex, List<int> applicableDatesInMonths, bool applicableOnLastDayOfMonth = false)
        {
            var dates = new List<DateTime>();
            var differenceBetween2Dates = endDate - startDate;
            dates.AddRange(Enumerable.Range(0, differenceBetween2Dates.Days + 1)
                .Select(i => startDate.AddDays(i))
                .Where(d => applicableMonthsIndex.Contains((int)d.Month))
                .Where(
                        d =>
                        (applicableDatesInMonths.Contains((int)d.Day))
                        && (!applicableOnLastDayOfMonth || (d.AddDays(1).Month != d.Month))
                       )

                .ToList());

            return dates;
        }
    }
}
