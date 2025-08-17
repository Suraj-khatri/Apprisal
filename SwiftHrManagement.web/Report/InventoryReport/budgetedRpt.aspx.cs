using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;


namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class budgetedRpt : BasePage
    {
        ClsDAOInv _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public budgetedRpt()
        {
            _clsdao = new ClsDAOInv();
            _company = new CompanyDAO();
            _CompanyCore = new CompanyCore();
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
            double Q1 = 0.00;
            double Q2 = 0.00;
            double Q3 = 0.00;

            double A1 = 0.00;
            double A2 = 0.00;
            double A3 = 0.00;

            string branchid = Request.QueryString["branchname"] == null ? "" : Request.QueryString["branchname"].ToString();
            string fy = Request.QueryString["fy"] == null ? "" : Request.QueryString["fy"].ToString();
            string product = Request.QueryString["product"] == null ? "" : Request.QueryString["product"].ToString();

            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            LblBranchName.Text = _clsdao.GetSingleresult("select branch_name as branch from branches where branch_id=" + branchid + "");
            lblFy.Text = fy;

            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;

            LblBranchName.Text = _clsdao.GetSingleresult("select dbo.GetBranchName(" + branchid + ")");
            DataTable dt = _clsdao.getTable("Exec [proc_datewiseMonthlyReport] @flag='C',@BRANCH_ID=" + filterstring(branchid) + ","+
            "@FY=" + filterstring(fy) + ",@PRODUCT_ID=" + filterstring(product) + "");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th align=\"center\" colspan='3'>PRODUCT DESCRIPTION</th>");
            str.Append("<th align=\"center\" colspan='3'>PURCHASE</th>");
            str.Append("<th align=\"center\" colspan='3'>BUDGETED</th>");
            str.Append("<th align=\"center\" colspan='3'>DIFFERENCE</th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<th align=\"left\">PROD CODE</th>");
            str.Append("<th align=\"left\">PRODUCT NAME</th>");
            str.Append("<th align=\"left\">PCK UNIT</th>");

            str.Append("<th align=\"left\">QTY</th>");
            str.Append("<th align=\"left\">RATE</th>");
            str.Append("<th align=\"left\">AMOUNT</th>");
            str.Append("<th align=\"left\">QTY</th>");
            str.Append("<th align=\"left\">RATE</th>");
            str.Append("<th align=\"left\">AMOUNT</th>");
            str.Append("<th align=\"left\">QTY</th>");
            str.Append("<th align=\"left\">RATE</th>");
            str.Append("<th align=\"left\">AMOUNT</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i ==4 || i== 5 || i==7||i==8 ||i==10 |i==11)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else if (i == 6 || i == 9 ||  i == 3)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else 
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                Q1 = Q1 + Double.Parse(dr["PQTY"].ToString());
                Q2 = Q2 + Double.Parse(dr["BQTY"].ToString());
                Q3 = Q3 + Double.Parse(dr["DQTY"].ToString());

                A1 = A1 + Double.Parse(dr["PAMOUNT"].ToString());
                A2 = A2 + Double.Parse(dr["BAMOUNT"].ToString());
                A3 = A3 + Double.Parse(dr["DAMOUNT"].ToString());
            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"3\"><b> TOTAL </b></td>");
            str.Append("<td align=\"center\"><b> " + Q1.ToString() + " </b></td>");
            str.Append("<td align=\"center\"</td>");
            str.Append("<td align=\"right\"><b> " +ShowDecimal(A1.ToString()) + " </b></td>");
            str.Append("<td align=\"center\"><b> " + Q2.ToString() + " </b></td>");
            str.Append("<td align=\"center\"</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(A2.ToString()) + " </b></td>");
            str.Append("<td align=\"canter\"><b> " + Q3.ToString() + " </b></td>");
            str.Append("<td align=\"center\"</td>");
            str.Append("<td align=\"right\"><b> " + ShowDecimal(A3.ToString()) + " </b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
