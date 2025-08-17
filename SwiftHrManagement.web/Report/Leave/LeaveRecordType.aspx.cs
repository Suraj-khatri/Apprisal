using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.DAL.LeaveManagementModule;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveRecordType : BasePage
    {
        
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        BranchCore _branchCore = null;
        BranchDao _branch = null;
        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;
        LeaveSummaryReport _leaveSummary = null;
        clsDAO CLsDAo = null;
        string currPage = "";
         DynamicRpt _rpt = null;
        public LeaveRecordType()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();
            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
            this._leaveSummary = new LeaveSummaryReport();
            this.CLsDAo = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
            populatetitle();
        }


        private void populatetitle()
        {
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string branchid = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string departmentid = Request.QueryString["departmentId"] == null ? "" : Request.QueryString["departmentId"].ToString();
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();

            if (branchid == "")
            {
                branchid = "0";

            }

            if (departmentid == "")
            {
                departmentid = "0";

            }

            if (empid == "")
            {
                empid = "0";

            }

            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("select dbo.[GetBranchName](" +branchid+ ") as branch, "
                + " dbo.GetEmployeeFullNameOfId(" + empid + ")as Emp,dbo.GetDeptName(" + departmentid + ")as dept ").Tables[0];


            foreach (DataRow dr in dt.Rows)
            {
                lblbranch.Text = dr["branch"].ToString();
                lbldepartmant.Text = dr["dept"].ToString();
                lblEmployeeName.Text = dr["Emp"].ToString();

            }

            if (branchid == "0")
                lblbranch.Text= "ALL";


            if (empid == "0")
                lblEmployeeName.Text = "ALL";


            if (departmentid == "0")
               lbldepartmant.Text = "ALL";

            this.DateFrom.Text = from;
            this.DateTo.Text = to;
        }





        private void loadReport()
        {

           
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string branch = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string department = Request.QueryString["departmentId"] == null ? "" : Request.QueryString["departmentId"].ToString();
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();


        //    DataTable dt = _leaveSummary.FindLeavesummaryReport(this.ReadSession().RptQuery).Tables[0];

        //    str.Append("<tr>" +
        //                " <th rowspan='2'>Employee Code </th> " +
        //                " <th rowspan='2'>Employee Name </th> " +
        //                "  <th colspan='3'>Casual Leave  </th> " +
        //                " <th colspan='3'>Sick Leave </th> " +
        //                " <th colspan='3'>Annual Leave </th> " +
        //                " <th colspan='7'>Other Leave </th> " +
        //                "</tr>" +
        //                "<tr>" +
        //                " <th>Earned</th> " +
        //                " <th>Used</th> " +
        //                " <th>Balance</th> " +
        //                "  <th>Earned</th> " +
        //                "  <th>Used</th> " +
        //                "  <th>Balance</th> " +
        //                "  <th>Earned</th> " +
        //                "  <th>Used</th> " +
        //                "  <th>Balance</th> " +
        //                " <th>Contract</th> " +
        //                " <th>Mourning</th> " +
        //                " <th>Maternity</th> " +
        //                " <th>Special</th> " +
        //                " <th>Unpaid</th> " +
        //                " <th>Education/Training</th> " +
        //                " </tr>");

        //    //str.Append("<tr>");

        //    int cols = dt.Columns.Count;

        //    //for (int i = 0; i < cols; i++)
        //    //{
        //    //    str.Append("<th align=\"right\">" + dt.Columns[i].ColumnName + "</th>");
        //    //}
        //    //str.Append("</tr>");


        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        str.Append("<tr>");
        //        for (int i = 0; i < cols; i++)
        //        {
        //            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
        //        }
        //        str.Append("</tr>");
        //    }

        //    str.Append("</table>");
        //    rptDiv.InnerHtml = str.ToString();
            //var ds = _leaveSummary.FindLeavesummaryReport(this.ReadSession().RptQuery);
            DataSet ds =CLsDAo.getDataset("EXEC [ProcLeaveSummaryRecords] " + filterstring(branch) + "," + filterstring(department) + ", " + filterstring(empid) + ",'" + from + "','" + to + "'");
            rptDiv.InnerHtml = MakeLeaveReport(ref ds);
        }
        private string MakeLeaveReport(ref DataSet ds)
        {
            var dtHead = ds.Tables[0];
            var dtDetail = ds.Tables[1];

            var str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            str.Append("<tr>");

            str.Append("<th align=\"left\" rowspan = \"2\">Employee Id</th>");
            str.Append("<th align=\"left\" rowspan = \"2\">Name</th>");

            foreach (DataRow dr in dtHead.Rows)
            {
                var columnName = dr["NAME_OF_LEAVE"];
                str.Append("<th align=\"center\" colspan = \"3\">" + columnName + "</th>");
            }
            str.Append("</tr>");


            str.Append("<tr>");
            foreach (DataRow dr in dtHead.Rows)
            {
                str.Append("<th>Earned</th>");
                str.Append("<th>Used</th>");
                str.Append("<th>Balance</th>");
            }
            str.Append("</tr>");


            var cols = dtDetail.Columns.Count;

            foreach (DataRow dr in dtDetail.Rows)
            {
                str.Append("<tr>");
                for (var i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");

            return str.ToString();

        }
    }
}
