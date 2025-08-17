using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Report.PayRollReport.HeadWise
{
    public partial class ManageReprot : BasePage
    {
        clsDAO _clsDao = null;
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        public ManageReprot()
        {

            _clsDao = new clsDAO();
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            getCurrPage();
            loadReport();
            
        }
        private void loadReport()
        {


            Populatedata();
            string FY = Request.QueryString["FY"] == null ? "" : Request.QueryString["FY"].ToString();
            string branchId = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string deptId = Request.QueryString["deptId"] == null ? "" : Request.QueryString["deptId"].ToString();
            string flag = Request.QueryString["flag"] == null ? "" : Request.QueryString["flag"].ToString();
            string rptType = Request.QueryString["rptType"] == null ? "" : Request.QueryString["rptType"].ToString();


            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblBranchName.Text = _clsDao.GetSingleresult("select BRANCH_NAME from Branches where BRANCH_ID=" + filterstring(branchId) + "");
            this.lblDeptName.Text = _clsDao.GetSingleresult("select DEPARTMENT_NAME from Departments where DEPARTMENT_ID=" + filterstring(deptId) + "");
            if (flag == "h")
            {
                this.lblReport.Text = _clsDao.GetSingleresult("select detail_title from StaticDataDetail where rowid=" + rptType + "");
            }
            else
            {
                this.lblReport.Text = rptType;
            }
            
              DataTable dt = null;
            if (rptType == "cit")
            {
                dt = _clsDao.getDataset("Exec [procYearlyCIT] @flag='a',@year=" +filterstring(FY) + ",@brach=" +filterstring(branchId)+ ",@dept=" +filterstring(deptId)).Tables[0];
               

            }
            else if (rptType == "epf")
            {
                dt = _clsDao.getDataset("Exec [procYearlyPF] @flag='a',@year=" +filterstring(FY) + ",@brach=" +filterstring( branchId) + ",@dept=" +filterstring( deptId)).Tables[0];

            }
            else if (rptType == "tax")
            {
                dt = _clsDao.getDataset("Exec [procYearlyTax] @flag='a',@year=" +filterstring(FY) + ",@brach=" +filterstring(branchId) + ",@dept=" +filterstring(deptId)).Tables[0];
            }
            else if (rptType == "650")
            {
                dt = _clsDao.getDataset("Exec [ProcYearlyOverTime] @flag='a',@year=" + filterstring(FY) + ",@brach=" + filterstring(branchId) + ",@dept=" + filterstring(deptId) + ",@headid=" + filterstring(rptType)).Tables[0];
            }
            else
            {
                dt = _clsDao.getDataset("Exec [ProcYearlyPayable] @flag='a',@year=" + filterstring(FY) + ",@brach=" + filterstring(branchId) + ",@dept=" + filterstring(deptId) + ",@headid=" + filterstring(rptType)).Tables[0];
            }

            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i <= 1)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + ShowDecimal(dr[i].ToString()) + "</td>");
                    }
                    
                }


                str.Append("</tr>");
            }


            str.Append("</table>");
            rptDiv.InnerHtml = str.ToString();
        }
        private void Populatedata()
        {
            string fiscalyear = Request.QueryString["FY"] == null ? "" : Request.QueryString["FY"].ToString();
            string branchid = Request.QueryString["branchId"] == null ? "" : Request.QueryString["branchId"].ToString();
            string detpid = Request.QueryString["deptId"] == null ? "" : Request.QueryString["deptId"].ToString();
            string rptType = Request.QueryString["rptType"] == null ? "" : Request.QueryString["rptType"].ToString();

            LblFiscalyear.Text = fiscalyear;
            lblReport.Text = rptType.ToUpper();

            if (fiscalyear == "")
            {
                fiscalyear = "0";
            }
            if (branchid == "")
            {
                branchid = "0";
            }
            if (detpid == "")
            {
                detpid = "0";
            }

            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("select dbo.[GetBranchName](" + branchid + ") as branch,dbo.GetDeptName(" + detpid + ") as dept").Tables[0];

                LblFiscalyear.Text = fiscalyear;
                foreach (DataRow dr in dt.Rows)
                {
                    lblBranchName.Text = dr["branch"].ToString();
                    lblDeptName.Text = dr["dept"].ToString();                 
                }

                if (fiscalyear == "0")
                    LblFiscalyear.Text = "ALL";

                if (branchid == "0")
                    lblBranchName.Text = "ALL";

                if (detpid == "0")
                    lblDeptName.Text = "ALL";
        }
        string getCurrPage()
        {
            string raw = Request.RawUrl.ToString();
            int pos = raw.IndexOf('?');
            if (pos > 0)
                raw = raw.Substring(0, pos);
            return raw;
        }
    }
}
