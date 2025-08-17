using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.DAL.RptDao;

namespace SwiftHrManagement.web.Report.AttendanceDetails
{
    public partial class DateWiseReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        AttendanceReports _attendance = null;

        public DateWiseReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._attendance = new AttendanceReports();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            loadReport();            
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            loadReport();
        }
        private void loadReport()
        {           
            StaticPage sPage = new StaticPage();
            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();
            string type = Request.QueryString["type"] == null ? "" : Request.QueryString["type"].ToString();
            if (to == "")
            {
                DailyReport.Visible = true;
                summaryReport.Visible = false;               
                lblReportDate.Text = from;
            }          
            else 
            {
                summaryReport.Visible = true;
                DailyReport.Visible = false;
                this.lblFromDate.Text = from;
                this.lblToDate.Text = to;
            }
            
            lblToDate.ForeColor = System.Drawing.Color.Black;
            lblFromDate.ForeColor = System.Drawing.Color.Black;


            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-8 col-md-offset-2\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
           
            DataTable dt = _attendance.DateWiseSearch(this.ReadSession().RptQuery).Tables[0];

            int cols = dt.Columns.Count;
            str.Append("<tr>");
            str.Append("<th align=\"center\" >S.N.</th>");
            for (int i = 0; i < cols; i++)
            {                
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");                
            }
            str.Append("</tr>");

            String bgColor = "white";
            String bgColor1 = "white";
            Double logInTime = 0;
            Double logOutTime = 0;
            double TolerateTime = 0;
            double OfficeST = 0;
            double OfficeET = 0;

           
        
            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string status = "";
                count++;
                str.Append("<tr>");
                str.Append("<td  align=\"left\" >" + count + "</td>");


                for (int i = 0; i < cols; i++)
                {
                    bgColor = "white";
                    bgColor1 = "white";
                    string fld = dr.Table.Columns[i].ColumnName;

                    if (fld == "Login Time" || fld =="Logout Time")
                    {
                        string toleranceTime = sPage.getTolerateTime("tolaranceTime");
                        string officeST = sPage.getTolerateTime("OfficeStartTime");
                        string officeET = sPage.getTolerateTime("OfficeEndTime");
                        Double.TryParse(officeST.Substring(0, 5).Replace(':', '.'), out OfficeST);
                        Double.TryParse(officeET.Substring(0, 5).Replace(':', '.'), out OfficeET);
                        

                        Double.TryParse(toleranceTime.Substring(0, 5).Replace(':', '.'), out TolerateTime);
                        Double.TryParse(dr[7].ToString().Substring(0, 5).Replace(':', '.'), out logInTime);               
                        Double.TryParse(dr[8].ToString().Substring(0, 5).Replace(':', '.'), out logOutTime);
                                             
                       
                        status = dr[9].ToString();

                        if (status == "ON LEAVE")
                        {
                            bgColor = sPage.getColorName("on_leave");
                        }
                        else if (logInTime == 0) //Login Time
                        {
                            bgColor = sPage.getColorName("absent");
                        }
                        else if (logInTime <= OfficeST && fld == "Login Time")  //Login Time
                        {
                            bgColor = sPage.getColorName("color0930");
                        }
                        else if (logInTime > OfficeST && logInTime <= TolerateTime && fld == "Login Time")
                        {
                            bgColor = sPage.getColorName("color1000");
                        }
                        else if (logInTime > TolerateTime && fld == "Login Time")
                        {
                            bgColor = sPage.getColorName("colorother");
                        }
                        else if (logOutTime < OfficeET && fld == "Logout Time")
                        {
                            bgColor = sPage.getColorName("colorother");
                        }
                        else if (logInTime <= TolerateTime || logOutTime > OfficeET)
                        {
                            bgColor = sPage.getColorName("color0930");
                        }
                        else if (logInTime > OfficeST && logInTime <= TolerateTime && logOutTime > OfficeET)
                        {
                            bgColor = sPage.getColorName("color1000");
                        }
                    }
                 
                    str.Append("<td  bgcolor = '" + bgColor + "' align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr></div>");
            }
            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        }
    }

