using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;


namespace MVC5Course.Controllers
{
    class RecordExecuteTimeAttribute  : ActionFilterAttribute
    {
        string excutetime = "";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            excutetime += DateTime.Now.Ticks.ToString();
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            excutetime += " " + DateTime.Now.Ticks.ToString();
            //filterContext.Controller.ViewBag.ExeTime = excutetime;
           // base.OnResultExecuted(filterContext);
            base.OnActionExecuted(filterContext);
        }
      
       
    }
}
