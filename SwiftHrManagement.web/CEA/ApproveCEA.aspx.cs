using System;
using System.Data;
using System.Drawing;
using SwiftHrManagement.DAL.CEA;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.CEA
{
    public partial class ApproveCEA : BasePage
    {
        string file_2_be_deleted = "";
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        FileUploaderDao _fileuploader = null;
        clsDAO _clsDao = null;
        CEADao _ceaDao = null;
        public ApproveCEA()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._fileuploader = new FileUploaderDao();
            this._clsDao = new clsDAO();
            this._ceaDao = new CEADao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 259) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                //PopulateData();

                if (Getflag() == "A")
                {
                    string msg = _ceaDao.OnApprove(GetId().ToString(),GetAmount());
                    Response.Redirect("ListPendingCEA.aspx");
                }
                else if (Getflag()=="R")
                {
                    string msg = _ceaDao.OnReject(GetId().ToString());
                     Response.Redirect("ListPendingCEA.aspx");
                }
            }
        }

        protected long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        protected String Getflag()
        {
            return (Request.QueryString["Flag"] != "" ? Request.QueryString["Flag"].ToString() : null);
        }
        protected String GetAmount()
        {
            return (Request.QueryString["amt"] != "" ? Request.QueryString["amt"].ToString() : null);
        }

        //private void PopulateData()
        //{
        //    DataTable dt = _clsDao.getDataset(" Exec [proc_CEA] @flag='s',@id=" + filterstring(GetId().ToString()) + "").Tables[0];

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        lblEmployeeName.Text = dr["emp_id"].ToString();
        //        lblbillDate.Text = dr["bill_date"].ToString();
        //        lblBillAmt.Text = ShowDecimal(dr["Bill_Amount"].ToString());
        //        lblFromFy.Text = dr["From_FY"].ToString();
        //        lblFromMonth.Text = dr["From_month"].ToString();
        //        lblToFy.Text = dr["To_FY"].ToString();
        //        lblToMonth.Text = dr["To_month"].ToString();
        //        txtnarration.Text = dr["Description"].ToString();
        //        //lblappBy.Text = dr["Approved_by"].ToString();
        //        lblFileDesc.Text = dr["file_desc"].ToString();
        //        lblFileType.Text = dr["file_type"].ToString();
        //        lblLink.Text = "<a target='_blank' href='/doc/CEABills/" + dr["id"].ToString() + "." + dr["file_type"].ToString() + "'> Browse File </a>";
        //    }
        //}

        //protected void btnApprove_Click(object sender, EventArgs e)
        //{
        //    string msg = _ceaDao.OnApprove(GetId().ToString());

        //    lblMessage.Text = msg;
        //    lblMessage.ForeColor = Color.Green;
        //}

        //protected void btnReject_Click(object sender, EventArgs e)
        //{
        //    string msg = _ceaDao.OnReject(GetId().ToString());

        //    lblMessage.Text = msg;
        //    lblMessage.ForeColor = Color.Green;
        //}
    }
}