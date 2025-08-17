using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.FamilyMembersDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageFamilyMembers : BasePage
    {
        EmployeeDAO empdao = null;
        Employee emp = null;
        RoleMenuDAOInv _roleMenuDao = null;
        FamilyMembersDAO _familyMembersDao = null;
        FamilyMembersCore _familyMembersCore = null;
        clsDAO _clsdao = null;
        public ManageFamilyMembers()
        {
            _clsdao = new clsDAO();

            this.empdao = new EmployeeDAO();
            this.emp = new Employee();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._familyMembersDao = new FamilyMembersDAO();
            this._familyMembersCore = new FamilyMembersCore();
        }

        protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        protected long GetFamilyMemberId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateoccupation()
        {
            _clsdao.CreateDynamicDDl(Ddloccupation, "select ROWID, DETAIL_TITLE from StaticDataDetail where TYPE_ID =56", "ROWID", "DETAIL_TITLE", "DETAIL_TITLE", "Select");
            
        }
        private void PopulateFamilyMembers()
        {
            pnlDisplayFile.Visible = true;
            familyFileUpload.Visible = false;

            this._familyMembersCore = this._familyMembersDao.FindById(this.GetFamilyMemberId());
            this.DdlRelation.SelectedValue = this._familyMembersCore.Relation;
            this.DdlGender.SelectedValue = this._familyMembersCore.Gender;
            this.DdlBloodGroup.SelectedValue = this._familyMembersCore.BloodGroup;
            this.DdlMaritalStatus.SelectedValue = this._familyMembersCore.MaritalStatus;
                        
            this.TxtFirstName.Text = this._familyMembersCore.FirstName;
            this.TxtMiddleName.Text = this._familyMembersCore.MiddleName;
            this.TxtLastName.Text = this._familyMembersCore.LastName;
            this.TxtMobileNumber.Text = this._familyMembersCore.MobileNumber;
            this.TxtDateOfBirth.Text = this._familyMembersCore.DateOfBirth.ToString();
            this.TxtCurrentAddress.Text = this._familyMembersCore.CurrentAddress;
            this.TxtNationality.Text = this._familyMembersCore.Nationality;
            this.TxtnationalityNumber.Text = this._familyMembersCore.NationalityNumber;
            this.txtIssueDate.Text = this._familyMembersCore.IssueDate.ToString();
            this.TxtPassportNumber.Text = this._familyMembersCore.PassportNumber;

            this.TxtEmployer.Text = this._familyMembersCore.Employer;
            this.TxtDesignation.Text = this._familyMembersCore.Designation;
            this.TxtOfficePhone.Text = this._familyMembersCore.OfficePhone;
            this.TxtOfficeEmail.Text = this._familyMembersCore.OfficeEmail;

            this.TxtEmployerAddress.Text = this._familyMembersCore.EmployerAddress;
            this.TxtInsurer.Text = this._familyMembersCore.Insurer;
            this.TxtInsurancePolicy.Text = this._familyMembersCore.InsurancePolicyNumber;
            this.TxtInsurancePolicyExpiryDate.Text = this._familyMembersCore.InsuranceExpiryDate.ToString();
            this.TxtStudyCenter.Text = this._familyMembersCore.StudyCenterName;
            this.TxtNameOfCourse.Text = this._familyMembersCore.NameOfCourse;
            this.TxtLevelOfStudy.Text = this._familyMembersCore.LevelOfStudy;
            this.TxtStudyCenterPhone.Text = this._familyMembersCore.StudyCenterPhone;
            this.TxtStudyCenterEmail.Text = this._familyMembersCore.StudyCenterEmail;
            this.TxtStudyCenterAddress.Text = this._familyMembersCore.StudyCenterAddress;

            this.hdnempid.Value = this._familyMembersCore.EmployeeId.ToString();



            this.Ddloccupation.Text = this._familyMembersCore.Occupation;
            this.Ddlstatus.SelectedItem.Text = this._familyMembersCore.Status;

            string fileDescription=this._familyMembersCore.FamilyMembDoc;

            if (fileDescription == "error:Invalid file content")
            {
                familyFileName.Value = "";
                this.lblFileDesc.Text = "No File Uploaded";
            }
            else
            {
                familyFileName.Value = fileDescription;

                var documentType = fileDescription.Split('_');

                this.lblFileDesc.Text = documentType[0].ToString();

                lblLink.Text = "<a target='_blank' href='../../doc/FamilyMember/" + fileDescription + "'> Browse File </a>";
            }



        }
        private string ManageFamMem()

        {

            FamilyMembersCore _famCore = new FamilyMembersCore();
            long Id = this.GetFamilyMemberId();
            
            _familyMembersCore.Id = long.Parse(Id.ToString());
            _familyMembersCore.Relation = DdlRelation.Text;
            _familyMembersCore.Gender = DdlGender.Text;
            _familyMembersCore.BloodGroup = DdlBloodGroup.Text;
            _familyMembersCore.MaritalStatus = DdlMaritalStatus.Text;
            _familyMembersCore.FirstName = TxtFirstName.Text;
            _familyMembersCore.MiddleName = TxtMiddleName.Text;
            _familyMembersCore.LastName = TxtLastName.Text;
            _familyMembersCore.MobileNumber = TxtMobileNumber.Text;
            _familyMembersCore.DateOfBirth = (TxtDateOfBirth.Text);
            _familyMembersCore.CurrentAddress = TxtCurrentAddress.Text;

            _familyMembersCore.Nationality = TxtNationality.Text;
            _familyMembersCore.NationalityNumber = TxtnationalityNumber.Text;
            _familyMembersCore.IssueDate = (txtIssueDate.Text);
            _familyMembersCore.PassportNumber = TxtPassportNumber.Text;

            _familyMembersCore.Employer = TxtEmployer.Text;
            _familyMembersCore.Designation = TxtDesignation.Text;
            _familyMembersCore.OfficePhone = TxtOfficePhone.Text;
            _familyMembersCore.OfficeEmail = TxtOfficeEmail.Text;
            _familyMembersCore.EmployerAddress = TxtEmployerAddress.Text;

            _familyMembersCore.Insurer = TxtInsurer.Text;
            _familyMembersCore.InsurancePolicyNumber = TxtInsurancePolicy.Text;
            _familyMembersCore.InsuranceExpiryDate = (TxtInsurancePolicyExpiryDate.Text);

            _familyMembersCore.StudyCenterName = TxtStudyCenter.Text;
            _familyMembersCore.NameOfCourse = TxtNameOfCourse.Text;
            _familyMembersCore.LevelOfStudy = TxtLevelOfStudy.Text;
            _familyMembersCore.StudyCenterPhone = TxtStudyCenterPhone.Text;
            _familyMembersCore.StudyCenterEmail = TxtStudyCenterEmail.Text;
            _familyMembersCore.StudyCenterAddress = TxtStudyCenterAddress.Text;

            _familyMembersCore.Occupation = Ddloccupation.Text;
            _familyMembersCore.Status = Ddlstatus.Text;

            


            //if (Ddloccupation.Text != "0")
            //{
            //    _familyMembersCore.Occupation = Ddloccupation.Text;
            //}
            //else
            //    _familyMembersCore.Occupation = null;

            if (Id > 0)
            {
                _familyMembersCore.ModifyBy = this.ReadSession().UserId.ToString();
                _familyMembersCore.EmployeeId = long.Parse(this.hdnempid.Value);
                this._familyMembersDao.Update(this._familyMembersCore);
            }
            else
            {

                //upload doc
                string type = "doc";
                string empid = GetFamilyMemberId().ToString();
                string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
                int pos = p_file.LastIndexOf(".");
                if (pos < 0)
                    type = "";
                else
                    type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

                if (type == "pdf" || type == "jpg" || type == "JPG" || type=="")
                {
                    
                }
                else
                {
                    LblMsg.Text = "Error:Unable to upload,Invalid file type!";
                    LblMsg.ForeColor = Color.Red;
                    return "1";
                }

                //switch (type)
                //{
                //    case "pdf":
                //        break;
                //    case "jpg":
                //        break;
                //    default:
                //        LblMsg.Text = "Error:Unable to upload,Invalid file type!";
                //        LblMsg.ForeColor = Color.Red;
                //        return "1";
                //}

                string docPath = ConfigurationSettings.AppSettings["root"];
                string info = UploadFile(TxtFileDescription.Text + "_" + GetTimestamp(DateTime.Now) + "." + type, empid, docPath);

                //uploaddoc

                _familyMembersCore.FamilyMembDoc = info;

                _familyMembersCore.CreatedBy = this.ReadSession().UserId.ToString();
                _familyMembersCore.EmployeeId = this.GetEmpId();
                this._familyMembersDao.Save(this._familyMembersCore);
            }
            this._familyMembersCore = _famCore;
            return "0";
        }

        public string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssfff");
        }

        public string UploadFile(String fileName, string rowid, string WorkFlowPath)
        {
            if (fileName == "")
            {
                return "error:Invalid filename supplied";
            }
            if (fileUpload.PostedFile.ContentLength == 0)
            {
                return "error:Invalid file content";
            }
            try
            {
                if (fileUpload.PostedFile.ContentLength <= 2048000)
                {
                    string saved_file_name = WorkFlowPath + "\\doc\\FamilyMember\\" + fileName;
                    fileUpload.PostedFile.SaveAs(saved_file_name);
                    return fileName;
                }
                else
                {
                    LblMsg.Text = "Error:Unable to upload,File size is too large!";
                    LblMsg.ForeColor = Color.Red;
                    return "error:Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
            }
        }


        private void ResetFamilyMembers()
        {
            if (GetDepartmentName() == "Human Resource Department")
            {
                BtnSave.Visible = true;
                BtnDelete.Visible = true;
                BtnBack.Visible = true;
            }
            else
            {
                BtnSave.Visible = false;
                BtnDelete.Visible = false;
                BtnBack.Visible = false;
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {               
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 11) == false && _roleMenuDao.hasAccess(ReadSession().AdminId, 12) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                //populateoccupation();
                PopulateDropdownList();
                if (this.GetFamilyMemberId() > 0)
                {
                    this.BtnDelete.Visible = true;
                    PopulateFamilyMembers();
                    //this.BtnSave.Visible = false;
                }
                else
                {
                    this.BtnDelete.Visible = false;
                    this.hdnempid.Value = GetEmpId().ToString();                   
                }
                this.emp = this.empdao.FindFullNameById(long.Parse(hdnempid.Value));
                detail.Visible = false;
            }
            TxtOfficePhone.Attributes.Add("onblur", "checknumber(this);");
            TxtMobileNumber.Attributes.Add("onblur", "checknumber(this);");
            TxtStudyCenterPhone.Attributes.Add("onblur", "checknumber(this);");
            TxtnationalityNumber.Attributes.Add("onblur", "checknumber(this);");
            ResetFamilyMembers();
        }
        private void PopulateDropdownList()
        {
            string selectValue = "";
            clsDAO swift = new clsDAO();
           
            if (DdlMaritalStatus.SelectedItem != null)
                selectValue = DdlMaritalStatus.SelectedItem.Value.ToString();            
            swift.setDDL(ref DdlMaritalStatus, "Exec ProcStaticDataView 's','11'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (DdlGender.SelectedItem != null)
                selectValue = DdlGender.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlGender, "Exec ProcStaticDataView 's','5'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (DdlBloodGroup.SelectedItem != null)
                selectValue = DdlBloodGroup.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlBloodGroup, "Exec ProcStaticDataView 's','6'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (DdlRelation.SelectedItem != null)
                selectValue = DdlRelation.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlRelation, "Exec ProcStaticDataView 's','27'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

            if (Ddloccupation.SelectedItem != null)
                selectValue = Ddloccupation.SelectedItem.Value.ToString();
            swift.setDDL(ref Ddloccupation, "select ROWID, DETAIL_TITLE from StaticDataDetail where TYPE_ID =56", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                string errorCode=ManageFamMem();
                if (errorCode == "1")
                {
                    return;
                }
                else
                {
                    Response.Redirect("ListFamilyMembers.aspx?Id=" + long.Parse(this.hdnempid.Value) + "");
                    
                }

                //string errorCode=ManageFamMem();
                //if (errorCode != "1")
                //{
                    
                //}
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (familyFileName.Value != "")
                {
                    string docPath = ConfigurationSettings.AppSettings["root"];
                    string familydoc = familyFileName.Value;
                    System.IO.File.Delete(docPath + "doc/FamilyMember/" + familydoc);
                }
                this._familyMembersDao.DeleteById(GetFamilyMemberId());
                Response.Redirect("ListFamilyMembers.aspx?Id=" + long.Parse(this.hdnempid.Value) + "");
            }
            catch
            {
                LblMsg.Text = "Error In Delete Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFamilyMembers.aspx?Id=" + long.Parse(this.hdnempid.Value) + "");
        }

        private string GetDepartmentName()
        {
            string department = ReadSession().Department;
            string id = _clsdao.GetSingleresult("select DEPARTMENT_NAME from departments with(nolock) where department_id=" + _clsdao.FilterString(department) + "");
            return id;
        }
    }
}