using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;


namespace SwiftHrManagement.web.PerformanceAppraisal.Details
{
    public partial class exportAppraisalList : BasePage
    {
        clsDAO _clsdao = null;
        public exportAppraisalList()
        {
        this._clsdao = new clsDAO();            
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadHTML();           
        }
        void LoadHTML()
        {
            string year = Request.QueryString["bsDate"] == null ? "" : Request.QueryString["bsDate"].ToString();

            DataTable dt = _clsdao.getDataset(@"select * from (SELECT AP.ID,AP.POSITION_ID,
                                  E.FIRST_NAME + ' ' + E.MIDDLE_NAME + ' ' + E.LAST_NAME AS Employee_Name
                                  ,CONVERT(VARCHAR,AP.FROM_DATE,107) AS FROM_DATE 
                                  ,CONVERT(VARCHAR,AP.TO_DATE,107) AS TO_DATE
                                  ,CONVERT(VARCHAR,aTask.commentDate,107) Appraisee_Task
                                  ,CONVERT(VARCHAR,AP.appraisee_date,107) Appraisee_Rating
                                  ,dbo.GetEmployeeFullNameOfId (sup.SUPERVISOR) Appraiser
                                  ,CONVERT(VARCHAR,AP.Appraiser_Date,107) Appraiser_Date
                                  ,CONVERT(VARCHAR,sTask.commentDate,107) Appraiser_Comment
                                  ,dbo.GetEmployeeFullNameOfId(rev.SUPERVISOR) Reviewer
                                  ,CONVERT(VARCHAR,AP.Reviewer_date,107) Review_Date
                                  ,CONVERT(VARCHAR,apAcpt.commentDate,107) Acceptance_By_Appraisee  
                                  ,CONVERT(VARCHAR,AP.HRC_Date,107) Reviewer_Commt 
                                  ,CONVERT(VARCHAR,AP.CEO_date,107) HR FROM APPRAISAL AS AP
                                INNER JOIN Employee AS E ON AP.EMPLOYEE_ID = E.EMPLOYEE_ID and AP.EMPLOYEE_ID = E.EMPLOYEE_ID 
                                LEFT JOIN (select appraisal_id,supervisor from appraisalSupervisorAssignment where SUPERVISOR_TYPE='s') sup on sup.appraisal_id=ap.ID
                                LEFT JOIN (select appraisal_id,supervisor from appraisalSupervisorAssignment where SUPERVISOR_TYPE='r') rev on rev.appraisal_id=ap.ID
								LEFT JOIN(SELECT appraisalId,commentDate FROM appraisalComments WHERE raterTypeFlag = 'a' and flag='t')aTask on aTask.appraisalId = ap.ID 
                                LEFT JOIN(SELECT appraisalId,commentDate FROM appraisalComments WHERE raterTypeFlag = 'a' and flag='f')apAcpt on apAcpt.appraisalId = ap.ID 
                                LEFT JOIN(SELECT appraisalId,commentDate FROM appraisalComments WHERE raterTypeFlag = 's' and flag='t')sTask on sTask.appraisalId = ap.ID 
                                )m where 1=1").Tables[0];

            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");

            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            double[] sum = new double[cols];

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                   
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
    }
}