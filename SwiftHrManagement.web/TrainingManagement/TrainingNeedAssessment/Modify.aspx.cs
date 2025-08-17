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
    public partial class Modify : BasePage
    {
        String delRespon = "";
        String delRespon1 = "";
        String delTraining = "";
        String delTrainingReq = "";
        String delSoftTrainingReq = "";

        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsDao = null;
        public Modify()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _clsDao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["ckID"] != null)
                delRespon = Request.Form["ckID"].ToString();
            if (Request.Form["ckID1"] != null)
                delRespon1 = Request.Form["ckID1"].ToString();
            if (Request.Form["ckID2"] != null)
                delTraining = Request.Form["ckID2"].ToString();
            if (Request.Form["ckID3"] != null)
                delTrainingReq = Request.Form["ckID3"].ToString();
            if (Request.Form["ckID4"] != null)
                delSoftTrainingReq = Request.Form["ckID4"].ToString();

            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 2011) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                getResponsibility();
                getSoftTrainingRequirement();
                getTrainingNames();
                getUniqueResponsibility();
                getTrainingRequirement();

                if (FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM")
                {
                    showEmp.Visible = true;
                    DdlEmpName.Visible = false;
                    txtEmployee.Enabled = false;
                }
                //else
                //{
                //    populateDropDownList();

                //}
                
                if (GetID() > 0)
                {
                    populateTNA();
                }
            }
        }
        public long GetID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        public string FindHrByDeptId(string deptId)
        {
            var sql = "SELECT DEPARTMENT_SHORT_NAME FROM Departments where DEPARTMENT_ID = " + deptId;
            return _clsDao.GetSingleresult(sql);

        }
        private void populateDropDownList(string empTypeId)
        {
            string empId = FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM" ? empTypeId: empTypeId;
            _clsDao.CreateDynamicDDl(DdlEmpName, "SELECT EMPLOYEE_ID,FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME as EMP_NAME FROM "
            + " EMPLOYEE WHERE EMPLOYEE_ID=" + empId + "", "EMPLOYEE_ID", "EMP_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlBranchName, "SELECT B.BRANCH_ID,B.BRANCH_NAME FROM Branches B INNER JOIN Employee E ON B.BRANCH_ID=E.BRANCH_ID"
            + " WHERE EMPLOYEE_ID=" + empId + "", "BRANCH_ID", "BRANCH_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlEmpPosition, " SELECT POSITION_ID,dbo.GetDetailTitle(POSITION_ID) as POSITION_NAME FROM Employee WHERE"
            + " EMPLOYEE_ID=" + empId + "", "POSITION_ID", "POSITION_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlDeptName, "SELECT D.DEPARTMENT_ID,D.DEPARTMENT_NAME FROM Departments D INNER JOIN Employee E ON D.DEPARTMENT_ID=E.DEPARTMENT_ID"
            + " WHERE EMPLOYEE_ID=" + empId + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlISupName, "SELECT E.EMPLOYEE_ID,E.FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME AS EMP_NAME FROM Employee E WHERE"
                + " EMPLOYEE_ID IN (SELECT DISTINCT SUPERVISOR FROM SuperVisroAssignment WHERE EMP=" + empId + ")", "EMPLOYEE_ID", "EMP_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlISupPosition, "SELECT POSITION_ID,dbo.GetDetailTitle(POSITION_ID)AS POSITION_NAME FROM Employee WHERE EMPLOYEE_ID IN("
                + " SELECT DISTINCT SUPERVISOR FROM SuperVisroAssignment WHERE EMP='1000')", "POSITION_ID", "POSITION_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlISubName, "SELECT E.EMPLOYEE_ID,E.FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME AS EMP_NAME FROM Employee E WHERE"
             + " EMPLOYEE_ID IN (SELECT DISTINCT SUPERVISOR FROM SuperVisroAssignment WHERE EMP=" + empId + ")", "EMPLOYEE_ID", "EMP_NAME", "", "");

            _clsDao.CreateDynamicDDl(DdlISubPosition, "SELECT POSITION_ID,dbo.GetDetailTitle(POSITION_ID)AS POSITION_NAME FROM Employee WHERE EMPLOYEE_ID IN("
                + " SELECT DISTINCT SUPERVISOR FROM SuperVisroAssignment WHERE EMP=" + empId + ")", "POSITION_ID", "POSITION_NAME", "", "");
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                manageSaveTNA();
            }
            catch
            {
                lblmsg.Text = "Error In Operation!";
            }
        }
        private void manageSaveTNA()
        {
            string[] arrayEmpId = txtEmployee.Text.Split('|');
            string empTypeId = arrayEmpId[1];
            string empId = FindHrByDeptId(ReadSession().Department.ToString()).ToUpper() == "HRM" ? empTypeId : filterstring(DdlEmpName.Text);
            string msg=  _clsDao.GetSingleresult("EXEC [ProcManageTNA] "
                + " @FLAG='u',"
                + " @ID=" + filterstring(GetID().ToString()) + ","
                + " @EMPLOYEE_ID=" + filterstring(empId) + ","
                + " @POSITION_ID=" + filterstring(DdlEmpPosition.Text.ToString()) + ","
                + " @BRANCH_ID=" + filterstring(DdlBranchName.Text.ToString()) + ","
                + " @DEPT_ID=" + filterstring(DdlDeptName.Text.ToString()) + ","
                + " @IMM_SUP_ID=" + filterstring(DdlISupName.Text) + ","
                + " @IMM_SUP_POSITION_ID=" + filterstring(DdlISupPosition.Text) + ","
                + " @IMM_SUB_ID=" + filterstring(DdlISubName.Text) + ","
                + " @IMM_SUB_POSITION_ID=" + filterstring(DdlISubPosition.Text) + ","
                + " @ANS_ONE=" + filterstring(ans_1.Text) + ","
                + " @ANS_TWO_A=" + filterstring(ans_2_a.Text) + ","
                + " @ANS_TWO_B =" + filterstring(ans_2_b.Text) + ","
                + " @ANS_TWO_C=" + filterstring(ans_2_c.Text) + ","
                + " @ANS_THREE_MASTER=" + filterstring(ans_3_master.Checked.ToString()) + ","
                + " @ANS_THREE_BACHELOR=" + filterstring(ans_3_bachelor.Checked.ToString()) + ","
                + " @ANS_THREE_SPECIAL=" + filterstring(ans_3_special.Checked.ToString()) + ","
                + " @ANS_THREE_SPECIAL_DEGREE=" + filterstring(ans_3_special_degree.Text) + ","
                + " @ANS_THREE_PROF=" + filterstring(ans_3_prof.Checked.ToString()) + ","
                + " @ANS_THREE_PROF_DEGREE=" + filterstring(ans_3_prof_degree.Text.ToString()) + ","
                + " @ANS_THREE_OTHER=" + filterstring(ans_3_Other.Checked.ToString()) + ","
                + " @ANS_THREE_OTHER_DEGREE=" + filterstring(ans_3_other_degree.Text) + ","
                + " @ANS_FIVE=" + filterstring(ans_5.Text) + ","
                + " @ANS_SIX_STRESSFULL=" + filterstring(ans_6_stressful.Checked.ToString()) + ","
                + " @ANS_SIX_BORING=" + filterstring(ans_6_boring.Checked.ToString()) + ","
                + " @ANS_SIX_EASY=" + filterstring(ans_6_easy.Checked.ToString()) + ","
                + " @ANS_SIX_DIFFICULT=" + filterstring(ans_6_difficult.Checked.ToString()) + ","
                + " @ANS_SIX_INTERESTING=" + filterstring(ans_6_interesting.Checked.ToString()) + ","
                + " @ANS_SIX_OTHER=" + filterstring(ans_6_other.Checked.ToString()) + ","
                + " @ANS_SIX_OTHER_DETAIL=" + filterstring(ans_6_other_detail.Text) + ","
                + " @ANS_SIX_WHY=" + filterstring(ans_6_why.Text) + ","
                + " @ANS_SEVEN=" + filterstring(ans_7.Text) + ","
                + " @ANS_EIGHT=" + filterstring(ans_8.Text) + ","
                + " @ANS_TEN=" + filterstring(ans_10.Text) + ","
                + " @ANS_ELEVEN_TRAINING=" + filterstring(ans_11_training.Checked.ToString()) + ","
                + " @ANS_ELEVEN_OTHER=" + filterstring(ans_11_other.Checked.ToString()) + ","
                + " @ANS_ELEVEN_OTHER_DETAIL=" + filterstring(ans_11_other_detail.Text) + ","
                + " @SESSION_ID=" + filterstring(ReadSession().Sessionid) + ","
                + " @USER =" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            //lblmsg.Text = msg;
            Response.Redirect("List.aspx");
        }
        private void populateTNA()
        {
            DataTable dt = _clsDao.getTable("Exec [ProcManageTNA] @FLAG='s',@ID=" + filterstring(GetID().ToString()) + "");

            foreach (DataRow dr in dt.Rows)
            {
                //DdlEmpName.SelectedValue = dr["EMPLOYEE_ID"].ToString();
                txtEmployee.Text = dr["empName"].ToString();
                DdlEmpPosition.SelectedValue = dr["POSITION_ID"].ToString();
                DdlBranchName.SelectedValue = dr["BRANCH_ID"].ToString();
                DdlDeptName.SelectedValue = dr["DEPT_ID"].ToString();
                DdlISupName.SelectedValue = dr["IMM_SUP_ID"].ToString();
                DdlISupPosition.SelectedValue = dr["IMM_SUP_POSITION_ID"].ToString();
                DdlISubName.SelectedValue = dr["IMM_SUB_ID"].ToString();
                DdlISubPosition.SelectedValue = dr["IMM_SUB_POSITION_ID"].ToString();
                populateDropDownList(dr["EMPLOYEE_ID"].ToString());
                ans_1.Text = dr["ANS_ONE"].ToString();
                ans_2_a.Text = dr["ANS_TWO_A"].ToString();
                ans_2_b.Text = dr["ANS_TWO_B"].ToString();
                ans_2_c.Text = dr["ANS_TWO_C"].ToString();
                if (dr["ANS_THREE_MASTER"].ToString() == "True")
                    ans_3_master.Checked = true;
                else
                    ans_3_master.Checked = false;

                string CHECK = dr["ANS_THREE_MASTER"].ToString();
                if (dr["ANS_THREE_BACHELOR"].ToString() == "True")
                    ans_3_bachelor.Checked = true;
                else
                    ans_3_bachelor.Checked = false;

                if (dr["ANS_THREE_BACHELOR"].ToString() == "True")
                    ans_3_bachelor.Checked = true;
                else
                    ans_3_bachelor.Checked = false;

                if (dr["ANS_THREE_SPECIAL"].ToString() == "True")
                    ans_3_special.Checked = true;
                else
                    ans_3_special.Checked = false;
                
                ans_3_special_degree.Text = dr["ANS_THREE_SPECIAL_DEGREE"].ToString();

                if (dr["ANS_THREE_PROF"].ToString() == "True")
                    ans_3_prof.Checked = true;
                else
                    ans_3_prof.Checked = false;

                ans_3_prof_degree.Text = dr["ANS_THREE_PROF_DEGREE"].ToString();
                if (dr["ANS_THREE_OTHER"].ToString() == "True")
                    ans_3_Other.Checked = true;
                else
                    ans_3_Other.Checked = false;
                
                ans_3_other_degree.Text = dr["ANS_THREE_OTHER_DEGREE"].ToString();
                ans_5.Text = dr["ANS_FIVE"].ToString();

                if (dr["ANS_SIX_STRESSFULL"].ToString() == "True")
                    ans_6_stressful.Checked=true;
                else
                    ans_6_stressful.Checked=false;

                if (dr["ANS_SIX_BORING"].ToString() == "True")
                    ans_6_boring.Checked = true;
                else
                    ans_6_boring.Checked = false;

                if (dr["ANS_SIX_EASY"].ToString() == "True")
                    ans_6_easy.Checked = true;
                else
                    ans_6_easy.Checked = false;

                if (dr["ANS_SIX_DIFFICULT"].ToString() == "True")
                    ans_6_difficult.Checked = true;
                else
                    ans_6_difficult.Checked = false;

                if (dr["ANS_SIX_INTERESTING"].ToString() == "True")
                    ans_6_interesting.Checked = true;
                else
                    ans_6_interesting.Checked = false;

                if (dr["ANS_SIX_OTHER"].ToString() == "True")
                    ans_6_other.Checked = true;
                else
                    ans_6_other.Checked = false;
                
                ans_6_other_detail.Text = dr["ANS_SIX_OTHER_DETAIL"].ToString();
                ans_6_why.Text = dr["ANS_SIX_WHY"].ToString();
                ans_7.Text = dr["ANS_SEVEN"].ToString();
                ans_8.Text = dr["ANS_EIGHT"].ToString();
                ans_10.Text = dr["ANS_TEN"].ToString();

                if (dr["ANS_ELEVEN_TRAINING"].ToString() == "True")
                    ans_11_training.Checked = true;
                else
                    ans_11_training.Checked = false;

                if (dr["ANS_ELEVEN_OTHER"].ToString() == "True")
                    ans_11_other.Checked = true;
                else
                    ans_11_other.Checked = false;
                
                ans_11_other_detail.Text = dr["ANS_ELEVEN_OTHER_DETAIL"].ToString();
            }
        }
        protected void btnAddResponsibility_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("INSERT INTO TNA_RESPONSIBILITY(TRAIN_NEED_ASS_ID,GENERAL_RESPONSIBILLY,DAILY,WEEKLY,MONTHLY,YEARLY,FLAG)VALUES("
                + " " + filterstring(GetID().ToString()) + "," + filterstring(txtResponsibilty.Text) + "," + filterstring(checkDaily.Checked.ToString()) + ","
                + " " + filterstring(checkWeekly.Checked.ToString()) + "," + filterstring(checkMonthly.Checked.ToString()) + ","
                + " " + filterstring(checkAnnually.Checked.ToString()) + ",'MAJOR')");

            getResponsibility();
        }
        private void getResponsibility()
        {
            BtnDelRes.Visible = true;
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("SELECT ID,ROW_NUMBER()OVER(ORDER BY ID) AS SN,GENERAL_RESPONSIBILLY,CASE WHEN DAILY='TRUE' THEN 'Yes' ELSE '' END,"
                                + " CASE WHEN WEEKLY='TRUE' THEN 'Yes' ELSE '' END,CASE WHEN MONTHLY='TRUE' THEN 'Yes' ELSE '' END,"
                                + " CASE WHEN YEARLY='TRUE' THEN 'Yes' ELSE '' END from TNA_RESPONSIBILITY"
                                + " WHERE TRAIN_NEED_ASS_ID=" + filterstring(GetID().ToString()) + " AND FLAG='MAJOR'").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("</tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID\" name=\"ckID\" value=\"" + dr["ID"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            disResponsibility.InnerHtml = str.ToString();
        }

        protected void BtnDelRes_Click(object sender, EventArgs e)
        {
            if (delRespon != "")
            {
                string sql = "DELETE FROM TNA_RESPONSIBILITY WHERE ID='" + delRespon + "'";
                _clsDao.runSQL(sql);
                getResponsibility();
            }  
        }

        protected void btnAddResponsibility1_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("INSERT INTO TNA_RESPONSIBILITY(TRAIN_NEED_ASS_ID,GENERAL_RESPONSIBILLY,DAILY,WEEKLY,MONTHLY,YEARLY,FLAG)VALUES("
                + " " + filterstring(GetID().ToString()) + "," + filterstring(txtResponsibilty1.Text) + "," + filterstring(checkDaily1.Checked.ToString()) + ","
                + " " + filterstring(checkWeekly1.Checked.ToString()) + "," + filterstring(checkMonthly1.Checked.ToString()) + ","
                + " " + filterstring(checkAnnually1.Checked.ToString()) + ",'UNIQUE')");

            getUniqueResponsibility();
        }
        private void getUniqueResponsibility()
        {
            BtnDelRes1.Visible = true;
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("SELECT ID,ROW_NUMBER()OVER(ORDER BY ID) AS SN,GENERAL_RESPONSIBILLY,CASE WHEN DAILY='TRUE' THEN 'Yes' ELSE '' END,"
                                + " CASE WHEN WEEKLY='TRUE' THEN 'Yes' ELSE '' END,CASE WHEN MONTHLY='TRUE' THEN 'Yes' ELSE '' END,"
                                + " CASE WHEN YEARLY='TRUE' THEN 'Yes' ELSE '' END from TNA_RESPONSIBILITY"
                                + " WHERE TRAIN_NEED_ASS_ID=" + filterstring(GetID().ToString()) + " AND FLAG='UNIQUE'").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("</tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID1\" name=\"ckID1\" value=\"" + dr["ID"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            disUniqueResponsibility.InnerHtml = str.ToString();
        }
        protected void BtnDelRes1_Click(object sender, EventArgs e)
        {
            if (delRespon1 != "")
            {
                string sql = "DELETE FROM TNA_RESPONSIBILITY WHERE ID='" + delRespon1 + "'";
                _clsDao.runSQL(sql);
                getUniqueResponsibility();
            } 
        }
        protected void BtnAddTraining_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("INSERT INTO TNA_TRAINING_ATTENDED(TRAIN_NEED_ASS_ID,TRAINING_NAME,LOCATION,DURATION)VALUES("
                + " " + filterstring(GetID().ToString()) + "," + filterstring(txtTrainingName.Text) + ","
                + " " + filterstring(txtTrainingLocation.Text.ToString()) + ","
                + " " + filterstring(txtTrainingMonthYear.Text.ToString()) + ")");

            getTrainingNames();
        }
        private void getTrainingNames()
        {
            BtnDelTraining.Visible = true;
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("SELECT ID,ROW_NUMBER()OVER(ORDER BY ID) AS SN,TRAINING_NAME,LOCATION,DURATION from TNA_TRAINING_ATTENDED WHERE"
                                + " TRAIN_NEED_ASS_ID=" + filterstring(GetID().ToString()) + "").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("</tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID2\" name=\"ckID2\" value=\"" + dr["ID"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            rptTrainingDetails.InnerHtml = str.ToString();
        }

        protected void BtnDelTraining_Click(object sender, EventArgs e)
        {
            if (delTraining != "")
            {
                string sql = "DELETE FROM TNA_TRAINING_ATTENDED WHERE ID='" + delTraining + "'";
                _clsDao.runSQL(sql);
                getTrainingNames();
            } 
        }

        protected void BtnAddTrainingRequirement_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("INSERT INTO TNA_TRAINING_REQUIREMENT(TRAIN_NEED_ASS_ID,TRAINING_REQ_NAME,FLAG)VALUES("
                + " " + filterstring(GetID().ToString()) + "," + filterstring(txtTrainingRequirement.Text) + ",'TRAINING_REQ')");

            getTrainingRequirement();
        }
        private void getTrainingRequirement()
        {
            BtnDelTrainingReq.Visible = true;
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("SELECT ID,ROW_NUMBER()OVER(ORDER BY ID) AS SN,TRAINING_REQ_NAME from TNA_TRAINING_REQUIREMENT WHERE"
                                + " TRAIN_NEED_ASS_ID=" + filterstring(GetID().ToString()) + " AND FLAG='TRAINING_REQ'").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("</tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID3\" name=\"ckID3\" value=\"" + dr["ID"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            disTrainingRequirement.InnerHtml = str.ToString();
        }

        protected void BtnDelTrainingReq_Click(object sender, EventArgs e)
        {
            if (delTrainingReq != "")
            {
                string sql = "DELETE FROM TNA_TRAINING_REQUIREMENT WHERE ID='" + delTrainingReq + "'";
                _clsDao.runSQL(sql);
                getTrainingRequirement();
            } 
        }

        protected void BtnAddSoftTrainingRequirement_Click(object sender, EventArgs e)
        {
            _clsDao.runSQL("INSERT INTO TNA_TRAINING_REQUIREMENT(TRAIN_NEED_ASS_ID,TRAINING_REQ_NAME,FLAG)VALUES("
               + " " + filterstring(GetID().ToString()) + "," + filterstring(txtSoftTrainingRequirement.Text) + ",'TRAINING_REQ_SOFT')");

            getSoftTrainingRequirement();
        }
        private void getSoftTrainingRequirement()
        {
            BtnDelSoftTrainingReq.Visible = true;
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("SELECT ID,ROW_NUMBER()OVER(ORDER BY ID) AS SN,TRAINING_REQ_NAME from TNA_TRAINING_REQUIREMENT WHERE"
                                + " TRAIN_NEED_ASS_ID=" + filterstring(GetID().ToString()) + " AND FLAG='TRAINING_REQ_SOFT'").Tables[0];
            int cols = dt.Columns.Count;
            StringBuilder str = new StringBuilder("");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("</tr>");
                for (int i = 0; i < cols; i++)
                {
                    if (i > 0)
                    {
                        str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                    }
                }
                str.Append("<td align=\"left\"><input type=\"radio\" id=\"ckID4\" name=\"ckID4\" value=\"" + dr["ID"].ToString() + "\"></td>");
                str.Append("</tr>");
            }
            disSoftTrainingRequirement.InnerHtml = str.ToString();
        }

        protected void BtnDelSoftTrainingReq_Click(object sender, EventArgs e)
        {
            if (delSoftTrainingReq != "")
            {
                string sql = "DELETE FROM TNA_TRAINING_REQUIREMENT WHERE ID='" + delSoftTrainingReq + "'";
                _clsDao.runSQL(sql);
                getSoftTrainingRequirement();
            } 
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            //populateDropDownList();
        }
    }
}
