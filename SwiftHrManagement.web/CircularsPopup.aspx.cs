using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web
{
    public partial class CircularsPopup : System.Web.UI.Page
    {
        clsDAO _cls = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetId() != "")
                {
                    PopulateData();
                }
            }
        }

        private string GetId()
        {
            return GetStatic.ReadQueryString("id", "");
        }

        private void PopulateData()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            string sql = "exec Proc_Circulars @flag = 'b', @func_id = '" + GetId() + "'";
            DataSet ds = _cls.ExecuteDataset(sql);

            if (ds.Tables.Count == 2)
            {
                dt1 = ds.Tables[0];
                dt2 = ds.Tables[1];       
            }

            DataRow dr = dt1.Rows[0];
            head.Text = dr["func_head"].ToString();
            body.Text = dr["func_detail"].ToString();

            if (dt2.Rows == null || dt2.Rows.Count == 0)
            {
                circulars.InnerHtml = "<tr><td colspan=\"6\" align=\"center\">No files uploaded.</td>";
                return;
            }

            StringBuilder sb = new StringBuilder("");
            int sNo = 1;

            foreach (DataRow item in dt2.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sNo + "</td>");
                sb.AppendLine("<td>" + item["doc_desc"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["doc_ext"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["created_date"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["Name"].ToString() + "</td>");
                sb.AppendLine("<td><a target='_blank' href=\"" + item["Location"].ToString() + "\">");
                sb.AppendLine("<img src=\"images/"+item["doc_ext"].ToString()+".png\" alt=\""+item["doc_ext"].ToString()+"\" width=\"35\" height=\"30\" style=\"border:0px;\"/></a></td>");
                sb.AppendLine("</tr>");
                sNo++;
            }
            circulars.InnerHtml = sb.ToString();
        }
    }
}