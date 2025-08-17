using System;
using System.Drawing;
using System.Configuration;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class InterestBenifit : BasePage
    {

        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsdao = null;

        public InterestBenifit()
        {
            _clsdao = new clsDAO();
            _RoleMenuDAOInv = new RoleMenuDAOInv();
            _fileuploader = new FileUploaderDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PopulateDdlList();
            if (!IsPostBack)
            {
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 252) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }

        
        public void PopulateDdlList()
        {
            this.PopulateBenifits();
            this.populateFiscal();

        }

        public void PopulateBenifits()
        {
            string selectValue = "";
            if (Ddlinterest.SelectedItem != null)
                selectValue = Ddlinterest.SelectedItem.Value.ToString();
            _clsdao.setDDL(ref Ddlinterest, "Exec ProcStaticDataView 's','42'", "ROWID", "DETAIL_TITLE", selectValue, "Select");
        }
        public  void populateFiscal()
        {
            string selectValue = _clsdao.GetSingleresult("select FISCAL_YEAR_ID from FiscalYear where isnull(FLAG,0)=1");

            _clsdao.setDDL(ref DdlFiscalYear, "Exec proc_getmonth_year 'f'", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", selectValue, "Select");

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if ((Ddlinterest.SelectedValue == "Select") || (Ddlinterest.SelectedValue == ""))
            {
                lblMessage.Text = "Please select Benefits!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;

            }
            else if ((DdlFiscalYear.SelectedValue == "Select") || (DdlFiscalYear.SelectedValue == ""))
            {
                lblMessage.Text = "Please select Fiscal Year!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                string type = "";
                string p_file = fileUpload.FileName;//fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
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
                string upload_path = root + "doc\\InterestBenefit\\Upload\\" + p_file;

                string msg = _clsdao.GetSingleresult("exec [ProcUploadInterestBenefit] @flag='a',@type=" + filterstring(Ddlinterest.Text) + ","
               // + " @head=" + filterstring(DdlAdhocHead.Text) 
                + " @file_path='" + upload_path + "',@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
               // + "@isApplied= " + filterstring(ChkPaid.Checked.ToString()) + ",@AppliedDate=" + filterstring(TxtPayableDate.Text) + ","
                + " @year=" + filterstring(DdlFiscalYear.Text));
                lblMessage.Text = msg;
            }
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
                    string saved_file_name = root + "\\doc\\InterestBenefit\\Upload\\" + fileName;
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
           
    }
}