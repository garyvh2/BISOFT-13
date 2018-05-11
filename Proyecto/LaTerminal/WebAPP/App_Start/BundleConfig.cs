using System.Web;
using System.Web.Optimization;

namespace WebAPP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        // >> PolyFills
                        "~/Scripts/Libs/polyfill-es6.js",
                        "~/Scripts/Libs/polyfill-promise.js",
                        // >> jQuery
                        "~/Scripts/Libs/jquery-3.3.1.min.js",
                        "~/Scripts/Libs/jquery.validate.js",
                        "~/Scripts/Libs/jquery.validate.additional-methods.js",
                        "~/Scripts/Libs/jquery-ui.min.js",
                        "~/Scripts/Libs/jquery.ext.js",
                        // >> Data Threatment
                        "~/Scripts/Libs/underscore.js",
                        "~/Scripts/Libs/async.min.js",
                        "~/Scripts/Libs/moment.js",
                        "~/Scripts/Libs/moment-timezone.js",
                        // >> UI Libs
                        "~/Scripts/Libs/popper.js",
                        "~/Scripts/Libs/bootstrap.min.js",
                        "~/Scripts/Libs/EasePack.min.js",
                        "~/Scripts/Libs/rAF.js",
                        "~/Scripts/Libs/TweenLite.min.min.js", 
                        "~/Scripts/Libs/sweetalert2.all.js",
                        "~/Scripts/Libs/fontawesome-iconpicker.min.js",
                        "~/Scripts/Libs/DraggableList.js",
                        "~/Scripts/Libs/material.min.js",
                        "~/Scripts/Libs/select2.min.js",
                        // >> Custom Libs
                        //"~/Scripts/Views/laterminal_lite.js",
                        "~/Scripts/Views/ControlActions.js",
                        "~/Scripts/Views/BaseView.js",
                        // >> Data Tables
                        "~/Scripts/Libs/datatables.min.js",
                        // >> Braintree
                        "~/Scripts/Libs/dropin.min.js"
                        ));
            
            bundles.Add(new ScriptBundle("~/bundles/LTL").Include(
                        "~/Scripts/Views/LTL/ltl.js",
                        "~/Scripts/Views/LTL/ltl.session.js",
                        "~/Scripts/Views/LTL/ltl.forms.js",
                        "~/Scripts/Views/LTL/ltl.table.js",
                        "~/Scripts/Views/LTL/ltl.conf.js",
                        "~/Scripts/Views/LTL/ltl.components.js",
                        "~/Scripts/Views/LTL/ltl.map.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/APIs")
                .IncludeDirectory("~/Scripts/APIs", "*.js", true));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/normalize.css",
                      // >> jQuery
                      "~/Content/jquery-ui.min.css",
                      "~/Content/bootstrap.css",
                      "~/Content/princing.css",
                      "~/Content/material.min.css",
                      "~/Content/select2.min.css",
                      // >> Font Awesome
                      "~/Content/fontawesome-all.css",
                      "~/Content/fontawesome-iconpicker.min.css",
                      // >> Data Tables
                      "~/Content/datatables.min.css"));
        }
    }
}
