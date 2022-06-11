using System.Web.Mvc;
using System.Web.Optimization;
namespace Subscription.Ui.Mvc.Areas.Subscription
{
    public partial class SubscriptionAreaRegistration : AreaRegistration
    {
        public void RegisterBundlesExtension()
        {
            bundles.Add(new StyleBundle("~/bundles/subscription-essentials-css").Include(
            "~/Scripts/custom/css/index.css",
            "~/Scripts/custom/css/bootstrap.css",
            "~/Scripts/custom/css/select.min.css",
            "~/Scripts/custom/css/ng-table.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-essentials-js").Include(
                "~/Areas/Subscription/Angular/modal-controller.js",
                "~/Areas/Transaction/Angular/transaction-sale-web-service.js",
                "~/Areas/Subscription/Angular/subscription-web-service.js",
                "~/Areas/Subscription/Angular/Model/subscription-model.js",
                "~/Areas/Subscription/Angular/Model/customer-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/Model/product-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/Model/transaction-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/customer-search-popup-modal-controller.js",
                "~/Areas/Subscription/Angular/product-search-popup-modal-controller.js"
            ));


            bundles.Add(new ScriptBundle("~/bundles/subscription-schedule-transaction-js").Include(
                "~/Areas/Subscription/Angular/schedule-transaction-module.js",
                "~/Areas/Subscription/Angular/schedule-transaction-controller.js",
                "~/Areas/Subscription/Angular/Model/get-payment-due-detail-dto.js",
                "~/Areas/Subscription/Angular/Model/get-payment-due-detail-return-type.js",
                "~/Areas/Subscription/Angular/Model/save-scheduled-transaction-return-type.js",
                "~/Areas/Subscription/Angular/Model/save-scheduled-transaction-dto.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-select-customer-js").Include(
                "~/Areas/Subscription/Angular/select-customer-module.js",
                "~/Areas/Subscription/Angular/select-customer-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-select-transaction-js").Include(
                "~/Areas/Subscription/Angular/select-transaction-module.js",
                "~/Areas/Subscription/Angular/select-transaction-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-define-frequency-js").Include(
                "~/Areas/Subscription/Angular/define-frequency-module.js",
                "~/Areas/Subscription/Angular/define-frequency-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-summary-js").Include(
                "~/Areas/Subscription/Angular/summary-module.js",
                "~/Areas/Subscription/Angular/summary-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-payment-js").Include(
                "~/Areas/Subscription/Angular/subscription-web-service.js",
                "~/Areas/Subscription/Angular/payment-module.js",
                "~/Areas/Subscription/Angular/payment-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/view-all-scheduled-transactions-js").Include(
                "~/Areas/Subscription/Angular/view-all-scheduled-transaction-module.js",
                "~/Areas/Subscription/Angular/view-all-scheduled-transactions-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/view-scheduled-transactions-js").Include(
                "~/Areas/Subscription/Angular/subscription-web-service.js",
                "~/Areas/Subscription/Angular/Model/subscription-model.js",
                "~/Areas/Subscription/Angular/view-scheduled-transaction-module.js",
                "~/Areas/Subscription/Angular/view-scheduled-transactions-controller.js",
                "~/Areas/Subscription/Angular/Model/customer-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/Model/view-schedule-transaction-model.js",
                "~/Areas/Subscription/Angular/Model/get-scheduled-transaction-dto.js",
                "~/Areas/Subscription/Angular/Model/get-last-payment-date-for-customer-dto.js",
                "~/Areas/Subscription/Angular/Model/get-last-payment-date-for-customer-return-type.js",
                "~/Areas/Subscription/Angular/Model/get-scheduled-transaction-return-type.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/payment-scheduled-transactions-js").Include(
                "~/Areas/Subscription/Angular/payment-scheduled-transaction-module.js",
                "~/Areas/Subscription/Angular/payment-scheduled-transaction-controller.js",
                "~/Areas/Subscription/Angular/Model/save-payment-for-transaction-due-dto.js",
                "~/Areas/Subscription/Angular/Model/save-payment-for-transaction-due-return-type.js"
            ));
        }

        public void RegisterAreaExtension()
        {
            areaRegistrationContext.MapRoute(
                "Subscription_default",
                "Subscription/{controller}/{action}/{idTransaction}/{idTransactionDue}/{mode}/{isSubsection}",
                new { action = "Index", idTransaction = UrlParameter.Optional, idTransactionDue = UrlParameter.Optional, mode = UrlParameter.Optional, isSubsection = UrlParameter.Optional }
            );
        }
    }
}