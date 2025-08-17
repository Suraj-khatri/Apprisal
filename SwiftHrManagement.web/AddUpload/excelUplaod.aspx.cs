using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace SwiftHrManagement.web.AddUpload
{
    public partial class excelUplaod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            string INS_str ="";

            string str;
            double str2;
            string str3;
            int rCnt = 0;
            int cCnt = 0;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open("C:\\your_excel_file.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;
        }
        private void checkDB()
        {
            SqlConnection connection = new SqlConnection(string.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", "your_sql_server", "your_sql_table"));
            SqlCommand command;
            connection.Open();

            for (rCnt = 2; rCnt )
            {
                for (cCnt = 1; cCnt 1)
                {
                    if (str.Contains("'"))
                    {
                        INS_str = INS_str + "'" + str.Replace("'", """) + "',";
                    }
                    else
                    {
                        INS_str = INS_str + "'" + str + "',";
                    }
                }
                else
                {
                    if (str.Contains("'"))
                    {
                         INS_str = "'" + str.Replace("'", """) + "',";
                    }
                    else
                    {
                        INS_str = "'" + str + "',";
                    }
            }
            }

            Exception handling:

            catch (Exception exc)
            {
            if (exc.Message.Contains(""))
            {
            str2 = Convert.ToDouble((range.Cells[rCnt, cCnt] as Excel.Range).Value2);
            str3 = Convert.ToString(str2);
            }
            }

            }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            }
            private void releaseObject(object obj)
            {
            try
            {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
            }
            catch (Exception ex)
            {
            obj = null;
            MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
            GC.Collect();
            }
            }

            We then save the package into a file system.

            Dts.TaskResult = (int)ScriptResults.Success;
            SIFISO_app.SaveToXml("C:\\TEMP\\pkg_Read_Excel_Into_Csharp.dtsx", p, null);
        }
    }
}