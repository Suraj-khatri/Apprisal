using SwiftHrManagement.web.LeaveManagementModule.LeaveFacility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.MessagingPortal
{
    public partial class ManageGroup : BasePage
    {
        clsDAO _cls = new clsDAO();
        private string emp_ids = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetId() != "")
                {
                    PopulateDDL();
                    PopulateData();
                }
                PopulateDDL();
            }
        }

        private void PopulateData()
        {
            string sql = "SELECT * FROM dbo.MsgPortalGrp WHERE GroupId = '" + GetId() + "'";
            var dt = _cls.getTable(sql);

            foreach (DataRow item in dt.Rows)
            {
                groupName.Text = item["GroupName"].ToString();
                groupDDL.SelectedValue = item["GroupId"].ToString();
            }
            groupDDL.Enabled = false;
            PopulateMembersDDL();
        }

        private void PopulateMembersDDL()
        {
            string sql = "SELECT dbo.GetEmployeeFullNameOfId(E.EMPLOYEE_ID) AS Name, E.EMPLOYEE_ID FROM MsgPortalGrpMembers M INNER JOIN Employee E ON E.EMPLOYEE_ID = M.EmployeeId ";
            sql += "WHERE M.GroupId = '" + GetId() + "';";

            _cls.CreateDynamicDDl(groupMemberDDL2, sql, "EMPLOYEE_ID", "Name", "", "");
        }

        protected string GetId()
        {
            return GetStatic.ReadQueryString("groupId", "");
        }

        private void PopulateDDL()
        {
            _cls.CreateDynamicDDl(groupDDL, "SELECT GroupId, GroupName FROM MsgPortalGrp WHERE Is_Active = 'Y'", "GroupId", "GroupName", "", "SELECT");
        }

        protected void groupMemberDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            emp_ids = Request.Form["ctl00$MainPlaceHolder$groupMemberDDL2"];
            if (groupDDL.SelectedValue != "")
            {
                if (emp_ids != null && emp_ids != "")
                {
                    string sql = "EXEC proc_messagePortal @flag = 'm', @groupId = " + filterstring(groupDDL.SelectedValue) + ", @empId = '" + (emp_ids) + "'";

                    string msg = _cls.GetSingleresult(sql);
                    if (msg == "SUCCESS")
                    {
                        GetStatic.SweetAlertSuccessMessage(this, "Success", "Employees successfully added");
                    }
                    else
                        GetStatic.SweetAlertErrorMessage(this, "Error!", "Oops!! Something went wrong");
                }
                else
                    GetStatic.SweetAlertErrorMessage(this, "Error!", "Select employee to add");
                
            }
            else
                GetStatic.SweetAlertErrorMessage(this, "Error!", "Select group first");
            
        }


        protected void removeButton_Click(object sender, EventArgs e)
        {
            string emp_ids1 = Request.Form["ctl00$MainPlaceHolder$groupMemberDDL1"];
            if (emp_ids != "")
            {
                string sql = "EXEC proc_messagePortal @flag = 'r', @empId = '" + emp_ids1 + "', @groupId= '" + groupDDL.SelectedValue + "'";
                string res = _cls.GetSingleresult(sql);
                if (res == "SUCCESS")
                {
                    GetStatic.SweetAlertSuccessMessage(this, "Success", "Employees successfuly removed");
                }
                else
                    GetStatic.SweetAlertErrorMessage(this, "Error!", "Oops!! Something went wrong");
            }
            else
                GetStatic.SweetAlertErrorMessage(this, "Error!", "No employees selecteed");
            
        }

        protected void addGroup_Click(object sender, EventArgs e)
        {
            string sql = "EXEC proc_messagePortal @flag = 'i', @groupName="+filterstring(groupName.Text)+", @is_Active='Y'";
            string res = _cls.GetSingleresult(sql);
            if (res == "SUCCESS")
            {
                GetStatic.SweetAlertSuccessMessage(this, "Success", "Message group successfully added");
                PopulateDDL();
            }
            else
                GetStatic.SweetAlertErrorMessage(this, "Error!", "Group name already exist");
        }

       
        protected void addEmp_Click(object sender, EventArgs e)
        {
            ListItem item = new ListItem();
            string empDetail = empName.Text;

            string[] detail = empDetail.Split('|');

            item.Text = detail[0];
            item.Value = detail[1];

            foreach (ListItem li in groupMemberDDL2.Items)
            {
                if (li.Value == item.Value)
                {
                    GetStatic.SweetAlertErrorMessage(this, "Error!", "Employee already added");
                    empName.Text = "";
                    return;
                }
            }

            groupMemberDDL1.Items.Add(item);
            empName.Text = "";
        }

        protected void groupDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupMemberDDL1.Items.Clear();
            if (groupDDL.Text != "")
            {
                string sql = "SELECT dbo.GetEmployeeFullNameOfId(E.EMPLOYEE_ID) AS Name, E.EMPLOYEE_ID FROM MsgPortalGrpMembers M INNER JOIN Employee E ON E.EMPLOYEE_ID = M.EmployeeId ";
                sql += "WHERE M.GroupId = " + filterstring(groupDDL.SelectedValue) + "";

                _cls.CreateDynamicDDl(groupMemberDDL2, sql, "EMPLOYEE_ID", "Name", "", "");
            }
            else
                groupMemberDDL2.Items.Clear();
        }

    }
}