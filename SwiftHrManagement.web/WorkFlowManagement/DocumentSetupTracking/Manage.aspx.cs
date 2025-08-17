using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;

namespace SwiftHrManagement.web.WorkFlowManagement.DocumentSetupTracking
{
    public partial class Manage : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            displayList();
            lblCategoryName.Text = _clsdao.GetSingleresult("SELECT WF_CatName FROM WF_Category WHERE WF_CategoryID=" + GetCatID()+ "");
        }

        private int GetCatID()
        {
            return (Request.QueryString["WFCat_Id"] != null ? int.Parse(Request.QueryString["WFCat_Id"]) : 0);
        }

        private void displayList()
        {
            string user = ",@user='" + ReadSession().AdminId.ToString() + "'";
            DataTable dt = _clsdao.getTable("Exec proc_SetloanDocs @flag='V',@JobTypeID='" + GetCatID() + "'" + user);
            int rowcount = dt.Rows.Count;
            StringBuilder display = new StringBuilder("<table class=\"TBL\" cellpadding=\"10\" cellspacing=\"10\">");
            display.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                display.Append("<th nowrap=\"nowrap\">" + dc.ToString() + "</th>");
            }
            display.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                display.Append("<tr>");

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    display.Append("<td nowrap=\"nowrap\">" + dr[j].ToString() + "</td>");
                }

                display.Append("</tr>");
            }
            display.Append("</table>");

            displayArea.InnerHtml = display.ToString();

        }
    }
}
