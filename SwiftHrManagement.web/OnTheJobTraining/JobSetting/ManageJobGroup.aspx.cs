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
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.OnTheJobTraining.JobSetting
{
    public partial class ManageJobGroup : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageJobGroup()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetJobGroupId() > 0)
                {
                    PopulateData();

                }
                else
                {
                    setDdl();
                    BtnDelete.Visible = false;
                }

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 61) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            
            }


        }

        private void PopulateData()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec procJobGroup @Flag='s',@JOB_GROUP_ID="+GetJobGroupId()+"").Tables[0];

            if (dt == null)
                return;
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];

            }

             txtGroupName.Text = dr["GROUP_NAME"].ToString();
            _clsDao.setDDL(ref DdlPostition, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE TYPE_ID=4", "ROWID", "DETAIL_TITLE", dr["POSITION_ID"].ToString(), "Select");
            _clsDao.setDDL(ref DdlDepartment, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments where 1=1", "DEPARTMENT_ID", "DEPARTMENT_NAME", dr["DEPT_ID"].ToString(), "Select");
        

        }
        
        private long GetJobGroupId()
        {
            return (Request.QueryString["Job_Group_Id"] != null ? long.Parse(Request.QueryString["Job_Group_Id"].ToString()) : 0);
        }
        private void setDdl()
        {
            _clsDao.setDDL(ref DdlPostition, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE TYPE_ID=4", "ROWID", "DETAIL_TITLE", "", "Select");
            _clsDao.setDDL(ref DdlDepartment, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments where 1=1", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
        }

        protected void btnSave0_Click(object sender, EventArgs e)
        {
            OpertationData();
        }

        private void OpertationData()
        {
            string sql = "Exec [procJobGroup] @flag="+ (GetJobGroupId().ToString() =="0" ? "'i'" : "'u'");
                        sql = sql + ", @GROUP_NAME = " + filterstring( txtGroupName.Text);
                        sql = sql + ", @DEPT_ID = " + filterstring(DdlDepartment.Text);
                        sql = sql + ",@POSITION_ID  = " + filterstring(DdlPostition.Text);
                        sql = sql + ",@JOB_GROUP_ID  = " + filterstring(GetJobGroupId().ToString());
                        _clsDao.runSQL(sql);
                        
            Response.Redirect("/OnTheJobTraining/JobSetting/ListJobGroup.aspx");

        }
        	
      

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec procJobGroup @flag='d',@JOB_GROUP_ID="+GetJobGroupId()+"");
            Response.Redirect("/OnTheJobTraining/JobSetting/ListJobGroup.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/OnTheJobTraining/JobSetting/ListJobGroup.aspx");
        }

    }
}
