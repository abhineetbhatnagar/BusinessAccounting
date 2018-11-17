using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AccountingPlanner.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AccountingPlanner.Controllers.Generic
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [Route("api/panel")]
    public class Panel : ControllerBase
    {
        #region Controller Properties
        private IConfiguration _configuration;
        private IHostingEnvironment _env;
        private CommonHelper _objHelper = new CommonHelper();
        private MySQLGateway _objDataHelper;
        #endregion

        public Panel(IConfiguration configuration, IHostingEnvironment env)
        {
            this._configuration = configuration;
            this._env = env;
            this._objDataHelper = new MySQLGateway(this._configuration.GetConnectionString("Connection"));
        }

        [HttpGet("BusinessList")]
        public JsonResult BusinessList()
        {
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

            parameters.Add(new KeyValuePair<string, string>("selectBy", "user_business"));
            parameters.Add(new KeyValuePair<string, string>("param1", _objHelper.GetTokenData(HttpContext.User.Identity as ClaimsIdentity, "id_user")));
            parameters.Add(new KeyValuePair<string, string>("param2", ""));

            DataTable _dtResp = _objDataHelper.ExecuteProcedure("entity_master_select", parameters);
            List<Dictionary<string, string>> resp = new List<Dictionary<string, string>>();

            if (this._objHelper.checkDBNullResponse(_dtResp))
            {
                resp =  _objHelper.ConvertTableToDictionary(_dtResp);
            }

            return new JsonResult(resp);
        }
    }
}