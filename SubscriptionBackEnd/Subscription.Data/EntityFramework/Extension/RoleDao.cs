using Subscription.Business;
using Subscription.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Data
{
    public partial class RoleDao : IRoleDao
    {
        public List<Role> GetRolesForUser(long idUser)
        {
            using (SubscriptionEntities db = new EntityFramework.SubscriptionEntities())
            {
                return GetRolesForUserRaw(idUser, db);
            }
        }
        public List<Role> GetRolesForUserRaw(long idUser, SubscriptionEntities db)
        {
            var roles = db.User_Role
                        .Include("Role")
                        .Include("User")
                        .Where(ur => ur.IdUser == idUser).Select(ur => ur.Role).ToList();

            var user = db.User_Role.Include("User").Where(u => u.IdUser == idUser).FirstOrDefault();

            if (user == null)
                return new List<Role>();

            return roles;
        }
    }
}
