using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.UI;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Role;
namespace SwiftHrManagement.web
{
    public class BasePage : System.Web.UI.Page
    {
        protected SessionStore ReadSession()
        {
            SessionStore sessionStore = (SessionStore)Session["sessionStore"];
            if (Session["sessionStore"] == null)
            {
                string url = HttpUtility.UrlEncode(Request.Url.ToString());
                Response.Redirect("~/Default.aspx?ReturnUrl=" + url);
            }
            Session["sessionStore"] = sessionStore;
            return sessionStore;
        }
        public string AutoSelect(string str1, string str2)
        {
            string str3 = "";
            // if stored value or selected value is zero then return some other value and display first value as "select"  for combo.
            //str3 = str2 == "0" ? "200" : str2;
            str3 = str2 == "0" ? "0" : str2;
            if (str1 == str3)
                return "selected=\"selected\"";
            else
                return "";

        }
        public DateTime ParseDateTime(string data)
        {

            DateTime m;
            DateTime.TryParse(data, out m);
            return m;
        }
        protected void WriteSession(SessionStore sessionStore)
        {
            Session["sessionStore"] = sessionStore;
        }
        public String ShowDecimalDipesh(String strVal)
        {
            return (strVal == null ? String.Format("{0:0,0.00}", double.Parse(strVal).ToString()) : "0");
        }
        public String ShowDecimal(string data)
        {
            var m = ParseDouble(data);
            return ShowDecimal(m);
        }
        public String ShowDecimal(double data)
        {
            return data.ToString("N");
        }
        public bool ParseBoolen(string data)
        {
            bool m;
            bool.TryParse(data, out m);
            return m;
        }
        public int ParseInt(string data)
        {
            int d;
            int.TryParse(data, out d);
            return d;
        }
        public String filterstring(String strVal)
        {
            if (strVal == null)
                return "null";

            string str = strVal.Trim();
            if (str != "" && str != "0" && str != "-1" && str != "null")
            {
                str = str.Replace(";", "");
                str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");
                str = "'" + str + "'";
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }
        public String filterStringCms(String strVal)
        {
            string str = strVal.Trim();
            if (str != "" && str != "0" && str != "-1" && str != "null")
            {
                str = str.Replace(";", "");
                str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");
                //str = str.Replace("amp", "");
                //str = str.Replace("amp;", "");
                str = "'" + str + "'";
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }
        public static void SetMessage(DbResult value)
        {
            HttpContext.Current.Session["message"] = value;

        }
        public static DbResult GetMessage()
        {
            return (DbResult)HttpContext.Current.Session["message"];
        }
        public string SetMessageBox()
        {
           
            if (Session["message"] == null)
                return null;

            var dbResult = GetMessage();

            var cssClass = dbResult.ErrorCode == "0" ? "success" : (dbResult.ErrorCode == "1" ? "errorExplanation" : "warning");
            //Session.Remove("message");
            return cssClass;
        }
        public String filterPageContent(String strVal)
        {
            string str = strVal.Trim();
            if (str != "" && str != "0" && str != "-1")
            {
                str = str.Replace(";", "");
                str = str.Replace("--", "");
                str = str.Replace("&nbsp", "");
                str = str.Replace("delete", "");
                str = str.Replace("update", "");
                str = str.Replace("drop", "");
                str = str.Replace("truncate", "");
                str = str.Replace("insert", "");
                str = str.Replace("<br>", "");
                str = str.Replace("'", "''");
                str = "'" + str + "'";
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }
        public String FilterQuote(String strVal)
        {
            string str = strVal.Trim();
            if (str != "" && str != "0" && str != "-1")
            {
                str.Replace(";", "");
                str.Replace("--", "");
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }
        public void checkAuthentication(long userId, long menuId, bool redirectIfNotAuthorised)
        {
            RoleMenuDAOInv _role = new RoleMenuDAOInv();
            if (!_role.hasAccess(userId, menuId))
            {
                string page2redirect = "";
                if (ConfigurationManager.AppSettings.Get("unauthorised_page_msg") != null)
                {
                    page2redirect = ConfigurationManager.AppSettings.Get("unauthorised_page_msg");
                    HttpContext.Current.Response.Redirect(page2redirect);
                }
            }
        }
        public static string ReadQueryString(string key, string defVal)
        {
            return HttpContext.Current.Request.QueryString[key] ?? defVal;
        }
        public double ParseDouble(string data)
        {
            double m;
            double.TryParse(data, out m);
            return m;
        }
        public static long ReadNumericDataFromQueryString(string key)
        {
            var tmpId = ReadQueryString(key, "0");
            long tmpIdLong;
            long.TryParse(tmpId, out tmpIdLong);
            return tmpIdLong;
        }
        public long CEOID()
        {

            return 1096;
        }
        public static bool GetCharToBool(string value)
        {
            return value.ToUpper() == "Y" ? true : false;
        }
        public static string GetBoolToChar(bool chk)
        {
            return chk ? "Y" : "N";

        }
        public string AppraisalWeight(double Marks)
        {
            string Result = "";

            if (Marks > 0 && Marks <= 25)
            {
                Result = "Satisfactory";
            }
            if (Marks > 25 && Marks <= 40)
            {
                Result = "Average";
            }
            if (Marks > 40 && Marks <= 55)
            {
                Result = "Good";
            }
            if (Marks > 55 && Marks <= 70)
            {
                Result = "Very Good";
            }
            if (Marks > 71 && Marks <= 85)
            {
                Result = "Excellent";
            }
            if (Marks > 85 && Marks <= 100)
            {
                Result = "Outstanding";
            }

            return Result;
        }
        public string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }
        public string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }
        public string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }
        public bool DoesHrUser(string empId)
        {
            clsDAO _clsdao = new clsDAO();
            if (empId == "1000")
            {
                return true;
            }
            else
            {
                var sql = "select 'X' from Employee where DEPARTMENT_ID =28 and EMPLOYEE_ID = " + empId + "";
                return _clsdao.CheckStatement(sql);
            }
        }
         public static void MakeNumericTextbox(ref System.Web.UI.WebControls.TextBox tb)
        {
            tb.Attributes.Add("onfocus", "resetInput(this, '0', 1, true);");
            tb.Attributes.Add("onblur", "resetInput(this, '0', 2, true);");
            tb.Attributes.Add("onkeydown", "return numericOnly(this, (event?event:evt), true);");
            tb.Attributes.Add("onpaste", "return manageOnPaste(this);");
        }
        public static void CallBackJs1(Page page, String scriptName, string functionName)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), scriptName, functionName, true);
        }
        public static string DataTableToHTML(ref DataTable dt, bool showSerialNumber = false)
        {
            int sNo = 1;
            var sb = new System.Text.StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.Append("<tr>");
            if (showSerialNumber == true)
            {
                sb.Append("<th>S.No.</th>");
            }
            foreach (DataColumn dc in dt.Columns)
            {
                sb.Append("<th>" + dc.ColumnName.ToString() + "</th>");
            }
            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                if (showSerialNumber == true)
                {
                    sb.Append("<td>" + sNo + "</td>");
                    sNo++;
                }
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td>" + row[dc].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table></div>");

            return sb.ToString();
        }

       
    }
}
