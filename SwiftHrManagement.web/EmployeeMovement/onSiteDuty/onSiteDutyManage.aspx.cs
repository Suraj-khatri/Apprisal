using System;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.OnSiteDuty;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.EmployeeMovement.onSiteDuty
{
    public partial class onSiteDutyManage : BasePage
    { 
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        
        onSiteDutyAssignmentCore _onSiteDuty = null;
        onSiteDutyAssignmentDAO _onSiteDutyDao = null;
        clsDAO _clsdao = null;

        public onSiteDutyManage()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._onSiteDutyDao = new onSiteDutyAssignmentDAO();
            this._onSiteDuty = new onSiteDutyAssignmentCore();
            
            this._clsdao = new clsDAO();
        }

        private long GetDutyID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        public string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"].ToString()) : "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ApprovedRemarks.Visible = false;
                approvedDate.Visible = false;
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 48) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                if (GetFlag() == "i")
                {
                    txtEmpId.Text = _clsdao.GetSingleresult("select RTRIM(dbo.GetEmployeeInfoById(" + filterstring(ReadSession().Emp_Id.ToString()) + "))");
                    txtEmpId.Enabled = false;
                    ApprovedRemarks.Visible = false;
                    approvedDate.Visible = false;
                    btnAdd.Visible = false;
                }
                else if (GetFlag() == "")
                {
                    ApprovedRemarks.Visible = true;
                    approvedDate.Visible = true;
                }

                if (GetDutyID() > 0)
                {
                    populateOnSiteDuty();
                    BtnDelete.Visible = true; 
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
        }

        private void PrepareData()
        {
            string[] a = txtApproveBy.Text.Split('|');

            string approver = a[1];
            string empId = HiddenEmpid.Value;


            string[] e = txtEmpId.Text.Split('|');
            empId = e[1];

            onSiteDutyAssignmentCore _onSiteDuty = new onSiteDutyAssignmentCore();

            long id = this.GetDutyID();

            if (id > 0)
            {
                _onSiteDuty.OnsiteID = int.Parse(id.ToString());
                _onSiteDuty.ModifyBy = ReadSession().UserId.ToString();
            }
            else
            {
                _onSiteDuty.CreatedBy = ReadSession().UserId;
            }
            _onSiteDuty.SiteDateFrom = this.txtDateFrom.Text;
            _onSiteDuty.SiteDateTo = this.txtDateTo.Text;
            _onSiteDuty.SiteLocation = this.txtLocation.Text;
            _onSiteDuty.Purpose = this.txtPurpose.Text;
            _onSiteDuty.Description = this.txtDesc.Text;
            _onSiteDuty.EmpId = empId;
            _onSiteDuty.ApproveBy = approver;
            _onSiteDuty.ApprovedDate = this.txtApprovedDate.Text;

            if (GetFlag() == "i")
            {
                _onSiteDuty.Recorded = "N";
                _onSiteDuty.Status = "Pending";
            }
            else
            {
                _onSiteDuty.Recorded = "Y";
                _onSiteDuty.Status = "Approved";
            }
            this._onSiteDuty = _onSiteDuty;
        }

        private void populateOnSiteDuty()
        {
            _onSiteDuty = _onSiteDutyDao.FindallById(this.GetDutyID());
            //this.txtEmpId.Text = _clsdao.GetSingleresult("select FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME+' '+'-'+' '+ EMP_CODE+'('+' '+b.BRANCH_NAME+' '+')'+ '|'  + CONVERT(varchar, e.EMPLOYEE_ID) as employee_details from Employee e"
            //     + " inner join Branches b on b.BRANCH_ID = e.BRANCH_ID where  e.EMPLOYEE_ID=" + _onSiteDuty.EmpId.ToString() + "");  

            //OnDisplayRpt();
            txtEmpId.Text = _clsdao.GetSingleresult("select rtrim(dbo.GetEmployeeInfoById(" + _onSiteDuty.EmpId + "))");
            txtDateFrom.Text = _onSiteDuty.SiteDateFrom;
            txtDateTo.Text = _onSiteDuty.SiteDateTo;
            txtLocation.Text = _onSiteDuty.SiteLocation;
            txtPurpose.Text = _onSiteDuty.Purpose;
            txtDesc.Text = _onSiteDuty.Description;
            txtApproveBy.Text = _clsdao.GetSingleresult("select rtrim(dbo.GetEmployeeInfoById(" + _onSiteDuty.ApproveBy + "))");
            txtApprovedDate.Text = _onSiteDuty.ApprovedDate;


            if (!string.IsNullOrWhiteSpace(_onSiteDuty.ApprovedDate))
            {
                approvedDate.Visible = true;
                ApprovedRemarks.Visible = true;
                btnAdd.Visible = false;
                Btn_Save.Visible = false;
                txtDateFrom.Enabled = false;
                txtDateTo.Enabled = false;
                txtDesc.Enabled = false;
                txtLocation.Enabled = false;
                txtPurpose.Enabled = false;
                txtApprovedDate.Enabled = false;
                txtApproveBy.Enabled = false;
                //lblAppRemarks.Enabled = false;
                txtAppRemarks.Text = _onSiteDuty.ApprovedRemarks;
                txtApprovedDate.Text = _onSiteDuty.ApprovedDate;
            }
            else
            {
                approvedDate.Visible = false;
                ApprovedRemarks.Visible = false;
                btnAdd.Visible = true;
                Btn_Save.Visible = true;
                txtDateFrom.Enabled = true;
                txtDateTo.Enabled = true;
                txtDesc.Enabled = true;
                txtLocation.Enabled = true;
                txtPurpose.Enabled = true;
                txtApprovedDate.Enabled = true;
                txtApproveBy.Enabled = true;
            }
            //OnDisplayRpt();

            //HiddenEmpid.Value = _onSiteDuty.EmpId;
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                this.manageDutyAssign();
                Response.Redirect("onSiteDutyDetail.aspx?flag=" + GetFlag());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void manageDutyAssign()
        {
            string[] arrayApprovedBy = txtApproveBy.Text.Split('|');
            string approvedBy = arrayApprovedBy[1];
            string flag1 = "";
            if (GetID() > 0)
            {
                flag1 = "update";
            }
            else
            {
                flag1 = "insert";
            }

            if (GetFlag() == "i")
            {

                string[] empid = txtEmpId.Text.Split('|');
                string emp = empid[1];
                string msg = _clsdao.GetSingleresult("exec procOnSiteDuty @flag=" + filterstring(flag1) + ", @id=" +
                                                     filterstring(GetID().ToString())
                                                     + ", @empId=" + filterstring(emp)
                             + ", @fromDate=" + filterstring(txtDateFrom.Text) + ", @toDate=" +
                             filterstring(txtDateTo.Text)
                             + ", @location=" + filterstring(txtLocation.Text) + ", @purpose=" +
                             filterstring(txtPurpose.Text)
                             + ", @approvedBy=" + filterstring(approvedBy) + ", @description=" +
                             filterstring(txtDesc.Text)
                             + ", @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ", @sessionId=" +
                             filterstring(ReadSession().Sessionid));

                if (msg.Contains("Success"))
                {
                    Response.Redirect("onSiteDutyDetail.aspx?flag=i");
                }
                else
                {
                    lblmsg.Text = msg;
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                string msg = _clsdao.GetSingleresult("exec procOnSiteDuty @flag=" + filterstring(flag1) + ", @id=" + filterstring(GetID().ToString())
                                            + ", @fromDate=" + filterstring(txtDateFrom.Text) + ", @toDate=" + filterstring(txtDateTo.Text)
                                            + ", @location=" + filterstring(txtLocation.Text) + ", @purpose=" + filterstring(txtPurpose.Text)
                                            + ", @approvedBy=" + filterstring(approvedBy) + ", @approvedDate=" + filterstring(txtApprovedDate.Text) 
                                            + ", @appRemarks=" + filterstring(txtAppRemarks.Text) + ", @description=" + filterstring(txtDesc.Text) 
                                            + ", @user=" + filterstring(ReadSession().Emp_Id.ToString())
                                            + ", @sessionId="+filterstring(ReadSession().Sessionid));

                if (msg.Contains("Success"))
                {
                    Response.Redirect("onSiteDutyDetail.aspx");
                }
                else
                {
                    lblmsg.Text = msg;
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }

        private void deleteDuty()
        {
            try
            {

                this._onSiteDutyDao.DeleteById(this.GetDutyID(), ReadSession().UserId);
                Response.Redirect("onSiteDutyDetail.aspx");
            }
            catch
            {
                lblmsg.Text = "Error In Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            deleteDuty();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if(GetFlag()=="i")
                Response.Redirect("onSiteDutyDetail.aspx?flag="+GetFlag());
            else
                Response.Redirect("onSiteDutyDetail.aspx");
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string msg = _clsdao.GetSingleresult("Exec procOnSiteDuty @flag='insertOSD', @empId=" +
                                    filterstring(getEmpIdfromInfo(txtEmpId.Text)) + ", @sessionId=" +
                                    filterstring(ReadSession().Sessionid));
            OnDisplayRpt();
            txtEmpId.Text = "";
            if (!string.IsNullOrWhiteSpace(msg))
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblmsg.Text = "";
            }
        }

        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"]) : 0);
        }

        private void OnDisplayRpt()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
            str.Append("<tr>");
            DataTable dt = new DataTable();
            if (GetID() > 0)
            {
                dt = _clsdao.getDataset("Exec procOnSiteDuty @flag = 'DisplayA', @osd_id = " + filterstring(GetID().ToString()) + "").Tables[0];
            }
            else
            {
                dt = _clsdao.getDataset("Exec procOnSiteDuty @flag = 'DisplayB', @sessionId = " + filterstring(ReadSession().Sessionid) + "").Tables[0];
            }
            string appStatus = getApprovedStatus(GetDutyID().ToString());

            int ColumnsCount = dt.Columns.Count;
            
            for (int i = 1; i < ColumnsCount; i++)
            {
                if (i == 1)
                {
                    str.Append("<th align\"left\" ><b>" + dt.Columns[i].ColumnName + "</b></th>");
                }
                if (i > 1)
                {
                    str.Append("<th align=\"left\" ><b>" + dt.Columns[i].ColumnName + "</b></th>");
                }
            }
            if (appStatus == "Pending" || appStatus == "")
            {
                str.Append("<th align=\"left\"><b>Delete</b></th>");
            }
            else if (appStatus == "Approved" || appStatus == "Rejected")
            {
                str.Append("");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");

                for (int i = 1; i < ColumnsCount; i++)
                {
                    if (i == 2)
                    {
                        str.Append("<td nowrap='nowrap'>" + dr[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td nowrap='nowrap'>" + dr[i] + "</td>");
                    }

                }
                if (appStatus == "Pending" || appStatus == "")
                {
                    str.Append("<td align=\"left\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Remove\" onclick = \"IsDeleteDetail('" +
                               dr["id"].ToString() +
                               "')\" border = '0' title = \"Confirm Delete\" href=\"#\"><i class=\"fa fa-times\" aria-hidden=\"true\"></a></td>");
                }
                    
                else if (appStatus == "Approved" || appStatus == "Rejected")
                {
                    str.Append("");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rptOnsiteDetail.InnerHtml = str.ToString();
        }

        private string getApprovedStatus(string tadaid)
        {
            return _clsdao.GetSingleresult("EXEC procOnSiteDuty @flag='appstatus',@id=" + tadaid);
        }

        protected void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            //string st = _clsdao.GetSingleresult("Exec procOnSiteDuty @flag = 'Displayc', @sessionId = " + filterstring(ReadSession().Sessionid) + "");
            try
            {
                _clsdao.runSQL("Exec procOnSiteDuty @flag = 'detailDelete', @sessionId = " + filterstring(ReadSession().Sessionid) + ", @osd_id=" + hdnDetailId.Value + "");
                OnDisplayRpt();
            }
            catch
            {
                lblmsg.Text = "Error In Deletion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
