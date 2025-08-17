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

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveCallBack
{
    public partial class ApprovedLeaveSearch : BasePage
    {
        clsDAO clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public ApprovedLeaveSearch()
        {
            this.clsdao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 35) == false)
            {
                Response.Redirect("/Error.aspx");                
            }
            if (!IsPostBack)
            {
                clsdao.CreateDynamicDDl(DdlLeaveType, "SELECT NAME_OF_LEAVE, ID FROM LeaveTypes where IS_ACTIVE=1", "ID", "NAME_OF_LEAVE", "", "Select");
            }
        }

        protected void BtnGo_Click(object sender, EventArgs e)
        {
            try
            {
                OnSearch();
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
        }

        private void OnSearch()
        {
            if (getEmpIdfromInfo(lblEmpName.Text) == "")
            {
                LblMsg.Text = "Please choose employee!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                string emp_id = "";
                string leave_id = "";
                emp_id = getEmpIdfromInfo(lblEmpName.Text);
                leave_id = DdlLeaveType.Text;
                Response.Redirect("ApprovedLeaveList.aspx?empId=" + emp_id + "&leaveId=" + leave_id + "");
            }
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }

        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";
        }
    }
}
