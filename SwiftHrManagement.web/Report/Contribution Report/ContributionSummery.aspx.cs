using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
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
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Contribution_Report
{
    public partial class ContributionSummery : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        LoanAndadvence _ContributionReport = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        string currPage = "";

        DynamicRpt _rpt = null;
        clsDAO CLsDAo = null;
        public ContributionSummery()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();
            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
            this._ContributionReport = new LoanAndadvence();
            this.CLsDAo = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string Getflag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            if (Getflag == "")
            {
                currPage = getCurrPage();
                loadReport();
            
            }
            else
            {
                currPage = getCurrPage();
                loadReportDetails();
            }
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 72) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }


     
        private void loadReport()
        {
            Report_ContSummery.Visible = true;

            Populatedata();

            double amtEmp = 0.00;
            double amtEmplr = 0.00;
            double rtrfundEmp = 0.00;
            double rtrfundEmplr = 0.00;
          

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _ContributionReport.FindContributionSummeryReport(this.ReadSession().RptQuery).Tables[0];
            //DataTable dt = _ContributionReport.FindContributionDetailsReport(this.ReadSession().RptQuery).Tables[0];

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
                    if (i == 0 || i == 1|| i==5)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }

                    else if (i == 2 || i==3 || i==4)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                   
                   // str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                amtEmp = amtEmp + double.Parse(dr[2].ToString());            
                amtEmplr = amtEmplr + double.Parse(dr[3].ToString());
                rtrfundEmp = rtrfundEmp + double.Parse(dr[4].ToString());
                //rtrfundEmplr = rtrfundEmplr + double.Parse(dr[5].ToString());

                str.Append("</tr>");
            }

            str.Append("<tr>" +
               "<td colspan='2' class=\"text-right\"><b>TOTAL:</b></td>" +
               "<td class=\"text-right\"><b>" + ShowDecimal(amtEmp.ToString()) + "</b></td>" +
               "<td class=\"text-right\"><b>" + ShowDecimal(amtEmplr.ToString()) + "</b></td>" +
               "<td class=\"text-right\"><b>" + ShowDecimal(rtrfundEmp.ToString()) + "</b> </td>" +
               "<td class=\"text-right\">&nbsp;</td>" +
               "</tr>");
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void loadReportDetails()
        {
            Report_ContDetail.Visible = true;

            Populatedata();


            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            //DataTable dt = _ContributionReport.FindContributionSummeryReport(this.ReadSession().RptQuery).Tables[0];
            DataTable dt = _ContributionReport.FindContributionDetailsReport(this.ReadSession().RptQuery).Tables[0];

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



        private void Populatedata()
        {



            string fiscalyear = Request.QueryString["fiscalyear"] == null ? "" : Request.QueryString["fiscalyear"].ToString();
            string monthId = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            string branchid = Request.QueryString["branchid"] == null ? "" : Request.QueryString["branchid"].ToString();
            string detpid = Request.QueryString["deptId"] == null ? "" : Request.QueryString["deptId"].ToString();
            string empId = Request.QueryString["empId"] == null ? "" : Request.QueryString["empId"].ToString();
            LblFisclYear.Text = fiscalyear;


            if (fiscalyear == "")
            {
                fiscalyear = "0";

            }
            if (monthId == "")
            {
                monthId = "0";

            }

            if (branchid == "")
            {
                branchid = "0";

            }
            if (detpid == "")
            {
                detpid = "0";

            }
            if (empId == "")
            {
                empId = "0";

            }



            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("select dbo.[GetBranchName](" + branchid + ") as branch ,dbo.[FNAGetNepMonthName](" + monthId + ") as Month,dbo.GetDeptName("+detpid+") as dept,dbo.GetEmployeeFullNameOfId("+empId+") as emp").Tables[0];

            string Getflag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            if (Getflag == "")
            {
                LblFiscalyear.Text = fiscalyear;
                foreach (DataRow dr in dt.Rows)
                {
                   lblBranchName.Text = dr["branch"].ToString();
                   lblMonth.Text = dr["Month"].ToString();
                   lblDetpsumName.Text = dr["dept"].ToString();
                   lblEmpsumName.Text= dr["emp"].ToString();

                }
                if (fiscalyear == "0")
                    LblFiscalyear.Text = "ALL";

                if (monthId == "0")
                    lblMonth.Text = "ALL";


                if (branchid == "0")
                    lblBranchName.Text = "ALL";

                if (detpid == "0")
                    lblDetpsumName.Text = "ALL";

                if (empId == "0")
                    lblEmpsumName.Text = "ALL";
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LblBranchDetail.Text = dr["branch"].ToString();
                    LblMonthdetail.Text = dr["Month"].ToString();
                    lblDepartment.Text = dr["dept"].ToString();
                    lblEmployee.Text = dr["emp"].ToString();

                }

                if (fiscalyear == "0")
                    LblFiscalyear.Text = "ALL";

                if (monthId == "0")
                    LblMonthdetail.Text = "ALL";


                if (branchid == "0")
                    LblBranchDetail.Text = "ALL";

                if (detpid == "0")
                    lblDepartment.Text = "ALL";

                if (empId == "0")
                    lblEmployee.Text = "ALL";

            }

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
