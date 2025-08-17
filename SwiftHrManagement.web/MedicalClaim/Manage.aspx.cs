using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.MedicalClaim
{
    public partial class Manage : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 245) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDDL();
                if (GetID() > 0)
                {
                    OnPopulateData();
                    BtnDelete.Visible = true;
                }
                else
                {
                    OnDisplayDoc();
                    OnDisplayTreatment();
                    OnDisplayEmpInfo();
                    BtnDelete.Visible = false;
                }
                MakeNumericTextbox(ref txtAmount);
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void PopulateDDL()
        {
            CLsDAo.setDDL(ref ddlDependedName, "Exec [procMedicalClaim] @flag='g',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "ID", "familyName", "", "Select");
            CLsDAo.setDDL(ref ddlParticulars, "Exec ProcStaticDataView 's','87'", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private void OnDisplayEmpInfo()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='e',@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            lblEmpName.Text = dr["empName"].ToString();
            lblBranch.Text = dr["branchName"].ToString();
            lblDept.Text = dr["deptName"].ToString();
            lblAge.Text = dr["age"].ToString();
        }

        private void OnPopulateData()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='s',@id=" + filterstring(GetID().ToString()) + ","
                                    +" @empId="+filterstring(ReadSession().Emp_Id.ToString())+"").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            lblEmpName.Text = dr["empName"].ToString();
            lblBranch.Text = dr["branchId"].ToString();
            lblDept.Text = dr["deptId"].ToString();
            lblPosition.Text = dr["positionId"].ToString();
            lblRelation.Text = dr["relationId"].ToString();
            lblAge.Text = dr["age"].ToString();
            lblDependendAge.Text = dr["dependendAge"].ToString();
            ddlDependedName.SelectedValue = dr["familyMemberId"].ToString();
            ddlClaimType.Text = dr["claimType"].ToString();
            if (ddlClaimType.Text == "Accident")
            {
                divAccident.Visible = true;
                divSickness.Visible = false;
                txtAccDateTime.Text = dr["accDateTime"].ToString();
                txtAccPlace.Text = dr["accPlace"].ToString();
                txtAccOccur.Text = dr["accOccur"].ToString();
                txtAccInjury.Text = dr["accInjury"].ToString();
                txtAccAttendingDoctor.Text = dr["accAttendingDoctor"].ToString();
            }

            else if (ddlClaimType.Text == "Sickness")
            {
                divSickness.Visible = true;
                divAccident.Visible = false;
                txtSickDate.Text = dr["sickDateTime"].ToString();
                txtSickAttendingDoctor.Text = dr["sickAttendingDoctor"].ToString();
                txtSickHospital.Text = dr["sickHospital"].ToString();
                txtSickDiagnosis.Text = dr["sickDiagnosis"].ToString();
                txtLeaveFrom.Text = dr["leaveFrom"].ToString();
                txtLeaveTo.Text = dr["leaveTo"].ToString();
            }
            else
            {
                divSickness.Visible = false;
                divAccident.Visible = false;
            }
           /*
            if (dr["claimStatus"].ToString() == "Approved")
            {
                divApproved.Visible = true;
                actualAmt.Text = dr["actAmount"].ToString();
                remarks.Text = dr["remarks"].ToString();
                BtnSave.Visible = false;
                btnAdd.Visible = false;
                BtnDelete.Visible = false;
            }
            else if (dr["claimStatus"].ToString() == "Requested")
            {
                divApproved.Visible = false;
            }
            else if (dr["claimStatus"].ToString() == "On Process")
            {
                divApproved.Visible = false;
                BtnSave.Visible = false;
                btnAdd.Visible = false;
                BtnDelete.Visible = false;
            }
            */
            OnDisplayTreatment();
            OnDisplayDoc();
            OnDisplayRpt();
        }

        private void OnDisplayTreatment()
        {
            double totAmt = 0.0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            if (GetID() > 0)
            {
                dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='j',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            }
            else
            {
                dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='k',@sessionId=" + filterstring(ReadSession().Sessionid) + ",@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "").Tables[0];
            }

            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
            str.Append("<th align=\"left\"><b>Delete</b></th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                totAmt = totAmt + double.Parse(dr["Amount"].ToString());
                str.Append("<tr>");
                
                for (int i = 1; i < ColumnsCount; i++)
                {
                    if(i==2)
                    {
                        str.Append("<td  width='400px'>" + dr[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td>" + dr[i] + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDelete('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan='2'><div  align='center'><b>Total</b></div></td>");
            str.Append("<td align='right'><b>" + ShowDecimal(totAmt) + "</b></td>");
            str.Append("<td>&nbsp;</td>");
            str.Append("</tr>");
            str.Append("</table>");
            rptShow.InnerHtml = str.ToString();
        }

        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void OnSave()
        {
            string flag = "";
            if (GetID() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }

            string msg = CLsDAo.GetSingleresult("exec [procMedicalClaim] @flag=" + filterstring(flag) + ",@id=" + filterstring(GetID().ToString()) + ""
                        + " ,@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@familyMemberId=" + filterstring(ddlDependedName.Text) + ","
                        + "  @claimType=" + filterstring(ddlClaimType.Text) + ",@accDateTime="+filterstring(txtAccDateTime.Text)+","
                        + "  @accPlace=" + filterstring(txtAccPlace.Text) + ",@accOccur=" + filterstring(txtAccOccur.Text) + ","
                        + "  @accInjury=" + filterstring(txtAccInjury.Text) + ",@accAttendingDoctor=" + filterstring(txtAccAttendingDoctor.Text) + ","
                        + "  @sickDateTime=" + filterstring(txtSickDate.Text) + ",@sickAttendingDoctor=" + filterstring(txtSickAttendingDoctor.Text) + ","
                        + "  @sickHospital=" + filterstring(txtSickHospital.Text) + ",@sickDiagnosis=" + filterstring(txtSickDiagnosis.Text) + ","
                        + "  @leaveFrom=" + filterstring(txtLeaveFrom.Text) + ",@leaveTo=" + filterstring(txtLeaveTo.Text) + ","
                        + "  @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@sessionId="+filterstring(ReadSession().Sessionid)+","
                        + "  @claimFor=" + filterstring("Self") + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void ddlClaimType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlClaimType.Text == "Accident")
            {
                divAccident.Visible = true;
                divSickness.Visible = false;
            }
                
            else if (ddlClaimType.Text == "Sickness")
            {
                divSickness.Visible = true;
                divAccident.Visible = false;
            }
            else
            {
                divSickness.Visible = false;
                divAccident.Visible = false;
            }
                
        }

        protected void ddlDependedName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDependedName.Text == ReadSession().Emp_Id.ToString())
            {
                lblDependendAge.Text = CLsDAo.GetSingleresult("select DATEDIFF(YEAR,BIRTH_DATE,getdate()) from employee where employee_id=" + filterstring(ddlDependedName.Text) + "");

                lblRelation.Text = "Self";
            }
            else
            {
                DataTable dt = new DataTable();
                dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='f',@familyMemberId=" + filterstring(ddlDependedName.Text) + "").Tables[0];
                DataRow dr = null;
                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                }
                lblDependendAge.Text = dr["dAge"].ToString();

                lblRelation.Text = dr["relationName"].ToString();
            }
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OnAddTreatAmount();
            }
            catch
            {
                LblMsg.Text = "Error in operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnAddTreatAmount()
        {
            CLsDAo.GetSingleresult("Exec [procMedicalClaim] @flag='h',@headId="+filterstring(ddlParticulars.Text)+",@amount="+filterstring(txtAmount.Text)+","
            + " @sessionId=" + filterstring(ReadSession().Sessionid) + ",@id=" + filterstring(GetID().ToString()) + ",@empId=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            OnDisplayTreatment();
        }

        protected void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("Exec [procMedicalClaim] @flag='d',@id='"+hdnId.Value+"'");

                OnDisplayTreatment();
            }
            catch
            {
                LblMsg.Text = "Error In Deletion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string msg = CLsDAo.GetSingleresult("EXEC [procMedicalClaim] @flag='delete',@id=" + filterstring(GetID().ToString()) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddReport_Click(object sender, EventArgs e)
        {
            CLsDAo.GetSingleresult("Exec procMedicalClaim @flag='rptType',@rptName=" + filterstring(txtReport.Text) + ",@rptType=" + filterstring(ddlReportType.Text) + ","
           + " @sessionId=" + filterstring(ReadSession().Sessionid) + ",@id=" + filterstring(GetID().ToString()) + "");
            OnDisplayRpt();
        }

        private void OnDisplayRpt()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            if (GetID() > 0)
            {
                dt = CLsDAo.getDataset("Exec procMedicalClaim @flag = 'rptDisplayA',@id = " + filterstring(GetID().ToString()) + "").Tables[0];
            }
            else
            {
                dt = CLsDAo.getDataset("Exec procMedicalClaim @flag = 'rptDisplayB',@sessionId = " + filterstring(ReadSession().Sessionid) + "").Tables[0];
            }

            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
            str.Append("<th align=\"left\"><b>Delete</b></th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");

                for (int i = 1; i < ColumnsCount; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td width='400px'>" + dr[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td>" + dr[i] + "</td>");
                    }

                }
                str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDeleteDoc('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            divReport.InnerHtml = str.ToString();
        }

        protected void btnDeleteRptType_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("Exec procMedicalClaim @flag='rptDelete',@id='" + hdnDocId.Value + "'");

                OnDisplayRpt();
            }
            catch
            {
                LblMsg.Text = "Error In Deletion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddDoc_Click(object sender, EventArgs e)
        {
            CLsDAo.GetSingleresult("Exec [procMedicalClaim] @flag='docType',@docName=" + filterstring(ddlDocumentOf.Text) + ",@docType=" + filterstring(ddlDocType.Text) + ","
           + " @sessionId=" + filterstring(ReadSession().Sessionid) + ",@id=" + filterstring(GetID().ToString()) + ",@empid=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            OnDisplayDoc();
        }

        private void OnDisplayDoc()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            if (GetID() > 0)
            {
                dt = CLsDAo.getDataset("Exec procMedicalClaim @flag = 'docDisplayA',@id = " + filterstring(GetID().ToString()) + "").Tables[0];
            }
            else
            {
                dt = CLsDAo.getDataset("Exec procMedicalClaim @flag = 'docDisplayB',@sessionId = " + filterstring(ReadSession().Sessionid) + ",@empId = " + filterstring(ReadSession().Emp_Id.ToString()) + "").Tables[0];
            }

            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
            str.Append("<th align=\"left\"><b>Delete</b></th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");

                for (int i = 1; i < ColumnsCount; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td width='400px'>" + dr[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td>" + dr[i] + "</td>");
                    }

                }
                str.Append("<td align=\"left\"><img style=\"cursor:pointer;\" onclick = \"IsDeleteDoc('" + dr["id"].ToString() + "')\" border = '0' title = \"Confirm Delete\" src=\"../../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            divDocument.InnerHtml = str.ToString();
        }

        protected void btnDeleteDocType_Click(object sender, EventArgs e)
        {
            try
            {
                CLsDAo.runSQL("Exec [procMedicalClaim] @flag='docDelete',@id='" + hdnDocId.Value + "'");

                OnDisplayDoc();
            }
            catch
            {
                LblMsg.Text = "Error In Deletion!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
