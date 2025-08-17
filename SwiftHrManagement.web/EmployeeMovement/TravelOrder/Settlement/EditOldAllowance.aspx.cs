using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder.Settlement
{
    public partial class EditOldAllowance : System.Web.UI.Page
    {
        TravelOrderSettlementDao _TOSDao = new TravelOrderSettlementDao();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateData();
                //setDDL();
            }
            txtRate.Attributes.Add("OnBlur", "TotalAllowance()");
        }

        private long GetTravelOID()
        {
            return (Request.QueryString["TravelOID"] != null ? long.Parse(Request.QueryString["TravelOID"]) : 0);
        }
        private void setDDL(string selectedValue)
        {
            var sql = "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 61";
            _clsDao.setDDL(ref ddlAllowanceType, sql, "ROWID", "DETAIL_TITLE", selectedValue, "Select");
            

        }

        private void PopulateData()
        {
            DataTable dt = _TOSDao.EditAllownceById(GetTravelOID().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            setDDL(dr["allowanceType"].ToString());
            txtDays.Text = dr["days"].ToString();
            txtRate.Text = dr["rate"].ToString();
            txtTotal.Text = dr["total"].ToString();
              
        }

        private void OnAdd()
        {
            string msg = _TOSDao.EditAllowanceById(ddlAllowanceType.Text, txtRate.Text, txtTotal.Text, "", txtDays.Text, GetTravelOID().ToString());
            LblMsg.Text = msg;
            LblMsg.ForeColor = System.Drawing.Color.Green;
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAdd();
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (int.Parse(txtDays.Text) * int.Parse(txtRate.Text)).ToString();
        }

    }
}
