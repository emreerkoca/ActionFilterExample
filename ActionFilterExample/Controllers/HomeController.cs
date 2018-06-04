using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionFilterExample.Controllers
{
    public class HomeController : Controller
    {
        [ActionFilterX]
        public ActionResult Index()
        {
            StreamWriter strWriter = new StreamWriter(HttpContext.Server.MapPath("~/log.txt"), true);
            strWriter.WriteLine(this.ControllerContext.RouteData.Values["action"].ToString() + " - " + DateTime.Now.ToString());
            strWriter.Close();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}