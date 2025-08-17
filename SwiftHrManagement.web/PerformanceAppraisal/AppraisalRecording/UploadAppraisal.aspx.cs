using System;
using System.Configuration;
using System.Drawing;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.PerformanceAppraisal.AppraisalRecording
{
    public partial class UploadAppraisal : BasePage
    {
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsdao = null;
        FileUploaderDao _fileuploader = null;
        public UploadAppraisal()
        {
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsdao = new clsDAO();
            this._fileuploader = new FileUploaderDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 92) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                _clsdao.CreateDynamicDDl(fiscalYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "");
                fiscalYear.SelectedValue = _clsdao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where flag='1'");
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
                    string saved_file_name = root + "\\doc\\AppraisalRating\\" + fileName;
                    fileUpload.PostedFile.SaveAs(saved_file_name);
                    return saved_file_name;
                }
                else
                {
                    lblMsgDis.Text = "Error:Unable to upload,File size is too large!";
                    lblMsgDis.ForeColor = Color.Red;
                    return "error:Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
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
                    lblMsgDis.Text = "Error:Unable to upload,Invalid file type!";
                    lblMsgDis.ForeColor = Color.Red;
                    return;
            }
            string root = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(p_file, root);

            if (info.Substring(0, 5) == "error")
                return;
            string upload_path = root + "doc\\AppraisalRating\\" + p_file;

            string msg = _clsdao.GetSingleresult("exec [ProcUploadAppraisalRating] @flag='a',@fy_id=" + filterstring(fiscalYear.Text) + ","
            + " @file_path=" + filterstring(upload_path) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()));

            lblMsgDis.Text = msg;
        }
    }
}