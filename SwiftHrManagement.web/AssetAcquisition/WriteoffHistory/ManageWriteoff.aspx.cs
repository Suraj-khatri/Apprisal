using System;
using System.Data;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.AssetAcquisition.WriteoffHistory
{
    public partial class ManageWriteoff : BasePage
    {
        private ClsDAOInv _clsdao = null;
        private RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();

        public ManageWriteoff()
        {
            _clsdao = new ClsDAOInv();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 197) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                txtRejectionReason.Enabled = false;
                populateForwardedTo();
                if (ReadSession().UserType == "A")
                {
                    AutoCompleteExtender3.ContextKey = "null";
                }
                else
                {
                    AutoCompleteExtender3.ContextKey = ReadSession().Branch_Id.ToString();
                }
                if (GetId() > 0)
                {
                    populateWriteoffDetails();
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void populateForwardedTo()
        {
            _clsdao.CreateDynamicDDl(ddlForwarded_to,
                                     "exec proc_GetSupervisorFA @flag='a',@empId=" +
                                     filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "Name", "",
                                     "Select");

        }

        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void populateWriteoffDetails()
        {
            DataTable dt = new DataTable();
            dt =
                _clsdao.getDataset("EXEC procManageAssetWriteoffRequest @flag='s',@id=" +
                                   filterstring(GetId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                TxtAssetNumber.Text = dr["asset_number"].ToString();
                TxtBookvalue.Text = dr["book_value"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAccDepn.Text = dr["acc_depriciation"].ToString();
                txtLocation.Text = dr["branch_id"].ToString();
                txtAssetNarration.Text = dr["asset_narration"].ToString();
                TxtwriteoffDate.Text = dr["write_off_date"].ToString();
                ddlForwarded_to.SelectedValue = dr["forwarded_to"].ToString();
                TxtNarration.Text = dr["narration"].ToString();
                txtRejectionReason.Text = dr["rejection_reason"].ToString();
                txtScrapValue.Text = dr["Scrap_Value"].ToString();
                txtNetProfitLoss.Text = dr["Net_Profit_Loss"].ToString();
                HdnAssetnumber.Value = dr["id"].ToString();
                TxtBookvalue.Enabled = false;
                txtPurchaseValue.Enabled = false;
                txtAssetNarration.Enabled = false;
            }
        }

        private void getbookvalue()
        {
            DataTable dt = new DataTable();
            dt =
                _clsdao.getDataset("exec procManageAssetWriteoffRequest @flag='a',@asset_id=" +
                                   filterstring(HdnAssetnumber.Value) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                TxtBookvalue.Text = dr["Book_Value"].ToString();
                txtPurchaseValue.Text = dr["purchase_value"].ToString();
                txtAccDepn.Text = dr["acc_depreciation"].ToString();
                txtLocation.Text = dr["branch_id"].ToString();
                txtAssetNarration.Text = dr["narration"].ToString();
                TxtBookvalue.Enabled = false;
                txtPurchaseValue.Enabled = false;
                txtAssetNarration.Enabled = false;
            }
        }

        private void manage()
        {
            string procFlag = "";
            if (GetId() > 0)
            {
                procFlag = "u";
            }
            else
            {
                procFlag = "i";
            }
            _clsdao.runSQL("exec procManageAssetWriteoffRequest @flag=" + filterstring(procFlag) + ",@id=" +
                           filterstring(GetId().ToString()) + ","
                           + " @user=" + filterstring(ReadSession().Emp_Id.ToString()) + ",@asset_id=" +
                           filterstring(HdnAssetnumber.Value) + ","
                           + " @writeoff_date=" + filterstring(TxtwriteoffDate.Text) + ",@narration=" +
                           filterstring(TxtNarration.Text) + ","
                           + " @forwarded_to=" + filterstring(ddlForwarded_to.Text) + ", @scrapValue=" + 
                           filterstring(txtScrapValue.Text) + ", @netProfitLoss="+filterstring(txtNetProfitLoss.Text));
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                manage();
                Response.Redirect("requestedList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void HdnAssetnumber_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void TxtAssetNumber_TextChanged(object sender, EventArgs e)
        {
            if (HdnAssetnumber.Value != "")
                getbookvalue();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                delete();
                Response.Redirect("requestedList.aspx");
            }
            catch
            {
                LblMsg.Text = "Error in Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void delete()
        {
            _clsdao.runSQL("exec procManageAssetWriteoffRequest @flag = 'd', @id = " + filterstring(GetId().ToString()));
        }

        protected void txtScrapValue_TextChanged(object sender, EventArgs e)
        {
            double GainLoss;
            string bookVal;
            bookVal = _clsdao.GetSingleresult("EXEC procManageAssetWriteoffRequest @flag='z',@id=" +
                                                     filterstring(HdnAssetnumber.Value) + "");
            GainLoss = double.Parse(txtScrapValue.Text) - double.Parse(bookVal);
            txtNetProfitLoss.Text = GainLoss.ToString();
        }
    }
}
