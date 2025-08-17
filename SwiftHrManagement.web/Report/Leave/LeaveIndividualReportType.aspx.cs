using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;

namespace SwiftHrManagement.web.Report.Leave
{
    public partial class LeaveIndividualReportType : BasePage
    {
        clsDAO _clsdao = null;
        public LeaveIndividualReportType()
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

            string from = Request.QueryString["from"] == null ? "" : Request.QueryString["from"].ToString();
            string to = Request.QueryString["to"] == null ? "" : Request.QueryString["to"].ToString();

            string branchid = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string departmentid = Request.QueryString["departmentId"] == null ? "" : Request.QueryString["departmentId"].ToString();
            string empid = Request.QueryString["empid"] == null ? "" : Request.QueryString["empid"].ToString();

            this.From_Date1.Text = from;
            this.To_Date1.Text = to;

            DataTable dt1 = new DataTable();

            dt1 = _clsdao.getDataset("select dbo.[GetBranchName](" + branchid + ") as branch, "
                + " dbo.GetEmployeeFullNameOfId(" + empid + ")as Emp,dbo.GetDeptName(" + departmentid + ")as dept ").Tables[0];

            foreach (DataRow dr in dt1.Rows)
            {
                lblleaveBranchName.Text = dr["branch"].ToString();
                lblleaveDeptName.Text = dr["dept"].ToString();
                lblleaveEmpname.Text = dr["Emp"].ToString();

            }



            //DataSet ds = _clsdao.getDataset("exec ProcLeaveDetailReportIndividuals '1047','2010-1-1','2010-12-30'");

            DataSet ds = _clsdao.getDataset("exec ProcLeaveDetailReportIndividuals " + filterstring(empid) + "," + filterstring(from) + "," + filterstring(to) + "");




            DataTable dt = new DataTable();
            StringBuilder str = new StringBuilder("");
            string RemainLeave = "0";
            string LastYearleave = "0";
            string ThisYearBalance = "0";
            double TotalTaken = 0.0;

            int count;
            count = 0;


            for (int j = 0; j <= 3; j++)
            {
                dt = ds.Tables[j];
                str.Append("<table width=\"700\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"0\" align=\"center\">");
                int cols = dt.Columns.Count;
                foreach (DataRow dr in dt.Rows)
                {

                    LastYearleave = dr["LAST_YEAR_LEAVE"].ToString();
                    ThisYearBalance = dr["NO_OF_DAYS_ACTUAL"].ToString();

                }

                if (j == 0)
                {
                    str.Append("<tr> <th colspan='4' align=\"center\"> CASUAL LEAVE </th> </tr>");
                    str.Append("<tr> <th colspan='3' align=\"right\"> This Year Balance </th> <th> " + ThisYearBalance + " </th> </tr>");
                }
                else if (j == 1)
                {
                    str.Append("<tr> <th colspan='4' align=\"center\"> ANNUAL LEAVE </th> </tr>");
                    str.Append("<tr> <th colspan='3' align=\"right\"> Last Year Balance </th> <th> " + LastYearleave + " </th> </tr>");
                    str.Append("<tr> <th colspan='3' align=\"right\"> This Year Balance </th> <th> " + ThisYearBalance + " </th> </tr>");

                }
                else if (j == 2)
                {
                    str.Append("<tr> <th colspan='4' align=\"center\"> SICK LEAVE </th> </tr>");
                    str.Append("<tr> <th colspan='3' align=\"right\"> Last Year Balance </th> <th> " + LastYearleave + " </th> </tr>");
                    str.Append("<tr> <th colspan='3' align=\"right\"> This Year Balance </th> <th> " + ThisYearBalance + " </th> </tr>");
                }
                else
                {
                    str.Append("<tr> <th colspan='5' align=\"center\"> OTHER LEAVE </th> </tr>");
                }

                //if (j == 1 || j == 2)
                //{
                //    str.Append("<tr> <th colspan='3' align=\"right\"> Last Year Balance </th> <th> " + LastYearleave + " </th> </tr>");
                //    str.Append("<tr> <th colspan='3' align=\"right\"> This Year Balance </th> <th> " + ThisYearBalance + " </th> </tr>");
                //}

                str.Append("<tr>");
                str.Append("<th align=\"center\" >S.N.</th>");
                for (int i = 0; i < cols - 3; i++)
                {
                    str.Append("<th align=\"center\" >" + dt.Columns[i].ColumnName + "</th>");
                }

                str.Append("</tr>");



                TotalTaken = 0.0;
                RemainLeave = "0";
                //LastYearleave = "0";
                //ThisYearBalance = "0";

                count = 1;
                foreach (DataRow dr in dt.Rows)
                {

                    str.Append("<tr>");
                    str.Append("<td align=\"right\" >" + count + "</td>");
                    for (int i = 0; i < cols - 3; i++)
                    {
                        if (i == 0 || i == 1 || i == 2)
                        {
                            str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                        }
                        else if (i > 2)
                        {
                            str.Append("<td align=\"center\">" + dr[i].ToString() + "</td>");
                        }
                        // str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");

                    }

                    TotalTaken = TotalTaken + double.Parse(dr["DAYS"].ToString());
                    //RemainLeave = dr["REMAINING_DAYS"].ToString();

                    //LastYearleave = dr["LAST_YEAR_LEAVE"].ToString();
                    //ThisYearBalance = dr["NO_OF_DAYS_ACTUAL"].ToString();
                    str.Append("</tr>");
                    count++;
                }
                RemainLeave = (double.Parse(LastYearleave) + double.Parse(ThisYearBalance) - TotalTaken).ToString();


                if (j == 0 || j == 1 || j == 2)
                {
                    str.Append("<tr> <th colspan='3' align=\"right\"> Total Taken </th> <th> " + TotalTaken + " </th> </tr>");
                    str.Append("<tr> <th colspan='3' align=\"right\"> Total Remain </th> <th> " + RemainLeave + " </th> </tr>");
                }
                else
                {
                    str.Append("<tr> <th colspan='4' align=\"right\"> Total Taken </th> <th> " + TotalTaken + " </th> </tr>");
                    str.Append("<tr> <th colspan='4' align=\"right\"> Total Remain </th> <th> " + RemainLeave + " </th> </tr>");

                }
                str.Append("</table><br/><br/>");

            }


            rptDiv.InnerHtml = str.ToString();
        }
    }
}
