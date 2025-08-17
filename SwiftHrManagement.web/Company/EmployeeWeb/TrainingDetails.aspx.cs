using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class TrainingDetails : BasePage
    {
        clsDAO _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public TrainingDetails()
        {
            _clsdao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv(); 
        }       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                PopulateDdlList();
                if (this.GetEmployeeTrainingID() > 0)
                {
                    BtnDelete.Visible = true;
                    this.Populatetraining();
                }
                else
                {
                    BtnDelete.Visible = false;
                    txtempid.Value = GetEmpId().ToString();
                }                
            }           
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        protected long GetEmployeeTrainingID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ManageTraining();      
            Response.Redirect("ListTrainingItems.aspx?Id=" + txtempid.Value);
        }
        private void ManageTraining()
        {
            if (GetEmployeeTrainingID() > 0)
                 _clsdao.runSQL("Update Employee_Training set EMPLOYEE_ID=" + filterstring(txtempid.Value) + ",FECULTY=" + filterstring(ddlfecaulty.Text) + ",DURATION=" + filterstring(txtDuration.Text) + ",NAMEOF_INSTITUTION=" + filterstring(txtnameofinstitution.Text) + ",ADDRESS=" + filterstring(txtAddress.Text) + ",TRN_DESC=" + filterstring(txtTrndescription.Text) + " where TRAINING_ID=" + GetEmployeeTrainingID() + " ");
               
            else
            {
                _clsdao.runSQL("Insert into Employee_Training(EMPLOYEE_ID,FECULTY,DURATION,NAMEOF_INSTITUTION,ADDRESS,TRN_DESC)"
                    + " values(" +filterstring(txtempid.Value )+ ", " +filterstring(ddlfecaulty.Text) + "," +filterstring(txtDuration.Text) + "," +filterstring(txtnameofinstitution.Text)+ "," +filterstring(txtAddress.Text) + "," +filterstring(txtTrndescription.Text)+ ")");
            }
        }
       
        private void PopulateDdlList()
        {
            string selectValue = "";
            clsDAO swift = new clsDAO();
          
            if (ddlfecaulty.SelectedItem != null)
                selectValue = ddlfecaulty.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlfecaulty, "Exec ProcStaticDataView 's','55'", "ROWID", "DETAIL_TITLE", selectValue, "Select");          
        }
        private void Populatetraining()
        {       
            DataTable dt = new DataTable();
             dt = _clsdao.getDataset("select FECULTY,DURATION,NAMEOF_INSTITUTION,ADDRESS,TRN_DESC, EMPLOYEE_ID from Employee_Training where TRAINING_ID='" + GetEmployeeTrainingID() + "'").Tables[0];           
           // dt = _clsdao.getDataset("select FECULTY,DURATION,NAMEOF_INSTITUTION,ADDRESS,TRN_DESC, t.EMPLOYEE_ID, e.FIRST_NAME, e.MIDDLE_NAME , e.LAST_NAME from Employee_Training t, Employee e  where t.EMPLOYEE_ID=e.EMPLOYEE_ID ").Tables[0];           
            foreach (DataRow dr in dt.Rows)
            {
               ddlfecaulty.Text = dr["FECULTY"].ToString();
               txtDuration.Text = dr["DURATION"].ToString();
               txtnameofinstitution.Text = dr["NAMEOF_INSTITUTION"].ToString();
               txtAddress.Text = dr["ADDRESS"].ToString();
               txtTrndescription.Text = dr["TRN_DESC"].ToString();
               txtempid.Value  = dr["EMPLOYEE_ID"].ToString();
              // LblEmpName.Text = dr["FIRST_NAME"].ToString() + " " + dr["MIDDLE_NAME"].ToString() +" "+ dr["LAST_NAME"].ToString() ;

            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //string strDelete = "Delete from Employee_Training where TRAINING_ID='" + GetEmployeeTrainingID() + "'";
            _clsdao.runSQL("Delete from Employee_Training where TRAINING_ID='" + GetEmployeeTrainingID() + "'");
             Response.Redirect("ListTrainingItems.aspx?Id=" + txtempid.Value);
          
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListTrainingItems.aspx?Id="+ txtempid.Value  );
        }
    }
}
