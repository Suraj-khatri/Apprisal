using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
namespace SwiftAssetManagement.AssetAcquisition.InsuranceDetail
{
    public partial class ManageInsurance : BasePage
    {
        ClsDAOInv _ClsDao = null;
        public ManageInsurance()
        {
            _ClsDao = new ClsDAOInv();
        }
        private void SaveInsuranceDetl()
        {
            string strflag = "";
            long id = GetInsuranceid();
            if (id > 0)
                strflag = "u";
            else
                strflag = "i";
            _ClsDao.runSQL("proc_Asset_Insurance "+ strflag +","+ id +","+ ReadSession().Emp_Id +", "
            + " "+ filterstring(DdlInsurer.Text) +","+ filterstring(TxtInsuredAmount.Text)+","+ filterstring(TxtInsuredDate.Text) +","
            + " "+ filterstring(TxtExpiredDate.Text)+","+ filterstring(TxtNarration.Text) +", "+ DdlBranch.Text +"");
        }
        private void Populateinsurance()
        {
            DataTable dt = _ClsDao.getTable("proc_Asset_Insurance 's',"+ filterstring(GetInsuranceid().ToString())+"");
            foreach (DataRow dr in dt.Rows)
            {
                DdlInsurer.Text = dr["insurer"].ToString();
                TxtInsuredAmount.Text = dr["insured_amt"].ToString();
                DdlBranch.Text = dr["Branch_Id"].ToString();
                TxtInsuredDate.Text = dr["insured_date"].ToString();
                TxtExpiredDate.Text = dr["expiry_date"].ToString();
                TxtNarration.Text = dr["narration"].ToString();
            }
        }
        private long GetInsuranceid()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void PopulateDdl()
        {
            _ClsDao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches with (nolock)", "BRANCH_ID", "BRANCH_NAME", "", "Select");
            _ClsDao.CreateDynamicDDl(DdlInsurer, "select ROWID, DETAIL_TITLE from HRManagement.dbo.StaticDataDetail with (nolock) where TYPE_ID=33", "ROWID", "DETAIL_TITLE", "", "Select");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDdl();
                Populateinsurance();
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveInsuranceDetl();
                Response.Redirect("ListInsuranceDetail.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void deleteinsurance()
        {
            _ClsDao.runSQL("exec procExecuteSQLString 'd' , 'delete from ASSET_INSURENCE' , ' and ID=''" + GetInsuranceid() + "''', '" + ReadSession().Emp_Id + "'");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteinsurance();
                Response.Redirect("ListInsuranceDetail.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
