using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FamilyMembersDAO;

namespace SwiftHrManagement.DAL.FamilyMembersDAO
{
    public class FamilyMembersDAO : BaseDAO
    {
        // private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public FamilyMembersDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO FamilyMembers (EMPLOYEE_ID, FIRST_NAME, MIDDLE_NAME, LAST_NAME, "
            + " RELATION, MARITAL_STATUS,GENDER,DATE_OF_BIRTH,MOBILE_NUMBER,NATIONALITY, NATIONALITY_NUMBER,ISSUE_DATE,PASSPORT_NUMBER, "
            + " EMPLOYER, EMPLOYER_ADDRESS, DESIGNATION, OFFICE_PHONE, OFFICE_EMAIL, INSURER, INSURANCE_POLICY_NUMBER, BLOOD_GROUP, "
            + "CURRENT_ADDRESS, INSURANCE_EXPIRY_DATE, STUDY_CENTER_NAME, LEVEL_OF_STUDY, NAME_OF_COURSE, STUDY_CENTER_PHONE, "
            + "STUDY_CENTER_EMAIL, STUDY_CENTER_ADDRESS,CREATED_BY,CREATED_DATE, OCCUPATION, STATUS,FAMILYDOC)"
            + " VALUES (_EMPLOYEE_ID, _FIRST_NAME, _MIDDLE_NAME, _LAST_NAME, "
            + "_RELATION, _MARITALSTATUS, _GENDER, _DATE_OF_BIRTH, _MOBILE_NUMBER, _NATIONALITY, _NATIONALITY_NUMBER,_ISSUE_DATE, _PASSPORT_NUMBER, "
            + "_EMPLOYER, _EMPRADDRESS, _DESIGNATION, _OFFICE_PHONE, _OFFICE_EMAIL, _INSURER, _INSURANCE_POLICY_NUMBER, _BLOOD_GROUP, "
            + "_CURRENT_ADDRESS,  _INSURANCE_EXPIRY_DATE, _STUDY_CENTER_NAME, _LEVEL_OF_STUDY, _NAME_OF_COURSE, _STUDY_CENTER_PHONE, "
            + "_STUDY_CENTER_EMAIL, _STUDY_CENTER_ADDRESS,_CREATEDBY,GETDATE(),_OCCUPATION,_STATUS_,_FAMILYDOC)");

            this.updateQuery = new StringBuilder("UPDATE FamilyMembers SET "

            + " RELATION=_RELATION, "
            + " MARITAL_STATUS=_MARITALSTATUS, "
            + " GENDER=_GENDER, "

            + " FIRST_NAME=_FIRST_NAME, "
            + " MIDDLE_NAME=_MIDDLE_NAME, "
            + " LAST_NAME=_LAST_NAME, "
            + " BLOOD_GROUP=_BLOOD_GROUP, "
            + " CURRENT_ADDRESS=_CURRENT_ADDRESS, "
            
            + " DATE_OF_BIRTH=_DATE_OF_BIRTH, "
            + " MOBILE_NUMBER=_MOBILE_NUMBER, "
            + " NATIONALITY=_NATIONALITY, "
            + " NATIONALITY_NUMBER=_NATIONALITY_NUMBER, "
            + " ISSUE_DATE=_ISSUE_DATE, "
            + " PASSPORT_NUMBER=_PASSPORT_NUMBER, "
            
            + " EMPLOYER=_EMPLOYER, "
            + " EMPLOYER_ADDRESS=_EMPRADDRESS, "
            + " DESIGNATION=_DESIGNATION, "
            + " OFFICE_PHONE=_OFFICE_PHONE, "
            + " OFFICE_EMAIL=_OFFICE_EMAIL, "
            
            + " INSURER=_INSURER, "
            + " INSURANCE_POLICY_NUMBER=_INSURANCE_POLICY_NUMBER, "
            + " INSURANCE_EXPIRY_DATE=_INSURANCE_EXPIRY_DATE, " 
            + " STUDY_CENTER_NAME=_STUDY_CENTER_NAME, "
            + " LEVEL_OF_STUDY=_LEVEL_OF_STUDY, "
            + " NAME_OF_COURSE=_NAME_OF_COURSE, "
            + " STUDY_CENTER_PHONE=_STUDY_CENTER_PHONE, "
            + " STUDY_CENTER_EMAIL=_STUDY_CENTER_EMAIL, "
            + " STUDY_CENTER_ADDRESS=_STUDY_CENTER_ADDRESS, "
            + " MODIFIED_BY=_MODIFIEDBY, "
            + " MODIFIED_DATE=GETDATE() ,"
            + " OCCUPATION = _OCCUPATION, "
            + " STATUS = _STATUS_ "

            + " WHERE ID= ID_");

