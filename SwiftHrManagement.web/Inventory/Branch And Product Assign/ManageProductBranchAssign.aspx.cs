using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace SwiftHrManagement.web.Inventory.Branch_And_Product_Assign
{
    public partial class ManageProductBranchAssign : BasePage
    {
         String DelProduct = "";
          ClsDAOInv _clsdao = null;
          public ManageProductBranchAssign()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!Page.IsPostBack)
            {
                populateddl();
            }
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
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


            //column type : LT = like text , ET = Equal to text, EN= equal to numbert,  ED= equal to Date
            String[,] matfilter = new String[,]{  
                            {"BRANCH_NAME",    "Branch Name",         "LT"},
                      
                    };


            //column type : T = text , M = Money, D = date , I = image
            String[,] matgrid = new String[,]{

                {"item_name",     "Product Name",        "100",      "T"},
                {"BRANCH_NAME",     "Branch Name",       "100",      "T"}                       
            };

            string sortby = "ID";
            string table_name = "IN_BRANCH";

            String sql = "";

            sql = "select B.ID,M.item_name,A.BRANCH_NAME,B.PRODUCT_ID,B.BRANCH_ID  from IN_ITEM M "
                       +"  inner join IN_BRANCH B on B.PRODUCT_ID=M.id"
                         +" inner join Branches A on A.BRANCH_ID=B.BRANCH_ID where B.BRANCH_ID="+DdlBranch.Text+" ";


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


            string thisPage = "ManagePlaceRequisition.aspx?sortd=" + sortd + "&sortby={sortby}";

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


            StringBuilder html = new StringBuilder("<table border=\"0\" cellpadding=\"5\" cellspacing=\"5\" class=\"SimpleGrid\" >");

            html.Append("<tr>");

            for (int i = 0; i <= arr_cnt; i++)
            {
                string sortLink = "<a href=\"" + thisPage.Replace("{sortby}", matgrid.GetValue(i, 0).ToString()) + "\">";

                html.Append("<th align=\"left\">" + matgrid.GetValue(i, 1).ToString() + "</a></th>");
            }
            html.Append("<th align=\"right\">Delete</th>");
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


                        case "N":
                            html.Append("<td align=\"right\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "M":
                            html.Append("<td align=\"right\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "T":
                            html.Append("<td align=\"left\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        case "D":
                            html.Append("<td align=\"center\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                        default:
                            html.Append("<td align=\"left\" valign=\"top\">" + dr[matgrid.GetValue(i, 0).ToString()].ToString() + "</td>");
                            break;
                    }
                }
                html.Append("<td align=\"right\"  valign=\"top\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["ID"].ToString() + "\"></td>");
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

        public void populateddl()
        {

            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID,BRANCH_NAME from Branches where 1=1", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            managebranchproduct();
            init();
        }

        private void managebranchproduct()
        {

            string strflag = "";
            string msg = "";
            //if (rowid > 0)
            //    strflag = "u";
            //else
            strflag = "p";

            msg = _clsdao.GetSingleresult("exec proc_in_branch @flag=" + filterstring(strflag) + ",@user=" + filterstring(ReadSession().UserId) + ","
             + " @branchid=" + filterstring(DdlBranch.Text) + ",@productid=" + filterstring(HdnProduct.Value) + "");
            LblMsg.Text = msg;
            LblMsg.ForeColor = System.Drawing.Color.Red;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Deleteproduct();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        private void Deleteproduct()
        {
            if (DelProduct != "")
            {
                _clsdao.runSQL("delete from IN_BRANCH where ID = " + DelProduct + "");
            }
            init();
        }
    }
}
