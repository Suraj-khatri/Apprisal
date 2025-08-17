using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.AttendenceDao;

namespace SwiftHrManagement.DAL.AttendenceDao
{
   public class AttendenceDao : BaseDAO
    {
       public StringBuilder insertQuery;
       public StringBuilder updateQuery;

       public AttendenceDao()
       {
           this.insertQuery = new StringBuilder("INSERT INTO Attendence(EMPLOYEE_ID,ATT_DATE_IN,ATT_DATE_OUT,ATT_REMARKS) VALUES('EMPLOYEEID','ATTDATEIN','ATTDATEOUT','ATTREMARKS')");
           this.updateQuery = new StringBuilder("UPDATE Attendence SET ATT_DATE_IN = 'ATTDATEIN',ATT_DATE_OUT = 'ATTDATEOUT' WHERE ATTENDENCE_ID = 'ATTENDENCEID' ");
       }
       public override void  Save(object obj)
        {
            AttendenceCore attendence = (AttendenceCore)obj;
            this.insertQuery.Replace("EMPLOYEEID",attendence.Employeeid.ToString());
            this.insertQuery.Replace("ATTDATEIN", attendence.Attdate.ToString());
            this.insertQuery.Replace("ATTDATEOUT",attendence.Atttimeout.ToString());
            this.insertQuery.Replace("ATTREMARKS",attendence.Attremarks);
            ExecuteQuery(this.insertQuery.ToString());
        }
       public override void  Update(object obj)
        {
            try
            {
                AttendenceCore _attendence = (AttendenceCore)obj;
                this.updateQuery.Replace("'ATTENDENCEID'", _attendence.Attendenceid.ToString());
                this.updateQuery.Replace("ATTDATEIN", _attendence.Attdate.ToString());
                this.updateQuery.Replace("ATTDATEOUT", _attendence.Atttimeout.ToString());
                ExecuteQuery(this.updateQuery.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

       public List<AttendenceCore> Findall()
       {
           string sSql = "SELECT A.ATTENDENCE_ID,E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS EMPLOYEE_ID,A.ATT_DATE_IN,A.ATT_DATE_OUT,A.ATT_REMARKS FROM Attendence A inner join Employee E on A.EMPLOYEE_ID=E.EMPLOYEE_ID";
           DataTable dt = SelectByQuery(sSql);
           List<AttendenceCore> atten= new List<AttendenceCore>();
           if (dt != null)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   AttendenceCore _atten = (AttendenceCore)this.MapObject(dr);
                   atten.Add(_atten);
               }
           }
           return atten;
       }

       public AttendenceCore FindById(long Attendenceid)
       {
           string sSql = "SELECT ATTENDENCE_ID,EMPLOYEE_ID,ATT_DATE_IN,ATT_DATE_OUT,ATT_REMARKS FROM Attendence WHERE ATTENDENCE_ID =" + Attendenceid + "";
           DataTable dt = SelectByQuery(sSql);
           AttendenceCore _atten = null;
           if (dt != null)
               _atten = (AttendenceCore)this.MapObject(dt.Rows[0]);
           return _atten;
       }

       public override object MapObject(DataRow dr)
       {
           AttendenceCore attendence = new AttendenceCore();
           attendence.Attendenceid = long.Parse(dr["ATTENDENCE_ID"].ToString());
           attendence.Employeeid = dr["EMPLOYEE_ID"].ToString();
           attendence.Attdate = dr["ATT_DATE_IN"].ToString();
           attendence.Atttimeout = dr["ATT_DATE_OUT"].ToString();
           attendence.Attremarks = dr["ATT_REMARKS"].ToString();
           return attendence;

       }
       public string CRUDLog(string Id)
       {
           return GetCurrentRecordInformation("Attendence", "ATTENDENCE_ID", Id);
       }
     
    }
}
