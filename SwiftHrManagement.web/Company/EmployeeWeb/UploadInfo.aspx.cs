using SwiftHrManagement.web.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SwiftHrManagement.DAL.Models;
using SwiftHrManagement.DAL.EmployeeDAO;
using System.IO;
using ClosedXML.Excel;
using SwiftHrManagement.web.Library;

namespace SwiftHrManagement.web.Company.EmployeeWeb
{
    public partial class UploadInfo : BasePage
    {
        EmployeeDAO _EMP = null;

        public UploadInfo()
        {
            this._EMP = new EmployeeDAO();

        }
        private string connection = ConfigurationSettings.AppSettings["connectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        #region Empinfo_upload
        //protected void btnUploadEmp_Click(object sender, EventArgs e)
        //{
        //    if (Emp_uploadFile.PostedFile != null)
        //    {
        //        try
        //        {

        //            //string fileName = Path.GetFileName(Emp_uploadFile.FileName);
        //            //string uniqueFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{DateTime.Now.Ticks}{Path.GetExtension(fileName)}";
        //            //string path = Server.MapPath("~/App_Data/" + uniqueFileName);

        //            //if (!Directory.Exists(Server.MapPath("~/App_Data/")))
        //            //{
        //            //    Directory.CreateDirectory(Server.MapPath("~/App_Data/"));
        //            //}


        //            string path =Server.MapPath("~/App_Data/" + Emp_uploadFile.FileName);
        //            Emp_uploadFile.SaveAs(path);
        //            List<EmployeeUpload> EmpList = new List<EmployeeUpload>();
        //            string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
        //            using (OleDbConnection con = new OleDbConnection(excelCS))
        //            {
        //                DataTable dtExcel = new DataTable();
        //                OleDbDataAdapter cmd = new OleDbDataAdapter(@"SELECT * FROM  [Sheet1$]", con);
        //                con.Open();
        //                // Create DbDataReader to Data Worksheet  
        //                cmd.Fill(dtExcel);
        //                for (int i = 0; i < dtExcel.Rows.Count; i++)
        //                {
        //                    if (!String.IsNullOrEmpty(dtExcel.Rows[i]["EMP_CODE"].ToString()))
        //                    {
        //                        EmpList.Add(new EmployeeUpload
        //                        {
        //                            BRANCH_NAME = dtExcel.Rows[i]["BRANCH_NAME"].ToString(),
        //                            DATE_OF_APPIONTMENT = dtExcel.Rows[i]["DATE_OF_APPIONTMENT"].ToString(),
        //                            DATE_OF_BIRTH = dtExcel.Rows[i]["DATE_OF_BIRTH"].ToString(),
        //                            DATE_OF_JOINING = dtExcel.Rows[i]["DATE_OF_JOINING"].ToString(),
        //                            LASTPROMOTED = dtExcel.Rows[i]["LASTPROMOTED"].ToString(),
        //                            LASTTRANSFER = dtExcel.Rows[i]["LASTTRANSFER"].ToString(),
        //                            Salution = dtExcel.Rows[i]["SALUTATION"].ToString(),
        //                            FirstName = dtExcel.Rows[i]["FIRST_NAME"].ToString(),
        //                            MiddleName = dtExcel.Rows[i]["MIDDLE_NAME"].ToString(),
        //                            LastName = dtExcel.Rows[i]["LAST_NAME"].ToString(),
        //                            DEPARTMENT = dtExcel.Rows[i]["DEPARTMENT"].ToString(),
        //                            EMPLOYEE_STATUS = dtExcel.Rows[i]["EMPLOYEE_STATUS"].ToString(),
        //                            EMPLOYEE_TYPE = dtExcel.Rows[i]["EMPLOYEE_TYPE"].ToString(),
        //                            Emp_Code = dtExcel.Rows[i]["EMP_CODE"].ToString(),
        //                            Gender = dtExcel.Rows[i]["GENDER"].ToString(),
        //                            MERITAL_STATUS = dtExcel.Rows[i]["MERITAL_STATUS"].ToString(),
        //                            OFFICE_EMAIL = dtExcel.Rows[i]["OFFICE_EMAIL"].ToString(),
        //                            POSITION = dtExcel.Rows[i]["POSITION"].ToString(),
        //                            PhoneNumber = dtExcel.Rows[i]["PhoneNumber"].ToString(),

        //                        });
        //                    }
        //                }

        //                string mgs = _EMP.insertBulkEmployee(EmpList, ReadSession().Emp_Id.ToString());
        //                lblMessage.Text = "Correct record of employee has uploaded successfully. Click on 'Incorrect Record' button to download incorrect data which ware not uploaded.";
        //                lblMessage.ForeColor = System.Drawing.Color.Green;
        //                btnDownloadEmp.Text = "Incorrect Record";
        //                btnDownloadEmp.CssClass = "btn btn-success btn-sm";


        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ex.Message.Contains("Sheet1$' is not a valid name"))
        //            {
        //                lblMessage.Text = "Please rename the sheet of excel to the 'Sheet1'";
        //            }
        //            else if (ex.Message.Contains("Could not find a part of the path "))
        //            {
        //                lblMessage.Text = "Please select the file to upload";
        //            }
        //            else
        //            {
        //                lblMessage.Text = ex.Message;
        //            }

