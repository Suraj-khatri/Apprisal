using System;
using System.Data;
using SwiftHrManagement.DAL.ExternalTransferPlanDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.web.EmployeeDiscontinuous
{
    public partial class Manage : BasePage
    {
        ExternalTransferPlanCore _externalTransCore = null;
        ExternalTransferPlanDAO _externalTransDao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO CLsDAo = null;
        public Manage()
        {
            this.CLsDAo = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            _externalTransCore = new ExternalTransferPlanCore();
            _externalTransDao = new ExternalTransferPlanDAO();
        }
        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 49) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDropdownList();

                if (this.GetID() > 0)
                {
                    BtnDelete.Visible = true;
                    PopulateEmployeeDiscontinuous();
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                txtEffectiveDate.Attributes.Add("OnBlur", "checkDateFormat(this);");
            }
        }
        private void PopulateDropdownList()
        {
            CLsDAo.CreateDynamicDDl(DdlDiscontReason, "Exec ProcStaticDataView 's','44'", "ROWID", "DETAIL_TITLE", "", "Select");          
        }
        private void PopulateEmployeeDiscontinuous()
        {            
            DataTable dt = CLsDAo.getTable("Exec procManageEmployeeDiscontinuous @flag='s',@rowid=" + filterstring(GetID().ToString()) + "");
            foreach (DataRow dr in dt.Rows)
            {
                lblEmpName.Text = dr["EMP_NAME"].ToString();
                txtEffectiveDate.Text = dr["EFFECTIVE_DATE"].ToString();
                txtDesc.Text = dr["DISCRIPTION"].ToString();
                DdlDiscontReason.SelectedValue = dr["DISCONTINUOUS_REASON"].ToString();
            }     
        }
        
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                OnSave();
            }
            catch
            {
                lblmsg.Text = "Error in Operation!";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnSave()
        {
            string msg = "";
            if (GetID() > 0)
            {
                msg= CLsDAo.GetSingleresult("exec procManageEmployeeDiscontinuous @flag='u',@empId=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ","
                + " @reasonMode=" + filterstring(DdlDiscontReason.Text) + ",@effectiveDate=" + filterstring(txtEffectiveDate.Text) + ","
                + " @Discription=" + filterstring(txtDesc.Text) + ",@user=" + filterstring(ReadSession().UserId) + ",@rowid=" + GetID() + "");
            }
            else
            {
                msg = CLsDAo.GetSingleresult("exec procManageEmployeeDiscontinuous @flag='i',@empId=" + filterstring(getEmpIdfromInfo(lblEmpName.Text)) + ","
                + " @reasonMode=" + filterstring(DdlDiscontReason.Text) + ",@effectiveDate=" + filterstring(txtEffectiveDate.Text) + ","
                + " @Discription=" + filterstring(txtDesc.Text) + ",@user=" + filterstring(ReadSession().UserId) + ",@rowid=" + GetID() + "");
            }
            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                OnDelete();
            }
            catch
            {
                lblmsg.Text = "Error In Delete Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void OnDelete()
        {
            string msg=CLsDAo.GetSingleresult("exec procManageEmployeeDiscontinuous @flag='d',@rowid=" + filterstring(GetID().ToString()));
            if (msg.Contains("SUCCESS"))
            {
                Response.Redirect("List.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }

        protected void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            lblEmpName.Text = GetEmpInfoForLabel(txtEmpName.Text, lblEmpName.Text);
            txtEmpName.Text = "";
        }

        private string GetEmpInfoForLabel(string curEmpInfo, string prevEmpInfo)
        {
            return (GetEmpInfoComponents(curEmpInfo).Length == 2) ? curEmpInfo : prevEmpInfo;
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

    }
}
