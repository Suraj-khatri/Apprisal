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

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class PayrollAllInfo : System.Web.UI.Page
    {
        protected int empId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            empId = GetEmployeeId();
           
        }
        protected int GetEmployeeId()
        {
            return (Request.QueryString["Id"] != null ? int.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
    }
}
