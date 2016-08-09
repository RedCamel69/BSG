using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MembersBSG.Infrastructure.Filters
{
    public class ProfileResultAttribute : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
           
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }
    }
}