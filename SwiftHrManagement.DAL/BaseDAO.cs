using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.IO;

namespace SwiftHrManagement.DAL
{
    public abstract class BaseDAO
    {
        private DbService service;
        public BaseDAO()
        {
            Init();
        }
        private void Init()
        {
            this.service = new DbService();
        }
        public abstract Object MapObject(DataRow dr);

        public abstract void Save(Object obj);

        public abstract void Update(Object obj);

        public DataTable SelectByQuery(string sqlstring)
        {
            return this.service.SelectByQuery(sqlstring);
        }
        public DataSet ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            SqlDataAdapter da;

            try
            {
                this.service.OpenConnection();
                da = new SqlDataAdapter(sql, this.service.Connection);

                da.Fill(ds);
                da.Dispose();
                this.service.CloseConnection();
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da = null;
                this.service.CloseConnection();
            }
            return ds;
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
                str = str.Replace("'", "");
                str = str.Replace("+", "");
                ////str = str.Replace(",", "");
                //str = str.Replace("--", "");
                //str = str.Replace("'", "");

                //str = str.Replace("/*", "");
                //str = str.Replace("*/", "");

                //str = str.Replace("select", "");
                //str = str.Replace("insert", "");
                //str = str.Replace("update", "");
                //str = str.Replace("delete", "");

                //str = str.Replace("drop", "");
                //str = str.Replace("truncate", "");
                //str = str.Replace("create", "");

                //str = str.Replace(" begin", "");
                //str = str.Replace(" end", "");
                //str = str.Replace("char(", "");

                //str = str.Replace("exec", "");
                //str = str.Replace("xp_cmd", "");


                //str = str.Replace("script", "");

            }
            else
            {
                str = "null";
            }
            return str;
        }
        public void ExecuteQuery(string sSQL)
        {
            this.service.ExecuteQuery(sSQL);
        }

        public int ExecuteQuery(string sql, char IsReturn)
        {
            return this.service.ExecuteQuery(sql, IsReturn);
        }
        protected void ExecuteUpdateProcedure(String spName)
        {
            this.service.ExecuteUpdateProcedure(spName);
        }

        protected DataTable ExecuteStoreProcedure(String spName)
        {
            return this.service.ExecuteStoreProcedure(spName);
        }
        public string GetSingleresult(string sSql)
        {
            return this.service.GetSingleresult(sSql);

        }
        protected DataSet ReturnDataset(String spName)
        {
            return this.service.ReturnDataset(spName);
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
        protected Boolean CheckStatement(String sSql)
        {
            return this.service.CheckStatement(sSql);
        }
        protected String[] GetwebserviceInfo(String prefixText, String sSql)
        {
            try
            {
                this.service.OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(sSql, this.service.Connection);
                adapter.SelectCommand.Parameters.Add("@prefixText", SqlDbType.VarChar, 50).Value = prefixText + "%";
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                string[] items = new string[dt.Rows.Count];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    items.SetValue(dr[0].ToString(), i);
                    i++;
                }
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.service.CloseConnection();
            }
        }
        public String filterstring(String strVal)
        {
            return this.service.filterstring(strVal);
        }
        public String filterPageContent(String strVal)
        {
            string str = strVal;
            if (str != "" && str != "0" && str != "-1")
            {
                str = str.Replace(";", "");
                str = str.Replace("--", "");
                str = str.Replace("&nbsp", "");
                str = str.Replace("delete", "");
                str = str.Replace("update", "");
                str = str.Replace("drop", "");
                str = str.Replace("truncate", "");
                str = str.Replace("insert", "");
                str = str.Replace("<br>", "");
                str = str.Replace("''", "'");

            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }

        public void executeProcedure(string spName, SqlParameter[] param)
        {
            this.service.executeProcedure(spName, param);
        }
        public string GetCurrentRecordInformation(string tableName, string fieldName, string dataId)
        {
            try
            {
                this.service.OpenConnection();
                SqlCommand command = new SqlCommand("proc_GetColumnToRow", this.service.Connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@table_name", tableName);
                param[1] = new SqlParameter("@field_name", fieldName);
                param[2] = new SqlParameter("@data_id", dataId);
                param[3] = new SqlParameter("@dataList", SqlDbType.VarChar, 8000);
                param[3].Direction = ParameterDirection.Output;


                foreach (SqlParameter p in param)
                {
                    command.Parameters.Add(p);
                }
                command.ExecuteNonQuery();
                return param[3].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.service.CloseConnection();
            }
        }
        public bool CheckHrAdmin(long empid)
        {
            string sql = @"SELECT DISTINCT 'A' Mgs
                         FROM   dbo.user_role r
                                INNER JOIN dbo.StaticDataDetail s ON r.role_id = s.ROWID
                                INNER JOIN dbo.Admins a ON a.AdminID = r.user_id
                         WHERE  s.TYPE_ID = '25'
                                  AND LOWER(s.value) ='admin'
                                AND a.Name = " + empid;
            try
            {
                DataTable dt = this.SelectByQuery(sql);
                int count = dt.Rows.Count;
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }
        public String GetJobHistoryRecords(String Sql)
        {
            try
            {
                DataTable dt = this.SelectByQuery(Sql);
                string dataAll = "";
                string colName = "";
                string data = "";
                DataRow dr = dt.Rows[0];
                foreach (DataColumn col in dt.Columns)
                {
                    colName = col.ColumnName;
                    data = dr[colName].ToString();
                    if (dataAll == "")
                        dataAll = colName + " = " + data;
                    else
                        dataAll = dataAll + "," + colName + " =" + data;

                }
                return dataAll;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void LogJobHistoryReport(string logType, string tableName, string dataId, string oldData, string newData, string user)
        {
            ExecuteQuery("Exec [proc_applicationLogs] @flag ='i' ,@log_type=" + filterstring(logType) + ",@table_name=" + filterstring(tableName) + ","
            + " @data_id=" + filterstring(dataId) + ",@old_data=" + filterstring(oldData) + ",@new_data=" + filterstring(newData) + ",@user=" + filterstring(user) + "");
        }
        public long CEOID()
        {
            return 1096;
        }
    }
}
