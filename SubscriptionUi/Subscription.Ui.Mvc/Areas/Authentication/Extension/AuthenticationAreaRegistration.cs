using CoreWeb.Ui.Common.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;


namespace Subscription.Ui.Mvc.Areas.Authentication
{
    public partial class AuthenticationAreaRegistration : AreaRegistration
    {
        public void RegisterBundlesExtension()
        {
            bundles.Add(new ScriptBundle("~/bundles/public-security-base-script").Include(
               // "~/Areas/Public/Angular/Security/Model/register-screen-constant-return-type.js", 
               "~/Areas/Authentication/Angular/Model/auth-screen-state-enum.js",
               "~/Areas/Authentication/Angular/Model/forgot-password-return-type.js",
               "~/Areas/Authentication/Angular/Model/register-screen-constant-return-type.js",
               "~/Areas/Authentication/Angular/authentication-2-web-service.js",
               "~/Areas/Authentication/Angular/auth-module.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/public-security-script").Include(
               "~/Areas/Authentication/Angular/authentication-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/public-home-js").Include(
               "~/Areas/Public/Angular/PublicHome/Model/save-quick-message-dto.js",
               "~/Areas/Public/Angular/PublicHome/Model/save-quick-message-return-type.js",
               "~/Areas/Public/Angular/PublicHome/public-home-web-service.js",
               "~/Areas/Public/Angular/PublicHome/public-home-module.js",
               "~/Areas/Public/Angular/PublicHome/public-home-controller.js"
          ));
        }
        public void RegisterAreaExtension()
        {

        }
    }
}