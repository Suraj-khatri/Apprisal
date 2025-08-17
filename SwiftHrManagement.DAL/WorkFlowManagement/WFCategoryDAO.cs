using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.DAL.WorkFlowManagement
{
    public class WFCategoryDAO : BaseDAO
    {

        public WFCategoryCore FindByCatId(long Id)
        {

            string sSql = "SELECT WF_CATEGORYID,WF_DeptName, WF_CATNAME,WF_CATDETAILS,CREATEDBY,"
                               + " CONVERT(VARCHAR,CREATEDDATE,101) AS CREATEDDATE FROM WF_CATEGORY WHERE WF_CATEGORYID = " + Id + "";
            
                DataTable dt = SelectByQuery(sSql);
                WFCategoryCore _wFCat = null;
                if (dt != null)
                    _wFCat = (WFCategoryCore)this.MapObject(dt.Rows[0]);
         
            return _wFCat;
        }

        public WFCategoryCore GetCaogoryNameByMemID(long Id)
        {
            
            string sSql = " SELECT WF_CATNAME,WF_CATDETAILS FROM WF_MEMBER M"
                          + " INNER JOIN  WF_CATEGORY C ON C.WF_CATEGORYID = M.WF_CATEGORYID  WHERE M.WF_MEMBERID = " + Id + "";

            DataTable dt = SelectByQuery(sSql);

            WFCategoryCore _wFCat = null;

            if(dt != null)
                _wFCat = (WFCategoryCore)this.MapCatDetails(dt.Rows[0]);  
          
            return _wFCat;
        }

        public WFCategoryCore GetCaogoryNameByCatID(long Id)
        {

            string sSql = "SELECT WF_CATNAME,WF_CATDETAILS FROM WF_CATEGORY WHERE WF_CATEGORYID = " + Id + "";                         

            DataTable dt = SelectByQuery(sSql);

            WFCategoryCore _wFCat = null;

            if (dt != null)
                _wFCat = (WFCategoryCore)this.MapCatDetails(dt.Rows[0]);

            return _wFCat;
        }

        public object MapCatDetails(DataRow dr)
        {
            WFCategoryCore _wfCatCore = new WFCategoryCore();
            _wfCatCore.WFCatName = dr["WF_CATNAME"].ToString();
            _wfCatCore.WFCatDetails = dr["WF_CATDETAILS"].ToString();
            return _wfCatCore;
        }


        public override object MapObject(DataRow dr)
        {
            WFCategoryCore _wfCatCore = new WFCategoryCore();
            _wfCatCore.WFCategoryID = long.Parse(dr["WF_CATEGORYID"].ToString());
            _wfCatCore.WFDept = dr["WF_DeptName"].ToString();
            _wfCatCore.WFCatName = dr["WF_CATNAME"].ToString();
            _wfCatCore.WFCatDetails = dr["WF_CATDETAILS"].ToString();
            _wfCatCore.CreatedBy = dr["CREATEDBY"].ToString();
            _wfCatCore.CreatedDate = DateTime.Parse(dr["CREATEDDATE"].ToString());
            return _wfCatCore;

        }

        public override void Save(object obj)
        {            
            WFCategoryCore _catCore = (WFCategoryCore)obj;
            String sSql = ("exec procInsertUpdateWorkFlowCat '" + _catCore.WFCategoryID + "'," + filterstring(_catCore.WFCatName.ToString()) + ","
            + " " + filterstring(_catCore.WFCatDetails) + "," + filterstring(_catCore.CreatedBy.ToString()) + ",'I',"+filterstring(_catCore.WFDept)+"".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public void Delete(Object obj)
        {
            WFCategoryCore _catCore = (WFCategoryCore)obj;
            String sSql = ("exec procInsertUpdateWorkFlowCat '" + _catCore.WFCategoryID + "',@Mode='" + "D" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public override void Update(object obj)
        {
            WFCategoryCore _catCore = (WFCategoryCore)obj;
            String sSql = ("exec procInsertUpdateWorkFlowCat '" + _catCore.WFCategoryID + "'," + filterstring(_catCore.WFCatName.ToString()) + ", "
            + " " + filterstring(_catCore.WFCatDetails) + "," + filterstring(_catCore.CreatedBy.ToString()) + ",'U'," + filterstring(_catCore.WFDept) + "".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        
    }
}
