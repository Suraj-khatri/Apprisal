using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.Payrole_management
{
    public partial class EditSalary : BasePage
    {
        public EditSalary()
        {

        }
        public string Empid;
        protected DataSet GetSalaryList(string Empid)
        {
            DataSet ds = new DataSet();
            return ds;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }
        protected void GvprofileParam_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}
