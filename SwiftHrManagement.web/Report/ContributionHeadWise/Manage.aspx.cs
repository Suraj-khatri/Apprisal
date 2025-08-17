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

namespace SwiftHrManagement.web.Report.ContributionHeadWise
{
    public partial class Manage : System.Web.UI.Page
    {
        clsDAO CLsDAo = null;

        public Manage()
        {
            this.CLsDAo = new clsDAO();
        }
         
          
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDdl();
            }


        }
        private void populateDdl()
        {
            CLsDAo.CreateDynamicDDl(DdlFiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlBranchType, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }

    
        protected void DdlBranchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlDepartment.Items.Clear();
            if (DdlBranchType.Text != "")
            {
                CLsDAo.CreateDynamicDDl(DdlDepartment, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + DdlBranchType.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            } 
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/ContributionHeadWise/ManageReprot.aspx?FY="+DdlFiscalYear.Text+"&branchId="+DdlBranchType.Text+"&deptId="+DdlDepartment.Text+"&rptType="+ddlReport.Text+"");

        }
    }
}
