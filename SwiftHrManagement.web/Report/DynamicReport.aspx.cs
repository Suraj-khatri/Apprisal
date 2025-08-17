using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.RptDao;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
namespace SwiftHrManagement.web.Report
{
    public partial class DynamicReport : BasePage
    {
        DynamicRpt _rpt = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        string sql = "";

        public DynamicReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();

            this._rpt = new DynamicRpt();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkCol"] != null)
                sql = "SELECT " + Request.Form["chkCol"].ToString() + " FROM " + DdlDynamicRpt.Text;
        }
        private void LoadCheckBox(Table tbl, DataTable dt)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
        }

        protected void DdlDynamicRpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlDynamicRpt.Text == "Select")
            {
                return;
            }

            DataTable dt = _rpt.FindReportDtl(DdlDynamicRpt.Text).Tables[0];
            if (dt == null){
                rptDiv.InnerHtml = "<font color=\"red\"> No Record Found </font>";
                return;
            }
            if (DdlDynamicRpt.Text == "Employee")
            {
                DataColumn dcPermnt = new DataColumn("PERMANENT_ADDRESS");
                dt.Columns.Add(dcPermnt);

                DataColumn dcTemp = new DataColumn("TEMP_ADDRESS");
                dt.Columns.Add(dcTemp);
            }
           
            TableRow tr = new TableRow();
            int pos = 0;
            TableCell td = null;
            foreach (DataColumn dc in dt.Columns)
            {
                td = new TableCell();
                td.Text = "<Input type=\"CheckBox\" value=\"" + dc.ColumnName + "\" name=\"chkCol\" id=\"chkCol\"> " + dc.ColumnName ;
                tr.Cells.Add(td);
                pos++;
                if (pos % 1 == 0)
                {
                    tblMain.Rows.Add(tr);
                    tr = new TableRow();
                }

                if (pos == dt.Columns.Count)
                {
                    if(pos % 5!=0)
                        tblMain.Rows.Add(tr);
                }
            }
        }
        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            if (sql != "")
            {
                if (DdlDynamicRpt.Text == "Employee")
                {
                    sql = "exec procEmplyeeDetailReport @fields='" + Request.Form["chkCol"].ToString() + "'";
                }
                if (DdlDynamicRpt.Text == "Insurance")
                {
                    sql = "exec [procInsuranceDetailReport] @fields='" + Request.Form["chkCol"].ToString() + "'";
                }
                this.ReadSession().RptQuery = sql;
                Response.Redirect("CompanyDynamicReport.aspx");
            }
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (sql != "")
            {
                if (DdlDynamicRpt.Text == "Employee")
                {
                    sql = "exec procEmplyeeDetailReport @fields='" + Request.Form["chkCol"].ToString() + "'";
                }
                if (DdlDynamicRpt.Text == "Insurance")
                {
                    sql = "exec [procInsuranceDetailReport] @fields='" + Request.Form["chkCol"].ToString() + "'";
                }
                this.ReadSession().RptQuery = sql;

                Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
            }
        }
    }
}
