using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.TrainingManagement.TrainingNeedAssessment
{
    public partial class TNAReport : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsDao = null;
        public TNAReport()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 10080) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            if (txtHdnEmpId.Text != "")
            {
                populateDropDownList();
                BtnSearchRpt.Visible = true;
            }
            else
            {
                lblmsg.Text = "Please Choose Employee Properly!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                rptTRF.Visible = false;
                rptWCBDTRTP.Visible = false;
                rptTPA.Visible = false;
                rptSST.Visible = false;
                rptDWDD.Visible = false;
                return;
            }
        }
        private void populateDropDownList()
        {
            string empId = txtHdnEmpId.Text;

            _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT B.BRANCH_ID,B.BRANCH_NAME FROM TRAINING_NEED_ASSESSMENT T INNER JOIN Branches B ON"
                + " B.BRANCH_ID=T.BRANCH_ID WHERE EMPLOYEE_ID=" + empId + "", "BRANCH_ID", "BRANCH_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlEmpPosition, "SELECT POSITION_ID,dbo.GetDetailTitle(POSITION_ID) as POSITION_NAME FROM TRAINING_NEED_ASSESSMENT"
                + " WHERE EMPLOYEE_ID=" + empId + "", "POSITION_ID", "POSITION_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlDeptName, "SELECT D.DEPARTMENT_ID,D.DEPARTMENT_NAME FROM Departments D INNER JOIN TRAINING_NEED_ASSESSMENT E ON D.DEPARTMENT_ID=E.DEPT_ID"
                + " WHERE EMPLOYEE_ID=" + empId + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlISupName, "SELECT E.EMPLOYEE_ID,E.FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME AS EMP_NAME FROM Employee E "
                + " INNER JOIN TRAINING_NEED_ASSESSMENT T ON T.IMM_SUP_ID=E.EMPLOYEE_ID WHERE T.EMPLOYEE_ID=" + empId + "", "EMPLOYEE_ID", "EMP_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlISupPosition, "SELECT IMM_SUP_POSITION_ID POSITION_ID,dbo.GetDetailTitle(IMM_SUP_POSITION_ID)AS POSITION_NAME"
                + " FROM TRAINING_NEED_ASSESSMENT WHERE EMPLOYEE_ID=" + empId + " ", "POSITION_ID", "POSITION_NAME", "", "");
        }
        private void populateReportContent()
        {
            StringBuilder STR1 = new StringBuilder("<table class=\"TBL2\"  width=\"100%\">");
            DataTable DT1 = new DataTable();
            DT1 = _clsDao.getDataset("EXEC [ProcManageTNARpt] @FLAG='r',@EMPLOYEE_ID=" + filterstring(txtHdnEmpId.Text) + ","
            + " @FROM_DATE="+filterstring(txtFromDate.Text)+",@TO_DATE="+filterstring(txtToDate.Text)+"").Tables[0];
            STR1.Append("<tr>");
            int cols = DT1.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                STR1.Append("<th align=\"left\">" + DT1.Columns[i].ColumnName + "</th>");
            }
            STR1.Append("</tr>");
            foreach (DataRow dr in DT1.Rows)
            {

                STR1.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    STR1.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                STR1.Append("</tr>");
            }
            STR1.Append("</table>");
            rptTPA.InnerHtml = STR1.ToString();


            rptDWDD.InnerHtml = _clsDao.GetSingleresult("SELECT ANS_TEN FROM TRAINING_NEED_ASSESSMENT WHERE EMPLOYEE_ID=" + filterstring(txtHdnEmpId.Text) + "");

            StringBuilder STR2 = new StringBuilder("<UL>");
            DataTable DT2 = new DataTable();
            DT2 = _clsDao.getDataset("EXEC [ProcManageTNARpt] @FLAG='r',@EMPLOYEE_ID=" + filterstring(txtHdnEmpId.Text) + ","
            + " @FROM_DATE=" + filterstring(txtFromDate.Text) + ",@TO_DATE=" + filterstring(txtToDate.Text) + "").Tables[1];         
            int COLS2 = DT2.Columns.Count;
            foreach (DataRow dr in DT2.Rows)
            {
                for (int i = 0; i < COLS2; i++)
                {
                    STR2.Append("<LI>" + dr[i].ToString() + "</LI>");
                }
            }
            STR2.Append("</UL>");
            rptWCBDTRTP.InnerHtml = STR2.ToString();


            StringBuilder STR3 = new StringBuilder("<UL>");
            DataTable DT3 = new DataTable();
            DT3 = _clsDao.getDataset("EXEC [ProcManageTNARpt] @FLAG='r',@EMPLOYEE_ID=" + filterstring(txtHdnEmpId.Text) + ","
            + " @FROM_DATE=" + filterstring(txtFromDate.Text) + ",@TO_DATE=" + filterstring(txtToDate.Text) + "").Tables[2];
            int COLS3 = DT3.Columns.Count;
            foreach (DataRow dr in DT3.Rows)
            {
                for (int i = 0; i < COLS3; i++)
                {
                    STR3.Append("<LI>" + dr[i].ToString() + "</LI>");
                }
            }
            STR3.Append("</UL>");
            rptTRF.InnerHtml = STR3.ToString();


            StringBuilder STR4 = new StringBuilder("<UL>");
            DataTable DT4 = new DataTable();
            DT4 = _clsDao.getDataset("EXEC [ProcManageTNARpt] @FLAG='r',@EMPLOYEE_ID=" + filterstring(txtHdnEmpId.Text) + ","
            + " @FROM_DATE=" + filterstring(txtFromDate.Text) + ",@TO_DATE=" + filterstring(txtToDate.Text) + "").Tables[3];
            int COLS4 = DT4.Columns.Count;
            foreach (DataRow dr in DT4.Rows)
            {
                for (int i = 0; i < COLS4; i++)
                {
                    STR4.Append("<LI>" + dr[i].ToString() + "</LI>");
                }
            }
            STR4.Append("</UL>");
            rptSST.InnerHtml = STR4.ToString();
        }

        protected void BtnSearchRpt_Click(object sender, EventArgs e)
        {
            string check = _clsDao.GetSingleresult("SELECT COUNT(*) FROM TRAINING_NEED_ASSESSMENT WHERE CREATED_DATE BETWEEN " + filterstring(txtFromDate.Text) + ""
                        + " AND " + filterstring(txtToDate.Text) + " AND EMPLOYEE_ID=" + filterstring(txtHdnEmpId.Text) + "");
            if (long.Parse(check) > 0)
            {
                lblmsg.Text = "";
                rptTRF.Visible = true;
                rptWCBDTRTP.Visible = true;
                rptTPA.Visible = true;
                rptSST.Visible = true;
                rptDWDD.Visible = true;
                populateReportContent();
                BtnSearchRpt.Visible = false;
            }
            else
            {
                lblmsg.Text = "No TNA Records Found!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
                rptTRF.Visible = false;
                rptWCBDTRTP.Visible = false;
                rptTPA.Visible = false;
                rptSST.Visible = false;
                rptDWDD.Visible = false;
                return;
            }            
        }
    }
}
