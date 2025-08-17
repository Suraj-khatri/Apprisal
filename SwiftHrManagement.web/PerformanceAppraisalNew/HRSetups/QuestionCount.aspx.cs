using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.web.Library;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class QuestionCount : BasePage
    {
        AppraisalDAO _appraisal = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO swift = null;

        public QuestionCount()
        {
            _appraisal = new AppraisalDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this.swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1111) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            PopulateddlQstnGrp();
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (ddlQuestionGroup.SelectedItem.ToString() == "KRA" && string.IsNullOrEmpty(txtRatingCeiling.Text))
            {
                GetStatic.SweetAlertMessage(this,"KRA Rating cannot be empty","");
                return;
            }
            if (ddlQuestionGroup.SelectedItem.ToString() == "KPI per KRA" && string.IsNullOrEmpty(txtRatingCeiling.Text))
            {
                GetStatic.SweetAlertMessage(this, "KPI per KRA Rating cannot be empty", "");
                return;
            }
            string res = _appraisal.QuestionCountSetup(ddlQuestionGroup.SelectedItem.ToString(), txtNoOfQstn.Text, txtTotalWeight.Text, txtRatingCeiling.Text, ReadSession().UserName.ToString());

            if (res == "SUCCESS")
            {
                GetStatic.AlertMessage(this, "Data saved successfully!");
                hdnId2.Value = "";
                LoadGrid();
                ClearAllFields();
            }
            else if (res == "Duplicate")
            {
                GetStatic.AlertMessage(this, "Cannot Insert Same Question Type Multiple times!");
            }
            else
            {
                GetStatic.AlertMessage(this, "Some error occured while saving!");
            }
        }

        private void ClearAllFields()
        {
            ddlQuestionGroup.SelectedValue = "";
            txtNoOfQstn.Text = "";
            txtTotalWeight.Text = "";
            txtRatingCeiling.Text = "";
        }

        private void PopulateddlQstnGrp()
        {
            string selectValue = "";
            if (ddlQuestionGroup.SelectedItem != null)
                selectValue = ddlQuestionGroup.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlQuestionGroup, "Exec ProcStaticDataView 's','108'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void LoadGrid()
        {
            var dt = _appraisal.GetQuestionCountTable();

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                app_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString();

                if (rowId == hdnId2.Value)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>  <label>" + item["QuestionGroupId"].ToString() + "</label>");
                    //sb.AppendLine("<td><input type=\"text\" name=\"\" value=\"" + item["QuestionGroupId"].ToString() + "\" class=\"form-control\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"NoOfQuestion\" value=\"" + item["maxNoOfQues"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" id=\"TW"+rowId+"\" name=\"TotalWeightage\" value=\"" + item["TotalWeightage"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    sb.AppendLine("<td><input type=\"text\" id=\"RC"+rowId+"\" name=\"RatingCeiling\" value=\"" + item["RatingCeiling"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditData(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"Cancel(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                else
                {
                    sb.AppendLine("<tr>");
                    //sb.AppendLine("<td>" + item["QuestionGroupId"].ToString() + "</td>");
                    sb.AppendLine("<td>  <label>" + item["QuestionGroupId"].ToString() + "</label>");
                    sb.AppendLine("<td>" + item["maxNoOfQues"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["TotalWeightage"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["RatingCeiling"].ToString() + "</td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"#\" onclick=\"onDelete(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                sb.AppendLine("</tr>");
            }
            app_grid.InnerHtml = sb.ToString();
        }
        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            _appraisal.DeleteQuestionCount(hdnId1.Value);
            LoadGrid();
        }

        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        bool IsNumber(string NoOfQuestion)
        {
            return NoOfQuestion.Any() && NoOfQuestion.All(c => Char.IsDigit(c));

        }
        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string NoOfQuestion = "";
            string TotalWeightage = "";
            string RatingCeiling = "";
            if (Request.Form["QuestionGroupId"] == "KRA" && string.IsNullOrEmpty(Request.Form["RatingCeiling"]))
            {
                GetStatic.SweetAlertMessage(this,"KRA rating should not be empty","");
                return;
            }
            if (Request.Form["QuestionGroupId"] == "KPI per KRA" && string.IsNullOrEmpty(Request.Form["RatingCeiling"]))
            {
                GetStatic.SweetAlertMessage(this, "KPI per KRA rating should not be empty", "");
                return;
            }
            if (!string.IsNullOrEmpty(Request.Form["NoOfQuestion"]))
            {
                NoOfQuestion = Request.Form["NoOfQuestion"].ToString();
                if (Regex.IsMatch(NoOfQuestion, @"^\d+$") == false)
                {
                    GetStatic.AlertMessage(this, "NoOfQuestion must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }
            if (!string.IsNullOrEmpty(Request.Form["TotalWeightage"]))
            {
                TotalWeightage = Request.Form["TotalWeightage"].ToString();
                if (Regex.IsMatch(TotalWeightage, @"([0-9.])+") == false)
                {
                    GetStatic.AlertMessage(this, "TotalWeight must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }
            if (!string.IsNullOrEmpty(Request.Form["RatingCeiling"]))
            {
                 RatingCeiling = Request.Form["RatingCeiling"].ToString();
                 if (Regex.IsMatch(RatingCeiling, @"([0-9.])+") == false)
                {
                      GetStatic.AlertMessage(this, "RatingCeiling must be in number");
                return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }

            string res = _appraisal.EditQuestionCount(filterstring(NoOfQuestion), filterstring(TotalWeightage), RatingCeiling, ReadSession().UserName.ToString(), hdnId2.Value);

            if (res == "SUCCESS")
            {
                GetStatic.AlertMessage(this, "Data updated successfully!");
                hdnId2.Value = "";
                LoadGrid();
                ClearAllFields();
            }
         
            else
            {
                GetStatic.AlertMessage(this, "Some error occured while updating!");
            }
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            hdnId2.Value = "";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

    }
}