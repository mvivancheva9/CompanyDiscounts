// <copyright file="BundleConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Web;
using System.Web.Optimization;

namespace CompanyDiscount.Web
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
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                     "~/Scripts/AdministrationScripts/bootstrap.min.js",
                     "~/Scripts/AdministrationScripts/Chart.js",
                     "~/Scripts/AdministrationScripts/classie.js",
                     "~/Scripts/AdministrationScripts/jquery-1.10.2.min.js",
                     "~/Scripts/AdministrationScripts/jquery.flexisel.js",
                     "~/Scripts/AdministrationScripts/jquery.flot.min.js",
                     "~/Scripts/AdministrationScripts/jquery.nicescroll.js",
                     "~/Scripts/AdministrationScripts/scripts.js",
                     "~/Scripts/AdministrationScripts/skycons.js",
                     "~/Scripts/AdministrationScripts/uisearch.js",
                     "~/Scripts/AdministrationScripts/wow.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                "~/Content/css/bootstrap.min.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/colorbox.css",
                      "~/Content/css/elastislide.css",
                      "~/Content/css/font-awesome.css",
                      "~/Content/css/graph.css",
                      "~/Content/css/icon-font.min.css",
                      "~/Content/css/magnific-popup.css",
                      "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/front").Include(
                     "~/Content/front-panel/main.css"));

            bundles.Add(new ScriptBundle("~/bundles/front").Include(
                      "~/Scripts/FrontPageScripts/main.js"));

        }
    }
}
