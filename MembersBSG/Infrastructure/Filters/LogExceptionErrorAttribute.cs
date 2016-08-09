using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MembersBSG.Infrastructure.Filters
{
    public class LogExceptionErrorAttribute : HandleErrorAttribute
    {
        //https://gist.github.com/lkaczanowski/5899045

        public override void OnException(ExceptionContext filterContext)
        {
            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            var exception = filterContext.Exception.Message;

            //log to db
        }
    }
}