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
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder
{
    public partial class GenerateReport : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public GenerateReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                loadReport();
            }
        }
        private void loadReport()
        {
            string from = Request.QueryString["fromDate"] == null ? "" : Request.QueryString["fromDate"].ToString();
            string to = Request.QueryString["toDate"] == null ? "" : Request.QueryString["toDate"].ToString();
            string branch = Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString();
            string status = Request.QueryString["status"] == null ? "" : Request.QueryString["status"].ToString();

            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            lblFrom.Text = from;
            lblTo.Text = to;

            DataTable dt = _clsDao.getTable("Exec [proc_travelOrderReport] @flag='s',@branch=" + filterstring(branch) + ",@status=" + filterstring(status) + ",@fromDate=" + filterstring(from)+ ",@toDate=" + filterstring(to));

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\" colspan=\"2\" id = \"hiddenTd\">View Details</th>");
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td align=\"left\" id = \"hiddenTd\"><a href=\"/EmployeeMovement/TravelOrder/Detailreport.aspx?flag=rd&OId=" + dr[0].ToString() + "\">Request Detail</a></td>");
                str.Append("<td align=\"left\" id = \"hiddenTd\"><a href=\"/EmployeeMovement/TravelOrder/Detailreport.aspx?flag=sd&OId=" + dr[0].ToString() + "\">Settlement Detail</a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
