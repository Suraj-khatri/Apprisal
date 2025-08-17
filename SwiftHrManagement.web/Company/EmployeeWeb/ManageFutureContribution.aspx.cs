using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.ContributionDAO;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageFutureContribution : BasePage
    {
        ContributionDAO _contriDao = new ContributionDAO();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetContributionId() > 0)
                {
                    hdnEmployeeId.Value = GetEmpId().ToString();
                    PopulateDataById();
                }
                else
                {
                    hdnEmployeeId.Value = GetEmpId().ToString();
                    BtnDelete.Visible = false;
                }
            }
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }

        private long GetContributionId()
        {
            return Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"]) : 0;
        }

        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        private void PopulateDataById()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getTable("Exec procManageFutureContributionForTax @flag='s',@id=" + filterstring(GetContributionId().ToString()));
            DataRow dr = dt.Rows[0];
            TxtAmount.Text = ShowDecimal(dr["Amount"].ToString());
            TxtDate.Text = dr["Contribution_Date"].ToString();
            TxtRemarks.Text = dr["Remarks"].ToString();
            ChkInactive.Checked = GetCharToBool(dr["Inactive"].ToString());
            hdnEmployeeId.Value = dr["Employee_Id"].ToString();
        }

        private void ManagePay()
        {
            if (GetContributionId() > 0)
            {
                string oldValue = _contriDao.CRUDFutLog(GetContributionId().ToString());

                _clsDao.runSQL("Exec procManageFutureContributionForTax @flag='u',@emp_id=" + filterstring(hdnEmployeeId.Value) + ",@contri_date=" + filterstring(TxtDate.Text) + ",@remarks=" + filterstring(TxtRemarks.Text)
                    + " ,@amount=" + filterstring(TxtAmount.Text) + ",@inactive=" +filterstring(GetBoolToChar(ChkInactive.Checked)) + ",@id= " + filterstring(GetContributionId().ToString()) + " ,@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

                string newValue = this._contriDao.CRUDFutLog(GetContributionId().ToString());
                this._contriDao.LogJobHistoryReport("update", "FutureContributionForTax", GetContributionId().ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {
                string RowId = _clsDao.GetSingleresult("Exec procManageFutureContributionForTax @flag='i',@emp_id=" + filterstring(hdnEmployeeId.Value) + ",@contri_date=" + filterstring(TxtDate.Text) + ",@remarks=" + filterstring(TxtRemarks.Text)
                    + " ,@amount=" + filterstring(TxtAmount.Text) + ",@inactive=" + filterstring(GetBoolToChar(ChkInactive.Checked)) + " ,@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

                string newValue = this._contriDao.CRUDFutLog(RowId);
                this._contriDao.LogJobHistoryReport("Insert", "FutureContributionForTax", ID.ToString(), "", newValue, ReadSession().UserId);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ManagePay();
            if(GetContributionId() > 0)
            {
                try
                {
                    lblTransactionMessage.Text = "Record Updated Successfully.";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("/Company/EmployeeWeb/ListFutureContribution.aspx?Id=" + GetEmpId());
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                try
                {
                    lblTransactionMessage.Text = "Record Inserted Successfully.";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Green;
                    Response.Redirect("/Company/EmployeeWeb/ListFutureContribution.aspx?Id=" + GetEmpId());
                }
                catch
                {
                    lblTransactionMessage.Text = "Error In Operation";
                    lblTransactionMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}
