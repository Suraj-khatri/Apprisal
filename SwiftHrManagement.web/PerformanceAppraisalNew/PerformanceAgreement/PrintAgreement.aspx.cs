using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
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

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement
{
    public partial class PrintAgreement : BasePage
    {
        PerformanceAgreementDao _Obj = null;
        PerformanceReviewDao _ObjR = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public PrintAgreement()
        {
            _Obj = new PerformanceAgreementDao();
            _ObjR = new PerformanceReviewDao();
            _RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateDataByEmployeeId();
            LoadGrid();
            LoadGridCJ();
            LoadGridTranning();
            LoadGridRating();
            LoadGridAck();
        }
        private void PopulateDataByEmployeeId()
        {

            var res = _Obj.SelectByIdPerformance(GetEmpID(), GetAppID(), ReadSession().Emp_Id.ToString());
            if (res == null)
                return;

            txtJobHolder.Text = res["EMPNAME"].ToString();

            currentBranch.Text = res["BRANCH_NAME"].ToString();
            currentDepartment.Text = res["DEPARTMENT_NAME"].ToString();
            lblFuncTitle.Text = res["FunctionalTitle"].ToString();
            lblCorpTitle.Text = res["CURRPOSITION"].ToString();
            lbljoiningDate.Text = res["joiningDate"].ToString();
            timeSpentInTheCurrentBranchDept.Text = res["timeSpentOnCurrBranch"].ToString();
            timeSpentInTheCurrentPosition.Text = res["timeSpentOnCurrPosition"].ToString();
            txtSuperVis.Text = res["supervisorName"].ToString();
            LblReviewingOfficer.Text = res["reviewerName"].ToString();
            startDate.Text = res["appraisalStartDate"].ToString();
            endDate.Text = res["appraisalEndDate"].ToString();
            SigName.Text= res["EMPNAME"].ToString();
            SigSuv.Text= res["supervisorName"].ToString().Split('|')[0];
            SigRev.Text= res["reviewerName"].ToString();
            lblFiscal.Text = res["FiscalYear"].ToString();


        }
        private void LoadGridCJ()
        {

           
            var dt = _Obj.GetCriticalJobsDate(GetEmpID(), GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                criticalJobs_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";

            }else
            {
                StringBuilder sb = new StringBuilder();
                int sno = 0;
                foreach (DataRow item in dt.Rows)
                {
                    string rowId = item["RowId"].ToString();
                    sno++;

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + sno + "</td>");
                    sb.AppendLine("<td>" + item["objectives"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["deductionScore"].ToString() + "</td>");



                    sb.AppendLine("</tr>");
                }

                criticalJobs_grid.InnerHtml = sb.ToString();

            }



        }
        private string GetEmpID()
        {

            return Crypto(GetStatic.ReadQueryString("empId", ""), false);
        }
        private string GetAppID()
        {
            if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("appId", "")))
            {
                return Crypto(GetStatic.ReadQueryString("appId", ""), false);
            }

            return "";
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
        private void LoadGrid()
        {
           

            var dt = _Obj.GetPrintKraList(GetAppID());
            int sn = 1;
            decimal totalKRASum = 0;
            decimal totalKPISum = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var item in dt.GroupBy(x => x.KraTopic))
            {

                
                int rowcount = item.Count() + 1;
                sb.AppendLine("<tr>");


              
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + sn + "</td>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().KraTopic.ToString() +
                                  "</td>");
                    //sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().kraWeightage.ToString() +
                    //              "</td>");
                    totalKRASum += Convert.ToDecimal(item.FirstOrDefault().kraWeightage);
              

                sn++;
                sb.AppendLine("</tr>");
                foreach (var item1 in item)
                {
                    sb.AppendLine("<tr>");
                    
                        sb.AppendLine("<td>" + item1.KpiTopic + "</td>");
                        sb.AppendLine("<td>" + item1.KpiWeightage + "</td>");
                        totalKPISum += item1.KpiWeightage;
                       
                    

                    sb.AppendLine("</tr>");
                }
            }

            sb.AppendLine("<tr>");
            sb.AppendLine("<td colspan=\"3\" align=\"right\"> Total Sum </td>");
            sb.AppendLine("<td colspan=\"2\" align=\"right\">" + totalKPISum + "</td>");
            sb.AppendLine("</tr>");

            kra_grid.InnerHtml = sb.ToString();
         

        }
        private void LoadGridTranning()
        {

            var dt = _Obj.GetProposedTrainingData(GetEmpID(), GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null || dt.Columns.Count == 3)
            {
                perfTranning_grid.InnerHtml =
                    "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
              
                return;
            }

           

            StringBuilder sb = new StringBuilder();
            int sno = 0;
            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString() ?? "";
                sno++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sno + "</td>");
                

                    sb.AppendLine("<td>" + item["ProposedTrainingArea"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["Criticality"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["ProposedByDate"].ToString() + "</td>");
                   
               

                sb.AppendLine("</tr>");
            }

            perfTranning_grid.InnerHtml = sb.ToString();
           
        }
        private void LoadGridRating()
        {
            var dt = _Obj.GetPerformanceRatingData();

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                perfRatingRef_grid.InnerHtml =
                    "<tr><td colspan=\"2\" align=\"center\"> No Records to display.</td></tr>";
            
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (DataRow item in dt.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");

                sb.AppendLine("</tr>");
            }

            perfRatingRef_grid.InnerHtml = sb.ToString();
           
        }

        private void LoadGridAck()
        {
          
        
            int supervisorid = 0, empId = 0, ReviewerId = 0, status = 0;

            var ds = _Obj.AckData(GetEmpID(), GetAppID());
            DataTable res = ds.Tables[0];
            DataTable revStatus = ds.Tables[1];
            status = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["STATUS"].ToString()) ? "0" : revStatus.Rows[0]["STATUS"].ToString());
            supervisorid = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["supervisorId"].ToString()) ? "0" : revStatus.Rows[0]["supervisorId"].ToString());
            empId = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["employeeId"].ToString()) ? "0" : revStatus.Rows[0]["employeeId"].ToString());
            ReviewerId = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["reviewerId"].ToString()) ? "0" : revStatus.Rows[0]["reviewerId"].ToString());
            var IsAdmin = _Obj.CheckHrAdmin(ReadSession().Emp_Id.ToString());
            
            
            foreach (DataRow dr in res.Rows)
            {

                if (dr["commenterType"].ToString() == "Supervisor")
                {
                 
                    SigSuvDate.Text = Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                  

                }
                else if (dr["commenterType"].ToString() == "Appraise")
                {

                    txt_disReason.Text = dr["comment"].ToString();
                    SigNameDate.Text = Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");

                }
                
                else if (dr["commenterType"].ToString() == "Reviewer")
                {

                    txt_disReason.Text = dr["comment"].ToString();
                    SigRevDate.Text = Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                   

                }
                else if (dr["commenterType"].ToString() == "HRD")
                {

                    HrdComment.Text = dr["comment"].ToString();
                    HrdName.Text = dr["Employeee"].ToString();
                    hrdDate.Text =  Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                  

                }
               



            }
          

        

        }

    }
}