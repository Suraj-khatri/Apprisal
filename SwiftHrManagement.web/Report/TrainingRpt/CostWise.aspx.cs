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
    public partial class CostWise : BasePage
    {
        clsDAO _clsdao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public CostWise()
        {
            _clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string startDate = Request.QueryString["startDate"] == "" ? "null" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == "" ? "null" : Request.QueryString["endDate"].ToString();
            string costFrom = Request.QueryString["costFrom"] == "" ? "null" : Request.QueryString["costFrom"].ToString();
            string costTo = Request.QueryString["costTo"] == "" ? "null" : Request.QueryString["costTo"].ToString();

            var sql = "EXEC [ProcRptTraining] @flag='d',@startDate=" + filterstring(startDate) + ",@endDate=" +
                    filterstring(endDate) + ",@costFrom=" + filterstring(costFrom) + ",@costTo=" + filterstring(costTo) + "";

            DataTable dt = _clsdao.getTable(sql);
          
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.RptHead.Text = _CompanyCore.Name;
            this.RptSubHead.Text = _CompanyCore.Address;
            this.RptDesc.Text = "Training Cost Wise Report";
            lblFromDate.Text = startDate;
            lblToDate.Text = endDate;

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
                    if (i==0||i==5||i==6||i==7)
                    {
                        str.Append("<td align=\"center\">" + row[i] + "</td>");
                    }
                    else if (i == 8 || i == 9 || i == 10 || i == 11 || i==12)
                    {
                        str.Append("<td align=\"right\">" + row[i] + "</td>");
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