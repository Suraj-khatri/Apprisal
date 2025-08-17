using System;
using SwiftHrManagement.Core.Domain;
using System.Text;
using SwiftHrManagement.DAL.CompInfo;
using System.Data;

namespace SwiftHrManagement.web.Report.Leave.LFAReport
{
    public partial class LFARpt : BasePage
    {
        CompanyCore _companyCore = new CompanyCore();
        CompanyDAO _company = new CompanyDAO();
        clsDAO _clsDao = new clsDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            string _fromDate = Request.QueryString["fromDate"];
            string _toDate = Request.QueryString["toDate"];
            string branchId = Request.QueryString["branchId"];

            var sql = "Exec proc_LFARpt @flag='s'";
            sql += ",@fromDate  =" + filterstring(_fromDate);
            sql += ",@toDate    =" + filterstring(_toDate);
            sql += ",@branchId  =" + filterstring(branchId);

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-8 col-md-offset-2\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _companyCore = _company.FindCompany();
            lblHeading.Text = _companyCore.Name;
            lbldesc.Text = _companyCore.Address;
            fromDate.Text = _fromDate;
            toDate.Text = _toDate;
            DataTable dt = _clsDao.getTable(sql);

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
                    str.Append("<td align=\"left\">" + dr[i] + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}