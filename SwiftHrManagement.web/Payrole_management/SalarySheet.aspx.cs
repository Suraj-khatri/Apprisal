using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Payrole;

namespace SwiftHrManagement.web.Payrole_management
{
    public partial class SalarySheet : BasePage
    {
        payroleDAO _payroll = null;
        public SalarySheet()
        {
            _payroll = new payroleDAO();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string empId = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
                string fiscalYear = Request.QueryString["fy"] == null ? "" : Request.QueryString["fy"].ToString();
                string month_number = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();

                if (empId != "")
                {   
                    DataSet ds = _payroll.Executepayroll("[proc_calc_payrole] '" + fiscalYear + "','" + month_number + "','d','" + empId + "','s'");

                    lblEmpName.Text = ds.Tables[1].Rows[0]["EmployeeName"].ToString();

                    if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["name"] != null)
                        lblMonth.Text = ds.Tables[0].Rows[0]["name"].ToString();

                    listHead(tblBenefit, ds.Tables[2],lblTotalBenefit);
                    listHead(tbldeduction, ds.Tables[3],lblTotalDeduction);
                    lblnetPayable.Text = Convert.ToDouble(ds.Tables[1].Rows[0]["NetPayble"].ToString()).ToString("0.00");
                }
            }
        }

        private void listHead(Table tbl,DataTable dt,Label lblsum)
        {
            TableRow tr=null;
            TableCell td=null;
            double sum = 0;
            double tmp = 0;
            
            foreach (DataRow row in dt.Rows)
            {
                tr = new TableRow();
                
                td = new TableCell();                
                td.Text = row["name"].ToString();
                td.Width = 300;
                td.Style.Add("text-align", "left");
                tr.Cells.Add(td);

                td = new TableCell();
                td.Text = Convert.ToDouble(row["Amount"].ToString()).ToString("0.00");
                td.Style.Add("text-align", "right");
                td.Width = 150;
                tr.Cells.Add(td);

                tbl.Rows.Add(tr);

                if (row["Amount"] == null)
                    continue;

                if (double.TryParse(row["Amount"].ToString(), out tmp))
                    sum += Convert.ToDouble(row["Amount"]);                
            }
            lblsum.Text = sum.ToString("0.00");
            if (tr!=null) tr.Dispose();
            if ( td!=null) td.Dispose();
        }
    }
}
