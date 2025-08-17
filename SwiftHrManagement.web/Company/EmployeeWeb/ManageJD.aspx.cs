using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.IO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class ManageJD : BasePage
    {
        string file_2_be_deleted = "";
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = new clsDAO();
        public ManageJD()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._fileuploader = new FileUploaderDao();
        }

        protected long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private long GetId()
        {
            return (Request.QueryString["P_Id"] != null ? long.Parse(Request.QueryString["P_Id"].ToString()) : 0);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (!IsPostBack)
            {
                OnPopulateDDL();
                if (GetId() > 0)
                {
                    OnPopulateJD();
                    BtnSave.Visible = false;
                    fileUploadForm.Visible = false;
                    pnlDisplayFile.Visible = true;
                }
                else
                {
                    btnDelete.Visible = false;
                }
            }
        }

        private void OnPopulateJD()
        {
            DataTable dt = _clsdao.getDataset(" Exec [procManageEmployeeJD] @flag='s',@id=" + filterstring(GetId().ToString()) + "").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                ddlBranchName.Text = dr["branch_id"].ToString();
                ddlDeptName.Text = dr["dept_id"].ToString();
                ddlPositionName.Text = dr["position_id"].ToString();
                ddlSupervisorName.Text = dr["supervisor_id"].ToString();
                txtFromDate.Text = dr["from_date"].ToString();
                txtToDate.Text = dr["to_date"].ToString();
                lblFileDesc.Text = dr["file_desc"].ToString();
                lblFileType.Text = dr["file_type"].ToString();
                lblLink.Text = "<a target='_blank' href='/doc/JobDescription/" + dr["id"].ToString() + "." + dr["file_type"].ToString() + "'> Browse File </a>";
            }
        }

        private void OnPopulateDDL()
        {
            string branch_id = "", dept_id = "", position_id = "";
            DataTable dt = _clsdao.getDataset("select BRANCH_ID,DEPARTMENT_ID,POSITION_ID from Employee where EMPLOYEE_ID="+GetEmpId()+"").Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                branch_id = dr["BRANCH_ID"].ToString();
                dept_id = dr["DEPARTMENT_ID"].ToString();
                position_id = dr["POSITION_ID"].ToString();
            }
            _clsdao.CreateDynamicDDl(ddlBranchName, "SELECT BRANCH_ID,BRANCH_SHORT_NAME+' | '+BRANCH_NAME BRANCH_NAME FROM Branches"
                                    + " ORDER BY BRANCH_SHORT_NAME", "BRANCH_ID", "BRANCH_NAME", "" + branch_id + "", "");
            _clsdao.CreateDynamicDDl(ddlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments", "DEPARTMENT_ID", "DEPARTMENT_NAME", "" + dept_id + "", "");
            _clsdao.CreateDynamicDDl(ddlPositionName, "SELECT ROWID,DETAIL_TITLE FROM StaticDataDetail WHERE TYPE_ID=4", "ROWID", "DETAIL_TITLE", "" + position_id + "", "");
            _clsdao.CreateDynamicDDl(ddlSupervisorName, "SELECT EMPLOYEE_ID,EMP_CODE+' | '+FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME EMP_NAME FROM Employee"
                            +" ", "EMPLOYEE_ID", "EMP_NAME", "" + ReadSession().Branch_Id.ToString() + "", "");

            ddlSupervisorName.SelectedValue=_clsdao.GetSingleresult("SELECT SUPERVISOR FROM SuperVisroAssignment "
                            +" WHERE EMP="+GetEmpId()+"  AND SUPERVISOR_TYPE='i' AND record_status='y'");
        }
 
        public string uploadFile(String fileName, string rowid, string WorkFlowPath)
        {
            if (fileName == "")
            {
                return "error:Invalid filename supplied";
            }
            if (fileUpload.PostedFile.ContentLength == 0)
            {
                return "error:Invalid file content";
            }
            try
            {
                if (fileUpload.PostedFile.ContentLength <= 2048000)
                {
                    string saved_file_name = WorkFlowPath + "\\doc\\JobDescription\\" + fileName;
                    fileUpload.PostedFile.SaveAs(saved_file_name);
                    return saved_file_name;
                }
                else
                {
                    lblMessage.Text = "Error:Unable to upload,File size is too large!";
                    lblMessage.ForeColor = Color.Red;
                    return "error:Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
            }
        }

        protected void ddlBranchName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _clsdao.CreateDynamicDDl(ddlDeptName, "SELECT DEPARTMENT_ID,DEPARTMENT_NAME FROM Departments"
                    +" WHERE BRANCH_ID="+ddlBranchName.Text+"", "DEPARTMENT_ID", "DEPARTMENT_NAME", "", "");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string type = "doc";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            switch (type)
            {
                case "xls":
                    break;
                case "xlsx":
                    break;
                case "doc":
                    break;
                case "docx":
                    break;
                case "pdf":
                    break;
                default:
                    lblMessage.Text = "Error:Unable to upload,Invalid file type!";
                    lblMessage.ForeColor = Color.Red;
                    return;
            }
            string docPath = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileDescription.Text + "." + type, GetEmpId().ToString(), docPath);

            if (info.Substring(0, 5) == "error")
                return;

            string retValue = _clsdao.GetSingleresult("Exec [procManageEmployeeJD] @flag='i',@emp_id=" + filterstring(GetEmpId().ToString()) + ","
                                + " @branch_id="+filterstring(ddlBranchName.Text)+",@dept_id="+filterstring(ddlDeptName.Text)+","
                                + " @position_id=" + filterstring(ddlPositionName.Text) + ",@supervisor_id="+filterstring(ddlSupervisorName.Text)+","
                                + " @from_date="+filterstring(txtFromDate.Text)+",@to_date="+filterstring(txtToDate.Text)+","
                                + " @fileDesc=" + filterstring(TxtFileDescription.Text) + ",@fileType=" + filterstring(type) + ","
                                + " @user=" + filterstring(ReadSession().Emp_Id.ToString()));

            string location_2_move = docPath + "\\doc\\JobDescription".ToString();

            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);

            string strMessage = "File Uploaded as  " + file_2_create;

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Green;
            Response.Redirect("ListJD.aspx?Id=" + GetEmpId() + "");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListJD.aspx?Id=" + GetEmpId() + "");
        }
    }
}
