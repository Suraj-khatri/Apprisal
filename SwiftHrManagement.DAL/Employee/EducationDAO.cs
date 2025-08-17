using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EducationDAO;

namespace SwiftHrManagement.DAL.EducationDAO
{
    public class EducationDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public EducationDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Employee_Education(EMPLOYEE_ID,LEVELS,DEGREE,FECULTY,"
                                + " DIVISION,PERCENTAGE,PASSED_YEAR,NAMEOF_INSTITUTION,COUNTRY_NAME,CREATED_BY,CREATED_DATE) VALUES "
                                + " ('EMPLOYEEID','LE_VELS','DE_GREE','FE_CULTY','DIV_ISION','PER_CENTAGE',"
                                + "  'PASSEDYEAR','NAMEOFINSTITUTION','COUNTRYNAME','CREATEDBY','CREATEDDATE')");

            this.updateQuery = new StringBuilder("UPDATE Employee_Education SET LEVELS='LEV_ELS',DEGREE='DEGR_EE',FECULTY='FECU_LTY',"
                                + " DIVISION='DI_VISION',PERCENTAGE=PERCENTAG_E,PASSED_YEAR='PASS_EDYEAR',"
                                + " NAMEOF_INSTITUTION='NAME_OFINSTITUTION',COUNTRY_NAME='COUNTRYN_AME',MODIFIED_BY='MODIFIEDBY',"
                                + " MODIFIED_DATE='MODIFIEDDATE' WHERE EDUCATION_ID='EDUCATIONID'");
        }

        public override void Save(object obj)
        {
            EmployeeEducation empedu = (EmployeeEducation)obj;

            this.insertQuery.Replace("EMPLOYEEID",FilterQuote(empedu.EmpId.ToString()));
            this.insertQuery.Replace("LE_VELS",FilterQuote( empedu.Levels));
            this.insertQuery.Replace("DE_GREE", FilterQuote(empedu.Degree));
            this.insertQuery.Replace("FE_CULTY", FilterQuote(empedu.Fecaulty));
            this.insertQuery.Replace("DIV_ISION", FilterQuote(empedu.Division));
            this.insertQuery.Replace("PER_CENTAGE", FilterQuote(empedu.Percentage));
            this.insertQuery.Replace("PASSEDYEAR", FilterQuote(empedu.Passedyear));
            this.insertQuery.Replace("NAMEOFINSTITUTION", FilterQuote(empedu.Nameofintitution));
            this.insertQuery.Replace("COUNTRYNAME", FilterQuote(empedu.Countyname));
            this.insertQuery.Replace("CREATEDBY", FilterQuote(empedu.CreatedBy.ToString()));
            this.insertQuery.Replace("CREATEDDATE", FilterQuote(empedu.CreatedDate.ToString()));
            ExecuteQuery(this.insertQuery.ToString());       
        }

        public override void Update(object obj)
        {
            EmployeeEducation emped = (EmployeeEducation)obj;
            this.updateQuery.Replace("EDUCATIONID", FilterQuote(emped.Educationid.ToString()));
            this.updateQuery.Replace("LEV_ELS", FilterQuote(emped.Levels));
            this.updateQuery.Replace("DEGR_EE", FilterQuote(emped.Degree));
            this.updateQuery.Replace("FECU_LTY", FilterQuote(emped.Fecaulty));
            this.updateQuery.Replace("DI_VISION", FilterQuote(emped.Division));
            this.updateQuery.Replace("PERCENTAG_E", FilterQuote(emped.Percentage));
            this.updateQuery.Replace("PASS_EDYEAR", FilterQuote(emped.Passedyear));
            this.updateQuery.Replace("NAME_OFINSTITUTION", FilterQuote(emped.Nameofintitution));
            this.updateQuery.Replace("COUNTRYN_AME", FilterQuote(emped.Countyname));
            this.updateQuery.Replace("MODIFIEDBY", FilterQuote(emped.ModifyBy.ToString()));
            this.updateQuery.Replace("MODIFIEDDATE", FilterQuote(emped.ModifyDate.ToString()));
            ExecuteQuery(this.updateQuery.ToString());
            //throw new NotImplementedException();
        }
        public List<EmployeeEducation> Findall(long Id)
        {
            string sSql = "SELECT EDUCATION_ID,EMPLOYEE_ID,LEVELS,DEGREE,S.DETAIL_TITLE AS FECULTY,DIVISION,PERCENTAGE,PASSED_YEAR,NAMEOF_INSTITUTION,"
                            + " COUNTRY_NAME FROM Employee_Education E INNER JOIN StaticDataDetail S ON S.ROWID=E.FECULTY WHERE EMPLOYEE_ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            List<EmployeeEducation> emp = new List<EmployeeEducation>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    EmployeeEducation _emp = (EmployeeEducation)this.MapObject(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }
        public EmployeeEducation FindbyId(long Id)
        {
            string sSql = "SELECT EDUCATION_ID,EMPLOYEE_ID,LEVELS,DEGREE,FECULTY AS FECULTYID,S.DETAIL_TITLE AS FECULTY,DIVISION,PERCENTAGE,PASSED_YEAR,NAMEOF_INSTITUTION,"
                            + " COUNTRY_NAME FROM Employee_Education E INNER JOIN StaticDataDetail S ON S.ROWID=E.FECULTY WHERE EDUCATION_ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            EmployeeEducation _empedu = null;
            if (dt != null)
                _empedu = (EmployeeEducation)this.MapObject(dt.Rows[0]);
            return _empedu;
        }

        public override object MapObject(DataRow dr)
        {
            EmployeeEducation empedu = new EmployeeEducation();

            empedu.Educationid = long.Parse(dr["EDUCATION_ID"].ToString());
            empedu.EmpId = dr["EMPLOYEE_ID"].ToString();
            empedu.Levels = dr["LEVELS"].ToString();
            empedu.Degree = dr["DEGREE"].ToString();
            empedu.FacultyID = long.Parse(dr["FECULTYID"].ToString());
            empedu.Fecaulty = dr["FECULTY"].ToString();
            empedu.Division = dr["DIVISION"].ToString();
            empedu.Percentage = dr["PERCENTAGE"].ToString();
            empedu.Passedyear = dr["PASSED_YEAR"].ToString();
            empedu.Nameofintitution = dr["NAMEOF_INSTITUTION"].ToString();
            empedu.Countyname = dr["COUNTRY_NAME"].ToString();
            return empedu;
            //throw new NotImplementedException();
        }
        public void DeleteById(long Id, String UserName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Employee_Education' , ' and  EDUCATION_ID=''" + Id + "''', '" + UserName + "'");         
        }
    }
}
