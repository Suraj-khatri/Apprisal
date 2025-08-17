using System;
using System.Data;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.MedicalClaim
{
    public partial class ManageClaim : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public ManageClaim()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 246) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                OnPopulateData();
                MakeNumericTextbox(ref actualAmt);
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
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
            lblDependedName.Text = dr["dependendName"].ToString();
            lblClaimType.Text = dr["claimType"].ToString();
            lblPRemarks.Text = dr["onProcRemarks"].ToString();
            if (lblClaimType.Text == "Hospitalization")
            {
                divHospitalization.Visible = true;
                divSickness.Visible = false;
                hosAdmissionDate.Text = dr["hosAddmissionDate"].ToString();
                hosDiagnosis.Text = dr["hosDiagnosis"].ToString();
                txtAccAttendingDoctor.Text = dr["accAttendingDoctor"].ToString();
            }

            else if (lblClaimType.Text == "Sickness")
            {
                divSickness.Visible = true;
                divHospitalization.Visible = false;
                txtSickDate.Text = dr["sickDateTime"].ToString();
                txtSickAttendingDoctor.Text = dr["sickAttendingDoctor"].ToString();
                txtSickHospital.Text = dr["sickHospital"].ToString();
                txtSickDiagnosis.Text = dr["sickDiagnosis"].ToString();
                txtLeaveFrom.Text = dr["leaveFrom"].ToString();
                txtLeaveTo.Text = dr["leaveTo"].ToString();
            }

            if (dr["claimStatus"].ToString() == "On Process")
            {
                divApproved.Visible = true;
                btnApprove.Visible = true;
                btnProcess.Visible = false;
                btnReject.Visible = false;
                divOnproc.Visible = false;
                divlblPRemarks.Visible = true;
            }

            if (dr["claimStatus"].ToString() == "Reimburse")
            {
                btnApprove.Visible = false;
                btnProcess.Visible = false;
                divApproved.Visible = true;
                divOnproc.Visible = false;
                divlblPRemarks.Visible = true;
                actualAmt.Text = dr["actAmount"].ToString();
                remarks.Text = dr["remarks"].ToString();
              
            }

            if (dr["claimStatus"].ToString() == "Rejected")
            {
                btnApprove.Visible = false;
                btnProcess.Visible = false;
                divApproved.Visible = false;
                divOnproc.Visible = false;
                divlblPRemarks.Visible = true;
            }
            OnDisplayTreatment();
            OnDisplayDoc();
            OnDisplayRpt();
            OnDisplayUploadedFiles();

            if(GetFlag()=="p")
            {
                btnApprove.Visible = false;
                btnProcess.Visible = false;
                btnReject.Visible = false;
            }
        }

        private void OnDisplayUploadedFiles()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='uploadS',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            TableRow tr = null;
            TableCell td1 = null;
            TableCell td2 = null;
            TableCell td3 = null;
            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;


            if (dt.Rows.Count > 0)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td3 = new TableCell();
                tr.CssClass = "TBL";
                td1.Text = "<strong>File Desciption</strong>";
                td2.Text = "<strong>File Type</strong>";
                td3.Text = "<strong>View</strong>";
                td1.CssClass = "TBL";
                td2.CssClass = "TBL";
                td3.CssClass = "TBL";

                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);
                tblResult.Rows.Add(tr);

                foreach (DataRow row in dt.Rows)
                {
                    tr = new TableRow();
                    td1 = new TableCell();
                    td2 = new TableCell();
                    td3 = new TableCell();
         
                    td1.Text = row["docDesc"].ToString();
                    td2.Text = row["docExt"].ToString();
                    td3.Text = "<a target='_blank' href='/doc/medicalClaim" + "/" + row["id"] + "." + row["docExt"].ToString() + "'> View </a>";

                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tblResult.Rows.Add(tr);
                }
            }            
        }

        private void OnDisplayTreatment()
        {
            double totAmt = 0.0;
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
                dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='j',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            
            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                totAmt = totAmt + double.Parse(dr["Amount"].ToString());
                for (int i = 1; i < ColumnsCount; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td  width='400px'>" + dr[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td>" + dr[i] + "</td>");
                    }
                }
                 
                str.Append("</tr>");
            }
            str.Append("<tr>");
            str.Append("<td colspan='2'><div  align='center'><b>Total</b></div></td>");
            str.Append("<td align='right'><b>" + ShowDecimal(totAmt) + "</b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            rptShow.InnerHtml = str.ToString();
        }

        private void OnDisplayDoc()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='docDisplayA',@id=" + filterstring(GetID().ToString()) + "").Tables[0];

            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
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

                str.Append("</tr>");
            }
            str.Append("</table>");
            divDoc.InnerHtml = str.ToString();
        }

        private void OnDisplayRpt()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table class='simpleTBL'>");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procMedicalClaim] @flag='rptDisplayA',@id=" + filterstring(GetID().ToString()) + "").Tables[0];

            int ColumnsCount = dt.Columns.Count;
            for (int i = 1; i < ColumnsCount; i++)
            {
                str.Append("<th align=\"left\"><b>" + dt.Columns[i].ColumnName + "</b></th>");
            }
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

                str.Append("</tr>");
            }
            str.Append("</table>");
            divRpt.InnerHtml = str.ToString();
        }

        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ?  Request.QueryString["flag"].ToString() : "");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProcessClaim.aspx");
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            OnProcess();
        }

        private void OnProcess()
        {
            string msg=CLsDAo.GetSingleresult("EXEC [procMedicalClaim] @flag='p',@id="+filterstring(GetID().ToString())+",@onProcRemarks="+filterstring(onProcremarks.Text)+"");

            if (msg.Contains("Success"))
            {
                Response.Redirect("ProcessClaim.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            string msg = CLsDAo.GetSingleresult("EXEC [procMedicalClaim] @flag='Reimburse',@id=" + filterstring(GetID().ToString()) + ","
            +"@amount="+filterstring(actualAmt.Text)+",@remarks="+filterstring(remarks.Text)+"");

            if (msg.Contains("Success"))
            {
                Response.Redirect("ProcessClaim.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            string msg = CLsDAo.GetSingleresult("EXEC [procMedicalClaim] @flag='reject',@id=" + filterstring(GetID().ToString()) + ",@onProcremarks=" + filterstring(onProcremarks.Text) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("ProcessClaim.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
