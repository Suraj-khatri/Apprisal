//using System;
//using System.Web;
//using System.Linq;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using SwiftHrManagement.Core.Domain;
//using SwiftHrManagement.DAL.BenefitsOnlyForTaxDAO;
//using SwiftHrManagement.DAL.Role;

//namespace SwiftHrManagement.web.Company.EmployeeWeb
//{
//    public partial class ManageBenefitsForTax : BasePage
//    {
//        RoleMenuDAOInv _RoleMenuDAOInv = null;
//        BenefitsOnlyForTaxCore _bCore = null;
//        BenefitsOnlyForTaxDAO _bDAO = null;

//        //CONSTRUCTOR STARTED

//        public ManageBenefitsForTax()
//        {
//            // OBJECT INSTANCE INITIALIZED
//            this._RoleMenuDAOInv = new RoleMenuDAOInv();
//            this._bDAO = new BenefitsOnlyForTaxDAO();
//            this._bCore = new BenefitsOnlyForTaxCore();
//        }

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
//                {
//                    Response.Redirect("/Error.aspx");
//                }
//                long Id = this.GetBenefitsId();

//                if (Id > 0)
//                {
//                    // call update method
//                    PopulateBenefitsForTaxOnly();
//                }
//            }
//        }

//        //retrieve id frm url parameter

//        private long GetBenefitsId()
//        {
//            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
//        }

//        // when user clicks save button

//        protected void btnSave_Click(object sender, EventArgs e)
//        {
//            this.Manage();
//            Response.Redirect("ListBenefitsOnlyForTax.aspx");
//        }

//        private void Manage()
//        {
//            long id = this.GetBenefitsId();

//            this.PrepareBenefitsForTaxOnly();
//            if (id > 0)
//            {
//                this._bCore.ModifyBy = this.ReadSession().UserId;
//                this._bDAO.Update(this._bCore);
//                lblMessage.Visible = true;
//                lblMessage.Text = "Employee Benefit For Tax Updated Successfully!!";
//                lblMessage.ForeColor = System.Drawing.Color.Green;
//            }
//            else
//            {
//                this._bCore.CreatedBy = this.ReadSession().UserId;
//                this._bDAO.Save(this._bCore);
//                lblMessage.Visible = true;
//                lblMessage.Text = "Benefit Information For Tax Created Successfully !!";
//                lblMessage.ForeColor = System.Drawing.Color.Green;
//                Clear();
//            }
//        }

//        private void PrepareBenefitsForTaxOnly()
//        {
//            BenefitsOnlyForTaxCore _benCore = new BenefitsOnlyForTaxCore();
//            long Id = this.GetBenefitsId();
//            if (Id > 0)
//            {
//                _benCore.Id = Id;
//            }
//            _benCore.Name = TxtBenefitName.Text;
//            _benCore.GlCode = TxtGlCode.Text;

//            this._bCore = _benCore;
//        }

//        private void PopulateBenefitsForTaxOnly()
//        {
//            this._bCore = this._bDAO.FindBenefitById(this.GetBenefitsId());

//            this.TxtBenefitName.Text = this._bCore.Name;
//            this.TxtGlCode.Text = this._bCore.GlCode;
//        }

//        private void Clear()
//        {
//            this.TxtBenefitName.Text = "";
//            this.BtnSave.Enabled = false;
//            this.TxtGlCode.Text = "";
//        }

//        protected void BtnSave_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                this.Manage();
//                Response.Redirect("ListBenefitsOnlyForTax.aspx");
//            }
//            catch
//            {
//                lblMessage.Text = "Error In Operation";
//                lblMessage.ForeColor = System.Drawing.Color.Red;
//            }
//        }
//    }
//}
