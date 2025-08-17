using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class UploadFutureContribution : BasePage
    {
        clsDAO _clsdao = new clsDAO();
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 108) == false)
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
                    string saved_file_name = root + "\\doc\\payroll_upload\\futuretaxcontribution\\" + fileName;
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
            string upload_path = root + "doc\\payroll_upload\\futuretaxcontribution\\" + p_file;

            string msg = _clsdao.GetSingleresult("exec [ProcUploadAdhocContribution] @flag='f',"
            + "@file_path= " + filterstring(upload_path) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "");
            lblMessage.Text = msg;
        }
    }
}
