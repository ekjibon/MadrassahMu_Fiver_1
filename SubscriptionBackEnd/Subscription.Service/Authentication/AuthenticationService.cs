using Subscription.Business;
using Subscription.Business.Dto;
using Subscription.Business.Enums;
using Subscription.Data.EntityFramework.Identity;
using CoreWeb.Business.Common;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Subscription.Business.ReturnType;
using Subscription.Business.Common;
using System.Linq.Expressions;
using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using System.Web.Security;
using Newtonsoft.Json;
using Subscription.Business.Custom;
using Subscription.Business.Dto.Security;
using Subscription.Business.ReturnType.Security;
using Subscription.Data;
using System.Configuration;
using System.Threading;

namespace Subscription.Service.Authentication
{
    public class AuthenticationService : BaseService
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
        }

        public async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> LoginWithCredential(AuthenticateUserDto authenticateUserDto)
        {
            BusinessResponse<OAuthAuthenticateUserReturnType> response = new BusinessResponse<OAuthAuthenticateUserReturnType>();
            try
            {
                response.Result = await LoginWithCredentialRaw(authenticateUserDto);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public async Task<OAuthAuthenticateUserReturnType> LoginWithCredentialRaw(AuthenticateUserDto authenticateUserDto)
        {
            //ServiceFactory.Instance.GlobalVariableService.LoginProvider = AuthenticationTypeEnum.IDENTITY;
            OAuthAuthenticateUserReturnType authenticateUserReturnType = await AuthenticateUserRaw(authenticateUserDto);

            return authenticateUserReturnType;
        }


        public async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> AuthenticateUser(AuthenticateUserDto authenticateUserDto, bool usePassword = true)
        {
            BusinessResponse<OAuthAuthenticateUserReturnType> response = new BusinessResponse<OAuthAuthenticateUserReturnType>();
            try
            {
                response.Result = await AuthenticateUserRaw(authenticateUserDto, usePassword);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public async Task<OAuthAuthenticateUserReturnType> AuthenticateUserRaw(AuthenticateUserDto authenticateUserDto, bool shouldUsePassword = true, bool shouldGenerateToken = false, bool shouldLogin = true)
        {
            OAuthAuthenticateUserReturnType authenticateUserReturnType = new OAuthAuthenticateUserReturnType();
            authenticateUserReturnType.SignInStatus = SignInStatus.Failure;
            var user = ServiceFactory.SignInManager.UserManager.FindByEmail(authenticateUserDto.Email);
            if (user == null)
                throw new Exception(String.Format("User with email {0} cannot be found", authenticateUserDto.Email));

            SignInStatus signInStatus = SignInStatus.Success;

            if (shouldLogin)
            {
                if (shouldUsePassword)
                {
                    signInStatus = await ServiceFactory.SignInManager.PasswordSignInAsyncWithEmail(authenticateUserDto.Email, authenticateUserDto.Password, true, false);
                }
                else
                {
                    ServiceFactory.SignInManager.SignIn(user, true, false);
                    authenticateUserReturnType.SignInStatus = SignInStatus.Success;
                }
            }

            authenticateUserReturnType.SignInStatus = signInStatus;

            if (signInStatus == SignInStatus.Success)
            {
                authenticateUserReturnType.NeedPasswordChange = user.NeedPasswordChange;
                IdentityResult responseMaintenance = new IdentityResult();
                ServiceFactory.Instance.GlobalVariableService.UserLogged = ServiceFactory.Instance.UserService.MapUserIdentityCustom(user);
                ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail = ServiceFactory.Instance.UserService.MapUserCustom(ServiceFactory.Instance.UserService.GetUserDetail(user.Id));
                ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged = ServiceFactory.Instance.RoleService.GetRoleForUserRaw(user.Id).EntityList;
                ServiceFactory.Instance.GlobalVariableService.CombinedPermission = ServiceFactory.Instance.AuthenticationService.GetPermissionForMe();

                authenticateUserReturnType.UserWithoutConfidentialInfo = ServiceFactory.Instance.UserService.MapUserToNonConfidentialInfo();

                //GetUserDetailForSession

                if (shouldGenerateToken)
                {
                    List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) };
                    authenticateUserReturnType.AccessToken = GetAuthToken(claims);
                    authenticateUserReturnType.ExpiryDate = DateTime.Now.AddDays(365);
                }
            }
            return authenticateUserReturnType;
        }


        public async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> AuthenticateUserOAuth(AuthenticateUserDto authenticateUserDto)
        {
            BusinessResponse<OAuthAuthenticateUserReturnType> response = new BusinessResponse<OAuthAuthenticateUserReturnType>();

            try
            {
                response.Result = await AuthenticateUserOAuthRaw(authenticateUserDto);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public async Task<OAuthAuthenticateUserReturnType> AuthenticateUserOAuthRaw(AuthenticateUserDto authenticateUserDto)
        {
            //ServiceFactory.Instance.GlobalVariableService.LoginProvider = AuthenticationTypeEnum.IDENTITY;
            OAuthAuthenticateUserReturnType authenticateUserReturnType = await AuthenticateUserRaw(authenticateUserDto, true, true, false);
            return authenticateUserReturnType;
        }

        public async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> RegisterUser(AuthenticateUserDto authenticateUserDto, Person person = null, bool shouldGenerateToken = false)
        {
            BusinessResponse<OAuthAuthenticateUserReturnType> response = new BusinessResponse<OAuthAuthenticateUserReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();

            try
            {
                unitOfWork.Begin();
                RegisterUserRaw(authenticateUserDto, unitOfWork, person);
                unitOfWork.Commit();

                response.Result = await AuthenticateUserRaw(authenticateUserDto, false, shouldGenerateToken, true);

                //long idPerson = GlobalVariableService.Instance.UserLoggedWithDetail.IdPerson.Value;
    
            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public Business.User RegisterUserRaw(AuthenticateUserDto authenticateUserDto, UnitOfWork unitOfWork, Person person = null)
        {
            Business.Identity.User user = ServiceFactory.Instance.UserService.CreateUser(authenticateUserDto.Email, authenticateUserDto.Password, RoleEnum.NORMAL);

            if (person == null)
            {
                person = new Person() { };
            }

            try
            {
                daoFactory.PersonDao.SaveOnlyPerson(person, unitOfWork.Db);

                Concept concept = new Concept() { IdPerson = person.IdPerson, IdConceptType = (long)ConceptTypeEnum.PROFILE };
                daoFactory.ConceptDao.SaveOnlyConcept(concept, unitOfWork.Db);


                //Business.User businessUser = ServiceFactory.Instance.UserService.MapIdentityUserToBusinessUser(user);
                //businessUser.IdPerson = person.IdPerson;
                //daoFactory.UserDao.SaveOnlyUser(businessUser, unitOfWork.Db);
                //businessUser.Person = person;

                //MailToSend mailToSend = ServiceFactory.Instance.MailBuilderService.BuildUserRegistrationMail(businessUser.IdUser.Value, authenticateUserDto.Password, businessUser);
                //ServiceFactory.Instance.MailToSendService.SaveMailToSendCustomRaw(mailToSend, unitOfWork);
                //return businessUser;
                return null;
            }
            catch (Exception e)
            {
                unitOfWork.RollbackTransaction(false);
                ServiceFactory.Instance.UserService.RevertUserCreation(authenticateUserDto.Email);
                throw e;
            }
        }

        public async Task<BusinessResponse<OAuthAuthenticateUserReturnType>> RegisterOrLoginWithSocial(AuthenticateUserDto authenticateUserDto, bool shouldGenerateToken = false)
        {
            BusinessResponse<OAuthAuthenticateUserReturnType> response = new BusinessResponse<OAuthAuthenticateUserReturnType>();
            UnitOfWork unitOfWork = new UnitOfWork();

            try
            {

                unitOfWork.Begin();
                RegisterOrLoginWithSocialRaw(authenticateUserDto, unitOfWork);
                unitOfWork.Commit();

                //save to elasticsearch
                response.Result = await AuthenticateUserRaw(authenticateUserDto, false, shouldGenerateToken, true);
                //long idPerson = GlobalVariableService.Instance.UserLoggedWithDetail.IdPerson.Value;


            }
            catch (Exception ex)
            {
                unitOfWork.RollbackTransaction();
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public void RegisterOrLoginWithSocialRaw(AuthenticateUserDto authenticateUserDto, UnitOfWork unitOfWork)
        {
            bool shouldSaveUser_SocialNetworkToSave = false;
            Business.User user = null;
            var alreadyPresentIdentityUser = ServiceFactory.SignInManager.UserManager.FindByEmail(authenticateUserDto.Email);
            if (alreadyPresentIdentityUser != null)
            {
                Expression<Func<User_SocialNetwork, bool>> expression = property => property.IsDeactivated != true
                && property.IdUser == alreadyPresentIdentityUser.Id && property.IdSocialNetwork == (long)authenticateUserDto.Provider;

                //user = ServiceFactory.Instance.UserService.MapIdentityUserToBusinessUser(alreadyPresentIdentityUser);
                User_SocialNetwork user_SocialNetwork = ServiceFactory.Instance.User_SocialNetworkService.GetUser_SocialNetworkCustomRaw(expression);
                if (user_SocialNetwork == null)
                {
                    shouldSaveUser_SocialNetworkToSave = true;
                }

                //ServiceFactory.Instance.GlobalVariableService.LoginProvider = authenticateUserDto.Provider;
            }
            else
            {
                Person person = new Person() { Firstname = authenticateUserDto.Firstname, Lastname = authenticateUserDto.Lastname };
                authenticateUserDto.Password = ServiceFactory.Instance.PasswordGenerationService.GenerateNewPassword();
                //ServiceFactory.Instance.GlobalVariableService.LoginProvider = authenticateUserDto.Provider;
                user = RegisterUserRaw(authenticateUserDto, unitOfWork, person);
                shouldSaveUser_SocialNetworkToSave = true;
            }

            if (shouldSaveUser_SocialNetworkToSave)
            {
                daoFactory.User_SocialNetworkDao.SaveOnlyUser_SocialNetwork(new User_SocialNetwork()
                {
                    IdUser = user.IdUser,
                    IdSocialNetwork = (long)authenticateUserDto.Provider,
                    SocialNetworkId = authenticateUserDto.Uid
                }, unitOfWork.Db);
            }
        }

        public void LogOff(ApplicationSignInManager signInManager)
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
            signInManager.AuthenticationManager.SignOut();
            if (ServiceFactory.Instance.GlobalVariableService != null)
            {
                ServiceFactory.Instance.GlobalVariableService.UserLogged = null;
                ServiceFactory.Instance.GlobalVariableService.CombinedPermission = null;
                ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged = null;
                ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail = null;
            }

            DeleteCookies();
        }

        public void DeleteCookies()
        {
            HttpCookie httpCookie;
            int iCookieCount = HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < iCookieCount; i++)
            {
                httpCookie = new HttpCookie(HttpContext.Current.Request.Cookies[i].Name);
                httpCookie.Expires = DateTime.Now.AddDays(-1);
                httpCookie.Path = HttpContext.Current.Request.Cookies[i].Path;
                httpCookie.Domain = HttpContext.Current.Request.Cookies[i].Domain;
                httpCookie.Values.Clear();
                HttpContext.Current.Response.Cookies.Add(httpCookie);
            }
        }

        //public void AddUserDetailToHttpCookie()
        //{
        //List<Claim> claims = GetClaimsForAuth();

        //long idUser = GlobalVariableService.Instance.UserLoggedWithDetail.IdUser.Value;
        //claims.ForEach(c =>
        //{
        //    ServiceFactory.UserManager.AddClaim(idUser, c);
        //});
        //}

        //public List<Claim> GetClaimsForAuth()
        //{
        //    ClaimsItem claimsItem = new ClaimsItem()
        //    {
        //        //LoginProvider = GlobalVariableService.Instance.LoginProvider,
        //        CombinedPermission = GlobalVariableService.Instance.CombinedPermission,
        //        RolesForUserLogged = GlobalVariableService.Instance.RolesForUserLogged,
        //        UserLogged = GlobalVariableService.Instance.UserLogged,
        //        UserLoggedWithDetail = GlobalVariableService.Instance.UserLoggedWithDetail
        //    };

        //    List<Claim> claims = new List<Claim>();
        //    claims.Add(new Claim(ClaimsItem.Bundle, JsonConvert.SerializeObject(claimsItem)));
        //    return claims;
        //}

        public string GetAuthToken(List<Claim> claims, int noOfDays = 365)
        {
            var tokenExpiration = TimeSpan.FromDays(noOfDays);
            ClaimsIdentity identity = new ClaimsIdentity(OAuthDefaults.AuthenticationType);
            identity.AddClaims(claims);

            AuthenticationProperties props = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.Add(tokenExpiration),
                IsPersistent = true,
                AllowRefresh = true
            };
            AuthenticationTicket ticket = new AuthenticationTicket(identity, props);
            string accessToken = ServiceFactory.OAuthOptions.AccessTokenFormat.Protect(ticket);
            return accessToken;
        }

        public BusinessResponse<UserWithoutConfidentialInfo> GetLoggedUser()
        {
            BusinessResponse<UserWithoutConfidentialInfo> response = new BusinessResponse<UserWithoutConfidentialInfo>();

            try
            {
                if (ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail != null)
                {
                    response.Result = ServiceFactory.Instance.UserService.MapUserToNonConfidentialInfo();
                }
                else
                {
                    throw new Exception("No logged user");
                }
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }
            return response;
        }

        public List<CombinedPermission> GetPermissionForMe()
        {
            long? idUser = null;
            if (GlobalVariableService.Instance.UserLogged != null)
            {
                idUser = GlobalVariableService.Instance.UserLogged.Id;
            }

            var permissions = ServiceFactory.Instance.PermissionService.GetAllPermissionsForRolesRaw(ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged.Select(r => r.IdRole.Value).ToList(), idUser);

            return permissions;
        }

        public BusinessResponse<ForgotPasswordReturnType> ForgotPassword(ApplicationSignInManager signInManager, ApplicationUserManager applicationUserManager, string email)
        {
            BusinessResponse<ForgotPasswordReturnType> response = new BusinessResponse<ForgotPasswordReturnType>();

            try
            {
                Business.Identity.User user = signInManager.UserManager.FindByEmail(email);
                if (user == null)
                {
                    throw new Exception(string.Format("User with email {0} does not exits on our records", email));
                }

                WorkflowTransition workflowTransition = ServiceFactory.Instance.WorkflowService.GetNextPossibleWorkflowTransition(null, (long)WorkflowActionEnum.FORGOT_PASSWORD_GENERATED, (long)WorkflowRoleEnum.FORGOT_PASSWORD_INITIATOR);

                if (workflowTransition == null)
                    throw new Exception("No workflow transition specified for criteria");

                Request request = new Request()
                {
                    IdRequestType = workflowTransition.WorkflowAction.Workflow.RequestTypes.FirstOrDefault().IdRequestType,
                    IdRequestAuthor = user.Id,
                    RequestDate = DateTime.Now,
                    IdWorkflowState = workflowTransition.IdWorkflowStateFinal.Value,
                    IdUserAssignedTo = user.Id
                };
                ServiceFactory.Instance.RequestService.SaveOnlyRequestRaw(request);
                ServiceFactory.Instance.WorkflowService.InitiateWorkflowTransitionAction(workflowTransition.IdWorkflowTransition.Value, JsonConvert.SerializeObject(new { IdRequest = request.IdRequest, IdRequestAuthor = user.Id }));

            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }
            return response;
        }

        public async Task<BusinessResponse<ForgotPasswordReturnType>> ResetPasswordExternal(ApplicationSignInManager signInManager, ResetPasswordExternalDto resetPasswordExternalDto)
        {
            BusinessResponse<ForgotPasswordReturnType> response = new BusinessResponse<ForgotPasswordReturnType>();
            response.Result = new ForgotPasswordReturnType();
            try
            {
                ServiceFactory.Instance.WorkflowService.WorkflowTransitionFromExternalRaw(new ExecuteExternalTransitionDto() { Token = resetPasswordExternalDto.Token });
                RequestWorkflowToken requestWorkflowToken = JWTTokenManager.VerifyToken<RequestWorkflowToken>(resetPasswordExternalDto.Token);
                await ChangePasswordRaw(signInManager, requestWorkflowToken.IdUser, resetPasswordExternalDto.Password);
            }
            catch (Exception ex)
            {
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }
            return response;
        }

        public async Task<BusinessResponse<ChangePasswordReturnType>> ChangePassword(ApplicationSignInManager signInManager, long idUser, string password)
        {
            BusinessResponse<ChangePasswordReturnType> response = new BusinessResponse<ChangePasswordReturnType>();
            try
            {
                response.Result = await ChangePasswordRaw(signInManager, idUser, password);
            }
            catch (Exception ex)
            {
                response.Result = null;
                response.Exception = new BusinessLayerException(ex.Message, ex);
            }

            return response;
        }

        public async Task<ChangePasswordReturnType> ChangePasswordRaw(ApplicationSignInManager signInManager, long idUser, string password)
        {
            ChangePasswordReturnType response = new ChangePasswordReturnType();
            response.ChangePasswordStatus = false;
            var user = signInManager.UserManager.FindById(idUser);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.PasswordHash = signInManager.UserManager.PasswordHasher.HashPassword(password);
            var result = await signInManager.UserManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception(String.Join(", ", result.Errors.ToArray()));
            }

            response.ChangePasswordStatus = true;
            return response;
        }



    }
}
