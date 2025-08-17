using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.StaticView.FiscalMonthSetup
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsDao = null;
        public Manage()
        {
            _clsDao = new clsDAO(); 
            this._RoleMenuDAOInv = new RoleMenuDAOInv();        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 59) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        private void manageFiscalmonth()
        {
            _clsDao.runSQL("exec ProcFiscalMonthSetup 'i','" + TxtNepYear.Text + "','" + TxtEngDate.Text + "','" + txtMonth1.Text + "','" + txtMonth2.Text + "',"
            + " '" + txtMonth3.Text + "','" + txtMonth4.Text + "','" + txtMonth5.Text + "','" + txtMonth6.Text + "','" + txtMonth7.Text + "','" + txtMonth8.Text + "',"
            + " '" + txtMonth9.Text + "','" + txtMonth10.Text + "','" + txtMonth11.Text + "','" + txtMonth12.Text + "'");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string result = "";
                result = _clsDao.GetSingleresult("exec ProcFiscalMonthSetup 'c',@nplYear = '" + TxtNepYear.Text + "',@engDateBaisakh='"+ TxtEngDate.Text +"'");

                if (result == "False")
                {
                    manageFiscalmonth();
                    Response.Redirect("List.aspx");
                }
                else
                {
                    lblMessage.Text = "Setup For Current Year Already Exists";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }   
            }
            catch
            {               
                lblMessage.Text = "Error In Operation";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
