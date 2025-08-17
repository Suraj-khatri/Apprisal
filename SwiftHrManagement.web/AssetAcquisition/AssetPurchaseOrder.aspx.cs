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
    public partial class AssetPurchaseOrder : BasePage
    {
        String DelAsset = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public AssetPurchaseOrder()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ckID"] != null)
                DelAsset = Request.Form["ckID"].ToString();
            BtnDelProduct.Visible = false;            
            if (!IsPostBack)
            {  
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 132) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                getAssetInfo();
                txtOrderDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }
        }
        private void getAssetInfo()
        {
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("Exec procGetRemainApprovedAsset 'i',"+filterstring(GetId().ToString())+","+filterstring(ReadSession().Sessionid)+"").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"SimpleGrid\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                if (i == 3 || i == 4)
                {
                    str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if (i == 2)
                {
                    str.Append("<th><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else if(i==1)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
            }
            str.Append("<th align=\"left\">Modify</th>");
            str.Append("<th align=\"left\">Delete</th></tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                for (int i = 0; i < cols; i++)
                {
                    if (i==3 || i==4)
                    {
                        str.Append("<td><div align=\"right\">" + dr[i].ToString() + "</div></td>");
                    }
                    else if (i == 2)
                    {
                        str.Append("<td><div align=\"center\">" + dr[i].ToString() + "</div></td>");
                    }
                    else if(i==1)
                    {
                        str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                    }
                }
                str.Append("<td><a href=\"/AssetAcquisition/EditForOrder.aspx?Id=" + dr["id"] + "&ReqMessId="+GetId()+"\">View</a></td>");
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total Amount:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + ShowDecimal(tot_amount.ToString()) + "</asp:TextBox></div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total VAT:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totvat\" name=\"totvat\" size=\"12\" runat=\"server\">" + ShowDecimal(((tot_amount * 13) / 100).ToString()) + "</asp:TextBox><div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                double totalAmount = 0.0;
                
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("Exec procGetRemainApprovedAsset 'i'," + filterstring(GetId().ToString()) + "," + filterstring(ReadSession().Sessionid) + "").Tables[0];
                int cols = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {
                    totalAmount = Double.Parse(dr["Amount"].ToString());
                    if (totalAmount <= 0)
                    {
                        LblMsg.Text = "Please enter any price for all asset products !";
                        LblMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

                string[] a = txtVendor.Text.Split('|');
                string vender_id = a[1];
                string note="";
                if (ChkNote.Checked == true)
                {
                    note = txtRemarks.Text;
                }
                else
                {
                    note = txtRemarks1.Text;
                }
                _clsdao.runSQL("Exec ProcManageAssetPurchaseOrder 'i'," + filterstring(txtDeliverDate.Text) + "," + filterstring(txtOrderDate.Text) + "," + filterstring(vender_id) + "," + filterstring(note) + "," + filterstring(ReadSession().Sessionid) + "," + filterstring(GetId().ToString()) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
                Response.Redirect("AssetPurchaseOrderList.aspx?Id="+GetId()+"");
            }
            catch
            {
                LblMsg.Text = "Error In Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                getAssetInfo();
            }
            catch
            {
            }
        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (DelAsset != "")
                {
                    string sql = "DELETE FROM asset_temp_order WHERE id='" + DelAsset + "'";
                    _clsdao.runSQL(sql);
                    getAssetInfo();
                }
            }
            catch
            {
            }
        }
    }
}
