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
    public partial class DepMonthlyRpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        public DepMonthlyRpt()
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
            getActiveAssetRpt();
            getINTransferedRpt();
            getInactiveAssetRpt();
            getOutTransferedAssetRpt();
            getSoldAssetRpt();
            getWriteoffAssetRpt();
        }
        private void getActiveAssetRpt()
        {
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            double tot_cost = 0.00,Totalacc_dep=0.00, shawan = 0.00, bhadra = 0.00, ashoj = 0.00, kartik = 0.00, mangshir = 0.00, poush = 0.00,
                magh = 0.00, falgun = 0.00, chaitra = 0.00, baishak = 0.00, jestha = 0.00, asad = 0.00, acc_dep = 0.00, closing_cost = 0.00;

            StringBuilder str = new StringBuilder("<div class=\"table-responsive branchlist\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt = _clsdao.getTable("Exec [procDepreciationMonthWiseRpt]  'a'," + filterstring(FY) + "," + filterstring(group) + "," + filterstring(branch) + "");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            rptDes.Text = "Month Wise Depreciation Report for the Fiscal Year: " + FY;
            BRANCH_NAME.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
            group_name.Text = _clsdao.GetSingleresult("SELECT item_name FROM ASSET_ITEM WHERE id="+group+"");
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
                        if (i>0 && i<=3)
                        {
                            str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {                            
                            str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str.Append("</tr>");                   
                    tot_cost = tot_cost + double.Parse(row[4].ToString());
                    Totalacc_dep = Totalacc_dep + double.Parse(row[5].ToString());
                    shawan = shawan + double.Parse(row[6].ToString());
                    bhadra = bhadra + double.Parse(row[7].ToString());
                    ashoj = ashoj + double.Parse(row[8].ToString());
                    kartik = kartik + double.Parse(row[9].ToString());
                    mangshir = mangshir + double.Parse(row[10].ToString());
                    poush = poush + double.Parse(row[11].ToString());
                    magh = magh + double.Parse(row[12].ToString());
                    falgun = falgun + double.Parse(row[13].ToString());
                    chaitra = chaitra + double.Parse(row[14].ToString());
                    baishak = baishak + double.Parse(row[15].ToString());
                    jestha = jestha + double.Parse(row[16].ToString());
                    asad = asad + double.Parse(row[17].ToString());
                    acc_dep = acc_dep + double.Parse(row[18].ToString());
                    closing_cost = closing_cost + double.Parse(row[19].ToString());
                }
                str.Append("<tr>");
                str.Append("<td align=\"center\" colspan=\"4\"><b>Total</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(tot_cost.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(Totalacc_dep.ToString()) + "</b></td>");
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
                str.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep.ToString()) + "</b></td>");
                str.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost.ToString()) + "</b></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            rpt.InnerHtml = str.ToString();
        }
        private void getINTransferedRpt()
        {
            //Asset IN Transfered-----
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            double tot_cost1 = 0.00, acc_dep1 = 0.00, shawan1 = 0.00, bhadra1 = 0.00, ashoj1 = 0.00, kartik1 = 0.00, mangshir1 = 0.00, poush1 = 0.00,
                magh1 = 0.00, falgun1 = 0.00, chaitra1 = 0.00, baishak1 = 0.00, jestha1 = 0.00, asad1 = 0.00, closing_cost1 = 0.00;

            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt1 = _clsdao.getTable("Exec [procDepreciationMonthWiseRpt]  'b'," + filterstring(FY) + "," + filterstring(group) + "," + filterstring(branch) + "");

            int cols1 = dt1.Columns.Count;
            {
                str1.Append("<tr>");
                for (int i = 0; i < cols1; i++)
                {
                    str1.Append("<th><div align=\"left\">" + dt1.Columns[i].ColumnName + "</div></th>");
                }
                str1.Append("</tr>");

                foreach (DataRow row in dt1.Rows)
                {
                    str1.Append("<tr>");
                    for (int i = 0; i < cols1; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            str1.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str1.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str1.Append("</tr>");
                    tot_cost1 = tot_cost1 + double.Parse(row[2].ToString());
                    acc_dep1 = acc_dep1 + double.Parse(row[3].ToString());
                    shawan1 = shawan1 + double.Parse(row[4].ToString());
                    bhadra1 = bhadra1 + double.Parse(row[5].ToString());
                    ashoj1 = ashoj1 + double.Parse(row[6].ToString());
                    kartik1 = kartik1 + double.Parse(row[7].ToString());
                    mangshir1 = mangshir1 + double.Parse(row[8].ToString());
                    poush1 = poush1 + double.Parse(row[9].ToString());
                    magh1 = magh1 + double.Parse(row[10].ToString());
                    falgun1 = falgun1 + double.Parse(row[11].ToString());
                    chaitra1 = chaitra1 + double.Parse(row[12].ToString());
                    baishak1 = baishak1 + double.Parse(row[13].ToString());
                    jestha1 = jestha1 + double.Parse(row[14].ToString());
                    asad1 = asad1 + double.Parse(row[15].ToString());
                    closing_cost1 = closing_cost1 + double.Parse(row[16].ToString());
                }
                str1.Append("<tr>");
                str1.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(tot_cost1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(shawan1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(bhadra1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(ashoj1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(kartik1.ToString()) + "</b></td>");

                str1.Append("<td align=\"right\"><b>" + ShowDecimal(mangshir1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(poush1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(magh1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(falgun1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(chaitra1.ToString()) + "</b></td>");

                str1.Append("<td align=\"right\"><b>" + ShowDecimal(baishak1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(jestha1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(asad1.ToString()) + "</b></td>");
                str1.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost1.ToString()) + "</b></td>");
                str1.Append("</tr>");
            }
            str1.Append("</table>");
            str1.Append("</div>");
            rptIN.InnerHtml = str1.ToString();
        }
        private void getInactiveAssetRpt()
        {
            //Asset Inactive Report----
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            double tot_cost2 = 0.00, acc_dep2 = 0.00, shawan2 = 0.00, bhadra2 = 0.00, ashoj2 = 0.00, kartik2 = 0.00, mangshir2 = 0.00, poush2 = 0.00,
                magh2 = 0.00, falgun2 = 0.00, chaitra2 = 0.00, baishak2 = 0.00, jestha2 = 0.00, asad2 = 0.00, closing_cost2 = 0.00;

            StringBuilder str2 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt2 = _clsdao.getTable("Exec [procDepreciationMonthWiseRpt]  'c'," + filterstring(FY) + "," + filterstring(group) + "," + filterstring(branch) + "");

            int cols2 = dt2.Columns.Count;
            {
                str2.Append("<tr>");
                for (int i = 0; i < cols2; i++)
                {
                    str2.Append("<th><div align=\"left\">" + dt2.Columns[i].ColumnName + "</div></th>");
                }
                str2.Append("</tr>");

                foreach (DataRow row in dt2.Rows)
                {
                    str2.Append("<tr>");
                    for (int i = 0; i < cols2; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            str2.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str2.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str2.Append("</tr>");
                    tot_cost2 = tot_cost2 + double.Parse(row[2].ToString());
                    acc_dep2 = acc_dep2 + double.Parse(row[3].ToString());
                    shawan2 = shawan2 + double.Parse(row[4].ToString());
                    bhadra2 = bhadra2 + double.Parse(row[5].ToString());
                    ashoj2 = ashoj2 + double.Parse(row[6].ToString());
                    kartik2 = kartik2 + double.Parse(row[7].ToString());
                    mangshir2 = mangshir2 + double.Parse(row[8].ToString());
                    poush2 = poush2 + double.Parse(row[9].ToString());
                    magh2 = magh2 + double.Parse(row[10].ToString());
                    falgun2 = falgun2 + double.Parse(row[11].ToString());
                    chaitra2 = chaitra2 + double.Parse(row[12].ToString());
                    baishak2 = baishak2 + double.Parse(row[13].ToString());
                    jestha2 = jestha2 + double.Parse(row[14].ToString());
                    asad2 = asad2 + double.Parse(row[15].ToString());
                    closing_cost2 = closing_cost2 + double.Parse(row[16].ToString());
                }
                str2.Append("<tr>");
                str2.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(tot_cost2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(shawan2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(bhadra2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(ashoj2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(kartik2.ToString()) + "</b></td>");

                str2.Append("<td align=\"right\"><b>" + ShowDecimal(mangshir2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(poush2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(magh2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(falgun2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(chaitra2.ToString()) + "</b></td>");

                str2.Append("<td align=\"right\"><b>" + ShowDecimal(baishak2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(jestha2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(asad2.ToString()) + "</b></td>");
                str2.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost2.ToString()) + "</b></td>");
                str2.Append("</tr>");
            }
            str2.Append("</table>");
            str2.Append("</div>");
            rptInactive.InnerHtml = str2.ToString();
        }
        private void getOutTransferedAssetRpt()
        {
            //Asset OUT Transfer Report----
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            double tot_cost3 = 0.00, acc_dep3 = 0.00, shawan3 = 0.00, bhadra3 = 0.00, ashoj3 = 0.00, kartik3 = 0.00, mangshir3 = 0.00, poush3 = 0.00,
                magh3 = 0.00, falgun3 = 0.00, chaitra3 = 0.00, baishak3 = 0.00, jestha3 = 0.00, asad3 = 0.00, closing_cost3 = 0.00;

            StringBuilder str3 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt3 = _clsdao.getTable("Exec [procDepreciationMonthWiseRpt]  'd'," + filterstring(FY) + "," + filterstring(group) + "," + filterstring(branch) + "");

            int cols3 = dt3.Columns.Count;
            {
                str3.Append("<tr>");
                for (int i = 0; i < cols3; i++)
                {
                    str3.Append("<th><div align=\"left\">" + dt3.Columns[i].ColumnName + "</div></th>");
                }
                str3.Append("</tr>");

                foreach (DataRow row in dt3.Rows)
                {
                    str3.Append("<tr>");
                    for (int i = 0; i < cols3; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            str3.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str3.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str3.Append("</tr>");
                    tot_cost3 = tot_cost3 + double.Parse(row[2].ToString());
                    acc_dep3 = acc_dep3 + double.Parse(row[3].ToString());
                    shawan3 = shawan3 + double.Parse(row[4].ToString());
                    bhadra3 = bhadra3 + double.Parse(row[5].ToString());
                    ashoj3 = ashoj3 + double.Parse(row[6].ToString());
                    kartik3 = kartik3 + double.Parse(row[7].ToString());
                    mangshir3 = mangshir3 + double.Parse(row[8].ToString());
                    poush3 = poush3 + double.Parse(row[9].ToString());
                    magh3 = magh3 + double.Parse(row[10].ToString());
                    falgun3 = falgun3 + double.Parse(row[11].ToString());
                    chaitra3 = chaitra3 + double.Parse(row[12].ToString());
                    baishak3 = baishak3 + double.Parse(row[13].ToString());
                    jestha3 = jestha3 + double.Parse(row[14].ToString());
                    asad3 = asad3 + double.Parse(row[15].ToString());
                    closing_cost3 = closing_cost3 + double.Parse(row[16].ToString());
                }
                str3.Append("<tr>");
                str3.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(tot_cost3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(shawan3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(bhadra3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(ashoj3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(kartik3.ToString()) + "</b></td>");

                str3.Append("<td align=\"right\"><b>" + ShowDecimal(mangshir3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(poush3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(magh3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(falgun3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(chaitra3.ToString()) + "</b></td>");

                str3.Append("<td align=\"right\"><b>" + ShowDecimal(baishak3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(jestha3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(asad3.ToString()) + "</b></td>");
                str3.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost3.ToString()) + "</b></td>");
                str3.Append("</tr>");
            }
            str3.Append("</table>");
            str3.Append("</div>");
            rptOUT.InnerHtml = str3.ToString();
        }
        private void getSoldAssetRpt()
        {
            //Asset SOLD Report----
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            double tot_cost4 = 0.00, acc_dep4 = 0.00, shawan4 = 0.00, bhadra4 = 0.00, ashoj4 = 0.00, kartik4 = 0.00, mangshir4 = 0.00, poush4 = 0.00,
                magh4 = 0.00, falgun4 = 0.00, chaitra4 = 0.00, baishak4 = 0.00, jestha4 = 0.00, asad4 = 0.00, closing_cost4 = 0.00;

            StringBuilder str4 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt4 = _clsdao.getTable("Exec [procDepreciationMonthWiseRpt]  'e'," + filterstring(FY) + "," + filterstring(group) + "," + filterstring(branch) + "");

            int cols4 = dt4.Columns.Count;
            {
                str4.Append("<tr>");
                for (int i = 0; i < cols4; i++)
                {
                    str4.Append("<th><div align=\"left\">" + dt4.Columns[i].ColumnName + "</div></th>");
                }
                str4.Append("</tr>");

                foreach (DataRow row in dt4.Rows)
                {
                    str4.Append("<tr>");
                    for (int i = 0; i < cols4; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            str4.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str4.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str4.Append("</tr>");
                    tot_cost4 = tot_cost4 + double.Parse(row[2].ToString());
                    acc_dep4 = acc_dep4 + double.Parse(row[3].ToString());
                    shawan4 = shawan4 + double.Parse(row[4].ToString());
                    bhadra4 = bhadra4 + double.Parse(row[5].ToString());
                    ashoj4 = ashoj4 + double.Parse(row[6].ToString());
                    kartik4 = kartik4 + double.Parse(row[7].ToString());
                    mangshir4 = mangshir4 + double.Parse(row[8].ToString());
                    poush4 = poush4 + double.Parse(row[9].ToString());
                    magh4 = magh4 + double.Parse(row[10].ToString());
                    falgun4 = falgun4 + double.Parse(row[11].ToString());
                    chaitra4 = chaitra4 + double.Parse(row[12].ToString());
                    baishak4 = baishak4 + double.Parse(row[13].ToString());
                    jestha4 = jestha4 + double.Parse(row[14].ToString());
                    asad4 = asad4 + double.Parse(row[15].ToString());
                    closing_cost4 = closing_cost4 + double.Parse(row[16].ToString());
                }
                str4.Append("<tr>");
                str4.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(tot_cost4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(shawan4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(bhadra4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(ashoj4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(kartik4.ToString()) + "</b></td>");

                str4.Append("<td align=\"right\"><b>" + ShowDecimal(mangshir4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(poush4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(magh4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(falgun4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(chaitra4.ToString()) + "</b></td>");

                str4.Append("<td align=\"right\"><b>" + ShowDecimal(baishak4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(jestha4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(asad4.ToString()) + "</b></td>");
                str4.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost4.ToString()) + "</b></td>");
                str4.Append("</tr>");
            }
            str4.Append("</table>");
            str4.Append("</div>");
            rptSOLD.InnerHtml = str4.ToString();
        }
        private void getWriteoffAssetRpt()
        {
            //Asset WRITEOFF Report----
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string group = Request.QueryString["group"] == "" ? "null" : Request.QueryString["group"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();

            double tot_cost5 = 0.00, acc_dep5 = 0.00, shawan5 = 0.00, bhadra5 = 0.00, ashoj5 = 0.00, kartik5 = 0.00, mangshir5 = 0.00, poush5 = 0.00,
                magh5 = 0.00, falgun5 = 0.00, chaitra5 = 0.00, baishak5 = 0.00, jestha5 = 0.00, asad5 = 0.00, closing_cost5 = 0.00;

            StringBuilder str5 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped\"> "
);
            DataTable dt5 = _clsdao.getTable("Exec [procDepreciationMonthWiseRpt]  'f'," + filterstring(FY) + "," + filterstring(group) + "," + filterstring(branch) + "");

            int cols5 = dt5.Columns.Count;
            {
                str5.Append("<tr>");
                for (int i = 0; i < cols5; i++)
                {
                    str5.Append("<th><div align=\"left\">" + dt5.Columns[i].ColumnName + "</div></th>");
                }
                str5.Append("</tr>");

                foreach (DataRow row in dt5.Rows)
                {
                    str5.Append("<tr>");
                    for (int i = 0; i < cols5; i++)
                    {
                        if (i == 0 || i == 1)
                        {
                            str5.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str5.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                        }
                    }
                    str5.Append("</tr>");
                    tot_cost5 = tot_cost5 + double.Parse(row[2].ToString());
                    acc_dep5 = acc_dep5 + double.Parse(row[3].ToString());
                    shawan5 = shawan5 + double.Parse(row[4].ToString());
                    bhadra5 = bhadra5 + double.Parse(row[5].ToString());
                    ashoj5 = ashoj5 + double.Parse(row[6].ToString());
                    kartik5 = kartik5 + double.Parse(row[7].ToString());
                    mangshir5 = mangshir5 + double.Parse(row[8].ToString());
                    poush5 = poush5 + double.Parse(row[9].ToString());
                    magh5 = magh5 + double.Parse(row[10].ToString());
                    falgun5 = falgun5 + double.Parse(row[11].ToString());
                    chaitra5 = chaitra5 + double.Parse(row[12].ToString());
                    baishak5 = baishak5 + double.Parse(row[13].ToString());
                    jestha5 = jestha5 + double.Parse(row[14].ToString());
                    asad5 = asad5 + double.Parse(row[15].ToString());
                    closing_cost5 = closing_cost5 + double.Parse(row[16].ToString());
                }
                str5.Append("<tr>");
                str5.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(tot_cost5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(shawan5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(bhadra5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(ashoj5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(kartik5.ToString()) + "</b></td>");

                str5.Append("<td align=\"right\"><b>" + ShowDecimal(mangshir5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(poush5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(magh5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(falgun5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(chaitra5.ToString()) + "</b></td>");

                str5.Append("<td align=\"right\"><b>" + ShowDecimal(baishak5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(jestha5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(asad5.ToString()) + "</b></td>");
                str5.Append("<td align=\"right\"><b>" + ShowDecimal(closing_cost5.ToString()) + "</b></td>");
                str5.Append("</tr>");
            }
            str5.Append("</table>");
            str5.Append("</div>");
            rptWriteOff.InnerHtml = str5.ToString();
        }        
    }
}