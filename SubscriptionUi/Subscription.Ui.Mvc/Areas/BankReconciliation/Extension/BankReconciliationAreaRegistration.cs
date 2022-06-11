using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc.Areas.BankReconciliation
{
    public partial class BankReconciliationAreaRegistration : AreaRegistration
    {
        public void RegisterBundlesExtension()
        {
            bundles.Add(new ScriptBundle("~/bundles/bank-reconciliation-essentials-js").Include(
               "~/Areas/BankReconciliation/Angular/BankReconciliation/bank-reconciliation-web-service.js",
               "~/Areas/BankReconciliation/Angular/BankReconciliation/bank-reconciliation-module.js"
           ));

            bundles.Add(new ScriptBundle("~/bundles/bank-reconciliation-listing-js").Include(
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/bank-reconciliation-sorting-paging-info.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/bank-reconciliation-list-return-type.js",
                 "~/Areas/BankReconciliation/Angular/BankReconciliation/bank-reconciliation-listing-controller.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bank-reconciliation-js").Include(
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/save-bank-reconciliation-file-dto.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/save-bank-reconciliation-file-return-type.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/analyse-bank-reconciliation-file-dto.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/analyse-bank-reconciliation-file-return-type.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/load-bank-reconciliation-content-return-type.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/load-bank-reconciliation-content-dto.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/load-bank-statement-staging-detail-batch-dto.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/analyse-bank-reconciliation-file-for-batch-dto.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/analyse-bank-reconciliation-file-for-batch-return-type.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/reconcile-bank-order-return-type.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/save-reconcile-bank-order-dto.js",
                "~/Areas/BankReconciliation/Angular/BankReconciliation/Model/load-bank-statement-staging-detail-batch.js",
                 "~/Areas/BankReconciliation/Angular/BankReconciliation/bank-reconciliation-controller.js",
                 "~/Areas/BankReconciliation/Angular/BankReconciliation/reconcile-bank-order-popup-controller.js"
            ));
        }
        public void RegisterAreaExtension()
        {
            areaRegistrationContext.MapRoute(
                "BankReconciliation_default",
                "BankReconciliation/{controller}/{action}/{id}/{mode}/{isSubSection}",
                new { action = "Index", id = UrlParameter.Optional, mode = UrlParameter.Optional, isSubSection = UrlParameter.Optional }
            );
        }

    }
}