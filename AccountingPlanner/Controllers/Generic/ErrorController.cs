using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountingPlanner.Controllers.Generic
{
    [AllowAnonymous]
    [Route("Error")]
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}