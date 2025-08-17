using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.BranchDao
{
    public class BranchDao : BaseDAOInv
    {

        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private StringBuilder selectQuery;
        
        public BranchDao()
        {
            this.insertQuery = new StringBuilder("INSERT INTO BRANCHES"
                + "(BRANCH_NAME,BRANCH_SHORT_NAME,BRANCH_ADDRESS, BRANCH_PHONE,BRANCH_MOBILE,BRANCH_EMAIL,BRANCH_FAX,BRANCH_COUNTRY,BRANCH_ZONE,BRANCH_DISTRICT,CONTACT_PERSON,CREATED_BY,CREATED_DATE)"
              + "VALUES('name','b_short_name','address','phone','mobile','email','fax','country','zone','district','contactperson','CREATEDBY','CREATEDDATE')");

            this.updateQuery = new StringBuilder("UPDATE BRANCHES SET BRANCH_NAME='b_name',BRANCH_SHORT_NAME='b_short_name',BRANCH_ADDRESS='b_address', BRANCH_PHONE='b_phone',"
                + " BRANCH_MOBILE='b_mobile',BRANCH_EMAIL='b_email',BRANCH_FAX='b_fax',BRANCH_COUNTRY='b_country',BRANCH_ZONE='b_zone',BRANCH_DISTRICT='b_district',"
                + " CONTACT_PERSON='contact_b_person', MODIFIED_DATE='mdate', MODIFIED_BY='mby' WHERE BRANCH_ID = 'b_Id'");

            this.selectQuery = new StringBuilder("SELECT BRANCH_ID,BRANCH_NAME,BRANCH_SHORT_NAME,BRANCH_ADDRESS, BRANCH_PHONE,BRANCH_MOBILE,BRANCH_EMAIL,"
                + "BRANCH_FAX,BRANCH_COUNTRY,BRANCH_ZONE,BRANCH_DISTRICT,CONTACT_PERSON FROM BRANCHES");
        }

        public override void Save(object obj)
        {
            BranchCore branch = (BranchCore)obj;
            this.insertQuery.Replace("name", branch.Name);
            this.insertQuery.Replace("b_short_name", branch.Branchshortname);
            this.insertQuery.Replace("address", branch.Address);
            this.insertQuery.Replace("phone", branch.Phone);
            this.insertQuery.Replace("mobile", branch.Mobile);
            this.insertQuery.Replace("email", branch.Email);
            this.insertQuery.Replace("fax", branch.Fax);
            this.insertQuery.Replace("country", branch.Country);
            this.insertQuery.Replace("group",branch.Group);
            this.insertQuery.Replace("zone", branch.Zone);
            this.insertQuery.Replace("district", branch.District);            
            this.insertQuery.Replace("contactperson", branch.ContactPerson);       
            this.insertQuery.Replace("CREATEDBY", branch.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", branch.CreatedDate.ToString());

            //this.insertQuery.Replace("stock_Ac", branch.StockAc.ToString());
            //this.insertQuery.Replace("expenses_Ac", branch.ExpAc);
            //this.insertQuery.Replace("transit_Ac", branch.TransitAc.ToString());
            //this.insertQuery.Replace("isDirect_Exp", branch.IsDirectExp);


            ExecuteQuery(this.insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            BranchCore branch = (BranchCore)obj;
            BaseDomain basedomain = (BaseDomain)obj;
            this.updateQuery.Replace("'b_Id'", branch.Id.ToString());
            this.updateQuery.Replace("b_name", branch.Name);
            this.updateQuery.Replace("b_short_name", branch.Branchshortname);
            this.updateQuery.Replace("b_address", branch.Address);
            this.updateQuery.Replace("b_phone", branch.Phone);
            this.updateQuery.Replace("b_mobile", branch.Mobile);
            this.updateQuery.Replace("b_email", branch.Email);
            this.updateQuery.Replace("b_fax", branch.Fax);
            this.updateQuery.Replace("b_country", branch.Country);
            this.updateQuery.Replace("b_group", branch.Group);
            this.updateQuery.Replace("b_zone", branch.Zone);
            this.updateQuery.Replace("b_district", branch.District);
            this.updateQuery.Replace("contact_b_person", branch.ContactPerson);
            this.updateQuery.Replace("mdate", basedomain.ModifyDate.ToString());
            this.updateQuery.Replace("mby", basedomain.ModifyBy.ToString());
            //this.updateQuery.Replace("stock_Ac", branch.StockAc.ToString());
            //this.updateQuery.Replace("expenses_Ac", branch.ExpAc);
            //this.updateQuery.Replace("transit_Ac", branch.TransitAc.ToString());
            //this.updateQuery.Replace("isDirect_Exp", branch.IsDirectExp);

            ExecuteQuery(this.updateQuery.ToString());
        }
        public BranchCore FindBranchByName(String Name)
        {
            string sSql = "SELECT BRANCH_ID FROM Branches WHERE BRANCH_NAME ='" + Name + "'";
            DataTable dt = SelectByQuery(sSql);
            BranchCore _branch = null;
            if (dt.Rows.Count != 0)
                _branch = (BranchCore)this.MapbranchId(dt.Rows[0]);
            return _branch;
        }
        public object MapbranchId(DataRow dr)
        {
            BranchCore branch = new BranchCore();
            branch.Id = dr["BRANCH_ID"].ToString();
            return branch;
        }
        public List<BranchCore> Findall()
        {
            string sSql = "SELECT BRANCH_ID,BRANCH_NAME,BRANCH_ADDRESS,BRANCH_PHONE,BRANCH_EMAIL,CONTACT_PERSON,stockAc,expensesAc,transitAc,isDirectExp FROM Branches";
            DataTable dt = SelectByQuery(sSql);
            List<BranchCore> branch = new List<BranchCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BranchCore _branch = (BranchCore)this.MapObject(dr);
                    branch.Add(_branch);
                }
            }
            return branch;
        }
        public List<BranchCore> FindBranchName()
        {
            string sSql = "SELECT BRANCH_ID,BRANCH_NAME FROM Branches";
            DataTable dt = SelectByQuery(sSql);
            List<BranchCore> branch = new List<BranchCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BranchCore _branch = (BranchCore)this.MapObjectforDdl(dr);
                    branch.Add(_branch);
                }
            }
            return branch;
        }
        public object MapObjectforDdl(DataRow dr)
        {
            BranchCore branch = new BranchCore();
            branch.Id = dr["BRANCH_ID"].ToString();
            branch.Name = dr["BRANCH_NAME"].ToString();         
            return branch;
        }

        public List<BranchCore> FindAll()
        {
            DataTable dt = SelectByQuery(this.selectQuery.ToString());
            List<BranchCore> branches = new List<BranchCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BranchCore branch = (BranchCore)this.MapObject(dr);
                    branches.Add(branch);
                }
            }
            return branches;
        }
        public List<BranchCore> FindRecordByFilter(string searcbybranchname, string branchaddress)
        {
            
                string sSql = "SELECT BRANCH_ID,BRANCH_NAME,BRANCH_SHORT_NAME,BRANCH_ADDRESS,BRANCH_PHONE,"
                       + " BRANCH_MOBILE,BRANCH_FAX,BRANCH_EMAIL,BRANCH_COUNTRY,BRANCH_ZONE,BRANCH_DISTRICT,"
                       + " CONTACT_PERSON," +
                       //"stockAc,expensesAc,transitAc,isDirectExp" +
                       " FROM Branches with (nolock) WHERE 1=1 ";                   
                
               if (searcbybranchname != "")
                    {
                        sSql = sSql + " AND BRANCH_NAME LIKE '" + searcbybranchname + "%'";
               }

                if (branchaddress != "")
                    {
                        sSql = sSql + " AND BRANCH_ADDRESS LIKE '" + branchaddress + "%'";
               }

                DataTable dt = SelectByQuery(sSql);
                List<BranchCore> branch = new List<BranchCore>();
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BranchCore branches = (BranchCore)this.MapObject(dr);
                        branch.Add(branches);
                    }
                }
                return branch;
             
        }

       
        public BranchCore FindById(string Id)
        {
            string sSql = this.selectQuery.Append(" WHERE BRANCH_ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            BranchCore _branch = null;
            if (dt.Rows.Count != 0)
                _branch = (BranchCore)this.MapObject(dt.Rows[0]);
            return _branch;
        }
        public override object MapObject(DataRow dr)
        {
            BranchCore branch = new BranchCore();
            branch.Id = dr["BRANCH_ID"].ToString();
            branch.Name = dr["BRANCH_NAME"].ToString();
            branch.Branchshortname = dr["BRANCH_SHORT_NAME"].ToString();
            branch.Address = dr["BRANCH_ADDRESS"].ToString();
            branch.Phone = dr["BRANCH_PHONE"].ToString();
            branch.Email = dr["BRANCH_EMAIL"].ToString();
            branch.Mobile = dr["BRANCH_MOBILE"].ToString();
            branch.Fax = dr["BRANCH_FAX"].ToString();
            branch.Country = dr["BRANCH_COUNTRY"].ToString();
            branch.Zone = dr["BRANCH_ZONE"].ToString();
            branch.District = dr["BRANCH_DISTRICT"].ToString();
            branch.ContactPerson = dr["CONTACT_PERSON"].ToString();
            //branch.StockAc = dr["stockAc"].ToString();
            //branch.ExpAc = dr["expensesAc"].ToString();
            //branch.TransitAc = dr["transitAc"].ToString();
            //branch.IsDirectExp = dr["isDirectExp"].ToString();


            return branch;
        }
    }
}
