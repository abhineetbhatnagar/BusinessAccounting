using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AccountingPlanner.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AccountingPlanner
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AccessControlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MySQLGateway _dB;
        private readonly CommonHelper _helper;

        public AccessControlMiddleware(RequestDelegate next, string connectionString)
        {
            this._dB = new MySQLGateway(connectionString);
            this._helper = new CommonHelper();
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.User.Identity.IsAuthenticated)
            {

                List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();

                parameters.Add(new KeyValuePair<string, string>("user_id", _helper.GetTokenData(httpContext.User.Identity as ClaimsIdentity, "id_user")));
                parameters.Add(new KeyValuePair<string, string>("org_id", _helper.GetTokenData(httpContext.User.Identity as ClaimsIdentity, "id_organization")));

                if (httpContext.Request.Path.ToString().StartsWith("/Customer"))
                {
                    parameters.Add(new KeyValuePair<string, string>("url", "CUSTOMER"));
                    parameters.Add(new KeyValuePair<string, string>("method", httpContext.Request.Method));

                    DataTable _dtResp = _dB.ExecuteProcedure("access_control", parameters);

                    if (_dtResp.Rows[0]["response"].ToString() != "1")
                    {
                        httpContext.Response.Redirect("/Error/Forbidden");
                    }
                }

                else if (httpContext.Request.Path.ToString().StartsWith("/Business"))
                {
                    parameters.Add(new KeyValuePair<string, string>("url", "BUSINESS"));
                    parameters.Add(new KeyValuePair<string, string>("method", httpContext.Request.Method));

                    DataTable _dtResp = _dB.ExecuteProcedure("access_control", parameters);

                    if (_dtResp.Rows[0]["response"].ToString() != "1")
                    {
                        httpContext.Response.Redirect("/Error/Forbidden");
                    }
                }

                else if (httpContext.Request.Path.ToString().StartsWith("/ProductService"))
                {
                    parameters.Add(new KeyValuePair<string, string>("url", "PRODUCTSERVICE"));
                    parameters.Add(new KeyValuePair<string, string>("method", httpContext.Request.Method));

                    DataTable _dtResp = _dB.ExecuteProcedure("access_control", parameters);

                    if (_dtResp.Rows[0]["response"].ToString() != "1")
                    {
                        httpContext.Response.Redirect("/Error/Forbidden");
                    }
                }

                else if (httpContext.Request.Path.ToString().StartsWith("/Tax"))
                {
                    parameters.Add(new KeyValuePair<string, string>("url", "TAX"));
                    parameters.Add(new KeyValuePair<string, string>("method", httpContext.Request.Method));

                    DataTable _dtResp = _dB.ExecuteProcedure("access_control", parameters);

                    if (_dtResp.Rows[0]["response"].ToString() != "1")
                    {
                        httpContext.Response.Redirect("/Error/Forbidden");
                    }
                }

                else if (httpContext.Request.Path.ToString().StartsWith("/Vendor"))
                {
                    parameters.Add(new KeyValuePair<string, string>("url", "VENDOR"));
                    parameters.Add(new KeyValuePair<string, string>("method", httpContext.Request.Method));

                    DataTable _dtResp = _dB.ExecuteProcedure("access_control", parameters);

                    if (_dtResp.Rows[0]["response"].ToString() != "1")
                    {
                        httpContext.Response.Redirect("/Error/Forbidden");
                    }
                }

            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessControlMiddleware>();
        }
    }
}
