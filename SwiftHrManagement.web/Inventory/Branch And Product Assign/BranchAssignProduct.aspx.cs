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
    public partial class BranchAssignProduct : BasePage
    {
        String selectAll = "";
        String DeleteProduct = "";
        ClsDAOInv _clsdao = null;
        public BranchAssignProduct()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populatelbl();
                populateddl();
                if (GetID() > 0)
                {
                    populateProductBranch();
                    btnUpdate.Visible = true;
                    BtnAdd.Visible = false;
                }
                else
                {
                    BtnAdd.Visible = true;
                    btnUpdate.Visible = false;
                }                     
                OnDisplayData();
                
            }
            if (Request.Form["ckID"] != null)
                DeleteProduct = Request.Form["ckID"].ToString();
        }
        private void populateProductBranch()
        {
            DataTable dt = _clsdao.getTable("exec [proc_in_branch] @flag='s',@id=" + filterstring(GetID().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                DdlBranch.Text = dr["BRANCH_ID"].ToString();

                TxtSalesAcNo.Text = dr["SALES_AC"].ToString();
                TxtInventoryAcNo.Text = dr["INVENTORY_AC"].ToString();
                TxtPurchaseAcNo.Text = dr["PURCHASE_AC"].ToString();
                TxtCommisionAcNo.Text = dr["COMM_AC"].ToString();

                DdlIsActive.Text = dr["IS_ACTIVE"].ToString();

                TxtSalesAc.Text = dr["SALES_NAME"].ToString();
                TxtPurchaseAc.Text = dr["PURCHASE_NAME"].ToString();
                TxtCommisionAc.Text = dr["COMMISSION_NAME"].ToString();
                TxtInventoryAc.Text = dr["EXPENSES_NAME"].ToString();

                TxtReorderLevel.Text = dr["REORDER_LEVEL"].ToString();
                txtReorderQty.Text = dr["REORDER_QTY"].ToString();
                txtMaxStockHoldingQty.Text = dr["MAX_HOLDING_QTY"].ToString();
 
            }
        }
        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private long GetProductId()
        {
            return (Request.QueryString["product_id"] != null ? long.Parse(Request.QueryString["product_id"].ToString()) : 0);
        }

        private void populatelbl()
        {
            string productName = _clsdao.GetSingleresult("SELECT porduct_code FROM IN_PRODUCT WHERE id=" + filterstring(GetProductId().ToString()) + "");
            lblproductName.Text = productName;
            HdnProduct.Value = GetProductId().ToString();
        }

        private void OnDisplayData()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsdao.getTable(@"SELECT  IB.ID,B.BRANCH_NAME [BRANCH NAME],IP.id [PROD CODE],
		IB.REORDER_LEVEL   [RE-ORDER LEAVEL],
		IB.REORDER_QTY [RE-ORDER QTY],IB.MAX_HOLDING_QTY [MAX HOLDING QTY]
	FROM IN_BRANCH IB INNER JOIN IN_PRODUCT IP ON IP.id=IB.PRODUCT_ID INNER JOIN Branches B ON B.BRANCH_ID=IB.BRANCH_ID
	WHERE IB.PRODUCT_ID="+GetProductId()+"");

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 1; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("<th align=\"right\">Modify</th>");
            str.Append("<th align=\"right\">Delete</th>");
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");                   
                }
                str.Append("<td><a href=\"BranchAssignProduct.aspx?ID=" + row["ID"] + "&product_id=" + GetProductId() + "\">Modify</a></td>");
                str.Append("<td align=\"center\"  valign=\"top\"><input type=\"checkbox\" id=\"ckID\" name=\"ckID\" value=\"" + row["ID"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();
        }
        public void populateddl()
        {

            _clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID,BRANCH_NAME from Branches with(nolock) where 1=1", "BRANCH_ID", "BRANCH_NAME", "", "All Branches");
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            managebranchproduct();
            OnDisplayData();

        }
        private void managebranchproduct()
        {
            string msg = _clsdao.GetSingleresult("exec proc_in_branch @flag=" + filterstring("i") + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                                + " @sales_ac=" + filterstring(TxtSalesAcNo.Text) + ",@purchase_ac=" + filterstring(TxtPurchaseAcNo.Text) + ","
                                + "@inventory_ac=" + filterstring(TxtInventoryAcNo.Text) + ",@comm_ac=" + filterstring(TxtCommisionAcNo.Text) + ","
                                + " @branchid=" + filterstring(DdlBranch.Text) + ",@productid=" + filterstring(GetProductId().ToString()) + ","
                                + " @reorderlever=" + filterstring(TxtReorderLevel.Text) + ",@isactive=" + filterstring(DdlIsActive.Text) + ","
                                + " @REORDER_QTY=" + filterstring(txtReorderQty.Text) + ",@MAX_HOLDING_QTY="+filterstring(txtMaxStockHoldingQty.Text)+"");

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
            if (DeleteProduct != "")
            {
                string MSG = _clsdao.GetSingleresult("exec proc_in_branch @flag='d',@id='" + DeleteProduct + "'");
                if (MSG.Contains("SUCCESS"))
                {
                    LblMsg.Text = MSG;
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    OnDisplayData();
                }
                else
                {
                    LblMsg.Text = MSG;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            OnDisplayData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = _clsdao.GetSingleresult("exec proc_in_branch @flag=" + filterstring("u") + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                                + " @sales_ac=" + filterstring(TxtSalesAcNo.Text) + ",@purchase_ac=" + filterstring(TxtPurchaseAcNo.Text) + ","
                                + " @inventory_ac=" + filterstring(TxtInventoryAcNo.Text) + ",@comm_ac=" + filterstring(TxtCommisionAcNo.Text) + ","
                                + " @branchid=" + filterstring(DdlBranch.Text) + ",@productid=" + filterstring(GetProductId().ToString()) + ","
                                + " @reorderlever=" + filterstring(TxtReorderLevel.Text) + ",@isactive=" + filterstring(DdlIsActive.Text) + ","
                                + " @REORDER_QTY=" + filterstring(txtReorderQty.Text) + ",@MAX_HOLDING_QTY=" + filterstring(txtMaxStockHoldingQty.Text) + ","
                                + " @id="+filterstring(GetID().ToString())+"");

                Response.Redirect("BranchAssignProduct.aspx?product_id=" + GetProductId() + "");
            }            
            catch (Exception)
            {
                LblMsg.Text = "Error in Opertaion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}
