using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PerformanceAppraisal.Matrix;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class HRFeedback : BasePage
    {
        clsDAO _clsDao = null;
        HRFeedbackDao _hrDao = null;
        SupervisorFeedbackDAO _sfDao = null;
        AppraisalReportDao _arDao = null;

        string fromAppDt = "";
        string toAppDt = "";
        string a;
        public HRFeedback()
        {
            _clsDao = new clsDAO();
            _hrDao = new HRFeedbackDao();
            _sfDao = new SupervisorFeedbackDAO();
            _arDao = new AppraisalReportDao();
        }

        string section8 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            section8 = (Request.Form["section8"] ?? "").ToString();
            if (!IsPostBack)
            {
                ShowTrangetDutiesAndResponsibilities();
                ShowApprisalMatrix();
                SetAppraiseeComment();
                SetAppraiserComments();
                SetAppraiserRecommendation();
                SetReviewerSection();
                ShowSection6();
                ShowData();
               //GetFirstRater();
               GetValidation();
              // GetMemberTypeWithPosition();              
            }            
        }

        private string GetRetingTypeId()
        {
            return Request.QueryString["ratingTypeId"] != null ? Request.QueryString["ratingTypeId"] : "";
        }

        private void ShowData()
        {

            var dt = _sfDao.GetSection8(GetAppraisalId().ToString());
            if (dt == null)
                return;

            var _matrix = new PerformanaceMatrixDao();
            var dr1 = _matrix.AllowApprisalRating(GetAppraisalId().ToString(), GetRetingTypeId().ToString(), GetPositionId().ToString(), ReadSession().Emp_Id.ToString(), GetEmployeeId().ToString());
            var allowBtnSave = (dr1["reviewCommitte"].ToString().ToUpper().Equals("TRUE") ? true : false);

            string st = _clsDao.GetSingleresult("SELECT 'X' FROM appraisalComments WHERE APPRAISALID=" + filterstring(GetAppraisalId().ToString()) + " AND raterTypeFlag='rc'");
            if (st.ToLower().Equals("x"))
                allowBtnSave = false;
            var seperator = "";
            var elementName = "section8";
            var sb = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");
            sb.Append("<tr>");
            sb.Append("<th> Particular </th>");
            sb.Append("<th> Comments </th>");
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                hddQuesionId.Value += seperator + dr["appOtherSectionId"].ToString();
                sb.Append("<tr>");
                sb.Append("<td>" + dr["question"].ToString() + "</td>");
                if (dr["answerType"].ToString() == "Numeric")
                {
                    sb.Append("<td align=\"left\"><input type=\"text\" id=\"section6_" + dr["appOtherSectionId"] + "\" value =\"" + dr["comments"].ToString() + "\" name=\"" + elementName + "\" class=\"inputTextBoxLP1\" onblur=\"checknumber(this.value);\"></td>");
                }
                else if (dr["answerType"].ToString() == "Yes/No")
                {
                    sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDll(dr["appOtherSectionId"].ToString(), dr["comments"].ToString()) + "</div></td>");
                }
                else
                {
                    if (GetFirstRater()[3] == "Y")
                    {
                        sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\"><textarea \"name=\"" + elementName + "\" class=\"inputTextBoxLP1\" rows=\"2\" cols=\"20\" overflow=\"auto\" style=\"height:50px;width:275px;text-align:top;text-mode:multiline\">" + dr["comments"].ToString() + "</textarea></div></td>");
                        radioChk.Enabled = true;
                    }
                    else
                    {
                        sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\"><textarea disabled=\"disabled\" \"name=\"" + elementName + "\" class=\"inputTextBoxLP1\" rows=\"2\" cols=\"20\" overflow=\"auto\" style=\"height:50px;width:275px;text-align:top;text-mode:multiline\">" + dr["comments"].ToString() + "</textarea></div></td>");
                    }
                }
                sb.Append("</tr>");
                seperator = ",";

            }
            HRSection.InnerHtml = sb.ToString();
            GetSoleComments();
            GetShowHide(st);
        }

        private void GetSoleComments()
        {
            radioChk.SelectedValue = _clsDao.GetSingleresult(@"SELECT soleComment FROM appraisalComments WHERE APPRAISALID="
                    + filterstring(GetAppraisalId().ToString()) 
                    + " AND raterTypeFlag='rc' and soleComment in ('Substandard','Acceptable','Good','Very Good','Excellent')");

            txtReview.Text = _clsDao.GetSingleresult("SELECT soleComment FROM appraisalComments WHERE APPRAISALID=" 
                + filterstring(GetAppraisalId().ToString()) + " AND commentBy='" + ReadSession().Emp_Id.ToString()
                + "'  AND raterTypeFlag='rc' and soleComment not in ('Substandard','Acceptable','Good','Very Good','Excellent')");
        }

        private void GetShowHide(string st)
        {
            getApprisalDate();
            if (FlagStatus() == "p" || GetValidation() == "")
            {
                btnForward.Visible = false;
                btnSave.Visible = false;
            }           
            else
            {
                if (!st.ToLower().Equals("x") && GetFirstRater()[3] != "Y")
                {
                    btnSave.Visible = false;
                    btnForward.Visible = false;
                }
                else
                {
                    btnSave.Visible = true;
                    btnForward.Visible = true;
                }
            }
            
        }

        private string MakeDll(string id,string valueToBeSelected)
        {
            var html = new StringBuilder();
            html.Append("<select id = \"section6_"+id + "\" name = \"section6\" class=\"FltCMBDesign\" style=\"width:75px;\">");
            html.Append("<option value=\"\" "+(string.IsNullOrWhiteSpace(valueToBeSelected)? "selected=\"selected\"":"")+">select</option>");
            html.Append("<option value=\"Yes\" " + (valueToBeSelected.Equals("Yes") ? "selected=\"selected\"" : "") + ">Yes</option>");
            html.Append("<option value=\"No\" " + (valueToBeSelected.Equals("No") ? "selected=\"selected\"" : "") + ">No</option>");
            html.Append("</select>");
            return html.ToString();
        }

        private long GetEmployeeId()
        {
            return ReadNumericDataFromQueryString("employeeId");
        }

        private long GetEmployeePosition()
        {
            return ReadNumericDataFromQueryString("positionId");
        }

        private string GetFlag()
        {
            return ReadNumericDataFromQueryString("flag").ToString();
        }

        private string GetEmpIdFromSupervisor()
        {
            return Request.QueryString["employeeId"] != null ? Request.QueryString["employeeId"] : "";
        }

        private long GetAppraisalId()
        {
            return ReadNumericDataFromQueryString("AppraisalId");
        }

        private long GetPositionId()
        {
            return ReadNumericDataFromQueryString("positionId");
        }

        private void OnPartialSave()
        {         
            string[] section8_list = HiddenField1.Value.Split(',');
            if (section8_list.Contains("")||radioChk.SelectedValue=="")
            {
                string msg = "Please Select Value for All Factors and over all rating";
                DivMsg.InnerHtml = msg;
                DivMsg.Attributes.Add("class", "warning");
                return;
            }
            string soleComment = txtReview.Text;
            string overallReview = radioChk.SelectedValue;

            if (GetFirstRater()[3] == "Y")
            {
                DataTable dt = _hrDao.OnSaveSoleComment(GetAppraisalId().ToString(), "", "", soleComment, ReadSession().Emp_Id.ToString(), "t", "");
                DataTable dtt = _hrDao.OnSaveSoleComment(GetAppraisalId().ToString(), "", "", overallReview, ReadSession().Emp_Id.ToString(), "t", "");
                var comment = section8_list[0] + ',' + section8_list[1] + ',' + section8_list[2] + ',' + section8_list[3] + ',';
                var dr = _hrDao.InsertComments(GetAppraisalId().ToString(), hddQuesionId.Value, comment, ReadSession().Emp_Id.ToString(), "t","");
                if (dr == null)
                    return;
                PrintMessage(dr);
            }
            else
            {
                DataTable dt = _hrDao.OnSaveSoleComment(GetAppraisalId().ToString(), "", "", soleComment, ReadSession().Emp_Id.ToString(), "t","");
                if (dt.Rows.Count <= 0)
                    return;
                PrintMessage(dt.Rows[0]);
            }
            //DivMsg.Attributes.Add("class", "success");
            //Response.Redirect("HRFeedback.aspx?appraisalId=" + GetAppraisalId());
        }

        private void PrintMessage(DataRow dr)
        {
           
            var url = "HRFeedback.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + GetEmployeeId() + "&appraisalId=" + GetAppraisalId();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printMsg", "PrintMessage('" + dr["error_code"].ToString().Trim() + "','" + dr["msg"].ToString().Trim() + "','" + url + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OnPartialSave();
        }

        private List<string> GetFirstRater()
        {
            List<string> _list = new List<string>();
            var dt = _clsDao.ExecuteDataset("select empId,memberTypeId,memberPosition,isFirstRater from reviewCommitteeMembers where empId='" + ReadSession().Emp_Id.ToString() + "' and memberTypeId='" + GetMemberTypeWithPosition()+ "' and isnull(isDelete,'N')<>'Y'").Tables[0];
            if (dt.Rows.Count <= 0) {
                  btnSave.Visible = false;
                    btnForward.Visible = false;
               
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    _list.Add("");
                }
                return _list;
            }

            for(int i=0;i<dt.Columns.Count;i++)
            {
                _list.Add(dt.Rows[0][i].ToString());
            }
            return _list;           
        }

        private string GetValidation()
        {
            string _txtCondition = _clsDao.GetSingleresult("select 'X' from appraisalComments WHERE appraisalId = '" + GetAppraisalId().ToString() + "' and soleComment in ('Agree','DisAgree')");
            return _txtCondition;
        }

        private string FlagStatus()
        {
            string _fl = _clsDao.GetSingleresult("SELECT distinct LTRIM(RTRIM(flag)) FROM appraisalComments WHERE APPRAISALID=" + filterstring(GetAppraisalId().ToString()) + " AND commentBy='" + ReadSession().Emp_Id.ToString() + "' AND raterTypeFlag='rc'");
            return _fl;
        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            OnFinalSave();
        }

        private void OnFinalSave()
        {
            string[] section8_list = HiddenField1.Value.Split(',');
            if (section8_list.Contains("") || radioChk.SelectedValue == "")
            {
                string msg = "Please Select Value for All Factors and Over All Rating";
                DivMsg.InnerHtml = msg;
                DivMsg.Attributes.Add("class", "warning");
                return;
            }
            string soleComment = txtReview.Text;
            string overallReview = radioChk.SelectedValue;
            if (GetFirstRater()[3] == "Y")
            {
                DataTable dt = _hrDao.OnSaveSoleComment(GetAppraisalId().ToString(), "", "", soleComment, ReadSession().Emp_Id.ToString(), "p", "sf");
                DataTable dtt = _hrDao.OnSaveSoleComment(GetAppraisalId().ToString(), "", "", overallReview, ReadSession().Emp_Id.ToString(), "p", "sf");
                var comment = section8_list[0] + ',' + section8_list[1] + ',' + section8_list[2] + ',' + section8_list[3] + ',';
                var dr = _hrDao.InsertComments(GetAppraisalId().ToString(), hddQuesionId.Value, comment, ReadSession().Emp_Id.ToString(), "p","sf");
                if (dr == null)
                    return;
                PrintMessage(dr);
            }
            else
            {
                DataTable dt = _hrDao.OnSaveSoleComment(GetAppraisalId().ToString(), "", "", soleComment, ReadSession().Emp_Id.ToString(), "p", "sf");
                if (dt.Rows.Count <= 0)
                    return;
                PrintMessage(dt.Rows[0]);
            }
        }

        private string GetMemberTypeWithPosition()
        {
            var pos  = GetEmployeePosition().ToString();
            if (pos != "0")
                Session["pos"] = pos;
            else
                pos = Session["pos"].ToString();
            string getType = _clsDao.GetSingleresult("select memberType from appriasalReviewPosition with(nolock) where position='" + pos + "'");
            return getType;        
        }
        private void getApprisalDate() {
            var dt =_clsDao.ExecuteDataset("select FROM_DATE,TO_DATE from appraisal with(nolock) where ID='"+GetAppraisalId().ToString()+"'").Tables[0];
            fromAppDt = dt.Rows[0][0].ToString();
            toAppDt = dt.Rows[0][1].ToString();
            ValidateAppRange();
        }
        private string ValidateAppRange()
        {
            string emp = ReadSession().Emp_Id.ToString();
            string valueFrom = _clsDao.GetSingleresult(@"select 'Y' from reviewCommitteeMembers with(nolock) where cast(memberFrom  as date)
                                                                > cast('" + toAppDt + "' as date)  and empId='" + emp + "' ");

            string valueTo = _clsDao.GetSingleresult(@"select 'Y' from reviewCommitteeMembers with(nolock) where cast(memberTo  as date)
                                                                >  cast('" + toAppDt + "' as date) and empId='" + emp + "'");
            return valueFrom + "-" + valueTo;
        }


        #region Section1
        private void ShowTrangetDutiesAndResponsibilities()
        {
            var dr = _arDao.GetSection1(GetAppraisalId().ToString());
            if (dr == null)
                return;

            txtTaskDefinition.InnerHtml = dr["comments"].ToString();
            txtOtherAchievements.InnerHtml = dr["otherAchievements"].ToString();
            txtCommentsOnDuties.InnerHtml = dr["soleComment"].ToString();
        }
        #endregion

        #region Section2
        private void ShowApprisalMatrix()
        {

            var dt = _arDao.GetSection2(GetAppraisalId().ToString(), GetEmployeeId().ToString());
            if (dt == null)
                return;

            var currentGroup = "";
            var previousGroup = "";

            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");
            str.Append("<tr>");
            str.Append("<th style=\"text-align:center\"><strong>Critical Attributes</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong> Weight</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong> Total Weight</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong> Self Rating</strong></th>");
            str.Append("<th style=\"text-align:center\" width=\"75px\" wrap=\"wrap\"><strong>  Rating by Supervisor</strong></th>");
            str.Append("<th style=\"text-align:center\" width=\"75px\" wrap=\"wrap\"><strong>  Rating by Reviewer</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong>Supervisor Comment</strong></th>");
            str.Append("<th style=\"text-align:center\"><strong>Reviewer Comment</strong></th>");
            str.Append("</tr>");


            foreach (DataRow row in dt.Rows)
            {
                //RatingValue.Value = RatingValue.Value + seprator + row["perAppMatSetUpId"].ToString();
                //currentGroup = row[2].ToString();

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
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row["WeightJE(%)"].ToString() + "</div></td>"); //6
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row["Total Weight (%)"].ToString() + "</div></td>");//7
                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + PopulateData(row["a"].ToString()) + "</td>");

                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + PopulateData(row["s"].ToString()) + "</td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + PopulateData(row["r"].ToString()) + "</td>"); //class=\"inputTextBoxLP1\"
                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><div id=\"super_" + row["perAppMatSetUpId"].ToString() + "\"  style=\"text-align:top;text-mode:multiline;color:black; padding-bottom: 0 !important;\">" + row["sComment"].ToString() + "</div></td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><div id=\"review_" + row["perAppMatSetUpId"].ToString() + "\" style=\"text-align:top;text-mode:multiline;color:black; padding-bottom: 0 !important;\">" + row["rComment"].ToString() + "</div></td>");
                str.Append("</tr>");
            }

            var colSpan = 4;

            var rowEverage = _arDao.GetEverageRating(GetAppraisalId().ToString());

            str.Append("<tr>");
            str.Append("<td colspan=\"" + (colSpan) + "\"><strong>Average Rating</strong></td>");
            str.Append("<td>" + rowEverage["Supervisor"].ToString() + "</td>");
            str.Append("<td>" + rowEverage["Reviewer"].ToString() + "</td>");
            str.Append("<td style=\"text-align:center\" colspan=\"3\">&nbsp;</td>");
            str.Append("</tr>");

            str.Append("<tr>");
            str.Append("<td colspan=\"" + (colSpan) + "\"><strong>Rating</strong></td>");
            str.Append("<td><strong>" + GetRatingGrade(rowEverage["Supervisor"].ToString()) + "</strong></td>");
            str.Append("<td><strong>" + GetRatingGrade(rowEverage["Reviewer"].ToString()) + "</strong></td>");
            str.Append("<td style=\"text-align:center\" colspan=\"3\">&nbsp;</td>");
            str.Append("</tr>");

            str.Append("</table>");
            setSection2.InnerHtml = str.ToString();
        }

        private string GetRatingGrade(string marks)
        {
            var grade = "";
            float toTalEverage = string.IsNullOrWhiteSpace(marks) ? 0 : float.Parse(marks);
            if (toTalEverage > 0 && toTalEverage < 20)
                grade = "Substandard";
            else if (toTalEverage >= 20 && toTalEverage < 40)
                grade = "Acceptable";
            else if (toTalEverage >= 40 && toTalEverage < 60)
                grade = "Good";
            else if (toTalEverage >= 60 && toTalEverage < 81)
                grade = "Very Good";
            else if (toTalEverage >= 81)
                grade = "Excellent";
            return grade;
        }
        string PopulateData(string value)
        {
            var html = new StringBuilder("");
            html.Append("<label style=\"text-align:left\">" + value + "</label>");
            return html.ToString();
        }
        #endregion

        #region Section3
        private void SetAppraiserSection()
        {
            var str = new StringBuilder("<table width=\"100%\" class=\"TBL2\" border=\"0\" align=\"center\">");
            DataTable dt = _arDao.GetdetailReport(GetAppraisalId().ToString(), "", "").Tables[2];
            var previousSection = "";
            foreach (DataRow dr in dt.Rows)
            {
                var currentSection = dr["section"].ToString();
                if (dr["sectionId"].ToString() == "Section II" || dr["sectionId"].ToString() == "Section III" || dr["sectionId"].ToString() == "Section IV")
                {
                    if (currentSection != previousSection)
                    {
                        previousSection = currentSection;
                        str.AppendLine("<tr>");
                        str.AppendLine("<td>");
                        str.AppendLine("<b>" + dr["Title"].ToString() + "</b>");
                        str.AppendLine("</td>");
                        str.AppendLine("</tr>");
                        str.AppendLine("<tr>");
                        str.AppendLine("<td>");
                        var html = PopulateList(ref dt, currentSection, dr["comments"].ToString());
                        str.AppendLine(html);
                        str.AppendLine("</td>");
                        str.AppendLine("</tr>");
                    }
                }
            }
            str.Append("</table>");
            setSection2.InnerHtml = str.ToString();
        }
        private string PopulateList(ref DataTable dt, string typeId, string comments)
        {
            DataRow[] rows = dt.Select("section='" + typeId + "'");
            var str = new StringBuilder();
            str.AppendLine("<table width=\"700\" border=\"0\" class=\"TBL2\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");

            foreach (DataRow dr in rows)
            {
                var question_id = dr["appOtherSectionId"].ToString();
                str.AppendLine("<tr>");
                str.AppendLine("<td align=\"left\" width=\"400px\">");
                str.AppendLine("<div style = \"margin-left:20px\">" + dr["question"].ToString() + "</td>");
                if (dr["sectionId"].ToString() == "Section-2")
                {
                    str.AppendLine("<td align=\"left\"><input type=\"text\" style = \"border-color:#999999\" disabled=\"disabled\" value=\"" + dr["comments"].ToString() + "\"></td>");
                }
                else
                {
                    str.AppendLine("<td align=\"left\"><div style = \"border:solid 1px #666666;\">" + (dr["comments"].ToString() != "" ? dr["comments"].ToString() : " - ") + "</div></td>");
                }
                str.AppendLine("</tr>");

            }
            str.AppendLine("</table>");
            return str.ToString();
        }
        #endregion

        #region AppraiseeComment
        private void SetAppraiseeComment()
        {
            DataTable dt = _arDao.GetdetailReport(GetAppraisalId().ToString(), GetEmployeeId().ToString(), "").Tables[4];
            foreach (DataRow dr in dt.Rows)
            {
                rdoResponse.Text = dr["soleComment"].ToString();
                //txtComments.Text = dr["comments"].ToString();
                divComments.InnerText = dr["comments"].ToString();
            }
        }
        #endregion

        #region AppraiserComments
        private void SetAppraiserComments()
        {
            var dt = _arDao.GetSection3(GetAppraisalId().ToString());
            if (dt == null)
                return;

            var sb = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + dr["question"].ToString() + "</td>");
                sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + dr["comments"].ToString() + "</div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            setSection3.InnerHtml = sb.ToString();
        }
        #endregion

        #region Section4
        private void SetAppraiserRecommendation()
        {
            var dt = _arDao.GetSection4(GetAppraisalId().ToString());
            if (dt == null)
                return;

            var sb = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");

            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + dr["question"].ToString() + "</td>");
                sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + dr["comments"].ToString() + "</div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            setSection4.InnerHtml = sb.ToString();
        }
        #endregion

        #region Section 5
        private void SetReviewerSection()
        {
            var dr = _arDao.GetSection5(GetAppraisalId().ToString());
            if (dr == null)
                return;
            rdReviewer.SelectedValue = dr["soleComment"].ToString();
            rdReviewer.SelectedItem.Attributes.CssStyle.Add("font-weight", "bold");
            reviewrsComment.InnerText = dr["comments"].ToString();
        }
        #endregion

        #region Section 6
        public void ShowSection6()
        {
            var dt = _arDao.GetSection6(GetAppraisalId().ToString());
            if (dt == null)
                return;

            var sb = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");
            sb.Append("<tr>");
            sb.Append("<th> Particular </th>");
            sb.Append("<th>Yes/No </th>");
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + dr["question"].ToString() + "</td>");
                sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + dr["comments"].ToString() + "</div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            section6.InnerHtml = sb.ToString();
        }
        #endregion
              
    }
}
