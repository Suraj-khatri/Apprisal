using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using SwiftHrManagement.DAL.Payrole;

namespace SwiftHrManagement.web.Payrole_management
{
    public partial class MonthSetting : Page
    {
        MonthSettingDAO _monthSetting = null;
        public MonthSetting()
        {
            _monthSetting = new MonthSettingDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            showMonth();
        }

        private void showMonth()
        {            
            DataTable dt = new DataTable();
            dt = _monthSetting.SelectByQuery("proc_MonthList 's'");

            if (dt.Rows.Count == 0)
                return;

            txtMonth1.Text  = dt.Rows[0][0].ToString();
            txtMonth2.Text  = dt.Rows[0][1].ToString();
            txtMonth3.Text  = dt.Rows[0][2].ToString();
            txtMonth4.Text  = dt.Rows[0][3].ToString();
            txtMonth5.Text  = dt.Rows[0][4].ToString();
            txtMonth6.Text  = dt.Rows[0][5].ToString();
            txtMonth7.Text  = dt.Rows[0][6].ToString();
            txtMonth8.Text  = dt.Rows[0][7].ToString();
            txtMonth9.Text  = dt.Rows[0][8].ToString();
            txtMonth10.Text = dt.Rows[0][9].ToString();
            txtMonth11.Text = dt.Rows[0][10].ToString();
            txtMonth12.Text = dt.Rows[0][11].ToString();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string monthId = hddMonthId.Value;
                string monthName = hddMonthName.Value;
                _monthSetting.Save(monthId, monthName);
                lblMessage.Text = "Operation Completed Successfully";
                lblMessage.ForeColor = Color.Green;
            }
            catch
            {
                lblMessage.Text = "Error in operation";
                lblMessage.ForeColor = Color.Red;
            }
            
            
        }
    }
}
