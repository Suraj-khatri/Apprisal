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
    public partial class AssetSummaryReport : BasePage
    {
            CompanyDAO _company = null;
            CompanyCore _CompanyCore = null;
            ClsDAOInv _clsdao = null;
            string sql = "";

            public AssetSummaryReport()
            {
                this._company = new CompanyDAO();
                this._CompanyCore = new CompanyCore();
                _clsdao = new ClsDAOInv();
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                getReport();
            }
            private string GetBranchId()
            {
                return (Request.QueryString["branch"] != null ? (Request.QueryString["branch"]) : "");
            }
            private string GetDeptId()
            {
                return (Request.QueryString["dept"] != null ? (Request.QueryString["dept"]) : "");
            }
            private string GetGroupId()
            {
                return (Request.QueryString["group"] != null ? (Request.QueryString["group"]) : "");
            }
            private string GetAssetId()
            {
                return (Request.QueryString["type"] != null ? (Request.QueryString["type"]) : "");
            }
            private string GetAssetNumber()
            {
                return (Request.QueryString["number"] != null ? (Request.QueryString["number"]) : "");
            }

            private void getReport()
            {
                double p_value = 0.00, acc_dep = 0.00, booked_value = 0.00;
                StringBuilder str = new StringBuilder("<table width=\"90%\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
                DataTable dt = _clsdao.getTable("Exec procAssetReport 'a', " + filterstring(GetBranchId().ToString()) + "," + filterstring(GetDeptId().ToString()) + "," + filterstring(GetGroupId()) + "," + filterstring(GetAssetId()) + "," + filterstring(GetAssetNumber()) + "");

                _CompanyCore = _company.FindCompany();
                this.divCompany.InnerText = _CompanyCore.Name;
                getBranchName();
                lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");  
                int cols = dt.Columns.Count;
                str.Append("<tr>");

                for (int i = 0; i < cols; i++)
                {
                    if (i == 2 || i == 7 || i == 8 || i==10 || i==12)
                    {
                        str.Append("<th><div align=\"center\">" + dt.Columns[i].ColumnName + "</div></th>");
                    }
                    else if (i == 3 || i==4)
                    {
                        str.Append("<th><div align=\"right\">" + dt.Columns[i].ColumnName + "</div></th>");
                    }
                    else
                    {
                        str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
                    }
                }
                str.Append("</tr>");

                foreach (DataRow row in dt.Rows)
                {
                    str.Append("<tr>");
                    p_value = p_value + Double.Parse(row[4].ToString());
                    acc_dep = acc_dep + Double.Parse(row[5].ToString());
                    booked_value = booked_value + Double.Parse(row[6].ToString());
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 4 || i == 5 || i == 6)
                        {
                            str.Append("<td align=\"right\">" + row[i].ToString() + "</td>");
                        }
                        else if (i == 2 || i == 3)
                        {
                            str.Append("<td align=\"center\">" + row[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                        }

                    }
                    str.Append("</tr>");
                }
                str.Append("<tr>");
                str.Append("<td align=\"center\" colspan=\"2\"><b> TOTAL </b></td>");
                str.Append("<td align=\"right\">&nbsp;</td>");
                str.Append("<td align=\"right\">&nbsp;</td>");
                str.Append("<td align=\"right\"><b> " + ShowDecimal(p_value.ToString()) + " </b></td>");
                str.Append("<td align=\"right\"><b> " + ShowDecimal(acc_dep.ToString()) + "</b> </td>");
                str.Append("<td align=\"right\"><b> " + ShowDecimal(booked_value.ToString()) + "</b> </td>");
                str.Append("<td colspan=\"7\"><b>&nbsp;</b></td>");
                str.Append("</tr>");
                str.Append("</table>");
                rpt.InnerHtml = str.ToString();
            }
            private void getBranchName()
            {
                if (GetBranchId() != "")
                {
                    DataTable dt = new DataTable();
                    dt = _clsdao.getDataset("select BRANCH_NAME from Branches where BRANCH_ID='" + GetBranchId() + "'").Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        lblBranchName.Text = dr["BRANCH_NAME"].ToString();
                    }
                }
                else
                {
                    lblBranchName.Text = "All Branches";
                }
            }
        }
    }
