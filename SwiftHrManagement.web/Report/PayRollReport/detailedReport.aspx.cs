using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Payrole;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class detailedReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        payroleDAO _payroll = null;
        Employee _empcore = null;
        EmployeeDAO _empdao = null;
        clsDAO _clsDao = null;
        public detailedReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._payroll = new payroleDAO();
            this._empcore = new Employee();
            this._empdao = new EmployeeDAO();
            _clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
            }
        }
        private string returnmonthname(int month)
        {
            string monthname = "";
            monthname = _clsDao.GetSingleresult("select Name from MonthList where Month_Number=" + month + "");
            return monthname;
        }
        private void loadReport()
        {
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            string id = Request.QueryString["Id"] == null ? "" : Request.QueryString["Id"].ToString();
            string empname = Request.QueryString["Empname"] == null ? "" : Request.QueryString["Empname"].ToString();
            string month="";
            string year = "";

            _CompanyCore = _company.FindCompany();
            _empcore = _empdao.FindEmpCodeById(long.Parse(empid));
            this.Lblcompany.Text = _CompanyCore.Name;
            this.LblDesc.Text = _CompanyCore.Address;

            DataTable dt1 = new DataTable();
            dt1 = _clsDao.getDataset("select FY_ID,Run_Month from TaxCalculation where id="+id+"").Tables[0];
            foreach (DataRow dr1 in dt1.Rows)
            {
                Lblyear.Text = dr1["FY_ID"].ToString();
                LblMonth.Text = returnmonthname(int.Parse(dr1["Run_Month"].ToString()));
                month = dr1["Run_Month"].ToString();
                year = dr1["FY_ID"].ToString();
            }
            LblEmpName.Text = empname;
            LblEmpId.Text = _empcore.EmpCode;
            
            DataSet ds = _payroll.Executepayroll("exec [proc_PayRollReportMonthly] '" + year + "','" + month + "','" + empid + "'");


            //DataSet ds = AppraisalList(this.appId);
     
            DataTable dt = ds.Tables[0];
            DataTable dt2 = ds.Tables[1];

            StringBuilder str = new StringBuilder("");
            int cols = dt.Columns.Count;
            double Benifit = 0;
            double Deduction = 0;

            str.Append("<table width=\"400\"  cellpadding=\"3\" cellspacing=\"0\" align=\"center\" >");
            str.Append("<tr bgcolor='#CCCCCC'><td align=\"left\" class=\"border\" ><b>Benefit</td><td class=\"border\" align=\"right\"><b> Amount</td></tr>");

            foreach (DataRow dr in dt.Rows)
            {
               
                str.Append("<tr>");
                str.Append("<td class=\"border\" align=\"left\"  >" + dr[0].ToString() + "</td><td class=\"border\"  align=\"right\"> " + dr[1].ToString() + "</td>");
                str.Append("</tr>");

                Benifit = Benifit + double.Parse(dr[1].ToString());
              
            }
            str.Append("<tr><td align=\"left\" class=\"border\"><b>Total Benefit</td><td class=\"border\" align=\"right\"><b> " + Benifit.ToString("0.00") + "</td></tr>");
            str.Append("<tr><td align=\"left\" ></td><td align=\"right\"> </td></tr>");
            str.Append("<tr bgcolor='#CCCCCC'><td align=\"left\" class=\"border\" ><b>Deduction</td><td align=\"right\" class=\"border\"><b> Amount</td></tr>");

            foreach (DataRow dr in dt2.Rows)
            {

                str.Append("<tr>");
                str.Append("<td class=\"border\" align=\"left\"  >" + dr[0].ToString() + "</td><td class=\"border\"  align=\"right\"> " + dr[1].ToString() + "</td>");
                str.Append("</tr>");

                Deduction = Deduction + double.Parse(dr[1].ToString());

            }
            str.Append("<tr ><td align=\"left\" class=\"border\"><b>Total Deduction</td><td class=\"border\" align=\"right\"><b> " + Deduction.ToString("0.00") + "</td></tr>");
            str.Append("<tr ><td align=\"left\" class=\"border\"><b>Net Payable</td><td class=\"border\" align=\"right\"><b> " + (Benifit - Deduction).ToString("0.00") + "</td></tr>");


            str.Append("</table>");
            rptSalary.InnerHtml = str.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
    }
}
