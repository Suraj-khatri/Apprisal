using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport.empDetails
{
    public partial class List : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsdao = null;
        string sql = "";
        public List()
        {
            _company = new CompanyDAO();
            _CompanyCore = new CompanyCore();
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getEmployeeDetails();
            }

        }
        private string GetBranchID()
        {
            return (Request.QueryString["branchId"] != "" ?(Request.QueryString["branchId"].ToString()) : "");
        }
        private string GetDeptID()
        {
            return (Request.QueryString["deptId"] != "" ? (Request.QueryString["deptId"].ToString()) : "");
        }
        private string GetEmpID()
        {
            return (Request.QueryString["empId"] != "" ? (Request.QueryString["empId"].ToString()) : "");
        }
        private void getEmployeeDetails()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" align=\"center\">");
            
            _CompanyCore = _company.FindCompany();
            this.divCompany.InnerText = _CompanyCore.Name;
            lblprintDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            if (GetBranchID()!="")
            {
                lblBranchName.Text = _clsdao.GetSingleresult("select BRANCH_NAME FROM BRANCHES WHERE BRANCH_ID=" + GetBranchID() + "");
            }
            else
            {
                lblBranchName.Text = "All";
            }
            if (GetDeptID()!="")
            {
                lblDeptName.Text = _clsdao.GetSingleresult("SELECT DEPARTMENT_NAME FROM Departments WHERE DEPARTMENT_ID=" + GetDeptID() + "");
            }
            else
            {
                lblDeptName.Text = "All";
            }
            DataTable dt = _clsdao.getTable("Exec ProcGetEmpDetails 's', " + filterstring(GetBranchID().ToString()) + "," + filterstring(GetDeptID().ToString()) + "," + filterstring(GetEmpID().ToString()) + "");           

            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {                
                str.Append("<th class=\"text_center\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            str.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0)
                    {
                        str.Append("<td class=\"text_center\">" + row[i].ToString() + "</td>");  
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");  
                    }                                    
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}
