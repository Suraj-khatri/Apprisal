using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;


namespace SwiftHrManagement.web.Inventory
{
    public partial class transferDetailRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public transferDetailRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsdao = new ClsDAOInv();
        }
        private string GetBranchID()
        {
            return (Request.QueryString["branch_id"] != null ? (Request.QueryString["branch_id"]) : "");
        }
        private string GetFromDate()
        {
            return (Request.QueryString["from_date"] != null ? (Request.QueryString["from_date"]) : "");
        }
        private string GetTodate()
        {
            return (Request.QueryString["to_date"] != null ? (Request.QueryString["to_date"]) : "");
        }
        private void getBranchName()
        {
            if (GetBranchID() != "")
            {
                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchID() + "'").Tables[0];

                foreach (DataRow dr in dt.Rows)
                {
                    lblbranchname.Text = dr["BRANCH_NAME"].ToString();
                }
            }
            else
            {
                lblbranchname.Text = "All Branches";
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
            StringBuilder str1 = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintdate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblfromdate.Text = GetFromDate();
            lbltodate.Text = GetTodate();
            getBranchName();

            DataTable dt1 = _clsdao.getDataset("Exec [procStockSummaryRptBranchWise] @flag='C',@branchid=" + filterstring(GetBranchID()) + ","
            + "@startdate=" + filterstring(GetFromDate()) + ",@enddate="+filterstring(GetTodate()) + "").Tables[0];
            int cols1 = dt1.Columns.Count;


            foreach (DataRow dr in dt1.Rows)
            {

                for (int i = 0; i < cols1; i++)
                {
                    DataTable dt = _clsdao.getDataset("Exec [procStockSummaryRptBranchWise] @flag='b',@branchid=" + filterstring(dr[i].ToString()) + ",@startdate=" + filterstring(GetFromDate()) + ",@enddate=" + filterstring(GetTodate()) + "").Tables[0];

                    int cols = dt.Columns.Count;
                    int rows = dt.Rows.Count;
                    double qty = 0.0;
                    double amt = 0.0;
                    str1.Append("<tr>");
                    str1.Append("<td align=\"left\" colspan=\"" + cols + "\">&nbsp;</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<th align=\"left\" colspan=\"" + cols + "\"><u>" + dr[i + 1].ToString() + "</u></th>");
                    str1.Append("</tr>");
                    if (rows > 0)
                    {
                        str1.Append("<tr>");
                        for (int l = 1; l < cols; l++)
                        {
                            str1.Append("<td align=\"left\"><b>" + dt.Columns[l].ColumnName.ToString() + "</b></td>");
                        }
                        str1.Append("</tr>");

                        foreach (DataRow dr1 in dt.Rows)
                        {
                            qty = qty + double.Parse(dr1["QTY"].ToString());
                            amt = amt + double.Parse(dr1["Amount"].ToString());
                            str1.Append("<tr>");
                            for (int j = 1; j < cols; j++)
                            {
                                if(j==5|| j==6)
                                {
                                    str1.Append("<td align=\"right\">" + ShowDecimal(dr1[j].ToString()) + "</td>");
                                }
                                else
                                {
                                    str1.Append("<td align=\"left\">" + dr1[j].ToString() + "</td>");
                                }

                            }
                            str1.Append("</tr>");
                        }
                        str1.Append("<tr>");
                        str1.Append("<td align=\"center\" colspan=\"3\"><b>Total</b></td>");
                        str1.Append("<td align=\"center\"><b>" + qty.ToString() + "</b></td>");
                        str1.Append("<td align=\"center\"></td>");
                        str1.Append("<td align=\"right\"><b>" + ShowDecimal(amt.ToString()) + "</b></td>");
                        str1.Append("</tr>");
                    }
                    else
                    {
                        str1.Append("<tr>");

                        str1.Append("<td align=\"center\" colspan=\"" + cols + "\"><b>No Product Information!</b></td>");

                        str1.Append("</tr>");
                    }
                    i++;
                }
            }

            str1.Append("</table>");
            rpt.InnerHtml = str1.ToString();
        }
    }
}
