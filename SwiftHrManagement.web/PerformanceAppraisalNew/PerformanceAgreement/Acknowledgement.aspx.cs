using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement
{
    public partial class Acknowledgement : BasePage
    {
        PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public Acknowledgement()
        {
            _Obj = new PerformanceAgreementDao();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1113) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {

            }
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
        }
        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }
        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }
    }
}