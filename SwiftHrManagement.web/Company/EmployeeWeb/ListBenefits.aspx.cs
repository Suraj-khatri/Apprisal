using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

using SwiftHrManagement.DAL.BenefitsDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ListBenefits : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        BenefitsDAO _benefitsDAO = null;
        public ListBenefits()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
            this._benefitsDAO = new BenefitsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.GdvBenefitList.DataSource = this._benefitsDAO.FindAllBenefits();
                this.GdvBenefitList.DataBind();
            }
        }
    }
}
