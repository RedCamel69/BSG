using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MembersBSG.Infrastructure.Filters
{
   
        public class ProfileActionAttribute : FilterAttribute, IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext
            filterContext)
            {

         
            }
            public void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (filterContext.Exception == null)
                {

                if (filterContext.HttpContext.Request.RequestType == "GET")
                {
                    //log register page visisted
                }


                //log page visit
                var action = filterContext.ActionDescriptor.ActionName;
                var controller = filterContext.Controller;

            }
            }
        }

    
}