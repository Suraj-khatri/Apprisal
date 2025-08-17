using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.Company
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        CompanyDAO CompInfo = null;
        CompanyCore _company = null;
        public Manage()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this.CompInfo = new CompanyDAO();
            this._company = new CompanyCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 5) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                string Id = StringEncryption.Decrypt(this.getCustomerId());
                if (Id != "")
                {
                    populateCustomer();
                    BtnBack.Visible = true;
                }
                else
                {
                    BtnBack.Visible = false;
                }
            }
        }
        private void PrepareCompany()
        {
            CompanyCore _companyCore = new CompanyCore();
            string id = StringEncryption.Decrypt(this.getCustomerId());
            if (id != "")
            {
                _company.Id = id;
            }
            _company.Shortname = TxtCompShortName.Text;
            _company.Name = TxtCompName.Text;
            _company.Address = TxtCompAddress.Text;
            _company.Address2 = TxtCompAddress2.Text;
            _company.Phone_no = TxtCompPhone.Text;
            _company.Fax_no = TxtCompFax.Text;
            _company.Map_code = TxtCompMapcode.Text;
            _company.Contact_person = TxtContactPerson.Text;
            if (ChkActive.Checked==true)
            {
                _company.Status = "true";
            }
            else
            {
                _company.Status = "false";
            }
            _company.Url = Txturl.Text;
            _company.Email = TxtEmail.Text;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.ManageCompany();
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in Operation!!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

       
        private void populateCustomer()
        {
            string Id = StringEncryption.Decrypt(this.getCustomerId());
            if (Id != "")
            {
                this._company = this.CompInfo.FindById(Id);
                TxtCompShortName.Text = this._company.Shortname;
                TxtCompName.Text = this._company.Name;
                TxtCompAddress.Text = this._company.Address;
                TxtCompAddress2.Text = this._company.Address2;
                TxtCompPhone.Text = this._company.Phone_no;
                TxtCompFax.Text = this._company.Fax_no;
                TxtContactPerson.Text = this._company.Contact_person;
                Txturl.Text = this._company.Url;
                TxtEmail.Text = this._company.Email;
                if (this._company.Status == "Active")
                {
                    ChkActive.Checked = true;
                }
                else
                {
                    ChkActive.Checked = false;
                }
                TxtCompMapcode.Text = this._company.Map_code;
            }
        }
        private void Clear()
        {
            TxtCompShortName.Text = "";
            TxtCompName.Text = "";
            TxtCompAddress.Text = "";
            TxtCompAddress2.Text = "";
            TxtCompPhone.Text = "";
            TxtCompFax.Text = "";
            TxtContactPerson.Text = "";
            Txturl.Text = "";
            TxtCompMapcode.Text = "";
            TxtEmail.Text = "";
        }
        private void ManageCompany()
        {
            string Id = StringEncryption.Decrypt(this.getCustomerId());
            this.PrepareCompany();
            if (Id != "")
            {
                this._company.ModifyBy = this.ReadSession().UserId;
                this.CompInfo.Update(_company);
            }
            else
            {
                this._company.CreatedBy = this.ReadSession().UserId;
                this.CompInfo.Save(_company);
            }
        }
        private string getCustomerId()
        {
             return Request.QueryString["Id"] != null ? Uri.UnescapeDataString(Request.QueryString["Id"].ToString()) : "";
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }  
    }
}
