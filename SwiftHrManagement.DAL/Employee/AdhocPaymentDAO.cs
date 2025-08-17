using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.AdhocPaymentDAO;

namespace SwiftHrManagement.DAL.AdhocPaymentDAO
{
    public class AdhocPaymentDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;     

        public AdhocPaymentDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO AdhocPayment(EMPLOYEE_ID, ADD_DEDUCT, HEAD_ID,  APPLIED_DATE, AMOUNT,TAX_DEDUCTED, "
            + " IS_PAID, NARRATION, IS_TAXED, CREATED_BY, CREATED_DATE) VALUES('EMPLOYEEID', 'ADDDEDUCT', 'HEADID',  APPLIEDDATE, 'AMOUNT_',"
            + " 'TAXDEDUCTED','ISPAID','NARRATION_', 'ISTAXED', 'CREATEDBY','CREATEDDATE') SELECT SCOPE_IDENTITY();");

            this.updateQuery = new StringBuilder("UPDATE AdhocPayment SET ADD_DEDUCT='ADDDEDUCT', HEAD_ID='HEADID', APPLIED_DATE=APPLIEDDATE,"
            + " IS_PAID='ISPAID',AMOUNT = 'AMOUNT_' , TAX_DEDUCTED = 'TAXDEDUCTED', NARRATION = 'NARRATION_', IS_TAXED ='ISTAXED' "
            + " ,MODIFIED_BY = 'MODIFIEDBY', MODIFIED_DATE ='MODIFIEDDATE' WHERE ID= 'ID_'");
        }

        public override void Save(object obj)
        {
            AdhocPaymentCore _adhocPaymentCore = (AdhocPaymentCore)obj;
            this.insertQuery.Replace("EMPLOYEEID", _adhocPaymentCore.EmployeeId.ToString());
            this.insertQuery.Replace("ADDDEDUCT", _adhocPaymentCore.Add_deduct.ToString());
            this.insertQuery.Replace("HEADID", _adhocPaymentCore.Head_id.ToString());
            this.insertQuery.Replace("APPLIEDDATE",filterstring(_adhocPaymentCore.Applied_date.ToString()));
            this.insertQuery.Replace("AMOUNT_", _adhocPaymentCore.Amount.ToString());
            this.insertQuery.Replace("TAXDEDUCTED", _adhocPaymentCore.Tax_deduct.ToString());
            this.insertQuery.Replace("ISPAID", _adhocPaymentCore.Ispaid.ToString());
            this.insertQuery.Replace("ISTAXED", _adhocPaymentCore.Istaxed.ToString());
            this.insertQuery.Replace("NARRATION_", _adhocPaymentCore.Narration.ToString());
            this.insertQuery.Replace("CREATEDBY", _adhocPaymentCore.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", _adhocPaymentCore.CreatedDate.ToString());
            int RowId = ExecuteQuery(this.insertQuery.ToString(),'y');
            _adhocPaymentCore.Id = RowId;
        }
        public override void Update(object obj)
        {
            AdhocPaymentCore _adhocPaymentCore = (AdhocPaymentCore)obj;
            this.updateQuery.Replace("ID_", _adhocPaymentCore.Id.ToString());
            this.updateQuery.Replace("EMPLOYEEID", _adhocPaymentCore.EmployeeId.ToString());
            this.updateQuery.Replace("ADDDEDUCT", _adhocPaymentCore.Add_deduct.ToString());
            this.updateQuery.Replace("HEADID", _adhocPaymentCore.Head_id.ToString());
            this.updateQuery.Replace("APPLIEDDATE",filterstring(_adhocPaymentCore.Applied_date.ToString()));
            this.updateQuery.Replace("AMOUNT_", _adhocPaymentCore.Amount.ToString());
            this.updateQuery.Replace("TAXDEDUCTED", _adhocPaymentCore.Tax_deduct.ToString());
            this.updateQuery.Replace("ISPAID", _adhocPaymentCore.Ispaid.ToString());
            this.updateQuery.Replace("ISTAXED", _adhocPaymentCore.Istaxed.ToString());
            this.updateQuery.Replace("NARRATION_", _adhocPaymentCore.Narration.ToString());
            this.updateQuery.Replace("MODIFIEDBY", _adhocPaymentCore.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", _adhocPaymentCore.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
        }
        public List<AdhocPaymentCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  AP.ID, case when AP.IS_PAID = 'True' then 'Yes' when AP.IS_PAID = 'False' then 'No' end 'IS_PAID', "
            + " AP.ADD_DEDUCT,AP.EMPLOYEE_ID, AP.TAX_DEDUCTED, AP.IS_PAID, s.DETAIL_TITLE 'HEAD_ID', CONVERT(VARCHAR,AP.APPLIED_DATE,107) AS 'APPLIED_DATE',"
            + " AP.AMOUNT, AP.NARRATION, AP.TAX_DEDUCTED,case when AP.IS_TAXED = 'True' then 'Yes' when AP.IS_TAXED = 'False' then 'No' "
            + " end 'IS_TAXED',E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME+ ' - ' + CAST(E.EMPLOYEE_ID AS "
            + " VARCHAR(50)) AS EMPLOYEE_NAME FROM AdhocPayment AS AP INNER JOIN Employee AS E ON AP.EMPLOYEE_ID = E.EMPLOYEE_ID inner join "
            + " (select ROWID, TYPE_ID, DETAIL_TITLE, DETAIL_DESC from StaticDataDetail where TYPE_ID in (40,41)) s on s.ROWID= AP.HEAD_ID WHERE AP.EMPLOYEE_ID=" + Id + "";   
            DataTable dt = SelectByQuery(sSql); 
            List<AdhocPaymentCore> _adhocList = new List<AdhocPaymentCore>(); 
            if (dt != null) 
            {
                foreach (DataRow dr in dt.Rows) 
                {
                    AdhocPaymentCore _adhoc = (AdhocPaymentCore)this.MapObject(dr); 
                    _adhocList.Add(_adhoc); 
                }
            }
            return _adhocList; 
        }

        public AdhocPaymentCore FindById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, ADD_DEDUCT, HEAD_ID, ISNULL(TAX_DEDUCTED,0) 'TAX_DEDUCTED', CONVERT(VARCHAR,APPLIED_DATE,101) "
            + " AS 'APPLIED_DATE', isnull(AMOUNT,0) as AMOUNT, TAX_DEDUCTED, IS_PAID, NARRATION, IS_TAXED, APPLIED_FOR_MONTH, APPLIED_FOR_YEAR "
            +" from AdhocPayment WHERE ID=" + Id + "").ToString(); 

            DataTable dt = SelectByQuery(sSql); 
            AdhocPaymentCore _ap = null; 
            if (dt != null) 
                _ap = (AdhocPaymentCore)this.MapObject(dt.Rows[0]); 
            return _ap; 
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            AdhocPaymentCore _adhoc = new AdhocPaymentCore();
            _adhoc.Id = long.Parse(dr["ID"].ToString());
            _adhoc.EmployeeId = dr["EMPLOYEE_ID"].ToString();
            _adhoc.Add_deduct = dr["ADD_DEDUCT"].ToString();
            _adhoc.Applied_date = (dr["APPLIED_DATE"].ToString());
            _adhoc.Head_id = dr["HEAD_ID"].ToString();
            _adhoc.Ispaid = dr["IS_PAID"].ToString();
            _adhoc.Istaxed = dr["IS_TAXED"].ToString();
            _adhoc.Narration = dr["NARRATION"].ToString();
            _adhoc.Tax_deduct = Double.Parse(dr["TAX_DEDUCTED"].ToString());
            _adhoc.Amount = Double.Parse(dr["AMOUNT"].ToString());
            _adhoc.App_for_Month = dr["APPLIED_FOR_MONTH"].ToString();
            _adhoc.App_for_Year = dr["APPLIED_FOR_YEAR"].ToString();
            return _adhoc;
        }
        public void deleteAdhoc(long id, string user)
        {
            ExecuteQuery(" exec procExecuteSQLString 'd' , 'delete from AdhocPayment' , ' and ID=''"+ id +"''', '"+ user +"'");
        }
        public string CRUDLog(string Id)
        {

            return GetCurrentRecordInformation("AdhocPayment", "ID", Id);
        }
    }
}