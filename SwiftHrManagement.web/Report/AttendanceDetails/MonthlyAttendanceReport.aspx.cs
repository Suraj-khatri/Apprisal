using System;
using System.Data;
using System.Text;

namespace SwiftHrManagement.web.Report.AttendanceDetails
{
    public partial class MonthlyAttendanceReport : BasePage
    {
        clsDAO _cls=new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateDropdownList();
                showrpt.Visible = false;
            }
            
        }

        protected void PopulateDropdownList()
        {
            _cls.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "");
            DdlYear.SelectedValue = _cls.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG ='1'");
            _cls.CreateDynamicDDl(DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "Select");
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            DisplayRpt();
            Displaycount();
            showrpt.Visible = true;
            searchrpt.Visible = false;
        }

        private void DisplayRpt()
        {

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _cls.getDataset("EXEC Proc_MonthlyIndividualAttendance @flag='i',@year=" + filterstring(DdlYear.Text) + ",@month="+filterstring(DdlMonth.Text)+",@emp=" + filterstring(ReadSession().Emp_Id.ToString())).Tables[0];

            int cols = dt.Columns.Count;


            str.Append("<tr>");
            str.Append("<th colspan=" + cols+1 + " align=\"center\" >Monthly Attendance Report</th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<td colspan=" + cols+1 + "><b>Fiscal Year: </b>" + DdlYear.SelectedItem.Text + "<br/> <b>Month: </b>" + DdlMonth.SelectedItem.Text + "</td>");
            str.Append("</tr>");
           

            str.Append("<tr>");
            str.Append("<th align=\"center\" >S.N.</th>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string status = "";
                count++;
                str.Append("<tr>");
                str.Append("<td  align=\"left\" >" + count + "</td>");


                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            showrpt.InnerHtml = str.ToString();
        }

        private void Displaycount()
        {

            StringBuilder str = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            DataTable dt = _cls.getDataset("EXEC Proc_MonthlyIndividualAttendance @flag='i',@year=" + filterstring(DdlYear.Text) + ",@month=" + filterstring(DdlMonth.Text) + ",@emp=" + filterstring(ReadSession().Emp_Id.ToString())).Tables[1];

            int cols = dt.Columns.Count;

            str.Append("<tr>");
            str.Append("<th align=\"center\" >S.N.</th>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");

            int count = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string status = "";
                count++;
                str.Append("<tr>");
                str.Append("<td  align=\"left\" >" + count + "</td>");

                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            str.Append("</div>");
            showrpt1.InnerHtml = str.ToString();
        }
    }
}