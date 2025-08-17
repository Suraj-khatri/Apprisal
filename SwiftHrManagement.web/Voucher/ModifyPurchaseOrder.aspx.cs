using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.Voucher
{
    public partial class ModifyPurchaseOrder : BasePage
    {
        String DelProduct = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ModifyPurchaseOrder()
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
                DelProduct = Request.Form["ckID"].ToString();
            if (!IsPostBack)
            {
                BtnDelProduct.Visible = false;
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 112) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                txtOrderDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");


                if (GetId() > 0)
                {
                    checkISVat();
                    getProductInfo();
                    getOrderInfo();

                }
            }
            txtProduct_AutoCompleteExtender.ContextKey = hdnVendorId.Value + '|' + ReadSession().Branch_Id.ToString();
            txtRate.Attributes.Add("onblur", "CalculateTotal();");
            txtQty.Attributes.Add("onblur", "CalculateTotal();");
        }
        private void checkISVat()
        {
            string isVAT = _clsdao.GetSingleresult("select case when vat_amt>0 then 'Y' else 'N' end as IsVAT from Purchase_Order_Message where id=" + GetId() + "");
            if (isVAT == "Y")
            {
                chkVAT.Checked = false;
            }
            else
            {
                chkVAT.Checked = true;
            }

        }
        private void getProductInfo()
        {
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("select p.id,i.porduct_code as [Product Name],i.package_unit [Unit],p.qty [Qty],dbo.ShowDecimal(p.rate) as Rate,"
                    + " dbo.ShowDecimal(p.amount) as Amount from Purchase_Order p inner join IN_PRODUCT i on p.product_code=i.id"
                    + " where order_message_id='" + GetId() + "' order by p.id").Tables[0];

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
                    else if (dr[i].ToString() == dr["Rate"].ToString())
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
            str.Append("<td colspan=\"4\"><div align=\"right\"><b>Total Amount :</b></div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\"><b>" + ShowDecimal((tot_amount + VAT_AMT).ToString()) + "</b></asp:TextBox></div></td>");
            str.Append("<td align=\"right\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div");
            hdnVat.Value = ShowDecimal((VAT_AMT).ToString());
            rpt.InnerHtml = str.ToString();
        }
        private void getOrderInfo()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset(@"select p.id,order_no,convert(varchar,order_date,101) as order_date,remarks,forwarded_to,
c.CUSTOMERNAME + '-' + c.CUSTOMERCODE + '|' + convert(varchar,c.ID) as vendor_code,
e.FIRST_NAME + ' ' + e.MIDDLE_NAME + ' ' + e.LAST_NAME + ' -' +e.EMP_CODE + ' ('+b.BRANCH_NAME +') ' +  '|' + convert(varchar, EMPLOYEE_ID)
as emp_name,prod_specfic,CONVERT(VARCHAR,delivery_date,101) delivery_date 
from Purchase_Order_Message p inner join Customer c on p.vendor_code=c.ID inner join Employee e
on e.EMPLOYEE_ID=p.forwarded_to inner join Branches b on e.BRANCH_ID=b.BRANCH_ID where status='Requested'
and p.id='" + GetId() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                txtOrderDate.Text = dr["order_date"].ToString();
                txtVendor.Text = dr["vendor_code"].ToString();

                string[] a = txtVendor.Text.Split('|');
                string vendor_code = a[1];
                hdnVendorId.Value = vendor_code;
                txtSpecification.Text = dr["prod_specfic"].ToString();
               
                txtDeliveryDate.Text = dr["delivery_date"].ToString();
                hdnEmpId.Value = dr["forwarded_to"].ToString();
                txtNotes.Text = dr["remarks"].ToString();
                forwardedto.Text = dr["emp_name"].ToString();
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
                getProductInfo();
                resetFields();
            }
        }
        private void managePurchaseOrderInTemp()
        {
            _clsdao.runSQL("insert into Purchase_Order(order_message_id,product_code,qty,rate,amount)values(" + filterstring(GetId().ToString()) + "," + filterstring(hdnProductId.Value.ToString()) + "," + filterstring(txtQty.Text) + "," + filterstring(txtRate.Text) + "," + filterstring(txtAmount.Text) + ")");
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
                string sql = "DELETE FROM Purchase_Order WHERE id='" + DelProduct + "' and order_message_id='" + GetId() + "'";
                _clsdao.runSQL(sql);
                getProductInfo();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] a = txtVendor.Text.Split('|');
                string vender_code = a[1];
                string check = _clsdao.GetSingleresult("select top(1)id from Purchase_Order where order_message_id=" + GetId() + "");
                if (check != "")
                {
                    _clsdao.runSQL("UPDATE Purchase_Order_Message SET order_date=" + filterstring(txtOrderDate.Text) + ","
                    + " vendor_code=" + filterstring(vender_code) + ",remarks=" + filterstring(txtNotes.Text) + ",forwarded_to=" + filterstring(hdnEmpId.Value) + ","
                    + " vat_amt=" + filterstring(hdnVat.Value) + ",modified_by=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                    + " modified_date=" + filterstring(System.DateTime.Now.ToString()) + ",prod_specfic=" + filterstring(txtSpecification.Text) + ","
                    + " delivery_date=" + filterstring(txtDeliveryDate.Text) + " WHERE id='" + GetId() + "'");

                    _clsdao.runSQL("Update Purchase_Order_Message_History set to_user =" + filterstring(hdnEmpId.Value) + " WHERE Ord_id='" + GetId() + "'");

                    Response.Redirect("ListPurchaseOrder1.aspx");
                }
                else
                {
                    LblMsg.Text = "There is no product for purchase order!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }

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
            string vender_code = a[1];
            string check = _clsdao.GetSingleresult("select top(1)id from Purchase_Order where order_message_id=" + GetId() + "");
            if (check != "")
            {
                _clsdao.runSQL("UPDATE Purchase_Order_Message SET order_date=" + filterstring(txtOrderDate.Text) + ","
                + " vendor_code=" + filterstring(vender_code) + ",remarks=" + filterstring(txtNotes.Text) + ",forwarded_to=" + filterstring(hdnEmpId.Value) + ","
                + " vat_amt=" + filterstring(hdnVat.Value) + ",modified_by=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                + " modified_date=" + filterstring(System.DateTime.Now.ToString()) + ",prod_specfic=" + filterstring(txtSpecification.Text) + ","
                + " delivery_date=" + filterstring(txtDeliveryDate.Text) + " WHERE id='" + GetId() + "'");
            }
            else
            {
                LblMsg.Text = "There is no product information for purchase order!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getProductInfo();
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
        protected void txtProduct_TextChanged(object sender, EventArgs e)
        {
            if (txtVendor.Text != "")
            {
                if (txtProduct.Text != "")
                {
                    LblMsg.Text = "";
                    string[] a = txtProduct.Text.Split('|');
                    string product_id = a[1];
                    string rate = a[2];
                    hdnProductId.Value = product_id;
                    txtRate.Text = rate;
                }
            }
            else
            {
                LblMsg.Text = "Please choose first vendor by autocomplete!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
