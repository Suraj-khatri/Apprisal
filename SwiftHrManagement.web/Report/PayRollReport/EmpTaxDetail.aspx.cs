using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class EmpTaxDetail : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        double Totpm = 0;
        double Tottm = 0;
        double Totrem = 0;
        double Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
            }
        }

        private void loadReport()
        {

            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string branchID = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string deptID = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            Lblmonth.Text = "Salary Sheet Details For Fiscal Year : " + year + ", Month : " + _clsdao.GetSingleresult("select Name from MonthList where Month_Number=" + month + "");
            lblEmpName.Text = "Employee Name :" + _clsdao.GetSingleresult("select FIRST_NAME + ' ' + MIDDLE_NAME+ ' ' + LAST_NAME from Employee where EMPLOYEE_ID = " + empid);

            DataSet ds = _clsdao.getDataset("Exec [Proc_TaxCalculationReport] @fyid=" + filterstring(year.ToString()) + ",@runmonth=" + filterstring(month.ToString()) + ",@empid=" + filterstring(empid.ToString()) + "");
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");

            DataTable dt = dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            DataTable dt3 = ds.Tables[3];
            DataTable dt4 = ds.Tables[4];
            DataTable dt5 = ds.Tables[5];
            DataTable dt6 = ds.Tables[6];

            str.Append("<tr>");
            str.Append("<th class=\"text-center\"><strong>Head</strong></th><th class=\"text-center\"><strong>Upto Previous Month</strong></th><th class=\"text-center\"><strong>This Month</strong></th><th class=\"text-center\"><strong>Remaining</strong></th><th class=\"text-center\"><strong>Total</strong></th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<th align=\"left\" colspan=\"5\"><strong>Benefits</strong></th>");
            str.Append("</tr>");
            int cols = dt.Columns.Count;
            double pm = 0;
            double tm = 0;
            double rem = 0;
            double tot = 0;
            double odpm = 0;
            double odtm = 0;
            double odrem = 0;
            double odtot = 0;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                pm = pm + double.Parse(dr[1].ToString());
                tm = tm + double.Parse(dr[2].ToString());
                rem = rem + double.Parse(dr[3].ToString());
                tot = tot + double.Parse(dr[4].ToString());
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<th align=\"left\"><strong>Total Benefits</strong></th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(pm.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(tm.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(rem.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(tot.ToString()) + "</th>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<th align=\"left\" colspan=\"5\"><strong>Deductions</strong></th>");
            str.Append("</tr>");
            int col1 = dt1.Columns.Count;
            double pm1 = 0;
            double tm1 = 0;
            double rem1 = 0;
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < col1; i++)
                {
                    if (i == 0)
                    {
                        if (dr[0].ToString() == "Total Contribution")
                        {
                            pm1 = double.Parse(dr[1].ToString());
                            tm1 = double.Parse(dr[2].ToString());
                            rem1 = double.Parse(dr[3].ToString());
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                        else
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                str.Append("</tr>");
            }

            int col2 = dt2.Columns.Count;
            foreach (DataRow dr in dt2.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < col2; i++)
                {
                    str.Append("<td class=\"text-center\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }

            double rdtot = 0;
            int col3 = dt3.Columns.Count;
            foreach (DataRow dr in dt3.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < col3; i++)
                {
                    if (i == 0)
                    {
                        if (dr[0].ToString() == "Retirement Deduction")
                        {
                            rdtot = double.Parse(dr[4].ToString());
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                        else
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                str.Append("</tr>");
            }

            str.Append("<tr>");
            str.Append("<th align=\"left\" colspan=\"5\"><strong> Other Deduction</strong></th>");
            str.Append("</tr>");

            int col4 = dt4.Columns.Count;
            double pm2 = 0;
            double tm2 = 0;
            double rem2 = 0;
            double tot2 = 0;
            foreach (DataRow dr in dt4.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < col4; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                odpm = odpm + double.Parse(dr[1].ToString());
                odtm = odtm + double.Parse(dr[2].ToString());
                odrem = odrem + double.Parse(dr[3].ToString());
                odtot = odtot + double.Parse(dr[4].ToString());
                str.Append("</tr>");
            }

            pm2 = pm1 + odpm;
            tm2 = tm1 + odtm;
            rem2 = rem1 + odrem;
            tot2 = rdtot + odtot;

            str.Append("<tr>");
            str.Append("<th align=\"left\"><strong>Total Deductions</strong></th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(pm2.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(tm2.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(rem2.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(tot2.ToString()) + "</th>");
            str.Append("</tr>");

            int col5 = dt5.Columns.Count;
            foreach (DataRow dr in dt5.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < col5; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                str.Append("</tr>");
            }

            str.Append("<tr>");
            str.Append("<th align=\"left\" colspan=\"5\"><strong>Tax Calculation</strong></th>");
            str.Append("</tr>");
            Totpm = pm - pm2;
            Tottm = tm - tm2;
            Totrem = rem - rem2;
            Total = tot - tot2;

            str.Append("<tr>");
            str.Append("<th align=\"left\">Total Taxable Amount</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(Totpm.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(Tottm.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(Totrem.ToString()) + "</th>");
            str.Append("<th class=\"text-center\">" + ShowDecimal(Total.ToString()) + "</th>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<th align=\"left\" colspan=\"5\"><strong>Tax Slab(Annual Calculation)</strong></th>");
            str.Append("</tr>");

            int col6 = dt6.Columns.Count;
            foreach (DataRow dr in dt6.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < col6; i++)
                {
                    if (i == 0)
                    {
                        if (dr[0].ToString() == "Tax Amount")
                        {
                            str.Append("<td align=\"left\"><b>Total Tax Amount(Annual)</b></td>");
                        }
                        else if (dr[0].ToString() == "Tax Discount")
                        {
                            str.Append("<td align=\"left\"><b>Tax Discount(Annual)</b></td>");
                        }
                        else
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    if (i == 1)
                    {
                        if (dr[1].ToString() != "")
                        {
                            str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                        }
                        else
                            str.Append("<td></td>");
                    }
                    if (i == 2)
                    {
                        if (dr[2].ToString() != "")
                        {
                            str.Append("<td class=\"text-center\">" + dr[i].ToString() + "%" + "</td>");
                        }
                        else
                            str.Append("<td></td>");
                    }
                    if (i == 3)
                    {
                        str.Append("<td></td>");
                        str.Append("<td class=\"text-center\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
