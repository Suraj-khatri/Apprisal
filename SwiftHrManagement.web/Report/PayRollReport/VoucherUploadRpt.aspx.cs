using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class VoucherUploadRpt : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;

        public VoucherUploadRpt()
        {
            _clsdao = new clsDAO();
            _company = new CompanyDAO();
            _CompanyCore = new CompanyCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();
        }

        void LoadHTML()
        {
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString(); ;
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            string branch = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            _CompanyCore = _company.FindCompany();
            string monthName = _clsdao.GetSingleresult("SELECT Name FROM MonthList WHERE Month_Number=" + month + "");

            double sumD = 0.00;
            double sumC = 0.00;
            double diff = 0.00;

            StringBuilder str = new StringBuilder("<table width=\"80%\" border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\">");

            if (branch == "")
            {
                DataTable dt1 = _clsdao.getDataset("SELECT BRANCH_ID,BRANCH_NAME+' ('+BRANCH_SHORT_NAME+')' BRANCH_NAME FROM Branches ORDER BY BRANCH_ID").Tables[0];
                int cols1 = dt1.Columns.Count;

                foreach (DataRow dr in dt1.Rows)
                {
                    DataTable dt = new DataTable();

                    dt = _clsdao.getDataset("EXEC Proc_SalaryVoucher @fiscalYear = " + filterstring(year) + ",@runmonth = " + filterstring(month) + ",@BRANCH_ID = " + filterstring(dr[0].ToString()) + "").Tables[0];

                    int cols = dt.Columns.Count;

                    str.Append("<tr>");
                    str.Append("<th colspan=\"4\" align=\"center\">" + _CompanyCore.Name + "<br />" + _CompanyCore.Address + "<br /> Fiscal Year: " + year + " Month " + monthName + "</th>");
                    str.Append("</tr>");
                    str.Append("<tr>");
                    str.Append("<th align=\"left\" colspan=\"" + cols + "\">" + dr[1].ToString().ToUpper() + "</th>");
                    str.Append("</tr>");

                    str.Append("<tr>");
                    str.Append("<th>Account Number</th>");
                    str.Append("<th>Particulars</th>");
                    str.Append("<th>Debit</th>");
                    str.Append("<th>Credit</th>");
                    str.Append("</tr>");

                    foreach (DataRow dr1 in dt.Rows)
                    {
                        str.Append("<tr>");
                        if (dr1["flag"].ToString() == "d")
                        {
                            sumD = sumD + double.Parse(dr1["AMOUNT"].ToString());
                            str.Append("<td>" + dr1["accNo"].ToString() + "</td>");
                            str.Append("<td>" + dr1["DESCRIPTION"].ToString() + "</td>");
                            str.Append("<td>" + dr1["AMOUNT"].ToString() + "</td>");
                            str.Append("<td></td>");
                        }
                        if (dr1["flag"].ToString() == "c")
                        {
                            sumC = sumC + double.Parse(dr1["AMOUNT"].ToString());
                            str.Append("<td>" + dr1["accNo"].ToString() + "</td>");
                            str.Append("<td>" + dr1["DESCRIPTION"].ToString() + "</td>");
                            str.Append("<td></td>");
                            str.Append("<td>" + dr1["AMOUNT"].ToString() + "</td>");
                        }
                        str.Append("</tr>");
                    }

                    diff = sumD - sumC;

                    str.Append("<tr>");
                    str.Append("<th colspan=\"2\">Total</th>");
                    str.Append("<th >" + sumD + "</th>");
                    str.Append("<th >" + sumC + "</th>");
                    str.Append("</tr>");
                    str.Append("<tr>");
                    str.Append("<th colspan=\"3\">Difference</th>");
                    str.Append("<th >" + ShowDecimal(diff) + "</th>");
                    str.Append("</tr>");
                    str.Append("<br />");

                    sumD = 0.00;
                    sumC = 0.00;
                    diff = 0.00;

                }
                str.Append("<tr></tr>");
                str.Append("</table>");


                rpt.InnerHtml = str.ToString();
            }
            else
            {
                string branchName = _clsdao.GetSingleresult("SELECT BRANCH_NAME FROM Branches WHERE BRANCH_ID=" + branch + "");
                DataTable dt = new DataTable();

                dt = _clsdao.getDataset("EXEC Proc_SalaryVoucher @fiscalYear = " + filterstring(year) + ",@runmonth = " + filterstring(month) + ",@BRANCH_ID = " + filterstring(branch) + "").Tables[0];

                int cols = dt.Columns.Count;

                str.Append("<tr>");
                str.Append("<th colspan=\"4\" align=\"center\">" + _CompanyCore.Name + "<br />" + _CompanyCore.Address + "<br /> Fiscal Year: " + year + " Month " + monthName + "</th>");
                str.Append("</tr>");

                str.Append("<tr>");
                str.Append("<th>Account Number</th>");
                str.Append("<th>Particulars</th>");
                str.Append("<th>Debit</th>");
                str.Append("<th>Credit</th>");
                str.Append("</tr>");

                foreach (DataRow dr1 in dt.Rows)
                {
                    str.Append("<tr>");
                    if (dr1["flag"].ToString() == "d")
                    {
                        sumD = sumD + double.Parse(dr1["AMOUNT"].ToString());
                        str.Append("<td>" + dr1["accNo"].ToString() + "</td>");
                        str.Append("<td>" + dr1["DESCRIPTION"].ToString() + "</td>");
                        str.Append("<td>" + dr1["AMOUNT"].ToString() + "</td>");
                        str.Append("<td></td>");
                    }
                    if (dr1["flag"].ToString() == "c")
                    {
                        sumC = sumC + double.Parse(dr1["AMOUNT"].ToString());
                        str.Append("<td>" + dr1["accNo"].ToString() + "</td>");
                        str.Append("<td>" + dr1["DESCRIPTION"].ToString() + "</td>");
                        str.Append("<td></td>");
                        str.Append("<td>" + dr1["AMOUNT"].ToString() + "</td>");
                    }
                    str.Append("</tr>");
                }
                diff = sumD - sumC;

                str.Append("<tr>");
                str.Append("<th colspan=\"2\">Total</th>");
                str.Append("<th >" + sumD + "</th>");
                str.Append("<th >" + sumC + "</th>");
                str.Append("</tr>");
                str.Append("<tr>");
                str.Append("<th colspan=\"3\">Difference</th>");
                str.Append("<th >" + ShowDecimal(diff) + "</th>");
                str.Append("</tr>");
                str.Append("<br />");

                sumD = 0.00;
                sumC = 0.00;
                diff = 0.00;

                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
        }
    }
}