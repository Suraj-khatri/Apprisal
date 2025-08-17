using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Report
{
    public partial class Gatepassreport : BasePage
    {
        ClsDAOInv _clsdao = null;
        public Gatepassreport()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            preparereport();
        }
        private void preparereport()
        {
            DateTime gatepassdate;
            long id = 0;
            lblHeading.Text = _clsdao.GetSingleresult("select COMP_NAME from HRManagement.dbo.Company");
            if (Request.QueryString["id"] != null)
                id = long.Parse(Request.QueryString["id"]);
                DataSet ds =  _clsdao.getDataset("exec Proc_AssetGatepassreport "+ filterstring(id.ToString()) +"");
                StringBuilder str = new StringBuilder("<table border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"left\">");
                DataTable dt = new DataTable();
                DataTable dtinfo = ds.Tables[1];
                DataTable dtbranch = ds.Tables[2];
                foreach (DataRow dr in dtinfo.Rows)
                {
                    lbloutMsg.Text = dr["out_message"].ToString();
                    //lblPreparedDate.Text = dr["preapereddate"].ToString();
                    lblpreparedby.Text = dr["preaperedby"].ToString();
                    lbldeliveredto.Text = dr["delivered_to"].ToString();
                    gatepassdate = DateTime.Parse(dr["Get_pass_date"].ToString());
                    lbldeliveredDate.Text = gatepassdate.ToString("MM/dd/yyyy");
                    lblGatepassno.Text = id.ToString();
                }
                dt = ds.Tables[0];

                foreach (DataRow dr in dtbranch.Rows)
                {
                    lblbranch.Text = dr["branch_name"].ToString();
                }
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
                    str.Append("</tr>");
                }
                str.Append("</table>");
                rptDiv.InnerHtml = str.ToString();
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }

    }
}
