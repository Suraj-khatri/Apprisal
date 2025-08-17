using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BenefitsDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageBenefits : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        BenefitsCore _bCore = null;
        BenefitsDAO _bDAO = null;
    
        //CONSTRUCTOR STARTED
        
        public ManageBenefits()
        {
            // OBJECT INSTANCE INITIALIZED
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
            this._bDAO = new BenefitsDAO();
            this._bCore = new BenefitsCore();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                long Id = this.GetBenefitsId();

                if (Id > 0)
                {
                    // call update method
                    PopulateBenefits();
                }
            }
        }
        
        //retrieve id frm url parameter
        
        private long GetBenefitsId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        
        // when user clicks save button
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.Manage();
            Response.Redirect("ListBenefits.aspx");
        }

        private void Manage()
        {
            long id = this.GetBenefitsId();
            this.PrepareBenefits();
            if (id > 0)
            {
                this._bCore.ModifyBy = this.ReadSession().UserId;
                this._bDAO.Update(this._bCore);
                lblMessage.Visible = true;
                lblMessage.Text = "Employee Benefit Updated Successfully!!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this._bCore.CreatedBy = this.ReadSession().UserId;
                this._bDAO.Save(this._bCore);
                lblMessage.Visible = true;
                lblMessage.Text = "Benefit Information Saved Successfully !!";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Clear();
            }
        }

        private void PrepareBenefits()
        {
            BenefitsCore _benCore = new BenefitsCore();
            long Id = this.GetBenefitsId();
            if (Id > 0)
            {
                _benCore.Id = Id;
            }

            _benCore.BenefitName = TxtBenefitName.Text;
            _benCore.Occurrence = ddlOccurrence.Text;
            _benCore.Details = TxtDetails.Text;
            _benCore.GlCode = TxtGlCode.Text;
            _benCore.BenefitGroup = ddlBenefitGroup.Text;
            
            this._bCore = _benCore;
        }

        private void PopulateBenefits()
        {
            this._bCore = this._bDAO.FindBenefitById(this.GetBenefitsId());

            this.TxtBenefitName.Text = this._bCore.BenefitName;
            this.ddlOccurrence.SelectedValue = this._bCore.Occurrence;
            this.TxtDetails.Text = this._bCore.Details;
            this.TxtGlCode.Text = this._bCore.GlCode;
            this.ddlBenefitGroup.SelectedValue = this._bCore.BenefitGroup;
            
        }

        private void Clear()
        {
            this.TxtBenefitName.Text = "";
            this.ddlOccurrence.Enabled= false;
            this.TxtDetails.Text = "";
            this.TxtGlCode.Text = "";
            this.ddlBenefitGroup.Enabled = false; 
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Manage();
                Response.Redirect("ListBenefits.aspx");
            }
            catch
            {
                lblMessage.Text = "Error In Operation";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
