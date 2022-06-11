using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Mvc;
using Subscription.Service;
using Subscription.Service.Authentication;
using System.Security.Claims;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Subscription.Business;

namespace Subscription.Ui.Mvc.Controllers
{
    //[CustomAuthorization(AuthorizationTypeEnum.REQUIRE_AUTHORIZATION)]
    [AllowAnonymous]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetAuthManager();
            // you should be able to get session stuff here!!
            base.OnActionExecuting(filterContext);
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        protected ServiceFactory serviceFactory
        {
            get
            {

                return ServiceFactory.Instance;
            }
        }

        protected void SetAuthManager()
        {
            ServiceFactory.AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            ServiceFactory.SignInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            ServiceFactory.UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ServiceFactory.OAuthOptions = Startup.OAuthOptions;
        }

        protected ApplicationSignInManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }

        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

        }

        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        protected string Subdomain
        {
            get { return (string)Request.RequestContext.RouteData.Values["subdomain"]; }
        }
    }
}