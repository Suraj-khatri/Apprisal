using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class employeeHistory : BasePage
    {
        clsDAO _clsdao = null;
        protected long empId;

        public employeeHistory()
        {
         _clsdao = new clsDAO();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetEmpId() > 0)
                    empId = GetEmpId();
                else
                    empId = ReadSession().Emp_Id;
                
                populatedata(empId);
                getEducation(empId);
                getMedical(empId);
                getInsurance(empId);
                getPayble(empId);
                getLoan(empId);
                getContribution(empId);
                getLeaveDetail(empId);
                getAppraisal(empId);
                getAdvance(empId);
                getDonation(empId);
            }
        }
        private long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        } 
        public DataSet populatedata(long emp_id)
        {    
            String sSql = ("exec procGetEmployeePersonalHistoryDetails 'p'," + filterstring(emp_id.ToString()) + "");
            return _clsdao.getDataset(sSql);
        }
        private void getEducation(long emp_id)
        {
            DataTable dt = new DataTable();

            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'e'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\""+cols+"\"><b><u>Education Details</u></b></td>");    
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {               
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");               
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
                              
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\""+cols+"\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>"); 
            rptDiv1.InnerHtml = str.ToString();
        }
        private void getMedical(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'm'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Medical Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv2.InnerHtml = str.ToString();
        }
        private void getInsurance(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'i'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");


            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Insurance Details<b><u></td>");
            str.Append("</tr>");
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv3.InnerHtml = str.ToString();
        }
        private void getPayble(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'pay'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Payable (Benefits) Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv4.InnerHtml = str.ToString();
        }
        private void getLoan(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'l'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Loan Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv5.InnerHtml = str.ToString();
        }
        private void getContribution(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'c'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Contribution Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv6.InnerHtml = str.ToString();
        }
        private void getLeaveDetail(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'lev'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Leave Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv7.InnerHtml = str.ToString();
        }
        private void getAppraisal(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'app'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Appraisal Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv8.InnerHtml = str.ToString();
        }
        private void getAdvance(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'ad'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Advance Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv9.InnerHtml = str.ToString();
        }
        private void getDonation(long emp_id)
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("exec procGetEmployeePersonalHistoryDetails 'don'," + filterstring(emp_id.ToString()) + "").Tables[0];

            int cols = dt.Columns.Count;
            if (dt.Rows.Count == 0)
            {
                return;
            }
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"EMP_RECORD\" cellpadding=\"5\" cellspacing=\"5\"");
            str.Append("<tr>");
            str.Append("<td align=\"left\" colspan=\"" + cols + "\"><b><u>Donation Details</b></u></td>");
            str.Append("</tr>");
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<td align=\"left\" class=\"\"><b>" + dt.Columns[i].ColumnName + "</b></td>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i < 5)
                        {
                            str.Append("<td><div align=\"left\">" + dr[i].ToString() + "</div></td>");
                        }
                        else if (i == 5)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan=\"" + cols + "\"><div align=\"center\">No Records</div></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv10.InnerHtml = str.ToString();
        }
    }
}
