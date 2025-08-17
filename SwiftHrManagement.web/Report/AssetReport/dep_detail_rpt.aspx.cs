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
    public partial class dep_detail_rpt : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsdao = null;
        string sql = "";

        public dep_detail_rpt()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            _clsdao = new ClsDAOInv();
        }       
        protected void Page_Load(object sender, EventArgs e)
        {
            string group_id = Request.QueryString["group_id"] == "" ? "null" : Request.QueryString["group_id"].ToString();
            string FY = Request.QueryString["fy"] == "" ? "null" : Request.QueryString["fy"].ToString();
            string month = Request.QueryString["month"] == "" ? "null" : Request.QueryString["month"].ToString();
            string branch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();
            double dep_value = 0.00, acc_dep = 0.00, purchase_value = 0.00;
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt = _clsdao.getTable("Exec procDepGroupWiseDetailRpt 'a'," + filterstring(FY) + "," + filterstring(month) + ","+filterstring(branch)+","+filterstring(group_id)+"");

            _CompanyCore = _company.FindCompany();
            divCompany.InnerText = _CompanyCore.Name;
            rptDes.Text = "Monthly Report for the Fiscal Year: " + FY + ", Month: " + _clsdao.GetSingleresult("select Name from MonthList where Month_Number="+month+"");
            BRANCH_NAME.Text = _clsdao.GetSingleresult("SELECT DBO.GetBranchName(" + branch + ")");
            group_name.Text = _clsdao.GetSingleresult("SELECT item_name FROM ASSET_ITEM WHERE id=" + group_id + "");
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
                    if(i==2 ||i==3||i==4)
                    {
                        str.Append("<td align=\"right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td>" + row[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
                dep_value = dep_value + double.Parse(row[2].ToString());
                acc_dep = acc_dep + double.Parse(row[3].ToString());
                purchase_value = purchase_value + double.Parse(row[4].ToString());

            }
            str.Append("<tr>");
            str.Append("<td align=\"center\" colspan=\"2\"><b>Total</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(dep_value.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(acc_dep.ToString()) + "</b></td>");
            str.Append("<td align=\"right\"><b>" + ShowDecimal(purchase_value.ToString()) + "</b></td>");
       
            str.Append("</tr>");
        
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

        }
    }
}
