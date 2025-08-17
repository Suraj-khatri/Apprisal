using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;
using SwiftHrManagement.ReportEnging.TrainingProgram;

namespace SwiftHrManagement.web.Report.Training
{
    public partial class UpcomongOrPlannedTrainingrpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;

        BranchCore _branchCore = null;
        BranchDao _branch = null;

        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;

        TrainingProgramUpComingOrPlanned _trainingprogramUpcoming = null;
        string currPage = "";
        public UpcomongOrPlannedTrainingrpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();

            this._branch = new BranchDao();
            this._branchCore = new BranchCore();

            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();

            _trainingprogramUpcoming = new TrainingProgramUpComingOrPlanned();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\"");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            DataTable dt = _trainingprogramUpcoming.UpcomingorPlannedTraining(this.ReadSession().RptQuery).Tables[0];
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\"><a \"" + currPage + "?branch= " + dr[1] + "& id2=" + dr[2] + "href \"" + ">" + dr[i].ToString() + "</a></td>");
                }
                str.Append("</tr>");
            }
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
