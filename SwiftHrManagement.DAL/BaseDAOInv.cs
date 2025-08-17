using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SwiftHrManagement.DAL
{
    public abstract class BaseDAOInv
    {
        SqlConnection connection = null;
        private DbService service;
        public BaseDAOInv()
        {
            Init();
        }
        private void Init()
        {
            this.connection = new SqlConnection(this.GetConnectionString());
        }
        public abstract Object MapObject(DataRow dr);

        public abstract void Save(Object obj);

        public abstract void Update(Object obj);

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
        private string GetConnectionString()
        {
            return ConfigurationSettings.AppSettings["connectionString"].ToString();
        }
        public DataTable SelectByQuery(string sqlstring)
        {
            SqlDataAdapter dataAdoptor = null;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                this.OpenConnection();
                dataAdoptor = new SqlDataAdapter(sqlstring, this.connection);
                dataAdoptor.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
                dataAdoptor = null;
                ds = null;
            }

            return dt;
        }

        public void LogJobHistoryReport(string logType, string tableName, string dataId, string oldData, string newData, string user)
        {
            ExecuteQuery("Exec [proc_applicationLogs] @flag ='i' ,@log_type=" + filterstring(logType) + ",@table_name=" + filterstring(tableName) + ","
            + " @data_id=" + filterstring(dataId) + ",@old_data=" + filterstring(oldData) + ",@new_data=" + filterstring(newData) + ",@user=" + filterstring(user) + "");
        }

        //******//
        public int ExecuteQuery(string sql, char IsReturn)
        {
            return this.service.ExecuteQuery(sql, IsReturn);
        }
        public void ExecuteQuery(string sSQL)
        {
            try
            {
                this.OpenConnection();
                SqlCommand command = new SqlCommand(sSQL, this.connection);
                command.ExecuteNonQuery();
                this.CloseConnection();
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
        protected void ExecuteUpdateProcedure(String spName)
        {
            try
            {
                this.OpenConnection();
                SqlCommand command = new SqlCommand(spName, this.connection);
                command.ExecuteNonQuery();
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected DataTable ExecuteStoreProcedure(String spName)
        {
            try
            {
                this.OpenConnection();
                DataTable temp = null;
                SqlCommand cmd = new SqlCommand(spName, this.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "table1");
                temp = ds.Tables[0];
                return temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();

            }
        }
        protected DataSet ReturnDataset(String spName)
        {
            try
            {
                OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(spName, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        protected Boolean CheckStatement(String sSql)
        {
            try
            {
                this.OpenConnection();
                SqlDataReader dreader;
                SqlCommand Cmd = new SqlCommand(sSql, this.connection);
                dreader = Cmd.ExecuteReader();
                if (dreader.HasRows == true)
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
            finally
            {

                this.CloseConnection();
            }
        }
        protected String[] GetwebserviceInfo(String prefixText, String sSql)
        {
            try
            {
                this.OpenConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(sSql, connection);
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
                this.CloseConnection();
            }
        }
        public String filterstring(String strVal)
        {
            string str = strVal;
            if (str != "" && str != "0" && str != "-1")
            {
                str = str.Replace(";", "");
                str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");
                str = "'" + str + "'";
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }
        public String FilterQuote(String strVal)
        {
            string str = strVal;
            if (str != "" && str != "0" && str != "-1" && str != null)
            {
                str = str.Replace(";", "");
                str = str.Replace(",", "");
                str = str.Replace("--", "");
                str = str.Replace("'", "");
            }
            else
            {
                str = "null";
            }
            return str.ToString();
        }

        public void executeProcedure(string spName, SqlParameter[] param)
        {
            try
            {
                this.OpenConnection();
                SqlCommand command = new SqlCommand(spName, this.connection);
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
            finally
            {
                this.CloseConnection();
            }
        }
        //public string GetSingleresult(string sSql)
        //{
        //    return this.service.GetSingleresult(sSql);

        //}
        public string GetSingleresult(string sSql)
        {
            OpenConnection();
            SqlCommand cmd = new SqlCommand(sSql, this.connection);
            SqlDataReader dread;
            string result = "";
            dread = cmd.ExecuteReader();
            while (dread.Read())
            {
                result = dread[0].ToString();
            }
            return result;
        }
        public DataSet ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            SqlDataAdapter da = null;
            try
            {
                OpenConnection();
                da = new SqlDataAdapter(sql, this.connection);

                da.Fill(ds);
                da.Dispose();
                this.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                da = null;
                this.CloseConnection();
            }
            return ds;
        }
        public string GetCurrentRecordInformation(string tableName, string fieldName, string dataId)
        {
            try
            {
                this.OpenConnection();
                SqlCommand command = new SqlCommand("proc_GetColumnToRow", this.connection);
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
                this.CloseConnection();
            }
        }

    }
}
