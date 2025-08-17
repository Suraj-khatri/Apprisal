using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.Voucher
{
    public partial class PurchaseOrder : BasePage
    {
        String DelProduct = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public PurchaseOrder()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ckID"] != null)
                DelProduct = Request.Form["ckID"].ToString();
            if (!IsPostBack)
            {
                BtnDelProduct.Visible = false;
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 112) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                txtOrderDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }
            txtRate.Attributes.Add("onblur", "CalculateTotal();");
            txtQty.Attributes.Add("onblur", "CalculateTotal();");
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
                LblMsg.Text = "Please enter valid product code!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtProduct.Focus();
                return;
            }
            else if (txtRate.Text == "")
            {
                LblMsg.Text = "Please enter valid rate!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtRate.Focus();
                return;
            }
            else if (txtQty.Text == "")
            {
                LblMsg.Text = "Please enter valid qty!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtQty.Focus();
                return;
            }
            else if (txtAmount.Text == "")
            {
                LblMsg.Text = "Please enter valid Amount!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtAmount.Focus();
                return;
            }
            else
            {
                LblMsg.Text = "";
                managePurchaseOrderInTemp();
                getProductInfo(ReadSession().Sessionid);
                resetFields();
            }
        }
        private void managePurchaseOrderInTemp()
        {
            if (hdnProductId.Value != "")
            {
                _clsdao.runSQL("Exec [procManagePurchaseVoucher] 'o'," + filterstring(hdnProductId.Value) + "," + filterstring(txtQty.Text) + "," + filterstring(txtRate.Text) + "," + filterstring(txtAmount.Text) + ","
                + " " + filterstring(ReadSession().Sessionid) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
            }
            else
            {
                LblMsg.Text = "Please enter valid product name!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                txtProduct.Focus();
            }
        }
        private void getProductInfo(string session_id)
        {
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT T.id,P.porduct_code as 'Product Name',P.package_unit [Unit],T.qty as Qty, dbo.ShowDecimal(T.rate) as Rate,"
                                    +" dbo.ShowDecimal(T.amount) as Amount FROM Temp_Purchase T INNER JOIN IN_PRODUCT P ON P.id=T.product_code WHERE flag='o'"
                                    +" and session_id=" + filterstring(session_id) + " order by T.id").Tables[0];

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
                    else if (dr[i].ToString() == dr["rate"].ToString())
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</div></td>");
                    }
                    else if (i != 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("</tr>");
            }

            double VAT_AMT = (tot_amount * 0.13);

            if (chkVAT.Checked == true)
            {
                VAT_AMT = 0.00;
            }

            str.Append("<tr>");
            str.Append("<td colspan=\"4\"><div align=\"right\"><b>SUB Total :</b></div></td>");
            str.Append("<td><div align=\"right\"><b>" + ShowDecimal(tot_amount.ToString()) + "</div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan=\"4\"><div align=\"right\"><b>13% VAT :</b></div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totvat\" name=\"totvat\" size=\"12\" runat=\"server\"><b>" + ShowDecimal(VAT_AMT.ToString()) + "</b></asp:TextBox><div></td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan=\"4\"><div align=\"right\"><b>Total Amount:</b></div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\"><b>" + ShowDecimal((tot_amount + VAT_AMT).ToString()) + "</b></asp:TextBox></div></td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            hdnVat.Value = ShowDecimal((VAT_AMT).ToString());
            rpt.InnerHtml = str.ToString();

        }
        private void resetFields()
        {
            txtProduct.Text = "";
            txtRate.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
        }
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelProduct != "")
            {
                string sql = "DELETE FROM Temp_Purchase WHERE id='" + DelProduct + "'";
                _clsdao.runSQL(sql);
                getProductInfo(ReadSession().Sessionid);
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managePurchaseOrder();
                Response.Redirect("ListPurchaseOrder1.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void managePurchaseOrder()
        {
            string[] a = txtVendor.Text.Split('|');
            string vendor_id = a[1];

            string[] e =forwardedto. Text.Split('|');
            string emp_id = e[1];

            _clsdao.runSQL("Exec [procManagePurchaseOrder] @flag='i',@order_date=" + filterstring(txtOrderDate.Text) + ","
                + " @vendor_code=" + filterstring(vendor_id) + ",@forwarded_to=" + filterstring(emp_id) + ","
                + " @session_id=" + filterstring(ReadSession().Sessionid) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                + " @vat=" + filterstring(hdnVat.Value) + ",@branch_id=" + filterstring(ReadSession().Branch_Id.ToString()) + ","
                + " @department_id=" + filterstring(ReadSession().Department.ToString()) + ",@specification="+filterstring(txtSpecification.Text)+","
                + " @delivery_date="+filterstring(txtDeliveryDate.Text)+","
                + " @notes="+filterstring(txtNotes.Text)+"");

        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getProductInfo(ReadSession().Sessionid);
        }
        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtVendor.Text.Contains("|"))
            {
                if (txtProduct.Text.Contains("|"))
                {
                    LblMsg.Text = "";
                    string[] a = txtProduct.Text.Split('|');
                    string product_id = a[1];
                    string rate = a[2];
                    hdnProductId.Value = product_id;
                    txtRate.Text = rate;
                    txtUnit.Text = _clsdao.GetSingleresult("select package_unit from IN_PRODUCT where id="+hdnProductId.Value+"");
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

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            txtAmount.Focus();
        }

        protected void txtVendor_TextChanged(object sender, EventArgs e)
        {
            if (txtVendor.Text != "")
            {
                if (txtVendor.Text.Contains("|"))
                {
                    string[] a = txtVendor.Text.Split('|');
                    string vendor_code = a[1];
                    hdnVendorId.Value = vendor_code;
                    txtProduct_AutoCompleteExtender.ContextKey = hdnVendorId.Value + '|' + ReadSession().Branch_Id.ToString();
                    txtVendor.Focus();
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
    }
}
