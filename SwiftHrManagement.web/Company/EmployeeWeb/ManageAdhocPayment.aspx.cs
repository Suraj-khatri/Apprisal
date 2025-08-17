using System;
using SwiftHrManagement.DAL.AdhocPaymentDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageAdhocPayment : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        AdhocPaymentDAO _adhocDao = null;
        AdhocPaymentCore _adhocCore = null;
        clsDAO _clsdao = null;
        public ManageAdhocPayment()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._adhocDao = new AdhocPaymentDAO();
            this._adhocCore = new AdhocPaymentCore();
            _clsdao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.PopulateDdlList();
                TxtPayableDate.Enabled = false;
                long Id = this.GetAdhocId();
                if (Id > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateAdhoc();
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

        private void PopulateDdlList()
        {
            _clsdao.setDDL(ref ddlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            _clsdao.setDDL(ref Ddlmonth, "select Month_Number,name from MonthList  ", "Month_Number", "Name", "", "Select");
        }

        public long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        private long GetAdhocId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void PopulateAdhoc()
        {
            string selectValue = "";
            this._adhocCore = this._adhocDao.FindById(this.GetAdhocId());
            this.DdlAddDeduct.Text = this._adhocCore.Add_deduct.ToString();

            if (DdlAddDeduct.Text == "D")
            {
                
                if (DdlAdhocHead.SelectedItem != null)
                    selectValue = DdlAdhocHead.SelectedItem.Value.ToString();
                _clsdao.setDDL(ref DdlAdhocHead, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID in (36,37,38,40,41)", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
            }
            else
            {
               
                if (DdlAdhocHead.SelectedItem != null)
                    selectValue = DdlAdhocHead.SelectedItem.Value.ToString();
                _clsdao.setDDL(ref DdlAdhocHead, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID in (36,37,38,41)", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
            }
            this.TxtPayableDate.Text = _adhocCore.Applied_date.ToString();                       
            this.DdlAdhocHead.Text = this._adhocCore.Head_id.ToString();            
            this.TxtPayableAmount.Text = this._adhocCore.Amount.ToString();
            this.TxtTax.Text = this._adhocCore.Tax_deduct.ToString();
            this.hdnempid.Value = this._adhocCore.EmployeeId;
            if (_adhocCore.Ispaid == "True")
                ChkPaid.Checked = true;
            else
                ChkIstaxed.Checked = false;
            if(_adhocCore.Istaxed == "True")
                ChkIstaxed.Checked = true;
            else
                ChkIstaxed.Checked = false;
            DdlAdhocHead.Text = _adhocCore.Head_id;
            TxtPayableAmount.Text = _adhocCore.Amount.ToString();
            TxtNarration.Text = _adhocCore.Narration;
            Ddlmonth.SelectedValue = this._adhocCore.App_for_Month;
            ddlYear.SelectedValue = this._adhocCore.App_for_Year;


        }

        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();          
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));      
            //LblName.Text = _empcore.EmpName;
        }

        private void ManageAdhoc()
        {
            AdhocPaymentCore _adhCore = new AdhocPaymentCore();      
            long id = this.GetAdhocId();
            _adhocCore.Id = long.Parse(id.ToString());
            _adhocCore.Add_deduct = DdlAddDeduct.Text;
            if (DdlAddDeduct.Text == "D")
            {
                _adhocCore.Tax_deduct = 0;
                
            }
            else
            {
                _adhocCore.Tax_deduct = Double.Parse(TxtTax.Text);
            }
            _adhocCore.Head_id = DdlAdhocHead.Text;
            _adhocCore.Applied_date = (TxtPayableDate.Text);
            _adhocCore.Amount = Double.Parse(TxtPayableAmount.Text);

           
            if (ChkPaid.Checked == true)
                _adhocCore.Ispaid = "True";
            else
                _adhocCore.Ispaid = "False";
            if (ChkIstaxed.Checked == true)
                _adhocCore.Istaxed = "True";
            else
                _adhocCore.Istaxed = "False";
            _adhocCore.Narration = TxtNarration.Text;
           // _adhocCore.Tax_deduct = double.Parse(TxtTax.Text);
            if (id > 0)
            {
                string oldValue = this._adhocDao.CRUDLog(id.ToString());

                _adhocCore.EmployeeId = this.hdnempid.Value;
                _adhocCore.ModifyBy = ReadSession().UserId;
                _adhocCore.ModifyDate = _adhocCore.ModifyDate;
                this._adhocDao.Update(this._adhocCore);

                 string newValue = this._adhocDao.CRUDLog(id.ToString());
                 this._adhocDao.LogJobHistoryReport("update", "AdhocPayment", id.ToString(), oldValue, newValue, _adhocCore.ModifyBy);
            }
            
            else
            {
                _adhocCore.EmployeeId = hdnempid.Value;
                _adhocCore.CreatedBy = ReadSession().UserId;
                _adhocCore.CreatedDate = _adhocCore.CreatedDate;
                this._adhocDao.Save(this._adhocCore);


                string Rowid = this._adhocCore.Id.ToString();
                string newValue = this._adhocDao.CRUDLog(Rowid);
                this._adhocDao.LogJobHistoryReport("Insert", "AdhocPayment", Rowid, "", newValue, ReadSession().UserId);
            }
            this._adhocCore = _adhCore;
        }

        private void PopulatePaymentAdhocHeadForAdd()
        {
            string selectValue = "";
            if (DdlAdhocHead.SelectedItem != null)
                selectValue = DdlAdhocHead.SelectedItem.Value.ToString();
            _clsdao.setDDL(ref DdlAdhocHead, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID in (36,37,38,41,40)", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
        }

        private void PopulatePaymentAdhocHeadForDeduct()
        {
            string selectValue = "";
            if (DdlAdhocHead.SelectedItem != null)
                selectValue = DdlAdhocHead.SelectedItem.Value.ToString();
            _clsdao.setDDL(ref DdlAdhocHead, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID in (36,37,38,40,41)", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (ChkPaid.Checked == true && TxtPayableDate.Text == "")
            {
                LblMsg.Text = "Applied date is mendatory for applied";
                TxtPayableDate.Focus();
                return;
            }
            try
            {
                ManageAdhoc();
                LblMsg.Text = "Operation Completed Successfully";
                LblMsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("/Company/EmployeeWeb/ListAdhocPayment.aspx?Id=" + hdnempid.Value + "&EmpId=" + GetEmpId() +"");
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
                string oldValue = this._adhocDao.CRUDLog(GetAdhocId().ToString());
                this._adhocDao.LogJobHistoryReport("Delete", "AdhocPayment", GetAdhocId().ToString(), oldValue, "", ReadSession().UserId);

                _adhocDao.deleteAdhoc(this.GetAdhocId(), ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListAdhocPayment.aspx?Id="+hdnempid.Value+"");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void DdlAddDeduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlAddDeduct.SelectedItem.Value == "A")
            {
                DdlAdhocHead.Items.Clear();
                PopulatePaymentAdhocHeadForAdd();
                ChkIstaxed.Enabled = false;
                TxtTax.Enabled = true;
            }
            if (DdlAddDeduct.SelectedItem.Value == "D")
            {
                DdlAdhocHead.Items.Clear();
                ChkIstaxed.Enabled = true;
                TxtTax.Enabled = false;
                PopulatePaymentAdhocHeadForDeduct();
            }
        }

        protected void ChkPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPaid.Checked == true)
            {
                TxtPayableDate.Text = "";
                TxtPayableDate.Enabled = true;

                if (ddlYear.SelectedValue == "Select" || ddlYear.SelectedValue == "")
                {
                    LblMsg.Text = "Please enter Applied for Year! ";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Ddlmonth.SelectedValue == "Select" || Ddlmonth.SelectedValue == "")
                {
                    LblMsg.Text = "Please enter Applied for Year! ";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }
            else
            {
                TxtPayableDate.Text = "";
                TxtPayableDate.Enabled = false;
            }

           
        }

  
    }
}