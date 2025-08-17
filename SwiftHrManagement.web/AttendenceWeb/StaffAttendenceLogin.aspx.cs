using System;
using System.Data;

namespace SwiftHrManagement.web
{
    public partial class StaffAttendenceLogin : BasePage
    {
        clsDAO CLsDAo = null;
        private string IP_Address = "";

        public StaffAttendenceLogin()
        {
            CLsDAo = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            IP_Address = Request.ServerVariables["REMOTE_ADDR"];

            if (!Page.IsPostBack)
            {
                lblServerTIme.Text = DateTime.Now.ToString();
                PopulateDdl();
                GetStatusMessage();
            }
        }

        private void PopulateDdl()
        {
            CLsDAo.CreateDynamicDDl(DdlReasonType, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID=57", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"].ToString()) : "");
        }
        private void GetStatusMessage()
        {
            if (Request.QueryString["msg"] != null)
                Lblstatus.Text = Request.QueryString["msg"].ToString();
            if (Request.QueryString["ot"] != null)
            {
                OT_div.Visible = true;
            }                
        }
        public DataRow SelectById()
        {
            string sql = "exec [proc_OfficeTimeSetup] @flag='startTime'";

            DataSet ds = CLsDAo.ExecuteDataset(sql);
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].Rows[0];
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Lblstatus.Text = "";
           // StaticPage sPage = new StaticPage();
            //DateTime getStartTime = sPage.getStartEndTime("OfficeStartTime");
            //DateTime getEndTime = sPage.getStartEndTime("OfficeEndTime");
            //DateTime getFridayTime = sPage.getStartEndTime("OfficeFridayEndTime");


            DataRow dr = SelectById();
            if (dr == null)
                return;

            DateTime getStartTime = Convert.ToDateTime(dr["login_time"].ToString());
            DateTime getEndTime = Convert.ToDateTime(dr["logout_time"].ToString());
            DateTime getFridayTime = Convert.ToDateTime(dr["friday_logout_time"].ToString());

            string MSG = CLsDAo.GetSingleresult("EXEC [procCheckEmployeeAttendance] @USER_NAME="+filterstring(txtEmployeeName.Text)+","
                +" @USER_PASSWORD="+filterstring(txtEmployeePassword.Text)+",@ATTEN_TYPE="+filterstring("IN")+",@LOGIN_TIME='"+getStartTime+"',"
                +" @LOGOUT_TIME='"+getEndTime+"',@HALFDAY_TIME='"+getFridayTime+"'");

            if (MSG == "1")
            {
                Lblloginreason.Text = "Attendance LOGIN Reason";
                InLoginRemark.Visible = true;
                pnlLogin.Visible = false;
                BtnLogOut1.Visible = false;
                return;
            }
            else if (MSG == "0")
            {
                NormalLogin("IN");
            }
            else
            {
                lblmsg.Text = MSG;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }
        void NormalLogin(string ATT_TYPE)
        {
            string msg = "";

            msg = CLsDAo.GetSingleresult(" Exec [procEmployeeLogin_New] @FLAG='a',@USER_NAME=" + filterstring(txtEmployeeName.Text) + ","
                + " @USER_PSW=" + filterstring(hdnUserPassword.Value) + ",@ATT_TYPE=" + filterstring(ATT_TYPE) + ",@IP_Address=" + filterstring(IP_Address) + "");

            Response.Redirect("StaffAttendenceLogin.aspx?flag=" + GetFlag() + "&msg=" + msg + "");
        }
        private void InLoginReason(string ATT_TYPE)
        {
            string msg = "";

            msg = CLsDAo.GetSingleresult(" Exec [procEmployeeLogin_New] @FLAG='a',@USER_NAME=" + filterstring(txtEmployeeName.Text) + ","
                + " @USER_PSW=" + filterstring(hdnUserPassword.Value)+",@REASON_TYPE="+filterstring(DdlReasonType.Text)+","
                + " @REASON_DETAIL=" + filterstring(txtBoxDetails.Text) + ",@ATT_TYPE=" + filterstring(ATT_TYPE) + ",@IP_Address=" + filterstring(IP_Address) + "");

            Response.Redirect("StaffAttendenceLogin.aspx?flag=" + GetFlag() + "&msg=" + msg + "");
        }

        protected void BtnLogIN1_Click(object sender, EventArgs e)
        {
            InLoginReason("IN");
        }

        protected void BtnLogOut1_Click(object sender, EventArgs e)
        {
            InLoginReason("OUT");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Lblstatus.Text = "";
            DataRow dr1 = SelectById();
            if (dr1 == null)
                return;

            DateTime getStartTime = Convert.ToDateTime(dr1["login_time"].ToString());
            DateTime getEndTime = Convert.ToDateTime(dr1["logout_time"].ToString());
            DateTime getFridayTime = Convert.ToDateTime(dr1["friday_logout_time"].ToString());

            hdnUserName.Value = txtEmployeeName.Text;
            hdnUserPassword.Value = txtEmployeePassword.Text;


            DataTable dt = CLsDAo.getTable("EXEC [procCheckEmployeeAttendance] @USER_NAME=" + filterstring(txtEmployeeName.Text) + ","
                + " @USER_PASSWORD=" + filterstring(txtEmployeePassword.Text) + ",@ATTEN_TYPE=" + filterstring("OUT") + ","
                +" @LOGIN_TIME='" + getStartTime + "',@LOGOUT_TIME='" + getEndTime + "',@HALFDAY_TIME='" + getFridayTime + "'");
            foreach (DataRow dr in dt.Rows)
            {
                string MSG = dr["REMARKS"].ToString();
                if (MSG == "1")
                { 
                    Lblloginreason.Text = "Attendance LOGOUT Reason";
                    InLoginRemark.Visible = true;
                    pnlLogin.Visible = false;
                    BtnLogIN1.Visible = false;
                    return;
                }
                else if (MSG == "2")
                {
                    populateDDLTime();
                    OtRequest.Visible = true;
                    lblLoginTime.Text=dr["LOGIN_TIME"].ToString();
                    lblLogoutTime.Text=dr["LOGOUT_TIME"].ToString();
                    lblActualLoginTime.Text=dr["A_LOGIN_TIME"].ToString();
                    lblActualLogoutTime.Text=dr["OT_TO_DATE"].ToString();
                    lblOTHours.Text=dr["OT_HOUR"].ToString();
                    lblOTfromTime.Text = dr["OT_FROM_DATE"].ToString();
                    lblOTtoTime.Text = dr["OT_TO_DATE"].ToString();
                    txtFromTime.Text = dr["FROM_DATE"].ToString();
                    txtToTime.Text = dr["TO_DATE"].ToString();
                    ddlhourin.Text = dr["FROM_HOUR"].ToString();
                    ddlminutein.Text = dr["FROM_MINUTE"].ToString();
                    ddlhourout.Text = dr["TO_HOUR"].ToString();
                    ddlminuteout.Text = dr["TO_MINUTE"].ToString();
                    txtApplyOtHour.Text = dr["OT_HOUR"].ToString();
                    txtEmpId.Text = dr["EMP_ID"].ToString();
                    CLsDAo.CreateDynamicDDl(ddlApprovedBy, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[super_name] from SuperVisroAssignment where  EMP = "+txtEmpId.Text+" and record_status='y'", "SUPERVISOR", "super_name", "", "Select");
                    CLsDAo.CreateDynamicDDl(ddlRecommendedBY, "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR)[super_name] from SuperVisroAssignment where  EMP = "+txtEmpId.Text+" and record_status='y'", "SUPERVISOR", "super_name", "", "Select");
                    pnlLogin.Visible = false;
                    BtnLogIN1.Visible = false;
                    return;
                }
                else if (MSG == "0")
                {
                    NormalLogin("OUT");
                }
                else
  
                {
                    lblmsg.Text = MSG;
                    lblmsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
            }            
        }

        protected void btnLogoutOT_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlhourin.Text != "" && ddlhourout.Text != "" && ddlminutein.Text != "" && ddlminuteout.Text != "" && txtFromTime.Text != "" && txtToTime.Text != "")
                {
                    string reqInTime = txtFromTime.Text + ' ' + ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
                    string reqOutTime = txtToTime.Text + ' ' + ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";

                    if (DateTime.Parse(reqInTime) > DateTime.Parse(reqOutTime))
                    {
                        lblLogutMsg.Text = "Invalid Time, Time Out must be greater than Time In!";
                        lblLogutMsg.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    else
                    {
                        string msg = "";
                        msg = CLsDAo.GetSingleresult(" Exec [procEmployeeLogin_New] @FLAG='b',@USER_NAME=" + filterstring(txtEmployeeName.Text) + ","
                            + " @USER_PSW=" + filterstring(hdnUserPassword.Value) + ",@LOGOUT_TIME='" + lblActualLogoutTime.Text + "',"
                            + " @OT_FROM_DATE=" + filterstring(reqInTime) + ",@OT_TO_DATE="+filterstring(reqOutTime)+","
                            + " @IS_OT=" + filterstring(ddlOTApply.Text) + ",@REMARKS=" + filterstring(txtRemarks.Text) + ","
                            + " @requested_with="+filterstring(ddlRecommendedBY.Text)+","
                            + " @hod_approved_by=" + filterstring(ddlApprovedBy.Text) + ",@IP_Address=" + filterstring(IP_Address) + "");

                        Response.Redirect("StaffAttendenceLogin.aspx?flag=" + GetFlag() + "&msg=" + Lblstatus.Text + "");
                    }
                }
            }
            catch
            {
                lblLogutMsg.Text = "Error In Logout!";
                lblLogutMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void TotalCalculatedHour()
        {
            if (ddlhourin.Text != "" && ddlhourout.Text != "" && ddlminutein.Text != "" && ddlminuteout.Text != "" && txtFromTime.Text != "" && txtToTime.Text != "")
            {
                string reqInTime = txtFromTime.Text + ' ' + ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
                string reqOutTime = txtToTime.Text + ' ' + ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";
                string OT_Hour = CLsDAo.GetSingleresult("SELECT CONVERT(VARCHAR(5), DATEADD(s,DATEDIFF(s,'" + reqInTime + "','" + reqOutTime + "'),0), 108)");
                txtApplyOtHour.Text = OT_Hour;
            }
        }
        protected void ddlhourin_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlminutein_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlhourout_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }

        protected void ddlminuteout_SelectedIndexChanged(object sender, EventArgs e)
        {
            TotalCalculatedHour();
        }
        private void populateDDLTime()
        {
            StaticPage.SetTimeDDL(ref ddlhourin, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlminutein, "", "Minute", false);
            StaticPage.SetTimeDDL(ref ddlhourout, "", "Hour", true);
            StaticPage.SetTimeDDL(ref ddlminuteout, "", "Minute", false);
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (GetFlag() == "a") //check the user weather user is logged in or not
                this.Page.MasterPageFile = "~/SwiftHRManager.Master";
            else
                this.Page.MasterPageFile = "~/ProjectMaster.Master";
        }
    }
}
