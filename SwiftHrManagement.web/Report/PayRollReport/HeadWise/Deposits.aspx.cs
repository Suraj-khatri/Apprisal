using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport.HeadWise
{
    public partial class Deposits : BasePage
    {
        clsDAO _clsDao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;

        public Deposits()
        {
            _clsDao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
            string FY = Request.QueryString["FY"] == null ? "" : Request.QueryString["FY"].ToString();
            string branchId = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string deptId = Request.QueryString["deptId"] == null ? "" : Request.QueryString["deptId"].ToString();
            string rptType = Request.QueryString["rptType"] == null ? "" : Request.QueryString["rptType"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();



            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.LblMonth.Text = _clsDao.GetSingleresult("select Name from MonthList where Month_Number=" + filterstring(month));
            this.lblBranchName.Text = _clsDao.GetSingleresult("select BRANCH_NAME from Branches where BRANCH_ID=" + filterstring(branchId) + "");
            this.lblDeptName.Text = _clsDao.GetSingleresult("select DEPARTMENT_NAME from Departments where DEPARTMENT_ID=" + filterstring(deptId) + "");
            this.lblReport.Text = rptType;

            DataTable dt = null;
            if (rptType == "cit")
            {
                dt = _clsDao.getDataset("Exec [Proc_Deposits] @flag='c',@fiscalyear=" + filterstring(FY) + ",@barnchid=" + filterstring(branchId) + ",@deptId=" + filterstring(deptId) +", @month="+ filterstring(month)+"").Tables[0];
            }
            else if (rptType == "epf")
            {
                dt = _clsDao.getDataset("Exec [Proc_Deposits] @flag='e',@fiscalyear=" + filterstring(FY) + ",@barnchid=" + filterstring(branchId) + ",@deptId=" + filterstring(deptId) + ", @month=" + filterstring(month) + "").Tables[0];
            }
            else if (rptType == "tax")
            {
                dt = _clsDao.getDataset("Exec [Proc_Deposits] @flag='t',@fiscalyear=" + filterstring(FY) + ",@barnchid=" + filterstring(branchId) + ",@deptId=" + filterstring(deptId) + ", @month=" + filterstring(month) + "").Tables[0];
            }
            else if (rptType == "ins")
            {
                dt = _clsDao.getDataset("Exec [Proc_Deposits] @flag='i',@fiscalyear=" + filterstring(FY) + ",@barnchid=" + filterstring(branchId) + ",@deptId=" + filterstring(deptId) + ", @month=" + filterstring(month) + "").Tables[0];
            }

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th class=\"text-center\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i==4)
                    {
                        str.Append("<td class=\"text-right\">" + dr[i].ToString() + "</td>");
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

    }
}