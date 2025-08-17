using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using SwiftHrManagement.DAL.Role;
using System.Data.SqlClient;
using SwiftHrManagement.DAL.CustomerFileUploader;

namespace SwiftHrManagement.web.TrainingManagement.ExternalTrainingManagement
{
    public partial class ManageExtTraining : BasePage
    {
        clsDAO CLsDAo = null;
        RoleMenuDAOInv _roleMenuDao = null;
        string file_2_be_deleted = "";
        CustomerFileUploaderDao _fileuploader = null;
        string checkRecoAssign = null;
        string DocStatus = "";
        public ManageExtTraining()
        {
            CLsDAo = new clsDAO();
           _roleMenuDao = new RoleMenuDAOInv();
           this._fileuploader = new CustomerFileUploaderDao();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //setddl();
            displayTraineeRecommender();

            if (Getflag() == "s" )
          {
                showcc.Visible = false;
                diseableOperation();
                populatedata();
                Btn_Save.Visible = false;
                BtnDelete.Visible = false;
                trainingUpload.Visible = false;
               
          }
            else if (Getflag() == "c")
            {
                diseableOperation();
                populatedata();
                Btn_Save.Visible = false;
                BtnDelete.Visible = false;
                trainingUpload.Visible = false;
            
            }


            else
            {
                if (!IsPostBack)
                {
                    if (_roleMenuDao.hasAccess(ReadSession().AdminId, 43) == false)
                    {
                        Response.Redirect("/Error.aspx");
                    }
                    setddl();
                    displayTraineeRecommender();
                    if (GetExtTrainingId() > 0)
                    {
                        populatedata();

                    }
                    else
                    {

                        BtnDelete.Visible = false;
                        listFileInformation(_fileuploader.GetTrainingFileInfo(GetTrainingFileId().ToString(), ReadSession().Sessionid));
                    }

                }
                if (Request.Form["chk_recoAssign_id"] != null)
                    checkRecoAssign = Request.Form["chk_recoAssign_id"].ToString();


            }
        

            if (Request.Form["chkTran"] != null)
                file_2_be_deleted = Request.Form["chkTran"].ToString();

            txtStartDate.Attributes.Add("onblur","checkDateFormat(this);");
            txtEndDate.Attributes.Add("onblur", "checkDateFormat(this);");
            txtNominateWithin.Attributes.Add("onblur", "checkDateFormat(this);");
            TxtCostEstimate.Attributes.Add("onblur", "checknumber(this);");
            txtNoOfHOurs.Attributes.Add("onblur", "checknumber(this);");
            txtTotalCapacity.Attributes.Add("onblur", "checknumber(this);");

            Btn_Save.Attributes.Add("onclick", "GetId();");
      }
        
        private void setddl()
        {

            CLsDAo.CreateDynamicDDl(DDLApprovedBy, "select FIRST_NAME+' '+MIDDLE_NAME+' '+LAST_NAME+'-'+EMP_CODE as employee,EMPLOYEE_ID from Employee where POSITION_ID in ('158','161')", "EMPLOYEE_ID", "employee", "", "Select");

        }

