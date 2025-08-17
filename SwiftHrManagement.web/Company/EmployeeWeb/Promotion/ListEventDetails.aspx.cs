using System;
using System.Data;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.Company.EmployeeWeb.Promotion
{
    public partial class ListEventDetails : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        clsDAO _clsdao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            showDetails();
        }
        protected long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void showDetails()
        {
            DataTable dt = _clsdao.getDataset("Exec Proc_ServiceEvents @FLAG='a',@Emp_ID=" + filterstring(GetEmpId().ToString())).Tables[0];

            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");

            int count;
            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th align=\"center\" Class=\"HeaderStyle\">S.N.</th>");
            for (int i =1; i < cols; i++)
            {
                str.Append("<th align=\"center\" Class=\"HeaderStyle\">" + dt.Columns[i].ColumnName + "</th>");
            }

            str.Append("</tr>");

            count = 1;
            int cnt = 0;
            foreach (DataRow dr in dt.Rows)
            {
                cnt++;

                if (cnt % 2 == 0)
                {
                    str.Append("<tr class=\"GridOddRow\" onMouseOver=\"this.className='GridOddRowOver'\" onMouseOut=\"this.className='GridOddRow'\" >");
                }
                else
                {
                    str.Append("<tr class=\"GridEvenRow\" onMouseOver=\"this.className='GridEvenRowOver'\" onMouseOut=\"this.className='GridEvenRow'\">");
                }
                str.Append("<td align=\"center\" >" + count + "</td>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
                count++;
            }


            str.Append("</table>");
            str.Append("</div><br/><br/>");

            rpt.InnerHtml = str.ToString();

        }
    }
}
