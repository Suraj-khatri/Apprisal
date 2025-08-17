using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.OnTheJobTraining
{
    public partial class ManageOJT : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageOJT()
        {
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
       {
            
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 38) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetOJTId() > 0)
                {
                    PopulateData();
                }
                else
                {
                    SetDDL();
                    BtnDelete.Visible = false;
                }
            }
            DdlSuperVisorMentor.Enabled = false;

        }

        private void PopulateData()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("exec procOJT_DETAILS @Flag='a',@OJT_ID="+GetOJTId()+"").Tables[0];
           
            if (dt == null)
            {
                return; 
            }
            DataRow dr = null;

            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
              DdlTrainingType.Text = dr["TRN_TYPE"].ToString();
            txtFromDate.Text = dr["FROM_DATE"].ToString();
            txtToDate.Text = dr["TO_DATE"].ToString();
            _clsDao.setDDL(ref DdlJobType, "SELECT JOB_GROUP_ID,GROUP_NAME FROM JOBGROUP WHERE 1=1", "JOB_GROUP_ID", "GROUP_NAME", dr["JOB_GROUP_ID"].ToString(), "Select");
            _clsDao.setDDL(ref DdlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", dr["BRANCH_ID"].ToString(), "Select");
            _clsDao.CreateDynamicDDl(DdlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", dr["DEPT_ID"].ToString(), "select");
            _clsDao.CreateDynamicDDl(DdlEmployee, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranch.Text + " AND DEPARTMENT_ID=" + DdlDepartment.Text + "", "EMPLOYEE_ID", "EmpName", dr["EMP_ID"].ToString(), "Select");
            _clsDao.setDDL(ref DdlSuperVisorMentor, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[super_name] from OJTDETAILS where OJT_ID = " + GetOJTId() + "", "SUPERVISOR", "super_name", "SUPERVISOR", "");
            
            txtEvaluator.Text = dr["EVALUATOR"].ToString();



        
    }
         
	
        private void SetDDL()
        {
            _clsDao.setDDL(ref DdlJobType, "SELECT JOB_GROUP_ID,GROUP_NAME FROM JOBGROUP WHERE 1=1", "JOB_GROUP_ID", "GROUP_NAME", "", "Select");
            _clsDao.setDDL(ref DdlBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
           
        }
        private long GetOJTId()
        {
            return (Request.QueryString["OJT_ID"] != null ? long.Parse(Request.QueryString["OJT_ID"]) : 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ManageData();
        }

        private void ManageData()
        {
            string evaluatorId = "";

            string empId = DdlSuperVisorMentor.Text;

            if (txtEvaluator.Text != "")
            {
                string[] B = txtEvaluator.Text.Split('|');
                evaluatorId = B[1];
            }
            else
            {

                evaluatorId = empId;
            }
                

            string  sql = "Exec [procOJT_DETAILS] @Flag=" + (GetOJTId().ToString()=="0"   ?  "'i'" :"'u'");
                    sql = sql + ",@OJT_ID=" + filterstring(GetOJTId().ToString());
                    sql = sql + ",@BRANCH_ID="+filterstring(DdlBranch.Text);
                    sql = sql + ",@DEPT_ID="+filterstring(DdlDepartment.Text);
                    sql = sql + ",@EMP_ID="+filterstring(DdlEmployee.Text);
                    sql = sql + ",@SUPERVISOR = " + filterstring(empId);
                    sql = sql + ",@JOB_GROUP_ID="+filterstring(DdlJobType.Text);
                    sql = sql + ",@FROM_DATE="+filterstring(txtFromDate.Text);
                    sql = sql + ",@TO_DATE="+filterstring(txtToDate.Text);
                    sql = sql + ",@TRN_TYPE="+filterstring(DdlTrainingType.Text);
                    sql = sql + ",@CREATED_BY="+filterstring(ReadSession().UserId);
                    sql = sql + ",@EVALUATOR = " + filterstring(evaluatorId);

                    _clsDao.runSQL(sql);

                    Response.Redirect("/OnTheJobTraining/ListOJT.aspx");
 
        }
        
					

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteOperation();
        }
        private void DeleteOperation()
        {
            _clsDao.runSQL("Exec procOJT_DETAILS @Flag='d',@OJT_ID="+GetOJTId()+"");
            Response.Redirect("/OnTheJobTraining/ListOJT.aspx");

        }

     
        protected void DdlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDepartment.Items.Clear();
            if (DdlBranch.Text != "")
            {
                _clsDao.CreateDynamicDDl(DdlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }   
        }

        protected void DdlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlEmployee.Items.Clear();
            if (DdlBranch.Text != "" && DdlDepartment.Text != "")
            {
                _clsDao.CreateDynamicDDl(DdlEmployee, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + DdlBranch.Text + " AND DEPARTMENT_ID=" + DdlDepartment.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

      

        protected void DdlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlSuperVisorMentor.Items.Clear();
            if (DdlBranch.Text != "" && DdlDepartment.Text != "" && DdlEmployee.Text != "")
            {
                GetSuperVisorName();

            }
              
            
        }

        private void GetSuperVisorName()
        { 
        
            
                EmployeeDAO superVisor = new EmployeeDAO();
                List<Employee> empList = superVisor.FindFullNameOfSuperVisor(int.Parse(DdlEmployee.Text));

                if (empList != null && empList.Count > 0)
                {
                   
                    this.DdlSuperVisorMentor.DataSource = empList;
                    this.DdlSuperVisorMentor.DataTextField = "EmpName";
                    this.DdlSuperVisorMentor.DataValueField = "Id";
                    this.DdlSuperVisorMentor.DataBind();
                    this.DdlSuperVisorMentor.SelectedIndex = 0;
                }
                
        
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/OnTheJobTraining/ListOJT.aspx");
        }

       
    }
}
