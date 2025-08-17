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
using System.Data;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageLoanCollection : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        LoanDAO _loanDao = null;
        LoanCore _loanCore = null;
        clsDAO _clsDao = null;
        public ManageLoanCollection()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._loanDao = new LoanDAO();
            this._loanCore = new LoanCore();
            this._clsDao = new clsDAO();
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        protected long GetLoanId()
        {
            return (Request.QueryString["LoanId"] != null ? long.Parse(Request.QueryString["LoanId"].ToString()) : 0);
        }
        protected long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                long Id = this.GetId();
                populateLoanDetails();
                if (Id > 0)
                {
                    populateLoanCollection();
                    BtnDelete.Visible = true;
                    BtnSave.Visible = false;
                }
                else
                {
                    BtnSave.Visible = true;
                    BtnDelete.Visible = false;
                    hdnempid.Value = GetEmpId().ToString();
                }
                hdnempid.Value = GetEmpId().ToString();
                getemployee();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }
        private void populateLoanDetails()
        {
            DataTable dt = new DataTable();
            {
                dt = _clsDao.getDataset("select dbo.showdecimal(LOAN_AMOUNT) as loan_amount,s.DETAIL_TITLE as loan_type from Loan l inner join "
                +" StaticDataDetail s on l.LOAN_TYPE=s.ROWID where l.ID="+filterstring(GetLoanId().ToString())+"").Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                loanType.Text = dr["loan_type"].ToString();
                loan_amount.Text = dr["loan_amount"].ToString();
            }
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }
        private void populateLoanCollection()
        {
            DataTable dt = new DataTable();
            {
                dt = _clsDao.getDataset("SELECT paid_amount,convert(varchar,paid_date,101) as paid_date,narration FROM loan_collection "
                +" where id=" + filterstring(GetId().ToString()) + "").Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                txtPaidAmount.Text = dr["paid_amount"].ToString();
                txtPaidDate.Text = dr["paid_date"].ToString();
                txtNarration.Text = dr["narration"].ToString();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {                
                string totPaidAmt=_clsDao.GetSingleresult("select sum(isnull(paid_amount,0)) from loan_collection where loan_id="+filterstring(GetLoanId().ToString())+"");
                if (totPaidAmt == "")
                {
                    totPaidAmt = "0";
                }
                if((Double.Parse(totPaidAmt)+Double.Parse(txtPaidAmount.Text))>Double.Parse(loan_amount.Text))
                {
                    LblMsg.Text="Total paid amount can not be more than loan taken amount!";
                    LblMsg.ForeColor=System.Drawing.Color.Red;
                }
                else
                {
                   string RowId =  _clsDao.GetSingleresult("Exec procManageLoanCollection 'i',"+filterstring(GetLoanId().ToString())+"," + filterstring(txtPaidAmount.Text) + "," + filterstring(txtPaidDate.Text) + "," + filterstring(txtNarration.Text) + ","+filterstring(ReadSession().Emp_Id.ToString())+"");
                    
                    string newValue = this._loanDao.CRUDLog(RowId,'y');
                    this._loanDao.LogJobHistoryReport("Insert", "loan_collection", RowId, "", newValue, ReadSession().UserId);
                    Response.Redirect("ListLoanCollection.aspx?Id=" + GetLoanId() + "&EmpId=" + GetEmpId() + "");

                }                
            }
            catch
            {
                LblMsg.Text = "Error In Insertion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string oldValue = this._loanDao.CRUDLog(GetId().ToString(),'y');
            this._loanDao.LogJobHistoryReport("Delete", "loan_collection", GetId().ToString(), oldValue, "", ReadSession().UserId);

            _clsDao.runSQL("Exec procManageLoanCollection 'd'," + filterstring(GetId().ToString()) + ",null,null,null,null");
            Response.Redirect("ListLoanCollection.aspx?Id=" + GetLoanId() + "&EmpId=" + GetEmpId() + "");
        }
        
    }
}
