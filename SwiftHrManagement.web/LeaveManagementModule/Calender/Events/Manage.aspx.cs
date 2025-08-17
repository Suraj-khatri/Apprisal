using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.LeaveCalender;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagementModule.Calender.Events
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        LeaveCalenderDAO _leaveCal = null;
        OfficialCalender _officialCal = null;
        public Manage()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._leaveCal = new LeaveCalenderDAO();
            this._officialCal = new OfficialCalender();
        }
        private long GetLeaveCalenderId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void PrepareCalender()
        {
            OfficialCalender _cal = new OfficialCalender();
            long Id = GetLeaveCalenderId();
            if (Id > 0)
            {
                _cal.Id = Id;
            }
            _cal.Date = this.TxtDate.Text;
            _cal.Description = this.TxtDescription.Text;
            _cal.Title = this.TxtLeaveTitle.Text;
            _cal.Venue = TxtVenue.Text;
            _cal.BranchId = DdlBranch.Text;
            _cal.Type = "E";
            this._officialCal = _cal;
        }
        private void Prepareddl()
        {
            clsDAO CLsDAo = new clsDAO();
            CLsDAo.CreateDynamicDDl(DdlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }

        private void ManageCalender()
        {
            long Id = this.GetLeaveCalenderId();
            this.PrepareCalender();
            if (Id > 0)
            {
                this._officialCal.ModifyBy = this.ReadSession().UserId;
                this._leaveCal.Update(_officialCal);
            }
            else
            {
                this._officialCal.CreatedBy = this.ReadSession().UserId;
                this._leaveCal.Save(_officialCal);
            }
        }
        private void PopulateCalander()
        {
            _officialCal = this._leaveCal.FindEventById(GetLeaveCalenderId());
            TxtDate.Text = _officialCal.Date;
            TxtDescription.Text = _officialCal.Description;
            TxtLeaveTitle.Text = _officialCal.Title;
            TxtVenue.Text = _officialCal.Venue;
            DdlBranch.Text = _officialCal.BranchId;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 26) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                Prepareddl();
                if (this.GetLeaveCalenderId() > 0)
                {
                    this.BtnDelete.Visible = true;
                    PopulateCalander();
                }
                else
                {
                    this.BtnDelete.Visible = false;
                }
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageCalender();
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this._leaveCal.DeleteById(this.GetLeaveCalenderId(), ReadSession().UserId);
                Response.Redirect("List.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
