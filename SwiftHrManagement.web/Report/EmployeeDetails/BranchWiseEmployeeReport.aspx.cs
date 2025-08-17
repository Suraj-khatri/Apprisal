using System;
using System.Text;
using System.Data;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;


namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class BranchWiseEmployeeReport : BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        ClsDAOInv _clsDAO = null;

        public BranchWiseEmployeeReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDAO = new ClsDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblDate.Text = DateTime.Now.ToLongDateString();

            DataTable dt1 = _clsDAO.getDataset("SELECT BRANCH_ID,BRANCH_NAME+' ('+BRANCH_SHORT_NAME+')' BRANCH_NAME FROM Branches ORDER BY BRANCH_ID").Tables[0];
            int cols1 = dt1.Columns.Count;
            foreach (DataRow dr in dt1.Rows)
            {
               
                for (int i = 0; i < cols1; i++)
                {


                    DataTable dt = _clsDAO.getDataset("select EMP_CODE [EMP CODE],dbo.GetEmployeeFullNameOfId(EMPLOYEE_ID)NAME,convert(varchar, BIRTH_DATE,107) [DOB], convert(varchar,APPOINTMENT_DATE,107) [APPOINT DATE]"
                                +" ,Sdd.DETAIL_DESC POSITION, Sdd1.DETAIL_DESC [Designation],Sdd2.DETAIL_DESC [EMP TYPE], DBO.GetBranchName(BRANCH_ID) [BRANCH],DBO.GetDeptName(DEPARTMENT_ID) [DEPARTMENT] "
                                +" from Employee E"
                                +" left Join StaticDataDetail Sdd on e.POSITION_ID=Sdd.ROWID"
                                +" left Join StaticDataDetail Sdd1 on E.FUNCTIONAL_TITLE=Sdd1.ROWID"
                                + " left Join StaticDataDetail Sdd2 on E.EMP_TYPE=Sdd2.ROWID"
                                +" where BRANCH_ID in (select BRANCH_ID from Branches)"
                                + " AND EMPLOYEE_ID<>1000 AND e.EMP_Status='458' AND BRANCH_ID=" + filterstring(dr[i].ToString()) + " order by e.EMP_TYPE,EMP_CODE").Tables[0];

                    int cols = dt.Columns.Count;

                    str1.Append("<tr>");
                    str1.Append("<th align=\"left\" colspan=\""+cols+"\">" + dr[i + 1].ToString().ToUpper() + "</th>");
                    str1.Append("</tr>");

                    str1.Append("<tr>");
                    for (int l = 0; l < cols; l++)
                    {
                        str1.Append("<th align=\"center\">" + dt.Columns[l].ColumnName.ToUpper() + "</th>");
                    }
                    str1.Append("</tr>");

                    foreach (DataRow dr1 in dt.Rows)
                    {
                        str1.Append("<tr>");
                        for (int j = 0; j < cols; j++)
                        {
                            str1.Append("<td align=\"left\">" + dr1[j].ToString() + "</td>");
                        }
                        str1.Append("</tr>");
                    }
                    i++;
                }                
            }

            str1.Append("</table></div>");
            rptDiv.InnerHtml = str1.ToString();
        }
    }
}
