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
using SwiftHrManagement.web.DAL.TravelOrder;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder
{
    public partial class EditAllowance : System.Web.UI.Page
    {
        clsDAO _clsDao = new clsDAO();
        TravelOrderDao _travelDao = new TravelOrderDao();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PopulateData();
            }
            txtPerDays.Attributes.Add("OnBlur","Total();");

        }
        private long GetTravelOID()
        {
            return (Request.QueryString["TravelOID"] != null ? long.Parse(Request.QueryString["TravelOID"]) : 0);
        }
        protected long GetTotalDays()
        {
            return (Request.QueryString["totalDays"] != null ? long.Parse(Request.QueryString["totalDays"]) : 0);
        }


        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            OnAdd();
        }
    
        private void PopulateData()
        {
            DataTable dt = _travelDao.FindAllowanceById(GetTravelOID().ToString());
            DataRow dr = null;
            if (dt == null || dt.Rows.Count <= 0)
                return;
            dr = dt.Rows[0];
            _clsDao.setDDL(ref ddlAllowanceType, "select ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID = 61", "ROWID", "DETAIL_TITLE", dr["allowanceType"].ToString(), "Select");
            txtPerDays.Text   = dr["perdays"].ToString();
            txtDays.Text      = dr["days"].ToString();
            txtTotal.Text     = dr["total"].ToString();             
        }

        private void OnAdd()
        {
           
           string msg =  _travelDao.OnAdd(GetTravelOID().ToString(),ddlAllowanceType.Text,txtPerDays.Text,txtDays.Text,txtTotal.Text);
           LblMsg.Text = msg;
           LblMsg.ForeColor = System.Drawing.Color.Green;

        }

      
    }
}
