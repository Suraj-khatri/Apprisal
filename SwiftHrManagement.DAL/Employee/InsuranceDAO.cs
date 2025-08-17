using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.InsuranceDAO;

namespace SwiftHrManagement.DAL.InsuranceDAO
{
    public class InsuranceDAO : BaseDAO
    {
        private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public InsuranceDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO INSURANCE (EMPLOYEE_ID, INSURER, INSURED_AMOUNT, INSURED_DATE, EXPIRY_DATE, PREMIUM_PAYER, INSURANCE_POLICY,"
            + " ANNUAL_PREMIUM_AMT,FREQUENCY,SALARY_DEDUCTION,Insurance_For,created_by,created_date)"
            + " VALUES ('EMPLOYEEID','INSURER_','INSUREDAMOUNT','INSUREDDATE','EXPIRYDATE','PREMIUMPAYER','INSURANCEPOLICY',ANNUAL_PREMIUM_AMT_value,Pay_Frequency,"
            + " Salary_Deduction_value,'InsuranceFor','CREATEDBY','CREATEDDATE')SELECT SCOPE_IDENTITY();");
            this.updateQuery = new StringBuilder("UPDATE INSURANCE SET INSURER='INSURER_',INSURED_AMOUNT='INSUREDAMOUNT',INSURED_DATE='INSUREDDATE',Insurance_For='InsuranceFor' "
                + " ,EXPIRY_DATE='EXPIRYDATE', PREMIUM_PAYER='PREMIUMPAYER', INSURANCE_POLICY='INSURANCEPOLICY',ANNUAL_PREMIUM_AMT=ANNUAL_PREMIUM_AMT_value,"
                + " FREQUENCY=Pay_Frequency,SALARY_DEDUCTION=Salary_Deduction_value WHERE ID= ID_");
            this.selectQuery = new StringBuilder("");
        }

