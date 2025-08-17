using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TaskAssignCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private String fname;

        public String Fname
        {
            get { return fname; }
            set { fname = value; }
        }
        private String taskId;

        public String TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string assigned_by;

        public string Assigned_by
        {
            get { return assigned_by; }
            set { assigned_by = value; }
        }
        private string report_to;

        public string Report_to
        {
            get { return report_to; }
            set { report_to = value; }
        }
        private String start_date;

        public String Start_date
        {
            get { return start_date; }
            set { start_date = value; }
        }
        private String end_date;

        public String End_date
        {
            get { return end_date; }
            set { end_date = value; }
        }
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
    }
}
