using Subscription.Business;
using Subscription.Business.Enums;
using Subscription.Service;
using Subscription.Service.Authentication;
using CoreWeb.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using Newtonsoft.Json;
using System.Web.Services.Description;
using Subscription.Ui.Mvc;

namespace Subscription.Ui.Mvc
{
    public enum UnauthorizedResultEnum
    {
        REDIRECT_TO_LOGIN = 0,
        JSON_TIMEOUT = 1
    }

    public enum AuthorizationTypeEnum
    {
        ALLOW_ANONYMOUS = 1,
        REQUIRE_AUTHORIZATION = 2
    }

    public class CustomAuthorization : System.Web.Mvc.AuthorizeAttribute
    {
        List<PermissionEnum> PermissionCodes { get; set; }
        private UnauthorizedResultEnum UnauthorizedResultEnum { get; set; }
        private AuthorizationTypeEnum AuthorizationTypeEnum { get; set; }
        public CustomAuthorization()
        {
            Init();
        }

        public CustomAuthorization(params PermissionEnum[] permissionCodes)
        {
            Init();
            this.PermissionCodes = permissionCodes.ToList();
        }

        public CustomAuthorization(AuthorizationTypeEnum authorizationTypeEnum)
        {
            Init();
            this.AuthorizationTypeEnum = authorizationTypeEnum;
        }

        public CustomAuthorization(UnauthorizedResultEnum unauthorizedResultEnum, AuthorizationTypeEnum authorizationTypeEnum, params PermissionEnum[] permissionCodes)
        {
            this.PermissionCodes = permissionCodes.ToList();
            this.UnauthorizedResultEnum = unauthorizedResultEnum;
            this.AuthorizationTypeEnum = authorizationTypeEnum;
        }

        public void Init()
        {
            this.PermissionCodes = new List<PermissionEnum>();
            this.UnauthorizedResultEnum = UnauthorizedResultEnum.REDIRECT_TO_LOGIN;
            this.AuthorizationTypeEnum = AuthorizationTypeEnum.ALLOW_ANONYMOUS;


        }

        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            try
            {
                ServiceFactory.Instance.GlobalVariableService.IdHostedDomain = null;
                ServiceFactory.Instance.GlobalVariableService.Area = AreaEnum.GENERAL;
                var routeData = HttpContext.Current.Request.RequestContext.RouteData;
                var dataTokens = routeData.DataTokens;

                long idEntityTemp;
                string areaName = null;

                if (routeData.Values["idHostedDomain"] != null && long.TryParse(routeData.Values["idHostedDomain"].ToString(), out idEntityTemp))
                {
                    ServiceFactory.Instance.GlobalVariableService.IdHostedDomain = idEntityTemp;
                }

                if (dataTokens.ContainsKey("area"))
                {
                    areaName = (string)dataTokens["area"];
                }
                if (areaName == "DataCode")
                {
                    ServiceFactory.Instance.GlobalVariableService.Area = AreaEnum.DATACODE;
                }
                else if (areaName == "FlipBook")
                {
                    ServiceFactory.Instance.GlobalVariableService.Area = AreaEnum.FLIPBOOK;
                }
                else if (areaName == "Profile")
                {
                    ServiceFactory.Instance.GlobalVariableService.Area = AreaEnum.PERSON;
                }
                else if (areaName == "Company")
                {
                    ServiceFactory.Instance.GlobalVariableService.Area = AreaEnum.COMPANY;
                }
                else
                {
                    ServiceFactory.Instance.GlobalVariableService.Area = AreaEnum.GENERAL;
                }

                if (ServiceFactory.Instance.GlobalVariableService.UserLogged == null)
                {
                    InitializeSessionData();
                }

                if (AuthorizationTypeEnum == AuthorizationTypeEnum.ALLOW_ANONYMOUS)
                {
                    return;
                }

                if (GlobalVariableService.IsInstanceInitialized() && ServiceFactory.Instance.GlobalVariableService.UserLogged != null && IsUserAllowedToPerformAction())
                {
                    return;
                }

                //if (user == null && actionContext.HttpContext.Request.Headers["Authorization"] != null)
                //{
                //    RequestType = 2;
                //    token = actionContext.HttpContext.Request.Headers["Authorization"].ToString();
                //}

                //if (user == null && actionContext.HttpContext.Request.Params["Token"] != null)
                //{
                //    RequestType = 2;
                //    token = actionContext.HttpContext.Request.Params["Token"];
                //}

                //if (user == null && token != null)
                //{
                //    var accessToken = Startup.OAuthOptions.AccessTokenFormat.Unprotect(token);
                //    if (accessToken.Identity.IsAuthenticated)
                //    {
                //        user = ApplicationSignInManager.UserManager.FindByName(accessToken.Identity.Name);
                //        ServiceFactory.Instance.GlobalVariableService.UserLogged = ServiceFactory.Instance.UserService.MapUserIdentityCustom(user);
                //        ServiceFactory.Instance.GlobalVariableService.UserLoggedWithDetail = ServiceFactory.Instance.UserService.MapUserCustom(ServiceFactory.Instance.UserService.GetUserDetail(user.Id));
                //        ServiceFactory.Instance.GlobalVariableService.RolesForUserLogged = ServiceFactory.Instance.RoleService.GetRoleForUser(user.Id).Result.EntityList;
                //        ServiceFactory.Instance.GlobalVariableService.CombinedPermission = ServiceFactory.Instance.AuthenticationService.GetPermissionForMe();
                //    }
                //}

                //if (user != null)
                //{
                //    //TODO:Check for permission
                //    return;
                //}

                //actionContext.ControllerContext.RouteData.Values.Add(CustomVariableEnum.PERMISSION_FOR_USER.ToString(), combinedPermissions);
            }
            catch (Exception e)
            {
                actionContext.Controller.TempData["ErrorMessage"] = e.Message;
            }

