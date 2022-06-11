using Subscription.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Business.Report
{
    public static class ReportParameterMapper<T> where T : BaseReportDto
    {
        public static ReportParameter Map(T rawParameter)
        {
            //ReportParameter rp = new ReportParameter() { ReportCode = rawParameter.ReportCode, IdReportFormat = rawParameter.IdReportFormat, ReportName = rawParameter.ReportName };

            return null;
        }
    }
}
