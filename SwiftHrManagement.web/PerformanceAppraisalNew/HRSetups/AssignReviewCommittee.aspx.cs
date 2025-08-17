using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class AssignReviewCommittee : BasePage 
    {
        AppraisalDAO _appraisal = null;
        RoleMenuDAOInv _roleMenuDAOInv = null;

        public AssignReviewCommittee()
        {
            _appraisal = new AppraisalDAO();
            this._roleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (_roleMenuDAOInv.hasAccess(ReadSession().AdminId, 1113) == false)
            {
                Response.Redirect("/Error.aspx");
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("rowId", "")))
                {
                    LoadLevelName();
                    //LoadAssignReviewDetails();
                    ShowAssignReviewTempData();
                    chkBoxActive.Checked = true;

                }
            }

        }

        //private void LoadAssignReviewDetails()
        //{
        //    var dt = _appraisal.LoadAssignReviewDetails(GetStatic.ReadQueryString("rowId", ""), GetStatic.GetSessionId());
        //    ShowAssignReviewData(dt);
        //}

        private void LoadLevelName()
        {
            var dt = _appraisal.LoadLevelName(GetStatic.ReadQueryString("rowId", ""));
            var comMatrixName = "";
            comMatrixName = dt.Rows[0]["LevelName"].ToString();
            lblLevelName.Text = comMatrixName;
        }

        //protected void BtnAdd_Click(object sender, EventArgs e)
        //{
        //    string levelName = lblLevelName.Text;
        //    string empName = txtEmpName.Text;
        //    string status = chkBoxActive.Checked ? "Y" : "N";

        //    var dt = _appraisal.assignReviewCommittee(levelName, empName, status, GetStatic.GetSessionId(), "");
        //    if ((string)dt.Rows[0]["code"] == "0")
        //    {
        //        ShowAssignReviewTempData();
        //        txtEmpName.Text = "";
        //    }
        //    else
        //    {
        //        GetStatic.AlertMessage(this, dt.Rows[0]["msg"].ToString());
        //    }
        //}

        private void ShowAssignReviewTempData()
        {
            ShowAssignReviewData(_appraisal.ShowAssignReviewTempData(GetStatic.ReadQueryString("rowId",""), hdnId.Value));
        }


        private void ShowAssignReviewData(DataTable dt)
        {
            if (dt.Rows.Count == 0 || dt == null)
            {
                rpt.InnerHtml = "";
                return;
            }

            int i = 1;
            var comMatrixName = "";
            var sb = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.Append("<tr>");
            sb.Append("<th align='center'>Sno</th>");
            sb.Append("<th align='center'>Employee Name</th>");
            //sb.Append("<th></th>");
            sb.Append("<th></th>");

            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td align='center'>" + i + "</td>");
                sb.Append("<td align='center'>" + row["EmployeeName"] + "</td>");
                //sb.Append("<td align='center'><a href='#' onclick='EditFunction(" + row["id"] + ")'>Edit</a></td>");
                sb.Append("<td align='center'><a href='#' onclick='DeleteFunction(" + row["RowId"] + ")'>Delete</a></td>");
                sb.Append("</tr>");
                comMatrixName = row["comMatrixName"].ToString();
                i++;
            }
            sb.Append("</table></div>");
            rpt.InnerHtml = sb.ToString();
            string status = dt.Rows[0]["Active"].ToString();
            chkBoxActive.Checked = status == "Y";
            //txtComMatrixName.Text = comMatrixName;
            //BtnAdd.Text = "Add";
        }



        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hdnEmpId.Value))
            {
                GetStatic.SweetAlertMessage(this,"","Please select Employee from Auto Complete");
                return;
            }
            string active = "";
            if (this.chkBoxActive.Checked == true)
                active = "Y";
            else
                active = "N";
            string LevelName = lblLevelName.Text;

            int user = (int)ReadSession().Emp_Id;
            var res = _appraisal.SaveAssignReviewCommittee(user.ToString(), LevelName, hdnEmpId.Value, active, GetStatic.ReadQueryString("rowId", ""), hdnId.Value);
            if (res.Rows[0]["code"].ToString() == "0")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                hdnEmpId.Value = "";
                rpt.InnerHtml = "";
                txtEmpName.Text = "";
                //Response.Redirect("CompetancyList.aspx");
                ShowAssignReviewTempData();
            }
            else if (res.Rows[0]["code"].ToString() == "1")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
            else if (res.Rows[0]["code"].ToString() == "2")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
            else if (res.Rows[0]["code"].ToString() == "3")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                ShowAssignReviewTempData();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
        }
        protected void BtnDelete_OnClick(object sender, EventArgs e)
        {
            string id = hdnId.Value;
            var res = _appraisal.DeleteTempAssignReviewCommittee(id);
            if (res.Rows[0]["code"].ToString() == "0")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                ShowAssignReviewTempData();
            }
            else
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
        }
       
    }
}