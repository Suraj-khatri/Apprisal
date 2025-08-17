using System;
using System.Drawing;
using System.Configuration;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.AssetManagement
{
    public partial class upload_asset : BasePage
    {
        RoleMenuDAOInv _roleMenuDao = null;
        ClsDAOInv _clsdao = null;
        public upload_asset()
        {
            _clsdao = new ClsDAOInv();
            _roleMenuDao = new RoleMenuDAOInv();
        }
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 211) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                LblMessageText.Text = GetMessage().ToString();
            }
        }
        private string GetMessage()
        {
            return (Request.QueryString["msg"] != null ? (Request.QueryString["msg"]) : "");
        }

        protected void BtnUploadDM_Click(object sender, EventArgs e)
        {           
                try
                {
                    string type = "";
                    string p_file = fileDM.PostedFile.FileName.ToString().Replace("\\", "/");
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
                            lblmsg1.Text = "Error:Unable to upload,Please select CSV file!";
                            lblmsg1.ForeColor = Color.Red;
                            return;
                    }
                    string root = ConfigurationSettings.AppSettings["root"];
                    string info = uploadFile1(p_file, root);

                    if (info.Substring(0, 5) == "error")
                        return;
                    string upload_path = root + "doc\\Asset_Doc\\" + p_file;

                    string msg = _clsdao.GetSingleresult("exec [procUploadAssetBooking] 'a',"
                    + " " + filterstring(upload_path) + "," + filterstring(ReadSession().Emp_Id.ToString()) + "");
                    Response.Redirect("upload_asset.aspx?msg=" + msg + "");
                }
                catch
                {
                    lblmsg1.Text = "Error in Uploading!";
                    lblmsg1.ForeColor = System.Drawing.Color.Red;
                }            
        }
        public string uploadFile1(String fileName, string root)
        {
            if (fileName == "")
            {
                return "error:Invalid filename supplied";
            }
            if (fileDM.PostedFile.ContentLength == 0)
            {
                return "error:Invalid file content";
            }
            try
            {
                if (fileDM.PostedFile.ContentLength <= 2048000)
                {
                    string saved_file_name = root + "\\doc\\Asset_Doc\\" + fileName;
                    fileDM.PostedFile.SaveAs(saved_file_name);
                    return saved_file_name;
                }
                else
                {
                    lblmsg1.Text = "Error:Unable to upload,File size is too large!";
                    lblmsg1.ForeColor = Color.Red;
                    return "error:Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
            }
        }
    }
}

