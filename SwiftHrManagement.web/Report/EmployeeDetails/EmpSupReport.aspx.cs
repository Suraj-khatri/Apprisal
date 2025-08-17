using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.CompInfo;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.BranchDao;

namespace SwiftHrManagement.web.Report.EmployeeDetails
{
    public partial class EmpSupReport :  BasePage
    {
        CompanyDAO _company = null;
        CompanyCore _CompanyCore = null;
        clsDAO _clsDAO = null;
        public EmpSupReport()
        {
            this._company = new CompanyDAO();
            this._CompanyCore = new CompanyCore();
            this._clsDAO = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string flag = Request.QueryString["flag"].ToString() == "" ? "null" : Request.QueryString["flag"].ToString();
                if (flag == "n")
                {
                    OnNewReport();
                }
                else
                {
                    OnOldReport();
                }
            }
        }
        private void OnOldReport()
        {
            StringBuilder str1 = new StringBuilder("<div class=\"table-responsive col-md-12\" style=\"wodth:auto\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblPrintDate.Text = DateTime.Now.ToLongDateString();

            string branch_id = Request.QueryString["branch_id"].ToString() == "" ? "null" : Request.QueryString["branch_id"].ToString();
            string dept_id = Request.QueryString["dept_id"].ToString() == "" ? "null" : Request.QueryString["dept_id"].ToString();
           
            DataTable dt1=new DataTable();      
            dt1 = _clsDAO.getDataset("Exec [procSuperVisorRpt] @FLAG='A',@BRANCH_ID=" + filterstring(branch_id) + ",@DEPT_ID=" + filterstring(dept_id) + "").Tables[0];
          
            
            int cols1 = dt1.Columns.Count;

            foreach (DataRow dr in dt1.Rows)
            {
               
                for (int i = 0; i < cols1; i++)
                {
                    DataTable dt = _clsDAO.getDataset("Exec [procSuperVisorRpt] @FLAG='B',@EMP_ID=" + filterstring(dr[i].ToString()) + "").Tables[0];

                    int cols = dt.Columns.Count;

                    str1.Append("<tr>");
                    str1.Append("<th align=\"left\" colspan=\""+cols+"\">" + dr[i + 1].ToString() + "</th>");
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
        private void OnNewReport()
        {
            StringBuilder str = new StringBuilder("<div class=\"table-responsive col-md-10 col-md-offset-1\" style=\"wodth:auto\" align=\"center\"> <table class=\"table table-bordered table-striped table-condensed\">");

            _CompanyCore = _company.FindCompany();
            this.lblHeading.Text = _CompanyCore.Name;
            this.lbldesc.Text = _CompanyCore.Address;
            this.lblPrintDate.Text = DateTime.Now.ToLongDateString();

            string branch_id = Request.QueryString["branch_id"].ToString() == "" ? "null" : Request.QueryString["branch_id"].ToString();
            string dept_id = Request.QueryString["dept_id"].ToString() == "" ? "null" : Request.QueryString["dept_id"].ToString();

            DataTable dt = _clsDAO.getTable("Exec [procSuperVisorRpt] @FLAG='C',@BRANCH_ID=" + filterstring(branch_id) + ",@DEPT_ID=" + filterstring(dept_id) + "");


            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 1; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 1; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");                    
                }
                str.Append("</tr>");
            }
            str.Append("</table></div>");
            rptDiv.InnerHtml = str.ToString();
        }

    }
}
