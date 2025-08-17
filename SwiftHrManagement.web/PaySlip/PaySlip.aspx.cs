using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Payrole;


namespace SwiftHrManagement.web.PaySlip
{
    public partial class PaySlip : BasePage
    {
        private clsDAO _clsDao = null;
        payroleDAO _payroll = null;

        double pm = 0;
        double tm = 0;
        double rem = 0;
        double tot = 0;

        public PaySlip()
        {
            this._clsDao = new clsDAO();
            this._payroll= new payroleDAO();
        }

        public string GetYear()
        {
            return Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
        }

        public string GetMonth()
        {
            return Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
        }

        public string GetEmp()
        {
            return Request.QueryString["empId"] == null ? "" : Request.QueryString["empId"].ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReport();
        }

        protected void LoadReport()
        {
            ShowEmpDetails();
            ShowMonthlySalarySlip();
            ShowTotalBenefitforTax();
            ShowInsuranceBenefit();
            ShowTaxCalculation();
            ShowTaxNGratuity();
            ShowFacility();
            ShowEstimatedRf();
            ShowAppRating();
        }

        protected  void ShowEmpDetails()
        {
            DataSet ds = _clsDao.getDataset("exec [Proc_MonthlyPaySlip] @flag='ed',@empid=" + GetEmp() + ",@year=" + filterstring(GetYear()) + ",@month=" + filterstring(GetMonth()) + "");

            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblEmpName.Text = dr["NAME"].ToString();
                lblBranchName.Text = dr["BRANCH"].ToString();
                lblPosition.Text = dr["POSITION"].ToString();
                lblBankAccount.Text = dr["ACCOUNT_NUMBER"].ToString();
                lblFiscalYear.Text = GetYear();
                lblMonthName.Text = dr["MONTH_NAME"].ToString();
                lblDate.Text = dr["nep_date"].ToString();
            } 
        }

