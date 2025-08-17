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
    public partial class ReceivePurchaseOrder : BasePage
    {
       String DelAsset = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ReceivePurchaseOrder()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        private long GetOrderMessId()
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
                //if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 131) == false)
                //{
                //    Response.Redirect("/Error.aspx");
                //}
                InsertAssetInfoIntoTemp();
                getAssetInfo();
            }
        }
        private void InsertAssetInfoIntoTemp()
        {
            _clsdao.runSQL("Exec procManageOrderedAsset 'i'," + filterstring(GetOrderMessId().ToString()) + "," + filterstring(ReadSession().Sessionid) + "");
        }
        private void getAssetInfo()
        {
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT t.id,a.porduct_code+'-'+a.ASSET_CODE  AS 'Asset Type',qty as Qty,dbo.ShowDecimal(rate) as Rate,"
            +" dbo.ShowDecimal(amount) as Amount FROM asset_temp_order t with(nolock) inner join ASSET_PRODUCT a with(nolock) ON"
            + " t.asset_id=CAST(a.id AS VARCHAR) WHERE order_message_id=" + filterstring(GetOrderMessId().ToString()) + " AND session_id=" + filterstring(ReadSession().Sessionid) + " and qty<>0").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"SimpleGrid\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                if (i==4 || i==3)
                {
                    str.Append("<th Class=\"HeaderStyle\"><div align=\"right\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else if (i==2)
                {
                    str.Append("<th Class=\"HeaderStyle\"><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else if (i==1)
                {
                    str.Append("<th Class=\"HeaderStyle\"><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
            }
            str.Append("<th Class=\"HeaderStyle\" align=\"left\">Modifiy</th>");
            str.Append("<th Class=\"HeaderStyle\" align=\"left\">Delete</th></tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\">");
                tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                for (int i = 0; i < cols; i++)
                {
                    if (i == 4 || i == 3)
                    {
                        str.Append("<td><div align=\"right\">" + dr[i].ToString() + "</div></td>");
                    }
                    else if (i == 2)
                    {
                        str.Append("<td><div align=\"center\">" + dr[i].ToString() + "</div></td>");
                    }
                    else if (i == 1)
                    {                       
                        str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                    }                    
                }
                str.Append("<td align=\"left\"><span onclick=\"editAsset('" + dr["id"].ToString() + "')\"><a href=\"#\">Modify</a></span></td>");          
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total Amount:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\"><b>" + ShowDecimal(tot_amount.ToString()) + "</b></asp:TextBox></div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total VAT:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totvat\" name=\"totvat\" size=\"12\" runat=\"server\"><b>" + ShowDecimal(((tot_amount * 13) / 100).ToString()) + "</b></asp:TextBox><div></td>");
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
                string msg=_clsdao.GetSingleresult("Exec procManageAssetOrderReceive 'i',"+filterstring(receiveMessage.Text)+","+filterstring(GetOrderMessId().ToString())+","
                +" "+filterstring(ReadSession().Sessionid)+","+filterstring(ReadSession().Emp_Id.ToString())+"");
                if (msg == "sucess")
                {
                    Response.Redirect("AssetOrderReceivedList.aspx?Id=" + GetOrderMessId() + "");
                }
                else
                {
                    LblMsg.Text = msg;
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }                
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getAssetInfo();
        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelAsset != "")
            {
                string sql = "DELETE FROM asset_temp_order WHERE id='" + DelAsset + "' or qty='0'";
                _clsdao.runSQL(sql);
                getAssetInfo();
            } 
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssetOrderReceivedList.aspx?Id=" + GetOrderMessId() + "");
        }
    }
}
