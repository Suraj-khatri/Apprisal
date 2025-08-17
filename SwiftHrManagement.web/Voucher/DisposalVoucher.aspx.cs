using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Voucher
{
    public partial class DisposalVoucher : BasePage
    {
        String DelProduct = "";
        String DelAccount = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public DisposalVoucher()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
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
                billDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            }
            DdlType.SelectedItem.Text = "DR";

            unitprice.Attributes.Add("onblur", "CalculateTotal();");
            qty.Attributes.Add("onblur", "CalculateTotal();");
            amount.Attributes.Add("onblur", "CalculateTotal();");

            AutoCompleteExtender4.ContextKey = ReadSession().Branch_Id.ToString();
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
            if (unitprice.Text == "")
            {
                LblMsg.Text = "Please enter valid rate!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                unitprice.Focus();
                return;
            }
            if (qty.Text == "")
            {
                LblMsg.Text = "Please enter valid qty!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                qty.Focus();
                return;
            }
            if (amount.Text == "")
            {
                LblMsg.Text = "Please enter valid Amount!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                amount.Focus();
                return;
            }
            
        }
        private void ManageTempPurchase1()
        {
            string product_id = hdnProductId.Value;
            string msg= _clsdao.GetSingleresult("Exec [procManageDisposalVoucher] 'i'," + filterstring(product_id) + "," + filterstring(qty.Text) + "," + filterstring(unitprice.Text) + "," + filterstring(amount.Text) + ","
            + " " + filterstring(ReadSession().Sessionid) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
            if (!msg.Contains("SUCCESS!"))
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

        }
        private void resetAdd()
        {
            txtProduct.Text = "";
            unitprice.Text = "";
            qty.Text = "";
            amount.Text = "";
            txtProduct.Focus();
        }
        private void getAddItems(string session_id)
        {
            BtnDelProduct.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT T.id,P.product_desc+' ('+P.porduct_code+')' as 'Product Code',"
                + " T.qty as Qty,T.rate Rate,T.amount as Amount FROM Temp_Disposal T INNER JOIN IN_PRODUCT P ON "
                + " P.id=T.product_code WHERE flag='d' and session_id=" + filterstring(session_id) + " and order_message_id is null and ac_type='cr'").Tables[0];

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
            str.Append("<th align=\"left\" class=\"text-center\" >Delete</th>");
            str.Append("<th align=\"left\" class=\"text-center\" >Other Info</th></tr>");
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

            ac_amt.Text = (tot_amount).ToString();

            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total Amount:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + tot_amount.ToString() + "</asp:TextBox><div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                checkEmptyFields();
                LblMsg.Text = "";
                ManageTempPurchase1();
                getAddItems(ReadSession().Sessionid);
                resetAdd();
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
            _clsdao.runSQL("INSERT INTO Temp_Disposal(session_id,product_code,ac_type,amount,flag)VALUES(" + filterstring(ReadSession().Sessionid) + "," + filterstring(TxtAc_Name.Text) + "," + filterstring(DdlType.Text) + "," + filterstring(ac_amt.Text) + ",'d')");
        }
        private void resetAccountInfo()
        {
            TxtAc_Name.Text = "";
            //DdlType.Text = "";
            ac_amt.Text = "";
        }
        private void getAccountInfo(string session_id)
        {
            BtnDeleteAcc.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT id,product_code AS 'Account Name',ac_type as 'Type',amount as 'Amount (DR)' FROM Temp_Disposal WHERE flag='d' and session_id=" + filterstring(session_id) + " and ac_type='dr'").Tables[0];

            int cols = dt.Columns.Count;
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
                tot_amount = tot_amount + Double.Parse(dr["Amount (DR)"].ToString());
                for (int i = 0; i < cols; i++)
                {
                    if (dr[i].ToString() == dr["Amount (DR)"].ToString())
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
            str.Append("<td colspan=\"2\"><div align=\"right\">Total Amount (DR):</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\">" + tot_amount.ToString() + "</asp:TextBox></div></td>");
            str.Append("</tr>");

            str.Append("</table>");
            str.Append("</div>");
            rpt1.InnerHtml = str.ToString();

        }

        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelProduct != "")
            {
                string sql = "DELETE FROM Temp_Disposal WHERE id='" + DelProduct + "'";
                _clsdao.runSQL(sql);
                getAddItems(ReadSession().Sessionid);
            }
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

        protected void BtnDeleteAcc_Click(object sender, EventArgs e)
        {
            if (DelAccount != "")
            {
                string sql = "DELETE FROM Temp_Disposal WHERE id='" + DelAccount + "'";
                _clsdao.runSQL(sql);
                getAccountInfo(ReadSession().Sessionid);
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
        private void resetFields()
        {
            billno.Text = "";
            billDate.Text = "";
            remarks.Text = "";
            getAccountInfo(ReadSession().Sessionid);
            getAddItems(ReadSession().Sessionid);
        }
        private void managePurchaseVoucher()
        {
            string SQL = "Exec procSaveDisposalVoucher @flag='i',@mesage=" + filterstring(remarks.Text) + ",@date=" + filterstring(billDate.Text) + ","
            +" @sessionid=" + filterstring(ReadSession().Sessionid) + ",@billno=" + filterstring(billno.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
            +" @branchid=" + filterstring(ReadSession().Branch_Id.ToString())+",@pur_id="+filterstring(hdnPurId.Value)+"";
            string msg = _clsdao.GetSingleresult(SQL);
            LblMsg.Text = msg;
            LblMsg.Focus();
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getAccountInfo(ReadSession().Sessionid);
            getAddItems(ReadSession().Sessionid);
        }

        protected void qty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
