using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BenefitsDAO;

namespace SwiftHrManagement.DAL.BenefitsDAO
{
    public class BenefitsDAO : BaseDAO    //benefits DAO derived from base DAO
    {
        // instance of StringBuilder Object created and assigned null values
        
        private StringBuilder insertQuery = null;
        private StringBuilder updateQuery = null;
        
        // new instances of BenefitsCore and BaseDomain created

        BenefitsCore _benefits = new BenefitsCore();
        BaseDomain _baseDomain = new BaseDomain();

        //constructor started

        public BenefitsDAO()
        {   // insertQuery stringbuilder initialized

            this.insertQuery = new StringBuilder(" INSERT INTO Benefits(BENEFIT_NAME, OCCURRENCE, DETAILS, GL_CODE, BENEFIT_GROUP ,CREATED_BY, CREATED_DATE)"
                                                 + " VALUES('_BENEFIT_NAME', '_OCCURRENCE', '_DETAILS', '_GL_CODE','_BENEFIT_GROUP','CREATEDBY','CREATEDDATE')");
            // updateQuery stringbuilder initialized
            
            this.updateQuery = new StringBuilder("UPDATE Benefits SET BENEFIT_NAME='_BENEFIT_NAME', OCCURRENCE = '_OCCURRENCE',"
                                                 + "DETAILS = '_DETAILS', GL_CODE='_GL_CODE', BENEFIT_GROUP = '_BENEFIT_GROUP' ,MODIFIED_DATE='MODIFIEDDATE', MODIFIED_BY = 'MODIFIEDBY' WHERE ID = _ID ");

        }
        // Save method overridden from BaseDAO so as to Save new benefit Object
        public override void Save(object obj)
        {
            BenefitsCore _benCore = (BenefitsCore)obj;
            this.insertQuery.Replace("_BENEFIT_NAME", _benCore.BenefitName);
            this.insertQuery.Replace("_OCCURRENCE", _benCore.Occurrence);
            this.insertQuery.Replace("_DETAILS", _benCore.Details);
            this.insertQuery.Replace("_GL_CODE", _benCore.GlCode);
            
            this.insertQuery.Replace("_BENEFIT_GROUP",_benCore.BenefitGroup);

            this.insertQuery.Replace("CREATEDBY", _benCore.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", _benCore.CreatedDate.ToString());
            
            ExecuteQuery(this.insertQuery.ToString());
        }

        // Update method overridden from BaseDAO so as to Update existing benefit Object

        public override void Update(object obj)
        {
            BenefitsCore _benCore = (BenefitsCore)obj;
            this.updateQuery.Replace("_ID", _benCore.Id.ToString());
            this.updateQuery.Replace("_BENEFIT_NAME", _benCore.BenefitName);
            this.updateQuery.Replace("_OCCURRENCE", _benCore.Occurrence);
            this.updateQuery.Replace("_DETAILS", _benCore.Details);
            this.updateQuery.Replace("_GL_CODE", _benCore.GlCode);
            
            this.updateQuery.Replace("_BENEFIT_GROUP", _benCore.BenefitGroup);

            this.updateQuery.Replace("MODIFIEDBY", _benCore.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIEDDATE", _benCore.ModifyDate.ToString());

            ExecuteQuery(this.updateQuery.ToString());
        }
        // method to retrieve all benefit Objects
        public List<BenefitsCore> FindBenefit()
        {
            // PREPARE SQL SRTING TO JOIN Contribution and Employee TABLES

            string sSql = "SELECT  ID, BENEFIT_NAME FROM Benefits";

            DataTable dt = SelectByQuery(sSql);                                 //WHATEVER QUERY RETURNS IS AT DATA TABLE NOW

            List<BenefitsCore> _bList = new List<BenefitsCore>();               // PREPARE LIST OF DATA

            if (dt != null)                                                     // IF DATA TABLE CONTAINS SOMETHING
            {
                foreach (DataRow dr in dt.Rows)                                 // UNTIL THE LAST ROW
                {
                    BenefitsCore _bCore = (BenefitsCore)this.Mapbenefit(dr);    // ONE ROW IS RETURNED AS ONE OBJECT
                    _bList.Add(_bCore);                                         // EACH OBJECT IS ADDED TO OBJECT LISTING
                }
            }
            return _bList;                                                      // OBJECT LIST IS RETURNED
        }

        public object Mapbenefit(System.Data.DataRow dr)
        {
            BenefitsCore _bCore = new BenefitsCore();
            _bCore.Id = long.Parse(dr["ID"].ToString());
            _bCore.BenefitName = dr["BENEFIT_NAME"].ToString();
            return _bCore;
        }

        public List<BenefitsCore> FindAllBenefits()
        {
            String sqlStatement = "SELECT ID, BENEFIT_NAME, OCCURRENCE, DETAILS, GL_CODE, BENEFIT_GROUP FROM Benefits";

            DataTable dTable = SelectByQuery(sqlStatement);

            List<BenefitsCore> benefitList = new List<BenefitsCore>();
            if (benefitList != null)
            {
                foreach (DataRow dRow in dTable.Rows)
                {
                    _benefits = (BenefitsCore)this.MapObject(dRow);
                    benefitList.Add(_benefits);
                }
            }
            return benefitList;
        }

        // method to retrieve any among persisted benefit Objects

        public BenefitsCore FindBenefitById(long Id)
        {
            String sqlStatement = "SELECT ID, BENEFIT_NAME, OCCURRENCE, DETAILS, GL_CODE, BENEFIT_GROUP FROM Benefits"
                + " WHERE ID =" + Id + "";
            DataTable dTable = SelectByQuery(sqlStatement);
            BenefitsCore _oneBenefit = null;

            if (dTable != null)
            
              _oneBenefit = (BenefitsCore) this.MapObject(dTable.Rows[0]);
              return _oneBenefit; 
         }
        
        // Objects mapped to persistence layer
        
        public override object MapObject(DataRow dRow)
        {
            
            BenefitsCore _benefits = new BenefitsCore();
            _benefits.Id = long.Parse(dRow["ID"].ToString());
            _benefits.BenefitName = dRow["BENEFIT_NAME"].ToString();
            _benefits.Occurrence = dRow["OCCURRENCE"].ToString();
            _benefits.Details = dRow["DETAILS"].ToString();
            _benefits.GlCode = dRow["GL_CODE"].ToString();
            _benefits.BenefitGroup = dRow["BENEFIT_GROUP"].ToString();
            return _benefits;
        }

    }
}
