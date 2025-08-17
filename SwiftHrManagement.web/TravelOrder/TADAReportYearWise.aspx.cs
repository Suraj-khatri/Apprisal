using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.TravelOrder
{
    public partial class TADAReportYearWise : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDao = null;

        public TADAReportYearWise()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
                string emp_id = Request.QueryString["emp_id"] == null ? "" : Request.QueryString["emp_id"].ToString();
                string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();

                _CompanyCore = _company.FindCompany();
                this.lblHeading.Text = _CompanyCore.Name;
                this.lbldesc.Text = _CompanyCore.Address;
                lblYear.Text = year;

                if (flag == "L")
                {
                    detailedRpt(year, emp_id);
                }

            }
        }

        private void detailedRpt(string year, string emp_id)
        {
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            DataTable dt = _clsDao.getTable("EXEC [Proc_Travel] @FLAG='L',@YEAR=" + filterstring(year) + ",@EMP_ID=" + filterstring(emp_id) + "");

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("<td class=\"text-center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" href=\"ManageRequest.aspx?id=" + dr["id"] + "&flag=" + "R" + "\"><i class=\"fa fa-eye\"></i></a></td>");

                //str.Append("<td align=\"left\"><a href=\"ManageRequest.aspx?id=" + dr["id"] + "&flag="+"R"+"\">View</a></td>");
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }     
    }
}