using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.RptDao
{
    public class DynamicRpt:BaseDAO
    {
        public DynamicRpt()
        {

        }
        public DataSet FindReportDtl(String param)
        {

            String sSql = "";
            if (param == "Branches")
            {
                sSql = ("select BRANCH_NAME, BRANCH_ADDRESS, BRANCH_PHONE, BRANCH_MOBILE, BRANCH_EMAIL, BRANCH_COUNTRY, BRANCH_ZONE, "
                + " BRANCH_DISTRICT, CONTACT_PERSON from Branches ");
            }
            else if (param == "Company")
            {
                sSql = ("SELECT COMP_NAME, COMP_ADDRESS, COMP_ADDRESS2, COMP_CONTACT_PERSON, COMP_MAP_CODE, "
                        + " COMP_PHONE_NO, COMP_SHORT_NAME, case when COMP_STATUS = 'True' then 'Active'  when "
                        + " COMP_STATUS = 'False' then 'In Active'  end 'COMP_STATUS', COMP_URL FROM Company");
            }
            else if (param == "Departments")
            {
                sSql = ("select BRANCH_ID , DEPARTMENT_SHORT_NAME , DEPARTMENT_NAME from Departments");
            }
            else if (param == "Employee")
            {
                sSql = ("SELECT  EMP_CODE,'' EMPLOYEE_NAME,GENDER,"
                            + " MARITAL_STATUS,BIRTH_DATE,APPOINTMENT_DATE,"
                            + " BRANCH_ID BRANCH_NAME,DEPARTMENT_ID DEPARTMENT_NAME,"
                            + " POSITION_ID DESIGNATION,EMP_TYPE,EMP_STATUS, "
                            + " HOME_PHONE,OFFICE_MOBILE, PERSONAL_MOBILE, OFFICIAL_EMAIL  FROM Employee");
            }
            else if (param == "Insurance")
            {
                sSql = ("SELECT EMPLOYEE_ID EMPLOYEE_NAME,INSURER,INSURED_AMOUNT,INSURED_DATE,EXPIRY_DATE,PREMIUM_PAYER,INSURANCE_POLICY,"
                + " SUM(ip.PAYMENT_AMOUNT) AS PAYMENT_AMOUNT FROM Insurance i LEFT JOIN InsurancePremium ip ON ip.INSURANCE_ID=i.ID"
                + " GROUP BY EMPLOYEE_ID,INSURER,INSURED_AMOUNT,INSURED_DATE,EXPIRY_DATE,PREMIUM_PAYER,INSURANCE_POLICY");
            }
            return ReturnDataset(sSql);

        }
        public DataSet FindsummaryReport(String Flag, String branch_Id, String department_Id, String Empid)
        {
            String sSql = "EXEC proc_rptSummery '" + Flag + "'," + FilterQuote(branch_Id) + "," + FilterQuote(department_Id) + "," + FilterQuote(Empid) + "";
            return ReturnDataset(sSql);
        }
        public DataTable runSql(string sql)
        {
            return ExecuteStoreProcedure(sql);
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }
    }
}
