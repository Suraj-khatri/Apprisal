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

namespace SwiftHrManagement.web.Report.OnThe_Job_and_Buddy
{
    public partial class TrainingWiseReport : BasePage
    {
        clsDAO _clsdao = null;
        public TrainingWiseReport()
        {
         _clsdao = new clsDAO();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            populatetitle();
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
            DataTable dt = _clsdao.getDataset("exec [procOJTWiseReport] 'e'," + filterstring(From) + "," + filterstring(To) + "," + filterstring(BranchId) + "," + filterstring(DeptId) + "," + filterstring(EmpId) + "," + filterstring(Train) + "").Tables[0];
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
            string BranchId = Request.QueryString["Branch"] == null ? "" : Request.QueryString["Branch"].ToString();
            string DeptId = Request.QueryString["Depart"] == null ? "" : Request.QueryString["Depart"].ToString();
            string EmpId = Request.QueryString["Emp"] == null ? "" : Request.QueryString["Emp"].ToString();
            string from = Request.QueryString["From"] == null ? "" : Request.QueryString["From"].ToString();
            string to = Request.QueryString["To"] == null ? "" : Request.QueryString["To"].ToString();

            if (BranchId == "")
            {
                BranchId = "0";

            }

            if (DeptId == "")
            {
                DeptId = "0";

            }

            if (EmpId == "")
            {
                EmpId = "0";

            }

            DataTable dt = new DataTable();

            dt = _clsdao.getDataset("select dbo.[GetBranchName](" + BranchId + ") as branch, "
            + " dbo.GetEmployeeFullNameOfId(" + EmpId + ")as Emp,dbo.GetDeptName(" + DeptId + ")as dept ").Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                lblbranch.Text = dr["branch"].ToString();
                lbldepartmant.Text = dr["dept"].ToString();
                lblEmployeeName.Text = dr["Emp"].ToString();

            }

            if (BranchId == "0")
                lblbranch.Text = "ALL";


            if (EmpId == "0")
                lblEmployeeName.Text = "ALL";


            if (DeptId == "0")
                lbldepartmant.Text = "ALL";

            this.DateFrom.Text = from;
            this.DateTo.Text = to;
        }
    }
}
