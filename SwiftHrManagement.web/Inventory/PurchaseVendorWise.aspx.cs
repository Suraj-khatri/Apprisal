using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class PurchaseVendorWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public PurchaseVendorWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetProductID()
        {
            return (Request.QueryString["Product"] != null ? (Request.QueryString["Product"]) : "");
        }
        private string GetVendorId()
        {
            return (Request.QueryString["Vendor"] != null ? (Request.QueryString["Vendor"]) : "");
        }
        private string GetBranchId()
        {
            return (Request.QueryString["branch"] != null ? (Request.QueryString["branch"]) : "");
        }
        private void GetReportData()
        {
            if (GetVendorId() =="")
            {
                lblVendorName.Text = "All Vendor";
            }
            else
            {
                lblVendorName.Text = _clsdao.GetSingleresult("SELECT customercode+' | '+CustomerName AS Customer_Name from Customer where ID='" + GetVendorId() + "'");
            }
            if (GetBranchId() == "")
                lblBranchName.Text = "All Branches";
            else
                lblBranchName.Text = _clsdao.GetSingleresult("SELECT BRANCH_NAME FROM Branches WHERE BRANCH_ID="+GetBranchId()+"");
                        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            double tot_amount = 0.00;
            double tot_qty = 0;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> ");
            DataTable dt = _clsdao.getTable("Exec procStockInHand 'v', @Branch=" + filterstring(GetBranchId().ToString()) + ",@product=" + filterstring(GetProductID().ToString()) + ",@from="+filterstring(GetVendorId())+"");

            _CompanyCore = _company.FindCompany();

            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            GetReportData();

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                if (i == 0 || i == 3)
                {
                    str.Append("<th><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else if (i == 1 || i==2)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if (i > 3)
                {
                    str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                tot_amount = tot_amount + Double.Parse(row["AMOUNT (Rs.)"].ToString());
                tot_qty = tot_qty + Double.Parse(row["QTY"].ToString());

                for (int i = 0; i < cols; i++)
                {

                    if (i > 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else if (i == 0 || i == 3)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else if (i == 1 || i == 2)
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }

                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"3\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + tot_qty.ToString() + " </b></td>");

            str.Append("<td>&nbsp;</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(tot_amount.ToString()) + "</b> </td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }


    }
}
