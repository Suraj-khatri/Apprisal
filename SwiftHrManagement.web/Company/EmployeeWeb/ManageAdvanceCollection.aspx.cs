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
using System.Data;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageAdvanceCollection : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        AdvanceDAO _advanceDao = null;
        AdvanceCore _advanceCore = null;
        clsDAO _clsDao = null;
        public ManageAdvanceCollection()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._advanceDao = new AdvanceDAO();
            this._advanceCore = new AdvanceCore();
            this._clsDao = new clsDAO();
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        protected long GetAdvanceId()
        {
            return (Request.QueryString["AdvanceId"] != null ? long.Parse(Request.QueryString["AdvanceId"].ToString()) : 0);
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
                populateAdvanceDetails();
                if (Id > 0)
                {
                    populateAdvanceCollection();
                    //BtnDelete.Visible = true;
                }
                else
                {
                    //BtnDelete.Visible = false;
                    hdnempid.Value = GetEmpId().ToString();
                }
                hdnempid.Value = GetEmpId().ToString();
                getemployee();
                BtnCancel.Attributes.Add("onclick", "history.back();return false");
            }
        }
        private void populateAdvanceDetails()
        {
            this._advanceCore = this._advanceDao.FindAdvanceDetails(GetAdvanceId());
            lblAdvanceType.Text = _advanceCore.Advance_type;
            lblAdvanceAmt.Text = _advanceCore.Amount.ToString();
            lblDateTaken.Text = _advanceCore.Date_Taken;
            lblDeductionAmt.Text = _advanceCore.Deduction_amt.ToString();
            lblDeducationStartDate.Text = _advanceCore.Deduction_start_date;
            lblIsFullyPaid.Text = _advanceCore.FullyPaid;
            lblRemainBalance.Text = _advanceCore.Remaining_bal.ToString();
            lblDeductionFrequency.Text = _advanceCore.DeductionFrequency;
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
            //LblEmpName.Text = _empcore.EmpName;
        }
        private void populateAdvanceCollection()
        {
            DataTable dt = new DataTable();
            long id = GetId();
            if (id > 0)
            {
                dt = _clsDao.getDataset("SELECT ID,ADVANCE_ID,PAID_AMOUNT,convert(varchar,PAID_DATE,101) as PAID_DATE,NARRATION FROM AdvanceCollection where ID=" + id + "").Tables[0];
            }
            foreach (DataRow dr in dt.Rows)
            {
                txtPaidAmount.Text = dr["PAID_AMOUNT"].ToString();
                txtPaidDate.Text = dr["PAID_DATE"].ToString(); 
                txtNarration.Text = dr["NARRATION"].ToString();
                BtnSave.Visible = false;
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(txtPaidAmount.Text) > double.Parse(lblRemainBalance.Text))
                {
                    LblMsg.Text = "Total advance paid can not be more than total advance taken!";
                    LblMsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                   string RowId =  _clsDao.GetSingleresult("Exec procManageAdvanceCollection 'i'," + filterstring(GetAdvanceId().ToString()) + "," + filterstring(txtPaidAmount.Text) + ","
                    +" " + filterstring(txtPaidDate.Text) + "," + filterstring(txtNarration.Text) + "," + filterstring(ReadSession().UserId) + "");
                   string newValue = this._advanceDao.CRUDLog(RowId, 'y');
                   this._advanceDao.LogJobHistoryReport("Insert", "AdvanceCollection", ID.ToString(), "", newValue, ReadSession().UserId);
                    Response.Redirect("/Company/EmployeeWeb/ListAdvanceCollection.aspx?EmpId=" + hdnempid.Value + "&Id="+GetAdvanceId()+"");
                }
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}
