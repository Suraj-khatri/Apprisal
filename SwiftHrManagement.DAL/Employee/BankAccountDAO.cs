using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BankAccountDAO;
namespace SwiftHrManagement.DAL.BankAccountDAO
{
    public class BankAccountDAO : BaseDAO
    {
        private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public BankAccountDAO()
        {
            this.insertQuery = new StringBuilder("EXEC procBankaccount i,0,_EMPLOYEE_ID,_ACCOUNT_NUMBER,_ACCOUNT_PROVIDER,_ACCOUNT_DETAILS, _IS_DEFAULT");
            this.updateQuery = new StringBuilder("UPDATE BankAccounts SET ACCOUNT_NUMBER=_ACCOUNT_NUMBER,ACCOUNT_PROVIDER=_ACCOUNT_PROVIDER, "
            + " ACCOUNT_DETAILS=_ACCOUNT_DETAILS, IS_DEFAULT=_IS_DEFAULT WHERE ID= ID_");
        
        }
        public override void Save(object obj)
        {
            BankAccountsCore _bankAccounts = (BankAccountsCore)obj;
            
            this.insertQuery.Replace("_EMPLOYEE_ID", filterstring(_bankAccounts.Employee_Id.ToString()));
            this.insertQuery.Replace("_ACCOUNT_NUMBER", filterstring(_bankAccounts.AccountNumber.ToString()));
            this.insertQuery.Replace("_ACCOUNT_PROVIDER", filterstring(_bankAccounts.AccountProvider.ToString()));
            this.insertQuery.Replace("_ACCOUNT_DETAILS", filterstring(_bankAccounts.AccountDetails.ToString()));
            this.insertQuery.Replace("_IS_DEFAULT", filterstring(_bankAccounts.IsDefault.ToString()));
            int RowId = ExecuteQuery(this.insertQuery.ToString(),'y');
            _bankAccounts.Id = RowId;
        }
        public override void Update(object obj)
        {
            BankAccountsCore _bankAccounts = (BankAccountsCore)obj;
            this.updateQuery.Replace("ID_", _bankAccounts.Id.ToString());
            this.updateQuery.Replace("_EMPLOYEE_ID", filterstring(_bankAccounts.Employee_Id.ToString()));
            this.updateQuery.Replace("_ACCOUNT_NUMBER", filterstring(_bankAccounts.AccountNumber.ToString()));
            this.updateQuery.Replace("_ACCOUNT_PROVIDER", filterstring(_bankAccounts.AccountProvider.ToString()));
            this.updateQuery.Replace("_ACCOUNT_DETAILS", filterstring(_bankAccounts.AccountDetails.ToString()));
            this.updateQuery.Replace("_IS_DEFAULT", filterstring(_bankAccounts.IsDefault.ToString()));


            ExecuteQuery(this.updateQuery.ToString());
        }

        public Boolean VerifyDefaultAc(String EmpId, long id)
        {
            String sSql = "";
                if( id == 0)
                {
                      sSql = "select is_default from BankAccounts where  EMPLOYEE_ID = '" + EmpId + "' AND IS_DEFAULT ='True'";
                }
            else
                {
                    sSql = "select is_default from BankAccounts where ID <> "+ id+" AND  EMPLOYEE_ID = '" + EmpId + "' AND IS_DEFAULT ='True'";
                }
            if (CheckStatement(sSql) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean Rowexists(long EmpId)
        {
            return CheckStatement("select * from BankAccounts where EMPLOYEE_ID = "+ EmpId +"");
        }

        public List<BankAccountsCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  B.ID, B.EMPLOYEE_ID, B.ACCOUNT_NUMBER, s.DETAIL_TITLE as 'ACCOUNT_PROVIDER',B.ACCOUNT_DETAILS,B.IS_DEFAULT, "
            + "E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME+ ' - ' + CAST(E.EMPLOYEE_ID AS VARCHAR(50)) AS EMPLOYEE_NAME "
            + "FROM  BankAccounts AS B INNER JOIN Employee AS E ON B.EMPLOYEE_ID = E.EMPLOYEE_ID "
            + "inner join (select * from StaticDataDetail where TYPE_ID=39) s on s.ROWID=B.ACCOUNT_PROVIDER "
            + "and  B.EMPLOYEE_ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<BankAccountsCore> _bankAccounts = new List<BankAccountsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BankAccountsCore _adv = (BankAccountsCore)this.MapObject(dr);
                    _bankAccounts.Add(_adv);
                }
            }
            return _bankAccounts;
        }
        public BankAccountsCore FindById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, ACCOUNT_NUMBER, ACCOUNT_PROVIDER, ACCOUNT_DETAILS, IS_DEFAULT "
                          + "  FROM  BankAccounts WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            BankAccountsCore _bank = null;
            if (dt != null)
                _bank = (BankAccountsCore)this.MapObjectForBankAccounts(dt.Rows[0]);
            return _bank;
        }
        public object MapObjectForBankAccounts(System.Data.DataRow dr)
        {
            BankAccountsCore _bankAccounts = new BankAccountsCore();
            _bankAccounts.Id = long.Parse(dr["ID"].ToString());
            _bankAccounts.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _bankAccounts.AccountNumber = dr["ACCOUNT_NUMBER"].ToString();
            _bankAccounts.AccountProvider= dr["ACCOUNT_PROVIDER"].ToString();
            _bankAccounts.AccountDetails = dr["ACCOUNT_DETAILS"].ToString();
            _bankAccounts.IsDefault = bool.Parse(dr["IS_DEFAULT"].ToString());
            
            return _bankAccounts;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            BankAccountsCore _bankAccounts = new BankAccountsCore();
            _bankAccounts.Id = long.Parse(dr["ID"].ToString());
            _bankAccounts.Employee_Id = dr["EMPLOYEE_ID"].ToString();
            _bankAccounts.AccountNumber = dr["ACCOUNT_NUMBER"].ToString();
            _bankAccounts.AccountProvider = dr["ACCOUNT_PROVIDER"].ToString();
            _bankAccounts.AccountDetails = dr["ACCOUNT_DETAILS"].ToString();
            _bankAccounts.IsDefault = bool.Parse(dr["IS_DEFAULT"].ToString());
            //
            if (_bankAccounts.IsDefault == true)
                _bankAccounts.SisDefault = "Yes";
            else
                _bankAccounts.SisDefault = "No";
            //
            return _bankAccounts;
        }
        public void deleteBankAccounts(long Id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from BankAccounts' , ' and ID=''"+ Id +"''', '"+ user +"'");
        }
        public string CRUDLog(string Id)
        {

            return GetCurrentRecordInformation("BankAccounts", "ID", Id);
        }
    }
}
