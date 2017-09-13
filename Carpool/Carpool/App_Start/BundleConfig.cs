using System.Web;
using System.Web.Optimization;

namespace Carpool
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/main.js",
                      "~/Scripts/_reference.js",
                      "~/Scripts/custom.js",
                      "~/Scripts/classie.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/gmap3.js",
                      "~/Scripts/isotop.pkgd.js",
                      "~/Scripts/JavaScript.js",
                      "~/Scripts/jquery-1.10.2.intellisense.js",
                      "~/Scripts/jquery-1.10.2.js",
                      "~/Scripts/jquery-1.10.2.min.js",
                      "~/Scripts/jquery-ui.min.js",
                      "~/Scripts/jquery.appear.js",
                      "~/Scripts/jquery.countdown.min.js",
                      "~/Scripts/jquery.countdownTimer.min.js",
                      "~/Scripts/jquery.easing.min.js",
                      "~/Scripts/jquery.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/jquery.nicescroll.min.js",
                      "~/Scripts/jquery.validate-vsdoc.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusiv.js",
                      "~/Scripts/jquery.validate.unobtrusive.min.js",
                      "~/Scripts/map-int.js",
                      "~/Scripts/masonry-horizontal.js",
                      "~/Scripts/modernizr-2.6.2.js",
                      "~/Scripts/modernizr-2.8.3-respond-1.4.2.min.js",
                      "~/Scripts/npm.js",
                      "~/Scripts/odometer.js",
                      "~/Scripts/owl.carousel.js",
                      "~/Scripts/owl.carousel.min.js",
                      "~/Scripts/parallax.min.js",
                      "~/Scripts/plg-int.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/responsivethumbnailgallery.js",
                      "~/Scripts/scrolling-nav.js",
                      "~/Scripts/scrollreveal.min.js",
                      "~/Scripts/earch.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/color.css",
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/magnific-popup.css",
                      "~/Content/main-black.css",
                      "~/Content/main.css",
                      "~/Content/normailize.css",
                      "~/Content/odometer-theme-car.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/owl.theme.css",
                      "~/Content/responsive.css",
                      "~/Content/scrolling-nav.css",
                      "~/Content/Site.css",
                      "~/Content/style.css"));
        }
    }
}
