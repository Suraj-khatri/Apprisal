using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.ContributionDAO;

namespace SwiftHrManagement.DAL.ContributionDAO
{
    public class ContributionDAO : BaseDAO
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private StringBuilder selectQuery;

        public ContributionDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Contribution(EMPLOYEE_ID, CONTRIBUTED_TO, CONTRIBUTION_CODE, VALUE_EMPLOYEE, "
            + "CONTRIBUTION_BASIS_EMPLOYEE, FLAG_EMPLOYEE, CONTRIBUTION_FROM_DATE_EMPLOYEE,VALUE_EMPLOYER,"
            + "CONTRIBUTION_BASIS_EMPLOYER, FLAG_EMPLOYER, CONTRIBUTION_FROM_DATE_EMPLOYER,CREATED_BY,CREATED_DATE) values "

            + " (EMPLOYEEID, CONTRIBUTEDTO, CONTRIBUTIONCODE, VALUEEMPLOYEE, 'CONTRIBUTIONBASISEMPLOYEE', FLAGEMPLOYEE, CONTRIBUTIONFROMDATEEMPLOYEE,"
            + " VALUEEMPLOYER,'CONTRIBUTIONBASISEMPLOYER',FLAGEMPLOYER,CONTRIBUTIONFROMDATEEMPLOYER,_CREATEDBY,_CREATEDDATE) SELECT SCOPE_IDENTITY();");

            this.updateQuery = new StringBuilder("UPDATE Contribution SET CONTRIBUTED_TO=CONTRIBUTEDTO,CONTRIBUTION_CODE=CONTRIBUTIONCODE,"
            + " VALUE_EMPLOYEE=VALUEEMPLOYEE,CONTRIBUTION_BASIS_EMPLOYEE='CONTRIBUTIONBASISEMPLOYEE', "
            + " CONTRIBUTION_FROM_DATE_EMPLOYEE = CONTRIBUTIONFROMDATEEMPLOYEE,"
            + " VALUE_EMPLOYER = VALUEEMPLOYER, CONTRIBUTION_BASIS_EMPLOYER = 'CONTRIBUTIONBASISEMPLOYER',"
            + " FLAG_EMPLOYER = FLAGEMPLOYER,FLAG_EMPLOYEE = FLAGEMPLOYEE,CONTRIBUTION_FROM_DATE_EMPLOYER = CONTRIBUTIONFROMDATEEMPLOYER ,MODIFIED_BY=_MODIFIEDBY,MODIFIED_DATE=_MODIFIEDDATE WHERE ID= ID_");

