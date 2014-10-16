using StackExchange.Profiling;
using studProfkom.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace studProfkom
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            if (ex is HttpRequestValidationException)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.Write(@"
                    <html><head><title>Використання HTML не дозволено</title>
                    <script language='JavaScript'><!--
                    function back() { history.go(-1); } //--></script></head>
                    <body style='font-family: Arial, Sans-serif;'>
                    <h1>Ой!</h1>
                    <p>Вибачте, але використання HTML не дозволено на цій сторінці.</p>
                    <p>Будь-ласка, впевніться, що те що ви ввели, не містить кутових дужок,
                    таких, як &lt; або &gt;.</p>
                    <p><a href='javascript:back()'>Повернутись назад</a></p>
                    </body></html>
                    ");
                Response.End();

            }
        }
        protected void Application_BeginRequest()
        {
            if (Request.IsLocal) { MiniProfiler.Start(); } //or any number of other checks, up to you 
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop(); //stop as early as you can, even earlier with MvcMiniProfiler.MiniProfiler.Stop(discardResults: true);
        }
    }
}