using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.VisitRecordDAO;

namespace SwiftHrManagement.DAL.VisitRecordDAO
{
    public class VisitRecordDAO : BaseDAO
    {

        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public VisitRecordDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO VisitRecord(EMPLOYEE_ID, FROM_DATE, TO_DATE, COUNTRY, CITY, PLACE, TYPE, REASON )"
                                                      + " VALUES ('_EMPLOYEE_ID', '_FROM_DATE','_TO_DATE','_COUNTRY','_CITY','_PLACE','_TYPE','_REASON')");

            this.updateQuery = new StringBuilder("UPDATE VisitRecord SET "

            + " FROM_DATE='_FROM_DATE', "
            + " TO_DATE='_TO_DATE', "
            + " COUNTRY='_COUNTRY', "
            + " CITY='_CITY', "
            + " PLACE='_PLACE', "
            + " TYPE='_TYPE', "
            + " REASON='_REASON' "
            + " WHERE ID= ID_");
        }

        public override void Save(object obj)
        {
            VisitRecordCore _visitRecord = (VisitRecordCore)obj;

            this.insertQuery.Replace("_EMPLOYEE_ID", _visitRecord.EmployeeId.ToString());
            this.insertQuery.Replace("_FROM_DATE", _visitRecord.DateFrom.ToString());
            this.insertQuery.Replace("_TO_DATE", _visitRecord.DateTo.ToString());

            this.insertQuery.Replace("_COUNTRY", _visitRecord.Country.ToString());
            this.insertQuery.Replace("_CITY", _visitRecord.City.ToString());
            this.insertQuery.Replace("_PLACE", _visitRecord.Place.ToString());
            this.insertQuery.Replace("_TYPE", _visitRecord.VisitType.ToString());
            this.insertQuery.Replace("_REASON", _visitRecord.Reason.ToString());

            ExecuteQuery(this.insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            VisitRecordCore _visitRecord = (VisitRecordCore)obj;

            this.updateQuery.Replace("ID_", _visitRecord.Id.ToString());

            this.updateQuery.Replace("_EMPLOYEE_ID", _visitRecord.EmployeeId.ToString());
            this.updateQuery.Replace("_FROM_DATE", _visitRecord.DateFrom.ToString());
            this.updateQuery.Replace("_TO_DATE", _visitRecord.DateTo.ToString());

            this.updateQuery.Replace("_COUNTRY", _visitRecord.Country.ToString());
            this.updateQuery.Replace("_CITY", _visitRecord.City.ToString());
            this.updateQuery.Replace("_PLACE", _visitRecord.Place.ToString());
            this.updateQuery.Replace("_TYPE", _visitRecord.VisitType.ToString());
            this.updateQuery.Replace("_REASON", _visitRecord.Reason.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<VisitRecordCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  V.ID, V.EMPLOYEE_ID, V.FROM_DATE, V.TO_DATE, V.COUNTRY, V.CITY, V.PLACE, V.TYPE, V.REASON"
                          + "  FROM  VisitRecord AS V INNER JOIN Employee AS E ON V.EMPLOYEE_ID = E.EMPLOYEE_ID WHERE V.EMPLOYEE_ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<VisitRecordCore> _visits = new List<VisitRecordCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    VisitRecordCore _v = (VisitRecordCore)this.MapObject(dr);
                    _visits.Add(_v);
                }
            }
            return _visits;
        }
        public VisitRecordCore FindById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, FROM_DATE, TO_DATE, COUNTRY, CITY, PLACE, TYPE, REASON "
                          + "  FROM  VisitRecord WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            VisitRecordCore _visit = null;
            if (dt != null)
                _visit = (VisitRecordCore)this.MapObject(dt.Rows[0]);
            return _visit;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            VisitRecordCore _visit = new VisitRecordCore();

            _visit.Id = long.Parse(dr["ID"].ToString());
            _visit.EmployeeId = dr["EMPLOYEE_ID"].ToString();

            _visit.DateFrom = DateTime.Parse(dr["FROM_DATE"].ToString());
            _visit.DateTo = DateTime.Parse(dr["TO_DATE"].ToString());
            _visit.VisitType = dr["TYPE"].ToString();
            _visit.Country = dr["COUNTRY"].ToString();
            _visit.City = dr["CITY"].ToString();
            _visit.Place = dr["PLACE"].ToString();
            _visit.Reason = dr["REASON"].ToString();

            return _visit;
        }
    }
}