            this.selectQuery = new StringBuilder("");
        }

        public override void Save(object obj)
        {
            ContributionCore _contributionCore = (ContributionCore)obj;

            this.insertQuery.Replace("EMPLOYEEID",filterstring( _contributionCore.EmployeeID.ToString()));
            this.insertQuery.Replace("CONTRIBUTEDTO", filterstring(_contributionCore.ContributedTo));
            this.insertQuery.Replace("CONTRIBUTIONCODE", filterstring(_contributionCore.ContributionCode));
            this.insertQuery.Replace("VALUEEMPLOYEE",filterstring( _contributionCore.Value_employee.ToString()));
            this.insertQuery.Replace("CONTRIBUTIONBASISEMPLOYEE", _contributionCore.ContributionBasisEmployee.ToString());
            this.insertQuery.Replace("FLAGEMPLOYEE", filterstring(_contributionCore.Flag_employee.ToString()));
            this.insertQuery.Replace("CONTRIBUTIONFROMDATEEMPLOYEE",filterstring( _contributionCore.ContributionFromDateEmployee.ToString()));
            this.insertQuery.Replace("VALUEEMPLOYER",filterstring( _contributionCore.Contbemplr_amt_pct.ToString()));
            this.insertQuery.Replace("CONTRIBUTIONBASISEMPLOYER",_contributionCore.ContributionBasisEmployer.ToString());
            this.insertQuery.Replace("FLAGEMPLOYER", filterstring(_contributionCore.Flag_employer.ToString()));
            this.insertQuery.Replace("CONTRIBUTIONFROMDATEEMPLOYER",filterstring(_contributionCore.ContributionFromDateEmployer.ToString()));
            this.insertQuery.Replace("_CREATEDBY", filterstring(_contributionCore.CreatedBy.ToString()));
            this.insertQuery.Replace("_CREATEDDATE", filterstring(_contributionCore.CreatedDate.ToString()));
            
          int AutoId =   ExecuteQuery(this.insertQuery.ToString(),'y');
          _contributionCore.Id = AutoId;
        }

        public override void Update(object obj)
        {
            ContributionCore _contributionCore = (ContributionCore)obj;

            this.updateQuery.Replace("ID_", filterstring(_contributionCore.Id.ToString()));
            this.updateQuery.Replace("EMPLOYEEID", filterstring(_contributionCore.EmployeeID.ToString()));
            this.updateQuery.Replace("CONTRIBUTEDTO", filterstring(_contributionCore.ContributedTo));
            this.updateQuery.Replace("CONTRIBUTIONCODE", filterstring(_contributionCore.ContributionCode));

            this.updateQuery.Replace("VALUEEMPLOYEE", filterstring(_contributionCore.Value_employee.ToString()));
            this.updateQuery.Replace("VALUEEMPLOYER", filterstring(_contributionCore.Value_employer.ToString()));

            this.updateQuery.Replace("CONTRIBUTIONBASISEMPLOYEE",_contributionCore.ContributionBasisEmployee.ToString());
            this.updateQuery.Replace("CONTRIBUTIONBASISEMPLOYER", _contributionCore.ContributionBasisEmployer.ToString());

            this.updateQuery.Replace("FLAGEMPLOYEE", filterstring(_contributionCore.Flag_employee.ToString()));
            this.updateQuery.Replace("FLAGEMPLOYER", filterstring(_contributionCore.Flag_employer.ToString()));

            this.updateQuery.Replace("CONTRIBUTIONFROMDATEEMPLOYEE", filterstring(_contributionCore.ContributionFromDateEmployee.ToString()));
            this.updateQuery.Replace("CONTRIBUTIONFROMDATEEMPLOYER", filterstring(_contributionCore.ContributionFromDateEmployer.ToString()));

            this.updateQuery.Replace("_MODIFIEDBY", filterstring(_contributionCore.ModifyBy.ToString()));
            this.updateQuery.Replace("_MODIFIEDDATE", filterstring(_contributionCore.ModifyDate.ToString()));

            ExecuteQuery(this.updateQuery.ToString());
        }
        public List<ContributionCore> FindAllByEmpId(long Id)
        {
            string sSql = "SELECT  C.ID,A.DETAIL_TITLE AS CONTRIBUTED_TO,C.VALUE_EMPLOYEE,CASE WHEN C.CONTRIBUTION_BASIS_EMPLOYEE='36' THEN 'BASIC SALARY' "
                +" WHEN C.CONTRIBUTION_BASIS_EMPLOYEE='36,37' THEN 'BASIC & GRADE' ELSE 'GROSS SALARY' END AS CONTRIBUTION_BASIS_EMPLOYEE,C.VALUE_EMPLOYER,"
                +" C.CONTRIBUTION_CODE,CASE WHEN C.CONTRIBUTION_BASIS_EMPLOYER='36' THEN 'BASIC SALARY' WHEN C.CONTRIBUTION_BASIS_EMPLOYER='36,37' "
                +" THEN 'BASIC & GRADE' ELSE 'GROSS SALARY' END AS CONTRIBUTION_BASIS_EMPLOYER FROM Contribution AS C WITH (NOLOCK) INNER JOIN StaticDataDetail A WITH (NOLOCK) ON C.CONTRIBUTED_TO=A.ROWID "
                +" WHERE C.EMPLOYEE_ID=" + Id + "";
            
            DataTable dt = SelectByQuery(sSql); 
            
            List<ContributionCore> _contributionList = new List<ContributionCore>();
            
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows) 
                {
                    ContributionCore _contribution = (ContributionCore)this.MapObjectForGrid(dr);
                    _contributionList.Add(_contribution);
                }
            }
            return _contributionList; 
        }
        public object MapObjectForGrid(System.Data.DataRow dr)
        {
            ContributionCore _contrubution = new ContributionCore();

            _contrubution.Id = long.Parse(dr["ID"].ToString());
            _contrubution.ContributedTo = dr["CONTRIBUTED_TO"].ToString();
            _contrubution.ContributionCode = dr["CONTRIBUTION_CODE"].ToString();
            _contrubution.Value_employee = dr["VALUE_EMPLOYEE"].ToString();
            _contrubution.Value_employer = dr["VALUE_EMPLOYER"].ToString();
            _contrubution.ContributionBasisEmployee = dr["CONTRIBUTION_BASIS_EMPLOYEE"].ToString();
            _contrubution.ContributionBasisEmployer = dr["CONTRIBUTION_BASIS_EMPLOYER"].ToString();
            return _contrubution;
        }
        public ContributionCore FindById(long Id) 
        {
            string sSql = ("SELECT ID, EMPLOYEE_ID, CONTRIBUTED_TO, CONTRIBUTION_CODE, VALUE_EMPLOYEE,VALUE_EMPLOYER, FLAG_EMPLOYEE,FLAG_EMPLOYER,"
            + " CONTRIBUTION_BASIS_EMPLOYEE, CONVERT(VARCHAR,CONTRIBUTION_FROM_DATE_EMPLOYEE,101) AS CONTRIBUTION_FROM_DATE_EMPLOYEE,"
            + " CONTRIBUTION_BASIS_EMPLOYER,CONVERT(VARCHAR,CONTRIBUTION_FROM_DATE_EMPLOYER,101) AS CONTRIBUTION_FROM_DATE_EMPLOYER FROM "
            +" Contribution WHERE ID=" + Id + "").ToString(); 
            
            DataTable dt = SelectByQuery(sSql);
            ContributionCore _cn = null;
            if (dt != null) 
                _cn = (ContributionCore)this.MapObject(dt.Rows[0]); 
            return _cn; 
        }
        public override object MapObject(System.Data.DataRow dr)
        {
            ContributionCore _contrubution = new ContributionCore();

            _contrubution.Id = long.Parse(dr["ID"].ToString());
        
            _contrubution.EmployeeID = dr["EMPLOYEE_ID"].ToString();
            _contrubution.ContributedTo = dr["CONTRIBUTED_TO"].ToString();
            _contrubution.ContributionCode = dr["CONTRIBUTION_CODE"].ToString();
            _contrubution.Value_employee = dr["VALUE_EMPLOYEE"].ToString();
            _contrubution.Value_employer = dr["VALUE_EMPLOYER"].ToString();
            _contrubution.ContributionBasisEmployee = dr["CONTRIBUTION_BASIS_EMPLOYEE"].ToString();            
            _contrubution.ContributionFromDateEmployee = dr["CONTRIBUTION_FROM_DATE_EMPLOYEE"].ToString();
            _contrubution.ContributionBasisEmployer = dr["CONTRIBUTION_BASIS_EMPLOYER"].ToString();
            _contrubution.Flag_employee = dr["FLAG_EMPLOYEE"].ToString();
            _contrubution.Flag_employer = dr["FLAG_EMPLOYER"].ToString();
            _contrubution.ContributionFromDateEmployer = dr["CONTRIBUTION_FROM_DATE_EMPLOYER"].ToString();           
          return _contrubution;
        }
        public void deleteContribution(long id, string user)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from Contribution' , ' and ID =''"+ id +"''', '"+ user +"'");
        }

        public string CRUDFutLog(string Id)
        {
            return GetCurrentRecordInformation("Contribution", "ID", Id);
        }
        public string CRUDLog(string Id)
        {
            return GetCurrentRecordInformation("Contribution", "ID", Id);
        }
        public string CRUDLog(string Id, char ReturnType)
        {
            return GetCurrentRecordInformation("Adhoc_Contribution", "ID", Id);
        }
    }
}