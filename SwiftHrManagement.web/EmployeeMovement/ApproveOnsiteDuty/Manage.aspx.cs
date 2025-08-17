using System;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.OnSiteDuty;
using System.Text;
using System.Data;

namespace SwiftHrManagement.web.EmployeeMovement.ApproveOnsiteDuty
{
    public partial class Manage : BasePage
    {
        private ClsDAOInv _clsDaoInv = null;
        private RoleMenuDAOInv _roleMenuDaoInv = null;
        onSiteDutyAssignmentCore _onSiteDuty = null;
        onSiteDutyAssignmentDAO _onSiteDutyDao = null;
        public Manage()
        {
           this._clsDaoInv = new ClsDAOInv();
           this._roleMenuDaoInv = new RoleMenuDAOInv(); 
           this._onSiteDutyDao = new onSiteDutyAssignmentDAO();
           this._onSiteDuty = new onSiteDutyAssignmentCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDaoInv.hasAccess(ReadSession().AdminId, 39) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                populateOnSiteDuty();
                OnDisplayRpt();
                approvedDate.Visible = false;
            }
        }

        private long GetDutyID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void populateOnSiteDuty()
        {

            _onSiteDuty = this._onSiteDutyDao.FindallById(this.GetDutyID());
            this.lblEmpId.Text = _clsDaoInv.GetSingleresult("select FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME+' '+'-'+' '+ EMP_CODE+'('+' '+b.BRANCH_NAME+' '+')'+ '|'  + CONVERT(varchar, e.EMPLOYEE_ID) as employee_details from Employee e"
                 + " inner join Branches b on b.BRANCH_ID=e.BRANCH_ID where  e.EMPLOYEE_ID=" + _onSiteDuty.EmpId.ToString() + "");

            //this.lblDateFrom.Text = _onSiteDuty.SiteDateFrom;
            //this.lblDateTo.Text = _onSiteDuty.SiteDateTo;
            //this.lblLocation.Text = _onSiteDuty.SiteLocation;
            //this.lblPurpose.Text = _onSiteDuty.Purpose;
            this.lblDesc.Text = _onSiteDuty.Description;
            this.lblApproveBy.Text = _clsDaoInv.GetSingleresult("select rtrim(dbo.GetEmployeeInfoById(" + _onSiteDuty.ApproveBy.ToString() + "))").ToString();
            this.lblApprovedDate.Text = _onSiteDuty.ApprovedDate;
            this.txtAppRemarks.Text = _onSiteDuty.ApprovedRemarks;

            if (_onSiteDuty.Status =="Approved")
            {
                Btn_Approve.Visible = false;
                lblApprovedDate.Visible = true;
            }

            HiddenEmpid.Value = _onSiteDuty.EmpId.ToString();
        }

        protected void PrepareData()
        {
            onSiteDutyAssignmentCore _onSiteDuty = new onSiteDutyAssignmentCore();

            long id = this.GetDutyID();

            _onSiteDuty.OnsiteID = int.Parse(id.ToString());
            _onSiteDuty.ModifyBy = ReadSession().UserId.ToString();
            _onSiteDuty.ApprovedRemarks = this.txtAppRemarks.Text;

            this._onSiteDuty = _onSiteDuty;
        }

        protected void ApproveOnsiteDuty()
        {
            PrepareData();
            long Id = GetDutyID();
            this._onSiteDutyDao.Approve(_onSiteDuty);
        }

        protected void Btn_Approve_Click(object sender, EventArgs e)
        {
            try
            {
                this.ApproveOnsiteDuty();
                Response.Redirect("list.aspx?");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        private void OnDisplayRpt()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            dt = _clsDaoInv.getDataset("Exec procOnSiteDuty @flag = 'DisplayA', @osd_id = " + filterstring(GetDutyID().ToString()) + "").Tables[0];

            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");

                for (int i = 1; i < ColumnsCount; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td nowrap='nowrap'>" + dr[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td nowrap='nowrap'>" + dr[i] + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            osdRpt.InnerHtml = str.ToString();
        }
    }
}