        private void populatedata()
        {
            setddl();
            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("Exec [proc_externalTrainingInfo] 'a',@external_traingin_id="+ filterstring(GetExtTrainingId().ToString())+"").Tables[0];
              DataRow dr = null;
            if (dt.Rows.Count > 0)
            {
                dr = dt.Rows[0];

            }
            if (dr == null)
                return;

                TxtProgramName.Text = dr["Program_Name"].ToString();
                txtStartDate.Text = dr["Start_date"].ToString();
                txtEndDate.Text = dr["End_Date"].ToString();
                txtConductedBy.Text = dr["Conducted_By"].ToString();
                txtVenue.Text = dr["Venue"].ToString();
                txtTotalCapacity.Text = dr["Total_Capacity"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtCountry.Text = dr["Country"].ToString();
                txtNoOfDays.Text = dr["No_of_days"].ToString();
                txtNoOfHOurs.Text = dr["No_of_Hours"].ToString();
                TxtCostEstimate.Text = dr["Cost_Estimate"].ToString();
                txtProgramDesc.Text = dr["Program_Description"].ToString();
                txtNominateWithin.Text = dr["Nominate_within"].ToString();
                DDLApprovedBy.Text = dr["Approved_by"].ToString();
               listFileInformation(_fileuploader.GetTrainingFileInfo1(GetTrainingFileId().ToString()));
                
          
            
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            updateOperation();
        }

        private long GetExtTrainingId()
        {
            return (Request.QueryString["external_traingin_id"] != null ? long.Parse(Request.QueryString["external_traingin_id"].ToString()) : 0);
        }
        private string Getflag()
        {
            return (Request.QueryString["flag"] != null ? Request.QueryString["flag"].ToString() : "");
        }

        private void diseableOperation()
        {
          

                TxtProgramName.Enabled = false;
                txtStartDate.Enabled = false;
                txtEndDate.Enabled = false;
                txtConductedBy.Enabled = false;
                txtVenue.Enabled = false;
                txtTotalCapacity.Enabled = false;
                txtCity.Enabled = false;
                txtCountry.Enabled = false;
                txtNoOfDays.Enabled = false;
                txtNoOfHOurs.Enabled = false;
                TxtCostEstimate.Enabled = false;
                txtProgramDesc.Enabled = false;

                txtEmpId.Visible = false;
                btnAddRec.Visible = false;
                BtnDeleteReco.Visible = false;
                DDLApprovedBy.Enabled = false;

            

        }


        private void updateOperation()
        {
            

         string sql = "exec [proc_externalTrainingInfo] @flag=" + (GetExtTrainingId().ToString() == "0" ? "'i'" : "'u'") + ",@external_traingin_id=" + filterstring(GetExtTrainingId().ToString()) + ",@user=" + filterstring(ReadSession().UserId);
            sql = sql + ",@Program_Name=" + filterstring(TxtProgramName.Text);
            sql = sql + ",@Start_date=" + filterstring(txtStartDate.Text);
            sql = sql + ",@End_Date=" + filterstring(txtEndDate.Text);
            sql = sql + ",@Conducted_By=" + filterstring(txtConductedBy.Text);
            sql = sql + ",@Venue=" + filterstring(txtVenue.Text);
            sql = sql + ",@Total_Capacity=" + filterstring(txtTotalCapacity.Text);
            sql = sql + ",@City=" + filterstring(txtCity.Text);
            sql = sql + ",@Country=" + filterstring(txtCountry.Text);
            sql = sql + ",@No_of_days=" + filterstring(txtNoOfDays.Text);
            sql = sql + ",@No_of_Hours=" + filterstring(txtNoOfHOurs.Text);
            sql = sql + ",@Cost_Estimate=" + filterstring(TxtCostEstimate.Text);
            sql = sql + ",@Program_Description=" + filterstring(txtProgramDesc.Text);
            sql = sql + ",@Nominate_within=" + filterstring(txtNominateWithin.Text);
            sql = sql + ",@session_id=" + filterstring(ReadSession().Sessionid);
            sql = sql + ",@ApprovedBy=" + filterstring(DDLApprovedBy.Text);
            sql = sql + ",@ccEmails=" + filterstring(HiddenFieldEmpEmail.Value);

            CLsDAo.runSQL(sql);
           Response.Redirect("/TrainingManagement/ExternalTrainingManagement/List.aspx");
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            deleteOperation();

        }
        private void deleteOperation()
        {

            CLsDAo.runSQL("exec [proc_externalTrainingInfo] 'd',@external_traingin_id="+GetExtTrainingId()+"");
            Response.Redirect("/TrainingManagement/ExternalTrainingManagement/List.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            if (Getflag() == "s")
            {
                Response.Redirect("/TrainingManagement/ExternalTrainingManagement/ListAddTraineeParticipant.aspx");


            }
            if (Getflag() == "c")
            {
                Response.Redirect("/TrainingManagement/ExternalTrainingManagement/List.aspx");


            }
            else
            {
                Response.Redirect("/TrainingManagement/ExternalTrainingManagement/List.aspx");
            }

        }
        protected void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            txtNoOfDays.Text = "";
            if (txtStartDate.Text != "0" && txtEndDate.Text != "0")
            {
                DateTime startDate = DateTime.Parse( txtStartDate.Text);
                DateTime endDate = DateTime.Parse(txtEndDate.Text);


                string days = (endDate - startDate).TotalDays.ToString();
                days = (int.Parse(days) + 1).ToString();
                txtNoOfDays.Text = days;


                //txtNoOfDays.Text = (endDate - startDate).TotalDays;

            }

        }

        #region  upload doc
     
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string type = "Doc";
            string p_file = fileUpload.PostedFile.FileName.ToString().Replace("\\", "/");
            int pos = p_file.LastIndexOf(".");

            if (pos < 0)
                type = "";
            else
                type = p_file.Substring(pos + 1, p_file.Length - pos - 1);

            switch (type)
            {

                case "bmp":
                    break;
                case "jpg":
                    break;
                case "xls":
                    break;
                case  "docx":
                    break;
                case "doc":
                    break;
                case "gif":
                    break;
                case "pdf":
                    break;

                default:
                    lblMessage.Text = "Error: Invalid file type!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
            }

            string root = ConfigurationSettings.AppSettings["root"];
            string info = uploadFile(GetTrainingFileId() + "." + type, GetTrainingFileId().ToString(), root);

            if (info.Substring(0, 5) == "error")
                return;

            string retValue = "";
            if (GetTrainingFileId() > 0)
            {
                retValue = saveData(GetTrainingFileId(), txtFileDesc.Text, ReadSession().UserId, type, "");
            }
            else
            {
                retValue = saveData(GetTrainingFileId(), txtFileDesc.Text, ReadSession().UserId, type, ReadSession().Sessionid);
            }
            if (GetExtTrainingId() > 0)
            {
                listFileInformation(_fileuploader.GetTrainingFileInfo1(GetTrainingFileId().ToString()));
            }
            else
            {
                listFileInformation(_fileuploader.GetTrainingFileInfo(GetTrainingFileId().ToString(), ReadSession().Sessionid));
            }

            if (retValue == "0")
                return;


            string location_2_move = root + "\\Doc\\Customer".ToString();
            string file_2_create = location_2_move + "\\" + retValue + "." + type;

            if (File.Exists(file_2_create))
            {
                File.Delete(file_2_create);
            }

            if (!Directory.Exists(location_2_move))
                Directory.CreateDirectory(location_2_move);

            File.Move(info, file_2_create);
            string strMessage = "File Uploaded: " + fileUpload.Value;

            lblMessage.Text = strMessage;
            lblMessage.ForeColor = System.Drawing.Color.Green;


        }


