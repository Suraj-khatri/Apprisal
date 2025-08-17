using System;

namespace SwiftHrManagement.web.Report.EmployeeMovements.InternalTransfer
{
    public partial class ManageInternalTransferPlanRpt : BasePage
    {
        //InternalTransferPlanRpt _internalTransRpt = null;
        //public ManageInternalTransferPlanRpt()
        //{
        //    this._internalTransRpt = new InternalTransferPlanRpt();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnShowRpt_Click(object sender, EventArgs e)
        {
            String sSql = null; /*_internalTransRpt.EmpInternalTransferQuryStr(TxtFromDate.Text, TxtToDate.Text);*/
            this.ReadSession().RptQuery = sSql;
            Response.Redirect("InternalTransferPlanSummery.aspx");
        }
    }
}
