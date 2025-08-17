using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport.TaxReport
{
    public partial class TDSReportForBranchWise : BasePage
    {
        
        string currPage = "";
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO CLsDAo = null;

        public TDSReportForBranchWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            CLsDAo = new clsDAO();
         }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            currPage = getCurrPage(); 

        }
        private void loadReport()
        {
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            string departmentid = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
            string branchId = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            populateTdsreport();
            lblYear.Text = year;

            StringBuilder str = new StringBuilder("<table width=\"600\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;


            DataTable dt = CLsDAo.getTable("Exec [procTDSEmployeeWiseReport] @flag='i',@year=" + filterstring(year) + ",@month=" + filterstring(month) + ",@EmpID=" + filterstring(empid) + ""
            + ",@branch=" + filterstring(branchId) + ",@dept=" + filterstring(departmentid) + "");

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            double tot = 0.00;
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
                    if (i == 0 || i == 1 )
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else if (i > 1 )
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");

                    }
                    //str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                tot = tot + double.Parse(dr[2].ToString());
                str.Append("</tr>");
            }
            str.Append("<tr>" +
                "<td colspan='2' align=\"right\"><b>TOTAL:</b></td>" +
                "<td align=\"right\"><b>" + ShowDecimal(tot.ToString()) + "</b></td>" +
                "</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void populateTdsreport()
        {
            string branchId = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string departmentid = Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString();
          //  string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            if (branchId == "")
            {
                branchId = "0";

            }

            if (departmentid == "")
            {
                departmentid = "0";

            }

            //if (empid == "")
            //{
            //    empid = "0";

            //}

            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("select dbo.[GetBranchName](" + branchId + ") as branch,dbo.GetDeptName(" + departmentid + ")as dept ").Tables[0];





            foreach (DataRow dr in dt.Rows)
            {
                lblBranchName.Text = dr["branch"].ToString();
                lbldeptName.Text = dr["dept"].ToString();
               // lblEmpName.Text = dr["Emp"].ToString();

            }

            if (branchId == "0")
                lblBranchName.Text = "ALL";


            if (departmentid == "0")
                lbldeptName.Text = "ALL";


            //if (empid == "0")
            //    lblEmpName.Text = "ALL";





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
