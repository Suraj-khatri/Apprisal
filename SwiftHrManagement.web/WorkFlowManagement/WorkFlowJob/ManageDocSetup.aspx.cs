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

namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob
{
    public partial class ManageDocSetup : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            displayList();           
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (GetMasterFlag() ==1)
                this.Page.MasterPageFile = "~/ProjectMaster.Master";
            else
                this.Page.MasterPageFile = "~/SwiftHRManager.Master";
        }

        private long GetJobId()
        {
            return (Request.QueryString["JOB_ID"] != null ? long.Parse(Request.QueryString["JOB_ID"]) : 0);
        }
        private long GetMasterFlag()
        {
            return (Request.QueryString["Flag"] != null ? long.Parse(Request.QueryString["Flag"]) : 0);
        }
        private void displayList()
        {
            string CAT_ID = _clsdao.GetSingleresult("SELECT WF_CatID FROM WF_Job WHERE WF_JobID="+GetJobId()+"");

            DataTable dt = _clsdao.getTable("Exec ProcDocumentSetup @flag='V',@CatId='" + CAT_ID + "',"
                +" @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@JobId="+filterstring(GetJobId().ToString())+"");


            int rowcount = dt.Rows.Count;
            StringBuilder display = new StringBuilder("<table class=\"TBL\" cellpadding=\"10\" cellspacing=\"10\">");
            display.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {
                display.Append("<th nowrap=\"nowrap\"><div align=\"left\">" + dc.ToString() + "</div></th>");
            }
            display.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                display.Append("<tr>");

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    display.Append("<td nowrap=\"nowrap\"><div align=\"left\">" + dr[j].ToString() + "</div></td>");
                }

                display.Append("</tr>");
            }
            display.Append("</table>");

            displayArea.InnerHtml = display.ToString();

        }
    }
}
