using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.LeaveManagementModule.LeaveAssignment
{
    public partial class exportLeave : BasePage
    {
       clsDAO _clsdao = null;
       public exportLeave()
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

            DataTable dt = _clsdao.getDataset(@"SELECT * FROM 
                                                (SELECT LA.ID,e.EMP_CODE,E.FIRST_NAME+' '+E.MIDDLE_NAME+' '+E.LAST_NAME as EMPLOYEE 
                                                ,LA.EMPLOYEE_ID as emp_ID 
                                                ,LT.NAME_OF_LEAVE as LEAVE_TYPE_ID 
                                                ,CONVERT(VARCHAR,LA.FROMDATE,107) as FROM_DATE 
                                                ,CONVERT(VARCHAR,LA.TODATE,107) as TO_DATE 
                                                ,LA.NO_OF_DAYS_ACTUAL 
                                                ,ISNULL(LAST_YEAR_LEAVE,0) as LAST_YEAR_LEAVE 
                                                ,ISNULL(LA.LEAVE_TAKEN_THIS_YEAR,0) as LEAVE_TAKEN_THIS_YEAR 
                                                ,CASE WHEN ISNULL(La.IS_UNLIMITED,0)=1 THEN 0  ELSE 
                                                ISNULL(LA.NO_OF_DAYS_ACTUAL,0)+ISNULL(LAST_YEAR_LEAVE,0)-ISNULL(LA.LEAVE_TAKEN_THIS_YEAR,0) END REMAIN_LEAVE 
                                                ,case when LA.IS_DISABLED='1' then 'Yes' when LA.IS_DISABLED='0' then 'No' end as ACTIVE 
                                                ,LFA_Taken = CASE WHEN ISNULL(LFA_Taken,0)=0 THEN 'No' WHEN LFA_Taken = 1 THEN 'Yes' ELSE '-' END 
                                                FROM leaveAssignment AS LA  
                                                inner join Employee E on E.EMPLOYEE_ID=LA.EMPLOYEE_ID 
                                                inner join LeaveTypes LT ON LT.ID=LA.LEAVE_TYPE_ID 
                                                WHERE LA.IS_DISABLED=1)A where 1=1").Tables[0];

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