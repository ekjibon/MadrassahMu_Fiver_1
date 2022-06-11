using CoreWeb.Business.Common;
using ReportManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Report;
using Subscription.Business.Report.Transaction;
using Subscription.Business.ReturnType;
using Subscription.Service;

namespace TransactionReceipt
{
    [Export(typeof(IReportGenerator<>))]
    [ExportMetadata("ReportCode", "5015d08d-8d55-4657-b06c-aed1a56274ce")]
    public class TransactionReceipt<T> : IReportGenerator<T>
    {
        public string GenerateReport(T reportParameter)
        {
            TransactionReceiptDto transactionReceiptDto = (TransactionReceiptDto)(object)reportParameter;

            Dictionary<string, dynamic> reportParameters = new Dictionary<string, dynamic>();

            Dictionary<string, dynamic> dataSource = new Dictionary<string, dynamic>();
            GetTransactionSaleForPrintReturnType getTransactionSaleForPrintReturnType = transactionReceiptDto.GetTransactionSaleForPrintReturnType;
            if (transactionReceiptDto.GetTransactionSaleForPrintReturnType == null)
            {
                getTransactionSaleForPrintReturnType = new TransactionService().GetTransactionSaleForPrint(transactionReceiptDto.IdTransaction).Result;
            }

            dataSource.Add("TransactionReceiptDataset", new List<GetTransactionSaleForPrintReturnType>() { getTransactionSaleForPrintReturnType });
            dataSource.Add("TransactionReceiptDetailDataset", getTransactionSaleForPrintReturnType.TransactionDetails);
            //string reportPath = new ReportGenerator().GenerateReport("1", dataSource, transactionReceiptDto.ReportFormat, reportParameters); //irshad commented parski p fer tro letours. nun met nom raport la direct embas

            string reportPath = "";

            if (getTransactionSaleForPrintReturnType.IdTransactionType == 1)
            {
                reportPath = new ReportGenerator().GenerateReportByName("TransactionReceiptCredit.rdlc", dataSource, transactionReceiptDto.ReportFormat, reportParameters);
            } else if (getTransactionSaleForPrintReturnType.IdTransactionType == 2)
            {
                reportPath = new ReportGenerator().GenerateReportByName("TransactionReceipt.rdlc", dataSource, transactionReceiptDto.ReportFormat, reportParameters);
            }


            return reportPath;
        }
    }
}
