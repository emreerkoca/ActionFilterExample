using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ActionFilterExample
{
    public class ActionFilterX : ActionFilterAttribute , IActionFilter
    {
        //Action tetiklenmeden once buraya gelir
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"), true);
            strWriter.WriteLine(filterContext.ToString() + " - " + DateTime.Now.ToString());
            strWriter.Close();
            base.OnActionExecuting(filterContext);
            Log(filterContext.ToString(), filterContext.RouteData);
        }

        //Action' daki islemler bittikten sonra buraya gelir.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"),true);
            strWriter.WriteLine(filterContext.ToString() + " - " +DateTime.Now.ToString());
            strWriter.Close();
            base.OnActionExecuted(filterContext);
            Log(filterContext.ToString(), filterContext.RouteData);
        }

        //Action' daki islemler bittiginde buraya gelir. OnActionExecuted bu metoddan onceliklidir.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"), true);
            strWriter.WriteLine(filterContext.ToString() + " - " + DateTime.Now.ToString());
            strWriter.Close();
            base.OnResultExecuting(filterContext);
            Log(filterContext.ToString(), filterContext.RouteData);
        }

        //Action' daki islemler bittiğinde buraya gelir.  OnResultExecuting bu metoddan onceliklidir.
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"), true);
            strWriter.WriteLine(filterContext.ToString() + " - " + DateTime.Now.ToString());
            strWriter.Close();
            base.OnResultExecuted(filterContext);
            Log(filterContext.ToString(), filterContext.RouteData);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
        }
    }
}