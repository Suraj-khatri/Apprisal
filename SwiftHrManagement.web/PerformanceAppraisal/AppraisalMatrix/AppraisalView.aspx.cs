using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PerformanceAppraisal;
using SwiftHrManagement.Core.Domain;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalMatrix
{
    public partial class AppraisalView : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO CLsDAo = null;
        protected int appId = 0;
        public AppraisalView()
        {
            CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 6) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                //long positionId1 = (Request.QueryString["positionId"] != null ? long.Parse(Request.QueryString["positionId"].ToString()) : 0);              
                
                CLsDAo.CreateDynamicDDl(DdlPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", "", "");
                
            }
            string position_id = DdlPosition.Text;
            init(position_id);
            //long positionId = (Request.QueryString["positionId"] != null ? long.Parse(Request.QueryString["positionId"].ToString()) : 0);
            //if (positionId > 0)
            //{
            
            //}
            //else
            //{
            //    init(positionId);
            //}
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
        private void init(string position_id)
        {
            /************************* editable vairable starts***************************************/


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert
            String[,] matfilter = new String[,]{  
                        {"T.DETAIL_DESC",    "Topic Name",         "LT"}                  
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                        {"TOPIC_ID",            "Topic",             "200",      "T"},
                        {"SUBTOPIC_ID",       "SubTopic",        "200",      "T"},
                        {"JOB_ELEMENT_ID",    "Job Element",     "200",      "T"}, 
                        {"WEIGHTAGE",    "Weightage",     "200",      "T"},
                        {"PRIORITY_ID",    "Priority",     "200",      "T"}
                        };



            string sortby = "ID";
            string table_name = "AppraisalMatrix";

            String sql = "";
            

            sql = "SELECT A.ID, P.DETAIL_TITLE AS POSITION_ID,T.DETAIL_DESC AS TOPIC_ID,S.DETAIL_DESC AS SUBTOPIC_ID,J.DETAIL_DESC AS JOB_ELEMENT_ID,"
                +" WEIGHTAGE,PRIORITY_ID from AppraisalMatrix A INNER JOIN StaticDataDetail P ON P.ROWID=A.POSITION_ID INNER JOIN "
                +" StaticDataDetail T ON A.TOPIC_ID=T.ROWID INNER JOIN StaticDataDetail S ON S.ROWID=A.SUBTOPIC_ID INNER JOIN "
                + " StaticDataDetail J ON J.ROWID=A.JOB_ELEMENT_ID WHERE POSITION_ID='" + position_id + "'";

            DataTable dt = new DataTable();
            if (long.Parse(position_id) > 0)
            {
                dt = CLsDAo.getDataset("SELECT SUM(weightage)AS WEIGHTAGE FROM AppraisalMatrix WHERE POSITION_ID=" + position_id + "").Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                lblWeight.Text = dr["WEIGHTAGE"].ToString();
            }    
           
            /************************* editable vairable ends***************************************/
            string _page_size = "100";
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

            rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, matfilter, sortd, sortby, _page, page_size,position_id) + "</center>";

        }
    
        private string load_report(string table_name, string sql, String[,] matgrid, string[,] matfilter, String sortd, string sortby, int _page, int page_size,string position_id)
        {
            clsDAO db = new clsDAO();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            //sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "AppraisalView.aspx?sortd=" + sortd + "&sortby={sortby}&positionId=" + position_id + "";


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
                html.Append("<td><a href=\"/PerformanceAppraisal/AppraisalMatrix/Manage.aspx?Id=" + dr["ID"] + "\">View</a></td>");

                html.Append("</tr>");
            }

            html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\"> <tr> <td align=\"center\"></td></tr>");
            html.Append("<tr> <td align=\"right\"></td></tr>");
            html.Append("</table>");


            string filter_form = make_filter_form(table_name, matfilter);
            //Project/Assignproject.aspx?Project_id
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "/PerformanceAppraisal/AppraisalMatrix/Manage.aspx?PositionId=" + position_id + "");


            return filter_form + navigation_bar + html.ToString();
        }
        private string make_filter_form(string table_name, string[,] matfilter)
        {
            StringBuilder html = new StringBuilder("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");


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
            html.Append("<table width=\"700\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\">");
            html.Append("<tr>");
            html.Append("<td width=\"240\" class=\"GridTextNormal\">");
            //html.Append("<select name=\"ddl_per_page\" onChange=\"submit_form();\">");
            //html.Append("<option value=\"10\"" + autoSelect("10", _page_size.ToString()) + ">10</option>");
            //html.Append("<option value=\"20\"" + autoSelect("20", _page_size.ToString()) + ">20</option>");
            //html.Append("<option value=\"30\"" + autoSelect("30", _page_size.ToString()) + ">30</option>");
            //html.Append("<option value=\"40\"" + autoSelect("40", _page_size.ToString()) + ">40</option>");
            //html.Append("<option value=\"50\"" + autoSelect("50", _page_size.ToString()) + ">50</option>");
            //html.Append("</select>&nbsp;&nbsp;per page");
            html.Append("</td>");
            html.Append("<td width=\"539\" align=\"right\">");

            if (_page > 1)
                html.Append("<a href=''");
            else
                html.Append("");

            if (_page * _page_size < _total_record)
                html.Append("<a href=''");
            else
                html.Append("");

            if (_show_add_button)
                html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' border='0'></a>");
            html.Append("</td>");
            html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion

        protected void DdlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlPosition.Text == "")
            {
                return;
            }
            else
            {
                //long positionId2 = long.Parse(DdlPosition.Text);
                //if (positionId2 > 0)
                //{
                //    init(positionId2);
                //}
                //else
                //{
                //    init(positionId2);
                //}
                init(DdlPosition.Text);
            }
        }

    }
}
       