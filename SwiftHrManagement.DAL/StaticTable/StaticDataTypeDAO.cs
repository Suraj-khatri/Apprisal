using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL.StaticDataTypeDAO;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.StaticDataTypeDAO
{     
    public class StaticDataTypeDAO:BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        public StaticDataTypeDAO()
        {
            this.insertQuery = new StringBuilder("");

            this.updateQuery = new StringBuilder("");
        }
        public override void Save(object obj)
        {
            //EmployeeEducation empedu = (EmployeeEducation)obj;
            //this.insertQuery.Replace("EMPLOYEEID", empedu.Id.ToString());
            //this.insertQuery.Replace("LE_VELS", empedu.Levels);
            //this.insertQuery.Replace("DE_GREE", empedu.Degree);
            //this.insertQuery.Replace("FE_CULTY", empedu.Fecaulty);
            //this.insertQuery.Replace("DIV_ISION", empedu.Division);
            //this.insertQuery.Replace("PER_CENTAGE", empedu.Percentage);
            //this.insertQuery.Replace("PASSEDYEAR", empedu.Passedyear);
            //this.insertQuery.Replace("NAMEOFINSTITUTION", empedu.Nameofintitution);
            //this.insertQuery.Replace("COUNTRYNAME", empedu.Countyname);
            //this.insertQuery.Replace("CREATEDBY", empedu.CreatedBy.ToString());
            //this.insertQuery.Replace("CREATEDDATE", empedu.CreatedDate.ToString());
            //ExecuteQuery(this.insertQuery.ToString());
            ////throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            //EmployeeEducation emped = (EmployeeEducation)obj;
            //this.updateQuery.Replace("EMPID", emped.Id.ToString());
            //this.updateQuery.Replace("LEV_ELS", emped.Levels);
            //this.updateQuery.Replace("DEGR_EE", emped.Degree);
            //this.updateQuery.Replace("FECU_LTY", emped.Fecaulty);
            //this.updateQuery.Replace("DI_VISION", emped.Division);
            //this.updateQuery.Replace("PERCENTAG_E", emped.Percentage);
            //this.updateQuery.Replace("PASS_EDYEAR", emped.Passedyear);
            //this.updateQuery.Replace("NAME_OFINSTITUTION", emped.Nameofintitution);
            //this.updateQuery.Replace("COUNTRYN_AME", emped.Countyname);
            //this.updateQuery.Replace("MODIFIEDBY", emped.ModifyBy.ToString());
            //this.updateQuery.Replace("MODIFIEDDATE", emped.ModifyDate.ToString());
            //ExecuteQuery(this.updateQuery.ToString());
            ////throw new NotImplementedException();
        }
        public List<StaticDataTypeCore> FindAll()
        {
            string sSql = "SELECT ROWID, TYPE_TITLE, TYPE_DESC"
                + " FROM StaticDataType ";
            DataTable dt = SelectByQuery(sSql);

            List<StaticDataTypeCore> staticType = new List<StaticDataTypeCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    StaticDataTypeCore _staticType = (StaticDataTypeCore)this.MapObject(dr);
                    staticType.Add(_staticType);
                }
            }
            return staticType;
        }
        public List<StaticDataTypeCore> FindAllByField(string typeTitle)
        {
            string sSql = "SELECT ROWID, TYPE_TITLE, TYPE_DESC"
                + " FROM StaticDataType where TYPE_TITLE like '"+typeTitle+"%'";
            DataTable dt = SelectByQuery(sSql);

            List<StaticDataTypeCore> staticType = new List<StaticDataTypeCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    StaticDataTypeCore _staticType = (StaticDataTypeCore)this.MapObject(dr);
                    staticType.Add(_staticType);
                }
            }
            return staticType;
        }
        public StaticDataTypeCore FindByTypeId(long Id)
        {
            string sSql = "SELECT ROWID,TYPE_TITLE FROM StaticDataType WHERE ROWID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            StaticDataTypeCore _empedu = null;
            if (dt != null)
                _empedu = (StaticDataTypeCore)this.MapObj(dt.Rows[0]);
            return _empedu;
        }

        public  object MapObj(DataRow dr)
        {
            StaticDataTypeCore s_dataDetail = new StaticDataTypeCore();
            s_dataDetail.Id = long.Parse(dr["ROWID"].ToString());
            s_dataDetail.Type_title = dr["TYPE_TITLE"].ToString();
            return s_dataDetail;
        }
        public override object MapObject(DataRow dr)
        {
            StaticDataTypeCore s_dataType = new StaticDataTypeCore();
            s_dataType.Id = long.Parse(dr["ROWID"].ToString());
            s_dataType.Type_title = dr["TYPE_TITLE"].ToString();
            s_dataType.Type_desc = dr["TYPE_DESC"].ToString();
            return s_dataType;
        }
    }
}
