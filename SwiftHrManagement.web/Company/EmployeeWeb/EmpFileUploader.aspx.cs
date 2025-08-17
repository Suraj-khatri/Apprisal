using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.web.Library;
using SwiftHrManagement.DAL;
using System.Collections.Specialized;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class EmpFileUploader : BasePage
    {
       
        string file_2_be_deleted = "";
        string file_2_make_profile_pic = "";
        
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _roleMenuDao = null;
        EmployeeDAO empDao = null;
        Employee empCore = null;
        clsDAO _clsDao = null;

        public EmpFileUploader()
        {
            this.empDao = new EmployeeDAO();
            this.empCore = new Employee();
            this._fileuploader = new FileUploaderDao();
            this._roleMenuDao = new RoleMenuDAOInv();
            this._clsDao = new clsDAO();
        }

        string _filePath = "";
        private readonly DbResult _obj = new DbResult();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["rbTran"] != null)
                file_2_make_profile_pic = Request.Form["rbTran"].ToString();
              
            if (!IsPostBack)
            {
              
                if (_roleMenuDao.hasAccess(1, 25) == false)
                {
                    Response.Redirect("/Error.aspx");
                }

                long Id = this.GetEmpId();

                this.empCore = this.empDao.FindFullNameById(Id);           
                lblEmpNo.Text = Id.ToString();
                lblEmpNo.Visible = false;
                OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(),GetDocType()));
                if (GetDocType() != "")
                {
                    ddlDocType.SelectedValue = GetDocType();
                }
            }
            btnBack.Attributes.Add("onclick", "history.back();return false");
        }


        private long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        private string GetDocType()
        {
            return (Request.QueryString["type"] != null ? Request.QueryString["type"].ToString() : "");
        }

        public string uploadFile(String fileName,string EMP_ID)
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
                    string saved_file_name = GetStatic.GetUploadRoot() +"tmp\\" + EMP_ID + "_" + fileName;
                    fileUpload.PostedFile.SaveAs(saved_file_name);
                    return saved_file_name;
                }
                else
                {
                    return "error:Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
            }
        }

        //upload
        private bool IsFileValid(string type)
        {
            string[] allowedImageTyps = { "image/gif", "image/jpg", "image/jpeg", "image/bmp", "image/png", "Application/pdf"};
            StringCollection imageTypes = new StringCollection();
            imageTypes.AddRange(allowedImageTyps);
            if (imageTypes.Contains(type))
                return true;
            else
            {
                return false;                
            }
            
            //if (type.Equals("gif") || type.Equals("jpeg") || type.Equals("jpg") || type.Equals("bmp") || type.Equals("x-png") || type.Equals("pdf"))
            //{
            //    string allowedImageTyps = type;

            //    StringCollection imageTypes = new StringCollection();

            //    imageTypes.Add(allowedImageTyps);

            //    if (imageTypes.Contains(ContentType))
            //        return true;
            //    else
            //        return false;
            //}
            //else
            //    return false;

           // string[] allowedImageTyps = {  };
            
        }
        
        private void OnShowFile(DataTable dt)
        {
            TableRow tr = null;
            TableCell th1 = null;
            TableCell th2 = null;
            TableCell th3 = null;
            TableCell th4 = null;
            TableCell th5 = null;
            TableCell th6 = null;

            TableCell td1 = null;
            TableCell td2 = null;
            TableCell td3 = null;
            TableCell td4 = null;
            TableCell td5 = null;
            TableCell td6 = null;

            tblResult.CellPadding = 3;
            tblResult.CellSpacing = 0;
            tblResult.CssClass = "table table-bordered table-striped table-condensed";

                tr = new TableRow();
                th1 = new TableCell();
                th2 = new TableCell();
                th3 = new TableCell();
                th4 = new TableCell();
                th5 = new TableCell();
                th6 = new TableCell();
        
                th1.Text = "<strong>File Desciption</strong>";
                th2.Text = "<strong>File Type</strong>";
                th3.Text = "<strong>Document Type</strong>";
                th4.Text = "<strong>Delete</strong>";
                th5.Text = "<strong>View</strong>";
                th6.Text = "<strong>Profile Picture</strong>";

                tr.Cells.Add(th1);
                tr.Cells.Add(th2);
                tr.Cells.Add(th3);
                tr.Cells.Add(th4);
                tr.Cells.Add(th5);
                tr.Cells.Add(th6);
                tblResult.Rows.Add(tr);

                foreach (DataRow row in dt.Rows)
                {
                    tr = new TableRow();
                    td1 = new TableCell();
                    td2 = new TableCell();
                    td3 = new TableCell();
                    td4 = new TableCell(); 
                    td5 = new TableCell();
                    td6 = new TableCell();

                    td1.Text = row["FILE_DESC"].ToString();
                    td2.Text = row["FILE_TYPE"].ToString();
                    td3.Text = row["doc_type"].ToString();
                    td4.Text = "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"Delete\" href='#' onclick = \"DeleteUploadFile('" + row["ROWID"].ToString() + "')\"><i class=\"fa fa-times\"></i></a>";
                    td5.Text = "<a class=\"tool btn btn-primary btn-xs\" data-toggle=\"tooltip\" data-placement=\"top\" title=\"View\" target='_blank' href='/doc/" + lblEmpNo.Text + "/" + row["ROWID"].ToString() + "." + row["FILE_TYPE"].ToString() + "'><i class=\"fa fa-eye\"></i></a>";

                    if( row["PROFILE_PICTURE_FLAG"].ToString().ToUpper() == "Y")
                        td6.Text = "<input type='radio' name='rbTran'  value='" + row["ROWID"].ToString() + "' checked>";
                    else
                        td6.Text = "<input type='radio' name='rbTran'  value='" + row["ROWID"].ToString() + "'>";
                    
                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tr.Cells.Add(td4);
                    tr.Cells.Add(td5);
                    tr.Cells.Add(td6);
                    tblResult.Rows.Add(tr);
                }            
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string type = "doc";

            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\","/");            
            
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos +1, p_file.Length - pos-1);

            if (!IsFileValid(fileUpload.PostedFile.ContentType))
            {
               lblMessage.Text="File Type is not valid. Please upload file with valid file type.";
            lblMessage.ForeColor = System.Drawing.Color.Red;
                //GetStatic.AlertMessage(this,"please upload valid file");
            OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
            return;
            }

            string root = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileDescription.Text + "." + type, lblEmpNo.Text);


            if (info.Substring(0, 5) == "error")
            {
                lblMessage.Text = info;
                lblMessage.ForeColor = System.Drawing.Color.Red;
                OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
            }

            //return;
            else
            {

                string retValue = saveData(int.Parse(lblEmpNo.Text), TxtFileDescription.Text, this.ReadSession().Emp_Id.ToString(), type, ddlDocType.Text);

                string location_2_move = GetStatic.GetUploadRoot() + lblEmpNo.Text;

                string file_2_create = location_2_move + "\\" + retValue + "." + type;

                if (File.Exists(file_2_create))
                    File.Delete(file_2_create);

                if (!Directory.Exists(location_2_move))
                    Directory.CreateDirectory(location_2_move);

                File.Move(info, file_2_create);

                string strMessage = "Success, Uploaded as " + file_2_create;

                lblMessage.Text = strMessage;
                lblMessage.ForeColor = Color.Green;

            }
            OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
        }
        
        private string saveData(int EMP_ID, string FILE_DESC, string UPLOAD_BY,string FILE_TYPE,string docType)
        {

            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@flag", "i");
            p[1] = new SqlParameter("@ROWID", 0 );
            p[2] = new SqlParameter("@EMP_ID", EMP_ID);
            p[3] = new SqlParameter("@FILE_DESC", FILE_DESC);
            p[4] = new SqlParameter("@UPLOAD_BY", UPLOAD_BY);            
            p[5] = new SqlParameter("@FILE_TYPE", FILE_TYPE);
            p[6] = new SqlParameter("@DOCTYPE", docType);
            p[1].Direction = ParameterDirection.Output;
                       
            _fileuploader.SaveUploadedInformation("", p);

            return p[1].Value.ToString();


        }
        
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (upload_Id.Value != "")
            {                
                string root = ConfigurationSettings.AppSettings["root"];
                string sql = "exec proc_EmployeeFileUpload_delete '" + upload_Id.Value + "'";
                
                FileUploaderDao _upoader = new FileUploaderDao();

                DataTable dt = _upoader.delete_user_file(sql).Tables[0];

                string location = root + "\\doc\\" + lblEmpNo.Text;

                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row[0].ToString()))
                        File.Delete(location + "\\" + row[0].ToString());
                }
                OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
            }
        }

        protected void btnSetProfile_Click(object sender, EventArgs e)
        {
            try
            {
                OnSetProfilePicture();
            }
            catch
            {
                lblMessage.Text = "Error In Operation!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        
        private void OnSetProfilePicture()
        {
            if (file_2_make_profile_pic != "")
            {
                string fileType = "";

                fileType = _clsDao.GetSingleresult("select file_type from EmployeeFileUpload where rowid=" + filterstring(file_2_make_profile_pic) + "");
                fileType.ToLower();

                if (fileType != "jpg" && fileType != "png" && fileType != "gif" && fileType != "tif")
                {
                    lblMessage.Text = "Invalid file Type! Please choose jpg,gif,png or tif file for profile picture!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
                    return;
                }

                string sql1 = "update EmployeeFileUpload set PROFILE_PICTURE_FLAG = 'N' where EMP_ID =" + filterstring(GetEmpId().ToString()) + "";
                _clsDao.runSQL(sql1);

                string sql2 = "update EmployeeFileUpload set PROFILE_PICTURE_FLAG = 'Y' where ROWID =" + filterstring(file_2_make_profile_pic) + "";
                _clsDao.runSQL(sql2);
                OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
            }
            else
            {
                lblMessage.Text = "Please choose a profile file!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                OnShowFile(_fileuploader.GetfileInformation(GetEmpId().ToString(), GetDocType()));
            }
        }

        protected void btnResetProfile_Click(object sender, EventArgs e)
        {
            try
            {
                OnResetProfile();
            }
            catch
            {
                lblMessage.Text = "Error In Operation!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void OnResetProfile()
        {
            _clsDao.runSQL("UPDATE EmployeeFileUpload SET profile_picture_flag='N' WHERE EMP_ID="+filterstring(GetEmpId().ToString())+"");
            Response.Redirect("EmpFileUploader.aspx?Id="+GetEmpId()+"");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            
        }

        
    }
}