            actionContext.Result = GetActionResult(actionContext);
        }


        private void InitializeSessionData()
        {
            string token = null;
            List<Claim> claims = ClaimsPrincipal.Current.Claims.ToList();

            if (HttpContext.Current.Request.Headers["Authorization"] != null)
            {
                token = HttpContext.Current.Request.Headers["Authorization"].ToString();
            }
            else if (HttpContext.Current.Request.Headers["Token"] != null)
            {
                token = HttpContext.Current.Request.Headers["Token"].ToString();
            }

            if (token != null)
            {
                var accessToken = Startup.OAuthOptions.AccessTokenFormat.Unprotect(token);
                if (accessToken.Identity.IsAuthenticated)
                {
                    claims = accessToken.Identity.Claims.ToList();
                }
            }

            Claim userIdClaim = claims.Where(p => p.Type == ClaimTypes.NameIdentifier).FirstOrDefault();
            bool areAuthenticationClaimsAvailable = userIdClaim != null && userIdClaim.Value != null;

            if (areAuthenticationClaimsAvailable)
            {
                long idUser = long.Parse(claims.Where(p => p.Type == ClaimTypes.NameIdentifier).First().Value.ToString());
                ServiceFactory.Instance.UserService.GetUserDetailForSessionAndAssignToSession(idUser);
            }
        }

        private bool IsUserAllowedToPerformAction()
        {
            return true;
        }

        private IAuthenticationManager AuthenticationManager { get { return HttpContext.Current.GetOwinContext().Authentication; } }
        private ApplicationSignInManager ApplicationSignInManager { get { return HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>(); } }


        public ActionResult GetActionResult(AuthorizationContext actionContext)
        {
            var url = new UrlHelper(actionContext.RequestContext);
            string redirectUrl = null;

            if (UnauthorizedResultEnum == UnauthorizedResultEnum.REDIRECT_TO_LOGIN || UnauthorizedResultEnum == UnauthorizedResultEnum.JSON_TIMEOUT)
            {
                //AuthenticationManager.SignOut();
                redirectUrl = url.Action("Authentication", "Authentication", new { area = "Authentication" });
            }

            if (UnauthorizedResultEnum == UnauthorizedResultEnum.JSON_TIMEOUT)
            {
                actionContext.Controller.TempData["ErrorMessage"] = "Session timeout, please login again";
            }
            else if (UnauthorizedResultEnum == UnauthorizedResultEnum.REDIRECT_TO_LOGIN)
            {
                actionContext.Controller.TempData["ErrorMessage"] = "Login to access the required section";
            }
            else
            {
                redirectUrl = url.Action("Index", "Error", new { area = "Public" });
            }

            return new RedirectResult(redirectUrl);
        }
    }
}
