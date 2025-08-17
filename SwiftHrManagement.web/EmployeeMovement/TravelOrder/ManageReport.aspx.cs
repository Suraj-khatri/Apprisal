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

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder
{
    public partial class ManageReport : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 15) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDDl();
            }
        }

        private void PopulateDDl()
        {
            _clsDao.CreateDynamicDDl(ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "","Select");
        }

        protected void BtnSearchBrthday_Click(object sender, EventArgs e)
        {
            if (txtFromDate1.Text == "")
            {
                lblMsg.Text = "Select Request From Date";
            }
            else if (txtToDate1.Text == "")
            {
                lblMsg.Text = "Select Request To Date";
            }
            else
                Response.Redirect("/EmployeeMovement/TravelOrder/GenerateReport.aspx?fromDate=" + txtFromDate1.Text + "&toDate=" + txtToDate1.Text + "&branch=" + ddlBranch.Text + "&status=" + ddlStatus.Text );
        }
    }
}
