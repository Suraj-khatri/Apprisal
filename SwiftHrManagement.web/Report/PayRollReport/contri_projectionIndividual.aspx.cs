using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.PayRollReport
{
    public partial class contri_projectionIndividual : BasePage
    {
        clsDAO _clsdao = null;
        public contri_projectionIndividual()
        {
         _clsdao = new clsDAO();
        }  
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {


            string year = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG=1");

            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");
            Lblmonth.Text = "Contribution Projection for the Fiscal Year : " + year + "";
            lblempname.Text = "Employee Name : " + _clsdao.GetSingleresult("select dbo.GetEmployeeFullNameOfId('" + ReadSession().Emp_Id + "')");
            DataTable dt = _clsdao.getDataset("Exec [procContributionProjection] 'i'," + filterstring(year) + "," + ReadSession().Emp_Id + "," + filterstring(ReadSession().UserId.ToString()) + "").Tables[0];

            StringBuilder str = new StringBuilder("<table border=\"1\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\">");
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
                            str.Append("<td align=\"right\">" + dr[i].ToString() + "</td>");
                        }
                    }
                    str.Append("</tr>");
                }
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
    }
}