        protected void ShowMonthlySalarySlip()
        {
            DataSet ds = _payroll.Executepayroll("exec [proc_PayRollReportMonthly] '" + GetYear() + "','" + GetMonth() + "','" + GetEmp() + "'");


            //DataSet ds = AppraisalList(this.appId);

            DataTable dt = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            StringBuilder str = new StringBuilder("");
            int cols = dt.Columns.Count;
            double Benifit = 0;
            double Deduction = 0;

            str.Append("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            foreach (DataRow dr in dt.Rows)
            {

                str.Append("<tr>");
                str.Append(" <td colspan=\"2\" class=\"bluetext\" > &nbsp;&nbsp;&nbsp; &nbsp;" + dr[0].ToString() + "</td><td> " + dr[1].ToString() + "</td>");
                str.Append("</tr>");

                Benifit = Benifit + double.Parse(dr[1].ToString());

            }
            str.Append("<tr><td>&nbsp;&nbsp;&nbsp;<b>Total Benefit</td>" +
                       " <td>&nbsp;</td>  <td  ><b> " + Benifit.ToString("0.00") + "</td></tr>");

            str.Append("</table>");
            str.Append("</div>");


            StringBuilder str1 = new StringBuilder("");

            str1.Append("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            foreach (DataRow dr1 in dt2.Rows)
            {

                str1.Append("<tr>");
                str1.Append(" <td colspan=\"2\" class=\"bluetext\" > &nbsp;&nbsp;&nbsp; &nbsp;" + dr1[0].ToString() + "</td><td > " + dr1[1].ToString() + "</td>");
                str1.Append("</tr>");

                Deduction = Deduction + double.Parse(dr1[1].ToString());
            }

            str1.Append("<tr><td <b>Total Deduction</td>" +
                       " <td>&nbsp;</td>  <td><b> " + Deduction.ToString("0.00") + "</td></tr>");

            str1.Append("</table>");
            str.Append("</div>");

            lblNetAmount.Text = (Benifit - Deduction).ToString("0.00");
            rptSalary.InnerHtml = str.ToString();
            rptSalaryD.InnerHtml = str1.ToString();
        }

        protected void ShowTotalBenefitforTax()
        {
            DataSet ds = _clsDao.getDataset("Exec [Proc_TaxCalculationReport] @fyid=" + filterstring(GetYear()) + ",@runmonth=" + filterstring(GetMonth()) + ",@empid=" + filterstring(GetEmp()) + "");
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = ds.Tables[0];

            str.Append("<tr> "
                            + " <td class=\"RedText\" colspan=\"3\" nowrap > Description</td>"
                            + " <td class=\"RedText\" align=\"right\">Till Last Month</td>"
                            + " <td class=\"RedText\" align=\"right\">This Month</td>"
                            + " <td class=\"RedText\" align=\"right\">Estimated</td>"
                            + " <td class=\"RedText\" align=\"right\">Annual</td>"
                         +" </tr>");
             str.Append("<tr>"
                        +" <td colspan=\"7\" ><hr color=\"#009900\" size=\"1\" /></td>"
                        +" </tr>");
            
            str.Append("</tr>");

            int cols = dt.Columns.Count;
           

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"bluetext\" colspan=\"3\" nowrap> " + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                pm = pm + double.Parse(dr[1].ToString());
                tm = tm + double.Parse(dr[2].ToString());
                rem = rem + double.Parse(dr[3].ToString());
                tot = tot + double.Parse(dr[4].ToString());
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td class=\"greentext\" colspan=\"3\" nowrap><strong> Net Income</strong></td>");
            str.Append("<td class=\"greentext\" align=\"right\">" + ShowDecimal(pm.ToString()) + "</td>");
            str.Append("<td class=\"greentext\" align=\"right\">" + ShowDecimal(tm.ToString()) + "</td>");
            str.Append("<td class=\"greentext\" align=\"right\">" + ShowDecimal(rem.ToString()) + "</td>");
            str.Append("<td class=\"greentext\" align=\"right\">" + ShowDecimal(tot.ToString()) + "</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            YearlyBenefits.InnerHtml = str.ToString();
        }

        protected void ShowInsuranceBenefit()
        {
            //DataTable dt = _clsDao.getDataset("select Sdd.detail_title, sum(ANNUAL_PREMIUM_AMT) Amount from Insurance I "
            //            + " Inner join StaticDataDetail sdd on I.Insurance_For=sdd.ROWID "
            //            +" where PREMIUM_PAYER='Employer' "
            //            + " AND EMPLOYEE_ID=" + filterstring(GetEmp()) + ""
            //            + " group by detail_title").Tables[0];

            DataTable dt = _clsDao.getDataset("select Sdd.detail_title, sum(ANNUAL_PREMIUM_AMT) Amount from Insurance I "
                        + " Inner join StaticDataDetail sdd on I.Insurance_For=sdd.ROWID "
                        + "inner join FiscalYear f on i.EXPIRY_DATE > f.EN_YEAR_START_DATE"
                        + " where PREMIUM_PAYER='Employer'and f.FLAG='1' "
                        + " AND EMPLOYEE_ID=" + filterstring(GetEmp()) + ""
                        + " group by detail_title").Tables[0];

            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            str.Append("<td class=\"RedText\"><span >Description</span></td>");
            str.Append("<td class=\"RedText\" align=\"right\">Amount</td>");
            str.Append("<td colspan=\"3\" >&nbsp;</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"7\" ><hr color=\"#009900\" size=\"1\" /></td>");
            str.Append("</tr>");

            double tot = 0;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"bluetext\"  nowrap> " + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
               
                tot = tot + double.Parse(dr["Amount"].ToString());
                str.Append("</tr>");
            }

            str.Append("<tr>");
            str.Append("<td class=\"greentext\"  nowrap><strong> Total </strong></td>");
            str.Append("<td class=\"greentext\" align=\"right\">" + ShowDecimal(tot.ToString()) + "</td>");
            str.Append("<td colspan=\"3\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            InsuranceBenefit.InnerHtml = str.ToString();
        }

        protected void ShowTaxCalculation()
        {
            DataSet ds = _clsDao.getDataset("Exec [Proc_MonthlyPaySlip] @flag='tc', @year=" + filterstring(GetYear()) + ",@month=" + filterstring(GetMonth()) + ",@EmpID=" + filterstring(GetEmp()) + "");
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = ds.Tables[0]; 

            str.Append("<tr>");
            str.Append("<td class=\"RedText\" width=\"20%\"><span >Description</span></td>");
            str.Append("<td class=\"RedText\" width=\"20%\" align=\"right\"><span >Amount</span></td>");
            str.Append("<td class=\"RedText\" width=\"20%\" align=\"right\"><span>Total Amount</span></td>");
            str.Append("<td colspan=\"2\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"5\" ><hr color=\"#009900\" size=\"1\" /></td>");
            str.Append("</tr>");

            int cols = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"bluetext\" nowrap> " + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }

                str.Append("<td colspan=\"2\">&nbsp;</td>");
                str.Append("</tr>");
            }

            str.Append("</table>");
            str.Append("</div>");
            TaxCalculationDetail.InnerHtml = str.ToString();

        }

