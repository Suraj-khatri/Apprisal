using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;


namespace SwiftHrManagement.web.Report.ExternalTrainingReport
{
    public partial class ExternalTrainingSummaryReport : BasePage
    {
           clsDAO _clsdao = null;
           RoleMenuDAOInv _roleMenuDao = null;
      public ExternalTrainingSummaryReport()
        {
         _clsdao = new clsDAO();
         this._roleMenuDao = new RoleMenuDAOInv();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 46) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        private void loadReport()
        {

            string From = Request.QueryString["From"] == null ? "" : Request.QueryString["From"].ToString();
            string To = Request.QueryString["To"] == null ? "" : Request.QueryString["To"].ToString();
            string month = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");

            StringBuilder str = new StringBuilder("<table width=\"700\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");
            DataTable dt = _clsdao.getDataset("exec [procExternalTrainingSummaryReport] 's'," + filterstring(From) + "," + filterstring(To) + "").Tables[0];
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
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
