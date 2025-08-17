using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.BankAccountDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageBankAccounts : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        BankAccountDAO _bankDao = null;
        BankAccountsCore _bankCore = null;
        public ManageBankAccounts()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._bankDao = new BankAccountDAO();
            this._bankCore = new BankAccountsCore();
        }
        private Boolean CheckDefaultAc()
        {
            Boolean IfExists = false;
            return IfExists;
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetBankAccountId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));   
            //LblEmpname.Text = _empcore.EmpName;
        }
        private void PopulateBankAccount()
        {
            bool val;
            this._bankCore = this._bankDao.FindById(this.GetBankAccountId());
            this.TxtAccountNumber.Text = this._bankCore.AccountNumber.ToString();
            this.DdlBankName.Text = this._bankCore.AccountProvider;
            this.hdnempid.Value = this._bankCore.Employee_Id;
            this.TxtAccountDetails.Text = this._bankCore.AccountDetails;
            val = this._bankCore.IsDefault;
            if (val == true)
            {
                this.ChkIsDefault.Checked = true;
            }
            else
            {
                this.ChkIsDefault.Checked = false;
            }
        }
        private void populateDdlBank()
        {
            string selectValue = "";
            if (DdlBankName.SelectedItem != null)
                selectValue = DdlBankName.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlBankName, "Exec ProcStaticDataView 's','39'", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
        }
        private void ManageBanks()
        {
            long id = this.GetBankAccountId();
            _bankCore.Id = long.Parse(id.ToString());
            _bankCore.AccountNumber = TxtAccountNumber.Text;
            _bankCore.AccountProvider = DdlBankName.Text;
            _bankCore.AccountDetails = TxtAccountDetails.Text;
            _bankCore.Employee_Id = this.hdnempid.Value;
            if (ChkIsDefault.Checked == true)
            {
                _bankCore.IsDefault = true;
            }
            else
            {
                _bankCore.IsDefault = false;
            }
            if (id > 0)
            {
                string oldValue = this._bankDao.CRUDLog(id.ToString());   
                this._bankDao.Update(this._bankCore);

                string newValue = this._bankDao.CRUDLog(id.ToString());
                this._bankDao.LogJobHistoryReport("update", "BankAccounts", id.ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
                this._bankDao.Save(this._bankCore);

                  string Rowid = this._bankCore.Id.ToString();
                string newValue = this._bankDao.CRUDLog(Rowid);
                this._bankDao.LogJobHistoryReport("Insert", "BankAccounts", Rowid, "", newValue, ReadSession().UserId.ToString());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdlBank();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false && _RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 104) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetBankAccountId();
                if (Id > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateBankAccount();
                }
                else
                {
                    hdnempid.Value = GetEmpId().ToString();
                    BtnDelete.Visible = false;
                }
                getemployee();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Boolean DefaultAcExists = false;
            try
            {
                DefaultAcExists = this._bankDao.VerifyDefaultAc(this.hdnempid.Value, GetBankAccountId());
                if (DefaultAcExists != false && ChkIsDefault.Checked == true)
                {
                    LblMsg.Text = "Default A/C Already Exists";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    ManageBanks();
                    Response.Redirect("/Company/EmployeeWeb/ListBankAccounts.aspx?Id="+hdnempid.Value+"");
                }
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string oldValue = this._bankDao.CRUDLog(GetBankAccountId().ToString());
                this._bankDao.LogJobHistoryReport("Delete", "BankAccounts", GetBankAccountId().ToString(), oldValue, "", ReadSession().UserId);

                _bankDao.deleteBankAccounts(GetBankAccountId(), ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListBankAccounts.aspx?Id=" + hdnempid.Value + "");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}