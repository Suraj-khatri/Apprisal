using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.AccountMaintainance
{
    public class AccountMaintainanceDAO :BaseDAOInv
    {

        public AccountMaintainanceCore GetAccountDetailsByID(long Id)
        {
            string sSql = " SELECT [ACCT_ID],[ACCT_NUM],[ACCT_NAME],[ACCT_CURRENCY],ISNULL([ACCT_BRANCH_ID],0) AS ACCT_BRANCH_ID,[ACCT_TYPE_CODE]"
                          + ",[ACCT_BALANCE]  FROM [AC_MASTER] WHERE ACCT_ID = " + Id + "";

            DataTable dt = SelectByQuery(sSql);

            AccountMaintainanceCore _acCore = null;

            if (dt != null)
            {
                _acCore = (AccountMaintainanceCore)this.MapObject(dt.Rows[0]);
            }

            return _acCore;
        }

        public override object MapObject(DataRow dr)
        {
            AccountMaintainanceCore _acCore = new AccountMaintainanceCore();
            _acCore.AcID = long.Parse(dr["ACCT_ID"].ToString());
            _acCore.AcNumber = dr["ACCT_NUM"].ToString();
            _acCore.AcName = dr["ACCT_NAME"].ToString();
            _acCore.AcCurrency = dr["ACCT_CURRENCY"].ToString();
            _acCore.AcBranchId = long.Parse(dr["ACCT_BRANCH_ID"].ToString());
            _acCore.AcTypeCode = dr["ACCT_TYPE_CODE"].ToString();
            _acCore.Acbalance = double.Parse(dr["ACCT_BALANCE"].ToString());

            return _acCore;
        }

        public override void Save(object obj)
        {
            AccountMaintainanceCore acCore = (AccountMaintainanceCore)obj;
            String sSql = ("exec proc_manageAccountMaintainance '" + acCore.AcID + "','" + acCore.AcNumber + "',"
                        + "'" + acCore.AcName + "','" + acCore.AcCurrency + "','" + acCore.AcBranchId + "',"
                        + "'" + acCore.AcTypeCode + "','" + acCore.ActEmpID + "','" + acCore.CreatedDate + "','" + "I" +  "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public override void Update(object obj)
        {
            AccountMaintainanceCore acCore = (AccountMaintainanceCore)obj;
            String sSql = ("exec proc_manageAccountMaintainance '" + acCore.AcID + "','" + acCore.AcNumber + "',"
                        + "'" + acCore.AcName + "','" + acCore.AcCurrency + "','" + acCore.AcBranchId + "',"
                        + "'" + acCore.AcTypeCode + "','" + acCore.ActEmpID + "','" + acCore.CreatedDate + "','" + "U" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
    }
}
