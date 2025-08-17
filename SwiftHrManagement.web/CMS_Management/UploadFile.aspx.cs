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
using SwiftHrManagement.DAL.CMS_Management;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;
using System.Text;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.CMS_Management
{
    public partial class UploadFile : BasePage
    {
        string file_2_be_deleted = "";
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _roleMenuDao = null;
        CMSCore cmsCore = null;
        CMSDAO cmsdao = null;
        clsDAO _clsDao = null;
        public UploadFile()
        {
            this._fileuploader = new FileUploaderDao();
            this._roleMenuDao = new RoleMenuDAOInv();
            this.cmsCore = new CMSCore();
            this.cmsdao = new CMSDAO();
            this._clsDao = new clsDAO();
        }
        private long GetPageID()
        {
            return (Request.QueryString["ID"] != null ? long.Parse(Request.QueryString["ID"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 98) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                long Id = this.GetPageID();
                if (Id > 0)
                {
                    this.cmsCore = this.cmsdao.FindById(Id);
                    this.lblPageName.Text = this.cmsCore.FuncName;
                }
                else
                {
                    lblPName.Visible = false;
                    ddlPName.Visible = true;
                    BtnBack.Visible = false;
                    setDDL();

                }
                listFileInformation(_fileuploader.GetCmsFiles(Id.ToString()));
            }
            lblMessage.Text = "";
        }

        private void setDDL()
        { 
            var sql = "SELECT id,func_name FROM CMS_functions WHERE  1=1 ORDER BY func_name";
            _clsDao.setDDL(ref ddlPageName, sql, "id", "func_name", "", "Select");
        }


        private void listFileInformation(DataTable dt)
        {
            StringBuilder sb = new StringBuilder("<div class=\"table-responsive\"> <table class=\"table table-bordered table-striped table-condensed\">");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th>S. No.</th>");
            sb.AppendLine("<th>File Desciption</th>");
            sb.AppendLine("<th>File Type</th>");
            sb.AppendLine("<th>Select</th>");
            sb.AppendLine("<th>View</th>");
            sb.AppendLine("</tr>");

            int sNo = 1;

            foreach (DataRow item in dt.Rows)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>" + sNo + "</td>");
                sb.AppendLine("<td>" + item["doc_desc"].ToString() + "</td>");
                sb.AppendLine("<td>" + item["doc_ext"].ToString() + "</td>");
                sb.AppendLine("<td class=\"text-center\"><span title = \"Delete Voucher\" class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" onclick = \"DeleteUploadFile('" + item["rowid"].ToString() + "')\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i></td></span>");
                sb.AppendLine("<td class=\"text-center\"><a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" href=\"/doc/CMS_Management/" + item["funct_id"].ToString() + "/" + item["rowid"].ToString() +"."+ item["doc_ext"].ToString() + "\"><i class=\"fa fa-eye\"></i></a></td>");
                sNo++;
            }
            sb.AppendLine("</table></div>");
            fileDesc.InnerHtml = sb.ToString();

        }
        public string uploadFile(String fileName, string rowid)
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
                string saved_file_name = GetStatic.GetUploadRoot() + "tmp\\" + rowid + "_" + fileName;
                fileUpload.PostedFile.SaveAs(saved_file_name);
                return saved_file_name;

                //if (fileUpload.PostedFile.ContentLength <= 2100000000)
                //{
                //    string saved_file_name = cms + "\\doc\\tmp\\" + rowid + "_" + fileName;
                //    fileUpload.PostedFile.SaveAs(saved_file_name);
                //    return saved_file_name;
                //}
                //else
                //{
                //    return "error:Unable to upload,file exceeds maximum limit";
                //}
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
            }
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string type = "doc";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            //switch (type)
            //{
            //    case "xls":
            //        break;
            //    case "xlsx":
            //        break;
            //    case "doc":
            //        break;
            //    case "docx":
            //        break;
            //    case "jpg":
            //        break;
            //    case "gif":
            //        break;
            //    case "pdf":
            //        break;
            //    case "htm":
            //        break;
            //    case "html":
            //        break;
            //    case "txt":
            //        break;
            //    default:
            //        lblMessage.Text = "Error:Unable to upload,Invalid file type!";
            //        lblMessage.ForeColor = Color.Red;
            //        return;
            //}

            string cms = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileDescription.Text + "." + type, GetPageID().ToString());

            if (info.Substring(0, 5) == "error")
                return;
        
            string retValue = saveData(long.Parse(GetPageID().ToString()) > 0 ? GetPageID().ToString() : ddlPageName.Text, TxtFileDescription.Text, this.ReadSession().UserId.ToString(), type, txtFileDate.Text);
            string location_2_move = GetStatic.GetUploadRoot() + "CMS_Management\\" + GetPageID().ToString();

            string file_2_create = location_2_move + "\\" + retValue + "." + type;
            //string location_2_move = cms + "\\doc\\CMS_Management\\" + GetPageID().ToString();
            //string file_2_create = location_2_move + "\\" + retValue + "." + type;
            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);
            File.Move(info, file_2_create);
            string strMessage = "Sucess!!Uploaded as  " + file_2_create;
            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Green;
            listFileInformation(_fileuploader.GetCmsFiles(int.Parse(GetPageID().ToString())>0 ? GetPageID().ToString() : ddlPageName.Text));
        }
        private string saveData(string rowid, string FILE_DESC, string UPLOAD_BY, string FILE_TYPE,string file_date)
        {
           
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@flag", "i");
            p[1] = new SqlParameter("@ROWID", 0);
            p[2] = new SqlParameter("@func_id", rowid);
            p[3] = new SqlParameter("@FILE_DESC", FILE_DESC);
            p[4] = new SqlParameter("@UPLOAD_BY", UPLOAD_BY);
            p[5] = new SqlParameter("@FILE_TYPE", FILE_TYPE);
            p[6] = new SqlParameter("@file_date", file_date);
            p[1].Direction = ParameterDirection.Output;
            _fileuploader.SaveUploadedFile("", p);
            return p[1].Value.ToString();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (HdnUploadId.Value !="")
            {
                string cms = ConfigurationSettings.AppSettings["root"];
                string sql = "exec proc_CMSFileUpload_delete '" + HdnUploadId.Value + "'";
                FileUploaderDao _upoader = new FileUploaderDao();
                DataTable dt = _upoader.delete_user_file(sql).Tables[0];
                string location = cms + "\\CMS_Management\\" + GetPageID();
                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row[0].ToString()))
                        File.Delete(location + "\\" + row[0].ToString());
                }
                listFileInformation(_fileuploader.GetCmsFiles(int.Parse(GetPageID().ToString()) > 0 ?GetPageID().ToString() : ddlPageName.Text ));
            }
        }
        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListPages.aspx");
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            listFileInformation(_fileuploader.GetCmsFiles(ddlPageName.Text));
        }
    }
}
