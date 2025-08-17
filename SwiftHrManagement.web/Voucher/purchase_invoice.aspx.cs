using System;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.Voucher
{
    public partial class purchase_invoice : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public purchase_invoice()
        {
            _clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }
        private string getBillId()
        {
            return (Request.QueryString["bill_id"] != null ? (Request.QueryString["bill_id"].ToString()) : "");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadreport();

            _CompanyCore = _company.FindCompany();
            //this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

        }
        private void loadreport()
        {
            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt10 = new DataTable();
            dt10 = _clsdao.getDataset(@"select a.bill_id,a.billno,convert(varchar,a.bill_date,107) as bill_date,b.CustomerName
                                        from Bill_info a inner join Customer b on a.party_code=b.ID
                                        where a.bill_id=" + getBillId() + "").Tables[0];
            str1.Append("<tr>");
            foreach (DataRow dr in dt10.Rows)
            {
                str1.Append("<td align=\"left\" nowrap=\"nowrap\" class=\"NOBORDER\"><b> Vendor Name : </b> " + dr["CustomerName"].ToString() + "<br>"
                    + "<b> Bill No. : </b> " + dr["billno"].ToString() + " </td>");

                str1.Append("<td align=\"right\" valign=\"top\" nowrap=\"nowrap\" class=\"NOBORDER\"><b>Bill Date : </b> " + dr["bill_date"].ToString() + "</td>");
            }
            str1.Append("</tr>");
            str1.Append("</table>");
            str1.Append("</div>");
            rptDiv1.InnerHtml = str1.ToString();

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsdao.getDataset("exec [procGetPurchaseInvoice] @flag='b',@bill_id=" + filterstring(getBillId().ToString()) + "").Tables[0];

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                if (i == 0 || i == 2 || i == 5)
                {
                    str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if (i == 1)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else
                {
                    str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {

                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0 || i == 2 || i == 5)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i == 1)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                    }

                }
                str.Append("</tr>");
            }
            DataTable dt2 = _clsdao.getDataset("exec [procGetPurchaseInvoice] @flag='c',@bill_id=" + filterstring(getBillId().ToString()) + "").Tables[0];
            foreach (DataRow dr in dt2.Rows)
            {
                str.Append("<tr><td colspan=\"4\"><div align=\"right\"><b>Sub Total</b></div></td><td><div align=\"right\"><b>" + dr["SubTotal"].ToString() + "</b></div></td><td></td><tr>");
                str.Append("<tr><td colspan=\"4\"><div align=\"right\"><b>VAT (13%) </b></div></td><td><div align=\"right\"><b>" + dr["vat_amt"].ToString() + "</b></div></td><td></td><tr>");
                str.Append("<tr><td colspan=\"4\"><div align=\"right\"><b>Grand Total</b></div></td><td><div align=\"right\"><b>" + dr["bill_amount"].ToString() + "</b></div></td><td></td><tr></table></div>");
                rptDiv.InnerHtml = str.ToString();


                billNotes.Text = "Bill Notes : " + dr["bill_notes"].ToString() + "<br/><br/><br/>";
                lblReceivedBy.Text = "Received By :  " + dr["entered_by"].ToString();
                lblReceivedDate.Text = "Received Date :  " + dr["entered_date"].ToString();
            }

        }
    }
}
