using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.EventCalander;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.EventCalander
{
    public partial class Events : BasePage
    {
        EventCalanderDAO _eventCal = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public Events()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _eventCal = new EventCalanderDAO();
        }
        private string GetDate()
        {
            return (Request.QueryString["ondate"] == null ? "" : Request.QueryString["ondate"].ToString());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            showevent();
        }
        private void showevent()
        {
            this.ondate.Text = (GetDate().Replace("'",""));
           
            _CompanyCore = _company.FindCompany();

            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            String sSql = "EXEC [procManageHolidayCalender] @FLAG='C',@DATE='" + GetDate() + "'";

            StringBuilder sb = new StringBuilder("<div class=\"table-responsive\" style=\"width:60%\" align=\"center\" > <table style=\"width:100%\" class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = _eventCal.GetEvents(sSql).Tables[0];
            int cols = dt.Columns.Count;
            
            sb.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                sb.Append("<th class='THHeadBG' align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    sb.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table></div>");
            divEvents.InnerHtml = sb.ToString();
        }
    }
}
