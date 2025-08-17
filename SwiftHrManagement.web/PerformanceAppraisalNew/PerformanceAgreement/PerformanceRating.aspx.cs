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
    public partial class PerformanceRating : BasePage
    {
        PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO swift = null;

        public PerformanceRating()
        {
            _Obj = new PerformanceAgreementDao();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1113) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                LoadPerformanceRatingGrid();
               // LoadGrid();
            }
            PopulateddlCriticality();
        }
        private void PopulateddlCriticality()
        {
            string selectValue = "";
            if (ddlCriticality.SelectedItem != null)
                selectValue = ddlCriticality.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlCriticality, "Exec ProcStaticDataView 's','112'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }

        private void LoadPerformanceRatingGrid()
        {
            var dt = _Obj.GetPerformanceRatingData();

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                perfRatingRef_grid.InnerHtml = "<tr><td colspan=\"2\" align=\"center\"> No Records to display.</td></tr>";
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (DataRow item in dt.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["PercentIncrement"].ToString() + "</td>");
                sb.AppendLine("</tr>");
            }
            perfRatingRef_grid.InnerHtml = sb.ToString();

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
            var dt = _Obj.GetPerformanceRatingData();
            dt = null;

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                perfTranning_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString();

                if (rowId == hdnId2.Value)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td><input type=\"text\" name=\"kraScore\" value=\"" + item["rowId"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"kraScore\" value=\"" + item["proposedArea"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"perFormance\" value=\"" + item["criticality"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"percentIncrement\" value=\"" + item["data"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditData(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"Cancel(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                else
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["rowId"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["proposedArea"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["criticality"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["data"].ToString() + "</td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"#\" onclick=\"onDelete(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                sb.AppendLine("</tr>");
            }
            perfTranning_grid.InnerHtml = sb.ToString();
        }

        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            //_Obj.DeleteReocrdPerformanceRating(hdnId1.Value);
            LoadGrid();
        }

        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string txtProposedArea = "";
            string txtCriticality = "";
            string txtDate = "";


            if (!string.IsNullOrEmpty(Request.Form["txtProposedArea"]))
                txtProposedArea = filterstring(Request.Form["txtProposedArea"].ToString());
            if (!string.IsNullOrEmpty(Request.Form["txtCriticality"]))
                txtCriticality = filterstring(Request.Form["txtCriticality"].ToString());
            if (!string.IsNullOrEmpty(Request.Form["txtDate"]))
                txtDate = filterstring(Request.Form["txtDate"].ToString());

            var res = _Obj.EditDataPerformanceRating(txtProposedArea, txtCriticality, txtDate, ReadSession().UserName.ToString(), filterstring(hdnId2.Value),"","");

            if (res.Msg == "SUCCESS")
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
        private void ClearContent()
        {
            txtProposedArea.Text = "";
            txtDate.Text = "";           
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            hdnId2.Value = "";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            var res = _Obj.UpdateCriticalPerformanceRating(ReadSession().UserName.ToString(), txtProposedArea.Text, ddlCriticality.SelectedValue, txtDate.Text,"","","");
            if (res.Msg == "SUCCESS")
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
    }

}