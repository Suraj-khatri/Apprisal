using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class MessageCore : BaseDomain
    {
        private long msg_Id;

        public long Msg_Id
        {
            get { return msg_Id; }
            set { msg_Id = value; }
        }
        private String subject;

        public String Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        private String posted_By;

        public String Posted_By
        {
            get { return posted_By; }
            set { posted_By = value; }
        }
        private String forum;

        public String Forum
        {
            get { return forum; }
            set { forum = value; }
        }
        private String posted_Date;

        public String Posted_Date
        {
            get { return posted_Date; }
            set { posted_Date = value; }
        }
        private String reply;

        public String Reply
        {
            get { return reply; }
            set { reply = value; }
        }
        private string msg_head;

        public string Msg_head
        {
            get { return msg_head; }
            set { msg_head = value; }
        }
    }
}
