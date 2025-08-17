using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;

namespace SwiftHrManagement.web.Inventory.Requisition
{
    public partial class RequisitionPlaceManual : BasePage
    {
        ClsDAOInv _clsdao = null;
        String DelProduct = "";
        public RequisitionPlaceManual()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CreateDdlBranch();
                populateBranch();
            }
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();

            init();
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
            AutoCompleteExtender2.ContextKey = branch.Text.ToString();

        }
        private void populateBranch()
        {
            if (ReadSession().UserType == "A")            
                _clsdao.CreateDynamicDDl(branch, "EXEC procGetBranchList @flag='I'", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
            
            else if(ReadSession().UserType == "B")            
                _clsdao.CreateDynamicDDl(branch, "EXEC procGetBranchList @flag='I',"
                     +" @branch_id="+filterstring(ReadSession().Branch_Id.ToString())+"", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
           
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
                        
                        {"item_name",           "Product Name",         "300",      "LT"},
                        {"quantity",       "Qty",        "100",      "LT"},
                        {"unit",           "Unit of Mesurement",            "100",      "LT"}
                        };

            string sortby = "item";
            string table_name = "IN_Temp_Requisition";
            String sql = "select  IN_Temp_Requisition.id, item, quantity, unit, session_id, IN_PRODUCT.porduct_code "
            + " as item_name from IN_Temp_Requisition with(nolock) inner join IN_PRODUCT with(nolock) on IN_Temp_Requisition.item = IN_PRODUCT.id "
            + " where session_id = '" + ReadSession().Sessionid + "'";

            /************************* editable vairable ends***************************************/

            string _page_size = "50";
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

            String sql1 = "select * from (select ROW_NUMBER() OVER (ORDER BY " + sortby + " ) as rowId,* from(" + sql + " ) as aa) as tmp where 1 = 1";

            sql1 += " order by " + sortby + " " + sortd;
            string sqlCount = "select count(*) as totalRecord from (" + sql + ") as tmp;";
            string thisPage = "RequisitionPlaceManual.aspx?sortd=" + sortd + "&sortby={sortby}";
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
            }
            html.Append("</table>");
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
        #endregion

        private string Getproductunit(int itemID)
        {
            string strunit = "";
            strunit = _clsdao.GetSingleresult("select package_unit from IN_PRODUCT where id = " + itemID + "");
            return strunit;
        }
        private void ManageTempRequisition()
        {
            int itemID = 0;
            string[] item = product.Text.Split('|');
            itemID = int.Parse(item[1]);

            _clsdao.runSQL("exec [proc_Requisition] 'i',0," + filterstring(itemID.ToString()) + "," + filterstring(quantity.Text) + "," + filterstring(Getproductunit(itemID)) + "," + filterstring(ReadSession().Sessionid) + ","
            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
        }
        private void ManageRequestion()
        {
            string emp_id = "";
            string[] item = TxtEmpname.Text.Split('|');
            emp_id = item[1].ToString();

            string msg = _clsdao.GetSingleresult("exec [proc_Requisition] 'j',@session_id=" + filterstring(ReadSession().Sessionid) + ",@approver=" + filterstring(emp_id) + ""
            + ",@message=" + filterstring(TxtMessage.Text) + ",@forwarded_to=" + filterstring(DdlBranchRqe.Text) + ",@priority=" + filterstring(Ddlpriority.Text) + ","
            + " @branch=" + filterstring(branch.Text) + ",@department=" + filterstring(DEPT.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            init();
            LblMsg.Text = msg;
            LblMsg.ForeColor = System.Drawing.Color.Red;
            LblMsg.Focus();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageRequestion();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void resetAdd()
        {
            product.Text = "";
            quantity.Text = "";
            txtUnit.Text = "";
            product.Focus();
        }
        private void Deleteproduct()
        {
            if (DelProduct != "")
            {
                _clsdao.runSQL("delete from IN_Temp_Requisition where id = " + DelProduct + "");
            }
            init();
        }
        private void CreateDdlBranch()
        {
            _clsdao.CreateDynamicDDl(DdlBranchRqe, "EXEC procGetBranchList @flag='I',"
            +" @branch_id="+filterstring(ReadSession().Branch_Id.ToString())+"", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
            DdlBranchRqe.Text = ReadSession().Branch_Id.ToString();


        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ManageTempRequisition();
                init();
                resetAdd();
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
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
        protected void product_TextChanged(object sender, EventArgs e)
        {
            if (branch.Text != "")
            {
                if (product.Text.Contains('|'))
                {
                    LblMsg.Text = "";
                    int itemID = 0;
                    string[] item = product.Text.Split('|');
                    itemID = int.Parse(item[1]);
                    if (itemID > 0)
                    {
                        string unit_mesurement = _clsdao.GetSingleresult("SELECT package_unit FROM IN_PRODUCT WHERE id='" + itemID + "'");
                        txtUnit.Text = unit_mesurement;
                        product.Focus();
                    }
                }
                else
                {
                    LblMsg.Text = "Please choose valid product!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    product.Focus();

                }
            }
            else
            {
                LblMsg.Text = "Please Choose Branch!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                LblMsg.Focus();
                return;
            }
        }

        protected void branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsdao.CreateDynamicDDl(DEPT, "EXEC procGetDeptList @FLAG='I',@BRANCH_ID="+filterstring(branch.Text)+"", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "SELECT");
        }
    }
}
