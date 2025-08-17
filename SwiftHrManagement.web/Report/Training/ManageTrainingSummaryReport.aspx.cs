using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.ReportEnging.TrainingProgram;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.Training
{
    public partial class ManageTrainingSummaryReport : BasePage
    {
        TrainingSummary _trainingSummary = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public ManageTrainingSummaryReport()
        {
            this._trainingSummary = new TrainingSummary();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 75) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            String sQl = _trainingSummary.FindTrainingSummaryReport(TxtFromDate.Text, TxtToDate.Text);
            this.ReadSession().RptQuery = sQl;
            Response.Redirect("TrainingSummaryReport.aspx");
        }

    }
}
