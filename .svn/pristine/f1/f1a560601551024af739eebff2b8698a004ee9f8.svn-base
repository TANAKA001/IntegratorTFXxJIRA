using System.Web.Optimization;

namespace TFS_IntegradoraWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                      "~/Scripts/angular.min.js",
                      "~/Scripts/angular-messages.min.js",
                      "~/Scripts/angular-route.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/css/AngularGrid").Include(
                      "~/Content/AngularGrid/angularGrid.min.css",
                      "~/Content/AngularGrid/theme-fresh.css"));

            bundles.Add(new ScriptBundle("~/configuracao").Include(
                        "~/Scripts/crossDomainIframeCommunication.min.js",
                        "~/Scripts/i18n/angular-locale_pt-br.js",
                        "~/Scripts/angularGrid.min.js"));

#if !DEBUG
            BundleTable.EnableOptimizations = true;//Reduz tamanho e garante atualização quando mudar.
#endif
        }
    }
}
