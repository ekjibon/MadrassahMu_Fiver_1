using Subscription.Business.Common;
using Subscription.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using Subscription.Business.ReturnType;
using Subscription.Data.DaoMapper;
using Subscription.Business.Dto;
using System.Data.Common;
using Subscription.Business;

namespace Subscription.Data.DaoMapper
{
    class TransactionDaoMapper
    {
        public GetEmailForTransactionReturnType MapGetEmailForTransaction(SubscriptionEntities db, DbDataReader reader)
        {
            GetEmailForTransactionReturnType getEmailForTransactionReturnType = new GetEmailForTransactionReturnType();

            List<GetEmailForTransactionQueryTransactionReturnType> emailDetails = ((IObjectContextAdapter)db)
                 .ObjectContext
                 .Translate<GetEmailForTransactionQueryTransactionReturnType>(reader).ToList();

            reader.NextResult();

            List<Person_ContactType> personDetails = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Person_ContactType>(reader).ToList();

            reader.NextResult();

            List<Company_ContactType> companyDetail = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Company_ContactType>(reader).ToList();

            getEmailForTransactionReturnType.Transactions = new BaseListReturnType<GetEmailForTransactionEmailDetailReturnType>();

            getEmailForTransactionReturnType.Transactions.EntityList = emailDetails.GroupBy(g => g.IdTransaction).Select(s => new GetEmailForTransactionEmailDetailReturnType()
            {
                Account = s.FirstOrDefault().Account,
                BankStatementDateFrom = s.FirstOrDefault().BankStatementDateFrom,
                BankStatementDateTo = s.FirstOrDefault().BankStatementDateTo,
                BranchCode = s.FirstOrDefault().BranchCode,
                CreditAmount = s.FirstOrDefault().CreditAmount,
                FullName = s.FirstOrDefault().FullName,
                IdBankStatementStaging = s.FirstOrDefault().IdBankStatementStaging,
                IdBankStatementStagingDetail = s.FirstOrDefault().IdBankStatementStagingDetail,
                IdBankStatementStagingDetailBatch = s.FirstOrDefault().IdBankStatementStagingDetailBatch,
                IdBankStatementStagingState = s.FirstOrDefault().IdBankStatementStagingState,
                IdBankStatementStagingStateBatch = s.FirstOrDefault().IdBankStatementStagingStateBatch,
                IdCompany = s.FirstOrDefault().IdCompany,
                IdCustomer = s.FirstOrDefault().IdCustomer,
                IdCustomerType = s.FirstOrDefault().IdCustomerType,
                IdPerson = s.FirstOrDefault().IdPerson,
                ReceiptNo = s.FirstOrDefault().ReceiptNo,
                Remarks = s.FirstOrDefault().Remarks,
                TransactionDate = s.FirstOrDefault().TransactionDate,
                EmailDetails = s.Where(e => e.EmailAddress != null).Select(e => new GetEmailForTransactionEmailDetailListReturnType()
                {
                    EmailAddress = e.EmailAddress,
                    IdMailToSend = e.IdMailToSend,
                    IdEmailStatus = e.IdEmailStatus
                }).ToList(),
                IdTransaction = s.Key
            }).ToList();

            personDetails.ForEach(p =>
            {
                GetEmailForTransactionEmailDetailReturnType getEmailForTransactionEmailDetailReturnType = getEmailForTransactionReturnType.Transactions.EntityList.Where(e => e.IdPerson == p.IdPerson).FirstOrDefault();
                GetEmailForTransactionEmailDetailListReturnType getEmailForTransactionEmailDetailListReturnType = getEmailForTransactionEmailDetailReturnType.EmailDetails.Where(ed => ed.EmailAddress == p.Description).FirstOrDefault();
                if (getEmailForTransactionEmailDetailListReturnType == null)
                {
                    getEmailForTransactionEmailDetailReturnType.EmailDetails.Add(new GetEmailForTransactionEmailDetailListReturnType()
                    {
                        EmailAddress = p.Description,
                        IdMailToSend = null,
                        IdEmailStatus = null
                    });
                }
            });

            companyDetail.ForEach(c =>
            {
                GetEmailForTransactionEmailDetailReturnType getEmailForTransactionEmailDetailReturnType = getEmailForTransactionReturnType.Transactions.EntityList.Where(e => e.IdCompany == c.IdCompany).FirstOrDefault();
                GetEmailForTransactionEmailDetailListReturnType getEmailForTransactionEmailDetailListReturnType = getEmailForTransactionEmailDetailReturnType.EmailDetails.Where(ed => ed.EmailAddress == c.Description).FirstOrDefault();
                if (getEmailForTransactionEmailDetailListReturnType == null)
                {
                    getEmailForTransactionEmailDetailReturnType.EmailDetails.Add(new GetEmailForTransactionEmailDetailListReturnType()
                    {
                        EmailAddress = c.Description,
                        IdMailToSend = null,
                        IdEmailStatus = null
                    });
                }
            });

            return getEmailForTransactionReturnType;
        }

