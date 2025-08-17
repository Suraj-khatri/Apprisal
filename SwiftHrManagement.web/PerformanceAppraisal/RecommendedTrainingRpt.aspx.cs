using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.PerformanceAppraisal
{
    public partial class RecommendedTrainingRpt : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        RoleMenuDAOInv _roleMenuDao = null;
        AppraisalReportDao _arDao = new AppraisalReportDao();

        public RecommendedTrainingRpt()
        {
            _clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._roleMenuDao = new RoleMenuDAOInv();

        }
        protected int GetEmployeeId()
        {
            return (Request.QueryString["EmpId"] != null ? int.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 101) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                loadReport();
            }

        }

        private void loadReport()
        {
            string branch_id = Request.QueryString["branch_id"] == null ? "" : Request.QueryString["branch_id"].ToString();
            string from_date = Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
            string to_date = Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();
            string department_id = Request.QueryString["department_id"] == null ? "" : Request.QueryString["department_id"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
            lblFromDate.Text = from_date;
            lblToDate.Text = to_date;

            DataTable dt = new DataTable();
            dt = _arDao.GetTrainingReport(branch_id, department_id, emp_id, from_date, to_date);

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.RptHead.Text = _CompanyCore.Name;
            this.RptSubHead.Text = _CompanyCore.Address;
            this.RptDesc.Text = "Training Participant Summary Report";
           

            int cols = dt.Columns.Count;

            StringBuilder stringBuilder = str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");

            double[] sum = new double[cols];

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 9)
                    {
                        str.Append("<td align=\"right\">" + row[i] + "</td>");
                    }
                    else if (i == 10 || i == 11 || i == 12 || i == 13 || i == 14 || i == 18)
                    {
                        str.Append("<td align=\"center\">" + row[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i] + "</td>");
                    }
                }
                str.Append("</tr>");
            }

            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}