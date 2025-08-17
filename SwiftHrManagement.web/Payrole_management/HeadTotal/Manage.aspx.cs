using System;
using System.Data;
using System.Text;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.CompInfo;

namespace SwiftHrManagement.web.Payrole_management.HeadTotal
{
    public partial class Manage : BasePage
    {
        clsDAO Clsdao = null;
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        CompanyDAO _companyDao = new CompanyDAO();
        CompanyCore _CompanyCore = null;
        string company_Name = "";

        public Manage()
        {
            Clsdao = new clsDAO();
            this._CompanyCore = new CompanyCore();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 257) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDdl();
            }
        }

        private void PopulateDdl()
        {
            Clsdao.CreateDynamicDDl(fiscalYear, "exec proc_gradeIncrement @flag='FY'", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            fiscalYear.SelectedValue = Clsdao.GetSingleresult("exec proc_gradeIncrement @flag='DFY'");
            Clsdao.CreateDynamicDDl(month, "select Name,Month_Number from MonthList", "Month_Number", "Name", "", "Select");
        }

        private string returnmonthname(int month)
        {
            string monthname = "";
            monthname = Clsdao.GetSingleresult("select Name from MonthList where Month_Number=" + month + "");
            return monthname;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //form.Visible = false;
            report.Visible = true;
            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            DataTable dt = Clsdao.getTable("Exec proc_HeadTotal 'a',@fiscalYear="+ filterstring(fiscalYear.Text)+",@runMonth="+filterstring(month.Text)+"");
            int cols = dt.Columns.Count;
            _CompanyCore = _companyDao.FindCompany();
            company_Name = _CompanyCore.Name;

            str.Append("<tr>");
            str.Append("<th class=\"text-center\" colspan=\"" + cols + 1 + "\"\">" + company_Name + "<br /> Head Total for the month of " + returnmonthname(int.Parse(month.Text)) + "</th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<th>S.N.</th>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            int sno = 1;
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + sno + "</td>");
                for (int i = 0; i < cols; i++)
                {
                    if(i>=2)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }
                    
                }
                str.Append("</tr>");
                sno = sno + 1;
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
            			
        }

        protected void BtnSearchTrial_Click(object sender, EventArgs e)
        {
            //form.Visible = false;
            report.Visible = true;

            StringBuilder str = new StringBuilder("<table width=\"100%\" class=\"table table-bordered table-striped table-condensed\" class=\"text-center\">");
            DataTable dt = Clsdao.getTable("Exec proc_HeadTotalTrial 'a',@fiscalYear=" + filterstring(fiscalYear.Text) + ",@runMonth=" + filterstring(month.Text) + "");
            int cols = dt.Columns.Count;
            _CompanyCore = _companyDao.FindCompany();
            company_Name = _CompanyCore.Name;

            str.Append("<tr>");
            str.Append("<th class=\"text-center\" colspan=\"" + cols + 1 + "\"\">" + company_Name + "<br /> Head Total for the month of " + returnmonthname(int.Parse(month.Text)) + "</th>");
            str.Append("</tr>");
            str.Append("<tr>");
            str.Append("<th>S.N.</th>");
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th>" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            int sno = 1;
            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                str.Append("<td align=\"left\">" + sno + "</td>");
                for (int i = 0; i < cols; i++)
                {
                    if (i >= 2)
                    {
                        str.Append("<td class=\"text-right\">" + ShowDecimal(row[i].ToString()) + "</td>");
                    }
                    else
                    {
                        str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");
                    }

                }
                str.Append("</tr>");
                sno = sno + 1;
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();
        }
        
    }
}