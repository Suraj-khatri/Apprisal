using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using System.Text;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Role
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        RoleMenuCore _roleMenuCore = null;
        string menuList = "";
        StringBuilder sb = new StringBuilder("");

        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._roleMenuCore = new RoleMenuCore();
        }
        private void writeMenu(DataTable dt, string group_code, string group_name, int i)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();

            DataRow[] rows = dt.Select("menu_group='" + group_code + "'");
            sb.AppendLine("<div class=\"panel\">");

            if (rows.Length > 0)
            {
                string colId = "col" + i.ToString();
                string id = "hading" + i.ToString();
                sb.AppendLine("<div class=\"panel-heading\" role=\"tab\" id=\""+id+"\">");
                sb.AppendLine("<a class=\"collapsed\" style=\"text-decoration:none; \" role=\"button\" data-toggle=\"collapse\" data-parent=\"#accordion\" href=\"#" + colId + "\" aria-expanded=\"true\" aria-controls=\"" + colId + "\">");
                sb.AppendLine(""+group_name+"");
                sb.AppendLine("</a>");
                sb.AppendLine("<div id=\"" + colId + "\" class=\"panel-collapse collapse\" role=\"tabpanel\" aria-labelledby=\"" + id + "\">");
                sb.AppendLine("<div class=\"panel-body\">");
                sb.AppendLine("<ul style=\"list-style: none;\">");
                foreach (DataRow row in rows)
                {
                    sb.AppendLine("<li class=\"roleborder\">");
                    sb.AppendLine("<div class=\"row \"><div class=\"col-md-10\">");
                    sb.AppendLine("" + row["function_name"].ToString() + "</div>");
                    sb.AppendLine("<div class=\"col-md-2\">");
                    sb.AppendLine("<input type='checkbox' name ='chkMenu' value='" + row["sno"].ToString() + "' " + (row["granted"].ToString() == "1" ? "checked='checked'" : "") + " />");
                    sb.AppendLine("</div></li>");
                }
                sb.AppendLine("</ul>");
                sb.AppendLine("</div></div></div></div>");
            }
            i++;
        }

        private void makeList()
        {
            int i = 1;
            DataTable dt = new DataTable();
            dt = _roleMenuDao.getMeluList_For_Role(DdlRoleList.Text);
            sb.AppendLine("<div class=\"roleSetup\">");
            sb.AppendLine("<div class=\"panel-group\" id=\"accordion\" role=\"tablist\" aria-multiselectable=\"true\">");
            writeMenu(dt, "u", "User Management", i); i++;
            writeMenu(dt, "c", "Company Management", i); i++;
            writeMenu(dt, "e", "Employee Management", i); i++;
            //writeMenu(dt, "app", "Employee Appraisal", i); i++;
            writeMenu(dt, "app_new", "Employee Appraisal", i); i++;
            //writeMenu(dt, "a", "Employee Attendance", i); i++;
            //writeMenu(dt, "lm", "Leave Management", i); i++;
            //writeMenu(dt, "t", "Training Management", i); i++;
            writeMenu(dt, "f", "Employee Movement", i); i++;
            //writeMenu(dt, "r", "Employee Recruitment", i); i++;
            //writeMenu(dt, "cea", "CEA REIMBURSEMENT", i); i++;
            //writeMenu(dt, "mr", "MEDICAL REIMBURSEMENT", i); i++;
            //writeMenu(dt, "pr", "Payroll Management", i); i++;
            writeMenu(dt, "s", "General Data Setting", i); i++;
            //writeMenu(dt, "z", "Summary Report", i); i++;
            //writeMenu(dt, "ot", " Over Time Management ", i); i++;
            //writeMenu(dt, "tr", "Travel Order", i); i++;
            //writeMenu(dt, "m", "Content Management", i); i++;

            //writeMenu(dt, "w", "Work Flow Management", i); i++;

            //writeMenu(dt, "prd_mgmt", "Inventory Management", i); i++;
            //writeMenu(dt, "vou", "Inventory Purchase", i); i++;
            //writeMenu(dt, "prd_movmt", "Inventory Movement", i); i++;
            //writeMenu(dt, "ass_per", "Assets Parameters", i); i++;
            //writeMenu(dt, "ass_acq", "Assets Acquisition", i); i++;
            //writeMenu(dt, "ass_mgmt", "Assets Management", i); i++;
            //writeMenu(dt, "bill_insr", "Bill & Insurance", i); i++;
            //writeMenu(dt, "repr_main", "Repair & Maintenance", i); i++;
            //writeMenu(dt, "gate_pass", "Gate Pass", i); i++;
            //writeMenu(dt, "rpt", "MIS Reporting", i); i++;
            //writeMenu(dt, "s", " Setup Static Data", i); i++;
            //writeMenu(dt, "lo", " System Logs ", i); i++;
            sb.AppendLine("</div></div>");
            tblMain.InnerHtml = sb.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                makeList();
            }
            _roleMenuDao.hasAccess(ReadSession().AdminId,2);
                prepareDdlRole();
                menuList = Request.Form["chkMenu"];
        }
        private void prepareDdlRole()
        {
            if (!IsPostBack)
            {
                clsDAO CLsDAo = new clsDAO();
                CLsDAo.CreateDynamicDDl(DdlRoleList, "Exec ProcStaticDataView 's','25'", "ROWID", "DETAIL_TITLE", "", "Select");
                DdlRoleList.SelectedIndex = 0;
            }
        }
        private void prepareRole()
        {
            RoleMenuCore _rCore = new RoleMenuCore();
            _rCore.MenuList = menuList;
            _rCore.Role_id = (DdlRoleList.Text.ToString());
            this._roleMenuCore = _rCore;
            this._roleMenuDao.Save(_roleMenuCore);
        }
        private void ManageRole()
        {
            prepareRole();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ManageRole();
                GetStatic.AlertMessage(this, "Role setup successfully!");
            }
            catch(Exception ex)
            {
                GetStatic.AlertMessage(this, "Error in operation!");
                throw ex;
            }
        }

        protected void DdlRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeList();
        }
    }
}
