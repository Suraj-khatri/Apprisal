using System;
using System.Web.UI;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class PerformanceRatingReference : BasePage
    {
        AppraisalDAO _appraisal = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public PerformanceRatingReference()
        {
            _appraisal = new AppraisalDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1113) == false)
            {
                Response.Redirect("/Error.aspx");
            }  
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            string res = _appraisal.PerformanceRating(KRARatings1.Text, KRARatings2.Text, KRARatings3.Text, ReadSession().UserName.ToString());

            if (res == "SUCCESS")
            {
                GetStatic.AlertMessage(this, "Data saved successfully!");
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.AlertMessage(this, "Some error occured while saving!");
            }
        }

        private void ClearContent()
        {
            KRARatings1.Text = "";
            KRARatings2.Text = "";
            KRARatings3.Text = "";
        }

        private void LoadGrid()
        {
            var dt = _appraisal.GetPerformanceTable();

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
                    sb.AppendLine("<td><input type=\"text\" name=\"kraScore\" value=\"" + item["KraAchiveScore"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"perFormance\" value=\"" + item["PerformLblRating"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" id = \"PI"+rowId+"\" name=\"percentIncrement\" value=\"" + (string.IsNullOrWhiteSpace(item["PercentIncrement"].ToString()) ? "0" :item["PercentIncrement"].ToString()) + "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditData(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"Cancel(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                else
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");
                    sb.AppendLine("<td>" + (string.IsNullOrWhiteSpace(item["PercentIncrement"].ToString()) ? "0" : item["PercentIncrement"].ToString()) + "</td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"#\" onclick=\"onDelete(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                sb.AppendLine("</tr>");
            }
            app_grid.InnerHtml = sb.ToString();
        }

        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            _appraisal.DeleteReocrd(hdnId1.Value);
            LoadGrid();
        }

        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string KraScore = "";
            string PerformLblRating = "";
            string PercentIncrement = "";

            //if (!string.IsNullOrEmpty(Request.Form["kraScore"]))
            //    kraScore = filterstring(Request.Form["kraScore"].ToString());
            //if (!string.IsNullOrEmpty(Request.Form["perFormance"]))
            //    PerformLblRating = filterstring(Request.Form["perFormance"].ToString());
            //if (!string.IsNullOrEmpty(Request.Form["percentIncrement"]))
            //    PercentIncrement = filterstring(Request.Form["percentIncrement"].ToString());

            if (!string.IsNullOrEmpty(Request.Form["kraScore"]))
            {
                KraScore = Request.Form["kraScore"].ToString();
                //if (Regex.IsMatch(KraScore, @"^\d+$") == false)
                //{
                //    GetStatic.AlertMessage(this, "kraScore must be in number");
                //    return;
                //}
            }
            else
            {
                GetStatic.AlertMessage(this, "kraScore Should not be empty");
                return;
            }
            if (!string.IsNullOrEmpty(Request.Form["perFormance"]))
            {
                PerformLblRating = Request.Form["perFormance"].ToString();
                //if (Regex.IsMatch(PerformLblRating, @"^\d+$") == false)
                //{
                //    GetStatic.AlertMessage(this, "PerformLblRating must be in number");
                //    return;
                //}
            }
            else
            {
                GetStatic.AlertMessage(this, "PerformLblRating Should not be empty");
                return;
            }
            if (!string.IsNullOrEmpty(Request.Form["percentIncrement"]))
            {
                PercentIncrement = Request.Form["percentIncrement"].ToString();
                if (Regex.IsMatch(PercentIncrement, @"([0-9.])+") == false)
                {
                    GetStatic.AlertMessage(this, "Percent Increment must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Percent Increment Should not be empty");
                return;
            }

            string res = _appraisal.EditData(KraScore, PerformLblRating, PercentIncrement, ReadSession().UserName.ToString(), hdnId2.Value);

            if (res == "SUCCESS")
            {
                GetStatic.AlertMessage(this, "Data updated successfully!");
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
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