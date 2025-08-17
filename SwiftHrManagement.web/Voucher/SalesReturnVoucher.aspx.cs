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

namespace SwiftAssetManagement.Voucher
{
    public partial class SalesReturnVoucher : BasePage
    {
        String DelProduct = "";
        String DelAccount = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public SalesReturnVoucher()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();
            if (Request.Form["ckID1"] != null)
                DelAccount = Request.Form["ckID1"].ToString();
            if (!IsPostBack)
            {
                BtnDelProduct.Visible = false;
                BtnDeleteAcc.Visible = false;
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 44) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                billDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }

            AutoCompleteExtender2.ContextKey = ReadSession().Branch_Id.ToString();


            //contextKey
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
            if (txtProduct.Text == "")
            {
                LblMsg.Text = "Please enter valid product name!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtProduct.Focus();
                return;
            }       
            else if (unitprice.Text == "")
            {
                LblMsg.Text = "Please enter valid rate!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                unitprice.Focus();
                return;
            }
            else if (qty.Text == "")
            {
                LblMsg.Text = "Please enter valid qty!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                qty.Focus();
                return;
            }
            else if (amount.Text == "")
            {
                LblMsg.Text = "Please enter valid Amount!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                amount.Focus();
                return;
            }
            else
            {
                LblMsg.Text = "";
                ManageTempPurchase1();
                getAddItems(ReadSession().Sessionid);
                resetAdd();     
            }              
        }
        private void ManageTempPurchase1()
        {
            string product_id = hdnProductId.Value;
            _clsdao.runSQL("Exec [procSaveSalesReturnVoucher] 'i'," + filterstring(product_id) + "," + filterstring(qty.Text) + "," + filterstring(unitprice.Text) + "," + filterstring(amount.Text) + ","
            +" " +filterstring(ReadSession().Sessionid) + "," +filterstring(ReadSession().UserId) + "");
        }
        private void resetAdd()
        {
            txtProduct.Text = "";
            unitprice.Text = "";
            qty.Text = "";
            amount.Text = "";
        }
        private void getAddItems(string session_id)
        {
            BtnDelProduct.Visible = true;
            double tot_amount=0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT T.id,P.product_desc+' ('+P.porduct_code+')' as 'Product Code',"
                + " T.qty as Qty,dbo.ShowDecimal(T.rate) as Rate,dbo.ShowDecimal(T.amount) as Amount FROM Temp_Purchase T INNER JOIN IN_PRODUCT P ON "
                + " P.id=T.product_code WHERE flag='p' and session_id=" + filterstring(session_id) + " and order_message_id is null").Tables[0];

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
                str.Append("<th align=\"left\" class=\"\">Other Info</th></tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                    for (int i = 0; i < cols; i++)
                    {
                        if (dr[i].ToString() == dr["Amount"].ToString())
                        {
                            str.Append("<td><div align=\"right\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (dr[i].ToString() != dr["id"].ToString())
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");

                    str.Append("<td align=\"left\"><span onclick=\"addOther('" + dr["id"].ToString() + "')\"><a href=\"#\">add</a></span></td>"); 
                    
                    str.Append("</tr>");                    
                }


                double VAT_AMT = (tot_amount * 0.13);

                if (chkVAT.Checked == true)
                {
                    VAT_AMT= 0.0;
                }
                

                str.Append("<tr>");
                str.Append("<td colspan=\"3\"><div align=\"right\">SUB Total:</div></td>");
                str.Append("<td><div align=\"right\">" + (tot_amount) + "</div></td>");
                str.Append("</tr>");
                str.Append("<tr>");
                str.Append("<td colspan=\"3\"><div align=\"right\">VAT Amount:</div></td>");
                str.Append("<td><div align=\"right\"><asp:TextBox id=\"totvat\" name=\"totvat\" size=\"12\" runat=\"server\">" + VAT_AMT + "</asp:TextBox></div></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("</tr>");

                ac_amt.Text = (tot_amount + VAT_AMT).ToString();

                str.Append("<tr>");
                str.Append("<td colspan=\"3\"><div align=\"right\">Total Amount:</div></td>");
                str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + (tot_amount + VAT_AMT) + "</asp:TextBox><div></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("</tr>");                
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
        }
        protected void BtnAddAcc_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAccountInfo();
                getAccountInfo(ReadSession().Sessionid);
                resetAccountInfo();
               
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void DeleteAccount()
        {
            LblMsg.Text = "Delete";
            LblMsg.ForeColor = System.Drawing.Color.Red;
        }

        private void ManageAccountInfo()
        {
            _clsdao.runSQL("INSERT INTO Temp_Purchase(session_id,product_code,ac_type,amount,flag)VALUES("+filterstring(ReadSession().Sessionid)+","+filterstring(TxtAc_Name.Text)+","+filterstring(DdlType.Text)+","+filterstring(ac_amt.Text)+",'a')");

        }
        private void resetAccountInfo()
        {
            TxtAc_Name.Text = "";
            DdlType.Text = "";
            ac_amt.Text = "";
        }
        private void getAccountInfo(string session_id)
        {
            BtnDeleteAcc.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT id,product_code AS 'Account Name',ac_type as 'Type',amount as 'Amount (CR)' FROM Temp_Purchase WHERE flag='a' and session_id=" + filterstring(session_id) + "").Tables[0];

                int cols = dt.Columns.Count;
                StringBuilder str = new StringBuilder("<table border=\"0\" class=\"SimpleGrid\" cellpadding=\"5\" cellspacing=\"5\"");
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (dt.Columns[i].ColumnName != "id")
                    {
                        str.Append("<th align=\"left\" class=\"HeaderStyle\">" + dt.Columns[i].ColumnName + "</th>");
                    }
                }
                str.Append("<th align=\"left\" class=\"HeaderStyle\">Delete</th></tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    tot_amount = tot_amount + Double.Parse(dr["Amount (CR)"].ToString());
                    for (int i = 0; i < cols; i++)
                    {
                        if (dr[i].ToString() == dr["Amount (CR)"].ToString())
                        {
                            str.Append("<td><div align=\"right\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (dr[i].ToString() != dr["id"].ToString())
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID1\" name=\"ckID1\" value=\"" + dr["id"].ToString() + "\"></td>");
                    str.Append("</tr>");
                }
                str.Append("<tr>");
                str.Append("<td colspan=\"2\"><div align=\"right\">Total Amount (CR):</div></td>");
                str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + tot_amount + "</asp:TextBox></div></td>");
                str.Append("</tr>");

                str.Append("</table>");
                rpt1.InnerHtml = str.ToString();

        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelProduct != "")
            {
                string sql = "DELETE FROM Temp_Purchase WHERE id='" + DelProduct + "'";
                _clsdao.runSQL(sql);
                getAddItems(ReadSession().Sessionid);
            }
        }
        protected void BtnDeleteAcc_Click(object sender, EventArgs e)
        {
            if (DelAccount != "")
            {
                string sql = "DELETE FROM Temp_Purchase WHERE id='" + DelAccount + "'";
                _clsdao.runSQL(sql);
                getAccountInfo(ReadSession().Sessionid);
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getAccountInfo(ReadSession().Sessionid);
            getAddItems(ReadSession().Sessionid);
        }

        protected void unitprice_TextChanged(object sender, EventArgs e)
        {
            Double totAmt;
            if (unitprice.Text == "")
            {
                LblMsg.Text = "Please enter valid unit price!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                unitprice.Focus();
            }
            else if (qty.Text == "")
            {
                LblMsg.Text = "Please enter valid quantity!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                qty.Focus();
            }
            else
            {
                LblMsg.Text = "";
                totAmt = (Double.Parse(unitprice.Text) * Double.Parse(qty.Text));
                amount.Text = totAmt.ToString();
            }
         
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managePurchaseVoucher();
                resetFields();                
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void managePurchaseVoucher()
        {
            string[] a = vendor.Text.Split('|');
            string vender_id = a[1];
            string SQL = "Exec procSavePurchaseVoucher 'i'," + filterstring(remarks.Text) + "," + filterstring(billDate.Text) + "," + filterstring(ReadSession().Sessionid) + "," + filterstring(billno.Text) + "," + filterstring(vender_id) + "," + filterstring(ReadSession().UserId) + "," + filterstring(chkVAT.Checked.ToString());
            string msg = _clsdao.GetSingleresult(SQL );
            LblMsg.Text = msg;
            LblMsg.Focus();
        }
        private void resetFields()
        {
            billno.Text = "";
            billDate.Text = "";
            vendor.Text = "";
            remarks.Text = "";
            getAccountInfo(ReadSession().Sessionid);
            getAddItems(ReadSession().Sessionid);
        }
    }
}
