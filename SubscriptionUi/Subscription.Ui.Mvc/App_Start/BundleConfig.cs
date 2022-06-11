using BundleTransformer.Core.Transformers;
using BundleTransformer.Yui.Minifiers;
using System.Web;
using System.Web.Optimization;

namespace Subscription.Ui.Mvc
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var styleTransformer = new StyleTransformer(new YuiCssMinifier());
            var orderer = new NonOrderingBundleOrderer();

            var bootstrapCss = (new StyleBundle("~/bundles/bootstrap-css").Include(
                "~/Scripts/bower_components/bootstrap-4.1.3/css/bootstrap.min.css"
            ));
            bootstrapCss.Transforms.Add(styleTransformer);
            bundles.Add(bootstrapCss);


            var bootstrapBundleOrderer = (new ScriptBundle("~/bundles/bootstrap-js").Include(
                "~/Scripts/bower_components/bootstrap-4.1.3/popper.min.js"
                , "~/Scripts/bower_components/bootstrap-4.1.3/js/bootstrap.min.js"
            ));
            bootstrapBundleOrderer.Orderer = orderer;
            bundles.Add(bootstrapBundleOrderer);


            var jqueryBundleOrderer = (new ScriptBundle("~/bundles/jquery-js").Include(
                "~/Scripts/custom/js/jquery.min.js"
            ));
            bundles.Add(jqueryBundleOrderer);


            var mandatoryFrontEndBundleOrderer = (new ScriptBundle("~/bundles/mandatory-front-end-js").Include(
                "~/Scripts/custom/js/angular.min.js"
            ));
            bundles.Add(mandatoryFrontEndBundleOrderer);


            var themeFrontEndBundleOrderer = (new ScriptBundle("~/bundles/theme-front-end-front-js").Include(
                "~/Scripts/theme/js/sticky.js"
                , "~/Scripts/theme/js/swipe.js"
                , "~/Scripts/theme/js/custom.js"
                , "~/Scripts/custom/js/custom.js"
                , "~/Scripts/theme/js/custom2.js"
            ));
            themeFrontEndBundleOrderer.Orderer = orderer;
            bundles.Add(themeFrontEndBundleOrderer);


            var adminSideBarBundleOrderer = (new ScriptBundle("~/bundles/admin-sidebar-js").Include(
                "~/Scripts/bower_components/toggle-sidebar/sidemenu.js"
            ));
            bundles.Add(adminSideBarBundleOrderer);


            var adminSidebarCss = (new StyleBundle("~/bundles/admin-sidebar-css").Include(
                "~/Scripts/bower_components/toggle-sidebar/sidemenu.css"
            ));
            adminSidebarCss.Transforms.Add(styleTransformer);
            bundles.Add(adminSidebarCss);

            var themeBackEndCss = (new StyleBundle("~/bundles/theme-back-end-back-css").Include(
                "~/Scripts/theme/css/admin-custom.css"
            ));
            themeBackEndCss.Transforms.Add(styleTransformer);
            bundles.Add(themeBackEndCss);


            var angularCommonOrderingBundleOrderer = new ScriptBundle("~/bundles/angular-common-js").Include(
                 "~/Angular/Model/Angular.Model.Common.js"
                , "~/Angular/Model/Angular.Model.js"
                , "~/Angular/Model/angular-project-model.js"
                , "~/Angular/Model/base-screen-constant-return-type.js"
                , "~/Angular/Common/common-utility.js"
                , "~/Angular/Common/generic-web-connection-service.js"
                , "~/Angular/Common/global-variables-factory.js"
                , "~/Angular/Common/session-variables.js"
                , "~/Angular/Common/download-response-service.js"
                , "~/Angular/Common/variables.js"
                , "~/Angular/Common/screen-mode-manager.js"
                , "~/Angular/Common/date-conversion.js"
                , "~/Angular/Common/screen-mode.js"
                , "~/Angular/Common/date-conversion.js"
                , "~/Angular/Common/simple-entity-controller.js"
                , "~/Angular/Common/simple-entity-popup-controller.js"
                , "~/Angular/Enum/Angular.Enum.Common.js"
                , "~/Angular/Enum/angular-project-enum.js"
                , "~/Angular/ReturnType/base-return-type.js"
                , "~/Angular/Common/file-manager.js"
                , "~/Angular/Common/validation-utility.js"
            );
            //angularCommonOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(angularCommonOrderingBundleOrderer);

            var angularBaseOrderingBundleOrderer =new ScriptBundle("~/bundles/angular-base-js").Include(
                "~/Angular/Model/combined-permission-model.js"
                , "~/Angular/Common/permission-manager.js"
                , "~/Angular/Common/loading-controller.js"
                , "~/Angular/Base/base-controller.js"
                , "~/Angular/Base/base-module.js"
                , "~/Angular/Base/base-web-service.js"
            );
            //angularBaseOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(angularBaseOrderingBundleOrderer);

            var angularAfterLoadOrderingBundleOrderer =(new ScriptBundle("~/bundles/angular-after-load-js").Include(
                "~/Angular/Filters/htmlToPlaintext.js"
                , "~/Scripts/bower_components/jquery-easing/jquery.easing.1.3.min.js"
                , "~//Scripts/bower_components/jquery-globalize/jquery.globalize.min.js"
            ));
            //angularAfterLoadOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(angularAfterLoadOrderingBundleOrderer);


            var angularDirectiveOrderingBundleOrderer = (new ScriptBundle("~/bundles/angular-directives").Include(
                 "~/Angular/Directive/compare-to.js"
                , "~/Angular/Directive/dismiss.js"
                , "~/Angular/Directive/empty-links.js"
                , "~/Angular/Directive/file-upload.js"
                , "~/Angular/Directive/init-from-form.js"
                , "~/Angular/Directive/angular-template-include.js"
                , "~/Angular/Directive/perfect-scrollbar.js"
                , "~/Angular/Directive/panel-tools.js"
                , "~/Angular/Directive/image-defer.js"
            ));
            //angularDirectiveOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(angularDirectiveOrderingBundleOrderer);


            var angularFormatterOrderingBundleOrderer = (new ScriptBundle("~/bundles/angular-formatter").Include(
                 "~/Angular/Formatter/address-formatter.js"
                 , "~/Angular/Formatter/person-formatter.js"
                 , "~/Angular/Formatter/gender-formatter.js"
            ));
            //angularFormatterOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(angularFormatterOrderingBundleOrderer);

            var bowerFrontEndOrderingBundleOrderer = (new ScriptBundle("~/bundles/bower-front-end-js").Include(
                 "~/Scripts/bower_components/fastclick/lib/fastclick.js"
                , "~/Scripts/bower_components/moment/min/moment.min.js"
                , "~/Scripts/bower_components/quill/quill.min.js"
                , "~/Scripts/bower_components/chartjs/Chart.min.js"
                , "~/Scripts/bower_components/angular-cookies/angular-cookies.min.js"
                , "~/Scripts/bower_components/angular-animate/angular-animate.min.js"
                , "~/Scripts/bower_components/angular-touch/angular-touch.min.js"
                , "~/Scripts/bower_components/angular-sanitize/angular-sanitize.min.js"
                , "~/Scripts/bower_components/ngstorage/ngStorage.min.js"
                , "~/Scripts/bower_components/angular-breadcrumb/dist/angular-breadcrumb.min.js"
                , "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-tpls.min.js"
                , "~/Scripts/bower_components/angular-loading-bar/build/loading-bar.min.js"
                , "~/Scripts/bower_components/angular-scroll/angular-scroll.min.js"
                , "~/Scripts/bower_components/angular-ui-switch/angular-ui-switch.min.js"
                , "~/Scripts/bower_components/angular-moment/angular-moment.min.js"
                , "~/Scripts/bower_components/AngularJS-Toaster/toaster.js"
                , "~/Scripts/bower_components/sweetalert/lib/sweet-alert.min.js"
                , "~/Scripts/bower_components/angular-sweetalert-promised/SweetAlert.min.js"
                , "~/Scripts/bower_components/angular-truncate/src/truncate.js"
                , "~/Scripts/bower_components/angular-notification-icons/dist/angular-notification-icons.min.js"
                , "~/Scripts/bower_components/angular-ui-select/dist/select.min.js"
                , "~/Scripts/bower_components/perfect-scrollbar/js/min/perfect-scrollbar.jquery.min.js"
                , "~/Scripts/bower_components/components-modernizr/modernizr.js"
                , "~/Scripts/bower_components/jquery.sparkline.build/dist/jquery.sparkline.min.js"
                , "~/Scripts/bower_components/v-accordion/dist/v-accordion.min.js"
                , "~/Scripts/bower_components/tr-ngGrid/trNgGrid.js"
                , "~/Scripts/bower_components/angular-xeditable/dist/js/xeditable.min.js"
                , "~/Scripts/bower_components/accountingjs/accounting.min.js"
                , "~/Scripts/bower_components/angular-file-upload/angular-file-upload.min.js"
                , "~/Scripts/bower_components/fileuploads/js/dropify.min.js"
                , "~/Scripts/bower_components/angular-perfect-scrollbar/src/angular-perfect-scrollbar.min.js"
                , "~/Scripts/bower_components/angucomplete-alt/angucomplete-alt.min.js"
                , "~/Scripts/bower_components/angular-filter/angular-filter.min.js"
                , "~/Scripts/bower_components/ng-quill/ng-quill.min.js"
                , "~/Scripts/bower_components/ng-table/ng-table.js"
            ));
            bowerFrontEndOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(bowerFrontEndOrderingBundleOrderer);


            var pluginBundleOrderer = (new ScriptBundle("~/bundles/plugins-js").Include(
                "~/Scripts/bower_components/linq/linq.min.js"
            ));
            bundles.Add(pluginBundleOrderer);


            var graphOrderingBundleOrderer = (new ScriptBundle("~/bundles/graph-js").Include(
                 "~/Scripts/bower_components/d3/d3.min.js"
                 , "~/Scripts/bower_components/c3-0.4.13/c3.min.js"
                 , "~/Scripts/bower_components/c3-angular-directive-1.3.0/c3-angular.min.js"
            ));
            graphOrderingBundleOrderer.Orderer = orderer;
            bundles.Add(graphOrderingBundleOrderer);


            var bowerFrontEndCssBundle = (new StyleBundle("~/bundles/bower-front-end-css").Include(
                "~/Scripts/bower_components/themify-icons/themify-icons.css"
                , "~/Scripts/bower_components/animate.css/animate.min.css"
                , "~/Scripts/bower_components/angular-loading-bar/build/loading-bar.min.css"
                , "~/Scripts/bower_components/angular-ui-switch/angular-ui-switch.min.css"
                , "~/Scripts/bower_components/AngularJS-Toaster/toaster.css"
                , "~/Scripts/bower_components/angular-notification-icons/dist/angular-notification-icons.min.css"
                , "~/Scripts/bower_components/angular-ui-select/dist/select.min.css"
                , "~/Scripts/bower_components/perfect-scrollbar/css/perfect-scrollbar.min.css"
                , "~/Scripts/bower_components/v-accordion/dist/v-accordion.min.css"
                , "~/Scripts/bower_components/sweetalert/lib/sweet-alert.min.css"
                , "~/Scripts/bower_components/tr-ngGrid/trNgGrid.css"
                , "~/Scripts/bower_components/angular-xeditable/dist/css/xeditable.css"
                , "~/Scripts/bower_components/selectize.js/css/selectize.default.css"
                , "~/Scripts/bower_components/quill/quill.snow.css"
                , "~/Scripts/bower_components/quill/quill.bubble.css"
            ));
            bowerFrontEndCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(bowerFrontEndCssBundle);

            var graphCssBundle = (new StyleBundle("~/bundles/graph-css").Include(
                 "~/Scripts/bower_components/c3-0.4.13/c3.min.css"
            ));
            graphCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(graphCssBundle);

            var authenticationBundleOrderer = (new ScriptBundle("~/bundles/authentication-js").Include(
                "~/Angular/Authentication/authentication-factory.js"
                , "~/Angular/Model/authentication-factory.js"
                , "~/Angular/Model/auth-screen-state-enum.js"
                , "~/Angular/Model/forgot-password-return-type.js"
                , "~/Angular/Model/register-screen-constant-return-type.js"
                , "~/Angular/Authentication/facebook-authentication.js"
                , "~/Angular/Authentication/google-authentication.js"
                , "~/Angular/Authentication/identity-authentication.js"
                , "~/Angular/Authentication/linkedin-authentication.js"
            ));
            //authenticationBundleOrderer.Orderer = orderer;
            bundles.Add(authenticationBundleOrderer);


            var leafletCssBundle = (new StyleBundle("~/bundles/leaflet-css").Include(
                "~/Scripts/bower_components/leaflet/leaflet.css"
            ));
            leafletCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(leafletCssBundle);

            var leafletBundleOrderer = (new ScriptBundle("~/bundles/leaflet-js").Include(
                "~/Scripts/bower_components/leaflet/leaflet.js"
                , "~/Scripts/bower_components/angular-simple-logger/angular-simple-logger.js"
                , "~/Scripts/bower_components/angular-ui-leaflet/src/services/google.js"
                , "~/Scripts/bower_components/angular-ui-leaflet/dist/ui-leaflet.js"
                , "~/Scripts/bower_components/angular-ui-leaflet/dist/ui-leaflet-layers.min.js"
            ));
            leafletBundleOrderer.Orderer = orderer;
            bundles.Add(leafletBundleOrderer);

            var theHubCssBundle = (new StyleBundle("~/bundles/subscription-css").Include(
                "~/Scripts/custom/css/subscription.css"
                , "~/Scripts/custom/css/utils.css"
            ));
            theHubCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(theHubCssBundle);

            /** THEME **/
            var themeCssBundle = (new StyleBundle("~/bundles/theme-css").Include(
                  "~/Scripts/theme/css/dashboard.css"
                , "~/Scripts/theme/fonts/font-awesome.min.css"
                , "~/Scripts/theme/Horizontal2/Horizontal-menu/dropdown-effects/fade-down.css"
                , "~/Scripts/theme/Horizontal2/Horizontal-menu/horizontal.css"
                , "~/Scripts/theme/Horizontal2/Horizontal-menu/color-skins/color.css"
                , "~/Scripts/theme/select2/select2.min.css"
                , "~/Scripts/theme/cookie/cookie.css"
                , "~/Scripts/theme/css/owl-carousel.css"
                , "~/Scripts/theme/scroll-bar/jquery.mCustomScrollbar.css"
                , "~/Scripts/theme/iconfonts/plugin.css"
                , "~/Scripts/theme/iconfonts/icons.css"
                 , "~/Scripts/bower_components/fileuploads/css/dropify.min.css"
                 , "~/Scripts/bower_components/scroll-bar/jquery.mCustomScrollbar.css"
            ));
            themeCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(themeCssBundle);

            var themeBundleOrderer = (new ScriptBundle("~/bundles/theme-js").Include(
                "~/Scripts/theme/js/jquery.sparkline.min.js"
                , "~/Scripts/theme/js/circle-progress.min.js"
                , "~/Scripts/theme/rating/jquery.rating-stars.min.js"
                , "~/Scripts/theme/owl-carousel/owl.carousel.js"
                , "~/Scripts/theme/Horizontal2/Horizontal-menu/horizontal.js"
                , "~/Scripts/theme/js/jquery.touchSwipe.min.js"
                , "~/Scripts/theme/select2/select2.full.min.js"
                , "~/Scripts/theme/js/select2.js"
                , "~/Scripts/theme/scroll-bar/jquery.mCustomScrollbar.concat.min.js"
            ));
            themeBundleOrderer.Orderer = orderer;
            bundles.Add(themeBundleOrderer);


            var themebackEndBundleOrderer = (new ScriptBundle("~/bundles/theme-back-end-back-js").Include(
                "~/Scripts/theme/counters/counterup.min.js"
                , "~/Scripts/theme/counters/waypoints.min.js"
                , "~/Scripts/bower_components/selectize.js/js/selectize.min.js"
                , "~/Scripts/theme/js/admin-custom.js"
            ));
            themebackEndBundleOrderer.Orderer = orderer;
            bundles.Add(themebackEndBundleOrderer);


            var scrollBarBundleOrderer = (new ScriptBundle("~/bundles/scrollbar-js").Include(
                 "~/Scripts/bower_components/scroll-bar/jquery.mCustomScrollbar.concat.min.js"
            ));
            bundles.Add(scrollBarBundleOrderer);

            /** LANDING PAGE **/
            var landingPageCssBundle = (new StyleBundle("~/bundles/landing-theme-css").Include(
                "~/Scripts/landing/css/slick.css",
                "~/Scripts/landing/css/magnific-popup.css",
                "~/Scripts/landing/css/LineIcons.css",
                "~/Scripts/landing/css/default.css",
                "~/Scripts/landing/css/style.css"
            ));
            landingPageCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(landingPageCssBundle);

            var landingThemeBundleOrderer = (new ScriptBundle("~/bundles/landing-theme-js").Include(
                "~/Scripts/landing/js/typed.min.js",
                "~/Scripts/landing/js/isotope.pkgd.min.js",
                "~/Scripts/landing/js/imagesloaded.pkgd.min.js",
                "~/Scripts/landing/js/scrolling-nav.js",
                "~/Scripts/landing/js/slick.min.jss",
                "~/Scripts/landing/js/jquery.magnific-popup.min.js",
                "~/Scripts/landing/js/main.js"
            ));
            landingThemeBundleOrderer.Orderer = orderer;
            bundles.Add(landingThemeBundleOrderer);


            var adminItemdBundleOrderer = (new ScriptBundle("~/bundles/admin-item-js").Include(
                "~/Angular/Shared/admin-footer.js",
                "~/Angular/Shared/admin-header.js",
                "~/Angular/Shared/admin-sidebar.js",
                "~/Angular/Shared/admin-item-module.js"
            ));
            adminItemdBundleOrderer.Orderer = orderer;
            bundles.Add(adminItemdBundleOrderer);


            /** PROFILE ONE PAGER **/
            var profileOnePagerCssBundle = (new StyleBundle("~/bundles/profile-one-pager-css").Include(
                "~/Scripts/landing/css/LineIcons.css",
                "~/Scripts/onepager/profile/css/profile-one-pager.css"
            ));
            profileOnePagerCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(profileOnePagerCssBundle);


            /** COMPANY ONE PAGER **/
            var companyOnePagerCssBundle = (new StyleBundle("~/bundles/company-one-pager-css").Include(
                "~/Scripts/landing/css/LineIcons.css",
                "~/Scripts/onepager/company/css/company-one-pager.css"
            ));
            companyOnePagerCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(companyOnePagerCssBundle);

            var companyOnePagerBundleOrderer = (new ScriptBundle("~/bundles/company-one-pager-js").Include(
                "~/Scripts/onepager/company/js/company-one-pager.js"
            ));
            companyOnePagerBundleOrderer.Orderer = orderer;
            bundles.Add(companyOnePagerBundleOrderer);

            /** GENERAL ONE PAGER **/
            var generalOnePagerBundleOrderer = (new ScriptBundle("~/bundles/general-one-pager-js").Include(
                "~/Scripts/bower_components/sweetalert/lib/sweet-alert.min.js",
                "~/Scripts/onepager/general/one-pager-general.js"
            ));
            generalOnePagerBundleOrderer.Orderer = orderer;
            bundles.Add(generalOnePagerBundleOrderer);

            var generalOnePagerCssBundle = (new StyleBundle("~/bundles/general-one-pager-css").Include(
                "~/Scripts/bower_components/sweetalert/lib/sweet-alert.min.css"
            ));
            generalOnePagerCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(generalOnePagerCssBundle);



            /** SIGNALR **/
            var signalRBundleOrderer = (new ScriptBundle("~/bundles/signalr-js").Include(
                "~/Scripts/signalR/jquery.signalR-2.4.1.min.js"
            ));
            signalRBundleOrderer.Orderer = orderer;
            bundles.Add(signalRBundleOrderer);


            /** FLIPBOOK ONE PAGER **/
            var flipBookOnePagerBundleOrderer = (new ScriptBundle("~/bundles/flipBook-one-pager-js").Include(
                "~/Scripts/flipbook/js/LoadingJS.js",
                "~/Scripts/flipbook/template/Metro/javascript/main.js",
                "~/Scripts/flipbook/js/book_config.js",
                "~/Scripts/flipbook/js/flipHtml5.hiSlider2.min.js",
                "~/Scripts/flipbook/js/MovingBackgrounds.min.js",
                "~/Scripts/flipbook/js/slideJS.js",
                "~/Scripts/flipbook/js/searchtext.js"
            ));
            flipBookOnePagerBundleOrderer.Orderer = orderer;
            bundles.Add(flipBookOnePagerBundleOrderer);


            var flipBookOnePagerCssBundle = (new StyleBundle("~/bundles/flipBook-one-pager-css").Include(
                "~/Scripts/flipbook/template/Metro/style/phoneTemplate.css",
                "~/Scripts/flipbook/template/Metro/style/style.css",
                "~/Scripts/flipbook/template/Metro/style/player.css",

                "~/Scripts/flipbook/template/Metro/style/template.css",
                "~/Scripts/flipbook/css/hiSlider2.min.css",
                "~/Scripts/flipbook/css/MovingBackgrounds.min.css"
            ));
            flipBookOnePagerCssBundle.Transforms.Add(styleTransformer);
            bundles.Add(flipBookOnePagerCssBundle);



            BundleTable.EnableOptimizations = false;

        }
    }
}
