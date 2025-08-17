using System;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ManageStatement : BasePage
    {
        ClsDAOInv _clsDao = new ClsDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
            if (!IsPostBack)
            {
                _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches order by branch_short_name", "BRANCH_ID", "BRANCH_NAME", "", "Select");
                fromDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                toDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }
            
        }

        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            lblProduct.Text = GetEmpInfoForLabel(txtProduct.Text, lblProduct.Text);
            txtProduct.Text = "";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (lblProduct.Text == "")
            {
                lblMsg.Text = "Please choose product!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                Response.Redirect("StockStatement.aspx?fromDate=" + fromDate.Text + "&toDate=" + toDate.Text + "&productId=" + getEmpIdfromInfo(lblProduct.Text) + "&branchId=" + DdlBranchName.Text + "");
            }
        }
    }
}
