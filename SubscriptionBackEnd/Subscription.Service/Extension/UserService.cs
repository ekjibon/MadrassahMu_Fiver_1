using CoreWeb.Business.Common;
using Subscription.Business.Enums;
using Subscription.Service.Authentication;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Linq.Expressions;
using Subscription.Business;
using Subscription.Business.ReturnType;
using Subscription.Business.Common;

namespace Subscription.Service
{
    public partial class UserService : BaseService
    {
        internal Business.Identity.User CreateUser(string email, string password, RoleEnum role, long? idPerson = null)
        {
            var alreadyPresentIdentityUser = ServiceFactory.SignInManager.UserManager.FindByEmail(email);

            if (alreadyPresentIdentityUser != null)
                throw new BusinessLayerException(String.Format("User with email {0} already exists", email));

            var identityUser = new Business.Identity.User { UserName = email, Email = email, NeedPasswordChange = false, IdPerson = idPerson };
            var userCreationResult = ServiceFactory.UserManager.CreateAsync(identityUser, password).Result;
            if (!userCreationResult.Succeeded)
            {
                Exception exception = new BusinessLayerException(userCreationResult.Errors.FirstOrDefault());
                throw exception;
            }

            var roleData = ServiceFactory.Instance.RoleService.GetRole((long)role);
            var roleCreationResult = ServiceFactory.UserManager.AddToRoleAsync(identityUser.Id, roleData.Result.Name).Result;

            if (!roleCreationResult.Succeeded)
            {
                Exception exception = new BusinessLayerException(roleCreationResult.Errors.FirstOrDefault());
                throw exception;
            }

            return identityUser;
        }

        internal void RevertUserCreation(string email)
        {
            Expression<Func<User, bool>> userExpression = property => property.IsDeactivated != true && property.Email == email;
            var user = daoFactory.UserDao.GetUserCustom(userExpression);
            if (user != null)
            {
                Expression<Func<User_Role, bool>> expression = property => property.IsDeactivated != true && property.IdUser == user.IdUser;
                var user_RoleList = daoFactory.User_RoleDao.GetUser_RoleCustomList(expression).EntityList;
                user_RoleList.ForEach(ur =>
                {
                    daoFactory.User_RoleDao.DeletePermanentlyUser_Role(ur);
                });

                daoFactory.UserDao.DeletePermanentlyUser(user);
            }
        }

        //public string GetNameForUser(long? idUser)
        //{
        //    if (!idUser.HasValue)
        //    {
        //        return null;
        //    }

        //    Expression<Func<Business.User, bool>> expression = property => property.IsDeactivated != true && property.IdUser == idUser.Value;
        //    List<String> includes = new List<string>() {
        //        UserDatabaseReferences.PERSON
        //    };

        //    Business.User user = ServiceFactory.Instance.UserService.GetUserCustomRaw(expression, includes);
        //    return GetNameForUser(user.Person);
        //}

        //public string GetNameForUser(Person person)
        //{
        //    return String.Format("{0} {1}",
        //                person != null ? person.Firstname : "",
        //               person != null ? person.Lastname : "");
        //}

        public Business.User GetUserDetail(long idUser)
        {
            Expression<Func<Business.User, bool>> expression = property => property.IsDeactivated != true && property.IdUser == idUser;
            List<String> includes = new List<string>() {
                UserDatabaseReferences.PERSON,
                //String.Format("{0}.{1}.{2}",UserDatabaseReferences.PERSON,PersonDatabaseReferences.DOCUMENT,DocumentDatabaseReferences.PARAMETER),
                //String.Format("{0}.{1}.{2}",UserDatabaseReferences.PERSON,PersonDatabaseReferences.DOCUMENT,DocumentDatabaseReferences.PARAMETER1),
                //String.Format("{0}.{1}.{2}",UserDatabaseReferences.PERSON,PersonDatabaseReferences.DOCUMENT1,DocumentDatabaseReferences.PARAMETER),
                //String.Format("{0}.{1}.{2}",UserDatabaseReferences.PERSON,PersonDatabaseReferences.DOCUMENT1,DocumentDatabaseReferences.PARAMETER1),
            };

            Business.User user = ServiceFactory.Instance.UserService.GetUserCustomRaw(expression, includes);
            return user;
        }

        public Business.User MapUserCustom(User user)
        {
            User remappedUser = Mapper.MapUserSingle(user, true);
            if (user.Person != null)
            {
                remappedUser.Person = ServiceFactory.Instance.PersonService.RemapPerson(user.Person);
                remappedUser.FirstName = remappedUser.Person.Firstname;
                remappedUser.LastName = remappedUser.Person.Lastname;
            }
            return remappedUser;
        }

        public Business.Identity.User MapUserIdentityCustom(Business.Identity.User user)
        {
            Business.Identity.User remappedUser = new Business.Identity.User();
            remappedUser.Id = user.Id;
            remappedUser.AccessFailedCount = user.AccessFailedCount;
            remappedUser.Email = user.Email;
            remappedUser.EmailConfirmed = user.EmailConfirmed;
            remappedUser.Firstname = user.Firstname;
            remappedUser.Lastname = user.Lastname;
            remappedUser.LockoutEndDateUtc = user.LockoutEndDateUtc;
            remappedUser.NeedPasswordChange = user.NeedPasswordChange;
            remappedUser.PasswordHash = user.PasswordHash;
            remappedUser.PhoneNumber = user.PhoneNumber;
            remappedUser.PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            remappedUser.SecurityStamp = user.SecurityStamp;
            remappedUser.TwoFactorEnabled = user.TwoFactorEnabled;
            remappedUser.UserName = user.UserName;
            remappedUser.LockoutEnabled = user.LockoutEnabled;
            return remappedUser;
        }

