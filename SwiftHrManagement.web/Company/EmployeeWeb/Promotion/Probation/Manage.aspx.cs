using System;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.DAL.Probation;

namespace SwiftHrManagement.web.Company.EmployeeWeb.Promotion.Probation
{
    public partial class Manage : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO CLsDAo = null;
        private ProbationDao _probationDao = null;
        string[] payableHead;
        string[] payableValue;
        public Manage()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this.CLsDAo = new clsDAO();
            this._probationDao = new ProbationDao();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 220) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if(GetProSalId()>0)
                {
                    PopulateDdl();  
                    PopulateDataById();
                }
            }
        }
        private string[] GetEmpInfoComponents(string empInfo)
        {
            return empInfo.Split('|');
        }

        private string getEmpIdfromInfo(string curEmpInfo)
        {
            int i = curEmpInfo.LastIndexOf("|");
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo.Substring(i + 1, curEmpInfo.Length - (i + 1)) : "0";
        }
        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmpName.Text);
            txtEmployee.Text = "";
            PopulateDdl();
            DisableField();
        }
        private void LoadCurrentSalarySet(string empId)
        {
            DataRow dr = _probationDao.SelectSalarySet(empId);
            if (dr == null)
                return;
            DdlSalarySet.Text = dr["salarySet"].ToString();
        }
        private void PopulateDdl()
        {
            var sql = @"SELECT  d.ROWID ,d.DETAIL_DESC EMP_TYPE FROM Employee e 
                            INNER JOIN StaticDataDetail d 
                            ON e.EMP_TYPE = ROWID
                            WHERE EMPLOYEE_ID = " + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "";
            var sql1 = @"SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where TYPE_ID = 10";
            if(GetProSalId()>0)
                CLsDAo.CreateDynamicDDl(DddlEmpType, sql1, "ROWID", "DETAIL_TITLE", "", "");
            else
                CLsDAo.CreateDynamicDDl(DddlEmpType, sql, "ROWID", "EMP_TYPE", "", "");
            CLsDAo.CreateDynamicDDl(DdlChangedEmpType, sql1, "ROWID", "DETAIL_TITLE", "", "Select");
            txtEffectiveDate.Text = System.DateTime.Now.ToShortDateString();
            SetDDLEmpPosition();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Update();
        }

        private long GetProSalId()
        {
            return ReadNumericDataFromQueryString("ID");
        }

        private void Update()
        {
            string currentPosition = "";
            string newPosition = "";

            string fromBranch = "";
            string toBranch = "";
            string fromDept = "";
            string toDept = "";

        if(radioEmpPromotionType.Text == "WP")
            {
                currentPosition = DdlCurrentPosition.Text;
                newPosition = DdlPosition.Text;
            }
            else
            {
                currentPosition = "";
                newPosition = "";
            }

            if(radioTransferType.Text =="WT")
            {
                fromBranch = DdlFromBranch.Text;
                toBranch = DdlToDept.Text;
                fromDept = DdlFromDept.Text;
                toDept = DdlToDept.Text;
            }
            else
            {
                fromBranch = "";
                toBranch = "";
                fromDept = "";
                toDept = ""; 
            }
            _probationDao.Update(ReadSession().AdminId.ToString(), GetProSalId().ToString(),
                                 filterstring(getEmpIdfromInfo(lblEmpName.Text)), DddlEmpType.Text,
                                 DdlChangedEmpType.Text, txtEffectiveDate.Text,
                                 currentPosition, newPosition, fromBranch, fromDept, toBranch, toDept,
                                 radioEmpPromotionType.Text, radioTransferType.Text, DdlSalarySet.Text);
            Response.Redirect("List.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }
        
        #region salary

        protected void radioEmpPromotionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            salarySet.Visible = true;
            ShowHideEmpPosition();
        }

        private void ShowHideEmpPosition()
        {
            if (radioEmpPromotionType.Text == "WP")
            {
                if(GetProSalId()>0)
                    PopulateDataById();
                else
                {
                    ShowHidePosition.Visible = true;
                    SetDDLEmpPosition();
                    SetDDlSalarySet();  
                    DisplaySalarySet();
                }
            }
            else
            {
                ShowHidePosition.Visible = false;
                SetDDlSalarySet();
                DisplaySalarySet();
            }
          
        }

        private void SetDDlSalarySet()
        {
            var sql = "select m.salarySetMasterId salary_set_id,setName  [Salary_set]from salarySetMaster m inner join"
                     + " (select POSITION_ID from   Employee where EMPLOYEE_ID = " + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + " ) e "
                     + " on m.position = e.POSITION_ID";
            CLsDAo.CreateDynamicDDl(DdlSalarySet, sql, "salary_set_id", "Salary_set", "", "");
            LoadCurrentSalarySet(getEmpIdfromInfo(lblEmpName.Text));
        }

        private void SetDDLEmpPosition()
        {
            var sql = @"SELECT  d.ROWID ,d.DETAIL_DESC Position FROM Employee e 
                            INNER JOIN StaticDataDetail d 
                            ON e.POSITION_ID = ROWID
                            WHERE EMPLOYEE_ID = " + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "";
            var sql1 = @"SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail where TYPE_ID = 4";
            CLsDAo.CreateDynamicDDl(DdlCurrentPosition, sql, "ROWID", "Position", "", "");
            CLsDAo.CreateDynamicDDl(DdlPosition, sql1, "ROWID", "DETAIL_TITLE", "", "Select");
        }

        protected void DdlSalarySet_SelectedIndexChanged(object sender, EventArgs e)
        {
            salarySet.Visible = true;
            DisplaySalarySet();
        }

        private void DisplaySalarySet()
        {
            if(DdlSalarySet.Text == "")
            {
                return;
            }

            //string[] arrayValue = DdlSalarySet.Text.Split('-');
            //string salarySetMaterId = arrayValue[0];
            //string gradeId = arrayValue[1];
         
            StringBuilder str = new StringBuilder("<table border=\"0\" width=\"600px\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            DataTable dt = _probationDao.SelectSalarySetByEmpId(filterstring(getEmpIdfromInfo(lblEmpName.Text)), DdlSalarySet.Text);
           int cols = dt.Columns.Count;
            int count = 1;
           str.Append("<tr>");
           str.Append("<th align=\"left\">Sn.</th>");
           for (int i = 0; i < cols; i++)
           {
               str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
           }
           str.Append("</tr>");
           foreach (DataRow dr in dt.Rows)
           {
               str.Append("<tr>");
               str.Append("<td align=\"left\">" + count++ + "</td>");
               for (int i = 0; i < cols; i++)
               {
                   if(i==1)
                   {
                       str.Append("<td ><div align=\"right\">" + dr[i].ToString() + "</div></td>");
                   }
                   else
                   {
                       str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                   }
                   
               }
               str.Append("</tr>");
           }
           str.Append("</table>");
           salarySet.InnerHtml = str.ToString();
        }

        protected void DdlPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            salarySet.Visible = false;
            SetDdlNewSalarySet("");
        }

        private void SetDdlNewSalarySet(string selectedValue)
        {
          
            if(DdlPosition.Text !="")
            {
                var sql = @"select salarySetMasterId salary_set_id,setName [Salary_set] from salarySetMaster where  position = " + DdlPosition.Text + "";
                CLsDAo.CreateDynamicDDl(DdlSalarySet, sql, "salary_set_id", "Salary_set", selectedValue, "Select");
                DisplaySalarySet();
            }


        }

        #endregion

        #region Transfer

        protected void radioTransferType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioTransferType.Text =="WT")
            {
                showHideTransfer.Visible = true;
                SetDdlTranser();
            }
            else
            {
                showHideTransfer.Visible = false;
            }
        }

        private void SetDdlTranser()
        {
            var sql = @"select DEPARTMENT_ID,dbo.GetDeptName(DEPARTMENT_ID) as deptName from Employee where EMPLOYEE_ID =" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "";
            var sql1 = @"select BRANCH_ID,dbo.GetBranchName(BRANCH_ID) as branchName from Employee where EMPLOYEE_ID =" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + "";
            var sql2 = @"SELECT BRANCH_ID,BRANCH_NAME FROM Branches";
            var sql3 = @"SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments";

            CLsDAo.CreateDynamicDDl(DdlFromBranch, sql1, "BRANCH_ID", "branchName", "", "");
            CLsDAo.CreateDynamicDDl(DdlFromDept, sql, "DEPARTMENT_ID", "deptName", "", "");
            CLsDAo.CreateDynamicDDl(DdlToBranch, sql2, "BRANCH_ID", "BRANCH_NAME", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlToDept, sql3, "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
            DdlFromBranch.Enabled = false;
            DdlFromDept.Enabled = false;

        }

        #endregion
        private void PopulateDataById()
        {
            DataRow dr = _probationDao.SelectById(ReadSession().Emp_Id.ToString(), GetProSalId().ToString());
            if (dr == null)
                return;

            lblEmpName.Text = dr["empName"].ToString();
            DddlEmpType.Text = dr["currentEmpType"].ToString();
            DdlChangedEmpType.Text = dr["newEmpType"].ToString();
            txtEffectiveDate.Text = dr["effectiveDate"].ToString();
            DdlCurrentPosition.Text = dr["currentPosition"].ToString();
            if (dr["promotionFlag"].ToString() == "WP")
            {
                radioEmpPromotionType.SelectedValue = "WP";
                ShowHidePosition.Visible = true;
                SetDDLEmpPosition();
                DdlPosition.Text = dr["newPosition"].ToString();
                SetDdlNewSalarySet(dr["salarySetMasterId"].ToString());
                DdlCurrentPosition.Text = dr["currentPosition"].ToString();
                DdlSalarySet.Text = dr["salarySetMasterId"].ToString() + "-" + dr["gradeId"];
                DisplaySalarySet();
            }
            else
            {
                radioEmpPromotionType.SelectedValue = "OP";
                ShowHideEmpPosition();
            }
               
            if(dr["transferFlag"].ToString() == "WT")
            {
                radioTransferType.SelectedValue = "WT";
                showHideTransfer.Visible = true;
                SetDdlTranser();
                DdlFromBranch.Text = dr["currentBranch"].ToString();
                DdlFromDept.Text = dr["currentDept"].ToString();
                DdlToBranch.Text = dr["newBranch"].ToString();
                DdlToDept.Text = dr["newDept"].ToString();
            }
            else
                radioTransferType.SelectedValue = "OT";

            DisableField();
        }
        private void DisableField()
        {
            DddlEmpType.Enabled = false;
            DdlCurrentPosition.Enabled = false;
            DdlFromBranch.Enabled = false;
            DdlFromDept.Enabled = false;
        }

        protected void DdlToBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLsDAo.CreateDynamicDDl(DdlToDept, "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM Departments WHERE BRANCH_ID = " + DdlFromBranch.Text, "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
        }

        protected void DdlFromBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CLsDAo.CreateDynamicDDl(DdlFromDept, "SELECT DEPARTMENT_ID, DEPARTMENT_NAME FROM Departments WHERE BRANCH_ID = " + DdlFromBranch.Text, "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "Select");
        }


        protected void btnBack_Click1(object sender, EventArgs e)
        {

            Response.Redirect("List.aspx");
        }
    }
}