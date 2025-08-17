using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport.HeadWise
{
    public partial class BankDeposits : BasePage
    {
        clsDAO _clsDao = null;
        public BankDeposits()
        {
            _clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
            string FY = Request.QueryString["FY"] == null ? "" : Request.QueryString["FY"].ToString();
            string branchId = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string bank = Request.QueryString["bank"] == null ? "" : Request.QueryString["bank"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            StringBuilder str = new StringBuilder("<table width=\"45%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");
            
            this.LblMonth.Text = _clsDao.GetSingleresult("select Name from MonthList where Month_Number=" + filterstring(month));
            this.LblFiscalyear.Text = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            this.LblCurrentDate.Text = _clsDao.GetSingleresult("select convert(varchar, getdate(), 107)");
            this.LblBankName.Text = _clsDao.GetSingleresult("Select DETAIL_DESC from StaticDataDetail where ROWID=" + filterstring(bank));
            this.LblAccNo.Text = _clsDao.GetSingleresult("Select DETAIL_Title from StaticDataDetail where ROWID=" + filterstring(bank));

            DataTable dt = null;
            dt = _clsDao.getDataset("Exec [Proc_BankDeposits] @fy_id=" + filterstring(FY) + ",@Branch=" + filterstring(branchId) + ", @month=" + filterstring(month) + ",@Bank=" + filterstring(bank) + "").Tables[0];

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            double[] sum = new double[cols];

            


            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                        double currVal;
                        double.TryParse(dr[i].ToString(), out currVal);
                        sum[i] += currVal;
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan = \"3\" align=\"left\"><b>Total</b></td>");
            for (int i = 3; i < cols ; i++)
            {
                str.Append("<td align=\"right\"><b>" + ShowDecimal(sum[i].ToString()) + "</b></td>");
            }
            str.Append("</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}