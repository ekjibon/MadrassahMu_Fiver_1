using System;
using Subscription.Business;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Data.EntityFramework;
using Subscription.Business.Common;
using System.Linq.Expressions;
using Subscription.Business.ExtensionMethod;
using System.Linq.Dynamic;
using Subscription.Data.Common;
using System.Data.SqlClient;
using Subscription.Business.Dto;

namespace Subscription.Data
{
    public partial class TemporaryTransactionDao : ITemporaryTransactionDao
    {
        public List<TemporaryTransaction> SaveBulkTemporaryTransaction(List<TemporaryTransaction> temporaryTransactions)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return SaveBulkTemporaryTransaction(db, temporaryTransactions);
            }
        }

        public List<TemporaryTransaction> SaveBulkTemporaryTransaction(SubscriptionEntities db, List<TemporaryTransaction> temporaryTransactions)
        {
            db.TemporaryTransactions.AddRange(temporaryTransactions);
            db.SaveChanges();

            return temporaryTransactions;
        }

        public bool ProcessTemporaryTransactionForBankStatement(long idBatch)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return ProcessTemporaryTransactionForBankStatement(db, idBatch);
            }
        }

        public bool ProcessTemporaryTransactionForBankStatement(SubscriptionEntities db, long idBatch)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@IdBatch",  Value =  (object) idBatch, Direction = System.Data.ParameterDirection.Input},
            };

            db.Database.ExecuteSqlCommand("EXEC [dbo].[ProcessTemporaryTransactionForBankStatement] @IdBatch", sqlParams);
            return true;
        }

        public void DeleteTemporaryTransactionForBankStatement(long idBankStatementStaging)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                DeleteTemporaryTransactionForBankStatement(db, idBankStatementStaging);
            }
        }

        public void DeleteTemporaryTransactionForBankStatement(SubscriptionEntities db, long idBankStatementStaging)
        {
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@IdBankStatementStaging",  Value =  (object) idBankStatementStaging, Direction = System.Data.ParameterDirection.Input},
            };

            db.Database.ExecuteSqlCommand("EXEC [dbo].[DeleteTemporaryTransactionForBankStatement] @IdBankStatementStaging", sqlParams);
        }
    }
}