using System;
using SwiftHrManagement.DAL.Role;
using System.Data;

namespace SwiftHrManagement.web.AttendenceWeb
{
    public partial class ManageOfficeTime : BasePage
    {
        clsDAO _clsDao = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;

        public ManageOfficeTime()
        {
            _clsDao = new clsDAO();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (getId() > 0)
                {
                    populateData();
                }
            }
        }

        private long getId()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }

        private void populateData()
        {
            DataTable dt = new DataTable();
            dt = _clsDao.getDataset("Exec proc_OfficeTimeSetup @flag='s',@id=" + getId() + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            if (dr == null)
                return;

            ddlOfficeTiming.Text = dr["flag"].ToString();
            txtFromDate.Text = dr["from_date"].ToString();
            txtToDate.Text = dr["to_date"].ToString();
            txtFromTime.Text = dr["from_time"].ToString();
            txtToTime.Text = dr["to_time"].ToString();
            txtToleranceStartTime.Text = dr["toleranceFromTime"].ToString();
            txtToleranceEndTime.Text = dr["toleranceToTime"].ToString();
        }

        protected void BtnSave_Click1(object sender, EventArgs e)
        {
            string msg = CheckData();
            if (msg == "0")
            {
                ProcessData();
                Response.Redirect("/AttendenceWeb/ListOfficeTime.aspx");
            }
            else
            {
                lblmsg.Text = msg;
                lblmsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private string CheckData()
        {
            string result;
            string sql = "Exec proc_OfficeTimeSetup @flag ='c' ";
            sql = sql + ", @id = " + filterstring(getId().ToString());
            sql = sql + ", @timeFlag = " + filterstring(ddlOfficeTiming.Text);
            sql = sql + ", @fromDate = " + filterstring(txtFromDate.Text);
            sql = sql + ", @toDate = " + filterstring(txtToDate.Text);
            sql = sql + ", @fromTime = " + filterstring(txtFromTime.Text);
            sql = sql + ", @toTime = " + filterstring(txtToTime.Text);
            sql = sql + ", @createdBy = " + filterstring(ReadSession().Emp_Id.ToString());
            sql = sql + ", @modifiedBy = " + filterstring(ReadSession().Emp_Id.ToString());
            result = _clsDao.GetSingleresult(sql);
            return result;
        }
        private void ProcessData()
        {
            string sql = "Exec proc_OfficeTimeSetup @flag =" + (getId().ToString() == "0" ? "'i'" : "'u'");
            sql = sql + ", @id = " + filterstring(getId().ToString());
            sql = sql + ", @timeFlag = " + filterstring(ddlOfficeTiming.Text);
            sql = sql + ", @fromDate = " + filterstring(txtFromDate.Text);
            sql = sql + ", @toDate = " + filterstring(txtToDate.Text);
            sql = sql + ", @fromTime = " + filterstring(txtFromTime.Text);
            sql = sql + ", @toTime = " + filterstring(txtToTime.Text);
            sql = sql + ", @toleranceFromTime = " + filterstring(txtToleranceStartTime.Text);
            sql = sql + ", @toleranceToTime = " + filterstring(txtToleranceEndTime.Text);
            sql = sql + ", @createdBy = " + filterstring(ReadSession().Emp_Id.ToString());
            sql = sql + ", @modifiedBy = " + filterstring(ReadSession().Emp_Id.ToString());
            _clsDao.runSQL(sql);
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AttendenceWeb/ListOfficeTime.aspx");
        }
    }
}