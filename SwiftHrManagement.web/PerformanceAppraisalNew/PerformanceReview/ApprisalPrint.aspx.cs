using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.Models;
using System.Data;
using SwiftHrManagement.web.Model;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceReview
{
    public partial class ApprisalPrint : BasePage
    {
        PerformanceReviewDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO swift = null;
        public ApprisalPrint()
        {
            _Obj = new PerformanceReviewDao();
            _RoleMenuDAOInv = new RoleMenuDAOInv();
            swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1119) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                PopulateDataByEmployeeId();
                LoadGridKRAKPI();
                LoadGridCJ();
                lblApprisalStartDate.Text = effectiveFrom.Text;
                lblApprisalEndDate.Text = effectiveTo.Text;
                LoadGridRating();
                LoadGridTranning();
                LoadGridCompetency();
                LoadGridScore();
                loadSupervisorComment();
                LoaCommitteeGridScore();
                loadReviewerComment();
                LoadComMemberCommentGrid();
                Session["StS"] = GetStatus();
            }
        }
        private void PopulateDataByEmployeeId()
        {
            string appid = GetAppID(), EMpId = GetEmpID();
            var res = _Obj.SelectByIdPerformanceReview(EMpId,appid);
            if (res == null)
                return;

            lblEmpName.Text = res["EMPNAME"].ToString();
            currentBranch.Text = res["BRANCH_NAME"].ToString();
            currentDepartment.Text = res["DEPARTMENT_NAME"].ToString();
            currentFunctionalTitle.Text = res["CURRPOSITION"].ToString();
            currentPosition.Text = res["CURRPOSITION"].ToString();
            dateOfJoining.Text = res["joiningDate"].ToString();
            timeSpentInTheCurrentBranchDept.Text = res["timeSpentOnCurrBranch"].ToString();
            timeSpentInTheCurrentPosition.Text =res["timeSpentOnCurrPosition"].ToString();
            nameAndFUnctionalDesignationOfSupervisor.Text = res["supervisorName"].ToString();
            nameAndFunctionalDesignationOfReviewingOfficer.Text = res["reviewerName"].ToString();
            Session["supervisorName"] = res["supervisorName"].ToString();
            Session["reviewerName"] = res["reviewerName"].ToString();
            Session["EmpName"] = res["EMPNAME"].ToString();
            Session["FiscalYear"] = res["FiscalYear"].ToString();
            Session["reviewerPosition"] = res["reviewerPosition"].ToString();
            effectiveFrom.Text = res["appraisalStartDate"].ToString();
            effectiveTo.Text = res["appraisalEndDate"].ToString();



        }
        private string GetEmpID()
        {

            return GetStatic.ReadQueryString("empId", "");
        }
        private string GetAppID()
        {
            if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("appId", "")))
            {
                return GetStatic.ReadQueryString("appId", "");
            }
            return "";
        }
        private string GetStatus()
        {
            if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("status", "")))
            {
                return GetStatic.ReadQueryString("status", "");
            }
            return "";
        }
        private void loadSupervisorComment()
        {

            var dt = _Obj.getSupervisorComment(GetEmpID(), GetAppID());
            var Empdata = _Obj.getAppraiseeComment(GetEmpID(), GetAppID());
            if (dt.Rows.Count != 0 && dt != null)
            {
                txtan1.Text = "";
                txtan2.Text = "";
                txtan3.Text = "";
                txtan4.Text = "";
                txtan5.Text = "";
                if (dt.Rows.Count >= 1)
                {
                    txtan1.Text = dt.Rows[0]["comment"].ToString();
                }

                if (dt.Rows.Count >= 2)
                {
                    txtan2.Text = dt.Rows[1]["comment"].ToString();
                }

                if (dt.Rows.Count >= 3)
                {
                    txtan3.Text = dt.Rows[2]["comment"].ToString();
                }

                if (dt.Rows.Count >= 4)
                {
                    txtan4.Text = dt.Rows[3]["comment"].ToString();
                }

                if (dt.Rows.Count == 5)
                {
                    txtan5.Text = dt.Rows[4]["comment"].ToString();
                }

                if (!String.IsNullOrEmpty(dt.Rows[4]["remarks"].ToString()))
                {
                    SupervisorRemarks.Text = dt.Rows[4]["remarks"].ToString();
                }
               

                string sup = dt.Rows[0]["commentBy"].ToString();
                
               
                Session["SupDate"]= String.IsNullOrEmpty(dt.Rows[0]["createdDate"].ToString())?" ": dt.Rows[0]["createdDate"].ToString();
                if (Empdata.Rows.Count > 0)
                {
                    Session["AppriseDate"] = String.IsNullOrEmpty(Empdata.Rows[0]["createdDate"].ToString()) ? " " : Empdata.Rows[0]["createdDate"].ToString();
                }
               


            }
            else
            {

                return;
            }

        }
        private void LoadGridKRAKPI()
        {

            List<KraKpiGrid> dt = _Obj.GetKRAKPIData(GetEmpID(), GetAppID());

            if (dt.Count == 0 || dt == null)
            {
                kra_grid.InnerHtml = "<tr><td colspan=\"9\" align=\"center\"> No Records to display.</td></tr>";

                //var dt1 = _Obj.getLevelDT();
                return;
            }
            // btnSaveKRAKPI.Text = "Update & Next";
            int sn = 1;
            decimal kpiTotal = 0;

            StringBuilder sb = new StringBuilder();

            foreach (var item in dt.GroupBy(x => x.KraTopic))
            {
                int rowcount = item.Count() + 1;

                if (rowcount > 2)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + sn + "</td>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().KraTopic + "</td>");
                    sb.AppendLine("</tr>");
                    foreach (var item1 in item)
                    {
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td>" + item1.KpiTopic + "</td>");
                        sb.AppendLine("<td>" + item1.KpiWeightage + "</td>");
                        kpiTotal += item1.KpiWeightage;
                        sb.AppendLine("<td>" + GetStatic.ShowDecimal(item1.Variance.ToString()) + "</td>");
                        sb.AppendLine("<td>" + GetStatic.ShowDecimal(item1.performanceScore.ToString()) + "</td>");
                        sb.AppendLine("<td>" + item1.PerformanceRemarks.ToString() + "</td>");
                        sb.AppendLine("</tr>");
                    }
                }
                else
                {
                    foreach (var item1 in item)
                    {
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td>" + sn + "</td>");
                        sb.AppendLine("<td>" + item.FirstOrDefault().KraTopic + "</td>");
                        sb.AppendLine("<td>" + item1.KpiTopic + "</td>");
                        sb.AppendLine("<td>" + item1.KpiWeightage + "</td>");
                        kpiTotal += item1.KpiWeightage;
                        sb.AppendLine("<td>" + GetStatic.ShowDecimal(item1.Variance.ToString()) + "</td>");
                        sb.AppendLine("<td>" + GetStatic.ShowDecimal(item1.performanceScore.ToString()) + "</td>");
                        sb.AppendLine("</tr>");
                    }
                }


                sn++;

            }
            decimal tot = Convert.ToDecimal(dt.Sum(x => x.performanceScore));
            total.Text = Decimal.Round(tot, 2).ToString();
            //kratotaltable.Text = kraTotal.ToString();
            kpitotaltable.Text = kpiTotal.ToString();
            //decimal kratot = string.IsNullOrWhiteSpace(kratotaltable.Text) ? 0 : Convert.ToDecimal(kratotaltable.Text);
            kra_grid.InnerHtml = sb.ToString();

        }
        private void LoadGridCJ()
        {
            var dt = _Obj.GetCriticalJobsData(GetEmpID(), GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                criticalJobs_grid.InnerHtml = "<tr><td colspan=\"3\" align=\"center\"> No Records to display.</td></tr>";
                lblCJTotal.Text = "0";

                return;
            }

            StringBuilder sb = new StringBuilder();
            float total = 0, total1 = 0;
            int sno = 0;
            foreach (DataRow item in dt.Rows)
            {
                sno++;
                string rowId = item["RowId"].ToString();
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sno + "</td>");
                sb.AppendLine("<td>" + item["objectives"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["deductionScore"].ToString() + "</td>");
                sb.AppendLine("<td>" + GetStatic.ShowDecimalCustomize(item["Score"].ToString()) + "</td>");
                sb.AppendLine("</tr>");
                total += float.Parse(item["deductionScore"].ToString());
                if (!string.IsNullOrEmpty(item["Score"].ToString()))
                {
                    total1 += float.Parse(item["Score"].ToString());
                }

            }
            lblCJTotal.Text = total.ToString();
            lblCJTotalObtained.Text = total1.ToString();
            criticalJobs_grid.InnerHtml = sb.ToString();


            criticalJobs_grid.Focus();

        }
        private void LoadGridRating()
        {
            var dt = _Obj.GetPerformanceRatingData();
            var dtKRA = _Obj.GetKRAKPIData(GetEmpID(), GetAppID());
            decimal Score = 0;
            for (int i = 0; i < dtKRA.Count; i++)
            {
                Score = Score + Convert.ToDecimal(String.IsNullOrEmpty(dtKRA[i].performanceScore.ToString()) == true ? 0 : dtKRA[i].performanceScore);
            }
            var ded = _Obj.GetCriticalJobsData(GetEmpID(), GetAppID());
            decimal deduction = 0;
            foreach (DataRow item in ded.Rows)
            {

                if (!string.IsNullOrEmpty(item["Score"].ToString()))
                {
                    deduction = deduction + (item["Score"].ToString() == null ? 0 : Convert.ToDecimal(item["Score"].ToString()));
                }

            }
            Score = Score - deduction;
            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                perfRatingRef_grid.InnerHtml = "<tr><td colspan=\"2\" align=\"center\"> No Records to display.</td></tr>";

                return;
            }

            StringBuilder sb = new StringBuilder();
            var scoreRange = new List<int[]>();
            foreach (DataRow item in dt.Rows)
            {
                // KraAchievementScoreRangeList(item["KraAchiveScore"].ToString(), item["rowId"].ToString()));
                int[] ScoreRange = KraAchievementScoreRangeList(item["KraAchiveScore"].ToString(), item["rowId"].ToString());
                scoreRange.Add(ScoreRange);
                bool check = false;
                string AddCheck = "<i class='fa fa-check' aria-hidden='true'></i>";
                if (ScoreRange.Length == 2)
                {
                    int rang = ScoreRange[1];
                    if (rang == 110 && rang < Score)
                    {
                        check = true;
                    }
                    if (rang == 65 && Score < rang)
                    {
                        check = true;
                    }
                }
                else if (ScoreRange[1] < Score && Score < ScoreRange[2])
                {
                    check = true;
                }


                if (check)
                {
                    sb.AppendLine("<tr style=\"background:#ddd\">");
                    sb.AppendLine("<th>" + item["KraAchiveScore"].ToString() + "</th>");
                    sb.AppendLine("<th>" + item["PerformLblRating"].ToString() + "</th>");
                    sb.AppendLine("<th>" + item["PercentIncrement"].ToString() + "  " + AddCheck + "</th>");
                    sb.AppendLine("</tr>");
                }
                else
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["PercentIncrement"].ToString() + "</td>");
                    sb.AppendLine("</tr>");
                }



            }
            string rowId = KraAchievementScoreCalculation(scoreRange);


            perfRatingRef_grid.InnerHtml = sb.ToString();

            perfRatingRef_grid.Focus();
        }
        private string KraAchievementScoreCalculation(List<int[]> scoreRange)
        {

            int[] lowest = new int[2];
            int[] highest = new int[2];
            int templow = 0, temphigh = 0;
            string rowid = "";

            foreach (var item in scoreRange)
            {
                if (item.Length == 2 || item.Length == 3)
                {
                    lowest[0] = item[1];
                    highest[0] = item[1];
                    break;
                }
            }

            foreach (var item in scoreRange)
            {
                //templow = item[];
                //temphigh = item.Max();
                if (item.Length > 1)
                {
                    templow = item[1];
                    temphigh = item[1];
                    for (int i = 1; i < item.Length; i++)
                    {
                        if (item[i] < templow)
                        {
                            templow = item[i];
                        }
                    }

                    for (int i = 1; i < item.Length; i++)
                    {
                        if (item[i] > temphigh)
                        {
                            temphigh = item[i];
                        }
                    }

                    if (templow < lowest[0])
                    {
                        lowest[0] = templow;
                    }

                    if (temphigh > highest[0])
                    {
                        highest[0] = temphigh;
                    }
                }

            }
            foreach (var item in scoreRange)
            {
                if (item.Length == 2)
                {
                    if (item[1] == highest[0])
                    {
                        highest[1] = item[0];
                    }
                    else if (item[1] == lowest[0])
                    {
                        lowest[1] = item[0];
                    }
                }
            }
            return rowid;
        }
        private int[] KraAchievementScoreRangeList(string str, string rowId)
        {
            string[] numbers = Regex.Split(str, @"\D+");

            var temp = new List<int>();
            temp.Add(Convert.ToInt32(rowId));
            foreach (var num in numbers)
            {
                if (!string.IsNullOrEmpty(num))
                {
                    temp.Add(Convert.ToInt32(num));
                }
            }
            return temp.ToArray();
        }
        private void LoadGridTranning()
        {
            var ds = _Obj.GetProposedTrainingData(GetEmpID(), GetAppID());
            var dts = _Obj.GetKRAKPIData(GetEmpID(), GetAppID());

            var chkdt = ds.Tables[0];
            if (chkdt.Rows.Count == 0 || chkdt.Rows == null) { }

            var dt = ds.Tables[1];
            if (dt.Rows.Count == 0 || dt.Rows == null || dt.Columns.Count == 3)
            {
                perfTranning_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";

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
                sb.AppendLine("<td>" + item["ProposedByDate"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["PAT"].ToString() + "</td>");
                sb.AppendLine("</tr>");
            }
            perfTranning_grid.InnerHtml = sb.ToString();

            perfTranning_grid.Focus();


        }
        private void LoadGridCompetency()
        {
            var dt = _Obj.GetCompetencyData(GetEmpID(), GetAppID());
            var dts = _Obj.GetKRAKPIData(GetEmpID(), GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                competencies_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                lblCompTotal.Text = "";

                return;
            }

            StringBuilder sb = new StringBuilder();
            decimal total = 0,totalweight=0;
            int sn = 0;
            lblLevelHeader.Text = dt.Rows[0]["LevelName"].ToString();

            var bsGroup = dt.Select("CompetencyID='Behavioral Skills'");
            var fsGroup = dt.Select("CompetencyID='Functional Skills'");
            var msGroup = dt.Select("CompetencyID='Managerial Skills'");

            //Listing Functional Skills 
            sb.AppendLine("<tr style=\"font-weight:bold;\">");
            sb.AppendLine("<td>A</td>");
            sb.AppendLine("<td>Functional Skills</td>");
            if (fsGroup.Length > 0)
            {
                sb.AppendLine("<td>" + fsGroup[0]["CompetencyWeight"] + "</td>");
            }
            else
            {
                sb.AppendLine("<td>0</td>");
            }
            sb.AppendLine("<td></td>");
            sb.AppendLine("</tr>");

            foreach (DataRow dr in fsGroup)
            {
                sn++;
                var row = dr["RowId"];
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>A." + sn + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyID"] + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyWeight"] + "</td>");
                sb.AppendLine("<td>" + dr["Score"] + "</td>");
                sb.AppendLine("</tr>");
                totalweight+= string.IsNullOrWhiteSpace(dr["CompetencyKeyWeight"].ToString()) ? 0 : Convert.ToDecimal(dr["CompetencyKeyWeight"].ToString());
                total += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
            }

            //Listing Managerial Skills
            sb.AppendLine("<tr style=\"font-weight:bold;\">");
            sb.AppendLine("<td>B</td>");
            sb.AppendLine("<td>Managerial Skills</td>");
            if (msGroup.Length > 0)
            {
                sb.AppendLine("<td>" + msGroup[0]["CompetencyWeight"] + "</td>");
            }
            else
            {
                sb.AppendLine("<td>0</td>");
            }
            sb.AppendLine("<td></td>");
            sb.AppendLine("</tr>");
            sn = 0;
            foreach (DataRow dr in msGroup)
            {
                sn++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>B." + sn + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyID"] + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyWeight"] + "</td>");

                sb.AppendLine("<td>" + dr["Score"] + "</td>");
                sb.AppendLine("</tr>");
                totalweight += string.IsNullOrWhiteSpace(dr["CompetencyKeyWeight"].ToString()) ? 0 : Convert.ToDecimal(dr["CompetencyKeyWeight"].ToString());
                total += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
            }

            //Listing Behavioral Skills
            sb.AppendLine("<tr style=\"font-weight:bold;\">");
            sb.AppendLine("<td>C</td>");
            sb.AppendLine("<td>Behavioral Skills</td>");
            if (bsGroup.Length > 0)
            {
                sb.AppendLine("<td>" + bsGroup[0]["CompetencyWeight"] + "</td>");
            }
            else
            {
                sb.AppendLine("<td>0</td>");
            }
            sb.AppendLine("<td></td>");
            sb.AppendLine("</tr>");
            sn = 0;
            foreach (DataRow dr in bsGroup)
            {
                sn++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>C." + sn + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyID"] + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyWeight"] + "</td>");
                sb.AppendLine("<td>" + dr["Score"] + "</td>");
                sb.AppendLine("</tr>");
                totalweight += string.IsNullOrWhiteSpace(dr["CompetencyKeyWeight"].ToString()) ? 0 : Convert.ToDecimal(dr["CompetencyKeyWeight"].ToString());
                total += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
            }
            competencies_grid.InnerHtml = sb.ToString();
            lblCompTotal.Text = total.ToString();
            lblCompTotalWeight.Text = totalweight.ToString();

        }
        private void LoadGridScore()
        {
            var ds = _Obj.GetScoreData(GetEmpID(), GetAppID());

            if (ds.Tables.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            int sn = 0;
            decimal scoreKratotal = 0, weightKraTotal = 0;
            var scoreKraTable = ds.Tables[0];
            if (scoreKraTable.Rows.Count == 0 || scoreKraTable.Rows == null)
            {
                ScoreKpi_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
            }
            else
            {
                // KRA Scores
                foreach (DataRow dr in scoreKraTable.Rows)
                {
                    sn++;
                    if (dr["kraTopic"].ToString() == "Critical Jobs")
                    {
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td>" + sn + "</td>");
                        sb.AppendLine("<td>" + dr["kraTopic"] + "</td>");
                        sb.AppendLine("<td>(" + dr["kraWeightage"] + ")</td>");
                        sb.AppendLine("<td>" + dr["Score"] + "</td>");
                        sb.AppendLine("</tr>");


                        scoreKratotal -= string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
                    }
                    else
                    {
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td>" + sn + "</td>");
                        sb.AppendLine("<td>" + dr["kraTopic"] + "</td>");
                        sb.AppendLine("<td>" + dr["kraWeightage"] + "</td>");
                        sb.AppendLine("<td>" + dr["Score"] + "</td>");
                        sb.AppendLine("</tr>");
                        scoreKratotal += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
                        weightKraTotal += string.IsNullOrWhiteSpace(dr["kraWeightage"].ToString()) ? 0 : Convert.ToDecimal(dr["kraWeightage"].ToString());
                    }

                }
                lblWeightKpiTotal.Text = weightKraTotal.ToString();
                lblScoreKpiTotal.Text = scoreKratotal.ToString();
                ScoreKpi_grid.InnerHtml = sb.ToString();

            }

            //Competencies Score
            var scoreCompTable = ds.Tables[1];
            decimal scoreComptotal = 0, weightCompTotal = 0;
            if (scoreCompTable.Rows.Count == 0 || scoreCompTable.Rows == null)
            {
                ScoreComp_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
            }
            else
            {
                sn = 0;
                sb = new StringBuilder();
                foreach (DataRow dr in scoreCompTable.Rows)
                {
                    sn++;
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + sn + "</td>");
                    sb.AppendLine("<td>" + dr["CompetencyID"] + "</td>");
                    sb.AppendLine("<td>" + dr["CompetencyWeight"] + "</td>");
                    sb.AppendLine("<td>" + dr["Score"] + "</td>");
                    sb.AppendLine("</tr>");
                    scoreComptotal += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
                    weightCompTotal += string.IsNullOrWhiteSpace(dr["CompetencyWeight"].ToString()) ? 0 : Convert.ToDecimal(dr["CompetencyWeight"].ToString());
                }
                lblWeightCompTotal.Text = weightCompTotal.ToString();
                lblScoreCompTotal.Text = scoreComptotal.ToString();
                ScoreComp_grid.InnerHtml = sb.ToString();
            }

            //overall performance Score
            var overallPerfTable = ds.Tables[2];
            decimal ttlPerfScore = 0, ttlKraWeighted = 0, ttlCompWeighted = 0;
            if (overallPerfTable.Rows.Count == 0 || overallPerfTable.Rows == null)
            {
                //ScoreKpi_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
            }
            else
            {

                lblKraWeightAsPerLevel.Text = overallPerfTable.Rows[0]["kra"].ToString();
                lblCompWeightAsPerLevel.Text = overallPerfTable.Rows[0]["Competencies"].ToString();

                lblTotalKraScored.Text = scoreKratotal.ToString();
                lblTotalCompScored.Text = scoreComptotal.ToString();

                ttlKraWeighted = ((scoreKratotal * Convert.ToDecimal(overallPerfTable.Rows[0]["kra"].ToString())) / 100);//percentage part
                ttlCompWeighted = ((scoreComptotal * Convert.ToDecimal(overallPerfTable.Rows[0]["Competencies"].ToString())) / 100);
                ttlPerfScore = Convert.ToDecimal(ttlKraWeighted.ToString("F")) + Convert.ToDecimal(ttlCompWeighted.ToString("F"));

                lblTotalKraWeighted.Text = ttlKraWeighted.ToString("F");
                lblTotalCompWeighted.Text = ttlCompWeighted.ToString("F");
                lblOverallPerfScore.Text = ttlPerfScore.ToString();
            }


            //overall score rating

            if (ttlPerfScore > 115)
            {
                divExcellent.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "";
            }
            else if (ttlPerfScore > 95 && ttlPerfScore <= 115)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "";
            }
            else if (ttlPerfScore > 80 && ttlPerfScore <= 95)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "";
            }
            else if (ttlPerfScore > 65 && ttlPerfScore <= 80)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divPoor.InnerHtml = "";
            }
            else if (ttlPerfScore <= 65)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
            }




        }
        private void LoaCommitteeGridScore()
        {

            var ds = _Obj.GetScoreData(GetEmpID(), GetAppID());

            if (ds.Tables.Count == 0)
            {
                return;
            }

            double scoreKratotal = 0, weightKraTotal = 0;
            var scoreKraTable = ds.Tables[0];
            if (scoreKraTable.Rows.Count == 0 || scoreKraTable.Rows == null)
            {
                //ScoreKpi_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
            }
            else
            {
                // KRA Scores
                foreach (DataRow dr in scoreKraTable.Rows)
                {

                    if (dr["kraTopic"].ToString() == "Critical Jobs")
                    {
                        double Ded = string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : ParseDouble(dr["Score"].ToString());
                        scoreKratotal -= Ded;
                    }
                    else
                    {
                        scoreKratotal += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : ParseDouble(dr["Score"].ToString());
                        weightKraTotal += string.IsNullOrWhiteSpace(dr["kraWeightage"].ToString()) ? 0 : ParseDouble(dr["kraWeightage"].ToString());
                    }

                }
                lblWeightKpiTotal.Text = weightKraTotal.ToString();
                lblScoreKpiTotal.Text = scoreKratotal.ToString();

            }

            //Competencies Score
            var scoreCompTable = ds.Tables[1];
            double scoreComptotal = 0, weightCompTotal = 0;
            if (scoreCompTable.Rows.Count == 0 || scoreCompTable.Rows == null)
            {
                //ScoreComp_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
            }
            else
            {
                foreach (DataRow dr in scoreCompTable.Rows)
                {
                    scoreComptotal += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : ParseDouble(dr["Score"].ToString());

                    weightCompTotal += string.IsNullOrWhiteSpace(dr["CompetencyWeight"].ToString()) ? 0 : ParseInt(dr["CompetencyWeight"].ToString());
                }
                lblWeightCompTotal.Text = weightCompTotal.ToString();
                lblScoreCompTotal.Text = scoreComptotal.ToString();
            }

            //overall performance Score
            var overallPerfTable = ds.Tables[2];
            double ttlPerfScore = 0, ttlKraWeighted = 0, ttlCompWeighted = 0;
            if (overallPerfTable.Rows.Count == 0 || overallPerfTable.Rows == null)
            {
                //ScoreKpi_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
            }
            else
            {
                ttlKraWeighted = ((scoreKratotal * ParseDouble(overallPerfTable.Rows[0]["kra"].ToString())) / 100);//percentage part
                ttlCompWeighted = ((scoreComptotal * ParseDouble(overallPerfTable.Rows[0]["Competencies"].ToString())) / 100);
                ttlPerfScore = ttlKraWeighted + ttlCompWeighted;
            }


            //overall score rating

            if (ttlPerfScore > 115)
            {
                divExcellent1.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divVeryGood1.InnerHtml = "";
                divGood1.InnerHtml = "";
                divFair1.InnerHtml = "";
                divPoor1.InnerHtml = "";
            }
            else if (ttlPerfScore > 95 && ttlPerfScore <= 115)
            {
                divExcellent1.InnerHtml = "";
                divVeryGood1.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divGood1.InnerHtml = "";
                divFair1.InnerHtml = "";
                divPoor1.InnerHtml = "";
            }
            else if (ttlPerfScore > 80 && ttlPerfScore <= 95)
            {
                divExcellent1.InnerHtml = "";
                divVeryGood1.InnerHtml = "";
                divGood1.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divFair1.InnerHtml = "";
                divPoor1.InnerHtml = "";
            }
            else if (ttlPerfScore > 65 && ttlPerfScore <= 80)
            {
                divExcellent1.InnerHtml = "";
                divVeryGood1.InnerHtml = "";
                divGood1.InnerHtml = "";
                divFair1.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divPoor1.InnerHtml = "";
            }
            else if (ttlPerfScore <= 65)
            {
                divExcellent1.InnerHtml = "";
                divVeryGood1.InnerHtml = "";
                divGood1.InnerHtml = "";
                divFair1.InnerHtml = "";
                divPoor1.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
            }




        }
        protected void LoadComMemberCommentGrid()
        {


            
            LoaCommitteeGridScore();
            var dt1 = _Obj.getCommitteeMembers(GetEmpID(), GetAppID());

            if (dt1.Rows.Count == 0 || dt1 == null)
            {
                rpt.InnerHtml = "";
            }
            int i = 1;
            string IsComMeb = "No";
            foreach (DataRow row in dt1.Rows)
            {
                if (Convert.ToInt32(row["EMPLOYEE_ID"]) == ReadSession().Emp_Id)
                {
                    IsComMeb = "Yes";
                }
            }

            var sb = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.Append("<tr>");
            sb.Append("<th align='left'>Sno</th>");
            sb.Append("<th align='left'>Employee Name</th>");
            sb.Append("<th align='left'>Position</th>");         
            sb.Append("<th align='left'>Comment/Status</th>");
            sb.Append("<th align='left'>Instructions/Date</th></tr>");
            

            foreach (DataRow row in dt1.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td align='left'>" + i + "</td>");
                sb.Append("<td align='left'>" + row["EmployeeName"] + "</td>");
                sb.Append("<td align='left'>" + row["comMatrixName"] + "</td>");
             

                    if (String.IsNullOrEmpty(row["createdDate"].ToString()))
                    {
                        sb.Append("<td align='left'>" + row["Comment"].ToString().Split('|')[0] + "<small class='pull-right'>     Pending </small></td>");

                    }
                    else
                    {
                        sb.Append("<td align='left'>" + row["Comment"].ToString().Split('|')[0] + "  <small class='pull-right'>  Done </small></td>");

                    }

                    sb.Append("<td align='left'>" + row["Instruction"] + "      <small class='pull-right'>" + row["createdDate"] + " </small></td>");
                

                sb.Append("</tr>");
                i++;
            }
            sb.Append("</table></div>");
            rpt.InnerHtml = sb.ToString();

        }
        private void loadReviewerComment()
        {
           
            var ds = _Obj.getReviewerComment(GetEmpID(), GetAppID());
            if (ds.Tables.Count == 0)
            {
                return;
            }
            DataTable suitDept = ds.Tables[0];
            DataTable revComment = ds.Tables[1];

            if (revComment.Rows.Count > 0)
            {
                //txtRevCommentReason.Text = revComment.Rows[0]["Remarks"].ToString();
                txtRevOfficer.Text = revComment.Rows[0]["comment"].ToString() == null ? " " : revComment.Rows[0]["comment"].ToString();
                ReviewerDate.Text = revComment.Rows[0]["createdDate"].ToString() == null ? " " : revComment.Rows[0]["createdDate"].ToString(); 
            }
           
            if(revComment.Rows.Count > 0)
            {
                txtRevReason.Text = revComment.Rows[1]["comment"].ToString() == null ? " " : revComment.Rows[1]["comment"].ToString();

            }


            if (suitDept.Rows.Count == 0 || revComment.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow row in suitDept.Rows)
            {
                var deptId = row["DeptId"].ToString();
                
                
            }
            foreach (DataRow row in revComment.Rows)
            {
                var qId = row["questionId"].ToString();
                if (qId == "6")
                {
                    txtRevOfficer.Text = row["comment"].ToString();
                }
                else if (qId == "7")
                {
                    txtRevReason.Text = row["comment"].ToString();
                }

            }
        }
        private string ReturnYearAndMonth(string Days)
        {
            decimal totalDays = 0;
            if (!String.IsNullOrEmpty(Days))
            {
                totalDays = Convert.ToDecimal(Days);
                var totalYears = Math.Truncate(totalDays / 365);
                var totalMonths = Math.Truncate((totalDays % 365) / 30);
                return totalYears + " year " + totalMonths + " month";
            }else
            {
                return "";
            }
           
        }
    }
}
