using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.EventCalander;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.web
{
    public partial class Main : BasePage
    {
        EventCalanderDAO _eventCal = null;
        clsDAO _clsdao = null;

        public Main()
        {
            _clsdao = new clsDAO();
            _eventCal = new EventCalanderDAO();
        }

        string y = "";
        string m = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string flag = Request.QueryString["q"] == "" ? "null" : Request.QueryString["q"].ToString();
            this.ReadSession().MenuType = flag;
            PopulateBirthdayList();
            PopulateAvailableLeave();
            PopulateLeave();
            GetLeaveCount();
            GetAttendanceCount();
            GetRequisitionCount();
            LoadCircularData();

            notifyPwd.InnerHtml = "";
            if (null != Request.QueryString["p"])
            {
                string pwdday = Request.QueryString["p"] == "" ? "null" : Request.QueryString["p"].ToString();
                notifyPwd.InnerHtml = "<a href=\"SysUserInv/ChangePassword.aspx\" > Your Password will expire in " + pwdday + " Day(s)!</a>";
            }
            if (ReadSession().Department == "28")
            {
                GetNotifications2();
            }

            if (year.Text != null)
                y = year.Text;
            if (y == "")
            {
                y = System.DateTime.Now.Year.ToString();
            }

            year.Items.Clear();
            for (int i = 2009; i < 2025; i++)
            {
                ListItem li = new ListItem();
                li.Value = i.ToString();
                li.Text = i.ToString();

                if (i.ToString() == y)
                    li.Selected = true;

                year.Items.Add(li);

            }

            if (month.Text != null)
                m = month.Text;

            if (m == "")
            {
                m = System.DateTime.Now.Month.ToString();
            }

            month.Items.Clear();

            for (int i = 1; i < 13; i++)
            {
                DateTime monthname = DateTime.Parse("2010/" + i + "/3");
                string strMonth = monthname.ToString("MMMM");
                ListItem li = new ListItem();
                li.Value = i.ToString();
                li.Text = strMonth.ToString();

                if (i.ToString() == m)
                    li.Selected = true;

                month.Items.Add(li);
            }
            loadCalender();
        }

        private void LoadCircularData()
        {
            StringBuilder sb = new StringBuilder("<i class=\"fa fa-flag pull-left\" aria-hidden=\"true\"></i>");
            sb.AppendLine("<h3>Circular And Documents</h3>");
            var dt = _clsdao.getTable("EXEC Proc_Circulars @flag = 'a'");

            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                sb.AppendLine("<div class=\"media\">");
                sb.AppendLine("<div class=\"media-body\">");
                sb.AppendLine("<p>No circulars to display.</p></div></div>");
                circulars.InnerHtml = sb.ToString();
                return;
            }

            foreach (DataRow item in dt.Rows)
            {
                string id = item["id"].ToString();
                string header = item["func_head"].ToString();
                string body = item["func_detail"].ToString();
                string newBody = TrimWords(body);
                sb.AppendLine("<div class=\"media\">");
                sb.AppendLine("<div class=\"media-body\">");
                sb.AppendLine("<h5 class=\"media-heading\"><a href=\"#\" onclick=\"return popitup('CircularsPopup.aspx?id=" + id + "');\">");
                sb.AppendLine("" + header + "</a></h5>");
                sb.AppendLine("<p>" + newBody + "</p>");
                sb.AppendLine("</div></div>");
            }

            sb.AppendLine("<div class=\"media\">");
            sb.AppendLine("<div class=\"media-body\">");
            sb.AppendLine("<h5 class=\"media-heading\"><a href=\"#\" onclick=\"return popitup('OrganizationalChart/Manage.aspx');\">");
            sb.AppendLine("Organization Chart</a></h5>");
            sb.AppendLine("<p>Organization Chart</p>");
            sb.AppendLine("</div></div>");

            circulars.InnerHtml = sb.ToString();
        }

        private string TrimWords(string value)
        {
            int len = value.Length;

            string res = null;
            char[] array = value.ToCharArray();
            char[] finalArray = new char[150];

            if (len == 0)
            {
                return null;
            }
            else
            {
                if (len <= 150)
                {
                    for (int i = 0; i < len; i++)
                    {
                        // Get character from array.
                        char letter = array[i];
                        // Display each letter.
                        finalArray[i] = letter;
                    }
                }
                else
                {
                    for (int i = 0; i < 150; i++)
                    {
                        // Get character from array.
                        char letter = array[i];
                        // Display each letter.
                        finalArray[i] = letter;
                    }
                }

            }
            res = new string(finalArray);

            if (len > 150)
            {
                res = res + "...";
            }

            return res;
        }

        private void GetRequisitionCount()
        {
            string sql = @"select Count(*) from IN_Requisition_Message m inner join Departments d 
				 on m.dept_id = d.DEPARTMENT_ID inner join
                 Branches b on m.branch_id = b.BRANCH_ID inner join Employee e 
				 on e.EMPLOYEE_ID = m.Requ_by where status = 'Requested' and Requ_by='" + ReadSession().Emp_Id + "'";
            string result = _clsdao.GetSingleresult(sql);
            getReqCnt.Text = result.ToString();
        }

        private void GetAttendanceCount()
        {
            string sql = @"SELECT COUNT(*)
                        FROM atttendance A inner join Employee E on A.emp_id=E.EMPLOYEE_ID
                        inner join Fiscal_Month F on cast((A.att_date)as Date)>=f.engDateBaisakh	
                        left join attendance_reason c on c.att_id=a.id where logout_time is null and f.DefaultYr='1' and  emp_id =" + ReadSession().Emp_Id + "";
            string result = _clsdao.GetSingleresult(sql);
            attendanceCnt.Text = result.ToString();
        }

        private void GetLeaveCount()
        {
            string sql = "SELECT COUNT(*) AS [Count] FROM dbo.LeaveRequest WHERE LEAVE_STATUS = 'Pending' AND REQUESTED_BY = '" + ReadSession().Emp_Id.ToString() + "'";
            var dt = _clsdao.getTable(sql);
            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                return;
            }
            foreach (DataRow item in dt.Rows)
            {
                getLeave.Text = item["Count"].ToString();
            }
        }

        private void PopulateLeave()
        {
            string sql = @"SELECT E.EMPLOYEE_ID,LEAVE_STATUS, L.APPROVED_FROM , L.APPROVED_TO , dbo.GetEmployeeFullNameOfId(E.EMPLOYEE_ID) AS Name,L.APPROVED_DAYS AS Days FROM dbo.LeaveRequest L " +
                        "INNER JOIN dbo.Employee E ON E.EMPLOYEE_ID = L.REQUESTED_BY WHERE L.LEAVE_STATUS = 'Approved' AND " +
                        "GETDATE() BETWEEN CONVERT(DATETIME,L.APPROVED_FROM,107) AND CONVERT(DATETIME,APPROVED_TO,107) + '23:59:59' AND L.LEAVE_TYPE_ID IN (1,2,3,10,14)";
            var dt = _clsdao.getTable(sql);
            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                return;
            }

            StringBuilder sb = new StringBuilder("");
            foreach (DataRow item in dt.Rows)
            {
                string Name = item["Name"].ToString();
                String ELink = "<a href=\"/Company/EmployeeWeb/EmployeeAllInfo.aspx?Id=" + Uri.EscapeDataString(Crypto(item["EMPLOYEE_ID"].ToString())) + "\">" + Name + "</a>";
                sb.AppendLine("<div class=\"col-md-12\">");
                sb.AppendLine("<div class=\"form-group\">");

                sb.AppendLine("" + ELink + "");
                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
                //sb.AppendLine("<div class=\"col-md-4\">");
                //sb.AppendLine("<div class=\"form-group\">");
                //sb.AppendLine("</div>");
                //sb.AppendLine("</div>");


            }
            onLeave.InnerHtml = sb.ToString();
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
        private void PopulateAvailableLeave()
        {
            string empId = ReadSession().Emp_Id.ToString();
            string sql = "SELECT LA.ID, LA.NO_OF_DAYS_ACTUAL,ISNULL(LAST_YEAR_LEAVE,0) as LAST_YEAR_LEAVE, CONVERT(VARCHAR,FROMDATE,107) as FROM_DATE ";
            sql += ",CONVERT(VARCHAR,TODATE,107) as TO_DATE ,E.FIRST_NAME+' '+E.MIDDLE_NAME+' '+E.LAST_NAME as EMPLOYEE_ID, isnull(LA.LEAVE_TAKEN_THIS_YEAR,0) as LEAVE_TAKEN_THIS_YEAR ";
            sql += ",CASE WHEN isnull(La.IS_UNLIMITED,0)=1 THEN 0 ELSE isnull(LA.NO_OF_DAYS_ACTUAL,0)+ISNULL(LAST_YEAR_LEAVE,0)-isnull(LA.LEAVE_TAKEN_THIS_YEAR,0) END REMAIN_LEAVE ";
            sql += ",case when LA.IS_DISABLED='1' then 'Yes' when LA.IS_DISABLED='0' then 'No' end as IS_DISABLED, LT.NAME_OF_LEAVE as LEAVE_TYPE_ID, IS_LFA = CASE WHEN isnull(LFA_Taken,0)=0 THEN 'No' WHEN LFA_Taken = 1 THEN 'Yes' ELSE '-' END ";
            sql += "FROM leaveAssignment AS LA inner join Employee E on E.EMPLOYEE_ID=LA.EMPLOYEE_ID inner join LeaveTypes LT ON LT.ID=LA.LEAVE_TYPE_ID WHERE LA.EMPLOYEE_ID='" + empId + "' and LA.IS_DISABLED=1 AND ";
            sql += "LA.FromDate BETWEEN 'Apr 15, 2014' AND 'Apr 14, 2016'";
            DataTable dt = _clsdao.getTable(sql);
            if (dt.Rows == null || dt.Rows.Count == 0)
            {
                leaveAvailable.Text = "0";
                return;
            }

            int remainLeave = 0;
            foreach (DataRow item in dt.Rows)
            {
                remainLeave += Convert.ToInt16(item["REMAIN_LEAVE"]);
            }
            leaveAvailable.Text = remainLeave.ToString();
        }

        private String getnextmonth()
        {
            String month = "";
            return month;
        }
        private void PopulateBirthdayList()
        {


            DataTable dt = _clsdao.getTable("Exec procGetBirthdayList @flag='B'");

            int cols = dt.Columns.Count;
            if (dt.Rows.Count > 0)
            {
                StringBuilder str = new StringBuilder("<table align=\"center\">");
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        str.Append("<td ><b>" + dr[i].ToString() + "</b></td>");
                    }
                    str.Append("</tr>");
                }
                str.Append("</table>");
                BIRTH_LIST.InnerHtml = str.ToString();
            }

        }

        private void loadCalender()
        {

            string today_year = DateTime.Now.Year.ToString();
            string today_month = DateTime.Now.Month.ToString();
            string today_day = DateTime.Now.Day.ToString();
            bool monthMatch = (today_year == y && today_month == m);
            DataTable dt = _eventCal.GetEventCalander(y, m).Tables[0];
            StringBuilder sb = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered \"><tr>");
            sb.Append("<th colspan=\"2\" align=\"left\"><div align=\"left\"><strong><a href=\"JavaScript:moveMonth('p');\"><i class='fa fa-arrow-left'></i></a></strong></div></th>");
            sb.Append("<th colspan=\"3\" align=\"center\"><div align=\"center\"><strong> " + y + ", " + month.SelectedItem.Text + "</strong> </div></th>");
            sb.Append("<th colspan=\"2\" align=\"right\"><div align=\"right\"><strong><a href=\"JavaScript:moveMonth('n');\"><i class='fa fa-arrow-right'></i></a></strong></div></th>");
            sb.Append("</tr>");
            sb.Append("<tr style=\" background-color:#21AB47; color:#ffffff\">");
            sb.Append("<td><strong> SUNDAY </strong></td>");
            sb.Append("<td><strong> MONDAY  </strong> </td>");
            sb.Append("<td><strong> TUESDAY  </strong></td>");
            sb.Append("<td><strong> WEDNESDAY </strong></td>");
            sb.Append("<td><strong> THURSDAY </strong></td>");
            sb.Append("<td><strong> FRIDAY  </strong></td>");
            sb.Append("<td><strong> SATURDAY </strong> </td>");
            sb.Append("</tr>");

            int firstDay = Convert.ToInt16(dt.Rows[0][2]);
            int cnt = 0;

            sb.Append("<tr>");
            for (int i = 1; i < firstDay; i++)
            {
                sb.Append("<td>  </td>");
            }

            foreach (DataRow row in dt.Rows)
            {
                string css = "numbers";
                string css1 = "blank;";

                if (today_day == row[3].ToString() && today_month == month.Text && today_year == year.Text)
                {
                    css1 = "numbers_today";
                }

                if (row[9].ToString() != "E" && row[9].ToString() != "H" && row[9].ToString() != "E,H")
                {
                    sb.Append("<td  class=" + css1 + "><div class=" + css + ">" + row[3].ToString() + "</div>");
                    sb.Append("<div class='eventNotifier'><a href='#' onclick=\"return popitup('/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "')\"></a> </div>");
                }

                else
                {
                    if (row[9].ToString() == "E")
                    {
                        //<a href="#" onclick="return popitup('ViewUploads.aspx?projectid=<%=getId() %>')">View Images</a>
                        sb.Append("<td  class='events'><div class=" + css + ">" + row[3].ToString() + "</div>");
                        sb.Append("<div class='eventNotifier'><a href='#' style=\"color:teal;\" onclick=\"return popitup('/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "')\"> Event(s) </a> </div>");
                    }

                    else if (row[9].ToString() == "H")
                    {
                        string msg = _clsdao.GetSingleresult("EXEC [procManageHolidayCalender] @FLAG='e',@BRANCH_ID=" + filterstring(ReadSession().Branch_Id.ToString()) + ",@DATE=" + filterstring(row[0].ToString()) + "");
                        if (msg == "1")
                        {
                            sb.Append("<td  class='holidays'><div class=" + css + ">" + row[3].ToString() + "</div>");
                            sb.Append("<div class='eventNotifier'><a href='#' style=\"color:red;\" onclick=\"return popitup('/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "')\"> Holiday(s) </a> </div>");
                        }
                        else
                        {
                            sb.Append("<td  class='Otherholidays'><div class=" + css + ">" + row[3].ToString() + "</div>");
                            sb.Append("<div class='eventNotifier'><a rel='gb_page_center[650,500]' href='#' style=\"color:red;\" onclick=\"return popitup('/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "')\"> Holiday(s) </a> </div>");
                        }
                    }

                    else if (row[9].ToString() == "E,H")
                    {
                        sb.Append("<td  class='holidays'><div class=" + css + ">" + row[3].ToString() + "</div>");
                        sb.Append("<div class='eventNotifier'><a rel='gb_page_center[650,500]' href='#' onclick=\"return popitup('/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "')\"><span  style=\"color:red;\"> Holiday(s)</span> <br><span  style=\"color:teal;\">Event(s) </a></span></div>");
                    }
                }

                sb.Append("</td>");
                cnt++;

                if ((firstDay + cnt - 1) % 7 == 0)
                {
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                }
            }
            cal.InnerHtml = sb.ToString() + "</tr></table></div>";
        }
        private void showevent()
        {
            String eventdat = hddDate.Value;
            StringBuilder sb = new StringBuilder("<table border=\"0\" class=\"TBL\"");
            ReadSession().RptQuery = _eventCal.GetEvents(DateTime.Parse(eventdat));
            Response.Redirect("/EventCalander/Events.aspx?ondate='" + eventdat + "'");
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;

        }
        protected void btnEventShow_Click(object sender, EventArgs e)
        {
            showevent();
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            loadCalender();
        }


        #region "Notification2"
        private void GetNotifications2()
        {
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"left\">");
            DataTable dt = _clsdao.getTable("exec proc_ActiveNotifications 'h','" + ReadSession().UserId + "','" + ReadSession().Emp_Id + "'");
            int cols = dt.Columns.Count;

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");

            rptDivHr.InnerHtml = str.ToString();
        }
        #endregion


    }
}
