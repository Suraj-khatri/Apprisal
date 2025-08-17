using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Models;
using System.Linq;
using System.Data.SqlTypes;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceReview
{
    public partial class Main : BasePage
    {
        PerformanceReviewDao _Obj = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO swift = null;
        public Main()
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
                SetDetails();
            }
        }
        private void SetDetails()
        {
            hdnEmpName.Value = GetEmpID();
            if (!string.IsNullOrWhiteSpace(hdnEmpName.Value))
            {
                PopulateDataByEmployeeId();
                string user = ReadSession().Emp_Id.ToString();
                if (user == hdnReviewerId.Value)
                {
                    krakpiNext.Visible = true;
                    nextCriticalJob.Visible = true;
                    nextPerformanceRating.Visible = true;
                }
                LoadGridKRAKPI("");
            }
        }
        private void PopulateDataByEmployeeId()
        {

            var res = _Obj.SelectByIdPerformanceReview(hdnEmpName.Value, GetAppID());
            if (res == null)
                return;

            lblEmpName.Text = res["EMPNAME"].ToString();
            currentBranch.Text = res["BRANCH_NAME"].ToString();
            currentDepartment.Text = res["DEPARTMENT_NAME"].ToString();
            currSubDeptID.Text = res["SUBDEPARTMENT_NAME"].ToString();

            //currSubDeptID.Visible = !string.IsNullOrWhiteSpace(res["SUBDEPARTMENT_NAME"].ToString());

            currentFunctionalTitle.Text = res["FunctionalTitle"].ToString();
            currentPosition.Text = res["CURRPOSITION"].ToString();
            dateOfJoining.Text = res["joiningDate"].ToString();
            timeSpentInTheCurrentBranchDept.Text = res["timeSpentOnCurrBranch"].ToString();
            timeSpentInTheCurrentPosition.Text = res["timeSpentOnCurrPosition"].ToString();
            nameAndFUnctionalDesignationOfSupervisor.Text = res["supervisorName"].ToString();
            nameAndFunctionalDesignationOfReviewingOfficer.Text = res["reviewerName"].ToString();
            effectiveFrom.Text = res["appraisalStartDate"].ToString();
            effectiveTo.Text = res["appraisalEndDate"].ToString();
            hdnReviewerId.Value = res["reviewerId"].ToString();
            hdnSupervisorId.Value = res["supervisorId"].ToString();


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
        private void getAttributes(string Id)
        {
            int functionId = int.Parse(Id);
            if (functionId == 0)
            {
                tab1.Attributes["class"] = "active";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "";
                tab5.Attributes["class"] = "";
                tab6.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane active";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Comments.Attributes["class"] = "tab-pane";
                Competency.Attributes["class"] = "tab-pane";
                Score.Attributes["class"] = "tab-pane";
            }
            else if (functionId == 1)
            {
                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "active";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "";
                tab5.Attributes["class"] = "";
                tab6.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane active";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Comments.Attributes["class"] = "tab-pane";
                Competency.Attributes["class"] = "tab-pane";
                Score.Attributes["class"] = "tab-pane";

            }
            else if (functionId == 2)
            {
                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "active";
                tab4.Attributes["class"] = "";
                tab5.Attributes["class"] = "";
                tab6.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane active";
                Comments.Attributes["class"] = "tab-pane";
                Competency.Attributes["class"] = "tab-pane";
                Score.Attributes["class"] = "tab-pane";

            }
            else if (functionId == 5)
            {

                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "active";
                tab5.Attributes["class"] = "";
                tab6.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Comments.Attributes["class"] = "tab-pane active";
                Competency.Attributes["class"] = "tab-pane";
                Score.Attributes["class"] = "tab-pane";
                CommentsBack.Visible = true;
            }
            else if (functionId == 3)
            {

                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "";
                tab5.Attributes["class"] = "active";
                tab6.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Comments.Attributes["class"] = "tab-pane";
                Competency.Attributes["class"] = "tab-pane active";
                Score.Attributes["class"] = "tab-pane";
            }
            else if (functionId == 4)
            {

                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "";
                tab5.Attributes["class"] = "";
                tab6.Attributes["class"] = "active";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Comments.Attributes["class"] = "tab-pane";
                Competency.Attributes["class"] = "tab-pane";
                Score.Attributes["class"] = "tab-pane active";
            }


        }

        private void CheckSupervisor(Button btn)
        {
            btn.Enabled = hdnSupervisorId.Value == ReadSession().Emp_Id.ToString();
        }
        private string ReturnYearAndMonth(decimal totalDays)
        {
            var totalYears = Math.Truncate(totalDays / 365);
            var totalMonths = Math.Truncate((totalDays % 365) / 30);
            return totalYears + "year(s) " + totalMonths + " month(s)";
        }
        //KRAKPI Start
        #region KRAKPI
        protected void LoadKRAKPIGrid_OnClick(object sender, EventArgs e)
        {
            LoadGridKRAKPI("");

        }
        private void LoadGridKRAKPI(string uniId)
        {
            if (string.IsNullOrEmpty(uniId))
                getAttributes(universalId.Value);
            else
            {
                getAttributes((int.Parse(universalId.Value) + 1).ToString());
                universalId.Value = (int.Parse(universalId.Value) + 1).ToString();
                CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
            }

            List<KraKpiGrid> dt = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());

            if (dt.Count == 0 || dt == null)
            {
                kra_grid.InnerHtml = "<tr><td colspan=\"9\" align=\"center\"> No Records to display.</td></tr>";

                //var dt1 = _Obj.getLevelDT();
                return;
            }
            // btnSaveKRAKPI.Text = "Update & Next";
            int sn = 1;
            decimal kraTotal = 0, kpiTotal = 0;
            string disable = "disabled";

            StringBuilder sb = new StringBuilder();
            foreach (var item in dt.GroupBy(x => x.KraTopic))
            {
                int rowcount = item.Count() + 1;
                sb.AppendLine("<tr>");



                if (rowcount > 0)
                {
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + sn + "</td>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().KraTopic + "</td>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().kraWeightage + "</td>");
                    kraTotal += item.FirstOrDefault().kraWeightage;
                    sn++;

                }
                else
                {
                    sb.AppendLine("<td>" + sn + "</td>");
                    sb.AppendLine("<td>" + item.FirstOrDefault().KraTopic + "</td>");
                    sb.AppendLine("<td>" + item.FirstOrDefault().kraWeightage + "</td>");
                    kraTotal += item.FirstOrDefault().kraWeightage;
                    sn++;
                }
                sb.AppendLine("</tr>");
                foreach (var item1 in item)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + item1.KpiTopic + "</td>");
                    sb.AppendLine("<td>" + item1.KpiWeightage + "</td>");

                    kpiTotal += item1.KpiWeightage;

                    //if (item["Status"].ToString() == "12" && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                    //disable = "";
                    if ((item1.Status == "13" || item1.Status == "11"||item1.Status=="6"||item1.Status=="16") && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                    {
                        disable = "";
                    }
                   
                    sb.AppendLine("<td><input  class='input-sm'  style='width:70px'  type=\"text\" id=\"PAA" + item1.RowId + "\" name='PA" + item1.RowId + "' onkeyup=\"CheckDecimal(event)\"" +
                        "onchange=\"PACalculation(this.value,'" + item1.RowId + "','" + item1.KpiWeightage + "','" + item1.Rating + "')\" " +
                                  "" + "value=\"" + GetStatic.ShowDecimal(item1.PAchievement.ToString()) + "\""
                                  + (item1.PAchievement == null ? "" : "" + disable + " ") + " placeholder='Score'></td>");
                    sb.AppendLine("<td><textarea  class='input-sm' rows='2' cols='20'  name='R" + item1.RowId + "'" + disable + " >" + (item1.PerformanceRemarks=="."?null: item1.PerformanceRemarks) + "</textarea></td>");
                    sb.AppendLine("<td><input  class='input-sm' style='width:70px'  type=\"text\" id=\"\" name=\"V" + item1.RowId + "\" value=\"" + GetStatic.ShowDecimal(item1.Variance.ToString()) + "\"" + (item1.Variance == null ? "" : "" + disable + " ") + " readonly=\"readonly\"></td>");
                    sb.AppendLine("<td><input class='input-sm'  style='width:70px'  type=\"text\"  id=\"PS\" name=\"PS" + item1.RowId + "\" value=\"" + GetStatic.ShowDecimal(item1.performanceScore.ToString()) + "\"" + (item1.performanceScore == null ? "" : "" + disable + " ") + "readonly=\"readonly\"></td>");

                    sb.AppendLine("</tr>");
                }



            }
            decimal tot = Convert.ToDecimal(dt.Sum(x => x.performanceScore));
            total.Text = Decimal.Round(tot, 2).ToString();
            kratotaltable.Text = Decimal.Round(kraTotal,2).ToString();
            kpitotaltable.Text = Decimal.Round(kpiTotal,2).ToString();

            //double tot = string.IsNullOrWhiteSpace(total.Text) ? 0 : ParseDouble(total.Text);
            decimal kratot = string.IsNullOrWhiteSpace(kratotaltable.Text) ? 0 : Convert.ToDecimal(kratotaltable.Text);
            hdnKraAchieveScore.Value = (Decimal.Round((tot / kratot) * 100, 2)).ToString();

            if(disable== "disabled")
            {
                hdnReviewAgreedByReviewer.Value = "1";
                btnSaveKRAKPI.Visible = false;
            }else
            if (dt.FirstOrDefault().performanceScore != 0)
            {
                int status = Convert.ToInt32(dt.FirstOrDefault().Status);
               
                if (status == 12 && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                {
                    hdnDisagreedByReviewer.Value = "1";
                    btnSaveKRAKPI.Enabled = true;
                }
                if (status == 6  && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                {

                    btnSaveKRAKPI.Enabled = true;
                }
                else if (status == 8)
                {
                    hdnReviewAgreedByReviewer.Value = "1";
                    btnSaveKRAKPI.Visible = false;
                }
                else
                {
                    CheckSupervisor(btnSaveKRAKPI);
                }
                //if ((status == 13 || status == 11 || status == 6 || status == 16) && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                //{
                //    hdnReviewAgreedByReviewer.Value = "1";
                //    btnSaveKRAKPI.Visible = false;
                //}
            }
            else
            {
                CheckSupervisor(btnSaveKRAKPI);
            }

            kra_grid.InnerHtml = sb.ToString();
        }
        protected void btnSaveKRAKPI_OnClick(object sender, EventArgs e)
        {
            var dt = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            foreach (var row in dt)
            {
                string dataPA = String.IsNullOrWhiteSpace(Request.Form["PA" + row.RowId.ToString()]) == true ? "0.00" : Request.Form["PA" + row.RowId];
                string dataR = String.IsNullOrEmpty(Request.Form["R" + row.RowId])==true?".": Request.Form["R" + row.RowId];
                string dataV = dataPA == "0.00" ? "-1.00" : Request.Form["V" + row.RowId];
                string dataPS = Request.Form["PS" + row.RowId];
                if (Regex.IsMatch(dataV, @"[0-9\-]+") == false)
                {
                    GetStatic.AlertMessage(this, "Variance must be in number");
                    return;
                }
                if (dataPS != null)
                {
                    if (Regex.IsMatch(dataPS, @"^(?:\d{1,5})?(?:\.\d{1,4})?$") == false)
                    {
                        GetStatic.AlertMessage(this, "Performance Score must be in number");
                        return;
                    }
                }
                else
                {
                    GetStatic.AlertMessage(this, "Not Authorized or value can not be null");
                    return;
                }
               
                //if (string.IsNullOrEmpty(dataPA) || string.IsNullOrEmpty(dataR) || string.IsNullOrEmpty(dataV) || string.IsNullOrEmpty(dataPS))
                //{
                //    GetStatic.SweetAlertMessage(this, "", "Please insert all fileds");
                //    return;
                //}

                //sb.AppendLine("<row id=\"" + row.RowId + "\" ");
                sb.AppendLine("<row id=\"" + row.RowId + "\"");
                sb.AppendLine("PA=\"" + dataPA + "\" ");
                sb.AppendLine("R=\"" + dataR.Replace("&", "and") + "\" ");
                sb.AppendLine("V=\"" + dataV + "\" ");
                sb.AppendLine("PS=\"" + dataPS + "\"/>");
            }
            sb.AppendLine("</root>");
            double tot = string.IsNullOrWhiteSpace(total.Text) ? 0 : ParseDouble(total.Text);
            double kratot = string.IsNullOrWhiteSpace(kratotaltable.Text) ? 0 : ParseDouble(kratotaltable.Text);
            hdnKraAchieveScore.Value = ((tot / kratot) * 100).ToString();
            var res = _Obj.SaveKRAKPIRating(sb.ToString(), ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Saved Sucessfully");
                LoadGridKRAKPI(res.ErrorCode);
                btnSaveKRAKPI.Enabled = true;
                btnSaveKRAKPI.Text = "Update & Next";
            }
            if (res.ErrorCode == "2")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                LoadGridKRAKPI(res.ErrorCode);
                btnSaveKRAKPI.Enabled = true;
                btnSaveKRAKPI.Text = "Update & Next";
            }
            else { btnSaveKRAKPI.Enabled = true; }
            //string v = HttpContext.Current.Request.Form["txtPR"];
        }
        #endregion
        //Critical Jobs Start
        #region Critical Jobs
        protected void LoadCJGrid_OnClick(object sender, EventArgs e)
        {
            LoadGridCJ();
        }
        private void LoadGridCJ()
        {
            var dt = _Obj.GetCriticalJobsData(hdnEmpName.Value, GetAppID());
            string disable = "disabled";
            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                criticalJobs_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                lblCJTotal.Text = "0";
                getAttributes(universalId.Value);
                return;
            }
            var dts = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());
            string Status = dts.FirstOrDefault().Status;
            if ((Status == "13" || Status == "11" || Status == "6" || Status == "16") && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
            {
                disable = "";
            }
            StringBuilder sb = new StringBuilder();
            decimal total = 0, total1 = 0;
            int sno = 0;
            foreach (DataRow item in dt.Rows)
            {
                sno++;
                string rowId = item["RowId"].ToString();
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sno + "</td>");
                sb.AppendLine("<td>" + item["objectives"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["deductionScore"].ToString() + "</td>");
                if (!String.IsNullOrEmpty(item["Score"].ToString()))
                {
                    sb.AppendLine("<td><input type=\"text\" "+disable+" class=\"form-control\"  id=\"CJR\" value=\"" + GetStatic.ShowDecimal(item["Score"].ToString()) + "\" name=\"CJR" + rowId + "\" onchange=\"CJcalculation(this.value,'" + item["deductionScore"] + "','CJR" + item["RowId"] + "')\" onkeyup=\"CheckDecimal(event)\" class='form-control' placeholder='0.00'/></td>");
                }
                else
                {
                    sb.AppendLine("<td><input type=\"text\" " + disable + " class=\"form-control\"  id=\"CJR\" value=\"" + item["Score"].ToString() + "\" name=\"CJR" + rowId + "\" onchange=\"CJcalculation(this.value,'" + item["deductionScore"] + "','CJR" + item["RowId"] + "')\" onkeyup=\"CheckDecimal(event)\" class='form-control' placeholder='0.00'/></td>");
                }
                sb.AppendLine("</tr>");
                total += decimal.Parse(item["deductionScore"].ToString());
                if (!string.IsNullOrEmpty(item["Score"].ToString()))
                {
                    total1 += decimal.Parse(item["Score"].ToString());
                }

            }
            lblCJTotal.Text = total.ToString();
            lblCJTotalObtained.Text = total1.ToString();
            criticalJobs_grid.InnerHtml = sb.ToString();

            getAttributes(universalId.Value);
           
            criticalJobs_grid.Focus();
            if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
            {
                //hdnDisagreedByReviewer.Value = "1";
                CriticleJobNext.Enabled = true;
            }
            else
            {
                CheckSupervisor(CriticleJobNext);
            }

            if (disable == "disabled")
            {
                CriticleJobNext.Enabled = false; 
            }
        }
        protected void CriticleJobNext_Click(object sender, EventArgs e)
        {
            var dt = _Obj.GetCriticalJobsData(hdnEmpName.Value, GetAppID());
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            foreach (DataRow row in dt.Rows)
            {

                string CJR = Request.Form["CJR" + row["RowId"].ToString()];
                if (String.IsNullOrEmpty(CJR))
                {
                    GetStatic.SweetAlertErrorMessage(this, "Error", "Critical Jobs Rating Score should not be empty");
                    return;
                }
                if (Regex.IsMatch(CJR, @"^(?:\d{1,5})?(?:\.\d{1,4})?$") == false)
                {
                    GetStatic.SweetAlertErrorMessage(this, "Critical Jobs Rating Score must be in number", "");
                    return;
                }
                if (Convert.ToDecimal(CJR) > Convert.ToDecimal(row["deductionScore"]))
                {
                    GetStatic.SweetAlertErrorMessage(this, "Critical Jobs Rating Score must be less than Critical Job", "");
                    return;
                }
                sb.AppendLine("<row id=\"" + row["RowId"] + "\"");
                sb.AppendLine("CJR=\"" + CJR + "\" />");
            }
            sb.AppendLine("</root>");
            var res = _Obj.SaveCJRating(sb.ToString(), ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Saved Sucessfully");
                LoadGridKRAKPI(res.ErrorCode);
                CriticleJobNext.Enabled = true;
                CriticleJobNext.Text = "Update & Next";
            }
            if (res.ErrorCode == "2")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                LoadGridKRAKPI(res.ErrorCode);
                CriticleJobNext.Enabled = true;
                CriticleJobNext.Text = "Update & Next";
            }
            else { CriticleJobNext.Enabled = true; }
            getAttributes((int.Parse(universalId.Value) + 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) + 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }
        protected void CriticleJobBack_Click(object sender, EventArgs e)
        {
            getAttributes((int.Parse(universalId.Value) - 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) - 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }
        #endregion

        //Performance Rating
        #region Performance Rating
        protected void LoadRatingGrid_Click(object sender, EventArgs e)
        {
            lblApprisalStartDate.Text = effectiveFrom.Text;
            lblApprisalEndDate.Text = effectiveTo.Text;
            LoadGridRating();
            LoadGridTranning();
            CheckSupervisor(btnPerformanceRatingSave);
            if (hdnReviewAgreedByReviewer.Value == "1")
            {
                btnPerformanceRatingSave.Visible = false;
            }

        }
        private void LoadGridRating()
        {
            var dt = _Obj.GetPerformanceRatingData();
            var dtKRA = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());
            var ded = _Obj.GetCriticalJobsData(hdnEmpName.Value, GetAppID());
            var fiscalid = _Obj.GetFiscalYear( GetAppID());
            decimal Score =Convert.ToDecimal(dtKRA.Sum(x => x.performanceScore));
            decimal deduction = 0;
            

            foreach (DataRow item in ded.Rows)
            {
                
                if (!string.IsNullOrEmpty(item["Score"].ToString()))
                {
                    deduction= deduction+(item["Score"].ToString()==null?0:Convert.ToDecimal(item["Score"].ToString()));
                }

            }

            if (Convert.ToInt32(fiscalid) >= 26)
            {
                Score = Score - deduction;
            }
            
            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                perfRatingRef_grid.InnerHtml = "<tr><td colspan=\"2\" align=\"center\"> No Records to display.</td></tr>";
                getAttributes(universalId.Value);
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
                else if (ScoreRange[1] < Score && Score <= ScoreRange[2])
                {
                    check = true;
                }
                //if (scoreRange.Length == 1)
                //{
                //    if (Convert.ToDouble(hdnKraAchieveScore.Value) > Convert.ToDouble(scoreRange[0]))
                //    {

                //    }
                //}
                //else
                //{
                //}
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
                //sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");
                if (check)
                {
                    sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "  " + AddCheck + "</td>");
                }
                else
                {
                    sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + " </td>");
                }

                //sb.AppendLine("<td></td>");
                sb.AppendLine("</tr>");
            }
            string rowId = KraAchievementScoreCalculation(scoreRange);

            //foreach (DataRow item in dt.Rows)
            //{
            //    if (rowId == item["rowId"].ToString())
            //    {
            //        sb.AppendLine("<tr>");
            //        sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
            //        sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");
            //        //sb.AppendLine("<td>" + item["PercentIncrement"].ToString() + "</td>");
            //        sb.AppendLine("</tr>");
            //    }

            //}
            perfRatingRef_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
            perfRatingRef_grid.Focus();
        }

        private string KraAchievementScoreCalculation(List<int[]> scoreRange)
        {

            int[] lowest = new int[2];
            int[] highest = new int[2];
            int templow = 0, temphigh = 0;
            string rowid = "";
            double KraAchieveScore = Convert.ToDouble(string.IsNullOrWhiteSpace(hdnKraAchieveScore.Value) ? "0" : hdnKraAchieveScore.Value);
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


            foreach (var item in scoreRange)
            {
                if (item.Length == 2)
                {
                    if (KraAchieveScore > highest[0] && highest[1] == item[0])
                    {
                        rowid = item[0].ToString();
                        break;
                    }

                    else if (KraAchieveScore < lowest[0] && lowest[1] == item[0])
                    {
                        rowid = item[0].ToString();
                        break;
                    }

                }
                else if (item.Length == 3)
                {
                    if (KraAchieveScore >= item[1] && KraAchieveScore <= item[2])
                    {
                        rowid = item[0].ToString();
                        break;
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
            var ds = _Obj.GetProposedTrainingData(hdnEmpName.Value, GetAppID());
            var dts = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());

            var chkdt = ds.Tables[0];
            if (chkdt.Rows.Count == 0 || chkdt.Rows == null) { }
            else
            {
                if (chkdt.Rows[0][0].ToString() == "Y")
                {
                    chkAknowledgement.Checked = true;
                    chkAknowledgement.Enabled = false;
                }
            }

            var dt = ds.Tables[1];
            if (dt.Rows.Count == 0 || dt.Rows == null || dt.Columns.Count == 3)
            {
                perfTranning_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                getAttributes(universalId.Value);
                return;
            }

            StringBuilder sb = new StringBuilder();
            int sno = 0;
            string disable = ((dts.FirstOrDefault().Status == "16" || dts.FirstOrDefault().Status == "13" || dts.FirstOrDefault().Status == "6" || dts.FirstOrDefault().Status == "11") && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString()) ? "" : "disabled";
            foreach (DataRow item in dt.Rows)
            {
                // arrayID[sno] = item["RowId"].ToString() ?? "";
                string rowId = item["RowId"].ToString() ?? "";
                sno++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sno + "</td>");
                sb.AppendLine("<td>" + item["ProposedTrainingArea"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["ProposedByDate"].ToString() + "</td>");
                sb.AppendLine("<td><input type=\"text\" id=\"PAT" + rowId + "\" name=\"" + rowId + "\" class=\"form-control\" value=\"" + item["PAT"].ToString() + "\"  onkeyup=\"CheckDecimal(event)\"" + (string.IsNullOrWhiteSpace(item["PAT"].ToString()) ? "" : " " + disable + " ") + "/></td>");
                sb.AppendLine("</tr>");
            }
            perfTranning_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
            perfTranning_grid.Focus();
            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["PAT"].ToString()))
            {
                btnPerformanceRatingSave.Text = "Update";
                if (hdnDisagreedByReviewer.Value == "1" && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                {
                    btnPerformanceRatingSave.Enabled = true;
                    chkAknowledgement.Checked = false;
                    chkAknowledgement.Enabled = true;
                }
                else if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() && hdnDisagreedByReviewer.Value == "")
                {
                    btnPerformanceRatingSave.Enabled = true;
                    chkAknowledgement.Checked = true;
                    chkAknowledgement.Enabled = false;
                }
            }
            else
            {
                CheckSupervisor(btnPerformanceRatingSave);
                chkAknowledgement.Checked = false;
                chkAknowledgement.Enabled = true;
            }

        }
        protected void btnPerformanceRatingSave_OnClick(object sender, EventArgs e)
        {
            if (!chkAknowledgement.Checked)
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Please Acknowledge first");
                return;
            }

            var dt = _Obj.GetProposedTrainingData(hdnEmpName.Value, GetAppID()).Tables[1];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");

            foreach (DataRow row in dt.Rows)
            {
                string data = Request.Form[row["RowId"].ToString()];
                if (string.IsNullOrWhiteSpace(data))
                {
                    GetStatic.SweetAlertErrorMessage(this, "", "Please insert all fileds");
                    return;
                }
                float f = Convert.ToSingle(data);
                if ((f) > 5)
                {
                    GetStatic.SweetAlertErrorMessage(this, "", "Cannot insert more than 5");
                    return;
                }

                sb.AppendLine("<row id=\"" + row["RowId"].ToString() + "\" ");
                sb.AppendLine("value=\"" + f + "\"/>");
            }
            sb.AppendLine("</root>");
            //string v = HttpContext.Current.Request.Form["txtPR"];

            //string t = HttpContext.Current.Request.Form["chkPR"] ?? "0";
            //var sp = v.Split(',');
            var res = _Obj.SavePerformanceRating(sb.ToString(), "Y", GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                LoadGridTranning();
                getAttributes((int.Parse(universalId.Value) + 1).ToString());
                universalId.Value = (int.Parse(universalId.Value) + 1).ToString();
                CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
            }

        }
        protected void PerformanceRatingBack_Click(object sender, EventArgs e)
        {
            getAttributes((int.Parse(universalId.Value) - 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) - 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }
        #endregion
        //Competency
        #region Competency
        protected void LoadCompetencyGrid_Click(object sender, EventArgs e)
        {
            LoadGridCompetency();
            CheckSupervisor(BtnCompReviewSave);
            if (hdnReviewAgreedByReviewer.Value == "1")
            {
                BtnCompReviewSave.Enabled = false;
            }

            var chk = _Obj.CheckPerformanceRatingAck(GetAppID());
            if (chk == "N" || string.IsNullOrWhiteSpace(chk))
                PRMessage.Visible = true;
            else
                PRMessage.Visible = false;
        }
        private void LoadGridCompetency()
        {
            var dt = _Obj.GetCompetencyData(hdnEmpName.Value, GetAppID());
            var dts = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                competencies_grid.InnerHtml = "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                lblCompTotal.Text = "";
                getAttributes(universalId.Value);
                return;
            }

            StringBuilder sb = new StringBuilder();
            decimal total = 0;
            int sn = 0;
            string disable = ((dts.FirstOrDefault().Status == "16" || dts.FirstOrDefault().Status == "13" || dts.FirstOrDefault().Status == "11" || dts.FirstOrDefault().Status == "6") && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString()) ? "" : "disabled";
            lblLevelHeader.Text = dt.Rows[0]["LevelName"].ToString();

            var bsGroup = dt.Select("CompetencyID='Behavioral Skills'");
            var fsGroup = dt.Select("CompetencyID='Functional Skills'");
            var msGroup = dt.Select("CompetencyID='Managerial Skills'");

            //Listing Functional Skills 
       /*     sb.AppendLine("<tr style=\"font-weight:bold;\">");
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
            sb.AppendLine("</tr>");*/

            foreach (DataRow dr in fsGroup)
            {
                sn++;
                var row = dr["RowId"];
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sn + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyID"] + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyWeight"] + "</td>");
                sb.AppendLine("<td><input type='text' class=\"form-control\"  id = \"CompReview\"  name='CompReview" + dr["RowId"] + "' onchange=\"TCalculation(this.value,'" + dr["CompetencyKeyWeight"] + "','CompReview" + dr["RowId"] + "')\" value='" + dr["Score"] + "' onkeyup=\"CheckDecimal(event)\" " + (string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? "" : "" + disable + " ") + "/></td>");
                sb.AppendLine("</tr>");
                total += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
            }

            //Listing Managerial Skills
            /*sb.AppendLine("<tr style=\"font-weight:bold;\">");
            sb.AppendLine("<td>B</td>");
            sb.AppendLine("<td>Managerial Skills</td>");*/
            /*if (msGroup.Length > 0)
            {
                sb.AppendLine("<td>" + msGroup[0]["CompetencyWeight"] + "</td>");
            }
            else
            {
                sb.AppendLine("<td>0</td>");
            }
            sb.AppendLine("<td></td>");
            sb.AppendLine("</tr>");*/
           // sn = 0;
            foreach (DataRow dr in msGroup)
            {
                sn++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sn + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyID"] + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyWeight"] + "</td>");

                sb.AppendLine("<td><input type='text'  class=\"form-control\" id = \"CompReview\" name='CompReview" + dr["RowId"] + "' value='" + dr["Score"] + "'  onchange=\"TCalculation(this.value,'" + dr["CompetencyKeyWeight"] + "','CompReview" + dr["RowId"] + "')\" onkeyup=\"CheckDecimal(event)\" " + (string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? "" : "" + disable + " ") + "/></td>");
                sb.AppendLine("</tr>");
                total += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
            }

            //Listing Behavioral Skills
            /*sb.AppendLine("<tr style=\"font-weight:bold;\">");
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
            sb.AppendLine("</tr>");*/
          //  sn = 0;
            foreach (DataRow dr in bsGroup)
            {
                sn++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sn + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyID"] + "</td>");
                sb.AppendLine("<td>" + dr["CompetencyKeyWeight"] + "</td>");
                sb.AppendLine("<td><input type='text'  class=\"form-control\" id = \"CompReview\" name='CompReview" + dr["RowId"] + "' value='" + dr["Score"] + "'  onchange=\"TCalculation(this.value,'" + dr["CompetencyKeyWeight"] + "','CompReview" + dr["RowId"] + "')\" onkeyup=\"CheckDecimal(event)\" " + (string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? "" : "" + disable + " ") + "/></td>");
                sb.AppendLine("</tr>");
                total += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
            }
            competencies_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
          
         
            if (!string.IsNullOrWhiteSpace(dt.Rows[0]["Score"].ToString()))
            {
                lblCompTotal.Text = total.ToString();
                if (disable == "disabled")
                {
                    hdnReviewAgreedByReviewer.Value = "1";
                    BtnCompReviewSave.Visible = false;
                }
                else
                {
                    BtnCompReviewSave.Text = "Update & Next";
                }

                if (hdnDisagreedByReviewer.Value == "1" && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                {
                    BtnCompReviewSave.Enabled = true;

                }
                else if (hdnReviewAgreedByReviewer.Value == "1")
                {
                    BtnCompReviewSave.Visible = false;
                }
                else if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
                {
                    BtnCompReviewSave.Enabled = true;
                }

            }
            else
            {
                CheckSupervisor(BtnCompReviewSave);
            }
        }
        protected void BtnCompReviewSave_Click(object sender, EventArgs e)
        {
            var dt = _Obj.GetCompetencyData(hdnEmpName.Value, GetAppID());
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");
            foreach (DataRow row in dt.Rows)
            {
                string dataCompReview = Request.Form["CompReview" + row["RowId"].ToString()];
                if (string.IsNullOrEmpty(dataCompReview))
                {
                    dataCompReview = "0";
                }

                //sb.AppendLine("<row id=\"" + row["RowId"].ToString() + "\" ");
                sb.AppendLine("<row id=\"" + row["RowId"] + "\"");
                sb.AppendLine("value=\"" + dataCompReview + "\"/>");
            }
            sb.AppendLine("</root>");
            var res = _Obj.SaveCompetencyRating(sb.ToString(), ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Saved Sucessfully");
                BtnCompReviewSave.Enabled = false;
                LoadGridCompetency();
                getAttributes((int.Parse(universalId.Value) + 1).ToString());
                universalId.Value = (int.Parse(universalId.Value) + 1).ToString();
                CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
            }
            if (res.ErrorCode == "1")
            {
                GetStatic.SweetAlertErrorMessage(this, "", res.Msg);
                BtnCompReviewSave.Enabled = false;

            }
            if (res.ErrorCode == "2")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                BtnCompReviewSave.Enabled = false;
                LoadGridCompetency();
                getAttributes((int.Parse(universalId.Value) + 1).ToString());
                universalId.Value = (int.Parse(universalId.Value) + 1).ToString();
                CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
            }
        }
        protected void CompReviewBack_Click(object sender, EventArgs e)
        {
            getAttributes((int.Parse(universalId.Value) - 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) - 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }

        #endregion
        //Performance Score
        #region performance Score
        protected void LoadScoreGrid_Click(object sender, EventArgs e)
        {
            LoadGridScore();
        }
        private void LoadGridScore()
        {
            var ds = _Obj.GetScoreData(hdnEmpName.Value, GetAppID());

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
 /*                 sn++;
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + sn + "</td>");
                    sb.AppendLine("<td>" + dr["CompetencyID"] + "</td>");
                    sb.AppendLine("<td>" + dr["CompetencyWeight"] + "</td>");
                    sb.AppendLine("<td>" + dr["Score"] + "</td>");
                    sb.AppendLine("<td>Competency(Technical/Behavioral)</td>");
                    sb.AppendLine("<td></td>");
                    sb.AppendLine("<td></td>");*/

                    sb.AppendLine("</tr>");
                    scoreComptotal += string.IsNullOrWhiteSpace(dr["Score"].ToString()) ? 0 : Convert.ToDecimal(dr["Score"].ToString());
                    weightCompTotal += string.IsNullOrWhiteSpace(dr["CompetencyWeight"].ToString()) ? 0 : Convert.ToDecimal(dr["CompetencyWeight"].ToString());
                }
                sn++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sn + "</td>");

                sb.AppendLine("<td>Competency(Technical/Behavioral)</td>");
                sb.AppendLine("<td>"+ weightCompTotal + "</td>");
                sb.AppendLine("<td>" + scoreComptotal + "</td>");

                sb.AppendLine("</tr>");
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
                rangeDiv5.InnerHtml = $"<b>{rangeDiv5.InnerHtml}</b>";
                levelDiv5.InnerHtml = $"<b>{levelDiv5.InnerHtml}</b>";
                percentDiv5.InnerHtml = $"<b>{percentDiv5.InnerHtml}</b>";
            }
            else if (ttlPerfScore > 95 && ttlPerfScore <= 115)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "";
                rangeDiv4.InnerHtml = $"<b>{rangeDiv4.InnerHtml}</b>";
                levelDiv4.InnerHtml = $"<b>{levelDiv4.InnerHtml}</b>";
                percentDiv4.InnerHtml = $"<b>{percentDiv4.InnerHtml}</b>";
            }
            else if (ttlPerfScore > 80 && ttlPerfScore <= 95)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "";
                rangeDiv3.InnerHtml = $"<b>{rangeDiv3.InnerHtml}</b>";
                levelDiv3.InnerHtml = $"<b>{levelDiv3.InnerHtml}</b>";
                percentDiv3.InnerHtml = $"<b>{percentDiv3.InnerHtml}</b>";
            }
            else if (ttlPerfScore > 65 && ttlPerfScore <= 80)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                divPoor.InnerHtml = "";
                rangeDiv2.InnerHtml = $"<b>{rangeDiv2.InnerHtml}</b>";
                levelDiv2.InnerHtml = $"<b>{levelDiv2.InnerHtml}</b>";
                percentDiv2.InnerHtml = $"<b>{percentDiv2.InnerHtml}</b>";
            }
            else if (ttlPerfScore <= 65)
            {
                divExcellent.InnerHtml = "";
                divVeryGood.InnerHtml = "";
                divGood.InnerHtml = "";
                divFair.InnerHtml = "";
                divPoor.InnerHtml = "<i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                rangeDiv1.InnerHtml = $"<b>{rangeDiv1.InnerHtml}</b>";
                levelDiv1.InnerHtml = $"<b>{levelDiv1.InnerHtml}</b>";
                percentDiv1.InnerHtml = $"<b>{percentDiv1.InnerHtml}</b>";
            }

            getAttributes(universalId.Value);


        }
        protected void LoadScoreNext_Click(object sender, EventArgs e)
        {
            getAttributes((int.Parse(universalId.Value) + 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) + 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }
        protected void LoadScoreBack_Click(object sender, EventArgs e)
        {
            getAttributes((int.Parse(universalId.Value) - 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) - 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }

        #endregion
        //comments
        #region comments
        protected void LoadCommentGrid_OnClick(object sender, EventArgs e)
        {
            getAttributes(universalId.Value);
            var dt = _Obj.getSupervisorComment(hdnEmpName.Value, GetAppID());
            if (dt.Rows.Count != 0)
            {

                loadSupervisorComment();
            }
            else
            {
                 string reviewerType = _Obj.getReviewerType(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID());
                if (reviewerType.Contains("S"))
                {
                    setSupervisorAccess("11");

                }else
                {
                    setSupervisorAccess("");
                }
                
            }



        }
        private void setSupervisorAccess(string status)
        {
            string reviewerType = _Obj.getReviewerType(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID());

            if (reviewerType.Contains("S") && (status == "13" || status == "16" || status == "11" || status == "6"))
            {
                btnSupervisorComment.Enabled = true;
                txtan1.Enabled = true;
                txtan2.Enabled = true;
                txtan3.Enabled = true;
                txtan4.Enabled = true;
                txtan5.Enabled = true;
                chkIagreeSupervisorComment.Enabled = true;
                chkIagreeSupervisorComment.Checked = true;
                SupRemarks.Enabled = true;
                btnSupervisorComment.Enabled = true;

            }
            else
            {
                btnSupervisorComment.Enabled = false;
                txtan1.Enabled = false;
                txtan2.Enabled = false;
                txtan3.Enabled = false;
                txtan4.Enabled = false;
                txtan5.Enabled = false;
                chkIagreeSupervisorComment.Enabled = false;
                //chkIagreeSupervisorComment.Checked = true;
                SupRemarks.Enabled = false;
                btnSupervisorComment.Enabled = false;


            }
        }
        private void setReviewerAccess()
        {
            string reviewerType = _Obj.getReviewerType(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID());
            var ds = _Obj.getReviewerComment(hdnEmpName.Value, GetAppID());
            DataTable suitDept = ds.Tables[0];
            DataTable revComment = ds.Tables[1];
            DataTable revStatus = ds.Tables[2];
            string status="";
            if (ds.Tables.Count != 0)
            {
                if (revComment.Rows.Count > 0)
                {
                    txtRevCommentReason.Text = revComment.Rows[0]["Remarks"].ToString();
                    txtRevOfficer.Text = revComment.Rows[0]["comment"].ToString();
                    RevAckDate.Text = "Acknowledge on:  " + Convert.ToDateTime(revComment.Rows[0]["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                    if (revComment.Rows.Count > 1)
                    {
                        txtRevReason.Text = revComment.Rows[1]["comment"].ToString();
                        chkRevCommentAgree.Checked = true;
                    }
                  
                  
                }
               

            }
            status=revStatus.Rows[0]["STATUS"].ToString();
            if (reviewerType.Contains("R") && ((status=="7")||(status=="8")))
            {
                btnSaveRevComment.Enabled = true;
                btnDisagree.Enabled = true;
                 chkRevCommentAgree.Checked = true;
            }
            else
            {
                txtRevOfficer.Enabled = false;
            txtRevReason.Enabled = false;
            txtRevCommentReason.Enabled = false;
            chkSales.Enabled = false;
            chkOperation.Enabled = false;
            chkHR.Enabled = false;
            chkBackOffice.Enabled = false;
            chkMarketing.Enabled = false;
            chkAdministration.Enabled = false;
            chkFinance.Enabled = false;
            chkOthers.Enabled = false;
            txtSales.Enabled = false;
            txtOthers.Enabled = false;
            //chkRevCommentAgree.Checked = false;
            chkRevCommentAgree.Enabled = false;
            btnSaveRevComment.Enabled = false;
            btnSaveRevComment.Visible = false;
            btnDisagree.Visible = false;
            }
        }
        private void setAppraiseAccess(string status)
        {
            
            if (status == "6" ||  status == "11" )
            {
               
                Txt_DisagreeReason.Enabled = true;
                btn_Appraisee_Save.Visible = true;
                Chk_Apr_agree.Enabled = true;
                Chk_Disagree_appraisee.Enabled = true;

            }
            else
            {
                Txt_DisagreeReason.Visible = false;
                btn_Appraisee_Save.Visible = false;
                Chk_Apr_agree.Visible = false;
                Chk_Disagree_appraisee.Visible = false;
                btnSupervisorComment.Visible = false;
                BtnCompReviewSave.Visible = false;
            }
        }
        private void setReviewerCommitteeAccess()
        {
             chkFreeze.Checked = true;
                chkFreeze.Enabled = false;
            string reviewerType = _Obj.getReviewerType(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID());
            if (reviewerType.Contains("C"))
            {
                txtCEO.Enabled = false;
                btnSaveComMember.Enabled = true;
            }
            else if (reviewerType.Contains("O"))
            {
                txtCEO.Enabled = true;
                btnSaveCEOComment.Visible = true;
                btnSaveComMember.Enabled = false;

                txtComMemberRemark.Enabled=false;
                chkComMemberAgree.Enabled = false;
                txtComMember.Enabled = false;
                txtIssueddate.Enabled = false;
                txtInstructions.Enabled = false;
                btnSaveComMember.Visible = false;
                btnEditComment.Visible = false;
                txtComMemberRemark.Enabled = false;
            }
            else
            {
                txtCEO.Enabled = false;
                btnSaveComMember.Enabled = false;
                txtComMemberRemark.Enabled=false;
                chkComMemberAgree.Enabled = false;
                txtComMember.Enabled = false;
                txtIssueddate.Enabled = false;
                txtInstructions.Enabled = false;
                btnSaveComMember.Visible = false;
                btnEditComment.Visible = false;
                txtComMemberRemark.Enabled = false;
            }
        }
        private void loadSupervisorComment()
        {
            getCommentAttributes(universalCommentId.Value);
            var dt = _Obj.getSupervisorComment(hdnEmpName.Value, GetAppID());
            if (dt.Rows.Count != 0 && dt != null)
            {
                txtan1.Text="";
                txtan2.Text="";
                txtan3.Text="";
                txtan4.Text="";
                txtan5.Text="";
                if(dt.Rows.Count>=1)
                {
                    txtan1.Text = dt.Rows[0]["comment"].ToString();
                    SupAckDate.Text= "Acknowledge on:  " + Convert.ToDateTime(dt.Rows[0]["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                }
                chkIagreeSupervisorComment.Checked = true;
                if(dt.Rows.Count>=2)
                {
                     txtan2.Text = dt.Rows[1]["comment"].ToString();
                }

                if (dt.Rows.Count>=3)
                {
                    txtan3.Text = dt.Rows[2]["comment"].ToString();
                }

                if (dt.Rows.Count>=4)
                {
                   txtan4.Text = dt.Rows[3]["comment"].ToString();
                }

                if (dt.Rows.Count==5)
                {
                    txtan5.Text = dt.Rows[4]["comment"].ToString();
                }
                
                string sup = dt.Rows[0]["commentBy"].ToString();
                SupRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                var status = dt.Rows[0]["STATUS"].ToString();
                setSupervisorAccess(status);

            }
            else
            {
                string reviewerType = _Obj.getReviewerType(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID());
                if (reviewerType.Contains("S") ||reviewerType=="")
                {
                    setSupervisorAccess("11");

                }
                return;
            }

        }
        protected void btnSupervisorComment_OnClick(object sender, EventArgs e)
        {
            List<KraKpiGrid> dt = _Obj.GetKRAKPIData(hdnEmpName.Value, GetAppID());
            int count = dt.Where(x => x.PerformanceRemarks == "").Count();
            int countLength= dt.Where(x => x.PerformanceRemarks.Length<=1).Count();
            if (count>0 || countLength>0)
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Please fill up all Score Remarks  in KRA/KPI Scoring with more than a characters");
                return;
            }
            
            if (chkIagreeSupervisorComment.Checked == false)
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Please check the Acknowledge Agreement");
                return;
            }
            if (string.IsNullOrEmpty(txtan1.Text) || string.IsNullOrEmpty(txtan2.Text) || string.IsNullOrEmpty(txtan3.Text) || string.IsNullOrEmpty(txtan4.Text) || string.IsNullOrEmpty(txtan5.Text) || string.IsNullOrEmpty(SupRemarks.Text))
            {
                GetStatic.SweetAlertErrorMessage(this, "", "Please write comment for each question fileds");
                return ;
            }
           
            var res = _Obj.SaveSupervisorComment(txtan1.Text, txtan2.Text, txtan3.Text, txtan4.Text, txtan5.Text, SupRemarks.Text, "Y", "Supervisor", ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                loadSupervisorComment();
            }
        }
        protected void LoadappraiseeGrid_OnClick(object sender, EventArgs e)
        {
            var dt = _Obj.getAppraiseeComment(hdnEmpName.Value, GetAppID());
            getCommentAttributes(universalCommentId.Value);
            if (ReadSession().Emp_Id.ToString() != hdnEmpName.Value)
            {
                Chk_Disagree_appraisee.Visible = false;
                Txt_DisagreeReason.Visible = false;
                btn_Appraisee_Save.Visible = false;
                Chk_Apr_agree.Visible = false;                          
                btnSupervisorComment.Visible = false;
                BtnCompReviewSave.Visible = false;
            }
            if (dt.Rows.Count > 0)
            {
                Txt_DisagreeReason.Text = dt.Rows[0]["comment"].ToString();
                ApreeAckDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dt.Rows[0]["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                string remark = dt.Rows[0]["remarks"].ToString();
                if (remark.ToLower() == "disagreed")
                {

                    Chk_Apr_agree.Checked = false;
                    Chk_Disagree_appraisee.Checked = true;

                }
                else if (remark.ToLower()== "agreed")
                {
                    Chk_Apr_agree.Checked = true;
                    Chk_Disagree_appraisee.Checked = false;
                }
                setAppraiseAccess(dt.Rows[0]["STATUS"].ToString());
            }




        }
        protected void btnSaveAppraisee_OnClick(object sender, EventArgs e)
        {
            try
            {
                var dt = _Obj.getSupervisorComment(hdnEmpName.Value, GetAppID());
            


                string sts;
                string Comment = Txt_DisagreeReason.Text;
                if (dt.Rows.Count > 0)
                {
                    string Status = dt.Rows[0]["STATUS"].ToString();
                    if (Status == "6" || Status == "11")
                    {
                        if (Chk_Disagree_appraisee.Checked == true && Chk_Apr_agree.Checked == true)
                        {
                            GetStatic.SweetAlertErrorMessage(this, "Error", "Please Check either agree of disagree !! ");
                            return;
                        }
                        if (Chk_Disagree_appraisee.Checked == true)
                        {
                            if (String.IsNullOrEmpty(Txt_DisagreeReason.Text))
                            {
                                GetStatic.SweetAlertErrorMessage(this, "Error", "Please Specify reason of disagree !! ");
                                return;
                            }


                            sts = _Obj.SaveAppraiseeComment("disagreed", "Appraisee", ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID(), Comment);
                            if (sts.Contains("successfully"))
                            {
                                Txt_DisagreeReason.Enabled = false;
                                Chk_Apr_agree.Checked = false;
                                Chk_Apr_agree.Enabled = false;
                                Chk_Disagree_appraisee.Checked = true;
                                Chk_Disagree_appraisee.Enabled = false;
                                GetStatic.SweetAlertSuccessMessage(this, "", sts);
                            }
                        }
                        else if (Chk_Apr_agree.Checked == true)
                        {

                            sts = _Obj.SaveAppraiseeComment("agreed", "Appraisee", ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID(), Comment);
                            if (sts.Contains("successfully"))
                            {
                                Txt_DisagreeReason.Enabled = false;
                                Chk_Apr_agree.Checked = true;
                                Chk_Apr_agree.Enabled = false;
                                Chk_Disagree_appraisee.Checked = false;
                                Chk_Disagree_appraisee.Enabled = false;
                                GetStatic.SweetAlertSuccessMessage(this, "", sts);
                            }
                        }
                        else
                        {
                            GetStatic.SweetAlertErrorMessage(this, "Error", "Please checked Either  Agree or disagree !! ");
                        }

                    }
                    else
                    {
                        GetStatic.SweetAlertErrorMessage(this, "Error", "You are not auhtorized to proceed !! ");
                    }
                }
                else
                {
                    GetStatic.SweetAlertErrorMessage(this, "Error", "You are not auhtorized to proceed !! ");
                }

            }
            catch (Exception Ex)
            {

                GetStatic.SweetAlertErrorMessage(this, "Error", Ex.Message);
            }
           


        }
        protected void LoadSupCommentGrid_OnClick(object sender, EventArgs e)
        {
            getCommentAttributes(universalCommentId.Value);
            var dt = _Obj.getSupervisorComment(hdnEmpName.Value, GetAppID());
            if (dt.Rows.Count != 0 || dt.Rows != null || dt.Columns.Count != 0)
            {
                loadSupervisorComment();
            }
            else
            {
                setSupervisorAccess("");
            }

        }
        private void getCommentAttributes(string cId)
        {
            int functionId = int.Parse(cId);
            if (functionId == 0)
            {
                sComment.Attributes["class"] = "active";
                Acomment.Attributes["class"] = "";
                rComment.Attributes["class"] = "";
                cMComment.Attributes["class"] = "";
                supervisorcomment.Attributes["class"] = "tab-pane active ";
                appraisee.Attributes["class"] = "tab-pane";
                reviewercomment.Attributes["class"] = "tab-pane";
                comitteemembercomment.Attributes["class"] = "tab-pane";
            }
            else if (functionId == 1)
            {
                sComment.Attributes["class"] = "";
                Acomment.Attributes["class"] = "active";
                rComment.Attributes["class"] = "";
                cMComment.Attributes["class"] = "";
                supervisorcomment.Attributes["class"] = "tab-pane ";
                appraisee.Attributes["class"] = "tab-pane active";
                reviewercomment.Attributes["class"] = "tab-pane";
                comitteemembercomment.Attributes["class"] = "tab-pane";
            }
            else if (functionId == 2)
            {
                sComment.Attributes["class"] = "";
                Acomment.Attributes["class"] = "";
                rComment.Attributes["class"] = "active";
                cMComment.Attributes["class"] = "";
                supervisorcomment.Attributes["class"] = "tab-pane ";
                reviewercomment.Attributes["class"] = "tab-pane active";
                appraisee.Attributes["class"] = "tab-pane";
                comitteemembercomment.Attributes["class"] = "tab-pane";
            }
            else if (functionId == 3)
            {
                sComment.Attributes["class"] = "";
                rComment.Attributes["class"] = "";
                Acomment.Attributes["class"] = "";
                cMComment.Attributes["class"] = "active";
                supervisorcomment.Attributes["class"] = "tab-pane ";
                reviewercomment.Attributes["class"] = "tab-pane";
                comitteemembercomment.Attributes["class"] = "tab-pane active";
            }
        }
        protected void LoadRevCommentGrid_OnClick(object sender, EventArgs e)
        {
            getCommentAttributes(universalCommentId.Value);
            var ds = _Obj.getReviewerComment(hdnEmpName.Value, GetAppID());
            if (ds.Tables.Count == 0)
            {
                return;
            }
            DataTable suitDept = ds.Tables[0];
            //DataTable revComment = ds.Tables[1];
            if (suitDept.Rows.Count != 0)
            {
                loadReviewerComment();
            }
            else
            {
                setReviewerAccess();
            }


        }
        private void loadReviewerComment()
        {
            setReviewerAccess();
            var ds = _Obj.getReviewerComment(hdnEmpName.Value, GetAppID());
            if (ds.Tables.Count == 0)
            {
                return;
            }
            DataTable suitDept = ds.Tables[0];
            DataTable revComment = ds.Tables[1];


            if (revComment.Rows.Count > 0)
            {
                txtRevCommentReason.Text = revComment.Rows[0]["Remarks"].ToString();
                txtRevOfficer.Text = revComment.Rows[0]["comment"].ToString();
                
                RevAckDate.Text= "Acknowledge on:  " + Convert.ToDateTime(revComment.Rows[0]["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                txtRevReason.Text = revComment.Rows[1]["comment"].ToString();
            }
            txtRevOfficer.Enabled = false;
            txtRevReason.Enabled = false;
            txtRevCommentReason.Enabled = false;
            chkSales.Enabled = false;
            chkOperation.Enabled = false;
            chkHR.Enabled = false;
            chkBackOffice.Enabled = false;
            chkMarketing.Enabled = false;
            chkAdministration.Enabled = false;
            chkFinance.Enabled = false;
            chkOthers.Enabled = false;
            txtSales.Enabled = false;
            txtOthers.Enabled = false;
            chkRevCommentAgree.Checked = true;
            chkRevCommentAgree.Enabled = false;
            btnSaveRevComment.Enabled = false;
            btnDisagree.Enabled = false;
            if (suitDept.Rows.Count == 0 || revComment.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow row in suitDept.Rows)
            {
                var deptId = row["DeptId"].ToString();
                if (deptId == "7")
                {
                    chkSales.Checked = true;
                    txtSales.Text = row["Remarks"].ToString();
                }
                if (deptId == "1")
                {
                    chkOperation.Checked = true;
                }
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
        protected void btnDisagree_OnClick(object sender, EventArgs e)
        {
            GetStatic.PrintSweetAlertMessage(this);

            if (string.IsNullOrEmpty(txtRevCommentReason.Text))
            {
                GetStatic.SweetAlertErrorMessage(this, "*Required", "Please mention the reason of disagreement ");
                return;
            }
            var res = _Obj.DisagreeComment(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID(), txtRevCommentReason.Text);
            if (res.ErrorCode == "0")
            {
                
                SendDisagreeMail(hdnEmpName.Value, ReadSession().Emp_Id.ToString(), GetAppID());
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                loadReviewerComment();
                //Response.Redirect(Request.RawUrl);
                btnSaveRevComment.Enabled = false;
                btnDisagree.Enabled = false;
            }
        }
        private void SendDisagreeMail(string empName, string approver, string appId)
        {
            _Obj.SendDisagreeMail(empName, approver, appId);
        }
        protected void btnSaveRevComment_OnClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRevOfficer.Text))
            {
                GetStatic.SweetAlertMessage(this, "", "You cannot save Without Commenting");
                return;
            }
            if (chkRevCommentAgree.Checked == false)
            {
                GetStatic.SweetAlertMessage(this, "", "Please agree the points mentioned in the above.");
                return;
            }
            if (chkSales.Checked && string.IsNullOrEmpty(txtSales.Text))
            {
                GetStatic.SweetAlertMessage(this, "", "Please Specify Sales reason.");
                return;
            }
            if (chkOthers.Checked && string.IsNullOrEmpty(txtOthers.Text))
            {
                GetStatic.SweetAlertMessage(this, "", "Please Specify Other reason.");
                return;
            }
            string sales = "", operations = "", HR = "", BackOffice = "", Marketing = "", Administration = "", Finance = "", Others = "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<root>");

            if (chkSales.Checked)
            {
                sales = "7";
                sb.AppendLine("<row id=\"" + sales + "\"");
                sb.AppendLine(" comment=\"" + txtSales.Text + "\"/>");
            }
            if (chkOperation.Checked)
            {
                operations = "";
                sb.AppendLine("<row id=\"" + operations + "\"");
                sb.AppendLine(" comment=\"\"/>");
            }
            if (chkHR.Checked)
            {
                HR = "";
                sb.AppendLine("<row id=\"" + HR + "\"");
                sb.AppendLine(" comment=\"\"/>");

            }
            if (chkBackOffice.Checked)
            {
                BackOffice = "";
                sb.AppendLine("<row id=\"" + BackOffice + "\"");
                sb.AppendLine(" comment=\"\"/>");


            }
            if (chkMarketing.Checked)
            {
                Marketing = "";
                sb.AppendLine("<row id=\"" + Marketing + "\"");
                sb.AppendLine(" comment=\"\"/>");


            }
            if (chkAdministration.Checked)
            {
                Administration = "";
                sb.AppendLine("<row id=\"" + Administration + "\"");
                sb.AppendLine(" comment=\"\"/>");


            }
            if (chkFinance.Checked)
            {
                Finance = "";
                sb.AppendLine("<row id=\"" + Finance + "\"");
                sb.AppendLine(" comment=\"\"/>");

            }
            if (chkOthers.Checked)
            {
                Others = "5";
                sb.AppendLine("<row id=\"" + Others + "\"");
                sb.AppendLine(" comment=\"" + txtOthers.Text + "\"/>");
            }

            sb.AppendLine("</root>");
            var res = _Obj.SaveRevComment(txtRevOfficer.Text, txtRevReason.Text, sb.ToString(), hdnEmpName.Value, ReadSession().Emp_Id.ToString(), txtRevCommentReason.Text, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                loadReviewerComment();
                //Response.Redirect(Request.RawUrl);
                btnSaveRevComment.Enabled = false;
                btnDisagree.Enabled = false;
                return;
            }
        }
        protected void LoadComMemberCommentGrid_OnClick(object sender, EventArgs e)
        {
            setReviewerCommitteeAccess();
            getCommentAttributes(universalCommentId.Value);
            LoaCommitteeGridScore();
            var dt1 = _Obj.getCommitteeMembers(hdnEmpName.Value, GetAppID());

            if (dt1.Rows.Count == 0 || dt1 == null)
            {
                rpt.InnerHtml = "";
            }
            int i = 1;
            string IsComMeb="No";
            foreach (DataRow row in dt1.Rows)
            {
                if(Convert.ToInt32(row["EMPLOYEE_ID"])==ReadSession().Emp_Id)
                {
                    IsComMeb="Yes";
                }
            }
            
            var sb = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.Append("<tr>");
            sb.Append("<th align='left'>Sno</th>");
            sb.Append("<th align='left'>Employee Name</th>");
            sb.Append("<th align='left'>Position</th>");
            if(IsComMeb.Contains("Yes"))
            {
                sb.Append("<th align='left'>Status</th>");
                sb.Append("<th align='left'>Date</th></tr>");
            }
            else {
                sb.Append("<th align='left'>Comment/Status</th>");
            sb.Append("<th align='left'>Instructions/Date</th></tr>");
            }
            
            foreach (DataRow row in dt1.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td align='left'>" + i + "</td>");
                sb.Append("<td align='left'>" + row["EmployeeName"] + "</td>");
                sb.Append("<td align='left'>" + row["comMatrixName"] + "</td>");
                if(IsComMeb.Contains("Yes"))
            {
                    if (String.IsNullOrEmpty(row["createdDate"].ToString()))
                    {
                        sb.Append("<td align='left'>"+"Pending"+"</td>");
                    }else
                    {
                        sb.Append("<td align='left'>"+"Done"+"</td>");
                    }
                
                sb.Append("<td align='left'>"+row["createdDate"]+"</td>");
            }
            else {
                    
                    if (String.IsNullOrEmpty(row["createdDate"].ToString()))
                    {
                         sb.Append("<td align='left'>" +  row["Comment"].ToString().Split('|')[0]+ "<small class='pull-right'>     Pending </small></td>");
                        
                    }else
                    {
                         sb.Append("<td align='left'>" +  row["Comment"].ToString().Split('|')[0]+ "  <small class='pull-right'>  Done </small></td>");

                    }
               
                sb.Append("<td align='left'>" +  row["Instruction"]+"      <small class='pull-right'>"+row["createdDate"]+ " </small></td>");
            }
               
                sb.Append("</tr>");
                i++;
            }
            sb.Append("</table></div>");
            rpt.InnerHtml = sb.ToString();
            var ds = _Obj.getComMemberComment(hdnEmpName.Value, GetAppID(),ReadSession().Emp_Id.ToString());
            if (ds.Tables[0].Rows.Count != 0)
            {
                loadComMemberComment();
                loadCEOComment();
            }


        }
        private void loadCEOComment()
        {
            var ds = _Obj.getComMemberComment(hdnEmpName.Value, GetAppID(),ReadSession().Emp_Id.ToString());
            if (ds.Tables[1].Rows.Count > 0)
            {
                txtCEO.Text = ds.Tables[1].Rows[0]["comment"].ToString();
                txtCEO.Enabled = false;
            }
        }
        private void loadComMemberComment()
        {
             
            setReviewerCommitteeAccess();
            var ds = _Obj.getComMemberComment(hdnEmpName.Value, GetAppID(),ReadSession().Emp_Id.ToString());
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0 || ds.Tables[0] == null)
            {
                return;
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                int qId = Convert.ToInt16(dr["questionId"]);
                if (qId == 9)
                {
                    string comment = dr["comment"].ToString();
                    string[] split = comment.Split('|');
                    txtComMember.Text = split[0];
                    txtIssueddate.Text = split[1];
                }
                if (qId == 10)
                {
                    txtInstructions.Text = dr["comment"].ToString();
                }

            }
            if (ReadSession().Emp_Id.ToString() == ds.Tables[0].Rows[0]["commentBy"].ToString())
            {
                txtComMemberRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                chkComMemberAgree.Checked = true;
                chkComMemberAgree.Enabled = true;
                txtComMember.Enabled = true;
                txtIssueddate.Enabled = true;
                txtInstructions.Enabled = true;
                btnSaveComMember.Visible = false;
                btnEditComment.Visible = true;
                txtComMemberRemark.Enabled = true;
            }
            else
            {
                txtComMemberRemark.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                chkComMemberAgree.Checked = true;
                chkComMemberAgree.Enabled = false;
                txtComMember.Enabled = false;
                txtIssueddate.Enabled = false;
                txtInstructions.Enabled = false;
                btnSaveComMember.Enabled = false;
                btnEditComment.Visible = false;
                txtComMemberRemark.Enabled = false;
               
            }

        }
        protected void btnSaveComMember_OnClick(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtComMember.Text))
            //{
            //    GetStatic.SweetAlertErrorMessage(this, "", "Comment of Comittee cannot be empty");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtIssueddate.Text))
            //{
            //    GetStatic.SweetAlertErrorMessage(this, "", "Please Select Letter Issue Date");
            //    return;
            //}
            if (chkComMemberAgree.Checked == false)
            {
                GetStatic.SweetAlertMessage(this, "", "Please agree ");
                return;
            }
            string comMemberComment = txtComMember.Text + "|" + txtIssueddate.Text;
            char freeze = 'Y';
            var res = _Obj.SaveComMemberComment(comMemberComment, ReadSession().Emp_Id.ToString(), hdnEmpName.Value, txtComMemberRemark.Text, txtInstructions.Text, freeze, GetAppID());
              
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                loadComMemberComment();
                btnSaveRevComment.Enabled = false;
            }
        }
        private void LoaCommitteeGridScore()
        {

            var ds = _Obj.GetScoreData(hdnEmpName.Value, GetAppID());

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

            getAttributes(universalId.Value);


        }
        protected void btnEditComment_Click(object sender, EventArgs e)
        {
            string comMemberComment = txtComMember.Text + "|" + txtIssueddate.Text;
            char freeze = 'N';
            if (chkFreeze.Checked)
            {
                freeze = 'Y';
            }
            var res = _Obj.UpdateComMemberComment(comMemberComment, ReadSession().Emp_Id.ToString(), hdnEmpName.Value, txtComMemberRemark.Text, txtInstructions.Text, freeze, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                loadComMemberComment();
            }
        } 
        protected void btnSaveCEOComment_OnClick(object sender, EventArgs e)
        {
            var res = _Obj.SaveCEOComment(txtCEO.Text, ReadSession().Emp_Id.ToString(), hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "", "Record Updated Sucessfully");
                loadComMemberComment();
                btnSaveRevComment.Enabled = false;
            }
        }
        protected void CommentsBack_Click(object sender, EventArgs e)
        {
            getAttributes((int.Parse(universalId.Value) - 1).ToString());
            universalId.Value = (int.Parse(universalId.Value) - 1).ToString();
            CallBackJs1(this, "", "LoadGridCJ('" + universalId.Value + "');");
        }
        #endregion
        protected void krakpiNext_Click(object sender, EventArgs e)
        {
            CallBackJs1(this, "", "LoadGridCJ(1);");
        }
        protected void nextCriticalJob_Click(object sender, EventArgs e)
        {
            CallBackJs1(this, "", "LoadGridCJ(2);");
        }
        protected void nextPerformanceRating_Click(object sender, EventArgs e)
        {
            CallBackJs1(this, "", "LoadGridCJ(3);");
        }

    }
}