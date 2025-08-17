using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PerformanceAppraisal.Matrix;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class ReviewerFeedback : BasePage
    {
        clsDAO _clsDao = null;
        PerformanaceMatrixDao _matrix = null;
        SupervisorFeedbackDAO _superDao = null;
        string ratingvalue = null;
        RoleMenuDAOInv _roleMenuDao = null;
        string matrix_Id = "";
        string rating_value = "";
        string reviewerVisorComment = "";
        public ReviewerFeedback()
        {

            _clsDao = new clsDAO();
            _matrix = new PerformanaceMatrixDao();
            _superDao = new SupervisorFeedbackDAO();
            _roleMenuDao = new RoleMenuDAOInv();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ratingvalue_"] != null)
                ratingvalue = Request.Form["ratingvalue_"].ToString();
            matrix_Id = (Request.Form["rowId"] ?? "").ToString();
            rating_value = (Request.Form["ratingvalue"] ?? "").ToString();
            reviewerVisorComment = (Request.Form["txtReviewerComment"] ?? "").ToString();
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 19) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                listQuestion();
                DisplaySoleComment();
            }
        }

        private long GetPositionId()
        {
            return Request.QueryString["positionId"] != null ? long.Parse(Request.QueryString["positionId"]) : 0;
        }

        private long GetEmployeeId()
        {
            return ReadNumericDataFromQueryString("employeeId");
        }

        private string GetSupervisorId()
        {
            return ReadNumericDataFromQueryString("EmpIdType").ToString();
        }

        private long GetappraisalId()
        {
            return Request.QueryString["appraisalId"] != null ? long.Parse(Request.QueryString["appraisalId"]) : 0;
        }

        private string GetRetingTypeId()
        {
            return Request.QueryString["ratingTypeId"] != null ? Request.QueryString["ratingTypeId"] : "";
        }

        private string GetEmpIdFromSupervisor()
        {
            return Request.QueryString["employeeId"] != null ? Request.QueryString["employeeId"] : "";
        }
        
        public string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "");
        }

        private DateTime GetDeadLine()
        {
            DateTime enddate = ParseDateTime(_clsDao.GetSingleresult("select [days] from  appraisalSupervisorAssignment where  SUPERVISOR_TYPE = 'r' and  appraisal_id =" +
                                            filterstring(GetappraisalId().ToString())));

            return (enddate);
        }  
        
        string MakeDDL(int id, string keyValue, ref DataTable dt, string valueToBeSelected, bool enableDdl)
        {
            var html = new StringBuilder("");
            var codeForDisable = "";
            if (!enableDdl)
            {
                codeForDisable = "disabled=\"disabled\"";
            }

            if (id.Equals(1)) //&& (allowMarking) onblur=\"CalculateRating('" + id + "')\" 
            {
                html.Append("<select " + codeForDisable + "  id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" ValidationGroup=\"Save\">");
                html.Append("<option value=\"\">select</option>");
                foreach (DataRow dr in dt.Rows)
                {
                    html.Append("<option value = \"" + dr["DETAIL_TITLE"].ToString() + "\"" + AutoSelect(dr["DETAIL_TITLE"].ToString(), valueToBeSelected.ToString()) + ">" + dr["DETAIL_TITLE"].ToString() + "</option>");
                }
                html.Append("</select>");
            }
            else if (id.Equals(2)) //&& (allowMarking) onblur=\"CalculateRating('" + id + "')\"
            {
                html.Append("<select " + codeForDisable + " onchange=\"OnDdlChange('ratingvalue" + id + "_" + keyValue + "')\" id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" ValidationGroup=\"Save\">");
                html.Append("<option value=\"\">select</option>");
                foreach (DataRow dr in dt.Rows)
                {
                    html.Append("<option value = \"" + dr["DETAIL_TITLE"].ToString() + "\"" + AutoSelect(dr["DETAIL_TITLE"].ToString(), valueToBeSelected.ToString()) + ">" + dr["DETAIL_TITLE"].ToString() + "</option>");
                }
                html.Append("</select>");
            }
            else if (id.Equals(3)) //&& (allowMarking) onblur=\"CalculateRating('" + id + "')\"
            {
                html.Append("<select " + codeForDisable + " onchange=\"OnDdlChange('ratingvalue" + id + "_" + keyValue + "')\" id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" ValidationGroup=\"Save\">");
                html.Append("<option value=\"\">select</option>");
                foreach (DataRow dr in dt.Rows)
                {
                    html.Append("<option value = \"" + dr["DETAIL_TITLE"].ToString() + "\"" + AutoSelect(dr["DETAIL_TITLE"].ToString(), valueToBeSelected.ToString()) + ">" + dr["DETAIL_TITLE"].ToString() + "</option>");
                }
                html.Append("</select>");
            }
            else
            {
                html.Append("<select id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px;\"  disabled=\"disabled\">");
                html.Append("<option value=\"\">select</option>");
                html.Append("</select>");
            }
            return html.ToString();
        }

        private void listQuestion()
        {

            var dtRow = _matrix.AllowApprisalRating(GetappraisalId().ToString(), GetRetingTypeId(), GetPositionId().ToString(), ReadSession().Emp_Id.ToString(), GetEmployeeId().ToString());
            DataSet ds = _matrix.FindMatrixSetupById(GetPositionId().ToString(), GetappraisalId().ToString());
            if (ds.Tables[0].Rows.Count < 0 || ds == null)
            {
                return;
            }
            DataTable dt = ds.Tables[0];
            var dtrating = _clsDao.getDataset("SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE [TYPE_ID] = 76").Tables[0];
            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            str.Append("<th style=\"text-align:center\"><strong>Critical Attributes</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong> Weight</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong> Total Weight</strong></th>");

            bool allowSelf = dtRow["allowMarking"].ToString().Equals("TRUE") && dtRow["reviewer"].ToString().Equals("TRUE") ? true : false;
          
            bool enableSelf = false;
            bool enableAppraisee = false;

            var dr = _matrix.checkPartialOrFinalSave(GetappraisalId(), "r");
            if (dr == null)
            {
                if (allowSelf)
                {
                    btnPartialSave.Visible = true;
                    btnSave.Visible = true;
                    enableSelf = allowSelf;
                }
            }
            else if ((dr["setFlag"].ToString().Trim().ToLower().Equals("p")) && allowSelf)
            {
                btnPartialSave.Visible = true;
                btnSave.Visible = true;
                enableSelf = true;
            }

            else if (dr["setFlag"].ToString().Trim().ToLower().Equals("sf"))
            {
                enableSelf = false;
                allowSelf = true;
                btnPartialSave.Visible = false;
                btnSave.Visible = false;

                radioChk.Enabled = false;
                txtReviewerComment.ReadOnly = true; 
            }

            enableAppraisee = _matrix.ChekSelfRating(GetappraisalId().ToString());
            if (enableAppraisee)
                str.Append("<th style=\"text-align:center\"><strong> Self Rating</strong></th>");

            str.Append("<th style=\"text-align:center\" width=\"75px\" wrap=\"wrap\"><strong>  Rating by Supervisor</strong></th>");
            str.Append("<th style=\"text-align:center\" width=\"75px\" wrap=\"wrap\"><strong>  Rating by Reviewer</strong></th>");
            str.Append("<th style=\"text-align:center\">Supervisor Comment</th>");
            str.Append("<th style=\"text-align:center\">Reviewer Comment</th>");
            str.Append("</tr>");

            var currentGroup = "";
            var previousGroup = "";
            hdnRatingValue.Value = "";
            var seprator = ",";

            float toTalEverage=0;

            foreach (DataRow row in dt.Rows)
            {
                hdnRatingValue.Value = hdnRatingValue.Value + seprator + row["perAppMatSetUpId"].ToString();
                currentGroup = row["appraisalSubTopic"].ToString();
                if (currentGroup != previousGroup)
                {
                    str.Append("<tr>");
                    str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row["appraisal Sub Topic"].ToString() + "</font></strong></div></td>");//3
                    str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row["Weight(%)"].ToString() + "</font></strong></div></td>");//4
                    str.Append("</tr>");
                    previousGroup = currentGroup;
                }

                str.Append("<tr>");
                str.Append("<td align=\"left\"><div style = \"margin-left:20px\" >" + row["SN"].ToString() + ". " + row["Job Element"].ToString() + "</div></td>");//0,5
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row["jobElementWeight(%)"].ToString() + "</div></td>"); //6
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row["Total Weight (%)"].ToString() + "</div></td>");//7  

                if (enableAppraisee)
                {
                    str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(1, row["perAppMatSetUpId"].ToString(), ref dtrating, row["a"].ToString(), false) + "</td>");
                }

                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(2, row["perAppMatSetUpId"].ToString(), ref dtrating, row["s"].ToString(), false) + "</td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(3, row["perAppMatSetUpId"].ToString(), ref dtrating, row["r"].ToString(), enableSelf) + "</td>"); //class=\"inputTextBoxLP1\" 
                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea disabled=\"disabled\"  id=\"super_" + row["perAppMatSetUpId"].ToString() + "\" class=\"form-control\" name=\"txtSupervisorComment\" rows=\"2\" cols=\"20\" overflow=\"auto\">" + row["sComment"].ToString() + "</textarea></td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea class=\"form-control\" " + (!enableSelf ? "disabled=\"disabled\"" : "") + " id=\"reviewer_" + row["perAppMatSetUpId"].ToString() + "\" name=\"txtReviewerComment\" rows=\"2\" cols=\"20\" overflow=\"auto\">" + row["rComment"].ToString() + "</textarea>");
                str.Append(" <input type=\"hidden\" name= \"rowId\" class=\"form-control\"  id=\"rowId_ " + row["perAppMatSetUpId"].ToString() + "\" value = \"" + row["perAppMatSetUpId"].ToString() + "\" /></td>"); 
                //str.Append("<td align=\"left\"><div style = \"margin-left:8px\">" + (row["weightedAverage"].ToString().Equals("0") ? "" : row["weightedAverage"].ToString()) + "</div><input type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + row["perAppMatSetUpId"].ToString() + "\" value = \"" + row[1].ToString() + "\" /></td>");

                toTalEverage += string.IsNullOrWhiteSpace(row["weightedAverage"].ToString())?0: float.Parse(row["weightedAverage"].ToString());
                str.Append("</tr>");
            }           

            var colSpan = enableAppraisee ? 4 : 3;
            var sumValue = "";
            if (toTalEverage > 0 && toTalEverage < 20)
                sumValue = toTalEverage.ToString() + "&nbsp" + "Substarndard";
            else if (toTalEverage >= 20 && toTalEverage < 40)
                sumValue = toTalEverage.ToString() + "&nbsp" + "Acceptable";
            else if (toTalEverage >= 40 && toTalEverage < 60)
                sumValue = toTalEverage.ToString() + "&nbsp" + "Good";
            else if (toTalEverage >= 60 && toTalEverage < 81)
                sumValue = toTalEverage.ToString() + "&nbsp" + "Very Good";
            else if (toTalEverage >= 81)
                sumValue = toTalEverage.ToString() + "&nbsp" + "Excellent";

            str.Append("<tr>");
            str.Append("<td colspan=\"" + (colSpan + 2) + "\"><strong>Average Rating(Both Supervisor and Reviewer)</strong></td>" +
                "<td style=\"text-align:center\" colspan=\"3\"><strong>" + sumValue + "</strong></td>");
            str.Append("</tr>");

            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();         
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void OnSave()
        {   
            string[] ratingvalue = Request.Form["ratingvalue"].Split(',');
            if (ratingvalue.Contains(""))
            {
                string msg = "Please Select Value for All Factors";
                DataTable dtMsg = new DataTable();
                dtMsg.Columns.Add("error_code");
                dtMsg.Columns.Add("msg");
                dtMsg.Rows.Add("1", msg);
                PrintMessage(dtMsg.Rows[0]);
                return;
            }

            DataTable dt1 = _matrix.OnSave(GetappraisalId().ToString(), matrix_Id, ReadSession().Emp_Id.ToString(), rating_value, "r", "sf", reviewerVisorComment);
            DataRow dr1 = dt1.Rows[0];          
            if (dr1["error_code"].ToString() == "0")
            {
                ConfirmMsg.InnerText = dr1["msg"].ToString();
                ConfirmMsg.Attributes.Add("class", "success");
            }


            DataTable dt = _superDao.OnSaveSoleComment(GetappraisalId().ToString(), "", txtReviewerComment.Text, radioChk.Text, ReadSession().Emp_Id.ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];
            PrintMessage(dr);
        }

        private void DisplaySoleComment()
        {
            DataTable dt = _matrix.RetreiveComments( GetappraisalId().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            txtReviewerComment.Text = dr["comments"].ToString();
            radioChk.Text = dr["soleComment"].ToString();           
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            _superDao.OnReject(hdnRemarks.Value, hdnRaterType.Value, GetappraisalId().ToString(), hdnMatrixId.Value);

        }

        protected void BtnPartialSave_Click(object sender, EventArgs e)
        {
            OnPartialSave();
        }

        private void OnPartialSave()
        {
            DataTable dt1 = _matrix.OnSave(GetappraisalId().ToString(), matrix_Id, ReadSession().Emp_Id.ToString(), rating_value, "r", "p", reviewerVisorComment);
            DataRow dr1 = dt1.Rows[0];
            if (dr1["error_code"].ToString() == "0")
            {
                ConfirmMsg.InnerText = dr1["msg"].ToString();
                ConfirmMsg.Attributes.Add("class", "success");
            }

            DataTable dt = _superDao.OnSaveSoleComment(GetappraisalId().ToString(), "", txtReviewerComment.Text, radioChk.Text, ReadSession().Emp_Id.ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];
            PrintMessage(dr);
            
        }

       

        private void PrintMessage(DataRow dr)
        {
            var url = "ReviewerFeedback.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + GetEmployeeId() + "&appraisalId=" + GetappraisalId() + "&positionId=" + GetPositionId() + "&ratingTypeId=" + GetRetingTypeId();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printMsg", "PrintMessage('" + dr["error_code"].ToString().Trim() + "','" + dr["msg"].ToString().Trim() + "','" + url + "');", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (hdnMatrixId.Value == "")
            {
                return;
            }
            string[] arrayMatrixIdFlag = hdnMatrixId.Value.Split('_');
            string matrixId = arrayMatrixIdFlag[0];
            string raterType = arrayMatrixIdFlag[1];

            var sql = "exec [proc_AppraiserRating] @flag='ru',@rating= " + filterstring(hdnRating.Value) + ","
                      + "@appraisalId=" + GetappraisalId() + ",@matrixId=" + matrixId + ",@raterType=" + filterstring(raterType); 

            _clsDao.runSQL(sql);
            listQuestion();

        }
     
    }
}
