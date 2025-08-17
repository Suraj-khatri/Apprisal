using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.Voucher
{
    public partial class ReceivePurchaseVoucher : BasePage
    {
        String DelProduct = "";
        String DelAccount = "";
        ClsDAOInv _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ReceivePurchaseVoucher()
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
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 114) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                checkISVat();
                insertProductToTemp();
                getProductInfo();
                billDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }            
        }
        private void insertProductToTemp()
        {

            if (GetMode() != "e")
            {
                _clsdao.runSQL("Exec procInsertProductInTemp @flag='i',@session_id=" + filterstring(ReadSession().Sessionid) + ","
                    + " @order_id=" + filterstring(GetOrderMsgId().ToString()) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                    + " @updateQty=" + filterstring(GetQty()) + "");
            }
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private string GetMode()
        {
            return (Request.QueryString["Mode"] != null ? Request.QueryString["Mode"].ToString() : "");
        }

        private string GetQty()
        {
            return (Request.QueryString["Qty"] != null ? Request.QueryString["Qty"].ToString() : "");
        }

        private long GetOrderMsgId()
        {
            return (Request.QueryString["OrderMsgId"] != null ? long.Parse(Request.QueryString["OrderMsgId"].ToString()) : 0);
        }

        /// added by bibhut
        private void checkISVat()
        {
            string isVAT = _clsdao.GetSingleresult("select case when vat_amt>0 then 'Y' else 'N' end as IsVAT from Purchase_Order_Message where id=" + GetOrderMsgId() + "");
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

                dt = _clsdao.getDataset("SELECT T.id,P.porduct_code as 'Product Name',T.qty as Qty,dbo.ShowDecimal(T.rate) as Rate,"
                + " dbo.ShowDecimal(t.qty * t.rate) as Amount FROM Temp_Purchase T INNER JOIN IN_PRODUCT P ON P.id=T.product_code WHERE"
                + " flag='p' and session_id ='" + ReadSession().Sessionid + "' and order_message_id=" + filterstring(GetOrderMsgId().ToString()) + "").Tables[0];
           
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                if (dt.Columns[i].ColumnName != "id")
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("<th align=\"left\">Delete</th>");          
            str.Append("<th align=\"left\">Edit</th>");
            str.Append("<th align=\"left\">Other Info</th></tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                for (int i = 0; i < cols; i++)
                {
                    if (i==3 || i==4)
                    {
                        str.Append("<td><div align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</div></td>");
                    }
                    else if (i == 2)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if(i==1)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }

                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("<td align=\"left\"><span onclick=\"editProduct('" + dr["id"].ToString() + "')\"><a href=\"#\">Modify</a></span></td>");
                str.Append("<td align=\"left\"><span onclick=\"addOther('" + dr["id"].ToString() + "')\"><a href=\"#\">Add</a></span></td>");
                str.Append("</tr>");
            }
            double VAT_AMT = (tot_amount * 0.13);
            if (chkVAT.Checked == true)
            {
                VAT_AMT = 0.0;
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">SUB Total:</div></td>");
            str.Append("<td><div align=\"right\"><b>" + ShowDecimal(tot_amount.ToString()) + "</div></td>");
            str.Append("<td colspan=\"3\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">VAT Amount:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totvat\" name=\"totvat\" size=\"12\" runat=\"server\"><b>" + ShowDecimal(VAT_AMT.ToString()) + "</asp:TextBox></div></td>");
            str.Append("<td colspan=\"3\">&nbsp;</td>");
            str.Append("</tr>");

            ac_amt.Text = ShowDecimal((tot_amount + VAT_AMT).ToString());

            str.Append("<tr>");
            str.Append("<td colspan=\"3\"><div align=\"right\">Total Amount:</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\"><b>" + ShowDecimal((tot_amount + VAT_AMT).ToString()) + "</asp:TextBox><div></td>");
            str.Append("<td colspan=\"3\">&nbsp;</td>");
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
        private void ManageAccountInfo()
        {
            if (double.Parse(ac_amt.Text) <= 0)
                return;
            else
            _clsdao.runSQL("INSERT INTO Temp_Purchase(session_id,product_code,ac_type,amount,flag)VALUES(" + filterstring(ReadSession().Sessionid) + "," + filterstring(TxtAc_Name.Text) + "," + filterstring(DdlType.Text) + "," + filterstring(ac_amt.Text) + ",'a')");

        }
        private void getAccountInfo(string session_id)
        {
            BtnDeleteAcc.Visible = true;
            double tot_amount = 0.00;
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT id,product_code AS 'Account Name',ac_type as 'Type',dbo.ShowDecimal(amount) as 'Amount (CR)' FROM Temp_Purchase WHERE flag='a' and session_id=" + filterstring(session_id) + "").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                if (i!=0)
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
                    if (i==3)
                    {
                        str.Append("<td><div align=\"right\">" + dr[i].ToString() + "</div></td>");
                    }
                    else if (i==1 || i==2)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID1\" name=\"ckID1\" value=\"" + dr["id"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"2\"><div align=\"right\">Total Amount (CR):</div></td>");
            str.Append("<td><div align=\"right\"><asp:TextBox id=\"totamt\" name=\"totamt\" size=\"12\" runat=\"server\"><b>" + ShowDecimal(tot_amount.ToString()) + "</b></asp:TextBox></div></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            rpt1.InnerHtml = str.ToString();
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
        protected void BtnDelProduct_Click(object sender, EventArgs e)
        {
            if (DelProduct != "")
            {
                string sql = "DELETE FROM Temp_Purchase WHERE id='" + DelProduct + "'";
                _clsdao.runSQL(sql);
                getProductInfo();
            }
        }
        private void resetAccountInfo()
        {
            TxtAc_Name.Text = "";
            DdlType.Text = "";
            ac_amt.Text = "";
            TxtAc_Name.Focus();
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            { 
                double tot_amount = 0.00;
                DataTable dt = _clsdao.getDataset("SELECT T.id,T.order_message_id,P.porduct_code as 'Product Code',T.qty as Qty,dbo.ShowDecimal(T.rate) as Rate,"
                + " dbo.ShowDecimal(t.qty * t.rate) as Amount FROM Temp_Purchase T INNER JOIN IN_PRODUCT P ON P.id=T.product_code WHERE"
                + " flag='p' and session_id ='" + ReadSession().Sessionid + "' and order_message_id=" + filterstring(GetOrderMsgId().ToString()) + "").Tables[0];
           
                int cols = dt.Columns.Count;
                if (cols > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        tot_amount = tot_amount + Double.Parse(dr["Amount"].ToString());
                    }               
                }
                if (tot_amount <= 0)
                {
                    LblMsg.Text = "No any product item to receive !";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }            
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
            try
            {               
                string vendor_id = _clsdao.GetSingleresult("select vendor_code from Purchase_Order_Message where id=" + filterstring(GetOrderMsgId().ToString()) + "");

                string msg = _clsdao.GetSingleresult("Exec procSavePurchaseOrderVoucher @flag='i',@mesage=" + filterstring(remarks.Text) + ","
                            + " @date=" + filterstring(billDate.Text) + ",@sessionid=" + filterstring(ReadSession().Sessionid) + ","
                            + " @billno=" + filterstring(billno.Text) + ",@vendor=" + filterstring(vendor_id) + ","
                            + " @msg_id=" + filterstring(GetOrderMsgId().ToString()) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                            + " @branch_id=" + filterstring(ReadSession().Branch_Id.ToString()) + ",@isVat='" + chkVAT.Checked + "'");

                LblMsg.Text = msg;
                LblMsg.Focus();

                if (msg.Contains("Success"))
                {
                    string sql = "exec procReceivePurchaseOrder" + filterstring(GetOrderMsgId().ToString()) + "," + filterstring(ReadSession().Sessionid) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "";
                    _clsdao.runSQL(sql);
                }
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void resetFields()
        {
            billno.Text = "";
            billDate.Text = "";
            remarks.Text = "";
            getAccountInfo(ReadSession().Sessionid);
            getProductInfo();
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            getAccountInfo(ReadSession().Sessionid);
            getProductInfo();
        }
    }
}
  