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
using SwiftHrManagement.web;

namespace SwiftAssetManagement.AssetAcquisition.BillDetail
{
    public partial class UploadBill : BasePage
    {
        ClsDAOInv _clsdao = null;
        public UploadBill()
        {
            _clsdao = new ClsDAOInv();
        }
        string strfilename;
        string file_2_be_deleted = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            listFileInformation(GetfileInformation());
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string type = "doc";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            strfilename = p_file;
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);
            switch (type)
            {
                case "gif":
                    break;
                case "jpg":
                    break;
                default:
                    lblMessage.Text = "Invalid File Format";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
            }

            string AttPath = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile("." + type, AttPath);

            if (info.Substring(0, 5) == "error")
                return;
            string retValue = saveData(int.Parse(GetBillId().ToString()), TxtFileDesc.Text, ReadSession().Emp_Id.ToString(), type);


            string location_2_move = AttPath + "\\Billinformation\\";
            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
                File.Delete(file_2_create);

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);

            string strMessage = "File Uploaded as  " + file_2_create;

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = Color.Red;
            listFileInformation(GetfileInformation());
        }
        private string GetInsurer()
        {
            string insurer = "";
            if (Request.QueryString["insurer"] != null)
            {
                insurer = Request.QueryString["insurer"].ToString();
            }
            return insurer;
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
                td1.Text = "<strong>File Desciption</strong>";
                td2.Text = "<strong>File Type</strong>";
                //td3.Text = "<strong>Select</strong>";
                td4.Text = "<strong>View</strong>";
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
                    td1.Text = row["FILE_DESC"].ToString();
                    td2.Text = row["FILE_TYPE"].ToString();
                    //td3.Text = "<input type='checkbox' name='chkTran' ID='chkTran' value='" + row["ID"].ToString() + "'>";
                    td4.Text = "<a target='_blank' href='/Billinformation/" + row["id"].ToString() + "." + row["file_type"].ToString() + "'>View</a>";
                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tr.Cells.Add(td4);
                    tblResult.Rows.Add(tr);
                }
            }
        }
        private long GetBillId()
        {
            return (Request.QueryString["id"] != null ? long.Parse(Request.QueryString["id"].ToString()) : 0);
        }
        public DataTable GetfileInformation()
        {
            DataTable dt = _clsdao.getTable("exec proc_InsrBillFileUpload 's',@ROWID=" + GetBillId() + ",@mode='b'");
            return dt;
        }
        public string uploadFile(String fileName, string AttPath)
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
                    string saved_file_name = AttPath + "\\Billinformation\\tmp\\" + strfilename;
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

        private string saveData(int Bill_Id, string FILE_DESC, string UPLOAD_BY, string FILE_TYPE)
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@flag", "i");
            p[1] = new SqlParameter("@ROWID", GetBillId());
            p[2] = new SqlParameter("@user", ReadSession().Emp_Id);
            p[3] = new SqlParameter("@FILE_DESC", FILE_DESC);
            p[4] = new SqlParameter("@UPLOAD_BY", UPLOAD_BY);
            p[5] = new SqlParameter("@FILE_TYPE", FILE_TYPE);
            p[6] = new SqlParameter("@jobid", GetBillId());
            p[7] = new SqlParameter("@jobflag", "b");
            p[1].Direction = ParameterDirection.Output;

            _clsdao.executeProcedure("proc_InsrBillFileUpload", p);
            return p[1].Value.ToString();
        }
    }
}
