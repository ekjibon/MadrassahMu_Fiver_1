using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using ReportManager.Model;

namespace ReportManager
{
    public static class ReportManager
    {

        public static string ExportExcelTemplate(List<ExcelTemplateWorksheet> excelTemplateWorksheets, string fullReportPath, string outputFilePath)
        {
            ExcelPackage excelPackage = new ExcelPackage(new FileInfo(fullReportPath));
            excelTemplateWorksheets.OrderBy(tw => tw.WorksheetNumber).ToList().ForEach(tw =>
            {
                ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets[tw.WorksheetNumber];
                tw.ExcelTemplateDatas.ForEach(etd => {
                    excelWorksheet.Cells[etd.Cell].Value = etd.Value;
                });
            });


            string outputFilePathWithFileName = GetFilePath(outputFilePath, "EXCELOPENXML");
            excelPackage.SaveAs(new FileInfo(outputFilePathWithFileName));

            return outputFilePathWithFileName;
        }
        public static string ExportReport(Dictionary<string, dynamic> reportDataSource, string fullReportPath, string outputFilePath, string fileFormat, Dictionary<string, dynamic> reportParameters = null)
        {
            string reportPath = null;
            LocalReport localReport = new LocalReport();
            localReport.EnableExternalImages = true;

            localReport.ReportPath = fullReportPath;

            List<ReportDataSource> dsList = new List<ReportDataSource>();

            foreach (KeyValuePair<string, dynamic> entry in reportDataSource)
            {
                var dataset = new ReportDataSource(entry.Key);
                dataset.Value = entry.Value;
                dsList.Add(dataset);
            }

            if (reportParameters != null)
            {
                var parameters = new List<ReportParameter>();
                foreach (KeyValuePair<string, dynamic> entry in reportParameters)
                {
                    var dataset = new ReportParameter(entry.Key, entry.Value);
                    parameters.Add(dataset);
                }
                reportPath = ExportReport(localReport, dsList, outputFilePath, fileFormat, parameters);
            }
            else
            {
                reportPath = ExportReport(localReport, dsList, outputFilePath, fileFormat);
            }
            return reportPath;
        }

        private static string ExportReport(LocalReport localReport, List<ReportDataSource> dsList, string outputFilePath, string fileFormat, List<ReportParameter> reportParameters = null)
        {
            dsList.ForEach((ds1) =>
            {
                localReport.DataSources.Add(ds1);
            });

            if (reportParameters != null)
            {
                localReport.SetParameters(reportParameters);
            }

            string outputFilePathWithFileName = GetFilePath(outputFilePath, fileFormat);

            byte[] bytes = localReport.Render(fileFormat);

            FileStream fileStream = new FileStream(outputFilePathWithFileName, FileMode.Create, FileAccess.Write);
            fileStream.Write(bytes, 0, bytes.Length);
            fileStream.Close();
            return outputFilePathWithFileName;
        }

        private static string GetFilePath(string outputFilePath, string fileFormat)
        {
            String filename = String.Format("{0}_{1}", Guid.NewGuid(), DateTime.Now.ToString("yyyyMMdd_HH_mm_ss_ms"));

            string extension = "";
            if (fileFormat == "PDF")
                extension = "pdf";
            else if (fileFormat == "EXCEL")
                extension = "xls";
            else if (fileFormat == "IMAGE")
                extension = "jpg";
            else if (fileFormat == "WORD")
                extension = "doc";
            else if (fileFormat == "WORDOPENXML")
                extension = "docx";
            else if(fileFormat == "EXCELOPENXML")
                extension = "xlsx";

            string outputFilePathWithFileName = Path.Combine(outputFilePath, string.Format("{0}.{1}", filename, extension));

            String exportDir = Path.GetDirectoryName(outputFilePathWithFileName);
            if (!Directory.Exists(exportDir))
                Directory.CreateDirectory(exportDir);

            return outputFilePathWithFileName;
        }

    }
}