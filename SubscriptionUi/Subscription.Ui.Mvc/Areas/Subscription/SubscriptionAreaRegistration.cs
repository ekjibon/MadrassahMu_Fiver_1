using CoreWeb.Ui.Common.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.Subscription

{
    public partial class SubscriptionAreaRegistration : AreaRegistration 
    {
        public static BundleCollection bundles;
        public static AreaRegistrationContext areaRegistrationContext;
        public override string AreaName
        {
            get
            {
                return "Subscription";
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