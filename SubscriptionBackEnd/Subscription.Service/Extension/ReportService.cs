using CoreWeb.Business.Common;
using Subscription.Business.Dto;
using Subscription.Business.Report;
using Subscription.Service.MEFLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.ReturnType;

namespace Subscription.Service
{
    public partial class ReportService : BaseService
    {
        public BusinessResponse<BaseReportReturnType> GenerateReport(Object reportParameter)
        {
            BusinessResponse<BaseReportReturnType> response = new BusinessResponse<BaseReportReturnType>();
            try
            {
                response.Result = GenerateReportRaw(reportParameter);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex);
            }
            return response;
        }

        internal BaseReportReturnType GenerateReportRaw(dynamic reportParameter)
        {
            ReportInitializer<Object> reportInitializer = new ReportInitializer<Object>();

            var report = reportInitializer.reports.Where(r => r.Metadata.ReportCode == reportParameter.ReportCode).FirstOrDefault();
            if(report != null)
            {
                string reportPath = report.Value.GenerateReport(reportParameter);
                var fileName = Path.GetFileNameWithoutExtension(reportPath);
                var fileExtension = Path.GetExtension(reportPath);
                var fileNameWithExtension = Path.GetFileName(reportPath);
                var reportName = String.Format("{0}{1}", reportParameter.ReportName, fileExtension);
                return new BaseReportReturnType() { FileName = fileName, FileExtension = fileExtension, FilePath = reportPath, FileNameWithExtension = fileNameWithExtension, ReportName = reportName };
            } else
            {
                throw new Exception();
            }
            
        }
    }
}
