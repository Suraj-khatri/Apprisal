using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EducationDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageOtherInfo : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        EducationDAO edudao = null;
        EmployeeEducation empedu = null;
        Employee emp = null;
        EmployeeDAO empdao = null;
        clsDAO CLsDAo = null;

        public ManageOtherInfo()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv(); 
            this.edudao = new EducationDAO();
            this.empedu = new EmployeeEducation();
            this.empdao = new EmployeeDAO();
            this.emp = new Employee();
            this.CLsDAo = new clsDAO();
        }
        protected long GetEmpID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }  
                this.emp = this.empdao.FindFullNameById(GetEmpID());              
                this.PopulateChecked();                
            }
        }
        private void PopulateChecked()
        {
            this.emp = this.empdao.FindOtherInfobyId(this.GetEmpID());
            this.txtEmpId.Text = this.emp.Id.ToString();
            if (emp.IsVehicleFacility == "Y")
            {
                checkVehicle.Checked = true;
            }
            else
            {
                checkVehicle.Checked = false;
            }
            if (emp.IsHouseFacility == "Y")
            {
                checkHouse.Checked = true;
            }
            else
            {
                checkHouse.Checked = false;
            }
            if (emp.IsPensionHolder == "Y")
            {
                txtPensionAmt.Visible = true;
                txtPensionAmt.Text = emp.PensionAmount;
                checkPensionHolder.Checked = true;
            }
            else
            {
                txtPensionAmt.Visible = false;
                checkPensionHolder.Checked = false;
            }
            if (emp.IsDisabled == "Y")
            {
                txtDisabledID.Visible = true;
                txtDisabledID.Text = emp.DisabledId;
                checkDisabled.Checked = true;
            }
            else
            {
                txtDisabledID.Visible = false;
                checkDisabled.Checked = false;
            }
            DdlMaritalStatus.SelectedValue = emp.Meritalstatus;
            DdlResidence.SelectedValue = emp.Nationality;
            DdlRlGroup.SelectedValue = emp.RLGroup;

        }
        private void PrepareOtherInfo()
        {
            String IscheckedVehicle;
            String IscheckedHouse;
            String IscheckedPension;
            String IscheckedDisabled;
            long Id = this.GetEmpID();
            Employee _empCore = new Employee();
            if (Id > 0)
            {
                _empCore.Id = Id;
            }
            if (checkVehicle.Checked == true)
            {
                IscheckedVehicle = "Y";
            }
            else
            {
                IscheckedVehicle = "N";
            }
            _empCore.IsVehicleFacility = IscheckedVehicle.ToString();

            if (checkHouse.Checked == true)
            {
                IscheckedHouse = "Y";
            }
            else
            {
                IscheckedHouse = "N";
            }
            _empCore.IsHouseFacility = IscheckedHouse.ToString();

            if (checkPensionHolder.Checked == true)
            {
                IscheckedPension = "Y";
                
            }
            else
            {
                txtPensionAmt.Visible = false;
                txtPensionAmt.Text = "";
                IscheckedPension = "N";
            }
            _empCore.IsPensionHolder = IscheckedPension.ToString();

            if (checkDisabled.Checked == true)
            {
                IscheckedDisabled = "Y";
                txtDisabledID.Visible = true;
            }
            else
            {
                txtDisabledID.Visible = false;
                txtDisabledID.Text = "";
                IscheckedDisabled = "N";
            }
            _empCore.IsDisabled = IscheckedDisabled.ToString();
            _empCore.PensionAmount = txtPensionAmt.Text;
            _empCore.DisabledId = txtDisabledID.Text;
            _empCore.Meritalstatus = DdlMaritalStatus.Text;
            _empCore.Nationality = DdlResidence.Text;
            _empCore.RLGroup = DdlRlGroup.Text;

            try
            {
                clsDAO swift = new clsDAO();
                if (IscheckedPension == "Y" && txtPensionAmt.Text == "")
                {
                    lblmsg.Text = "Please Enter Annual Pension Amount!";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    swift.runSQL("UPDATE Employee SET AVAAILED_VEHICLE_FACILITY=" + filterstring(_empCore.IsVehicleFacility) + ",AVAILED_HOUSE_RENT_FACILITY=" + filterstring(_empCore.IsHouseFacility) + ","
                    + " IS_PENSION_HOLDER=" + filterstring(_empCore.IsPensionHolder) + ", IS_DISABLED=" + filterstring(_empCore.IsDisabled) + ",MODIFIED_BY=" + filterstring(ReadSession().UserId) + ","
                    + " MODIFIED_DATE=" + filterstring(swift.CreatedDate.ToString()) + ",PENSION_AMOUNT=" + filterstring(_empCore.PensionAmount) + ",MARITAL_STATUS=" + filterstring(_empCore.Meritalstatus) + ","
                    + " DISABLED_ID=" + filterstring(_empCore.DisabledId) + ", NATIONALITY=" + filterstring(_empCore.Nationality) + ",Rl_group ="+ filterstring(_empCore.RLGroup) +" WHERE EMPLOYEE_ID=" + filterstring(_empCore.Id.ToString()) + "");

                    Response.Redirect("ListOtherInfo.aspx?Id=" + GetEmpID() + "");
                }                
            }
            catch
            {
                lblmsg.Text = "Error in Insertion";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            } 
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            this.PrepareOtherInfo();        
        }        
        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListOtherInfo.aspx?Id=" + GetEmpID() + "");
        }
        protected void checkDisabled_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDisabled.Checked == true)
            {
                txtDisabledID.Visible = true;
            }
            else
            {
                txtDisabledID.Visible = false;
            }
        }
        protected void checkPensionHolder_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPensionHolder.Checked == true)
            {
                txtPensionAmt.Visible = true;
            }
            else
            {
                txtPensionAmt.Visible = false;
            }
        }
    }
}
