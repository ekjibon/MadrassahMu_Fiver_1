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
using Subscription.Business.Dto;
using System.Data;
using Subscription.Data.DaoMapper;

namespace Subscription.Data
{
    public partial class TransactionDao : ITransactionDao
    {
        public GetEmailForTransactionReturnType GetEmailForTransaction(GetEmailForTransactionDto getEmailForTransactionDto)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetEmailForTransaction(getEmailForTransactionDto, db);
            }

        }
        public GetEmailForTransactionReturnType GetEmailForTransaction(GetEmailForTransactionDto getEmailForTransactionDto, SubscriptionEntities db)
        {
            GetEmailForTransactionReturnType getEmailForTransactionReturnType = new GetEmailForTransactionReturnType();
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@PageNumber",  Value =  (object)getEmailForTransactionDto.CurrentPageIndex , Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@RowsOfPage",  Value =  (object)getEmailForTransactionDto.PageSize , Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@IdBankStatementStaging",  Value =  (object)getEmailForTransactionDto.IdBankStatementStaging ?? Convert.DBNull, Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@IdBankStatementStagingDetailBatch",  Value =  (object)getEmailForTransactionDto.IdBankStatementStagingDetailBatch ?? Convert.DBNull, Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@ReceiptNo",  Value =  (object)getEmailForTransactionDto.ReceiptNo ?? Convert.DBNull, Direction = System.Data.ParameterDirection.Input},
            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[GetEmailForTransaction] @PageNumber,@RowsOfPage,@IdBankStatementStaging,@IdBankStatementStagingDetailBatch,@ReceiptNo,@TotalCount OUTPUT";
            sqlCommand.Parameters.AddRange(sqlParams);
            sqlCommand.Parameters.Add(new SqlParameter { ParameterName = "@TotalCount", SqlDbType = SqlDbType.Int, Direction = System.Data.ParameterDirection.Output });

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
                TransactionDaoMapper transactionDaoMapper = new TransactionDaoMapper();
                getEmailForTransactionReturnType = transactionDaoMapper.MapGetEmailForTransaction(db, reader);

                reader.Close();//Closing the reader
                var totalCountParameter = sqlCommand.Parameters["@TotalCount"];

                getEmailForTransactionReturnType.Transactions.TotalCount = totalCountParameter.Value == DBNull.Value ? 0 : (int)totalCountParameter.Value;
            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }

            return getEmailForTransactionReturnType;
        }


        public List<GetTransactionSaleForPrintReturnType> GetTransactionSaleForPrint(List<long> idTransactions)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetTransactionSaleForPrint(idTransactions, db);
            }
        }
        public List<GetTransactionSaleForPrintReturnType> GetTransactionSaleForPrint(List<long> idTransactions, SubscriptionEntities db)
        {
            List<GetTransactionSaleForPrintReturnType> getTransactionSaleForPrintReturnTypes = new List<GetTransactionSaleForPrintReturnType>();
            DataTable idTransactionDatatable = new DataTable();
            idTransactionDatatable.Columns.Add("Id", typeof(long));
            foreach (long id in idTransactions)
            {
                idTransactionDatatable.Rows.Add(id);
            }

            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@IdTransactionList",  Value =  (object)idTransactionDatatable, Direction = System.Data.ParameterDirection.Input,TypeName = "IdList"},
            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[GetTransactionSaleForPrint] @IdTransactionList";
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
                TransactionDaoMapper transactionDaoMapper = new TransactionDaoMapper();
                getTransactionSaleForPrintReturnTypes = transactionDaoMapper.MapGetTransactionSaleForPrint(db, reader);

                reader.Close();//Closing the reader
            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }

            return getTransactionSaleForPrintReturnTypes;
        }

        public GetTransactionTotalForDateReturnType GetTransactionTotalForDate(long idUser, DateTime date)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetTransactionTotalForDate(idUser, date, db);
            }
        }
        public GetTransactionTotalForDateReturnType GetTransactionTotalForDate(long idUser, DateTime date, SubscriptionEntities db)
        {
            GetTransactionTotalForDateReturnType getTransactionSaleForPrintReturnType = new GetTransactionTotalForDateReturnType();

            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@IdUser",  Value =  (object)idUser , Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@Date",  Value =  (object)date , Direction = System.Data.ParameterDirection.Input},
            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[GetTransactionTotalForDate] @IdUser, @Date";
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
                TransactionDaoMapper transactionDaoMapper = new TransactionDaoMapper();
                getTransactionSaleForPrintReturnType = transactionDaoMapper.GetTransactionTotalForDate(db, reader);

                reader.Close();//Closing the reader
            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }

            return getTransactionSaleForPrintReturnType;
        }
        ///[dbo].[GetTransactionTotalForDate]
    }
}
