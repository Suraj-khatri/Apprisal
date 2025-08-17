using System;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.Report.TrainingRpt
{
    public partial class DetailedRpt : BasePage
    {
        clsDAO _clsDAO = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public DetailedRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDAO = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive col-md-12\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblDate.Text = DateTime.Now.ToLongDateString();

            string startDate = Request.QueryString["startDate"] == "" ? "null" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == "" ? "null" : Request.QueryString["endDate"].ToString();
            string ddlTrainingType = Request.QueryString["trainingType"] == "" ? "null" : Request.QueryString["trainingType"].ToString();

            lblFromDate.Text = startDate;
            lblToDate.Text = endDate;

            DataTable dt1 = _clsDAO.getDataset("EXEC [ProcRptTraining] @FLAG='b',@startDate=" + filterstring(startDate) + ",@endDate=" +
                    filterstring(endDate) + ",@trainingType=" + filterstring(ddlTrainingType) + "").Tables[0];
            int cols1 = dt1.Columns.Count;

            foreach (DataRow dr in dt1.Rows)
            {

                for (int i = 0; i < cols1; i++)
                {
                    DataTable dt = _clsDAO.getDataset(@"select ROW_NUMBER() OVER(ORDER BY ID) [S.N.],dbo.GetBranchName(branchId) [Branch Name],
                        dbo.GetDeptName(deptId) [Department Name] ,dbo.GetEmployeeFullNameOfId(employeeId) [Employee Name],dbo.GetDetailTitle(positionId) [Position] 
                        from trainingParticipation where trainingId=" + filterstring(dr[i].ToString()) + "").Tables[0];

                    int cols = dt.Columns.Count;
                    int rows = dt.Rows.Count;
                    
                    str1.Append("<tr>");
                    str1.Append("<td align=\"left\" colspan=\"" + cols + "\">&nbsp;</td>");
                    str1.Append("</tr>");
                    str1.Append("<tr>");
                    str1.Append("<th align=\"left\" colspan=\"" + cols + "\"><u>" + dr[i + 1].ToString() + "</u></th>");
                    str1.Append("</tr>");
                    if (rows > 0)
                    {
                        str1.Append("<tr>");
                        for (int l = 0; l < cols; l++)
                        {
                            str1.Append("<td align=\"left\"><b>" + dt.Columns[l].ColumnName.ToString() + "</b></td>");
                        }
                        str1.Append("</tr>");

                        foreach (DataRow dr1 in dt.Rows)
                        {
                            str1.Append("<tr>");
                            for (int j = 0; j < cols; j++)
                            {
                                str1.Append("<td align=\"left\">" + dr1[j].ToString() + "</td>");
                            }
                            str1.Append("</tr>");
                        }
                    }
                    else
                    {
                        str1.Append("<tr>");

                        str1.Append("<td align=\"center\" colspan=\"" + cols + "\"><b>No Added Nominees!</b></td>");
                       
                        str1.Append("</tr>");
                    }
                    i++;
                }
            }

            str1.Append("</table></div>");
            rptDiv.InnerHtml = str1.ToString();
        }
    }
}