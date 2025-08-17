using System;
using System.Data;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.MedicalDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class EmpMedicalHistory : BasePage
    {
        MedicalDAO medicaldao = null;
        EmployeeMedical medical = null;
        RoleMenuDAOInv _roleMenuDao = null;
        Employee emp = null;
        EmployeeDAO empdao = null;
        clsDAO _clsDao = null;

        public EmpMedicalHistory()
        {
            this.medicaldao = new MedicalDAO();
            this.medical = new EmployeeMedical();
            this._roleMenuDao = new RoleMenuDAOInv(); 
            this.empdao = new EmployeeDAO();
            this.emp = new Employee();
            this._clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                if (this.GetEmployeehelthID() > 0)
                {
                    this.populateempmed();
                    this.BtnDelete.Visible = true;
                }
                else
                {
                    this.BtnDelete.Visible = false;                 
                    this.hdnEmpId.Value = GetEmpId().ToString();
                    txtcheckeddate.Text = System.DateTime.Today.ToShortDateString();
                }
                //this.emp = this.empdao.FindFullNameById(long.Parse(hdnEmpId.Value));
                //this.LblEmpName.Text = this.emp.EmpName;                    
            }
            txtcheckeddate. Attributes.Add("onblur", "checkDateFormat(this);");
        }

        protected void BtnSaveMedical_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "Sorry! Cannot save the details. Please Verify the filled in details.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            //string fileType = "";
            string flag = "i";

                if (GetEmployeehelthID() > 0)
                    flag = "u";
                else
                    flag = "i";

                string msg = _clsDao.GetSingleresult("Exec procManageMedical @flag=" + filterstring(flag) + ",@ID=" + filterstring(GetEmployeehelthID().ToString()) + ","
                            + " @emp_id=" + filterstring(GetEmpId().ToString()) + "," 
                            + " @problem=" + filterstring(txtproblem.Text) + ",@diagnosis=" + filterstring(txtdignosis.Text) + ","
                            + " @doctor=" + filterstring(txtdoctor.Text) + ",@hospital=" + filterstring(txthospital.Text) + ","
                            + " @checkedDate=" + filterstring(txtcheckeddate.Text) + ",@disease=" + filterstring(txtdesease.Text) + ","
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            Response.Redirect("ViewMedical.aspx?Id=" + GetEmpId() + "");

        }

        private void populateempmed()
        {

            DataTable dt = _clsDao.getDataset(" Exec [procManageMedical] @flag='s',@id=" + filterstring(GetEmployeehelthID().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                txtproblem.Text = dr["PROBLEM"].ToString();
                txtdignosis.Text = dr["DIAGNOSIS"].ToString();
                txtdoctor.Text = dr["DOCTOR"].ToString();
                txthospital.Text = dr["HOSPITAL"].ToString();
                txtcheckeddate.Text = dr["CHACHED_DATE"].ToString();
                txtdesease.Text = dr["DESEASE"].ToString();
            }

        }

        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected long GetEmployeehelthID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = _clsDao.GetSingleresult("Exec procManageMedical @flag='D',@id=" + filterstring(GetEmployeehelthID().ToString()) + "");
                Response.Redirect("ViewMedical.aspx?Id=" + GetEmpId() + "");
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewMedical.aspx?Id=" + GetEmpId() + "");
        }       
    }
}
