using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.CMS_Management
{
    public class CMSDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private StringBuilder selectQuery;
        public CMSDAO()
        {
            this.insertQuery = new StringBuilder("");
            this.updateQuery = new StringBuilder("");
            this.selectQuery = new StringBuilder("");
        }
        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }
        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
        public CMSCore FindById(long Id)
        {
            string sSql = "Select id,func_name,created_date,create_by from CMS_functions where id=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            CMSCore _cmscore = null;
            if (dt != null)
                _cmscore = (CMSCore)this.MapObject(dt.Rows[0]);
            return _cmscore;
        }
        public DataSet FindAllById(long Id)
        {
            String sSql = ("select id,func_id,menu_name,menu_desc,linked_id,created_by,create_date,display_flag from CMS_Menu where id='"+Id+"'");
            //String sSql = ("select id,func_id,menu_name,menu_desc,linked_id,created_by,create_date,menu_type from CMS_Menu where id='" + Id + "'");
            return ReturnDataset(sSql);
        }
        public DataSet FindPageDetailsByID(long Id)
        {
            String sSql = ("Select id,func_type,func_name,func_head,func_detail,created_date,create_by from CMS_functions where id=" + Id + "");
            return ReturnDataset(sSql);
        }
        public DataSet FindPageByID(long Id)
        {
            string type = GetSingleresult("select func_type from CMS_functions where id=" + Id + "");
            string query = "";
            string query1="";
            string sSql="";
            if (type == "Query")
            {
                query1 = "select  func_type,func_head  from CMS_functions where id=" + Id + "";
                query = filterPageContent(GetSingleresult("select func_detail from CMS_functions where id=" + Id + ""));
                sSql = query1 + ';' + query;
            }
            else
            {
                sSql = ("exec ManageCMSPageList @func_id='" + Id + "'");
            }
            return ReturnDataset(sSql);
        }
        public DataSet FindNotice()
        {
            String sSql = ("select func_head from CMS_functions where id in (select func_id from CMS_Menu where linked_id=21)");
            return ReturnDataset(sSql);
        }
        public DataSet FindNoticeByID(long Id)
        {
            String sSql = ("exec ManageCMSPageList @func_id='" + Id + "'");
            return ReturnDataset(sSql);
        }
        public DataSet FindAllMenus(string displayFlag)
        {
            String sSql = ("exec ProcDisplayMenu @flag=" + filterstring(displayFlag) + "");
            return ReturnDataset(sSql);
        }

        public override object MapObject(DataRow dr)
        {
            CMSCore cms = new CMSCore();
            cms.Id = long.Parse(dr["id"].ToString());
            cms.FuncName = dr["func_name"].ToString();
            cms.CreatedDate = DateTime.Parse(dr["created_date"].ToString());
            cms.CreatedBy = dr["create_by"].ToString();
            return cms;
        }
        public void DeleteById(long Id, String userName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from CMS_functions' , ' and  id=''" + Id + "''', '" + userName + "'");
        }
        public void DeleteMenuById(long Id, String userName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from CMS_Menu' , ' and  id=''" + Id + "''', '" + userName + "'");
        }
    }
}
