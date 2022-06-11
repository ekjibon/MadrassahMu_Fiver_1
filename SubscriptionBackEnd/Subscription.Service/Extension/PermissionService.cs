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
    public partial class PermissionService : BaseService
    {
        public BusinessResponse<List<CombinedPermission>> GetAllPermissionsForRoles(List<long> idRoles, long? idUser = null)
        {
            BusinessResponse<List<CombinedPermission>> response = new BusinessResponse<List<CombinedPermission>>();

            try
            {
                response.Result = GetAllPermissionsForRolesRaw(idRoles, idUser);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal List<CombinedPermission> GetAllPermissionsForRolesRaw(List<long> idRoles, long? idUser = null)
        {
            Expression<Func<Role_Permission, bool>> expression = property => property.IsDeactivated != true && idRoles.Contains(property.IdRole.Value);

            List<string> includes = new List<string>()
            {
                Role_PermissionDatabaseReferences.PERMISSION
            };

            List<Role_Permission> role_Permission = ServiceFactory.Instance.Role_PermissionService.GetRole_PermissionCustomListRaw(expression, includes, true)
                    .EntityList;

            List<CombinedPermission> finalPremission = new List<CombinedPermission>();

            if (idUser == null)
            {
                finalPremission = role_Permission.Select(p => new CombinedPermission()
                {
                    IdPermission = p.IdPermission.Value,
                    PermissionCode = p.Permission.PermissionCode.Value,
                    PermissionName = p.Permission.PermissionName,
                    //Delete = p.Delete.Value,
                    //Edit = p.Edit.Value,
                    //View = p.View.Value
                }).ToList();
            }
            else
            {

                Expression<Func<User_Permission, bool>> userPermissionExpression = property => property.IsDeactivated != true && property.IdUser == idUser;

                List<string> userPermissionIncludes = new List<string>()
                {
                    User_PermissionDatabaseReferences.PERMISSION
                };

                List<User_Permission> user_permission = ServiceFactory.Instance.User_PermissionService.GetUser_PermissionCustomListRaw(userPermissionExpression, userPermissionIncludes, false).EntityList;
                var idUser_Permission = user_permission.Select(up => up.IdPermission.Value).ToList();

                role_Permission.Where(ugp => !idUser_Permission.Contains(ugp.IdPermission.Value)).ToList().ForEach(ugp =>
                {
                    finalPremission.Add(new CombinedPermission()
                    {
                        IdPermission = ugp.IdPermission.Value,
                        PermissionCode = ugp.Permission.PermissionCode.Value,
                        PermissionName = ugp.Permission.PermissionName,
                        //View = ugp.View.HasValue ? ugp.View.Value : false ,
                        //Edit = ugp.Edit.HasValue ? ugp.Edit.Value : false,
                        //Delete = ugp.Delete.HasValue ? ugp.Delete.Value : false,
                    });
                });

                user_permission.ForEach(up =>
                {
                    finalPremission.Add(new CombinedPermission()
                    {
                        IdPermission = up.IdPermission.Value,
                        PermissionCode = up.Permission.PermissionCode.Value,
                        PermissionName = up.Permission.PermissionName,
                        //View = up.View.HasValue ? up.View.Value : false,
                        //Edit = up.Edit.HasValue ? up.Edit.Value : false,
                        //Delete = up.Delete.HasValue ? up.Delete.Value : false,
                    });
                });
            }

            return finalPremission;
        }
    }
}
