using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.PerformanceAppraisal.Matrix;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalFeedback
{
    public partial class SupervisorFeedback : BasePage
    {
        private clsDAO _clsDao = null;
        private SupervisorFeedbackDAO _sfDao = null;
        private PerformanaceMatrixDao _matrix = null;

        public SupervisorFeedback()
        {
            _clsDao = new clsDAO();
            _sfDao = new SupervisorFeedbackDAO();
            _matrix = new PerformanaceMatrixDao();
        }

        string appraisal_fb_list = "";
        string appraisal_fb_id_list = "";
        string matrix_Id = "";
        string rating_value = "";
        string superVisorComment = "";
        string section6Ans = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            matrix_Id = (Request.Form["rowId"] ?? "").ToString();
            rating_value = (Request.Form["ratingvalue"] ?? "").ToString();
            appraisal_fb_list = (Request.Form["appraisal_fb"] ?? "").ToString();
            appraisal_fb_id_list = (Request.Form["appraisal_fb_id"] ?? "").ToString();
            superVisorComment = (Request.Form["txtSupervisorComment"] ?? "").ToString();
            section6Ans = (Request.Form["section6"] ?? "").ToString();
            if (!IsPostBack)
            {
                //load appraisee rating and display question for appraisal 
                listQuestion();
                // another section question load and display after rating
                SetSection2();
                // another section question load and display after rating
                SetSection6();               
            }
            
        }

        private long GetAppraisalId()
        {
            return ReadNumericDataFromQueryString("AppraisalId");
        }

        private long GetFlag()
        {
            return ReadNumericDataFromQueryString("flag");
        }

        private long GetPositionId()
        {
            return ReadNumericDataFromQueryString("positionId");
        }

        private long GetEmployeeId()
        {
            return ReadNumericDataFromQueryString("employeeId");
        }

        private string GetRetingTypeId()
        {
            return Request.QueryString["ratingTypeId"] != null ? Request.QueryString["ratingTypeId"] : "";
        }

        private long GetRatingType()
        {
            return ReadNumericDataFromQueryString("ratingTypeId");
        }

        private long GetappraisalId()
        {
            return Request.QueryString["appraisalId"] != null ? long.Parse(Request.QueryString["appraisalId"]) : 0;
        }

        private string GetSupervisorId()
        {
            return ReadNumericDataFromQueryString("EmpIdType").ToString();
        }

        private DateTime GetDeadLine()
        {
            DateTime enddate = ParseDateTime((_clsDao.GetSingleresult("select [days] from  appraisalSupervisorAssignment where  SUPERVISOR_TYPE = 's' and appraisal_id =" +
                                            filterstring(GetAppraisalId().ToString()))));
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
            else if (id.Equals(2)) //&& (allowMarking)
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


            bool allowSelf = dtRow["allowMarking"].ToString().Equals("TRUE") && dtRow["appraiser"].ToString().Equals("TRUE") ? true : false;
            
            bool enableSelf = false;
            bool enableAppraisee = false;

            var dr = _matrix.checkPartialOrFinalSave(GetappraisalId(), "s");
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
            RatingValue.Value = "";
            var seprator = ",";
            float toTalEverage = 0;

            foreach (DataRow row in dt.Rows)
            {
                RatingValue.Value = RatingValue.Value + seprator + row["perAppMatSetUpId"].ToString();
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

                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(2, row["perAppMatSetUpId"].ToString(), ref dtrating, row["s"].ToString(), enableSelf) + "</td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(3, row["perAppMatSetUpId"].ToString(), ref dtrating, row["r"].ToString(), false) + "</td>"); //class=\"inputTextBoxLP1\"


                if (row["s"].ToString() == "")
                {
                    str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea id=\"super_" + row["perAppMatSetUpId"].ToString() + "\" class=\"form-control commentArea\"  name=\"txtSupervisorComment\" " + (!enableSelf ? "disabled=\"disabled\"" : "") + " rows=\"2\" cols=\"20\" overflow=\"auto\">" + row["sComment"].ToString() + "</textarea></td>");
                }
                else {
                    str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea id=\"super_" + row["perAppMatSetUpId"].ToString() + "\" class=\"form-control commentArea super_commentArea \"  name=\"txtSupervisorComment\" " + (!enableSelf ? "disabled=\"disabled\"" : "") + " rows=\"2\" cols=\"20\" overflow=\"auto\">" + row["sComment"].ToString() + "</textarea></td>");                
                }

                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea id=\"review_" + row["perAppMatSetUpId"].ToString() + "\" name=\"txtReviewerComment\" class=\"form-control\" disabled=\"disabled\" rows=\"2\" cols=\"20\" overflow=\"auto\">" + row["rComment"].ToString() + "</textarea>");
                str.Append(" <input class=\"form-control\" type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + row["perAppMatSetUpId"].ToString() + "\" value = \"" + row["perAppMatSetUpId"].ToString() + "\" /></td>");                  
                //str.Append("<td align=\"left\"><div style = \"margin-left:8px\">" + (row["weightedAverage"].ToString().Equals("0") ? "" : row["weightedAverage"].ToString()) + "</div><input type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + row["perAppMatSetUpId"].ToString() + "\" value = \"" + row[1].ToString() + "\" /></td>");
                toTalEverage += string.IsNullOrWhiteSpace(row["weightedAverage"].ToString()) ? 0 : float.Parse(row["weightedAverage"].ToString());
                str.Append("</tr>");
            }            
          
            var colSpan = enableAppraisee ? 4 : 3;
            var sumValue = "";
            if (toTalEverage > 0 && toTalEverage < 20)
                sumValue = toTalEverage.ToString() + "&nbsp" + "Substandard";
            else if(toTalEverage>=20 && toTalEverage<40)
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
            matrix.InnerHtml = str.ToString();
        }

        
        #region supervisor region
        string CreateDdl(string keyValue, string name)
        {
            var html = new StringBuilder("");
            html.Append("<select id = \"ratingvalue_" + keyValue + "\" name = \"" + name + "\" class=\"form-control\" style=\"width:100px\">");
                html.Append("<option value=\"\">Select</option>");
                html.Append("<option value = \"YES\">Yes</option>");
                html.Append("<option value = \"NO\">No</option>");
                html.Append("</select>");
            return html.ToString();
        }


        // Generate text and combo for the question and rating
        private string PrintList(ref DataTable dt, string typeId)
        {
            DataRow[] rows = dt.Select("section='" + typeId + "'");
            var str = new StringBuilder();
            str.AppendLine("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.AppendLine("<tr>");
            str.AppendLine("<th style=\"text-align:center\"><strong>Comments</strong></th>");
            str.AppendLine("<th style=\"text-align:center\"><strong> Feedback </strong></th>");
            str.AppendLine("</tr>");

            var elementName = "appraisal_fb";
            var elementNameId = "appraisal_fb_id";
            var appraisal_id = GetAppraisalId().ToString();
           
                foreach (DataRow dr in rows)
                {
                    var question_id = dr["appOtherSectionId"].ToString();
                    str.AppendLine("<tr>");
                    str.AppendLine("<td align=\"left\" width=\"400px\">");
                    str.AppendLine("<input class=\"form-control\" type = \"hidden\" value = \"" + question_id + "\" name = \"" + elementNameId + "\" />");
                    str.AppendLine("<div style = \"margin-left:20px\">" + dr["question"].ToString() + "</td>");

                    if (dr["answerType"].ToString() == "Yes/No")
                    {
                        str.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + CreateDdl(dr["appOtherSectionId"].ToString(), elementName) + "</div></td>");
                    }
                    else if (dr["answerType"].ToString() == "Numeric")
                    {
                        str.AppendLine("<td align=\"left\"><input type=\"text\" id=\"text_" + question_id + "\" name=\"" + elementName + "\" class=\"form-control\" onblur=\"checknumber(this.value);\"></td>");
                    }
                    else
                    {
                        str.AppendLine("<td align=\"left\"><div style = \"margin-left:none\"><textarea id=\"text_" + question_id + "\" name=\"" + elementName + "\" class=\"form-control commentArea\" rows=\"2\" cols=\"20\" overflow=\"auto\"></textarea></div></td>");
                    }
                    str.AppendLine("</tr>");

                }
                str.AppendLine("</table></div>");
    
            return str.ToString();
        }


        // another section question - Generate and display data 
        private void SetSection2()
        {
            DataTable dt1 = _sfDao.GetSection2(GetAppraisalId().ToString());
            var str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            var dt = _sfDao.SetSection2(GetAppraisalId().ToString());

            if (dt1.Rows.Count > 0)
            {
                // Populate another section Answers
                GetSection2();
            }
            else
            {
                var previousSection = "";
                foreach (DataRow dr in dt.Rows)
                {
                    var currentSection = dr["section"].ToString();
                    if (dr["sectionId"].ToString() == "Section II" || dr["sectionId"].ToString() == "Section III" ||
                           dr["sectionId"].ToString() == "Section IV")
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
                            // load question and display data after save 
                            var html = PrintList(ref dt, currentSection);
                            str.AppendLine(html);
                            str.AppendLine("</td>");
                            str.AppendLine("</tr>");
                        }
                    }
                }
                str.Append("</table><div>");
                section2.InnerHtml = str.ToString();
            }
        }

        private void SetSection6()
        {
            var dt = _sfDao.GetSection6(GetAppraisalId().ToString());
            if (dt == null)
                return;
            var _matrix = new PerformanaceMatrixDao();          

            var seperator = "";
            var elementName = "section6";

            var sb = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            //sb.Append("<tr><th colspan=\"2\">Other Information (to be filled by Appraisee)</th></tr>");
            sb.Append("<tr>");
            sb.Append("<th> Particular </th>");
            sb.Append("<th> Yes/No </th>");
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                var questionId = dr["appOtherSectionId"].ToString();

                section6Ques.Value += seperator + questionId;
                sb.Append("<tr>");
                sb.Append("<td>" + dr["question"].ToString() + "</td>");
                if (dr["answerType"].ToString() == "Numeric")
                {
                    sb.Append("<td align=\"left\"><input type=\"text\" id=\"section6_" + questionId + "\" name=\"" + elementName + "\" value =\"" + dr["comments"].ToString() + "\" class=\"form-control\" onblur=\"checknumber(this.value);\"></td>");
                }
                else if (dr["answerType"].ToString() == "Yes/No")
                {
                    sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDllForSection6(dr["appOtherSectionId"].ToString(), dr["comments"].ToString()) + "</div></td>");
                }
                else
                {
                    sb.AppendLine("<td align=\"left\"><div style = \"margin-left:none\"><textarea id=\"section6_" + questionId + "\" name=\"" + elementName + "\" class=\"form-control commentArea\" rows=\"2\" cols=\"20\" overflow=\"auto\">" + dr["comments"].ToString() + "</textarea></div></td>");

                }
                sb.Append("</tr>");
                seperator = ",";
            }
            sb.AppendLine("</table></div>");
            section6.InnerHtml = sb.ToString();
        }


        private string MakeDllForSection6(string id,string valueToBeSelected)
        {
            var html = new StringBuilder();
            html.Append("<select id = \"section6_" + id + "\" name = \"section6\" class=\"form-control\" style=\"width:75px;\">");
            html.Append("<option value=\"\" "+(string.IsNullOrWhiteSpace(valueToBeSelected)? "selected=\"selected\"":"")+">select</option>");
            html.Append("<option value=\"Yes\" " + (valueToBeSelected.Equals("Yes") ? "selected=\"selected\"" : "") + ">Yes</option>");
            html.Append("<option value=\"No\" " + (valueToBeSelected.Equals("No") ? "selected=\"selected\"" : "") + ">No</option>");
            html.Append("</select>");
            return html.ToString();
        }

        #endregion

        #region populate Data ater supervisor rating
        private void GetSection2()
        {
            var str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            var dt = _sfDao.GetSection2(GetAppraisalId().ToString());

            var previousSection = "";
            foreach (DataRow dr in dt.Rows)
            {
                var currentSection = dr["section"].ToString();
                if (dr["sectionId"].ToString() == "Section II" || dr["sectionId"].ToString() == "Section III" ||
                           dr["sectionId"].ToString() == "Section IV")
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
                        var html = PopulateList(ref dt, currentSection,dr["comments"].ToString());
                        str.AppendLine(html);
                        str.AppendLine("</td>");
                        str.AppendLine("</tr>");
                    }
                }
            }
            str.Append("</table></div>");
            section2.InnerHtml = str.ToString();
        }

        string PopulateDdl(string keyValue, string name, string comments)
        {
            var html = new StringBuilder("");
            html.Append("<select id = \"ratingvalue_" + keyValue + "\" name = \"" + name + "\" class=\"form-control\" style=\"width:100px\" >");
                html.Append("<option value=\"\">Select</option>");
                html.Append("<option value = \"YES\" ");
                if(comments=="YES")
                    html.Append("selected ");
                html.Append(">Yes</option>");
                html.Append("<option value = \"NO\" ");
                if (comments == "NO")
                    html.Append("selected ");
                html.Append(">No</option>");
                html.Append("</select>");

                

             
            return html.ToString();
        }

        private string PopulateList(ref DataTable dt, string typeId, string comments)
        {
            DataRow[] rows = dt.Select("section='" + typeId + "'");
            var str = new StringBuilder();
            str.AppendLine("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.AppendLine("<tr>");
            str.AppendLine("<th style=\"text-align:center\"><strong>Comments</strong></th>");
            str.AppendLine("<th style=\"text-align:center\"><strong> Feedback </strong></th>");
            str.AppendLine("</tr>");

            var elementName = "appraisal_fb";
            var elementNameId = "appraisal_fb_id";
            var appraisal_id = GetAppraisalId().ToString();
                foreach (DataRow dr in rows)
                {
                    var question_id = dr["appOtherSectionId"].ToString();
                    str.AppendLine("<tr>");
                    str.AppendLine("<td align=\"left\" width=\"400px\">");
                    str.AppendLine("<input type = \"hidden\" class=\"form-control\" value = \"" + question_id + "\" name = \"" + elementNameId + "\" />");
                    str.AppendLine("<div style = \"margin-left:20px\">" + dr["question"].ToString() + "</td>");

                    if (dr["answerType"].ToString() == "Yes/No")
                    {
                        str.AppendLine("<td align=\"left\"><div style = \"margin-left:none\">" + PopulateDdl(dr["appOtherSectionId"].ToString(), elementName, dr["comments"].ToString()) + "</td>");
                    }
                    else if (dr["answerType"].ToString() == "Numeric")
                    {
                        str.AppendLine("<td align=\"left\"><input type=\"text\" id=\"text_" + question_id + "\"  name=\"" + elementName + "\" class=\"form-control\" value=\"" + dr["comments"].ToString() + "\"></td>");
                    }
                    else
                    {
                        str.AppendLine("<td align=\"left\"><div style = \"margin-left:none\"><textarea id=\"text_" + question_id + "\" name=\"" + elementName + "\" class=\"form-control commentArea\" rows=\"2\" cols=\"20\" overflow=\"auto\">" + dr["comments"].ToString() + "</textarea></td>");
                    }
                    str.AppendLine("</tr>");

                }
                str.AppendLine("</table></div>");
            return str.ToString();
        }
        #endregion

        private void OnSave()
        {
            string[] ratingvalue = (Request.Form["ratingvalue"] ?? "").Split(',');
            string[] appraisalFbList;
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

            if (!string.IsNullOrWhiteSpace(appraisal_fb_list))
            {
                appraisalFbList = appraisal_fb_list.Split(',');

                if (appraisalFbList.Contains(""))
                {
                    string msg = "Please answer all question!";
                    DataTable dtMsg = new DataTable();
                    dtMsg.Columns.Add("error_code");
                    dtMsg.Columns.Add("msg");
                    dtMsg.Rows.Add("1", msg);
                    PrintMessage(dtMsg.Rows[0]);
                    return;
                }
            }
            
            DataRow dr = null;
            DataTable dt1 = _sfDao.InsertRating(GetAppraisalId().ToString(), matrix_Id, rating_value, ReadSession().Emp_Id.ToString(), "sf", superVisorComment);
            dr = _sfDao.InsertComments(GetAppraisalId().ToString(), appraisal_fb_id_list, appraisal_fb_list, ReadSession().Emp_Id.ToString(),"s");
            dr = _sfDao.InsertComments(GetAppraisalId().ToString(), section6Ques.Value, section6Ans, ReadSession().Emp_Id.ToString(), "sc");
            if (dr == null)
                return;
            
            PrintMessage(dr);
       
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            _sfDao.OnReject(hdnRemarks.Value,hdnRaterType.Value,GetAppraisalId().ToString(),hdnMatrixId.Value);
           
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(hdnMatrixId.Value =="")
            {
                return;
            }
            string[] arrayMatrixIdFlag = hdnMatrixId.Value.Split('_');
            string matrixId = arrayMatrixIdFlag[0];
            string raterType = arrayMatrixIdFlag[1];
            var sql = "exec [proc_AppraiserRating] @flag='ru',@rating= " + filterstring(hdnRating.Value) + ","
                  + "@appraisalId=" + GetAppraisalId() + ",@matrixId=" + matrixId + ",@raterType=" + filterstring(raterType);         

            _clsDao.runSQL(sql);
            listQuestion();           
           
        }

        protected void btnPartialSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rating_value))
                return;
            DataRow dr = null;

            DataTable dt1 = _sfDao.InsertRating(GetAppraisalId().ToString(), matrix_Id, rating_value, ReadSession().Emp_Id.ToString(),"p",superVisorComment);

             dr = _sfDao.InsertComments(GetAppraisalId().ToString(), appraisal_fb_id_list, appraisal_fb_list, ReadSession().Emp_Id.ToString(),"s");
             dr = _sfDao.InsertComments(GetAppraisalId().ToString(), section6Ques.Value, section6Ans, ReadSession().Emp_Id.ToString(), "sc");

             if (dr == null)
                 return;

            PrintMessage(dr);
        }

        private void PrintMessage(DataRow dr)
        {
            var url = "SupervisorFeedback.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + GetEmployeeId() + "&appraisalId=" + GetAppraisalId() + "&positionId=" + GetPositionId() + "&ratingTypeId=" + GetRetingTypeId();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printMsg", "PrintMessage('" + dr["error_code"].ToString().Trim() + "','" + dr["msg"].ToString().Trim() + "','" + url + "');", true);
        }
    }
}
