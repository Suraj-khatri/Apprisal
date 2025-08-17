using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL.StaticDataDetailsDAO;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;


namespace SwiftHrManagement.DAL.StaticDataDetailsDAO
{
    public class StaticDataDetailsDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public StaticDataDetailsDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO StaticDataDetail (TYPE_ID,DETAIL_TITLE, DETAIL_DESC, CREATED_BY, CREATED_DATE,IS_DELETE,applyOT) "
                + " VALUES ('TYPEID','DETAILTITLE','DETAILDESC','CREATEDBY','CREATEDDATE',NULL,'APPLYOT')");
            //this.updateQuery = new StringBuilder("UPDATE StaticDataDetail SET TYPE_ID='TYPEID',DETAIL_TITLE='DETAILTITLE',DETAIL_DESC='DETAILDESC',"
            //+" MODIFIED_BY='MODIFIEDBY', MODIFIED_DATE='MODIFIEDDATE' where ROWID='_ROWID'");
            this.updateQuery = new StringBuilder("EXEC ProcStaticDataView 'u',@rowid=_ROWID,@DETAIL_TITLE=DETAILTITLE,@DETAIL_DESC=DETAILDESC,@user=MODIFIEDBY,@applyOT=APPLYOT");
        }
        public override void Save(object obj)
        {
            StaticDataDetailCore _dataDetailCore = (StaticDataDetailCore)obj;     
            this.insertQuery.Replace("TYPEID", _dataDetailCore.Type_id.ToString());
            this.insertQuery.Replace("DETAILTITLE", _dataDetailCore.Detail_title);
            this.insertQuery.Replace("DETAILDESC", _dataDetailCore.Detail_desc);
            this.insertQuery.Replace("APPLYOT", _dataDetailCore.Apply_OT);
            this.insertQuery.Replace("CREATEDBY", _dataDetailCore.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", _dataDetailCore.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());       
        }
        public override void Update(object obj)
        {
            StaticDataDetailCore _dataDetailCore = (StaticDataDetailCore)obj;
            this.updateQuery.Replace("_ROWID", filterstring(_dataDetailCore.Id.ToString()));
            this.updateQuery.Replace("DETAILTITLE", filterstring(_dataDetailCore.Detail_title));
            this.updateQuery.Replace("DETAILDESC",filterstring( _dataDetailCore.Detail_desc));
            this.updateQuery.Replace("APPLYOT", filterstring(_dataDetailCore.Apply_OT));
            this.updateQuery.Replace("MODIFIEDBY",filterstring( _dataDetailCore.ModifyBy.ToString()));
            ExecuteQuery(this.updateQuery.ToString());
        }
        public List<StaticDataDetailCore> FindAll(long id)
        {
            string sSql = "SELECT ROWID,TYPE_ID,DETAIL_TITLE,DETAIL_DESC,applyOT"
                + " FROM StaticDataDetail where  TYPE_ID='"+id+"'";
            DataTable dt = SelectByQuery(sSql);

            List<StaticDataDetailCore> dataDetail = new List<StaticDataDetailCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    StaticDataDetailCore _dataDetail = (StaticDataDetailCore)this.MapObject(dr);
                    dataDetail.Add(_dataDetail);
                }
            }
            return dataDetail;
        }
        public StaticDataDetailCore FindById(long Id)
        {
            string sSql = "SELECT ROWID,TYPE_ID,DETAIL_TITLE,DETAIL_DESC,applyOT FROM StaticDataDetail WHERE ROWID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            StaticDataDetailCore _datadetailcore = null;
            if (dt != null)
                _datadetailcore = (StaticDataDetailCore)this.MapObject(dt.Rows[0]);
            return _datadetailcore;
        }
        public StaticDataDetailCore FindPositionHierarchy(String position)
        {
            string sSql = "SELECT DETAIL_DESC FROM  StaticDataDetail WHERE (TYPE_ID = 4) AND (DETAIL_TITLE = '"+ position +"')";
            DataTable dt = SelectByQuery(sSql);
            StaticDataDetailCore _datadetailcore = null;
            if (dt != null)
                _datadetailcore = (StaticDataDetailCore)this.MapObjectforPosition(dt.Rows[0]);
            return _datadetailcore;
        }
        public  object MapObjectforPosition(DataRow dr)
        {
            StaticDataDetailCore s_dataDetail = new StaticDataDetailCore();
            s_dataDetail.Detail_desc = (dr["DETAIL_DESC"].ToString());          
            return s_dataDetail;
        }
        public override object MapObject(DataRow dr)
        {
            StaticDataDetailCore s_dataDetail = new StaticDataDetailCore();
            s_dataDetail.Id = long.Parse(dr["ROWID"].ToString());
            s_dataDetail.Type_id = dr["TYPE_ID"].ToString();
            s_dataDetail.Detail_title = dr["DETAIL_TITLE"].ToString();
            s_dataDetail.Detail_desc = dr["DETAIL_DESC"].ToString();
            s_dataDetail.Apply_OT = dr["applyOT"].ToString();
            return s_dataDetail;
        }
        public StaticDataDetailCore FindByRowId(long Id)
        {
            string sSql = "select d.ROWID,D.TYPE_ID,TYPE_TITLE,d.DETAIL_DESC,d.DETAIL_TITLE,applyOT from StaticDataDetail d inner join "
            + " StaticDataType t on t.ROWID=d.TYPE_ID where d.ROWID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            StaticDataDetailCore _empedu = null;
            if (dt != null)
                _empedu = (StaticDataDetailCore)this.MapObjDetail(dt.Rows[0]);
            return _empedu;
        }
        public object MapObjDetail(DataRow dr)
        {
            StaticDataDetailCore s_dataDetail = new StaticDataDetailCore();
            s_dataDetail.Id = long.Parse(dr["ROWID"].ToString());
            s_dataDetail.Type_id = dr["TYPE_ID"].ToString();
            s_dataDetail.Type_Title = dr["TYPE_TITLE"].ToString();
            s_dataDetail.Detail_desc = dr["DETAIL_DESC"].ToString();
            s_dataDetail.Detail_title = dr["DETAIL_TITLE"].ToString();
            s_dataDetail.Apply_OT = dr["applyOT"].ToString();
            return s_dataDetail;
        }

        public void DeleteById(long Id, String userName)
        {
            ExecuteQuery("Exec ProcStaticDataView 'd',@rowid=" + filterstring(Id.ToString()));
        }
    }
}
