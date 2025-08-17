using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SwiftHrManagement.DAL
{
    public class DbService
    {
        SqlConnection connection = null;

        public SqlConnection Connection
        {
            get { return connection; }

        }
        public DbService()
        {
            Init();
        }
        private void Init()
        {
            this.connection = new SqlConnection(this.GetConnectionString());
        }
        public void OpenConnection()
        {
            if (this.connection.State == ConnectionState.Open)
                this.connection.Close();
            this.connection.Open();
        }
        public void CloseConnection()
        {
            if (this.connection.State == ConnectionState.Open)
                this.connection.Close();
        }
        private string GetConnectionString()
        {
            return ConfigurationSettings.AppSettings["connectionString"].ToString();
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

        public DataTable SelectByQuery(string sqlstring)
        {
            SqlDataAdapter dataAdoptor = null;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                this.OpenConnection();
                dataAdoptor = new SqlDataAdapter(sqlstring, this.connection);
                dataAdoptor.Fill(ds);    //this will return a table wita a name specified by itself
                dt = ds.Tables[0]; //this will return the first table
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

        public void ExecuteQuery(string sSQL)
        {
            SqlTransaction transaction = null;
            try
            {
                this.OpenConnection();
                transaction = this.connection.BeginTransaction();
                SqlCommand command = new SqlCommand(sSQL, this.connection, transaction);
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException sqlException)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw sqlException;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public int ExecuteQuery(string sql, char IsReturn)
        {
            try
            {
                this.OpenConnection();
                SqlCommand command = new SqlCommand(sql, this.connection);
                int RowId = Convert.ToInt32(command.ExecuteScalar());
                //   command.ExecuteNonQuery();

                this.CloseConnection();
                return RowId;
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

        public void ExecuteUpdateProcedure(String spName)
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

        public DataTable ExecuteStoreProcedure(String spName)
        {
            try
            {
                this.OpenConnection();
                DataTable temp = null;
                SqlCommand cmd = new SqlCommand(spName, this.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "table1");  //return a table with a name table1
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

        public DataSet ReturnDataset(String spName)
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
        public DataSet ExecuteDataset(string sql)
        {
            var ds = new DataSet();
            SqlDataAdapter da = null;
            try
            {
                OpenConnection();
                da = new SqlDataAdapter(sql, connection);

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
        public Boolean CheckStatement(String sSql)
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




    }
}
