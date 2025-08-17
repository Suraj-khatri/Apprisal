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
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.AccountMaintainance;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.AccountMaintainance
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = null;
        AccountMaintainanceCore _acCore = null;
        AccountMaintainanceDAO _acDao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public Manage()
        {
            _clsDao = new clsDAO();
            _acCore = new AccountMaintainanceCore();
            _acDao = new AccountMaintainanceDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }

        private long GetRowId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 65) == false)
                {
                    Response.Redirect("/Error.aspx");
                }                
                long Id = GetRowId();
                PopulateDDL();
                if (Id > 0)
                {
                    PopulateAccountDetails();
                }


            }
        }

        private void PopulateDDL()
        {
            _clsDao.CreateDynamicDDl(CmbAccountBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");            
        }

        private void PopulateAccountDetails()
        {
            try
            {
                long Id = GetRowId();
                _acCore = _acDao.GetAccountDetailsByID(Id);
                TxtAccountNumber.Text = _acCore.AcNumber;
                TxtAccountName.Text = _acCore.AcName;
                TxtAccountCurrency.Text = _acCore.AcCurrency;
                CmbAccountBranch.SelectedValue = _acCore.AcBranchId.ToString();
                TxtAccountType.Text = _acCore.AcTypeCode;
                TxtAccountNumber.Enabled = false;
            }
            catch
            {
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAccountDetails();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Saving!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ManageAccountDetails()
        {
            long Id = GetRowId();
            _acCore.AcID = Id;
            _acCore.AcNumber = TxtAccountNumber.Text;
            _acCore.AcName = TxtAccountName.Text;
            _acCore.AcCurrency = TxtAccountCurrency.Text;
            _acCore.AcBranchId = long.Parse(CmbAccountBranch.SelectedValue);
            _acCore.AcTypeCode = TxtAccountType.Text;
            _acCore.ActEmpID = ReadSession().Emp_Id;

            if (Id > 0)
            {
                _acDao.Update(_acCore);
            }
            else
            {
                _acDao.Save(_acCore);
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
