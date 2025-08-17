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
    public class WFCustomerDAO : BaseDAO
    {

        public CustomerCore GetCustomerDetailByID(long id)
        {
            
            string sSql = " SELECT [ID],[CUSTOMERCODE],[CUSTOMERNAME],[CUSTOMERADDRESS],[CUSTOMERTELNO],[CUSTOMERTELNOSEC],[CUSTOMERMOBILENO],[CUSTOMEFAX]"
                          + "  ,[CONTACTPERSONFIRST],[CONTACTPERSONMOBILE1],[CONTACTPERSONEMAIL1],[CONTACTPERSONSEC],[CONTACTPERSONMOBILE2]"
                          + " ,[CONTACTPERSONEMAIL2],[CONTACTPERSONTHIRD],[CONTACTPERSONMOBILE3],[CONTACTPERSONEMAIL3],[CUSTOMEREMAIL]"
                          + " ,[CUSTOMERWEBSITE],[BUSINESSDETAILS],[FACILITYDETAILS],[CREATEDDATE],[CREATEDBY] FROM [WF_CUSTOMER] WHERE ID = "+ id +"";

            DataTable dt = SelectByQuery(sSql);
            CustomerCore _custCore = null;
            if (dt != null)
                _custCore = (CustomerCore)this.MapObject(dt.Rows[0]);

            return _custCore;
        
        }

        public override object MapObject(DataRow dr)
        {
            CustomerCore _custCore = new CustomerCore();
            _custCore.Id = long.Parse(dr["ID"].ToString());
            _custCore.CustomerCode = dr["CUSTOMERCODE"].ToString();
            _custCore.CustomerName = dr["CUSTOMERNAME"].ToString();
            _custCore.CustomerAddress = dr["CUSTOMERADDRESS"].ToString();
            _custCore.CustomerTelNo = dr["CUSTOMERTELNO"].ToString();
            _custCore.CustomerTelNoSec = dr["CUSTOMERTELNOSEC"].ToString();
            _custCore.CustomerMobileNo = dr["CUSTOMERMOBILENO"].ToString();
            _custCore.CustomeFax = dr["CUSTOMEFAX"].ToString();
            _custCore.ContactPersonFirst = dr["CONTACTPERSONFIRST"].ToString();
            _custCore.ContactPersonSec = dr["CONTACTPERSONSEC"].ToString();
            _custCore.ContactPersonThird = dr["CONTACTPERSONTHIRD"].ToString();
            _custCore.CustomerEmail = dr["CUSTOMEREMAIL"].ToString();
            _custCore.CustomerWebsite = dr["CUSTOMERWEBSITE"].ToString();
            _custCore.BusinessDetails = dr["BUSINESSDETAILS"].ToString();
            _custCore.FacilityDetails = dr["FACILITYDETAILS"].ToString();
            _custCore.ContPersonMobile1 = dr["CONTACTPERSONMOBILE1"].ToString();
            _custCore.ContPersonMobile2 = dr["CONTACTPERSONMOBILE2"].ToString();
            _custCore.ContPersonMobile3 = dr["CONTACTPERSONMOBILE3"].ToString();
            _custCore.ContPersonEmail1 = dr["CONTACTPERSONEMAIL1"].ToString();
            _custCore.ContPersonEmail2 = dr["CONTACTPERSONEMAIL2"].ToString();
            _custCore.ContPersonEmail3 = dr["CONTACTPERSONEMAIL3"].ToString();

            //_custCore.CreatedDate = DateTime.Parse(dr["CREATEDDATE"].ToString());
            _custCore.CreatedBy = dr["CREATEDBY"].ToString();
            return _custCore;

        }

        public override void Save(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;
                        
            String sSql = ("exec PROCINSERTUPDATECUSTOMER '" + custCore.Id + "','" + custCore.CustomerCode + "','" + custCore.CustomerName + "','" + custCore.CustomerAddress + "','" + custCore.CustomerTelNo + "','" + custCore.CustomerTelNoSec + "',"
                          + "'" + custCore.CustomerMobileNo + "','" + custCore.CustomeFax + "','" + custCore.ContactPersonFirst + "','" + custCore.ContactPersonSec + "',"
                          + "'" + custCore.ContactPersonThird + "','" + custCore.CustomerEmail + "','" + custCore.CustomerWebsite + "','" + custCore.BusinessDetails + "','" + custCore.FacilityDetails + "',"
                          + "'" + custCore.ContPersonMobile1 + "','" + custCore.ContPersonMobile2 + "','" + custCore.ContPersonMobile3 + "',"
                          + "'" + custCore.ContPersonEmail1 + "','" + custCore.ContPersonEmail2 + "','" + custCore.ContPersonEmail3 + "','" + "I" + "'".ToString());


            ExecuteUpdateProcedure(sSql);


        }

        public void Delete(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;

            String sSql = ("exec PROCINSERTUPDATECUSTOMER '" + custCore.Id + "','" + custCore.CustomerCode + "','" + custCore.CustomerName + "','" + custCore.CustomerAddress + "','" + custCore.CustomerTelNo + "','" + custCore.CustomerTelNoSec + "',"
                          + "'" + custCore.CustomerMobileNo + "','" + custCore.CustomeFax + "','" + custCore.ContactPersonFirst + "','" + custCore.ContactPersonSec + "',"
                          + "'" + custCore.ContactPersonThird + "','" + custCore.CustomerEmail + "','" + custCore.CustomerWebsite + "','" + custCore.BusinessDetails + "','" + custCore.FacilityDetails + "',"
                          + "'" + custCore.ContPersonMobile1 + "','" + custCore.ContPersonMobile2 + "','" + custCore.ContPersonMobile3 + "',"
                          + "'" + custCore.ContPersonEmail1 + "','" + custCore.ContPersonEmail2 + "','" + custCore.ContPersonEmail3 + "','" + "D" + "'".ToString());


            ExecuteUpdateProcedure(sSql);
        }



        public override void Update(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;
            
            String sSql = ("exec PROCINSERTUPDATECUSTOMER '" + custCore.Id + "','" + custCore.CustomerCode + "','" + custCore.CustomerName + "','" + custCore.CustomerAddress + "','" + custCore.CustomerTelNo + "','" + custCore.CustomerTelNoSec + "',"
                          + "'" + custCore.CustomerMobileNo + "','" + custCore.CustomeFax + "','" + custCore.ContactPersonFirst + "','" + custCore.ContactPersonSec + "',"
                          + "'" + custCore.ContactPersonThird + "','" + custCore.CustomerEmail + "','" + custCore.CustomerWebsite + "','" + custCore.BusinessDetails + "','" + custCore.FacilityDetails + "',"
                          + "'" + custCore.ContPersonMobile1 + "','" + custCore.ContPersonMobile2 + "','" + custCore.ContPersonMobile3 + "',"
                          + "'" + custCore.ContPersonEmail1 + "','" + custCore.ContPersonEmail2 + "','" + custCore.ContPersonEmail3 + "','" + "U" + "'".ToString());

            ExecuteUpdateProcedure(sSql);
        }
    }
}
