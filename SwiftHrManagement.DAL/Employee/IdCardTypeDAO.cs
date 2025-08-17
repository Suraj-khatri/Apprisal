using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.IdCardTypeDAO;

namespace SwiftHrManagement.DAL.IdCardTypeDAO
{
    public class IdCardTypeDAO : BaseDAO
    {
        private StringBuilder selectQuery;
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public IdCardTypeDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO EMPLOYEE_IDENTIFICATION (EMPLOYEE_ID, CARD_TYPE, CARD_NO, ISSUE_PLACE, ISSUE_DATE, EXPIRY_DATE)"
           + " VALUES (EMPLOYEEID,CARDTYPE,CARDNO,ISSUEPLACE,ISSUEDATE,EXPIRYDATE)");
            this.updateQuery = new StringBuilder("UPDATE EMPLOYEE_IDENTIFICATION SET CARD_TYPE=CARDTYPE,CARD_NO=CARDNO,ISSUE_PLACE=ISSUEPLACE,"
                + " ISSUE_DATE=ISSUEDATE, EXPIRY_DATE=EXPIRYDATE WHERE ID= ID_");
            this.selectQuery = new StringBuilder("");
        }
        public override void Save(object obj)
        {
            IdCardTypeCore _idTypeCore = (IdCardTypeCore)obj;
            this.insertQuery.Replace("EMPLOYEEID", filterstring(_idTypeCore.EmpId.ToString()));
            this.insertQuery.Replace("CARDTYPE", filterstring(_idTypeCore.CardType.ToString()));
            this.insertQuery.Replace("CARDNO", filterstring(_idTypeCore.CardNo.ToString()));
            this.insertQuery.Replace("ISSUEPLACE", filterstring(_idTypeCore.IssuePlace.ToString()));
            this.insertQuery.Replace("ISSUEDATE", filterstring(_idTypeCore.IssueDate.ToString()));
            this.insertQuery.Replace("EXPIRYDATE", filterstring(_idTypeCore.ExpiryDate.ToString()));
            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            IdCardTypeCore _idTypeCore = (IdCardTypeCore)obj;
            this.updateQuery.Replace("ID_", filterstring(_idTypeCore.Id.ToString()));
            this.updateQuery.Replace("CARDTYPE", filterstring(_idTypeCore.CardType.ToString()));
            this.updateQuery.Replace("CARDNO", filterstring(_idTypeCore.CardNo.ToString()));
            this.updateQuery.Replace("ISSUEPLACE", filterstring(_idTypeCore.IssuePlace.ToString()));
            this.updateQuery.Replace("ISSUEDATE", filterstring(_idTypeCore.IssueDate.ToString()));
            this.updateQuery.Replace("EXPIRYDATE", filterstring(_idTypeCore.ExpiryDate.ToString()));
            ExecuteQuery(this.updateQuery.ToString());
        }
        public List<IdCardTypeCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  I.ID, I.EMPLOYEE_ID, S.DETAIL_TITLE AS CARD_TYPE,  I.CARD_NO, I.ISSUE_PLACE, I.ISSUE_DATE, I.EXPIRY_DATE"         
            + "  FROM  EMPLOYEE_IDENTIFICATION AS I INNER JOIN StaticDataDetail S ON I.CARD_TYPE=S.ROWID WHERE I.EMPLOYEE_ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<IdCardTypeCore> _idTypeCore = new List<IdCardTypeCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    IdCardTypeCore _idCore = (IdCardTypeCore)this.MapObject(dr);
                    _idTypeCore.Add(_idCore);
                }
            }
            return _idTypeCore;
        }
        public IdCardTypeCore FindById(long Id)
        {
            string sSql = ("SELECT  ID, EMPLOYEE_ID, CARD_TYPE, CARD_NO, ISSUE_PLACE, CONVERT(VARCHAR,ISSUE_DATE,101) AS ISSUE_DATE, CONVERT(VARCHAR,EXPIRY_DATE,101) AS EXPIRY_DATE "
                          + "  FROM  EMPLOYEE_IDENTIFICATION WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            IdCardTypeCore _idCardType = null;
            if (dt != null)
                _idCardType = (IdCardTypeCore)this.MapObject(dt.Rows[0]);
            return _idCardType;
        }       
        public override object MapObject(System.Data.DataRow dr)
        {
            IdCardTypeCore _cardType = new IdCardTypeCore();
            _cardType.Id = long.Parse(dr["ID"].ToString());
            _cardType.EmpId = long.Parse(dr["EMPLOYEE_ID"].ToString());          
            _cardType.CardType = dr["CARD_TYPE"].ToString();
            _cardType.CardNo = dr["CARD_NO"].ToString();
            _cardType.IssuePlace = dr["ISSUE_PLACE"].ToString();
            _cardType.IssueDate = dr["ISSUE_DATE"].ToString();
            _cardType.ExpiryDate = dr["EXPIRY_DATE"].ToString();
            return _cardType;
        }
        public void DeleteById(long Id)
        {
            String sSql = "";
            sSql = "DELETE FROM EMPLOYEE_IDENTIFICATION WHERE ID = " + Id + "";
            this.ExecuteQuery(sSql);
        }
    }
}
