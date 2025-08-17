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
    public partial class AssetSummaryBranchWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public AssetSummaryBranchWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string branch = Request.QueryString["branch"].ToString() == "" ? "null" : Request.QueryString["branch"].ToString();

            double p_value = 0.00, acc_dep = 0.00, booked_value = 0.00;
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt = _clsdao.getTable("Exec [procDepreciationGroupWiseSummaryRpt]  @flag='s',@branch_id=" + filterstring(branch) + "");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            branchName.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            int cols = dt.Columns.Count;
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
                    if (i == 2 || i == 3 || i == 4)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                p_value = p_value + double.Parse(row[2].ToString());
                acc_dep = acc_dep + double.Parse(row[3].ToString());
                booked_value = booked_value + double.Parse(row[4].ToString());
            }
            str.Append("<tr>");
            str.Append("<td colspan=\"2\" align=\"center\"><b>Total</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(p_value.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(booked_value.ToString()) + "</b></td>");
            str.Append("</tr>");
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();

        }
    }
}
