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
    public partial class DateWiseRpt : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public DateWiseRpt()
        {
            _clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            
        }
        private string GetCategory()
        {
            return (Request.QueryString["category"] != "" ? (Request.QueryString["category"].ToString()) : "");
        }
        private string GetStatus()
        {
            return (Request.QueryString["status"] != "" ? (Request.QueryString["status"].ToString()) : "");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string startDate = Request.QueryString["startDate"] == "" ? "null" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == "" ? "null" : Request.QueryString["endDate"].ToString();
            string ddlTrainingType = Request.QueryString["trainingType"] == "" ? "null" : Request.QueryString["trainingType"].ToString();


            var sql = "EXEC [ProcRptTraining] @FLAG='a',@startDate=" + filterstring(startDate) + ",@endDate=" +
                    filterstring(endDate) + ",@trainingType=" + filterstring(ddlTrainingType) + ",@category="+filterstring(GetCategory())+","
                    + " @status=" + filterstring(GetStatus()) + "";
            DataTable dt = _clsdao.getTable(sql);

            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.RptHead.Text = _CompanyCore.Name;
            this.RptSubHead.Text = _CompanyCore.Address;
            this.RptDesc.Text = "Training Summary Report";
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
              
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
            }
        }
    
}