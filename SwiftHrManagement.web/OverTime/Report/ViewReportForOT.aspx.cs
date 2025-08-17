using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.OverTime.Report
{
    public partial class ViewReportForOT : BasePage
    {

        string currPage = "";
        double TotalAmt = 0;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO CLsDAo = new clsDAO();

        public ViewReportForOT()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        
        }

         protected void Page_Load(object sender, EventArgs e)
         {
             currPage = getCurrPage();
             string mode = ReadQueryString("mode", "").ToLower();
             if (mode == "download")
             {
                 string format = "xls";
                 string reportName = "STOCK";
                 Response.Clear();
                 Response.ClearContent();
                 Response.ClearHeaders();
                 Response.ContentType = "application/vnd.ms-excel";
                 Response.AddHeader("Content-Disposition", "inline; filename=" + reportName + "." + format);
                 exportDiv.Visible = false;
             }

             loadReport();
             populatetitle();

         }

         private void populatetitle()
         {
             string BranchId = Request.QueryString["BranchId"] == null ? "" : Request.QueryString["BranchId"].ToString();
             string DeptId = Request.QueryString["DeptId"] == null ? "" : Request.QueryString["DeptId"].ToString();
             string EmpId = Request.QueryString["empId"] == null ? "" : Request.QueryString["empId"].ToString();
             string from = Request.QueryString["FromDate"] == null ? "" : Request.QueryString["FromDate"].ToString();
             string to = Request.QueryString["ToDate"] == null ? "" : Request.QueryString["ToDate"].ToString();

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

             dt = CLsDAo.getDataset("select dbo.[GetBranchName](" + BranchId + ") as branch, "
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

         private void loadReport()
         {
             string BranchId = Request.QueryString["BranchId"] == null ? "" : Request.QueryString["BranchId"].ToString();
             string DeptId = Request.QueryString["DeptId"] == null ? "" : Request.QueryString["DeptId"].ToString();
             string EmpId = Request.QueryString["empId"] == null ? "" : Request.QueryString["empId"].ToString();
             string from = Request.QueryString["FromDate"] == null ? "" : Request.QueryString["FromDate"].ToString();
             string to = Request.QueryString["ToDate"] == null ? "" : Request.QueryString["ToDate"].ToString();


             string AsDate = Request.QueryString["AsDate"] == null ? "" : Request.QueryString["AsDate"].ToString();
             string flg = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();

             StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\">");
             _CompanyCore = _company.FindCompany();
             this.lblHeading.Text = _CompanyCore.Name;
             this.lbldesc.Text = _CompanyCore.Address;

             DataTable dt = CLsDAo.getDataset("Exec procOtReport @flag='s',@branchId=" + filterstring(BranchId) + ",@deptId=" + filterstring(DeptId) + ","
             + "@emp_id=" + filterstring(EmpId) + ",@from_date=" + filterstring(from) + ",@to_date=" + filterstring(to) + " ").Tables[0];

             str.Append("<tr>");
             int cols = dt.Columns.Count;
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
                     if (i >= 9 || i != cols)
                     {
                         str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                     }
                     else if (i == cols)
                     {
                         str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                     }

                 }

                 str.Append("</tr>");
                 TotalAmt = TotalAmt + ParseDouble(dr[12].ToString());
             }
             str.Append("<tr>" +
           "<td colspan='12' align=\"right\"><b>TOTAL:</b></td>" +
          "<td align=\"right\"><b>" + ShowDecimal(TotalAmt.ToString()) + "</b></td>" +
          "</tr>");
             str.Append("</table>");
             rptDiv.InnerHtml = str.ToString();
         }

         string getCurrPage()
         {
             string raw = Request.RawUrl.ToString();
             int pos = raw.IndexOf('?');
             if (pos > 0)
                 raw = raw.Substring(0, pos);
             return raw;
         }
    }
}