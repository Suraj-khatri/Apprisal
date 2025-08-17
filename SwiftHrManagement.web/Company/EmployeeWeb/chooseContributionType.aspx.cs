using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class chooseContributionType : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public chooseContributionType()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
        }

        private long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                hdnEmpId.Value = GetEmpId().ToString();
                getemployee();
            }
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnEmpId.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }
        protected void regularContribution_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListContribution.aspx?Id=" + hdnEmpId.Value + "");
        }
        protected void adhocContribution_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAdhocContbution.aspx?Id=" + hdnEmpId.Value + "");
        }
    }
}
