using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.AssetManagement.Depreciation
{
    public partial class depreciationUpdate : BasePage
    {        
        ClsDAOInv _clsDao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public depreciationUpdate()
        {
            _clsDao = new ClsDAOInv();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {         
            if (!IsPostBack)
            {
                populateForwardEmployee();
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 205) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (ReadSession().UserType == "A")
                {
                    _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                }
                else
                {
                    _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
                }
                _clsDao.setDDL(ref RunMonth, "Exec proc_Get_monthList_for_payroll", "month_number", "name", "", "Select");
                _clsDao.CreateDynamicDDl(RunFiscalYear, "SELECT FISCAL_YEAR_NEPALI from FiscalYear where FLAG=1", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "");

                if (GetId() > 0)
                {
                    populateDepBooking();
                }
            }
        }
        private void populateDepBooking()
        {
            DataTable dt = _clsDao.getTable("SELECT fiscal_year,run_month,branch_id,forwarded_to,status,rejection_reason "
                                            +" FROM DEPRECIATION_BOOKING_REQUEST WHERE id="+GetId()+"");
            foreach (DataRow dr in dt.Rows)
            {
                RunFiscalYear.SelectedValue = dr["fiscal_year"].ToString();
                RunMonth.SelectedValue = dr["run_month"].ToString();
                DdlBranchName.SelectedValue = dr["branch_id"].ToString();
                ddlForwardedTo.SelectedValue = dr["forwarded_to"].ToString();
                txtRejectionReason.Text = dr["rejection_reason"].ToString();
                if (dr["status"].ToString() == "Approved")
                {
                    RunFiscalYear.Enabled = false;
                    RunMonth.Enabled = false;
                    DdlBranchName.Enabled = false;
                    ddlForwardedTo.Enabled = false;
                    txtRejectionReason.Enabled = false;
                    btnGenerate.Visible = false;
                    btnDelete.Visible = false;
                }
            }         
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateForwardEmployee()
        {
            if (ReadSession().Branch_Id == 1)
            {
                _clsDao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
            else
            {
                _clsDao.CreateDynamicDDl(ddlForwardedTo, "exec proc_GetSupervisorFA @flag='a',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "", "Select");
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = _clsDao.GetSingleresult("Exec [procRequestDepreciationBooking] @flag='i',@id='"+GetId()+"',@fiscalYear=" + filterstring(RunFiscalYear.Text) + ","
                                    + " @runMonth=" + filterstring(RunMonth.Text) + ",@branchId=" + filterstring(DdlBranchName.Text) + ","
                                    + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@forwarded_to=" + filterstring(ddlForwardedTo.Text) + "");

                if (msg.Contains("SUCCESS"))
                {
                    Response.Redirect("depreciation_booking_history.aspx");
                }
                else
                {
                    lblMes.Text = msg;
                    lblMes.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch
            {
                lblMes.Text = "Error In Operation!";
                lblMes.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                _clsDao.GetSingleresult("DELETE FROM DEPRECIATION_BOOKING_REQUEST WHERE id=" + GetId() + "");
                Response.Redirect("depreciation_booking_history.aspx");
            }
            catch
            {
                lblMes.Text = "Error In Operation!";
                lblMes.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
