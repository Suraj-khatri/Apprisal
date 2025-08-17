using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web.DAL.OnSiteDuty
{
    public class onSiteDutyAssignmentDAO : BaseDAOInv
    {
        private StringBuilder _insertQuery;

        private StringBuilder _updateQuery;

        private StringBuilder _ApproveQuery;

        public onSiteDutyAssignmentDAO()
        {
            this._insertQuery = new StringBuilder("INSERT INTO onsiteDuty (sitedatefrom,sitedateto,empID,branch,dept,siteLocation,purpose,[description],createdDate,createdBy,Approved_By,status,recorded,Approved_Date) "
                                + " SELECT '_sitedatefrom','_sitedateto','_empID',BRANCH_ID,DEPARTMENT_ID,'_siteLocation','_purpose','_description','_createdDate','_createdBy','_approvedBy','_status','_recorded',_approvedDate" +
                                " FROM EMPLOYEE WHERE EMPLOYEE_ID='_empID'");
            
            this._updateQuery = new StringBuilder("UPDATE OD "
                            + " set sitedatefrom='_sitedatefrom',sitedateto='_sitedateto',empID='_empID',siteLocation='_siteLocation' "
                            + " ,branch=BRANCH_ID,dept=DEPARTMENT_ID "
                            +" ,purpose='_purpose',[description]='_description' "
                            + " ,modifiedDate='_modifiedDate',modifiedBy='_modifiedBy',Approved_By='_approvedBy',Approved_date=_approvedDate "
                            + " from onsiteDuty OD join Employee E on E.EMPLOYEE_ID='_empID' WHERE onsiteID = ID_");

            this._ApproveQuery = new StringBuilder("Update Onsiteduty Set Approved_date=getdate(),Approved_remarks=_approvedRemarks, Status='Approved' where onsiteID=ID_");
        
        }

        public override void Save(object obj)
        {
            onSiteDutyAssignmentCore _onSiteDuty = (onSiteDutyAssignmentCore)obj;
            this._insertQuery.Replace("_sitedatefrom", _onSiteDuty.SiteDateFrom);
            this._insertQuery.Replace("_sitedateto", _onSiteDuty.SiteDateTo);
            //this._insertQuery.Replace("_empID", _onSiteDuty.EmpId);
            this._insertQuery.Replace("_siteLocation", _onSiteDuty.SiteLocation);
            this._insertQuery.Replace("_purpose", _onSiteDuty.Purpose);
            this._insertQuery.Replace("_description", _onSiteDuty.Description);
            this._insertQuery.Replace("_createdDate",DateTime.Now.ToString());
            this._insertQuery.Replace("_createdBy",_onSiteDuty.CreatedBy);
            this._insertQuery.Replace("_approvedBy", _onSiteDuty.ApproveBy);
            this._insertQuery.Replace("_recorded", _onSiteDuty.Recorded);
            this._insertQuery.Replace("_status", _onSiteDuty.Status);
            this._insertQuery.Replace("_approvedDate",filterstring(_onSiteDuty.ApprovedDate));
         
          ExecuteQuery(_insertQuery.ToString());
            //SendMail();

        }

        //public void SendMail()
        //{
        //    ExecuteStoreProcedure("");
        //}

        public override void Update(object obj)
        {
            onSiteDutyAssignmentCore _onSiteDuty = (onSiteDutyAssignmentCore)obj;

            this._updateQuery.Replace("ID_", _onSiteDuty.OnsiteID.ToString());
            this._updateQuery.Replace("_sitedatefrom", _onSiteDuty.SiteDateFrom);
            this._updateQuery.Replace("_sitedateto", _onSiteDuty.SiteDateTo);
            this._updateQuery.Replace("_siteLocation", _onSiteDuty.SiteLocation);
            this._updateQuery.Replace("_purpose", _onSiteDuty.Purpose);
            this._updateQuery.Replace("_description", _onSiteDuty.Description);
            this._updateQuery.Replace("_modifiedDate", DateTime.Now.ToString());
            this._updateQuery.Replace("_modifiedBy",_onSiteDuty.ModifyBy);
            this._updateQuery.Replace("_approvedBy", _onSiteDuty.ApproveBy);
            this._updateQuery.Replace("_approvedDate", filterstring(_onSiteDuty.ApprovedDate));

            ExecuteQuery(_updateQuery.ToString());
        }

        public void Approve(object obj)
        {
            onSiteDutyAssignmentCore _onSiteDuty = (onSiteDutyAssignmentCore)obj;

            this._ApproveQuery.Replace("ID_", _onSiteDuty.OnsiteID.ToString());
            this._ApproveQuery.Replace("_modifiedBy", _onSiteDuty.ModifyBy);
            this._ApproveQuery.Replace("_approvedRemarks", filterstring(_onSiteDuty.ApprovedRemarks));

            ExecuteQuery(_ApproveQuery.ToString());
        }

        public override object MapObject(System.Data.DataRow dr)
        {
            onSiteDutyAssignmentCore _onSiteDuty = new onSiteDutyAssignmentCore();

            _onSiteDuty.OnsiteID = long.Parse(dr["onsiteID"].ToString());
            _onSiteDuty.EmpId = dr["empId"].ToString();
            _onSiteDuty.SiteDateFrom = dr["sitedatefrom"].ToString();
            _onSiteDuty.SiteDateTo = dr["sitedateto"].ToString();
            _onSiteDuty.SiteLocation = dr["siteLocation"].ToString();
            _onSiteDuty.Purpose = dr["purpose"].ToString();
            _onSiteDuty.Description = dr["description"].ToString();
            _onSiteDuty.ApproveBy = dr["Approved_By"].ToString();
            _onSiteDuty.ApprovedDate = dr["Approved_date"].ToString();
            _onSiteDuty.ApprovedRemarks = dr["Approved_Remarks"].ToString();
            _onSiteDuty.Status = dr["Status"].ToString();

            return _onSiteDuty;
        }

        public onSiteDutyAssignmentCore FindallById(long Id)
        {
            string sSql = @"SELECT
                                     onsiteID
                                    ,empId
                                    ,CONVERT(varchar,sitedatefrom,101) sitedatefrom
                                    ,CONVERT(varchar,sitedateto,101) sitedateto
                                    ,siteLocation
                                    ,purpose
                                    ,[description]
                                    ,Approved_By
                                    ,CONVERT(varchar,approved_date,101) approved_date
                                    ,Status
                                    ,Approved_Remarks
                                FROM onsiteDuty WHERE onsiteID=" + Id + "";
            DataTable dt = SelectByQuery(sSql);
            onSiteDutyAssignmentCore _onSiteDuty = null;
            if (dt != null)
                _onSiteDuty = (onSiteDutyAssignmentCore)this.MapObject(dt.Rows[0]);
            return _onSiteDuty;
        }

        public void DeleteById(long Id, String UserName)
        {
            ExecuteQuery("exec procExecuteSQLString 'd' , 'delete from onsiteDuty' , ' and  onsiteID=''" + Id + "''', '" + UserName + "'");
        }
    }
}
