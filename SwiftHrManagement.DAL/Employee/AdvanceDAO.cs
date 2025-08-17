using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.AdvanceDAO;

namespace SwiftHrManagement.DAL.AdvanceDAO
{
    public class AdvanceDAO : BaseDAO
    {
        private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public AdvanceDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO ADVANCE(EMPLOYEE_ID, AMOUNT, DATE_TAKEN,ADVANCE_TYPE, DEDUCTION_AMT,IS_FULLYPAID,DEDUCTION_START_DATE,REMAINING_BAL,NARRATION,DEDUCTION_FREQUENCY,NEXT_RUN_MONTH,LEDGER_CODE,CREATED_BY,CREATED_DATE)"
            + " VALUES ('_EMPLOYEE_ID','_AMOUNT','_DATE_TAKEN','ADVANCETYPE','DEDUCTIONAMT','ISFULLYPAID','DEDUCTIONSTARTDATE','_REMAININGBAL','_NARRATION','_DEDUCTION_FREQUENCY','_NEXTRUNMONTH','_LEDGERCODE','_CREATEDBY','_CREATEDDATE') SELECT SCOPE_IDENTITY();");
            
            this.updateQuery = new StringBuilder("UPDATE ADVANCE SET AMOUNT='_AMOUNT',DATE_TAKEN='_DATE_TAKEN',ADVANCE_TYPE = 'ADVANCETYPE', "
            + " DEDUCTION_AMT ='DEDUCTIONAMT',IS_FULLYPAID='ISFULLYPAID',DEDUCTION_START_DATE ='DEDUCTIONSTARTDATE',NARRATION='_NARRATION',DEDUCTION_FREQUENCY='_DEDUCTION_FREQUENCY',NEXT_RUN_MONTH='_NEXTRUNMONTH',LEDGER_CODE='_LEDGERCODE',MODIFIED_BY='_MODIFIEDBY',MODIFIED_DATE='_MODIFIEDDATE' WHERE ID= ID_");
            this.selectQuery = new StringBuilder("");
        }
        public override void Save(object obj)
        {
            AdvanceCore _advance = (AdvanceCore)obj;

            this.insertQuery.Replace("_EMPLOYEE_ID", _advance.Employee_Id.ToString());
            this.insertQuery.Replace("_AMOUNT", _advance.Amount.ToString());
            this.insertQuery.Replace("_DATE_TAKEN", _advance.Date_Taken.ToString());
            this.insertQuery.Replace("ADVANCETYPE", _advance.Advance_type.ToString());
            this.insertQuery.Replace("DEDUCTIONAMT", _advance.Deduction_amt.ToString());
            this.insertQuery.Replace("ISFULLYPAID", _advance.Isfullypaid.ToString());
            this.insertQuery.Replace("DEDUCTIONSTARTDATE", _advance.Deduction_start_date.ToString());
            this.insertQuery.Replace("_REMAININGBAL", _advance.Remaining_bal.ToString());
            this.insertQuery.Replace("_NARRATION", _advance.Narration.ToString());
            this.insertQuery.Replace("_DEDUCTION_FREQUENCY", _advance.DeductionFrequency.ToString());
            this.insertQuery.Replace("_NEXTRUNMONTH", _advance.NextRunMonth.ToString());
            this.insertQuery.Replace("_LEDGERCODE", _advance.LedgerCode.ToString());
            this.insertQuery.Replace("_CREATEDBY", _advance.CreatedBy.ToString());
            this.insertQuery.Replace("_CREATEDDATE", _advance.CreatedDate.ToString());
            int AutoId =   ExecuteQuery(this.insertQuery.ToString(),'y');
            _advance.Id = AutoId;


         
        }
        public override void Update(object obj)
        {
            AdvanceCore _advance = (AdvanceCore)obj;
            this.updateQuery.Replace("ID_", _advance.Id.ToString());
            this.updateQuery.Replace("_EMPLOYEE_ID", _advance.Employee_Id.ToString());
            this.updateQuery.Replace("_AMOUNT", _advance.Amount.ToString());
            this.updateQuery.Replace("_DATE_TAKEN", _advance.Date_Taken.ToString());
            this.updateQuery.Replace("ADVANCETYPE", _advance.Advance_type.ToString());
            this.updateQuery.Replace("DEDUCTIONAMT", _advance.Deduction_amt.ToString());
            this.updateQuery.Replace("ISFULLYPAID", _advance.Isfullypaid.ToString());
            this.updateQuery.Replace("DEDUCTIONSTARTDATE", _advance.Deduction_start_date.ToString());
            //this.updateQuery.Replace("_REMAININGBAL", _advance.Remaining_bal.ToString());
            this.updateQuery.Replace("_NARRATION", _advance.Narration.ToString());
            this.updateQuery.Replace("_DEDUCTION_FREQUENCY", _advance.DeductionFrequency.ToString());
            this.updateQuery.Replace("_NEXTRUNMONTH", _advance.NextRunMonth.ToString());
            this.updateQuery.Replace("_LEDGERCODE", _advance.LedgerCode.ToString());
            this.updateQuery.Replace("_MODIFIEDBY", _advance.ModifyBy.ToString());
            this.updateQuery.Replace("_MODIFIEDDATE", _advance.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
          
           
        }
        public AdvanceCore checkDataInCalender(string deductionStartDate)
        {
            string sSql = ("exec procGetNepaliMonth " + filterstring(deductionStartDate) + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            AdvanceCore _adv = null;
            if (dt != null)

                _adv = (AdvanceCore)this.MapObjectForCalenderData(dt.Rows[0]);
            return _adv;
        }
        public object MapObjectForCalenderData(System.Data.DataRow dr)
        {
            AdvanceCore _advan = new AdvanceCore();
            _advan.NextRunMonth = dr["DT"].ToString();
            return _advan;
        }
        public AdvanceCore FindById(long Id)
        {
            string sSql = ("SELECT ID,EMPLOYEE_ID,LEDGER_CODE,DEDUCTION_AMT,IS_FULLYPAID,CONVERT(VARCHAR,DEDUCTION_START_DATE,101) AS DEDUCTION_START_DATE,"
            + " AMOUNT,CONVERT(VARCHAR,DATE_TAKEN,101) AS DATE_TAKEN , ADVANCE_TYPE,NARRATION,DEDUCTION_FREQUENCY,NEXT_RUN_MONTH FROM  Advance"
            +" WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            AdvanceCore _adv = null;
            if (dt != null)
                _adv = (AdvanceCore)this.MapObjectById(dt.Rows[0]);
            return _adv;
        }
        public AdvanceCore FindAdvanceDetails(long Id)
        {
            string sSql = ("SELECT A.ID,dbo.ShowDecimal(DEDUCTION_AMT) as DEDUCTION_AMT,dbo.ShowDecimal(REMAINING_BAL) as REMAINING_BAL,"
                +" case when IS_FULLYPAID='True' then 'Yes' when IS_FULLYPAID='False' then 'No' end as 'IS_FULLYPAID',"
                +" CONVERT(VARCHAR,DEDUCTION_START_DATE,107) AS DEDUCTION_START_DATE,s1.DETAIL_TITLE AS DEDUCTION_FREQUENCY,"
                +" dbo.ShowDecimal(AMOUNT) as AMOUNT,CONVERT(VARCHAR,DATE_TAKEN,107) AS DATE_TAKEN , S.DETAIL_TITLE AS ADVANCE_TYPE FROM "
                +" Advance A INNER JOIN StaticDataDetail S ON S.ROWID=A.ADVANCE_TYPE inner join StaticDataDetail s1"
                +" on s1.ROWID=A.DEDUCTION_FREQUENCY WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            AdvanceCore _adv = null;
            if (dt != null)
                _adv = (AdvanceCore)this.MapObjectAdvanceDetails(dt.Rows[0]);
            return _adv;
        }
        public object MapObjectById(System.Data.DataRow dr)
        {
            AdvanceCore _advance = new AdvanceCore();
            _advance.Id = long.Parse(dr["ID"].ToString());
            _advance.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _advance.Amount = double.Parse(dr["AMOUNT"].ToString());
            _advance.Date_Taken = dr["DATE_TAKEN"].ToString();
            _advance.Advance_type = dr["ADVANCE_TYPE"].ToString();
            _advance.Deduction_amt = double.Parse(dr["DEDUCTION_AMT"].ToString());
            _advance.Isfullypaid = bool.Parse(dr["IS_FULLYPAID"].ToString());
            _advance.Deduction_start_date = dr["DEDUCTION_START_DATE"].ToString();
            _advance.Narration = dr["NARRATION"].ToString();
            _advance.DeductionFrequency = dr["DEDUCTION_FREQUENCY"].ToString();
            _advance.LedgerCode = dr["LEDGER_CODE"].ToString();
            _advance.NextRunMonth = dr["NEXT_RUN_MONTH"].ToString();
            return _advance;
        }
        public object MapObjectAdvanceDetails(System.Data.DataRow dr)
        {
            AdvanceCore _advance = new AdvanceCore();
            _advance.Id = long.Parse(dr["ID"].ToString());
            _advance.Amount = double.Parse(dr["AMOUNT"].ToString());
            _advance.Date_Taken = dr["DATE_TAKEN"].ToString();
            _advance.Advance_type = dr["ADVANCE_TYPE"].ToString();
            _advance.Deduction_amt = double.Parse(dr["DEDUCTION_AMT"].ToString());
            _advance.FullyPaid = dr["IS_FULLYPAID"].ToString();
            _advance.Deduction_start_date = dr["DEDUCTION_START_DATE"].ToString();
            _advance.Remaining_bal = double.Parse(dr["REMAINING_BAL"].ToString());
            _advance.DeductionFrequency = dr["DEDUCTION_FREQUENCY"].ToString();
            return _advance;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            AdvanceCore _advance = new AdvanceCore();
            _advance.Id = long.Parse(dr["ID"].ToString());
            _advance.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _advance.Emp_Name = dr["EMPLOYEE_NAME"].ToString();
            _advance.Amount = double.Parse(dr["AMOUNT"].ToString());
            _advance.Date_Taken = dr["DATE_TAKEN"].ToString();
            _advance.Advance_type = dr["DETAIL_TITLE"].ToString();
            _advance.Deduction_amt = double.Parse(dr["DEDUCTION_AMT"].ToString());
            _advance.Isfullypaid = bool.Parse(dr["IS_FULLYPAID"].ToString());
          
            if (_advance.Isfullypaid == true)
                _advance.FullyPaid = "Yes";
            else
                _advance.FullyPaid = "No";
          
            _advance.Deduction_start_date = dr["DEDUCTION_START_DATE"].ToString();
            _advance.Remaining_bal = double.Parse(dr["REMAINING_BAL"].ToString());
            return _advance;
        }
        public void DeleteAdvance(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Advance' , ' and  id=''" + id + "''', '" + user + "'");
        }

        public string CRUDLog(string Id)
        {
          
            return GetCurrentRecordInformation("ADVANCE", "ID", Id);
        }

        public string CRUDLog(string Id,char returnType)
        {

            return GetCurrentRecordInformation("AdvanceCollection", "ID", Id);
        }
   
    }
}
