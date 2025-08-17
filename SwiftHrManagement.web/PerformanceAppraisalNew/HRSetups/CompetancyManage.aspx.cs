using System;
using System.Data;
using System.Web.UI;
using Microsoft.SqlServer.Server;
using SwiftHrManagement.DAL.PerformanceApprasialNew;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.PerformanceAppraisalNew.HRSetups
{
    public partial class CompetancyManage : BasePage
    {
        clsDAO swift = null;
        RoleMenuDAOInv _roleMenuDao = null;
        private AppraisalDAO _appraisalDao = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDdlPosition();
                if (string.IsNullOrWhiteSpace(GetStatic.ReadQueryString("rowId", "")))
                {
                    //ShowUnsavedData();
                }
                else
                {
                    LoadCompetencyDetails();
                    txtComMatrixName.Enabled = true;
                    string rowId = GetStatic.ReadQueryString("rowId", "");
                    if (!string.IsNullOrWhiteSpace(rowId))
                    {
                        btnSave.Visible = false;
                        btnUpdate.Visible = true;
                    }
                    else
                    {
                        btnUpdate.Visible = false;
                    }
                }

            }

        }

        private void LoadCompetencyDetails()
        {
            var dt = _appraisalDao.LoadCompetencyDetails(GetStatic.ReadQueryString("rowId", ""), GetStatic.GetSessionId());
            ShowCompetancyData(dt);
        }

        private void ShowUnsavedData()
        {
            string levelname = txtComMatrixName.Text;
            ShowCompetancyData(_appraisalDao.ShowUnsavedData(GetStatic.GetSessionId(), levelname));
        }

        public CompetancyManage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this.swift = new clsDAO();
            this._appraisalDao = new AppraisalDAO();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string active = "";
            string Probation="";
            if (this.chkBoxProbation.Checked == true)
                active = "Y";
            else
                active = "N";

            if (this.chkBoxActive.Checked == true)
                Probation = "1";
            else
                Probation = "0";

            string comMatrixName = txtComMatrixName.Text;
            string rowId = ReadQueryString("rowid", "");
            int user = (int)ReadSession().Emp_Id;
            var res = _appraisalDao.SaveCompetency(comMatrixName, active, user.ToString(), GetStatic.GetSessionId(), rowId, Probation);
            if (res.Rows[0]["code"].ToString() == "0")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                rptDiv.InnerHtml = "";
                txtComMatrixName.Text = "";
                DdlPosition.SelectedIndex = 0;
                Response.Redirect("CompetancyList.aspx");
            }
            else if (res.Rows[0]["code"].ToString() == "2")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
            else
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             string active = "";
             string probation = "";
            if (this.chkBoxActive.Checked == true)
                active = "Y";
            else
                active = "N";

            if (this.chkBoxProbation.Checked == true)
                probation = "1";
            else
                probation = "0";
            string comMatrixName = txtComMatrixName.Text;
            string rowId = ReadQueryString("rowid", "");
            int user = (int)ReadSession().Emp_Id;
            var res = _appraisalDao.UpdateCompetency(comMatrixName, active, user.ToString(), GetStatic.GetSessionId(), rowId, probation);
            if (res.Rows[0]["code"].ToString() == "0")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                rptDiv.InnerHtml = "";
                txtComMatrixName.Text = "";
                DdlPosition.SelectedIndex = 0;
                Response.Redirect("CompetancyList.aspx");
            }
            else if (res.Rows[0]["code"].ToString() == "2")
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
            else
            {
                GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
            }
        }
        protected void BtnAdd_OnClick(object sender, EventArgs e)
        {
            string comMatrixName = txtComMatrixName.Text;
            string postion = DdlPosition.Text;
            string status = chkBoxActive.Checked ? "Y" : "N";
            string probation = chkBoxProbation.Checked ? "1" : "0";
            string rowId = GetStatic.ReadQueryString("rowId", "");
            string user = ReadSession().Emp_Id.ToString();
            if (string.IsNullOrWhiteSpace(rowId))
            {
                var dt = _appraisalDao.manageCompetency(comMatrixName, status, postion, GetStatic.GetSessionId(), rowId, user, probation);
                if ((string)dt.Rows[0]["code"] == "0")
                {
                    ShowUnsavedData();
                    //LoadCompetencyDetails();
                }
                else
                {
                    GetStatic.AlertMessage(this, dt.Rows[0]["msg"].ToString());
                }
            }
            else
            {
                //string id = hdnId.Value;
                var res = _appraisalDao.manageCompetency(comMatrixName, status, postion, GetStatic.GetSessionId(), rowId, user, probation);
                if (res.Rows[0]["code"].ToString() == "0")
                {
                    GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                    //ShowUnsavedData();
                    LoadCompetencyDetails();
                }
                else
                {
                    GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                }
            }

        }

        private void ShowCompetancyData(DataTable dt)
        {
            if (dt.Rows.Count == 0 || dt == null)
            {
                rptDiv.InnerHtml = "";
                return;
            }
            if (dt.Columns.Count == 2)
            {
                txtComMatrixName.Text = dt.Rows[0]["comMatrixName"].ToString();
                rptDiv.InnerHtml = "";
                return;
            }
            int i = 1;
            var comMatrixName = "";
            var sb = new System.Text.StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.Append("<tr>");
            sb.Append("<th align='center'>Sno</th>");
            sb.Append("<th align='center'>Position</th>");
            sb.Append("<th></th>");
            //sb.Append("<th></th>");

            sb.Append("</tr>");
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td align='center'>" + i + "</td>");
                sb.Append("<td align='center'>" + row["DETAIL_TITLE"] + "</td>");
                //sb.Append("<td align='center'><a href='#' onclick='EditFunction(" + row["id"] + ")'>Edit</a></td>");
                sb.Append("<td align='center'><a href='#' onclick='DeleteFunction(" + row["id"] + ")'>Delete</a></td>");
                sb.Append("</tr>");
                comMatrixName = row["comMatrixName"].ToString();
                i++;
            }
            sb.Append("</table></div>");
            rptDiv.InnerHtml = sb.ToString();
            DdlPosition.SelectedIndex = 0;
            string status = dt.Rows[0]["status"].ToString();
            string probation = dt.Rows[0]["IsProbation"].ToString();
            chkBoxActive.Checked = status == "Y";
            chkBoxProbation.Checked =Convert.ToBoolean(probation);
            txtComMatrixName.Text = comMatrixName;
            BtnAdd.Text = "Add";
        }

        private void PopulateDdlPosition()
        {
            string selectValue = "";

            if (DdlPosition.SelectedItem != null)
                selectValue = DdlPosition.SelectedItem.Value.ToString();

            swift.setDDL(ref DdlPosition, "Exec ProcStaticDataView 's','4'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }

        protected void BtnEdit_OnClick(object sender, EventArgs e)
        {
            string id = hdnId.Value;
            var ddlPositionText = _appraisalDao.GetTempCompetencyById(id) ?? "";
            if (!String.IsNullOrWhiteSpace(ddlPositionText))
            {
                DdlPosition.Text = ddlPositionText;
                BtnAdd.Text = "Update";
            }

        }

        protected void BtnDelete_OnClick(object sender, EventArgs e)
        {
            string position = hdnId.Value;
            string rowId = ReadQueryString("rowid", "");
            string Probation = chkBoxProbation.Checked ? "1" : "0";
            if (string.IsNullOrEmpty(rowId))
            {
              
                var res = _appraisalDao.DeleteTempCompetency(position, Probation);
                if (res.Rows[0]["code"].ToString() == "0")
                {
                    GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                    ShowUnsavedData();
                    //LoadCompetencyDetails();
                }
                else
                {
                    GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                }
            }
            else
            {
                var res = _appraisalDao.DeletePosition(position, Probation);
                if (res.Rows[0]["code"].ToString() == "0")
                {
                    GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                    //ShowUnsavedData();
                    LoadCompetencyDetails();
                }
                else
                {
                    GetStatic.AlertMessage(this, res.Rows[0]["msg"].ToString());
                }
            }

        }


    }
}