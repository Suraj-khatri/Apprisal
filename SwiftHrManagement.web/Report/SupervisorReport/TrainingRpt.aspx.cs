using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.SupervisorReport
{
    public partial class TrainingRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public TrainingRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
            }
        }
        #region
        //made by bibhut
        public string LoadTrainRpt(string from,string to,string emp_id)
        {
            return "EXEC [ProcSupervisorSummaryRpt] @FLAG='T',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" +
                   filterstring(to) + ","
                   + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" +
                   filterstring(emp_id);
        }
        #endregion
        private void loadReport()
        {           
            StaticPage sPage = new StaticPage();
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
            lblFromDate.Text = from;
            lblToDate.Text = to;
            lblToDate.ForeColor = System.Drawing.Color.Black;
            lblFromDate.ForeColor = System.Drawing.Color.Black;


            StringBuilder str = new StringBuilder("<table class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            DataTable dt = _clsDao.getTable("EXEC [ProcSupervisorSummaryRpt] @FLAG='T',@FROM_DATE=" + filterstring(from) + ",@TO_DATE=" + filterstring(to) + ","
            + " @SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@EMPLOYEE_ID=" + filterstring(emp_id) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {                
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            str.Append("</tr>");
        
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i==5 || i==6 || i==8)
                    {
                        str.Append("<td><div align=\"center\">" + dr[i].ToString() + "</div></td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
     }
}

