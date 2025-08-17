using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.OnTheJobTraining.JobSetting
{
    public partial class ManageAssignJob : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageAssignJob()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setDDl();
                displayAssignJob();

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 61) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        private void setDDl()
        {
            _clsDao.setDDL(ref DdlJobType, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where TYPE_ID=58", "ROWID", "DETAIL_TITLE", "", "Select");
        
        }
        private long GetJobGroupId()
        {
            return (Request.QueryString["Job_Group_Id"]!= null ? long.Parse(Request.QueryString["Job_Group_Id"]):0);
         }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            AddOperation();
        }

        private void AddOperation()
        {
            string msg  =  _clsDao.GetSingleresult("Exec [procJobGroup] @Flag='j',@JOB_STATIC_TYPE=" + filterstring(DdlJobType.Text) + ",@JOB_GROUP_ID="+ filterstring(GetJobGroupId().ToString())+"");
            lblmsg.Text = msg;
            lblmsg.ForeColor = System.Drawing.Color.Red;
            displayAssignJob();
        }


        private void displayAssignJob()
        {
            string brainch_id = ReadSession().Branch_Id.ToString();
            DataTable dt = new DataTable();

            dt = _clsDao.getDataset("exec [procJobGroup] @Flag='G',@JOB_GROUP_ID=" + GetJobGroupId() + "").Tables[0];

            if (dt.Rows.Count == 0)
            {
                rptResult.InnerHtml = "<center><b> No Job is assigned.</b><center>";
                return;
            }
            var str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
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
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptResult.InnerHtml = str.ToString();
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec [procJobGroup] @Flag='m' , @JOB_ID = "+job_Id.Value+"");
            displayAssignJob();
        }
    }
}
