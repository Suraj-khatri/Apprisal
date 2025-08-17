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
    public partial class Manual_Benefit_Deduction_main : System.Web.UI.Page
    {
        payroleDAO _payroll = null;
        public Manual_Benefit_Deduction_main()
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
            
            string sql = "proc_manualBenefit_deduction 's','" + ddlFiscalYear.Text + "','" + ddlMonth.Text + "'," + ddlSalaryItem.Text + ",Null,Null," + ddlType.Text + ",'" + ddlSearchCriteria.Text + "','" + txtSearch.Text + "'";
            dt = _payroll.Executepayroll(sql).Tables[0];
            listEmployee(dt);           
        }

        /// <summary>
        /// Print list of employee
        /// </summary>
        /// <param name="dt">Data Table</param>
        /// 
        private void listEmployee(DataTable dt)
        {
            TableRow tr = null;
            TableCell td1 = null;
            TableCell td2 = null;
            TableCell td3 = null;
            TableCell td4 = null;
            TableCell td5 = null;
            TableCell td6 = null;
            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;
            

            if (dt.Rows.Count > 0)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td3 = new TableCell();
                td4 = new TableCell();
                td5 = new TableCell();
                td6 = new TableCell();
                tr.CssClass = "HeaderStyle";
                if (dt.Rows.Count > 1)
                    td1.Text = "<input type='checkbox' name='chkAll' name='chkAll'  id='chkAll' onclick=\"checkAll(this);\">";
                else
                    td1.Text = "";
                td2.Text = "<strong>Name</strong>";
                td3.Text = "<strong>Department</strong>";
                td4.Text = "<strong>Position</strong>";
                td5.Text = "<strong>Amount</strong>";
                td6.Text = "";
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);
                tr.Cells.Add(td4);
                tr.Cells.Add(td5);
                tr.Cells.Add(td6);
                tblResult.Rows.Add(tr);
                
            }

            foreach (DataRow row in dt.Rows)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td3 = new TableCell();
                td4 = new TableCell();
                td5 = new TableCell();
                td6 = new TableCell();

                td1.Text = "<input type='checkbox' name='chkTran' id='chkTran' value='" + row["id"].ToString() + "'>";
                td2.Text = row["Name"].ToString();
                td3.Text = row["Department"].ToString();
                td4.Text = row["position"].ToString();
                td5.Text = row["Amount"].ToString();
                td6.Text = "<a href=\"abc.aspx?id=" + row["id"].ToString() + "\">Edit</a>";
                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);
                tr.Cells.Add(td4);
                tr.Cells.Add(td5);
                tr.Cells.Add(td6);
                tblResult.Rows.Add(tr);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string Ids = "";
            if (Request.Form["chkTran"] != null)
            {
                Ids = Request.Form["chkTran"].ToString();                
            }

            if (Ids == "")
                return;

            string sql = "proc_manualBenefit_deduction @flag='d',@Ids='" + Ids + "'" ;
            //deletes selected transaction
            //selected transaction ids are put in the variable : IDs

            _payroll.ExecuteQuery(sql);
        }

        protected void ImgBtnHide_Click(object sender, ImageClickEventArgs e)
        {
            
                PnlSearch.Visible = false;
                ImgBtnHide.Visible = false;
                ImgBtnShow.Visible = true;
           
        }

        protected void ImgBtnShow_Click(object sender, ImageClickEventArgs e)
        {
                PnlSearch.Visible = true;
                ImgBtnHide.Visible = true;
                ImgBtnShow.Visible = false;            
        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {

        }
    }
}
