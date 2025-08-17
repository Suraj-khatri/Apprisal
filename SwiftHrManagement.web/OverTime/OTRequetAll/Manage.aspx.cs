using System;
using System.Collections.Generic;
using System.Text;
using SwiftHrManagement.Core.Domain;
using System.Data;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.EmployeeDAO;

namespace SwiftHrManagement.web.OverTime.OTRequetAll
{
    public partial class Manage : BasePage
    {
         clsDAO _clsDao = null;
         RoleMenuDAOInv _roleMenuDao = null;

         public Manage()
        {
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 104) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
               
                if (GetId() > 0)
                {
                   // BtnDelete.Visible = true;
                }
                else
                {
                    txtdateIn.Text = System.DateTime.Today.ToShortDateString();
                   
                }
            }
            DisplayOtRequest();
        }
        private long GetId()
        {
           
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

      
        private void manageTempOverTime()
        {
            string reqInTime;
            string reqOutTime;
            if (ddlReqType.Text == "650")
            {
                reqInTime = ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
                reqOutTime = ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";
            }
            else
            {
                reqInTime = "";
                reqOutTime = "";
            }
           

            string empname;
            empname = hdnemployeeID.Value;
            
            string strflagflag = "";
            long id = 0;

            id = GetId();
            if (id > 0)
                strflagflag = "u";
            else
                strflagflag = "i";

            _clsDao.runSQL("exec [proc_TempOverTimeDetails] @flag='" + strflagflag + "',@requested_with =" + filterstring(DdlApprovedBy.Text) 
               + ",@requested_date=" + filterstring(txtdateIn.Text) + ", @request_in_time=" + filterstring(reqInTime) + ","
               + " @request_out_time=" + filterstring(reqOutTime) + ",@requesting_type=" + ddlReqType.Text 
               + ",@headId="+filterstring(ddlHardshipHead.Text)+",@request_remark=" + filterstring(txtRemarks.Text) 
               + ",@requested_by=" + filterstring(empname) + ",@user=" + ReadSession().Emp_Id.ToString() + "," 
               + " @seseion_Id=" + filterstring(ReadSession().Sessionid) + "");
            ResetOperation();
            DisplayOtRequest();
        }

        private void ResetOperation()
        {
            txtdateIn.Text = "";
            ddlhourin.Text = "";
            ddlminutein.Text = "";
            ddlhourout.Text = "";
            ddlminuteout.Text = "";
            txtTotalTime.Text = "";
            txtRemarks.Text = "";
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

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec [proc_OverTimeDetails] @flag='i',@sessionId="+filterstring(ReadSession().Sessionid)+"");
            Response.Redirect("List.aspx");
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
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
                        this.manageTempOverTime();
                       
                    }
                }
                else
                {
                    this.manageTempOverTime();
                  
                }
            }
            catch
            {
                lblmsg.Text = "Error in insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }


        private void DisplayOtRequest()
        {
            DataTable dt;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            if (ddlReqType.Text == "650")
            {
               
                string sql = "Exec [proc_TempOverTimeDetails] @flag='t',@seseion_Id=" + filterstring(ReadSession().Sessionid) + "";
                dt = _clsDao.getDataset(sql).Tables[0];
            }
            else
            {
                string sql = "Exec [proc_TempOverTimeDetails] @flag='h',@seseion_Id=" + filterstring(ReadSession().Sessionid) + "";
                dt = _clsDao.getDataset(sql).Tables[0];
            }
           

           
            if (dt.Rows.Count == 0)
            {
                rtpOt.InnerHtml = "<center><b> No OverTime  is Requested.</b><center>";
                return;
            }

            otsave.Visible = true;
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 1)
                    {

                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rtpOt.InnerHtml = str.ToString();
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec [proc_TempOverTimeDetails] @flag='d' , @Temp_OtRequest_id = " + Temp_OtID.Value + "");
            DisplayOtRequest();
        }

        protected void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            string SuperVisorId = hdnemployeeID.Value;
            if (SuperVisorId != "")
            {
                EmployeeDAO superVisor = new EmployeeDAO();
                List<Employee> empList = superVisor.FindFullNameOfSuperVisor(int.Parse(SuperVisorId));

                if (empList != null && empList.Count > 0)
                {
                    this.DdlApprovedBy.DataSource = empList;
                    this.DdlApprovedBy.DataTextField = "EmpName";
                    this.DdlApprovedBy.DataValueField = "Id";
                    this.DdlApprovedBy.DataBind();
                    this.DdlApprovedBy.SelectedIndex = 0;
                }
            }
        }

        protected string CheckAttendance()
        {
            string empname = hdnemployeeID.Value;
            return _clsDao.GetSingleresult("Exec proc_OverTimeDetails @flag = 'ca',@EMPLOYEEID=" + empname + ",@requested_date=" + filterstring(txtdateIn.Text) + "");
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
                DisplayAuthorisedBy();
            }
        }

        private void DisplayAuthorisedBy()
        {
            long count = 1;
            DataTable dt;
            string empname = hdnemployeeID.Value;
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            if (ddlReqType.Text == "650")
            {
                dt = _clsDao.ExecuteDataset("EXEC proc_OverTimeDetails @flag='att', @requested_date=" + filterstring(txtdateIn.Text) + ", @requested_by=" + empname + "").Tables[0];

            }
            else
            {
                dt = _clsDao.ExecuteDataset("EXEC [proc_TempOverTimeDetails] @flag='x', @requested_date=" + filterstring(txtdateIn.Text) + ", @requested_by=" + empname + "").Tables[0];
 
            }

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"center\". width=\"150\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"center\" width=\"150\"><b>" + dr[i] + "</b></td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptAtt.InnerHtml = str.ToString();
        }

        protected void ddlReqType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ddlReqType.Text))
            {
                timing.Visible = ddlReqType.Text.Equals("650") ? true : false;
                hardshipHead.Visible = ddlReqType.Text.Equals("650") ? false : true;
                _clsDao.CreateDynamicDDl(ddlHardshipHead, "select ROWID,DETAIL_TITLE from StaticDataDetail where applyOT='Y'", "ROWID", "DETAIL_TITLE", "", "Select");
            }
            else
            {
                timing.Visible = false;
            }
        }

        
    }
}
