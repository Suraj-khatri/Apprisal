using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class LevelCriticalJobs : BasePage 
    {
         PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        private AppraisalDAO _appraisal = null;
        clsDAO swift = null;
        public LevelCriticalJobs()
        {
            _Obj = new PerformanceAgreementDao();  
            _RoleMenuDAOInv = new RoleMenuDAOInv();
            _appraisal = new AppraisalDAO();
            swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GetStatic.ReadQueryString("LrowId","")))
            {
                LoadLevelName();
                LoadGridCJ();
            }
            
        }
        private void LoadLevelName()
        {
            var dt = _appraisal.LoadLevelName(GetStatic.ReadQueryString("LrowId", ""));
            var comMatrixName = "";
            comMatrixName = dt.Rows[0]["LevelName"].ToString();
            lblLevelName.Text = comMatrixName;
        }

        //criticle Job
        #region Criticle Job
        private void LoadGridCJ()
        {
            var dt = _Obj.GetLevelCriticalJobsDate(GetStatic.ReadQueryString("LrowId", ""));

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                criticalJobs_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                //getAttributes(universalId.Value);
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString();

                if (rowId == hdnId2CJ.Value)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["SNO"].ToString() + "</td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"kraScore\" value=\"" + item["objectives"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" id = \"PR" + rowId + "\" name=\"perFormance\" value=\"" + item["deductionScore"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"javascript:void(0)\"onclick=\"EditDataCJ(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"javascript:void(0)\" onclick=\"CancelCJ(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                else
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["SNO"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["objectives"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["deductionScore"].ToString() + "</td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEditCJ(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"javascript:void(0)\" onclick=\"onDeleteCJ(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                sb.AppendLine("</tr>");
            }
            criticalJobs_grid.InnerHtml = sb.ToString();
            //getAttributes(universalId.Value);
            criticalJobs_grid.Focus();
        }

        protected void BtnDeleteRecordCJ_Click(object sender, EventArgs e)
        {
            _Obj.DeleteReocrdLevelCriticalJobs(hdnId1CJ.Value);
            LoadGridCJ();
        }

        protected void BtnEditRecordCJ_Click(object sender, EventArgs e)
        {
            LoadGridCJ();
        }
        protected void LoadCJGrid_Click(object sender, EventArgs e)
        {
            LoadGridCJ();
        }

        protected void saveBtnCJ_Click(object sender, EventArgs e)
        {
            string objectives = "";
            string DeductionScore = "";
            if (!string.IsNullOrEmpty(Request.Form["perFormance"]))
            {
                DeductionScore = Request.Form["perFormance"].ToString();
                if (Regex.IsMatch(DeductionScore, @"([0-9.])+") == false)
                {
                    GetStatic.AlertMessage(this, "Deduction Score must be in number");
                    return;
                }
            }

            if (!string.IsNullOrEmpty(Request.Form["kraScore"]))
                objectives = filterstring(Request.Form["kraScore"].ToString());
            //if (!string.IsNullOrEmpty(Request.Form["perFormance"]))
            //    DeductionScore = filterstring(Request.Form["perFormance"].ToString());


            var res = _Obj.EditDataLevelCriticalJobs(objectives, DeductionScore, ReadSession().UserName.ToString(), filterstring(hdnId2CJ.Value), GetStatic.ReadQueryString("LrowId", ""));

            if (res.ErrorCode.Equals("0"))
            {
                GetStatic.AlertMessage(this, "Data updated successfully!");
                hdnId2CJ.Value = "";
                LoadGridCJ();
                ClearContentCJ();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }
        private void ClearContentCJ()
        {
            txtObjectives.Text = "";
            txtDeductionScore.Text = "";
        }

        protected void cancelCJ_Click(object sender, EventArgs e)
        {
            hdnId2CJ.Value = "";
            //getAttributes(universalId.Value);
        }

        protected void BtnSaveCJ_Click(object sender, EventArgs e)
        {
          
            var res = _Obj.UpdateLevelCriticalJobs(ReadSession().UserName.ToString(), txtObjectives.Text, txtDeductionScore.Text, GetStatic.ReadQueryString("LrowId", "").ToString());
            if (res.ErrorCode.Equals("0"))
            {
                GetStatic.AlertMessage(this, "Data saved successfully!");
                hdnId2CJ.Value = "";
                LoadGridCJ();
                ClearContentCJ();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }

        #endregion
    }
}