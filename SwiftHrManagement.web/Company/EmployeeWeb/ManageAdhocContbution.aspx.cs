using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.ContributionDAO;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageAdhocContbution : BasePage
    {
        ContributionDAO _conDao = null;
        clsDAO _clsdao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        public ManageAdhocContbution()
        {
            _conDao = new ContributionDAO();
            this._clsdao = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 11) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                TxtDate.Enabled = false;
                _clsdao.setDDL(ref DdlContbOn, "Exec ProcStaticDataView 's','21'", "ROWID", "DETAIL_TITLE", "", "Select");
                if (GetId() > 0)
                {
                    BtnDelete.Visible = true;
                    populatAdhocCtb();
                }
                else
                {
                    BtnDelete.Visible = false;
                }
                getemployee();
                
            }
            BtnCancel.Attributes.Add("onclick", "history.back();return false");
        }
        private void getemployee()
        {
            Employee _empcore = new Employee();
            EmployeeDAO _empdao = new EmployeeDAO();
            if (GetId()> 0)
            {
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
                //LblEmpName.Text = _empcore.EmpName;
            }
            else
            {
                hdnempid.Value = GetEmpId().ToString();
                _empcore = _empdao.FindFullNameById(long.Parse(hdnempid.Value));
                //LblEmpName.Text = _empcore.EmpName;
            }            
        }
       protected long GetEmpId()
        {
            return (Request.QueryString["EmpId"] != null ? long.Parse(Request.QueryString["EmpId"].ToString()) : 0);
        }
        private long GetId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        private void populatAdhocCtb()
        {
            DataTable dt = _clsdao.getDataset("SELECT ID,EMPLOYEE_ID,CONTB_CODE,CONTB_TO,Is_Paid,convert(varchar, CONTB_DATE,101) as CONTB_DATE,"
            +" CONTB_AMOUNT_EMPLOYEE,CONTB_AMOUNT_EMPLOYER,"
            +" NARRATION FROM Adhoc_Contribution where ID="+GetId()+"").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                hdnempid.Value = dr["EMPLOYEE_ID"].ToString();
                TxtContbCode.Text = dr["CONTB_CODE"].ToString();
                DdlContbOn.SelectedValue = dr["CONTB_TO"].ToString();
                TxtAmountEmployer.Text = dr["CONTB_AMOUNT_EMPLOYER"].ToString();
                TxtAmtEmployee.Text = dr["CONTB_AMOUNT_EMPLOYEE"].ToString();
                TxtDate.Text = dr["CONTB_DATE"].ToString();
                TxtNarration.Text = dr["NARRATION"].ToString();
                if (bool.Parse(dr["Is_Paid"].ToString())== true)
                    ChkPaid.Checked = true;
                else
                    ChkPaid.Checked = false;
            }
        }
        private void ManageAdhocContb()
        {
            long id = GetId();
         
            if (id > 0)
            {

                string oldValue  =  _conDao.CRUDLog(id.ToString(), 'y');

                _clsdao.runSQL("Exec [ProcAdhocContribution] 'u','" + ReadSession().UserId + "'," + id + ",'" + hdnempid.Value + "','" + TxtContbCode.Text + "','" + DdlContbOn.Text + "',"
                + " " + filterstring(TxtDate.Text) + "," + filterstring(TxtAmtEmployee.Text) + "," + filterstring(TxtAmountEmployer.Text) + ",'" + TxtNarration.Text + "','" + ChkPaid.Checked + "'");
                
                string newValue = this._conDao.CRUDLog(id.ToString(),'y');
                this._conDao.LogJobHistoryReport("update", "Adhoc_Contribution", id.ToString(), oldValue, newValue, ReadSession().UserId);
            }
            else
            {

             string Id =  _clsdao.GetSingleresult("Exec [ProcAdhocContribution] 'i','" + ReadSession().UserId + "'," + id + ",'" + hdnempid.Value + "','" + TxtContbCode.Text + "','" + DdlContbOn.Text + "',"
                + " " + filterstring(TxtDate.Text) + "," + filterstring(TxtAmtEmployee.Text) + "," + filterstring(TxtAmountEmployer.Text) + ",'" + TxtNarration.Text + "','" + ChkPaid.Checked + "'");
                string Rowid = Id;
                string newValue = this._conDao.CRUDLog(Id);
                this._conDao.LogJobHistoryReport("Insert", "Adhoc_Contribution", Rowid, "", newValue, ReadSession().UserId);

            }
          }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (ChkPaid.Checked == true && TxtDate.Text == "")
            {
                LblMsg.Text = "Contribution date is mendatory for applied";
                LblMsg.ForeColor = System.Drawing.Color.Red;
                TxtDate.Focus();
                return;
            }
            try
            {
                ManageAdhocContb();
                Response.Redirect("/Company/EmployeeWeb/ListAdhocContbution.aspx?Id="+hdnempid.Value+"");
            }
            catch
            {
                LblMsg.Text = "Error in operation";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }

        }

        protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            try
            {
                string oldValue = this._conDao.CRUDLog(GetId().ToString(),'y');
                _clsdao.runSQL("Exec [ProcAdhocContribution] 'd','" + ReadSession().UserId + "','" + GetId() + "',null,null,null,"
            + " null,null,null,null");
                this._conDao.LogJobHistoryReport("Delete", "Adhoc_Contribution", GetId().ToString(), oldValue, "", ReadSession().UserId);

                Response.Redirect("/Company/EmployeeWeb/ListAdhocContbution.aspx?Id=" + hdnempid.Value + "");
            }
            catch
            {
                LblMsg.Text = "Error in Deletion";
                LblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ChkPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPaid.Checked == true)
            {
                TxtDate.Text = "";
                TxtDate.Enabled = true;
            }
            else
            {
                TxtDate.Text = "";
                TxtDate.Enabled = false;
            }
        }
    }
}
