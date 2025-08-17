using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core;
using System;
using SwiftHrManagement.DAL.Report;
using DbResult = SwiftHrManagement.DAL.DbResult;

public class clsDAO : BaseDomain
{
    SqlConnection connection = null;
    string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
    public clsDAO()
    {
        Init();
    }
    private void Init()
    {
        this.connection = new SqlConnection(connstring);
    }
    public DataSet getDataset(string sql)
    {
        try
        {
            DataSet ds = new DataSet();

            this.OpenConnection();

            SqlDataAdapter da = new SqlDataAdapter(sql, this.connection);
            da.Fill(ds);
            da.Dispose();
            return ds;
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
           this.CloseConnection();
        }

    }
    private void OpenConnection()
    {
        if (this.connection.State == ConnectionState.Open)
            this.connection.Close();
        this.connection.Open();
    }

    private void CloseConnection()
    {
        if (this.connection.State == ConnectionState.Open)
            this.connection.Close();
    }

    public ReportResult ParseReportResult(string sql)
    {
        var ds = ExecuteDataset(sql);
        var res = new ReportResult();

        res.Sql = sql;
        res.Result = ds;

        if (ds == null || ds.Tables.Count == 0)
            return res;

        var tableCount = ds.Tables.Count;

        if (tableCount > 3)
        {
            res.ReportHead = ds.Tables[tableCount - 1].Rows[0][0].ToString();
        }

        if (tableCount > 2)
        {
            var html = new StringBuilder("");
            var hasFilters = false;
            foreach (DataRow dr in ds.Tables[tableCount - 2].Rows)
            {
                html.Append(" | " + dr[0] + "=" + dr[1]);
                hasFilters = true;
            }

            res.Filters = hasFilters ? html.ToString().Substring(2) : "";
        }

        if (tableCount > 1)
        {
            var pos = tableCount - 3;
            if (pos < 1)
                pos = 1;

            var dbresult = ParseDbResult(ds.Tables[pos]);
            res.ErrorCode = dbresult.ErrorCode;
            res.Msg = dbresult.Msg;
            res.Id = dbresult.Id;
            res.ResultSet = ds.Tables[0];
        }

        return res;
    }
    public string GetSingleresult(string sSql)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dread;
            string result = "";

