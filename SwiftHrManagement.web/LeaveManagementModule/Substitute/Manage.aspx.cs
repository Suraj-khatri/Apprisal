using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;
using System.Data;

namespace SwiftHrManagement.web.LeaveManagementModule.Substitute
{
    public partial class Manage : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        public Manage()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 243) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (DoesHrUser(ReadSession().Emp_Id.ToString()))
                {
                    divHR.Visible = true;
                }
                else
                {
                    OnPopulateEmployee();
                    divSup.Visible = true;
                }
                if (GetID() > 0)
                {
                    OnPopulateData();
                    BtnDelete.Visible = true;
                }
                else
                {
                    BtnDelete.Visible = false;
                }
            }

            BtnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void OnPopulateEmployee()
        {
            CLsDAo.CreateDynamicDDl(ddlEmpName, "EXEC [ProcGetSupervisorEmployee] @FLAG='a',@SUPERVISOR_ID=" + filterstring(ReadSession().Emp_Id.ToString()) + "", "EMPLOYEE_ID", "EMPLOYEE_NAME", "", "SELECT");
        }

        private void OnPopulateData()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [proc_LeaveSubstituteAssign] @flag='s',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if (DoesHrUser(ReadSession().Emp_Id.ToString()))
            {
                divHR.Visible = true;
                //txtEmpName.Text = dr["EMP_NAME"].ToString();
                LblEmpName.Text = dr["EMP_NAME"].ToString();
            }
            else
            {
                divSup.Visible = true;
                ddlEmpName.SelectedValue = dr["EMP_ID"].ToString();
            }
            txtWorkingDate.Text = dr["WORKING_DATE"].ToString();

        }

        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void deleteOperation()
        {
            string msg = CLsDAo.GetSingleresult("exec [proc_LeaveSubstituteAssign] @flag='d',@id=" + filterstring(GetID().ToString()) + "");
            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string flag = "";
            if (GetID() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }
            string emp_id="";

            if (DoesHrUser(ReadSession().Emp_Id.ToString()))            
                emp_id = getEmpIdfromInfo(LblEmpName.Text);
            else
                emp_id = ddlEmpName.Text;

            if (emp_id == "" || emp_id=="0")
            {
                LblMsg.Text = "Please select employee!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            string msg = CLsDAo.GetSingleresult("exec [proc_LeaveSubstituteAssign] @FLAG=" + filterstring(flag) + ",@ID=" + filterstring(GetID().ToString()) + ""
                        + " ,@EMP_ID=" + filterstring(emp_id) + ",@WROKING_DATE=" + filterstring(txtWorkingDate.Text) + ","
                        + "  @USER=" + filterstring(ReadSession().Emp_Id.ToString()) + "");

            if (msg.Contains("Success"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                LblMsg.Text = msg;
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            LblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, LblEmpName.Text);
            txtEmpName.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deleteOperation();
            }
            catch
            {
                LblMsg.Text = "Error In Operation!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
