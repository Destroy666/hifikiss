using System.Web;
using System.Web.Optimization;

namespace KissHiFi
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/msgBoxJS").Include(
                        "~/Scripts/jquery.msgBox.js"));

            bundles.Add(new ScriptBundle("~/bundles/DropZoneJS").Include(
                        "~/Scripts/dropzone.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/galleryJS").Include(
                        "~/Scripts/jquery.galleriffic.js",
                        "~/Scripts/jquery.opacityrollover.js"));

            bundles.Add(new ScriptBundle("~/bundles/musicJS").Include(
                        "~/Scripts/ttw-music-player-min.js",
                        "~/Scripts/jquery.jplayer.js",
                        "~/Scripts/myplaylist.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/msgBox").Include("~/Content/msgBoxLight.css"));

            bundles.Add(new StyleBundle("~/bundles/DropZone").Include(
                        "~/Content/DropZone/css/dropzone.css",
                        "~/Content/DropZone/css/basic.css"));

            bundles.Add(new StyleBundle("~/bundles/gallery").Include(
                        "~/Content/gallery/basic.css",
                        "~/Content/gallery/galleriffic-2.css"));

            bundles.Add(new StyleBundle("~/bundles/music").Include(
                        "~/Content/music.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}