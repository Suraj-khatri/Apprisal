using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveIndividualReport : BasePage
    {
        DynamicRpt _rpt = null;
        clsDAO _CLsDAo = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        LeaveSummaryReport _leaveSummary = null;

        
        private string GetEmpId()
        {
            return string.IsNullOrEmpty(Request.QueryString["empid"]) ? "" : Request.QueryString["empid"].ToString();
        }
        private string GetFlag()
        {
            return string.IsNullOrEmpty(Request.QueryString["flag"]) ? "" : Request.QueryString["flag"].ToString();
        }
        private string GetYear()
        {
            return string.IsNullOrEmpty(Request.QueryString["year"]) ? "" : Request.QueryString["year"].ToString();
        }

        public LeaveIndividualReport()
        {
            this._rpt = new DynamicRpt();
            this._CLsDAo = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._leaveSummary = new LeaveSummaryReport();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadHeading();
            loadReport();
        }

        private void loadHeading()
        {
            string subdesc=_CLsDAo.GetSingleresult("SELECT dbo.GetEmployeeFullNameOfId(EMPLOYEE_ID) EMPLOYEENAME FROM Employee WHERE EMPLOYEE_ID = "+filterstring(GetEmpId()));
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            
            if (GetFlag() == "h")
            {
                subdesc = "<br>Individual Leave History Report<br>Employee Name : " + subdesc + "<BR>";
                subdesc = subdesc + "Year : " + GetYear() + "<BR>";
            }
            else
                subdesc = "<br>Individual Leave Report<br>Employee Name : " + subdesc + "<BR>";
           
            this.lblSubDesc.Text = subdesc;
        }

        private void loadReport()
        {
            string sql;

            //this.ReadSession().RptQuery = _leaveSummary.FindLeaveIndividualReport("h", GetEmpId(), GetYear()).ToString();
            //sql = ReadSession().RptQuery;
            sql = "Exec Proc_LeaveIndividualReport @flag=" + filterstring(GetFlag())
                  + ",@bs_year=" + filterstring(GetYear())
                  + ",@emp_id=" + filterstring(GetEmpId());
            DataTable dt = _CLsDAo.getDataset(sql).Tables[0];

            StringBuilder str;
            int CurrentRow=0;
            int totalRows = dt.Rows.Count;
            string PreviousLeave = "0";
            string CurrentLeave;
            int sn=0;
            double totLeave= 0.0;
            double RemainLeave = 0.0;
            double LeaveThisYear = 0.0;
            str = new StringBuilder("<table width=\"60%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
            foreach (DataRow dr in dt.Rows)
            {
                CurrentLeave = dr[0].ToString();
                if(CurrentLeave != PreviousLeave)
                {
                    
                    if (PreviousLeave!="0")
                    {
                        str.Append("<tr>");
                        str.Append("<th align=\"right\" colspan=\"6\">LEAVE TAKEN THIS YEAR</th>");
                        str.Append("<th align=\"right\">" + totLeave + "</th>");
                        str.Append("</tr>");
                        str.Append("<tr>");
                        str.Append("<th align=\"right\" colspan=\"6\">LEAVE REMAIN</th>");
                        str.Append("<th align=\"right\">" + RemainLeave + "</th>");
                        str.Append("</tr>");
                        totLeave = 0.0;
                        str.Append("<tr>");
                        str.Append("<td colspan=\"7\">&nbsp;</td>");
                        str.Append("</tr>");
                    }
                    
                    sn = 0;
                    LeaveThisYear = double.Parse(dr["TOTAL LEAVE"].ToString());
                    str.Append("<tr>");
                    str.Append("<th align=\"center\" colspan=\"7\">" + dr[0] + "</th>");
                    str.Append("</tr>");

                    for (int i = 1; i <= 3; i++)
                    {
                        str.Append("<tr>");
                        str.Append("<th align=\"right\" colspan=\"6\">" + dt.Columns[i].ColumnName + "</th>");
                        str.Append("<th align=\"right\">" + dr[i] + "</th>");
                        str.Append("</tr>");
                    }    
                }
                else
                {
                    if (sn==0)
                    {
                        totLeave = 0.0;
                        str.Append("<tr>");
                        str.Append("<td align=\"center\">SN</td>");
                        for (int i = 4; i <= 9; i++)
                        {
                            str.Append("<td align=\"center\">" + dt.Columns[i].ColumnName + "</td>");

                        } 
                        str.Append("</tr>");
                    }
                    totLeave = totLeave + double.Parse(dr["LEAVE TAKEN"].ToString());
                    
                    sn++;
                    str.Append("<tr>");
                    str.Append("<td align=\"right\">" + sn.ToString() + "</td>");
                    for (int i = 4; i <= 9; i++)
                    {
                        str.Append("<td align=\"center\">" + dr[i] + "</td>");
                    } 
                    str.Append("</tr>");

 
                }
                RemainLeave = LeaveThisYear - totLeave;
                PreviousLeave = CurrentLeave;
                CurrentRow++;
            }
            str.Append("<tr>");
            str.Append("<th align=\"right\" colspan=\"6\">LEAVE TAKEN THIS YEAR</th>");
            str.Append("<th align=\"right\">" + totLeave + "</th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<th align=\"right\" colspan=\"6\">LEAVE REMAIN</th>");
            str.Append("<th align=\"right\">" + RemainLeave + "</th>");
            str.Append("</tr>");
            

            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
