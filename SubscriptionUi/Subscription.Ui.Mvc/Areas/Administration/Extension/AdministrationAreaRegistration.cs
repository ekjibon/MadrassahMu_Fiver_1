using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.Administration
{
    public partial class AdministrationAreaRegistration : AreaRegistration 
    {
        public void RegisterBundlesExtension()
        {
            bundles.Add(new ScriptBundle("~/bundles/administration-product-essentials-js").Include(
                 "~/Areas/Administration/Angular/administration-product-web-service.js",
                 "~/Areas/Administration/Angular/administration-product-module.js",
                 "~/Areas/Administration/Angular/AdministrationProduct/administration-new-product-controller.js",
                 "~/Areas/Administration/Angular/AdministrationProduct/administration-product-controller.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/administration-product-js").Include(
                "~/Areas/Subscription/Angular/Model/product-list-sorting-paging-info.js",
                "~/Areas/Administration/Angular/AdministrationProduct/Model/get-administration-product-dto.js",
                "~/Areas/Administration/Angular/AdministrationProduct/Model/save-administration-product-dto.js",
                "~/Areas/Administration/Angular/AdministrationProduct/Model/save-administration-product-return-type.js",
                "~/Areas/Administration/Angular/AdministrationProduct/administration-product-listing-controller.js",
                "~/Areas/Administration/Angular/AdministrationProduct/Model/administration-product-listing-paging-info.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/administration-customer-essentials-js").Include(
                 "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-web-service.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-module.js"
             ));

            bundles.Add(new ScriptBundle("~/bundles/administration-customer-js").Include(
                "~/Areas/Subscription/Angular/Model/customer-list-sorting-paging-info.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/Model/get-administration-customer-dto.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/Model/save-administration-customer-dto.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/Model/save-administration-customer-return-type.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-listing-controller.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/administration-new-customer-controller.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-controller.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/Model/administration-customer-listing-paging-info.js"
            ));

            //-------- TO REMOVE ---------
            bundles.Add(new ScriptBundle("~/bundles/administration-customer-admin-essentials-js").Include(
                "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-web-service.js",
                "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-module.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/administration-customer-detail-js").Include(
                 "~/Areas/Administration/Angular/AdministrationCustomer/Model/administration-customer-screen-contant-return-type.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/Model/get-administration-customer-dto.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/Model/get-administration-customer-return-type.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/Model/save-administration-customer-dto.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/Model/save-administration-customer-return-type.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/Model/administration-customer-listing-paging-info.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-controller.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/administration-new-customer-controller.js",
                 "~/Areas/Administration/Angular/AdministrationCustomer/administration-customer-listing-controller.js"
            ));

            //----------------------------
        }

        public void RegisterAreaExtension()
        {
            areaRegistrationContext.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}/{mode}/{isSubsection}",
                new { action = "Index", id = UrlParameter.Optional, mode = UrlParameter.Optional, isSubsection = UrlParameter.Optional }
            );
        }
    }
}