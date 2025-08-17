using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAutomobile.Inventory.Requisition.Deliver
{
    public partial class AddOtherInfo :BasePage
    {
        String DelProduct = "";
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsdao = null;
        public AddOtherInfo()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsdao = new ClsDAOInv();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void getProductInfo()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT P.porduct_code as 'Product Code',T.quantity as Qty FROM IN_Requisition_detail T"
            + " INNER JOIN IN_PRODUCT P ON P.id=T.item WHERE T.id='" + GetId() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblProductName.Text = dr["Product Code"].ToString();
                lblqty.Text = dr["Qty"].ToString();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 44) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                IsSerialed();
                //checkIsBatch();
                deleteUnsavedInfo();
                getProductInfo();
                getAddItems();
            }
        }
        private void IsSerialed()
        {
            string flag1 = _clsdao.GetSingleresult("Exec procCheckProduct 'rc','" + GetId() + "'");
            string flag2 = _clsdao.GetSingleresult("Exec procCheckProduct 'rs','" + GetId() + "'");
            if (flag1 == "N")
            {
                sn_from.Enabled = false;
                sn_to.Enabled = false;
            }
            if (flag2 == "N")
            {
                batch.Enabled = false;
            }
            if (flag1 == "N" && flag2 == "N")
            {
                qty.Enabled = false;
                BtnAdd.Visible = false;
                BtnDelProduct.Visible = false;
                Button1.Visible = false;
                LblMsg.Text = "Sorry! No more add please!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void deleteUnsavedInfo()
        {
            _clsdao.runSQL("delete from IN_Requisition_Other where is_approved is null");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {

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
            if (sn_from.Text == "")
            {
                LblMsg.Text = "Please enter serial start from!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                sn_from.Focus();
                return;
            }
            else if (sn_to.Text == "")
            {
                LblMsg.Text = "Please enter serial start to!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                sn_to.Focus();
                return;
            }
            else if (qty.Text == "")
            {
                LblMsg.Text = "Please enter quantity!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                qty.Focus();
                return;
            }
            else
            {
                LblMsg.Text = "";
                manageOtherInfo();
            }
        }
        private void manageOtherInfo()
        {
            if (Double.Parse(lblqty.Text) >= Double.Parse(qty.Text))
            {
                string totQty = _clsdao.GetSingleresult("select ISNULL(SUM(qty),0) as totQty from IN_Requisition_Other where requisition_id ='" + GetId() + "'");

                if (Double.Parse(lblqty.Text) >= (Double.Parse(totQty) + Double.Parse(qty.Text)))
                {
                    _clsdao.runSQL("INSERT INTO IN_Requisition_Other(requisition_id,sn_from,sn_to,batch,qty)VALUES(" + filterstring(GetId().ToString()) + "," + filterstring(sn_from.Text) + "," + filterstring(sn_to.Text) + "," + filterstring(batch.Text) + "," + filterstring(qty.Text) + ")");
                    getAddItems();
                    resetAdd();
                }
                else
                {
                    LblMsg.Text = "Qty out of range!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                LblMsg.Text = "Qty out of range!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void getAddItems()
        {
            double totQty = 0;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select id,sn_from as 'Serial From',sn_to as 'Serial To',batch as Batch,qty as Qty from IN_Requisition_Other where requisition_id='" + GetId() + "'").Tables[0];

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
            str.Append("<th align=\"left\" class=\"\">Delete</th>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                totQty = totQty + Double.Parse(dr["qty"].ToString());
                for (int i = 0; i < cols; i++)
                {
                    if (dr[i].ToString() != dr["id"].ToString())
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("</tr>");

            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total Qty:</div></td>");
            str.Append("<td><div align=\"left\"><asp:TextBox id=\"totqty\" name=\"totqty\" size=\"12\" runat=\"server\">" + totQty + "</asp:TextBox></div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
        private void resetAdd()
        {
            sn_from.Text = "";
            sn_to.Text = "";
            qty.Text = "";
            batch.Text = "";
            qty.Focus();
        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelProduct != "")
            {
                string sql = "DELETE FROM IN_Requisition_Other WHERE id='" + DelProduct + "'";
                _clsdao.runSQL(sql);
                getAddItems();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string totQty = _clsdao.GetSingleresult("select ISNULL(SUM(qty),0) as totQty from IN_Requisition_Other where requisition_id ='" + GetId() + "'");

            if (Double.Parse(lblqty.Text) != (Double.Parse(totQty)))
            {
                LblMsg.Text = "Total quantity must be equal to sum of added qty!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                _clsdao.runSQL("update IN_Requisition_Other set is_approved='y' where requisition_id='" + GetId() + "'");
                LblMsg.Text = "Save operation sucessfully completed!";
                LblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void sn_from_TextChanged(object sender, EventArgs e)
        {
            sn_to.Text = (long.Parse(qty.Text) + long.Parse(sn_from.Text) - 1).ToString();
            batch.Focus();
        }
    }
}
