using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingManagement.ExternalTrainingManagement
{
    public partial class List : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO Clsdao = null;
        public List()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            Clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 43) == false)
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
                       
                        {"Program_Name",    "Program Name",         "LT"},  
                        {"Start_date",      "Start Date",           "ED"}
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                    {"Program_Name",                "Program Name",              "200",      "T"},
                    {"Start_date",                  "Start Date",                "200",      "T"},
                    {"End_Date",                    "End Date",                  "200",      "T"},
                    {"Conducted_By",                "Conducted By",               "200",      "T"},
                    {"Venue",                       "Venue",                     "200",      "T"},
                    {"City",                        "City",                      "200",      "T"},
                    {"Country",                     "Country",                   "200",      "T"},
                        };

            string sortby = "Program_Name";
            string table_name = "externalTrainingInfo";

            String sql = "";

            sql = "	select external_traingin_id,[Program_Name],convert(varchar,[Start_date],101) as Start_date,convert(varchar,[End_Date],101) as End_Date,[Conducted_By],[Venue],[Total_Capacity],[City]"
            + " ,isnull(cast(request_sendDate_Coo as varchar),0) as request_sendDate_Coo ,[Country],[No_of_days],[No_of_Hours],[Cost_Estimate],[Program_Description],[created_by],[created_date],isnull(cast(Approved_dateBy_Coo as varchar),0) as Approved_dateBy_Coo"
            + ", GETDATE() as nominateWithin,convert(varchar,Nominate_within,101) as Nominate_within  from [externalTrainingInfo] where 1=1";

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
                


                if (dr["request_sendDate_Coo"].ToString() != "0" && dr["Approved_dateBy_Coo"].ToString() == "0")
                {
                    html.Append("<td><a href=\"/TrainingManagement/ExternalTrainingManagement/ManageApproveTrainee.aspx?external_traingin_id=" + dr["external_traingin_id"] + "&flag=a\">HOD Apprved</a></td>");

                }

                else  if (dr["Approved_dateBy_Coo"].ToString()!="0")
                {
                    html.Append("<td><a href=\"/TrainingManagement/ExternalTrainingManagement/ManageApproveTrainee.aspx?external_traingin_id=" + dr["external_traingin_id"] + "&flag=a\">Approved</a></td>");
                }

                else if (Convert.ToDateTime(dr["nominateWithin"]) >= Convert.ToDateTime(dr["Nominate_within"]))
                { 
                html.Append("<td><a href=\"/TrainingManagement/ExternalTrainingManagement/ManageExtTraining.aspx?external_traingin_id=" + dr["external_traingin_id"] + "&flag=c\">Cancel</a></td>");
      
                }

                else
                {

                    html.Append("<td><a href=\"/TrainingManagement/ExternalTrainingManagement/ManageExtTraining.aspx?external_traingin_id=" + dr["external_traingin_id"] + "\">View</a></td>");
                }
               html.Append("</tr>");
            }

            html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\"> <tr> <td align=\"center\"> <strong> Page " + _page.ToString() + " Of " + total_page + "</strong></td></tr>");
            html.Append("<tr> <td align=\"right\"></td></tr>");
            html.Append("</table>");


            string filter_form = make_filter_form(table_name, matfilter);
            //Project/Assignproject.aspx?Project_id
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "/TrainingManagement/ExternalTrainingManagement/ManageExtTraining.aspx");


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
                      
                        case "EN":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + " = " + defValue;
                            break;
                        case "ED":
                            query = query + " and " + matfilter.GetValue(i, 0).ToString() + "  = " + filterstring(defValue);
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
                html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' border='0'></a>");
            html.Append("</td>");
            html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion
    }
}