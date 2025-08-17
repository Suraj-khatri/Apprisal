using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.AssetMovement
{
    public partial class AssetRequisition : BasePage
    {
        String DelAsset = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public AssetRequisition()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ckID"] != null)
                DelAsset = Request.Form["ckID"].ToString();
            if (!IsPostBack)
            {
                BtnDelProduct.Visible = false;
                _clsdao.CreateDynamicDDl(branchname, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "select");
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 62) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                checkEmptyFields();
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void checkEmptyFields()
        {
            if (asset.Text == "")
            {
                LblMsg.Text = "Please enter valid asset type!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                asset.Focus();
                return;
            }
            else if (qty.Text == "")
            {
                LblMsg.Text = "Please enter quantity!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                qty.Focus();
                return;
            }
            else if (amount.Text == "")
            {
                LblMsg.Text = "Please enter valid amount!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                amount.Focus();
                return;
            }
            else
            {
                LblMsg.Text = "";
                manageAssetRequisition();
                getAssetInfo();
                resetFields();
            }
        }
        private void resetFields()
        {
            asset.Text = "";
            qty.Text = "";
            amount.Text = "";
        }
        private void manageAssetRequisition()
        {
            _clsdao.runSQL("INSERT INTO Temp_Purchase(product_code,qty,amount,session_id,flag)values(" + filterstring(hdnAssetId.Value) + "," + filterstring(qty.Text) + "," + filterstring(amount.Text) + "," + filterstring(ReadSession().Sessionid) + ",'r')");
        }
        private void getAssetInfo()
        {
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select t.id,a.porduct_code+'-'+a.ASSET_CODE  AS 'Product Code',t.qty as Qty,t.amount as Amount from Temp_Purchase t inner join ASSET_PRODUCT a "
                    +" on t.product_code=cast(a.id as varchar) WHERE flag='r'  and session_id=" + filterstring(ReadSession().Sessionid) + "").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                if (dt.Columns[i].ColumnName != "id")
                {
                    str.Append("<th align=\"left\" class=\"\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("<th align=\"left\" class=\"\">Delete</th></tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                for (int i = 0; i < cols; i++)
                {
                    if (dr[i].ToString() == dr["Amount"].ToString())
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</div></td>");
                    }
                    else if (dr[i].ToString() != dr["id"].ToString())
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"2\"><div align=\"right\">Total Amount:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + ShowDecimal(tot_amount.ToString()) + "</asp:TextBox></div></td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();
        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelAsset != "")
            {
                string sql = "DELETE FROM Temp_Purchase WHERE id='" + DelAsset + "'";
                _clsdao.runSQL(sql);
                getAssetInfo();
            }   
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managePurchaseOrder();
                Response.Redirect("AssetRequisitionList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void managePurchaseOrder()
        {
            _clsdao.runSQL("Exec [procManageAssetRequisition] 'i'," + filterstring(ReadSession().Sessionid) + "," + filterstring(branchname.Text) + ","
            + " " + filterstring(Ddlpriority.Text) + "," + filterstring(hdnEmpId.Value) + "," + filterstring(narration.Text) + ","
            + " " + filterstring(ReadSession().Branch_Id.ToString()) + "," + filterstring(ReadSession().Department.ToString()) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");

        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getAssetInfo();
        }

    }
}
