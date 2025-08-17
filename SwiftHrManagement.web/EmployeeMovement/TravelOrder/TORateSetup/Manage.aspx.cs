using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.EmployeeMovement.TravelOrder.TORateSetup
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        clsDAO _clsDao = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 180) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetId() > 0)
                {
                    populateData();
                    BtnDelete.Visible = true;
                }
                else
                {
                    populateDdl();
                }
            }

            txtRate.Attributes.Add("OnBlur", "checknumber(this);");
        }

        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void populateDdl()
        {
            _clsDao.CreateDynamicDDl(ddlPost, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=4", "ROWID", "DETAIL_DESC", "", "Select");
            _clsDao.CreateDynamicDDl(ddlPlace, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=3", "ROWID", "DETAIL_TITLE", "", "Select");
            _clsDao.CreateDynamicDDl(ddlAllowance, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=64", "ROWID", "DETAIL_TITLE", "", "Select");
            _clsDao.CreateDynamicDDl(ddlCurrency, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=72", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        private void populateData()
        {
            string sql = "Exec [proc_travelOrderRate] @flag='s',@travelRateId=" + filterstring(GetId().ToString());
            DataTable dt = _clsDao.getTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                txtRate.Text = ShowDecimal(dr["rate"].ToString());

                _clsDao.setDDL(ref ddlPost, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=4", "ROWID", "DETAIL_DESC", dr["position"].ToString(), "Select");
                _clsDao.setDDL(ref ddlPlace, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=3", "ROWID", "DETAIL_TITLE", dr["place"].ToString(), "Select");
                _clsDao.setDDL(ref ddlAllowance, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=64", "ROWID", "DETAIL_TITLE", dr["allowanceType"].ToString(), "Select");
                _clsDao.setDDL(ref ddlCurrency, "select ROWID,DETAIL_TITLE,DETAIL_DESC from StaticDataDetail where TYPE_ID=72", "ROWID", "DETAIL_TITLE", dr["currency"].ToString(), "Select");
            }
        }

        private void resetFields()
        {
            ddlPost.Text = "";
            ddlPlace.Text = "";
            ddlCurrency.Text = "";
            ddlAllowance.Text = "";
            txtRate.Text = "";
        }
            

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GetId() > 0)
            {
                _clsDao.GetSingleresult("Exec [proc_travelOrderRate] @flag='u',@place=" + filterstring(ddlPlace.Text) + ",@position=" + filterstring(ddlPost.Text)
                                    + ",@rate=" + filterstring(txtRate.Text) + ",@allowanceType=" + filterstring(ddlAllowance.Text) + ",@currency=" + filterstring(ddlCurrency.Text)
                                    + ",@modifiedBy=" + filterstring(ReadSession().UserName.ToString()) + ",@travelRateId=" + filterstring(GetId().ToString()));
                Response.Redirect("List.aspx");
            }
            else 
                LblMsg.Text = _clsDao.GetSingleresult("Exec [proc_travelOrderRate] @flag='i',@place=" + filterstring(ddlPlace.Text) + ",@position=" + filterstring(ddlPost.Text)
                                    + ",@rate=" + filterstring(txtRate.Text) + ",@allowanceType=" + filterstring(ddlAllowance.Text) + ",@currency=" + filterstring(ddlCurrency.Text)
                                    + ",@createdBy=" + filterstring(ReadSession().UserName.ToString()) + "");
                resetFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("Exec [proc_travelOrderRate] @flag='d',@travelRateId=" + filterstring(GetId().ToString()));
            Response.Redirect("List.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
       
    }
}
