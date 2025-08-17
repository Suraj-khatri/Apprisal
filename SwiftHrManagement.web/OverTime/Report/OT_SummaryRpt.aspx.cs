using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.OverTime.Report
{
    public partial class OT_SummaryRpt : BasePage
    {
        clsDAO _clsDao = new clsDAO();
        CompanyDAO _company = new CompanyDAO();
        CompanyCore _CompanyCore = new CompanyCore();

        protected void Page_Load(object sender, EventArgs e)
        {
            OnReportHeading();
            OnShowRptAdjusted();
            OnShowRptPendingHR();
            OnShowRptPendingAdhoc();
        }

        private string getFromDate()
        {
            return Request.QueryString["from_date"] == null ? "" : Request.QueryString["from_date"].ToString();
        }

        private string gettodate()
        {
            return Request.QueryString["to_date"] == null ? "" : Request.QueryString["to_date"].ToString();
        }

        private void OnReportHeading()
        {
            lblFromDate.Text = getFromDate();
            lblToDate.Text = gettodate();
            _CompanyCore = _company.FindCompany();
            lblCompany.Text = _CompanyCore.Name;
            lblprintDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");  
        }

        private void OnShowRptAdjusted()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            lblCompany.Text = _CompanyCore.Name;

            DataTable dt = _clsDao.getDataset("Exec [procOtReport] @flag='a',@FROM_DATE=" + filterstring(getFromDate()) + ","
                                                +" @TO_DATE=" + filterstring(gettodate()) + "").Tables[0];
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            int rows = dt.Rows.Count;
            
            str.Append("</tr>");
            if (rows > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 3)
                        {
                            str.Append("<td align=\"CENTER\">" + dr[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"LEFT\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td align=\"CENTER\" colspan='" + cols + "'>No record is found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rpt1.InnerHtml = str.ToString();
        }
        private void OnShowRptPendingHR()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            lblCompany.Text = _CompanyCore.Name;

            DataTable dt = _clsDao.getDataset("Exec [procOtReport] @flag='b',@FROM_DATE=" + filterstring(getFromDate()) + ","
                                                + " @TO_DATE=" + filterstring(gettodate()) + "").Tables[0];
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            int rows = dt.Rows.Count;

            str.Append("</tr>");
            if (rows > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 3)
                        {
                            str.Append("<td align=\"CENTER\">" + dr[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"LEFT\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td align=\"CENTER\" colspan='" + cols + "'>No record is found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rpt2.InnerHtml = str.ToString();
        }
        private void OnShowRptPendingAdhoc()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            _CompanyCore = _company.FindCompany();
            lblCompany.Text = _CompanyCore.Name;

            DataTable dt = _clsDao.getDataset("Exec [procOtReport] @flag='c',@FROM_DATE=" + filterstring(getFromDate()) + ","
                                                + " @TO_DATE=" + filterstring(gettodate()) + "").Tables[0];
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            int rows = dt.Rows.Count;
            str.Append("</tr>");
            if (rows > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 3)
                        {
                            str.Append("<td align=\"CENTER\">" + dr[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td align=\"LEFT\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                str.Append("<tr>");
                str.Append("<td align=\"CENTER\" colspan='" + cols + "'>No record is found!</td>");
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rpt3.InnerHtml = str.ToString();
        }
    }
}
