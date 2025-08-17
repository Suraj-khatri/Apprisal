using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using System.Configuration;
using SwiftHrManagement.DAL.Models;


namespace SwiftHrManagement.DAL.EmployeeDAO
{
    public class EmployeeDAO : BaseDAO
    {
        public StringBuilder insertQuery;
        public StringBuilder updateQuery;
        public EmployeeDAO()
        {

            this.insertQuery = new StringBuilder("EXEC ProcManageEmployeeDetails 'i',null,EMPCODE,SALUTATION_,FIRSTNAME,MIDDLENAME,LASTNAME,"
            + " GEN_DER,DATEOFBIRTH,MERITALSTATUS,BRANCHID,DEPTID,sub_dept1,sub_dept2,POSITIONNAME,BLOODGROUP,PANNUMBER,APPOINTMENTDATE,DATEOFJOINING,"
            + " EMPSTATUS,EMPTYPE,TEMPCOUNTRY,TEMPZONE,TEMPDISTRICT,TEMPMUNICIPALITYVDC,TEMPWARDNO,TEMPHOUSENO,TEMPSTREETNAME,"
            + " PERCOUNTRY,PERZONE,PERDISTRICT,PERMUNICIPALITYVDC,PERWARDNO,PERHOUSENO,PERSTREETNAME,TEL_OFFICE,TEL_RESIDENCE,"
            + " MOB_OFFICE,MOB_PERSONAL,FAX_OFFICE,FAX_PERSONAL,EMAIL_OFFICE,EMAIL_PERSONAL,EMNAME,EMADDRESS,EMRELATIONSHIP,"
            + " EMCONTACT1,EMCONTACT2,EMCONTACT3,EMEMAIL,FUNC_TITLE,CREATEDBY,PERMANENTDATE,Individual_Profile_update,C_START_DATE,"
            + " C_END_DATE,_CARDNUMBER,_GratuityEffDate,_SalaryTitle,grade");

            this.updateQuery = new StringBuilder("EXEC ProcManageEmployeeDetails 'u',EMPLOYEEID,EMPCODE,SALUTATION_,FIRSTNAME,MIDDLENAME,LASTNAME,"
            + " GEN_DER,DATEOFBIRTH,MERITALSTATUS,BRANCHID,DEPTID,sub_dept1,sub_dept2,POSITIONNAME,BLOODGROUP,PANNUMBER,APPOINTMENTDATE,DATEOFJOINING,"
            + " EMPSTATUS,EMPTYPE,TEMPCOUNTRY,TEMPZONE,TEMPDISTRICT,TEMPMUNICIPALITYVDC,TEMPWARDNO,TEMPHOUSENO,TEMPSTREETNAME,"
            + " PERCOUNTRY,PERZONE,PERDISTRICT,PERMUNICIPALITYVDC,PERWARDNO,PERHOUSENO,PERSTREETNAME,TEL_OFFICE,TEL_RESIDENCE,"
            + " MOB_OFFICE,MOB_PERSONAL,FAX_OFFICE,FAX_PERSONAL,EMAIL_OFFICE,EMAIL_PERSONAL,EMNAME,EMADDRESS,EMRELATIONSHIP,"
            + " EMCONTACT1,EMCONTACT2,EMCONTACT3,EMEMAIL,FUNC_TITLE,MODIFYBY,PERMANENTDATE,Individual_Profile_update,C_START_DATE,"
            + " C_END_DATE,_CARDNUMBER,_GratuityEffDate,_SalaryTitle,grade");
        }
        public override void Save(object obj)
        {
            Employee emp = (Employee)obj;
            BaseDomain baedomain = (BaseDomain)obj;
            this.insertQuery.Replace("EMPCODE", filterstring((emp.EmpCode)));
            this.insertQuery.Replace("SALUTATION_", filterstring(emp.Salute));
            this.insertQuery.Replace("FIRSTNAME", filterstring(emp.Fname));
            this.insertQuery.Replace("MIDDLENAME", filterstring(emp.Mname));
            this.insertQuery.Replace("LASTNAME", filterstring(emp.Lname));
            this.insertQuery.Replace("TEL_OFFICE", filterstring(emp.Phoneoffice));
            this.insertQuery.Replace("TEL_RESIDENCE", filterstring(emp.Phoneres));
            this.insertQuery.Replace("MOB_OFFICE", filterstring(emp.Moboffice));
            this.insertQuery.Replace("MOB_PERSONAL", filterstring(emp.Mobpersonal));
            this.insertQuery.Replace("FAX_OFFICE", filterstring(emp.Faxoffice));
            this.insertQuery.Replace("FAX_PERSONAL", filterstring(emp.Faxpersonal));
            this.insertQuery.Replace("EMAIL_OFFICE", filterstring(emp.Emailoffice));
            this.insertQuery.Replace("EMAIL_PERSONAL", filterstring(emp.Emailperonal));
            this.insertQuery.Replace("GEN_DER", filterstring(emp.Gender));
            this.insertQuery.Replace("DEPTID", filterstring(emp.Department_id.ToString()));
            this.insertQuery.Replace("BRANCHID", filterstring(emp.Branch_id.ToString()));
            this.insertQuery.Replace("POSITIONNAME", filterstring(emp.Position_id));
            this.insertQuery.Replace("BLOODGROUP", filterstring(emp.Bloodgoup));
            this.insertQuery.Replace("DATEOFBIRTH", filterstring(emp.Dateofbirth));
            this.insertQuery.Replace("DATEOFJOINING", filterstring(emp.Dateofjoining));
            this.insertQuery.Replace("MERITALSTATUS", filterstring(emp.Meritalstatus));
            this.insertQuery.Replace("PANNUMBER", filterstring(emp.Pannumber));
            this.insertQuery.Replace("TEMPSTREETNAME", filterstring(emp.Temp_streetname.ToString()));
            this.insertQuery.Replace("TEMPWARDNO", filterstring(emp.Temp_wardno.ToString()));
            this.insertQuery.Replace("TEMPHOUSENO", filterstring(emp.Temp_houseno.ToString()));
            this.insertQuery.Replace("TEMPMUNICIPALITYVDC", filterstring(emp.Temp_muni_vdc.ToString()));
            this.insertQuery.Replace("TEMPDISTRICT", filterstring(emp.Temp_district.ToString()));
            this.insertQuery.Replace("TEMPZONE", filterstring(emp.Temp_zone.ToString()));
            this.insertQuery.Replace("TEMPCOUNTRY", filterstring(emp.Temp_country.ToString()));
            this.insertQuery.Replace("PERSTREETNAME", filterstring(emp.Per_streetname.ToString()));
            this.insertQuery.Replace("PERWARDNO", filterstring(emp.Per_wardno.ToString()));
            this.insertQuery.Replace("PERHOUSENO", filterstring(emp.Per_houseno.ToString()));
            this.insertQuery.Replace("PERMUNICIPALITYVDC", filterstring(emp.Per_muni_vdc.ToString()));
            this.insertQuery.Replace("PERDISTRICT", filterstring(emp.Per_district.ToString()));
            this.insertQuery.Replace("PERZONE", filterstring(emp.Per_zone.ToString()));
            this.insertQuery.Replace("PERCOUNTRY", filterstring(emp.Per_country.ToString()));
            this.insertQuery.Replace("EMPSTATUS", filterstring(emp.EmpStatus.ToString()));
            this.insertQuery.Replace("EMPTYPE", filterstring(emp.EmpType.ToString()));
            this.insertQuery.Replace("APPOINTMENTDATE", filterstring(emp.AppointmentDate.ToString()));
            this.insertQuery.Replace("EMNAME", filterstring(emp.EmName.ToString()));
            this.insertQuery.Replace("EMADDRESS", filterstring(emp.EmAddress.ToString()));
            this.insertQuery.Replace("EMRELATIONSHIP", filterstring(emp.EmRelationship.ToString()));
            this.insertQuery.Replace("EMCONTACT1", filterstring(emp.EmFirstContact.ToString()));
            this.insertQuery.Replace("EMCONTACT2", filterstring(emp.EmSecondContact.ToString()));
            this.insertQuery.Replace("EMCONTACT3", filterstring(emp.EmThirdContact.ToString()));
            this.insertQuery.Replace("EMEMAIL", filterstring(emp.EmEmail.ToString()));
            this.insertQuery.Replace("CREATEDBY", filterstring(baedomain.CreatedBy.ToString()));
            this.insertQuery.Replace("FUNC_TITLE", filterstring(emp.FuncTitle.ToString()));
            this.insertQuery.Replace("PERMANENTDATE", filterstring(emp.PermanentDate.ToString()));
            this.insertQuery.Replace("Individual_Profile_update", filterstring(emp.IndividualProfileUpdate.ToString()));
            this.insertQuery.Replace("C_START_DATE", filterstring(emp.ContractFrom.ToString()));
            this.insertQuery.Replace("C_END_DATE", filterstring(emp.ContractTo.ToString()));
            this.insertQuery.Replace("_CARDNUMBER", filterstring(emp.CardNumber.ToString()));
            this.insertQuery.Replace("_GratuityEffDate", filterstring(emp.GratuityStartDate.ToString()));
            this.insertQuery.Replace("_SalaryTitle", filterstring(emp.SalaryTitle.ToString()));
            this.insertQuery.Replace("grade", filterstring(emp.GradeYear.ToString()));
            this.insertQuery.Replace("sub_dept1", filterstring(emp.SubDepartment_id.ToString()));
            this.insertQuery.Replace("sub_dept2", filterstring(emp.SubDepartment_id2.ToString()));

            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            try
            {
                Employee _emp = (Employee)obj;
                BaseDomain basedomain = (BaseDomain)obj;
                this.updateQuery.Replace("EMPLOYEEID", filterstring(_emp.Id.ToString()));
                this.updateQuery.Replace("ECODE", filterstring(_emp.EmpCode));
                this.updateQuery.Replace("EMPCODE", filterstring(_emp.EmpCode));
                this.updateQuery.Replace("SALUTATION_", filterstring(_emp.Salute));
                this.updateQuery.Replace("FIRSTNAME", filterstring(_emp.Fname));
                this.updateQuery.Replace("MIDDLENAME", filterstring(_emp.Mname));
                this.updateQuery.Replace("LASTNAME", filterstring(_emp.Lname));
                this.updateQuery.Replace("TEL_OFFICE", filterstring(_emp.Phoneoffice));
                this.updateQuery.Replace("TEL_RESIDENCE", filterstring(_emp.Phoneres));
                this.updateQuery.Replace("MOB_OFFICE", filterstring(_emp.Moboffice));
                this.updateQuery.Replace("MOB_PERSONAL", filterstring(_emp.Mobpersonal));
                this.updateQuery.Replace("FAX_OFFICE", filterstring(_emp.Faxoffice));
                this.updateQuery.Replace("FAX_PERSONAL", filterstring(_emp.Faxpersonal));
                this.updateQuery.Replace("EMAIL_OFFICE", filterstring(_emp.Emailoffice));
                this.updateQuery.Replace("EMAIL_PERSONAL", filterstring(_emp.Emailperonal));
                this.updateQuery.Replace("GEN_DER", filterstring(_emp.Gender));
                this.updateQuery.Replace("DEPTID", filterstring(_emp.Department_id.ToString()));
                this.updateQuery.Replace("BRANCHID", filterstring(_emp.Branch_id.ToString()));
                this.updateQuery.Replace("POSITIONNAME", filterstring(_emp.Position_id));
                this.updateQuery.Replace("BLOODGROUP", filterstring(_emp.Bloodgoup));
                this.updateQuery.Replace("DATEOFBIRTH", filterstring(_emp.Dateofbirth));
                this.updateQuery.Replace("DATEOFJOINING", filterstring(_emp.Dateofjoining));
                this.updateQuery.Replace("MERITALSTATUS", filterstring(_emp.Meritalstatus));
                this.updateQuery.Replace("PANNUMBER", filterstring(_emp.Pannumber));
                this.updateQuery.Replace("TEMPSTREETNAME", filterstring(_emp.Temp_streetname.ToString()));
                this.updateQuery.Replace("TEMPWARDNO", filterstring(_emp.Temp_wardno.ToString()));
                this.updateQuery.Replace("TEMPHOUSENO", filterstring(_emp.Temp_houseno.ToString()));
                this.updateQuery.Replace("TEMPMUNICIPALITYVDC", filterstring(_emp.Temp_muni_vdc.ToString()));
                this.updateQuery.Replace("TEMPDISTRICT", filterstring(_emp.Temp_district.ToString()));
                this.updateQuery.Replace("TEMPZONE", filterstring(_emp.Temp_zone.ToString()));
                this.updateQuery.Replace("TEMPCOUNTRY", filterstring(_emp.Temp_country.ToString()));
                this.updateQuery.Replace("PERSTREETNAME", filterstring(_emp.Per_streetname.ToString()));
                this.updateQuery.Replace("PERWARDNO", filterstring(_emp.Per_wardno.ToString()));
                this.updateQuery.Replace("PERHOUSENO", filterstring(_emp.Per_houseno.ToString()));
                this.updateQuery.Replace("PERMUNICIPALITYVDC", filterstring(_emp.Per_muni_vdc.ToString()));
                this.updateQuery.Replace("PERDISTRICT", filterstring(_emp.Per_district.ToString()));
                this.updateQuery.Replace("PERZONE", filterstring(_emp.Per_zone.ToString()));
                this.updateQuery.Replace("PERCOUNTRY", filterstring(_emp.Per_country.ToString()));
                this.updateQuery.Replace("EMPSTATUS", filterstring(_emp.EmpStatus.ToString()));
                this.updateQuery.Replace("EMPTYPE", filterstring(_emp.EmpType.ToString()));
                this.updateQuery.Replace("APPOINTMENTDATE", filterstring(_emp.AppointmentDate.ToString()));
                this.updateQuery.Replace("EMNAME", filterstring(_emp.EmName.ToString()));
                this.updateQuery.Replace("EMADDRESS", filterstring(_emp.EmAddress.ToString()));
                this.updateQuery.Replace("EMRELATIONSHIP", filterstring(_emp.EmRelationship.ToString()));
                this.updateQuery.Replace("EMCONTACT1", filterstring(_emp.EmFirstContact.ToString()));
                this.updateQuery.Replace("EMCONTACT2", filterstring(_emp.EmSecondContact.ToString()));
                this.updateQuery.Replace("EMCONTACT3", filterstring(_emp.EmThirdContact.ToString()));
                this.updateQuery.Replace("EMEMAIL", filterstring(_emp.EmEmail.ToString()));
                this.updateQuery.Replace("MODIFYBY", filterstring(basedomain.ModifyBy.ToString()));
                this.updateQuery.Replace("FUNC_TITLE", filterstring(_emp.FuncTitle.ToString()));
                this.updateQuery.Replace("PERMANENTDATE", filterstring(_emp.PermanentDate.ToString()));

                this.updateQuery.Replace("Individual_Profile_update", filterstring("y"));
                this.updateQuery.Replace("C_START_DATE", filterstring(_emp.ContractFrom.ToString()));
                this.updateQuery.Replace("C_END_DATE", filterstring(_emp.ContractTo.ToString()));

                this.updateQuery.Replace("_CARDNUMBER", filterstring(_emp.CardNumber.ToString()));

                this.updateQuery.Replace("_GratuityEffDate", filterstring(_emp.GratuityStartDate.ToString()));
                this.updateQuery.Replace("_SalaryTitle", filterstring(_emp.SalaryTitle.ToString()));
                this.updateQuery.Replace("grade", filterstring(_emp.GradeYear.ToString()));
                this.updateQuery.Replace("sub_dept1", filterstring(_emp.SubDepartment_id.ToString()));
                this.updateQuery.Replace("sub_dept2", filterstring(_emp.SubDepartment_id2.ToString()));

                ExecuteQuery(this.updateQuery.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean checkEmpCodeUnique(string empCode)
        {
            string sSql = "select EMPLOYEE_ID  from Employee where EMP_CODE=" + filterstring(empCode) + "";
            Boolean IfExists = this.CheckStatement(sSql);
            if (IfExists == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean checkEmpCodeUnique1(string empCode, long emp_id)
        {
            string sSql = "select EMPLOYEE_ID  from Employee where EMP_CODE=" + filterstring(empCode) + " and employee_id<>" + filterstring(emp_id.ToString()) + "";
            Boolean IfExists = this.CheckStatement(sSql);
            if (IfExists == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Employee FindForSessionById(String UserName, long Id)
        {
            string sSql = "select dbo.UserFullName('" + UserName + "') as FullName, e.BRANCH_ID, e.DEPARTMENT_ID from Employee as e where e.EMPLOYEE_ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            Employee employ = null;
            if (dt != null)
                employ = (Employee)this.MapForSessionId(dt.Rows[0]);
            return employ;
        }
        public Employee FindEmpCodeById(long Id)
        {
            string sSql = "select EMP_CODE from Employee where EMPLOYEE_ID =" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            Employee employ = null;
            if (dt != null)
                employ = (Employee)this.MapForEmpCode(dt.Rows[0]);
            return employ;
        }
        public object MapForEmpCode(DataRow dr)
        {
            Employee emp = new Employee();
            emp.EmpCode = dr["EMP_CODE"].ToString();
            return emp;
        }
        public object MapForSessionId(DataRow dr)
        {
            Employee emp = new Employee();
            emp.EmpName = dr["FullName"].ToString();
            emp.Branch_id = dr["BRANCH_ID"].ToString();
            emp.Department_id = dr["DEPARTMENT_ID"].ToString();
            return emp;
        }
        public List<Employee> FindFullName()
        {
            string sSql = "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee where EMPLOYEE_ID<>'1000'";
            DataTable dt = SelectByQuery(sSql);
            List<Employee> emp = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee _emp = (Employee)this.MapSelectedObject(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }
        public List<Employee> FindFullNameInGrid()
        {
            string sSql = "SELECT EMPLOYEE_ID,EMP_CODE,FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee";
            DataTable dt = SelectByQuery(sSql);
            List<Employee> emp = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee _emp = (Employee)this.MapSelectedObjectForGrid(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }
        public object MapSelectedObjectForGrid(DataRow dr)
        {
            Employee emp = new Employee();
            emp.Id = long.Parse(dr["EMPLOYEE_ID"].ToString());
            emp.EmpCode = dr["EMP_CODE"].ToString();
            emp.EmpName = dr["EmpName"].ToString();
            return emp;
        }
        public Employee FindFullNameById(long Id)
        {
            string sSql = "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee where EMPLOYEE_ID='" + Id + "'";
            DataTable dt = SelectByQuery(sSql);
            Employee employ = null;
            if (dt != null)
                employ = (Employee)this.MapSelectedObject(dt.Rows[0]);
            return employ;
        }
        public List<Employee> FindFullNameByIds(long brnachId, long deptId)
        {
            string sSql = "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE BRANCH_ID=" + brnachId + " AND DEPARTMENT_ID=" + deptId + "";
            DataTable dt = SelectByQuery(sSql);
            List<Employee> emp = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee _emp = (Employee)this.MapSelectedObject(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }
        public List<Employee> FindFullNameOfSuperVisor(int empId)
        {
            string sql = "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[super_name] from SuperVisroAssignment where  EMP = " + empId + " and SUPERVISOR_TYPE ='i' and record_status='y'";
            DataTable dt = SelectByQuery(sql);
            List<Employee> emp = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee _emp = (Employee)this.MapSelectedByObject(dr);
                    emp.Add(_emp);
                }

            }
            return emp;
        }
        public Employee MapSelectedByObject(DataRow dr)
        {
            Employee emp = new Employee();
            emp.Id = int.Parse(dr["SUPERVISOR"].ToString());
            emp.EmpName = dr["super_name"].ToString();

            return emp;
        }
        public object MapSelectedObject(DataRow dr)
        {
            Employee emp = new Employee();
            emp.Id = long.Parse(dr["EMPLOYEE_ID"].ToString());
            emp.EmpName = dr["EmpName"].ToString();
            return emp;
        }
        private string NullORValue(String value)
        {
            String res = value.Trim();

            if (res.Length == 0 || res == "0")
                res = "Null";
            else
                res = "'" + res + "'";

            return res;

        }
        public List<Employee> FindAllByFields(string empName, string branchName, string deptName, string countryName)
        {
            string sSql = "exec SearchEmployeeData @flag={flag},@full_name={full_name},@branch_name={branch_name},@dept_name={dept_name},@country={country}";

            sSql = sSql.Replace("{flag}", "'s'");
            sSql = sSql.Replace("{full_name}", NullORValue(empName));
            sSql = sSql.Replace("{branch_name}", NullORValue(branchName));
            sSql = sSql.Replace("{dept_name}", NullORValue(deptName));
            sSql = sSql.Replace("{country}", NullORValue(countryName));

            DataTable dt = SelectByQuery(sSql);
            List<Employee> employee = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee emp = (Employee)this.MapSelectedObjectForGrid(dr);
                    employee.Add(emp);
                }
            }
            return employee;
        }
        public List<Employee> FindAll(string fname, long deptid)
        {
            string sSql = "SELECT EMP_CODE,EMPLOYEE_ID,FIRST_NAME,MIDDLE_NAME,LAST_NAME,OFFICE_PHONE,"
                 + " HOME_PHONE,OFFICE_MOBILE,PERSONAL_MOBILE,OFFICE_FAX,PERSONAL_FAX,OFFICIAL_EMAIL,PERSONAL_EMAIL,"
                 + " GENDER,DEPARTMENT_ID,POSITION_ID,BLOOD_GROUP,"
                 + " BIRTH_DATE,JOINED_DATE,MERITAL_STATUS,"
                 + " PAN_NUMBER FROM Employee WHERE FIRST_NAME LIKE '" + fname + "'"
                 + " AND DEPARTMENT_ID =  " + deptid + "";

            DataTable dt = SelectByQuery(sSql);
            List<Employee> employee = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee emp = (Employee)this.MapObject(dr);
                    employee.Add(emp);
                }
            }
            return employee;
        }
        public Employee FindbyId(long Id)
        {
            string sSql = "EXEC ProcManageEmployeeDetails 's'," + filterstring(Id.ToString()) + "";
            DataTable dt = SelectByQuery(sSql);
            Employee employ = null;
            if (dt != null)
                employ = (Employee)this.MapObject(dt.Rows[0]);
            return employ;
        }
        public Employee FindOtherInfobyId(long Id)
        {
            string sSql = "SELECT EMPLOYEE_ID,AVAAILED_VEHICLE_FACILITY,AVAILED_HOUSE_RENT_FACILITY,IS_PENSION_HOLDER,IS_DISABLED,PENSION_AMOUNT,DISABLED_ID,MARITAL_STATUS,NATIONALITY,Rl_group FROM Employee WHERE EMPLOYEE_ID = " + Id + "";
            DataTable dt = SelectByQuery(sSql);
            Employee employ = null;
            if (dt != null)
                employ = (Employee)this.MapObjectForOtherInfo(dt.Rows[0]);
            return employ;
        }
        public List<Employee> FindOtherInfo(long Id)
        {
            string sSql = "SELECT EMPLOYEE_ID,case when AVAAILED_VEHICLE_FACILITY= 'Y' then 'Yes' ELSE 'No' end as AVAAILED_VEHICLE_FACILITY,"
            + " case when AVAILED_HOUSE_RENT_FACILITY= 'Y' then 'Yes' ELSE 'No' end as AVAILED_HOUSE_RENT_FACILITY,"
            + " case when IS_PENSION_HOLDER= 'Y' then 'Yes' ELSE 'No' end as IS_PENSION_HOLDER,"
            + " case when IS_DISABLED= 'Y' then 'Yes' ELSE 'No' end as IS_DISABLED,dbo.ShowDecimal(PENSION_AMOUNT) AS PENSION_AMOUNT,"
            + " ISNULL(DISABLED_ID,0) AS DISABLED_ID,case when ISNULL(MARITAL_STATUS,'')='M' THEN 'Married' when ISNULL(MARITAL_STATUS,'')='U' then"
            + " 'Unmarried' else '' end as MARITAL_STATUS,"
            + " case when NATIONALITY= 'Y' then 'Yes' WHEN NATIONALITY='N' THEN 'No' ELSE '' end as NATIONALITY FROM Employee "
            + " WHERE EMPLOYEE_ID = " + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<Employee> emp = new List<Employee>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Employee _emp = (Employee)this.MapObjectForOtherInfo(dr);
                    emp.Add(_emp);
                }
            }
            return emp;
        }

        public string insertBulkEmployee(List<EmployeeUpload> Record, string EmpId)
        {
            try
            {
                string BatchId = GetSingleresult("SELECT ISNULL(MAX(BatchId),1) from Employee_Upload");

                foreach (var item in Record)
                {
                    StringBuilder BulkInser = new StringBuilder(@"INSERT INTO[dbo].[Employee_Upload]
                                                               ([EMP_CODE]
                                                               ,[SALUTATION]
                                                               ,[FIRST_NAME]
                                                               ,[MIDDLE_NAME]
                                                               ,[LAST_NAME]
                                                               ,[GENDER]
                                                               ,[DATE_OF_BIRTH]
                                                               ,[MERITAL_STATUS]
                                                               ,[BRANCH_NAME]
                                                               ,[DEPARTMENT]
                                                               ,[POSITION]
                                                               ,[DATE_OF_APPIONTMENT]
                                                               ,[DATE_OF_JOINING]
                                                               ,[EMPLOYEE_STATUS]
                                                               ,[EMPLOYEE_TYPE]
                                                               ,[LASTTRANSFER]
                                                               ,[LASTPROMOTED]
                                                               ,[PhoneNumber]
                                                               ,[OFFICE_EMAIL]
                                                               ,[IsPosted]
                                                               ,[CreatedOn]
                                                               ,[CreatedBy]
                                                               ,[BatchId])
                                                         VALUES
                                                               (@EMP_CODE
                                                               , @SALUTATION
                                                               , @FIRST_NAME
                                                               , @MIDDLE_NAME
                                                               , @LAST_NAME
                                                               , @GENDER
                                                               , @DATE_OF_BIRTH
                                                               , @MERITAL_STATUS
                                                               , @BRANCH_NAME
                                                               , @DEPARTMENT
                                                               , @POSITION
                                                               , @DATE_OF_APPIONTMENT
                                                               , @DATE_OF_JOINING
                                                               , @EMPLOYEE_STATUS
                                                               , @EMPLOYEE_TYPE
                                                               , @LASTTRANSFER
                                                               , @LASTPROMOTED
                                                               , @PhoneNumber
                                                               , @OFFICE_EMAIL
                                                               , 0
                                                               , GETDATE()
                                                               , @CreatedBy
                                                               , @BatchId)");

                    BulkInser.Replace("@EMP_CODE", (filterstring((item.Emp_Code))));
                    BulkInser.Replace("@SALUTATION", filterstring(item.Salution));
                    BulkInser.Replace("@FIRST_NAME", filterstring(item.FirstName));
                    BulkInser.Replace("@MIDDLE_NAME", filterstring(item.MiddleName));
                    BulkInser.Replace("@LAST_NAME", filterstring(item.LastName));
                    BulkInser.Replace("@GENDER", filterstring(item.Gender));
                    BulkInser.Replace("@DATE_OF_BIRTH", filterstring(Convert.ToDateTime(item.DATE_OF_BIRTH).ToString("yyyy-MMM-dd")));
                    BulkInser.Replace("@MERITAL_STATUS", filterstring(item.MERITAL_STATUS));
                    BulkInser.Replace("@BRANCH_NAME", filterstring(item.BRANCH_NAME.ToString()));
                    BulkInser.Replace("@DEPARTMENT", filterstring(item.DEPARTMENT.ToString()));
                    BulkInser.Replace("@POSITION", filterstring(item.POSITION));
                    BulkInser.Replace("@DATE_OF_APPIONTMENT", filterstring(Convert.ToDateTime(item.DATE_OF_APPIONTMENT).ToString("yyyy-MMM-dd")));
                    BulkInser.Replace("@DATE_OF_JOINING", filterstring(Convert.ToDateTime(item.DATE_OF_JOINING).ToString("yyyy-MMM-dd")));
                    BulkInser.Replace("@EMPLOYEE_STATUS", filterstring(item.EMPLOYEE_STATUS));
                    BulkInser.Replace("@EMPLOYEE_TYPE", filterstring(item.EMPLOYEE_TYPE));
                    BulkInser.Replace("@LASTTRANSFER", filterstring(Convert.ToDateTime(item.LASTTRANSFER).ToString("yyyy-MMM-dd")));
                    BulkInser.Replace("@OFFICE_EMAIL", filterstring(item.OFFICE_EMAIL.ToString()));
                    BulkInser.Replace("@LASTPROMOTED", filterstring(Convert.ToDateTime(item.LASTPROMOTED).ToString("yyyy-MMM-dd")));
                    BulkInser.Replace("@PhoneNumber", filterstring(item.PhoneNumber.ToString()));
                    BulkInser.Replace("@CreatedBy", filterstring(EmpId.ToString()));
                    BulkInser.Replace("@BatchId", filterstring((Convert.ToInt32(BatchId) + 1).ToString()));

                    ExecuteQuery(BulkInser.ToString());
                }
            }
            catch (SqlException Ex)
            {

                throw Ex;
            }

            return "";
        }
        public string insertBulkTransfer(List<TransferUpload> Record, string EmpId)
        {
            try
            {
                string BatchId = GetSingleresult("SELECT ISNULL(MAX(BatchId),0) from Transfer_Upload");
                foreach (var item in Record)
                {
                    StringBuilder BulkInser = new StringBuilder(@"INSERT INTO [dbo].[Transfer_Upload]
                                                                   ([EMP_Code]
                                                                   ,[EFFECTIVE_DATE]
                                                                   ,[FROM_BRANCH]
                                                                   ,[TO_BRANCH]
                                                                   ,[FROM_DEPARTMENT]
                                                                   ,[TO_DEPARTMENT]
                                                                   ,[IsPosted]
                                                                   ,[Error]
                                                                   ,[CreatedOn]
                                                                   ,[CreatedBy]
                                                                   ,[BatchId])
                                                             VALUES
                                                                   (<EMP_Code>
                                                                   ,<EFFECTIVE_DATE>
                                                                   ,<FROM_BRANCH>
                                                                   ,<TO_BRANCH>
                                                                   ,<FROM_DEPARTMENT>
                                                                   ,<TO_DEPARTMENT>
                                                                   ,0
                                                                   ,null
                                                                   ,GETDATE()
                                                                   ,<CreatedBy>
                                                                   ,<BatchId>)");

                    BulkInser.Replace("<EMP_Code>", (filterstring((item.EMP_Code))));
                    BulkInser.Replace("<EFFECTIVE_DATE>", filterstring(item.EFFECTIVE_DATE));                 
                    BulkInser.Replace("<FROM_BRANCH>", filterstring(item.FROM_BRANCH));
                    BulkInser.Replace("<TO_BRANCH>", filterstring(item.TO_BRANCH));
                    BulkInser.Replace("<FROM_DEPARTMENT>", filterstring(item.FROM_DEPARTMENT));
                    BulkInser.Replace("<TO_DEPARTMENT>", filterstring(item.TO_DEPARTMENT));
                    BulkInser.Replace("<CreatedBy>", filterstring(EmpId.ToString()));
                    BulkInser.Replace("<BatchId>", filterstring((Convert.ToInt32(BatchId) + 1).ToString()));
                    ExecuteQuery(BulkInser.ToString());
                }
            }
            catch (SqlException Ex)
            {

                throw Ex;
            }

            return "";
        }
        public string insertBulkPromotion(List<PromotionUpload> Record, string EmpId)
        {
            try
            {
                string BatchId = GetSingleresult("SELECT ISNULL(MAX(BatchId),1) from Promotion_Upload");

                foreach (var item in Record)
                {
                    StringBuilder BulkInser = new StringBuilder(@"INSERT INTO [dbo].[Promotion_Upload]
                                                       ([Emp_code]
                                                       ,[New_Position]
                                                       ,[OLD_POSITION]
                                                       ,[PROMOTION_DATE]
                                                       ,[emp_type]
                                                       ,[IsPosted]
                                                       ,[Error]
                                                       ,[CreatedOn]
                                                       ,[CreatedBy]
                                                       ,[BatchId])
                                                 VALUES
                                                       (<Emp_code>
                                                       ,<New_Position>
                                                       ,<OLD_POSITION>
                                                       ,<PROMOTION_DATE>          
                                                       ,<emp_type>
                                                       ,0
                                                       ,NULL
                                                       ,GETDATE()
                                                       ,<CreatedBy>
                                                       ,<BatchId>)");

                    BulkInser.Replace("<Emp_code>", (filterstring((item.Emp_code))));
                    BulkInser.Replace("<New_Position>", filterstring(item.New_Position));
                    BulkInser.Replace("<OLD_POSITION>", filterstring(item.OLD_POSITION));                 
                    BulkInser.Replace("<PROMOTION_DATE>", filterstring(item.PROMOTION_DATE));
                    BulkInser.Replace("<emp_type>", filterstring(item.emp_type));
                    BulkInser.Replace("<CreatedBy>", filterstring(EmpId.ToString()));
                    BulkInser.Replace("<BatchId>", filterstring((Convert.ToInt32(BatchId) + 1).ToString()));

                    ExecuteQuery(BulkInser.ToString());
                }
            }
            catch (SqlException Ex)
            {

                throw Ex;
            }

            return "";
        }
        public object MapObjectForOtherInfo(DataRow dr)
        {
            Employee emp = new Employee();
            emp.Id = long.Parse(dr["EMPLOYEE_ID"].ToString());
            emp.IsVehicleFacility = dr["AVAAILED_VEHICLE_FACILITY"].ToString();
            emp.IsHouseFacility = dr["AVAILED_HOUSE_RENT_FACILITY"].ToString();
            emp.IsPensionHolder = dr["IS_PENSION_HOLDER"].ToString();
            emp.IsDisabled = dr["IS_DISABLED"].ToString();
            emp.PensionAmount = dr["PENSION_AMOUNT"].ToString();
            emp.DisabledId = dr["DISABLED_ID"].ToString();
            emp.Meritalstatus = dr["MARITAL_STATUS"].ToString();
            emp.Nationality = dr["NATIONALITY"].ToString();
            emp.RLGroup = dr["Rl_group"].ToString();
            return emp;
        }
        public override object MapObject(DataRow dr)
        {
            Employee emp = new Employee();

            emp.Id = long.Parse(dr["EMPLOYEE_ID"].ToString());
            emp.EmpCode = dr["EMP_CODE"].ToString();
            emp.Salute = dr["SALUTATION"].ToString();
            emp.Fname = dr["FIRST_NAME"].ToString();
            emp.Mname = dr["MIDDLE_NAME"].ToString();
            emp.Lname = dr["LAST_NAME"].ToString();
            emp.Phoneoffice = dr["OFFICE_PHONE"].ToString();
            emp.Phoneres = dr["HOME_PHONE"].ToString();
            emp.Moboffice = dr["OFFICE_MOBILE"].ToString();
            emp.Mobpersonal = dr["PERSONAL_MOBILE"].ToString();
            emp.Faxoffice = dr["OFFICE_FAX"].ToString();
            emp.Faxpersonal = dr["PERSONAL_FAX"].ToString();
            emp.Emailoffice = dr["OFFICIAL_EMAIL"].ToString();
            emp.Emailperonal = dr["PERSONAL_EMAIL"].ToString();
            emp.Gender = dr["GENDER"].ToString();
            emp.Department_id = dr["DEPARTMENT_ID"].ToString();
            emp.SubDepartment_id = dr["SUB_DEPARTMENT"].ToString();
            emp.SubDepartment_id2 = dr["SUB_DEPARTMENT2"].ToString();
            emp.Branch_id = dr["BRANCH_ID"].ToString();
            emp.Position_id = dr["POSITION_ID"].ToString();
            emp.Bloodgoup = dr["BLOOD_GROUP"].ToString();
            emp.Dateofbirth = dr["BIRTH_DATE"].ToString();
            emp.Dateofjoining = dr["JOINED_DATE"].ToString();
            emp.Meritalstatus = dr["MERITAL_STATUS"].ToString();
            emp.Pannumber = dr["PAN_NUMBER"].ToString();
            emp.Per_country = dr["PER_COUNTRY"].ToString();
            emp.Per_zone = dr["PER_ZONE"].ToString();
            emp.Per_district = dr["PER_DISTRICT"].ToString();
            emp.Per_muni_vdc = dr["PER_MUNICIPALITY_VDC"].ToString();
            emp.Per_houseno = dr["PER_HOUSE_NO"].ToString();
            emp.Per_wardno = dr["PER_WARD_NO"].ToString();
            emp.Per_streetname = dr["PER_STREET_NAME"].ToString();
            emp.Temp_country = dr["TEMP_COUNTRY"].ToString();
            emp.Temp_district = dr["TEMP_DISTRICT"].ToString();
            emp.Temp_zone = dr["TEMP_ZONE"].ToString();
            emp.Temp_streetname = dr["TEMP_STREET_NAME"].ToString();
            emp.Temp_wardno = dr["TEMP_WARD_NO"].ToString();
            emp.Temp_houseno = dr["TEMP_HOUSE_NO"].ToString();
            emp.Temp_muni_vdc = dr["TEMP_MUNICIPALITY_VDC"].ToString();
            emp.EmpStatus = dr["EMP_STATUS"].ToString();
            emp.EmpType = dr["EMP_TYPE"].ToString();
            emp.AppointmentDate = dr["APPOINTMENT_DATE"].ToString();
            emp.EmName = dr["EM_NAME"].ToString();
            emp.EmAddress = dr["EM_ADDRESS"].ToString();
            emp.EmFirstContact = dr["EM_CONTACTNO1"].ToString();
            emp.EmSecondContact = dr["EM_CONTACTNO2"].ToString();
            emp.EmThirdContact = dr["EM_CONTACTNO3"].ToString();
            emp.EmRelationship = dr["EM_RELATIONSHIP"].ToString();
            emp.EmEmail = dr["EM_EMAIL"].ToString();
            emp.FuncTitle = dr["FUNCTIONAL_TITLE"].ToString();
            emp.PermanentDate = dr["PERMANENT_DATE"].ToString();
            emp.IndividualProfileUpdate = dr["Individual_Profile_update"].ToString();
            //emp.ContractFrom = dr["C_START_DATE"].ToString();
            //emp.ContractTo = dr["C_END_DATE"].ToString();
            emp.CardNumber = dr["CARD_NUMBER"].ToString();
            emp.GratuityStartDate = dr["GRATUITY_EFFECTIVE_DATE"].ToString();
            emp.SalaryTitle = dr["Salary_Title"].ToString();
            emp.GradeYear = dr["grade"].ToString();
            emp.LastPromoted = dr["LASTPROMOTED"].ToString();
            emp.LastTransfer = dr["LastTransfer"].ToString();
            return emp;
        }
        public string UserLogin(string name, string password)
        {
            string result = "0";
            DataTable dt = this.ExecuteStoreProcedure("Exec procEmployeeLogin '" + name + "','" + password + "'");
            foreach (DataRow dr in dt.Rows)
                result = dr[0].ToString();
            return result;
        }
        public void DeleteById(long Id, String UserName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Employee' , ' and  EMPLOYEE_ID=''" + Id + "''', '" + UserName + "'");
        }
        public bool DoesHrUser(string empId)
        {
            if (empId == "1000")
            {
                return true;
            }
            else
            {
                var sql = "select 'X' from Employee where DEPARTMENT_ID =18 and EMPLOYEE_ID = " + empId + "";
                return CheckStatement(sql);
            }

        }
        public bool CheckHrAdmin(int empid)
        {
            if (empid == 1000)
            {
                return true;
            }
            else
            {
                string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connstring;
                con.Open();
                string sql = @"SELECT DISTINCT 'A' Mgs
   FROM   dbo.user_role r
          INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
          INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
   WHERE  s.TYPE_ID = '25'
 AND s.DETAIL_TITLE = 'HR Admin'
          AND a.Name = " + empid;
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
        public bool DoesAccessUpdateProfile(string empId)
        {
            var sql = "SELECT Individual_Profile_update FROM Employee  WHERE EMPLOYEE_ID =" + empId + "";
            string msg = GetSingleresult(sql);
            if (msg.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
