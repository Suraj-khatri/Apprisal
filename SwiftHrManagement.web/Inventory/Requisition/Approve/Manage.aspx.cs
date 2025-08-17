using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.web;
using SwiftHrManagement.DAL.Role;

namespace SwiftAssetManagement.Inventory.Requisition.Approve
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;
        public Manage()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 122) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (GetRequisitionId() > 0)
                    PopulateReqQuantity();
                getcompinfo();
            }
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }
        private long GetRequisitionId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        private long GetAppId()
        {
            return (Request.QueryString["msgid"] != null ? long.Parse(Request.QueryString["msgid"].ToString()) : 0);
        }
        private void getcompinfo()
        {
            LblBranchDept.Text = _clsdao.GetSingleresult("select b.BRANCH_NAME + '(' +convert(varchar,(ir.branch_id)) + ')' + '  ' + d.DEPARTMENT_NAME +  ' (' + convert(varchar,(ir.dept_id)) + ')' "
            + "from IN_Requisition_Message ir inner join Branches b on ir.branch_id = b.BRANCH_ID inner join Departments d on ir.dept_id = d.DEPARTMENT_ID"
            + " where ir.id=" + GetAppId() + "");
        }
        private long GetMsgId()
        {
            return (Request.QueryString["msgid"] != null ? long.Parse(Request.QueryString["msgid"].ToString()) : 0);
        }
        //msgid
        private void managerequisition()
        {
            _clsdao.runSQL("exec [proc_Requisition] 'u',@quantity=" + filterstring(TxtAppQuantity.Text) + ",@id="+ filterstring(GetRequisitionId().ToString()) +"");
        }
        private void PopulateReqQuantity()
        {
            DataTable dt = _clsdao.getTable("select ir.quantity, ir.Approved_Quantity,p.product_desc from IN_Requisition ir, IN_PRODUCT p "
            + " where ir.item = p.id and ir.id = " + GetRequisitionId() + "");
            foreach (DataRow dr in dt.Rows)
            {
                TxtReqQuantity.Text = dr["quantity"].ToString();
                Product.Text = dr["product_desc"].ToString();
                TxtAppQuantity.Text = dr["Approved_Quantity"].ToString();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                managerequisition();
                Response.Redirect("/Inventory/Requisition/Approve/List.aspx?id=" + GetMsgId() + "");
            }
            catch
            {
                LblMsg.Text = "Error In Operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
