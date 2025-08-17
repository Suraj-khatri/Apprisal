using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageMedicalBill : BasePage
    {
        clsDAO _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public ManageMedicalBill()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsdao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                this.hdnEmpId.Value = GetEmpId().ToString();
                PopulateBillData();
            }
            
        }

        public long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }

        protected void BtnSaveMedical_Click(object sender, EventArgs e)
        {
            try
            {
                ManageBillDetail();
                Response.Redirect("/Company/EmployeeWeb/ListMedicalBill.aspx?Id=" + hdnEmpId.Value + "");
            }
            catch
            {
                lblmsg.Text = "Error In Operation";
                lblmsg.ForeColor = System.Drawing.Color.Red;
            }

                 
        }

        private long GetID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private void ManageBillDetail()
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
            _clsdao.runSQL("Exec Proc_ManageMedicalBill @flag="+flag+",@id="+ GetID() +",@emp_id="+GetEmpId()+",@bill_date="+filterstring(txtBillDate.Text)+",@bill_Amount="+filterstring(txtBillAmount.Text)+",@narration="+filterstring(txtNarration.Text)+",@user="+ReadSession().Emp_Id+"");
          
        }

        private void PopulateBillData()
        {

            DataSet ds = _clsdao.getDataset("select BILL_DATE,BILL_AMOUNT,NARRATION from medicalbills where ID="+ GetID() +"");

            DataTable dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                txtBillDate.Text = dr["BILL_DATE"].ToString();
                txtBillAmount.Text = dr["BILL_AMOUNT"].ToString();
                txtNarration.Text = dr["NARRATION"].ToString();
            }

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            _clsdao.runSQL("Exec Proc_ManageMedicalBill @flag='d',@id=" + GetID() + "");
            Response.Redirect("/Company/EmployeeWeb/ListMedicalBill.aspx?Id=" + hdnEmpId.Value + "");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/ListMedicalBill.aspx?Id=" + hdnEmpId.Value + "");
        }
    }
}