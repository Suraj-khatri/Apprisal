using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EducationDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.FileUploader;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class EducationDetails :BasePage
    {

        RoleMenuDAOInv _roleMenuDao = null;
        EducationDAO edudao = null;
        EmployeeEducation empedu = null;
        Employee emp = null;
        EmployeeDAO empdao = null;
        FileUploaderDao _fileuploader = null;
        clsDAO _clsDao = new clsDAO();

        public EducationDetails()
        {
            this._roleMenuDao = new RoleMenuDAOInv(); 
            this.edudao = new EducationDAO();
            this.empedu = new EmployeeEducation();
            this.empdao = new EmployeeDAO();
            this.emp = new Employee();
            this._fileuploader = new FileUploaderDao();
        }       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }   
                PopulateDdlList();
                
                if (this.GetEmployeeEducationID() > 0)
                {
                    BtnDelete.Visible = true;
                    this.Populateeducation();
                }
                else
                {
                    BtnDelete.Visible = false;
                    txtEmpId.Text = GetEmpId().ToString();
                }         
            }
        }

        private void PopulateDdlList()
        {
            string selectValue = "";
            if (ddllevel.SelectedItem != null)
                selectValue = ddllevel.SelectedItem.Value.ToString();
            clsDAO swift = new clsDAO();
            swift.setDDL(ref ddllevel, "Exec ProcStaticDataView 's','8'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (ddlcountry.SelectedItem != null)
                selectValue = ddlcountry.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlcountry, "Exec ProcStaticDataView 's','1'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (ddlfaculty.SelectedItem != null)
                selectValue = ddlfaculty.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlfaculty, "Exec ProcStaticDataView 's','13'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (ddlDivision.SelectedItem != null)
                selectValue = ddlDivision.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlDivision, "Exec ProcStaticDataView 's','12'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

        }

        protected void btnSave_Click(object sender, EventArgs e)
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

                if (GetEmployeeEducationID() > 0)
                    flag = "u";
                else
                    flag = "i";

                string msg = _clsDao.GetSingleresult("Exec procManageEducation @flag=" + filterstring(flag) + ",@ID=" + filterstring(GetEmployeeEducationID().ToString()) + ","
                            + " @emp_id=" + filterstring(GetEmpId().ToString()) + ","
                            + " @level=" + filterstring(ddllevel.Text) + ",@degree=" + filterstring(txtDegree.Text) + ","
                            + " @faculty=" + filterstring(ddlfaculty.Text) + ",@division=" + filterstring(ddlDivision.Text) + ","
                            + " @percentage=" + filterstring(txtPercentage.Text) + ",@passedYear=" + filterstring(ddlPassedYear.Text) + ","
                            + " @nameOfIns=" + filterstring(txtnameofinstitution.Text) + ",@country=" + filterstring(ddlcountry.Text) + ","
                            + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            Response.Redirect("ViewEducation.aspx?Id=" + GetEmpId() + "");
            
        }

        private void Populateeducation()
        {
            DataTable dt = _clsDao.getDataset(" Exec [procManageEducation] @flag='s',@id=" + filterstring(GetEmployeeEducationID().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                ddllevel.Text = dr["LEVELS"].ToString();
                txtDegree.Text = dr["DEGREE"].ToString();
                ddlfaculty.Text = dr["FECULTY"].ToString();
                ddlDivision.Text = dr["DIVISION"].ToString();
                txtPercentage.Text = dr["PERCENTAGE"].ToString();
                ddlPassedYear.Text = dr["PASSED_YEAR"].ToString();
                txtnameofinstitution.Text = dr["NAMEOF_INSTITUTION"].ToString();
                ddlcountry.Text = dr["COUNTRY_NAME"].ToString();
            }

        }

        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected long GetEmployeeEducationID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewEducation.aspx?Id=" + GetEmpId() + "");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = _clsDao.GetSingleresult("Exec procManageEducation @flag='D',@id=" + filterstring(GetEmployeeEducationID().ToString()) + "");
                Response.Redirect("ViewEducation.aspx?Id=" + GetEmpId() + "");
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
