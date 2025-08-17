using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;
using SwiftHrManagement.DAL.Report;
using DbResult = SwiftHrManagement.DAL.DbResult;

namespace SwiftHrManagement.web.DAL
{
    public class SwiftDao
    {
        private string GetConnectionString()
        {
            return ConfigurationSettings.AppSettings["connectionString"].ToString();
        }

        public DataSet ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            SqlDataAdapter da;


            using (SqlConnection _connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    _connection.Open();
                    da = new SqlDataAdapter(sql, _connection);
                    da.Fill(ds);
                    da.Dispose();
                }

                catch (Exception ex)
                {
                    throw ex;
                }

                finally
                {
                    da = null;
                }
            }

            return ds;
        }

        public DataTable ExecuteDataTable(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                return ds.Tables[0];
            }
        }

        public DataRow ExecuteDataRow(string sql)
        {
            using (var ds = ExecuteDataset(sql))
            {
                if (ds == null || ds.Tables.Count == 0)
                    return null;

                if (ds.Tables[0].Rows.Count == 0)
                    return null;

                return ds.Tables[0].Rows[0];
            }
        }

        public String GetSingleResult(string sql)
        {
            try
            {
                var ds = ExecuteDataset(sql);
                if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                    return "";

                return ds.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RemoveDecimal(double amt)
        {
            return Math.Floor(amt).ToString();
        }

        public String FilterString(string strVal)
        {
            var str = FilterQuote(strVal);

            if (str.ToLower() != "null")
                str = "'" + str + "'";

            return str.TrimEnd().TrimStart();
        }

        public String FilterQuote(string strVal)
        {
            if (string.IsNullOrEmpty(strVal))
            {
                strVal = "";
            }
            var str = strVal.Trim();

            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace(";", "");
                //str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");

                str = str.Replace("/*", "");
                str = str.Replace("*/", "");

                str = str.Replace(" select ", "");
                str = str.Replace(" insert ", "");
                str = str.Replace(" update ", "");
                str = str.Replace(" delete ", "");

                str = str.Replace(" drop ", "");
                str = str.Replace(" truncate ", "");
                str = str.Replace(" create ", "");

                str = str.Replace(" begin ", "");
                str = str.Replace(" end ", "");
                str = str.Replace(" char(", "");

                str = str.Replace(" exec ", "");
                str = str.Replace(" xp_cmd ", "");


                str = str.Replace("<script", "");

            }
            else
            {
                str = "null";
            }
            return str;
        }

        public string SingleQuoteToDoubleQuote(string strVal)
        {
            strVal = strVal.Replace("\"", "");
            return strVal.Replace("'", "\"");
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

        public DbResult ParseDbResult(string sql)
        {
            return ParseDbResult(ExecuteDataset(sql).Tables[0]);
        }

        public ReportResult ParseReportResult(string sql)
        {
            return ParseReportResult(ExecuteDataset(sql));
        }

        public ReportResult ParseReportResult(DataSet ds)
        {
            var res = new ReportResult();

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

        public DataTable GetTable2(string sql)
        {
            return ExecuteDataset(sql).Tables[1];
        }

        protected string ReadFileContent(string fileName)
        {
            return ReadFileContent(fileName, false);
        }

        protected string ReadFileContent(string fileName, bool ignoreFirstLine)
        {
            var contents = "";
            using (var streamReader = new StreamReader(fileName))
            {
                if (streamReader.EndOfStream)
                    return "";
                if (ignoreFirstLine)
                {
                    streamReader.ReadLine();
                    if (streamReader.EndOfStream)
                        return "";
                }
                contents = streamReader.ReadToEnd();
            }

            return contents;
        }

        protected string ParseData(string data)
        {
            return data.Replace("\"", "").Replace("'", "").Trim();
        }

        public string AutoSelect(string str1, string str2)
        {
            if (str1.ToLower() == str2.ToLower())
                return "selected=\"selected\"";

            return "";
        }

        protected string ParseDate(string data)
        {
            data = FilterString(data);
            if (data.ToUpper() == "NULL")
                return data;
            data = data.Replace("'", "");
            var dateParts = data.Split('/');
            if (dateParts.Length < 3)
                return "NULL";
            var m = dateParts[0];
            var d = dateParts[1];
            var y = dateParts[2];

            return "'" + y + "-" + (m.Length == 1 ? "0" + m : m) + "-" + (d.Length == 1 ? "0" + d : d) + "'";

        }
        public DataTable getTable(string sql)
        {
            return ExecuteDataTable(sql);
        }

        public void ExecuteProcedure(string spName, SqlParameter[] param)
        {

            using (SqlConnection _connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    _connection.Open();
                    SqlCommand command = new SqlCommand(spName, _connection);
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (SqlParameter p in param)
                    {
                        command.Parameters.Add(p);
                    }
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string UploadCsvFile(ref DataTable dt, string sql, string TblName)
        {
            using (SqlConnection _connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    using (SqlBulkCopy sqlblkcpy = new SqlBulkCopy(_connection))
                    {
                        _connection.Open();

                        sqlblkcpy.DestinationTableName = TblName;

                        foreach (DataColumn item in dt.Columns)
                        {
                            sqlblkcpy.ColumnMappings.Add(new SqlBulkCopyColumnMapping(item.ColumnName, item.ColumnName));
                        }

                        if (dt.Rows.Count > 0)
                            sqlblkcpy.WriteToServer(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return GetSingleResult(sql);
        }

        private SqlDataReader ExecuteDataReader(string sql)
        {
            using (SqlConnection _connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sql, _connection);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    return reader;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public DataTable ExecuteDataReaderAsDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection _connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, _connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var colName = reader.GetName(i);
                                dt.Columns.Add(colName);
                            }

                            while (reader.Read())
                            {
                                var row = dt.NewRow();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    var colName = reader.GetName(i);
                                    row[colName] = reader[colName];
                                }

                                dt.Rows.Add(row);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;
        }

        public DbResult TryParseSQL(string sql)
        {
            var dr = new DbResult();
            using (SqlConnection _connection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    _connection.Open();
                    using (SqlCommand _cmd = new SqlCommand())
                    {
                        _cmd.Connection = _connection;
                        _cmd.CommandType = CommandType.Text;
                        _cmd.CommandText = "SET NOEXEC ON " + sql + " SET NOEXEC OFF"; ;
                        _cmd.ExecuteNonQuery();
                        dr.ErrorCode = "0";
                        dr.Msg = "Success";
                    }

                    return dr;
                }
                catch (Exception ex)
                {
                    dr.ErrorCode = "1";
                    dr.Msg = FilterQuote(ex.Message);
                    return dr;
                }
            }

        }
        public string DataTableToText(ref DataTable dt, string delemeter, Boolean includeColHeader)
        {
            var sb = new StringBuilder();
            var del = "";
            var rowcnt = 0;
            if (includeColHeader)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append(del);
                    sb.Append(col.ColumnName);
                    del = delemeter;
                }
                rowcnt++;
            }

            foreach (DataRow row in dt.Rows)
            {
                if (rowcnt > 0)
                {
                    sb.AppendLine();
                }
                del = "";
                foreach (DataColumn col in dt.Columns)
                {
                    sb.Append(del);
                    sb.Append((row[col.ColumnName].ToString().Replace(",", "")));
                    del = delemeter;
                }
                rowcnt++;
            }
            return sb.ToString();
        }
        public string DataTableToText(ref DataTable dt, string delemeter)
        {
            return DataTableToText(ref dt, delemeter, true);
        }

    }
}
