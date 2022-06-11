using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business.Dto;
using Subscription.Business.ReturnType;
using Subscription.Data.EntityFramework;

namespace Subscription.Data
{
    public partial interface ITransactionDao
    {
        GetEmailForTransactionReturnType GetEmailForTransaction(GetEmailForTransactionDto getEmailForTransactionDto);
        GetEmailForTransactionReturnType GetEmailForTransaction(GetEmailForTransactionDto getEmailForTransactionDto, SubscriptionEntities db);

        List<GetTransactionSaleForPrintReturnType> GetTransactionSaleForPrint(List<long> idTransactions);
        List<GetTransactionSaleForPrintReturnType> GetTransactionSaleForPrint(List<long> idTransactions, SubscriptionEntities db);

        GetTransactionTotalForDateReturnType GetTransactionTotalForDate(long IdUser,DateTime date);
        GetTransactionTotalForDateReturnType GetTransactionTotalForDate(long IdUser, DateTime date, SubscriptionEntities db);
    }
}
