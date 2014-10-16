using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace studProfkom.App_Start
{
  public static class BundleConfig
  {
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new StyleBundle("~/content/css")
        .Include("~/Content/Styles/flexslider.css")
        .Include("~/Content/Styles/plusgallery.css")
        .Include("~/Content/Styles/jquery-ui-1.10.3.custom.css")
        .Include("~/Content/Styles/Site.css"));

      bundles.Add(new StyleBundle("~/content/bootstrap")
        .Include("~/Content/Styles/bootstrap.min.css")
        .Include("~/Content/Styles/Site.css"));

      bundles.Add(new ScriptBundle("~/content/js")
        .Include("~/Scripts/jquery-2.0.2.min.js")
        .Include("~/Content/Scripts/jquery-ui-1.10.3.custom.min.js")
        .Include("~/Content/Scripts/jquery.flexslider-min.js")
        .Include("~/Content/Scripts/plusgallery.js")
        .Include("~/Content/Scripts/Site.js"));

      bundles.Add(new StyleBundle("~/content/admin/css")
        .Include("~/Content/Scripts/themes/default.css")
        .Include("~/Content/Scripts/themes/default.date.css")
        .Include("~/Content/Scripts/themes/default.time.css"));

      bundles.Add(new ScriptBundle("~/content/admin/js")
        .Include("~/Content/Scripts/knockout-2.2.1.js")
        .Include("~/Scripts/jquery.validate.min.js")
        .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
        .Include("~/Content/Scripts/legacy.js")
        .Include("~/Content/Scripts/picker.js")
        .Include("~/Content/Scripts/picker.date.js")
        .Include("~/Content/Scripts/picker.time.js")
        .Include("~/Content/Scripts/article-crud.js")
        .Include("~/Content/Scripts/articleEditViewModel.js"));

      BundleTable.EnableOptimizations = true;
    }
  }
}