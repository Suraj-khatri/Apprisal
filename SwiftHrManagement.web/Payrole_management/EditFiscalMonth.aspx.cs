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
using SwiftHrManagement.DAL.Payrole.FiscalMonthSetup;
using SwiftHrManagement.Core.Domain;
namespace SwiftHrManagement.web.Payrole_management
{
    public partial class EditFiscalMonth : BasePage
    {
        //FiscalMonthDAO _fiscalmonth = null;
        //FiscalCore _fiscalcore = null;
        public EditFiscalMonth()
        {
            FiscalMonthDAO _fiscalmonth = new FiscalMonthDAO();
            FiscalCore _fiscalcore = new FiscalCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMonth.Text = getmonth().ToString();
                lblFiscalYear.Text = getfiscalyear();
                populatefiscalyear();
            }
        }
        public long getmonth()
        {
            long month_number = long.Parse(Request.QueryString["month_number"] == null ? "" : Request.QueryString["month_number"]);
             return month_number;
        }
        private void populatefiscalyear()
        {
            FiscalMonthDAO _fisDAO = new FiscalMonthDAO();
            FiscalCore _fiscore = new FiscalCore();
            DateTime engfrom;
            DateTime dateto;

            long id = getmonth();
            if (id > 0)
            {
                _fiscore = _fisDAO.FindById(id);
                if (_fiscore != null)
                {
                    //this.lblFiscalYear.Text = _fiscore.Fiscal_year == null ? "" : _fiscore.Fiscal_year;
                    this.lblFiscalYear.Text = _fiscore.Fiscal_year;
                    this.lblMonth.Text = _fiscore.Month_number.ToString();
                    engfrom = DateTime.Parse(_fiscore.Engfrom);
                    this.txtEngFrom.Text = engfrom.ToString("MM/dd/yyyy");
                    dateto = DateTime.Parse(_fiscore.Engto);
                    this.txtEngTo.Text = dateto.ToString("MM/dd/yyyy");
                    this.txtNepFrom.Text = _fiscore.Nepfrom;
                    this.txtNepTo.Text = _fiscore.Nepto;
                }                
            }            
        }
        public String getfiscalyear()
        {
            string fy = Request.QueryString["fy"] == null ? "" : Request.QueryString["fy"].ToString();
            return fy;
        }
        //string empId = Request.QueryString["EmployeeId"] == null ? "" : Request.QueryString["EmployeeId"].ToString();
        //string fiscalYear = "2009";
        //string month_number = Request.QueryString["month"] == null ? "" : Request.QueryString["month"].ToString();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FiscalMonthDAO _fiscalsetup = new FiscalMonthDAO();
                string fy = lblFiscalYear.Text;
                string month = lblMonth.Text;
                string engFrom = txtEngFrom.Text;
                string engTo = txtEngTo.Text;
                string nepFrom = txtNepFrom.Text;
                string nepTo = txtNepTo.Text;
                _fiscalsetup.Save(month,fy, engFrom, engTo, nepFrom, nepTo);
                Response.Redirect("FiscalMonthList.aspx");
            }
            catch
            {
                lblmessage.Text = "Error in operation";
                lblmessage.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}
