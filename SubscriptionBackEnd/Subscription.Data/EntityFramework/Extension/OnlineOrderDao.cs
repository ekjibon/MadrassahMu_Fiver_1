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
using System.Data;
using Subscription.Business.BusinessObject;

namespace Subscription.Data
{
    public class OnlineOrderDao : IOnlineOrderDao
    {
        private EntityFramework.SubscriptionEntities _db;
        public OnlineOrderDao()
        {

        }

        public OnlineOrderDao(EntityFramework.SubscriptionEntities db)
        {
            _db = db;
        }


        public BaseListReturnType<OnlineOrder> LoadOnlineOrders(OnlineOrdersSortingPagingInfo sortingPagingInfo)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return LoadOnlineOrders(sortingPagingInfo, db);
            }
        }

        public BaseListReturnType<OnlineOrder> LoadOnlineOrders(OnlineOrdersSortingPagingInfo sortingPagingInfo, SubscriptionEntities db)
        {
            BaseListReturnType<OnlineOrder> baseListReturnType = new BaseListReturnType<OnlineOrder>();
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@pageIndex",  Value =  (object)sortingPagingInfo.CurrentPageIndex , Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@pageSize ",  Value =  (object)sortingPagingInfo.PageSize , Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@Date",  Value =  (object)sortingPagingInfo.Date ?? Convert.DBNull, Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@IdOrderState",  Value =  (object)sortingPagingInfo.IdOrderState ?? Convert.DBNull, Direction = System.Data.ParameterDirection.Input},
                new SqlParameter { ParameterName = "@OrderByColumn",  Value =  (object)sortingPagingInfo.OrderByColumn ?? Convert.DBNull, Direction = System.Data.ParameterDirection.Input},
            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[LoadOnlineOrders] @pageIndex,@pageSize,@Date,@IdOrderState,@OrderByColumn,@TotalCount OUTPUT";
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
                OnlineOrderDaoMapper onlineOrderDaoMapper = new OnlineOrderDaoMapper();
                baseListReturnType = onlineOrderDaoMapper.MapLoadOnlineOrders(db, reader);

                reader.Close();//Closing the reader
                var totalCountParameter = sqlCommand.Parameters["@TotalCount"];

                baseListReturnType.TotalCount = totalCountParameter.Value == DBNull.Value ? 0 : (int)totalCountParameter.Value;
            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }

            return baseListReturnType;
        }

        public List<OnlineOrder> GetOnlineOrderDetailForBankRecon(long idBankStatementStaging)
        {
            using (SubscriptionEntities db = new SubscriptionEntities())
            {
                return GetOnlineOrderDetailForBankRecon(idBankStatementStaging, db);
            }
        }

        public List<OnlineOrder> GetOnlineOrderDetailForBankRecon(long idBankStatementStaging, SubscriptionEntities db)
        {
            List<OnlineOrder> onlineOrders = new List<OnlineOrder>();
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@IdBankStatementStaging",  Value =  (object)idBankStatementStaging , Direction = System.Data.ParameterDirection.Input},
            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[GetOnlineOrderDetailForBankRecon] @IdBankStatementStaging";
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
                OnlineOrderDaoMapper onlineOrderDaoMapper = new OnlineOrderDaoMapper();
                onlineOrders = onlineOrderDaoMapper.GetOnlineOrderDetailForBankRecon(db, reader);

                reader.Close();//Closing the reader

            }
            finally
            {
                if (shouldCloseDatabaseConnection)
                {
                    db.Database.Connection.Close();
                }
            }

            return onlineOrders;
        }
    }
}
