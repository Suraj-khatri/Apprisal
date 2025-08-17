using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.InsurancePremiumDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.InsuranceDAO;
namespace SwiftHrManagement.web.Company.EmployeeWeb
    
{
    public partial class ManageInsurancePremium : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        InsurancePremiumCore _ipCore = null;
        InsurancePremiumDAO _ipDAO = null;
        clsDAO swift = null;

        public ManageInsurancePremium()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._ipCore = new InsurancePremiumCore();
            this._ipDAO = new InsurancePremiumDAO();
            this.swift = new clsDAO();
        }
        private long GetPremiumId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        protected long GetInsuranceId()
        {
            return (Request.QueryString["Insurance_Id"] != null ? long.Parse(Request.QueryString["Insurance_Id"].ToString()) : 0);
        }
        private void PopulatePremium()
        {
            this._ipCore = _ipDAO.FindById(GetPremiumId());          
            this.TxtPaidAmount.Text = _ipCore.PaymentAmount.ToString();
            this.TxtPaidDate.Text = _ipCore.PaymentDate.ToString();
            this.TxtPaidReceiptNumber.Text = _ipCore.ReceiptNumber;
            this.txtInsurancePolicy.Text = _ipCore.InsurancePolicy;
            this.txtUnpaidAmt.Text = _ipCore.UnpaidAmount;
            this.hdnInsuranceId.Value = _ipCore.InsuranceId;
        }
        private void ManagePremium()
        {
            this.PreparePremium();
            if (GetPremiumId() > 0)
            {
                string oldValue = _ipDAO.CRUDLog(GetPremiumId().ToString());
                swift.runSQL("Exec procInsurancePremimum 'u', " + filterstring(hdnInsuranceId.Value) + "," + TxtPaidAmount.Text + "," + filterstring(TxtPaidDate.Text) + "," + filterstring(TxtPaidReceiptNumber.Text) + "," + filterstring(GetPremiumId().ToString()) + "," + filterstring(ReadSession().UserId) + "");
                string newValue = this._ipDAO.CRUDLog(GetPremiumId().ToString());
                this._ipDAO.LogJobHistoryReport("update", "InsurancePremium", GetPremiumId().ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
              string ID =   swift.GetSingleresult("Exec procInsurancePremimum 'i', " + filterstring(hdnInsuranceId.Value) + "," + TxtPaidAmount.Text + "," + filterstring(TxtPaidDate.Text) + "," + filterstring(TxtPaidReceiptNumber.Text) + "," + filterstring(GetPremiumId().ToString()) + "," + filterstring(ReadSession().UserId) + "");
                string newValue = this._ipDAO.CRUDLog(ID.ToString());
                this._ipDAO.LogJobHistoryReport("Insert", "InsurancePremium", ID.ToString(), "", newValue, ReadSession().UserId);
            }
        }

        private void PreparePremium()
        {
            InsurancePremiumCore _insPremCore = new InsurancePremiumCore();
            long premiumId = this.GetPremiumId();

            _insPremCore.Id = long.Parse(premiumId.ToString());
            _insPremCore.InsuranceId = GetInsuranceId().ToString();
            _insPremCore.PaymentAmount = Double.Parse(TxtPaidAmount.Text);
            _insPremCore.PaymentDate = TxtPaidDate.Text;
            _insPremCore.ReceiptNumber = TxtPaidReceiptNumber.Text;
            this._ipCore = _insPremCore;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetPremiumId();
                if (Id > 0)
                {
                    PopulatePremium();
                    BtnDelete.Visible = true;
                }
                else
                {
                    hdnInsuranceId.Value = GetInsuranceId().ToString();
                    this._ipCore = _ipDAO.FindInsurancePolicyById(GetInsuranceId());                   
                    this.txtInsurancePolicy.Text = this._ipCore.InsurancePolicy;
                    this.txtUnpaidAmt.Text = this._ipCore.UnpaidAmount;
                }
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (double.Parse(txtUnpaidAmt.Text) >= double.Parse(TxtPaidAmount.Text))
            {
                try
                {
                    ManagePremium();
                    Response.Redirect("/Company/EmployeeWeb/ListInsurancePremium.aspx?Insurance_Id=" + hdnInsuranceId.Value + "&EmpId=" + GetEmpId() + "");
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblTransactionMessage.Text = "Total premium can not be more than insured amount!";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }          
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string oldValue = this._ipDAO.CRUDLog(GetPremiumId().ToString());
                //_ipDAO.DeleteInsurancePremium(GetPremiumId(), ReadSession().UserId);
                swift.runSQL("Exec procInsurancePremimum 'd',null,null,null,null," + filterstring(GetPremiumId().ToString()) + "," + filterstring(ReadSession().UserId) + "");
                this._ipDAO.LogJobHistoryReport("Delete", "InsurancePremium", GetPremiumId().ToString(), oldValue, "", ReadSession().UserId);
                Response.Redirect("/Company/EmployeeWeb/ListInsurancePremium.aspx?Insurance_Id=" + hdnInsuranceId.Value + "&EmpId=" + GetEmpId() + "");
            }
            catch
            {
                lblTransactionMessage.Text = "Error in operation";
                lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
