using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.DAL.BranchDao;
using SwiftHrManagement.DAL.DepartmentDAO;

namespace SwiftHrManagement.web.Report
{
    public partial class CompanySummaryReport : System.Web.UI.Page
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;

        BranchCore _branchCore = null;
        BranchDao _branch = null;

        DepartmentDAO _department = null;
        DepartmentCore _deptCore = null;

        string currPage = "";
        String Flag = "";
        String Branch_Id = "";
        String Dept_Id = "";
        String Emp_Id = null;
        DynamicRpt _rpt = null;
        public CompanySummaryReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();

            this._branch = new BranchDao();
            this._branchCore = new BranchCore();
            this._rpt = new DynamicRpt();

            this._department = new DepartmentDAO();
            this._deptCore = new DepartmentCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            currPage = getCurrPage();

            String id = "";
            String id2 = "";
            if (!Page.IsPostBack)
            {
                if (Flag == "")
                {
                    Flag = "a";
                }
            }
            if (Request.QueryString["branch"] != null)
                {
                    if (Flag == "a")
                    {
                        Flag = "b";
                    }
                    else if(Flag=="b")
                    {
                        id = Request.QueryString["branch"].ToString();
                        id.Trim();
                        _branchCore = _branch.FindBranchByName(id.Trim());
                        Branch_Id = _branchCore.Id.ToString();
                    }
                }

            if (Request.QueryString["dept"] != null)
            {
                if (Flag == "a")
                {
                    Flag = "d";
                }
                else if(Flag=="b")
                {
                    id = Request.QueryString["dept"].ToString();
                    id.Trim();
                    _deptCore = _department.FindDeptIdByName(id.Trim());
                    Dept_Id = _deptCore.Id.ToString();
                    Flag = "d";    
                }
            }
            if (Request.QueryString["id2"] != null)
            {
                id2 = Request.QueryString["id2"].ToString();
            }
            if (Request.QueryString["empid"] != null)
            {
                id = Request.QueryString["empid"].ToString();
                Flag = "e";
            }

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;

            if (Flag == "")
                return;

            DataTable dt1 = _rpt.FindsummaryReport(Flag, Branch_Id, Dept_Id, Emp_Id).Tables[0];
            int cols = dt1.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt1.Columns[i].ColumnName + "</th>");
            }
            foreach (DataRow dr in dt1.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (Flag == "a")
                    {
                        if (i == 0)
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                        if (i > 0)
                        {
                            if (i == 1)
                            {
                                str.Append("<td align=\"left\"><a href=\"DynamicBranchRpt.aspx?branch= " + dr[1] + "\"" + ">" + dr[i].ToString() + "</a></td>");                           
                            }
                            else if (i == 2)
                            {
                                str.Append("<td align=\"left\"><a href=\"DynamicDeptRpt.aspx?empId= " + dr[3] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                            }
                            else if (i == 3)
                            {
                                str.Append("<td align=\"left\"><a href=\"DynamicEmpRpt.aspx?empId= " + dr[3] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                            }
                        }
                    }
                    if (Flag == "b")
                    {
                        str.Append("<td align=\"left\"><a href=\"" + currPage + "?branch= " + dr[1] + "& id2=" + dr[2] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                    }
                    else if (Flag == "d")
                    {
                        str.Append("<td align=\"left\"><a href=\"" + currPage + "?department= " + dr[1] + "& id2=" + dr[2] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                    }
                    else if (Flag == "e")
                    {
                        str.Append("<td align=\"left\"><a href=\"" + currPage + "?empid= " + dr[1] + "& id2=" + dr[2] + "\"" + ">" + dr[i].ToString() + "</a></td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
    }
}