        public override void Save(object obj)
        {
            InsueanceCore _insurence = (InsueanceCore)obj;
            this.insertQuery.Replace("EMPLOYEEID", _insurence.Employee_Id.ToString());
            this.insertQuery.Replace("INSURER_", _insurence.Insurer.ToString());
            this.insertQuery.Replace("INSUREDAMOUNT", _insurence.Insured_Amount.ToString());
            this.insertQuery.Replace("INSUREDDATE", _insurence.Insured_Date.ToString());
            this.insertQuery.Replace("EXPIRYDATE", _insurence.Expiry_Date.ToString());            
            this.insertQuery.Replace("PREMIUMPAYER", _insurence.PremiumPayer.ToString());
            this.insertQuery.Replace("INSURANCEPOLICY", _insurence.InsurancePolicy.ToString());
            this.insertQuery.Replace("ANNUAL_PREMIUM_AMT_value", filterstring(_insurence.AnnualPremiumAmt.ToString()));
            this.insertQuery.Replace("Pay_Frequency", filterstring(_insurence.Pay_Frequency.ToString()));
            this.insertQuery.Replace("Salary_Deduction_value", filterstring(_insurence.Salary_Deduction.ToString()));
            this.insertQuery.Replace("InsuranceFor", _insurence.Insurance_For.ToString());
            this.insertQuery.Replace("CREATEDBY", _insurence.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", _insurence.CreatedDate.ToString());

           int AutoId =  ExecuteQuery(this.insertQuery.ToString(),'y');
           _insurence.Id = AutoId;
        }
        public override void Update(object obj)
        {
            InsueanceCore _insurence = (InsueanceCore)obj;
            this.updateQuery.Replace("ID_", _insurence.Id .ToString());
            this.updateQuery.Replace("EMPLOYEEID", _insurence.Employee_Id.ToString());
            this.updateQuery.Replace("INSURER_", _insurence.Insurer.ToString());
            this.updateQuery.Replace("INSUREDAMOUNT", _insurence.Insured_Amount.ToString());
            this.updateQuery.Replace("INSUREDDATE", _insurence.Insured_Date.ToString());
            this.updateQuery.Replace("EXPIRYDATE", _insurence.Expiry_Date.ToString());            
            this.updateQuery.Replace("PREMIUMPAYER", _insurence.PremiumPayer.ToString());
            this.updateQuery.Replace("INSURANCEPOLICY", _insurence.InsurancePolicy.ToString());
            this.updateQuery.Replace("ANNUAL_PREMIUM_AMT_value", filterstring(_insurence.AnnualPremiumAmt.ToString()));
            this.updateQuery.Replace("Pay_Frequency", filterstring(_insurence.Pay_Frequency.ToString()));
            this.updateQuery.Replace("Salary_Deduction_value", filterstring(_insurence.Salary_Deduction.ToString()));
            this.updateQuery.Replace("InsuranceFor", _insurence.Insurance_For.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<InsueanceCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  I.ID, I.EMPLOYEE_ID,I.INSURED_AMOUNT, CONVERT(VARCHAR,I.INSURED_DATE,107) AS INSURED_DATE, CONVERT(VARCHAR,I.[EXPIRY_DATE],107) AS [EXPIRY_DATE], s.DETAIL_TITLE as 'INSURER',"
            + " I.PREMIUM_PAYER, I.INSURANCE_POLICY, E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPLOYEE_NAME, I.Insurance_For "
            + " FROM  Insurance AS I INNER JOIN Employee AS E ON I.EMPLOYEE_ID = E.EMPLOYEE_ID inner join (select * from StaticDataDetail "
            + "where TYPE_ID=33) s on s.ROWID=I.INSURER WHERE I.EMPLOYEE_ID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            List<InsueanceCore> _insurance = new List<InsueanceCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                   InsueanceCore _ins = (InsueanceCore)this.MapObject(dr);
                   _insurance.Add(_ins);
                }
            }
            return _insurance;
        }
        public InsueanceCore FindById(long Id)
        {
            string sSql = ("SELECT  ID, EMPLOYEE_ID, INSURER,INSURED_AMOUNT,convert(varchar,INSURED_DATE,101) as INSURED_DATE,"
            + " CONVERT(varchar,EXPIRY_DATE,101) as EXPIRY_DATE,PREMIUM_PAYER, INSURANCE_POLICY,ANNUAL_PREMIUM_AMT,FREQUENCY,SALARY_DEDUCTION,Insurance_For from Insurance WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            InsueanceCore _ins = null;
            if (dt != null)
                _ins = (InsueanceCore)this.MapObjectForInsurance(dt.Rows[0]);
            return _ins;
        }
        //public InsueanceCore GetInsuredAmount(string Id)
        //{
        //    string sSql = ("SELECT ID,INSURED_AMOUNT from Insurance WHERE ID=" + Id + "").ToString();
        //    DataTable dt = SelectByQuery(sSql);
        //    InsueanceCore _ins = null;
        //    if (dt != null)
        //        _ins = (InsueanceCore)this.GetInsuredAmount(dt.Rows[0]);
        //    return _ins;
        //}
        //public object GetInsuredAmount(System.Data.DataRow dr)
        //{
        //    InsueanceCore _insurance = new InsueanceCore();
        //    _insurance.Insurance_Id = long.Parse(dr["ID"].ToString());
        //    _insurance.Insured_Amount = double.Parse(dr["INSURED_AMOUNT"].ToString());
        //    return _insurance;
        //}
        public object MapObjectForInsurance(System.Data.DataRow dr)
        {
            InsueanceCore _insurance = new InsueanceCore();
            _insurance.Insurance_Id = long.Parse(dr["ID"].ToString());
            _insurance.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _insurance.Insured_Amount = double.Parse(dr["INSURED_AMOUNT"].ToString());
            _insurance.Insured_Date = dr["INSURED_DATE"].ToString();
            _insurance.Expiry_Date = dr["EXPIRY_DATE"].ToString();
            _insurance.Insurer = dr["INSURER"].ToString();
            _insurance.PremiumPayer = dr["PREMIUM_PAYER"].ToString();
            _insurance.InsurancePolicy = dr["INSURANCE_POLICY"].ToString();
            _insurance.AnnualPremiumAmt = dr["ANNUAL_PREMIUM_AMT"].ToString();
            _insurance.Pay_Frequency = dr["FREQUENCY"].ToString();
            _insurance.Salary_Deduction = dr["SALARY_DEDUCTION"].ToString();
            _insurance.Insurance_For = dr["Insurance_For"].ToString();

            return _insurance;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            InsueanceCore _insurance = new InsueanceCore();
            _insurance.Insurance_Id = long.Parse(dr["ID"].ToString());
            _insurance.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _insurance.Emp_Name = dr["EMPLOYEE_NAME"].ToString();
            _insurance.Insured_Amount = double.Parse(dr["INSURED_AMOUNT"].ToString());
            _insurance.Insured_Date = dr["INSURED_DATE"].ToString();
            _insurance.Expiry_Date = dr["EXPIRY_DATE"].ToString();
            _insurance.Insurer = dr["INSURER"].ToString();
            _insurance.PremiumPayer = dr["PREMIUM_PAYER"].ToString();
            _insurance.InsurancePolicy = dr["INSURANCE_POLICY"].ToString();
            _insurance.AnnualPremiumAmt = dr["ANNUAL_PREMIUM_AMT"].ToString();
            _insurance.Pay_Frequency = dr["FREQUENCY"].ToString();
            _insurance.Salary_Deduction = dr["SALARY_DEDUCTION"].ToString();
            _insurance.Insurance_For = dr["Insurance_For"].ToString();

            return _insurance;
        }
        public Boolean ifexists(long id)
        {
            return (CheckStatement("SELECT * FROM InsurancePremium WHERE INSURANCE_ID = "+id+""));
        }
        public void DeleteInsurance(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Insurance' , ' and ID=''"+ id +"''', '"+ user +"'");
        }
        public string CRUDLog(string Id)
        {

            return GetCurrentRecordInformation("INSURANCE", "ID", Id);
        }
    }
}
