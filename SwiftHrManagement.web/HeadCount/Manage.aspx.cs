using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.AllocationSetup
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = null;
        public Manage()
        {
            _clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
                if (GetId() > 0)
                {
                    PopulateAllocationDetails();
                }
            }
        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void PopulateDropDownList()
        {
            PopulateBranchName();
            PopulatePosition();
            if (GetId() > 0)
            {
                PopulateDepartment();
            }
        }

        private void PopulateBranchName()
        {
            _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME FROM BRANCHES ORDER BY BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        private void PopulatePosition()
        {
            _clsDao.CreateDynamicDDl(DdlPosition, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE TYPE_ID=4", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private void PopulateDepartment()
        {
        }


        private void PopulateAllocationDetails()
        {
            DataTable dt = new DataTable();
            DataRow dr = _clsDao.getDataset("EXEC [ProcManageAllocationSetup] 's'," + filterstring(GetId().ToString()) + "").Tables[0].Rows[0];

            DdlBranchName.SelectedValue = dr["BRANCH_ID"].ToString();
            DdlPosition.SelectedValue = dr["POSITION"].ToString();
            txtAllocation.Text = dr["ALLOCATION"].ToString();

            _clsDao.CreateDynamicDDl(DdlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments where BRANCH_ID=" + filterstring(dr["BRANCH_ID"].ToString()) + " ORDER BY DEPARTMENT_NAME", "DEPARTMENT_ID", "DEPARTMENT_NAME", "" , "Select");
            DdlDeptName.SelectedValue = dr["DEPT_ID"].ToString();

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.runSQL("EXEC [ProcManageAllocationSetup] @FLAG='d',@ID=" + filterstring(GetId().ToString()) + "");
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in Insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManagePopulateAllocation();
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in Insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void ManagePopulateAllocation()
        {
            long id = GetId();
            if (id > 0)
            {
                _clsDao.runSQL("EXEC [ProcManageAllocationSetup] @FLAG='u',@ID=" + filterstring(id.ToString()) + ",@BRANCH_ID=" + filterstring(DdlBranchName.Text) + ","
                    + "@DEPT_ID=" + filterstring(DdlDeptName.Text) + " @Position=" + filterstring(DdlPosition.Text) + ",@ALLOCATION=" + filterstring(txtAllocation.Text) + ","
                    + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            }
            else
            {
                _clsDao.runSQL("EXEC [ProcManageAllocationSetup] @FLAG='i',@BRANCH_ID=" + filterstring(DdlBranchName.Text) + ","
                    + "@DEPT_ID=" + filterstring(DdlDeptName.Text) + ", @Position=" + filterstring(DdlPosition.Text) + ", @ALLOCATION=" + filterstring(txtAllocation.Text) + ","
                    + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsDao.CreateDynamicDDl(DdlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments where BRANCH_ID=" + filterstring(DdlBranchName.Text) + " ORDER BY DEPARTMENT_NAME", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
        }
    }
}
