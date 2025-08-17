using System.Data;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Text;
using System.Web.UI.WebControls;
using SwiftHrManagement.Core;


public class ClsDAOInv : BaseDomain
{
    SqlConnection connection = null;
    string connstring = ConfigurationSettings.AppSettings["connectionString"].ToString();
    public ClsDAOInv()
    {
        this.connection = new SqlConnection(connstring);
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

    public DataSet getList(int appraisalId)
    {
        try
        {
            DataSet ds = new DataSet();
            this.OpenConnection();
            SqlDataAdapter da = new SqlDataAdapter("exec proc_ListPerformance_Appraisal " + appraisalId.ToString(), this.connection);
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
    public string GetSingleresult(string sSql)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader dread;
            string result = "";
            this.OpenConnection();
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
            this.CloseConnection();
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
        catch (SqlException sqlException)
        {
            throw sqlException;
        }
        finally
        {
            this.CloseConnection();
        }
    }
    public int ExecuteQuery(string sql)
    {
        try
        {
            this.OpenConnection();
            SqlCommand command = new SqlCommand(sql, this.connection);
            int RowId = Convert.ToInt32(command.ExecuteScalar());
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
    public void CreateDynamicDDl(DropDownList ddl, string sSql, string StrValue, string StrDisplay, string strSelectedValue, string StrLabel)
    {
        string defValue = "";
        if (ddl.SelectedItem != null)
            defValue = ddl.SelectedItem.Value.ToString();
        this.setDDL(ref ddl, sSql, StrValue, StrDisplay, strSelectedValue, StrLabel);
    }
    public void setDDL(ref DropDownList ddl, string sql, string valueField, string textField, string value2beSelected, string defValue)
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
    public bool CheckStatement(string sSql)
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

    public String filterstring(String strVal)
    {
        if (strVal == null)
            return "null";

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
            command.Dispose(); ;
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

    public void LogJobHistoryReport(string logType, string tableName, string dataId, string oldData, string newData, string user)
    {
        ExecuteQuery("Exec [proc_applicationLogs] @flag ='i' ,@log_type=" + filterstring(logType) + ",@table_name=" + filterstring(tableName) + ","
        + " @data_id=" + filterstring(dataId) + ",@old_data=" + filterstring(oldData) + ",@new_data=" + filterstring(newData) + ",@user=" + filterstring(user) + "");
    }

    public string CRUDLog(string tableName, string rowIdName, string Id)
    {

        return GetCurrentRecordInformation(tableName, rowIdName, Id);
    }
    public DataTable GetStringToTable(string data)
    {
        var stringSeparators = new[] { "-:::-" };

        var dataList = data.Split(stringSeparators, StringSplitOptions.None);


        var dt = new DataTable();
        var col1 = new DataColumn("Field Name");
        var col2 = new DataColumn("Values");
        var col3 = new DataColumn("field3");

        dt.Columns.Add(col1);
        dt.Columns.Add(col2);
        dt.Columns.Add(col3);

        var colCount = dataList.Length;

        for (var i = 0; i < colCount; i++)
        {
            var changeList = dataList[i].ToString().Split('=');
            var changeListCout = changeList.Length;
            var value1 = changeListCout > 0 ? changeList[0].Trim() : "";
            var value2 = changeListCout > 1 ? changeList[1].Trim() : "";
            var value3 = changeListCout > 2 ? changeList[2].Trim() : "";

            var row = dt.NewRow();
            row[col1] = value1;
            row[col2] = value2;
            row[col3] = value3;

            dt.Rows.Add(row);
        }
        return dt;
    }
}
