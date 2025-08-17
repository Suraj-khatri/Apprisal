using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.Report.SupervisorReport
{
    public partial class ViewAppraisalIndvRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        AppraisalReportDao _arDao = new AppraisalReportDao();
        public ViewAppraisalIndvRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
            }
        }
        private void loadReport()
        {
            string from_date = Request.QueryString["fromDate"] == null ? "" : Request.QueryString["fromDate"].ToString();
            string to_date = Request.QueryString["toDate"] == null ? "" : Request.QueryString["toDate"].ToString();
            string empId = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
            
            
           
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            lblFromDate.Text = from_date;
            lblToDate.Text = to_date;



            DataTable dt = _clsDao.getTable("Exec [procAppraisalIndvReport] @flag='s',@fromDate=" + filterstring(from_date) + ",@toDate=" + filterstring(to_date) + ",@SUPId=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMP_ID=" + filterstring(empId) + "");
            str.Append("<tr>");		
  
            int cols = dt.Columns.Count;
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
           
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
               str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }

        
    }
}
