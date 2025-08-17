using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.DonationsDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageDonations : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        DonationsDAO _donationDao = null;
        DonationsCore _donationCore = null;
        public ManageDonations()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._donationDao = new DonationsDAO();
            this._donationCore = new DonationsCore();
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetDonationId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateDonation()
        {
            this._donationCore = this._donationDao.FindById(this.GetDonationId());          
            this.TxtDonationAmount.Text = _donationCore.DonationAmount.ToString();
            this.TxtDonationDate.Text = _donationCore.DonationDate.ToString();
            this.TxtDetailedDescription.Text = _donationCore.DetailedDescription.ToString();
            this.TxtTaxpct.Text = _donationCore.GovernmentApprovedDeduction.ToString();
            this.hdnempid.Value = _donationCore.EmployeeId;
        }
        private void ManageDon()
        {
            DonationsCore _dnsCore = new DonationsCore(); 
            _donationCore.Id = GetDonationId();
            _donationCore.DonationAmount = Double.Parse(TxtDonationAmount.Text);
            _donationCore.DonationDate = TxtDonationDate.Text;
            _donationCore.DetailedDescription = TxtDetailedDescription.Text;
            _donationCore.GovernmentApprovedDeduction = TxtTaxpct.Text;
            _donationCore.EmployeeId = this.hdnempid.Value;
            if (GetDonationId() > 0)
            {
                string oldValue = this._donationDao.CRUDLog(GetDonationId().ToString());

                this._donationDao.Update(this._donationCore);

                string newValue = this._donationDao.CRUDLog(GetDonationId().ToString());
                this._donationDao.LogJobHistoryReport("update", "Donations", GetDonationId().ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
                this._donationDao.Save(this._donationCore);

                string Rowid = this._donationCore.Id.ToString();
                string newValue = this._donationDao.CRUDLog(Rowid);
                this._donationDao.LogJobHistoryReport("Insert", "Donations", Rowid, "", newValue, ReadSession().UserId);
            }
            this._donationCore = _dnsCore;
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                if (GetDonationId() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateDonation();
                }
                else
                {
                    BtnDelete.Visible = false;
                    hdnempid.Value = GetEmpId().ToString();
                }
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                getemployee();
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageDon();
                LblMsg.Text = "Operation Completed Successfully";
                LblMsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("/Company/EmployeeWeb/ListDonations.aspx?Id=" + hdnempid.Value + "");
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
                string oldValue = this._donationDao.CRUDLog(GetDonationId().ToString());
                this._donationDao.LogJobHistoryReport("Delete", "Donations", GetDonationId().ToString(), oldValue, "", ReadSession().UserId);

                _donationDao.Deletedonation(GetDonationId(), ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListDonations.aspx?Id="+ hdnempid.Value +"");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}