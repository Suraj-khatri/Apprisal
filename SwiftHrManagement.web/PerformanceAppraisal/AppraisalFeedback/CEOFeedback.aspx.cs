using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PerformanceAppraisal.Matrix;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class CEOFeedback : BasePage
    {
        SupervisorFeedbackDAO _superDao = new SupervisorFeedbackDAO();
        PerformanaceMatrixDao _matrix = new PerformanaceMatrixDao();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if(GetRater() == "r")
                //{
                //    if(ReadSession().Emp_Id.ToString() == CEOID().ToString())
                //    BtnSave.Visible = true;
                //    else
                //    BtnSave.Visible = false;

                //    Panel1.Visible = true;
                //}
                //DisplaySoleComment();
                Dispaly();
            }
        }

        private string GetRetingTypeId()
        {
            return Request.QueryString["ratingTypeId"] != null ? Request.QueryString["ratingTypeId"] : "";
        }

        private void Dispaly()
        {
            var _matrix = new PerformanaceMatrixDao();
            var dr = _matrix.AllowApprisalRating(GetAppraisalId().ToString(), GetRetingTypeId().ToString(), GetPositionId().ToString(), ReadSession().Emp_Id.ToString(), GetEmployeeId().ToString());
            btnSave.Visible = (dr["hrDepartment"].ToString().ToUpper().Equals("TRUE") ? true : false);
            
            
            dr =  _superDao.GetHrDepartMentComment(GetAppraisalId().ToString());
            if (dr == null)
                return;

            letterIssuedOn.Text = dr["letterIssuedOn"].ToString();
            incrementOn.Text = dr["incrementEffectedOn"].ToString();

            if((!string.IsNullOrEmpty(letterIssuedOn.Text))||(!string.IsNullOrEmpty(incrementOn.Text)))
                btnSave.Visible = false;
        }

        private long GetAppraisalId()
        {
            return ReadNumericDataFromQueryString("AppraisalId");
        }

        private long GetPositionId()
        {
            return ReadNumericDataFromQueryString("positionId");
        }

        private long GetEmployeeId()
        {
            return ReadNumericDataFromQueryString("employeeId");
        }

        private string GetRater()
        {
            var rater = _matrix.GetRater(GetAppraisalId().ToString());
            return rater;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var dr = _superDao.UpdateHrComments(GetAppraisalId().ToString(), ReadSession().Emp_Id.ToString(), letterIssuedOn.Text, incrementOn.Text);
            if (dr == null)
                return;
            PrintMessage(dr);
        }

        private void PrintMessage(DataRow dr)
        {
            var url = "CEOFeedback.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + GetEmployeeId() + "&appraisalId=" + GetAppraisalId() + "&positionId=" + GetPositionId();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printMsg", "PrintMessage('" + dr["error_code"].ToString().Trim() + "','" + dr["msg"].ToString().Trim() + "','" + url + "');", true);
        }
        
        //private void SaveCEOComment()
        //{
        //    DataTable dt = _superDao.OnSaveSoleCommentCEO(GetAppraisalId().ToString(), "", txtCEOComment.Text, "", ReadSession().Emp_Id.ToString());
        //    DataRow dr = null;
        //    if (dt == null || dt.Rows.Count < 0)
        //        return;
        //    dr = dt.Rows[0];

        //    if (dr["error_code"].ToString() == "1")
        //    {
        //        DivMsg.InnerHtml = dr["msg"].ToString();
        //        DivMsg.Attributes.Add("class", "warning");

        //    }
        //    else
        //    {
        //        DivMsg.InnerHtml = dr["msg"].ToString();
        //        DivMsg.Attributes.Add("class", "success");
        //        Response.Redirect("CEOFeedback.aspx?appraisalId=" + GetAppraisalId());
        //    }
        //}

        //protected void BtnSave_Click(object sender, EventArgs e)
        //{
        //    SaveCEOComment();
        //}

        //private void DisplaySoleComment()
        //{
        //    Panel1.Visible = true;
        //    DataTable dt = _superDao.FindSoleComment(GetAppraisalId(), CEOID(),"c");
        //    DataRow dr = null;
        //    if (dt == null || dt.Rows.Count <= 0)
        //        return;
        //    dr = dt.Rows[0];
        //    txtCEOComment.Text = dr["comments"].ToString();
        //    BtnSave.Visible = false;
        //}

    }
}
