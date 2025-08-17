using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        EmployeeDAO empdao = null;
        Employee emp = null;
        clsDAO swift = null;

        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this.empdao = new EmployeeDAO();
            this.emp = new Employee();
            this.swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!this.IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.PopulateDdlList();
                if (this.GetEmployeeId() > 0)
                {
                    BtnDelete.Visible = true;
                    this.PopulateEmployee();
                }
                else
                {
                    BtnDelete.Visible = false;
                }

                SessionStore session = ReadSession();
                if (!session.CanViewProfile)
                {
                }

                txtlastpromoted.Enabled = false;
                txtlasttransfer.Enabled = false;
            }

            if (empdao.CheckHrAdmin(Convert.ToInt32(ReadSession().Emp_Id.ToString())))
            {
                showHide.Visible = true;
                showHideSaveBtn.Visible = true;
                showHideDeleteBtn.Visible = true;

            }
            else
            if (empdao.CheckHrAdmin(Convert.ToInt32(ReadSession().Emp_Id.ToString())))
            {
                showHideSaveBtn.Visible = true;
                showHideDeleteBtn.Visible = false;

                DisableField();
            }
            else if (empdao.DoesAccessUpdateProfile(ReadSession().Emp_Id.ToString()))
            {
                showHideSaveBtn.Visible = true;
                showHideDeleteBtn.Visible = false;
                DisableField();
            }

            else if (empdao.DoesAccessUpdateProfile(ReadSession().Emp_Id.ToString()) && empdao.DoesHrUser(ReadSession().Emp_Id.ToString()))
            {
                showHideSaveBtn.Visible = true;
                showHideDeleteBtn.Visible = true;
            }
            else
            {
                showHideSaveBtn.Visible = false;
                showHideDeleteBtn.Visible = false;
                showHide.Visible = false;
            }
            txtFristContactNumber.Attributes.Add("onblur", "checknumber(this);");
            txtSecondContactNumber.Attributes.Add("onblur", "checknumber(this);");
            txtThirdContactNumber.Attributes.Add("onblur", "checknumber(this);");
            txtdob.Attributes.Add("onblur", "checkDateFormat(this);");
            txtAppointmentDate.Attributes.Add("onblur", "checkDateFormat(this);");
            txtdoj.Attributes.Add("onblur", "checkDateFormat(this);");
        }
        public string GetProfileImages()
        {
            string SQL = "select cast(ROWID  as varchar(20)) +'.'+ FILE_TYPE from EmployeeFileUpload where EMP_ID='" + GetEmployeeId().ToString() + "' and profile_picture_flag='y' ";
            string Image_name = swift.GetSingleresult(SQL);
            return Image_name;

        }

        private void DisableField()
        {
            //DdlBranchName.Enabled = false;
            //ddldepartment.Enabled = false;
            //ddlposition.Enabled = false;
            txtAppointmentDate.Enabled = false;
            DdlEmpType.Enabled = true;
            txtdoj.Enabled = false;
            //ddlmeritalstatus.Enabled = false;
            //ddlGender.Enabled = false;
            txtdob.Enabled = false;
            DdlEmpStatus.Enabled = false;
            txtPermanentDate.Enabled = true;
            txtContractFrm.Enabled = false;
            txtContractTo.Enabled = false;
            txtEmpCode.Enabled = false;
            //ddlFunTitle.Enabled = false;
            ddlSalaryTitle.Enabled = false;
            txtCardNumber.Enabled = false;
            DdlSalutation.Enabled = false;
            ChkInvProfileUpdate.Enabled = true;
        }

        private void PopulateDdlList()
        {
            this.PopulateDdlSalutation();
            this.PopulateDdlBranch();        
            this.PopulateDdlPost();
            this.DdlPerCountryList();
            this.DdlPerDistrictList();
            this.DdlPerZoneList();
            this.DdlTempCountryList();
            this.DdlTempDistrictList();
            this.DdlTempZoneList();
            this.ddlmeritalstatusList();
            this.ddlGenderList();
            this.ddlbloodgroupList();
            this.DdlEmpStatusList();
            this.DdlEmpTypeList();
            this.DdlEM_Relationship();
            this.DdlFunTitle();
            this.ddlSalaryTitleList();
        }
        private void PopulateDdlSalutation()
        {
            string selectValue = "";
            if (DdlSalutation.SelectedItem != null)
                selectValue = DdlSalutation.SelectedItem.Value.ToString();          
            swift.setDDL(ref DdlSalutation, "Exec ProcStaticDataView 's','43'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void DdlFunTitle()
        {
            string selectValue = "";
            if (ddlFunTitle.SelectedItem != null)
                selectValue = ddlFunTitle.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlFunTitle, "Exec ProcStaticDataView 's','59'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void populateDepartment()
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID(long.Parse(DdlBranchName.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);
                this.ddldepartment.DataSource = deptlist;
                this.ddldepartment.DataTextField = "Deptname";
                this.ddldepartment.DataValueField = "Id";
                this.ddldepartment.DataBind();
                this.ddldepartment.SelectedIndex = 0;
            }
           
        }

        private void populateSubDepartment()
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindSubDeptByBranchID(long.Parse(DdlBranchName.Text), long.Parse(ddldepartment.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);
                this.subDeptDDL1.DataSource = deptlist;
                this.subDeptDDL1.DataTextField = "Deptname";
                this.subDeptDDL1.DataValueField = "Id";
                this.subDeptDDL1.DataBind();
                this.subDeptDDL1.SelectedIndex = 0;

                this.subDeptDDL2.DataSource = deptlist;
                this.subDeptDDL2.DataTextField = "Deptname";
                this.subDeptDDL2.DataValueField = "Id";
                this.subDeptDDL2.DataBind();
                this.subDeptDDL2.SelectedIndex = 0;
            }
            
        }
        private void PopulateDdlBranch()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "Select";
                branchlist.Insert(0, DefaultBrn);
                this.DdlBranchName.DataSource = branchlist;
                this.DdlBranchName.DataTextField = "Name";
                this.DdlBranchName.DataValueField = "Id";
                this.DdlBranchName.DataBind();
                this.DdlBranchName.SelectedIndex = 0;
            }
        }
        private void PopulateDdlPost()
        {
            string selectValue = "";
            if (ddlposition.SelectedItem != null)
                selectValue = ddlposition.SelectedItem.Value.ToString();          
            swift.setDDL(ref ddlposition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void DdlPerCountryList()
        {
            string selectValue = "";
            if (DdlPerCountry.SelectedItem != null)
                selectValue = DdlPerCountry.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlPerCountry, "Exec ProcStaticDataView 's','1'", "ROWID", "DETAIL_TITLE", "136", "Select");

        }
        private void DdlTempCountryList()
        {
            string selectValue = "";
            if (DdlTempCountry.SelectedItem != null)
            selectValue = DdlTempCountry.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlTempCountry, "Exec ProcStaticDataView 's','1'", "ROWID", "DETAIL_TITLE","136", "Select");

        }
        private void DdlPerDistrictList()
        {
           
        }
        private void DdlTempDistrictList()
        {

        }
        private void DdlPerZoneList()
        {
            string selectValue = "";
            if (DdlPerZone.SelectedItem != null)
                selectValue = DdlPerZone.SelectedItem.Value.ToString();     
            swift.setDDL(ref DdlPerZone, "Exec ProcStaticDataView 's','2'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void DdlTempZoneList()
        {
            string selectValue = "";
            if (DdlTempZone.SelectedItem != null)
                selectValue = DdlTempZone.SelectedItem.Value.ToString();     
            swift.setDDL(ref DdlTempZone, "Exec ProcStaticDataView 's','2'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void ddlmeritalstatusList()
        {
            string selectValue = "";
            if (ddlmeritalstatus.SelectedItem != null)
            selectValue = ddlmeritalstatus.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlmeritalstatus, "Exec ProcStaticDataView 's','11'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void ddlGenderList()
        {
            string selectValue = "";
            if (ddlGender.SelectedItem != null)
                selectValue = ddlGender.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlGender, "Exec ProcStaticDataView 's','5'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void ddlbloodgroupList()
        {
            string selectValue = "";
            if (ddlbloodgroup.SelectedItem != null)
            selectValue = ddlbloodgroup.SelectedItem.Value.ToString();    
            swift.setDDL(ref ddlbloodgroup, "Exec ProcStaticDataView 's','6'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void DdlEmpStatusList()
        {
            string selectValue = "";
            if (DdlEmpStatus.SelectedItem != null)
                selectValue = DdlEmpStatus.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlEmpStatus, "Exec ProcStaticDataView 's','49'", "ROWID", "DETAIL_TITLE", "458", "Select");
        }
        private void DdlEmpTypeList()
        {
            string selectValue = "";
            if (DdlEmpType.SelectedItem != null)
                selectValue = DdlEmpType.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlEmpType, "Exec ProcStaticDataView 's','10'","ROWID","DETAIL_TITLE",selectValue,"Select");
        }
        private void ddlSalaryTitleList()
        {
            string selectValue = "";
            if (ddlSalaryTitle.SelectedItem != null)
                selectValue = ddlSalaryTitle.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlSalaryTitle, "Exec ProcStaticDataView 's','98'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        private void DdlEM_Relationship()
        {
            string selectValue = "";


            if (ddlRelationship.SelectedItem != null)
                selectValue = ddlRelationship.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlRelationship, "Exec ProcStaticDataView 's','27'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

        }
        protected long GetEmployeeId()
        {
             return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);            
        }  
        private Boolean ValidateDdl(DropDownList ddlcontrol)
        {
            if (ddlcontrol.SelectedIndex == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private Boolean checkEmpCodeUnique()
        {
            return (empdao.checkEmpCodeUnique(txtEmpCode.Text));
        }
        private Boolean checkEmpCodeUnique1(long emp_id)
        {
            return (empdao.checkEmpCodeUnique1(txtEmpCode.Text,emp_id));
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (GetEmployeeId() > 0) //check the user weather user is logged in or not

                this.Page.MasterPageFile = "~/ProjectMaster.Master";
            else
                this.Page.MasterPageFile = "~/SwiftHRManager.Master";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {            
            try
            {
                if (ddldepartment.SelectedIndex == 0)
                {
                    //GetStatic.SweetAlertMessage(this, "", "Subdepartment 1 and SubDepartment 2 cannot have same value");
                    GetStatic.AlertMessage(this, "Please select department!");
                    return;
                }
                long id = this.GetEmployeeId();
                this.PrepareEmp();
                if (id > 0)
                {
                    if (checkEmpCodeUnique1(id) == true)
                    {
                        lblmsg.Text = "Employee Code Already Exist!";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Focus();
                        return;
                    }
                    else
                    {
                        this.emp.ModifyBy = this.ReadSession().UserId;
                        this.empdao.Update(this.emp);
                        LblMsg1.Text = "Update Successfully";
                        LblMsg1.ForeColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    if (checkEmpCodeUnique() == true)
                    {
                        lblmsg.Text = "Employee Code Already Exist!";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        lblmsg.Focus();
                        return;
                    }
                    else
                    {
                        this.emp.CreatedBy = this.ReadSession().UserId;
                        this.empdao.Save(this.emp);
                        Response.Redirect("List.aspx");
                        LblMsg1.Text = "save Successfully";
                        LblMsg1.ForeColor = System.Drawing.Color.Red;
                    }
                }
                
            }
            catch
            {
                lblmsg.Text = "Error In Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }            
        }
        private void PrepareEmp()
        {
            Employee employee = new Employee();
            long Id = this.GetEmployeeId();
            if (Id > 0)
            {
                employee.Id = Id;
            }
            employee.EmpCode = txtEmpCode.Text;
            employee.Salute = DdlSalutation.Text;
            employee.Fname = txtfname.Text;
            employee.Mname = txtmname.Text;
            employee.Lname = txtlname.Text;     
            employee.Phoneoffice = txtphonoff.Text;
            employee.Phoneres = txtphonres.Text;
            employee.Moboffice = txtmoboff.Text;
            employee.Mobpersonal = txtmobpersonal.Text;
            employee.Faxoffice = txtfaxoffice.Text;
            employee.Faxpersonal = txtfaxpersonal.Text;
            employee.Emailoffice = txtemailoffice.Text;
            employee.Emailperonal = txtemailoffpersonal.Text;
            employee.Gender = ddlGender.Text;
            employee.Department_id = ddldepartment.Text;
            employee.SubDepartment_id = subDeptDDL1.Text;
            employee.SubDepartment_id2 = subDeptDDL2.Text;
            employee.Branch_id = DdlBranchName.Text;
            employee.Position_id = ddlposition.Text;
            employee.Bloodgoup = ddlbloodgroup.Text;            
            employee.Dateofbirth = txtdob.Text;
            employee.Dateofjoining = txtdoj.Text;
            employee.Meritalstatus = ddlmeritalstatus.Text;
            employee.Pannumber = txtpannumber.Text;
            employee.Per_streetname = TxtPerStreetName.Text;
            employee.Per_wardno = TxtPerWardno.Text;
            employee.Per_houseno = TxtPerHouseno.Text;
            employee.Per_muni_vdc = TxtPerMVDC.Text;
            employee.Per_district = DdlPerDistrict.Text;
            employee.Per_zone = DdlPerZone.Text;
            employee.Per_country = DdlPerCountry.Text;
            employee.Temp_streetname = TxtTempStreetName.Text;
            employee.Temp_wardno = TxtTempWardno.Text;
            employee.Temp_houseno = TxtTempHouseno.Text;
            employee.Temp_muni_vdc = TxtTempMVDC.Text;
            employee.Temp_district = DdlTempDistrict.Text;
            employee.Temp_zone = DdlTempZone.Text;
            employee.Temp_country = DdlTempCountry.Text;
            employee.ExtensionNO = txtExtensionNO.Text;

            employee.EmpType = DdlEmpType.Text;
            employee.EmpStatus = DdlEmpStatus.Text;
            employee.AppointmentDate = txtAppointmentDate.Text;

            employee.EmName = txtEmName.Text;
            employee.EmAddress = txtEmAddress.Text;
            employee.EmRelationship = ddlRelationship.Text;
            employee.EmFirstContact = txtFristContactNumber.Text;
            employee.EmSecondContact = txtSecondContactNumber.Text;
            employee.EmThirdContact = txtThirdContactNumber.Text;
            employee.EmEmail = txtEmail.Text;
            employee.PermanentDate = txtPermanentDate.Text;
            employee.ContractFrom = txtContractFrm.Text;
            employee.ContractTo = txtContractTo.Text;
            employee.FuncTitle = ddlFunTitle.Text;
            employee.CardNumber = txtCardNumber.Text;
            employee.GratuityStartDate = txtGratuityStartDate.Text;
            employee.SalaryTitle = ddlSalaryTitle.Text;
            employee.GradeYear = txtGradeYear.Text;

            if(ChkInvProfileUpdate.Checked)
            {
                employee.IndividualProfileUpdate = "y";
            }
            else
            {
                employee.IndividualProfileUpdate = "n";
            }
           

            this.emp = employee;
        }
        private void PopulateEmployee()
        {
            this.emp = this.empdao.FindbyId(this.GetEmployeeId());
            this.txtEmpCode.Text = this.emp.EmpCode;
            this.DdlSalutation.SelectedValue = this.emp.Salute;
            this.txtfname.Text = this.emp.Fname;
            this.txtmname.Text = this.emp.Mname;
            this.txtlname.Text = this.emp.Lname;       
            this.txtphonoff.Text = this.emp.Phoneoffice;
            this.txtphonres.Text = this.emp.Phoneres;
            this.txtmoboff.Text = this.emp.Moboffice;
            this.txtmobpersonal.Text = this.emp.Mobpersonal;
            this.txtfaxoffice.Text = this.emp.Faxoffice;
            this.txtfaxpersonal.Text = this.emp.Faxpersonal;
            this.txtemailoffice.Text = this.emp.Emailoffice;
            this.txtemailoffpersonal.Text = this.emp.Emailperonal;
            this.ddlGender.SelectedValue = this.emp.Gender;
            this.DdlBranchName.SelectedValue = this.emp.Branch_id;
            this.populateDepartment();
           
            this.ddldepartment.SelectedValue = this.emp.Department_id;
            this.populateSubDepartment();
            this.subDeptDDL1.SelectedValue = this.emp.SubDepartment_id;
            this.subDeptDDL2.SelectedValue = this.emp.SubDepartment_id2;
            this.ddlposition.SelectedValue = this.emp.Position_id;
            this.ddlbloodgroup.SelectedValue = this.emp.Bloodgoup;          
            this.txtdob.Text = this.emp.Dateofbirth;
            this.txtdoj.Text = this.emp.Dateofjoining;
            this.ddlmeritalstatus.SelectedValue = this.emp.Meritalstatus;
            this.txtpannumber.Text = this.emp.Pannumber;
            this.TxtPerStreetName.Text = this.emp.Per_streetname;
            this.TxtPerWardno.Text = this.emp.Per_wardno;
            this.TxtPerHouseno.Text = this.emp.Per_houseno;
            this.TxtPerMVDC.Text = this.emp.Per_muni_vdc;
            
            this.DdlPerZone.SelectedValue = this.emp.Per_zone;
            this.DdlPerCountry.SelectedValue = this.emp.Per_country;
            this.TxtTempStreetName.Text = this.emp.Temp_streetname;
            this.TxtTempWardno.Text = this.emp.Temp_wardno;
            this.TxtTempHouseno.Text = this.emp.Temp_houseno;
            this.TxtTempMVDC.Text = this.emp.Temp_muni_vdc;
            this.DdlTempZone.SelectedValue = this.emp.Temp_zone;
            this.DdlTempCountry.SelectedValue = this.emp.Temp_country;
            this.txtExtensionNO.Text = this.emp.ExtensionNO;
            
            this.DdlEmpStatus.SelectedValue = this.emp.EmpStatus;
            this.DdlEmpType.SelectedValue = this.emp.EmpType;
            if (DdlEmpType.Text == "519")
            {
                RequiredFieldValidator6.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                //rfv.Enabled = false;
                rfv1.Enabled = false;
                //Rffd1.Enabled = false;
                //Rftd1.Enabled = false;
            }
            this.txtAppointmentDate.Text = this.emp.AppointmentDate;

            this.txtEmName.Text = this.emp.EmName;
            this.txtEmAddress.Text = this.emp.EmAddress;
            this.txtFristContactNumber.Text = this.emp.EmFirstContact;
            this.txtSecondContactNumber.Text = this.emp.EmSecondContact;
            this.txtThirdContactNumber.Text = this.emp.EmThirdContact;
            this.txtEmail.Text = this.emp.EmEmail;
            this.ddlRelationship.Text = this.emp.EmRelationship;
            this.txtPermanentDate.Text = this.emp.PermanentDate;
            this.ddlFunTitle.SelectedValue = this.emp.FuncTitle;
            this.txtCardNumber.Text = this.emp.CardNumber;
            this.txtGratuityStartDate.Text = this.emp.GratuityStartDate;
            this.ddlSalaryTitle.Text = this.emp.SalaryTitle;
            this.txtGradeYear.Text = this.emp.GradeYear;

            if(DdlTempZone.Text!="")
                swift.CreateDynamicDDl(DdlTempDistrict, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=3 and value=" + filterstring(DdlTempZone.Text) + "", "ROWID", "DETAIL_TITLE", "", "Select");

            if (DdlPerZone.Text != "")
                swift.CreateDynamicDDl(DdlPerDistrict, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=3 and value=" + filterstring(DdlPerZone.Text) + "", "ROWID", "DETAIL_TITLE", "", "Select");


            this.DdlTempDistrict.SelectedValue = this.emp.Temp_district;
            this.DdlPerDistrict.SelectedValue = this.emp.Per_district;
            this.txtlastpromoted.Text = this.emp.LastPromoted;
            this.txtlasttransfer.Text = this.emp.LastTransfer;
            if(emp.IndividualProfileUpdate =="y")
            {
                ChkInvProfileUpdate.Checked = true;
            }
            else
            {
                ChkInvProfileUpdate.Checked = false;
            }
            GetServiceDate();
            ShowHideEmpType();
        }
        private void GetServiceDate()
        {
            DataTable dt=swift.getTable("EXEC ProcManageEmployeeDetails 'a'," + filterstring(GetEmployeeId().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                txtContractFrm.Text = dr["Cont_DateFrm"].ToString();
                txtContractTo.Text = dr["Cont_DateTo"].ToString();
            }
            
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.empdao.DeleteById(this.GetEmployeeId(), ReadSession().UserId);
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void txtEmpCode_TextChanged(object sender, EventArgs e)
        {
            if (checkEmpCodeUnique() == true)
            {
                lblmsg.Text = "Employee Code already Exist!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                txtEmpCode.Focus();
                return;
            }
            else
            {
                lblmsg.Text = "";
                DdlSalutation.Focus();
            }
        }

        protected void DdlEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowHideEmpType();

        }

        public void ShowHideEmpType()
        {
            ListItem lst = DdlEmpType.SelectedItem;
            DdlEmpType.Focus();
            if (lst.Text == "Permanent")
            {
                div_permamanent_date.Visible = true;
                div_Contract_detail.Visible = false;
            }
            else
            {
                div_Contract_detail.Visible = true;
                div_permamanent_date.Visible = false;
            }
            if(DdlEmpType.Text=="519")
            {
                RequiredFieldValidator6.Enabled = false;
                RequiredFieldValidator5.Enabled = false;
                //rfv.Enabled = false;
                rfv1.Enabled = false;
                //Rffd1.Enabled = false;
                //Rftd1.Enabled = false;
            }
        }

        protected void btnLink_Click(object sender, EventArgs e)
        {
            DdlTempCountry.SelectedValue = DdlPerCountry.Text;
            DdlTempZone.SelectedValue = DdlPerZone.Text;
            DdlTempDistrict.SelectedValue = DdlPerDistrict.Text;
            TxtTempMVDC.Text = TxtPerMVDC.Text;
            TxtTempHouseno.Text = TxtPerHouseno.Text;
            TxtTempStreetName.Text = TxtPerStreetName.Text;
            TxtTempWardno.Text = TxtPerWardno.Text;
        }

        protected void DdlPerZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlPerZone.Text != "")
            {
                string selectValue = "";
                if (DdlPerDistrict.SelectedItem != null)
                    selectValue = DdlPerDistrict.SelectedItem.Value.ToString();
                swift.setDDL(ref DdlPerDistrict, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=3 and value=" + filterstring(DdlPerZone.Text) + "", "ROWID", "DETAIL_TITLE", selectValue, "Select");
            }
        }

        protected void DdlTempZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlTempZone.Text != "")
            {
                string selectValue = "";
                if (DdlTempDistrict.SelectedItem != null)
                    selectValue = DdlTempDistrict.SelectedItem.Value.ToString();
                swift.setDDL(ref DdlTempDistrict, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=3 and value=" + filterstring(DdlTempZone.Text) + "", "ROWID", "DETAIL_TITLE", selectValue, "Select");
            }
        }
        protected void DdlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindDeptByBranchID(long.Parse(DdlBranchName.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);
                this.ddldepartment.DataSource = deptlist;
                this.ddldepartment.DataTextField = "Deptname";
                this.ddldepartment.DataValueField = "Id";
                this.ddldepartment.DataBind();
                this.ddldepartment.SelectedIndex = 0;
            }
           
            ddldepartment.Focus();
        }

        protected void ddldepartment_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DepartmentDAO deptdao = new DepartmentDAO();
            List<DepartmentCore> deptlist = deptdao.FindSubDeptByBranchID(long.Parse(DdlBranchName.Text),long.Parse(ddldepartment.Text));
            if (deptlist != null && deptlist.Count > 0)
            {
                DepartmentCore deprtcore = new DepartmentCore();
                deprtcore.Deptname = "Select";
                deptlist.Insert(0, deprtcore);
                this.subDeptDDL1.DataSource = deptlist;
                this.subDeptDDL1.DataTextField = "Deptname";
                this.subDeptDDL1.DataValueField = "Id";
                this.subDeptDDL1.DataBind();
                this.subDeptDDL1.SelectedIndex = 0;

                this.subDeptDDL2.DataSource = deptlist;
                this.subDeptDDL2.DataTextField = "Deptname";
                this.subDeptDDL2.DataValueField = "Id";
                this.subDeptDDL2.DataBind();
                this.subDeptDDL2.SelectedIndex = 0;
            }
            else
            {
                subDeptDDL1.Items.Clear();
                  subDeptDDL2.Items.Clear();  
            }
            //if (deptlist != null && deptlist.Count > 0)
            //{
            //    DepartmentCore deprtcore = new DepartmentCore();
            //    deprtcore.Deptname = "Select";
            //    deptlist.Insert(0, deprtcore);
               
            //}
            subDeptDDL1.Focus();

        }

        protected void subDeptDDL2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (subDeptDDL1.SelectedValue == subDeptDDL2.SelectedValue)
            {
                //GetStatic.SweetAlertMessage(this,"","Subdepartment 1 and SubDepartment 2 cannot have same value");
                GetStatic.AlertMessage(this, "Subdepartment 1 and SubDepartment 2 cannot have same value");
                return;
            }
        }

        protected void subDeptDDL1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (subDeptDDL2.SelectedValue == subDeptDDL1.SelectedValue)
            {
                //GetStatic.SweetAlertMessage(this, "", "Subdepartment 1 and SubDepartment 2 cannot have same value");
                GetStatic.AlertMessage(this, "Subdepartment 1 and SubDepartment 2 cannot have same value");
                return;
            }
        }
    }
}