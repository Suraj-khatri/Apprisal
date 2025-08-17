using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using SwiftHrManagement.DAL.FileUploader;
using SwiftHrManagement.DAL.Role;
using SwiftHrManagement.DAL.CEA;


namespace SwiftHrManagement.web.CEA
{
    public partial class ManageCEACliamIndividual : BasePage
    {
        string file_2_be_deleted = "";
        RoleMenuDAOInv _RoleMenuDAOInv = null;
        FileUploaderDao _fileuploader = null;
        clsDAO _clsDao = null;
        CEADao _ceaDao = null;
        public ManageCEACliamIndividual()
        {
            _RoleMenuDAOInv = new RoleMenuDAOInv();
            this._fileuploader = new FileUploaderDao();
            _clsDao = new clsDAO();
            _ceaDao = new CEADao();
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            if (_RoleMenuDAOInv.hasAccess(ReadSession().AdminId, 251) == false )
            {
                Response.Redirect("/Error.aspx");
            }
            
            if (!IsPostBack)
            {
                lblEmployeeName.Text = _clsDao.GetSingleresult("Select dbo.GetEmployeeInfoById(employee_id) from employee where employee_id="
                                        + ReadSession().Emp_Id.ToString());
                txtEmployee.Enabled = false;
                PopulateDDl();
                if (GetId() > 0)
                {
                    PopulateData();
                    BtnSave.Visible = false;
                    fileUploadForm.Visible = false;
                    pnlDisplayFile.Visible = true;
                    txtEmployee.Enabled = false;

                }
            }
        }

