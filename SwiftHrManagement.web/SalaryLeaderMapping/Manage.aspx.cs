using System;
using System.Data;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.SalaryLeaderMapping
{
    public partial class Manage : BasePage
    {
        clsDAO _clsDao = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            _clsDao = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownList();
                if (GetId() > 0)
                {
                    PopulateSalaryLedgerMapping();
                }
                
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 88) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        private void PopulateDropDownList()
        {
            PopulateBranchName();
            PopulateHeadName();
        }
        private void PopulateBranchName()
        {
            _clsDao.CreateDynamicDDl(DdlBranchName, "select BRANCH_ID, BRANCH_NAME from Branches order by BRANCH_NAME", "BRANCH_ID", "BRANCH_NAME", "", "All");
        }
        private void PopulateHeadName()
        {
            _clsDao.CreateDynamicDDl(DdlHeadName, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE TYPE_ID IN (36,37,38,40,41,58,21,102)", "ROWID", "DETAIL_TITLE", "", "Select");
        }
        private void PopulateSalaryLedgerMapping()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("EXEC [ProcManageSalaryLedgerMapping] 's',"+filterstring(GetId().ToString())+"").Tables[0];
            
            foreach (DataRow dr in dt.Rows)
            {
                DdlBranchName.SelectedValue = dr["Branch_ID"].ToString();
                DdlHeadName.SelectedValue = dr["Head_ID"].ToString();
                txtAccName.Text = dr["Ledger_Name"].ToString();
                txtAccNumber.Text = dr["Ledger_Number"].ToString();
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageSalaryLeadgerMapping();
                Response.Redirect("List.aspx");
            }
            catch
            {
                lblmsg.Text = "Error in Insertion!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void ManageSalaryLeadgerMapping()
        {
            long id = GetId();
            if (id > 0)
            {
                _clsDao.runSQL("EXEC [ProcManageSalaryLedgerMapping] 'u',"+filterstring(id.ToString())+"," + filterstring(DdlBranchName.Text) + ","
                    +" " + filterstring(DdlHeadName.Text) + "," + filterstring(txtAccName.Text) + "," + filterstring(txtAccNumber.Text) + ","
                    +" " + filterstring(ReadSession().UserName) + "");
            }
            else
            {
                _clsDao.runSQL("EXEC [ProcManageSalaryLedgerMapping] 'i',null," + filterstring(DdlBranchName.Text) + "," + filterstring(DdlHeadName.Text) + ","
                    + " " + filterstring(txtAccName.Text) + "," + filterstring(txtAccNumber.Text) + "," + filterstring(ReadSession().UserName) + "");
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