        protected void ShowTaxNGratuity()
        {
            DataSet ds = _clsDao.getDataset("Exec [Proc_MonthlyPaySlip] @flag='tg', @year=" + filterstring(GetYear()) + ",@month=" + filterstring(GetMonth()) + ",@EmpID=" + filterstring(GetEmp()) + "");
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = ds.Tables[0];

            str.Append("<tr>");
            str.Append("<td class=\"RedText\">Description</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Collected/Earned</td>");
            str.Append("<td class=\"RedText\" align=\"right\">This Month</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Estimated</td>");
            str.Append("<td class=\"RedText\" align=\"right\">By F/Y End</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"5\" ><hr color=\"#009900\" size=\"1\" /></td>");
            str.Append("</tr>");

            int cols = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"bluetext\"  nowrap> " + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td align=\"right\" >" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                str.Append("</tr>");
            }

            str.Append("</table>");
            str.Append("</div>");
            TaxNGratuity.InnerHtml = str.ToString();
        }

        protected void ShowFacility()
        {
            DataSet ds = _clsDao.getDataset("Exec [Proc_MonthlyPaySlip] @flag='f', @year=" + filterstring(GetYear()) + ",@month=" + filterstring(GetMonth()) + ",@EmpID=" + filterstring(GetEmp()) + "");
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = ds.Tables[0];

            str.Append("<tr>");
            str.Append("<td class=\"RedText\">Description</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Disbursed</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Other Payment</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Ded. From Salary</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Balance</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"5\" ><hr color=\"#009900\" size=\"1\" /></td>");
            str.Append("</tr>");

            int cols = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"bluetext\"  nowrap> " + dr[i].ToString() + "</td>");
                    }
                    else
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                }
                str.Append("</tr>");
            }

            str.Append("</table>");
            str.Append("</div>");
            Facility.InnerHtml = str.ToString();
        }

        protected void ShowEstimatedRf()
        {
            DataSet ds = _clsDao.getDataset("Exec [Proc_MonthlyPaySlip] @flag='sr', @year=" + filterstring(GetYear()) + ",@month=" + filterstring(GetMonth()) + ",@EmpID=" + filterstring(GetEmp()) + "");
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = ds.Tables[0];

            str.Append("<tr>");
            str.Append(" <td class=\"RedText\" >Description </td>"
                       + " <td class=\"RedText\" align=\"right\" w>Amount</td>"
                       + " <td colspan=\"3\">&nbsp;</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"5\" ><hr color=\"#009900\" size=\"1\" /></td>");
            str.Append("</tr>");

            int cols = dt.Columns.Count;
            int totalRows = dt.Rows.Count;
            int rowIndex = 0;

            foreach (DataRow dr in dt.Rows)
            {
                rowIndex = rowIndex + 1;
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (rowIndex == totalRows)
                    {
                        str.Append("<td class=\"greentext\">" + dr[i].ToString() + "</td>");
                        str.Append("<td class=\"greentext\"  align=\"right\">" + ShowDecimal(dr[i + 1].ToString()) + "</td>");
                        break;
                    }
                    if(i==0)
                        str.Append("<td class=\"bluetext\" nowrap> " + dr[i].ToString() + "</td>");
                    else
                        str.Append("<td align=\"right\" >" + ShowDecimal(dr[i].ToString()) + "</td>");

                        
                }
                str.Append("</tr>");
              
            }

            str.Append("</table>");
            str.Append("</div>");
            EstimatedRf.InnerHtml = str.ToString();
        }

        protected void ShowAppRating()
        {
            DataSet ds = _clsDao.getDataset("Exec [Proc_MonthlyPaySlip] @flag='ar', @year=" + filterstring(GetYear()) + ",@month=" + filterstring(GetMonth()) + ",@EmpID=" + filterstring(GetEmp()) + "");
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = ds.Tables[0];

            str.Append("<tr>");
            str.Append("<td class=\"RedText\">Appraisal Rating</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Grade Year</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Effective Date</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Applied Date</td>");
            str.Append("<td class=\"RedText\" align=\"right\">Increment in Salary</td>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=\"5\" ><hr color=\"#009900\" size=\"1\" /></td>");
            str.Append("</tr>");

            int cols = dt.Columns.Count;

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"bluetext\"  nowrap> " + dr[i].ToString() + "</td>");
                    }
                    else if (i==4)
                    {
                        str.Append("<td align=\"right\" >" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"right\"  nowrap> " + dr[i].ToString() + "</td>");
                    }
                        
                }
                str.Append("</tr>");
            }

            str.Append("</table>");
            str.Append("</div>");
            AppRating.InnerHtml = str.ToString();
        }
    }
}