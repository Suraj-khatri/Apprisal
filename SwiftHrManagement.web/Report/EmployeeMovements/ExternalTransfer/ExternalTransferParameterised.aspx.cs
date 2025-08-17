using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.Core.Domain;
//using SwiftHrManagement.DAL;
//using SwiftHrManagement.ReportEnging.EmployeeMovements.ExternalTransferPlan;

namespace SwiftHrManagement.web.Report.EmployeeMovements.ExternalTransfer
{
    public partial class ExternalTransferParameterised : BasePage
    {
        //ExternalTransferPlanParameterised _parameterised = null;
        //public ExternalTransferParameterised()
        //{
        //    this._parameterised = new ExternalTransferPlanParameterised();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDdlBranch();
        }
        private void PopulateDdlBranch()
        {
            BranchDao branchdao = new BranchDao();
            List<BranchCore> branchlist = branchdao.FindBranchName();
            if (branchlist != null && branchlist.Count > 0)
            {
                BranchCore DefaultBrn = new BranchCore();
                DefaultBrn.Name = "Select Branch";
                branchlist.Insert(0, DefaultBrn);
                this.DdlBranchName.DataSource = branchlist;
                this.DdlBranchName.DataTextField = "Name";
                this.DdlBranchName.DataValueField = "Id";
                this.DdlBranchName.DataBind();
                this.DdlBranchName.SelectedIndex = 0;
            }
        }
        protected void BtnViewRpt_Click(object sender, EventArgs e)
        {
            String rpttype="";
            if (RdbListRptType.Text == "Planned")
                rpttype = "Planned";
            else
                rpttype = "Approved";
            ReadSession().RptQuery = null; /*_parameterised.ExternalTransPlnPrm(this.ReadSession().Branch_Id, int.Parse(DdlBranchName.SelectedValue), TxtfromDate.Text, TxtToDate.Text, rpttype);*/
            Response.Redirect("ExternalTransferParam.aspx");
        }
    }
}
