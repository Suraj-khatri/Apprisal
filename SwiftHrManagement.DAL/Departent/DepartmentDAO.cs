using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.DepartmentDAO;

namespace SwiftHrManagement.DAL.DepartmentDAO
{
    public class DepartmentDAO : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;

        public DepartmentDAO()
        {
            this.insertQuery = new StringBuilder("INSERT INTO Departments(BRANCH_ID,DEPARTMENT_SHORT_NAME,DEPARTMENT_NAME,"
                + " CREATED_BY,CREATED_DATE)VALUES('BRANCHID','DEPTSHORTNAMES','DEPTNAMES','CREATEDBY',"
                + " 'CREATEDDATE')");

            this.updateQuery = new StringBuilder("UPDATE Departments SET BRANCH_ID = 'BRANC_HID',"
                + " DEPARTMENT_SHORT_NAME = 'DEPTSHORTNAME',DEPARTMENT_NAME='DEPTNAME',"
                + " MODIFIED_DATE='MODIFIEDDATE',MODIFIED_BY = 'MODIFIEDBY' WHERE DEPARTMENT_ID = 'DEPTID' ");
        }

        public override void Save(object obj)
        {
            DepartmentCore dept = (DepartmentCore)obj;
            BaseDomain basedomain = (BaseDomain)obj;
            this.insertQuery.Replace("BRANCHID", dept.Branchid.ToString());
            this.insertQuery.Replace("DEPTSHORTNAMES", dept.Deptshortname);
            this.insertQuery.Replace("DEPTNAMES", dept.Deptname);
            this.insertQuery.Replace("CREATEDBY", basedomain.CreatedBy.ToString());
            this.insertQuery.Replace("CREATEDDATE", basedomain.CreatedDate.ToString());
            ExecuteQuery(this.insertQuery.ToString());
            //throw new NotImplementedException();
        }

