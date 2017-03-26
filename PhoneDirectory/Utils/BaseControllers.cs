using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneDirectory.Utils
{
    public class BaseControllers : System.Web.Mvc.Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Session["admin"] == null || Session["admin"].ToString()   != "1")
            {
                filterContext.Result = new RedirectResult("~/admin-girisi");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}