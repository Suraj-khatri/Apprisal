using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using SwiftHrManagement.DAL;

namespace SwiftHrManagement.DAL.ApplicationLogs
{
   public class ApplicationLogsDao:BaseDAOInv
    {
        public DataTable PopulateAppLogById(string logId)
        {
            var sql = "exec [proc_applicationLogs] 'a', @rowId=" + logId + "";
            return ReturnDataset(sql).Tables[0];
        }

        public DataTable GetAuditDataForFunction(string old_data, string new_data)
        {
            var sql = "exec [proc_applicationLogs] 'auditFunction' ";
            sql += ", @old_data='" + old_data + "'";
            sql += ", @new_data='" + new_data + "'";
            return ReturnDataset(sql).Tables[0];
        }
        public DataTable GetAuditDataForRule(string old_data, string new_data)
        {
            var sql = "exec [proc_applicationLogs] 'auditRole' ";
            sql += ", @old_data='" + old_data + "'";
            sql += ", @new_data='" + new_data + "'";
            return ReturnDataset(sql).Tables[0];
        }
        public DataTable GetHistoryChangedList(string logType, string oldData, string newData)
        {
            string[] stringSeparators = new string[] { "-:::-" };

            var oldDataList = oldData.Split(stringSeparators, StringSplitOptions.None);
            var newDataList = newData.Split(stringSeparators, StringSplitOptions.None);


            var dt = new DataTable();
            var col1 = new DataColumn("Field");
            var col2 = new DataColumn("Old Value");
            var col3 = new DataColumn("New Value");
            var col4 = new DataColumn("hasChanged");

            dt.Columns.Add(col1);
            dt.Columns.Add(col2);
            dt.Columns.Add(col3);
            dt.Columns.Add(col4);

            var colCount = newData == "" ? oldDataList.Length : newDataList.Length;

            for (var i = 0; i < colCount; i++)
            {
                var changeList = ParseChangesToArray(logType, (oldData == "") ? "" : oldDataList[i], (newData == "") ? "" : newDataList[i]);

                var row = dt.NewRow();
                row[col1] = changeList[0];
                row[col2] = changeList[1];
                row[col3] = changeList[2];

                if (changeList[1] == changeList[2])
                {
                    row[col4] = "N";
                }
                else
                {
                    row[col4] = "Y";
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static string[] ParseChangesToArray(string logType, string oldData, string newData)
        {
            const string seperator = "=";
            var oldValue = "";
            var newValue = "";
            var field = "";

            if (logType.ToLower() == "insert" || logType.ToLower() == "update")
            {
                var seperatorPos = newData.IndexOf(seperator);
                if (seperatorPos > -1)
                {
                    field = newData.Substring(0, seperatorPos - 1).Trim();
                    newValue = newData.Substring(seperatorPos + 1).Trim();
                }
            }

            if (logType.ToLower() == "delete" || logType.ToLower() == "update")
            {
                var seperatorPos = oldData.IndexOf(seperator);
                if (seperatorPos > -1)
                {
                    if (field == "")
                        field = oldData.Substring(0, seperatorPos - 1).Trim();

                    oldValue = oldData.Substring(seperatorPos + 1).Trim();
                }
            }
            return new[] { field, oldValue, newValue };

        }


        public override object MapObject(System.Data.DataRow dr)
        {
            throw new NotImplementedException();
        }

        public override void Save(object obj)
        {
            throw new NotImplementedException();
        }

        public override void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
