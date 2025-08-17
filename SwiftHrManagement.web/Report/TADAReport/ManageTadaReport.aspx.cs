using System;


namespace SwiftHrManagement.web.Report.TADAReport
{
    public partial class ManageTadaReport:BasePage
    {
        private clsDAO ClsDao = null;

        public ManageTadaReport()
        {
            ClsDao=new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                PopulateData();
            }
        }

        private void PopulateData()
        {
            ClsDao.CreateDynamicDDl(ddlBranch,"Select branch_id,branch_name from branches","branch_id","branch_name","","Select");
            ClsDao.CreateDynamicDDl(ddlCountry, "select countriesId,dbo.GetDetailtitle(countriesId)country  from tadaClassificationOfAreas", "countriesId", "country", "", "Select");
            ClsDao.CreateDynamicDDl(ddlTravel, "EXEC ProcStaticDataView 's','99'", "Rowid", "DETAIL_TITLE", "", "Select");
            ClsDao.CreateDynamicDDl(DdlStatus, "select  distinct tada_status  from tada", "tada_status", "tada_status", "", "Select");
            ClsDao.CreateDynamicDDl(DdlreimStatus, "select  distinct status_tr   from  tadaReimbersement", "status_tr", "status_tr", "", "Select");
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";
            hdnempId.Value = filterstring(getEmpIdfromInfo(lblEmpName.Text));
            this.ddlBranch.Enabled = false;
            this.ddlDepartment.Enabled = false;
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }

        protected void BtnView_Report(object sender, EventArgs e)
        {
            Response.Redirect("TADASummaryReport.aspx?empId="+this.hdnempId.Value+ "&branchId="+this.ddlBranch.Text+"&deptId="+this.ddlDepartment.Text+
                               "&destination="+this.ddlCountry.Text+"&reasonTravel="+this.ddlTravel.Text+"&status="+this.DdlStatus.Text+
                               "&reimstatus="+this.DdlreimStatus.Text+"&fromdate="+this.txtfromdate.Text+"&todate="+this.txttodate.Text);
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClsDao.CreateDynamicDDl(ddlDepartment, "select branch_id,department_id,department_name from departments where branch_id=" + filterstring(this.ddlBranch.Text)+"", "department_id", "department_name", "", "Select");
        }
    }
}