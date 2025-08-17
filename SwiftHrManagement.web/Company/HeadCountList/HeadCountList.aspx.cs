using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.HeadCountList
{
    public partial class HeadCountList : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        public HeadCountList()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 124) == false)
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

        public long GetBranchID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void init()
        {
            /************************* editable vairable starts***************************************/


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert
            String[,] matfilter = new String[,]{
                        {"B.BRANCH_SHORT_NAME",    "Branch Code",         "LT"}
                     
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{ 
                        {"EMP_CODE",        "Employee Code",        "200",      "T"},        
                        {"Name",            "Employee Name",        "200",      "T"},
                        };

            string sortby = "EMP_CODE";
            string table_name = "Employee";

            String sql = "";
            sql = @"select 
	                    EMP_CODE, 
	                    sdd.DETAIL_TITLE+' '+rtrim(dbo.GetEmployeeFullNameOfId(EMPLOYEE_ID)) Name
                    from Employee E
                    inner join StaticDataDetail sdd on E.SALUTATION=sdd.ROWID
                    where BRANCH_ID="+ GetBranchID().ToString() +" and EMP_STATUS=458 and EMPLOYEE_ID<>1000";


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

            sortd = (sortd == "desc" ? "asc" : "desc");


            sql = sql + get_filter_sql(table_name, matfilter);

            rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size) + "</center>";

        }
        private string load_report(string table_name, string sql, String[,] matgrid, string[,] matfilter, String sortd, string sortby, int _page, int page_size)
        {
            clsDAO db = new clsDAO();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";

            string thisPage = "StatusView.aspx?sortd=" + sortd + "&sortby={sortby}";

            DataSet ds = db.getDataset(sqlCount + sql1);

            DataTable dtTotal = ds.Tables[0];
            int total_record = Convert.ToInt16(dtTotal.Rows[0]["totalRecord"].ToString());
            int remainder = total_record % page_size;
            int total_page = (total_record - remainder) / page_size;

            if (remainder > 0)
                total_page++;

            DataTable dt = ds.Tables[1];
            int arr_cnt = matgrid.GetUpperBound(0);


            StringBuilder html = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            //html.Append("<th Class=\"HeaderStyle\" align=\"left\">view</th>");
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

                //html.Append("<td><a href=\"/Company/Internship/Manage.aspx?Id=" + dr["BRANCH_ID"] + "\">View</a></td>");              

            }

            html.Append("<tr> <td align=\"center\" colspan=\"3\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("</table>");
            html.Append("</div>");


            string filter_form = make_filter_form(table_name, matfilter);
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "");
            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("");
            //html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            //html.Append("<table width=\"800\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            //html.Append("<tr>");
            //html.Append("<td class=\"GridTextNormal\" align=\"center\"><b>Filtered results</b>&nbsp;&nbsp;&nbsp;<a href=\"javascript:newTableToggle('td_Search', 'img_Search');\"><img src=\"/images/icon_show.gif\" border=\"0\" alt=\"Show\" id=\"img_Search\"></a></td>");
            //html.Append("</tr>");
            //html.Append("<tr>");
            //html.Append("<td id=\"td_Search\" style=\"display:none\" align=\"center\">");
            //html.Append("<table cellpadding=\"2\" cellspacing=\"2\" border=\"0\" width=\"400\">");

            //int arr_cnt = matfilter.GetUpperBound(0);
            //string ctlName = "";
            //string defValue = "";
            //for (int i = 0; i <= arr_cnt; i++)
            //{
            //    defValue = "";
            //    html.Append("<tr>");
            //    html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">" + matfilter.GetValue(i, 1).ToString() + "</td>");

            //    ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();

            //    if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
            //        defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

            //    if (Request.Form[ctlName] != null)
            //        defValue = Request.Form[ctlName].ToString();

            //    Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

            //    html.Append("<td width=\"200\"><input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\"></td>");
            //    html.Append("</tr>");
            //}
            //html.Append("<tr>");
            //html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">&nbsp;</td>");
            //html.Append("<td width=\"200\"><input type=\"button\" value=\"Filter\" class=\"button\" onclick=\"submit_form();\"></td>");
            //html.Append("</tr>");
            //html.Append("</table>");
            //html.Append("</td>");
            //html.Append("</tr>");
            //html.Append("</table>");

            return html.ToString();
        }
        private string get_filter_sql(String table_name, String[,] matfilter)
        {
            int arr_cnt = matfilter.GetUpperBound(0);
            string query = "";
            //string ctlName = "";
            //string defValue = "";

            //for (int i = 0; i <= arr_cnt; i++)
            //{
            //    ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();


            //    if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
            //        defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

            //    if (Request.Form[ctlName] != null)
            //        defValue = Request.Form[ctlName].ToString();

            //    if (defValue.Trim() != "")
            //    {
            //        switch (matfilter.GetValue(i, 2).ToString().ToUpper())
            //        {
            //            case "LT":
            //                query = query + " and " + matfilter.GetValue(i, 0).ToString() + " LIKE '%" + defValue + "%'";
            //                break;
            //            case "ET":
            //                query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = '" + defValue + "'";
            //                break;
            //            case "EB":
            //            case "EN":
            //                query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = " + defValue;
            //                break;
            //        }
            //    }
            //}
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
