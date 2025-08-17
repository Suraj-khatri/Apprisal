using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.LeaveCalender
{
    public class LeaveCalenderDAO : BaseDAOInv
    {
        private StringBuilder _insertQuery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;

        public LeaveCalenderDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO OfficialCalendar(BRANCHID, TITLE, DATE, NATURE, TYPE, "
            + " VENUE,DESCRIPTION,CREATEDBY,CREATEDDATE) VALUES (BRANCHID_,'TITLE_','DATE_','NATURE_','TYPE_','VENUE_','DESCRIPTION_','CREATEDBY_','created')");

            this._updateQuery = new StringBuilder("UPDATE OfficialCalendar SET BRANCHID=branchid,TITLE='TITLE_',DATE='DATE_',NATURE='NATURE_', "
            + "VENUE='VENUE_',DESCRIPTION='DESCRIPTION_',MODIFIEDBY='userby_',MODIFIEDDATE='date_' WHERE ID = 'ID_'");

            this._selectQuery = new StringBuilder("SELECT ID, BRANCHID, TITLE, DATE, NATURE, TYPE,VENUE,DESCRIPTION FROM OfficialCalendar");            
        }
        public override void Save(object obj)
        {
            OfficialCalender _cal = (OfficialCalender)obj;
            this._insertQuery.Replace("BRANCHID_", FilterQuote(_cal.BranchId));
            this._insertQuery.Replace("TITLE_", FilterQuote(_cal.Title));
            this._insertQuery.Replace("DATE_", FilterQuote(_cal.Date));
            this._insertQuery.Replace("NATURE_", FilterQuote(_cal.Nature));
            this._insertQuery.Replace("TYPE_", FilterQuote(_cal.Type));
            this._insertQuery.Replace("VENUE_", FilterQuote(_cal.Venue));
            this._insertQuery.Replace("DESCRIPTION_", FilterQuote(_cal.Description));
            this._insertQuery.Replace("CREATEDBY_", FilterQuote(_cal.CreatedBy));
            this._insertQuery.Replace("created", FilterQuote(_cal.CreatedDate.ToString()));
                
            ExecuteQuery(this._insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            OfficialCalender _cal = (OfficialCalender)obj;
            this._updateQuery.Replace("ID_", FilterQuote(_cal.Id.ToString()));
            this._updateQuery.Replace("branchid", FilterQuote(_cal.BranchId));
            this._updateQuery.Replace("TITLE_", FilterQuote(_cal.Title));
            this._updateQuery.Replace("DATE_", FilterQuote(_cal.Date));
            this._updateQuery.Replace("NATURE_", FilterQuote(_cal.Nature));
            this._updateQuery.Replace("VENUE_", FilterQuote(_cal.Venue));
            this._updateQuery.Replace("DESCRIPTION_", FilterQuote(_cal.Description));
            this._updateQuery.Replace("userby_", FilterQuote(_cal.ModifyBy));
            this._updateQuery.Replace("date_", FilterQuote(_cal.ModifyDate.ToString()));
            ExecuteQuery(this._updateQuery.ToString());
        }
        public List<OfficialCalender> Findall()
        {
            DataTable dt = SelectByQuery("SELECT ID,BRANCHID,TITLE,CONVERT(VARCHAR,DATE,107) AS DATE, NATURE, DESCRIPTION FROM OfficialCalendar where "
            + " TYPE ='H'");
            List<OfficialCalender> _caender = new List<OfficialCalender>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OfficialCalender _cal = (OfficialCalender)this.MapObject(dr);
                    _caender.Add(_cal);
                }
            }
            return _caender;
        }
        public List<OfficialCalender> FindallEvents()
        {
            DataTable dt = SelectByQuery("SELECT ID,BRANCHID, TITLE, CONVERT(VARCHAR,DATE,107) AS DATE, DESCRIPTION,VENUE FROM OfficialCalendar where "
            + " TYPE ='E'");
            List<OfficialCalender> _caender = new List<OfficialCalender>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OfficialCalender _cal = (OfficialCalender)this.MapObjectForEvent(dr);
                    _caender.Add(_cal);
                }
            }
            return _caender;
        }
        public List<OfficialCalender> FindHolidayFields(string L_Type)
        {
            DataTable dt = SelectByQuery("SELECT ID,BRANCHID, TITLE, CONVERT(VARCHAR,DATE,107) AS DATE, NATURE, DESCRIPTION FROM OfficialCalendar where "
            + " TYPE ='H' AND TITLE like '" + FilterQuote(L_Type) + "%'");
            List<OfficialCalender> _caender = new List<OfficialCalender>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OfficialCalender _cal = (OfficialCalender)this.MapObject(dr);
                    _caender.Add(_cal);
                }
            }
            return _caender;
        }
        public List<OfficialCalender> FindEventByField(string L_Type)
        {
            DataTable dt = SelectByQuery("SELECT ID,BRANCHID, TITLE, CONVERT(VARCHAR,DATE,107) AS DATE, DESCRIPTION,VENUE FROM OfficialCalendar where "
            + " TYPE ='E' AND TITLE like '" + FilterQuote(L_Type) + "%'");
            List<OfficialCalender> _caender = new List<OfficialCalender>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    OfficialCalender _cal = (OfficialCalender)this.MapObjectForEvent(dr);
                    _caender.Add(_cal);
                }
            }
            return _caender;
        }
        public OfficialCalender FindEventById(long Id)
        {
            string sSql = "SELECT ID,BRANCHID, TITLE, CONVERT(VARCHAR,DATE,101) AS DATE, DESCRIPTION,VENUE FROM OfficialCalendar where "
            + " TYPE ='E' AND ID =" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            OfficialCalender _Cal = null;
            if (dt != null)
                _Cal = (OfficialCalender)this.MapObjectForEvent(dt.Rows[0]);
            return _Cal;
        }
        public OfficialCalender FindHolidayById(long Id)
        {
            string sSql = "SELECT ID,BRANCHID, TITLE,NATURE,CONVERT(VARCHAR,DATE,101) AS DATE, DESCRIPTION FROM OfficialCalendar where "
            + " TYPE ='H' AND ID =" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            OfficialCalender _Cal = null;
            if (dt != null)
                _Cal = (OfficialCalender)this.MapObject(dt.Rows[0]);
            return _Cal;
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            OfficialCalender _cal = new OfficialCalender();
            _cal.Title = dr["TITLE"].ToString();
            _cal.Id = long.Parse(dr["ID"].ToString());
            _cal.Date = (dr["DATE"].ToString());
            _cal.Nature = dr["NATURE"].ToString();
            _cal.Description = dr["DESCRIPTION"].ToString();
            _cal.BranchId = dr["BRANCHID"].ToString();
            return _cal;
        }
        public object MapObjectForEvent(System.Data.DataRow dr)
        {
            OfficialCalender _cal = new OfficialCalender();
            _cal.Title = dr["TITLE"].ToString();
            _cal.Id = long.Parse(dr["ID"].ToString());
            _cal.Date = (dr["DATE"].ToString());
            _cal.Venue = dr["VENUE"].ToString();
            _cal.Description = dr["DESCRIPTION"].ToString();
            _cal.BranchId = dr["BRANCHID"].ToString();
            return _cal;
        }
        public void DeleteById(long Id,String UserName)
        {            
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from OfficialCalendar' , ' and  ID=''" + Id + "''', '" + UserName + "'");
        }
    }
}
