using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.ContributionMadeDAO;

namespace SwiftHrManagement.DAL.ContributionMadeDAO
{
    public class ContributionMadeDAO : BaseDAO
    {
        
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public ContributionMadeDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO ContributionsMade (CONTRIBUTION_ID, CONTRIBUTOR, CONTRIBUTION_AMOUNT, CONTRIBUTION_DATE, RECEIPT_NUMBER)"
            + " VALUES ('_CONTRIBUTION_ID', '_CONTRIBUTOR', '_CONTRIBUTION_AMOUNT', '_CONTRIBUTION_DATE', '_RECEIPT_NUMBER')");

            this.updateQuery = new StringBuilder("UPDATE ContributionsMade SET CONTRIBUTOR = '_CONTRIBUTOR', CONTRIBUTION_AMOUNT ='_CONTRIBUTION_AMOUNT' "
                + " , CONTRIBUTION_DATE = '_CONTRIBUTION_DATE', RECEIPT_NUMBER = '_RECEIPT_NUMBER' WHERE ID= ID_");
        }

        public override void Save(object obj)
        {
            ContributionMadeCore _contributionMade = (ContributionMadeCore)obj;
            this.insertQuery.Replace("_CONTRIBUTOR", _contributionMade.Contributor.ToString());
            this.insertQuery.Replace("_CONTRIBUTION_AMOUNT", _contributionMade.ContributionAmount.ToString());
            this.insertQuery.Replace("_CONTRIBUTION_DATE", _contributionMade.ContributionDate.ToString());
            this.insertQuery.Replace("_RECEIPT_NUMBER", _contributionMade.ReceiptNumber.ToString());

            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            ContributionMadeCore _contributionMade = (ContributionMadeCore)obj;
            this.updateQuery.Replace("ID_", _contributionMade.ContributionId.ToString());
            this.updateQuery.Replace("_CONTRIBUTOR", _contributionMade.Id.ToString());
            this.updateQuery.Replace("_CONTRIBUTOR", _contributionMade.Contributor.ToString());
            this.updateQuery.Replace("_CONTRIBUTION_AMOUNT", _contributionMade.ContributionAmount.ToString());
            this.updateQuery.Replace("_CONTRIBUTION_DATE", _contributionMade.ContributionDate.ToString());
            this.updateQuery.Replace("_RECEIPT_NUMBER", _contributionMade.ReceiptNumber.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<ContributionMadeCore> FindAllByContributionId(long ContributionId)
        {
            string sSql = "SELECT  CM.ID, CM.CONTRIBUTION_ID, CM.CONTRIBUTOR, C.CONTRIBUTION_CODE,CM.CONTRIBUTION_AMOUNT, CM.CONTRIBUTION_DATE, CM.RECEIPT_NUMBER, "
            + " C.ID FROM  Contribution AS C INNER JOIN "
            + "dbo.ContributionsMade as CM ON C.ID = CM.CONTRIBUTION_ID WHERE CONTRIBUTION_ID = " + ContributionId + " order by CM.CONTRIBUTOR, CM.CONTRIBUTION_DATE DESC ";
            DataTable dt = SelectByQuery(sSql);
            List<ContributionMadeCore> _contributionMade = new List<ContributionMadeCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ContributionMadeCore _cont = (ContributionMadeCore)this.MapContbCode(dr);
                    _contributionMade.Add(_cont);
                }
            }
            return _contributionMade;
        }
        public object MapContbCode(System.Data.DataRow dr)
        {
            ContributionMadeCore _contribution = new ContributionMadeCore();
            _contribution.Id = long.Parse(dr["ID"].ToString());
            _contribution.ContributionId = (dr["CONTRIBUTION_ID"].ToString());
            _contribution.Contributor = dr["CONTRIBUTOR"].ToString();
            _contribution.ContributionAmount = Double.Parse(dr["CONTRIBUTION_AMOUNT"].ToString());
            _contribution.ContributionDate = DateTime.Parse(dr["CONTRIBUTION_DATE"].ToString());
            _contribution.ReceiptNumber = dr["RECEIPT_NUMBER"].ToString();
            _contribution.ContributionCode = dr["CONTRIBUTION_CODE"].ToString();
            return _contribution;
        }


        public ContributionMadeCore FindById(long Id)
        {
            string sSql = ("SELECT  ID, CONTRIBUTION_ID, CONTRIBUTOR, CONTRIBUTION_AMOUNT, CONTRIBUTION_DATE, RECEIPT_NUMBER "
                          + "  FROM  ContributionsMade WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            
            ContributionMadeCore _cont = null;
            
            if (dt != null)
                _cont = (ContributionMadeCore)this.MapObject(dt.Rows[0]);
            
            return _cont;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            ContributionMadeCore _contribution = new ContributionMadeCore();
            _contribution.Id = long.Parse(dr["ID"].ToString());
            _contribution.ContributionId = (dr["CONTRIBUTION_ID"].ToString());
            _contribution.Contributor = dr["CONTRIBUTOR"].ToString();
            _contribution.ContributionAmount = Double.Parse(dr["CONTRIBUTION_AMOUNT"].ToString());
            _contribution.ContributionDate = DateTime.Parse(dr["CONTRIBUTION_DATE"].ToString());
            _contribution.ReceiptNumber = dr["RECEIPT_NUMBER"].ToString();
            return _contribution;
        }
    }
}
