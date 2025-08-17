using System;
using System.Web.UI;
using System.Data;
using System.Linq;
using System.Text;
using SwiftHrManagement.web.DAL.GlobalSalary;

namespace SwiftHrManagement.web.Payrole_management.GlobalSaleryCRUDOperation
{
    public partial class ManageOperation : BasePage
    {
        private clsDAO _clasDao = null;
        private GlobalSalaryDao _globalSalary = null;

        public ManageOperation()
        {
            _clasDao = new clsDAO();
           _globalSalary = new GlobalSalaryDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           

            if(!IsPostBack)
            {
                SetDDL();
            }
            CreateDynamicGrid();
        }

      
        
        private void SetDDL()
        {
            var sql = "select BRANCH_ID,BRANCH_NAME from Branches where 1=1";
            _clasDao.setDDL(ref ddlBranch, sql, "BRANCH_ID", "BRANCH_NAME","","Select");
            var sql1 = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 4";
            _clasDao.setDDL(ref ddlPostition, sql1, "ROWID", "DETAIL_TITLE", "", "Select");
            var sql2 = "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where TYPE_ID in('36','37','38')";
            _clasDao.setDDL(ref DdlHead, sql2, "ROWID", "DETAIL_TITLE", "", "Select");

        }

        string CreateDDL(string id)
        {
            var html = new StringBuilder();
            html.Append("<select onchange = \"ManageMethod(this,'" +  id + "');\" id=\"jobType_" + id + "\" name =\"jobType_"+id+"\" class=\"FltCMBDesign\" style=\"width:100px\">");
            html.AppendLine("<option value=\"\">Select</option>");
            html.AppendLine("<option value=\"a\">Add New</option>");
            html.AppendLine("<option value=\"i\">Increment By</option>");
            html.AppendLine("<option value=\"d\">Decrement By</option>");
            html.AppendLine("</select>");
            return html.ToString();
        }
        string CreateFlatDDL(string id)
        {
            var html = new StringBuilder();
            html.Append("<select id=\"FlatOrPercentage_" + id + "\" name =\"FlatOrPercentage_" + id + "\" class=\"FltCMBDesign\" style=\"width:100px\">");
            html.AppendLine("<option value=\"\">Select</option>");
            html.AppendLine("<option value=\"f\">Flat</option>");
            html.AppendLine("<option value=\"p\">Percentage</option>");
           
            html.AppendLine("</select>");
            return html.ToString();
        }

        private void CreateDynamicGrid()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt = new DataTable();
            var sql = "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where TYPE_ID in('36','37','38')";
            dt = _clasDao.getTable(sql);

            str.Append("<tr>");
            str.Append("<th align=\"left\">Head</th>");
            str.AppendLine("<th align=\"left\">Job Type</th>");
            str.AppendLine("<th align=\"left\">Flat</th>");
            str.AppendLine("<th align=\"left\">Value</th>");
            str.AppendLine("<th align=\"left\">Update</th>");
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                str.AppendLine("<td align=\"left\">" + dr["DETAIL_TITLE"].ToString() + "</td>");
                str.AppendLine("<td align=\"left\"><div style=\"margin-left:none\">" + CreateDDL(dr["ROWID"].ToString()) + "</div></td>");
                str.AppendLine("<td align=\"left\"><div style=\"margin-left:none\">" + CreateFlatDDL(dr["ROWID"].ToString()) + "</div></td>");
                str.AppendLine("<td align=\"left\"><div style=\"margin-left:none\"><input type=\"text\" id=\"text_" + dr["ROWID"].ToString() + "\" name=\"payableAmt_" + dr["ROWID"].ToString() + "\" class=\"inputTextBoxLP1\" onblur=\"checknumber(this.value);\" style=\"width:100px\"></div></td>");
                str.Append("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"\"><span OnClick=\"OnUpdate('" + dr["ROWID"] + "')\" style=\"cursor:pointer;\"><i class=\"fa fa-refresh\"></i></span></a></td>");
                //str.AppendLine("<td align=\"left\"><img OnClick=\"OnUpdate('" + dr["ROWID"] + "') \" class=\"clickimage\" src=\"../../Images/icon_apply.png\" /></td>");
                //str.AppendLine("<td align=\"left\"><img OnClick=\"OnUpdate('" + dr["ROWID"] + "')/> <i class=\"fa fa-eye\"></i></td>");
               

                //str.AppendLine("<td align=\"left\"><input type=\"text\" id=\"text_" + dr["ROWID"].ToString() + "\" value=\"" + dr["ROWID"].ToString() + "\"  name=\"RowId_" + dr["ROWID"].ToString() + "\"   style=\"display:none;\"> </td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }

        protected void ddlPostition_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployee.Text = "";
            if(ddlBranch.Text !="" && ddlPostition.Text != "")
            {
                var sql ="select EMPLOYEE_ID,FIRST_NAME +' '+ MIDDLE_NAME+' '+LAST_NAME empName from Employee where BRANCH_ID = "+ddlBranch.Text+" and POSITION_ID = "+ddlPostition.Text;
                _clasDao.setDDL(ref ddlEmployee, sql, "EMPLOYEE_ID", "empName", "", "Select");
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            OnUpdateData();
        }

        private  void OnUpdateData()
        {
            string jobType = (Request.Form["jobType_" + hdnHeadId.Value + ""] ?? "").ToString();
            string flatOrPercentage = (Request.Form["FlatOrPercentage_" + hdnHeadId.Value + ""] ?? "").ToString();
            string payableAmt = (Request.Form["payableAmt_" + hdnHeadId.Value + ""] ?? "").ToString();
            string rowId = (Request.Form["RowId_" + hdnHeadId.Value + ""] ?? "").ToString();

            if(ddlBranch.Text =="" || ddlPostition.Text =="")
            {
                string script;
                script = "OnValidation()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", script, true);
                return;

            }
            if (jobType == "" || flatOrPercentage == "" || payableAmt == "")
            {
                string script;
                script = "OnValidation1()";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "CloseWindow", script, true);
                return;

            }
         

            DataTable dt = _globalSalary.OnUpdate(jobType, ddlBranch.Text, ddlPostition.Text, ddlEmployee.Text, rowId,
                                                  payableAmt, flatOrPercentage ,ReadSession().UserId);

             DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;
            dr = dt.Rows[0];

            if (dr["error_code"].ToString() == "0")
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "warning");
            }
            else
            {
                DivMsg.InnerHtml = dr["msg"].ToString();
                DivMsg.Attributes.Add("class", "success");
               
            }
        }

        protected void DdlHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DdlHead.Text != "")
            {
                showSalaryRange.Visible = true;
            }
            else
            {
                showSalaryRange.Visible = false; 
            }

        }
        

    }
}