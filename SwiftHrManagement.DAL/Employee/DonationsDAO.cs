using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.DonationsDAO;

namespace SwiftHrManagement.DAL.DonationsDAO
{
    public class DonationsDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public DonationsDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Donations(EMPLOYEE_ID, DONATION_AMOUNT, DONATION_DATE, DETAILED_DESCRIPTION, GOVT_APPROVED_RATE )"
            + " VALUES ('_EMPLOYEE_ID','_DONATION_AMOUNT','_DONATION_DATE','_DETAILED_DESCRIPTION','_GOVT_APPROVED_RATE')SELECT SCOPE_IDENTITY();");
           
            this.updateQuery = new StringBuilder("UPDATE Donations SET DONATION_AMOUNT='_DONATION_AMOUNT', DONATION_DATE='_DONATION_DATE',"
            + " DETAILED_DESCRIPTION='_DETAILED_DESCRIPTION', GOVT_APPROVED_RATE='_GOVT_APPROVED_RATE' WHERE ID= ID_");
        }

        public override void Save(object obj)
        {
            DonationsCore _donations = (DonationsCore)obj;

            this.insertQuery.Replace("_EMPLOYEE_ID", _donations.EmployeeId.ToString());
            this.insertQuery.Replace("_DONATION_AMOUNT", _donations.DonationAmount.ToString());
            this.insertQuery.Replace("_DONATION_DATE", _donations.DonationDate.ToString());
            this.insertQuery.Replace("_DETAILED_DESCRIPTION", _donations.DetailedDescription.ToString());
            this.insertQuery.Replace("_GOVT_APPROVED_RATE", _donations.GovernmentApprovedDeduction.ToString());

            int RowId = ExecuteQuery(this.insertQuery.ToString(),'y');
            _donations.Id = RowId;
        }
        public override void Update(object obj)
        {
            DonationsCore _donations = (DonationsCore)obj;

            this.updateQuery.Replace("ID_", _donations.Id.ToString());
            this.updateQuery.Replace("_EMPLOYEE_ID", _donations.EmployeeId.ToString());
            this.updateQuery.Replace("_DONATION_AMOUNT", _donations.DonationAmount.ToString());
            this.updateQuery.Replace("_DONATION_DATE", _donations.DonationDate.ToString());
            this.updateQuery.Replace("_DETAILED_DESCRIPTION", _donations.DetailedDescription.ToString());
            this.updateQuery.Replace("_GOVT_APPROVED_RATE", _donations.GovernmentApprovedDeduction.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<DonationsCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  D.ID,D.EMPLOYEE_ID,D.DONATION_AMOUNT,CONVERT(VARCHAR,D.DONATION_DATE,107) AS DONATION_DATE,D.DETAILED_DESCRIPTION,GOVT_APPROVED_RATE"
                          + "  FROM  Donations AS D INNER JOIN Employee AS E ON D.EMPLOYEE_ID = E.EMPLOYEE_ID WHERE D.EMPLOYEE_ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<DonationsCore> _donation = new List<DonationsCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DonationsCore _dn = (DonationsCore)this.MapObject(dr);
                    _donation.Add(_dn);
                }
            }
            return _donation;
        }
        public DonationsCore FindById(long Id)
        {
            string sSql = ("SELECT ID,EMPLOYEE_ID,DONATION_AMOUNT,convert(varchar,DONATION_DATE,101) as DONATION_DATE,DETAILED_DESCRIPTION,GOVT_APPROVED_RATE FROM Donations WHERE "
            + " ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            DonationsCore _dn = null;
            if (dt != null)
                _dn = (DonationsCore)this.MapObject(dt.Rows[0]);
            return _dn;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            DonationsCore _donation = new DonationsCore();

            _donation.Id = long.Parse(dr["ID"].ToString());
            _donation.EmployeeId = dr["EMPLOYEE_ID"].ToString();           
            _donation.DonationDate = dr["DONATION_DATE"].ToString();
            _donation.sDonationDate = dr["DONATION_DATE"].ToString();
            _donation.DonationAmount = double.Parse(dr["DONATION_AMOUNT"].ToString());
            _donation.DetailedDescription = dr["DETAILED_DESCRIPTION"].ToString();
            _donation.GovernmentApprovedDeduction = dr["GOVT_APPROVED_RATE"].ToString();
            return _donation;
        }
        public void Deletedonation(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Donations' , ' and ID=''"+ id +"''', '"+ user +"'");
        }
        public string CRUDLog(string Id)
        {

            return GetCurrentRecordInformation("Donations", "ID", Id);
        }
    }
}