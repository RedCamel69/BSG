using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MembersBSG.Infrastructure.Filters
{
    public class AllowLocalRequestAttribute : AuthorizeAttribute
    {

        private bool localAllowed;

        public AllowLocalRequestAttribute(bool allowedParam)
        {
            localAllowed = allowedParam;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Request.IsLocal)
            {
                return localAllowed;
            }
            else
            {
                return true;
            }
        }

    }
}