            //  this.selectQuery = new StringBuilder("");
        }

        public override void Save(object obj)
        {
            FamilyMembersCore _familyMembers = (FamilyMembersCore)obj;

            this.insertQuery.Replace("_EMPLOYEE_ID", filterstring(_familyMembers.EmployeeId.ToString()) );
            this.insertQuery.Replace("_FIRST_NAME", filterstring(_familyMembers.FirstName.ToString()));
            this.insertQuery.Replace("_MIDDLE_NAME", filterstring(_familyMembers.MiddleName.ToString()));
            this.insertQuery.Replace("_LAST_NAME", filterstring(_familyMembers.LastName.ToString()));
            this.insertQuery.Replace("_RELATION", filterstring(_familyMembers.Relation.ToString()));
            this.insertQuery.Replace("_MARITALSTATUS", filterstring(_familyMembers.MaritalStatus.ToString()));
            this.insertQuery.Replace("_GENDER", filterstring(_familyMembers.Gender.ToString()));
            this.insertQuery.Replace("_BLOOD_GROUP", filterstring(_familyMembers.BloodGroup.ToString()));
            this.insertQuery.Replace("_DATE_OF_BIRTH", filterstring(_familyMembers.DateOfBirth.ToString()));
            //contact info
            this.insertQuery.Replace("_CURRENT_ADDRESS", filterstring(_familyMembers.CurrentAddress.ToString()));
            this.insertQuery.Replace("_MOBILE_NUMBER", filterstring(_familyMembers.MobileNumber.ToString()));
            this.insertQuery.Replace("_NATIONALITY_NUMBER", filterstring(_familyMembers.NationalityNumber.ToString()));
            this.insertQuery.Replace("_ISSUE_DATE", filterstring(_familyMembers.IssueDate.ToString()));
            this.insertQuery.Replace("_PASSPORT_NUMBER", filterstring(_familyMembers.PassportNumber.ToString()));
            this.insertQuery.Replace("_NATIONALITY", filterstring(_familyMembers.Nationality.ToString()));
            this.insertQuery.Replace("_EMPLOYER", filterstring(_familyMembers.Employer.ToString()));
            this.insertQuery.Replace("_EMPRADDRESS", filterstring(_familyMembers.EmployerAddress.ToString()));
            this.insertQuery.Replace("_DESIGNATION", filterstring(_familyMembers.Designation.ToString()));
            this.insertQuery.Replace("_OFFICE_PHONE", filterstring(_familyMembers.OfficePhone.ToString()));
            this.insertQuery.Replace("_OFFICE_EMAIL", filterstring(_familyMembers.OfficeEmail.ToString()));
            // insurance info
            this.insertQuery.Replace("_INSURER", filterstring(_familyMembers.Insurer.ToString()));
            this.insertQuery.Replace("_INSURANCE_POLICY_NUMBER", filterstring(_familyMembers.InsurancePolicyNumber.ToString()));
            this.insertQuery.Replace("_INSURANCE_EXPIRY_DATE", filterstring(_familyMembers.InsuranceExpiryDate.ToString()));
                       
            //study info
            this.insertQuery.Replace("_STUDY_CENTER_NAME",filterstring(_familyMembers.StudyCenterName.ToString()));
            this.insertQuery.Replace("_LEVEL_OF_STUDY", filterstring(_familyMembers.LevelOfStudy.ToString()));
            this.insertQuery.Replace("_NAME_OF_COURSE", filterstring(_familyMembers.NameOfCourse.ToString()));
            this.insertQuery.Replace("_STUDY_CENTER_PHONE", filterstring(_familyMembers.StudyCenterPhone.ToString()));
            this.insertQuery.Replace("_STUDY_CENTER_EMAIL", filterstring(_familyMembers.StudyCenterEmail.ToString()));
            this.insertQuery.Replace("_STUDY_CENTER_ADDRESS", filterstring(_familyMembers.StudyCenterAddress.ToString()));
            this.insertQuery.Replace("_CREATEDBY", filterstring(_familyMembers.CreatedBy.ToString()));
            this.insertQuery.Replace("_OCCUPATION", filterstring(_familyMembers.Occupation.ToString()));
            this.insertQuery.Replace("_STATUS_", filterstring(_familyMembers.Status.ToString()));
            this.insertQuery.Replace("_FAMILYDOC", filterstring(_familyMembers.FamilyMembDoc.ToString())); 

            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            FamilyMembersCore _familyMembers = (FamilyMembersCore)obj;

            this.updateQuery.Replace("ID_", _familyMembers.Id.ToString());

            this.updateQuery.Replace("_EMPLOYEE_ID", filterstring(_familyMembers.EmployeeId.ToString()));
            this.updateQuery.Replace("_FIRST_NAME", filterstring(_familyMembers.FirstName.ToString()));
            this.updateQuery.Replace("_MIDDLE_NAME", filterstring(_familyMembers.MiddleName.ToString()));
            this.updateQuery.Replace("_LAST_NAME", filterstring(_familyMembers.LastName.ToString()));
            this.updateQuery.Replace("_RELATION", filterstring(_familyMembers.Relation.ToString()));
            this.updateQuery.Replace("_MARITALSTATUS", filterstring(_familyMembers.MaritalStatus.ToString()));
            this.updateQuery.Replace("_GENDER", filterstring(_familyMembers.Gender.ToString()));
            this.updateQuery.Replace("_DATE_OF_BIRTH",filterstring( _familyMembers.DateOfBirth.ToString()));
            this.updateQuery.Replace("_BLOOD_GROUP", filterstring(_familyMembers.BloodGroup.ToString()));
            
            //contact info
            this.updateQuery.Replace("_CURRENT_ADDRESS",filterstring( _familyMembers.CurrentAddress.ToString()));
            this.updateQuery.Replace("_MOBILE_NUMBER", filterstring(_familyMembers.MobileNumber.ToString()));
            this.updateQuery.Replace("_NATIONALITY_NUMBER", filterstring(_familyMembers.NationalityNumber.ToString()));
            this.updateQuery.Replace("_ISSUE_DATE", filterstring(_familyMembers.IssueDate.ToString()));
            this.updateQuery.Replace("_PASSPORT_NUMBER",filterstring( _familyMembers.PassportNumber.ToString()));
            this.updateQuery.Replace("_NATIONALITY", filterstring(_familyMembers.Nationality.ToString()));
            this.updateQuery.Replace("_EMPLOYER", filterstring(_familyMembers.Employer.ToString()));
            this.updateQuery.Replace("_EMPRADDRESS", filterstring(_familyMembers.EmployerAddress.ToString()));
            this.updateQuery.Replace("_DESIGNATION",filterstring( _familyMembers.Designation.ToString()));
            this.updateQuery.Replace("_OFFICE_PHONE",filterstring( _familyMembers.OfficePhone.ToString()));
            this.updateQuery.Replace("_OFFICE_EMAIL",filterstring( _familyMembers.OfficeEmail.ToString()));
            
            //insurance info
            this.updateQuery.Replace("_INSURER",filterstring( _familyMembers.Insurer.ToString()));
            this.updateQuery.Replace("_INSURANCE_POLICY_NUMBER",filterstring( _familyMembers.InsurancePolicyNumber.ToString()));
            this.updateQuery.Replace("_INSURANCE_EXPIRY_DATE",filterstring( _familyMembers.InsuranceExpiryDate.ToString()));
            
            //study info
            this.updateQuery.Replace("_STUDY_CENTER_NAME", filterstring(_familyMembers.StudyCenterName.ToString()));
            this.updateQuery.Replace("_LEVEL_OF_STUDY",filterstring( _familyMembers.LevelOfStudy.ToString()));
            this.updateQuery.Replace("_NAME_OF_COURSE",filterstring( _familyMembers.NameOfCourse.ToString()));
            this.updateQuery.Replace("_STUDY_CENTER_PHONE",filterstring( _familyMembers.StudyCenterPhone.ToString()));
            this.updateQuery.Replace("_STUDY_CENTER_EMAIL", filterstring(_familyMembers.StudyCenterEmail.ToString()));
            this.updateQuery.Replace("_STUDY_CENTER_ADDRESS", filterstring(_familyMembers.StudyCenterAddress.ToString()));
            this.updateQuery.Replace("_MODIFIEDBY",filterstring( _familyMembers.ModifyBy.ToString()));
            this.updateQuery.Replace("_OCCUPATION", filterstring(_familyMembers.Occupation.ToString()));
            this.updateQuery.Replace("_STATUS_", filterstring(_familyMembers.Status.ToString()));

            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<FamilyMembersCore> FindAllByEmpId(long Id)
        {
            string sSql = ("SELECT  FM.ID, FM.FIRST_NAME, FM.MIDDLE_NAME, FM.LAST_NAME ,FM.EMPLOYEE_ID, S.DETAIL_TITLE AS RELATION,S3.DETAIL_TITLE AS MARITAL_STATUS,"
            + " S1.DETAIL_TITLE AS GENDER, FM.DATE_OF_BIRTH, FM.MOBILE_NUMBER, FM.NATIONALITY_NUMBER,FM.ISSUE_DATE,FM.PASSPORT_NUMBER,FM.NATIONALITY,FM.EMPLOYER,"
            +" FM.EMPLOYER_ADDRESS,FM.DESIGNATION,FM.OFFICE_PHONE,FM.OFFICE_EMAIL,FM.INSURER,FM.INSURANCE_POLICY_NUMBER, S2.DETAIL_TITLE AS BLOOD_GROUP,"
            +" FM.INSURANCE_EXPIRY_DATE,FM.STUDY_CENTER_NAME,FM.LEVEL_OF_STUDY,FM.NAME_OF_COURSE,FM.STUDY_CENTER_PHONE,FM.STUDY_CENTER_EMAIL,"
            + " FM.STUDY_CENTER_ADDRESS,FM.CURRENT_ADDRESS, occ.rowid 'DETAIL_TITLE', FM.STATUS FROM  FamilyMembers AS FM INNER JOIN Employee AS E ON FM.EMPLOYEE_ID = E.EMPLOYEE_ID " 
            +" INNER JOIN StaticDataDetail S ON S.ROWID=FM.RELATION INNER JOIN StaticDataDetail S1 ON S1.ROWID=FM.GENDER "
            +" INNER JOIN StaticDataDetail S2 ON S2.ROWID=FM.BLOOD_GROUP INNER JOIN StaticDataDetail S3 ON S3.ROWID=FM.MARITAL_STATUS"
            +" INNER JOIN StaticDataDetail occ ON occ.ROWID=FM.occupation"
            +" WHERE FM.EMPLOYEE_ID="+ Id+"").ToString();
            DataTable dt = SelectByQuery(sSql);
            List<FamilyMembersCore> _fmembers = new List<FamilyMembersCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FamilyMembersCore _fm = (FamilyMembersCore)this.MapObject(dr);
                    _fmembers.Add(_fm);
                }
            }
            return _fmembers;
        }
        public FamilyMembersCore FindById(long Id)
        {
            string sSql = ("SELECT  FM.ID, FM.FIRST_NAME, FM.MIDDLE_NAME, FM.LAST_NAME ,FM.EMPLOYEE_ID, FM.RELATION,FM.MARITAL_STATUS,"
           + " FM.GENDER,convert(varchar,FM.DATE_OF_BIRTH,101) as DATE_OF_BIRTH,FM.MOBILE_NUMBER, FM.NATIONALITY_NUMBER,convert(varchar,FM.ISSUE_DATE,101) as ISSUE_DATE ,FM.PASSPORT_NUMBER,FM.NATIONALITY,FM.EMPLOYER,"
           + " FM.EMPLOYER_ADDRESS,FM.DESIGNATION,FM.OFFICE_PHONE,FM.OFFICE_EMAIL,FM.INSURER,FM.INSURANCE_POLICY_NUMBER,FM.BLOOD_GROUP,"
           + " convert(varchar,FM.INSURANCE_EXPIRY_DATE,101) as INSURANCE_EXPIRY_DATE,FM.STUDY_CENTER_NAME,FM.LEVEL_OF_STUDY,FM.NAME_OF_COURSE,FM.STUDY_CENTER_PHONE,FM.STUDY_CENTER_EMAIL,"
           + " FM.STUDY_CENTER_ADDRESS,FM.CURRENT_ADDRESS, occ.rowid 'OCCUPATION', FM.STATUS, FM.FAMILYDOC FROM  FamilyMembers AS FM INNER JOIN Employee AS E ON FM.EMPLOYEE_ID = E.EMPLOYEE_ID "
           + " Left JOIN StaticDataDetail occ ON occ.ROWID=FM.occupation"
           + " WHERE FM.ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            FamilyMembersCore _fm = null;
            if (dt != null)
                _fm = (FamilyMembersCore)this.MapObject(dt.Rows[0]);
            return _fm;
        }


        public override object MapObject(System.Data.DataRow dr)
        {
            FamilyMembersCore _fmembers = new FamilyMembersCore();

            _fmembers.Id = long.Parse(dr["ID"].ToString());
            _fmembers.EmployeeId = long.Parse(dr["EMPLOYEE_ID"].ToString());
            _fmembers.FirstName = dr["FIRST_NAME"].ToString();
            _fmembers.MiddleName = dr["MIDDLE_NAME"].ToString();
            _fmembers.LastName = dr["LAST_NAME"].ToString();
            _fmembers.Relation = dr["RELATION"].ToString();
            _fmembers.MaritalStatus = dr["MARITAL_STATUS"].ToString();
            _fmembers.Gender = dr["GENDER"].ToString();
            _fmembers.DateOfBirth = dr["DATE_OF_BIRTH"].ToString();
            _fmembers.MobileNumber = dr["MOBILE_NUMBER"].ToString();
            _fmembers.CurrentAddress = dr["CURRENT_ADDRESS"].ToString();
            _fmembers.BloodGroup = dr["BLOOD_GROUP"].ToString();
            _fmembers.NationalityNumber = dr["NATIONALITY_NUMBER"].ToString();
            _fmembers.IssueDate = dr["ISSUE_DATE"].ToString();
            _fmembers.PassportNumber = dr["PASSPORT_NUMBER"].ToString();
            _fmembers.Nationality = dr["NATIONALITY"].ToString();
            _fmembers.Employer = dr["EMPLOYER"].ToString();
            _fmembers.EmployerAddress = dr["EMPLOYER_ADDRESS"].ToString();
            _fmembers.Designation = dr["DESIGNATION"].ToString();
            _fmembers.OfficePhone = dr["OFFICE_PHONE"].ToString();
            _fmembers.OfficeEmail = dr["OFFICE_EMAIL"].ToString();
            _fmembers.Insurer = dr["INSURER"].ToString();
            _fmembers.InsurancePolicyNumber = dr["INSURANCE_POLICY_NUMBER"].ToString();
            _fmembers.InsuranceExpiryDate = dr["INSURANCE_EXPIRY_DATE"].ToString();
            _fmembers.StudyCenterName = dr["STUDY_CENTER_NAME"].ToString();
            _fmembers.LevelOfStudy = dr["LEVEL_OF_STUDY"].ToString();
            _fmembers.NameOfCourse = dr["NAME_OF_COURSE"].ToString();
            _fmembers.StudyCenterPhone = dr["STUDY_CENTER_PHONE"].ToString();
            _fmembers.StudyCenterEmail = dr["STUDY_CENTER_EMAIL"].ToString();
            _fmembers.StudyCenterAddress = dr["STUDY_CENTER_ADDRESS"].ToString();
            _fmembers.Status = dr["STATUS"].ToString();
            _fmembers.Occupation = dr["OCCUPATION"].ToString();
            _fmembers.FamilyMembDoc = dr["FAMILYDOC"].ToString();
            
            return _fmembers;
        }
        public void DeleteById(long Id)
        {
            String sSql = "";
            sSql = "DELETE FROM FamilyMembers WHERE ID = " + Id + "";
            this.ExecuteQuery(sSql);
        }
    }
}
