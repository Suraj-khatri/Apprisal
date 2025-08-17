using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.PastExperiencesDAO;

namespace SwiftHrManagement.DAL.PastExperiencesDAO
{
    public class PastExperiencesDAO : BaseDAO
    {

        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public PastExperiencesDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO PastExperiences(EMPLOYEE_ID, ORGANIZATION, DATE_FROM,DATE_TO,POSITION,CONTRACT_TYPE,COUNTRY,CITY,LOCATION,PHONE_NUMBER,EMAIL_ADDRESS,CONTACT_PERSON,MOBILE_CONTACT_PERSON)"
            + " VALUES ('_EMPLOYEE_ID', '_ORGANIZATION', '_DATE_FROM','_DATE_TO','_POSITION','_CONTRACT_TYPE','_COUNTRY','_CITY','_LOCATION','_PHONE_NUMBER','_EMAIL_ADDRESS','CONTACTPERSON','MOBILECONTACTPERSON')");

            this.updateQuery = new StringBuilder("UPDATE PastExperiences SET ORGANIZATION='_ORGANIZATION',DATE_FROM='_DATE_FROM',DATE_TO='_DATE_TO' "
            + ",POSITION='_POSITION',CONTRACT_TYPE='_CONTRACT_TYPE',COUNTRY='_COUNTRY',CITY='_CITY',LOCATION='_LOCATION',PHONE_NUMBER='_PHONE_NUMBER', "
            + " EMAIL_ADDRESS='_EMAIL_ADDRESS',CONTACT_PERSON='CONTACTPERSON',MOBILE_CONTACT_PERSON='MOBILECONTACTPERSON' WHERE ID= ID_");
        }

        public override void Save(object obj)
        {
            PastExperiencesCore _pastExperience = (PastExperiencesCore)obj;
            this.insertQuery.Replace("_EMPLOYEE_ID", _pastExperience.EmployeeId.ToString());
            this.insertQuery.Replace("_ORGANIZATION", _pastExperience.Organization.ToString());
            this.insertQuery.Replace("_DATE_FROM", _pastExperience.DateFrom.ToString());
            this.insertQuery.Replace("_DATE_TO", _pastExperience.DateTo.ToString());

            this.insertQuery.Replace("_POSITION", _pastExperience.Position.ToString());
            this.insertQuery.Replace("_CONTRACT_TYPE", _pastExperience.ContractType.ToString());
            this.insertQuery.Replace("_COUNTRY", _pastExperience.Country.ToString());
            this.insertQuery.Replace("_CITY", _pastExperience.City.ToString());
            this.insertQuery.Replace("_LOCATION", _pastExperience.Location.ToString());
            this.insertQuery.Replace("_PHONE_NUMBER", _pastExperience.PhoneNumber.ToString());
            
            this.insertQuery.Replace("_EMAIL_ADDRESS", _pastExperience.PhoneNumber.ToString());
            this.insertQuery.Replace("CONTACTPERSON", _pastExperience.ContactPerson.ToString());
            this.insertQuery.Replace("MOBILECONTACTPERSON", _pastExperience.MobileContactPerson.ToString());
            
            ExecuteQuery(this.insertQuery.ToString());
        }
        public override void Update(object obj)
        {
            PastExperiencesCore _pastExperience = (PastExperiencesCore)obj;
            
            this.updateQuery.Replace("ID_", _pastExperience.Id.ToString());
            this.updateQuery.Replace("_EMPLOYEE_ID", _pastExperience.EmployeeId.ToString());
            this.updateQuery.Replace("_ORGANIZATION", _pastExperience.Organization.ToString());
            this.updateQuery.Replace("_DATE_FROM", _pastExperience.DateFrom.ToString());
            this.updateQuery.Replace("_DATE_TO", _pastExperience.DateTo.ToString());
            this.updateQuery.Replace("_POSITION", _pastExperience.Position.ToString());
            this.updateQuery.Replace("_CONTRACT_TYPE", _pastExperience.ContractType.ToString());
            this.updateQuery.Replace("_COUNTRY", _pastExperience.Country.ToString());
            this.updateQuery.Replace("_CITY", _pastExperience.City.ToString());
            this.updateQuery.Replace("_LOCATION", _pastExperience.Location.ToString());
            this.updateQuery.Replace("_PHONE_NUMBER", _pastExperience.PhoneNumber.ToString());
            this.updateQuery.Replace("_EMAIL_ADDRESS", _pastExperience.PhoneNumber.ToString());
            this.updateQuery.Replace("CONTACTPERSON", _pastExperience.ContactPerson.ToString());
            this.updateQuery.Replace("MOBILECONTACTPERSON", _pastExperience.MobileContactPerson.ToString());
            
            ExecuteQuery(this.updateQuery.ToString());
        }

        public List<PastExperiencesCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  P.ID, P.EMPLOYEE_ID, P.ORGANIZATION,P.DATE_FROM,P.DATE_TO,P.POSITION,P.CONTRACT_TYPE,P.COUNTRY,P.CITY,P.LOCATION,P.PHONE_NUMBER,P.EMAIL_ADDRESS,P.CONTACT_PERSON,P.MOBILE_CONTACT_PERSON, E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME+ ' - ' + CAST(E.EMPLOYEE_ID AS VARCHAR(50)) AS EMPLOYEE_NAME "
                          + "  FROM  PastExperiences AS P INNER JOIN Employee AS E ON P.EMPLOYEE_ID = E.EMPLOYEE_ID WHERE P.EMPLOYEE_ID=" + Id + "";

            DataTable dt = SelectByQuery(sSql);
            List<PastExperiencesCore> _experiences = new List<PastExperiencesCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PastExperiencesCore _past = (PastExperiencesCore)this.MapObject(dr);
                    _experiences.Add(_past);
                }
            }
            return _experiences;
        }
        public PastExperiencesCore FindById(long Id)
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, ORGANIZATION, DATE_FROM, DATE_TO, POSITION, CONTRACT_TYPE, COUNTRY, CITY, LOCATION, PHONE_NUMBER, EMAIL_ADDRESS, CONTACT_PERSON, MOBILE_CONTACT_PERSON "
                          + "  FROM  PastExperiences WHERE ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            PastExperiencesCore _past = null;
            if (dt != null)
                _past = (PastExperiencesCore)this.MapObject(dt.Rows[0]);
            return _past;
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            PastExperiencesCore _past = new PastExperiencesCore();
            
            _past.Id = long.Parse(dr["ID"].ToString());
            _past.EmployeeId = dr["EMPLOYEE_ID"].ToString();
            
            _past.Organization = dr["ORGANIZATION"].ToString();
            _past.DateFrom = DateTime.Parse(dr["DATE_FROM"].ToString());
            _past.DateTo = DateTime.Parse(dr["DATE_TO"].ToString());
            
            _past.Position = dr["POSITION"].ToString();
            _past.ContractType = dr["CONTRACT_TYPE"].ToString();
            _past.Country = dr["COUNTRY"].ToString();
            _past.City = dr["CITY"].ToString();
            _past.Location = dr["LOCATION"].ToString();

            _past.PhoneNumber = dr["PHONE_NUMBER"].ToString();
            _past.EmailAddress = dr["EMAIL_ADDRESS"].ToString();
            _past.ContactPerson = dr["CONTACT_PERSON"].ToString();
            _past.MobileContactPerson = dr["MOBILE_CONTACT_PERSON"].ToString();

            return _past;
        }
    }
}
