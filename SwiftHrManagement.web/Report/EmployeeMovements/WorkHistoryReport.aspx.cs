using System;
using System.Text;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using System.Data;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.EmployeeMovements
{
    public partial class WorkHistoryReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;


        BranchCore _branchCore = null;
        BranchDao _branch = null;

        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        string currPage = "";

        clsDAO _clsDAO = null;
      

        EmployeePastWorkHistory _pastWorkHistory = null;
        public WorkHistoryReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();

            this._branch = new BranchDao();
            this._branchCore = new BranchCore();

            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();

            this._pastWorkHistory = new EmployeePastWorkHistory();

            _clsDAO = new clsDAO();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        public long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? int.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        private void loadReport()
        {
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = new DataTable();

            string sQl = "exec procWorkHistory '" + GetEmpId() + "'";


            dt = _clsDAO.getTable(sQl);
            

            int cols = dt.Columns.Count;
            str.Append("<tr>");
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
