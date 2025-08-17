using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.PerformanceAppraisal;

namespace SwiftHrManagement.DAL.PerformanceAppraisal.Detail
{
    public class AppraisalDetailDao : BaseDAO
    {
        private StringBuilder _insertquery;
        private StringBuilder _updateQuery;
        private StringBuilder _selectQuery;
        public AppraisalDetailDao()
        {
            this._insertquery = new StringBuilder("");
            this._updateQuery = new StringBuilder("");
            this._selectQuery = new StringBuilder("SELECT ID, EMPLOYEE_ID,CONVERT(VARCHAR,FROM_DATE,101) AS FROM_DATE,CONVERT(VARCHAR,TO_DATE,101)AS TO_DATE,TITLE, DETAILS FROM APPRAISAL");
        }
        public override void Save(object obj)
        {            
        }
        public override void Update(object obj)
        {
        }
        public AppraisalDetailCore FindbyId(long Id)
        {
            AppraisalDetailCore _appraisalDtlcore = null;
            DataTable dt = SelectByQuery(this._selectQuery.Append(" WHERE ID = " + Id + "").ToString());
            if (dt.Rows.Count != null)
                _appraisalDtlcore = (AppraisalDetailCore)this.MapObject(dt.Rows[0]);
            return _appraisalDtlcore;
        }
        public override object MapObject(DataRow dr)
        {
            AppraisalDetailCore _appraisalDtlCore = new AppraisalDetailCore();
            _appraisalDtlCore.Id = long.Parse(dr["ID"].ToString());
            _appraisalDtlCore.AppraisalOf = dr["EMPLOYEE_ID"].ToString();
            _appraisalDtlCore.From_Date = (dr["FROM_DATE"].ToString());
            _appraisalDtlCore.To_Date = (dr["TO_DATE"].ToString());
            _appraisalDtlCore.Details = (dr["DETAILS"].ToString());
            _appraisalDtlCore.Title = (dr["TITLE"].ToString());
            return _appraisalDtlCore;
        }
        public object MapForName(DataRow dr)
        {
            AppraisalDetailCore _appraisalDtlCore = new AppraisalDetailCore();
            _appraisalDtlCore.Id = long.Parse(dr["ID"].ToString());
            _appraisalDtlCore.AppraisalOf = dr["NAME"].ToString();
            _appraisalDtlCore.From_Date = (dr["FROM_DATE"].ToString());
            _appraisalDtlCore.To_Date = (dr["TO_DATE"].ToString());
            _appraisalDtlCore.Details = (dr["DETAILS"].ToString());
            _appraisalDtlCore.Title = (dr["TITLE"].ToString());
            return _appraisalDtlCore;
        }

        public List<AppraisalDetailCore> FindAll()
        {
            DataTable dt = SelectByQuery("SELECT AP.ID,CONVERT(VARCHAR,AP.FROM_DATE,107) AS FROM_DATE,CONVERT(VARCHAR,AP.TO_DATE,107) AS TO_DATE, AP.TITLE, AP.DETAILS, E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS "
            + " NAME FROM APPRAISAL AS AP, Employee AS E WHERE AP.EMPLOYEE_ID = E.EMPLOYEE_ID");
            List<AppraisalDetailCore> _appraisalDtlCore = new List<AppraisalDetailCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AppraisalDetailCore _appdtllCore = (AppraisalDetailCore)this.MapForName(dr);
                    _appraisalDtlCore.Add(_appdtllCore);
                }
            }
            return _appraisalDtlCore;
        }
        public void DeleteById(long Id, String userName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from APPRAISAL' , ' and  ID=''" + Id + "''', '" + userName + "'");
        }


    }
}
