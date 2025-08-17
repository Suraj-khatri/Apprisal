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
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.One_Third_Contribution_Projection_Report
{
    public partial class ContributionProjectionReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        LoanAndadvence _ContributionProjection = null;
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        public ContributionProjectionReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsDao = new clsDAO();
            this._ContributionProjection = new LoanAndadvence();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
                
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 71) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }

        }
        private void loadReport()
        {
            populateloandata();

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.Lblcompany.Text = _CompanyCore.Name;
            this.LblDesc.Text = _CompanyCore.Address;

            DataTable dt = _ContributionProjection.FindContributionProjectionReport(this.ReadSession().RptQuery).Tables[0];
           

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



            string fiscalyear = Request.QueryString["fiscalyear"] == null ? "" : Request.QueryString["fiscalyear"].ToString();
            string monthId = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
            string branchid = Request.QueryString["branchid"] == null ? "" : Request.QueryString["branchid"].ToString();
            string DeptId = Request.QueryString["DeptId"] == null ? "" : Request.QueryString["DeptId"].ToString();
            string EmpId = Request.QueryString["EmpId"] == null ? "" : Request.QueryString["EmpId"].ToString();
            LblFiscalyear.Text = fiscalyear;


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
            if (DeptId == "")
            {
                DeptId = "0";

            }
            if (EmpId == "")
            {
                EmpId = "0";

            }


           

            DataTable dt = new DataTable();

            dt = _clsDao.getDataset("select dbo.[GetBranchName](" + branchid + ") as branch , dbo.GetDeptName("+DeptId+") as dept,dbo.GetEmployeeFullNameOfId("+EmpId+") as Emp,dbo.[FNAGetNepMonthName](" + monthId + ") as Month").Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                LblBranch.Text = dr["branch"].ToString();
                lblMonth.Text = dr["Month"].ToString();
                LblDeptName.Text = dr["dept"].ToString();
                LblEmpName.Text = dr["Emp"].ToString();
              

            }

            if (fiscalyear == "0")
                LblFiscalyear.Text= "ALL";

            if (monthId == "0")
               lblMonth.Text = "ALL";


            if (branchid == "0")
               LblBranch.Text = "ALL";

            if (DeptId == "0")
               LblDeptName.Text = "ALL";

            if (EmpId == "0")
                LblEmpName.Text = "ALL";


           

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