        public override void Update(object obj)
        {
            try
            {
                DepartmentCore _dept = (DepartmentCore)obj;
                BaseDomain basedomain = (BaseDomain)obj;
                this.updateQuery.Replace("DEPTID", _dept.Id.ToString());
                this.updateQuery.Replace("BRANC_HID", _dept.Branchid.ToString());
                this.updateQuery.Replace("DEPTSHORTNAME", _dept.Deptshortname.ToString());
                this.updateQuery.Replace("DEPTNAME", _dept.Deptname.ToString());
                this.updateQuery.Replace("MODIFIEDBY", basedomain.ModifyBy.ToString());
                this.updateQuery.Replace("MODIFIEDDATE", basedomain.ModifyDate.ToString());
                ExecuteQuery(this.updateQuery.ToString());
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            //throw new NotImplementedException();
        }
        public List<DepartmentCore> Findall()
        {
            string sSql = "SELECT DEPARTMENT_ID,b.BRANCH_NAME as BRANCH_ID,DEPARTMENT_SHORT_NAME,DEPARTMENT_NAME FROM DEPARTMENTS d inner join "
            + "Branches b on b.BRANCH_ID=d.branch_id";
            DataTable dt = SelectByQuery(sSql);
            List<DepartmentCore> dept = new List<DepartmentCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentCore _dept = (DepartmentCore)this.MapObject(dr);
                    dept.Add(_dept);
                }
            }
            return dept;
        }
        public List<DepartmentCore> FindAllByFileds(string branchName, string deptName)
        {
            string sSql = "SELECT DEPARTMENT_ID,b.BRANCH_NAME as BRANCH_ID,DEPARTMENT_SHORT_NAME,DEPARTMENT_NAME FROM DEPARTMENTS d inner join "
            + "Branches b with (nolock) on b.BRANCH_ID=d.branch_id where 1=1";
            if (branchName != "")
            {
                sSql = sSql + " and b.branch_name LIKE '" + branchName + "%'";
            }
            if (deptName != "")
            {
                sSql = sSql + " and DEPARTMENT_NAME LIKE '" + deptName + "%'";
            }
            DataTable dt = SelectByQuery(sSql);
            List<DepartmentCore> dept = new List<DepartmentCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentCore _dept = (DepartmentCore)this.MapObject(dr);
                    dept.Add(_dept);
                }
            }
            return dept;
        }
        public DepartmentCore FindDeptIdByName(String Name)
        {
            string sSql = "SELECT DEPARTMENT_ID FROM Departments WHERE DEPARTMENT_NAME ='" + Name + "'";
            DataTable dt = SelectByQuery(sSql);
            DepartmentCore _Department = null;
            if (dt.Rows.Count != 0)
                _Department = (DepartmentCore)this.MapDepthId(dt.Rows[0]);
            return _Department;
        }

        public List<DepartmentCore> FindDeptByBranchID(long branchid)
        {
            string sSql = "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM DEPARTMENTS where branch_id=" + branchid + "";
            DataTable dt = SelectByQuery(sSql);
            List<DepartmentCore> dept = new List<DepartmentCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentCore _dept = (DepartmentCore)this.MapObject12(dr);
                    dept.Add(_dept);
                }
            }
            return dept;
        }

        public List<DepartmentCore> FindSubDeptByBranchID(long branchid,long deptId)
        {
             string sSql="SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM DEPARTMENTS where branch_id=" + branchid + "";
          //  string sSql = "EXEC  ProcManageEmployeeDetails @flag='getSubDepart',@branch_id=" + branchid + ",@dept_id=" + deptId + "";
            DataTable dt = SelectByQuery(sSql);
            List<DepartmentCore> dept = new List<DepartmentCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentCore _dept = (DepartmentCore)this.MapObject11(dr);
                    dept.Add(_dept);
                }
            }
            return dept;
        }

        public object MapObject11(DataRow dr)
        {
            DepartmentCore dept = new DepartmentCore();
            dept.Id = dr["DEPARTMENT_ID"].ToString();
            dept.Deptname = dr["DEPARTMENT_NAME"].ToString();
            return dept;
        }

        public object MapObject12(DataRow dr)
        {
            DepartmentCore dept = new DepartmentCore();
            dept.Id = dr["DEPARTMENT_ID"].ToString();
            dept.Deptname=dr["DEPARTMENT_NAME"].ToString();
            return dept;
        }
        public List<DepartmentCore> FindDeptByEmpId(long empId)
        {
            string sSql = "select D.DEPARTMENT_ID,D.DEPARTMENT_NAME FROM DEPARTMENTS D inner join Branches B on D.BRANCH_ID=B.BRANCH_ID"
            + " INNER JOIN Employee E ON E.BRANCH_ID=D.BRANCH_ID WHERE E.EMPLOYEE_ID='"+empId+"'";

            DataTable dt = SelectByQuery(sSql);
            List<DepartmentCore> dept = new List<DepartmentCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentCore _dept = (DepartmentCore)this.MapObjectDeptByEmpId(dr);
                    dept.Add(_dept);
                }
            }
            return dept;
        }
        public object MapObjectDeptByEmpId(DataRow dr)
        {
            DepartmentCore dept = new DepartmentCore();
            dept.Id = dr["DEPARTMENT_ID"].ToString();
            dept.Deptname = dr["DEPARTMENT_NAME"].ToString();
            return dept;
        }
       
        public object MapDepthId(DataRow dr)
        {
            DepartmentCore dept = new DepartmentCore();
            dept.Id = dr["DEPARTMENT_ID"].ToString();
            return dept;
        }
        public DepartmentCore FindAll()
        {
            string sSql = "SELECT DEPARTMENT_ID,BRANCH_ID,DEPARTMENT_SHORT_NAME,DEPARTMENT_NAME FROM DEPARTMENTS";
            DataTable dt = SelectByQuery(sSql);
            DepartmentCore _dept = null;
            if (dt != null)
                _dept = (DepartmentCore)this.MapObject(dt.Rows[0]);
            return _dept;
        }

        public List<DepartmentCore> FindAll(string departmentbytype)
        {
            string sSql = "SELECT DEPARTMENT_ID,BRANCH_ID,DEPARTMENT_SHORT_NAME,DEPARTMENT_NAME FROM Departments "
                + " WHERE DEPT_NAME LIKE '" + departmentbytype + "%'";
            DataTable dt = SelectByQuery(sSql);
            List<DepartmentCore> department = new List<DepartmentCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DepartmentCore dept = (DepartmentCore)this.MapObject(dr);
                    department.Add(dept);
                }
            }
            return department;
        }

        public DepartmentCore FindbyId(long Id)
        {
            string sSql = "SELECT DEPARTMENT_ID,BRANCH_ID,DEPARTMENT_SHORT_NAME,STATIC_ID AS DEPARTMENT_NAME FROM DEPARTMENTS"
            + " WHERE DEPARTMENT_ID = " + Id + "";
            DataTable dt = SelectByQuery(sSql);
            DepartmentCore _dept = null;
            if (dt != null)
                _dept = (DepartmentCore)this.MapObject(dt.Rows[0]);
            return _dept;
        }

        public override object MapObject(DataRow dr)
        {
            DepartmentCore dept = new DepartmentCore();
            dept.Id = dr["DEPARTMENT_ID"].ToString();
            dept.Branchid = (dr["BRANCH_ID"].ToString());
            dept.Deptshortname = dr["DEPARTMENT_SHORT_NAME"].ToString();
            dept.Deptname = dr["DEPARTMENT_NAME"].ToString();
            return dept;          
        }
        
    }
}
