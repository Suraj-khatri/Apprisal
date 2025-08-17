using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;


namespace SwiftHrManagement.web.OverTime
{
    public partial class ManageRequestingOverTime : BasePage
    {
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;

        public ManageRequestingOverTime()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 100) == false)
                {
                    Response.Redirect("/Error.aspx");
                    
                }

                StaticPage.SetTimeDDL(ref ddlhourin, "", "Hour", true);
                StaticPage.SetTimeDDL(ref ddlminutein, "", "Minute", false);
                StaticPage.SetTimeDDL(ref ddlhourout, "", "Hour", true);
                StaticPage.SetTimeDDL(ref ddlminuteout, "", "Minute", false);
        
                if (GetId() > 0)
                {

                    BtnDelete.Visible = true;
                }
                else
                {
                    PopulateApprovalBy();
                    //txtdateIn.Text = System.DateTime.Today.ToShortDateString();
                    BtnDelete.Visible = false;
                }
                DisableFields();
            }

        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private string GetFlag()
        {
            return (Request.QueryString["Status"] != null ? Request.QueryString["Status"].ToString() : "");
        }

        private void PopulateApprovalBy()
        {

            EmployeeDAO superVisor = new EmployeeDAO();
            List<Employee> empList = superVisor.FindFullNameOfSuperVisor(int.Parse(ReadSession().Emp_Id.ToString()));

            if (empList != null && empList.Count > 0)
            {

                this.DdlApprovedBy.DataSource = empList;
                this.DdlApprovedBy.DataTextField = "EmpName";
                this.DdlApprovedBy.DataValueField = "Id";
                this.DdlApprovedBy.DataBind();
                this.DdlApprovedBy.SelectedIndex = 0;
            }
        }

        private void manageOverTime()
        {
            string reqInTime = "";
            string reqOutTime = "";

            if(DdlReqType.Text=="1453")
            {
                reqInTime = "00:00:00";
                reqOutTime = "00:00:00";
            }
            else
            {
                reqInTime = ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
                reqOutTime = ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";
            }
            string strflagflag = "i";
            long id = 0;
            id = GetId();

            if (id > 0)
                strflagflag = "u";

            string msg = _clsDao.GetSingleresult("exec [proc_OverTimeDetails] @flag='" + strflagflag + "', @OtRequest_id =" 
                        + filterstring(id.ToString()) + ", @requested_with =" + filterstring(DdlApprovedBy.Text) + ",@requested_date=" 
                        + filterstring(txtdateIn.Text) + ", @request_in_time=" + filterstring(reqInTime) + ", @request_out_time="
                        + filterstring(reqOutTime) + ", @requesting_type=" + filterstring(DdlReqType.Text) + ", @head_id = " 
                        + filterstring(ddlHardshipHead.Text) + ", @request_remark=" + filterstring(txtRemarks.Text) + ", @requested_by=" 
                        + filterstring(ReadSession().Emp_Id.ToString()) + ", @user=" + filterstring(ReadSession().UserId) + ", @statusFlag=" 
                        + filterstring(GetFlag()) + ",@from_date="+filterstring(txtFromDate.Text)+",@to_date="+filterstring(txtToDate.Text)+"");

            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        protected void btnSave0_Click(object sender, EventArgs e)
        {
            try
            {
                lblmsg.Text = "";
                if (ddlhourout.Text != "")
                {
                    if (long.Parse(ddlhourin.Text) > long.Parse(ddlhourout.Text))
                    {
                        lblmsg.Text = "Invalid Time, Time Out must be greater than Time In!";
                        lblmsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        this.manageOverTime();
                    }
                }
                else
                {
                    this.manageOverTime();
                }
            }
            catch
            {
                lblmsg.Text = "Error in insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        private bool checkTime()
        {
            if (long.Parse(ddlhourin.Text) > long.Parse(ddlhourout.Text))
            {
                lblmsg.Text = "Invalid Time, Time Out must be greater than Time In !";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return false;
              
            }
            else if (long.Parse(ddlhourin.Text) == long.Parse(ddlhourout.Text) && long.Parse(ddlminutein.Text) >= long.Parse(ddlminuteout.Text))
            {
                lblmsg.Text = "Invalid Time, Time Out must be greater than Time In !";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return false;
                
            }
            else return true;
          
        }

        private void TotalCalculatedHour()
        {
            if (ddlhourin.Text != "" && ddlhourout.Text != "" && ddlminutein.Text != "" && ddlminuteout.Text != "")
            {
                long _hour_in = long.Parse(ddlhourin.Text);
                long _hourout = long.Parse(ddlhourout.Text);

                long _mm_in = long.Parse(ddlminutein.Text);
                long _mmout = long.Parse(ddlminuteout.Text);

                if (checkTime() == false)
                    return;
                else
                {
                    lblmsg.Text = "";
                    if (_hourout >= _hour_in && _mmout >= _mm_in)
                    {
                        long mm = _mmout - _mm_in;
                        long hh = _hourout - _hour_in;
                        txtTotalTime.Text = hh.ToString() + ':' + mm.ToString() + ':' + "00";
                    }
                    else if (_hourout > _hour_in && _mmout < _mm_in)
                    {
                        long mm = 60 + _mmout - _mm_in;
                        long hh = _hourout - _hour_in - 1;
                        txtTotalTime.Text = hh.ToString() + ':' + mm.ToString() + ':' + "00";
                    }
                }
            }
        }

        protected void ddlhourin_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlminutein_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = _clsDao.ExecuteDataset("EXEC proc_OverTimeDetails @flag='att', @requested_date=" + filterstring(txtdateIn.Text) + ", @requested_by=" + ReadSession().Emp_Id.ToString()).Tables[0];

            var otTime = ddlhourin.Text + ":" + ddlminutein.Text;
            TimeSpan dateTime = TimeSpan.Parse(otTime);
            
            foreach (DataRow dr in dt.Rows)
            {
                TimeSpan loginTime = TimeSpan.Parse(dr["Logout Time"].ToString());
                if (loginTime < dateTime)
                {
                    lblmsg.Text = "Sorry! You cannot apply OT for more than your attendance.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    TotalCalculatedHour();
                    lblmsg.Text = "";
                }
            }
        }

        protected void ddlhourout_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlminuteout_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = _clsDao.ExecuteDataset("EXEC proc_OverTimeDetails @flag='att', @requested_date=" + filterstring(txtdateIn.Text) + ", @requested_by=" + ReadSession().Emp_Id.ToString()).Tables[0];
            var otTime = ddlhourout.Text + ":" + ddlminuteout.Text;
            TimeSpan dateTime = TimeSpan.Parse(otTime);
            foreach (DataRow dr in dt.Rows)
            {
                TimeSpan logoutTime = TimeSpan.Parse(dr["Logout Time"].ToString());
                if (logoutTime < dateTime)
                {
                    lblmsg.Text = "Sorry! You cannot apply OT for more than your attendance.";
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                else
                {
                    TotalCalculatedHour();
                    lblmsg.Text = "";
                }
            }
        }

        protected void DdlReqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(DdlReqType.Text))
            {
                CheckFields();
                _clsDao.CreateDynamicDDl(ddlHardshipHead, "select ROWID,DETAIL_TITLE from StaticDataDetail where applyOT='Y'", "ROWID", "DETAIL_TITLE", "", "Select");
            }
            else
            {
                DisableFields();
            }
        }

        private void CheckFields()
        {
            if (DdlReqType.Text == "650")
            {
                timing.Visible = true;
                hardshipHead.Visible = false;
                hardShipDates.Visible = false;
                oTDate.Visible = true;
            }
            else 
            {
                timing.Visible = false;
                hardshipHead.Visible = true;
                oTDate.Visible = false;
                hardShipDates.Visible = true;
            }
        }

        private void DisableFields()
        {
                timing.Visible = false;
                hardshipHead.Visible = false;
                oTDate.Visible = false;
                hardShipDates.Visible = false;
        }

        protected string CheckAttendance()
        {
            return _clsDao.GetSingleresult("Exec proc_OverTimeDetails @flag= 'ca',@EMPLOYEEID=" + ReadSession().Emp_Id.ToString() + ",@requested_date=" + filterstring(txtdateIn.Text) + "");
        }

        protected void txtdateIn_TextChanged(object sender, EventArgs e)
        {
            if (CheckAttendance() == "ABSENT")
            {
                lblmsg.Text = "Sorry! You have no attendance record for the requested date.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                lblmsg.Text = "";
                DisplayAttendance();
            }
        }

        private void DisplayAttendance()
        {
            long count = 1;
            DataTable dt;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            if (DdlReqType.Text == "650")
            {
               dt= new DataTable();
                dt= _clsDao.ExecuteDataset("EXEC proc_OverTimeDetails @flag='att', @requested_date=" + filterstring(txtdateIn.Text) + ", @requested_by=" + ReadSession().Emp_Id.ToString()).Tables[0];
            }
            else
            {
                dt = new DataTable();
             dt = _clsDao.ExecuteDataset("EXEC proc_OverTimeDetails @flag='har', @from_date=" + filterstring(txtFromDate.Text) + ",@to_date=" + filterstring(txtToDate.Text) + ", @requested_by=" + ReadSession().Emp_Id.ToString()).Tables[0];
                
            }
            txtNoOfDays.Text = dt.Rows.Count.ToString();
            if (txtNoOfDays.Text == "0")
            {
                lblmsg.Text = "Sorry! You have no logout record for the requested date.";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            //str.Append("<th align=\"left\">S.N.</th>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\" width=\"100\">" + dt.Columns[i].ColumnName + "</th>");
            }
            //str.Append("<th align=\"left\">Delete</th>");
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                //str.Append("<td align=\"left\">" + count++ + "</td>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\" width=\"100\"><b>" + dr[i] + "</b></td>");
                }
                //str.Append("<td align=\"left\"><img OnClick='OnDelete(" + dr["Id"] + ")' class=\"clickimage\" src=\"../../Images/delete.gif\" /></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptAtt.InnerHtml = str.ToString();
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            DisplayAttendance();
        }

        protected void txtFromDate_TextChanged(object sender, EventArgs e)
        {
            txtToDate.Text = "";
            txtNoOfDays.Text = "";
        }
    }
}
