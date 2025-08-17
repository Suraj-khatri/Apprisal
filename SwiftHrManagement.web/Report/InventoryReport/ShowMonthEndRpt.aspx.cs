using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ShowMonthEndRpt : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public ShowMonthEndRpt()
        {
            _clsdao = new ClsDAOInv();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
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
            loadReport();
        }
        private void loadReport()
        {
            double DR_AMT = 0.00;
            double CR_AMT = 0;
            string from_date = Request.QueryString["fromdate"] == null ? "" : Request.QueryString["fromdate"].ToString();
            string to_date = Request.QueryString["todate"] == null ? "" : Request.QueryString["todate"].ToString();
            string branchid = Request.QueryString["branchname"] == null ? "" : Request.QueryString["branchname"].ToString();

            lblFromDate.Text = from_date;
            lblToDate.Text = to_date;
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");  

            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;

            LblBranchName.Text = _clsdao.GetSingleresult("select dbo.GetBranchName(" + branchid + ")");
            DataTable dt = _clsdao.getTable("Exec [proc_datewiseMonthlyReport] @flag='A',@BRANCH_ID=" + filterstring(branchid) + ","+
            "@FROM_DATE="+filterstring(from_date)+",@TO_DATE="+filterstring(to_date)+"");

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i ==2 || i== 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else if (i == 0)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else 
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                DR_AMT = DR_AMT + Double.Parse(dr["DR AMOUNT"].ToString());
                CR_AMT = CR_AMT + Double.Parse(dr["CR AMOUNT"].ToString());
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"2\"><b> TOTAL </b></td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(DR_AMT.ToString()) + " </b></td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(CR_AMT.ToString()) + "</b> </td>");
            str.Append("<td align=\"right\"></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
