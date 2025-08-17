using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwiftHrManagement.Core;
using SwiftHrManagement.Core.Domain;

namespace SwiftHrManagement.DAL.Project.MessageBoard
{
    public class MessageDao : BaseDAOInv
    {
        private StringBuilder insertQuery;
        private StringBuilder updateQuery;
        private StringBuilder selectQuery;
        public MessageDao()
        {
            this.insertQuery = new StringBuilder("EXEC procManagemessageBoard 'i','MSG_SUBJECT','MSG_HEAD','FORUM','CREATED_BY','REPLY_ID'");
            this.updateQuery = new StringBuilder("EXEC procManagemessageBoard 'MSG_SUBJECT', 'POSTED_BY', 'FORUM', '', '', "
            + " 'MODIFIED_BY', 'MODIFIED_DATE', U, 'MSG_ID',  'REPLY_ID'");
            this.selectQuery = new StringBuilder("SELECT M.MSG_ID, M.MSG_SUBJECT, M.FORUM,M.CREATED_DATE AS POSTED_DATE, M.REPLY ,E.name AS POSTRD_BY, M.MODIFIED_BY FROM  Message_Board AS M, Admins AS E "
                                                + " WHERE E.UserName = M.POSTED_BY");
        }
        public override void Save(object obj)
        {
            MessageCore _messageCore = (MessageCore)obj;
            this.insertQuery.Replace("MSG_SUBJECT", _messageCore.Subject.ToString());
            //this.insertQuery.Replace("POSTED_BY", _messageCore.Posted_By.ToString());
            this.insertQuery.Replace("MSG_HEAD", _messageCore.Msg_head.ToString());
            this.insertQuery.Replace("FORUM", _messageCore.Forum.ToString());
            this.insertQuery.Replace("CREATED_BY", _messageCore.CreatedBy.ToString());
            //this.insertQuery.Replace("CREATED_DATE", _messageCore.CreatedDate.ToString());
            this.insertQuery.Replace("REPLY_ID", _messageCore.Reply.ToString());
            ExecuteUpdateProcedure(this.insertQuery.ToString());
        }
        public DataSet Getforum()
        {
            String sSql = " Exec ProcMessageBoard 's'";
            return ReturnDataset(sSql);
        }
        public DataSet GetProjects(string struser)
        {
            String sSql = "exec procDisplaiProject 'a','" + struser + "'";
            return ReturnDataset(sSql);
        }
        //public DataSet GetTasks()
        //{
        //    String sSql = "select TITLE from Tasks where COMPLETED='0'";
        //    return ReturnDataset(sSql);
        //}
        public DataSet Getforum(long forumid)
        {
            String sSql = " Exec ProcMessageBoard 'm'," + forumid + "";
            return ReturnDataset(sSql);
        }
        public override void Update(object obj)
        {
            MessageCore _messageCore = (MessageCore)obj;
            this.updateQuery.Replace("MSG_ID", _messageCore.Msg_Id.ToString());
            this.updateQuery.Replace("MSG_SUBJECT", _messageCore.Subject.ToString());
            this.updateQuery.Replace("POSTED_BY", _messageCore.Posted_By.ToString());
            this.updateQuery.Replace("FORUM", _messageCore.Forum.ToString());
            this.updateQuery.Replace("MODIFIED_BY", _messageCore.ModifyBy.ToString());
            this.updateQuery.Replace("MODIFIED_DATE", _messageCore.ModifyDate.ToString());
            this.updateQuery.Replace("REPLY", _messageCore.Reply.ToString());
            ExecuteUpdateProcedure(this.updateQuery.ToString());
        }
        public override object MapObject(DataRow dr)
        {
            MessageCore _msgCore = new MessageCore();
            _msgCore.Msg_Id = long.Parse(dr["MSG_ID"].ToString());
            _msgCore.Posted_Date = dr["POSTED_DATE"].ToString();
            _msgCore.Posted_By = dr["POSTRD_BY"].ToString();
            _msgCore.Subject = dr["MSG_SUBJECT"].ToString();
            _msgCore.Forum = dr["FORUM"].ToString();
            _msgCore.Reply = dr["REPLY"].ToString();
            _msgCore.ModifyBy = dr["MODIFIED_BY"].ToString();
            return _msgCore;
        }
        public List<MessageCore> FindallByDates(String Fdate, String TDate)
        {
            string sSql = this.selectQuery.Append(" AND M.CREATED_DATE BETWEEN '" + Fdate + "' AND '" + TDate + "' ").ToString();
            DataTable dt = SelectByQuery(sSql);
            List<MessageCore> _messageCore = new List<MessageCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MessageCore _msgCore = (MessageCore)this.MapObject(dr);
                    _messageCore.Add(_msgCore);
                }
            }
            return _messageCore;
        }
        public MessageCore FindallById(long Id)
        {
            string sSql = this.selectQuery.Append(" AND M.MSG_ID=" + Id + "").ToString();
            DataTable dt = SelectByQuery(sSql);
            MessageCore _msgCore = null;
            if (dt != null)
                _msgCore = (MessageCore)this.MapObject(dt.Rows[0]);
            return _msgCore;
        }
        public List<MessageCore> Findall()
        {
            string sSql = this.selectQuery.ToString();
            DataTable dt = SelectByQuery(sSql);
            List<MessageCore> _messageCore = new List<MessageCore>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MessageCore _msgCore = (MessageCore)this.MapObject(dr);
                    _messageCore.Add(_msgCore);
                }
            }
            return _messageCore;
        }
    }
}