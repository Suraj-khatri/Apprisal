using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.Leave.IdividualHistory
{
    public partial class ManageReport : BasePage
    {
         CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public ManageReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            populatetitle();
        }
        private void populatetitle()
        {

            string fromDate = Request.QueryString["fromDate"] == null ? "" : Request.QueryString["fromDate"].ToString();
            string toDate = Request.QueryString["toDate"] == null ? "" : Request.QueryString["toDate"].ToString();
            

            if (fromDate == "")
            {
                fromDate = "0";

            }

            if (toDate == "")
            {
                toDate = "0";

            }

           if (fromDate == "0")
                DateFrom.Text = "ALL";

           if (toDate == "0")
                DateTo.Text = "ALL";

        }

        private void loadReport()
        {

            string fromdate = Request.QueryString["fromDate"] == null ? "" : Request.QueryString["fromDate"].ToString();
            string todate = Request.QueryString["toDate"] == null ? "" : Request.QueryString["toDate"].ToString();
            string bsdate = Request.QueryString["bsDate"] == null ? "" : Request.QueryString["bsDate"].ToString();
           
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.Lblcompany.Text = _CompanyCore.Name;
            this.LblDesc.Text = _CompanyCore.Address;
            LblBsDate.Text = bsdate;
            DateFrom.Text = fromdate;
            DateTo.Text = todate;
            DataTable dt = new DataTable();

            dt = _clsDao.getDataset("Exec [proc_IndividualLeaveHistoryReport] " + filterstring(ReadSession().Emp_Id.ToString()) + "," + filterstring(bsdate) + "," + filterstring(fromdate) + "," + filterstring(todate)).Tables[0];
         


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
                    if (i==12)
                    {
                        str.Append("<td align=\"left\"><textarea style=\" font-family: Arial,Helvetica,sans-serif;font-size: 12px; border: 0; overflow: auto; width:20em; height:4em;\"> " + dr[i].ToString() + "</textarea></td>");
                    }
                  
                    else
                        str.Append("<td align=\"left\" >" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
