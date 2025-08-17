using GemBox.Document;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.JobDescription;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Company.EmployeeWeb.JobDescription
{
    public partial class PrintJd : BasePage
    {
        JobDescriptionCore _job = new JobDescriptionCore();
        private JobDescriptionDAO _db = new JobDescriptionDAO();
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {

            PopulateData();


        }
        #region ReadDecryptQueryString

        private string GetId()
        {
            string id = string.Empty;
            id = string.IsNullOrEmpty(Request.QueryString["Id"]) ? null : Request.QueryString["Id"].ToString();
            return id;
        }

        private string GetStatus()
        {
            string status = Uri.UnescapeDataString(Crypto(Request.QueryString["flag"], false));
            return status;
        }

        private string Crypto(string value, bool isEncrypt = true)
        {
            var forReturn = "";
            if (isEncrypt)
                forReturn = Cryptographer.Encrypt(value, Cryptographer.PrivateKey());
            else
                forReturn = Cryptographer.Decrypt(value, Cryptographer.PrivateKey());

            return forReturn;
        }
        #endregion

        private void PopulateData()
        {
            var jobDetails = _db.ReturnData(GetId());
            if (jobDetails != null)
            {
                txtJobHolder.Text = jobDetails.EmpId;
                AckJdEmp.Text = jobDetails.EmpId;
                lblBranch.Text = jobDetails.BranchId;
                lblFuncTitle.Text = jobDetails.FunctionalId;
                lblCorpTitle.Text = jobDetails.PositionId;
                txtSuperVis.Text = jobDetails.SuperVisor;
                AckJdSuv.Text = jobDetails.SuperVisor;
                AckdateEmp.Text = GetStatic.FormatData(jobDetails.EmpDate, "D");
                AckdateSuv.Text = GetStatic.FormatData(jobDetails.SuvDate, "D");
                lblFiscal.Text = jobDetails.FiscalYear;
                startDate.Text = GetStatic.FormatData(jobDetails.StartDate, "D");
                endDate.Text = GetStatic.FormatData(jobDetails.EndDate, "D");
                txtKeyComp.InnerText = jobDetails.KeyCompetent;
                txtGeneralJd.InnerText = jobDetails.GeneralJd;
                txtObj.InnerText = jobDetails.FunctionalObjectives;


                DataTable dt = _db.GetData(GetId());
                if (dt.Rows.Count > 0)
                {
                    int sno = 1;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("<table border='1' >");
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<th style='text-align:center'>SNo</th>");
                    sb.AppendLine("<th style='text-align:center'>Staff Name</th>");
                    sb.AppendLine("</tr>");
                    foreach (DataRow dr in dt.Rows)
                    {
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td align=\"left\">" + sno + "</td>");
                        sb.AppendLine("<td align=\"left\">" + dr["RptStaff"].ToString() + "</td>");
                        sb.AppendLine("</tr>");
                        sno++;
                    }
                    sb.AppendLine("</table>");
                    rptDiv.InnerHtml = sb.ToString();
                }
                

            }

        }

    }
}