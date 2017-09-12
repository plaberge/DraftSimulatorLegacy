using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraftSimulator.DAL;
using Microsoft.ApplicationInsights;
using DraftSimulator.ServerLogic;
using System.Net.Http;

namespace DraftSimulator.Web.Controllers
{
    public class ExecuteDraftRunController : Controller
    {
        
        public ActionResult Index()
        {
            string IPAddress = string.Empty;
            string[] SplitIPAddress;
            string IPv4Address;

            if (HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                IPAddress = HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Request.UserHostAddress.Length != 0)
            {
                IPAddress = HttpContext.Request.UserHostAddress;
            }

            //DEBUGGING
            //IPAddress = "24.150.185.77:3639";

            SplitIPAddress = IPAddress.Split(':');
            IPv4Address = SplitIPAddress[0];

            DraftRunLocation drl = new DraftRunLocation(IPv4Address);

            DraftRun draftrun = new DraftRun(drl);
            ViewBag.DraftRun = draftrun;
            ViewBag.DRL = drl;
            ViewBag.IPAddress = IPAddress;
            ViewBag.IPv4Address = IPv4Address;
            

            //Application Insights - CUSTOM EVENT
            var telemetry = new TelemetryClient();
            telemetry.TrackEvent("User clicked on creating a new DraftRun. Draft Winner was " + draftrun.TeamList4[0].TeamCity + " " + draftrun.TeamList4[0].TeamName + " with Draft Balls: " + draftrun.Ball1.ToString() + " | " + draftrun.Ball2.ToString() + " | " + draftrun.Ball3.ToString() + " | " + draftrun.Ball4.ToString() + ".");

            return View();
        }

        

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }

        public DraftRun GetDraftRun()
        {
            DraftRun draftrun = new DraftRun();
            return draftrun;
        }
    }
}