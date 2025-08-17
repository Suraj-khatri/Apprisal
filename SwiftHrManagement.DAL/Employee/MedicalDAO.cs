using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.MedicalDAO;

namespace SwiftHrManagement.DAL.MedicalDAO
{
    public class MedicalDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public MedicalDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Employee_Medical(EMPLOYEE_ID,PROBLEM,DIAGNOSIS,DOCTOR,HOSPITAL,"
                                      + " CHACHED_DATE,DESEASE,CREATED_BY,CREATED_DATE) VALUES ('EMPLOYEEID','PROB_LEM','DIA_GNOSIS','DO_CTOR',"
                                      + " 'HOSP_ITAL','CHACHEDDATE','DESEASE_','CREATEDBY','CREATEDDATE')");
            
            this.updateQuery = new StringBuilder("UPDATE Employee_Medical SET PROBLEM='P_ROBLEM',DIAGNOSIS='D_IAGNOSIS',"
                                      + " DOCTOR='D_OCTOR',HOSPITAL='H_OSPITAL',CHACHED_DATE='C_HACHEDDATE',DESEASE='D_ESEASE',"
                                      + " MODIFIED_BY = 'MODIFIEDBY',MODIFIED_DATE='MODIFIEDDATE' WHERE MEDICAL_ID = 'MEDICALID'");
        }   

        public override void Save(object obj)
        {
            EmployeeMedical empmed = (EmployeeMedical)obj;
            this.insertQuery.Replace("EMPLOYEEID", empmed.Id.ToString());
            this.insertQuery.Replace("PROB_LEM",empmed.Problem);
            this.insertQuery.Replace("DIA_GNOSIS",empmed.Diagnosis);
            this.insertQuery.Replace("DO_CTOR",empmed.Doctor);
            this.insertQuery.Replace("HOSP_ITAL",empmed.Hospital);
            this.insertQuery.Replace("CHACHEDDATE",empmed.Checheddate);
            this.insertQuery.Replace("DESEASE_", empmed.Desease);
            this.insertQuery.Replace("CREATEDBY",empmed.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", empmed.CreatedDate.ToString());

            ExecuteQuery(this.insertQuery.ToString());
            //throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            EmployeeMedical empmd = (EmployeeMedical)obj;
            this.updateQuery.Replace("MEDICALID", empmd.Medicalid.ToString());
            this.updateQuery.Replace("P_ROBLEM",empmd.Problem);
            this.updateQuery.Replace("D_IAGNOSIS",empmd.Diagnosis);
            this.updateQuery.Replace("D_OCTOR",empmd.Doctor);
            this.updateQuery.Replace("H_OSPITAL",empmd.Hospital);
            this.updateQuery.Replace("C_HACHEDDATE",empmd.Checheddate);
            this.updateQuery.Replace("D_ESEASE",empmd.Desease);
            this.updateQuery.Replace("MODIFIEDBY", empmd.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", empmd.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
            //throw new NotImplementedException();
        }

        public EmployeeMedical FindbyId(long Id)
        {
            string sSql = "SELECT MEDICAL_ID,EMPLOYEE_ID,PROBLEM,DIAGNOSIS,DOCTOR,HOSPITAL,CHACHED_DATE,DESEASE FROM Employee_Medical "
            + " WHERE MEDICAL_ID = " + Id + "";
            DataTable dt = SelectByQuery(sSql);
            EmployeeMedical _medic = null;
            if (dt != null)
                _medic = (EmployeeMedical)this.MapObject(dt.Rows[0]);
            return _medic;
        }

        public List<EmployeeMedical> Findall(long Id)
        {
            string sSql = "SELECT MEDICAL_ID,EMPLOYEE_ID,PROBLEM,DIAGNOSIS,DOCTOR,HOSPITAL,CHACHED_DATE,DESEASE FROM Employee_Medical WHERE EMPLOYEE_ID="+Id+"";
            DataTable dt = SelectByQuery(sSql);
            List<EmployeeMedical> med = new List<EmployeeMedical>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EmployeeMedical _med = (EmployeeMedical)this.MapObject(dr);
                    med.Add(_med);
                }
            }
            return med;
        }

        public override object MapObject(DataRow dr)
        {
            EmployeeMedical empmedical = new EmployeeMedical();   

            empmedical.Medicalid = long.Parse(dr["MEDICAL_ID"].ToString());
            empmedical.Id = long.Parse(dr["EMPLOYEE_ID"].ToString());
            empmedical.Problem = dr["PROBLEM"].ToString();
            empmedical.Diagnosis= dr["DIAGNOSIS"].ToString();
            empmedical.Doctor = dr["DOCTOR"].ToString();
            empmedical.Hospital = dr["HOSPITAL"].ToString();
            empmedical.Checheddate = dr["CHACHED_DATE"].ToString();
            empmedical.Desease = dr["DESEASE"].ToString();
            return empmedical;
            //throw new NotImplementedException();
        }
        public void DeleteById(long Id)
        {
            String sSql = "";
            sSql = "DELETE FROM Employee_Medical WHERE MEDICAL_ID = " + Id + "";
            this.ExecuteQuery(sSql);
        }
    }
}
