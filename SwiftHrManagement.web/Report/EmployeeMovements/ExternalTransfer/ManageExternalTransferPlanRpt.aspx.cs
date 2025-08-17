using System;
using System.Collections.Generic;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.Report.EmployeeMovements.ExternalTransfer
{
    public partial class ManageExternalTransferPlanRpt : BasePage
    {
        //ExternalTransferPlanRpt _externalTransRpt = null;   
        //public ManageExternalTransferPlanRpt()
        //{
        //    this._externalTransRpt = new ExternalTransferPlanRpt();
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
                DefaultBrn.Name = "Select";
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
            String sSql = null; /*_externalTransRpt.EmpExternalTransferQuryStr(TxtFromDate.Text, TxtToDate.Text);*/
            this.ReadSession().RptQuery = sSql;
            Response.Redirect("ExternalTransferPlanSummery.aspx");
        }

        protected void BtnSHowRpt_Click(object sender, EventArgs e)
        {
            String rpttype = "";
            if (RdbListRptType.Text == "Planned")
                rpttype = "Planned";
            else
                rpttype = "Approved";
            ReadSession().RptQuery = null;/* _externalTransRpt.ExternalTransPlnPrm(this.ReadSession().Branch_Id, int.Parse(DdlBranchName.SelectedValue), from_date.Text, to_date.Text, rpttype);*/
            Response.Redirect("ExternalTransferParam.aspx");
        }
    }
}
