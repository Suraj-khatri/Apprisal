using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using System.Text;

namespace SwiftHrManagement.web.Report.OnSiteDuty
{
    public partial class onSiteDutyReport : BasePage
    {
        clsDAO _clsdao = null;
        public onSiteDutyReport()
        {
         _clsdao = new clsDAO();
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();
        }

        private void loadReport()
        {
            lblHeading.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            lbldesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");

            string from = Request.QueryString["datefrom"] == null ? "" : Request.QueryString["datefrom"].ToString();
            string to = Request.QueryString["dateto"] == null ? "" : Request.QueryString["dateto"].ToString();
            string branch = filterstring(Request.QueryString["branch"] == null ? "" : Request.QueryString["branch"].ToString());
            string dept = filterstring(Request.QueryString["dept"] == null ? "" : Request.QueryString["dept"].ToString());

            string empid = filterstring(Request.QueryString["empId"] == null ? "" : Request.QueryString["empId"].ToString());

            this.From_Date1.Text = from;
            this.To_Date1.Text = to;

            lblBranchName.Text = _clsdao.GetSingleresult("SELECT dbo.GetBranchName(" + branch + ")");
            lblDeptName.Text = _clsdao.GetSingleresult("SELECT dbo.GetDeptName("+dept+")");
            
            DataSet ds = _clsdao.getDataset("exec ProcOnSiteDutyReport @empid=" + empid + ",@datefrom=" + filterstring(from)
                                            + ",@dateto=" + filterstring(to) + ",@branch=" + branch + ",@dept=" + dept);

            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder("<div class=\"table-responsive \"> <table class=\"table table-bordered table-striped table-condensed\">");
                      
            dt = ds.Tables[0];
            int cols = dt.Columns.Count;             
            str.Append("<tr>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\" >" + dt.Columns[i].ColumnName + "</th>");
            }

            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i == 0 || i == 4 || i == 5 || i == 6)
                    {
                        str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("</tr>");
            }
               
            str.Append("</table>");
            str.Append("</div>");
            rptDiv.InnerHtml = str.ToString();
        }

    }
}
