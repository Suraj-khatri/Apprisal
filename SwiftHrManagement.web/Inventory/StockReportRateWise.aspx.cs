using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Inventory
{
    public partial class StockReportRateWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public StockReportRateWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        private string GetProductID()
        {
            return (Request.QueryString["Product"] != null ? (Request.QueryString["Product"]) : "");
        }
        private string GetBranchID()
        {
            return (Request.QueryString["Branch"] != null ? (Request.QueryString["Branch"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchID()!="")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchID() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblBranchName.Text = dr["BRANCH_NAME"].ToString();
                }
            }
            else
            {
                lblBranchName.Text = "All Branches";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string mode = ReadQueryString("mode", "").ToLower();
            if (mode == "download")
            {
                string format = "xls";
                string reportName = "STOCK";
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "inline; filename=" + reportName + "." + format);
                exportDiv.Visible = false;
            }
            PrintReport();
        }
        private void PrintReport()
        {
            double tot_amount = 0.00;
            double tot_qty=0;
            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procStockInHand 'a', " + filterstring(GetBranchID().ToString()) + "," + filterstring(GetProductID().ToString())+",'null','null'");

            _CompanyCore = _company.FindCompany(); 

            this.divCompany.InnerText = _CompanyCore.Name;
            //this.lbldesc.Text = _CompanyCore.Address;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");  
            getBranchName();

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            
            for (int i = 0; i < cols; i++)
            {
                if (i==0||i==2||i==3)
                {
                    str.Append("<th><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                else if (i == 1)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
                else if(i>3)
                {
                    str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                tot_amount = tot_amount + Double.Parse(row["AMOUNT (Rs.)"].ToString());
                tot_qty = tot_qty + Double.Parse(row["STOCK"].ToString());

                for (int i = 0; i < cols; i++)
                {
                    if (i > 3)
                    {
                        str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                    }
                    else if (i == 0 || i == 2 || i == 3)
                    {
                        str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                    }
                    else if(i == 1)
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
            str.Append("<td align=\"right\"><b> "+ShowDecimal(tot_amount.ToString())+"</b> </td>");            
            str.Append("</tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }


    }
}
