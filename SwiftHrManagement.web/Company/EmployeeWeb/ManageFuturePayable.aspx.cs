using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PayableDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BenefitsDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageFuturePayable1 :BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        PayableDAO _payableDAO = null;
        PayableCore _payableCore = null;
        BenefitsCore _benefitsCore = null;
        clsDAO swift = new clsDAO();
        public ManageFuturePayable1()
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
            
            swift.setDDL(ref ddlBenefitName, "Exec ProcStaticDataView 'm',@mul_typeid='41'", "ROWID", "DETAIL_TITLE", selectValue, "Select...");
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        private string Getfiscalyear()
        {
            string fy_id = "";
            fy_id = swift.GetSingleresult("select FISCAL_YEAR_NEPALI from fiscalYear where flag=1");
            return fy_id;
        }
        private long GetPayableId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void PopulatePayable()
        {
            this._payableCore = this._payableDAO.FindFutureById(this.GetPayableId());
            this.ddlBenefitName.Text = this._payableCore.BenefitId;
            this.TxtAmount.Text = this._payableCore.Amount.ToString();
            this.hdnEmployeeId.Value = this._payableCore.EmployeeId;   
        }
        private void ManagePay()
        {


            if (GetPayableId() > 0)
            {
                string oldValue = _payableDAO.CRUDFutLog(GetPayableId().ToString());

                swift.runSQL("Exec procManageFuturePayable @flag='u',@emp_id=" + filterstring(hdnEmployeeId.Value) + ",@benifit_id=" + filterstring(ddlBenefitName.Text) + ""
                    + " ,@amount=" + filterstring(TxtAmount.Text) + ",@row_id= " + filterstring(GetPayableId().ToString()) + " ,@user=" + filterstring(ReadSession().UserId) + "");

                string newValue = this._payableDAO.CRUDFutLog(GetPayableId().ToString());
                this._payableDAO.LogJobHistoryReport("update", "FuturePayable", GetPayableId().ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
                string RowId = swift.GetSingleresult("Exec procManageFuturePayable @flag='i',@emp_id=" + filterstring(hdnEmployeeId.Value) + ",@benifit_id=" + filterstring(ddlBenefitName.Text) + ""
                  + " ,@amount=" + filterstring(TxtAmount.Text) + ",@user=" + filterstring(ReadSession().UserId) + "");

                string newValue = this._payableDAO.CRUDFutLog(RowId);
              this._payableDAO.LogJobHistoryReport("Insert", "FuturePayable", ID.ToString(), "", newValue, ReadSession().UserId);
            }
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
                    BtnDelete.Visible = false;
                }                
                getemployee();
            }
            TxtAmount.Attributes.Add("OnBlur", "checknumber(this);");
        }
        private bool checkmultiple()
        {
            return _payableDAO.checkmultipleFuture(long.Parse(hdnEmployeeId.Value), long.Parse(ddlBenefitName.Text), Getfiscalyear());
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GetPayableId() > 0)
            {
                try
                {
                    ManagePay();
                    lblTransactionMessage.Text = "Operation Completed Successfully";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("/Company/EmployeeWeb/ListFuturePayable.aspx?Id=" + hdnEmployeeId.Value + "");
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                if (checkmultiple() == true)
                {
                    lblTransactionMessage.Text = "Benifit Already Exists";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    try
                    {
                        ManagePay();
                        lblTransactionMessage.Text = "Operation Completed Successfully";
                        lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                        Response.Redirect("/Company/EmployeeWeb/ListFuturePayable.aspx?Id=" + hdnEmployeeId.Value + "");
                    }
                    catch
                    {
                        lblTransactionMessage.Text = "Error In Operation";
                        lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }            
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnEmployeeId.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string oldValue = this._payableDAO.CRUDFutLog(GetPayableId().ToString());
                this._payableDAO.LogJobHistoryReport("Delete", "FuturePayable", GetPayableId().ToString(), oldValue, "", ReadSession().UserId);

                swift.runSQL("Exec procManageFuturePayable 'd',null,null"
                  + " ,null," + filterstring(GetPayableId().ToString()) + "," + filterstring(ReadSession().UserId) + "");
                Response.Redirect("/Company/EmployeeWeb/ListFuturePayable.aspx?Id=" + hdnEmployeeId.Value + "");
            }
            catch
            {
                lblTransactionMessage.Text = "Error in operaton";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
