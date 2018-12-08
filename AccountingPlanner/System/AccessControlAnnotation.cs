using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingPlanner.System
{
    public class AccessControlAttribute : ActionFilterAttribute
    {
        public string s;
        public AccessControlAttribute()
        {
        }

        public AccessControlAttribute(IConfiguration configuration)
        {
            this.s = configuration.GetConnectionString("Connection");
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
