using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.DailyActivityRecord;

namespace SwiftHrManagement.web.DailyActivityReport
{
    public partial class DailyActivityRecord : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        DailyActivityDao _dailyActivityDao = new DailyActivityDao();
        clsDAO _clsDao = new clsDAO();
       protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 10081) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                DisplayActivityDetails();
                txtDate.Text = DateTime.Now.ToString("M/d/yyyy");
                setDDL();
            }
            DisplayEmpInfo();
            
            lblmsg.Text = "";
            lblDMsg.Text = "";

        }
       private void setDDL()
       { 
          var sql = "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR) supName from SuperVisroAssignment"
                    +" where EMP = "+ReadSession().Emp_Id+"  and SUPERVISOR_TYPE = 's' and record_status = 'y'";
          _clsDao.setDDL(ref ddlRecommend, sql, "SUPERVISOR", "supName", "", "SELECT");
       
       }
       private void setDDL(string superId)
       {
           var sql = "select SUPERVISOR,dbo.GetEmployeeFullNameOfId(SUPERVISOR) supName from SuperVisroAssignment"
                     + " where EMP = " + ReadSession().Emp_Id + "  and SUPERVISOR_TYPE = 's' and record_status = 'y'";
           _clsDao.setDDL(ref ddlRecommend, sql, "SUPERVISOR", "supName", superId, "select");

       }
       private void DisplayEmpInfo()
       {
           DataTable dt = _dailyActivityDao.DisplayEmpInfo(ReadSession().Emp_Id.ToString());
           DataRow dr = null;
           if (dt == null || dt.Rows.Count <= 0)
               return;
           dr = dt.Rows[0];
           lblEName.Text = dr["empName"].ToString();
           lblDept.Text = dr["deptName"].ToString();
           lblBranch.Text = dr["branchName"].ToString();

       }
        private void TotalCalculatedHour()
        {
            if (ddlhourin.Text != "" && ddlhourout.Text != "" && ddlminutein.Text != "" && ddlminuteout.Text != "")
            {
                if (checkTime() == false)
                    return;
                else
                {
                    long _hour_in = long.Parse(ddlhourin.Text);
                    long _hourout = long.Parse(ddlhourout.Text);

                    long _mm_in = long.Parse(ddlminutein.Text);
                    long _mmout = long.Parse(ddlminuteout.Text);

                    hdnfromTime.Value = _hour_in.ToString() + ':' + _mm_in.ToString() + ':' + "00";
                    hdntoTime.Value = _hourout.ToString() + ':' + _mmout.ToString() + ':' + "00";
                }
               

            }
        }
        private bool checkTime()
        {
            if (long.Parse(ddlhourin.Text) > long.Parse(ddlhourout.Text))
            {
                lblDMsg.Text = "Invalid Time, Time Out must be greater than Time In !";
                lblDMsg.ForeColor = System.Drawing.Color.Red;
                return false;

            }
            else if (long.Parse(ddlhourin.Text) == long.Parse(ddlhourout.Text) && long.Parse(ddlminutein.Text) >= long.Parse(ddlminuteout.Text))
            {
                lblDMsg.Text = "Invalid Time, Time Out must be greater than Time In !";
                lblDMsg.ForeColor = System.Drawing.Color.Red;
                return false;

            }
            else return true;

        }

        private long ActivityID()
        {
            
            if((hdnEdivActivityId.Value.ToString() == ""))
            {
            return 0;
            }
            else
             return  long.Parse(hdnEdivActivityId.Value);

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
          
            if (ActivityID() > 0)
            {
                OnUpdateActivityDetails();
            }
            else
            {
                OnAddDailyRecord();
                 Reset();
            }
        }

        private void OnAddDailyRecord()
        {
            string msg = _dailyActivityDao.OnAddDailyActivity(hdnfromTime.Value, hdntoTime.Value, txtDetail.Text, ReadSession().Sessionid.ToString(), txtDate.Text, ReadSession().Emp_Id.ToString());
            lblDMsg.Text = msg;
            lblDMsg.ForeColor = System.Drawing.Color.Green;
            DisplayActivityDetails();

        }

        private void OnUpdateActivityDetails()
        {

            string msg = _dailyActivityDao.OnUpdateActivityDetails(hdnfromTime.Value, hdntoTime.Value, txtDetail.Text,hdnEdivActivityId.Value);
            lblDMsg.Text = msg;
            lblDMsg.ForeColor = System.Drawing.Color.Green;
            OnSearch();

        }
        private void DisplayActivityDetails()
        {
             StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
             DataTable dt = _dailyActivityDao.DisplayActivityDetails(ReadSession().Sessionid.ToString());
            if (dt.Rows.Count == 0)
            {
                rpt.InnerHtml = "<center><b> </b></center>";
                return;
            }

          
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
                    if (i == 3)
                    {

                        str.Append("<td align=\"left\" width=\"30px\"><textarea readonly=\"readonly\"  style=\" border: 0; overflow: auto; width:40em; height:5em;font-size: 12px;\">" + dr[i].ToString() + " </textarea></td>");
                    }
                  else
                   str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            OnDeleteDailyAdd();
        }
        private void OnDeleteDailyAdd()
        {
          string msg =   _dailyActivityDao.OnDeleteActivityDeatils(long.Parse(hdnActivityDId.Value));
          DisplayActivityDetails();
        }

        protected void BtnFinalSave_Click(object sender, EventArgs e)
        {
            OnFinalSave();
        }
        private void OnFinalSave()
        {
          string msg  =   _dailyActivityDao.OnFinalSave(ReadSession().Branch_Id.ToString(), ReadSession().Department.ToString()
                            , ReadSession().Designation.ToString(), ReadSession().Emp_Id.ToString(),ReadSession().Sessionid,txtDate.Text,ddlRecommend.Text);
          lblmsg.Text = msg;
          DisplayActivityDetails();
          Reset();

        }
        private void Reset()
        {
            ddlhourin.ClearSelection();
            ddlminutein.ClearSelection();
            ddlhourout.ClearSelection();
            ddlminuteout.ClearSelection();
            txtDetail.Text = "";        

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            OnSearch();
        }

        private void OnSearch()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt = _dailyActivityDao.OnSearch(ReadSession().Emp_Id.ToString(), txtDate.Text);
            if (dt.Rows.Count == 0)
            {
                //rpt.InnerHtml = "<center><b> No Daily Activity  is Added.</b></center>";
                return;
            }
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                if (i >=0 && i < 6)
                {
                    str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                }
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i >= 0 && i < 6)
                    {
                        if (i == 3)
                        {

                            str.Append("<td align=\"left\" width=\"30px\"><textarea readonly=\"readonly\"  style=\" border: 0; overflow: auto; width:40em; height:5em;font-size: 12px;\">" + dr[i].ToString() + " </textarea></td>");
                        }

                        else
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    if (i == 6)
                    {

                        setDDL(dr[i].ToString());
                    }

                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

            
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            PopulateData();
        }
        private void PopulateData()
        {

            DataTable dt =   _dailyActivityDao.OnPupalate(hdnEdivActivityId.Value);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            string fromTime = dr["fromTime"].ToString();
            string [] arrayFromTime = fromTime.Split(':');
            ddlhourin.Text  = arrayFromTime[0];
            ddlminutein.Text = arrayFromTime[1];

            string toTime = dr["toTime"].ToString();
            string[] arrayToTime = toTime.Split(':');
            ddlhourout.Text = arrayToTime[0];
            ddlminuteout.Text = arrayToTime[1];


            hdnfromTime.Value = ddlhourin.Text + ':' + ddlminutein.Text + ':' + "00";
            hdntoTime.Value = ddlhourout.Text + ':' + ddlminuteout.Text + ':' + "00";
            txtDetail.Text = dr["details"].ToString();
          
        }
    }
}
