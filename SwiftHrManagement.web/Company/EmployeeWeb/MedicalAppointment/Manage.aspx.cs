using System;
using System.Data;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb.MedicalAppointment
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

                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 242) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                if (DoesHrUser(ReadSession().Emp_Id.ToString()))
                {
                    ddlIsConsulted.Enabled = true;
                }
                else
                {
                    ddlIsConsulted.Enabled = false;
                    LblEmpName.Text = CLsDAo.GetSingleresult("select dbo.GetEmployeeInfoById("+filterstring(ReadSession().Emp_Id.ToString())+")");
                    txtEmpName.Visible = false;
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
            txtExtensionNum.Attributes.Add("onblur", "checknumber(this);");
        }

        private void OnPopulateData()
        {
            DataTable dt = new DataTable();
            dt = CLsDAo.getDataset("Exec [procDocAppointment] @flag='s',@id=" + filterstring(GetID().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            
            ddlIsConsulted.Text = dr["IS_CONSULTED"].ToString();
            txtEmpName.Text = dr["EMP_NAME"].ToString();
            LblEmpName.Text = dr["EMP_NAME"].ToString();
            txtPatientName.Text = dr["PATIENT_NAME"].ToString();
            txtSymptoms.Text = dr["SYMPTOMS"].ToString();
            txtExtensionNum.Text = dr["EXTENSION_NUM"].ToString();
            
        }

        private long GetID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        
        private void deleteOperation()
        {
            string msg = CLsDAo.GetSingleresult("exec [procDocAppointment] @flag='d',@id=" + filterstring(GetID().ToString()) + "");
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
            string emp_id = getEmpIdfromInfo(LblEmpName.Text);
            if (emp_id == "0")
            {
                LblMsg.Text = "Please select employee!";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            string msg = CLsDAo.GetSingleresult("exec [procDocAppointment] @FLAG=" + filterstring(flag) + ",@ID=" + filterstring(GetID().ToString()) + ""
                        + " ,@EMP_ID=" + filterstring(emp_id) + ",@PATIENT_NAME=" + filterstring(txtPatientName.Text) + ","
                        + "  @SYMPTOMS=" + filterstring(txtSymptoms.Text) + ""
                        + " ,@EXTENSION_NUM=" + filterstring(txtExtensionNum.Text) + ",@IS_CONSULTED=" + filterstring(ddlIsConsulted.Text) + ","
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
