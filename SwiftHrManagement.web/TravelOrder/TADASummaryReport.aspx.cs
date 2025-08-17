using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.web.DAL.TravelOrder;


namespace SwiftHrManagement.web.TravelOrder
{
    public partial class TADASummaryReport : BasePage
    {
        TravelOrderDao _travel = null;              
        clsDAO CLsDAo = null;
        String Flag = "a";

        public TADASummaryReport()
        {
            CLsDAo = new clsDAO();
            this._travel = new TravelOrderDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
                
            }  
        }

        private void PopulateDropDownList()
        {
            CLsDAo.CreateDynamicDDl(DDL_YEAR,"SELECT nplYear FROM Fiscal_Month","nplYear","nplYear","","SELECT");
            DDL_YEAR.SelectedValue = CLsDAo.GetSingleresult("SELECT nplYear FROM Fiscal_Month WHERE DefaultYr='Y'");
        }

        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }
        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }

        protected void btnDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("TADAReportYearWise.aspx?year=" + DDL_YEAR.Text + "&emp_id=" + getEmpIdfromInfo(lblEmpName.Text) + "&flag=L");
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";
        }

        
    }
}