using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Report
{
    public class ReportParameter
    {
        public string ReportName { get; set; }
        public long IdReportFormat{ get; set; }
        public string ReportCode { get; set; }
        public Dictionary<string, string> ReportParameters { get; set; }

    }
}
