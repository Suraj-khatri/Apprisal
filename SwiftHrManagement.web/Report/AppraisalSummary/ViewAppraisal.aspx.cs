using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.web.Report.AppraisalSummary
{
    public partial class ViewAppraisal : BasePage
    {
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        AppraisalReportDao _arDao = new AppraisalReportDao();
        clsDAO _clsDao = new clsDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetReport();
        }

        private string GetAppraisalId()
        {
            return Request.QueryString["appraisalId"] == null ? "" : Request.QueryString["appraisalId"].ToString();
        }

        private string GetEmployeeId()
        {
            return Request.QueryString["employeeId"] == null ? "" : Request.QueryString["employeeId"].ToString();
        }

        private void GetReport()
        {
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblTitle.Text = "Performance Appraisal";
            GetEmployeeInfo();
            ShowTrangetDutiesAndResponsibilities();
            ShowApprisalMatrix();         
            SetAppraiseeComment();
            SetAppraiserComments();
            SetAppraiserRecommendation();
            SetReviewerSection();
            ShowSection6();
            ShowSection7();
            ShowSection8();
            ShowReviewCommittee();
            setReviewRatingOverall();
            //SetCEOComment();
            //SetHRSection();
            //SetHRAction();
            GetEmployeeName();
            //SetHrMember();
            ShowHRAction();
        }

        private void GetEmployeeInfo()
        {
            DataTable dt = new DataTable();
            dt = _arDao.GetdetailReport(GetAppraisalId(),"","").Tables[0];
            DataRow dr = dt.Rows[0];

            if(dr==null)
                return;
           
            lblEmpName.Text = dr["empName"].ToString();
            lblBranch.Text = dr["branch"].ToString();
            lblDept.Text = dr["department"].ToString();
            lblDesignation.Text = dr["Designation"].ToString();
            lblTitle.Text = dr["TITLE"].ToString();
            lblTotalPeriod.Text = dr["totalDays"].ToString();
            lblAppraisalFrom.Text = dr["FROM_DATE"].ToString();
            lblAppraisalTo.Text = dr["TO_DATE"].ToString();
            lblPreviousAppraisal.Text = dr["previousAppraisalDate"].ToString();

            HiddenField2.Value = lblEmpName.Text;
            HiddenField1.Value = lblAppraisalFrom.Text + "-" + lblAppraisalTo.Text;
            
        }

        #region Section1
            private void ShowTrangetDutiesAndResponsibilities()
            {
                var dr = _arDao.GetSection1(GetAppraisalId());
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

            var dt = _arDao.GetSection2(GetAppraisalId(), GetEmployeeId());
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
          
            var rowEverage = _arDao.GetEverageRating(GetAppraisalId());

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
         
        //    private void ShowApprisalMatrix()
        //{
        //    string branch_id = _clsDao.GetSingleresult("select BRANCH_ID from Appraisal where ID=" + GetAppraisalId() + "");
        //    DataTable dt1 = _clsDao.getDataset("Exec [proc_AppraisalReport] @flag='e',@branchId=" + filterstring(branch_id) + ","
        //    + " @employeeId=" + filterstring(GetEmployeeId()) + ",@fromDate=" + filterstring(lblAppraisalFrom.Text) + ","
        //    + " @toDate=" + filterstring(lblAppraisalTo.Text) + "").Tables[0]; 


        //    DataTable dt = _arDao.GetdetailReport(GetAppraisalId(),"","").Tables[1];
        //    int cols = dt.Columns.Count;

        //    StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
        //    str.Append("<tr>");
        //    str.Append("<th style=\"text-align:center\"><strong>Critical Attributes</strong></th>" +
        //    "<th width=\"25px\" style=\"text-align:center\"><strong> Weight</strong></th><th width=\"25px\" style=\"text-align:center\"><strong> Total Weight</strong></th>" +
        //    "<th width=\"25px\" style=\"text-align:center\"><strong> Self Rating</strong></th><th width=\"25px\" style=\"text-align:center\"><strong> Rating by <br/>Supervisor</strong></th>" +
        //    " <th width=\"25px\" style=\"text-align:center\"><strong> Rating by <br/> Reviewer</strong></th><th width=\"25px\" style=\"text-align:center\">Weighted Average</th>");
        //    str.Append("</tr>");

        //    var currentGroup = "";
        //    var previousGroup = "";
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        currentGroup = row["appraisalSubTopic"].ToString();


        //        if (currentGroup != previousGroup)
        //        {
        //            str.Append("<tr>");
        //            str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row["appraisal Sub Topic"].ToString() + "</font></strong></div></td>");
        //            str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row["Weight(%)"].ToString() + "</font></strong></div></td>");
        //            str.Append("</tr>");
        //            previousGroup = currentGroup;
        //        }
        //        str.Append("<tr>");
        //        str.Append("<td align=\"left\" ><div style = \"margin-left:20px\">" + row["SN"].ToString() + ". " + row["Job Element"].ToString() + "</td>");
        //        str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row["WeightJE(%)"].ToString() + "</td>");
        //        str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row["Total Weight (%)"].ToString() + "</td>");
        //        str.Append("<td width=\"25px\" align=\"center\"><div style = \"margin-left:none\">" + PopulateData(ref dt, row["a"].ToString()) + "</td>");
        //        str.Append("<td width=\"25px\" align=\"center\"><div style = \"margin-left:none\">" + PopulateData(ref dt, row["s"].ToString()) + "</td>");
        //        str.Append("<td width=\"25px\" align=\"center\"><div style = \"margin-left:none\">" + PopulateData(ref dt, row["r"].ToString()) + "</td>");
        //        //str.Append("<td width=\"25px\" align=\"center\"><div style = \"margin-left:none\">" + row["Total Weight"].ToString() + "</td>");
               
        //        str.Append("</tr>");

        //    }
        //    foreach (DataRow row in dt1.Rows)
        //    {
        //        str.Append("<tr>");
        //        str.Append("<td style=\"text-align:center\" colspan=\"4\"><strong>Average Rating</strong></td>" +
        //        "<td style=\"text-align:center\"><strong>" + row["Supervisor"].ToString() + "</strong></td>" +
        //        "<td style=\"text-align:center\"><strong>" + row["Reviewer"].ToString() + "</strong></td>" +
        //        "<td></td>");
        //        str.Append("</tr>");

        //        str.Append("<tr>");
        //        str.Append("<td style=\"text-align:center\" colspan=\"4\"><strong>Average Rating(Both Supervisor and Reviewer)</strong></td>" +
        //        "<td style=\"text-align:center\" colspan=\"3\"><strong>" + row["Total Weight Average"].ToString() + "</strong></td>");
        //        str.Append("</tr>");
        //    }

        //    str.Append("</table>");
        //    setSection2.InnerHtml = str.ToString();

        //}
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
            DataTable dt = _arDao.GetdetailReport(GetAppraisalId(), "", "").Tables[2];
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
                    str.AppendLine("<td align=\"left\"><div style = \"border:solid 1px #666666;\">" + (dr["comments"].ToString() != "" ? dr["comments"].ToString() : " - ") +"</div></td>");
                }
                str.AppendLine("</tr>");

            }
            str.AppendLine("</table>");
            return str.ToString();
        }
        #endregion

        #region AppraiserComments
            private void SetAppraiserComments()
            {
                var dt = _arDao.GetSection3(GetAppraisalId());
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
                var dt = _arDao.GetSection4(GetAppraisalId());
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
                var dr = _arDao.GetSection5(GetAppraisalId());
                if (dr == null)
                    return;
                radioChk.SelectedValue = dr["soleComment"].ToString();
                radioChk.SelectedItem.Attributes.CssStyle.Add("font-weight", "bold");
                reviewrsComment.InnerText = dr["comments"].ToString();
            }
        #endregion

        #region Section 6
        public void ShowSection6()
        {
            var dt = _arDao.GetSection6(GetAppraisalId());
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

        #region Section 7
            private void ShowSection7()
        {

            var dr = _arDao.GetSection7(GetAppraisalId(), GetEmployeeId());
            if (dr == null)
                return;
            rdoResponse.Text = dr["soleComment"].ToString();
            divComments.InnerHtml = dr["comments"].ToString();               
        }
        #endregion

        #region Section 8
        private void ShowSection8()
        {
            var dt = _arDao.GetSection8(GetAppraisalId());
            if (dt == null)
                return;

            var sb = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");            
            sb.Append("<tr>");
            sb.Append("<th width=\"30%\"> Particular </th>");
            sb.Append("<th> Comments </th>");
            sb.Append("</tr>");
            foreach(DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + dr["question"].ToString() + "</td>");
                sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + dr["comments"].ToString() + "</div><br/><br/><br/></td>");             
                sb.Append("</tr>");                
            }
            sb.Append("</table>");
            setSection8.InnerHtml = sb.ToString();

        }
        #endregion

        #region setReviewCommittee
        private void setReviewRatingOverall()
        {
            var dr = _arDao.GetReviewCommitteeRating(GetAppraisalId());
            if (dr == null)
                return;
            reviewCommitteeChk.SelectedValue = dr["soleComment"].ToString();
            reviewCommitteeChk.SelectedItem.Attributes.CssStyle.Add("font-weight", "bold");
        }
        private void ShowReviewCommittee()
        {
            var dt = _arDao.GetReviewCommittee(GetAppraisalId(), GetEmployeeId());
            if (dt == null)
                return;

            var sb = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL2\" cellpadding=\"2\" cellspacing=\"0\" align=\"center\">");
            sb.Append("<tr>");
            sb.Append("<th width=\"30%\"> Name (Committee Member) </th>");
            sb.Append("<th> Date </th>");
            sb.Append("<th> Comments </th>");
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td>" + dr["name"].ToString() + "</td>");            
                sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + dr["appDate"].ToString() + "</div></td>");            
                sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + dr["comment"].ToString() + "</div></td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            setReviewCommittee.InnerHtml = sb.ToString();

        }
        #endregion

        #region AppraiseeComment
            private void SetAppraiseeComment()
        {
            DataTable dt = _arDao.GetdetailReport(GetAppraisalId(),GetEmployeeId(),"").Tables[4];
            foreach (DataRow dr in dt.Rows)
            {
                rdoResponse.Text = dr["soleComment"].ToString();
                //txtComments.Text = dr["comments"].ToString();
                divComments.InnerText = dr["comments"].ToString();
            }
        }
        #endregion

        //private void SetCEOComment()
        //{
        //   DataTable dt = _arDao.GetdetailReport(GetAppraisalId(), CEOID().ToString(), "").Tables[4];
        //   foreach (DataRow dr in dt.Rows)
        //   {
        //      // txtCEOComment.Text = dr["comments"].ToString();
        //       divCeoComment.InnerText = dr["comments"].ToString();
        //   }
        //}

        //#region HRSection

        //private void SetHRSection()
        //{
        //    var str = new StringBuilder("<table width=\"100%\" border=\"0\" align=\"center\">");
        //    DataTable dt = _arDao.GetdetailReport(GetAppraisalId(), "", "").Tables[2];
        //    var previousSection = "";
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        var currentSection = dr["section"].ToString();
        //        if (dr["sectionId"].ToString() == "Section VII")
        //        {
        //            if (currentSection != previousSection)
        //            {
        //                previousSection = currentSection;
        //                str.AppendLine("<tr>");
        //                str.AppendLine("<td>");
        //                str.AppendLine("<b>" + dr["Title"].ToString() + "</b>");
        //                str.AppendLine("</td>");
        //                str.AppendLine("</tr>");
        //                str.AppendLine("<tr>");
        //                str.AppendLine("<td>");
        //                var html = PopulateComment(ref dt, currentSection, dr["comments"].ToString());
        //                str.AppendLine(html);
        //                str.AppendLine("</td>");
        //                str.AppendLine("</tr>");
        //            }
        //        }
        //    }
        //    str.Append("</table>");
        //    setSection7.InnerHtml = str.ToString();
        //}
        //private string PopulateComment(ref DataTable dt, string typeId, string comments)
        //{
        //    DataRow[] rows = dt.Select("section='" + typeId + "'");
        //    var str = new StringBuilder();
        //    str.AppendLine("<table width=\"700\" border=\"0\" class=\"TBL2\" cellpadding=\"5\" cellspacing=\"0\" align=\"left\">");

        //    foreach (DataRow dr in rows)
        //    {
        //        var question_id = dr["appOtherSectionId"].ToString();
        //        str.AppendLine("<tr>");
        //        str.AppendLine("<td align=\"left\" width=\"400px\">");
        //        str.AppendLine("<div style = \"margin-left:20px\">" + dr["question"].ToString() + "</td>");
        //        str.AppendLine("<td align=\"left\"><div style = \"margin-left:none\"><textarea disabled=\"disabled\" rows=\"2\" cols=\"20\" overflow=\"auto\" style=\"height:50px;width:275px;text-align:top;text-mode:multiline;border-color:#999999\">" + dr["comments"].ToString() + "</textarea></td>");
        //        str.AppendLine("</tr>");
        //    }
        //    str.AppendLine("</table>");
        //    return str.ToString();
        //}

        //#endregion

        //#region HRAction

        //private void SetHRAction()
        //{
        //    var str = new StringBuilder("<table width=\"100%\" class=\"TBL2\" border=\"0\" align=\"center\">");
        //    DataTable dt = _arDao.GetdetailReport(GetAppraisalId(), "", "").Tables[2];
        //    var previousSection = "";
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        var currentSection = dr["section"].ToString();
        //        if (dr["sectionId"].ToString() == "Action(s) taken by HR Department")
        //        {
        //            if (currentSection != previousSection)
        //            {
        //                previousSection = currentSection;
        //                str.AppendLine("<tr>");
        //                str.AppendLine("<td>");
        //                str.AppendLine("<b>" + dr["Title"].ToString() + "</b>");
        //                str.AppendLine("</td>");
        //                str.AppendLine("</tr>");
        //                str.AppendLine("<tr>");
        //                str.AppendLine("<td>");
        //                var html = PopulateComment(ref dt, currentSection, dr["comments"].ToString());
        //                str.AppendLine(html);
        //                str.AppendLine("</td>");
        //                str.AppendLine("</tr>");
        //            }
        //        }
        //    }
        //    str.Append("</table>");
        //    sethraction.InnerHtml = str.ToString();
        //}


        //#endregion

        #region HrMember

        //private void SetHrMember()
        //{
        //    StringBuilder str = new StringBuilder("<table border=\"0\" cellpadding=\"2\" cellspacing=\"2\" width=\"700px\" class=\"TBL2\">");
        //    DataTable dt = _arDao.GetHrCommittee(GetEmployeeId().ToString());
        //    int cols = dt.Columns.Count;
        //    int sn = 0;
        //    str.Append("<tr>");
        //    str.Append("<th width=\"20px\">SN</th>");
        //    for(int i =0; i<cols; i++)
        //    {
        //        str.Append("<th align=\"center\">" + dt.Columns[i].ColumnName + "</th>");
        //    }
        //    str.Append("<th align=\"center\">Signature</th>");
        //    str.Append("</tr>");

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        str.Append("<tr>");
        //        str.Append("<td width=\"20px\" align=\"center\">" + (++sn) + "</td>");
        //        for(int i =0; i<cols; i++)
        //        {
        //            str.Append("<td align=\"left\" width=\"200px\">" + dr[i].ToString() + "</td>");
        //        }
        //        str.Append("<td width=\"200px\"></td>");
        //        str.Append("</tr>");
        //    }
        //    str.Append("</table>");
        //    hrcommittee.InnerHtml = str.ToString();
        //}

        #endregion

        private void GetEmployeeName()
        {
            DataTable dt = _arDao.CommentByList(GetAppraisalId());
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["raterTypeFlag"].ToString() == "s")
                {
                    lblAppraiser.Text = dr["EmpName"].ToString();
                    lblSDate.Text = dr["commentDate"].ToString();
                }
                else if (dr["raterTypeFlag"].ToString() == "r")
                {
                    lblReviewer.Text = dr["EmpName"].ToString();
                    lblRDate.Text = dr["commentDate"].ToString();
                }
                else if (dr["raterTypeFlag"].ToString() == "h")
                {
                    lblHrName.Text = dr["EmpName"].ToString();
                    lblHrDate.Text = dr["commentDate"].ToString();
                }
                else if (dr["raterTypeFlag"].ToString() == "a")
                {
                    lblAppraisee.Text = dr["EmpName"].ToString();
                    lblADate.Text = dr["commentDate"].ToString();
                }

            }

        }

        #region HRAction
        private void ShowHRAction()
        {
            var dr = _arDao.GetHRAction(GetAppraisalId());
            if (dr == null)
                return;

            txtLetterIssuedOn.InnerHtml = dr["letterissuedOn"].ToString();
            txtSalaryIncrement.InnerHtml = dr["incrementEffectedOn"].ToString();
        }
        #endregion
    }
}
