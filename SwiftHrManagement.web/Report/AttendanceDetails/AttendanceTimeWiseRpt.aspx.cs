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
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.RptDao;


namespace SwiftHrManagement.web.Report.AttendanceDetails
{
    public partial class AttendanceTimeWiseRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        AttendanceReports _attendance = null;
        public AttendanceTimeWiseRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._attendance = new AttendanceReports();
        }
        protected void Page_Load(object sender, EventArgs e)
        {       
            loadReport();            
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {           
            StaticPage sPage = new StaticPage();
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string rptNature = Request.QueryString["rptNature"] == null ? "" : Request.QueryString["rptNature"].ToString();           
           
            lblToDate.ForeColor = System.Drawing.Color.Black;
            lblFromDate.ForeColor = System.Drawing.Color.Black;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            
            lblrptNature.Text = rptNature;            
            lblFromDate.Text = from;
            lblToDate.Text = to;

            DataTable dt = _attendance.DateWiseSearch(this.ReadSession().RptQuery).Tables[0];

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