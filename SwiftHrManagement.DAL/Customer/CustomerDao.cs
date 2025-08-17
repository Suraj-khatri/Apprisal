using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core.DomainInv;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.Customer
{
    public class CustomerDao:BaseDAOInv
    {
        public CustomerCore GetCustomerDetailByID(long id)
        {

            string sSql = " SELECT [ID],[CUSTOMERCODE],[CUSTOMERNAME],[CUSTOMERADDRESS],[CUSTOMERTELNO],[CUSTOMERTELNOSEC],[CustomerPANNo],[CUSTOMEFAX]"
                          + "  ,[CONTACTPERSONFIRST],[CONTACTPERSONMOBILE1],[CONTACTPERSONEMAIL1],[CONTACTPERSONSEC],[CONTACTPERSONMOBILE2]"
                          + " ,[CONTACTPERSONEMAIL2],[CONTACTPERSONTHIRD],[CONTACTPERSONMOBILE3],[CONTACTPERSONEMAIL3],[CUSTOMEREMAIL]"
                          + " ,[CUSTOMERWEBSITE],[BUSINESSDETAILS],[FACILITYDETAILS],[CREATEDDATE],[CREATEDBY],IsActive FROM [CUSTOMER] WHERE ID = " + id + "";

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
            _custCore.CustomerPANNo = dr["CustomerPANNo"].ToString();
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
            _custCore.CreatedBy = dr["CREATEDBY"].ToString();
            if (dr["IsActive"].ToString() == "Y")
            {
                _custCore.IsActive = "Y";
            }
            else
            {
                _custCore.IsActive = "N";
            }
            return _custCore;
        }

        public override void Save(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;

            String sSql = ("exec procManageCustomer '" + custCore.Id + "','" + custCore.CustomerName + "','" + custCore.CustomerAddress + "','" + custCore.CustomerTelNo + "','" + custCore.CustomerTelNoSec + "',"
                          + "'" + custCore.CustomerPANNo + "','" + custCore.CustomeFax + "','" + custCore.ContactPersonFirst + "','" + custCore.ContactPersonSec + "',"
                          + "'" + custCore.ContactPersonThird + "','" + custCore.CustomerEmail + "','" + custCore.CustomerWebsite + "','" + custCore.BusinessDetails + "','" + custCore.FacilityDetails + "',"
                          + "'" + custCore.ContPersonMobile1 + "','" + custCore.ContPersonMobile2 + "','" + custCore.ContPersonMobile3 + "',"
                          + "'" + custCore.ContPersonEmail1 + "','" + custCore.ContPersonEmail2 + "','" + custCore.ContPersonEmail3 + "','" + custCore.CreatedBy + "','" + custCore.CreatedDate + "','I'," + filterstring(custCore.IsActive) + "".ToString());


            ExecuteUpdateProcedure(sSql);
        }
        public void Delete(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;
            
            String sSql = ("exec procManageCustomer @ID=" + filterstring(custCore.Id.ToString()) + ", @MODE ='" + "D" + "'");

            ExecuteUpdateProcedure(sSql);
        }
        public override void Update(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;

            String sSql = ("exec procManageCustomer '" + custCore.Id + "','" + custCore.CustomerName + "','" + custCore.CustomerAddress + "','" + custCore.CustomerTelNo + "','" + custCore.CustomerTelNoSec + "',"
                          + "'" + custCore.CustomerPANNo + "','" + custCore.CustomeFax + "','" + custCore.ContactPersonFirst + "','" + custCore.ContactPersonSec + "',"
                          + "'" + custCore.ContactPersonThird + "','" + custCore.CustomerEmail + "','" + custCore.CustomerWebsite + "','" + custCore.BusinessDetails + "','" + custCore.FacilityDetails + "',"
                          + "'" + custCore.ContPersonMobile1 + "','" + custCore.ContPersonMobile2 + "','" + custCore.ContPersonMobile3 + "',"
                          + "'" + custCore.ContPersonEmail1 + "','" + custCore.ContPersonEmail2 + "','" + custCore.ContPersonEmail3 + "','" + custCore.ModifyBy + "','" + custCore.ModifyDate + "','U'," + filterstring(custCore.IsActive) + "".ToString());

            ExecuteUpdateProcedure(sSql);
        }
        public DataTable GetUploadedFileInfo(String CustID)
        {
            String sSql = ("exec procGetCustomerFileInfo '" + CustID + "'".ToString());
            return ExecuteStoreProcedure(sSql);
        }

        public void SaveUploadedFiles(object obj)
        {
            CustomerFileCore _custFileCore = (CustomerFileCore)obj;
            String sSql = ("exec procUploadCustFileHistory '" + _custFileCore.DocId + "','" + _custFileCore.CustID + "','" + _custFileCore.DocName + "',"
                           + "'" + _custFileCore.DocDesciption + "','" + _custFileCore.FileExtn + "','" + _custFileCore.CreatedBy + "','" + _custFileCore.CreatedDate + "','" + "I" + "'".ToString());

            ExecuteUpdateProcedure(sSql);

        }
        public DataSet delete_customer_file(string sql)
        {
            return ReturnDataset(sql);
        }

        public void SaveBudget(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;
            String sSql = ("exec procBudgetEntry'" + custCore.Id + "','" + custCore.FiscalYear + "','" + custCore.Branch + "',"
                          + "'" + custCore.Product + "','" + custCore.Qty + "','" + custCore.Price + "','" + custCore.Remarks
                          + "','" + custCore.IsActive + "','" + custCore.CustomerName + "','" + "I" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        public void UpdateBudget(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;
            String sSql = ("exec procBudgetEntry'" + custCore.Id + "','" + custCore.FiscalYear + "','" + custCore.Branch + "',"
                          + "'" + custCore.Product + "','" + custCore.Qty + "','" + custCore.Price + "','" + custCore.Remarks
                          + "','" + custCore.IsActive + "','" + custCore.CustomerName + "','" + "U" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }
        public void DeleteBudget(object obj)
        {
            CustomerCore custCore = (CustomerCore)obj;
            String sSql = ("exec procBudgetEntry'" + custCore.Id + "','" + custCore.FiscalYear + "','" + custCore.Branch + "',"
                          + "'" + custCore.Product + "','" + custCore.Qty + "','" + custCore.Price + "','" + custCore.Remarks
                          + "','" + custCore.IsActive + "','" + custCore.CustomerName + "','" + "D" + "'".ToString());
            ExecuteUpdateProcedure(sSql);
        }

        public CustomerCore GetBudgetDetailByID(long id)
        {
            string sSql = " SELECT [ID],[FY],[BRANCH_ID],[PRODUCT_ID],[BUDGET_QTY],[RATE],[REMARKS],[IS_ACTIVE]"                        
                         + ",[CREATED_DATE],[CREATED_BY] FROM [IN_BUDGET] WHERE ID = " + id + "";

            DataTable dt = SelectByQuery(sSql);
            CustomerCore _custCore = null;
            if (dt != null)
                _custCore = (CustomerCore)this.MapBudgetObject(dt.Rows[0]);

            return _custCore;
        }
        public object MapBudgetObject(DataRow dr)
        {
            CustomerCore _custCore = new CustomerCore();
            _custCore.Id = long.Parse(dr["ID"].ToString());
            _custCore.FiscalYear = dr["FY"].ToString();
            _custCore.Branch = dr["BRANCH_ID"].ToString();
            _custCore.Product = dr["PRODUCT_ID"].ToString();
            _custCore.Qty = dr["BUDGET_QTY"].ToString();
            _custCore.Price = dr["RATE"].ToString();
            _custCore.Remarks = dr["REMARKS"].ToString();
            if (dr["IS_ACTIVE"].ToString() == "Active")
            {
                _custCore.IsActive = "Active";
            }
            else
            {
                _custCore.IsActive = "InActive";
            }
            return _custCore;
        }
    }
}



               