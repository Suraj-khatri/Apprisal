using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.CompInfo
{
    public class CompanyDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private StringBuilder selectQuery;
        public CompanyDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO COMPANY (COMP_NAME, COMP_SHORT_NAME, COMP_ADDRESS, COMP_ADDRESS2, COMP_PHONE_NO, "
            + "COMP_FAX_NO, COMP_CONTACT_PERSON, COMP_MAP_CODE, COMP_STATUS,COMP_EMAIL,COMP_URL, CREATED_DATE, CREATED_BY, MODIFIED_BY, MODIFIED_DATE "
            + ") VALUES ('CompName', 'COMPSHORTNAME', 'CompAddress', 'Address_2', 'CompPhone', 'CompFax', "
            + " 'ContactPerson', 'CompMapCode', 'CompStatus','ComEmail', 'CompUrl', 'CREATEDDATE', 'CREATEDBY','','')");

            this.updateQuery = new StringBuilder("UPDATE COMPANY SET COMP_NAME='CompName', COMP_SHORT_NAME='ShortName', COMP_ADDRESS='CompAddress',"
            + "COMP_ADDRESS2='Address_2',COMP_PHONE_NO = 'CompPhone', COMP_FAX_NO='CompFax',COMP_CONTACT_PERSON='ContactPerson', "
            + "COMP_MAP_CODE='CompMapCode',COMP_STATUS='CompStatus',COMP_URL='CompUrl',COMP_EMAIL='CompEmail',MODIFIED_BY='MODIFIEDBY',MODIFIED_DATE='MODIFIEDDATE' WHERE COMP_ID=CompId");

            this.selectQuery = new StringBuilder("SELECT COMP_ID, COMP_NAME, COMP_SHORT_NAME, COMP_ADDRESS, COMP_ADDRESS2, COMP_PHONE_NO, COMP_FAX_NO, COMP_CONTACT_PERSON,"
                                + " COMP_MAP_CODE, CASE WHEN COMP_STATUS ='True' THEN 'Active' WHEN COMP_STATUS='False' then 'In Active'  END 'COMP_STATUS' , COMP_URL,COMP_EMAIL FROM COMPANY ");
        }
        public override void Save(object obj)
        {
            CompanyCore company = (CompanyCore)obj;
            this.insertQuery.Replace("CompName", company.Name);
            this.insertQuery.Replace("COMPSHORTNAME", company.Shortname);
            this.insertQuery.Replace("CompAddress", company.Address);
            this.insertQuery.Replace("Address_2", company.Address2);
            this.insertQuery.Replace("CompPhone", company.Phone_no);
            this.insertQuery.Replace("CompFax", company.Fax_no);
            this.insertQuery.Replace("ContactPerson", company.Contact_person);
            this.insertQuery.Replace("CompMapCode", company.Map_code);
            this.insertQuery.Replace("CompStatus", company.Status.ToString());
            this.insertQuery.Replace("CompEmail", company.Email);
            this.insertQuery.Replace("CompUrl", company.Url);
            this.insertQuery.Replace("CREATEDBY", company.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", company.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());
        }

        public override void Update(object obj)
        {
            CompanyCore company = (CompanyCore)obj;
            this.updateQuery.Replace("CompId", company.Id.ToString());
            this.updateQuery.Replace("CompName", company.Name);
            this.updateQuery.Replace("ShortName", company.Shortname);
            this.updateQuery.Replace("CompAddress", company.Address);
            this.updateQuery.Replace("Address_2", company.Address2);
            this.updateQuery.Replace("CompPhone", company.Phone_no);
            this.updateQuery.Replace("CompFax", company.Fax_no);
            this.updateQuery.Replace("ContactPerson", company.Contact_person);
            this.updateQuery.Replace("CompMapCode", company.Map_code);
            this.updateQuery.Replace("CompStatus", company.Status.ToString());
            this.updateQuery.Replace("CompEmail", company.Email);
            this.updateQuery.Replace("CompUrl", company.Url);
            this.updateQuery.Replace("MODIFIEDBY", company.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", company.ModifyDate.ToString());
            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<CompanyCore> Findall()
        {
            DataTable dt = SelectByQuery(this.selectQuery.ToString());
            List<CompanyCore> company = new List<CompanyCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CompanyCore Comp = (CompanyCore)this.MapObject(dr);
                    company.Add(Comp);
                }
            }
            return company;
        }
        public CompanyCore FindById(string Id)
        {
            string sSql = this.selectQuery.Append(" WHERE COMP_ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            CompanyCore _company = null;
            if (dt != null)
                _company = (CompanyCore)this.MapObject(dt.Rows[0]);
            return _company;
        }
        public List<CompanyCore> Findall(string CompAddress)
        {
            string sSql = this.selectQuery.Append(" WHERE COMP_ADDRESS LIKE '" + CompAddress + "%' ").ToString();
            DataTable dt = SelectByQuery(sSql);
            List<CompanyCore> company = new List<CompanyCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CompanyCore Comp = (CompanyCore)this.MapObject(dr);
                    company.Add(Comp);
                }
            }
            return company;
        }
        public CompanyCore FindCompany()
        {
            string sSql = ("SELECT COMP_NAME, COMP_ADDRESS FROM Company").ToString();
            DataTable dt = SelectByQuery(sSql);
            CompanyCore _company = null;
            if (dt != null)
                _company = (CompanyCore)this.MapCompany(dt.Rows[0]);
            return _company;
        }
        public object MapCompany(DataRow dr)
        {
            CompanyCore comp = new CompanyCore();
            comp.Name = dr["COMP_NAME"].ToString();
            comp.Address = dr["COMP_ADDRESS"].ToString();
            return comp;
        }
        public override object MapObject(DataRow dr)
        {
            CompanyCore comp = new CompanyCore();
            comp.Id = dr["COMP_ID"].ToString();
            comp.Name = dr["COMP_NAME"].ToString();
            comp.Shortname = dr["COMP_SHORT_NAME"].ToString();
            comp.Address = dr["COMP_ADDRESS"].ToString();
            comp.Address2 = dr["COMP_ADDRESS2"].ToString();
            comp.Phone_no = dr["COMP_PHONE_NO"].ToString();
            comp.Fax_no = dr["COMP_FAX_NO"].ToString();
            comp.Contact_person = dr["COMP_CONTACT_PERSON"].ToString();
            comp.Map_code = dr["COMP_MAP_CODE"].ToString();
            comp.Status = dr["COMP_STATUS"].ToString();
            comp.Url = dr["COMP_URL"].ToString();
            comp.Email = dr["COMP_EMAIL"].ToString();
            return comp;
        }
    }
}