using System;
using System.Data;
using SwiftHrManagement.DAL.FileUploader;

namespace SwiftHrManagement.web.AttendenceWeb
{
    public partial class UploadFiles : BasePage
    {
        string strfilename;
        FileUploaderDao _fileuploader = null;
        clsDAO _clsdao = null;

        public UploadFiles()
        {
            _fileuploader = new FileUploaderDao();
            _clsdao = new clsDAO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
            }
        }

        //protected void BtnUpload_Click(object sender, EventArgs e)
        //{
        //    string type = "doc";
        //    string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
        //    strfilename = p_file;
        //    int pos = p_file.LastIndexOf(".");
        //    if (pos < 0)
        //        type = "";
        //    else
        //        type = p_file.Substring(pos + 1, p_file.Length - pos - 1);
        //    switch (type)
        //    {
        //        case "csv":
        //            break;
        //        default:
        //            lblMessage.Text = "Invalid File Format";
        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //            return;
        //    }

        //    string AttPath = ConfigurationSettings.AppSettings["root"];
        //    //string info = uploadFile("." + type, AttPath);
        //    string info = uploadFile(strfilename + "." + type, AttPath);
        

        //    if (info.Substring(0, 5) == "error")
        //        return;

        //    //
        //    string retValue = saveData(TxtFileDescription.Text, this.ReadSession().Emp_Id.ToString(), type);
        //    //


        //    string location_2_move = AttPath + "\\attendancefile";
        //    //string file_2_create = location_2_move + "\\ tmp" +  "\\" + strfilename;
        //    string file_2_create = location_2_move + "\\" + retValue + "." + type;

        //    if (File.Exists(file_2_create))
        //        File.Delete(file_2_create);

        //    if (!Directory.Exists(location_2_move))
        //        Directory.CreateDirectory(location_2_move);

        //    File.Move(info, file_2_create);

        //    string strMessage = "File Uploaded as  " + file_2_create;

        //    lblMessage.Text = strMessage;
        //    lblMessage.ForeColor = Color.Red;
        //}

        
        //private string saveData(string FILE_DESC, string UPLOAD_BY, string FILE_TYPE)
        //{

        //    SqlParameter[] p = new SqlParameter[5];
        //    p[0] = new SqlParameter("@flag", "i");
        //    p[1] = new SqlParameter("@ROWID", 0);            
        //    p[2] = new SqlParameter("@FILE_DESC", FILE_DESC);
        //    p[3] = new SqlParameter("@UPLOAD_BY", UPLOAD_BY);
        //    p[4] = new SqlParameter("@FILE_TYPE", FILE_TYPE);
        //    p[1].Direction = ParameterDirection.Output;

        //    _fileuploader.SaveUploadedAttendanceFile("", p);

        //    return p[1].Value.ToString();


        //}
        ////

        //private void listFileInformation(DataTable dt)
        //{
        //    TableRow tr = null;
        //    TableCell td1 = null;
        //    TableCell td2 = null;
        //    TableCell td3 = null;
        //    TableCell td4 = null;
        //    tblResult.CellPadding = 3;
        //    tblResult.CellSpacing = 0;


        //    if (dt.Rows.Count > 0)
        //    {
        //        tr = new TableRow();
        //        td1 = new TableCell();
        //        td2 = new TableCell();
        //        td3 = new TableCell();
        //        td4 = new TableCell();
        //        tr.CssClass = "HeaderStyle";
        //        if (dt.Rows.Count > 1)
        //        {
        //            td1.Text = "<strong>File Desciption</strong>";
        //            td2.Text = "<strong>File Type</strong>";
        //            td3.Text = "<strong>Select</strong>";
        //            td4.Text = "<strong>View</strong>";

        //            td3.Text = "<input type='checkbox' name='chkAll' name='chkAll'  rowid='chkAll' onclick=\"checkAll(this);\">";
        //        }
        //        else
        //            td1.Text = "<strong>File Desciption</strong>";
        //        td2.Text = "<strong>File Type</strong>";
        //        td3.Text = "<strong>Select</strong>";
        //        td4.Text = "<strong>View</strong>";
        //        tr.Cells.Add(td1);
        //        tr.Cells.Add(td2);
        //        tr.Cells.Add(td3);
        //        tr.Cells.Add(td4);
        //        tblResult.Rows.Add(tr);

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            tr = new TableRow();
        //            td1 = new TableCell();
        //            td2 = new TableCell();
        //            td3 = new TableCell();
        //            td4 = new TableCell();
        //            td1.Text = row["DOC_DESCRIPTION"].ToString();
        //            td2.Text = row["FILE_EXTENSION"].ToString();
        //            td3.Text = "<input type='checkbox' name='chkTran' DOC_ID='chkTran' value='" + row["DOC_ID"].ToString() + "'>";

        //            tr.Cells.Add(td1);
        //            tr.Cells.Add(td2);
        //            tr.Cells.Add(td3);
        //            tr.Cells.Add(td4);
        //            tblResult.Rows.Add(tr);
        //        }
        //    }
        //}
        //public string uploadFile(String fileName, string AttPath)
        //{
        //    if (fileName == "")
        //    {
        //        return "error:Invalid filename supplied";
        //    }
        //    if (fileUpload.PostedFile.ContentLength == 0)
        //    {
        //        return "error:Invalid file content";
        //    }

        //    try
        //    {
        //        if (fileUpload.PostedFile.ContentLength <= 2048000)
        //        {
        //            string saved_file_name = AttPath + "\\attendancefile\\" + strfilename;
        //            fileUpload.PostedFile.SaveAs(saved_file_name);
        //            return saved_file_name;
        //        }
        //        else
        //        {
        //            return "error:Unable to upload,file exceeds maximum limit!";
        //        }
        //    }
        //    catch (UnauthorizedAccessException ex)
        //    {
        //        return "error:" + ex.Message + "Permission to upload file denied!";
        //    }
        //}

        //protected void Delete_Click(object sender, EventArgs e)
        //{

        //}

        protected void BtnImportData_Click(object sender, EventArgs e)
        {
            try
            {
              var res=_clsdao.getTable("Exec [procImportAttendance] @flag='a',@att_date=" + filterstring(txtDate.Text) + ",@att_Todate=" + filterstring(txtDate.Text) + "");
              if (res.Rows[0]["errcode"].ToString() == "1")
              {
                  lblMsg.Text = res.Rows[0]["msg"].ToString();
                  lblMsg.ForeColor = System.Drawing.Color.Red;
              }
              else {
                  lblMsg.Text = res.Rows[0]["msg"].ToString();
                  lblMsg.ForeColor = System.Drawing.Color.Green;
              }
               
            }
            catch
            {
                lblMsg.Text = "Oops! Something went wrong!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }

       
    }
}
