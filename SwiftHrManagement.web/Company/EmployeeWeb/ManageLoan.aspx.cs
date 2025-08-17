 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.LoanDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageLoan : BasePage
    {
        clsDAO swift = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        LoanDAO _LoanDAO = null;
        LoanCore _LoanCore = null;        
        public ManageLoan()
        {
            this.swift = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
            this._LoanDAO = new LoanDAO();
            this._LoanCore = new LoanCore();
        }        
        private long GetLoanId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        public long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            if (GetLoanId() > 0)
            {
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            }
            else
            {
                hdnempid.Value = GetEmpId().ToString();
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            }
        }
        private void PopulateDdlLoanFrequency()
        {
            string selectValue = "";
            if (ddlRepaymentFrequency.SelectedItem != null)
                selectValue = ddlRepaymentFrequency.SelectedItem.Value.ToString();            
            swift.setDDL(ref ddlRepaymentFrequency, "Exec ProcStaticDataView 's','53'", "ROWID", "DETAIL_TITLE", selectValue, "Select...");
        }
        private void PopulateMonthList()
        {
            string selectValue = "";
            if (DdlNextRunMonth.SelectedItem != null)
                selectValue = DdlNextRunMonth.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlNextRunMonth, "SELECT Month_Number,Name FROM MonthList", "Month_Number", "Name", "selectValue", "Select...");
        }
        private void populateDdlloantype()
        {
            string selectValue = "";
            if (DdlLoanType.SelectedItem != null)
                selectValue = DdlLoanType.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlLoanType, "Exec ProcStaticDataView 's','46'", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
        }

        private void PopulateLoan()
        {
            this._LoanCore = this._LoanDAO.FindById(this.GetLoanId());

            this.txtSanctionedDate.Text = this._LoanCore.DateTaken;
            this.txtSanctionedAmt.Text = this._LoanCore.LoanAmount.ToString();
            this.DdlLoanType.Text = this._LoanCore.LoanType;
            this.TxtNoOfInstallments.Text = this._LoanCore.NoOfInstallment.ToString();
            this.txtInterestRate.Text = this._LoanCore.InterestRate.ToString();
            this.ddlRepaymentFrequency.Text = this._LoanCore.RepaymentFrequency;            
            this.TxtLedgerCode.Text = this._LoanCore.LedgerCode;
            this.txtRemainingInstallment.Text = this._LoanCore.RemainingInstallment.ToString();
            this.txtInstallmentStartDate.Text = _LoanCore.InstallmentStartDate;
            this.txtInstallmentAmt.Text = _LoanCore.InstallmentAmount.ToString();
            this.txtNaration.Text = _LoanCore.Naration;
            this.DdlNextRunMonth.SelectedValue = _LoanCore.NextRunMonth;
            this.hdnempid.Value = this._LoanCore.Employee_Id;
            this.TxtAppliedDate.Text = this._LoanCore.AppliedDate;
            this.txtAppliedAmount.Text = this._LoanCore.AppliedAmt.ToString();
            this.DdlInterestType.Text = this._LoanCore.InterestType;
        }
        private void ManageLoanDetail()
        {
            LoanCore _lnCore = new LoanCore();
            long id = this.GetLoanId();
            _LoanCore.NextRunMonth = DdlNextRunMonth.Text;
            _LoanCore.DateTaken = txtSanctionedDate.Text.ToString();
            _LoanCore.LoanAmount = double.Parse(txtSanctionedAmt.Text);
            _LoanCore.LoanType = DdlLoanType.Text;
            _LoanCore.NoOfInstallment = int.Parse(TxtNoOfInstallments.Text);
            _LoanCore.InterestRate = Double.Parse(txtInterestRate.Text);
            _LoanCore.RepaymentFrequency = ddlRepaymentFrequency.Text;    
            _LoanCore.LedgerCode = TxtLedgerCode.Text;
            _LoanCore.InstallmentAmount = Double.Parse(txtInstallmentAmt.Text);
            _LoanCore.RemainingInstallment = txtRemainingInstallment.Text;
            _LoanCore.InstallmentStartDate = txtInstallmentStartDate.Text;
            _LoanCore.Naration = txtNaration.Text;
            _LoanCore.AppliedDate = TxtAppliedDate.Text;
            _LoanCore.AppliedAmt = Double.Parse(txtAppliedAmount.Text);
            _LoanCore.InterestType = DdlInterestType.Text;
            _LoanCore.CreatedBy = ReadSession().Emp_Id.ToString();
            _LoanCore.ModifyBy = ReadSession().Emp_Id.ToString();
            if (id > 0)
            {
                string oldValue = this._LoanDAO.CRUDLog(GetLoanId().ToString());

                _LoanCore.Id = long.Parse(id.ToString());
                _LoanCore.Employee_Id = this.hdnempid.Value;
                this._LoanDAO.Update(this._LoanCore);

                string newValue = this._LoanDAO.CRUDLog(GetLoanId().ToString());
                this._LoanDAO.LogJobHistoryReport("update", "Loan", GetLoanId().ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {               
                _LoanCore.Employee_Id = this.hdnempid.Value;
                this._LoanDAO.Save(this._LoanCore); 

                string Rowid = this._LoanCore.Id.ToString();
                string newValue = this._LoanDAO.CRUDLog(Rowid);
                this._LoanDAO.LogJobHistoryReport("Insert", "Loan", Rowid, "", newValue, ReadSession().UserId);
            }
            this._LoanCore = _lnCore;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDdlLoanFrequency();
                populateDdlloantype();
                PopulateMonthList();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                
                long Id = this.GetLoanId();
                if (Id > 0)
                {
                    PopulateLoan();
                    BtnDelete.Visible = true;
                }
                getemployee();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageLoanDetail();
                Response.Redirect("/Company/EmployeeWeb/ListLoan.aspx?Id=" + hdnempid.Value + "");
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

                string oldValue = this._LoanDAO.CRUDLog(GetLoanId().ToString());
                this._LoanDAO.LogJobHistoryReport("Delete", "Donations", GetLoanId().ToString(), oldValue, "", ReadSession().UserId);

                _LoanDAO.Deleteloan(GetLoanId(), ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListLoan.aspx?Id=" + hdnempid.Value + "");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void TxtNoOfInstallments_TextChanged(object sender, EventArgs e)
        {
            
            if (TxtNoOfInstallments.Text!= "")
            {
                string NoInstallment = TxtNoOfInstallments.Text;
                txtRemainingInstallment.Text = NoInstallment;
            }
        }
    }
}