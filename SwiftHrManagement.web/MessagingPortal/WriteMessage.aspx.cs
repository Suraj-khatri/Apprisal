using SwiftHrManagement.web.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftHrManagement.web.MessagingPortal
{
    public partial class WriteMessage : BasePage
    {
        clsDAO _cls = new clsDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDDL();
            }
        }

        protected void PopulateDDL()
        {
            _cls.CreateDynamicDDl(mesageGroupDDL, "SELECT GroupId, GroupName FROM MsgPortalGrp WHERE Is_Active = 'Y'", "GroupId", "GroupName", "", "SELECT");
        }
        protected void sendMessage_Click(object sender, EventArgs e)
        {
            string msgtype = "";
            string empId = "";

            if (mesageGroupDDL.SelectedValue != "" && empName.Text != "")
            {
                GetStatic.SweetAlertErrorMessage(this, "Error!", "Choose group or employee only");
            }
            else if (mesageGroupDDL.SelectedValue == "" && empName.Text == "")
            {
                GetStatic.SweetAlertErrorMessage(this, "Error!", "Select either group or employee");
            }
            else
            {
                if (empName.Text == "")
                {
                    msgtype = "G";
                }
                else
                {
                    string[] empInfo = empName.Text.Split('|');
                    empId = empInfo[1];
                    msgtype = "I";
                }
                string sql = "EXEC proc_messagePortal @flag = 's', @senderId = '" + ReadSession().Emp_Id.ToString() + "', @msgType = '" + msgtype + "' ";
                sql += ", @message = " + filterstring(message.Text) + ", @groupId = '" + mesageGroupDDL.SelectedValue + "', @receiverId = '" + empId + "'";
                string res = _cls.GetSingleresult(sql);
                if (res == "SUCCESS")
                {
                    GetStatic.SweetAlertSuccessMessage(this, "Success", "Message send successfully");
                    message.Text = "";
                    mesageGroupDDL.SelectedValue = "";
                    empName.Text = "";
                }
                else
                    GetStatic.SweetAlertErrorMessage(this, "Error", "Oops!! something went wrong");
            }

        }

        protected void clear_Click(object sender, EventArgs e)
        {
            message.Text = "";
            mesageGroupDDL.SelectedValue = "";
            empName.Text = "";
        }
    }
}