        //            lblMessage.ForeColor = System.Drawing.Color.Red;
        //        }
        //    }
        //}

        protected void btnUploadEmp_Click(object sender, EventArgs e)
        {
            if (Emp_uploadFile.HasFile)
            {
                try
                {
                    string directoryPath = Server.MapPath("~/App_Data/");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }
                    string fileName = Path.GetFileName(Emp_uploadFile.FileName);
                    string uniqueFileName = $"{Path.GetFileNameWithoutExtension(fileName)}_{DateTime.Now.Ticks}{Path.GetExtension(fileName)}";

                    string path = Path.Combine(directoryPath, uniqueFileName);

                    Emp_uploadFile.SaveAs(path);

                    List<EmployeeUpload> EmpList = new List<EmployeeUpload>();
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        DataTable dtExcel = new DataTable();
                        OleDbDataAdapter cmd = new OleDbDataAdapter(@"SELECT * FROM  [Sheet1$]", con);
                        con.Open();
                        cmd.Fill(dtExcel);

                        for (int i = 0; i < dtExcel.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(dtExcel.Rows[i]["EMP_CODE"].ToString()))
                            {
                                EmpList.Add(new EmployeeUpload
                                {
                                    BRANCH_NAME = dtExcel.Rows[i]["BRANCH_NAME"].ToString(),
                                    DATE_OF_APPIONTMENT = dtExcel.Rows[i]["DATE_OF_APPIONTMENT"].ToString(),
                                    DATE_OF_BIRTH = dtExcel.Rows[i]["DATE_OF_BIRTH"].ToString(),
                                    DATE_OF_JOINING = dtExcel.Rows[i]["DATE_OF_JOINING"].ToString(),
                                    LASTPROMOTED = dtExcel.Rows[i]["LASTPROMOTED"].ToString(),
                                    LASTTRANSFER = dtExcel.Rows[i]["LASTTRANSFER"].ToString(),
                                    Salution = dtExcel.Rows[i]["SALUTATION"].ToString(),
                                    FirstName = dtExcel.Rows[i]["FIRST_NAME"].ToString(),
                                    MiddleName = dtExcel.Rows[i]["MIDDLE_NAME"].ToString(),
                                    LastName = dtExcel.Rows[i]["LAST_NAME"].ToString(),
                                    DEPARTMENT = dtExcel.Rows[i]["DEPARTMENT"].ToString(),
                                    EMPLOYEE_STATUS = dtExcel.Rows[i]["EMPLOYEE_STATUS"].ToString(),
                                    EMPLOYEE_TYPE = dtExcel.Rows[i]["EMPLOYEE_TYPE"].ToString(),
                                    Emp_Code = dtExcel.Rows[i]["EMP_CODE"].ToString(),
                                    Gender = dtExcel.Rows[i]["GENDER"].ToString(),
                                    MERITAL_STATUS = dtExcel.Rows[i]["MERITAL_STATUS"].ToString(),
                                    OFFICE_EMAIL = dtExcel.Rows[i]["OFFICE_EMAIL"].ToString(),
                                    POSITION = dtExcel.Rows[i]["POSITION"].ToString(),
                                    PhoneNumber = dtExcel.Rows[i]["PhoneNumber"].ToString(),
                                });
                            }
                        }

                        string mgs = _EMP.insertBulkEmployee(EmpList, ReadSession().Emp_Id.ToString());

                        lblMessage.Text = "Correct record of employee has uploaded successfully. Click on 'Incorrect Record' button to download incorrect data which were not uploaded.";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        btnDownloadEmp.Text = "Incorrect Record";
                        btnDownloadEmp.CssClass = "btn btn-success btn-sm";
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Sheet1$' is not a valid name"))
                    {
                        lblMessage.Text = "Please rename the sheet of Excel to 'Sheet1'";
                    }
                    else if (ex.Message.Contains("Could not find a part of the path "))
                    {
                        lblMessage.Text = "Please select the file to upload.";
                    }
                    else
                    {
                        lblMessage.Text = "Error: " + ex.Message;
                    }

                    lblMessage.ForeColor = System.Drawing.Color.Red;

                    System.IO.File.WriteAllText(Server.MapPath("~/App_Data/error_log.txt"), ex.ToString());
                }
            }
            else
            {
                lblMessage.Text = "Please select a file to upload.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }



        protected void btnDownloadEmp_Click(object sender, EventArgs e)
        {
            string test = btnDownloadEmp.Text.ToString();
            if (test.Contains("Incorrect"))
            {
                ExportExcelEmp("");
                btnDownloadEmp.Text = "Download Sample";
                btnDownloadEmp.CssClass = "btn btn-warning btn-sm";
            }
            else
            {
                ExportExcelEmp("d");
            }

        }
        private void ExportExcelEmp(string flag)
        {

            string filename = flag == "d" ? "EmpInfoSample_" + DateTime.Now : "EmpInfoIncorrect_" + DateTime.Now;
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [EMP_CODE]
                                                          ,[SALUTATION]
                                                          ,[FIRST_NAME]
                                                          ,[MIDDLE_NAME]
                                                          ,[LAST_NAME]
                                                          ,[GENDER]
                                                          ,[DATE_OF_BIRTH]
                                                          ,[MERITAL_STATUS]
                                                          ,[BRANCH_NAME]
                                                          ,[DEPARTMENT]
                                                          ,[POSITION]
                                                          ,[DATE_OF_APPIONTMENT]
                                                          ,[DATE_OF_JOINING]
                                                          ,[EMPLOYEE_STATUS]
                                                          ,[EMPLOYEE_TYPE]
                                                          ,[LASTTRANSFER]
                                                          ,[LASTPROMOTED]
                                                          ,[PhoneNumber]
                                                          ,[OFFICE_EMAIL]
                                                          ,[Error] FROM Employee_Upload WHERE IsPosted =0 AND BatchId=(select max(BatchId) from Employee_Upload ) ORDER BY EMP_CODE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (flag == "d")
                            {
                                dt.Columns.Remove("Error");
                            }
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Sheet1");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }

            }

        }
        #endregion
        #region Transfer
        protected void btnUploadTransfer_Click(object sender, EventArgs e)
        {
            if (FileUploadTransfer.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/App_Data/" + FileUploadTransfer.FileName));
                    FileUploadTransfer.SaveAs(path);
                    List<TransferUpload> TransferList = new List<TransferUpload>();
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        DataTable dtExcel = new DataTable();
                        OleDbDataAdapter cmd = new OleDbDataAdapter(@"SELECT * FROM  [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        cmd.Fill(dtExcel);
                        for (int i = 0; i < dtExcel.Rows.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(dtExcel.Rows[i]["EMP_Code"].ToString()))
                            {
                                TransferList.Add(new TransferUpload
                                {
                                    EMP_Code = dtExcel.Rows[i]["EMP_Code"].ToString(),
                                    EFFECTIVE_DATE = dtExcel.Rows[i]["EFFECTIVE_DATE"].ToString(),
                                    FROM_BRANCH = dtExcel.Rows[i]["FROM_BRANCH"].ToString(),
                                    TO_BRANCH = dtExcel.Rows[i]["TO_BRANCH"].ToString(),
                                    TO_DEPARTMENT = dtExcel.Rows[i]["TO_DEPARTMENT"].ToString(),
                                    FROM_DEPARTMENT = dtExcel.Rows[i]["FROM_DEPARTMENT"].ToString(),

                                });
                            }
                        }
                        string mgs = _EMP.insertBulkTransfer(TransferList, ReadSession().Emp_Id.ToString());

                        lblTransfer.Text = "Correct record of employee transfer has uploaded successfully. Click on 'Incorrect Record' button to download incorrect data which ware not uploaded.";
                        lblTransfer.ForeColor = System.Drawing.Color.Green;
                        btnDownloadTransfer.Text = "Incorrect Record";
                        btnDownloadTransfer.CssClass = "btn btn-success btn-sm";

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Sheet1$' is not a valid name"))
                    {
                        lblTransfer.Text = "Please rename the sheet of excel to the 'Sheet1'";
                    }
                    else
                    {
                        lblTransfer.Text = ex.Message;
                    }

                    lblTransfer.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnDownloadTransfer_Click(object sender, EventArgs e)
        {
            string test = btnDownloadTransfer.Text.ToString();
            if (test.Contains("Incorrect"))
            {
                ExportExcelTransfer("");
                btnDownloadEmp.Text = "Download Sample";
                btnDownloadEmp.CssClass = "btn btn-warning btn-sm";
            }
            else
            {
                ExportExcelTransfer("d");
            }

        }
        public void ExportExcelTransfer(string flag)
        {
            string filename = flag == "d" ? "TransferInfoSample_" + DateTime.Now : "TransferInfoIncorrect_" + DateTime.Now;
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT [EMP_Code]
                                                              ,[EFFECTIVE_DATE]
                                                              ,[FROM_BRANCH]                                                             
                                                              ,[TO_BRANCH] 
                                                              ,[FROM_DEPARTMENT]
                                                              ,[TO_DEPARTMENT]                                                  
                                                              ,[Error]
                                                          FROM [dbo].[Transfer_Upload] WHERE IsPosted =0 AND BatchId=(select max(BatchId) from Transfer_Upload ) ORDER BY EMP_CODE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (flag == "d")
                            {
                                dt.Columns.Remove("Error");
                            }
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Sheet1");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region promotion
        protected void btnUploadPromotion_Click(object sender, EventArgs e)
        {
            if (FilePromotionUpload.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/App_Data/" + FilePromotionUpload.FileName));
                    FilePromotionUpload.SaveAs(path);
                    List<PromotionUpload> promotionList = new List<PromotionUpload>();
                    string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        DataTable dtExcel = new DataTable();
                        OleDbDataAdapter cmd = new OleDbDataAdapter(@"SELECT * FROM  [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        cmd.Fill(dtExcel);
                        for (int i = 0; i < dtExcel.Rows.Count; i++)
                        {
                            promotionList.Add(new PromotionUpload
                            {
                                //BRANCH = dtExcel.Rows[i]["BRANCH"].ToString(),
                                //DEPARTMENT = dtExcel.Rows[i]["DEPARTMENT"].ToString(),
                                Emp_code= dtExcel.Rows[i]["Emp_code"].ToString(),
                                New_Position = dtExcel.Rows[i]["New_Position"].ToString(),
                                OLD_POSITION = dtExcel.Rows[i]["OLD_POSITION"].ToString(),
                                PROMOTION_DATE = dtExcel.Rows[i]["PROMOTION_DATE"].ToString(),
                                emp_type = dtExcel.Rows[i]["emp_type"].ToString(),
                               
                            });
                        }
                        string mgs = _EMP.insertBulkPromotion(promotionList, ReadSession().Emp_Id.ToString());
                       
                        lblPromotion.Text = "Correct record of employee promotion has uploaded successfully. Click on 'Incorrect Record' button to download incorrect data which ware not uploaded.";
                        lblPromotion.ForeColor = System.Drawing.Color.Green;                       
                        btnDownloadPromotion.Text = "Incorrect Record";
                        btnDownloadPromotion.CssClass = "btn btn-success btn-sm";

                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Sheet1$' is not a valid name"))
                    {
                        lblPromotion.Text = "Please rename the sheet of excel to the 'Sheet1'";
                    }
                    
                    else
                    {
                        lblPromotion.Text = ex.Message;
                    }

                    lblPromotion.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
        protected void btnDownloadPromotion_Click(object sender, EventArgs e)
        {
            string test = btnDownloadPromotion.Text.ToString();
            if (test.Contains("Incorrect"))
            {
                ExportExcelPromotion("");
                btnDownloadEmp.Text = "Download Sample";
                btnDownloadEmp.CssClass = "btn btn-warning btn-sm";
            }
            else
            {
                ExportExcelPromotion("d");
            }

        }
        public void ExportExcelPromotion(string flag)
        {
            string filename = flag == "d" ? "PromotionInfoSample_" + DateTime.Now : "PromotionInfoIncorrect_" + DateTime.Now;
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand(@"SELECT  
                                                        [Emp_code]
                                                      ,[New_Position]
                                                      ,[OLD_POSITION]
                                                      ,[PROMOTION_DATE]                                                     
                                                      ,[emp_type]
                                                      ,[Error]
                                                       FROM Promotion_Upload WHERE IsPosted =0 AND BatchId=(select max(BatchId) from Promotion_Upload ) ORDER BY EMP_CODE"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            if (flag == "d")
                            {
                                dt.Columns.Remove("Error");
                            }
                            using (XLWorkbook wb = new XLWorkbook())
                            {
                                wb.Worksheets.Add(dt, "Sheet1");

                                Response.Clear();
                                Response.Buffer = true;
                                Response.Charset = "";
                                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                                Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
                                using (MemoryStream MyMemoryStream = new MemoryStream())
                                {
                                    wb.SaveAs(MyMemoryStream);
                                    MyMemoryStream.WriteTo(Response.OutputStream);
                                    Response.Flush();
                                    Response.End();
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}