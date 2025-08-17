using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement
{
    public partial class CriticalJobs : BasePage
    {
        PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public CriticalJobs()
        {
            _Obj = new PerformanceAgreementDao();
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

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
        }
        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }
        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }
        private void LoadGrid()
        {
            var dt = _Obj.GetCriticalJobsDate(hdnEmpName.Value,"");

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                criticalJobs_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString();

                if (rowId == hdnId2.Value)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["SNO"].ToString() + "</td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"kraScore\" value=\"" + item["objectives"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"perFormance\" value=\"" + item["deductionScore"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"javascript:void(0)\"onclick=\"EditData(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"javascript:void(0)\" onclick=\"Cancel(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                else
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["SNO"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["objectives"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["deductionScore"].ToString() + "</td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"javascript:void(0)\" onclick=\"onDelete(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                sb.AppendLine("</tr>");
            }
            criticalJobs_grid.InnerHtml = sb.ToString();
            criticalJobs_grid.Focus();
        }

        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            _Obj.DeleteReocrdCriticalJobs(hdnId1.Value);
            LoadGrid();
        }

        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string objectives = "";
            string deductionScore = "";


            if (!string.IsNullOrEmpty(Request.Form["kraScore"]))
                objectives = filterstring(Request.Form["kraScore"].ToString());
            if (!string.IsNullOrEmpty(Request.Form["perFormance"]))
                deductionScore = filterstring(Request.Form["perFormance"].ToString());


            var res = _Obj.EditDataCriticalJobs(objectives, deductionScore ,ReadSession().UserName.ToString(), filterstring(hdnId2.Value),hdnEmpName.Value,"");

            if (res.ErrorCode.Equals("0"))
            {
                GetStatic.AlertMessage(this, "Data updated successfully!");
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }
        private void ClearContent()
        {
            txtObjectives.Text = "";
            txtDeductionScore.Text = "";           
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            hdnId2.Value = "";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            var res = _Obj.UpdateCriticalJobs(ReadSession().UserName.ToString(), txtObjectives.Text, txtDeductionScore.Text,hdnEmpName.Value,"");
            if (res.ErrorCode.Equals("0"))
            {
                GetStatic.AlertMessage(this, "Data saved successfully!");
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }        
    }
}