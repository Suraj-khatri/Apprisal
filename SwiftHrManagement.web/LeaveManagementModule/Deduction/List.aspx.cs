using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.LeaveManagementModule.Deduction
{
    public partial class List : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;
        public List()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }
        private string getFronDate()
        {
            return Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
        }
        private string getToDate()
        {
            return Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            rptHeader();
            rptUnpaidLeave();
            rptAbsent();
            
        }
        private void rptHeader()
        {
            this._CompanyCore = _company.FindCompany();
            this.Lblcompany.Text = _CompanyCore.Name;
            this.LblDesc.Text = _CompanyCore.Address;
            lblFromDate.Text = getFronDate();
            lblToDate.Text = getToDate();
        }
        private void rptUnpaidLeave()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            DataTable dt = _clsDao.getDataset("EXEC [ProcUppaidLeaveReport] @FLAG='L',@FROM_DATE="+filterstring(getFronDate())+","
                                +" @TO_DATE="+filterstring(getToDate())+"").Tables[0];

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 1; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("<th align=\"left\"></th>");
            str.Append("<th align=\"left\"></th>");
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 1; i < cols; i++)
                    {
                        if (i == 6)
                        {
                            str.Append("<td align=\"right\" nowrap='nowrap'>"
                                + " <input type=\"text\" size=\"15\" name=\"amt_" + dr["id"] + "\" id=\"amt_" + dr["id"] + "\" value = \"" + ShowDecimal(dr[i].ToString()) + "\">");
                            str.Append("</td>");
                        }
                        else if (i == 2)
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                        else if (i == 7 || i==8 || i==9)
                        {
                            str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    if (dr["Status"].ToString() == "Not Approve")
                    {
                        str.Append("<td><a><span onclick = \"IsUnpaidApprove('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\">Approve</span></a></td>");
                        str.Append("<td><a><span onclick = \"OnReject('" + dr["id"].ToString() + "')\" style=\"cursor:pointer;\">Reject</span></a></td>");
                    }
                    else
                    {
                        str.Append("<td>N/A</td>");
                        str.Append("<td>N/A</td>");
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan='" + cols + 2 + "' align=\"center\">No Record Found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDivLeave.InnerHtml = str.ToString();
        }
        private void rptAbsent()
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");

            DataTable dt = _clsDao.getDataset("EXEC [ProcUppaidLeaveReport] @FLAG='A',@FROM_DATE=" + filterstring(getFronDate()) + ","
                                + " @TO_DATE=" + filterstring(getToDate()) + "").Tables[0];

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 4)
                        {
                            str.Append("<td align=\"right\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                        }
                        else if (i == 2)
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
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td colspan='" + cols + "' align=\"center\">No Record Found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDivAbsent.InnerHtml = str.ToString();
        }
        protected void btnLeaveApprove_Click(object sender, EventArgs e)
        {
            try
            {
                ApproveUnpaidLeave();
            }
            catch (Exception sqlException)
            {
                throw sqlException;
            }
        }
        private void ApproveUnpaidLeave()
        {
            string msg = _clsDao.GetSingleresult("Exec [ProcUppaidLeaveReport] @FLAG='APP',@ID=" + filterstring(hdnLeaveId.Value) + ","
                        + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@AMOUNT="+filterstring(hdnAmt.Value)+"");

            Response.Redirect("List.aspx?from_date=" + getFronDate() + "&to_date=" + getToDate() + "");
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                OnReject();
            }
            catch (Exception sqlException)
            {
                throw sqlException;
            }
        }
        private void OnReject()
        {
            string msg = _clsDao.GetSingleresult("Exec [ProcUppaidLeaveReport] @FLAG='REJ',@ID=" + filterstring(hdnLeaveId.Value) + ","
                        + " @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            Response.Redirect("List.aspx?from_date=" + getFronDate() + "&to_date=" + getToDate() + "");
        }
    }
}
