using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveIndividualReportFind : BasePage
    {
        clsDAO CLsDAo = null;
        LeaveSummaryReport _leaveSummary = null;
        public LeaveIndividualReportFind()
        {
            CLsDAo = new clsDAO();
            _leaveSummary = new LeaveSummaryReport();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
            }
            FillEmloyeeName();
            txtemployee.Enabled = false;
        }
        private String GetEmployeeId()
        {
            return ReadSession().Emp_Id.ToString();
        }
        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DdlYearIndividual, "select nplYear from Fiscal_Month where DefaultYr = 'N' order by cast(nplYear as int) desc", "nplYear", "nplYear", "", "");
        }
        private void FillEmloyeeName()
        {
            txtemployee.Text = CLsDAo.GetSingleresult("SELECT dbo.GetEmployeeFullNameOfId(EMPLOYEE_ID) EMPLOYEENAME FROM Employee WHERE EMPLOYEE_ID =" + filterstring(GetEmployeeId()));
        }

        protected void btnCurrent_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _leaveSummary.FindLeaveIndividualReport("c", GetEmployeeId(), DdlYearIndividual.Text).ToString();

            Response.Redirect("LeaveIndividualReport.aspx?"
                + "&empid=" + GetEmployeeId()
                + "&flag=c");
        }

        protected void btnHistory_Click(object sender, EventArgs e)
        {
            this.ReadSession().RptQuery = _leaveSummary.FindLeaveIndividualReport("h", GetEmployeeId(), DdlYearIndividual.Text).ToString();

            Response.Redirect("LeaveIndividualReport.aspx?year=" + DdlYearIndividual.Text
                + "&empid=" + GetEmployeeId()
                + "&flag=h");
        }
    }
}
