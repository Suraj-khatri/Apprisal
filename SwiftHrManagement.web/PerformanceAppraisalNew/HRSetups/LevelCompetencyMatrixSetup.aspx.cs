using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class LevelCompetencyMatrixSetup : BasePage 
    {
         PerformanceAgreementDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO swift = null;
        public  LevelCompetencyMatrixSetup()
        {
            _Obj = new PerformanceAgreementDao();  
            _RoleMenuDAOInv = new RoleMenuDAOInv();
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
                LoadGrid();
            }
           
        }
          #region KraKpi
        private void LoadGrid()
        {
            //var dt = _Obj.GetKRAKPIDate(hdnEmpName.Value);
            var dt = _Obj.GetLevelAppraisalMatrixDetails(GetStatic.ReadQueryString("LrowId", ""));

            if (dt.Rows.Count == 0 || dt.Rows == null || dt.Columns.Count <=3)
            {
                kra_grid.InnerHtml = "<tr><td colspan=\"6\" align=\"center\"> No Records to display.</td></tr>";
                //getAttributes(universalId.Value);
                return;
            }
             int sn = 1,rowSpanNum = 0,indicator=0;
             int editIndex = 0;
            StringBuilder sb = new StringBuilder();
            
            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString();
                
                var kraGroup = dt.Select("KraTopic='" + item["kraTopic"].ToString() + "'");
                rowSpanNum = kraGroup.Length;

                if (!string.IsNullOrWhiteSpace(hdnId2.Value) && editIndex == 0)
                {
                    foreach (DataRow dr in kraGroup)
                    {
                        if (dr["RowId"].ToString() == hdnId2.Value)
                        {
                            editIndex = 1;
                        }
                    }
                }
               
                    sb.AppendLine("<tr>");

                        if (rowSpanNum > 1)
                        {
                            if (indicator == 0)
                            {
                                if (editIndex == 1)
                                {
                                    sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + sn +"</td>");
                                    sb.AppendLine("<td rowspan='" + rowSpanNum + "'><input type=\"text\" name=\"kraTopicEdit\" value=\"" +
                                                  item["kraTopic"].ToString() +
                                                  "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                                    sb.AppendLine("<td rowspan='" + rowSpanNum + "'><input type=\"text\" name=\"kraWeightageEdit\" value=\"" +
                                                  item["kraWeightage"].ToString() +
                                                  "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                                    editIndex = 2;
                                }
                                else
                                {
                                    sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + sn + "</td>");
                                    sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + item["kraTopic"].ToString() + "</td>");
                                    sb.AppendLine("<td rowspan='" + rowSpanNum + "'>" + item["kraWeightage"].ToString() + "</td>"); 
                                }
                                sn++;
                            }
                            indicator++;
                        }
                        else
                        {
                            sb.AppendLine("<td>" + sn + "</td>");
                            sb.AppendLine("<td>" + item["kraTopic"].ToString() + "</td>");
                            sb.AppendLine("<td>" + item["kraWeightage"].ToString() + "</td>");
                            sn++;
                        }

                    if (rowId == hdnId2.Value)
                    {
                        sb.AppendLine("<td><input type=\"text\" name=\"kpiTopicEdit\" value=\"" + item["kpiTopic"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                        sb.AppendLine("<td><input type=\"text\" name=\"kpiWeightageEdit\" value=\"" + item["kpiWeightage"].ToString() + "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                        sb.AppendLine("<td align=\"center\" nowrap=\"nowrap\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditData(" + rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                        sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"Cancel(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                    }
                    else
                    {
                        sb.AppendLine("<td>" + item["kpiTopic"].ToString() + "</td>");
                        sb.AppendLine("<td>" + item["kpiWeightage"].ToString() + "</td>");
                        sb.AppendLine("<td align=\"center\" nowrap=\"nowrap\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" + rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                        sb.AppendLine("<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"#\" onclick=\"onDelete(" + rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                    }

                sb.AppendLine("</tr>");
                if (indicator == rowSpanNum)
                {
                    indicator = 0;
                    //editIndex = 0;
                }
            }
            kra_grid.InnerHtml = sb.ToString();
            //getAttributes(universalId.Value);
        }
        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            _Obj.DeleteReocrd(hdnId1.Value);
            LoadGrid();
        }

        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string kraTopic = "";
            string kraWeight = "";
            string kpiTopic = "";
            string kpiWeight = "";


            if (!string.IsNullOrEmpty(Request.Form["kraTopicEdit"]))
            { 
                kraTopic = Request.Form["kraTopicEdit"].ToString();
            }
            else
            { 
                GetStatic.AlertMessage(this, "Field Should not be empty");
            }

            if (!string.IsNullOrEmpty(Request.Form["kraWeightageEdit"]))
            {
                kraWeight = Request.Form["kraWeightageEdit"].ToString();
                if (Regex.IsMatch(kraWeight, @"^\d+$") == false)
                {
                    GetStatic.AlertMessage(this, "KRA Weightage must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
            }
                

            if (!string.IsNullOrEmpty(Request.Form["kpiTopicEdit"]))
            { 
                kpiTopic = Request.Form["kpiTopicEdit"].ToString();
            }
            else
            { 
                GetStatic.AlertMessage(this, "Field Should not be empty");
            }

            if (!string.IsNullOrEmpty(Request.Form["kpiWeightageEdit"]))
            {
                kpiWeight = Request.Form["kpiWeightageEdit"].ToString();
                if (Regex.IsMatch(kpiWeight, @"^\d+$") == false)
                {
                    GetStatic.AlertMessage(this, "KPI Weightage must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
            }

            var res = _Obj.EditLevelKriKpiData(kraTopic, kraWeight, kpiTopic, kpiWeight, ReadSession().Emp_Id.ToString(), filterstring(hdnId2.Value), GetStatic.ReadQueryString("LrowId", ""));

            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", res.Msg);
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", res.Msg);
            }
        }
        private void ClearContent()
        {
            //kraTopic.Text = "";
            //kraWeight.Text = "";
            kpiTopic.Text = "";
            kpiWeight.Text = "";
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            hdnId2.Value = "";
            LoadGrid();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(kraWeight.Text) == 0)
            {
                GetStatic.AlertMessage(this, "You cannot enter KRA weight 0");
                kraWeight.Text = "";
                kraWeight.Focus();
                return;
            }
            if (Convert.ToDecimal(kpiWeight.Text) == 0)
            {
                GetStatic.AlertMessage(this, "You cannot enter KPI weight 0 ");
                kpiWeight.Text = "";
                kpiWeight.Focus();
                return;
            }
            var res = _Obj.UpdateLevelKriKpi(ReadSession().Emp_Id.ToString(), kraTopic.Text, kraWeight.Text, kpiTopic.Text, kpiWeight.Text, GetStatic.ReadQueryString("LrowId", ""));
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this,"Success", res.Msg);
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this,"Error", res.Msg);
                if (!string.IsNullOrEmpty(res.Id))
                SetRemainingWeight(res);
            }
        }

        protected void SetRemainingWeight(DbResult res)
        {
            var result = res.Id.Split('|');
            if (result[1].ToString() == "KRA")
            {
                kraWeight.Text = result[0].ToString();   
            }
            else
            {

                kpiWeight.Text = result[0].ToString();

            }
        }
        protected void LoadKRAKPIGrid_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        #endregion
    }
}