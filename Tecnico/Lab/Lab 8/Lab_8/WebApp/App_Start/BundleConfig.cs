using System.Web;
using System.Web.Optimization;

namespace WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/libs").Include(
                        "~/Scripts/Libs/jquery-3.3.1.min.js",
                        "~/Scripts/Libs/bootstrap.min.js",
                        "~/Scripts/Libs/material.min.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/material.min.css"));

        }
    }
}
