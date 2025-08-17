using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

namespace SwiftHrManagement.web.Company.EmployeeWeb.SuperVisorAssignment
{
    public partial class ManageSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetFlag() == "r")
            {
                init();

            }
            else
            {
                init();
            }
        }
        private long GetBranchId()
        {
            return (Request.QueryString["BranchId"] != null ? long.Parse(Request.QueryString["BranchId"]) : 0);
        }
        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"] : "");

        }
        private long GetDeptId()
        {
            string ss = Request.QueryString["DeptId"];
            if (ss != "")
                  return (Request.QueryString["DeptId"] != null ? long.Parse(Request.QueryString["DeptId"]) : 0);
              return 0;
            
        }
        private long GetEmpId()
        {
            string qq = Request.QueryString["EmpId"];
            if(qq!="")
                 return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"]) : 0);
            return 0;
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


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert
            String[,] matfilter = new String[,]{
                        {"dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID)",    "Emp Name",         "LT"},
                        {"dbo.GetEmployeeFullNameOfId(sa.SUPERVISOR)",    "Supervisor",         "LT"},
                 
                     
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{ 
                        {"EMP_CODE",                "Emp Code",          "200",      "T"},        
                        {"emp_name",                "Emp Name",          "200",      "T"},
                        {"supervisor_name",         "SuperVisor",        "200",      "T"},
                        {"Status",                  "Type",              "200",      "T"},
                        };

            string sortby = "EMP_CODE";
            string table_name = "Employee";

            String sql = "";
            sql = @"select 
		                 e.EMP_CODE
		                ,sa.SV_ASSIGN_ID
		                ,e.BRANCH_ID
		                ,e.DEPARTMENT_ID
		                ,e.SECTION_ID
		                ,e.EMPLOYEE_ID
		                ,dbo.GetEmployeeFullNameOfId(e.EMPLOYEE_ID)[emp_name]
		                ,dbo.GetEmployeeFullNameOfId(sa.SUPERVISOR)[supervisor_name]
		                ,case sa.SUPERVISOR_TYPE when 'i' then 'Immediate' when 's' then 'SuperVisor' end [Status] 
	                from Employee e
	                left join
	                (select 
			                 SUPERVISOR
			                ,SV_ASSIGN_ID
			                ,EMP
			                ,SUPERVISOR_TYPE 
		                from
		                SuperVisroAssignment 
		                where record_status='y')sa
	                on e.EMPLOYEE_ID = sa.EMP
	                where e.BRANCH_ID ="+GetBranchId()+"";

            if (GetDeptId() != 0)
            {

                sql = sql + " and e.DEPARTMENT_ID="+GetDeptId();
            }
            if (GetEmpId() != 0)
            {

                sql = sql + " and e.EMPLOYEE_ID=" + GetEmpId();
            }

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

            string thisPage = "ManageSearch.aspx?sortd=" + sortd + "&sortby={sortby}";

            DataSet ds = db.getDataset(sqlCount + sql1);

            DataTable dtTotal = ds.Tables[0];
            int total_record = Convert.ToInt16(dtTotal.Rows[0]["totalRecord"].ToString());
            int remainder = total_record % page_size;
            int total_page = (total_record - remainder) / page_size;

            if (remainder > 0)
                total_page++;

            DataTable dt = ds.Tables[1];
            int arr_cnt = matgrid.GetUpperBound(0);


            StringBuilder html = new StringBuilder("<table width=\"800\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" align=\"center\" class=\"GridTemplate\" >");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Select</th>");
          
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
                string aa = dr["SV_ASSIGN_ID"].ToString();
                if (dr["SV_ASSIGN_ID"].ToString() != "0")
                {
                    html.Append("<td><a href=\"/Company/EmployeeWeb/SuperVisorAssignment/AssignSuperVisorIndividual.aspx?SuperId=" + dr["SV_ASSIGN_ID"] + "&Emp_Id=" + dr["EMPLOYEE_ID"] + "&DeptId="+dr["DEPARTMENT_ID"]+"&BranchId="+dr["BRANCH_ID"]+"\">Edit</a></td>");
                }
                else
                {
                    html.Append("<td><a href=\"/Company/EmployeeWeb/SuperVisorAssignment/AssignSuperVisorIndividual.aspx?SuperId=" + dr["SV_ASSIGN_ID"] + "\">Add</a></td>");

                }
            }

            html.Append("<table width=\"800\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\"> <tr> <td align=\"center\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("<tr> <td align=\"right\"></td></tr>");
            html.Append("</table>");


            string filter_form = make_filter_form(table_name, matfilter);
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "/Company/EmployeeWeb/Manage.aspx");
            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");

            html.Append("<table width=\"800\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            html.Append("<tr>");
            html.Append("<td class=\"GridTextNormal\" align=\"center\"><b>Filtered results</b>&nbsp;&nbsp;&nbsp;<a href=\"javascript:newTableToggle('td_Search', 'img_Search');\"><img src=\"/images/icon_show.gif\" border=\"0\" alt=\"Show\" id=\"img_Search\"></a></td>");
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append("<td id=\"td_Search\" style=\"display:none\" align=\"center\">");
            html.Append("<table cellpadding=\"2\" cellspacing=\"2\" border=\"0\" width=\"400\">");

            int arr_cnt = matfilter.GetUpperBound(0);
            string ctlName = "";
            string defValue = "";
            for (int i = 0; i <= arr_cnt; i++)
            {
                defValue = "";
                html.Append("<tr>");
                html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">" + matfilter.GetValue(i, 1).ToString() + "</td>");

                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();

                //if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                //  defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                //Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

                html.Append("<td width=\"200\"><input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\"></td>");
                html.Append("</tr>");
            }
            html.Append("<tr>");
            html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">&nbsp;</td>");
            html.Append("<td width=\"200\"><input type=\"button\" value=\"Filter\" class=\"button\" onclick=\"submit_form();\"></td>");
            html.Append("</tr>");
            html.Append("</table>");
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</table>");

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
                    }
                }
            }
            return query;
        }
        private string get_paging_block(int _total_record, int _page, int _page_size, Boolean _show_add_button, string _add_page)
        {

            StringBuilder html = new StringBuilder("<input type = \"hidden\" name=\"hdd_curr_page\" id = \"hdd_curr_page\" value=\"" + _page.ToString() + "\">");
            html.Append("<table width=\"800\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            html.Append("<tr>");
            html.Append("<td width=\"247\" class=\"GridTextNormal\">Result :&nbsp;<b>" + _total_record.ToString() + "</b>&nbsp;records&nbsp;");
            html.Append("<select name=\"ddl_per_page\" onChange=\"submit_form();\">");
            html.Append("<option value=\"10\"" + autoSelect("10", _page_size.ToString()) + ">10</option>");
            html.Append("<option value=\"20\"" + autoSelect("20", _page_size.ToString()) + ">20</option>");
            html.Append("<option value=\"30\"" + autoSelect("30", _page_size.ToString()) + ">30</option>");
            html.Append("<option value=\"40\"" + autoSelect("40", _page_size.ToString()) + ">40</option>");
            html.Append("<option value=\"50\"" + autoSelect("50", _page_size.ToString()) + ">50</option>");
            html.Append("</select>&nbsp;&nbsp;per page");
            html.Append("</td>");
            html.Append("<td width=\"539\" align=\"right\">");

            if (_page > 1)
                html.Append("<a href=\"JavaScript:nav('" + (_page - 1).ToString() + "');\" title='Previous page'><img src='/images/prev.gif' border='0'></a>&nbsp;&nbsp;&nbsp;");
            else
                html.Append("<img src='/images/prev.gif' border='0'>&nbsp;&nbsp;&nbsp;");

            if (_page * _page_size < _total_record)
                html.Append("<a href=\"JavaScript:nav('" + (_page + 1).ToString() + "');\" title='Next page'><img src='/images/next.gif' border='0'></a>&nbsp;&nbsp;&nbsp;");
            else
                html.Append("<img src='/images/next.gif' border='0'>&nbsp;&nbsp;&nbsp;");

            if (_show_add_button)
            //    html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' width='14' heigth='14' border='0'></a>");
            //html.Append("</td>");
            html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion
    }
}
