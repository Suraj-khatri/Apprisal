using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.TransferRpt
{
    public partial class DateWise : BasePage
    {
            clsDAO _clsdao = null;
            CompanyDAO _company = null;
            CompanyCore _CompanyCore = null;
        public DateWise()
        {
            _clsdao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string startDate = Request.QueryString["startDate"] == "" ? "null" : Request.QueryString["startDate"].ToString();
            string endDate = Request.QueryString["endDate"] == "" ? "null" : Request.QueryString["endDate"].ToString();
            string ddlTransferType = Request.QueryString["transferType"] == "" ? "null" : Request.QueryString["transferType"].ToString();
            string ddlBranch = Request.QueryString["branch"] == "" ? "null" : Request.QueryString["branch"].ToString();
            string ddlDepartment = Request.QueryString["department"] == "" ? "null" : Request.QueryString["department"].ToString();
            string ddlEmployee = Request.QueryString["employee"] == "" ? "null" : Request.QueryString["employee"].ToString();

            var sql = "EXEC [ProcRptTransfer] @FLAG='a',@startDate=" + filterstring(startDate) + ",@endDate=" +
                      filterstring(endDate) + ",@transferType=" + filterstring(ddlTransferType) + 
                      ",@frmBranch=" + filterstring(ddlBranch) + ",@frmDepartment=" + filterstring(ddlDepartment) +  ",@staffId=" + filterstring(ddlEmployee) + "";
            DataTable dt = _clsdao.getTable(sql);

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
              
            int cols = dt.Columns.Count;

            StringBuilder stringBuilder = str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");
            double[] sum = new double[cols];

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0 || i == 1 || i == 3 || i == 4)
                    {
                        str.Append("<td align=\"center\">" + row[i] + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i] + "</td>");
                    }
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
            }
        }
    }
