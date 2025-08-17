using System;
using System.Collections;
using System.Configuration;
using System.Data;
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

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveStatusReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public LeaveStatusReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            populatetitle();
        }
        private void populatetitle()
        {
           
            string branchid = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string departmentid = Request.QueryString["departmentId"] == null ? "" : Request.QueryString["departmentId"].ToString();
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();

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

            dt = _clsDao.getDataset("select dbo.[GetBranchName](" + branchid + ") as branch, "
                + " dbo.GetEmployeeFullNameOfId(" + empid + ")as Emp,dbo.GetDeptName(" + departmentid + ")as dept ").Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                lblbranch.Text = dr["branch"].ToString();
                lbldepartmant.Text = dr["dept"].ToString();
                lblEmployeeName.Text = dr["Emp"].ToString();

            }

            if (branchid == "0")
                lblbranch.Text = "ALL";


            if (empid == "0")
                lblEmployeeName.Text = "ALL";


            if (departmentid == "0")
                lbldepartmant.Text = "ALL";

           
        }

        private void loadReport()
        {
            string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            string branchid = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string departmentid = Request.QueryString["deptId"] == null ? "" : Request.QueryString["deptId"].ToString();
            string empid = Request.QueryString["EmpId"] == null ? "" : Request.QueryString["EmpId"].ToString();
            string bsdate = Request.QueryString["bsdate"] == null ? "" : Request.QueryString["bsdate"].ToString();

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            this.Lblcompany.Text = _CompanyCore.Name;
            this.LblDesc.Text = _CompanyCore.Address;
            DataTable dt = new DataTable();
            if (flag == "l")
            {
                dt = _clsDao.getDataset("Exec [proc_LeaveStatus] 'l'," + filterstring(branchid) + "," + filterstring(departmentid) + "," + filterstring(empid)+","+filterstring(bsdate)).Tables[0];
                LblBsDate.Text = bsdate;
            }
            else
            {
                 dt = _clsDao.getDataset("Exec [proc_LeaveStatus] 'c'," + filterstring(branchid) + "," + filterstring(departmentid) + "," + filterstring(empid)).Tables[0];
                 LblBsDate.Visible = false;
            }


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
                    str.Append("<td align=\"left\" >" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
