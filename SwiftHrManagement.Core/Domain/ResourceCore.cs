using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class ResourceCore : BaseDomain
    {
        private long resource_Id;

        public long Resource_Id
        {
            get { return resource_Id; }
            set { resource_Id = value; }
        }

        private long pTS_Id;

        public long PTS_Id
        {
            get { return pTS_Id; }
            set { pTS_Id = value; }
        }

        private long updated_By;

        public long Updated_By
        {
            get { return updated_By; }
            set { updated_By = value; }
        }
        private String link_To;

        private long comment_For;

        public long Comment_For
        {
            get { return comment_For; }
            set { comment_For = value; }
        }
        public String Link_To
        {
            get { return link_To; }
            set { link_To = value; }
        }
        private String flag;

        public String Flag
        {
            get { return flag; }
            set { flag = value; }
        }
        private String file_Name;

        public String File_Name
        {
            get { return file_Name; }
            set { file_Name = value; }
        }
        private String notes;

        public String Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
