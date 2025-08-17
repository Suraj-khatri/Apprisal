using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.OverTime.SuperVisorAppoveOT
{
    public partial class ListDetails : BasePage
    {
            RoleMenuDAOInv _roleMenuDao = null;
            public ListDetails()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 101) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
            init();
        }
        private long GetReqId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private long GetRtype()
        {
            return (Request.QueryString["RType"] != null ? long.Parse(Request.QueryString["RType"].ToString()) : 0);
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
            init();

        }
        private void init()
        {
            /************************* editable vairable starts***************************************/


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert,ED=equal to date
            String[,] matfilter = new String[,]{
                      {"requested_date",  "Date",         "ED"},    
                      {"created_date",    "Requested Date",         "ED"}                   
                    };

            //column type : T = text , M = Money, D = date , I = image

            if (GetRtype().ToString() == "650") /// Grid Display For overtime
            {
                String[,] matgrid = new String[,]{
                        {"Request_Name",        "Requested By",         "200",          "T"},
                        {"req_type",            "Req. Type",            "200",          "T"},
                        {"Ot_Request_date",     "Date",                 "300",          "D"},
                        {"Att_In",              "Att Login",            "200",          "D"},
                        {"Att_Out",             "Att Logout",           "200",          "D"},
                        {"from",                "OT From",              "200",          "T"},
                        {"to",                  "OT To",                "200",          "T"}, 
                        {"requested_Period",    "Req Hrs",              "300",          "o"}
                        };



                string sortby = "OtRequest_id ";
                string table_name = "OverTimeDetails";

                String sql = "";


                sql = @"SELECT 
			                 OtRequest_id
			                ,dbo.GetEmployeeFullNameOfId(requested_by) [Request_Name]
			                ,requested_by
			                ,convert(varchar,requested_date,107) [Ot_Request_date]
			                ,request_in_time [from]
			                ,request_out_time [to]
			                ,cast(datediff(minute, request_in_time, request_out_time )/60 as varchar(5)) + ':' + RIGHT('0' + cast(datediff(minute, request_in_time, request_out_time )%60 as varchar(2)), 2)
	                            as [requested_Period]
			                ,convert(varchar,ot.created_date,101) [request_date]
			                ,case when requesting_type='650' then 'OT' when requesting_type='1453' then 'Hardship' end req_type
			                ,convert(varchar,att.login_time,108) [Att_In]
			                ,convert(varchar,logout_time,108) [Att_Out]
                            ,status
                            ,supervisor_approv_time
                            ,supervisor_approved_remark
		            FROM OverTimeDetails ot 
		            INNER JOIN atttendance att on ot.requested_by = att.emp_id
		            WHERE requested_by=" + GetReqId() + " AND requested_with=" + ReadSession().Emp_Id + " AND requesting_type=" + GetRtype() +
                   "AND approved_date IS NULL AND convert(varchar,att.att_date,101) = CONVERT(varchar,ot.requested_date,101)";
                /************************* editable vairable ends***************************************/
                string _page_size = "10";
                string sortd = "desc";
                int _page = 1;

                if (Request.Form["hdd_curr_page"] != null)
                    _page = Convert.ToInt32(Request.Form["hdd_curr_page"].ToString());

                if (Request.Cookies["page_size"] != null)
                    _page_size = Request.Cookies["page_size"].Value;

                if (Request.Form["ddl_per_page"] != null)
                    _page_size = Request.Form["ddl_per_page"];



                Response.Cookies["page_size"].Value = _page_size;


                int page_size = Convert.ToUInt16(_page_size);


                if (Request.QueryString["sortd"] != null)
                    sortd = Request.QueryString["sortd"];

                if (Request.QueryString["sortby"] != null)
                    sortby = Request.QueryString["sortby"];

                sortd = (sortd == "desc" ? "asc" : "desc");


                sql = sql + get_filter_sql(table_name, matfilter);

                rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size) + "</center>";

            }
            else  ///// Grid Display For hardship
            {
                String[,] matgrid = new String[,]{
                        {"Request_Name",        "Requested By",         "200",          "T"},
                        {"req_type",            "Req. Type",            "200",          "T"},
                        {"Ot_Request_date",     "Date",                 "300",          "D"},
                        {"hardship_type",     "Hardship Type",           "300",          "T"}
                        };



                string sortby = "OtRequest_id ";
                string table_name = "OverTimeDetails";

                String sql = "";


                sql = @"SELECT 
			                 OtRequest_id
			                ,dbo.GetEmployeeFullNameOfId(requested_by) [Request_Name]
			                ,requested_by
			                ,convert(varchar,requested_date,107) [Ot_Request_date]
			                ,convert(varchar,ot.created_date,101) [request_date]
			                ,case when requesting_type='650' then 'OT' when requesting_type='1453' then 'Hardship' end req_type
                            ,status
                            ,supervisor_approv_time
                            ,supervisor_approved_remark
                            ,case when requesting_type='650' then 'OT' when requesting_type='1453' then ISNULL(dbo.GetDetailTitle(head_id),'Hardship') end as hardship_type
		            FROM OverTimeDetails ot 
		            INNER JOIN atttendance att on ot.requested_by = att.emp_id
		            WHERE requested_by=" + GetReqId() + " AND requested_with=" + ReadSession().Emp_Id + " AND requesting_type=" + GetRtype() +
                   "AND approved_date IS NULL and convert(varchar,att.att_date,101) = CONVERT(varchar,ot.requested_date,101)";
                /************************* editable vairable ends***************************************/
                string _page_size = "10";
                string sortd = "desc";
                int _page = 1;

                if (Request.Form["hdd_curr_page"] != null)
                    _page = Convert.ToInt32(Request.Form["hdd_curr_page"].ToString());

                if (Request.Cookies["page_size"] != null)
                    _page_size = Request.Cookies["page_size"].Value;

                if (Request.Form["ddl_per_page"] != null)
                    _page_size = Request.Form["ddl_per_page"];



                Response.Cookies["page_size"].Value = _page_size;


                int page_size = Convert.ToUInt16(_page_size);


                if (Request.QueryString["sortd"] != null)
                    sortd = Request.QueryString["sortd"];

                if (Request.QueryString["sortby"] != null)
                    sortby = Request.QueryString["sortby"];

                sortd = (sortd == "desc" ? "asc" : "desc");


                sql = sql + get_filter_sql(table_name, matfilter);

                rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size) + "</center>";
            
            }
        }
        private string load_report(string table_name, string sql, String[,] matgrid, string[,] matfilter, String sortd, string sortby, int _page, int page_size)
        {
            clsDAO db = new clsDAO();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "List.aspx?sortd=" + sortd + "&sortby={sortby}";


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


            StringBuilder html = new StringBuilder("<table width=\"700\" border=\"0\" cellpadding=\"3\" cellspacing=\"1\" align=\"center\" class=\"GridTemplate\" >");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\" class=\"GridHeader\" >";

                html.Append("<th nowrap Class=\"HeaderStyle\" align=\"left\">" + sortLink + matgrid.GetValue(i, 1) + "</a></th>");
            }
            if (GetRtype().ToString() == "650")
            {
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Approved Hours</th>");
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Update</th>");
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Remarks</th>");
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Approve</th>");
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Reject</th>");
            }
            else
            {
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Remarks</th>");
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Approve</th>");
                html.Append("<th Class=\"HeaderStyle\" align=\"left\">Reject</th>");
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
                            html.Append("<td align=\"right\">" + dr[matgrid.GetValue(i, 0).ToString()] + "</td>");
                            break;
                        case "D":
                            html.Append("<td align=\"center\">" + dr[matgrid.GetValue(i, 0).ToString()] + "</td>");
                            break;
                        case "o":
                            html.Append("<td align=\"left\" nowrap=\"nowrap\"><input  type=\"text\" readonly=\"readonly\" maxlength=\"5\" size=\"5\" name=\"ReqTime_" + dr["OtRequest_id"] + "\" id=\"ReqTime_" + dr["OtRequest_id"] + "\" value=" + dr[matgrid.GetValue(i, 0).ToString()] + ">"
                                + " </span> </td>");
                            break;
                        default:
                            html.Append("<td align=\"left\">" + dr[matgrid.GetValue(i, 0).ToString()] + "</td>");
                            break;
                    }
                }
          
                    //------------------- Total Approved Hours Text Field -----------------------//
                if (GetRtype().ToString() == "650")
                {
                    if (dr["supervisor_approv_time"].ToString() == "")
                    {
                        html.Append("<td align=\"left\" nowrap=\"nowrap\"><input type=\"text\" maxlength=\"5\" size=\"5\" name=\"Reqhrs_" + dr["OtRequest_id"] + "\" id=\"Reqhrs_" + dr["OtRequest_id"] + "\"> </td>");
                    }
                    else
                    {
                        html.Append("<td align=\"left\" nowrap=\"nowrap\"><input type=\"text\" maxlength=\"5\" size=\"5\" value=\"" + dr["supervisor_approv_time"] + "\" name=\"Reqhrs_" + dr["OtRequest_id"] + "\" id=\"Reqhrs_" + dr["OtRequest_id"] + "\"> </td>");
                    }

                    //------------------- Update Supervisor -----------------------//
                    html.Append("<td align=\"right\" nowrap> <a href='#' onclick='UpdateRequestPeriod(" + dr["OtRequest_id"] + ")'>Update</a>");

                    //------------------- Remarks Field -----------------------//
                    if (dr["supervisor_approved_remark"].ToString() == "")
                    {
                        html.Append("<td align=\"left\" nowrap=\"nowrap\"><input type=\"textarea\" cols=\"20\" rows=\"2\" name=\"txtarea_" + dr["OtRequest_id"] + "\" id=\"txtarea_" + dr["OtRequest_id"] + "\"> </td>");
                    }
                    else
                    {
                        html.Append("<td align=\"left\" nowrap=\"nowrap\"><input type=\"textarea\" cols=\"20\" rows=\"2\" value=\"" + dr["supervisor_approved_remark"] + "\" name=\"txtarea_" + dr["OtRequest_id"] + "\" id=\"txtarea_" + dr["OtRequest_id"] + "\"> </td>");
                    }

                    //------------------- Approve/Reject -----------------------//
                    html.Append("<td align=\"right\" id='TD_" + dr["OtRequest_id"] + "' nowrap><a href='#' onclick='approveSupervisor(" + dr["OtRequest_id"] + ")'>Approve</a></td>");
                    if (dr["status"].ToString() != "s")
                    {
                        html.Append("<td align=\"right\" id='TD_" + dr["OtRequest_id"] +
                                    "' nowrap><a href='#' onclick='rejectSupervisor(" + dr["OtRequest_id"] +
                                    ")'>Reject</a></td>");
                    }

                }
                else
                {

                    //------------------- Remarks Field -----------------------//
                    if (dr["supervisor_approved_remark"].ToString() == "")
                    {
                        html.Append("<td align=\"left\" nowrap=\"nowrap\"><input type=\"textarea\" cols=\"20\" rows=\"2\" name=\"txtarea_" + dr["OtRequest_id"] + "\" id=\"txtarea_" + dr["OtRequest_id"] + "\"> </td>");
                    }
                    else
                    {
                        html.Append("<td align=\"left\" nowrap=\"nowrap\"><input type=\"textarea\" cols=\"20\" rows=\"2\" value=\"" + dr["supervisor_approved_remark"] + "\" name=\"txtarea_" + dr["OtRequest_id"] + "\" id=\"txtarea_" + dr["OtRequest_id"] + "\"> </td>");
                    }

                    //------------------- Approve/Reject -----------------------//
                    html.Append("<td align=\"right\" id='TDA_" + dr["OtRequest_id"] + "' nowrap><a href='#' onclick='HDapproveSupervisor(" + dr["OtRequest_id"] + ")'>Approve</a></td>");
                    if (dr["status"].ToString() != "s")
                    {
                        html.Append("<td align=\"right\" id='TDR_" + dr["OtRequest_id"] + "' nowrap><a href='#' onclick='HDrejectSupervisor(" + dr["OtRequest_id"] +")'>Reject</a></td>");
                    }
                }
                  
               
                html.Append("</tr>");
            }

            html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\"> <tr> <td align=\"center\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("<tr> <td align=\"right\"></td></tr>");
            html.Append("</table>");


            string filter_form = make_filter_form(table_name, matfilter);
            //Project/Assignproject.aspx?Project_id
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "/OverTime/ManageRequestingOverTime.aspx");


            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");

            html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
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

                ctlName = "sch_" + matfilter.GetValue(i, 0);

                if (Request.Cookies[table_name + "_sch_" + ctlName] != null)
                    defValue = Request.Cookies[table_name + "_sch_" + ctlName].Value;

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

                        case "EN":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = " + defValue;
                            break;

                        case "ED":
                            query = query + " and CONVERT(varchar, " + matfilter.GetValue(i, 0).ToString() + ",101) = CONVERT(varchar,CAST( " + filterstring(defValue) + "AS DATETIME),101)";
                            break;

                    }
                }
            }
            return query;
        }
        private string get_paging_block(int _total_record, int _page, int _page_size, Boolean _show_add_button, string _add_page)
        {

            StringBuilder html = new StringBuilder("<input type = \"hidden\" name=\"hdd_curr_page\" id = \"hdd_curr_page\" value=\"" + _page.ToString() + "\">");
            html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
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
            //    html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' border='0'></a>");
            //html.Append("</td>");
            html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion
    }
}
