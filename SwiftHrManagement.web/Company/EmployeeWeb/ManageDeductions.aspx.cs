using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.DeductionsDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageDeductions : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        DeductionsDAO _deductionsDao = null;
        DeductionsCore _deductionsCore = null;
        
        public ManageDeductions()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._deductionsDao = new DeductionsDAO();
            this._deductionsCore = new DeductionsCore();
        }

        private long GetDeductionId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PopulateDeduction()
        {
            DateTime deductiondate;
            this._deductionsCore = this._deductionsDao.FindById(this.GetDeductionId());
            this.DdlDeduction.Text = this._deductionsCore.DeductionName.ToString();
            deductiondate = DateTime.Parse(this._deductionsCore.DeductionDate);
            this.TxtDeductionDate.Text = deductiondate.ToString("MM/dd/yyyy");
            this.TxtDeductionAmount.Text = this._deductionsCore.DeductionAmount.ToString();
            this.hdnempid.Value = this._deductionsCore.EmployeeId;
            ChkTaxable.Checked = _deductionsCore.Istaxable;
        }

        private void populateDdlAdvance()
        {
            string selectValue = "";
            if (DdlDeduction.SelectedItem != null)
                selectValue = DdlDeduction.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref DdlDeduction, "Exec ProcStaticDataView 's','40'", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
        }

        private void ManageDed()
        {
            DeductionsCore _dedCore = new DeductionsCore();
            long id = this.GetDeductionId();
            long dedId = this.GetDeductionId();
            _deductionsCore.Id = long.Parse(dedId.ToString());
            _deductionsCore.DeductionName = DdlDeduction.Text;
            _deductionsCore.DeductionDate = TxtDeductionDate.Text;
            _deductionsCore.DeductionAmount = Double.Parse(TxtDeductionAmount.Text);
            _deductionsCore.EmployeeId = this.hdnempid.Value;
            if (ChkTaxable.Checked == true)
            {
                _deductionsCore.Istaxable = true;
            }
            else
            {
                _deductionsCore.Istaxable = false;
            }
            if (dedId > 0)
            {
               
                this._deductionsDao.Update(this._deductionsCore);
            }
            else
            {
                this._deductionsDao.Save(this._deductionsCore);
            }
            this._deductionsCore = _dedCore;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetDeductionId();
                populateDdlAdvance();
                if (Id > 0)
                {
                    PopulateDeduction();
                }
                if (Id == 0)
                {
                    hdnempid.Value = (ReadSession().TempEmpId).ToString();
                }
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                getemployee();
            }
        }

        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            LblEmpName.Text = _empcore.EmpName;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageDed();
                LblMsg.Text = "Operation Completed Successfully";
                LblMsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("/Company/EmployeeWeb/ListDeductions.aspx?Id="+hdnempid.Value+"");
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
                _deductionsDao.DeleteDeduction(GetDeductionId(), ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListDeductions.aspx?Id=" + hdnempid.Value + "");
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

    }
}