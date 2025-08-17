using System;
using System.Drawing;
using System.Configuration;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;


namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class UploadPayment : BasePage
    {
        FileUploaderDao _fileuploader = null;
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        clsDAO _clsdao = null;
        
        public UploadPayment()
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
                if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 89) == false)
                {
                    Response.Redirect("/Error.aspx");
                }
            }
        }
        private void PopulateDdlList()
        {
            this.DdlYear();
            this.DdlMonth();
        }
       private  void DdlYear()
        {
            string selectValue = "";
            if (ddlYear.SelectedItem != null)
                selectValue = ddlYear.SelectedItem.Value.ToString();
            _clsdao.setDDL(ref ddlYear, "Exec proc_getmonth_year 'y'", "nplYear", "nplYear", selectValue, "Select");
        }

        private  void DdlMonth()
        {
            string selectValue = "";
            if (Ddlmonth.SelectedItem != null)
                selectValue = Ddlmonth.SelectedItem.Value.ToString();
            _clsdao.setDDL(ref Ddlmonth, "Exec proc_getmonth_year 'm'", "Id", "Name", selectValue, "Select");
        }

        public string uploadFile(String fileName,string root)   
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
                    string saved_file_name = root + "\\doc\\payroll_upload\\" + fileName;
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
            if (ChkPaid.Checked == true && TxtPayableDate.Text == "")
            {
                lblMessage.Text = "Please enter Applied Date!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            
            else if(TxtPayableDate.Text!="" && ChkPaid.Checked==false)
            {
                lblMessage.Text = "Please checked is Applied!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else if (ChkPaid.Checked == true &&( (ddlYear.SelectedValue == "Select") || (ddlYear.SelectedValue == "")))
            {
                lblMessage.Text = "Please select Applied for Year!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;

            }
            else if (ChkPaid.Checked == true &&( (Ddlmonth.SelectedValue == "Select") || (Ddlmonth.SelectedValue == ""))) 
            {
                lblMessage.Text = "Please select Applied for month!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;

            }
            else
            {
                string type = "";
                string p_file = fileUpload.FileName ;//fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
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
                string upload_path = root + "doc\\payroll_upload\\" + p_file;

                string msg = _clsdao.GetSingleresult("exec ProcUploadAdhocPaymentFile @flag='a',@type=" + filterstring(DdlAddDeduct.Text) + ","
                + " @head=" + filterstring(DdlAdhocHead.Text) + ",@file_path='" + upload_path + "',@user=" + filterstring(ReadSession().Emp_Id.ToString()) + ","
                + "@isApplied= " + filterstring(ChkPaid.Checked.ToString()) + ",@AppliedDate=" + filterstring(TxtPayableDate.Text) + ","
                + " @month=" + filterstring(Ddlmonth.Text) + ","
                + "@applied_on= " + filterstring(TxtAppliedOn.Text) + ",@year=" + filterstring(ddlYear.Text));
                lblMessage.Text = msg;
            }
        }
        protected void DdlAddDeduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlAddDeduct.Text == "A")
            {
                _clsdao.CreateDynamicDDl(DdlAdhocHead, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID in (36,37,38,41)", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
            }
            else
            {
                _clsdao.CreateDynamicDDl(DdlAdhocHead, "SELECT ROWID,DETAIL_TITLE from StaticDataDetail where TYPE_ID in (36,37,38,40)", "ROWID", "DETAIL_TITLE", "selectValue", "Select...");
            }           
        }
        protected void ChkPaid_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkPaid.Checked == true)
            {
                if (TxtPayableDate.Text == "")
                {   

                    lblMessage.Text = "Please enter Applied Date!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (TxtAppliedOn.Text == "")
                {
                    lblMessage.Text = "Please enter Applied On Date! ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (ddlYear.SelectedValue =="Select" || ddlYear.SelectedValue =="")
                {
                    lblMessage.Text = "Please enter Applied for Year! ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (Ddlmonth.SelectedValue == "Select" || Ddlmonth.SelectedValue == "")
                {
                    lblMessage.Text = "Please enter Applied for Year! ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                //if (TxtAppliedFor.Text == "")
                //{
                //    lblMessage.Text = "Please enter Applied For Date! ";
                //    lblMessage.ForeColor = System.Drawing.Color.Red;
                //    return;
                //}
            }
        }
        
        protected void TxtPayableDate_TextChanged(object sender, EventArgs e)
        {
            if (TxtPayableDate.Text == "")
            {
                ChkPaid.Checked = false;
            }
            else
            {
                ChkPaid.Checked = true;
            }
        }

        protected void TxtAppliedOn_TextChanged(object sender, EventArgs e)
        {
            if (TxtAppliedOn.Text == "")
            {
                ChkPaid.Checked = true;
            }
        }
    }
}
