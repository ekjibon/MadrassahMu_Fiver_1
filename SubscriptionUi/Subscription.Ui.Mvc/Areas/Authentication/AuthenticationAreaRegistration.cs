using CoreWeb.Ui.Common.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.Authentication
{
    public partial class AuthenticationAreaRegistration : AreaRegistration 
    {
        public static BundleCollection bundles;
        public static AreaRegistrationContext areaRegistrationContext;

        public override string AreaName 
        {
            get 
            {
                return "Authentication";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Authentication_default",
                "Authentication/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            areaRegistrationContext = context;
            RegisterAreaExtension();

            AreaRegistrationState state = (AreaRegistrationState)context.State;
            bundles = state.BundleCollection;
            RegisterBundlesExtension();
        }
    }
}