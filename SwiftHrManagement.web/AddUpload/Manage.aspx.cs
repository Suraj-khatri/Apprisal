using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SwiftHrManagement.web.AddUpload
{
    public partial class Manage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void upload()
        {            
            var values = GetAllLines();

            DataTable dt = new DataTable();

            foreach (var item in values.FirstOrDefault())
            {

                if (!dt.Columns.Contains(item))
                    dt.Columns.Add(item);

            }

            var allvalues = values.Skip(1).ToList();

            for (int i = 0; i < allvalues.Count; i++)
            {
                dt.Rows.Add(allvalues[i]);
            }
            clsDAO _clsDao = new clsDAO();

            string msg = _clsDao.uploadData(ref dt);

            StringBuilder str = new StringBuilder("<table width=\"500\" border=\"0\" class=\"TBL\" cellpadding=\"3\" cellspacing=\"3\" align=\"center\">");
            int cols = dt.Columns.Count;
            str.Append("<tr>");

            for (int i = 0; i < cols; i++)
            {
                str.Append("<th><div align=\"left\">" + dt.Columns[i].ColumnName + "</div></th>");
            }
            str.Append("</tr>");

            foreach (DataRow row in dt.Rows)
            {
                str.Append("<tr>");
                for (int i = 0; i < cols; i++)
                {
                    str.Append("<td align=\"left\">" + row[i].ToString() + "</td>");                    
                }
                str.Append("</tr>");
            }
            str.Append("</table>");
            rpt.InnerHtml = str.ToString();

        }
        private IEnumerable<string[]> GetAllLines()
        {

            string str;

            using (StreamReader rd = new StreamReader("D:/PROJECT_LATEST/ERP_NABIL/SwiftHrManagement.web/doc/upload.csv"))
            {

                while ((str = rd.ReadLine()) != null)
                {

                    yield return str.Split(',');

                }

            }

        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            upload();
        }


    }
}