using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveReportYearWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public LeaveReportYearWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
                string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
                string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();

                _CompanyCore = _company.FindCompany();
                this.lblHeading.Text = _CompanyCore.Name;
                this.lbldesc.Text = _CompanyCore.Address;
                lblYear.Text=year;

                if (flag == "L")
                    SummaryRpt(year,emp_id);
                else
                    detailedRpt(year, emp_id);
            }
        }
        private void SummaryRpt(string year,string emp_id)
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _clsDao.getTable("EXEC [procLeaveHistoryReport] @FLAG='L',@YEAR=" + filterstring(year) + ",@EMP_ID=" + filterstring(emp_id) + "");

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
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }

        private void detailedRpt(string year, string emp_id)
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _clsDao.getTable("EXEC [procLeaveHistoryReport] @FLAG='LD',@YEAR=" + filterstring(year) + ",@EMP_ID=" + filterstring(emp_id) + "");

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
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }
     }
}

