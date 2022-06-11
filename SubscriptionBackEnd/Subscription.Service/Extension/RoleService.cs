using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Subscription.Business;
using Subscription.Business.Common;
using Subscription.Business.Enums;

namespace Subscription.Service
{
    public partial class RoleService : BaseService
    {
        public BusinessResponse<BaseListReturnType<Role>> GetRoleForUser(long idUser)
        {
            BusinessResponse<BaseListReturnType<Role>> response = new BusinessResponse<BaseListReturnType<Role>>();

            try
            {
                response.Result = GetRoleForUserRaw(idUser);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal BaseListReturnType<Role> GetRoleForUserRaw(long idUser)
        {
            Expression<Func<Role, bool>> expression = property => property.IsDeactivated != true && property.User_Role.Select(r => r.IdUser.Value).Contains(idUser);

            List<string> includes = new List<string>() {
                RoleDatabaseReferences.USER_ROLE
            };

            BaseListReturnType<Role> roles = daoFactory.RoleDao.GetRoleCustomList(expression, includes);

            BaseListReturnType<Role> remappedRoles = new BaseListReturnType<Role>();
            remappedRoles.TotalCount = roles.TotalCount;
            remappedRoles.EntityList = new List<Role>();

            roles.EntityList.ForEach(r =>
            {
                Role role = Mapper.MapRoleSingle(r, true);
                remappedRoles.EntityList.Add(role);
            });
            return remappedRoles;
        }
    }
}
