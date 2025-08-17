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

namespace SwiftAssetManagement.AssetAcquisition
{
    public partial class ModifyAssetRequisition : BasePage
    {
        String DelAsset = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ModifyAssetRequisition()
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
                populateAssetRequisition();
                getAssetRequisitionInfo();
                
            }
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateAssetRequisition()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select e.FIRST_NAME + ' ' + e.MIDDLE_NAME + ' ' + e.LAST_NAME + ' -' +e.EMP_CODE + ' ('+b.BRANCH_NAME +') ' +  '|' + convert(varchar, EMPLOYEE_ID)"
                + " as forwarded_to,approved_by,a.priority,a.narration,forwarded_branch from ASSET_REQUISITION_MESSAGE a inner join Employee e on e.EMPLOYEE_ID=a.approved_by inner join Branches b on "
                + " b.BRANCH_ID=e.BRANCH_ID where a.id='" + GetId() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                branchname.Text = dr["forwarded_branch"].ToString();
                Ddlpriority.SelectedValue = dr["priority"].ToString();
                forwardedto.Text = dr["forwarded_to"].ToString();
                hdnEmpId.Value = dr["approved_by"].ToString();
                narration.Text = dr["narration"].ToString();
            }
        }
        private void getAssetRequisitionInfo()
        {
            
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select t.id,a.porduct_code+'-'+a.ASSET_CODE  AS 'Product Code',t.qty as Qty,t.price as Amount from ASSET_REQUISITION t inner join ASSET_PRODUCT a "
                    + " on t.asset_id=cast(a.id as varchar) WHERE requistion_message_id='" + GetId() + "'").Tables[0];
            
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"SimpleGrid\" cellpadding=\"5\" cellspacing=\"5\"");
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
                        str.Append("<td><div align=\"right\">" +  ShowDecimal(dr[i].ToString()) + "</div></td>");
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
            //str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + tot_amount + "</asp:TextBox></div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + ShowDecimal(tot_amount.ToString()) + "</asp:TextBox></div></td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();      

        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _clsdao.runSQL("UPDATE ASSET_REQUISITION_MESSAGE SET approved_by="+filterstring(hdnEmpId.Value)+",forwarded_branch="+filterstring(branchname.Text)+","
                            +" priority="+filterstring(Ddlpriority.Text)+",narration="+filterstring(narration.Text)+" WHERE id='"+GetId()+"'");
                Response.Redirect("AssetRequisitionList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getAssetRequisitionInfo();
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
                getAssetRequisitionInfo();
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
            _clsdao.runSQL("insert into ASSET_REQUISITION(asset_id,qty,price,requistion_message_id,approved_qty)values(" + filterstring(hdnAssetId.Value) + "," + filterstring(qty.Text) + "," + filterstring(amount.Text) + "," + filterstring(GetId().ToString()) + "," + filterstring(qty.Text) + ")");
        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelAsset != "")
            {
                string sql = "DELETE FROM ASSET_REQUISITION WHERE id='" + DelAsset + "'";
                _clsdao.runSQL(sql);
                getAssetRequisitionInfo();
            }
        }
    }
}
