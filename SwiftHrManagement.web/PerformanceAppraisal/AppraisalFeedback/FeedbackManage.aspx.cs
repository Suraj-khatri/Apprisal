using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.PerformanceAppraisal;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.Feedback
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        AppraisalFeedbackCore _appraisalCore = null;
        AppraisalFeedbackDAO _appraisalFeedbackDao = null;

        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();           
            _appraisalFeedbackDao = new AppraisalFeedbackDAO();
            _appraisalCore = new AppraisalFeedbackCore();
        }  
        private void ManageAppraisal()
        {
            this.prepareAppraisal();
            if(GetFeedbackId()>0)
            {
                _appraisalCore.CreatedBy = this.ReadSession().UserId;
                _appraisalFeedbackDao.Update(this._appraisalCore);
            }
            else
            {
                _appraisalCore.CreatedBy = this.ReadSession().UserId;
                _appraisalFeedbackDao.Save(this._appraisalCore);
            }
        }
        private void populateAppraisal()
        {
            AppraisalFeedbackDetailsCore _appraisalCore = new AppraisalFeedbackDetailsCore();
            AppraisalFeedbackDAO _appraisalFeedbackDao = new AppraisalFeedbackDAO();
            _appraisalCore = _appraisalFeedbackDao.FindbyId(GetFeedbackId());
            TxtFeedback.Text = _appraisalCore.FeedbackDetails;
            hdnAppraisalId.Value = _appraisalCore.AppraisalId.ToString();
            TxtTitle.Text = _appraisalCore.AppraisalTitle;
            LblEmpName.Text = _appraisalCore.EmployeeName;
        }
        private void prepareAppraisal()
        {
            AppraisalFeedbackCore _appCore = new AppraisalFeedbackCore();
            long id = this.GetFeedbackId();
            if (id > 0)
            {
                _appCore.Id = id;
            }
            else
            {
                _appCore.AppraisalId = this.GetAppraisalId();           
            }            
            _appCore.FeedbackDetails = this.TxtFeedback.Text;      
           this._appraisalCore = _appCore;
        }
        private long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetFeedbackId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);            
        }        
        private long GetAppraisalId()
        {
            return (Request.QueryString["AppId"] != null ? long.Parse(Request.QueryString["AppId"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 27) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if(GetFeedbackId()>0)
                {
                    BtnDelete.Visible = true;
                    populateAppraisal();
                }
                else
                {
                    hdnAppraisalId.Value = GetAppraisalId().ToString();
                    BtnDelete.Visible = false;
                    populateApprTitle();
                }
            }
        }
        private void populateApprTitle()
        {           
            AppraisalFeedbackDetailsCore _apprCore = new AppraisalFeedbackDetailsCore();
            AppraisalFeedbackDAO _apprDao = new AppraisalFeedbackDAO();
            _apprCore = _apprDao.FindTitleEmpNameById(this.GetAppraisalId());          
            TxtTitle.Text = _apprCore.AppraisalTitle;
            LblEmpName.Text = _apprCore.EmployeeName;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageAppraisal();
                Response.Redirect("FeedbackList.aspx?Id=" + hdnAppraisalId.Value + "&EmpId="+GetEmpId()+"");
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
                this._appraisalFeedbackDao.DeleteAppraisalFeedback(this.GetFeedbackId().ToString());  
                Response.Redirect("FeedbackList.aspx?Id=" + hdnAppraisalId.Value+"&EmpId="+GetEmpId()+"");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("FeedbackList.aspx?Id="+hdnAppraisalId.Value+"&EmpId="+GetEmpId()+"");
        }
    }
}