            cmd = new SqlCommand(sSql, this.connection);
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                result = dread[0].ToString();
            }
            return result;
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
            CloseConnection();
        }
    }

    public int ReturnSqlStatement(string sSql)
    {
        try
        {
            this.OpenConnection();
            int result = 0;
            SqlCommand cmd = new SqlCommand(sSql, this.connection);

            if (cmd.ExecuteScalar() != System.DBNull.Value)
            {
                result = (int)cmd.ExecuteScalar();
            }
            else
            {
                result = 0;
            }
            return result;
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
            this.CloseConnection();
        }
    }
    public string DataTable2ExcelXML(ref DataTable dt)
    {
        return DataTable2ExcelXML(ref dt, false);
    }

    public string DataTable2Csv(ref DataTable dt)
    {
        char lineBreak = '\n';// Convert.ToChar(13);
        return DataTable2Csv(ref dt, lineBreak);
    }

    public string DataTable2Csv(ref DataTable dt, char lineBreak)
    {
        return DataTable2Csv(ref dt, true, lineBreak);
    }
    public string DataTable2Csv(ref DataTable dt, bool noColumnHeader, char lineBreak)
    {
        
        var csv = new StringBuilder();

        var comma = "";
        if (!noColumnHeader)
        {
            foreach (DataColumn col in dt.Columns)
            {
                csv.Append(comma + col.ColumnName);
                //parse data if necessary
                comma = ",";
            }
            csv.Append(lineBreak);
        }

        foreach (DataRow row in dt.Rows)
        {
            comma = "";
            foreach (DataColumn col in dt.Columns)
            {
                var data = row[col.ColumnName].ToString();
                //parse data if necessary
                csv.Append(comma + data);
                comma = ",";
            }
            csv.Append(lineBreak);
        }
        
        return csv.ToString();

    }
    public DataSet ExecuteDataset(string sql)
    {
        var ds = new DataSet() ;
        SqlDataAdapter da;

        try
        {
            OpenConnection();
            da = new SqlDataAdapter(sql, this.connection);

            da.Fill(ds);
            da.Dispose();
            CloseConnection();
        }

        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            da = null;
            CloseConnection();
        }
        return ds;
    }

    public DbResult ParseDbResult(DataTable dt)
    {
        var res = new DbResult();
        if (dt.Rows.Count > 0)
        {
            res.ErrorCode = dt.Rows[0][0].ToString();
            res.Msg = dt.Rows[0][1].ToString();
            res.Id = dt.Rows[0][2].ToString();
        }
        return res;
    }

    public string Table2Text(string sql, string rowDelimeter, string colDelimeter, bool noColumnHeader)
    {

        var dt = getTable(sql);

        var sb = new StringBuilder();

        var tmpColDelimeter = colDelimeter;
        colDelimeter = "";
        if (!noColumnHeader)
        {
            foreach (DataColumn col in dt.Columns)
            {
                sb.Append(colDelimeter + col.ColumnName);
                //parse data if necessary
                colDelimeter = tmpColDelimeter;
            }
            sb.Append(rowDelimeter);
        }

        foreach (DataRow row in dt.Rows)
        {
            colDelimeter = "";
            foreach (DataColumn col in dt.Columns)
            {
                var data = row[col.ColumnName].ToString();
                //parse data if necessary
                sb.Append(colDelimeter + data);
                colDelimeter = tmpColDelimeter;
            }
            sb.Append(rowDelimeter);
        }

        return sb.ToString();

    }

    public string Table2Text(string sql)
    {
        return Table2Text(sql, "\n", ",", false);
    }


    public DataTable getTable(string sql)
    {
        try
        {
            DataSet ds = new DataSet();
            this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter(sql, this.connection);
            da.Fill(ds);
            da.Dispose();
            return ds.Tables[0];
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public void runSQL(string sqlStatement)
    {
        try
        {
            this.OpenConnection();
            SqlCommand cmd = new SqlCommand(sqlStatement, this.connection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
            this.CloseConnection();
        }
    }
    public void CreateDynamicDDl(DropDownList ddl, string sSql, string StrValue, string StrDisplay, string strSelectedValue, string StrLabel)
    {
        string defValue = "";
        if (ddl.SelectedItem != null)
            defValue = ddl.SelectedItem.Value.ToString();
        this.setDDL(ref ddl, sSql, StrValue, StrDisplay, strSelectedValue, StrLabel);
    }

    public void setDDL(ref DropDownList ddl, string sql, string valueField, string textField, string value2beSelected, string defValue)//To do
    {
        DataTable dt = getTable(sql);
        ListItem item = null;

        ddl.Items.Clear();

        if (defValue != "")
        {
            item = new ListItem(defValue, "");
            ddl.Items.Add(item);
        }
        foreach (DataRow row in dt.Rows)
        {
            item = new ListItem();
            item.Value = row[valueField].ToString();
            item.Text = row[textField].ToString();

            if (row[valueField].ToString().ToUpper() == value2beSelected.ToUpper())
                item.Selected = true;
            ddl.Items.Add(item);
        }
    }
    public string DataTable2ExcelXML(ref DataTable dt, bool isFlexCubeFormat)
    {
        var date = DateTime.Now.Date.ToString("yyyy-MM-dd");
        var header = new StringBuilder("");

        header.AppendLine("<?xml version=\"1.0\"?>");
        header.AppendLine("<?mso-application progid=\"Excel.Sheet\"?>");
        header.AppendLine("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        header.AppendLine("xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
        header.AppendLine("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
        header.AppendLine("xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"");
        header.AppendLine("xmlns:html=\"http://www.w3.org/TR/REC-html40\">");
        header.AppendLine("<DocumentProperties xmlns=\"urn:schemas-microsoft-com:office:office\">");
        header.AppendLine("<Created>" + date + "</Created>");
        header.AppendLine("<LastSaved>" + date + "</LastSaved>");
        header.AppendLine("<Version>12.00</Version>");
        header.AppendLine("</DocumentProperties>");
        header.AppendLine("<OfficeDocumentSettings xmlns=\"urn:schemas-microsoft-com:office:office\">");
        header.AppendLine("<RemovePersonalInformation/>");
        header.AppendLine("</OfficeDocumentSettings>");
        header.AppendLine("<ExcelWorkbook xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        header.AppendLine("<WindowHeight>8010</WindowHeight>");
        header.AppendLine("<WindowWidth>14805</WindowWidth>");
        header.AppendLine("<WindowTopX>240</WindowTopX>");
        header.AppendLine("<WindowTopY>105</WindowTopY>");
        header.AppendLine("<ProtectStructure>False</ProtectStructure>");
        header.AppendLine("<ProtectWindows>False</ProtectWindows>");
        header.AppendLine("</ExcelWorkbook>");
        header.AppendLine("<Styles>");
        header.AppendLine("<Style ss:ID=\"Default\" ss:Name=\"Normal\">");
        header.AppendLine("<Alignment ss:Vertical=\"Bottom\"/>");
        header.AppendLine("<Borders/>");
        header.AppendLine("<Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/>");
        header.AppendLine("<Interior/>");
        header.AppendLine("<NumberFormat/>");
        header.AppendLine("<Protection/>");
        header.AppendLine("</Style>");
        header.AppendLine("<Style ss:ID=\"s16\">");
        header.AppendLine("<NumberFormat ss:Format=\"@\"/>");
        header.AppendLine("</Style>");
        header.AppendLine("<Style ss:ID=\"s63\">");
        header.AppendLine("<NumberFormat ss:Format=\"Fixed\"/>");
        header.AppendLine("</Style>");
        header.AppendLine("</Styles>");
        header.AppendLine("<Worksheet ss:Name=\"Sheet1\">");
        header.AppendLine("<Table ss:ExpandedColumnCount=\"{columns}\" ss:ExpandedRowCount=\"{rows}\" x:FullColumns=\"1\" x:FullRows=\"1\" ss:DefaultRowHeight=\"15\">");

        var footer = new StringBuilder("");
        footer.AppendLine("</Table>");
        footer.AppendLine("<WorksheetOptions xmlns=\"urn:schemas-microsoft-com:office:excel\">");
        footer.AppendLine("<PageSetup>");
        footer.AppendLine("<Header x:Margin=\"0.3\"/>");
        footer.AppendLine("<Footer x:Margin=\"0.3\"/>");
        footer.AppendLine("<PageMargins x:Bottom=\"0.75\" x:Left=\"0.7\" x:Right=\"0.7\" x:Top=\"0.75\"/>");
        footer.AppendLine("</PageSetup>");
        footer.AppendLine("<Print>");
        footer.AppendLine("<ValidPrinterInfo/>");
        footer.AppendLine("<HorizontalResolution>300</HorizontalResolution>");
        footer.AppendLine("<VerticalResolution>300</VerticalResolution>");
        footer.AppendLine("</Print>");
        footer.AppendLine("<Selected/>");
        footer.AppendLine("<Panes>");
        footer.AppendLine("<Pane>");
        footer.AppendLine("<Number>3</Number>");
        footer.AppendLine("<ActiveRow>1</ActiveRow>");
        footer.AppendLine("</Pane>");
        footer.AppendLine("</Panes>");
        footer.AppendLine("<ProtectObjects>False</ProtectObjects>");
        footer.AppendLine("<ProtectScenarios>False</ProtectScenarios>");
        footer.AppendLine("</WorksheetOptions>");
        footer.AppendLine("</Worksheet>");
        footer.AppendLine("</Workbook>");

        const string dataTemplate = "<Cell ss:StyleID=\"s16\"><Data ss:Type=\"String\">{data}</Data></Cell>";

        const string dataTemplatefloat = "<Cell ss:StyleID=\"s63\"><Data ss:Type=\"Number\">{data}</Data></Cell>";

        var body = new StringBuilder("");

        var columnCount = dt.Columns.Count;

        if (isFlexCubeFormat)
        {
            body.AppendLine("<Row>");
            body.AppendLine(dataTemplate.Replace("{data}", "DETB_UPLOAD_DETAIL"));
            body.AppendLine(dataTemplate.Replace("{data}", "~~END~~"));

            for (var i = 2; i < columnCount; i++)
            {
                body.AppendLine(dataTemplate.Replace("{data}", ""));
            }
            body.AppendLine("</Row>");
        }

        body.AppendLine("<Row>");
        for (var i = 0; i < columnCount; i++)
        {
            body.AppendLine(dataTemplate.Replace("{data}", dt.Columns[i].ColumnName));
        }
        if (isFlexCubeFormat)
        {
            body.AppendLine(dataTemplate.Replace("{data}", "~~END~~"));
        }

        body.AppendLine("</Row>");

        foreach (DataRow dr in dt.Rows)
        {
            body.AppendLine("<Row>");
            for (var i = 0; i < columnCount; i++)
            {
                if (dt.Columns[i].ColumnName == "AMOUNT" || dt.Columns[i].ColumnName == "LCYAMOUNT")

                    body.AppendLine(dataTemplatefloat.Replace("{data}", dr[i].ToString()));
                else
                    body.AppendLine(dataTemplate.Replace("{data}", dr[i].ToString()));
            }
            if (isFlexCubeFormat)
            {
                body.AppendLine(dataTemplate.Replace("{data}", "~~END~~"));
            }
            body.AppendLine("</Row>");
        }
        if (isFlexCubeFormat)
        {
            body.AppendLine("<Row>");
            for (var i = 0; i < columnCount; i++)
            {
                body.AppendLine(dataTemplate.Replace("{data}", "~~END~~"));
            }
            body.AppendLine(dataTemplate.Replace("{data}", "~~END~~"));
            body.AppendLine("</Row>");
        }

        header.AppendLine(body.ToString());
        header.AppendLine(footer.ToString());

        var ret = header.ToString().Replace("{rows}", (5 + dt.Rows.Count).ToString()).Replace("{columns}",
                                                                                     (2 + dt.Columns.Count).ToString());
        //var x = System.IO.File.CreateText("D:\\data\\abc.xml");
        //x.Write(ret);
        //x.Close();
        //x.Dispose();
        return ret;


    }

    public bool CheckStatement(string sSql)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            this.OpenConnection();
            SqlDataReader dread;
            cmd = new SqlCommand(sSql, this.connection);
            dread = cmd.ExecuteReader();
            if (dread.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public string uploadData(ref DataTable dt)
    {
        SqlConnection dbconnection = new SqlConnection(connstring);

        SqlBulkCopy sqlblkcpy = new SqlBulkCopy(dbconnection);

        dbconnection.Open();

        sqlblkcpy.DestinationTableName = "UploadTest";

        foreach (DataColumn item in dt.Columns)
        {

            sqlblkcpy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(item.ColumnName, item.ColumnName));

        }

        if (dt.Rows.Count > 0)
            sqlblkcpy.WriteToServer(dt);             


        return "Upload Success!";
    }
    public String FilterString(string strVal)
    {
        var str = FilterQuote(strVal);

        if (str.ToLower() != "null")
            str = "'" + str + "'";

        return str;
    }

    public String FilterQuote(string strVal)
    {
        var str = strVal;
        if (!string.IsNullOrEmpty(str))
        {
            str = str.Replace(";", "");
            //str = str.Replace(",", "");
            str = str.Replace("--", "");
            str = str.Replace("'", "");

            str = str.Replace("/*", "");
            str = str.Replace("*/", "");

            str = str.Replace("select", "");
            str = str.Replace("insert", "");
            str = str.Replace("update", "");
            str = str.Replace("delete", "");

            str = str.Replace("drop", "");
            str = str.Replace("truncate", "");
            str = str.Replace("create", "");

            str = str.Replace(" begin", "");
            str = str.Replace(" end", "");
            str = str.Replace("char(", "");

            str = str.Replace("exec", "");
            str = str.Replace("xp_cmd", "");


            str = str.Replace("script", "");

        }
        else
        {
            str = "null";
        }
        return str;
    }
}
