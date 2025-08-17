using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;

namespace SwiftHrManagement.web.Report
{
    public partial class DynamicDeptRpt : System.Web.UI.Page
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;

        BranchCore _branchCore = null;
        BranchDao _branch = null;

        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;

        string currPage = "";
        String Flag = "";
        String Branch_Id = "";
        String Dept_Id = "";
        String Emp_Id = null;
        DynamicRpt _rpt = null;
        public DynamicDeptRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();

            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();

            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            currPage = getCurrPage();
            if (Request.QueryString["BranchName"] != null)
            {
                lblBranchName.Text = (Request.QueryString["BranchName"]);
            }

            if (Request.QueryString["branchid"] != null)
            {
                Branch_Id = (Request.QueryString["branchid"]);
            }

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-8 col-md-offset-2\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt1 = _rpt.FindsummaryReport("d", Branch_Id, Dept_Id, Emp_Id).Tables[0];
            int cols = dt1.Columns.Count;

            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt1.Columns[i].ColumnName + "</th>");
            }

            str.Append("</tr>");

            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 3)
                        {
                        if(Branch_Id =="")
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        else
                            str.Append("<td align=\"left\"><a href=\"DynamicEmpRpt.aspx?dept= " + dr[1] + "&Department=" + dr[2] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                        }
                        else if (i == 4)
                        {
                            str.Append("<td align=\"left\"><a href=\"DynamicEmpRpt.aspx?dept= " + dr[1] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                        }

                        else
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }

                    
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
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
