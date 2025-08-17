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

namespace SwiftHrManagement.web.Include
{
    public partial class ManageJobDoc : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            prepareList();
        }
        private int GetJobID()
        {
            return (Request.QueryString["JobID"] != null ? int.Parse(Request.QueryString["JobID"]) : 0);
        }
        private string getStrQry()
        {
            string user = ",@user='" + ReadSession().AdminId.ToString() + "'";
            return (Request.QueryString["StrQry"] != null ? Request.QueryString["StrQry"].ToString() + user : "Exec ProcDocumentSetup @flag='V',@JobTypeID='" + GetJobID() + "'" + user);

        }

        private void prepareList()
        {
            _clsdao.runSQL(getStrQry());
            //string id = GetJobID().ToString();
            long Flag = 1;
            Response.Redirect("/WorkFlowManagement/WorkFlowJob/ManageDocSetup.aspx?JOB_ID=" + GetJobID() + "&Flag="+Flag+"");

        }
    }
}