        protected void PopulateDDl()
        {
            string employeeid = ReadSession().Emp_Id.ToString();
            _clsDao.CreateDynamicDDl(ddlCEAFor, "Select ID,RTRIM(FIRST_NAME+ ' ' + isnull(MIDDLE_NAME,'') + ' ' + LAST_NAME)[FULL_NAME]from FamilyMembers where Date_Of_Birth between dateadd(year,-18,cast (GETDATE() as date)) and dateadd(year,-3,cast (GETDATE() as date))and RELATION in (1457,1458) and employee_id="
                                                 + employeeid, "ID", "FULL_NAME", "", "Select");

            _clsDao.CreateDynamicDDl(ddlFromFy, "Select FISCAL_YEAR_NEPALI from FiscalYear where flag is not null order by FISCAL_YEAR_NEPALI desc", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            _clsDao.CreateDynamicDDl(ddlFromMonth, "Select month_number,Name from MonthList ", "month_number", "Name", "", "Select");
            _clsDao.CreateDynamicDDl(ddlToFy, "Select FISCAL_YEAR_NEPALI from FiscalYear where flag is not null order by FISCAL_YEAR_NEPALI desc", "FISCAL_YEAR_NEPALI", "FISCAL_YEAR_NEPALI", "", "Select");
            _clsDao.CreateDynamicDDl(ddlToMonth, "Select month_number,Name from MonthList ", "month_number", "Name", "", "Select");

            ddlFromFy.SelectedValue = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
            ddlToFy.SelectedValue = _clsDao.GetSingleresult("select FISCAL_YEAR_NEPALI from FiscalYear where FLAG='1'");
        }

        private void PopulateData()
        {

            DataTable dt = _clsDao.getDataset(" Exec [proc_CEA] @flag='s',@id=" + filterstring(GetId().ToString()) + "").Tables[0];
            ddlCEAFor.Visible = false;
            RequiredFieldValidator7.Visible = false;
            foreach (DataRow dr in dt.Rows)
            {
                _clsDao.CreateDynamicDDl(ddlCEAFor, "Select ID,RTRIM(FIRST_NAME+ ' ' + isnull(MIDDLE_NAME,'') + ' ' + LAST_NAME)[FULL_NAME]from FamilyMembers where Date_Of_Birth between dateadd(year,-18,cast (GETDATE() as date)) and dateadd(year,-3,cast (GETDATE() as date))and RELATION in (1457,1458) and employee_id="
                                                + dr["emp_id"].ToString(), "ID", "FULL_NAME", "", "Select");
                lblEmployeeName.Text = dr["emp_name"].ToString();
                lblChild.Text = dr["Full_Name"].ToString();
                txtbillDate.Text = dr["bill_date"].ToString();
                txtBillAmt.Text = ShowDecimal(dr["Bill_Amount"].ToString());
                ddlFromFy.Text = dr["From_FY"].ToString();
                ddlFromMonth.Text = (dr["From_month"].ToString().Length == 1 ? "0" + dr["From_month"].ToString() : dr["From_month"].ToString());
                ddlToFy.Text = dr["To_FY"].ToString();
                ddlToMonth.Text = (dr["To_month"].ToString().Length == 1 ? "0" + dr["To_month"].ToString() : dr["To_month"].ToString());
                txtnarration.Text = dr["Description"].ToString();
                lblFileDesc.Text = dr["file_desc"].ToString();
                lblFileType.Text = dr["file_type"].ToString();
                lblLink.Text = "<a target='_blank' href='/doc/CEABills/" + dr["id"].ToString() + "." + dr["file_type"].ToString() + "'> Browse File </a>";

                if (dr["cea_status"].ToString() != "Pending")
                {
                    txtbillDate.Enabled = false;
                    txtBillAmt.Enabled = false;
                    ddlFromFy.Enabled = false;
                    ddlFromMonth.Enabled = false;
                    ddlToFy.Enabled = false;
                    ddlToMonth.Enabled = false;
                    txtnarration.Enabled = false;
                    btnDelete.Visible = false;
                }
            }
        }

        protected long GetId()
        {
            return (Request.QueryString["Id"] != null ? long.Parse(Request.QueryString["Id"].ToString()) : 0);
        }

        public string GetFlag()
        {
            return (Request.QueryString["flag"] != null ? (Request.QueryString["flag"].ToString()) : "");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        public void getChildList()
        {

        }
        public void OnSave()
        {
            string type = "doc";
            string empid = ReadSession().Emp_Id.ToString();
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            int pos = p_file.LastIndexOf(".");
            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            switch (type)
            {
                case "pdf":
                    break;
                case "jpg":
                    break;
                default:
                    lblMessage.Text = "Error:Unable to upload,Invalid file type!";
                    lblMessage.ForeColor = Color.Red;
                    return;
            }

            string docPath = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(TxtFileDescription.Text + "." + type, empid, docPath);

            if (info.Substring(0, 5) == "error")
                return;

            string flag = "";

            if (GetId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }

            DataTable retValue = _ceaDao.OnSave(flag, GetId().ToString(), empid, ddlCEAFor.SelectedValue, txtbillDate.Text,
                                 txtBillAmt.Text, ddlFromFy.Text, ddlFromMonth.Text, ddlToFy.Text, ddlToMonth.Text, txtnarration.Text,
                                 TxtFileDescription.Text, type, ReadSession().Emp_Id.ToString());

            foreach (DataRow dr in retValue.Rows)
            {
                if (dr["SUCCESS"].ToString() == "0")
                {
                    ErrorMessage(retValue);
                }
                else
                {

                    string location_2_move = docPath + "\\doc\\CEABills".ToString();

                    string file_2_create = location_2_move + "\\" + dr["id"].ToString() + "." + type;


                    if (File.Exists(file_2_create))
                        File.Delete(file_2_create);

                    if (!Directory.Exists(location_2_move))
                        Directory.CreateDirectory(location_2_move);

                    File.Move(info, file_2_create);

                    string strMessage = "File Uploaded as  " + file_2_create;

                    lblMessage.Text = strMessage;
                    lblMessage.ForeColor = Color.Green;

                }

            }
        }

        private void ErrorMessage(DataTable dt)
        {

            DataRow dr;
            dr = dt.Rows[0];

            if (dr["SUCCESS"].ToString() == "0")
            {
                lblMessage.Text = dr["REMARKS"].ToString();
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
                Response.Redirect("List.aspx");
        }

        public string uploadFile(String fileName, string rowid, string WorkFlowPath)
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
                    string saved_file_name = WorkFlowPath + "\\doc\\CEABills\\" + fileName;
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            _ceaDao.OnDelete(GetId().ToString());

            string empid = ReadSession().Emp_Id.ToString();

            if (GetFlag() == "i")
            {
                Response.Redirect("ListCEAClaim.aspx?Id=" + empid + "");
            }
            else
            {
                Response.Redirect("ListCEAClaim.aspx?");
            }
        }

        protected void txtEmployee_TextChanged(object sender, EventArgs e)
        {
            lblEmployeeName.Text = GetEmpInfoForLabel(txtEmployee.Text, lblEmployeeName.Text);
            txtEmployee.Text = "";
            string empid = ReadSession().Emp_Id.ToString();
            _clsDao.CreateDynamicDDl(ddlCEAFor, "Select ID,RTRIM(FIRST_NAME+ ' ' + isnull(MIDDLE_NAME,'') + ' ' + LAST_NAME)[FULL_NAME]from FamilyMembers where Date_Of_Birth between dateadd(year,-18,cast (GETDATE() as date)) and dateadd(year,-3,cast (GETDATE() as date))and RELATION in (1457,1458) and employee_id="
                                                 + empid, "ID", "FULL_NAME", "", "Select");

        }

        

    }
}