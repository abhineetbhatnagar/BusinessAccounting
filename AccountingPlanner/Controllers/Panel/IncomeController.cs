using AccountingPlanner.Models.Estimate;
using AccountingPlanner.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Security.Claims;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingPlanner.Controllers.Panel
{
    [Authorize]
    public class IncomeController : Controller
    {

        #region Controller Properties
        private IConfiguration _configuration;
        private CommonHelper _objHelper = new CommonHelper();
        private MySQLGateway _objDataHelper;
        #endregion

        public IncomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._objDataHelper = new MySQLGateway(this._configuration.GetConnectionString("Connection"));
        }

        #region Render Page
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["EstimateList"] = null;

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("selectBy", "estimate"));
            parameters.Add(new KeyValuePair<string, string>("param1", _objHelper.GetTokenData(HttpContext.User.Identity as ClaimsIdentity, "id_organization")));
            parameters.Add(new KeyValuePair<string, string>("param2", ""));

            DataTable _dtResp = _objDataHelper.ExecuteProcedure("entity_master_select", parameters);

            if (this._objHelper.checkDBNullResponse(_dtResp))
            {
                ViewData["EstimateList"] = _dtResp;
            }
            else
            {
                ViewData["ListErrorMessage"] = "Unable to fetch data. Try again later.";
            }

            return View("~/Views/Panel/Income/Index.cshtml");
        }
        #endregion

        #region Get Add Page
        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Panel/Income/Create.cshtml");
        }
        #endregion

        #region Insert Estimate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromBody] EstimateModel estimateModel)
        {
            if(!ModelState.IsValid)
            {
                return View("~/Views/Panel/Income/Create.cshtml");
            }

            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("i_id_organization_master", _objHelper.GetTokenData(HttpContext.User.Identity as ClaimsIdentity, "id_organization")));
            parameters.Add(new KeyValuePair<string, string>("i_id_currency_master", estimateModel.currency));
            parameters.Add(new KeyValuePair<string, string>("i_id_customer_master", estimateModel.cutomer));
            parameters.Add(new KeyValuePair<string, string>("i_date", estimateModel.date));
            parameters.Add(new KeyValuePair<string, string>("i_expires", estimateModel.expires));
            parameters.Add(new KeyValuePair<string, string>("i_footer", estimateModel.footer));
            parameters.Add(new KeyValuePair<string, string>("i_header", estimateModel.header));
            parameters.Add(new KeyValuePair<string, string>("i_memo", estimateModel.memo));
            parameters.Add(new KeyValuePair<string, string>("i_po_so", estimateModel.po_so));
            parameters.Add(new KeyValuePair<string, string>("i_subhead", estimateModel.subhead));
            parameters.Add(new KeyValuePair<string, string>("i_version", estimateModel.version));
            parameters.Add(new KeyValuePair<string, string>("i_created_by", _objHelper.GetTokenData(HttpContext.User.Identity as ClaimsIdentity, "id_user")));
            
            DataTable _dtResp = _objDataHelper.ExecuteProcedure("insert_estimate_master", parameters);

            if (this._objHelper.checkDBResponse(_dtResp))
            {
                // ENTER DETAILS
                parameters = new List<KeyValuePair<string, string>>();

                parameters.Add(new KeyValuePair<string, string>("i_id_estimate_master", _dtResp.Rows[0]["estimate_id"].ToString()));
                for (int i = 0; i < estimateModel.estimateDetailList.Count; i++)
                {
                    parameters.Add(new KeyValuePair<string, string>("i_id_tax_master", estimateModel.estimateDetailList[i].tax));
                    parameters.Add(new KeyValuePair<string, string>("i_id_product_master", estimateModel.estimateDetailList[i].product));
                    parameters.Add(new KeyValuePair<string, string>("i_description", estimateModel.estimateDetailList[i].description));
                    parameters.Add(new KeyValuePair<string, string>("i_quantity", estimateModel.estimateDetailList[i].quantity));
                    parameters.Add(new KeyValuePair<string, string>("i_price", estimateModel.estimateDetailList[i].price));
                    parameters.Add(new KeyValuePair<string, string>("i_amount", estimateModel.estimateDetailList[i].amount));

                    DataTable _dtRespDetail = _objDataHelper.ExecuteProcedure("insert_estimate_detail", parameters);

                    // Remove for next iteration
                    parameters.Remove(new KeyValuePair<string, string>("i_id_tax_master", estimateModel.estimateDetailList[i].tax));
                    parameters.Remove(new KeyValuePair<string, string>("i_id_product_master", estimateModel.estimateDetailList[i].product));
                    parameters.Remove(new KeyValuePair<string, string>("i_description", estimateModel.estimateDetailList[i].description));
                    parameters.Remove(new KeyValuePair<string, string>("i_quantity", estimateModel.estimateDetailList[i].quantity));
                    parameters.Remove(new KeyValuePair<string, string>("i_price", estimateModel.estimateDetailList[i].price));
                    parameters.Remove(new KeyValuePair<string, string>("i_amount", estimateModel.estimateDetailList[i].amount));
                }
                
                
            }
            else
            {
                ViewData["ErrorMessage"] = "Estimates service unavailable";
            }

            return View("~/Views/Panel/Income/Create.cshtml");
        }
        #endregion
    }
}
