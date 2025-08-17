using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.Library
{
    public static class GetStatic 
    {
        public static void AlertMessage(Page page)
        {
            if (HttpContext.Current.Session["message"] == null)
                return;
            var dbResult = GetMessage();
            if (dbResult.Msg == "")
                return;
            CallBackJs1(page, "Alert Message", "alert(\"" + FilterMessageForJs(dbResult.Msg) + "\");");
            HttpContext.Current.Session.Remove("message");
        }


        public static void AlertMessage(Page page,string msg)
        {
            CallBackJs1(page, "Alert Message", "alert(\"" + msg + "\");");           
        }
        public static String FilterMessageForJs(string strVal)
        {
            if (strVal.ToLower() != "null")
            {
                strVal = strVal.Replace("\"", "");
            }
            return strVal;
        }
        public static string GetReportPagesize()
        {
            return ReadWebConfig("reportPageSize");
        }
        public static double RoundOff(double num, int place, int currDecimal)
        {
            if (currDecimal != 0)
                return Math.Round(num, currDecimal);
            else if (place != 0)
                return (Math.Round(num / place)) * place;
            return Math.Round(num, 0);
        }
        public static Boolean IsNumeric(string stringToTest)
        {
            int result;
            return int.TryParse(stringToTest, out result);
        }
        
        public static string GetSessionId()
        {
            return HttpContext.Current.Session.SessionID;
        }

        #region Read/Write Data
        public static string ReadCookie(string key, string defVal)
        {
            var cookie = HttpContext.Current.Request.Cookies[key];
            return cookie == null ? defVal : HttpContext.Current.Server.HtmlEncode(cookie.Value);
        }

        public static string ReadFormData(string key, string defVal)
        {
            return HttpContext.Current.Request.Form[key] ?? defVal;
        }

        public static string ReadReportFormData(string key, string defVal)
        {
            var prefix = ReadWebConfig("controlNamePrefix");
            return ReadFormData(prefix + key, defVal);
        }

        public static string ReadQueryString(string key, string defVal)
        {
            ////string str=HttpContext.Current.Request.QueryString[key] ?? defVal;
            ////str = str.Replace("#", "");
            ////return str;
            return HttpContext.Current.Request.QueryString[key] ?? defVal;
        }

        public static string ReadValue(string gridName, string key)
        {
            key = gridName + "_ck_" + key;
            var ck = ReadCookie(key, "");
            return ck;
        }

        public static void WriteValue(string gridName, ref DropDownList ddl, string key)
        {
            key = gridName + "_ck_" + key;
            WriteCookie(key, ddl.Text);
        }
        public static void WriteValue(string gridName, ref TextBox tb, string key)
        {
            key = gridName + "_ck_" + key;
            WriteCookie(key, tb.Text);
        }
        #endregion

        public static string ReadSession(string key, string defVal)
        {
            return HttpContext.Current.Session[key] == null ? defVal : HttpContext.Current.Session[key].ToString();
        }

        public static void WriteSession(string key, string value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static void WriteCookie(string key, string value)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var myCookie = new HttpCookie(key);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(myCookie);
                HttpContext.Current.Response.Cookies.Remove(key);
            }
            var httpCookie = new HttpCookie(key, value);
            httpCookie.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static string FormatData(string data)
        {
            if (string.IsNullOrEmpty(data))
                return "";
            decimal m;
            decimal.TryParse(data, out m);

            return m.ToString("F2");
        }

        public static string FormatData(string data, string dataType)
        {
            if (string.IsNullOrEmpty(data))
                return "&nbsp;";

            if (dataType == "D")
            {
                DateTime d;
                DateTime.TryParse(data, out d);
                return d.Year + "-" + d.Month.ToString("00") + "-" + d.Day.ToString("00");
            }

            if (dataType == "DT")
            {
                DateTime t;
                DateTime.TryParse(data, out t);
                return t.Year + "-" + t.Month.ToString("00") + "-" + t.Day.ToString("00") + " " + t.Hour.ToString("00") + ":" + t.Minute.ToString("00");
            }

            if (dataType == "M")
            {
                decimal m;
                decimal.TryParse(data, out m);

                return m.ToString("N");
            }
            return data;

        }

        public static string NumberToWord(string data)
        {
            var str = data.Split('.');
            int number = Convert.ToInt32(str[0]);
            int dec = 0;
            if (str.Length > 1)
                dec = Convert.ToInt32(str[1].Substring(0, 2));

            if (number == 0) return "Zero";

            if (number == -2147483648)
                return
                    "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight Rupees Fifty Paisa";

            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            StringBuilder sb = new System.Text.StringBuilder();

            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }

            string[] words0 = {
                                  "", "One ", "Two ", "Three ", "Four ",
                                  "Five ", "Six ", "Seven ", "Eight ", "Nine "
                              };

            string[] words1 = {
                                  "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
                                  "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen "
                              };

            string[] words2 = {
                                  "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
                                  "Seventy ", "Eighty ", "Ninety "
                              };

            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            num[0] = number % 1000;               // units 
            num[1] = number / 1000;
            num[2] = number / 100000;
            num[1] = num[1] - 100 * num[2];       // thousands 
            num[3] = number / 10000000;           // crores 
            num[2] = num[2] - 100 * num[3];       // lakhs 

            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }


            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;

                u = num[i] % 10;  // ones 
                t = num[i] / 10;
                h = num[i] / 100; // hundreds 
                t = t - 10 * h;   // tens 

                if (h > 0) sb.Append(words0[h] + "Hundred ");

                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");

                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }

                if (i != 0) sb.Append(words3[i - 1]);

            }

            sb.Append(" Rupees ");

            int d1 = dec / 10;
            int d2 = dec % 10;
            if (d1 == 0)
                sb.Append(words0[d1]);
            else if (d1 == 1)
                sb.Append(words1[d2]);
            else
                sb.Append(words2[d1 - 2] + words0[d2]);

            if (dec > 0)
                sb.Append(" Paisa");
            return sb.ToString().TrimEnd() + " only";
        }

        public static DataTable GetHistoryChangedList(string logType, string oldData, string newData)
        {
            var stringSeparators = new[] { "-:::-" };

            var oldDataList = oldData.Split(stringSeparators, StringSplitOptions.None);
            var newDataList = newData.Split(stringSeparators, StringSplitOptions.None);


            var dt = new DataTable();
            var col1 = new DataColumn("Field");
            var col2 = new DataColumn("Old Value");
            var col3 = new DataColumn("New Value");
            var col4 = new DataColumn("hasChanged");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);

            var colCount = newData == "" ? oldDataList.Length : newDataList.Length;

            for (var i = 0; i < colCount; i++)
            {
                var changeList = ParseChangesToArray(logType, (oldData == "") ? "" : oldDataList[i], (newData == "") ? "" : newDataList[i]);

                var row = dt.NewRow();
                row[col1] = changeList[0];
                row[col2] = changeList[1];
                row[col3] = changeList[2];

                if (changeList[1] == changeList[2])
                {
                    row[col4] = "N";
                }
                else
                {
                    row[col4] = "Y";
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        public static DataTable GetStringToTable(string data)
        {
            var stringSeparators = new[] { "-:::-" };

            var dataList = data.Split(stringSeparators, StringSplitOptions.None);


            var dt = new DataTable();
            var col1 = new DataColumn("field1");
            var col2 = new DataColumn("field2");
            var col3 = new DataColumn("field3");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);

            var colCount = dataList.Length;

            for (var i = 0; i < colCount; i++)
            {
                var changeList = dataList[i].Split('=');
                var changeListCout = changeList.Length;
                var value1 = changeListCout > 0 ? changeList[0].Trim() : "";
                var value2 = changeListCout > 1 ? changeList[1].Trim() : "";
                var value3 = changeListCout > 2 ? changeList[2].Trim() : "";

                var row = dt.NewRow();
                row[col1] = value1;
                row[col2] = value2;
                row[col3] = value3;

                dt.Rows.Add(row);
            }
            return dt;
        }

        private static string[] ParseChangesToArray(string logType, string oldData, string newData)
        {
            const string seperator = "=";
            var oldValue = "";
            var newValue = "";
            var field = "";

            if (logType.ToLower() == "insert" || logType.ToLower() == "i" || logType.ToLower() == "update" || logType.ToLower() == "u" || logType.ToLower() == "login fails" || logType.ToLower() == "log in")
            {
                var seperatorPos = newData.IndexOf(seperator);
                if (seperatorPos > -1)
                {
                    field = newData.Substring(0, seperatorPos - 1).Trim();
                    newValue = newData.Substring(seperatorPos + 1).Trim();
                }
            }

            if (logType.ToLower() == "delete" || logType.ToLower() == "d" || logType.ToLower() == "update" || logType.ToLower() == "u")
            {
                var seperatorPos = oldData.IndexOf(seperator);
                if (seperatorPos > -1)
                {
                    if (field == "")
                        field = oldData.Substring(0, seperatorPos - 1).Trim();

                    oldValue = oldData.Substring(seperatorPos + 1).Trim();
                }
            }
            return new[] { field, oldValue, newValue };

        }

        public static DbResult GetPasswordStatus()
        {
            DbResult dr = null;
            if (HttpContext.Current.Session["passwordStatus"] != null)
            {
                dr = (DbResult)HttpContext.Current.Session["passwordStatus"];
            }
            return dr;
        }

        public static void SetPasswordStatus(DbResult dr)
        {
            HttpContext.Current.Session["passwordStatus"] = dr;
        }

        public static string GetUserName()
        {
            var user = "";
            if (HttpContext.Current.Session["currentUser"] != null)
            {
                user = HttpContext.Current.Session["currentUser"].ToString();
            }
            return user;
            //var identityArray = HttpContext.Current.User.Identity.Name.Split('\\');
            //return identityArray.Length > 1 ? identityArray[1] : identityArray[0];
        }


        public static string NoticeMessage
        {
            get { return ReadSession("message", ""); }
            set { WriteSession("message", value); }
        }
        
        public static string ReadWebConfig(string key)
        {
            return ReadWebConfig(key, "");
        }

        public static string ReadWebConfig(string key, string defValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defValue;
        }

        public static string PutYellowBackGround(string mes)
        {
            return "<span style = \"background-color : yellow\">" + mes + "</span>";
        }
        public static string PutRedBackGround(string mes)
        {
            return "<span style = \"background-color : red\">" + mes + "</span>";
        }
        public static string PutBlueBackGround(string mes)
        {
            return "<span style = \"background-color : blue\">" + mes + "</span>";
        }
        public static string PutHalfYellowBackGround(string mes)
        {
            return "<span style = \"background-color : #FFA822\">" + mes + "</span>";
        }

        public static long ReadNumericDataFromQueryString(string key)
        {
            var tmpId = ReadQueryString(key, "0");
            long tmpIdLong;
            long.TryParse(tmpId, out tmpIdLong);
            return tmpIdLong;
        }

        public static decimal ReadDecimalDataFromQueryString(string key)
        {
            var tmpId = ReadQueryString(key, "0");
            decimal tmpIdDecimal;
            decimal.TryParse(tmpId, out tmpIdDecimal);
            return tmpIdDecimal;
        }

        public static void SetActiveMenu(string menuFunctionId)
        {
            HttpContext.Current.Session["activeMenu"] = menuFunctionId;
        }

        public static void SetMessageBox(Page page)
        {
            if (HttpContext.Current.Session["message"] == null)
            {
                //CallBackJs1(page, "Remove Message", "window.parent.RemoveMessageBox();");
                return;
            }

            var dbResult = GetMessage();
            CallBackJs1(page, "Set Message", "window.parent.SetMessageBox('" + dbResult.Msg + "','" + dbResult.ErrorCode + "');");
            HttpContext.Current.Session.Remove("message");
        }

        public static void AlertMessageBox(Page page)
        {
            if (HttpContext.Current.Session["message"] == null)
                return;
            var dbResult = GetMessage();
            if (dbResult.Msg == "")
                return;
            CallBackJs1(page, "Alert Message", "alert('" + dbResult.Msg + "');");
            HttpContext.Current.Session.Remove("message");
        }

        public static void PrintMessage(Page page)
        {
            if (HttpContext.Current.Session["message"] == null)
            {
                //CallBackJs1(page, "Remove Message", "window.parent.RemoveMessageBox();");
                return;
            }

            var dbResult = GetMessage();
            CallBackJs1(page, "Set Message", "window.parent.SetMessageBox(\"" + dbResult.Msg + "\",\"" + dbResult.ErrorCode + "\");");
            HttpContext.Current.Session.Remove("message");
        }

        public static void SetMessage(DbResult value)
        {
            HttpContext.Current.Session["message"] = value;
        }
        public static void SetSingleMessage(string value)
        {
            HttpContext.Current.Session["message"] = value;
        }

        public static DbResult GetMessage()
        {
            return (DbResult)HttpContext.Current.Session["message"];
        }
        
        public static void Redirect(Page page, string url)
        {
            page.ClientScript.RegisterStartupScript(typeof(string), "script", "<script language = 'javascript'>Redirect('" + url + "');</script>");
        }

        public static void CloseDialog(Page page, string returnValue)
        {
            page.ClientScript.RegisterStartupScript(typeof(string), "scriptClose", "<script language = 'javascript'>CloseDialog('" + returnValue + "');</script>");
        }

        public static String ShowDecimal(String strVal)
        {
            if (String.IsNullOrWhiteSpace(strVal))
            {
                strVal = "0.00";
            }
            if (Convert.ToDecimal(strVal) < 0)
            {
                strVal = Math.Round(Convert.ToDecimal(strVal), 2).ToString();
            }
            else
            {
                strVal = Math.Round(Convert.ToDecimal(strVal), 2).ToString();
            }
            return strVal;
       
        }
        public static String ShowDecimalCustomize(String strVal)
        {
            if (!String.IsNullOrWhiteSpace(strVal))
            {
                if (Convert.ToDecimal(strVal) == 0)
                {
                    return null;
                }
                strVal= Convert.ToDecimal(strVal).ToString("0.##");
            }
               
            return strVal;
        }

        public static string GetRowData(DataRow dr, string fieldName, string defValue)
        {
            return dr == null ? defValue : dr[fieldName].ToString();
        }

        public static string GetRowData(DataRow dr, string fieldName)
        {
            return GetRowData(dr, fieldName, "");
        }

        public static string ParseResultJsPrint(DbResult dbResult)
        {
            return dbResult.ErrorCode + "-:::-" + dbResult.Msg + "-:::-" + dbResult.Id;
        }

        public static void CallBackJs1(Page page, String scriptName, string functionName)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), scriptName, functionName, true);
        }

        public static void CallBackJs2(Page page, string scriptName, string functionName)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), scriptName, functionName, true);
        }

        public static double ParseDouble(string value)
        {
            double tmp;
            double.TryParse(value, out tmp);
            return tmp;
        }
        
        public static string ParseMinusValue(double data)
        {
            var retVal = Math.Abs(data).ToString("N");
            if (data < 0)
            {
                return "(" + retVal + ")";
            }
            return retVal;

        }

        # region Sweet Alert Messages
        public static void SweetAlertMessage(Page page, string title, string msg)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Alert Message", "swal(\"" + title + "\",\"" + msg + "\");", true);
        }
        public static void PrintSweetAlertMessage(Page page)
        {
            if (HttpContext.Current.Session["message"] == null)
            {
                //CallBackJs1(page, "Remove Message", "window.parent.RemoveMessageBox();");
                return;
            }

            var dbResult = GetMessage();
            if (dbResult.ErrorCode == "0")
            {
                SweetAlertSuccessMessage(page,"Success",dbResult.Msg);
            }
            else
            {
                SweetAlertErrorMessage(page, "Error", dbResult.Msg);
            }
            //CallBackJs1(page, "Set Message", "window.parent.SetMessageBox(\"" + dbResult.Msg + "\",\"" + dbResult.ErrorCode + "\");");
            HttpContext.Current.Session.Remove("message");
        }
        public static void SweetAlertSuccessMessage(Page page, string title, string msg)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Success Message", "swal(\"" + title + "\",\"" + msg + "\",\"success\");", true);
        }

        public static void SweetAlertSuccessMessageCallbackUrl(Page page, string title, string msg, string callBackUrl)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Success Message", "swal({title:\"" + title + "\",text:\"" + msg + "\",type:\"success\"},function(){window.location.href=\"" + callBackUrl + "\";});", true);

        }

        public static void SweetAlertErrorMessage(Page page, string title, string msg)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Error Message", "swal(\"" + title + "\",\"" + msg + "\",\"error\");", true);
        }

        public static void SweetAlertIconMessage(Page page, string title, string msg)
        {
            string imageUrl = GetUrlRoot() + "/images/icon/prepaid.png"; // Use image as required.
            ScriptManager.RegisterStartupScript(page, page.GetType(), "Error Message", "swal({title:\"" + title + "\",text:\"" + msg + "\",imageUrl:\"" + imageUrl + "\"});", true);
        }

        #endregion

        public static string GetUrlRoot()
        {
            //return ReadWebConfig("urlRoot");
            string httpType = ConfigurationManager.AppSettings["HttpType"].ToString();
            return httpType + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
        }

        public static string GetUploadRoot()
        {
            return System.Web.HttpContext.Current.Server.MapPath("~") + "doc\\";
        }

        public static string ParseMinusValue(string data)
        {
            var m = ParseDouble(data);

            return ParseMinusValue(m);
        }

        public static string GetDefaultPage()
        {
            return "/Default.aspx";
        }
        public static string GetUser()
        {
            var user = ReadSession("admin", "");
            WriteSession("admin", user);
            return user;
        }

        public static string GetLogoutPage()
        {
            return GetStatic.GetUrlRoot() + "SignOut.aspx";
        }
        public static void DeleteCookie(string key)
        {
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var aCookie = new HttpCookie(key);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
        }

        public static string GetToday()
        {
            return DateTime.Today.ToShortDateString();
        }
    }
}