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
using Subscription.Business.ReturnType.BankReconciliation;
using Subscription.Data.DaoMapper;
using System.Data;

namespace Subscription.Data
{
    public partial class BankReconciliationDao : IBankReconciliationDao
    {
        private EntityFramework.SubscriptionEntities _db;
        public BankReconciliationDao()
        {

        }

        public BankReconciliationDao(EntityFramework.SubscriptionEntities db)
        {
            _db = db;
        }

        public List<BankStatementStagingHit> ReconcialeBankStatement(long idBankStatementStaging, long idBatch)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return ReconcialeBankStatement(idBankStatementStaging, idBatch, db);
            }
        }

        public List<BankStatementStagingHit> ReconcialeBankStatement(long idBankStatementStaging, long idBatch, SubscriptionEntities db)
        {
            var sqlParams = new SqlParameter[]
            {
               new SqlParameter { ParameterName = "@IdBankStatementStaging",  Value =  (object) idBankStatementStaging, Direction = System.Data.ParameterDirection.Input},
               new SqlParameter { ParameterName = "@IdBatch",  Value =  (object) idBatch, Direction = System.Data.ParameterDirection.Input}
            };

            List<BankStatementStagingHit> bankStatementStagingHits = db.Database.SqlQuery<BankStatementStagingHit>("EXEC [dbo].[ReconcileBankStatement] @IdBankStatementStaging, @IdBatch", sqlParams).ToList();


            return bankStatementStagingHits;
        }

        public List<BankStatementStagingDetailBatch> GetBatchesForBankStatmentStaging(long idBankStatementStaging)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetBatchesForBankStatmentStaging(idBankStatementStaging, db);
            }
        }

        public List<BankStatementStagingDetailBatch> GetBatchesForBankStatmentStaging(long idBankStatementStaging, SubscriptionEntities db)
        {
            var sqlParams = new SqlParameter[]
            {
               new SqlParameter { ParameterName = "@IdBankStatementStaging",  Value =  (object) idBankStatementStaging, Direction = System.Data.ParameterDirection.Input},
            };

            List<BankStatementStagingDetailBatchData> bankStatementStagingDetaildata = db.Database.SqlQuery<BankStatementStagingDetailBatchData>("EXEC [dbo].[GetBatchesForBankStatmentStaging] @IdBankStatementStaging", sqlParams).ToList();

            List<BankStatementStagingDetailBatch> bankStatementStagingDetailBatches = new List<BankStatementStagingDetailBatch>();
            bankStatementStagingDetaildata.ToList().ForEach(b =>
            {
                BankStatementStagingDetailBatch bankStatementStagingDetailBatch = new BankStatementStagingDetailBatch()
                {
                    BankStatementStagingState = new BankStatementStagingState() { Description = b.State, IdBankStatementStagingState = b.IdBankStatementStagingState },
                    IdBankStatementStagingDetailBatch = b.IdBankStatementStagingDetailBatch,
                    IdBankStatementStagingState = b.IdBankStatementStagingState,
                    BatchNumber = b.BatchNumber
                };
                bankStatementStagingDetailBatches.Add(bankStatementStagingDetailBatch);
            });

            return bankStatementStagingDetailBatches;
        }

        public ReconcileBankOrderReturnType ReconcileBankOrder(long idBankStatementStaging)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return ReconcileBankOrder(idBankStatementStaging, db);
            }
        }

        public ReconcileBankOrderReturnType ReconcileBankOrder(long idBankStatementStaging, SubscriptionEntities db)
        {
            ReconcileBankOrderReturnType reconcileBankOrderReturnType = new ReconcileBankOrderReturnType();
            var sqlParams = new SqlParameter[]
            {
               new SqlParameter { ParameterName = "@IdBankStatementStaging",  Value =  (object) idBankStatementStaging, Direction = System.Data.ParameterDirection.Input},

            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[ReconcileBankOrder] @IdBankStatementStaging";
            sqlCommand.Parameters.AddRange(sqlParams);
            bool shouldCloseDatabaseConnection = false;
            try
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Open && db.Database.CurrentTransaction != null)
                {
                    sqlCommand.Transaction = db.Database.CurrentTransaction.UnderlyingTransaction;
                }

                if (db.Database.Connection.State != System.Data.ConnectionState.Open)
                {
                    db.Database.Connection.Open();
                    shouldCloseDatabaseConnection = true;
                }

                var reader = sqlCommand.ExecuteReader();
                BankReconDaoMapper bankReconDaoMapper = new BankReconDaoMapper();
                reconcileBankOrderReturnType = bankReconDaoMapper.MapReconcileBankOrder(db, reader);

                reader.Close();//Closing the reader
            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }

            return reconcileBankOrderReturnType;
        }

        public bool SaveReconcileBankOrder(List<long> idBankStatementStagingDetails)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return SaveReconcileBankOrder(idBankStatementStagingDetails, db);
            }
        }

        public bool SaveReconcileBankOrder(List<long> idBankStatementStagingDetails, SubscriptionEntities db)
        {
            var idBankStatementStagingDetailTable = new DataTable();
            idBankStatementStagingDetailTable.Columns.Add("Id", typeof(long));

            idBankStatementStagingDetails.ForEach(p =>
            {
                var row = idBankStatementStagingDetailTable.NewRow();
                row["Id"] = p;
                idBankStatementStagingDetailTable.Rows.Add(row);
            });

            var sqlParams = new SqlParameter[]
               {
                    new SqlParameter
                    {
                        SqlDbType = SqlDbType.Structured,
                        Direction = ParameterDirection.Input,
                        ParameterName = "@IdBankStatementStagingDetails",
                        TypeName = "[dbo].[IdList]", //Don't forget this one!
                        Value = idBankStatementStagingDetailTable
                    }
               };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[SaveReconcileBankOrder] @IdBankStatementStagingDetails";
            sqlCommand.Parameters.AddRange(sqlParams);

            bool shouldCloseDatabaseConnection = false;
            try
            {
                if (db.Database.Connection.State == System.Data.ConnectionState.Open && db.Database.CurrentTransaction != null)
                {
                    sqlCommand.Transaction = db.Database.CurrentTransaction.UnderlyingTransaction;
                }

                if (db.Database.Connection.State != System.Data.ConnectionState.Open)
                {
                    db.Database.Connection.Open();
                    shouldCloseDatabaseConnection = true;
                }

                var reader = sqlCommand.ExecuteReader();

                reader.Close();//Closing the reader
            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }
            return true;
        }
    }
}