        public Business.User MapIdentityUserToBusinessUser(Business.Identity.User user)
        {
            Business.User remappedUser = new Business.User();
            remappedUser.IdUser = user.Id;
            remappedUser.Email = user.Email;
            remappedUser.FirstName = user.Firstname;
            remappedUser.LastName = user.Lastname;
            remappedUser.PasswordHash = user.PasswordHash;
            remappedUser.PhoneNumber = user.PhoneNumber;
            remappedUser.SecurityStamp = user.SecurityStamp;
            remappedUser.UserName = user.UserName;
            remappedUser.LockoutEnabled = user.LockoutEnabled;
            remappedUser.IdPerson = user.IdPerson;
            return remappedUser;
        }


        public UserWithoutConfidentialInfo MapUserToNonConfidentialInfo()
        {
            UserWithoutConfidentialInfo userWithoutConfidentialInfo = null;
            if (ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail != null)
            {
                userWithoutConfidentialInfo = new UserWithoutConfidentialInfo()
                {
                    Email = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.Email,
                    Firstname = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.FirstName,
                    Lastname = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.LastName,
                    IdUser = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdUser.Value,
                    Username = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.UserName,
                    //IdLoginProvider = ServiceFactory.Instance.GlobalVariableService.LoginProvider,
                    Roles = ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged,
                    CombinedPermission = ServiceFactory.Instance.GlobalVariableService.CombinedPermission,
                    IdPerson = ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.IdPerson,
                    //ProfilePicture = ServiceFactory.Instance.DocumentService.GetServerUrlFromDocumentRaw(ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail.Person?.Document1)
                };
            }

            return userWithoutConfidentialInfo;
        }

        public BusinessResponse<GetUserDetailForSessionReturnType> GetUserDetailForSession(long idUser)
        {
            BusinessResponse<GetUserDetailForSessionReturnType> response = new BusinessResponse<GetUserDetailForSessionReturnType>();

            try
            {
                response.Result = GetUserDetailForSessionRaw(idUser);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal GetUserDetailForSessionReturnType GetUserDetailForSessionRaw(long idUser)
        {
            return daoFactory.UserDao.GetUserDetailForSession(idUser);
        }
        public BusinessResponse<bool> GetUserDetailForSessionAndAssignToSession(long idUser)
        {
            BusinessResponse<bool> response = new BusinessResponse<bool>();

            try
            {
                response.Result = GetUserDetailForSessionAndAssignToSessionRaw(idUser);
            }
            catch (Exception ex)
            {
                response.Result = false;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        internal bool GetUserDetailForSessionAndAssignToSessionRaw(long idUser)
        {
            GetUserDetailForSessionReturnType getUserDetailForSessionReturnType = GetUserDetailForSessionRaw(idUser);
            if (getUserDetailForSessionReturnType.UserDetailForSessionUserDetail != null && getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.IdUser != null)
            {
                Business.Identity.User user = new Business.Identity.User()
                {
                    Id = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.IdUser.Value,
                    AccessFailedCount = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.AccessFailedCount,
                    Email = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.Email,
                    Firstname = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.Firstname,
                    IdPerson = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.IdPerson,
                    Lastname = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.Lastname,
                    LockoutEnabled = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.LockoutEnabled.HasValue ? getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.LockoutEnabled.Value : false,
                    LockoutEndDateUtc = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.LockoutEndDateUtc,
                    NeedPasswordChange = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.NeedPasswordChange.HasValue ? getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.NeedPasswordChange.Value : false,
                    SecurityStamp = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.SecurityStamp,
                    TwoFactorEnabled = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.TwoFactorEnabled.HasValue ? getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.TwoFactorEnabled.Value : false,
                    UserName = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.UserName
                };
                Business.User businessUser = MapIdentityUserToBusinessUser(user);
                businessUser.Person = new Person()
                {
                    IdPerson = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.IdPerson,
                    Firstname = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.Firstname,
                    Lastname = getUserDetailForSessionReturnType.UserDetailForSessionUserDetail.Lastname,
                };


                List<Role> roles = new List<Role>();
                getUserDetailForSessionReturnType.UserDetailForSessionRole.ForEach(r =>
                {
                    Role role = new Role() { IdRole = r.IdRole, Name = r.Name };
                    roles.Add(role);
                });

                List<CombinedPermission> combinedPermissions = new List<CombinedPermission>();
                getUserDetailForSessionReturnType.UserDetailForSessionPermission.ForEach(p =>
                {
                    CombinedPermission combinedPermission = new CombinedPermission() { IdPermission = p.IdPermission, PermissionName = p.PermissionName };
                    combinedPermissions.Add(combinedPermission);
                });

                ServiceFactory.Instance.GlobalVariableService.UserLogged = ServiceFactory.Instance.UserService.MapUserIdentityCustom(user);
                ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail = businessUser;
                ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged = roles;
                ServiceFactory.Instance.GlobalVariableService.CombinedPermission = combinedPermissions;
            }

            return true;
        }
    }
}
