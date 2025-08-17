using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.SupervisorReport
{
    public partial class PayrollRpt : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            init();
        }
        
       public string LoadPayrollRptExcel(string year,string month,string emp_id)
       {
           return "EXEC [ProcMonthlyPayrollReport_Supervisor] @FLAG='a',@year=" + filterstring(year) + ",@month=" +
                  filterstring(month) + ","+ " @sup=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@emp=" +
                  filterstring(emp_id);
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
                        {"Emp_code",    "Employee Code",         "LT"},
                        {"FIRST_NAME",    "Employee First Name",         "LT"},
                         {"TC.FY_ID",    "Fiscal Year",         "LT"},
                        {"M.Name",    "Salary For the Month",         "LT"}
                    };
            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                        {"Emp_code",           "Employee Code",             "200",      "LT"},
                        {"EMPNAME",            "Employee Full Name",             "200",      "LT"},
                        {"FY_ID",            "Fiscal Year",             "200",      "D"},
                        {"Name",            "For Month",             "200",      "T"},
                         {"NET_SALARY",        "Net Salary",             "200",      "M"}                        
                        };
            string sortby = "Emp_code";
            string table_name = "TAXCALCULATION";
            year.Value = filterstring(Request.QueryString[" "] == null ? "" : Request.QueryString["FY"].ToString());
            month.Value = filterstring(Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString());
            emp_id.Value = filterstring(Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString());

            String sql = "SELECT TC.RUN_MONTH,TC.EMP_ID,Emp_code,TC.FY_ID,M.Name,FIRST_NAME+' '+MIDDLE_NAME+' '+ LAST_NAME AS EMPNAME,"
                        +" dbo.ShowDecimal((BASIC_SALARY_CURRENT+GRADE_CURRENT+ ALLOWANCE_CURRENT+ADHOC_BENEFITS_THIS_MONTH+CONTRI_THIS_MONTH_EMPLOYER)-"
                        +" (CONTRI_THIS_MONTH_EMPLOYER+ CONTRI_CURRENT_EMPLOYEE+TAX_THIS_MONTH+ADHOC_DEDUCTION_CURRENT+LOAN_DEDUCTION+"
                        +" ADVANCE_DEDUCTION)) AS NET_SALARY FROM TAXCALCULATION TC INNER JOIN EMPLOYEE E ON E.EMPLOYEE_ID =TC.EMP_ID"
                        +" INNER JOIN MonthList M ON M.Month_Number=TC.Run_Month "
                        +" INNER JOIN (SELECT DISTINCT EMP FROM SuperVisroAssignment WHERE SUPERVISOR = " + filterstring(ReadSession().Emp_Id.ToString()) + " AND record_status='y'"
                        +" AND SUPERVISOR_TYPE IN ('s','i'))s ON s.EMP = E.EMPLOYEE_ID"
                        +" Left Join  "
                        +" ( "
                        +" select PD.EMP_ID, SUM(Deduction_Amt) Deduction_Amt, Deduction_Date from PremiumDeduction PD"
                        +" where PD.EMP_ID=isnull(" + emp_id.Value + ",PD.EMP_ID)"
                        +" group by PD.EMP_ID ,Deduction_Date"
                        +" ) pd on pd.EMP_ID=Tc.Emp_Id "
                        + " AND (PD.Deduction_Date between dbo.GetMonthStartDateEng(" + year.Value + ", " + month.Value + ") and dbo.GetMonthEndDateEng(" + year.Value + ", " + month.Value + ")) "
                        +" WHERE TC.FY_ID =" + year.Value + " AND TC.Run_Month = ISNULL(" + month.Value + ",TC.Run_Month) AND E.EMPLOYEE_ID = ISNULL(" + emp_id.Value + ",E.EMPLOYEE_ID)";



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


            string thisPage = "List.aspx?sortd=" + sortd + "&sortby={sortby}&year=" + year.Value + "&month=" + month.Value + "";


            DataSet ds = db.getDataset(sqlCount + sql1);

            DataTable dtTotal = ds.Tables[0];
            int total_record = Convert.ToInt16(dtTotal.Rows[0]["totalRecord"].ToString());
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
            html.Append("<th Class=\"HeaderStyle\" align=\"left\">View</th>");
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
                html.Append("<td class=\"text-center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" href=\"PayrollAdvice.aspx?empid=" + dr["EMP_ID"] + "&month=" + dr["RUN_MONTH"] + "&year=" + Request.QueryString["FY"].ToString() + "&Empname=" + dr["EmpName"] + "\" rel='gb_page_center[650,400]'><i class=\"fa fa-eye\"></i></a></td>");
                html.Append("</tr>");
            }

            html.Append("<tr> <td align=\"center\" colspan=\"6\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("</table>");
            html.Append("</div>");

            string filter_form = make_filter_form(table_name, matfilter);
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
            for (int i = 0; i <= arr_cnt; i++)
            {
                html.Append("<div class=\" col-md-3\">");
                html.Append("<div class=\" form-group\">");
                html.Append("<label align=\"left\">" + matfilter.GetValue(i, 1).ToString() + "</label>");

                ctlName = "sch_" + matfilter.GetValue(i, 0).ToString();

                if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value.ToString();

                if (Request.Form[ctlName] != null)
                    defValue = Request.Form[ctlName].ToString();

                Response.Cookies[table_name + "_sch_" + ctlName].Value = defValue;

                html.Append("<input type=\"text\" name=\"" + ctlName + "\" value=\"" + defValue + "\" class=\"form-control\">");
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
                    }
                }
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
