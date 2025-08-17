using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.EmployeeMovement.ExternalTransferPlan
{
    public partial class exportTransfer : BasePage
    {
       clsDAO _clsdao = null;
       public exportTransfer()
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

            DataTable dt = _clsdao.getDataset(@"SELECT ETP.ID
                        ,dbo.GetBranchName(FROM_BRANCH) AS FROM_BRANCH
                        ,dbo.GetDeptName(FROM_DEPARTMENT) AS FROM_DEPARTMENT, 
                        dbo.GetEmployeeFullNameOfId(STAFF_ID) AS STAFF_ID
                        ,dbo.GetBranchName(WHICH_BRANCH) AS WHICH_BRANCH,
                        dbo.GetDeptName(WHICH_DEPARTMENT) AS WHICH_DEPARTMENT,
                        convert(varchar,ETP.EFFECTIVE_DATE,107) as EFFECTIVE_DATE, 
                        convert(varchar,ETP.ACTUAL_REPORT_DATE,107) as ACTUAL_REPORT_DATE,
                        TRANSFER_DESCRIPTION,status,
                        dbo.GetEmployeeFullNameOfId(ETP.CREATED_BY)	CREATED_BY
                        ,TRANSFER_TYPE = case TRANSFER_TYPE when 'i' then 'Internal' when 'e' then 'External' else 'Deployment' end
                    FROM ExternalTransferPlan ETP
                    inner join Employee e on ETP.STAFF_ID = e.EMPLOYEE_ID
                    where TRANSFER_TYPE IN ('e','i','d') and status in('Recommended','Approved')").Tables[0];

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