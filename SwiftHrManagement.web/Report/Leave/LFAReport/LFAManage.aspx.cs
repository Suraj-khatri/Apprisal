using System;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Leave.LFAReport
{
    public partial class LFAManage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        clsDAO _clsDao=new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 278) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                LoadDDl();
            }
        }

        private void LoadDDl()
        {
            _clsDao.setDDL(ref ddlBranch, "select BRANCH_ID,BRANCH_NAME from Branches", "BRANCH_ID", "BRANCH_NAME","","All");
        }
        protected void btnReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("LFARpt.aspx?&fromDate="+txtFrmDate.Text+"&toDate="+txtToDate.Text+"&branchId="+ddlBranch.Text);
        }
    }
}