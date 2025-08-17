using System;
using System.Data;
using System.Text;



namespace SwiftHrManagement.web.Report.TADAReport
{
    public partial class TADASummaryReport : BasePage
    {

        clsDAO _clsdao = null;
        string currPage = "";

        public TADASummaryReport()
        {
            _clsdao=new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            }
            GenerateReport();
            currPage = getCurrPage();
        }

        private string getCurrPage()
        {
            string raw = Request.RawUrl;
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }

        private void GenerateReport()
        {
            Lblcompany.Text = _clsdao.GetSingleresult("select COMP_NAME from Company");
            LblDesc.Text = _clsdao.GetSingleresult("select COMP_ADDRESS from Company");

            StringBuilder _strext = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            DataTable dt = _clsdao.getTable(@"Exec PROC_TadaRpt @empId="+filterstring(Request.QueryString["empId"])+","
                                            + "@branchId=" + filterstring(Request.QueryString["branchId"]) + ","
                                            + "@deptId=" + filterstring(Request.QueryString["deptId"]) + ","
                                            + "@destination=" + filterstring(Request.QueryString["destination"]) + ","
                                            + "@reasonTravel=" + filterstring(Request.QueryString["reasonTravel"]) + ","
                                            + "@status=" + filterstring(Request.QueryString["status"]) + ","
                                            + "@reimstatus=" + filterstring(Request.QueryString["reimstatus"]) + ","
                                            + "@fromdate=" + filterstring(Request.QueryString["fromdate"]) + ","
                                            + "@todate=" + filterstring(Request.QueryString["todate"]) 
                                            );

            int cols = dt.Columns.Count;

            _strext.Append("<tr>");

            for(int j=0; j<=0; j++)
            {
                _strext.Append("<th align=\"left\">" + dt.Columns[j].ColumnName + "</th>");
            }
            for (int i = 2; i < cols; i++)
            {
                _strext.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
                
            }
            _strext.Append("<th align=\"left\">View</th>");
            _strext.Append("</tr>");

            foreach (DataRow dr in dt.Rows)
            {
                _strext.Append("<tr>");

                for (int j = 0; j <= 0; j++ )
                {
                    _strext.Append("<td align=\"left\">" + dr[j] + "</td>");
                }
                for (int i = 2; i < cols; i++)
                    {
                        _strext.Append("<td align=\"left\">" + dr[i] + "</td>");

                    }
                  //_strext.Append("<th align=\"left\"><a href=\"/Report/TADAReport/DetailReport.aspx?id="+dr["id"]+"\">View</a></th>");

                  _strext.Append("<th class=\"text-center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" href=\"/Report/TADAReport/DetailReport.aspx?id=" + dr["id"] + "\"><i class=\"fa fa-eye\"></i></a></th>");

                   _strext.Append("</tr>");
            }
            
            _strext.Append("</table>");
          
             divreport.InnerHtml = _strext.ToString();
        }

       
       
    }
}