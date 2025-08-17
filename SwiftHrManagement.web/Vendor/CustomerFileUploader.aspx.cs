using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using SwiftHrManagement.Core.Domain;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.Customer;
using SwiftHrManagement.DAL.CustomerFileUploader;
using SwiftHrManagement.web;

namespace SwiftAssetManagement.web.Customer
{
    public partial class CustomerFileUploader :BasePage
    {
         string file_2_be_deleted = "";
        CustomerFileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        ClsDAOInv _clsDao = null;
  
        public CustomerFileUploader()
        {
            this._fileuploader = new CustomerFileUploaderDao();
            this._RoleMenuDAOInv = new RoleMenuDAOInv();
            this._clsDao = new ClsDAOInv();
        }

        private int GetCustomerId()
        {
            return (Request.QueryString["Id"] != null ? int.Parse(Request.QueryString["Id"].ToString()) : 0);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 110) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                listFileInformation(_fileuploader.GetCustomerFileInfo(GetCustomerId().ToString()));
                GetCustomerName();
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
                //tr.CssClass = "HeaderStyle";
                
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
                    td4.Text = "<a target='_blank' href='/doc/Customer" + "/" + row["DOC_ID"] + "." + row["FILE_EXTENSION"].ToString() + "'> View </a>";                    

                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tr.Cells.Add(td4);
                    tblResult.Rows.Add(tr);
                }
            }
        }
        private void GetCustomerName()
        {
            try
            {
                string sSql = "select CustomerName from customer where ID = " + GetCustomerId() + "";
                string custName = _clsDao.GetSingleresult(sSql);
                lblcustName.Text = custName;
            }
            catch
            {
            }
        }       
        public string uploadFile(String fileName,string rowid,string FilePath)
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
                    string saved_file_name = FilePath + "\\doc\\Customer\\" + fileName;
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
            
            string type = "doc";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\","/");   
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos +1, p_file.Length - pos-1);

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
           
            string info = uploadFile(GetCustomerId() + "." + type, GetCustomerId().ToString(), root);



            if (info.Substring(0, 5) == "error")
                return;
            
            string retValue = saveData(GetCustomerId(),TxtFileDescription.Text, ReadSession().UserId, type);

            string location_2_move = root + "\\doc\\Customer".ToString();
            
            string file_2_create = location_2_move + "\\" + retValue + "." + type;
          
            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);

           string strMessage = "File Uploaded as  " + file_2_create;

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Green;
            
            listFileInformation(_fileuploader.GetCustomerFileInfo(GetCustomerId().ToString()));            
        }
        private string saveData(int JOB_ID, string FILE_DESC, string UPLOAD_BY, string FILE_TYPE)
        {

            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@flag", "i");
            p[1] = new SqlParameter("@ROWID", 0);
            p[2] = new SqlParameter("@CUST_ID", JOB_ID);
            p[3] = new SqlParameter("@FILE_DESC", FILE_DESC);
            p[4] = new SqlParameter("@UPLOAD_BY", UPLOAD_BY);
            p[5] = new SqlParameter("@FILE_TYPE", FILE_TYPE);
            p[1].Direction = ParameterDirection.Output;

            _fileuploader.SaveCustUploadedInformation("", p);

            return p[1].Value.ToString();

        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            if (file_2_be_deleted != "")
            {
                
                string FilePath = ConfigurationSettings.AppSettings["root"];
                string sql = "exec PROC_CUST_DOC_HISTORY_DELETE '" + file_2_be_deleted + "'";
                                
                DataTable dt = _fileuploader.delete_cust_file(sql).Tables[0];
                string location = FilePath + "\\doc\\Customer\\" + GetCustomerId().ToString();

                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row[0].ToString()))
                        File.Delete(location + "\\" + row[0].ToString());
                }                
                listFileInformation(_fileuploader.GetCustomerFileInfo(GetCustomerId().ToString()));
            }
        }

        protected void Btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("List.aspx");
        }
    }
}
