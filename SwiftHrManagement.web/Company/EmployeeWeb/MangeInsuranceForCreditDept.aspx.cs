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

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class MangeInsuranceForCreditDept : System.Web.UI.Page
    {
        clsDAO swift = null;
        public MangeInsuranceForCreditDept()
        {
            swift = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (GetID() > 0)
                {
                    Btn_Delete.Visible = true;
                    populateData();
                }
                else
                {
                    Btn_Delete.Visible = false;

                }
              
                Ddl_InsurerName();
            }           
        }
        private long GetID()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private void populateData()
        {
            DataTable dt = new DataTable();
            dt = swift.getDataset("select ROW_ID,COSTOMER_ID,INSURER_ID,INSURED_AMT,INSURED_DATE,EXPIRY_DATE,INSURENCE_POLICY,INSURED_PROPERTY,NERRATION from InsuranceCreditDept where ROW_ID= " + GetID() + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                hdnCustomerId.Value = dr["COSTOMER_ID"].ToString();
                DdlInsurerName.Text = dr["INSURER_ID"].ToString();
                txtInsuredAmount.Text = dr["INSURED_AMT"].ToString();
                txtInuredDate.Text = dr["INSURED_DATE"].ToString();
                txtExpiredDate.Text = dr["EXPIRY_DATE"].ToString();
                txtInsPolicy.Text = dr["INSURENCE_POLICY"].ToString();
                txtInsPropery.Text = dr["INSURED_PROPERTY"].ToString();
                txtNarration.Text = dr["NERRATION"].ToString();
               
            }

        }


        private void Ddl_InsurerName()
        {
            string selectValue = "";


            if (DdlInsurerName.SelectedItem != null)
                selectValue = DdlInsurerName.SelectedItem.Value.ToString();
            swift.setDDL(ref DdlInsurerName, "Exec ProcStaticDataView 's','33'", "ROWID", "DETAIL_TITLE", selectValue, "Select");

        }
        

        protected void Btn_Save_Click(object sender, EventArgs e)
        {

           
            try
            {

                if (GetID() > 0 )

                {

                    swift.runSQL(" update InsuranceCreditDept set COSTOMER_ID='" + hdnCustomerId.Value + "', INSURER_ID='" + DdlInsurerName.SelectedValue + "',INSURED_AMT='" + txtInsuredAmount.Text + "', INSURED_DATE='" + txtInuredDate.Text + "', EXPIRY_DATE='" + txtExpiredDate.Text + "',INSURENCE_POLICY='" + txtInsPolicy.Text + "',INSURED_PROPERTY='" + txtInsPropery.Text + "', NERRATION='" + txtNarration.Text + "' where ROW_ID=" + GetID() + "");
                    Response.Redirect("/Company/EmployeeWeb/ListInsuranceForCreditDept.aspx");

                

                }
                else
                {
                    swift.runSQL("insert into  InsuranceCreditDept(COSTOMER_ID,INSURER_ID,INSURED_AMT,INSURED_DATE,EXPIRY_DATE,INSURENCE_POLICY,INSURED_PROPERTY,NERRATION) VALUES('" + hdnCustomerId.Value + "' , '" + DdlInsurerName.SelectedValue + "' , '" + txtInsuredAmount.Text + "' ,'" + txtInuredDate.Text + "','" + txtExpiredDate.Text + "','" + txtInsPolicy.Text + "' ,'" + txtInsPropery.Text+ "',  '" + txtNarration.Text + "' )");
                    Response.Redirect("/Company/EmployeeWeb/ListInsuranceForCreditDept.aspx");

                
                }
            }

                catch
           
                {
                    LblMsg.Text = "Error In Operation";
                    LblMsg.ForeColor = System.Drawing.Color.Red;

                }


        
        }

      

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                swift.runSQL("delete from InsuranceCreditDept where ROW_ID=" + GetID() + "");
                Response.Redirect("/Company/EmployeeWeb/ListInsuranceForCreditDept.aspx");
            }
            catch
            {
               LblMsg.Text = "Error In Operation";
                    LblMsg.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Company/EmployeeWeb/ListInsuranceForCreditDept.aspx");
        }

        protected void TxtCustomerId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
