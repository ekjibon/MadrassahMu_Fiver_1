using Subscription.Business;
using Subscription.Business.Enums;
using Subscription.Business.Utils;
using Subscription.Service;
using ReportManager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager
{
    public class ReportGenerator
    {
        public string GenerateReport(string reportCode, Dictionary<string, dynamic> datasource, string reportFormat,Dictionary<string,dynamic> reportParameters = null)
        {
            string reportTemplatePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("reportTemplate"), GetReportTemplate(reportCode));
            string outputFilePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("generatedFiles"));
            return ReportManager.ExportReport(datasource,reportTemplatePath,outputFilePath, reportFormat, reportParameters);
        }

        public string GenerateReportByName(string reportName, Dictionary<string, dynamic> datasource, string reportFormat, Dictionary<string, dynamic> reportParameters = null)
        {
            string reportTemplatePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("reportTemplate"), reportName);
            string outputFilePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("generatedFiles"));
            return ReportManager.ExportReport(datasource, reportTemplatePath, outputFilePath, reportFormat, reportParameters);
        }

        public string GenerateExcelReport(string reportCode, List<ExcelTemplateWorksheet> excelTemplateWorksheets)
        {
            string reportTemplatePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("reportTemplate"), GetReportTemplate(reportCode));
            string outputFilePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("generatedFiles"));
            return ReportManager.ExportExcelTemplate(excelTemplateWorksheets, reportTemplatePath, outputFilePath);
        }

        private string GetReportTemplate(string code)
        {
            long idDocument = long.Parse(code);
            Expression<Func<Document, bool>> expression = p => p.IsDeactivated != true && p.IdDocument == idDocument;

            Document document = new DocumentService().GetDocumentCustom(expression).Result;

            return document.FileName;
        }
    }
}