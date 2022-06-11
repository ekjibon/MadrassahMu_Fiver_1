using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.BankStatementReader;
using Subscription.Service;

namespace SBMBankStatementReader
{
    [Export(typeof(IBankStatementReader<>))]
    [ExportMetadata("IdBank", "1")]
    public class SBMBankStatementReader<T> : IBankStatementReader<T>
    {
        public BankStatementStaging ProcessStatement(T reportParameter)
        {
            Document document = (Document)(object)reportParameter;

            BusinessResponse<string> physicalDocumentRepositoryPath = ServiceFactory.Instance.DocumentService.GetPhysicalDocumentRepositoryPath();
            string documentPath = Path.Combine(physicalDocumentRepositoryPath.Result, document.PhysicalFilePath);

            BankStatementStaging bankStatementStaging = new BankStatementStaging();
            bankStatementStaging.UploadDate = DateTime.Now;
            bankStatementStaging.BankStatementStagingDetails = new List<BankStatementStagingDetail>();

            using (var reader = new StreamReader(File.OpenRead(documentPath)))
            {
                int lineNumber = 0;
                while (!reader.EndOfStream)
                {
                    var lineContent = reader.ReadLine();
                    bankStatementStaging = GetContentAtLine(lineNumber, lineContent, bankStatementStaging);
                    lineNumber += 1;
                }
            }

            return bankStatementStaging;
        }

        public BankStatementStaging GetContentAtLine(int lineNo, string lineContent, BankStatementStaging bankStatementStaging)
        {
            if (lineNo == 0)
            {
                bankStatementStaging.Account = lineContent.Split(',').ToList().Where(l => !String.IsNullOrEmpty(l) && !l.Contains("Account")).FirstOrDefault();
            }
            else if (lineNo == 1)
            {
                var dateRegex = new Regex("[0-9]{2}-[0-9]{2}-[0-9]{4}", RegexOptions.IgnoreCase);
                string dateFrom = lineContent.Split(',').ToList().Where(l => !String.IsNullOrEmpty(l) && dateRegex.IsMatch(l)).FirstOrDefault();
                DateTime _dateFrom;
                DateTime.TryParseExact(dateFrom, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateFrom);
                bankStatementStaging.BankStatementDateFrom = _dateFrom;
            }
            else if (lineNo == 2)
            {
                var dateRegex = new Regex("[0-9]{2}-[0-9]{2}-[0-9]{4}", RegexOptions.IgnoreCase);
                string dateTo = lineContent.Split(',').ToList().Where(l => !String.IsNullOrEmpty(l) && dateRegex.IsMatch(l)).FirstOrDefault();
                DateTime _dateTo;
                DateTime.TryParseExact(dateTo, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateTo);
                bankStatementStaging.BankStatementDateTo = _dateTo;
            }
            else if (lineNo >= 6)
            {

                Regex numberRemoveThousandSeperator = new Regex("\".*?\"");
                lineContent = numberRemoveThousandSeperator.Replace(lineContent, new MatchEvaluator(NumberRemoveThousandSeperatorEvaluator));

                List<string> lineData = lineContent.Split(',').ToList();
                if (lineData.Count() > 0 && !String.IsNullOrEmpty(lineData.ElementAt(1)))
                {
                    //int _lineNo;
                    DateTime _valueDate;
                    double _debitAmount;
                    double _creditAmount;
                    double _balance;
                    BankStatementStagingDetail bankStatementStagingDetail = new BankStatementStagingDetail();

                    //int.TryParse(lineData.ElementAt(0), out _lineNo);
                    //bankStatementStagingDetail.StatementLineNo = _lineNo;

                    DateTime.TryParseExact(lineData.ElementAt(2), "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _valueDate);
                    bankStatementStagingDetail.ValueDate = _valueDate;

                    bankStatementStagingDetail.BranchCode = lineData.ElementAt(3);
                    bankStatementStagingDetail.Remarks = lineData.ElementAt(4);

                    double.TryParse(lineData.ElementAt(5), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out _debitAmount);
                    bankStatementStagingDetail.DebitAmount = _debitAmount;

                    double.TryParse(lineData.ElementAt(6), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out _creditAmount);
                    bankStatementStagingDetail.CreditAmount = _creditAmount;

                    double.TryParse(lineData.ElementAt(7), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out _balance);
                    bankStatementStagingDetail.Balance = _balance;

                    bankStatementStaging.BankStatementStagingDetails.Add(bankStatementStagingDetail);
                }
            }
            return bankStatementStaging;
        }

        public string NumberRemoveThousandSeperatorEvaluator(Match m)
        {
            return m.Groups[0].Value.Replace(",", "").Replace("\"", "");
        }

    }
}
