using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AccountingPlanner.System
{
    public class CommonHelper
    {
        public string GetTokenData(ClaimsIdentity identity, string key)
        {
            return identity.FindFirst(key).Value;
        }

        public string GetModelErrorMessages(ModelStateDictionary errors)
        {
            string messages = "";
            foreach (var item in errors)
            {
                for (int j = 0; j < item.Value.Errors.Count; j++)
                {
                    //messages += $"{item.Key.ToString().ToUpper()}: {item.Value.Errors[j].ErrorMessage} <br />";
                    messages += $"<strong>{item.Value.Errors[j].ErrorMessage}</strong><br/>";
                }
            }
            return messages;
        }

        public List<Dictionary<string, string>> ConvertTableToDictionary(DataTable dt)
        {
            List<Dictionary<string, string>> _list = new List<Dictionary<string, string>>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Dictionary<string, string> _row = new Dictionary<string, string>();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    _row.Add(dt.Columns[j].ColumnName, dt.Rows[i][dt.Columns[j].ColumnName].ToString());
                }
                _list.Add(_row);
            }
            return _list;
        }

        // Overloaded Function for Null Check DataTable
        public Boolean checkDBNullResponse(DataTable _dt)
        {
            return (_dt == null) ? false : true;
        }

        // Overloaded Function for Null Check DataSet
        public Boolean checkDBNullResponse(DataSet _ds)
        {
            return (_ds == null) ? false : true;
        }

        // Overloaded Function for complete check DataTable
        public Boolean checkDBResponse(DataTable _dt)
        {
            return (_dt == null || _dt.Rows.Count == 0) ? false : true;
        }

        // Overloaded Function for complete check DataSet
        public Boolean checkDBResponse(DataSet _ds)
        {
            return (_ds == null || _ds.Tables.Count == 0) ? false : true;
        }

        public void SendSMS(string mobilenumber, string msg)
        {
            try
            {
                String smsservicetype = "singlemsg";
                String query = "username=" + HttpUtility.UrlEncode("dogrpunjab-taxn") + "&password=" + HttpUtility.UrlEncode("taxn@pb2") + "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) + "&content=" + HttpUtility.UrlEncode(msg) + "&mobileno=" + HttpUtility.UrlEncode(mobilenumber) + "&senderid=" + HttpUtility.UrlEncode("PBGOVT");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
                byte[] byteArray = Encoding.ASCII.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                request.KeepAlive = false;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(byteArray, 0, byteArray.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {
                string messgae = ex.Message;
            }
        }

        public string generateOTP(int length = 6)
        {
            Random generator = new Random();

            return generator.Next((int)Math.Pow(10, (length - 1)), (int)Math.Pow(10, length) - 1).ToString();
        }

    }
}
