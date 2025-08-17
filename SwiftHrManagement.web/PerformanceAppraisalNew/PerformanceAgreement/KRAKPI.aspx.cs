using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using System.Text.RegularExpressions;
using System.Linq;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.PerformanceAgreement
{
    public partial class KRAKPI : BasePage
    {
        PerformanceAgreementDao _Obj = null;
        PerformanceReviewDao _ObjR = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO swift = null;

        public KRAKPI()
        {
            _Obj = new PerformanceAgreementDao();
            _ObjR = new PerformanceReviewDao();
            _RoleMenuDAOInv = new RoleMenuDAOInv();
            swift = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 1115) == false)
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
            hdnStatus.Value = GetStatus();

            if (!string.IsNullOrWhiteSpace(hdnEmpName.Value))
            {
                PopulateDataByEmployeeId();
                LoadGrid();
            }
        }

        private string GetStatus()
        {
            var dtt = _Obj.getAgreementStatus(hdnEmpName.Value, GetAppID());
            return dtt.Rows[0]["STATUS"].ToString();
        }

        private string GetAppID()
        {
            if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("appId", "")))
            {
                return Crypto(GetStatic.ReadQueryString("appId", ""), false);
            }

            return "";
        }

        //protected void txtEmployee_TextChanged(object sender, EventArgs e)
        //{
        //    lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
        //    txtEmployee.Text = "";
        //    if (!string.IsNullOrWhiteSpace(hdnEmpName.Value))
        //    {
        //        PopulateDataByEmployeeId();
        //        LoadGrid();
        //    }
        //}

        private void PopulateDataByEmployeeId()
        {

            var res = _Obj.SelectByIdPerformance(hdnEmpName.Value, GetAppID(),ReadSession().Emp_Id.ToString());
            if (res == null)
                return;

            lblEmpName.Text = res["EMPNAME"].ToString();

            currentBranch.Text = res["BRANCH_NAME"].ToString();
            currentDepartment.Text = res["DEPARTMENT_NAME"].ToString();
            currSubDeptID.Text = res["SUBDEPARTMENT_NAME"].ToString();
            currSubDeptID2.Text = res["SUBDEPARTMENT_NAME2"].ToString();

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

        private string Crypto(string value, bool isEncrypt = true)
        {
            var forReturn = "";
            if (isEncrypt)
                forReturn = Cryptographer.Encrypt(value, Cryptographer.PrivateKey());
            else
                forReturn = Cryptographer.Decrypt(value, Cryptographer.PrivateKey());

            return forReturn;
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        private string GetRowID()
        {
            return GetStatic.ReadQueryString("rowId", "");
        }

        private string GetEmpID()
        {

            return Crypto(GetStatic.ReadQueryString("empId", ""), false);
        }

        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
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
                KRAKPIDiv.Attributes["class"] = "tab-pane active";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Acknowledgement.Attributes["class"] = "tab-pane";

            }
            else if (functionId == 1)
            {
                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "active";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane active";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Acknowledgement.Attributes["class"] = "tab-pane";

            }
            else if (functionId == 2)
            {
                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "active";
                tab4.Attributes["class"] = "";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane active";
                Acknowledgement.Attributes["class"] = "tab-pane";
            }
            else if (functionId == 3)
            {

                tab1.Attributes["class"] = "";
                tab2.Attributes["class"] = "";
                tab3.Attributes["class"] = "";
                tab4.Attributes["class"] = "active";
                KRAKPIDiv.Attributes["class"] = "tab-pane";
                criticalJobs.Attributes["class"] = "tab-pane";
                PerformanceRating.Attributes["class"] = "tab-pane";
                Acknowledgement.Attributes["class"] = "tab-pane active";
            }

        }

        //KRA/KPI 

        #region KraKpi

        private void LoadGrid()
        {
            if (hdnStatus.Value == "2" || hdnStatus.Value == "1" || hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
            {
                if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() && hdnStatus.Value != "11")
                {
                    divAddKRAKPI.Visible = true;
                }
            }


            var dt = _Obj.GetKRAKPIDate(hdnEmpName.Value, GetAppID(),ReadSession().Emp_Id.ToString());


            if (dt == null||dt.Count==0)
            {
                GetStatic.SweetAlertErrorMessage(this, "Template Not Creaeted", "Template for this department has not been created yet");
                kra_grid.InnerHtml = "<tr><td colspan=\"6\" align=\"center\"> No Records to display.</td></tr>";
                //var dt1 = _Obj.getLevelDT();
                getAttributes(universalId.Value);
                return;
            }

            int sn = 1;
            int editIndex = 0;
            decimal totalKRASum = 0;
            decimal totalKPISum = 0;
            StringBuilder sb = new StringBuilder();

            foreach (var item in dt.GroupBy(x => x.KraTopic))
            {

                if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                    hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
                {
                    if (!string.IsNullOrWhiteSpace(hdnId2.Value) && editIndex == 0)
                    {
                        foreach (var dr in item)
                        {
                            if (dr.RowId.ToString() == hdnId2.Value)
                            {
                                editIndex = 1;
                            }
                        }
                    }
                }

                int rowcount = item.Count() + 1;
                sb.AppendLine("<tr>");


                if (editIndex == 1)
                {
                    sb.AppendLine("<td rowspan='" + (rowcount == 2 ? 1 : rowcount) + "'>" + sn + "</td>");
                    sb.AppendLine("<td rowspan='" + (rowcount == 2 ? 1 : rowcount) +
                                  "'><input type=\"text\" name=\"kraTopicEdit\" value=\"" +
                                  item.FirstOrDefault().KraTopic.ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td rowspan='" + (rowcount == 2 ? 1 : rowcount) +
                                  "'><input type=\"text\" id=\"KRWE" + item.FirstOrDefault().RowId +
                                  "\" name=\"kraWeightageEdit\" value=\"" +
                                  item.FirstOrDefault().kraWeightage +
                                  "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    editIndex = 2;
                }
                else
                {
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + sn + "</td>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().KraTopic.ToString() +
                                  "</td>");
                    sb.AppendLine("<td rowspan='" + rowcount + "'>" + item.FirstOrDefault().kraWeightage.ToString() +
                                  "</td>");
                    totalKRASum += Convert.ToDecimal(item.FirstOrDefault().kraWeightage);
                }

                sn++;
                sb.AppendLine("</tr>");
                foreach (var item1 in item)
                {
                    sb.AppendLine("<tr>");
                    if (item1.RowId.ToString() == hdnId2.Value)
                    {
                        sb.AppendLine("<td><input type=\"text\" id=\"KPTO" + item1.RowId +
                                      "\" name=\"kpiTopicEdit\" value=\"" + item1.KpiTopic +
                                      "\" class=\"form-control\" ></td>");
                        sb.AppendLine("<td><input type=\"text\" id=\"KPWE" + item1.RowId +
                                      "\" name=\"kpiWeightageEdit\" value=\"" + item1.KpiWeightage +
                                      "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                        if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                            hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14" || hdnStatus.Value == "14")
                        {
                            if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() &&
                                hdnStatus.Value != "11")
                            {
                                sb.AppendLine(
                                    "<td align=\"center\" nowrap=\"nowrap\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditData(" +
                                    item1.RowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                                sb.AppendLine(
                                    "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"Cancel(" +
                                    item1.RowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                            }
                        }
                    }
                    else
                    {
                        sb.AppendLine("<td>" + item1.KpiTopic + "</td>");
                        sb.AppendLine("<td>" + item1.KpiWeightage + "</td>");
                        totalKPISum += item1.KpiWeightage;
                        if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                            hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14" || hdnStatus.Value == "14")
                        {
                            if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() &&
                                hdnStatus.Value != "11")
                            {
                                sb.AppendLine(
                                    "<td align=\"center\" nowrap=\"nowrap\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEdit(" +
                                    item1.RowId +
                                    ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                                sb.AppendLine(
                                    "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"#\" onclick=\"onDelete(" +
                                    item1.RowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                            }

                        }
                    }

                    sb.AppendLine("</tr>");
                }
            }

            sb.AppendLine("<tr>");
            sb.AppendLine("<td colspan=\"3\" align=\"right\">" + totalKRASum + "</td>");
            sb.AppendLine("<td colspan=\"2\" align=\"right\">" + totalKPISum + "</td>");
            sb.AppendLine("</tr>");

            kra_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
        }

        protected void BtnDeleteRecord_Click(object sender, EventArgs e)
        {
            _Obj.DeleteReocrd(hdnId1.Value);
            LoadGrid();
        }

        protected void BtnEditRecord_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string kraTopic = "";
            string kraWeight = "";
            string kpiTopic = "";
            string kpiWeight = "";


            if (!string.IsNullOrEmpty(Request.Form["kraTopicEdit"]))
            {
                kraTopic = Request.Form["kraTopicEdit"].ToString();
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Field Should not be empty");
            }

            if (!string.IsNullOrEmpty(Request.Form["kraWeightageEdit"]))
            {
                kraWeight = Request.Form["kraWeightageEdit"].ToString();
                if (Regex.IsMatch(kraWeight, @"([0-9.])+") == false)
                {
                    GetStatic.SweetAlertErrorMessage(this, "Error", "KRA Weightage must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Field Should not be empty");
            }


            if (!string.IsNullOrEmpty(Request.Form["kpiTopicEdit"]))
            {
                kpiTopic = Request.Form["kpiTopicEdit"].ToString();
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Field Should not be empty");
            }

            if (!string.IsNullOrEmpty(Request.Form["kpiWeightageEdit"]))
            {
                kpiWeight = Request.Form["kpiWeightageEdit"].ToString();
                if (Regex.IsMatch(kpiWeight, @"([0-9.])+") == false)
                {
                    GetStatic.SweetAlertErrorMessage(this, "Error", "KPI Weightage must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Field Should not be empty");
            }

            var res = _Obj.EditData(kraTopic, kraWeight, kpiTopic, kpiWeight, ReadSession().Emp_Id.ToString(),
                filterstring(hdnId2.Value), hdnEmpName.Value, GetAppID());

            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", res.Msg);
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", res.Msg);
            }
        }

        private void ClearContent()
        {
            //kraTopic.Text = "";
            //kraWeight.Text = "";
            kpiTopic.Text = "";
            kpiWeight.Text = "";
        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            hdnId2.Value = "";
            LoadGrid();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(kraWeight.Text) == 0)
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "You cannot enter KRA weight 0");
                kraWeight.Text = "";
                kraWeight.Focus();
                return;
            }

            if (Convert.ToDecimal(kpiWeight.Text) == 0)
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "You cannot enter KPI weight 0 ");
                kpiWeight.Text = "";
                kpiWeight.Focus();
                return;
            }

            if (Convert.ToDecimal(kpiWeight.Text) > Convert.ToDecimal(kraWeight.Text))
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "You cannot enter Kpi more than kra");
                kpiWeight.Focus();
                kpiWeight.Text = "";
                return;
            }

            var res = _Obj.UpdateKriKpi(ReadSession().Emp_Id.ToString(), kraTopic.Text, kraWeight.Text, kpiTopic.Text,
                kpiWeight.Text, hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", res.Msg);
                hdnId2.Value = "";
                LoadGrid();
                ClearContent();
            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", res.Msg);
                if (!string.IsNullOrEmpty(res.Id))
                    SetRemainingWeight(res);
            }
        }

        protected void SetRemainingWeight(DbResult res)
        {
            var result = res.Id.Split('|');
            if (result[1].ToString() == "KRA")
            {
                kraWeight.Text = result[0].ToString();
            }
            else
            {

                kpiWeight.Text = result[0].ToString();

            }
        }

        protected void LoadKRAKPIGrid_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }

        #endregion

        //criticle Job

        #region Criticle Job

        private void LoadGridCJ()
        {

            if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
            {
                if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() && hdnStatus.Value != "11")
                {
                    divAddCriticalJobs.Visible = true;
                }
            }

            var dt = _Obj.GetCriticalJobsDate(hdnEmpName.Value, GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                criticalJobs_grid.InnerHtml =
                    "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                getAttributes(universalId.Value);
                return;
            }

            StringBuilder sb = new StringBuilder();
            int sno = 0;
            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString();
                sno++;
                if (rowId == hdnId2CJ.Value)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + sno + "</td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"kraScore\" value=\"" +
                                  item["objectives"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" id=\"per" + rowId + "\" name=\"perFormance\" value=\"" +
                                  item["deductionScore"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\" onkeyup=\"CheckDecimal(event)\"></td>");
                    if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                        hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
                    {
                        if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() &&
                            hdnStatus.Value != "11")
                        {
                            sb.AppendLine(
                                "<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"javascript:void(0)\"onclick=\"EditDataCJ(" +
                                rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                            sb.AppendLine(
                                "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"javascript:void(0)\" onclick=\"CancelCJ(" +
                                rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                        }
                    }
                }
                else
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>" + sno + "</td>");
                    sb.AppendLine("<td>" + item["objectives"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["deductionScore"].ToString() + "</td>");
                    if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                        hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
                    {
                        if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() &&
                            hdnStatus.Value != "11")
                        {
                            sb.AppendLine(
                                "<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEditCJ(" +
                                rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                            sb.AppendLine(
                                "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"javascript:void(0)\" onclick=\"onDeleteCJ(" +
                                rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                        }
                    }
                }

                sb.AppendLine("</tr>");
            }

            criticalJobs_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
            criticalJobs_grid.Focus();
        }

        protected void BtnDeleteRecordCJ_Click(object sender, EventArgs e)
        {
            _Obj.DeleteReocrdCriticalJobs(hdnId1CJ.Value);
            LoadGridCJ();
        }

        protected void BtnEditRecordCJ_Click(object sender, EventArgs e)
        {
            LoadGridCJ();
        }

        protected void LoadCJGrid_Click(object sender, EventArgs e)
        {
            LoadGridCJ();
        }

        protected void saveBtnCJ_Click(object sender, EventArgs e)
        {
            string objectives = "";
            string deductionScore = "";


            if (!string.IsNullOrEmpty(Request.Form["kraScore"]))
                objectives = filterstring(Request.Form["kraScore"].ToString());
            if (!string.IsNullOrEmpty(Request.Form["perFormance"]))
                deductionScore = filterstring(Request.Form["perFormance"].ToString());


            var res = _Obj.EditDataCriticalJobs(objectives, deductionScore, ReadSession().UserName.ToString(),
                filterstring(hdnId2CJ.Value), hdnEmpName.Value, GetAppID());

            if (res.ErrorCode.Equals("0"))
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", "Data updated successfully!");
                hdnId2CJ.Value = "";
                LoadGridCJ();
                ClearContentCJ();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }

        private void ClearContentCJ()
        {
            txtObjectives.Text = "";
            txtDeductionScore.Text = "";
        }

        protected void cancelCJ_Click(object sender, EventArgs e)
        {
            hdnId2CJ.Value = "";
            getAttributes(universalId.Value);
        }

        protected void BtnSaveCJ_Click(object sender, EventArgs e)
        {
            var res = _Obj.UpdateCriticalJobs(ReadSession().UserName.ToString(), txtObjectives.Text,
                txtDeductionScore.Text, hdnEmpName.Value, GetAppID());

            if (res.ErrorCode.Equals("0"))
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", "Data saved successfully!");
                hdnId2CJ.Value = "";
                LoadGridCJ();
                ClearContentCJ();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }

        #endregion

        //Performance Rating

        #region Performance Rating

        protected void LoadRatingGrid_Click(object sender, EventArgs e)
        {
            PopulateddlCriticality();
            LoadGridRating();
            LoadGridTranning();
        }

        private void LoadGridTranning()
        {

            if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
            {
                if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() && hdnStatus.Value != "11")
                {
                    divAddTraining.Visible = true;
                }
            }

            var dt = _Obj.GetProposedTrainingData(hdnEmpName.Value, GetAppID());

            if (dt.Rows.Count == 0 || dt.Rows == null || dt.Columns.Count == 3)
            {
                perfTranning_grid.InnerHtml =
                    "<tr><td colspan=\"4\" align=\"center\"> No Records to display.</td></tr>";
                getAttributes(universalId.Value);
                return;
            }

            if ((dt.Rows.Count) >= 3)
            {
                divRemarks.Visible = true;
                RFVRemarks.Visible = true;
            }
            else
            {
                divRemarks.Visible = false;
                RFVRemarks.Visible = false;
            }

            StringBuilder sb = new StringBuilder();
            int sno = 0;
            foreach (DataRow item in dt.Rows)
            {
                string rowId = item["RowId"].ToString() ?? "";
                sno++;
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sno + "</td>");
                if (rowId == hdnPrRowId2.Value)
                {
                    sb.AppendLine("<td><input type=\"text\" name=\"ProposedTrainingArea\" value=\"" +
                                  item["ProposedTrainingArea"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"Criticality\" value=\"" +
                                  item["Criticality"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\" onkeypress=\"return isNumber(event)\"></td>");
                    sb.AppendLine("<td><input type=\"text\" name=\"ProposedByDate\" value=\"" +
                                  item["ProposedByDate"].ToString() +
                                  "\" class=\"form-control\" onclick=\"retrun false\"></td>");
                    if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                        hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
                    {
                        if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() &&
                            hdnStatus.Value != "11")
                        {
                            sb.AppendLine(
                                "<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Update\" href=\"#\"onclick=\"EditDataPR(" +
                                rowId + ")\"><i class=\"fa fa-floppy-o\" aria-hidden=\"true\"></i></a>");
                            sb.AppendLine(
                                "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Cancel\" href=\"#\" onclick=\"CancelPR(" +
                                rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                        }
                    }

                }
                else
                {

                    sb.AppendLine("<td>" + item["ProposedTrainingArea"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["Criticality"].ToString() + "</td>");
                    sb.AppendLine("<td>" + item["ProposedByDate"].ToString() + "</td>");
                    if (hdnStatus.Value == "2" || hdnStatus.Value == "1" ||
                        hdnStatus.Value == "10" || hdnStatus.Value == "12" || hdnStatus.Value == "14")
                    {
                        if (hdnSupervisorId.Value == ReadSession().Emp_Id.ToString() &&
                            hdnStatus.Value != "11")
                        {
                            //sb.AppendLine("<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" href=\"#\"onclick=\"onViewPR(" + rowId + ")\"><i class=\"fa fa-eye\" aria-hidden=\"true\"></i></a>");
                            sb.AppendLine(
                                "<td align=\"center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Edit\" href=\"#\"onclick=\"onEditPR(" +
                                rowId + ")\"><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>");
                            sb.AppendLine(
                                "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href=\"javascript:void(0)\" onclick=\"onDeletePR(" +
                                rowId + ")\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></a></td>");
                        }
                    }
                }

                sb.AppendLine("</tr>");
            }

            perfTranning_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
            perfTranning_grid.Focus();
        }

        private void LoadGridRating()
        {
            var dt = _Obj.GetPerformanceRatingData();

            if (dt.Rows.Count == 0 || dt.Rows == null)
            {
                perfRatingRef_grid.InnerHtml =
                    "<tr><td colspan=\"2\" align=\"center\"> No Records to display.</td></tr>";
                getAttributes(universalId.Value);
                return;
            }

            StringBuilder sb = new StringBuilder();
            foreach (DataRow item in dt.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + item["KraAchiveScore"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["PerformLblRating"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["PercentIncrement"].ToString() + "</td>");
                sb.AppendLine("</tr>");
            }

            perfRatingRef_grid.InnerHtml = sb.ToString();
            getAttributes(universalId.Value);
            perfRatingRef_grid.Focus();
        }

        private void PopulateddlCriticality()
        {
            string selectValue = "";
            if (ddlCriticality.SelectedItem != null)
                selectValue = ddlCriticality.SelectedItem.Value.ToString();
            swift.setDDL(ref ddlCriticality, "Exec ProcStaticDataView 's','112'", "ROWID", "DETAIL_TITLE", selectValue,
                "Select");
        }

        protected void BtnPerfRatingAdd_OnClick(object sender, EventArgs e)
        {

            DateTime Startdate = Convert.ToDateTime(effectiveFrom.Text), Enddate = Convert.ToDateTime(effectiveTo.Text);
            bool Std = Convert.ToDateTime(txtPrDate.Text) >= Startdate ? true : false;
            bool Ed = Convert.ToDateTime(txtPrDate.Text) <= Enddate ? true : false;
            if (Std & Ed)
            {

            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Proposed Date should be in between appraisal Start Date and End Date");
                return;
            }
            var res = _Obj.UpdateCriticalPerformanceRating(ReadSession().Emp_Id.ToString(), txtProposedArea.Text,
                ddlCriticality.SelectedValue, txtPrDate.Text, hdnEmpName.Value, txtPrRemarks.Text, GetAppID());

            if (res.ErrorCode == "0")
            {
                GetStatic.AlertMessage(this, res.Msg);
                hdnPrRowId2.Value = "";
                LoadGridRating();
                LoadGridTranning();
                ClearPrContent();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }

        private void ClearPrContent()
        {
            txtProposedArea.Text = "";
            txtPrDate.Text = "";
            ddlCriticality.Text = "";
            txtPrRemarks.Text = "";
        }

        protected void BtnSavePR_Click(object sender, EventArgs e)
        {
            string proposedTrainingArea = "";
            string criticality = "";
            string proposedByDate = "";

            if (!string.IsNullOrEmpty(Request.Form["Criticality"]))
            {
                criticality = Request.Form["Criticality"];
                if (Regex.IsMatch(criticality, @"^\d+$") == false)
                {
                    GetStatic.AlertMessage(this, "Criticality must be in number");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }


            if (!string.IsNullOrWhiteSpace(Request.Form["ProposedTrainingArea"]))
            {
                proposedTrainingArea = Request.Form["ProposedTrainingArea"].ToString();
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }

            if (!string.IsNullOrWhiteSpace(Request.Form["ProposedByDate"]))
            {
                proposedByDate = Request.Form["ProposedByDate"].ToString();
                if (Regex.IsMatch(proposedByDate, "((0[1-9]|1[012])\\/(0[1-9]|[12]\\d|3[01])\\/((19|20)\\d\\d))$") ==
                    false)
                {
                    GetStatic.AlertMessage(this, "Enter the valid Date(MM/DD/YYYY)");
                    return;
                }
            }
            else
            {
                GetStatic.AlertMessage(this, "Field Should not be empty");
                return;
            }

            //if (!string.IsNullOrWhiteSpace(Request.Form["Criticality"]))
            //    criticality = Request.Form["Criticality"].ToString();
            //if (!string.IsNullOrWhiteSpace(Request.Form["ProposedByDate"]))
            //    proposedByDate = Request.Form["ProposedByDate"].ToString();

            DateTime Startdate = Convert.ToDateTime(effectiveFrom.Text), Enddate = Convert.ToDateTime(effectiveTo.Text);
            bool Std = Convert.ToDateTime(proposedByDate) >= Startdate ? true : false;
            bool Ed = Convert.ToDateTime(proposedByDate) <= Enddate ? true : false;
            if (Std & Ed)
            {

            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Proposed Date should be in between appraisal Start Date and End Date");
                return;
            }
            if (Convert.ToInt32(criticality) > 3 || Convert.ToInt32(criticality) <= 0)
            {
                GetStatic.AlertMessage(this, "Invalid Criticality inserted!");
                return;
            }

            var res = _Obj.EditDataPerformanceRating(proposedTrainingArea, criticality, proposedByDate,
                ReadSession().Emp_Id.ToString(), filterstring(hdnPrRowId2.Value), hdnEmpName.Value, GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.AlertMessage(this, res.Msg);
                hdnPrRowId2.Value = "";
                //LoadGridRating();
                LoadGridTranning();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Msg);
            }
        }

        protected void BtnEditRecordPR_Click(object sender, EventArgs e)
        {
            LoadGridTranning();

        }

        protected void BtnViewPR_Click(object sender, EventArgs e)
        {
            var dr = _Obj.ViewDataPerformanceRating(filterstring(hdnPrRowId1.Value), hdnEmpName.Value, GetAppID());
            if (dr == null)
            {
                return;
            }

            txtProposedArea.Text = dr["ProposedTrainingArea"].ToString();
            txtPrDate.Text = dr["ProposedByDate"].ToString();
            //divRemarks.Visible = !string.IsNullOrWhiteSpace(dr["Remarks"].ToString());
            txtPrRemarks.Text = dr["Remarks"].ToString();
            ddlCriticality.Text = dr["Criticality"].ToString();
            hdnPrRowId2.Value = "";
            LoadGridTranning();
        }

        protected void BtnCancelPR_Click(object sender, EventArgs e)
        {
            hdnPrRowId2.Value = "";
            //getAttributes(universalId.Value);
            ClearPrContent();
            LoadGridTranning();
        }

        protected void BtnDeleteRecordPR_Click(object sender, EventArgs e)
        {
            var res = _Obj.DeleteRecordPerformanceRating(hdnPrRowId1.Value);
            if (res.ErrorCode == "0")
            {
                //GetStatic.AlertMessage(this, res.Msg);
                hdnPrRowId1.Value = "";
                ClearPrContent();
                //LoadGridRating();
                LoadGridTranning();
            }
            else
            {
                GetStatic.AlertMessage(this, "Invalid delete operation!");
            }
        }

        #endregion

        //Performance Acknowledgement

        #region Acknowledgement
        private void LoadGridAck()
        {
            getAttributes(universalId.Value);

            int user = Convert.ToInt32(ReadSession().Emp_Id.ToString());
            string depart = ReadSession().Department;
           // bool ShowSave = false;
            bool HrAdmin = false;
            txt_disReason.Visible = true;
            Btn_Disagree.Visible = true;
            int supervisorid = 0, empId = 0, ReviewerId = 0, status = 0;

            var ds = _Obj.AckData(hdnEmpName.Value, GetAppID());
            DataTable res = ds.Tables[0];
            DataTable revStatus = ds.Tables[1];
            status = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["STATUS"].ToString()) ? "0" : revStatus.Rows[0]["STATUS"].ToString());
            supervisorid = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["supervisorId"].ToString()) ? "0" : revStatus.Rows[0]["supervisorId"].ToString());
            empId = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["employeeId"].ToString()) ? "0" : revStatus.Rows[0]["employeeId"].ToString());
            ReviewerId = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["reviewerId"].ToString()) ? "0" : revStatus.Rows[0]["reviewerId"].ToString());
            var IsAdmin = _Obj.CheckHrAdmin(ReadSession().Emp_Id.ToString());


            if (IsAdmin.Rows.Count == 1)
            {
                HrAdmin = true;
            }
            else
            {
                HrAdmin = false;
            }

            if (res.Columns.Count == 3)
            {
                GetStatic.SweetAlertMessage(this, "Alert", "Please Select Employee First");
                Response.Redirect(Request.RawUrl);
                return;
            }
            #region Loadcomment
            foreach (DataRow dr in res.Rows)
            {

                if (dr["commenterType"].ToString() == "Supervisor")
                {
                    chkSupervisor.Checked = true;
                    AckSuvDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                    hdnFlagSup.Value = "1";

                }
                else if (dr["commenterType"].ToString() == "Appraise" && dr["comment"].ToString() == "0")
                {
                    chkAppraisee.Checked = true;
                    hdnFlagAppraise.Value = "1";
                    AckAppraiseeDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");

                }
                else if (dr["commenterType"].ToString() == "Appraise" && dr["comment"].ToString() != "0")
                {

                    txt_disReason.Text = dr["comment"].ToString();
                    AckAppraiseeDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                    // ShowSave = true;

                }
                else if (dr["commenterType"].ToString() == "Reviewer")
                {
                    chkRevOfficer.Checked = true;
                    txtRevOfficer.Text = dr["comment"].ToString();
                    AckRevOfficerDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                    hdnFlagRev.Value = "1";

                }
                else if (dr["commenterType"].ToString() == "HRD")
                {
                    chkHRD.Checked = true;
                    txtHRD.Text = dr["comment"].ToString();
                    AckHrdDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                    hdnFlagHRD.Value = "1";

                }
                else if (dr["commenterType"].ToString() == "Appraise")
                {

                    txt_disReason.Text = dr["comment"].ToString();
                    hdnFlagHRD.Value = "1";
                    AckAppraiseeDate.Text = "Acknowledge on:  " + Convert.ToDateTime(dr["createdDate"].ToString()).ToString("yyyy-MMM-dd  hh:mm   tt");
                    txt_disReason.Enabled = false;

                }


            }
            #endregion
            #region setcheckbox
            chkAppraisee.Checked = false;
            chkRevOfficer.Checked = false;
            chkHRD.Checked = false;
            chkSupervisor.Checked = false;
            chkSupervisor.Enabled = false;
            chkAppraisee.Enabled = false;
            chkRevOfficer.Enabled = false;
            txtRevOfficer.Enabled = false;
            Btn_Disagree.Visible = false;
            saveBtn.Enabled = false;
            chkHRD.Enabled = false;
            txtHRD.Enabled = false;
            btnSaveHRD.Visible = false;
            txt_disReason.Enabled = false;
            if (status == 2 || status == 3 || status == 4 || status == 10 || status == 12 || status == 14)
            {
                chkSupervisor.Checked = true;
            }
            if (status == 3 || status == 4)
            {
                chkAppraisee.Checked = true;
            }
            if (status == 4)
            {
                chkRevOfficer.Checked = true;
            }
            #endregion
            if ((user == empId) && (status == 2 || status == 10 || status == 3))
            {
                chkSupervisor.Checked = true;
                chkAppraisee.Enabled = true;
                saveBtn.Enabled = true;
                btnSaveHRD.Visible = true;
                Btn_Disagree.Visible = true;
                Btn_Disagree.Enabled = true;
                txt_disReason.Enabled = true;


            }
            else if (user == supervisorid && (status == 2 || status == 10 || status == 12 || status == 14|| status==1))
            {


                chkSupervisor.Enabled = true;
                saveBtn.Enabled = true;
                btnSaveHRD.Visible = true;



            }
            else if (user == ReviewerId && (status == 3 || status == 12 || status == 4))
            {
                chkRevOfficer.Enabled = true;
                txtRevOfficer.Enabled = true;
                btnSaveHRD.Enabled = true;
                btnSaveHRD.Visible = true;
                Btn_Disagree.Visible = true;
                Btn_Disagree.Enabled = true;
            }



            else if (HrAdmin && (status == 4||status==14))
            {
                
                chkHRD.Enabled = true;
                txtHRD.Enabled = true;
                btnSaveHRD.Visible = true;
                btnSaveHRD.Enabled = true;
                Btn_Disagree.Visible = true;
                Btn_Disagree.Enabled = true;
                
            }

        }
        protected void LoadAckGrid_OnClick(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(hdnEmpName.Value))
            //{
            //    //Response.Redirect(Request.RawUrl);
            //    //GetStatic.SweetAlertMessage(this, "Alert", "Please Select Employee First");
            //    //Response.Write("<script>alert('Hello');</script>");
            //}
            //else
            //{
            //    LoadGridAck();
            //}
            LoadGridAck();

        }

        //protected void btnSaveAppraise_OnClick(object sender, EventArgs e)
        //{
        //    var chk = chkAppraisee.Checked ? "Y" : "N";
        //    if (chk == "N")
        //    {
        //        GetStatic.SweetAlertErrorMessage(this,"Checkbox","Please Check the CheckBox");
        //        return;
        //    }

        //    var res = _Obj.SaveAckApprData(hdnEmpName.Value, chk, "Reviewer", hdnEmpName.Value);
        //    if (res.ErrorCode =="0")
        //    {
        //        GetStatic.SweetAlertSuccessMessage(this,"Sucessful","Data Saved Sucessfully");
        //    }
        //    else
        //    {
        //        GetStatic.SweetAlertErrorMessage(this, "Error", "Couldnt Save Data");
        //    }
        //}

        //protected void btnSaveReviewOfficer_OnClick(object sender, EventArgs e)
        //{
        //    var chk = chkRevOfficer.Checked ? "Y" : "N";
        //    if (chk == "N")
        //    {
        //        GetStatic.SweetAlertErrorMessage(this, "Checkbox", "Please Check the CheckBox");
        //        return;
        //    }

        //    var res = _Obj.SaveAckOffData(ReadSession().Emp_Id.ToString(), chk, txtRevOfficer.Text, "Officer", hdnEmpName.Value);
        //    if (res.ErrorCode == "0")
        //    {
        //        GetStatic.SweetAlertSuccessMessage(this, "Sucessful", "Data Saved Sucessfully");
        //    }
        //    else
        //    {
        //        GetStatic.SweetAlertErrorMessage(this, "Error", "Couldnt Save Data");
        //    }
        //}
        protected void btnSaveHRD_OnClick(object sender, EventArgs e)
        {
            string cmtTypr = "";
            string comment = "";
            var chk0 = chkSupervisor.Checked ? "Y" : "N";
            var chk1 = chkAppraisee.Checked ? "Y" : "N";
            var chk2 = chkRevOfficer.Checked ? "Y" : "N";
            var chk3 = chkHRD.Checked ? "Y" : "N";

            int Count = Convert.ToInt32(_ObjR.CountPR(hdnEmpName.Value, GetAppID()));
            if (Count == 0)
            {
                GetStatic.SweetAlertErrorMessage(this, "Error",
                    "Please add atleast one Training Assessment in Performance Rating Tab");
                return;
            }

            string Res = _ObjR.ValidateKraKpi(GetAppID());
            if (!Res.Contains("Success"))
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", Res);
                return;
            }

            if (chkSupervisor.Checked && string.IsNullOrWhiteSpace(hdnFlagSup.Value))
            {
                decimal sum = 0;
                decimal total = 0;
                var competency = "";
                var dt = _ObjR.GetCompetencyData(hdnEmpName.Value, GetAppID());
                string User = ReadSession().UserId;
                foreach (DataRow dr in dt.Rows)
                {
                    if (competency == dr["CompetencyID"].ToString())
                    {
                        continue;
                    }

                    competency = dr["CompetencyID"].ToString();
                    sum = Convert.ToDecimal(dr["CompetencyWeight"].ToString());
                    total += sum;
                }

                if (100 != total)
                {
                    GetStatic.SweetAlertErrorMessage(this,
                        "Competency weight total is " + total + " but Competency  Weight must be 100", "");
                    return;
                }

                var competency1 = "";
                var dt1 = _ObjR.GetCompetencyData(hdnEmpName.Value, GetAppID());
                foreach (DataRow dr in dt1.Rows)
                {
                    decimal sum1 = 0;
                    if (competency1 == dr["CompetencyID"].ToString())
                    {
                        continue;
                    }

                    int competencyWeight = Convert.ToInt32(dr["CompetencyWeight"].ToString());
                    var competencyGroup = dt1.Select("CompetencyID='" + dr["CompetencyID"].ToString() + "'");
                    foreach (var group in competencyGroup)
                    {
                        competency1 = dr["CompetencyID"].ToString();
                        sum1 += Convert.ToDecimal(group["CompetencyKeyWeight"].ToString());
                    }

                    if (competencyWeight != sum1)
                    {
                        GetStatic.SweetAlertErrorMessage(this,
                            "Competency Key is " + dr["CompetencyWeight"].ToString() + "but Competency Key Weight is " +
                            sum1 + "", "Sum Of Competency Key Weight Must be equal to Competency Key");
                        return;
                    }
                }

                cmtTypr = "Supervisor";
                comment = "0";
            }

            if (chkSupervisor.Checked == true && hdnSupervisorId.Value == ReadSession().Emp_Id.ToString())
            {
                cmtTypr = "Supervisor";
                comment = "0";
            }

            if (chkAppraisee.Checked && hdnEmpName.Value == ReadSession().Emp_Id.ToString())
            {
                cmtTypr = "Appraise";
                comment = "0";
            }

            if (chkRevOfficer.Checked && hdnReviewerId.Value == ReadSession().Emp_Id.ToString())
            {
                cmtTypr = "Reviewer";
                comment = txtRevOfficer.Text;
            }

            if (chkHRD.Checked && string.IsNullOrWhiteSpace(hdnFlagHRD.Value))
            {
                cmtTypr = "HRD";
                comment = txtHRD.Text;
            }

            if (string.IsNullOrWhiteSpace(cmtTypr))
            {
                if (chk0 == "N")
                {
                    GetStatic.SweetAlertErrorMessage(this, "Checkbox", "Please Check the CheckBox");
                    return;
                }

                if (chk1 == "N")
                {
                    GetStatic.SweetAlertErrorMessage(this, "Checkbox", "Please Check the CheckBox");
                    return;
                }

                if (chk2 == "N")
                {
                    GetStatic.SweetAlertErrorMessage(this, "Checkbox", "Please Check the CheckBox");
                    return;
                }

                if (chk3 == "N")
                {
                    GetStatic.SweetAlertErrorMessage(this, "Checkbox", "Please Check the CheckBox");
                    return;
                }
            }

            var res = _Obj.SaveAckHRDData(ReadSession().Emp_Id.ToString(), "Y", comment, cmtTypr, hdnEmpName.Value,GetAppID());
            if (res.ErrorCode == "0")
            {
                GetStatic.SweetAlertSuccessMessage(this, "Sucessful", "Data Saved Sucessfully");
                btnSaveHRD.Enabled = false;
                Btn_Disagree.Enabled = false;

            }
            else
            {
                GetStatic.SweetAlertErrorMessage(this, "Error", "Couldnt Save Data");
            }
        }

        protected void btnDisagree_OnClick(object sender, EventArgs e)
        {
            string supervisor = hdnSupervisorId.Value;
            string user = ReadSession().Emp_Id.ToString();
            string reviewer = hdnReviewerId.Value;
            string depart = ReadSession().Department;
            string cmtTypr = "";
            string comment = "";
            bool HrAdmin = false;

            var ds = _Obj.AckData(hdnEmpName.Value, GetAppID());
            DataTable res = ds.Tables[0];
            DataTable revStatus = ds.Tables[1];
            int status = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["STATUS"].ToString()) ? "0" : revStatus.Rows[0]["STATUS"].ToString());
            int empId = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["employeeId"].ToString()) ? "0" : revStatus.Rows[0]["employeeId"].ToString());
            int ReviewerId = Convert.ToInt32(String.IsNullOrEmpty(revStatus.Rows[0]["reviewerId"].ToString()) ? "0" : revStatus.Rows[0]["reviewerId"].ToString());
            var IsAdmin = _Obj.CheckHrAdmin(ReadSession().Emp_Id.ToString());

            if (IsAdmin.Rows.Count == 1)
            {
                HrAdmin = true;
            }
            else
            {
                HrAdmin = false;
            }
            if (user == hdnEmpName.Value)
            {
                cmtTypr = "Appraise";
                comment = txt_disReason.Text;
            }
            else if (user == reviewer)
            {
                cmtTypr = "Reviewer";
                comment = txtRevOfficer.Text;
            }
            else if (HrAdmin && status == 4 && hdnEmpName.Value != user)
            {
                cmtTypr = "HRD";
                comment = txtHRD.Text;
            }


            _Obj.DisagreeAck(ReadSession().Emp_Id.ToString(), comment, cmtTypr, hdnEmpName.Value, GetAppID());
            GetStatic.SweetAlertSuccessMessage(this, "Disagreed", "Disagreed current PA ");
            return;

            #endregion
        }

    }
}