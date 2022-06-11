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

namespace ABSABankStatementReader
{
    [Export(typeof(IBankStatementReader<>))]
    [ExportMetadata("IdBank", "2")]

    public class ABSABankStatementReader<T> : IBankStatementReader<T>
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
            if (lineNo == 3)
            {
                bankStatementStaging.Account = lineContent.Split(',').ToList().Where(l => !String.IsNullOrEmpty(l) && !l.Contains("Account")).FirstOrDefault()?.Replace("'", "");
            }
            else if (lineNo == 7)
            {
                var dateRegex = new Regex("[0-9]{2}/[0-9]{2}/[0-9]{4}", RegexOptions.IgnoreCase);
                lineContent = lineContent.Replace("For Date Ranging From", "").Replace(",", "");
                List<string> dateFromTo = lineContent.Split(new string[] { "To" }, StringSplitOptions.None).ToList();
                string dateFrom = dateFromTo.ElementAtOrDefault(0)?.Trim();
                string dateTo = dateFromTo.ElementAtOrDefault(1)?.Trim();
                if (!string.IsNullOrEmpty(dateFrom) && dateRegex.IsMatch(dateFrom))
                {
                    DateTime _dateFrom;
                    DateTime.TryParseExact(dateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateFrom);
                    bankStatementStaging.BankStatementDateFrom = _dateFrom;
                }
                if (!string.IsNullOrEmpty(dateTo) && dateRegex.IsMatch(dateTo))
                {
                    DateTime _dateTo;
                    DateTime.TryParseExact(dateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _dateTo);
                    bankStatementStaging.BankStatementDateTo = _dateTo;
                }
            }

            else if (lineNo >= 13)
            {
                Regex numberRemoveThousandSeperator = new Regex("\".*?\"");
                lineContent = numberRemoveThousandSeperator.Replace(lineContent, new MatchEvaluator(NumberRemoveThousandSeperatorEvaluator));

                List<string> lineData = lineContent.Split(',').ToList();
                if (lineData.Count() > 0 && !String.IsNullOrEmpty(lineData.ElementAt(0)))
                {
                    //int _lineNo;
                    DateTime _valueDate;
                    double _debitAmount;
                    double _creditAmount;
                    double _balance;
                    BankStatementStagingDetail bankStatementStagingDetail = new BankStatementStagingDetail();

                    DateTime.TryParseExact(lineData.ElementAt(0), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _valueDate);
                    bankStatementStagingDetail.ValueDate = _valueDate;

                    bankStatementStagingDetail.BranchCode = lineData.ElementAt(1)?.Replace("'", "");
                    bankStatementStagingDetail.Remarks = lineData.ElementAt(2)?.Replace("'", "");

                    double.TryParse(lineData.ElementAt(3), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out _debitAmount);
                    bankStatementStagingDetail.DebitAmount = _debitAmount;

                    double.TryParse(lineData.ElementAt(4), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out _creditAmount);
                    bankStatementStagingDetail.CreditAmount = _creditAmount;

                    double.TryParse(lineData.ElementAt(5), System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out _balance);
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
