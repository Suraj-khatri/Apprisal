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
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Report.InventoryReport
{
    public partial class ManageReport : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = null;       
        public ManageReport()
        {
            _clsdao = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 151) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDdl();
            }
        }
        private void PopulateDdl()
        {
            if (ReadSession().UserType == "A")
            {
                _clsdao.CreateDynamicDDl(DdlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "ALL");
                _clsdao.CreateDynamicDDl(DdlBranchName1, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(DdlBranchName2, "select BRANCH_ID, BRANCH_NAME from Branches with(nolock) order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
            }
            else
            {
                _clsdao.CreateDynamicDDl(DdlBranchName, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "ALL");
                _clsdao.CreateDynamicDDl(DdlBranchName1, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
                _clsdao.CreateDynamicDDl(DdlBranchName2, "SELECT BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "" + ReadSession().Branch_Id + "", "SELECT");
            }

            _clsdao.CreateDynamicDDl(DdlGroupName, "SELECT id,item_name FROM IN_ITEM WHERE id IN(SELECT DISTINCT(parent_id) FROM IN_ITEM WHERE is_product='1')", "id", "item_name", "", "SELECT");

            _clsdao.CreateDynamicDDl(DdlGroupName1, "SELECT id,item_name FROM IN_ITEM WHERE id IN(SELECT DISTINCT(parent_id) FROM IN_ITEM WHERE is_product='1')", "id", "item_name", "", "SELECT");



            _clsdao.CreateDynamicDDl(DdlGroupName2, "SELECT id,item_name FROM IN_ITEM WHERE id IN(SELECT DISTINCT(parent_id) FROM IN_ITEM WHERE is_product='1')", "id", "item_name", "", "SELECT");

           


        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/InventoryReport/ViewReport.aspx?ProductGroup="+DdlGroupName.Text+"&Branch="+DdlBranchName.Text+""
            +"&ProductName="+DdlProductName.Text+"");
        }
        protected void Btn_Search_Exp_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/InventoryReport/ViewExpensesReport.aspx?ProductGroup=" + DdlGroupName2.Text + "&Branch=" + DdlBranchName2.Text + ""
            + "&ProductName=" + DdlProductName2.Text + "&from_date="+txtFromDate1.Text+"&to_date="+txtToDate1.Text+"");
        }

        protected void DdlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlProductName.Items.Clear();
            if (DdlGroupName.Text != "")
               _clsdao.CreateDynamicDDl(DdlProductName, "select id,porduct_code from IN_PRODUCT where item_id in(select id from IN_ITEM where parent_id='" + DdlGroupName.Text + "')", "id", "porduct_code", "", "Select");
        }

        protected void DdlGroupName1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlProductName1.Items.Clear();
            if (DdlGroupName1.Text != "")
                _clsdao.CreateDynamicDDl(DdlProductName1, "select id,porduct_code from IN_PRODUCT where item_id in(select id from IN_ITEM where parent_id='" + DdlGroupName1.Text + "')", "id", "porduct_code", "", "Select");
        }

        protected void DdlGroupName2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DdlProductName2.Items.Clear();
            if (DdlGroupName2.Text != "")
                _clsdao.CreateDynamicDDl(DdlProductName2, "select id,porduct_code from IN_PRODUCT where item_id in(select id from IN_ITEM where parent_id='" + DdlGroupName2.Text + "')", "id", "porduct_code", "", "Select");
        }

        protected void BtnSummaryRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/InventoryReport/ViewGroupWiseSummaryRpt.aspx?group_id=" + DdlGroupName1.Text + "&branch_id=" + DdlBranchName1.Text + ""
                + "&product_id=" + DdlProductName1.Text + "&from_date="+txtFromDate.Text+"&to_date="+txtToDate.Text+"");
        }

        protected void BtnExportSummaryRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Report/InventoryReport/ExportViewGroupWiseSummaryRpt.aspx?group_id=" + DdlGroupName1.Text + "&branch_id=" + DdlBranchName1.Text + ""
                + "&product_id=" + DdlProductName1.Text + "&from_date=" + txtFromDate.Text + "&to_date=" + txtToDate.Text + "");
        }      
    }
}
