using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class Remarksreport : BasePage
    {
        clsDAO _clsdao = null;
        public Remarksreport()
        {
            _clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadreport();
        }
        private void loadreport()
        {
            string fromdate = "";
            string todate = "";
            if (Request.QueryString["fromdate"] != null)
                fromdate = Request.QueryString["fromdate"];
            if (Request.QueryString["todate"] != null)
                todate = Request.QueryString["todate"];
            StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"left\">");
            StringBuilder strremarks = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"left\">");
            this.lblHeading.Text = _clsdao.GetSingleresult("select COMP_NAME from Company"); ;
            this.lbldesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");

            DataSet dsleavereport = _clsdao.getDataset("exec porcLeaveRemarksReport "+ filterstring(fromdate) +","+filterstring(todate)+"");
            DataTable dtleavecalander = dsleavereport.Tables[0];
            DataTable dtremarks = dsleavereport.Tables[1];

            int cols = dtleavecalander.Columns.Count;

            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dtleavecalander.Columns[i].ColumnName + "</th>");
            }

            str.Append("</tr>");

            foreach (DataRow dr in dtleavecalander.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {

                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();

            int colsremarks = dtremarks.Columns.Count;

            strremarks.Append("<tr>");

            for (int i = 0; i < colsremarks; i++)
            {
                strremarks.Append("<th align=\"left\">" + dtremarks.Columns[i].ColumnName + "</th>");
            }

            strremarks.Append("</tr>");

            foreach (DataRow dr in dtremarks.Rows)
            {
                strremarks.Append("<tr>");
                for (int i = 0; i < colsremarks; i++)
                {

                    strremarks.Append("<td align=\"left\">" + "* " + dr[i].ToString() + "</td>");

                }
                strremarks.Append("</tr>");
            }
            strremarks.Append("</table>");
            rptDivRemarks.InnerHtml = strremarks.ToString();
        }
    }
}
