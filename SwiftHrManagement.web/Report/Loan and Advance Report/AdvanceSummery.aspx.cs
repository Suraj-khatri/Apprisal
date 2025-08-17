using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.RptDao;


namespace SwiftHrManagement.web.Report.Loan_and_Advance_Report
{
    public partial class AdvanceSummery : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        LoanAndadvence _LoanAdvanceSummary = null;
        string currPage = "";
   
        DynamicRpt _rpt = null;
        clsDAO CLsDAo = null;
        public AdvanceSummery()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();
            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
            this._LoanAdvanceSummary = new LoanAndadvence();
            this.CLsDAo = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            currPage = getCurrPage();
            loadReport();  

        }
        private void loadReport()
        {
            string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            if (flag == "")
            {


                Advance_Summery.Visible = true;
            }
            else 
            
            {
             
                Advance_details.Visible = true;
              
            }
       
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            this.From_Date.Text = from;
            this.To_Date.Text = to;
            populateloandata();


            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-responsive table-bordered table-striped table-condensed text-center\" >");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _LoanAdvanceSummary.FindLoansummaryReport(this.ReadSession().RptQuery).Tables[0];

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
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void populateloandata()
        {



            string branchid = Request.QueryString["branchid"] == null ? "" : Request.QueryString["branchid"].ToString();
            string departmentid = Request.QueryString["deptId"] == null ? "" : Request.QueryString["deptId"].ToString();
            string empid = Request.QueryString["empId"] == null ? "" : Request.QueryString["empId"].ToString();
            string advancetype = Request.QueryString["advancetype"] == null ? "" : Request.QueryString["advancetype"].ToString();

            if (advancetype == "")
            {
                advancetype = "0";

            }
            if (branchid == "")
            {
                branchid = "0";

            }

            if (departmentid == "")
            {
                departmentid = "0";

            }

            if (empid == "")
            {
                empid = "0";

            }

            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("select s.DETAIL_TITLE as [Advance Type],dbo.[GetBranchName](" + branchid + ") as branch, "
                + " dbo.GetEmployeeFullNameOfId(" + empid + ")as Emp,dbo.GetDeptName(" + departmentid + ")as dept from Advance a with(nolock) inner join StaticDataDetail s with(nolock) on s.ROWID=a.ADVANCE_TYPE where a.ADVANCE_TYPE="+advancetype+"").Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                lblbranchName.Text = dr["branch"].ToString();
                lbldeptName.Text = dr["dept"].ToString();
                lblEmpName.Text = dr["Emp"].ToString();
                LblAdvanceType.Text = dr["Advance Type"].ToString();
                LblAdvanceType1.Text = dr["Advance Type"].ToString();

            }

            if (advancetype == "0")
                LblAdvanceType.Text= "ALL";

            if (branchid == "0")
                lblbranchName.Text = "ALL";


            if (empid == "0")
                lbldeptName.Text = "ALL";


            if (departmentid == "0")
                lblEmpName.Text = "ALL";

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
