using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Payrole;
namespace SwiftHrManagement.web.Payrole_management
{
    public partial class ManageManualAddDed : BasePage
    {
        ManualAddDedDAO _manualAddDeductDao = null;
        ManualAddDeductionCore _manualAddDedCore = null;
        public ManageManualAddDed()
        {
            _manualAddDedCore = new ManualAddDeductionCore();
            _manualAddDeductDao = new ManualAddDedDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (GetManualAddDedId() > 0)
            {
                BtnDelete.Visible = true;
                populataddDeduction();
            }
            else
            {
                BtnDelete.Visible = false;
            }
        }
        private long GetManualAddDedId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populataddDeduction()
        { 
            long id = GetManualAddDedId();
            ManualAddDedDAO _manualDao = new ManualAddDedDAO();
            ManualAddDeductionCore _manual = _manualDao.FindallbyId(id);
            TxtName.Text = _manual.Name;
            if (_manual.Enable == true)            
                ChkEnabled.Checked = true;
            else
                ChkEnabled.Checked = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                String isenabled = "";
                if (ChkEnabled.Checked == true)
                    isenabled = "True";
                else
                    isenabled = "False";
                _manualAddDeductDao.Save("i", int.Parse(GetManualAddDedId().ToString()), TxtName.Text, (isenabled));
                Response.Redirect("ListManualAddDed.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListManualAddDed.aspx");
        }
    }
}
