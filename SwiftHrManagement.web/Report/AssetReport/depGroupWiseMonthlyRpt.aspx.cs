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
    public partial class depGroupWiseMonthlyRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";
        public depGroupWiseMonthlyRpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetReport();
            }
        }
        private void GetReport()
        {
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();
            double acc_dep = 0.00, shawan = 0.00, bhadra = 0.00, ashoj = 0.00, kartik = 0.00, mangshir = 0.00, poush = 0.00,
                magh = 0.00, falgun = 0.00, chaitra = 0.00, baishak = 0.00, jestha = 0.00, asad = 0.00, closing_cost = 0.00;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive branchlist\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt = _clsdao.getTable("Exec [procDepreciationGroupWiseSummaryRpt]  'a'," + filterstring(FY) + "," + filterstring(branch) + "");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            rptDes.Text = "Group Wise Depreciation Report for the Fiscal Year: " + FY;
            BRANCH_NAME.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            int cols = dt.Columns.Count;
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
                        if (i == 0 || i==1)
                        {
                            str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {                            
                            str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str.Append("</tr>");
                    //tot_cost = tot_cost + double.Parse(row[2].ToString());
                    acc_dep = acc_dep + double.Parse(row[2].ToString());
                    shawan = shawan + double.Parse(row[3].ToString());
                    bhadra = bhadra + double.Parse(row[4].ToString());
                    ashoj = ashoj + double.Parse(row[5].ToString());
                    kartik = kartik + double.Parse(row[6].ToString());
                    mangshir = mangshir + double.Parse(row[7].ToString());
                    poush = poush + double.Parse(row[8].ToString());
                    magh = magh + double.Parse(row[9].ToString());
                    falgun = falgun + double.Parse(row[10].ToString());
                    chaitra = chaitra + double.Parse(row[11].ToString());
                    baishak = baishak + double.Parse(row[12].ToString());
                    jestha = jestha + double.Parse(row[13].ToString());
                    asad = asad + double.Parse(row[14].ToString());
                    closing_cost = closing_cost + double.Parse(row[15].ToString());
                }
                str.Append("<tr>");
                str.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(shawan.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(bhadra.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(ashoj.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(kartik.ToString()) + "</b></td>");

                str.Append("<td align=\"right\"><b>" + ShowDecimal(mangshir.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(poush.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(magh.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(falgun.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(chaitra.ToString()) + "</b></td>");

                str.Append("<td align=\"right\"><b>" + ShowDecimal(baishak.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(jestha.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(asad.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost.ToString()) + "</b></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }
    }
}