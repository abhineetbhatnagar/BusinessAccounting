using AccountingPlanner.Models;
using AccountingPlanner.Models.Profile;
using AccountingPlanner.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;

namespace AccountingPlanner.Controllers.Panel
{
    [Authorize]
    public class HomeController : Controller
    {
        #region Controller Properties
        private IConfiguration _configuration;
        private CommonHelper _objHelper = new CommonHelper();
        private MySQLGateway _objDataHelper;
        #endregion

        public HomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._objDataHelper = new MySQLGateway(this._configuration.GetConnectionString("Connection"));
        }

        public IActionResult Index()
        {
            return View("~/Views/Panel/Home/Index.cshtml");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View("~/Views/Panel/Home/Index.cshtml");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View("~/Views/Panel/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View("~/Views/Panel/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
