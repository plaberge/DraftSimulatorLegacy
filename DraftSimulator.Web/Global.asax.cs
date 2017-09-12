using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Configuration;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace DraftSimulator.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // The code below adds the Application Insights Instrumentation Key
            // from the Azure Web App application settings.
            var instrumentationKey = ConfigurationManager.AppSettings["APPINSIGHTS_INSTRUMENTATIONKEY"];

            if (string.IsNullOrWhiteSpace(instrumentationKey))
            {
                throw new ConfigurationErrorsException("Missing app setting 'APPINSIGHTS_INSTRUMENTATIONKEY' used for Application Insights");
            }

            TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;

            new TelemetryClient().TrackEvent("Application started at " + DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt"));

        }
    }
}
