using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Payrole_management
{
    public partial class EmpDetailList : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;     
        public EmpDetailList()
        {
            this._roleMenuDao = new RoleMenuDAOInv();            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 25) == false)
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


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert
            String[,] matfilter = new String[,]{
                        {"E.EMP_CODE",    "Emp Code",         "LT"},
                        {"E.FIRST_NAME",    "First Name",         "LT"},
                        {"B.BRANCH_NAME",    "Branch Name",         "LT"},
                        {"D.DEPARTMENT_NAME",    "Department Name",         "LT"},
                        {"S.DETAIL_TITLE",    "Position Title",         "LT"}
                     
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{ 
                        {"EMP_CODE",        "Emp Code",        "200",      "T"},        
                        {"EmpName",        "Full Name",        "200",      "T"}
                        };

            string sortby = "EMPLOYEE_ID";
            string table_name = "Employee";

            String sql = "";
            sql = "SELECT E.EMPLOYEE_ID,E.EMP_CODE,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EmpName,B.BRANCH_NAME,"
                +" D.DEPARTMENT_NAME ,S.DETAIL_TITLE FROM Employee E INNER JOIN Branches B ON B.BRANCH_ID=E.BRANCH_ID"
                +" INNER JOIN Departments D ON D.DEPARTMENT_ID=E.DEPARTMENT_ID INNER JOIN StaticDataDetail S ON S.ROWID=E.POSITION_ID WHERE 1=1";

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

            string thisPage = "EmpDetailList.aspx?sortd=" + sortd + "&sortby={sortby}";

            DataSet ds = db.getDataset(sqlCount + sql1);

            DataTable dtTotal = ds.Tables[0];
            int total_record = Convert.ToInt16(dtTotal.Rows[0]["totalRecord"].ToString());
            int remainder = total_record % page_size;
            int total_page = (total_record - remainder) / page_size;

            if (remainder > 0)
                total_page++;

            DataTable dt = ds.Tables[1];
            int arr_cnt = matgrid.GetUpperBound(0);


            StringBuilder html = new StringBuilder("<table width=\"900\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" align=\"center\" class=\"GridTemplate\" >");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Insurance</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Advance</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Contribution</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Payable</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Int.Benefit</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Adhoc</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Bank A/C</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Loan</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Donation</th>");
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">Other</th>");
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
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListInsurance.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Insurance</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListAdvance.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Advance</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/chooseContributionType.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Contribution</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListPayable.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Payable</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListBenefitsOnlyForTaxSettings.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Int.Benefit</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListAdhocPayment.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Adhoc</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListBankAccounts.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Bank a/c</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListLoan.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Loan</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListDonations.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Donation</a></td>");
                html.Append("<td><a href=\"/Company/EmployeeWeb/ListOtherInfo.aspx?Id=" + dr["EMPLOYEE_ID"] + "\">Other</a></td>");
            }

            html.Append("<table width=\"900\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\"> <tr> <td align=\"center\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("<tr> <td align=\"right\"></td></tr>");
            html.Append("</table>");


            string filter_form = make_filter_form(table_name, matfilter);
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "/Company/EmployeeWeb/Manage.aspx");
            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");

            html.Append("<table width=\"900\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
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
                html.Append("<tr>");
                html.Append("<td width=\"200\" align=\"right\" class=\"text_form\">" + matfilter.GetValue(i, 1).ToString() + "</td>");

                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();

                if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

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
            html.Append("<table width=\"900\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
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
            //html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' width='14' heigth='14' border='0'></a>");
            html.Append("</td>");
            html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion
    }
}
