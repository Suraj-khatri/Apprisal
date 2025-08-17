using System;
using System.Configuration;
using System.Drawing;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Payrole_management.GradeIncrement
{
    public partial class UploadGradeIncrement : BasePage
    {
        clsDAO Clsdao = null;
        RoleMenuDAOInv _roleMenuDao = new RoleMenuDAOInv();
        public UploadGradeIncrement()
        {
            Clsdao = new clsDAO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (_roleMenuDao.hasAccess(ReadSession().AdminId, 260) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
                PopulateDdl();
            }
        }

        private void PopulateDdl()
        {
            Clsdao.CreateDynamicDDl(fiscalYear, "exec proc_gradeIncrement @flag='FY'", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            fiscalYear.SelectedValue = Clsdao.GetSingleresult("exec proc_gradeIncrement @flag='DFY'");
            Clsdao.CreateDynamicDDl(appraisalRating, "EXEC proc_gradeIncrement @flag='AR'", "ROWID", "DETAIL_TITLE", "", "Select");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSearch();
        }

        private void OnSearch()
        {
            Response.Redirect("Confirm.aspx?fiscalYear=" + fiscalYear.Text + "&appRate=" + appraisalRating.Text + "&effectiveFrom=" + effectiveDate.Text + "&applyOn=" + applyDate.Text + "");
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ReadSession().RptQuery = "EXEC proc_gradeIncrement_test @flag='save',@fiscalYear=" + filterstring(fiscalYear.Text) + ","
                        + "@appRating=" + filterstring(appraisalRating.Text) + ",@effectiveDate=" + filterstring(effectiveDate.Text) + ","
                        + "@applyDate=" + filterstring(applyDate.Text) + ",@user=" + filterstring(ReadSession().Emp_Id.ToString()) + "";
            Response.Redirect("/Report/ExportToExcel/ExportExcel.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
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
            string upload_path = root + "doc\\payroll_upload\\grade\\" + p_file;

            string msg = Clsdao.GetSingleresult("exec proc_gradeIncrement_test @flag='upload',@file_path="+ filterstring(upload_path)+"");
            lblMsgDis.Text = msg;
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
                    string saved_file_name = root + "\\doc\\payroll_upload\\Grade\\" + fileName;
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
    }
}