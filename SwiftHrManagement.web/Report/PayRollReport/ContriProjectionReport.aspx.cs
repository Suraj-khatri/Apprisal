using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class ContriProjectionReport : BasePage
    {
        clsDAO _clsdao = null;
        string empid = "";
        string year = "";
        string amt1 = "";
        string amt2 = "";
        string amt3 = "";
        public ContriProjectionReport()
        {
         _clsdao = new clsDAO();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
                year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();
                amt1 = Request.QueryString["amt1"] == null ? "" : Request.QueryString["amt1"].ToString();
                amt2 = Request.QueryString["amt2"] == null ? "" : Request.QueryString["amt2"].ToString();
                amt3 = Request.QueryString["amt3"] == null ? "" : Request.QueryString["amt3"].ToString();

                projectionHead();
                projectionData();
                projectionDesc();
            }
        }
        private void projectionHead()
        {
            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            Lblmonth.Text = "Contribution Projection for the Fiscal Year : " + year + "";
            lblempname.Text = "Employee Name : " + _clsdao.GetSingleresult("select dbo.GetEmployeeFullNameOfId('" + empid + "')");
        }

        private void projectionData()
        {            
            DataTable dt = _clsdao.getDataset("Exec [procContributionProjectionNew] @flag='i',@fiscalYear=" + filterstring(year) + ","
                            + " @emp_id=" + filterstring(empid) + ",@user=" + filterstring(ReadSession().UserId.ToString()) + ","
            + " @projection1=" + filterstring(amt1) + ",@projection2=" + filterstring(amt2) + ",@projection3=" + filterstring(amt3) + "").Tables[0];

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-responsive table-bordered table-striped table-condensed\" align=\"center\">");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"Left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void projectionDesc()
        {
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();
            string year = Request.QueryString["year"] == null ? "" : Request.QueryString["year"].ToString();

            string amt1 = Request.QueryString["amt1"] == null ? "" : Request.QueryString["amt1"].ToString();
            string amt2 = Request.QueryString["amt2"] == null ? "" : Request.QueryString["amt2"].ToString();
            string amt3 = Request.QueryString["amt3"] == null ? "" : Request.QueryString["amt3"].ToString();

            DataTable dt = _clsdao.getDataset("Exec [procContributionProjectionNew] @flag='i',@fiscalYear=" + filterstring(year) + ","
                               + " @emp_id=" + filterstring(empid) + ",@user=" + filterstring(ReadSession().UserId.ToString()) + ","
               + " @projection1=" + filterstring(amt1) + ",@projection2=" + filterstring(amt2) + ",@projection3=" + filterstring(amt3) + "").Tables[1];

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-responsive table-bordered table-striped table-condensed\" align=\"center\">");
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            if (cols == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        str.Append("<td align=\"Left\"><font color=\"red\">" + dr[i].ToString() + "</font></td>");
                    }
                    str.Append("</tr>");
                }
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    str.Append("<tr>");
                    for (int i = 0; i < cols; i++)
                    {
                        if (i == 0)
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                        else
                        {
                            str.Append("<td class=\"text-right\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            str.Append("</table>");
            rptDivDesc.InnerHtml = str.ToString();  
        }
    }
}
