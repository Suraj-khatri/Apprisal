using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.PerformanceAppraisal
{
    public partial class DisciplinaryComments : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(getFlag().ToString() == "v")
                {
                    setData();
                    setDefault();
                    btnAdd.Visible = false;
                }
                else if(getFlag()=="s")
                {
                    fillDdl();
                    ddlBranch.Enabled = false;
                    ddlDepartment.Enabled = false;
                    _clsDao.CreateDynamicDDl(ddlEmployee, "select EMPLOYEE_ID, EMP_CODE +'|' +FIRST_NAME+' '+MIDDLE_NAME+ ' ' + LAST_NAME as empName from Employee where DEPARTMENT_ID=" + filterstring(ddlDepartment.Text) + " and BRANCH_ID=" + filterstring(ddlBranch.Text), "EMPLOYEE_ID", "empName", "", "Select");
                }
                else
                {
                    populateDdl();
                }
                txtStartDate.Attributes.Add("onBlur", "checkDateFormat(this);");
                txtEndDate.Attributes.Add("onBlur", "checkDateFormat(this);");
            }
        }

        private void fillDdl()
        {
            _clsDao.setDDL(ref ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", ReadSession().Branch_Id.ToString(), "Select");
            _clsDao.setDDL(ref ddlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", ReadSession().Department.ToString(), "Select");
                
        }

        private void populateDdl()
        {
            _clsDao.CreateDynamicDDl(ddlBranch,"SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME","","Select");
        }

        private string getFlag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"] : "");
        }

        private string getCommentId()
        {
            return (Request.QueryString["commentId"] != null ? Request.QueryString["commentId"] : "");
        }

        private string getEmpId()
        {
            return (Request.QueryString["empId"] != null ? Request.QueryString["empId"] : "");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblmsg.Text = _clsDao.GetSingleresult("Exec proc_DisciplinaryComment @flag='a',@empId=" + filterstring("") + ",@commentType=" + filterstring(ddlComments.Text) 
                            + ",@category=" +filterstring(ddlCategory.Text) + ",@remarks=" + filterstring(txtRemarks.Text) + ",@startDate=" + filterstring(txtStartDate.Text)
                            + ",@endDate=" + filterstring(txtEndDate.Text) + ",@sessionId=" + filterstring(ReadSession().Sessionid));
            populateData();
            ddlComments.Text = "";
            txtRemarks.Text = "";
            txtStartDate.Text = "";
            txtEndDate.Text = "";
        }

        protected void ddlComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlComments.SelectedValue == "")
            {
                ddlCategory.Text = "";
                lblmsg.Text = "Please select Comment Type";
            }
            else if(ddlComments.SelectedValue == "Appreciation")
            {
                _clsDao.CreateDynamicDDl(ddlCategory, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=60", "ROWID", "DETAIL_TITLE", "", "Select");
            }
            else if(ddlComments.SelectedValue == "Action")
            {
                _clsDao.CreateDynamicDDl(ddlCategory, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=61", "ROWID", "DETAIL_TITLE", "", "Select");
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            ddlDepartment.Items.Clear();
            if (ddlBranch.Text != "")
            {
                _clsDao.CreateDynamicDDl(ddlDepartment,
                                         "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" +
                                         filterstring(ddlBranch.Text), "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlEmployee.Items.Clear();
            if(ddlDepartment.Text != "")
            {
                _clsDao.CreateDynamicDDl(ddlEmployee, "select EMPLOYEE_ID, EMP_CODE +'|' +FIRST_NAME+' '+MIDDLE_NAME+ ' ' + LAST_NAME as empName from Employee where DEPARTMENT_ID=" + filterstring(ddlDepartment.Text) + " and BRANCH_ID=" + filterstring(ddlBranch.Text), "EMPLOYEE_ID", "empName", "", "Select");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisciplinaryList.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if(getFlag().ToString()=="v")
            {
                lblmsg.Text = _clsDao.GetSingleresult("Exec proc_DisciplinaryComment @flag='u',@endDate=" + filterstring(txtEndDate.Text) + ",@commentId=" + filterstring(getCommentId()));
                Response.Redirect("DisciplinaryList.aspx");
            }
            else
            {
                lblmsg.Text = _clsDao.GetSingleresult("Exec proc_DisciplinaryComment @flag='fs',@empId=" + filterstring(ddlEmployee.Text) + ",@branchId=" + filterstring(ddlBranch.Text) + ",@departmentId=" + filterstring(ddlDepartment.Text) + ",@sessionId=" + filterstring(ReadSession().Sessionid));
                Response.Redirect("DisciplinaryList.aspx");
            }

        }

        private void setDefault()
        {
            ddlBranch.Enabled = false;
            ddlDepartment.Enabled = false;
            ddlEmployee.Enabled = false;
            txtRemarks.Enabled = false;
            txtStartDate.Enabled = false;
            ddlComments.Enabled = false;
            ddlCategory.Enabled = false;
        }

        private void populateData()
        {
            StringBuilder str = new StringBuilder("<table border=\"0\" cellpadding=\"3\" cellspacing=\"3\" width=\"700\" align=\"center\" class=\"TBL\">");
            DataTable dt = new DataTable();
            dt = _clsDao.getTable("Exec proc_DisciplinaryComment @flag='s',@sessionId=" + filterstring(ReadSession().Sessionid));    

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for(int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for(int i =0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">"+ dr[i].ToString()+"</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptComments.InnerHtml = str.ToString();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg1 = _clsDao.GetSingleresult("Exec proc_DisciplinaryComment @flag='d',@commentId=" + filterstring((hdnRowid.Value).ToString()) + ",@sessionId=" + filterstring(ReadSession().Sessionid));
            lblmsg.Text = msg1;
            populateData();
        }

        private void setData()
        {
            string cType = Request.QueryString["cType"] != null ? Request.QueryString["cType"] : "";
            string category = Request.QueryString["category"] != null ? Request.QueryString["category"] : "";
            DataTable dt = new DataTable();
            dt = _clsDao.getTable("select * from disciplinaryComments where empId=" + filterstring(getEmpId()) + "and commentType=" 
                    + filterstring(cType)+ " and category=" + filterstring(category));
            foreach (DataRow dr in dt.Rows)
            {
                _clsDao.setDDL(ref ddlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", dr["branch_Id"].ToString(), "Select");
                _clsDao.setDDL(ref ddlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", dr["department_Id"].ToString(), "Select");
                _clsDao.setDDL(ref ddlEmployee, "select EMPLOYEE_ID, EMP_CODE +'|' +FIRST_NAME+' '+MIDDLE_NAME+ ' ' + LAST_NAME as empName from Employee", "EMPLOYEE_ID", "empName", dr["empId"].ToString(), "Select");
                ddlComments.Text = dr["commentType"].ToString();
                if (ddlComments.SelectedValue == "Appreciation")
                {
                    _clsDao.setDDL(ref ddlCategory, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=61", "ROWID", "DETAIL_TITLE", dr["category"].ToString(), "Select");
                }
                else if (ddlComments.SelectedValue == "Action")
                {
                    _clsDao.setDDL(ref ddlCategory, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=60", "ROWID", "DETAIL_TITLE", dr["category"].ToString(), "Select");
                }
                DateTime startDate = DateTime.Parse(dr["startDate"].ToString());
                txtStartDate.Text = startDate.ToString("MM/dd/yyyy");
                if(dr["endDate"].ToString() == "")
                {
                    txtEndDate.Text = "";
                }
                else
                {
                    DateTime endDate = DateTime.Parse(dr["endDate"].ToString());
                    txtEndDate.Text = endDate.ToString("MM/dd/yyyy");
                }
                txtRemarks.Text = dr["remarks"].ToString();
            }
        }

        private void editData()
        {
            lblmsg.Text = "Exec proc_DisciplinaryComment @flag='u',@endDate=" + filterstring(txtEndDate.Text) + ",@commentId=" + filterstring(getCommentId());
        }
    }
}