        public List<GetTransactionSaleForPrintReturnType> MapGetTransactionSaleForPrint(SubscriptionEntities db, DbDataReader reader)
        {
            List<GetTransactionSaleForPrintReturnType> getTransactionSaleForPrintReturnTypes = new List<GetTransactionSaleForPrintReturnType>();

            List<GetTransactionSaleForPrintQueryReturnType> transactions = ((IObjectContextAdapter)db)
                 .ObjectContext
                 .Translate<GetTransactionSaleForPrintQueryReturnType>(reader).ToList();


            transactions.GroupBy(t => t.IdTransaction).ToList().ForEach(t =>
            {
                GetTransactionSaleForPrintReturnType getTransactionSaleForPrintReturnType = new GetTransactionSaleForPrintReturnType();
                getTransactionSaleForPrintReturnType.IdTransaction = t.Key;
                getTransactionSaleForPrintReturnType.Address = t.FirstOrDefault().Address;
                getTransactionSaleForPrintReturnType.ChequeNo = t.FirstOrDefault().ChequeNo;
                getTransactionSaleForPrintReturnType.CustomerName = t.FirstOrDefault().FullName;
                getTransactionSaleForPrintReturnType.Date = t.FirstOrDefault().TransactionDate;
                getTransactionSaleForPrintReturnType.EmailAddresses = new List<string>();
                getTransactionSaleForPrintReturnType.PaymentMethod = t.FirstOrDefault().PaymentMethod;
                getTransactionSaleForPrintReturnType.ReceiptNo = t.FirstOrDefault().ReceiptNo;
                getTransactionSaleForPrintReturnType.Total = t.FirstOrDefault().TotalAmount;
                getTransactionSaleForPrintReturnType.TransactionDate = t.FirstOrDefault().TransactionDate;
                getTransactionSaleForPrintReturnType.TransactionDetails = t.Select(td => new GetTransactionSaleForPrintTransactionDetailReturnType
                {
                    Amount = td.Amount,
                    Description = td.TransactionDescription,
                    Name = td.ProductName,
                    Quantity = td.Quantity,
                    Rate = td.Rate
                }).ToList();
                getTransactionSaleForPrintReturnTypes.Add(getTransactionSaleForPrintReturnType);
            });

            return getTransactionSaleForPrintReturnTypes;
        }


        public GetTransactionTotalForDateReturnType GetTransactionTotalForDate(SubscriptionEntities db, DbDataReader reader)
        {
            GetTransactionTotalForDateReturnType getTransactionTotalForDateReturnType = new GetTransactionTotalForDateReturnType();
            getTransactionTotalForDateReturnType.TransactionGroup = new List<GetTransactionTotalForDateTransactionGroupReturnType>();

            List<TransactionTotalForDateAmountQueryReturnType> transactionTotalForDateAmountQueryReturnType = ((IObjectContextAdapter)db)
                 .ObjectContext
                 .Translate<TransactionTotalForDateAmountQueryReturnType>(reader).ToList();

            reader.NextResult();

            TransactionTotalForDateUserQueryReturnType transactionTotalForDateUserQueryReturnType = ((IObjectContextAdapter)db)
             .ObjectContext
             .Translate<TransactionTotalForDateUserQueryReturnType>(reader).FirstOrDefault();

            transactionTotalForDateAmountQueryReturnType.ForEach(t =>
            {
                GetTransactionTotalForDateTransactionGroupReturnType getTransactionTotalForDateTransactionGroupReturnType = new GetTransactionTotalForDateTransactionGroupReturnType()
                {
                    Amount = t.TotalAmount.Value,
                    PaymentType = t.TransactionPaymentType,
                    ReceiptNo = t.ReceiptNo, 
                    TransactionDate = t.TransactionDate
                };
                getTransactionTotalForDateReturnType.TransactionGroup.Add(getTransactionTotalForDateTransactionGroupReturnType);
            });
            getTransactionTotalForDateReturnType.User = transactionTotalForDateUserQueryReturnType.User;

            return getTransactionTotalForDateReturnType;
        }
    }
}
