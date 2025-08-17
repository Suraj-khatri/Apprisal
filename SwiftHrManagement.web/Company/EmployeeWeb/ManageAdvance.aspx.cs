using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.AdvanceDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageAdvance : BasePage
    {
        clsDAO swift = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        AdvanceDAO _advanceDao = null;
        AdvanceCore _advanceCore = null;
  
        public ManageAdvance()
        {
            this.swift=new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._advanceDao = new AdvanceDAO();
            this._advanceCore = new AdvanceCore();
           
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetAdvanceId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateAdvance()
        {
            this._advanceCore = this._advanceDao.FindById(this.GetAdvanceId());
            TxtAmount.Text = _advanceCore.Amount.ToString();         
            TxtDateTaken.Text = _advanceCore.Date_Taken;
            DdlAdvanceType.Text = _advanceCore.Advance_type;
            hdnempid.Value = _advanceCore.Employee_Id;
            TxtDeductionAmt.Text = _advanceCore.Deduction_amt.ToString();           
            TxtDeductionStartdate.Text = _advanceCore.Deduction_start_date.ToString();
            txtNarration.Text = _advanceCore.Narration;
            DdlDeductionFrequency.Text = _advanceCore.DeductionFrequency;
            txtLedgerCode.Text = _advanceCore.LedgerCode;
            DdlNextRunMonth.SelectedValue = _advanceCore.NextRunMonth;
            Chkfullypaid.Enabled = true;
            if (_advanceCore.Isfullypaid == true)
            {
                disabledForms();
            }
            Chkfullypaid.Checked = _advanceCore.Isfullypaid;
        }
        private void disabledForms()
        {
            BtnDelete.Visible = false;
            BtnSave.Visible = false;
            TxtAmount.Enabled = false;
            TxtDateTaken.Enabled = false;
            DdlAdvanceType.Enabled = false;
            TxtDeductionAmt.Enabled = false;
            TxtDeductionStartdate.Enabled = false;
            txtNarration.Enabled = false;
            DdlDeductionFrequency.Enabled = false;
            txtLedgerCode.Enabled = false;
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();      
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));        
            //LblEmpName.Text = _empcore.EmpName;
        }
        private void SaveAdvanceDetail()
        {
             AdvanceCore _insCore = new AdvanceCore();
            _advanceCore.Id = GetAdvanceId();
            _advanceCore.Amount = Double.Parse(TxtAmount.Text);
            _advanceCore.Remaining_bal = Double.Parse(TxtAmount.Text);
            _advanceCore.Date_Taken = TxtDateTaken.Text;
            _advanceCore.Advance_type = DdlAdvanceType.Text;
            _advanceCore.Deduction_amt = double.Parse(TxtDeductionAmt.Text);
            _advanceCore.Deduction_start_date = TxtDeductionStartdate.Text;
            _advanceCore.Narration = txtNarration.Text;
            _advanceCore.DeductionFrequency = DdlDeductionFrequency.Text;
            _advanceCore.LedgerCode = txtLedgerCode.Text;
            _advanceCore.NextRunMonth = DdlNextRunMonth.Text;
            _advanceCore.Employee_Id = hdnempid.Value;
            if (Chkfullypaid.Checked == true)
                _advanceCore.Isfullypaid = true;
            else
                this._advanceCore.Isfullypaid = false;

            if (GetAdvanceId() > 0)
            {
             
                this._advanceCore.ModifyBy = this.ReadSession().UserId;
                string oldValue = this._advanceDao.CRUDLog(GetAdvanceId().ToString());
                this._advanceDao.Update(this._advanceCore);
                string newValue = this._advanceDao.CRUDLog(GetAdvanceId().ToString());
                  this._advanceDao.LogJobHistoryReport("update", "Advance",GetAdvanceId().ToString(), oldValue, newValue,ReadSession().UserId);
                     
            }
            else
            {
                this._advanceCore.CreatedBy = this.ReadSession().UserId;
                this._advanceDao.Save(this._advanceCore);

                string Rowid = this._advanceCore.Id.ToString();
                string newValue = this._advanceDao.CRUDLog(Rowid);
                this._advanceDao.LogJobHistoryReport("Insert", "Advance", Rowid, "", newValue, ReadSession().UserId);
             
            }
            this._advanceCore = _insCore;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateDdlAdvance();
                populateDdlFrequency();
                PopulateMonthList();
                long Id = this.GetAdvanceId();
                if (Id > 0)
                {
                    PopulateAdvance();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                    hdnempid.Value = GetEmpId().ToString();
                }
                getemployee();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }
        private void PopulateMonthList()
        {
            string selectValue = "";
            if (DdlNextRunMonth.SelectedItem != null)
                selectValue = DdlNextRunMonth.SelectedItem.Value.ToString();          
            swift.setDDL(ref DdlNextRunMonth, "SELECT Month_Number,Name FROM MonthList", "Month_Number", "Name", "selectValue", "Select");
        }
        private void populateDdlAdvance()
        {
            string selectValue = "";
            if (DdlAdvanceType.SelectedItem != null)
                selectValue = DdlAdvanceType.SelectedItem.Value.ToString();       
            swift.setDDL(ref DdlAdvanceType, "Exec ProcStaticDataView 's','35'", "ROWID", "DETAIL_TITLE", "selectValue", "Select");
        }
        private void populateDdlFrequency()
        {
            string selectValue = "";
            if (DdlDeductionFrequency.SelectedItem != null)
                selectValue = DdlDeductionFrequency.SelectedItem.Value.ToString();            
            swift.setDDL(ref DdlDeductionFrequency, "Exec ProcStaticDataView 's','53'", "ROWID", "DETAIL_TITLE", "selectValue", "Select");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAdvanceDetail();
           }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void ManageAdvanceDetail()
        {                
            SaveAdvanceDetail();
            Response.Redirect("/Company/EmployeeWeb/ListAdvance.aspx?Id=" + hdnempid.Value + "");                     
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string oldValue = this._advanceDao.CRUDLog(GetAdvanceId().ToString());
                this._advanceDao.LogJobHistoryReport("Delete", "Advance", GetAdvanceId().ToString(), oldValue, "", ReadSession().UserId);

                _advanceDao.DeleteAdvance(GetAdvanceId(), ReadSession().UserId);
                 Response.Redirect("/Company/EmployeeWeb/ListAdvance.aspx?Id="+hdnempid.Value+"");
            }
            catch
            {
                LblMsg.Text = "error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {

        }
        protected void Chkfullypaid_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ListAdvance.aspx");
        }
    }
}