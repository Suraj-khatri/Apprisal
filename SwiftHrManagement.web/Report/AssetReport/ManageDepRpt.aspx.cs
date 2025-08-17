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

namespace SwiftHrManagement.web.Report.AssetReport
{
    public partial class ManageDepRpt : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = new RoleMenuDAOInv();
        ClsDAOInv _clsdao = new ClsDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 149) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropDownList();               
            }
        }

        private void PopulateDropDownList()
        {
            if (ReadSession().UserType == "A")
            {
                _clsdao.CreateDynamicDDl(DdlBranchName2, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "ALL");
                _clsdao.CreateDynamicDDl(ddlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "ALL");
                _clsdao.CreateDynamicDDl(DdlBranchName1, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "ALL");
                _clsdao.CreateDynamicDDl(DdlBranchName3, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "ALL");
            }
            else
            {
                _clsdao.CreateDynamicDDl(DdlBranchName2, "select BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
                _clsdao.CreateDynamicDDl(ddlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
                _clsdao.CreateDynamicDDl(DdlBranchName3, "select BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
                _clsdao.CreateDynamicDDl(DdlBranchName1, "select BRANCH_ID, BRANCH_NAME from Branches WHERE BRANCH_ID=" + ReadSession().Branch_Id + " order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "SELECT");
            }
            _clsdao.CreateDynamicDDl(ddlFY, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            ddlFY.SelectedValue = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            _clsdao.CreateDynamicDDl(ddlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "All");

            _clsdao.CreateDynamicDDl(ddlFY1, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            ddlFY1.SelectedValue = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");            
            _clsdao.CreateDynamicDDl(ddlGroupName, "select id,item_name from ASSET_ITEM where id in(select distinct(parent_id) from ASSET_ITEM where is_product='1')", "id", "item_name", "", "Select");

            _clsdao.CreateDynamicDDl(ddlFY2, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            ddlFY2.SelectedValue = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");           
        }

        protected void BtnDepRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("depGroupWiseRpt.aspx?fy=" + ddlFY.Text + "&month=" + ddlMonth.Text + "&branch=" + DdlBranchName2.Text);
        }

        protected void BtnDetailRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("depSummaryRpt.aspx?fy=" + ddlFY.Text + "&month=" + ddlMonth.Text + "&branch=" + DdlBranchName2.Text);
        }

        protected void BtnSearchRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("depMonthlyRpt.aspx?fy=" + ddlFY1.Text + "&group=" + ddlGroupName.Text + "&branch=" + ddlBranchName.Text);
        }

        protected void BtnSearchRptGrp_Click(object sender, EventArgs e)
        {
            Response.Redirect("depGroupWiseMonthlyRpt.aspx?fy=" + ddlFY2.Text + "&branch=" + DdlBranchName1.Text);
        }

        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportExceldepMonthlyRpt.aspx?fy=" + ddlFY1.Text + "&group=" + ddlGroupName.Text + "&branch=" + ddlBranchName.Text);
        }

        protected void BtnExport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExportExceldepSummaryRpt.aspx?fy=" + ddlFY.Text + "&month=" + ddlMonth.Text + "&branch=" + DdlBranchName2.Text);
        }

        protected void BtnSearchTot_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssetSummaryBranchWise.aspx?branch=" + DdlBranchName3.Text);
        }
    }
}
