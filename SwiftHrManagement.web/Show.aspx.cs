using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web
{
    public partial class Show : BasePage
    {
        clsDAO _clsdao = null;
        public Show()
        {
            _clsdao = new clsDAO();
        }
        string y = "";
        string m = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            GetNotifications();
        }
        private String getnextmonth()
        {
            String month = "";
            return month;
        }
        private void loadCalender()
        {
            string today_year = DateTime.Now.Year.ToString();
            string today_month = DateTime.Now.Month.ToString();
            string today_day = DateTime.Now.Day.ToString();
            bool monthMatch = (today_year == y && today_month == m);
            DataTable dt = _clsdao.getTable("Exec [procDepartmentalEvents] " + filterstring(y) + "," + filterstring(m) + "");
            StringBuilder sb = new StringBuilder("<table border=0 class=\"TableCal\" cellpadding=\"0\" cellspacing=\"0\"><tr>");
            sb.Append("<th colspan=\"2\" align=\"left\"><strong><a href=\"JavaScript:moveMonth('p');\"><img src=\"Images/prev.gif\" border=0/></a></strong></th>");
            sb.Append("<th colspan=\"3\"><div  align=\"center\"><strong> " + y + ", " + month.SelectedItem.Text + "</strong></div></th>");
            sb.Append("<th colspan=\"2\"><div  align=\"right\"><strong><a href=\"JavaScript:moveMonth('n');\"><img src=\"Images/next.gif\" border=0/></a></strong></div></th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
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
                    sb.Append("<div class=eventNotifier><a rel='gb_page_center[650,500]' href='Events.aspx?ondate= " + row[0].ToString() + "'></a> </div>");
                }

                //else
                //{
                //    if (row[9].ToString() == "E")
                //    {
                //        sb.Append("<td  class=events><div class=" + css + ">" + row[3].ToString() + "</div>");
                //        sb.Append("<div class=eventNotifier><a href='/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "' rel=\"gb_page_center[500,300]\"> Event(s) </a> </div>");
                //    }

                //    else if (row[9].ToString() == "H")
                //    {
                //        sb.Append("<td  class=holidays><div class=" + css + ">" + row[3].ToString() + "</div>");
                //        sb.Append("<div class=eventNotifier><a rel='gb_page_center[650,500]' href='/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "'> Holiday(s) </a> </div>");
                //    }

                //    else if (row[9].ToString() == "E,H")
                //    {
                //        sb.Append("<td  class=holidays><div class=" + css + ">" + row[3].ToString() + "</div>");
                //        sb.Append("<div class=eventNotifier><a rel='gb_page_center[650,500]' href='/EventCalander/Events.aspx?ondate= " + row[0].ToString() + "'> Holiday(s) <br> Event(s) </a> </div>");
                //    }
                //}

                sb.Append("</td>");
                cnt++;

                if ((firstDay + cnt - 1) % 7 == 0)
                {
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                }
            }
            cal.InnerHtml = sb.ToString() + "</tr></table>";
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
        protected void btnGo_Click(object sender, EventArgs e)
        {
            loadCalender();
        }
        #region "Notification"
        private void GetNotifications()
        {
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"left\">");
            DataTable dt = _clsdao.getTable("exec proc_ActiveNotifications '" + ReadSession().UserId + "','" + ReadSession().Emp_Id + "'," + filterstring(ReadSession().Branch_Id.ToString()) + "");
            
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
                    if (i == 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        #endregion
    }
}
