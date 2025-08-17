using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.LoanDAO;

namespace SwiftHrManagement.DAL.LoanDAO
{
    public class LoanDAO : BaseDAO
    {
        private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public LoanDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Loan(EMPLOYEE_ID, LOAN_TYPE, DATE_TAKEN, LOAN_AMOUNT, INTEREST_RATE, INSTALLMENT_AMT,NO_OF_INSTALLMENTS,REMAINING_INSTALLMENT,"
                + " REPAYMENT_FREQUENCY ,INSTALLMENT_START_DATE,LEDGER_CODE,NEXT_RUN_MONTH,NARATION,APPLIED_DT,APPLIED_AMOUNT,INT_FIGURE_TYPE,CREATED_BY,CREATED_DATE,remaining_amt,interest_paid)"
                + " VALUES ('_EMPLOYEE_ID','_LOAN_TYPE','_DATE_TAKEN','_LOAN_AMOUNT','_INTEREST_RATE','_INSTALLMENT_AMT', '_NO_OF_INSTALLMENTS','_REMAINING_INSTALLMENT','_REPAYMENT_FREQUENCY',"
                + " '_INSTALLMENT_START_DATE','_LEDGER_CODE','_NEXT_RUN_MONTH','_NARATION','_APPLIEDDATE','_APPLIEDAMT','_INTERESTTYPE','_CREATEDBY','_CREATEDDATE','_LOAN_AMOUNT','0') SELECT SCOPE_IDENTITY();");

            this.updateQuery = new StringBuilder("UPDATE Loan SET DATE_TAKEN='_DATE_TAKEN', INSTALLMENT_START_DATE='_INSTALLMENT_START_DATE',LOAN_AMOUNT='_LOAN_AMOUNT',"
            + " REMAINING_INSTALLMENT='_REMAINING_INSTALLMENT', LOAN_TYPE='_LOAN_TYPE', NO_OF_INSTALLMENTS='_NO_OF_INSTALLMENTS',INTEREST_RATE='_INTEREST_RATE',"
            + " REPAYMENT_FREQUENCY='_REPAYMENT_FREQUENCY',NARATION='_NARATION', LEDGER_CODE='_LEDGER_CODE',NEXT_RUN_MONTH='_NEXT_RUN_MONTH',APPLIED_DT='_APPLIEDDATE',"
            + " APPLIED_AMOUNT='_APPLIEDAMT',INT_FIGURE_TYPE='_INTERESTTYPE',MODIFIED_BY='_MODIFIEDBY',MODIFIED_DATE='_MODIFIEDDATE' FROM  Loan WHERE ID='ID_'");

            this.selectQuery = new StringBuilder("");
        }

