using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FileUploader;

namespace SwiftHrManagement.web.Payrole_management.TaxUpload
{
    public partial class taxupload : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        FileUploaderDao _fileuploader = null;

        public taxupload()
        {
            this.CLsDAo = new clsDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            _fileuploader = new FileUploaderDao();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 91) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                setDDLs();
            }           
        }

        private void setDDLs()
        {
             CLsDAo.setDDL(ref DdlMonth, "Exec [proc_Get_monthList_for_payroll]", "month_number", "name", "", "Select");
            CLsDAo.CreateDynamicDDl(DdlYear, "select FISCAL_YEAR_NEPALI from FiscalYear", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
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
                    string saved_file_name = root + "doc\\payroll_upload\\" + fileName;
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

        private void doUpload(char uploadtype)
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
            string upload_path = root + "doc\\payroll_upload\\" + p_file;

            string msg = CLsDAo.GetSingleresult("exec ProcUploadTaxFile '" + uploadtype + "'," + filterstring(DdlYear.Text) + ","
            + " " + filterstring(DdlMonth.Text) + "," + filterstring(upload_path) + "," + filterstring(ReadSession().Emp_Id.ToString()));
            lblMessage.Text = msg;
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            doUpload('L');
        }

        protected void BtnUploadTrial_Click(object sender, EventArgs e)
        {
            doUpload('T');
        }


    }
}
