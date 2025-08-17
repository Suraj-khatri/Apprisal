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


namespace SwiftHrManagement.web.AssetParameters.AssetCreationV2
{
    public partial class AssetBranchAssignProduct : BasePage
    {
        String DelProduct = "";
          ClsDAOInv _clsdao = null;

          public AssetBranchAssignProduct()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatelbl();
                init();
                populateddl();
            }

            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();

        }
        private long flag()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populatelbl()
        {
            string ID = Request.QueryString["PRODUCT_ID"];
            string productName = _clsdao.GetSingleresult("SELECT porduct_code FROM ASSET_PRODUCT WITH (NOLOCK) WHERE id=" + ID + "");
            lblproductName.Text = productName;
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
                {"BRANCH_NAME",     "Branch Name",       "100",      "T"},
                {"porduct_code",     "Product Name",        "100",      "T"},
                {"ASSET_AC",     "Asset A/C",        "100",      "T"},
                
                {"DEPRECIATION_EXP_AC",     "Depreciation A/C",        "100",      "T"},
                {"WRITE_OFF_EXP_AC",     "Write Off A/C",        "100",      "T"},
                {"SALES_PROFIT_LOSS_AC",     "Sales Profit Loss A/C",        "100",      "T"}
                    
                                        
            };

            string sortby = "ID";
            string table_name = "ASSET_BRANCH";
            string flag = Request.QueryString["flag"];
            string ID = Request.QueryString["PRODUCT_ID"];

            String sql = "";
            sql = "SELECT AB.ID,B.BRANCH_NAME,AP.porduct_code,AB.ASSET_AC,AB.DEPRECIATION_EXP_AC,AB.WRITE_OFF_EXP_AC,AB.SALES_PROFIT_LOSS_AC"
                    +" FROM ASSET_BRANCH AB INNER JOIN Branches B ON AB.BRANCH_ID=B.BRANCH_ID INNER JOIN ASSET_PRODUCT AP ON AP.id=AB.PRODUCT_ID"
                    +" WHERE PRODUCT_ID="+ID+"";



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


            StringBuilder html = new StringBuilder("<table class=\"table-responsive table-bordered table table-striped\">");

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
                html.Append("<td align=\"right\"  valign=\"top\"><input type=\"checkbox\" id=\"ckID\" name=\"ckID\" value=\"" + dr["ID"].ToString() + "\"></td>");
            }
            html.Append("</table>");
            return html.ToString();
            string navigation_bar = get_paging_block(total_record, _page, page_size, true, "");
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
                html.Append("<a href=\"" + _add_page + "\" title=\"Add a new record\"><img src='/images/add.gif' width='14' heigth='14' border='0'></a>");
            html.Append("</td>");
            html.Append("</tr></table>");

            return html.ToString();
        }
        #endregion

        public void populateddl()
        {

            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID,BRANCH_NAME from Branches where 1=1", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }
        private void managebranchproduct()
        {
            string flag = Request.QueryString["flag"];
            string ID = Request.QueryString["PRODUCT_ID"];
            string strflag = "";
            string msg = "";
            strflag = "i";

            msg = _clsdao.GetSingleresult("exec proc_ASSET_branch  @flag='" + strflag + "',@user='" + ReadSession().Emp_Id.ToString() + "',@asset_ac='" + TxtAssetAcNo.Text + "',@depreciation_exp_ac='" + TxtDepExpAcNo.Text + "',"
                       + "@accumulated_dep_ac='" + TxtAccuDepAcNo.Text + "',@write_off_ac='" + TxtWriteOffAcNo.Text + "',@sales_pl_ac='" + TxtSalesPLAcNo.Text + "',@maintainance_ac='" + TxtMaintainExpAcNo.Text + "',"
                       + "@branchid='" + DdlBranch.SelectedValue + "',@productid=" + ID + ",@asset_nextnum='" + 1 + "',@isactive='" + DdlIsActive.Text + "'");

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
            string msg = ""; 
            if (DelProduct != "")
            {
                msg=_clsdao.GetSingleresult("EXEC proc_ASSET_branch  @flag='dall',@id='" + DelProduct + "'");
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
            init();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            managebranchproduct();
            init();

        }
            
        
    }
}
