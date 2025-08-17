using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.WorkFlowManagement;
namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowMember
{
    public partial class MemberManage : BasePage
    {

        RoleMenuDAOInv _roleMenuDao = null;
        WFCategoryCore _catCore = null;
        WFMemberCore _memCore = null;
        WFCategoryDAO _wfCatDAO = null;
        WFMemberDAO _wfMemDAO = null;
        clsDAO _clsdao = null;
        public MemberManage()
        {
            _roleMenuDao = new RoleMenuDAOInv();
            _catCore = new WFCategoryCore();
            _memCore = new WFMemberCore();
            _wfCatDAO = new WFCategoryDAO();
            _wfMemDAO = new WFMemberDAO();
            _clsdao = new clsDAO();
        }
        private long GetMemberID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private long GetCatID()
        {
            return (Request.QueryString["CatId"] != null ? long.Parse(Request.QueryString["CatId"].ToString()) : 0);
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 82) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PouplateDdlList();
                long id = GetMemberID();
                long catID = GetCatID();
                string deptName = _clsdao.GetSingleresult("SELECT WF_DeptName FROM WF_CATEGORY WHERE WF_CATEGORYID = " + GetCatID() + "");
                lblDeptname.Text = deptName;

                if (id > 0)
                {
                    _clsdao.CreateDynamicDDl(DdlReqByDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
                    PopulateMember();
                    Btn_Save.Visible = false;
                }
                else
                {
                    _catCore = this._wfCatDAO.GetCaogoryNameByCatID(catID);                    
                    this.TxtWFCategory.Text = _catCore.WFCatName;
                    this.Btn_Delete.Visible = false;
                    this.Btn_Update.Visible = false;
                }
                
            }
            Btn_Back.Attributes.Add("onclick", "history.back();return false");
        }
        private void PopulateMember()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("SELECT M.WF_MEMBERID,M.WF_CATEGORYID,C.WF_CATNAME,M.EMPLOYEE_ID,E.BRANCH_ID,E.DEPARTMENT_ID FROM WF_MEMBER M INNER JOIN"
                            + " WF_CATEGORY C ON C.WF_CATEGORYID = M.WF_CATEGORYID INNER JOIN Employee E ON E.EMPLOYEE_ID=M.Employee_ID"
                            + " WHERE M.WF_MEMBERID = '" + GetMemberID() + "'").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                TxtWFCategory.Text = dr["WF_CATNAME"].ToString();              
                DdlReqWithBranch.SelectedValue = dr["BRANCH_ID"].ToString();
                DdlReqByDept.SelectedValue = dr["DEPARTMENT_ID"].ToString();
                _clsdao.CreateDynamicDDl(DdlStaffName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee where branch_id='"+DdlReqWithBranch.Text+"' and department_id='"+DdlReqByDept.Text+"'", "EMPLOYEE_ID", "EmpName", "", "Select");
                DdlStaffName.SelectedValue = dr["EMPLOYEE_ID"].ToString();
            }
        }

        private void PouplateDdlList()
        {
            _clsdao.CreateDynamicDDl(DdlReqWithBranch, "SELECT BRANCH_ID,BRANCH_NAME FROM Branches", "BRANCH_ID", "BRANCH_NAME", "", "Select");
        }

        private void populateEmployees()
        {

            _clsdao.CreateDynamicDDl(DdlStaffName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE DEPARTMENT_ID=" + this.DdlReqByDept.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
        }

        protected void DdlReqByDept_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (DdlReqByDept.Text != "")
            {
                DdlStaffName.Enabled = true;
                _clsdao.CreateDynamicDDl(DdlStaffName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME + ' ' + MIDDLE_NAME + ' ' + LAST_NAME AS EmpName FROM Employee WHERE DEPARTMENT_ID=" + this.DdlReqByDept.Text + "", "EMPLOYEE_ID", "EmpName", "", "Select");
            }
        }

        protected void DdlReqWithBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlReqWithBranch.Text != "")
            {
                DdlReqByDept.Enabled = true;
                _clsdao.CreateDynamicDDl(DdlReqByDept, "select DEPARTMENT_ID,DEPARTMENT_NAME from Departments where BRANCH_ID=" + this.DdlReqWithBranch.Text + "", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "select");
            }
        }
        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                manageMemberList();                
                Response.Redirect("MemberList.aspx?Id="+ GetCatID());
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void manageMemberList()
        {
            long catId = GetCatID();
            long memID = GetMemberID();

            prepareMemberList();

            if (memID > 0)
            {                
                _wfMemDAO.Update(_memCore);
               
            }
            else
            {
                _wfMemDAO.Save(_memCore);
            }
        }

        private void prepareMemberList()
        {
            long id = GetCatID();
            long memID = GetMemberID();
            _memCore.EmployeeID = long.Parse(DdlStaffName.SelectedValue);
            _memCore.CategoryID = id;
            _memCore.MemberID = memID;
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {

            try
            {
                manageMemberList();
                Response.Redirect("MemberList.aspx?Id=" + GetCatID());
            }
            catch
            {
                LblMsg.Text = "Error in Insertion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                _memCore.MemberID = GetMemberID();
                _wfMemDAO.Delete(_memCore);
                Response.Redirect("MemberList.aspx?Id=" + GetCatID());
            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberList.aspx?Id=" + GetCatID());
        }
    }
}
