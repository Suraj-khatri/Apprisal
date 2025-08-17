using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
namespace SwiftAssetManagement.AssetAcquisition.BillDetail
{
    public partial class ManageBill : BasePage
    {
        ClsDAOInv _Clsdao = null;
        public ManageBill()
        {
            _Clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateDdlBranch();
                if (GetBillid() > 0)
                {
                    PopulateBillinfo();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }
            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private long GetBillid()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private void PopulateDdlBranch()
        {
            _Clsdao.CreateDynamicDDl(DdlBranch, "select BRANCH_ID, BRANCH_NAME from Branches with (nolock)", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }
        private void PopulateBillinfo()
        {
            if(!IsPostBack)
            {
                DataTable dt = _Clsdao.getTable("select bill_no, bill_date, c.CUSTOMERNAME + '-' + c.CUSTOMERCODE + '|' + convert(varchar,c.ID) as CUST_NAME, "
                + " vendor_id, bill_amt, branch_id,narration from ASSET_BILL inner join Customer c on ASSET_BILL.vendor_id = c.ID where ASSET_BILL.id = " + filterstring(GetBillid().ToString()) + "");
                foreach(DataRow dr in dt.Rows)
                {
                    TxtBillno.Text = dr["bill_no"].ToString();
                    DdlBranch.Text = dr["branch_id"].ToString();
                    TxtVendor.Text = dr["CUST_NAME"].ToString();
                    HdnVendor.Value = dr["vendor_id"].ToString();
                    TxtBillAmount.Text = dr["bill_amt"].ToString();
                    TxtBillDate.Text = dr["bill_date"].ToString();
                    TxtNarration.Text = dr["narration"].ToString();
                }
            }
        }
        private void Managebill()
        {
            string strflag = "";
            long id = GetBillid();
            if (id > 0)
                strflag = "u";
            else
                strflag = "i";

            _Clsdao.runSQL("exec proc_Asset_Bill '"+ strflag +"', "+ id +",'"+ ReadSession().Emp_Id +"',"+filterstring(TxtBillno.Text)+","+filterstring(TxtBillDate.Text) +""
            + ", "+ filterstring(HdnVendor.Value) +","+ filterstring(TxtBillAmount.Text) +","+ filterstring(DdlBranch.Text) +","+filterstring(TxtNarration.Text)+"");
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Managebill();
                Response.Redirect("ListBillDetail.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void DeleteBillInfo()
        {
            _Clsdao.runSQL("delete from ASSET_BILL where  id = "+ filterstring(GetBillid().ToString()) +"");
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteBillInfo();
                Response.Redirect("ListBillDetail.aspx");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}
