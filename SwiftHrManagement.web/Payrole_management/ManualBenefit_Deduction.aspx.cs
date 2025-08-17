using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Payrole;


namespace SwiftHrManagement.web.Payrole_management
{
    public partial class ManualBenefit_Deduction : System.Web.UI.Page
    {
        payroleDAO _payroll = null;
        public ManualBenefit_Deduction()
        {
            _payroll = new payroleDAO();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            clsDAO obj = new clsDAO();
            obj.setDDL(ref ddlFiscalYear, "select FISCAL_YEAR_ID from FiscalYear", "FISCAL_YEAR_ID", "FISCAL_YEAR_ID", "", "");
            obj.setDDL(ref ddlSalaryItem, "select ManualEntryID,Name from ManualBenifitDeduction_Head Where Enable='1'", "ManualEntryID", "name", "", "");
            obj.setDDL(ref ddlMonth, "select Month_Number,Name from MonthList", "Month_Number", "Name", "", "");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string searchCriteria = ddlSearchCriteria.Text;
            string searchFor = txtSearch.Text;
            dt = _payroll.Executepayroll("proc_searchEmployee '" + ddlSearchCriteria.Text + "','" + txtSearch.Text + "'").Tables[0];
            listEmployee(dt);
        }

        /// <summary>
        /// Print list of employee
        /// </summary>
        /// <param name="dt">Data Table</param>
        /// 
        private void listEmployee(DataTable dt)
        {
            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;

            TableRow tr = null;
            TableCell td1 = null;
            TableCell td2 = null;
            TableCell td3 = null;
            TableCell td4 = null;

            if (dt.Rows.Count > 0)
            {

                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td3 = new TableCell();
                td4 = new TableCell();

                tr.CssClass = "HeaderStyle";

                if (dt.Rows.Count > 1)
                    td1.Text = "<input type='checkbox' name='chkAll' name='chkAll'  id='chkAll' onclick=\"checkAll(this);\">";
                else
                    td1.Text = "";

                td1.Text = "<input type='checkbox' name='chkAll' name='chkAll' id='chkAll' onclick=\"checkAll(this);\">";
                td2.Text = "<strong>Name</strong>";
                td3.Text = "<strong>Department</strong>";
                td4.Text = "<strong>Position</strong>";
                
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);
                tr.Cells.Add(td4);                
                tblResult.Rows.Add(tr);
            }

            foreach (DataRow row in dt.Rows)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td3 = new TableCell();
                td4 = new TableCell();

                td1.Text = "<input type='checkbox' name='chkEmployee' id='chkEmployee' value='" + row["employee_id"].ToString() + "'>";
                td2.Text = row["Name"].ToString();
                td3.Text = row["Department"].ToString();
                td4.Text = row["position"].ToString();
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);
                tr.Cells.Add(td4);
                tblResult.Rows.Add(tr);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //save             
            string employeeIds = "Null";
            string flag = "'a'";
            if (ddlApplyTo.Text == "m")
            {
                if (Request.Form["chkEmployee"] != null)
                {
                    employeeIds = Request.Form["chkEmployee"].ToString();
                    flag="'m'";
                }
            }

            string sql = "exec proc_manualBenefit_deduction " +  flag;
            sql += ",'" + ddlFiscalYear.Text + "','" + ddlMonth.Text + "'," + ddlSalaryItem.Text + "," + txtAmount.Text;
            sql += ",'" + ddlType.Text + "','" + employeeIds + "','" + ddlSearchCriteria.Text + "','" + txtSearch.Text + "'";

            _payroll.ExecuteQuery(sql);
                /*
                 proc_manualBenefit_deduction '@flag',
                 * '@fiscalYear',
                 * '@month_Number',
                 * @ManualEntryId,
                 * @amount,
                 * @addDeduct,
                 * @employeeIds,
                 * '@criteria',
                 * '@searchFor'                  
                 */ 

                //_payroll

        }

        protected void ddlApplyTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
