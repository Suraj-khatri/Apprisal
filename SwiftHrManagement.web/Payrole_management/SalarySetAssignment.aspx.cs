using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using System.Text;
using SwiftHrManagement.web.DAL.SalarySet;


namespace SwiftHrManagement.web.Payrole_management
{
    public partial class SalarySetAssignment : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        private SalarySetDao _salarySetDao = null;
        string empList = "";
        string salaryIdList = "";
        public SalarySetAssignment()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._salarySetDao = new SalarySetDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            empList = Request.Form["chkId"];
            salaryIdList = Request.Form["chkId1"]; 
            if (!IsPostBack)
            {                
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 228) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();
                txtGradeNo.Attributes.Add("onchange", "Calculate()");

                if (GetMsg()!= "")
                {
                    LblMsg.Text = "Salary Assigned Successfully!";
                    LblMsg.ForeColor = System.Drawing.Color.MediumSeaGreen;
                }
            }
          
        }

        protected string GetMsg()
        {
            return (Request.QueryString["msg"] != null ? (Request.QueryString["msg"].ToString()) : "");
        }

        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(ddlBranchName, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
            CLsDAo.CreateDynamicDDl(ddlSalaryTitle, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where TYPE_ID=98", "ROWID", "DETAIL_TITLE", "", "All");
            //CLsDAo.CreateDynamicDDl(ddlSalarySet, "select salarySetMasterId,sdd.DETAIL_TITLE from salarySetMaster sm inner join StaticDataDetail sdd on sdd.ROWID=sm.Salary_Title", "salarySetMasterId", "DETAIL_TITLE", "", "All");
            CLsDAo.CreateDynamicDDl(ddlNewSalarySet, "select salarySetMasterId,sdd.DETAIL_TITLE from salarySetMaster sm inner join StaticDataDetail sdd on sdd.ROWID=sm.Salary_Title", "salarySetMasterId", "DETAIL_TITLE", "", "All");
        }

        protected void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDeptName.Items.Clear();
            if (ddlBranchName.Text != "")
            {
                CLsDAo.CreateDynamicDDl(ddlDeptName, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + ddlBranchName.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "All");
            }
        }

        private void OnShowEmployee() 
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt;

            dt = CLsDAo.getTable("Exec [Proc_SalaryAssignment] @flag='e',@branch_id=" + filterstring(ddlBranchName.Text) + ",@dept_id=" + filterstring(ddlDeptName.Text) + ",@salary_title=" + filterstring(ddlSalaryTitle.Text) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                str.Append("<th align=\"left\">S.N.</th>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"CENTER\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\"><b><a href=\"javascript:void(0);\" onClick=\"CheckAll(this)\"><b>Check All</b></a><b> / </b><a href=\"javascript:void(0);\" onClick=\"UncheckAll(this)\"><b>Uncheck All</b></a></b> </th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    str.Append("<td align=\"left\">" + count++ + " </td>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }

                    str.Append("<td align=\"center\"><input type='checkbox' id = \"chk_" + dr["EMPLOYEE_ID"].ToString() + "\" name ='chkId' value='" + dr["EMPLOYEE_ID"].ToString() + "' " + (dr["EMPLOYEE_ID"].ToString() != "" ? "checked='checked'" : "") + " /></td>");

                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt.InnerHtml = str.ToString();
            }
        }

        private void OnShowPayable() 
        {
            long count = 1;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            DataTable dt;

            dt = CLsDAo.getTable("Exec [Proc_SalaryAssignment] @flag='ss',@new_Salary_set=" + filterstring(ddlNewSalarySet.Text) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            if (dt.Columns.Count > 0)
            {
                str.Append("<th align=\"left\">S.N.</th>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<th align=\"CENTER\">" + dt.Columns[i].ColumnName + "</th>");
                }
                str.Append("<th align=\"left\"><b><a href=\"javascript:void(0);\" onClick=\"CheckAll(this)\"><b>Check All</b></a><b> / </b><a href=\"javascript:void(0);\" onClick=\"UncheckAll(this)\"><b>Uncheck All</b></a></b> </th>");
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    str.Append("<td align=\"left\">" + count++ + " </td>");
                    for (int i = 1; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }

                    str.Append("<td align=\"center\"><input type='checkbox' id = \"chk_" + dr["salaryDetailId"].ToString() + "\" name ='chkId1' value='" + dr["salaryDetailId"].ToString() + "' " + (dr["salaryDetailId"].ToString() != "" ? "checked='checked'" : "") + " /></td>");
                    
                    str.Append("</tr>");
                }
                str.Append("</table>");
                str.Append("</div>");
                rpt1.InnerHtml = str.ToString();
            }
        }

        private void OnShowGradeAmount()
        {
            DataTable dt = _salarySetDao.FindGradeAmount(ddlNewSalarySet.Text, txtGradeNo.Text);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count < 0)
                return;

            dr = dt.Rows[0];

            txtGradeAmt.Text = dr["Grade"].ToString();
            txtGradeAmt.Enabled = false;
        }
         
        private void OnSaveUpdateData()
        {
            string flag = "";
            string msg = "";

            msg = CLsDAo.GetSingleresult("Exec Proc_SalaryAssignment @flag='i',@new_Salary_set=" + filterstring(ddlNewSalarySet.Text) + ","
            + " @grade=" + filterstring(txtGradeNo.Text) + ",@gradeAmt=" + filterstring(txtGradeAmt.Text) + ",@effectiveDate=" + filterstring(txtEffectiveDate.Text) + ","
            + " @applicableDate=" + filterstring(txtApplicableDate.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
            + " @emp_ids='" + empList + "',@salaryDetailId='" + salaryIdList + "'");

            if (msg.Contains("Success"))
            {
                Response.Redirect("SalarySetAssignment.aspx?msg="+LblMsg.Text+"");  
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
                OnShowEmployee();
            
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSaveUpdateData();
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCalcGrade_Click(object sender, EventArgs e)
        {
            OnShowGradeAmount();
        }

        protected void ddlNewSalarySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnShowPayable();
        }
    }
}