        private string saveData(int JOB_ID, string FILE_DESC, string UPLOAD_BY, string FILE_TYPE, string sessionId)
        {

            string flag = "";

            SqlParameter[] p = new SqlParameter[7];
            if (GetTrainingFileId() > 0)
            {
                flag = "u";
            }
            else
            {
                flag = "i";
            }

            string sql = " [procTrainingFileUpload] @flag='" + flag + "',@ROW_ID=0, @CUST_ID='" +
                    JOB_ID + "',@FILE_DESC='" + FILE_DESC + "',@UPLOAD_BY='" +
                    UPLOAD_BY + "',@FILE_TYPE='" + FILE_TYPE +
                    "',@session_id='" + sessionId + "'";


            DataTable dt = CLsDAo.getDataset(sql).Tables[0];
            string Msg = "";
            string retCode = "";

            foreach (DataRow dr in dt.Rows)
            {
                retCode = dr["returnCode"].ToString();
                Msg = dr["msg"].ToString();
            }

            if (retCode == "0")
            {
                lblMessage.Text = Msg;
                lblMessage.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                retCode = Msg;
            }

            return retCode;
        }

        public string uploadFile(String fileName, string rowid, string FilePath)
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
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return "error:Unable to upload,file exceeds maximum limit";
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return "error:" + ex.Message + "Permission to upload file denied";
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
                    td1.Text = row["FILE_DESC"].ToString();
                    td2.Text = row["FILE_TYPE"].ToString();

                    if (Getflag() != "")
                    {
                        td4.Text = "<a target='_blank' href='/Doc/Customer" + "/" + row["ROWID"] + "." + row["FILE_TYPE"].ToString() + "'> View </a>";

                    }

                    else
                    {
                        td3.Text = "<input type='checkbox' name='chkTran' ROWID='chkTran' value='" + row["ROWID"].ToString() + "'>";
                        td4.Text = "<a target='_blank' href='/Doc/Customer" + "/" + row["ROWID"] + "." + row["FILE_TYPE"].ToString() + "'> View </a>";
                    }
                    

