using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingPlanner.Models.SubUser;
using Microsoft.AspNetCore.Mvc;

namespace AccountingPlanner.Controllers.Panel
{
    public class SubUserController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Panel/SubUser/Index.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SubUserModel subUserModel)
        {
            if(!ModelState.IsValid)
            {
                return View("~/Views/Panel/SubUser/Index.cshtml");
            }

            

            return View("~/Views/Panel/SubUser/Index.cshtml");
        }
    }
}