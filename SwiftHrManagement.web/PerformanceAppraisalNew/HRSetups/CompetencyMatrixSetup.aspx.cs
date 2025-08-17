using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class CompetencyMatrixSetup : BasePage
    {
        AppraisalDAO _appraisal = null;
        clsDAO swift = null;
        RoleMenuDAOInv _roleMenuDao = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDao.hasAccess(ReadSession().AdminId, 1111) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            PopulateDdlPosition();
            if (!IsPostBack)
            {
                LoadLevelName();
                LoadGrid();
            }

        }
        private void LoadLevelName()
        {
            var dt = _appraisal.LoadLevelName(GetStatic.ReadQueryString("LrowId", ""));
            var comMatrixName = "";
            comMatrixName = dt.Rows[0]["LevelName"].ToString();
            lblLevelName.Text = comMatrixName;
        }
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (float.Parse(TxtWeight.Text) < float.Parse(TxtWeight1.Text))
            {
                GetStatic.SweetAlertMessage(this, "", "CompetencyKeyWeight must be less than CompetencyWeight ");
                return;
                
            }
            if (string.IsNullOrWhiteSpace(TxtWeight.Text) || float.Parse(TxtWeight.Text) <= 0)
            {
                GetStatic.SweetAlertMessage(this, "", "Zero cant be added in CompetencyWeight ");
                return;
            }
            if (string.IsNullOrWhiteSpace(TxtWeight1.Text) || float.Parse(TxtWeight1.Text) <= 0)
            {
                GetStatic.SweetAlertMessage(this, "", "Zero cant be added in CompetencyKeyWeight");
                return;
            }

            string res = _appraisal.CompetencyMatrixSetup(GetStatic.ReadQueryString("LrowId", ""), DdlCompetancy.SelectedItem.ToString(), TxtWeight.Text, DdlCompetancyKey.SelectedItem.ToString(), TxtWeight1.Text, ReadSession().Emp_Id.ToString());

            if (res == "SUCCESS")
            {
                GetStatic.AlertMessage(this, "Data saved successfully!");
                hdnId2.Value = "";
                LoadGrid();
                //ClearAllFields();
            }
            else if (res == "Competency Weight sum must not exceed 100")
            {
                GetStatic.SweetAlertErrorMessage(this,"", "Competency Weight sum must not exceed 100");
            }
            else if (res == "Duplicate")
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Cannot Insert Same Question Type Multiple times!");
            }
            else if (res == "Competency Key Weight sum must not exceed Competency Weight")
            {
                GetStatic.SweetAlertErrorMessage(this,"", "Competency Key Weight sum must not exceed Competency Weight");
            }
            else if (res == "CompetencyWeight value is different")
            {
                GetStatic.SweetAlertMessage(this, ""," Competency Weight value is different");
            }
               
            else
            {
                GetStatic.SweetAlertErrorMessage(this,"", "Some error occured while saving!");
            }

        }
        private void ClearAllFields()
        {
            DdlCompetancy.SelectedValue = "";
            DdlCompetancyKey.SelectedValue = "";
            TxtWeight.Text = "";
            TxtWeight1.Text = "";

        }
        private void LoadGrid()
        {
            var dt = _appraisal.GetCompetencyMatrixTable(GetStatic.ReadQueryString("LrowId","").ToString());

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                app_grid.InnerHtml = "<tr><td colspan=\"6\" align=\"center\"> No Records to display.</td></tr>";
                return;
            }
            int sn = 1, rowSpanNum = 0, indicator = 0;
            int editIndex = 0;
            StringBuilder sb = new StringBuilder();

            foreach (DataRow item in dt.Rows)
            {
                //string LrowId = item["RowId"].ToString();
                string rowId = item["RowId"].ToString();
                var CompetencyGroup = dt.Select("CompetencyID='" + item["CompetencyID"].ToString() + "'");
                rowSpanNum = CompetencyGroup.Length;

                if (!string.IsNullOrWhiteSpace(hdnId2.Value) && editIndex == 0)
                {
                    foreach (DataRow dr in CompetencyGroup)
                    {
                        if (dr["RowId"].ToString() == hdnId2.Value)
                        {
                            editIndex = 1;
                        }
                    }   
                }
                sb.AppendLine("<tr>");
                if (rowSpanNum >= 1)
                {
                    if (indicator == 0)
                    {
                        if (editIndex == 1)
                        {
                            sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + sn + "</td>");
                            sb.AppendLine("<td rowspan='" + rowSpanNum + "'><input type=\"text\" name=\"CompetencyID\" value=\"" +
                                          item["CompetencyID"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\" readonly></td>");
                            //sb.AppendLine("<td  rowspan='" + rowSpanNum + "'>  <label name=\"CompetencyID\">" + item["CompetencyID"].ToString() + "</label></td>");
                            sb.AppendLine("<td rowspan='" + rowSpanNum + "'><input type=\"text\" id = \"CW" + rowId + "\" name=\"comptancyWeight\" value=\"" +
                                          item["CompetencyWeight"].ToString() +
                                          "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                            editIndex = 2;
                        }
                        else
                        {
                            sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + sn + "</td>");
                            sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + item["CompetencyID"].ToString() + "</td>");
                            sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + item["CompetencyWeight"].ToString() + "</td>");
                        }
                        sn++;
                    }
                    indicator++;
                }
                else
                {
                    sb.AppendLine("<td>" + sn + "</td>");
                    sb.AppendLine("<td>" + item["CompetencyID"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["CompetencyWeight"].ToString() + "</td>");
                    sn++;
                }
                if (rowId == hdnId2.Value)
                {
                    //sb.AppendLine("<tr>");
                    //sb.AppendLine("<td>  <label>" + item["CompetencyID"].ToString() + "</label>");
                    //sb.AppendLine("<td><input type=\"text\" name=\"TxtWeight\" value=\"" + item["CompetencyWeight"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    //sb.AppendLine("<td>  <label name=\"CompetencyKeyID\">" + item["CompetencyKeyID"].ToString() + "</label>");
                    sb.AppendLine("<td><input type=\"text\" name=\"CompetencyKeyID_"+item["RowId"]+"\" value=\"" +
                                  item["CompetencyKeyID"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\" readonly>");
                    sb.AppendLine("<td><input type=\"text\" id = \"CKW" + rowId + "\" name=\"CompetencyKeyWeight\" value=\"" + item["CompetencyKeyWeight"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditData(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"Cancel(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                else
                {
                    //sb.AppendLine("<tr>");
                    //sb.AppendLine("<td>" + item["QuestionGroupId"].ToString() + "</td>");
                    //sb.AppendLine("<td>  <label>" + item["CompetencyID"].ToString() + "</label>");
                    //sb.AppendLine("<td>" + item["CompetencyWeight"].ToString() + "</td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"CompetencyKeyID_" + item["RowId"] + "\" value=\"" +
                                  item["CompetencyKeyID"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\" readonly>");
                    sb.AppendLine("<td>" + item["CompetencyKeyWeight"].ToString() + "</td>");
                    sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                    sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"#\" onclick=\"onDelete(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                }
                sb.AppendLine("</tr>");
                if (indicator == rowSpanNum)
                {
                    indicator = 0;
                    //editIndex = 0;
                }
            }
            app_grid.InnerHtml = sb.ToString();
            //var ddlvalue = dt.Rows[0]["CompetencyID"].ToString();
            //DdlCompetancy.Text = ddlvalue;
            TxtWeight.Text = dt.Rows[0]["CompetencyWeight"].ToString();
        }
        public CompetencyMatrixSetup()
        {
            this._appraisal = new AppraisalDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
           this.swift = new clsDAO();

        }
        private void PopulateDdlPosition()
        {
            string selectValue = "";
            string selectValue1 = "";

            if (DdlCompetancy.SelectedItem != null)
                selectValue = DdlCompetancy.SelectedItem.Value.ToString();
            if (DdlCompetancyKey.SelectedItem != null)
                selectValue1 = DdlCompetancyKey.SelectedItem.Value.ToString();

            swift.setDDL(ref DdlCompetancy, "Exec ProcStaticDataView 's','110'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
            swift.setDDL(ref DdlCompetancyKey, "Exec ProcStaticDataView 's','111'", "ROWID", "DETAIL_TITLE", selectValue1, "Select");
        }
        public void saveBtn_Click(object sender, EventArgs e)
        {
            string txtCompWeight = "";
            string txtKeyWeight = "";
            string CompId = Request.Form["CompetencyID"];
            string CompKeyId = Request.Form["CompetencyKeyID_"+hdnId2.Value];
            if (float.Parse(Request.Form["comptancyWeight"]) <= 0)
            {
                GetStatic.AlertMessage(this, "Competancy Weight must be in greater than zero");
                return;
            }
            if (float.Parse(Request.Form["CompetencyKeyWeight"]) <= 0)
            {
                GetStatic.AlertMessage(this, "Competency Key Weight must be in greater than zero");
                return;
            }

            if (!string.IsNullOrEmpty(Request.Form["comptancyWeight"]))
            {
                txtCompWeight = Request.Form["comptancyWeight"];
                if (Regex.IsMatch(txtCompWeight, @"([0-9.])+") == false)
                {
                    GetStatic.AlertMessage(this, "comptancyWeight must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }
            if (!string.IsNullOrEmpty(Request.Form["CompetencyKeyWeight"]))
            {
                txtKeyWeight = Request.Form["CompetencyKeyWeight"];
                if (Regex.IsMatch(txtKeyWeight, @"([0-9.])+") == false)
                {
                    GetStatic.AlertMessage(this, "CompetencyKeyWeight must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }

            string res = _appraisal.EditCompetencyMatrix(txtCompWeight, txtKeyWeight, ReadSession().Emp_Id.ToString(), hdnId2.Value, CompId,CompKeyId, ReadQueryString("LrowId","").ToString());

            if (res == "SUCCESS")
            {
                GetStatic.AlertMessage(this, "Data updated successfully!");
                hdnId2.Value = "";
                LoadGrid();
                //ClearAllFields();
            }
            else if (res == "Competency Key Weight sum must not exceed Competency Weight")
            {
                GetStatic.AlertMessage(this, "Competency Key Weight sum must not exceed Competency Weight");
            }
            else if (res == "Competency Weight sum must not exceed 100")
            { 
                GetStatic.AlertMessage(this, "CompetencyWeight sum must not exceed 100");
            }
            else
            {
                GetStatic.AlertMessage(this, "Some error occured while updating!");
            }
        }
        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            _appraisal.DeleteCompetencyMatrix(hdnId1.Value);
            LoadGrid();
        }
        protected void cancel_Click(object sender, EventArgs e)
        {
            hdnId2.Value = "";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

    }
}