using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.AttendenceWeb
{
    public partial class ListAttendanceDetailsForUser : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsDao = null;
        public ListAttendanceDetailsForUser()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 275) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            init();
        }
        #region SwiftGrid
        private string autoSelect(string str1, string str2)
        {
            if (str1 == str2)
                return "selected=\"selected\"";
            else
                return "";

        }
        protected void btnHidden_Click(object sender, EventArgs e)
        {

        }
        private void init()
        {
            /************************* editable vairable starts***************************************/


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert,ED=equal to date
            String[,] matfilter = new String[,]{  
                        {"A.login_time",    "Date (MM-DD-YYYY)",         "ED"}              
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                        {"EMP_CODE",        "Emp Code",         "200",      "T"},
                        {"EMP_NAME",        "Employee Name",    "200",      "T"},
                        {"login_time",      "Login Time",       "200",      "D"},
                        {"logout_time",     "Logout Time",      "200",      "D"},
                        {"login_reason",    "Login Reason",     "200",      "T"},
                        {"logout_reason",   "Logout Reason",    "200",      "T"},
                        {"login_ip",        "Login Device",     "200",      "T"},
                        {"logout_ip",       "Logout Device",    "200",      "T"}
                        };

            string sortby = "ID";
            string table_name = "atttendance";

            string yearStartDate = _clsDao.GetSingleresult("select engDateBaisakh yrStartdate from Fiscal_Month where DefaultYr='y'");
            string yearEndDate = _clsDao.GetSingleresult("select DATEADD(d,365,engDateBaisakh)  yrenddate from Fiscal_Month where DefaultYr='y'");
                

            String sql = "";

            if (ReadSession().UserId == "admin")
            {
                sql = @"SELECT A.id,E.EMP_CODE,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMP_NAME,DATENAME(WEEKDAY,att_date) DAY_NAME,A.login_time,A.logout_time,
                        c.login_reason,c.logout_reason,A.remarks,A.login_ip as login_ip,a.logout_ip as logout_ip
                        FROM atttendance A inner join Employee E on A.emp_id=E.EMPLOYEE_ID	
                        left join attendance_reason c on c.att_id=a.id where 1=1 ";
            }


            else


                sql = @"SELECT A.id,E.EMP_CODE,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMP_NAME,cast((A.login_time)as date) LoginDate,A.login_time,cast((A.logout_time)as Date) LogoutDate,
                        A.logout_time,c.login_reason,c.logout_reason,A.login_ip as login_ip,a.logout_ip as logout_ip
                        FROM atttendance A 
                        inner join Employee E on A.emp_id=E.EMPLOYEE_ID	
                        inner join Fiscal_Month F on cast((A.att_date)as Date)>=f.engDateBaisakh
                        left join attendance_reason c on c.att_id=a.id where 1=1 and A.emp_id=" + filterstring(ReadSession().Emp_Id.ToString()) + "and f.DefaultYr='1'";

            /************************* editable vairable ends***************************************/
            string _page_size = "10";
            string sortd = "desc";
            int _page = 1;

            if (Request.Form["hdd_curr_page"] != null)
                _page = Convert.ToInt32(Request.Form["hdd_curr_page"].ToString());

            if (Request.Cookies["page_size"] != null)
                _page_size = Request.Cookies["page_size"].Value.ToString();

            if (Request.Form["ddl_per_page"] != null)
                _page_size = Request.Form["ddl_per_page"].ToString();



            Response.Cookies["page_size"].Value = _page_size;


            int page_size = Convert.ToUInt16(_page_size);


            if (Request.QueryString["sortd"] != null)
                sortd = Request.QueryString["sortd"].ToString();

            if (Request.QueryString["sortby"] != null)
                sortby = Request.QueryString["sortby"].ToString();

            //sortd = (sortd == "asc" ? "desc" : "asc");


            sql = sql + get_filter_sql(table_name, matfilter);

            rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size) + "</center>";

        }
        private string load_report(string table_name, string sql, String[,] matgrid, string[,] matfilter, String sortd, string sortby, int _page, int page_size)
        {
            clsDAO db = new clsDAO();
                    
            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " " + sortd + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            string sqlCount = " select count(*) as totalRecord from (" + sql + ") as tmp ";

            sortd = (sortd == "asc" ? "desc" : "asc");

            string thisPage = "ListAttendanceDetailsForUser.aspx?sortd=" + sortd + "&sortby={sortby}";


            DataSet ds = db.getDataset(sqlCount + sql1);

            DataTable dtTotal = ds.Tables[0];
            int total_record = Convert.ToInt32(dtTotal.Rows[0]["totalRecord"].ToString());
            int remainder = total_record % page_size;
            int total_page = (total_record - remainder) / page_size;

            if (remainder > 0)
                total_page++;

            DataTable dt = ds.Tables[1];

            //get_dt(matgrid);
            int arr_cnt = matgrid.GetUpperBound(0);


            StringBuilder html = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("</tr>");

            int cnt = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cnt++;

                if (cnt % 2 == 0)
                {
                    html.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\" >");
                }
                else
                {
                    html.Append("<tr class=\"GridEvenRow\" onMouseOver=\"this.className='GridEvenRowOver'\" onMouseOut=\"this.className='GridEvenRow'\">");
                }

                for (int i = 0; i <= arr_cnt; i++)
                {

                    switch (matgrid.GetValue(i, 3).ToString())
                    {
                        case "M":
                            html.Append("<td align=\"right\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "D":
                            html.Append("<td align=\"center\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        default:
                            html.Append("<td align=\"left\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                    }
                }
                html.Append("</tr>");
            }

            html.Append("<tr> <td align=\"center\" colspan=\"8\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("</table>");
            html.Append("</div>");


            string filter_form = make_filter_form(table_name, matfilter);
            //Project/Assignproject.aspx?Project_id
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "");


            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<div class=\"col-md-12 filter-bg\">");

            html.Append("<div class=\"pull-right\" ><a class=\"btn btn-primary  btn-md\" align=\"center\" href=\"javascript:newTableToggle('td_Search', 'img_Search');\"><i class=\"fa fa-filter\" id=\"img_Search\"></i> </a></div>");
            html.Append("<div class=\"clear-fix\"></div>");
            html.Append("<div id=\"td_Search\" style=\"display:none; width:100%; float:left;\" align=\"left\">");

            int arr_cnt = matfilter.GetUpperBound(0);
            string ctlName = "";
            string defValue = "";
            string ctlType = "";
            for (int i = 0; i <= arr_cnt; i++)
            {
                html.Append("<div class=\" col-md-3\">");
                html.Append("<div class=\" form-group\">");
                html.Append("<label align=\"left\">" + matfilter.GetValue(i, 1).ToString() + "</label>");

                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();
                ctlType = matfilter.GetValue(i, 2).ToString();

                if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

                if (ctlType == "ED")
                {
                    html.Append("<td width=\"200\"><input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\" class=\"form-control\">" +
                        "<script language=\"JavaScript\"> new tcal ({ 'formname': 'aspnetForm','controlname': '" + ctlName + "'});</script> </td>");
                }
                else
                    html.Append("<td width=\"200\"><input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\" class=\"form-control\"></td>");
                
                html.Append("</div>");
                html.Append("</div>");
            }
            html.Append("<div class=\" col-md-3\">");
            html.Append("<div><input type=\"button\" value=\"Filter\" class=\"btn-filter btn btn-success\" onclick=\"submit_form();\"></div>");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");

            return html.ToString();
        }
        private string get_filter_sql(String table_name, String[,] matfilter)
        {
            int arr_cnt = matfilter.GetUpperBound(0);
            string query = "";
            string ctlName = "";
            string defValue = "";

            for (int i = 0; i <= arr_cnt; i++)
            {
                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();


                if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                if (defValue.Trim() != "")
                {
                    switch (matfilter.GetValue(i, 2).ToString().ToUpper())
                    {
                        case "LT":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " LIKE '%" + defValue + "%'";
                            break;

                        case "ET":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = '" + defValue + "'";
                            break;

                        case "EB":

                        case "EN":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = " + defValue;
                            break;

                        case "ED":
                            query = query + " and CONVERT(varchar, " + matfilter.GetValue(i, 0).ToString() + ",101) = CONVERT(varchar,CAST( " + filterstring(defValue) + "AS DATETIME),101)";
                            break;
                    }
                }
                //query = query + " order by A.ATT_DATE_IN desc";
            }
            return query;
        }
        private string get_paging_block(int _total_record, int _page, int _page_size, Boolean _show_add_button, string _add_page)
        {

            StringBuilder html = new StringBuilder("<input type = \"hidden\" name=\"hdd_curr_page\" id = \"hdd_curr_page\" value=\"" + _page.ToString() + "\">");
            html.Append("<div class=\"col-md-12 result-bg\">");
            html.Append("<div class=\"row\">");
            html.Append("<div class=\"col-md-9 text-left\">");
            html.Append("<div class=\"form-inline\">");
            html.Append("<div class=\"form-group\">Result");
            html.Append("</div>");
            html.Append("<div class=\"form-group\"><b>" + _total_record.ToString() + "</b>");
            html.Append("</div>");
            html.Append("<div class=\"form-group\">");
            html.Append("<select class=\"form-control\"  aria-describedby=\"sizing-addon3\" name=\"ddl_per_page\" onChange=\"submit_form();\">");
            html.Append("<option value=\"10\"" + autoSelect("10", _page_size.ToString()) + ">10</option>");
            html.Append("<option value=\"20\"" + autoSelect("20", _page_size.ToString()) + ">20</option>");
            html.Append("<option value=\"30\"" + autoSelect("30", _page_size.ToString()) + ">30</option>");
            html.Append("<option value=\"40\"" + autoSelect("40", _page_size.ToString()) + ">40</option>");
            html.Append("<option value=\"50\"" + autoSelect("50", _page_size.ToString()) + ">50</option>");
            html.Append("</select>");
            html.Append("</div>");
            html.Append("<div class=\"form-group\"> Per Page");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("<div class=\"col-md-3 text-right\">");

            if (_page > 1)
                html.Append("<a class=\"tool btn btn-default\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Previous\"  href=\"JavaScript:nav('" + (_page - 1).ToString() + "');\" title='Previous page'><i class=\"fa fa-arrow-left\"></i></a>");
            else
                html.Append("<span class=\"btn btn-default\"> <i class=\"fa fa-arrow-left\" aria-hidden=\"true\"></i></span>");

            if (_page * _page_size < _total_record)
                html.Append("<a class=\"tool btn btn-default\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Next\" href=\"JavaScript:nav('" + (_page + 1).ToString() + "');\" title='Next page'><i class=\"fa fa-arrow-right\"></i></a>");
            else
                html.Append("<span class=\"btn btn-default\"><i class=\"fa fa-arrow-right\" aria-hidden=\"true\"></i></span>");

            html.Append("</div>");
            html.Append("</div></div>");

            return html.ToString();
        }
        #endregion
    }
}
