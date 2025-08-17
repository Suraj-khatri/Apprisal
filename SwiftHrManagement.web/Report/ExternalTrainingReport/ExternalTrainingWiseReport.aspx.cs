using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;


namespace SwiftHrManagement.web.Report.ExternalTrainingReport
{
    public partial class ExternalTrainingWiseReport : BasePage
    {
        
        clsDAO _clsdao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ExternalTrainingWiseReport()
        {
         _clsdao = new clsDAO();
         this._roleMenuDao = new RoleMenuDAOInv();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            populatetitle();
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 46) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        private void loadReport()
        {
            string BranchId = Request.QueryString["Branch"] == null ? "" : Request.QueryString["Branch"].ToString();
            string DeptId = Request.QueryString["Depart"] == null ? "" : Request.QueryString["Depart"].ToString();
            string EmpId = Request.QueryString["Emp"] == null ? "" : Request.QueryString["Emp"].ToString();
            string From = Request.QueryString["From"] == null ? "" : Request.QueryString["From"].ToString();
            string To = Request.QueryString["To"] == null ? "" : Request.QueryString["To"].ToString();
            string Train = Request.QueryString["Train"] == null ? "" : Request.QueryString["Train"].ToString();

            lblHeading.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            lbldesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");

            StringBuilder str = new StringBuilder("<table width=\"700\" border=\"1\" align=\"center\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");
            DataTable dt = _clsdao.getDataset("exec [procExternalTrainingReport] 't'," + filterstring(From) + "," + filterstring(To) + "," + filterstring(BranchId) + "," + filterstring(DeptId) + "," + filterstring(EmpId) + "," + filterstring(Train) + "").Tables[0];
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
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

            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void populatetitle()
        {

            string from = Request.QueryString["From"] == null ? "" : Request.QueryString["From"].ToString();
            string to = Request.QueryString["To"] == null ? "" : Request.QueryString["To"].ToString();
            string Train = Request.QueryString["Train"] == null ? "" : Request.QueryString["Train"].ToString();
            if (Train == "")
            {
                Train = "0";

            }

            DataTable dt = new DataTable();

            dt = _clsdao.getDataset("select dbo.[GetTrainingName](" + Train + ") as training ").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                lblbranch.Text = dr["training"].ToString();
            }

            if (Train == "0")
                lblbranch.Text = "ALL";

            this.DateFrom.Text = from;
            this.DateTo.Text = to;
        }
    }
}
