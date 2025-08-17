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


namespace SwiftHrManagement.web.OverTime.SuperVisorAppoveOT
{
    public partial class ViewAttandance : BasePage
    {
          clsDAO _clsdao = null;
          CompanyDAO _company = null;
          CompanyCore _CompanyCore = null;
       
        public ViewAttandance()
        {
            this._clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string from = Request.QueryString["req_Date"] == null ? "" : Request.QueryString["req_Date"].ToString();
            string Req_Id = Request.QueryString["Req_Id"] == null ? "" : Request.QueryString["Req_Id"].ToString();

             lblReportDate.Text = from;
      
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");
            DataTable dt = _clsdao.getTable("EXEC procViewAttendanceForOverTime 'a'," + filterstring(from) + "," + filterstring(Req_Id) + "");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            //StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
          
         

            str.Append("<tr>");
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
    }
}
