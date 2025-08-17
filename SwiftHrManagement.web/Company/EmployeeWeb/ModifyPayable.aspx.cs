using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.PayableDAO;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ModifyPayable : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        PayableDAO _payableDAO = null;
        PayableCore _payableCore = null;
        BenefitsCore _benefitsCore = null;
        clsDAO swift = new clsDAO();
        public ModifyPayable()
        {
            swift = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv(); 
            this._payableDAO = new PayableDAO();
            this._payableCore = new PayableCore();
            this._benefitsCore= new BenefitsCore();
        }
         private void PopulateDdlContributionBasisEmp()
        {
            string selectValue = "";
            if (ddlBenefitName.SelectedItem != null)
                selectValue = ddlBenefitName.SelectedItem.Value.ToString();
            
            swift.setDDL(ref ddlBenefitName, "Exec ProcStaticDataView 'm',@mul_typeid='36,37,38'", "ROWID", "DETAIL_TITLE", selectValue, "Select...");
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetPayableId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void PopulatePayable()
        {
            this._payableCore = this._payableDAO.FindById(this.GetPayableId());
            this.ddlBenefitName.Text = this._payableCore.BenefitId;
            this.TxtAmount.Text = this._payableCore.Amount.ToString();
            this.hdnEmployeeId.Value = this._payableCore.EmployeeId;
        }
        private void ManagePay()
        {
           
           
                string oldValue = _payableDAO.CRUDLog(GetPayableId().ToString());

                swift.runSQL("Exec procManagePayable 'u'," + filterstring(hdnEmployeeId.Value) + "," + filterstring(ddlBenefitName.Text) + ""
                    + " ," + filterstring(TxtAmount.Text) + ", " + filterstring(GetPayableId().ToString()) + " ," + filterstring(ReadSession().UserId) + "");
                
                string newValue = this._payableDAO.CRUDLog(GetPayableId().ToString());
                this._payableDAO.LogJobHistoryReport("update", "Payable", GetPayableId().ToString(), oldValue, newValue, ReadSession().UserId);
            
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 25) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetPayableId();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
                PopulateDdlContributionBasisEmp();
                if (Id > 0)
                {
                    ddlBenefitName.Enabled = false;
                    PopulatePayable();
                }
                else
                {
                    hdnEmployeeId.Value = GetEmpId().ToString();
                   
                }                
                getemployee();
            }
        }
     
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            
                try
                {
                    ManagePay();
                    lblTransactionMessage.Text = "Operation Completed Successfully";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("/Company/EmployeeWeb/ListPayable.aspx?Id=" + hdnEmployeeId.Value + "");
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
            
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnEmployeeId.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }

     
    }
}