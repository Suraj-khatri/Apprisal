using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Text;

namespace SwiftHrManagement.web.Report.AssetReport
{
    public partial class depGroupWiseRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public depGroupWiseRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }       
        protected void Page_Load(object sender, EventArgs e)
        {
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string month = Request.QueryString["month"] == "" ? "null" : Request.QueryString["month"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();
            double dep_value = 0.00;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> ");
            DataTable dt = _clsdao.getTable("Exec procDepreciationRpt  'a'," + filterstring(FY) + "," + filterstring(month) + ","+filterstring(branch)+"");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            rptDes.Text = "Monthly Report for the Fiscal Year: " + FY + ", Month: " + _clsdao.GetSingleresult("select Name from MonthList where Month_Number="+month+"");
            BRANCH_NAME.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            int cols = dt.Columns.Count;
            if (cols == 1)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                }
                str.Append("</tr>");

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i > 0)
                        {
                            str.Append("<td align=\"left\" width=\"300px\"><font color=\"red\">" + row[i].ToString() + "</font></td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0)
                    {
                        str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                    }
                }
                str.Append("</tr>");

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 2)
                        {
                            str.Append("<td align=\"right\"><a href=\"dep_detail_rpt.aspx?group_id="+row["id"]+"&fy="+FY+"&month="+month+"&branch="+branch+"\">" + ShowDecimal(row[i].ToString()) + "</a></td>");
                        }
                        else if(i==1)
                        {
                            str.Append("<td align=\"left\" width=\"300px\">" + row[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                    dep_value = dep_value + double.Parse(row[2].ToString());
                }
                str.Append("<tr>");
                str.Append("<td align=\"center\"><b>Total</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(dep_value.ToString()) + "</b></td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rpt.InnerHtml = str.ToString();

        }
    }
}
