using CoreWeb.Business.Common;
using ReportManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Dto;
using Subscription.Business.Report;
using Subscription.Business.Report.Transaction;
using Subscription.Business.ReturnType;
using Subscription.Service;
using System.Data;
using System.ComponentModel;
using System.IO;
using Subscription.Business.Utils;
using OfficeOpenXml;

namespace DailyUserSaleReport
{
    [Export(typeof(IReportGenerator<>))]
    [ExportMetadata("ReportCode", "8092807d-065b-40be-9693-955bfd5698be")]
    public class DailyUserSaleReport<T> : IReportGenerator<T>
    {
        public string GenerateReport(T reportParameter)
        {
            GetTransactionTotalForDateDto getTransactionTotalForDateDto = (GetTransactionTotalForDateDto)(object)reportParameter;

            Dictionary<string, dynamic> reportParameters = new Dictionary<string, dynamic>();

            Dictionary<string, dynamic> dataSource = new Dictionary<string, dynamic>();
            GetTransactionTotalForDateReturnType getTransactionTotalForDateReturnType = new TransactionService().GetTransactionTotalForDate(getTransactionTotalForDateDto).Result;

            dataSource.Add("TransactionTotalForDateDateset", getTransactionTotalForDateReturnType.TransactionGroup);
            dataSource.Add("TransactionTotalForDateParamaterDateset", new List<GetTransactionTotalForDateReturnType>()
            {
                new GetTransactionTotalForDateReturnType()
                {
                    Date = getTransactionTotalForDateReturnType.Date, User = getTransactionTotalForDateReturnType.User
                }
            });

            //string reportPath = new ReportGenerator().GenerateReport("5", dataSource, "PDF", reportParameters); 
            // string reportPath = new ReportGenerator().GenerateReportByName("DailyUserSaleReport.rdlc", dataSource, "PDF", reportParameters);

            PropertyDescriptorCollection props1 = TypeDescriptor.GetProperties(typeof(GetTransactionTotalForDateReturnType));
            PropertyDescriptorCollection props2 = TypeDescriptor.GetProperties(typeof(GetTransactionTotalForDateTransactionGroupReturnType));
            DataTable dt = new DataTable();


           
           dt.Columns.Add("Date", typeof(DateTime)); 
           dt.Columns.Add("User", typeof(string)); 
           dt.Columns.Add("Receipt No", typeof(string)); 
           dt.Columns.Add("Amount", typeof(double)); 
           dt.Columns.Add("Payment Type", typeof(string)); 


            getTransactionTotalForDateReturnType.TransactionGroup.ForEach(tg =>
            {
                DataRow r = dt.NewRow();
                r["User"] = getTransactionTotalForDateReturnType.User;
                r["Date"] = getTransactionTotalForDateReturnType.Date;
                r["Receipt No"] = tg.ReceiptNo;
                r["Amount"] = Convert.ToDouble(tg.Amount);
                r["Payment Type"] = tg.PaymentType;

                dt.Rows.Add(r);
            });

            //DataRow chequeRow = dt.NewRow();
            //var sum = dt.AsEnumerable().Where(row => row.Field<string>("Payment Type").Equals("Cheque")).Sum(row => row.Field<double>("Amount"));
            //chequeRow[3] = sum;
            //dt.Rows.Add(chequeRow);

            //DataRow cashRow = dt.NewRow();
            //var cash_sum = dt.AsEnumerable().Where(row => row.Field<string>("Payment Type").Equals("Cash")).ToList();
            //cashRow[3] = cash_sum;
            //dt.Rows.Add(cashRow);


            string outputFilePath = Path.Combine(ConfigAccess.GetConfigByName("filesFolder"), ConfigAccess.GetConfigByName("generatedFiles"));
            string filePath = outputFilePath + "/" + Guid.NewGuid().ToString() + ".xlsx";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                using(ExcelPackage package = new ExcelPackage())
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Transactions");
                    ws.Cells["A1"].LoadFromDataTable(dt, true);
                    package.SaveAs(fileStream);
                }
            }

            //FileStream fs = new FileStream(outputFilePath, FileMode.Open, FileAccess.Read);

            return filePath;
        }
    }
}