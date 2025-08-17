using System;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Company.Branch
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        BranchDao branchDao = null;
        BranchCore _branch = null;
        public Manage()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this.branchDao = new BranchDao();
            this._branch = new BranchCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 6) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            string selectValue = "";
            if (ddlcountry.SelectedItem != null)
                selectValue = ddlcountry.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref ddlcountry, "Exec ProcStaticDataView 's','1'", "DETAIL_TITLE", "DETAIL_TITLE", "Nepal", "Select...");

            //if (DdlBranchGroup.SelectedItem != null)
            //    selectValue = DdlBranchGroup.SelectedItem.Value.ToString();
            //swift.setDDL(ref DdlBranchGroup, "Exec ProcStaticDataView 'b','103'", "DETAIL_TITLE", "DETAIL_TITLE", selectValue, "Select...");

            if (ddlzone.SelectedItem != null)
                selectValue = ddlzone.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlzone, "Exec ProcStaticDataView 's','2'", "DETAIL_TITLE", "DETAIL_TITLE", selectValue, "Select...");

            if (ddldistrict.SelectedItem != null)
                selectValue = ddldistrict.SelectedItem.Value.ToString();
            swift.setDDL(ref ddldistrict, "Exec ProcStaticDataView 's','3'", "DETAIL_TITLE", "DETAIL_TITLE", selectValue, "Select...");
            if (!IsPostBack)
            {
                if (this.GetBranchId() != "")
                    this.populateBranch();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.ManageBranch();
            lblmsg.ForeColor = System.Drawing.Color.Green;
            Clear();
            Response.Redirect("List.aspx");
        }
        private void Clear()
        {
            TxtBranchName.Text = "";
            TxtBranchAddress.Text = "";
            TxtBranchPhone.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            TxtContactPerson.Text = "";
        }
        private void ManageBranch()
        {
            string id = StringEncryption.Decrypt(this.GetBranchId());
            this.PrepareBranch();
            if (id != "")
            {
                try
                {
                    this._branch.ModifyBy = this.ReadSession().UserId;
                    this.branchDao.Update(_branch);
                    lblmsg.Text = "Branch Details Updated Successfully!!";
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            else
            {
                try
                {
                    this._branch.CreatedBy = this.ReadSession().UserId;
                    this.branchDao.Save(_branch);
                    lblmsg.Text = "Branch Details Saved Successfully!!";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        private void populateBranch()
        {
            this._branch = this.branchDao.FindById(StringEncryption.Decrypt(this.GetBranchId()));
            this.TxtBranchName.Text = this._branch.Name;
            this.TxtBranchAddress.Text = this._branch.Address;
            this.TxtBranchPhone.Text = this._branch.Phone;
            this.txtMobile.Text = this._branch.Mobile;
            this.txtEmail.Text = this._branch.Email;
            this.ddlcountry.Text = this._branch.Country;
            //this.DdlBranchGroup.Text = this._branch.Group;
            this.ddlzone.Text = this._branch.Zone;
            this.ddldistrict.Text = this._branch.District;
            this.TxtContactPerson.Text = this._branch.ContactPerson;
            this.Txtfax.Text = this._branch.Fax;
            this.TxtShortName.Text = this._branch.Branchshortname;
            //stockAc.Text = _branch.StockAc;
            //expensesAc.Text = _branch.ExpAc;
            //transitAc.Text = _branch.TransitAc;
            //isDirectExp.SelectedValue = _branch.IsDirectExp;

        }
        private void PrepareBranch()
        {
            string id = StringEncryption.Decrypt(this.GetBranchId());
            if (id != "")
            {
                _branch.Id = id;
            }
            _branch.Name = TxtBranchName.Text;
            _branch.Address = TxtBranchAddress.Text;
            _branch.Phone = TxtBranchPhone.Text;
            _branch.Mobile = txtMobile.Text;
            _branch.Email = txtEmail.Text;
            _branch.Country = ddlcountry.Text;
            //_branch.Group = DdlBranchGroup.Text;
            _branch.Zone = ddlzone.Text;
            _branch.District = ddldistrict.Text;
            _branch.ContactPerson = TxtContactPerson.Text;
            _branch.Branchshortname = TxtShortName.Text;
            _branch.Fax = Txtfax.Text;
            //_branch.StockAc = stockAc.Text;
            //_branch.ExpAc = expensesAc.Text;
            //_branch.TransitAc = transitAc.Text;
            //_branch.IsDirectExp = isDirectExp.Text;
        }
        private string GetBranchId()
        {
            return Request.QueryString["Id"] != null ? Uri.UnescapeDataString(Request.QueryString["Id"].ToString()) : "";
        }

        protected void ddlzone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlzone.SelectedValue == "Bagmati")
            {
                //ddldistrict.Text = "Achham";
                //ddldistrict.Text = "Arghakhanchi";
                //ddldistrict.Text = "Baglung";
                //ddldistrict.Text = "Banke";
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }        
    }
}
