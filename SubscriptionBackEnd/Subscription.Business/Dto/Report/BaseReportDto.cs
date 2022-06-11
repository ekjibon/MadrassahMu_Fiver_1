using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Dto
{
    public class BaseReportDto
    {
        public string ReportName { get; set; }
        public string ReportFormat { get; set; }
        public string ReportCode { get; set; }

        public string DeviceInfo { get; set; }
    }
}
