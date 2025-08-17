using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using SwiftHrManagement.DAL.PerformanceAppraisal.Matrix;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class AppraiseeTask : BasePage
    {
        SupervisorFeedbackDAO _sfDao = new SupervisorFeedbackDAO();
        PerformanaceMatrixDao _matrix = new PerformanaceMatrixDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            //var showSaveButton = false;
            if (!IsPostBack)
            {
                ShowData();
            }
        }

        private void ShowData()
        {
            var isAppraisee = _matrix.DoesAppraiseeAccess(GetEmployeeId(), ReadSession().Emp_Id);
            hddIsAppraisee.Value = isAppraisee.ToString();
            if (isAppraisee)
            {
                //btnSave.Visible = true;
            }
            else
                txtTaskDefinition.ReadOnly = true;

            var dtRow = _matrix.AllowApprisalRating(GetAppraisalId().ToString(), GetRetingTypeId(), GetPositionId().ToString(), ReadSession().Emp_Id.ToString(), GetEmployeeId().ToString());
            bool allowSelf = dtRow["allowMarking"].ToString().Equals("TRUE") && dtRow["appraisee"].ToString().Equals("TRUE") ? true : false;
            bool allowAppriseer = dtRow["allowMarking"].ToString().Equals("TRUE") && dtRow["appraiser"].ToString().Equals("TRUE") ? true : false;
            bool allowReviewer = dtRow["allowMarking"].ToString().Equals("TRUE") && dtRow["reviewer"].ToString().Equals("TRUE") ? true : false;
            hddAllowApriseer.Value = allowAppriseer.ToString();

            //allwSelfRating.Value = allowSelf.ToString();

            if (allowSelf)
            {
                txtCommentsOnDuties.Visible = false;
                comment.Visible = false;
                //btnSave.Visible = true;
                //showSaveButton = true;
            }
            else if ((!allowSelf) && (allowAppriseer))
            {
                txtCommentsOnDuties.Visible = true;
                txtOtherAchievements.ReadOnly = true;
                comment.Visible = true;
                //btnSave.Visible = true;
                //showSaveButton = true;
            }
            else if ((!allowSelf) && (allowReviewer))
            {
                txtCommentsOnDuties.ReadOnly = true;
                txtOtherAchievements.ReadOnly = true;
                txtTaskDefinition.ReadOnly = true;
            }
            else if ((!allowSelf) && isAppraisee)
            {
                txtCommentsOnDuties.ReadOnly = true;
                //showSaveButton = true;
            }

            if (isAppraisee || allowAppriseer || allowReviewer)
            {
                var flag = isAppraisee ? "appraisee":"super";
                var dr = _matrix.checkPartialOrFinalSave(GetAppraisalId(), flag);

                if (dr == null || dr["flag"].ToString().ToLower().Equals("p"))
                {
                    btnSave.Visible = true;
                    btnFinalSave.Visible = true;
                }
                else if (dr["flag"].ToString().ToLower().Equals("t"))
                {
                    btnSave.Visible = false;
                    btnFinalSave.Visible = false;
                }
            }

            DisplaySoleComment();
        }

        private long GetEmpIdFromSupervisor()
        {
            return ReadNumericDataFromQueryString("EmpID");
        }

        private long GetPositionId()
        {
            return Request.QueryString["positionId"] != null ? long.Parse(Request.QueryString["positionId"]) : 0;
        }

        private string GetRetingTypeId()
        {
            return Request.QueryString["ratingTypeId"] != null ? Request.QueryString["ratingTypeId"] : "";
        }

        private long GetEmployeeId()
        {
            return ReadNumericDataFromQueryString("employeeId");
        }

        private long GetEmpId()
        {
            return ReadNumericDataFromQueryString("EmpIdType");
        }

        private long GetAppraisalId()
        {
            return ReadNumericDataFromQueryString("appraisalId");
        }

        private void OnSave(string type)
        {
            var dr = _matrix.InsertAppraiseeTask(GetAppraisalId().ToString(), txtCommentsOnDuties.Text, txtTaskDefinition.Text, txtOtherAchievements.Text, ReadSession().Emp_Id.ToString(), hddIsAppraisee.Value, hddAllowApriseer.Value,type);
            if (dr == null)
                return;

            ShowData();
            PrintMessage(dr);           
        }

        private void PrintMessage(DataRow dr)
        {
            var url = "";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printMsg", "PrintMessage('" + dr["error_code"].ToString().Trim() + "','" + dr["msg"].ToString().Trim() + "','" + url + "');", true);
        }

        private void DisplaySoleComment()
        {
           var dr = _matrix.FindAppraiseeTask(GetAppraisalId().ToString(), ReadSession().Emp_Id.ToString());
            if (dr == null)                
                return;                        

            txtTaskDefinition.Text = dr["comments"].ToString();
            txtOtherAchievements.Text = dr["otherAchievements"].ToString();
            txtCommentsOnDuties.Text = dr["soleComment"].ToString();      
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OnSave("p");
        }

        protected void btnFinalSave_Click(object sender, EventArgs e)
        {
            OnSave("t");
        }
    }
}