        public override void Save(object obj) 
        {
            LoanCore _loan = (LoanCore)obj;
            this.insertQuery.Replace("_EMPLOYEE_ID", _loan.Employee_Id.ToString());
            this.insertQuery.Replace("_LOAN_TYPE", _loan.LoanType.ToString());
            this.insertQuery.Replace("_DATE_TAKEN", _loan.DateTaken.ToString());
            this.insertQuery.Replace("_LOAN_AMOUNT", _loan.LoanAmount.ToString());
            this.insertQuery.Replace("_INTEREST_RATE", _loan.InterestRate.ToString());
            this.insertQuery.Replace("_INSTALLMENT_AMT", _loan.InstallmentAmount.ToString());
            this.insertQuery.Replace("_NO_OF_INSTALLMENTS", _loan.NoOfInstallment.ToString());
            this.insertQuery.Replace("_REMAINING_INSTALLMENT", _loan.RemainingInstallment.ToString());
            this.insertQuery.Replace("_REPAYMENT_FREQUENCY", _loan.RepaymentFrequency.ToString());
            this.insertQuery.Replace("_INSTALLMENT_START_DATE", _loan.InstallmentStartDate.ToString());
            this.insertQuery.Replace("_LEDGER_CODE", _loan.LedgerCode.ToString());
            this.insertQuery.Replace("_NEXT_RUN_MONTH", _loan.NextRunMonth.ToString());
            this.insertQuery.Replace("_NARATION", _loan.Naration.ToString());
            this.insertQuery.Replace("_APPLIEDDATE", _loan.AppliedDate.ToString());
            this.insertQuery.Replace("_APPLIEDAMT", _loan.AppliedAmt.ToString());
            this.insertQuery.Replace("_INTERESTTYPE", _loan.InterestType.ToString());
            this.insertQuery.Replace("_CREATEDBY", _loan.CreatedBy.ToString());
            this.insertQuery.Replace("_CREATEDDATE", _loan.CreatedDate.ToString());
            int RowId = ExecuteQuery(this.insertQuery.ToString(),'y');
            _loan.Id = RowId;
        }
        public override void Update(object obj)
        {
            LoanCore _loan = (LoanCore)obj;            
            this.updateQuery.Replace("ID_", _loan.Id.ToString());
            this.updateQuery.Replace("_EMPLOYEE_ID", _loan.Employee_Id.ToString());
            this.updateQuery.Replace("_LOAN_TYPE", _loan.LoanType.ToString());
            this.updateQuery.Replace("_DATE_TAKEN", _loan.DateTaken.ToString());
            this.updateQuery.Replace("_LOAN_AMOUNT", _loan.LoanAmount.ToString());
            this.updateQuery.Replace("_INTEREST_RATE", _loan.InterestRate.ToString());
            this.updateQuery.Replace("_INSTALLMENT_AMT", _loan.InstallmentAmount.ToString());
            this.updateQuery.Replace("_NO_OF_INSTALLMENTS", _loan.NoOfInstallment.ToString());
            this.updateQuery.Replace("_REMAINING_INSTALLMENT", _loan.RemainingInstallment.ToString());
            this.updateQuery.Replace("_REPAYMENT_FREQUENCY", _loan.RepaymentFrequency.ToString());
            this.updateQuery.Replace("_INSTALLMENT_START_DATE", _loan.InstallmentStartDate.ToString());
            this.updateQuery.Replace("_LEDGER_CODE", _loan.LedgerCode.ToString());
            this.updateQuery.Replace("_NEXT_RUN_MONTH", _loan.NextRunMonth.ToString());
            this.updateQuery.Replace("_NARATION", _loan.Naration.ToString());
            this.updateQuery.Replace("_APPLIEDDATE", _loan.AppliedDate.ToString());
            this.updateQuery.Replace("_APPLIEDAMT", _loan.AppliedAmt.ToString());
            this.updateQuery.Replace("_INTERESTTYPE", _loan.InterestType.ToString());
            this.updateQuery.Replace("_MODIFIEDBY", _loan.ModifyBy.ToString());
            this.updateQuery.Replace("_MODIFIEDDATE", _loan.ModifyDate.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }
        public LoanCore checkDataInCalender(string installmentDate)
        {
            string sSql = ("exec procGetNepaliMonth " + filterstring(installmentDate) + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            LoanCore _ln = null;
            if (dt != null)
                _ln = (LoanCore)this.MapObjectForCalenderData(dt.Rows[0]);
            return _ln;
        }
        public object MapObjectForCalenderData(System.Data.DataRow dr)
        {
            LoanCore _loan = new LoanCore();
            _loan.NextRunMonth = dr["DT"].ToString();
            return _loan;
        }
        public List<LoanCore> FindAllByEmpId(long Id)
        {

            String sSql = "SELECT  L.ID, L.EMPLOYEE_ID,CONVERT(VARCHAR,L.DATE_TAKEN,107) AS DATE_TAKEN,CONVERT(VARCHAR,L.INSTALLMENT_START_DATE,107) AS INSTALLMENT_START_DATE,"
    + " dbo.showdecimal(L.LOAN_AMOUNT) as LOAN_AMOUNT, L.REMAINING_INSTALLMENT, S.DETAIL_TITLE AS LOAN_TYPE, L.NO_OF_INSTALLMENTS,L.INTEREST_RATE,REPAYMENT_FREQUENCY,"
    + " dbo.showdecimal(L.INSTALLMENT_AMT) as INSTALLMENT_AMT, L.LEDGER_CODE,L.NARATION,L.NEXT_RUN_MONTH,CONVERT(VARCHAR,L.APPLIED_DT,107) AS APPLIED_DT"
    + " L.APPLIED_AMOUNT,INT_FIGURE_TYPE FROM  Loan AS L "
    +" inner join (select * from StaticDataDetail where TYPE_ID=46) s on s.ROWID= L.LOAN_TYPE WHERE L.EMPLOYEE_ID="+Id+"";

            DataTable dt = SelectByQuery(sSql);
            List<LoanCore> _loan = new List<LoanCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LoanCore _ln = (LoanCore)this.MapObject(dr);
                    _loan.Add(_ln);
                }
            }
            return _loan;
        }
        public LoanCore FindById(long Id)
        {
            string sSql = ("SELECT  ID, EMPLOYEE_ID,CONVERT(VARCHAR,DATE_TAKEN,101) AS DATE_TAKEN,CONVERT(VARCHAR,INSTALLMENT_START_DATE,101) AS INSTALLMENT_START_DATE,"
                          + " LOAN_AMOUNT, REMAINING_INSTALLMENT, LOAN_TYPE, NO_OF_INSTALLMENTS,INTEREST_RATE,REPAYMENT_FREQUENCY,INSTALLMENT_AMT,LEDGER_CODE,NARATION,"
                + " NEXT_RUN_MONTH,INSTALLMENT_AMT,CONVERT(VARCHAR,APPLIED_DT,101) AS APPLIED_DT,APPLIED_AMOUNT,INT_FIGURE_TYPE FROM  Loan WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            LoanCore _ln = null;
            if (dt != null)
                _ln = (LoanCore)this.MapObject(dt.Rows[0]);
            return _ln;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            LoanCore _loan = new LoanCore();
            _loan.Id = long.Parse(dr["ID"].ToString());
            _loan.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _loan.DateTaken = dr["DATE_TAKEN"].ToString();
            _loan.LoanAmount = double.Parse(dr["LOAN_AMOUNT"].ToString());
            _loan.LoanType = dr["LOAN_TYPE"].ToString();
            _loan.NoOfInstallment = int.Parse(dr["NO_OF_INSTALLMENTS"].ToString());
            _loan.InterestRate = double.Parse(dr["INTEREST_RATE"].ToString());
            _loan.RepaymentFrequency = dr["REPAYMENT_FREQUENCY"].ToString();
            _loan.RemainingInstallment = dr["REMAINING_INSTALLMENT"].ToString();
            _loan.LedgerCode = dr["LEDGER_CODE"].ToString();
            _loan.InstallmentStartDate = dr["INSTALLMENT_START_DATE"].ToString();
            _loan.NextRunMonth = dr["NEXT_RUN_MONTH"].ToString();
            _loan.Naration = dr["NARATION"].ToString();
            _loan.InstallmentAmount = double.Parse(dr["INSTALLMENT_AMT"].ToString());
            _loan.AppliedDate = dr["APPLIED_DT"].ToString();
            _loan.AppliedAmt = double.Parse(dr["APPLIED_AMOUNT"].ToString());
            _loan.InterestType = dr["INT_FIGURE_TYPE"].ToString();

            return _loan;
        }
        public void Deleteloan(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from LOAN' , ' and  id=''" + id + "''', '" + user + "'");
        }
        public string CRUDLog(string Id)
        {
            return GetCurrentRecordInformation("Loan", "ID", Id);
        }
        public string CRUDLog(string Id,char returnType)
        {
            return GetCurrentRecordInformation("loan_collection", "id", Id);
        }
    }
}