                    tr.Cells.Add(td1);
                    tr.Cells.Add(td2);
                    tr.Cells.Add(td3);
                    tr.Cells.Add(td4);
                    tblResult.Rows.Add(tr);
                }
            }
        }

        private int GetTrainingFileId()
        {
            return (Request.QueryString["external_traingin_id"] != null ? int.Parse(Request.QueryString["external_traingin_id"].ToString()) : 0);
        }

        protected void DelateUpload_Click(object sender, EventArgs e)
        {
            if (file_2_be_deleted != "")
            {

                string FilePath = ConfigurationSettings.AppSettings["root"];
                string sql = "exec [procTrainingFileUpload] @Flag='e',@ROW_ID='0',@CUST_ID ='" + file_2_be_deleted + "'";

                DataTable dt = _fileuploader.delete_cust_file(sql).Tables[0];
                string location = FilePath + "\\Doc\\Customer\\" + GetTrainingFileId().ToString();


                foreach (DataRow row in dt.Rows)
                {
                    if (File.Exists(location + "\\" + row[0].ToString()))
                        File.Delete(location + "\\" + row[0].ToString());
                }
                if (GetExtTrainingId() > 0)
                {
                    listFileInformation(_fileuploader.GetTrainingFileInfo1(GetTrainingFileId().ToString()));

                }
                else
                {
                    listFileInformation(_fileuploader.GetTrainingFileInfo(GetTrainingFileId().ToString(), ReadSession().Sessionid));
                }

               
                lblMessage.Text = "";
                LblMsg.Text = "";
            }

        }






        #endregion

        protected void txtEmpId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DDLApprovedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAddRec_Click(object sender, EventArgs e)
        {
            AddRecommendedBy();
            ClearReco();
        }

        private void ClearReco()
        {
            txtEmpId.Text = "";
            txtEmpId.Focus();
        }
        private void AddRecommendedBy()
        {
            string sessionvalue = ChooseSession();
            string sql = "exec proc_ExtTrainingRecommend @flag='i',@EMPID=" + filterstring(HiddenFieldEmpID.Value) + ",@SESSION=" + filterstring(sessionvalue) + ",@USER=" + filterstring(ReadSession().UserId.ToString());
            //@branch=" + filterstring(DdlBranchName.Text);
            string msg = CLsDAo.GetSingleresult(sql);
            if (msg == "0")
            {

                lblRecMsg.Text = "";
            }
            else
            {
                lblRecMsg.Text = msg;
                lblRecMsg.ForeColor = System.Drawing.Color.Red;
            }



            displayTraineeRecommender();

        }
        private string ChooseSession()
        {
            string sessionvalue = null;
            if (GetExtTrainingId() > 0)
            {
                sessionvalue = GetExtTrainingId().ToString();
            }
            else
            {
                sessionvalue = ReadSession().Sessionid.ToString();
            }
            return sessionvalue;
        }

        private void displayTraineeRecommender()
        {
            //string brainch_id = ReadSession().Branch_Id.ToString();
            string sessionvalue = ChooseSession();
            DataTable dt = new DataTable();

            dt = CLsDAo.getDataset("exec proc_ExtTrainingRecommend @flag='s',@SESSION=" + filterstring(sessionvalue)).Tables[0];

            if (dt.Rows.Count == 0)
            {
                TraineeRecommender.InnerHtml = "<center><b> No Recommendee is assigned.</b><center>";
                return;
            }
            var str = new StringBuilder("<table width=\"100%\" border=\"0\" class=\"TBL\" cellpadding=\"5\" cellspacing=\"5\" align=\"center\">");
            str.Append("<tr>");
            int cols = dt.Columns.Count;
            for (int i = 0; i < cols; i++)
            {
                str.Append("<th align=\"left\">" + dt.Columns[i].ColumnName + "</th>");
            }
            str.Append("</tr>");
            foreach (DataRow dr in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + dr[i].ToString() + "</td>");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            TraineeRecommender.InnerHtml = str.ToString();
        }

        protected void BtnDeleteReco_Click(object sender, EventArgs e)
        {
            deleteRecommender();
        }
        private void deleteRecommender()
        {
            string sql = "exec [proc_ExtTrainingRecommend] @flag='d',@external_assign_id_chk=" + filterstring(checkRecoAssign) + " ";
            CLsDAo.runSQL(sql);
            displayTraineeRecommender();

        }
      

    }
}
