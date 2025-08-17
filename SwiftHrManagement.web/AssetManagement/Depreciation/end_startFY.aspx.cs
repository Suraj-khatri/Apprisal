using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web;


namespace SwiftHrManagement.web.AssetManagement.Depreciation
{
    public partial class end_startFY : BasePage
    {
        ClsDAOInv _clsDao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public end_startFY()
        {
            _clsDao = new ClsDAOInv();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 206) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                //_clsDao.setDDL(ref startFY, "SELECT FISCAL_YEAR_NEPALI from FiscalYear where FLAG=1", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "Select");
                _clsDao.CreateDynamicDDl(endFY, "SELECT FISCAL_YEAR_NEPALI from FiscalYear where FLAG=1", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "");
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string MSG = _clsDao.GetSingleresult("Exec procEndStartFiscalYear 'i'," + filterstring(endFY.Text) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
            lblMes.Text = MSG;
            lblMes.ForeColor = System.Drawing.Color.Red;
            //endFY.Text = "";
            //startFY.Text = "";
        }
    }
}
