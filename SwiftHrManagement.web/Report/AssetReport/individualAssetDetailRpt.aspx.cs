using System;
using System.Data;
using System.Text;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Report.AssetReport
{
    public partial class individualAssetDetailRpt : System.Web.UI.Page
    {
        ReportDao _obj = new ReportDao();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReprot();
        }

        private void LoadReprot()
        {
            var assetNOType = GetStatic.ReadQueryString("assetNOType", "");
            var assetNo = GetStatic.ReadQueryString("assetNo", "");
            var ds=_obj.GetIndividualAssetDetailRpt(assetNOType, assetNo);
            var sb = new StringBuilder();
            if(ds.Tables.Count>0)
            {
                var dt1 = ds.Tables[0];
                var dt2 = ds.Tables[1];
                var dt3 = ds.Tables[2];
                var dt4 = ds.Tables[3];
                var dt5 = ds.Tables[4];
                var dt6 = ds.Tables[5];        
                rpt.InnerHtml = GetMainDetail(dt1);                                                          
                  if(dt1.Rows.Count>0)
                    {
                        sb.Append(GetMainDetail(dt1));
                    }
                    if (dt2.Rows.Count > 0)
                    {
                       Div1.InnerHtml=GetDetail(dt2, "Transfer Details");                      
                    }
                    if (dt3.Rows.Count > 0)
                    {
                         Div2.InnerHtml=GetDetail(dt3,"Write off Details");
                    }
                    if (dt4.Rows.Count > 0)
                    {
                        Div3.InnerHtml=GetDetail(dt4, "Repair/ Maintenance Details");
                    }
                    if (dt5.Rows.Count > 0)
                    {
                        Div4.InnerHtml=GetDetail(dt5,"Asset capitalization Details");
                    }
                    if (dt6.Rows.Count > 0)
                    {
                        Div5.InnerHtml = GetDetail(dt6, "Depn Detail for this year");
                    }

            }
        }

        private string GetDetail(DataTable dt,string caption)
        {           
            var sb = new StringBuilder();           
            sb.Append("<table align=\"left\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"TBL\">");
            sb.Append("<tr><th colspan='" + dt.Columns.Count + "'>" + caption + "</th></tr>");
            sb.Append("<tr>");
            foreach (DataColumn dc in dt.Columns)
            {                   
                sb.Append("<th>" + dc.ColumnName + "</th>");                   
            }               
            sb.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {                                                                                 
                   sb.Append("<td>" + dr[dc] + "</td>");                                     
                }               
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }


        /*
        private string GetDetail(DataTable dt)
        {            
            var sb = new StringBuilder();
            sb.Append("<table align=\"left\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"TBL\">");
            foreach (DataRow dr in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn dc in dt.Columns)
                {
                    sb.Append("<td>" + dc.ColumnName + "</td>");
                    sb.Append("<td>" + dr[dc] + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
*/
        private string GetMainDetail(DataTable dt)
        {
            var sb = new StringBuilder();            
            sb.Append("<table align=\"left\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class=\"TBL\">");
            sb.Append("<tr><th>SN</th><th>Fields</th><th>Value</th></tr>");
            int i = 0;
            foreach (DataColumn dc in dt.Columns)
            {
                var ii = ++i;
                sb.Append("<tr>");
                    sb.Append("<td>" + ii + "</td>");
                    sb.Append("<td>" + dc.ColumnName + "</td>");
                    sb.Append("<td>" + dt.Rows[0][dc] + "</td>");               
                sb.Append("</tr>");
            }
            sb.Append("</table>");            
            return sb.ToString();
        }
    }
}