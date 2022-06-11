using CoreWeb.Ui.Common.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.Transaction
{
    public partial class TransactionAreaRegistration : AreaRegistration 
    {
        public static BundleCollection bundles;
        public static AreaRegistrationContext areaRegistrationContext;
        public override string AreaName 
        {
            get 
            {
                return "Transaction";
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