using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.PerformanceAppraisal.Matrix;

namespace SwiftHrManagement.web.PerformanceAppraisal.Details
{
    public partial class ManageMatrix : BasePage
    {
        clsDAO _clsDao                  = null;
        PerformanaceMatrixDao _matrix   = null;
        SupervisorFeedbackDAO _suvDao   = null;
        
        public ManageMatrix()
        {
            _clsDao = new clsDAO();
            _matrix = new PerformanaceMatrixDao();
            _suvDao = new SupervisorFeedbackDAO();
        }

        string rating_value = "";
        string matrix_Id = "";
        protected string checkRejectStatus = "";

        protected void Page_Load(object sender, EventArgs e)
        {          
            string aa = GetRetingTypeId();
            matrix_Id = (Request.Form["rowId"] ?? "").ToString();
            rating_value = (Request.Form["ratingvalue"] ?? "").ToString();

            if (!IsPostBack)
            {
                listQuestion();
            }
        }

        private string GetRater()
        {
            var rater = _matrix.GetRater(GetappraisalId().ToString());
            return rater;
        }

        private long GetPositionId()
        {
            return Request.QueryString["positionId"] != null ? long.Parse(Request.QueryString["positionId"]) : 0;
        }

        private long GetappraisalId()
        {
            return Request.QueryString["appraisalId"] != null ? long.Parse(Request.QueryString["appraisalId"]) : 0;
        }

