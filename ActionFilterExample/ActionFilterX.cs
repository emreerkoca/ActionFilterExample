using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        }

        //Action' daki islemler bittikten sonra buraya gelir.
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"),true);
            strWriter.WriteLine(filterContext.ToString() + " - " +DateTime.Now.ToString());
            strWriter.Close();
            base.OnActionExecuted(filterContext);
        }

        //Action' daki islemler bittiginde buraya gelir. OnActionExecuted bu metoddan onceliklidir.
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"), true);
            strWriter.WriteLine(filterContext.ToString() + " - " + DateTime.Now.ToString());
            strWriter.Close();
            base.OnResultExecuting(filterContext);
        }

        //Action' daki islemler bittiğinde buraya gelir.  OnResultExecuting bu metoddan onceliklidir.
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            StreamWriter strWriter = new StreamWriter(filterContext.HttpContext.Server.MapPath("~/log.txt"), true);
            strWriter.WriteLine(filterContext.ToString() + " - " + DateTime.Now.ToString());
            strWriter.Close();
            base.OnResultExecuted(filterContext);
        }
    }
}