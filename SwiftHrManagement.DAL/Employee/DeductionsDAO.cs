using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.DeductionsDAO;

namespace SwiftHrManagement.DAL.DeductionsDAO
{
    public class DeductionsDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public DeductionsDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Deductions(EMPLOYEE_ID, DEDUCTION_NAME, DEDUCTION_DATE, DEDUCTION_AMOUNT, IS_TAXABLE)"
            + " VALUES ('_EMPLOYEE_ID','_DEDUCTION_NAME','_DEDUCTION_DATE','_DEDUCTION_AMOUNT','ISTAXABLE')");

            this.updateQuery = new StringBuilder("UPDATE Deductions SET DEDUCTION_NAME='_DEDUCTION_NAME',DEDUCTION_DATE='_DEDUCTION_DATE',"
            + " DEDUCTION_AMOUNT='_DEDUCTION_AMOUNT',IS_TAXABLE='ISTAXABLE' WHERE ID= ID_");
        }

        public override void Save(object obj)
        {
            DeductionsCore _deductions = (DeductionsCore)obj;
          
            this.insertQuery.Replace("_EMPLOYEE_ID", _deductions.EmployeeId.ToString());
            this.insertQuery.Replace("_DEDUCTION_NAME", _deductions.DeductionName.ToString());
            this.insertQuery.Replace("_DEDUCTION_DATE", _deductions.DeductionDate.ToString());
            this.insertQuery.Replace("_DEDUCTION_AMOUNT", _deductions.DeductionAmount.ToString());
            this.insertQuery.Replace("ISTAXABLE", _deductions.Istaxable.ToString());

            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            DeductionsCore _deductions = (DeductionsCore)obj;
            this.updateQuery.Replace("ID_", _deductions.Id.ToString());
            this.updateQuery.Replace("_EMPLOYEE_ID", _deductions.EmployeeId.ToString());
            this.updateQuery.Replace("_DEDUCTION_NAME", _deductions.DeductionName.ToString());
            this.updateQuery.Replace("_DEDUCTION_DATE", _deductions.DeductionDate.ToString());
            this.updateQuery.Replace("_DEDUCTION_AMOUNT", _deductions.DeductionAmount.ToString());
            this.updateQuery.Replace("ISTAXABLE", _deductions.Istaxable.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<DeductionsCore> FindAllByEmpId(long Id)
        {
            string sSql = ("SELECT D.ID, D.EMPLOYEE_ID, D.IS_TAXABLE,s.DETAIL_TITLE 'DEDUCTION_NAME', CONVERT(VARCHAR,D.DEDUCTION_DATE,107) AS DEDUCTION_DATE, D.DEDUCTION_AMOUNT FROM  Deductions D "
           + " inner join (select * from StaticDataDetail where TYPE_ID=40) s on s.ROWID=D.DEDUCTION_NAME where D.EMPLOYEE_ID=" + Id + "").ToString();
            
            DataTable dt = SelectByQuery(sSql);
            List<DeductionsCore> _deductionList = new List<DeductionsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DeductionsCore _ded = (DeductionsCore)this.MapObject(dr);
                    _deductionList.Add(_ded);
                }
            }
            return _deductionList;
        }
        public DeductionsCore FindById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, DEDUCTION_NAME, IS_TAXABLE,DEDUCTION_DATE, DEDUCTION_AMOUNT FROM  Deductions WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            DeductionsCore _ded = null;
            if (dt != null)
                _ded = (DeductionsCore)this.MapObject(dt.Rows[0]);
            return _ded;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            DeductionsCore _deductions = new DeductionsCore();
            _deductions.Id = int.Parse(dr["ID"].ToString());
            _deductions.EmployeeId = dr["EMPLOYEE_ID"].ToString();
            _deductions.DeductionName = dr["DEDUCTION_NAME"].ToString();
            _deductions.DeductionDate = dr["DEDUCTION_DATE"].ToString();
            _deductions.DeductionAmount = double.Parse(dr["DEDUCTION_AMOUNT"].ToString());
            _deductions.Istaxable = bool.Parse(dr["IS_TAXABLE"].ToString());
            return _deductions;
        }
        public void DeleteDeduction(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Deductions' , ' and ID=''" + id + "''', '" + user + "'");
        }
    }
}