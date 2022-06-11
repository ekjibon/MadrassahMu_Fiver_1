using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.Transaction
{
    public partial class TransactionAreaRegistration
    {
        public void RegisterBundlesExtension()
        {
            bundles.Add(new ScriptBundle("~/bundles/transaction-sale-admin-essentials-js").Include(
                "~/Areas/Transaction/Angular/transaction-sale-web-service.js",
                "~/Areas/Transaction/Angular/transaction-sale-module.js",
                "~/Areas/Transaction/Angular/transaction-sale-controller.js",
                "~/Areas/Transaction/Angular/transaction-sale-signature-controller.js",
                "~/Areas/Transaction/Angular/transaction-sale-listing-controller.js",
                "~/Areas/Transaction/Angular/credit-transaction-sale-listing-controller.js",
                "~/Areas/Transaction/Angular/Model/transaction-sale-listing-paging-info.js",
                "~/Areas/Subscription/Angular/Model/transaction-list-sorting-paging-info.js",
                "~/Areas/Transaction/Angular/Model/get-signature-for-temporary-transaction-signature-dto.js",
                "~/Areas/Transaction/Angular/Model/get-email-for-transaction-dto.js",
                "~/Areas/Transaction/Angular/Model/get-email-for-transaction-return-type.js",
                "~/Areas/Transaction/Angular/Model/save-email-for-transaction-dto.js",
                "~/Areas/Transaction/Angular/Model/save-email-for-transaction-return-type.js",
                "~/Areas/Transaction/Angular/Model/send-email-to-client-dto.js",
                "~/Areas/Transaction/Angular/Model/save-temporary-transaction-dto.js",
                "~/Areas/Transaction/Angular/Model/save-temporary-transaction-return-type.js",
                "~/Areas/Transaction/Angular/Model/get-signature-for-temporary-transaction-signature-return-type.js",
                "~/Areas/Transaction/Angular/Model/get-temporary-transaction-signature-for-workstation-return-type.js",
                "~/Areas/Transaction/Angular/Model/get-temporary-transaction-signature-for-workstation-dto.js",
                "~/Areas/Transaction/Angular/Model/transaction-entity-model.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/transaction-sale-dto-return-type-js").Include(
                "~/Areas/Transaction/Angular/save-transaction-payment-dto.js",
                "~/Areas/Transaction/Angular/save-transaction-payment-return-type.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/subscription-essentials-js").Include(
                "~/Areas/Subscription/Angular/modal-controller.js",
                "~/Areas/Subscription/Angular/subscription-web-service.js",
                "~/Areas/Subscription/Angular/Model/subscription-model.js",
                "~/Areas/Subscription/Angular/Model/customer-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/Model/product-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/Model/transaction-list-sorting-paging-info.js",
                "~/Areas/Subscription/Angular/customer-search-popup-modal-controller.js",
                "~/Areas/Subscription/Angular/product-search-popup-modal-controller.js"
            ));
        }

        public void RegisterAreaExtension()
        {
            areaRegistrationContext.MapRoute(
                "Transaction_default",
                "Transaction/{controller}/{action}/{idTransaction}/{idTransactionDue}/{mode}/{isSubsection}",
                new { action = "Index", idTransaction = UrlParameter.Optional, idTransactionDue = UrlParameter.Optional, mode = UrlParameter.Optional, isSubsection = UrlParameter.Optional }
            );
        }
    }
}