        public string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "");
        }

        private long GetEmployeeId()
        {
            return Request.QueryString["employeeId"] != null ? long.Parse(Request.QueryString["employeeId"]) : 0;
            //return Request.QueryString["EmpIdType"] != null ? long.Parse(Request.QueryString["EmpIdType"]) : 0;
        }

        private string GetRetingTypeId()
        {
            return Request.QueryString["ratingTypeId"] != null ? Request.QueryString["ratingTypeId"] : "";
        }

        private DateTime GetDeadLine()
        {
            return ParseDateTime(_clsDao.GetSingleresult("select [days] from  appraisalSupervisorAssignment where  SUPERVISOR_TYPE = 'sf' and  appraisal_id =" +
                                            filterstring(GetappraisalId().ToString())));
        }    

        private void populateMatrixSetupData()
        {
            DataSet ds = _matrix.PopulateMatrixSetupDataById(GetappraisalId().ToString());

            string branch_id = _clsDao.GetSingleresult("select BRANCH_ID from Appraisal where ID=" + GetappraisalId() + "");
            string appraisal_from = _clsDao.GetSingleresult("select FROM_DATE from Appraisal where ID=" + GetappraisalId() + "");
            string appraisal_to = _clsDao.GetSingleresult("select TO_DATE from Appraisal where ID=" + GetappraisalId() + "");
            DataTable dt1 = _clsDao.getDataset("Exec [proc_AppraisalReport] @flag='e',@branchId=" + filterstring(branch_id) + ","
            + " @employeeId=" + filterstring(GetEmployeeId().ToString()) + ",@fromDate=" + filterstring(appraisal_from) + ","
            + " @toDate=" + filterstring(appraisal_to) + "").Tables[0]; 

            DataTable dt = ds.Tables[0];
            var val = "";
            var dtrating = _clsDao.getDataset("SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE [TYPE_ID]=54").Tables[0];

            int cols = dt.Columns.Count;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            str.Append("<th style=\"text-align:center\"><strong>Critical Attributes</strong></th>" +
            "<th style=\"text-align:center\"><strong> Weight</strong></th><th style=\"text-align:center\"><strong> Total Weight</strong></th>" +
            "<th style=\"text-align:center\"><strong> Self Rating</strong></th><th style=\"text-align:center\"><strong> Rating by <br/>Supervisor</strong></th>" +
            " <th style=\"text-align:center\"><strong> Rating by Reviewer</strong></th><th style=\"text-align:center\">Supervisor Comment</th><th style=\"text-align:center\">Reviewer Comment</th>");
            str.Append("</tr>");

            var currentGroup = "";
            var previousGroup = "";
            foreach (DataRow row in dt.Rows)
            {
                currentGroup = row[2].ToString();

                if (currentGroup != previousGroup)
                {
                    str.Append("<tr>");
                    str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row[3].ToString() + "</font></strong></div></td>");
                    str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row[4].ToString() + "</font></strong></div></td>");
                    str.Append("</tr>");
                    previousGroup = currentGroup;
                }
               
                str.Append("<tr>");
                str.Append("<td align=\"left\" ><div style = \"margin-left:20px\">" + row[0].ToString() + ". " + row[5].ToString() + "</td>");
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row[6].ToString() + "</td>");
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row[7].ToString() + "</td>");

                str.Append("<td align=\"left\" nowrap='nowrap'>" + PopulateDDL(1, row[1].ToString(), row["a"].ToString(), row["ar_a"].ToString(), row["comment_a"].ToString(), ref dtrating) + "</td>");
                str.Append("<td align=\"left\" nowrap='nowrap'>" + PopulateDDL(2, row[1].ToString(), row["s"].ToString(), row["ar_s"].ToString(), row["comment_s"].ToString(), ref dtrating) + "</td>");
                str.Append("<td align=\"left\" nowrap='nowrap'>" + PopulateDDL(3, row[1].ToString(), row["r"].ToString(), row["ar_r"].ToString(), row["comment_r"].ToString(), ref dtrating) + "</td>");
                
                str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row[11].ToString() + "</td>");
                str.Append("<td align=\"left\" disabled=\"disabled\"><input class=\"form-control\" type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + row[1].ToString() + "\" value = \"" + row[1].ToString() + "\" /></td>");
                str.Append("</tr>");

            }

            foreach (DataRow row in dt1.Rows)
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"4\"><strong>Average Rating</strong></td>" +
                "<td style=\"text-align:center\"><strong>" + row["Supervisor"].ToString() + "</strong></td>" +
                "<td style=\"text-align:center\"><strong>" + row["Reviewer"].ToString() + "</strong></td>" +
                "<td></td>");
                str.Append("</tr>");

                str.Append("<tr>");
                str.Append("<td colspan=\"4\"><strong>Average Rating(Both Supervisor and Reviewer)</strong></td>" +
                "<td style=\"text-align:center\" colspan=\"3\"><strong>" + row["Total Weight Average"].ToString() + "</strong></td>");
                str.Append("</tr>");
            }

            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();
        }

        string PopulateDDL(int id, string keyValue, string value,string rFlag,string rComments,ref DataTable dt)
        {
            var html = new StringBuilder("");
            html.Append("<select id = \"ratingvalue_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" disabled=\"disabled\" >");
             
            foreach (DataRow dr in dt.Rows)
            {
                if (value == "")
                {
                    html.Append("<option value=\"\">select</option>");
                }
                else
                {
                    html.Append("<option value = \"" + value + "\">" + value + "</option>");
                }
            }
            html.Append("</select>");
         
            if(_matrix.CheckReviewer(ReadSession().Emp_Id.ToString()) && id== 1)
            {
                if (!_suvDao.CheckRole(GetRetingTypeId()))
                {
                    html.Append("<textarea  id=\"ratingvalue_" + keyValue + "\"style=\"display:none;\" class=\"form-control\" ></textarea>");
                    html.Append("<button type=\"button\" class=\"btn btn-primary\" style=\"vertical-align:top;\" onclick=\"OnReject('" + keyValue + "','a','" + GetappraisalId() + "')\">Reject</button>"); 
                }
                    
            }
            string msg =
                _clsDao.GetSingleresult("Exec [proc_AppCheckRole] @flag='a',@emp_id=" +
                                        filterstring(ReadSession().Emp_Id.ToString()) + ","
                                        + " @app_id=" + filterstring(GetappraisalId().ToString()) + ",@role_name='sf'");

            // #### If only ,Rate type is appraisee(a) then update button enabled
            if (msg == "1" && id == 1 && rFlag == "r")
            {
                html.Append("<button type=\"button\" class=\"btn btn-primary\" style=\"vertical-align:top;\" onclick=\"OnUpdate('" + keyValue + "_a','" + GetappraisalId() + "')\">Update</button>");
            }
            return html.ToString();
        }

        //string MakeDDL(int id, string keyValue, ref DataTable dt, string valueToBeSelected, ref DataRow dtRow)

        string MakeDDL(int id, string keyValue, ref DataTable dt, string valueToBeSelected, bool enableDdl)
        {
            var html = new StringBuilder("");
            var codeForDisable = "";
            if (!enableDdl)
            {
                codeForDisable = "disabled=\"disabled\"";
            }

            if (id.Equals(1)) //&& (allowMarking)
            {
                html.Append("<select " + codeForDisable + "  onblur=\"CalculateRating('" + id + "')\" id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" ValidationGroup=\"Save\">");
                html.Append("<option value=\"\">select</option>");
                foreach (DataRow dr in dt.Rows)
                {
                    html.Append("<option value = \"" + dr["DETAIL_TITLE"].ToString() + "\"" + AutoSelect(dr["DETAIL_TITLE"].ToString(), valueToBeSelected.ToString()) + ">" + dr["DETAIL_TITLE"].ToString() + "</option>");
                }
                html.Append("</select>");
            }
            else if (id.Equals(2)) //&& (allowMarking)
            {
                html.Append("<select " + codeForDisable + " onblur=\"CalculateRating('" + id + "')\" id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" ValidationGroup=\"Save\">");
                html.Append("<option value=\"\">select</option>");
                foreach (DataRow dr in dt.Rows)
                {
                    html.Append("<option value = \"" + dr["DETAIL_TITLE"].ToString() + "\"" + AutoSelect(dr["DETAIL_TITLE"].ToString(), valueToBeSelected.ToString()) + ">" + dr["DETAIL_TITLE"].ToString() + "</option>");
                }
                html.Append("</select>");
            }
            else if (id.Equals(3)) //&& (allowMarking)
            {
                html.Append("<select " + codeForDisable + " onblur=\"CalculateRating('" + id + "')\" id = \"ratingvalue" + id + "_" + keyValue + "\" name = \"ratingvalue\" class=\"form-control\" style=\"width:75px\" ValidationGroup=\"Save\">");
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

            bool allowSelf = dtRow["allowMarking"].ToString().Equals("TRUE") && dtRow["appraisee"].ToString().Equals("TRUE") ? true : false;
            bool enableSelf = false;
          
            var dr = _matrix.checkPartialOrFinalSave(GetappraisalId(), "a");
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

            if (!allowSelf)
            {
                allowSelf = _matrix.ChekSelfRating(GetappraisalId().ToString());
                if (allowSelf)
                    enableSelf = false;
            }

            if (allowSelf || enableSelf)
            {
                str.Append("<th style=\"text-align:center\"><strong> Self Rating</strong></th>");
            }

            str.Append("<th style=\"text-align:center\" width=\"75px\" wrap=\"wrap\"><strong>  Rating by Supervisor</strong></th>");
            str.Append("<th style=\"text-align:center\" width=\"75px\" wrap=\"wrap\"><strong>  Rating by Reviewer</strong></th>");
            str.Append("<th style=\"text-align:center\">Supervisor Comment</th>");
            str.Append("<th style=\"text-align:center\">Reviewer Comment</th>");
            str.Append("</tr>");

            var currentGroup = "";
            var previousGroup = "";
            RatingValue.Value = "";
            var seprator = ",";          


            foreach (DataRow row in dt.Rows)
            {
                RatingValue.Value = RatingValue.Value + seprator + row["perAppMatSetUpId"].ToString(); //1
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

                if (allowSelf || enableSelf)
                {
                    str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(1, row["perAppMatSetUpId"].ToString(), ref dtrating, row["a"].ToString(), enableSelf) + "</div></td>"); //1
                }

                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(2, row["perAppMatSetUpId"].ToString(), ref dtrating, row["s"].ToString(), false) + "</div></td>");//1
                str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(3, row["perAppMatSetUpId"].ToString(), ref dtrating, row["r"].ToString(), false) + "</div></td>");//"perAppMatSetUpId" 


                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea disabled=\"disabled\" name=\"txtSupervisorComment\" class=\"form-control\" rows=\"2\" cols=\"20\" overflow=\"auto\" style=\"height:50px;width:175px;text-align:top;text-mode:multiline\">" + row["sComment"].ToString() + "</textarea></td>");
                str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><textarea disabled=\"disabled\" name=\"txtReviewerComment\" class=\"form-control\" rows=\"2\" cols=\"20\" overflow=\"auto\" style=\"height:50px;width:175px;text-align:top;text-mode:multiline\" >" + row["rComment"].ToString() + "</textarea>");
                str.Append(" <input type=\"hidden\" name= \"rowId\" class=\"form-control\"  id=\"rowId_ " + row["perAppMatSetUpId"].ToString() + "\" value = \"" + row["perAppMatSetUpId"].ToString() + "\" /></td>");      
                //str.Append("<td align=\"left\"><div style = \"margin-left:8px\">" + row["weightedAverage"].ToString() + "</div><input type=\"hidden\" name= \"rowId\"  id=\"rowId_ " + row["perAppMatSetUpId"].ToString() + "\" value = \"" + row[1].ToString() + "\" /></td>");
                str.Append("</tr>");
            }

            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();

            dr = _matrix.checkPartialOrFinalSave(GetappraisalId(), "r");
            if (dr == null)
                return;

            if (dr["setFlag"].ToString().Trim().ToLower().Equals("sf"))
            {
                if (System.DateTime.Now < GetDeadLine())
                {
                    if (GetEmployeeId() == ReadSession().Emp_Id)
                    {
                        Panel1.Visible = true;
                        btnSaveFinal.Visible = true;
                    }
                }
                else
                {
                    btnSaveFinal.Visible = false;
                }               
                DisplaySoleComment();
            }


            //foreach (DataRow row in dt.Rows)
            //{
            //    RatingValue.Value = RatingValue.Value + seprator + row[1].ToString();
            //    currentGroup = row[2].ToString();
            //    if (currentGroup != previousGroup)
            //    {
            //        str.Append("<tr>");
            //        str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row[3].ToString() + "</font></strong></div></td>");
            //        str.Append("<td align=\"left\"><div style = \"margin-left:8px\"><strong><font size=\"-1\">" + row[4].ToString() + "</font></strong></div></td>");
            //        str.Append("</tr>");
            //        previousGroup = currentGroup;
            //    }

            //    str.Append("<tr>");
            //    str.Append("<td align=\"left\"><div style = \"margin-left:20px\" >" + row[0].ToString() + ". " + row[5].ToString() + "</td>");
            //    str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row[6].ToString() + "</td>");
            //    str.Append("<td align=\"center\"><div style = \"margin-left:none\">" + row[7].ToString() + "</td>");

            //    if (allowSelf || enableSelf)
            //    {
            //        str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(1, row[1].ToString(), ref dtrating, row["a"].ToString(), enableSelf) + "</td>");
            //    }

            //    str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(2, row[1].ToString(), ref dtrating, row["s"].ToString(), false) + "</td>");
            //    str.Append("<td align=\"left\"><div style = \"margin-left:none\">" + MakeDDL(3, row[1].ToString(), ref dtrating, row["r"].ToString(), false) + "</td>");
            //    str.Append("<td align=\"left\"><div style = \"margin-left:8px\">" + row["weightedAverage"].ToString() + "<input type=\"text\" name= \"rowId\"  id=\"rowId_ " + row[1].ToString() + "\" value = \"" + row[1].ToString() + "\" /></div></td>");
            //    str.Append("</tr>");
            //}
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

                //DivMsg.InnerHtml = msg;
                //DivMsg.Attributes.Add("class", "warning");
                //listQuestion();
                return;
            }

            DataTable dt = _matrix.OnSave(GetappraisalId().ToString(), matrix_Id, ReadSession().Emp_Id.ToString(), rating_value, "a","sf","");
            // setFlag "sf" denote save and forward that means apprisal process has been complete, user can not modify record.
            DataRow dr = dt.Rows[0];
            PrintMessage(dr);

            //if (dr["error_code"].ToString() == "0")
            //{
            //    DivMsg.InnerText = dr["msg"].ToString();
            //    confirmMsg.InnerText = dr["msg"].ToString();
            //    DivMsg.Attributes.Add("class", "success");
            //    Response.Redirect("ManageMatrix.aspx?appraisalId=" + GetappraisalId() + "&positionId=" + GetPositionId() + "&EmpId=" + GetEmployeeId() + "&ratingTypeId="+GetRetingTypeId()+"&flag=p");
            //}
            //else
            //{
            //    DivMsg.InnerText = dr["msg"].ToString();
            //    confirmMsg.InnerText = dr["msg"].ToString();
            //    DivMsg.Attributes.Add("class", "warning");
            //}           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           OnSave();   
        }

        protected void btnSaveFinal_Click(object sender, EventArgs e)
        {
            var dr = _matrix.InsertComments(GetappraisalId().ToString(), rdoResponse.SelectedValue, txtComments.Text, ReadSession().Emp_Id.ToString());
            btnSaveFinal.Visible = false;
            PrintMessage(dr);         
            //DataTable dt = new DataTable();           
            //dt.Columns.Add("error_code");
            //dt.Columns.Add("msg");
            //dt.Rows.Add("0",msg);
              
            
            //DivMsg.InnerText = msg;
            //confirmMsg.InnerText = msg;
            //DivMsg.Attributes.Add("class", "success");
            //btnSaveFinal.Visible = false;
        }

        private void DisplaySoleComment()
        {
            Panel1.Visible = true;
            long commenter = 0;

            if (GetEmployeeId() == ReadSession().Emp_Id)
            {
                commenter = ReadSession().Emp_Id;
            }
            else
            {
                commenter = long.Parse(_clsDao.GetSingleresult("select EMPLOYEE_ID from appraisal where ID="+ GetappraisalId().ToString()));
            }

            DataTable dt = _matrix.FindSoleComment(GetappraisalId(), commenter);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            rdoResponse.Text = dr["soleComment"].ToString();
            txtComments.Text = dr["comments"].ToString();
            btnSaveFinal.Visible = false;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string[] arrayMatrixIdFlag = hdnMatrixId.Value.Split('_');
            string matrixId = arrayMatrixIdFlag[0];
            string raterType = arrayMatrixIdFlag[1];

            var sql = "exec [proc_AppraiserRating] @flag='ru',@rating= " + filterstring(hdnRating.Value) + ","
                  + "@appraisalId=" + GetappraisalId() + ",@matrixId=" + matrixId + ",@raterType=" + filterstring(raterType); 

            //var sql = "update appraisalRating set R_flag = 's'"
            //+" ,rating = "+hdnRating.Value+" where appraisalId = "+GetappraisalId()+" and matrixId ="+matrixId+" and raterType ="+filterstring(raterType)+"";

            _clsDao.runSQL(sql);
            Response.Redirect("ManageMatrix.aspx?appraisalId=" + GetappraisalId() + "&positionId=" + GetPositionId() + "&employeeId=" + GetEmployeeId() + "&ratingTypeId=" + GetRetingTypeId() + "&flag=p");

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            _suvDao.OnReject(hdnRemarks.Value, hdnRaterType.Value, GetappraisalId().ToString(), hdnMatrixId.Value); 
           
        }

        protected void btnPartialSave_Click(object sender, EventArgs e)
        {
            DataTable dt = _matrix.OnSave(GetappraisalId().ToString(), matrix_Id, ReadSession().Emp_Id.ToString(), rating_value, "a","p","");
            DataRow dr = dt.Rows[0];

            PrintMessage(dr);

            //if (dr["error_code"].ToString() == "0")
            //{
            //    DivMsg.InnerText = dr["msg"].ToString();
            //    confirmMsg.InnerText = dr["msg"].ToString();
            //    DivMsg.Attributes.Add("class", "success");
            //    Response.Redirect("ManageMatrix.aspx?appraisalId=" + GetappraisalId() + "&positionId=" + GetPositionId() + "&employeeId=" + GetEmployeeId() + "&ratingTypeId=" + GetRetingTypeId() + "");
            //}
            //else
            //{
            //    DivMsg.InnerText = dr["msg"].ToString();
            //    confirmMsg.InnerText = dr["msg"].ToString();
            //    DivMsg.Attributes.Add("class", "warning");
            //}            
        }

        private void PrintMessage(DataRow dr)
        {
            var url = "ManageMatrix.aspx?EmpIdType= " + ReadSession().Emp_Id + "&EmpID=" + GetEmployeeId() + "&appraisalId=" + GetappraisalId() + "&positionId=" + GetPositionId() + "&ratingTypeId=" + GetRetingTypeId();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printMsg", "PrintMessage('" + dr["error_code"].ToString().Trim() + "','" + dr["msg"].ToString().Trim() + "','" + url + "');", true);
        }
    }
}
