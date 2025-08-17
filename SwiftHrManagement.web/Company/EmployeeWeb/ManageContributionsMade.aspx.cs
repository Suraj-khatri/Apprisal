using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.ContributionMadeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageContributionsMade : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ContributionMadeCore _cnmCore = null;
        ContributionMadeDAO _cnmDAO = null;

        public ManageContributionsMade()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._cnmCore = new ContributionMadeCore();
            this._cnmDAO = new ContributionMadeDAO();
        }
        private long GetContributionId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateContribution()
        {
            DateTime Paid_Date;
            this._cnmCore = this._cnmDAO.FindById(this.GetContributionId());

            Paid_Date = this._cnmCore.ContributionDate;
            
            this.cmbContributor.Text = this._cnmCore.ContributionDate.ToString();
            this.TxtContributionAmount.Text = this._cnmCore.ContributionAmount.ToString();
            this.TxtContributionDate.Text = Paid_Date.ToString("MM/dd/yyyy");
            this.TxtReceiptNumber.Text = this._cnmCore.ReceiptNumber;

            this.hdnContributionId.Value = this._cnmCore.ContributionId;
        }
        private void ManageContribution()
        {
            long id = this.GetContributionId();
            this.PrepareContribution();

            if (id > 0)
            {
                this._cnmDAO.Update(this._cnmCore);
            }
            else
            {
                this._cnmDAO.Save(this._cnmCore);
            }
        }
        private void PrepareContribution()
        {
            ContributionMadeCore _cmCore = new ContributionMadeCore();
            long contributionId = this.GetContributionId();

            _cmCore.Id = long.Parse(contributionId.ToString());
            _cmCore.ContributionId = this.ReadSession().TempContribution_Id.ToString();
            _cmCore.Contributor = cmbContributor.Text;
            _cmCore.ContributionAmount = Double.Parse(TxtContributionAmount.Text);
            _cmCore.ContributionDate = DateTime.Parse(TxtContributionDate.Text);
            _cmCore.ReceiptNumber = TxtReceiptNumber.Text;

            this._cnmCore = _cmCore;
        }
        private void ResetContribution()
        {
            cmbContributor.Enabled = false;
            TxtContributionDate.Text = "";
            TxtReceiptNumber.Text = "";
            TxtContributionAmount.Text = "";
            BtnSave.Enabled = false;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                long Id = this.GetContributionId();

                if (Id > 0)
                {
                    PopulateContribution();
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageContribution();
                lblTransactionMessage.Text = "Operation Completed Successfully";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                this.ResetContribution();
            }
            catch
            {
                lblTransactionMessage.Text = "Error In Operation";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void cmbContributor_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtContributionAmount.Text = "1";
        }
    }
}
