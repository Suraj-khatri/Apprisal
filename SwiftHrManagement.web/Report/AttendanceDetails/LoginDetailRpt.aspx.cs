using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.Report.AttendanceDetails
{
    public partial class LoginDetailRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _cls = null;
        public LoginDetailRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._cls = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            string empId = Request.QueryString["id"] == null ? "" : Request.QueryString["id"].ToString();
            string date = Request.QueryString["date"] == null ? "" : Request.QueryString["date"].ToString();
            forDate.Text = date;


            DataSet ds = _cls.getDataset("EXEC Proc_IndividualMonthlyAttRpt @flag='a',@date='" + date + "',@emp=" + empId);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            branchName.Text = dt1.Rows[0]["Branch"].ToString() + ","+dt1.Rows[0]["Department"].ToString();
            empName.Text = dt1.Rows[0]["Name"].ToString();

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            str.Append("<tr>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<th align=\"center\" >S.N.</th>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                count++;
                str.Append("<tr>");
                str.Append("<td  align=\"left\" >" + count + "</td>");


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