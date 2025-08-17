using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;
namespace SwiftAssetManagement.GetPass.Out
{
    public partial class ManageGetpassDetail : BasePage
    {
        ClsDAOInv _clsdao = null;
        String DeletePass = "";
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ManageGetpassDetail()
        {
            _clsdao = new ClsDAOInv();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 144) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}
            }
            
            if (Request.Form["ckID"] != null)
                DeletePass = Request.Form["ckID"].ToString();
            init();
            BtnBack.Attributes.Add("onclick", "history.back();return false");

            TxtAssetNumber_AutoCompleteExtender.ContextKey = ReadSession().Branch_Id.ToString();
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
                    {"item",    "item",         "LT"},   
                    };

            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{
                        
                        {"asset_number",    "Asset Number",    "200",     "LT"},
                        {"BRANCH_NAME",     "Branch",          "10",      "LT"},
                        {"DEPARTMENT_NAME", "Department",      "10",      "LT"}
                        };

            string sortby = "id";
            string table_name = "Asset_Temp_Gatepass";
            String sql = "select tg.id, ai.asset_number, b.BRANCH_NAME, d.DEPARTMENT_NAME  from Asset_Temp_Gatepass tg "
            + " inner join ASSET_INVENTORY ai on tg.asset_id = ai.id inner join Branches b on tg.branch_id = b.BRANCH_ID "
            + " inner join Departments d on tg.dept_id = d.DEPARTMENT_ID where tg.session_id = '" + ReadSession().Sessionid + "'";

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

            rpt.InnerHtml = "<center>" + load_report(table_name, sql, matgrid, sortd, sortby, _page, page_size) + "</center>";
        }
        private string load_report(string table_name, string sql, String[,] matgrid, String sortd, string sortby, int _page, int page_size)
        {
            ClsDAOInv db = new ClsDAOInv();

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1 ";
            sql1 += " and  tmp.rowId between " + ((_page - 1) * page_size + 1).ToString() + " and " + (_page * page_size).ToString();

            sql1 += " order by " + sortby + " " + sortd;

            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";


            string thisPage = "EditListView.aspx?sortd=" + sortd + "&sortby={sortby}";


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


            StringBuilder html = new StringBuilder("<table width=\"500\" border=\"0\" cellpadding=\"5\" cellspacing=\"5\" align=\"left\" class=\"SimpleGrid\" >");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\">";

                html.Append("<th align=\"left\">" + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("<th align=\"left\">Delete</th>");
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
                html.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                html.Append("</tr>");
            }
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
        #endregion
        private void populategatepass()
        {
            DataTable dt = _clsdao.getTable("exec proc_getpass @flag = 's',@asset_id=" + HdnAssetnumber.Value + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtBookvalue.Text = dr["bookvalue"].ToString();
                TxtBranch.Text = dr["branch_name"].ToString();
                TxtDepartment.Text = dr["department_name"].ToString();
                TxtAssetHolder.Text = dr["asset_holder"].ToString();
            }
        }
        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            populategatepass();   
        }
        private void manage()
        {
            string id = "";
            id =
                _clsdao.GetSingleresult("exec proc_getpass @flag = 'p', @id = 0,@user = " + ReadSession().Emp_Id +
                                        ", @getpass_date = " + filterstring(TxtGatepassDate.Text) + ", @returnable = " +
                                        DdlReturnable.Text + ", @out_message = " + filterstring(TxtMessage.Text) + ",@session_id = " +
                                        filterstring(ReadSession().Sessionid) + ", @delivered_to=" + filterstring(Txtdeliveredto.Text) + "");
            Response.Redirect("/Report/Gatepassreport.aspx?id="+ id +"");
        }
        private bool ckeckforempty()
        {
            String sql = "select tg.id, ai.asset_number, b.BRANCH_NAME, d.DEPARTMENT_NAME  from Asset_Temp_Gatepass tg "
            + " inner join ASSET_INVENTORY ai on tg.asset_id = ai.id inner join Branches b on tg.branch_id = b.BRANCH_ID "
            + " inner join Departments d on tg.dept_id = d.DEPARTMENT_ID where tg.session_id = '" + ReadSession().Sessionid + "'";
            DataTable dt = _clsdao.getTable(sql);
            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckeckforempty() == false)
                    return;
                manage();
                
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void manageAdtoTemp()
        {
            _clsdao.runSQL("exec proc_getpass @flag = 'i',@asset_id=" + HdnAssetnumber.Value + ",@session_id='" + ReadSession().Sessionid + "'");
        }
        private void resetTempgatepass()
        {
            TxtAssetNumber.Text = "";
            TxtBookvalue.Text = "";
            TxtBranch.Text = "";
            TxtDepartment.Text = "";
            TxtAssetHolder.Text = "";
            TxtAssetNumber.Focus();
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            manageAdtoTemp();
            resetTempgatepass();
            init();
        }
        private void deleteGatepass()
        {
            _clsdao.runSQL("exec proc_getpass @flag = 'd', @id = '" + DeletePass + "'");
            init();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            deleteGatepass();
        }
    }
}
