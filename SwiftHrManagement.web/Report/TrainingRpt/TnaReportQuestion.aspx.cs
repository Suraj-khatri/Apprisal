using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;


namespace SwiftHrManagement.web.Report.TrainingRpt
{
    public partial class TnaReportQuestion : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public TnaReportQuestion()
        {
            this._clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string startDate = Request.QueryString["startDate"] == "" ? "null" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == "" ? "null" : Request.QueryString["endDate"].ToString();
            string emp = Request.QueryString["emp"] == "" ? "null" : Request.QueryString["emp"].ToString();
            string position = Request.QueryString["position"] == "" ? "null" : Request.QueryString["position"].ToString();
            string funTitle = Request.QueryString["funTitle"] == "" ? "null" : Request.QueryString["funTitle"].ToString();
            string question = Request.QueryString["question"] == "" ? "null" : Request.QueryString["question"].ToString();
            string questionId = Request.QueryString["questionId"] == "" ? "null" : Request.QueryString["questionId"].ToString();

            var sql = "EXEC [procRptTNAQuestion] @startDate=" + filterstring(startDate) + ",@endDate=" +
                    filterstring(endDate) + ",@question=" + filterstring(questionId) + ","
                    + " @emp=" + filterstring(emp) + ",@funTitle=" + filterstring(funTitle) + "";

            DataTable dt = _clsdao.getTable(sql);
          
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.RptHead.Text = _CompanyCore.Name;
            this.RptSubHead.Text = _CompanyCore.Address;
            this.RptDesc.Text = "Training Need Assessment (TNA) Summary Report";
            lblFromDate.Text = startDate;
            lblToDate.Text = endDate;
            lblQuestion.Text = question;

            int cols = dt.Columns.Count;

            StringBuilder stringBuilder = str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {                    
                    str.Append("<td align=\"left\">" + row[i] + "</td>");                    
                }
                str.Append("</tr>");
            }
              
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
            }
        }
    
}