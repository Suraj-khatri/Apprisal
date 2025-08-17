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


namespace SwiftHrManagement.web.Report.TrainingRpt
{
    public partial class DateWiseParticipantRpt : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public DateWiseParticipantRpt()
        {
            _clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            
        }
        private string employee()
        {
            return (Request.QueryString["employeeId"] != "" ? (Request.QueryString["employeeId"].ToString()) : "");
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string startDate = Request.QueryString["startDate"] == "" ? "null" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == "" ? "null" : Request.QueryString["endDate"].ToString();
            string branch_id = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string department_id = Request.QueryString["departmentId"] == null ? "" : Request.QueryString["departmentId"].ToString();
            string emp_id = Request.QueryString["employeeId"] == null ? "" : Request.QueryString["employeeId"].ToString();

            var sql = "EXEC [ProcRptTraining] @FLAG='p',@startDate=" + filterstring(startDate) + ",@endDate=" +
                    filterstring(endDate) + ",@branch_id=" + filterstring(branch_id) + ",@depart_id=" + filterstring(department_id) + ",@emp_id=" + filterstring(emp_id) + "";
            DataTable dt = _clsdao.getTable(sql);
          
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.RptHead.Text = _CompanyCore.Name;
            this.RptSubHead.Text = _CompanyCore.Address;
            this.RptDesc.Text = "Training Participant  Summary Report";
            lblFromDate.Text = startDate;
            lblToDate.Text = endDate;

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
                    if(i==9)
                    {
                        str.Append("<td align=\"right\">" + row[i] + "</td>");
                    }
                    else if (i==10||i==11||i==12||i==13||i==14||i==18)
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
              
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
            }
        }
    
}