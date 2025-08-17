using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.ContributionDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageContribution : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ContributionDAO _contributionDAO = null;
        ContributionCore _contributionCore = null;

        public ManageContribution()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._contributionDAO = new ContributionDAO();
            this._contributionCore = new ContributionCore();
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetContributionId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateContribution()
        {
            this._contributionCore = this._contributionDAO.FindById(this.GetContributionId());
            this.DdlContributedTo.Text = this._contributionCore.ContributedTo;
            this.TxtContributionCode.Text = this._contributionCore.ContributionCode;         
            this.TxtContributionFromDateEmployee.Text = this._contributionCore.ContributionFromDateEmployee; 
            this.TxtContributionFromDateEmployer.Text = this._contributionCore.ContributionFromDateEmployer;
            this.TxtContributionRateEmployee.Text = this._contributionCore.Value_employee.ToString();
            this.TxtContributionRateEmployer.Text = this._contributionCore.Value_employer.ToString();
            DdlContbonEmpl.Text = this._contributionCore.Flag_employee;
            DdlContbonEmplr.Text = this._contributionCore.Flag_employer;            
            this.DdlcontbBasisEmployee.Text = this._contributionCore.ContributionBasisEmployee.ToString();
            if (DdlcontbBasisEmployee.Text == "")
                DdlcontbBasisEmployee.Enabled = false;
            this.DdlcontbBasisEmployer.Text = this._contributionCore.ContributionBasisEmployer.ToString();
            if (DdlcontbBasisEmployer.Text == "")
                DdlcontbBasisEmployer.Enabled = false;
            this.hdnempid.Value = this._contributionCore.EmployeeID;
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();           
            if (GetContributionId() > 0)
            {
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
                //LblEmpName.Text = _empcore.EmpName;
            }
            else
            {
                _empcore = _empdao.FindFullNameById(GetEmpId());
                //LblEmpName.Text = _empcore.EmpName;
            }
        }
        private void ManageCont()
        {
            string contbasisonemp = "";
            string contbasisonemplr = "";
            ContributionCore _cCore = new ContributionCore();
            long id = this.GetContributionId();

            _contributionCore.EmployeeID = this.hdnempid.Value;
            _contributionCore.Id = long.Parse(id.ToString());
            _contributionCore.ContributedTo = DdlContributedTo.Text;
            _contributionCore.ContributionCode = TxtContributionCode.Text;
            if (TxtContributionFromDateEmployer.Text == "")
            {
                _contributionCore.ContributionFromDateEmployer = TxtContributionFromDateEmployer.Text;
            }
            else
            {
                _contributionCore.ContributionFromDateEmployer = TxtContributionFromDateEmployer.Text;
            }
            if (TxtContributionFromDateEmployee.Text == "")
            {
                _contributionCore.ContributionFromDateEmployee = TxtContributionFromDateEmployee.Text;
            }
            else
            {
                _contributionCore.ContributionFromDateEmployee = TxtContributionFromDateEmployee.Text;
            }            
            _contributionCore.Contbemplr_amt_pct = TxtContributionRateEmployer.Text;
            _contributionCore.Value_employee = TxtContributionRateEmployee.Text;
            _contributionCore.Value_employer = TxtContributionRateEmployer.Text;
            if (DdlContbonEmpl.SelectedItem.Value == "P")
            {
                contbasisonemp = DdlcontbBasisEmployee.Text;
            }
            else
            {
                contbasisonemp = "";
            }
            if (DdlContbonEmplr.SelectedItem.Value == "P")
            {
                contbasisonemplr = DdlcontbBasisEmployer.SelectedItem.Value;
            }
            else
            {
                contbasisonemplr = "";
            }
            _contributionCore.ContributionBasisEmployee = contbasisonemp;
            _contributionCore.ContributionBasisEmployer = contbasisonemplr;
            _contributionCore.Flag_employee = DdlContbonEmpl.SelectedItem.Value;
            _contributionCore.Flag_employer = DdlContbonEmplr.SelectedItem.Value;
            if (id > 0)
            {
                this._contributionCore.ModifyBy = this.ReadSession().UserId;
                string oldValue = this._contributionDAO.CRUDLog(id.ToString());
                this._contributionDAO.Update(this._contributionCore);
                string newValue = this._contributionDAO.CRUDLog(id.ToString());
                this._contributionDAO.LogJobHistoryReport("update", "Contribution", id.ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
                this._contributionCore.CreatedBy = this.ReadSession().UserId;
                this._contributionDAO.Save(this._contributionCore);
                string Rowid = this._contributionCore.Id.ToString();
                string newValue = this._contributionDAO.CRUDLog(Rowid);
                this._contributionDAO.LogJobHistoryReport("Insert", "Contribution", Rowid, "", newValue, ReadSession().UserId);
            }
        }
        private void ResetContribution()
        {        
            TxtContributionCode.Text = "";
            TxtContributionRateEmployee.Text = "";            
            TxtContributionFromDateEmployee.Text = "";         
            TxtContributionRateEmployer.Text = "";            
            TxtContributionFromDateEmployer.Text = "";            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }    
                PopulateDdlContributionType();
                long Id = this.GetContributionId();
                if (Id > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateContribution();
                }
                else
                {
                    hdnempid.Value = GetEmpId().ToString();
                    BtnDelete.Visible = false;
                }
                getemployee();
            }
        }
        private void PopulateDdlContributionType()
        {
            string selectValue = "";
            if (DdlContributedTo.SelectedItem != null)
                selectValue = DdlContributedTo.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlContributedTo, "Exec ProcStaticDataView 's','21'", "ROWID", "DETAIL_TITLE", selectValue, "Select...");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DdlContbonEmpl.SelectedItem.Value == "P" && DdlcontbBasisEmployee.SelectedItem.Value == "")
                {
                    lblTransactionMessage.Text = "Please enter contribution on for employee!";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else if (DdlContbonEmplr.SelectedItem.Value == "P" && DdlcontbBasisEmployer.SelectedItem.Value == "")
                {
                    lblTransactionMessage.Text = "Please enter contribution on for employer!";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    ManageCont();
                    Response.Redirect("/Company/EmployeeWeb/ListContribution.aspx?Id=" + hdnempid.Value + "");
                }
            }
            catch
            {
                lblTransactionMessage.Text = "Error In Operation";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void TxtContributedFromDate0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TxtContributionFrequency0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Ddl0_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string oldValue = this._contributionDAO.CRUDLog(GetContributionId().ToString());
                _contributionDAO.deleteContribution(GetContributionId(), ReadSession().UserId);
                this._contributionDAO.LogJobHistoryReport("Delete", "Contribution", GetContributionId().ToString(), oldValue, "", ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListContribution.aspx?Id="+hdnempid.Value+"");
            }
            catch
            {
                lblTransactionMessage.Text = "Error in operation";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DdlContbonEmpl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlContbonEmpl.SelectedItem.Value == "P")
            {
                DdlcontbBasisEmployee.Enabled = true;
            }
            else
            {
                DdlcontbBasisEmployee.Enabled = false;
            }
        }
        protected void DdlContbonEmplr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlContbonEmplr.SelectedItem.Value == "P")
            {
                DdlcontbBasisEmployer.Enabled = true;
            }
            else
            {
                DdlcontbBasisEmployer.Enabled = false;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/ListContribution.aspx?Id=" + hdnempid.Value + "");
        }
    }
}