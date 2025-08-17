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
    public partial class PurchaseVoucher : BasePage
    {
        String format = "0.00";
        String DelProduct = "";
        String DelAccount = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public PurchaseVoucher()
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
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 111) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                billDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }
            //ACproduct.ContextKey = ReadSession().Branch_Id.ToString();
            unitprice.Attributes.Add("onblur", "CalculateTotal();");
            qty.Attributes.Add("onblur", "CalculateTotal();");
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                checkEmptyFields();
                txtProduct.Focus();
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
            else if (qty.Text == "")
            {
                LblMsg.Text = "Please enter valid qty!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                qty.Focus();
                return;
            }
            else if (unitprice.Text == "")
            {
                LblMsg.Text = "Please enter valid rate!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                unitprice.Focus();
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

            if (hdnProductId.Text != "")
            {
                string product_id = hdnProductId.Text;
                _clsdao.runSQL("Exec procManagePurchaseVoucher 'i'," + filterstring(product_id) + "," + filterstring(qty.Text) + "," + filterstring(unitprice.Text) + "," + filterstring(amount.Text) + ","
                + " " + filterstring(ReadSession().Sessionid) + "," + filterstring(ReadSession().UserId) + "");
            }
            else
            {
                LblMsg.Text = "Please enter valid product name!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtProduct.Focus();
                return;
            }
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
            
            double tot_amount = 0.00;
            DataTable dt = new DataTable();

            dt = _clsdao.getDataset("SELECT T.id,P.porduct_code as 'Product Code',"
                + " T.qty as Qty,dbo.ShowDecimal(T.rate) as Rate,dbo.ShowDecimal(T.amount) as Amount FROM Temp_Purchase T INNER JOIN IN_PRODUCT P ON "
                + " P.id=T.product_code WHERE flag='p' and session_id=" + filterstring(session_id) + " and order_message_id is null").Tables[0];

            int cols = dt.Columns.Count;

                BtnDelProduct.Visible = true;
                StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
                str.Append("<tr>");

                for (int i = 0; i < cols; i++)
                {
                    if (dt.Columns[i].ColumnName != "id")
                    {
                        str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                    }
                }
                str.Append("<th align=\"left\" class=\"\">Delete</th>");
                str.Append("<th align=\"left\" class=\"\">Other Info</th></tr>");

                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (dr[i].ToString() == dr["Amount"].ToString())
                        {
                            str.Append("<td><div align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</div></td>");
                        }
                        else if (i != 0)
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                    str.Append("<td align=\"left\"><span onclick=\"addOther('" + dr["id"].ToString() + "')\"><a href=\"#\">add</a></span></td>");
                    tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                    str.Append("</tr>");
                }


                double VAT_AMT = (tot_amount * 0.13);

                if (chkVAT.Checked == true)
                {
                    VAT_AMT = 0.0;
                }

                str.Append("<tr>");
                str.Append("<td colspan=\"3\"><div align=\"right\">SUB Total:</div></td>");
                str.Append("<td><div align=\"right\"><b>" +ShowDecimal(tot_amount.ToString()) + "</b></div></td>");
                //str.Append("<td><div align=\"right\"><b>2342342.234</b></div></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("</tr>");
                str.Append("<tr>");
                str.Append("<td colspan=\"3\"><div align=\"right\">VAT Amount:</div></td>");
                str.Append("<td><div align=\"right\"><b>" + ShowDecimal(VAT_AMT.ToString()) + "</div></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("</tr>");

                ac_amt.Text = ShowDecimal((tot_amount + VAT_AMT).ToString());

                str.Append("<tr>");
                str.Append("<td colspan=\"3\"><div align=\"right\">Total Amount:</div></td>");
                str.Append("<td><div align=\"right\"><b>" + ShowDecimal((tot_amount + VAT_AMT).ToString()) + "<div></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("</tr>");
                str.Append("</table>");
            str.Append("</div>");
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

            _clsdao.runSQL("INSERT INTO Temp_Purchase(session_id,product_code,ac_type,amount,flag)VALUES(" + filterstring(ReadSession().Sessionid) + "," + filterstring(TxtAc_Name.Text) + "," + filterstring(DdlType.Text) + "," + filterstring(ac_amt.Text) + ",'a')");

        }
        private void resetAccountInfo()
        {
            TxtAc_Name.Text = "";
            DdlType.Text = "";
            ac_amt.Text = "";
        }
        private void getAccountInfo(string session_id)
        {
            
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT id,product_code AS 'Account Name',ac_type as 'Type',amount as 'Amount (CR)' FROM Temp_Purchase WHERE flag='a' and session_id=" + filterstring(session_id) + "").Tables[0];

            int cols = dt.Columns.Count;

                BtnDeleteAcc.Visible = true;
                StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
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
                            str.Append("<td><div align=\"right\">" + ShowDecimal(dr["Amount (CR)"].ToString()) + "</div></td>");
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
                str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + ShowDecimal(tot_amount.ToString()) + "</asp:TextBox></div></td>");
                str.Append("<td>&nbsp;</td>");
                str.Append("</tr>");

                str.Append("</table>");
                str.Append("</div>");
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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (vendor.Text != "")
                {
                    string[] a = vendor.Text.Split('|');
                    string vendor_id = a[1];

                    string SQL = "Exec procSavePurchaseVoucher 'i'," + filterstring(remarks.Text) + "," + filterstring(billDate.Text) + "," + filterstring(ReadSession().Sessionid) + "," + filterstring(billno.Text) + "," + filterstring(vendor_id) + "," + filterstring(ReadSession().UserId) + "," + filterstring(chkVAT.Checked.ToString()) + "," + filterstring(ReadSession().Branch_Id.ToString());
                    string msg = _clsdao.GetSingleresult(SQL);
                    resetFields();
                    LblMsg.Text = msg;
                    LblMsg.ForeColor = System.Drawing.Color.Green;
                    LblMsg.Focus();
                }
                else
                {
                    LblMsg.Text = "Please enter valid vendor name!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    LblMsg.Focus();
                }
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
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

        protected void qty_TextChanged(object sender, EventArgs e)
        {
            string strtest = hdnProductId.Text;
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
        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (vendor.Text.Contains("|"))
            {
                if (txtProduct.Text.Contains("|"))
                {
                    LblMsg.Text = "";
                    string[] a = txtProduct.Text.Split('|');
                    string product_id = a[1];
                    string rate = a[2];
                    hdnProductId.Text = product_id;
                    unitprice.Text = rate;
                    txtUnit.Text = _clsdao.GetSingleresult("SELECT package_unit FROM IN_PRODUCT WHERE id=" + hdnProductId.Text + "");
                    txtProduct.Focus();
                }
                else
                {
                    LblMsg.Text = "Please enter valid product name!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    txtProduct.Focus();
                }
            }
            else
            {
                LblMsg.Text = "Please choose first vendor by autocomplete!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void amount_TextChanged(object sender, EventArgs e)
        {
            amount.Focus();
        }

        protected void vendor_TextChanged(object sender, EventArgs e)
        {
            if (vendor.Text != "")
            {
                if (vendor.Text.Contains("|"))
                {
                    string[] a = vendor.Text.Split('|');
                    string vendor_code = a[1];
                    hdnVendorId.Value = vendor_code;
                    ACproduct.ContextKey = hdnVendorId.Value + '|' + ReadSession().Branch_Id.ToString();
                    vendor.Focus();
                }
                else
                {
                    LblMsg.Text = "Please Choose Vendor Properly!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                LblMsg.Text = "Please Choose Vendor Name First!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        protected void unitprice_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
