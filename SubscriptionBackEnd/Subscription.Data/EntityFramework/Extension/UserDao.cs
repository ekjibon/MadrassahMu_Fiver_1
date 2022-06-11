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

namespace Subscription.Data
{
    public partial class UserDao : IUserDao
    {
        public GetUserDetailForSessionReturnType GetUserDetailForSession(long idUser)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetUserDetailForSession(idUser, db);
            }
        }

        public GetUserDetailForSessionReturnType GetUserDetailForSession(long idUser, SubscriptionEntities db)
        {
            GetUserDetailForSessionReturnType getUserDetailForSessionReturnType = new GetUserDetailForSessionReturnType();
            var sqlParams = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@IdUser",  Value =  (object)idUser, Direction = System.Data.ParameterDirection.Input},
            };

            var sqlCommand = db.Database.Connection.CreateCommand();
            sqlCommand.CommandText = "EXEC [dbo].[GetUserDetailForSession] @IdUser";
            sqlCommand.Parameters.AddRange(sqlParams);
            try
            {
                db.Database.Connection.Open();
                var reader = sqlCommand.ExecuteReader();
                getUserDetailForSessionReturnType.UserDetailForSessionUserDetail = ((IObjectContextAdapter)db)
                  .ObjectContext
                  .Translate<UserDetailForSessionUserDetail>(reader).FirstOrDefault();

                reader.NextResult();

                getUserDetailForSessionReturnType.UserDetailForSessionPermission = ((IObjectContextAdapter)db)
                  .ObjectContext
                  .Translate<UserDetailForSessionPermission>(reader).ToList();

                reader.NextResult();

                getUserDetailForSessionReturnType.UserDetailForSessionRole = ((IObjectContextAdapter)db)
                  .ObjectContext
                  .Translate<UserDetailForSessionRole>(reader).ToList();
            }
            finally
            {
                db.Database.Connection.Close();
            }




            return getUserDetailForSessionReturnType;
        }

        public List<CombinedPermission> GetUserPermissions(string username)
        {
            //List<CombinedPermission> combinePermissions = new List<CombinedPermission>();
            //var finalPermission = new List<CombinedPermission>();
            //using (SubscriptionEntities dbContext = new SubscriptionEntities())
            //{
            //    var user = dbContext.Users
            //               .Where(u => u.UserName.Equals(username))
            //               .FirstOrDefault();

            //    var id_roles = dbContext.User_Role
            //        .Include("Role")
            //        .Where(ur => ur.IdUser == user.IdUser).Select(ur => ur.IdRole);

            //    var rolePermissions = dbContext.Role_Permission.Include("Permission").Where(rp => id_roles.Contains(rp.IdRole));

            //    var user_permission = dbContext.User_Permission.Include("Permission").Where(up => up.IdUser == user.IdUser).ToList();

            //    var finalPermissionSP = (from rp in rolePermissions
            //                             join permission in user_permission on rp.IdPermission equals permission.IdPermission into ps
            //                             from p in ps.DefaultIfEmpty()
            //                             select new CombinedPermission() {
            //                                 PermissionCode = rp.Permission.PermissionCode.Value,
            //                                 PermissionName = rp.Permission.PermissionName,
            //                                 View = ((p == null ? false : p.View.Value) || rp.View.Value),
            //                                 Edit = ((p == null ? false : p.Edit.Value) || rp.Edit.Value),
            //                                 Delete = ((p == null ? false : p.Delete.Value) || rp.Delete.Value)
            //                             });

            //    finalPermission = finalPermissionSP.ToList();

            //    foreach (var item in rolePermissions)
            //    {
            //        combinePermissions.Add(new CombinedPermission()
            //        {
            //            PermissionName = item.Permission.PermissionName,
            //            PermissionCode = item.Permission.PermissionCode.Value,
            //            View = item.View.Value,
            //            Edit = item.Edit.Value,
            //            Delete = item.Delete.Value
            //        }
            //        );
            //    }
            //}

            return null;
        }
    }

}
