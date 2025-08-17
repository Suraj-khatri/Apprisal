//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using SwiftHrManagement.DAL.BenefitsOnlyForTaxDAO;
//using SwiftHrManagement.DAL.Role;

//namespace SwiftHrManagement.web.Company.EmployeeWeb
//{
//    public partial class ListBenefitsOnlyForTax : BasePage
//    {
//        RoleMenuDAOInv _RoleMenuDAOInv = null;
//        BenefitsOnlyForTaxDAO _benefitsDAO = null;
//        public ListBenefitsOnlyForTax()
//        {
//            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
//            this._benefitsDAO = new BenefitsOnlyForTaxDAO();
//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
//                {
//                    Response.Redirect("/Error.aspx");
//                }
//                this.GdvBenefitList.DataSource = this._benefitsDAO.FindAllBenefits();
//                this.GdvBenefitList.DataBind();
//            }
//        }
//    }
//}
