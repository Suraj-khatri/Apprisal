using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.IO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.LeaveManagement.LeaveAssign
{
    public partial class UploadLeaveAssignment : BasePage
    {
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = null;
        public UploadLeaveAssignment()//undo this
        {
            _clsdao = new clsDAO();
            _roleMenuDao = new RoleMenuDAOInv();
            _fileuploader = new FileUploaderDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 10085) == false)
                {
                    Response.Redirect("/Error.aspx");
                }                
            }            
        }
        public string uploadFile(String fileName, string root)
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
                    string saved_file_name = root + "\\doc\\Leave\\" + fileName;
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
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string type = "";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            switch (type)
            {
                case "csv":
                    break;
                default:
                    lblMessage.Text = "Error:Unable to upload,Invalid file type!";
                    lblMessage.ForeColor = Color.Red;
                    return;
            }
            string root = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(p_file, root);

            if (info.Substring(0, 5) == "error")
                return;
            string upload_path = root + "doc\\Leave\\" + p_file;

            string msg = _clsdao.GetSingleresult("Exec procUploadLeaveAssignment 'a'," + filterstring(upload_path) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");

            lblMessage.Text = msg;
            lblMessage.ForeColor = Color.Green;

        }
    }
}
