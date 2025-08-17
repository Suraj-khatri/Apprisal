using System;
using System.Data;
using System.Linq;
using System.Text;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;


namespace SwiftHrManagement.web.LetterTemplate
{
    public partial class LetterReport : System.Web.UI.Page
    {
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            string DocType = Request.QueryString["DocType"] == null ? "" : Request.QueryString["DocType"].ToString();
            string EmpId = Request.QueryString["EmpId"] == null ? "" : Request.QueryString["EmpId"].ToString();
            int count = 0;
            string[] Emp_id =new string[]{};

            StringBuilder str = new StringBuilder("");

            Emp_id = EmpId.Split(',');
            count = Emp_id.Count();
            
            for (int j =0; j<=count-1; j++)
            {
               
                DataTable dt = _clsDao.getDataset("Exec proc_parseLetterTemplate @Employee_id='" + Emp_id[j] + "',@lt_id=" + DocType + "").Tables[0];
                str.Append("<P CLASS=\"pagebreakhere\"><table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"0\" align=\"center\">");
                str.Append("<tr>");
                int cols = dt.Columns.Count;
                str.Append("</tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }

                    str.Append("</tr>");
                }
                str.Append("</table></p>");
                
            }
            rptDiv.InnerHtml = str.ToString(); 
        }
    }
}
