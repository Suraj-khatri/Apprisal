using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.MedicalClaim
{
    public partial class Upload : BasePage
    {
        string file_2_be_deleted = "";
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _roleMenuDao = null;
        clsDAO _clsdao = new clsDAO();
        public Upload()
        {
            this._roleMenuDao = new RoleMenuDAOInv();
            this._fileuploader = new FileUploaderDao();
        }
        private long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (!IsPostBack)
            {
                OnPopulate();
            }
            btnBack.Attributes.Add("onclick", "history.back();return false");
        }

        private void OnPopulate()
        {
            DataTable dt = new DataTable();
            dt = _clsdao.getDataset("Exec [procMedicalClaim] @flag='uploadS',@id=" + filterstring(GetId().ToString()) + "").Tables[0];
            DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }

            TableRow tr = null;
            TableCell td1 = null;
            TableCell td2 = null;
            TableCell td3 = null;
            TableCell td4 = null;
            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;


            if (dt.Rows.Count > 0)
            {
                tr = new TableRow();
                td1 = new TableCell();
                td2 = new TableCell();
                td3 = new TableCell();
                td4 = new TableCell();
                tr.CssClass = "HeaderStyle";
                td1.Text = "<strong>File Desciption</strong>";
                td2.Text = "<strong>File Type</strong>";
                td3.Text = "<strong>Select</strong>";
                td4.Text = "<strong>View</strong>";
                td1.CssClass = "HeaderStyle";
                td2.CssClass = "HeaderStyle";
                td3.CssClass = "HeaderStyle";
                td4.CssClass = "HeaderStyle";

                tr.Cells.Add(td1);
                tr.Cells.Add(td2);
                tr.Cells.Add(td3);
                tr.Cells.Add(td4);
                tblResult.Rows.Add(tr);

                foreach (DataRow row in dt.Rows)
                {
                    tr = new TableRow();
                    td1 = new TableCell();
                    td2 = new TableCell();
                    td3 = new TableCell();
                    td4 = new TableCell();
                    td1.Text = row["docDesc"].ToString();
                    td2.Text = row["docExt"].ToString();

                    td3.Text = "<input type='checkbox' name='chkTran' DOC_ID='chkTran' value='" + row["id"].ToString() + "'>";
                    td4.Text = "<a target='_blank' href='/doc/MedicalClaim" + "/" + row["id"] + "." + row["docExt"].ToString() + "'> View </a>";

                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tr.Cells.Add(td4);
                    tblResult.Rows.Add(tr);
                }
            }            
        }
        public string uploadFile(String fileName, string rowid, string docPath)
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
                    string saved_file_name = docPath + "\\doc\\MedicalClaim\\" + fileName;
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

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (file_2_be_deleted != "")
            {
                string docPath = ConfigurationSettings.AppSettings["root"];
                string location = docPath + "\\doc\\MedicalClaim\\" + GetId().ToString();

                DataTable dt = new DataTable();
                dt = _clsdao.getDataset("Exec [procMedicalClaim] @flag='uploadD',@id='" + file_2_be_deleted + "'").Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row["FILENAME"].ToString()))
                        File.Delete(location + "\\" + row["FILENAME"].ToString());
                }
                OnPopulate();
            }
        }
        protected void Btn_Back_Click(object sender, EventArgs e)
        {

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
                case "jpg":
                    break;
                case "gif":
                    break;
                case "pdf":
                    break;
                case "txt":
                    break;
                default:
                    lblMessage.Text = "Error:Unable to upload,Invalid file type!";
                    lblMessage.ForeColor = Color.Red;
                    return;
            }
            string docPath = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileDescription.Text + "." + type, GetId().ToString(), docPath);

            if (info.Substring(0, 5) == "error")
                return;

            string retValue = _clsdao.GetSingleresult("Exec [procMedicalClaim] @flag='uploadI',@id=" + filterstring(GetId().ToString()) + ","
                                +" @fileDesc="+filterstring(TxtFileDescription.Text)+",@fileType="+filterstring(type)+","
                                +" @user="+filterstring(ReadSession().Emp_Id.ToString()));

            string location_2_move = docPath + "\\doc\\MedicalClaim".ToString();

            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);

            string strMessage = "File Uploaded as  " + file_2_create;

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Green;

            OnPopulate();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }
    }
}
