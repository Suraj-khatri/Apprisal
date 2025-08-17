using SwiftHrManagement.web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SwiftHrManagement.web
{
    public partial class Dashboard : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = String.IsNullOrEmpty(Request.QueryString["q"])? "HR" : Request.QueryString["q"].ToString();
            this.ReadSession().MenuType = flag;
            PACount.InnerText = CountAgreement().ToString();
            int Scount = countJd("super"), Ucount = countJd("User");
            JdCount.InnerText = Scount != 0? Scount.ToString(): Ucount.ToString();
            PRCount.InnerText = CountReview().ToString();
            if (Scount != 0) { JdLink.NavigateUrl = "/Company/EmployeeWeb/JobDescription/JDList.aspx"; } else { JdLink.NavigateUrl = "/Company/EmployeeWeb/JobDescription/List.aspx"; }
        }

        public int CountReview()
        {
            int count = 0;
            bool IsAdmin = CheckHrAdmin(null);
            int user = Convert.ToInt32(ReadSession().Emp_Id);
            try
            {
                List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
                string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
                SqlConnection con = new SqlConnection();
                string sql = "";
                con.ConnectionString = connstring;
                con.Open();
                if (IsAdmin)
                {
                    sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='HRadminPR'";
                }
                else
                {
                    sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='PRforuser'";
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    Result.Add(
                        new PerformanceAgreement
                        {

                            AppriseeName = dr["EMPNAME"].ToString(),
                            EndDate = dr["AppraisalEndDate"].ToString(),
                            Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                            StartDate = dr["AppraisalStartDate"].ToString(),
                            Status = dr["Status"].ToString(),
                            EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                            AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                            flag = dr["FLAG"].ToString(),
                            SupervisorId = Convert.ToInt32(dr["supervisorId"].ToString()),
                            Reviewrid = Convert.ToInt32(dr["reviewerId"].ToString()),
                            statusCode = Convert.ToInt32(dr["Code"].ToString()),
                            FiscalId = Convert.ToInt32(dr["Fiscal_Year_Id"].ToString()),
                        }
                        );


                }

                int rev = Result.Where(x => x.Reviewrid == user && x.statusCode == 7).Count();
                int suv = Result.Where(x => x.SupervisorId == user && (x.statusCode == 11 || x.statusCode == 13 || x.statusCode == 16 || x.statusCode == 17)).Count();
                int emp = Result.Where(x => x.statusCode == 6 && x.EmpId == user).Count();
                count = rev + suv + emp;
            }
            catch (Exception)
            {
                count = 0;
            }

            return count;
        }
        public int CountAgreement()
        {
            
            int count = 0;
            bool IsAdmin = CheckHrAdmin(null);
            int user = Convert.ToInt32(ReadSession().Emp_Id);
            try
            {
                List<PerformanceAgreement> Result = new List<PerformanceAgreement>();
                string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
                SqlConnection con = new SqlConnection();
                string sql = "";
                con.ConnectionString = connstring;
                con.Open();
                if (IsAdmin)
                {
                    sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='HRadminPA'";
                }
                else
                {
                    sql = @"Exec SP_PmsDashboardReports @EmpId=" + ReadSession().Emp_Id + ",@flag='PAforuser'";
                }
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    Result.Add(
                        new PerformanceAgreement
                        {
                           
                            AppriseeName = dr["EMPNAME"].ToString(),
                            EndDate = dr["AppraisalEndDate"].ToString(),
                            Fiscalyear = dr["FISCAL_YEAR_NEPALI"].ToString(),
                            StartDate = dr["AppraisalStartDate"].ToString(),
                            Status = dr["Status"].ToString(),                            
                            EmpId = Convert.ToInt32(dr["EMPLOYEE_ID"].ToString()),
                            AppId = Convert.ToInt32(dr["appraisalId"].ToString()),
                            flag = dr["FLAG"].ToString(),
                            SupervisorId= Convert.ToInt32(dr["supervisorId"].ToString()),
                            Reviewrid= Convert.ToInt32(dr["reviewerId"].ToString()),
                            statusCode = Convert.ToInt32(dr["Code"].ToString()),
                            FiscalId = Convert.ToInt32(dr["Fiscal_Year_Id"].ToString()),
                        }
                        );

                   
                }
                int rev = Result.Where(x => x.Reviewrid == user && x.statusCode == 3).Count();
                int suv = Result.Where(x => x.SupervisorId == user && (x.statusCode == 1 || x.statusCode == 10 || x.statusCode == 12 || x.statusCode == 14)).Count();
                int emp= Result.Where(x => x.statusCode == 2 && x.EmpId == user).Count();
                count = rev + suv + emp;
                if (IsAdmin)
                {
                    count += Result.Where(x => x.statusCode == 4).Count();
                }
                    
            }
            catch (Exception)
            {
                count = 0;
            }

            return count;
        }
        public int countJd(string Flag)
        {
            int count = 0;
            try
            {
                string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
                SqlConnection con = new SqlConnection();
                string sql = "";
                con.ConnectionString = connstring;
                con.Open();

                if (Flag == "User")
                {
                    sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR,j.startDate, 107) startDate,
                        CONVERT(VARCHAR,j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E 
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F 
                        ON f.FISCAL_YEAR_ID=j.FiscalId
                        WHERE j.flag IN ('N')  
                          AND f.FLAG=1 AND IsDeleted=0
                          AND j.EmpId=" + ReadSession().Emp_Id;

                }
            if(Flag=="super"){
                sql = @"SELECT j.rowId,
                        E.EMPLOYEE_ID,
                        E.FIRST_NAME + ' ' + ISNULL(E.MIDDLE_NAME, '') + ' ' + E.LAST_NAME AS Employee,
                        dbo.GetBranchName(branchId) Branch,
                        dbo.GetPosOfId(positionId) POSITION,
                        dbo.GetEmployeeFullNameOfId(supervisorId) Supervisor,
                        CONVERT(VARCHAR, j.startDate, 107) startDate,
                        CONVERT(VARCHAR, j.endDate, 107) endDate,
                        [Status] = CASE
                        WHEN j.flag = 'Y' THEN 'ACCEPTED'
                        WHEN j.flag = 'N' THEN 'PENDING'
                        WHEN j.flag = 'A' THEN 'APPROVED'
                        WHEN j.flag = 'D' THEN 'DISAGREED'
                        END,
                        F.FISCAL_YEAR_ID,
                        F.FISCAL_YEAR_NEPALI
                        FROM jobDescription j
                        INNER JOIN dbo.Employee E
                        ON j.empId = E.EMPLOYEE_ID
                        INNER JOIN FiscalYear F
                        ON f.FISCAL_YEAR_ID= j.FiscalId
                        WHERE j.flag IN ('Y',
                                         'D')
                          AND f.FLAG=1 AND (IsDeleted = 0 OR IsDeleted IS NULL)
                          AND j.supervisorid= " + ReadSession().Emp_Id;


                }
               
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            count = dt.Rows.Count;
        }
            catch (Exception Ex)
            {



            }
           
            return count;
        }
        public bool CheckHrAdmin(int? empid)
        {
            string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connstring;
            con.Open();
            var eid = (ReadSession().Emp_Id).ToString();
            string sql = @"SELECT DISTINCT 'A' Mgs
                         FROM   dbo.user_role r
                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                         WHERE  s.TYPE_ID = '25'
                                  AND s.DETAIL_TITLE = 'HR Admin'
                                AND a.Name = " + ReadSession().Emp_Id;
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            int count = dt.Rows.Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}