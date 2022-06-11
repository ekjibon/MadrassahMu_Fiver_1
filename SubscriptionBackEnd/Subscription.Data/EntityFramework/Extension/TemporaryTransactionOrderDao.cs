using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Dto;
using Subscription.Data.EntityFramework;
using Subscription.Business.ReturnType;

namespace Subscription.Data
{
    public partial class TemporaryTransactionOrderDao : ITemporaryTransactionOrderDao
    {
        public TemporaryTransactionOrder GetTemporaryTransactionOrderForWorkstation(string idWorkstation)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetTemporaryTransactionOrderForWorkstation(idWorkstation, db);
            }
        }

        public TemporaryTransactionOrder GetTemporaryTransactionOrderForWorkstation(string idWorkstation, SubscriptionEntities db)
        {
            var sqlParams = new SqlParameter[]
            {
               new SqlParameter { ParameterName = "@IdWorkstation",  Value =  (object) idWorkstation, Direction = System.Data.ParameterDirection.Input},
            };

            TemporaryTransactionOrder temporaryTransactionSignature = db.Database.SqlQuery<TemporaryTransactionOrder>("EXEC [dbo].[GetTemporaryTransactionOrderForWorkstation] @IdWorkstation", sqlParams).FirstOrDefault();

            return temporaryTransactionSignature;
        }
    }
}
