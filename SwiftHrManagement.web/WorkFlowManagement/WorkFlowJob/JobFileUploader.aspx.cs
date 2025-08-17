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
using SwiftHrManagement.DAL.EmployeeDAO;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.WorkFlowManagement;

namespace SwiftHrManagement.web.WorkFlowManagement.WorkFlowJob
{
    public partial class JobFileUploader : BasePage
    {
        string file_2_be_deleted = "";
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _roleMenuDao = null;        
        WFJobDAO _jobDAO = null;
        WFUploadJobFilesCore _wfJobFilesCore = null;
        public JobFileUploader()
        {            
            this._jobDAO = new WFJobDAO();
            this._roleMenuDao = new RoleMenuDAOInv();
            _wfJobFilesCore = new WFUploadJobFilesCore();
            this._fileuploader = new FileUploaderDao();
        }

        private int GetJobId()
        {
            return (Request.QueryString["Id"] != null ? int.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        private long GetEmpId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        } 
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (!IsPostBack)
            {                
                listFileInformation(_jobDAO.GetUploadedFileInfo(GetJobId().ToString()));
                GetJobDetails();
            }
        }
        private void listFileInformation(DataTable dt)
        {
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
                //if (dt.Rows.Count > 1)
                //{
                //    td1.Text = "<strong>File Desciption</strong>";
                //    td2.Text = "<strong>File Type</strong>";
                //    td3.Text = "<strong>Select</strong>";
                //    td4.Text = "<strong>View</strong>";
                //    td3.Text = "<input type='checkbox' name='chkAll' name='chkAll'  rowid='chkAll' onclick=\"checkAll(this);\">";
                //}
                //else
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
                    td1.Text = row["DOC_DESCRIPTION"].ToString();
                    td2.Text = row["FILE_EXTENSION"].ToString();
                    td3.Text = "<input type='checkbox' name='chkTran' DOC_ID='chkTran' value='" + row["DOC_ID"].ToString() + "'>";
                    td4.Text = "<a target='_blank' href='/doc/wf" + "/" + row["DOC_ID"] + "." + row["FILE_EXTENSION"].ToString() + "'> View </a>";
                    //td4.Text = "<a target='_blank' href='/doc/wf" + "/" + GetJobId() + "/" + row["WF_DOC_NAME"].ToString() + "." + row["FILE_EXTENSION"].ToString() + "'> View </a>";

                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tr.Cells.Add(td4);
                    tblResult.Rows.Add(tr);
                }
            }
        }
        private void GetJobDetails()
        {
            WFJobCore jobCore = new WFJobCore();
            WFJobDAO jobDao = new WFJobDAO();
            jobCore = jobDao.FindJobDetails(GetJobId());
            lblWorkCategoryname.Text = "Category Name: " + jobCore.JobCategory + ", Job Code: " + jobCore.JobCode + "";
        }       
        public string uploadFile(String fileName,string rowid,string WorkFlowPath)
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
                    string saved_file_name = WorkFlowPath + "\\doc\\wf\\" + fileName;
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
           // string type = "doc";
           // string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\","/");   
           // int pos = p_file.LastIndexOf(".");
           // if (pos < 0)
           //     type = "";
           // else
           //     type = p_file.Substring(pos +1, p_file.Length - pos-1);

           // switch (type)
           // {
           //     case "xls":
           //         break;
           //     case "xlsx":
           //         break;
           //     case "doc":
           //         break;
           //     case "docx":
           //         break;
           //     case "jpg":
           //         break;
           //     case "gif":
           //         break;
           //     case "pdf":
           //         break;
           //     case "txt":
           //         break;                
           //     default:
           //         lblMessage.Text = "Error:Unable to upload,Invalid file type!";
           //         lblMessage.ForeColor = Color.Red;
           //         return;
           // }                        
           // string root = ConfigurationSettings.AppSettings["root"];           
           // string info = uploadFile(TxtFileDescription.Text + "." + type, GetJobId().ToString(), root);

           // if (info.Substring(0, 5) == "error")
           //     return;
            
           // string retValue = saveData(GetJobId(),TxtFileDescription.Text, ReadSession().UserId, type);

           // string location_2_move = root + "\\doc\\wf".ToString();
            
           // string file_2_create = location_2_move + "\\" + retValue + "." + type;
          
           // if (File.Exists(file_2_create))
           //     File.Delete(file_2_create);

           // if (!Directory.Exists(location_2_move))
           //     Directory.CreateDirectory(location_2_move);

           // File.Move(info, file_2_create);

           //string strMessage = "File Uploaded as  " + file_2_create;

           // lblMessage.Text = strMessage;
           // lblMessage.ForeColor = Color.Green;
            
           // listFileInformation(_jobDAO.GetUploadedFileInfo(GetJobId().ToString()));            
        }
        private string saveData(int JOB_ID, string FILE_DESC, string UPLOAD_BY, string FILE_TYPE)
        {

            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@flag", "i");
            p[1] = new SqlParameter("@ROWID", 0);
            p[2] = new SqlParameter("@JOB_ID", JOB_ID);
            p[3] = new SqlParameter("@FILE_DESC", FILE_DESC);
            p[4] = new SqlParameter("@UPLOAD_BY", UPLOAD_BY);
            p[5] = new SqlParameter("@FILE_TYPE", FILE_TYPE);
            p[1].Direction = ParameterDirection.Output;

            _fileuploader.SaveJobUploadedFile("", p);
            return p[1].Value.ToString();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (file_2_be_deleted != "")
            {
                
                string WorkFlowPath = ConfigurationSettings.AppSettings["WorkFlowPath"];
                string sql = "exec PROC_WF_DOC_HISTORY_DELETE '" + file_2_be_deleted + "'";
                                
                DataTable dt = _jobDAO.delete_job_file(sql).Tables[0];
                string location = WorkFlowPath + "\\doc\\wf\\" + GetJobId().ToString();

                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row[0].ToString()))
                        File.Delete(location + "\\" + row[0].ToString());
                }                
                listFileInformation(_jobDAO.GetUploadedFileInfo(GetJobId().ToString()));
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("JobList.aspx");
        }

        protected void BtnUpload_Click1(object sender, EventArgs e)
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
            string root = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileDescription.Text + "." + type, GetJobId().ToString(), root);

            if (info.Substring(0, 5) == "error")
                return;

            string retValue = saveData(GetJobId(), TxtFileDescription.Text, ReadSession().UserId, type);

            string location_2_move = root + "\\doc\\wf".ToString();

            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);

            string strMessage = "File Uploaded as  " + file_2_create;

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Green;

            listFileInformation(_jobDAO.GetUploadedFileInfo(GetJobId().ToString())); 
        }
    }
}
