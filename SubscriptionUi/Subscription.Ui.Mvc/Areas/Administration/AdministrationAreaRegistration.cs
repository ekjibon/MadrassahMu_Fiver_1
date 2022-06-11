using CoreWeb.Ui.Common.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.Administration
{
    public partial class AdministrationAreaRegistration : AreaRegistration 
    {
        public static BundleCollection bundles;
        public static AreaRegistrationContext areaRegistrationContext;
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            areaRegistrationContext = context;
            RegisterAreaExtension();

            AreaRegistrationState state = (AreaRegistrationState)context.State;
            bundles = state.BundleCollection;
            RegisterBundlesExtension();

        }
    }
}