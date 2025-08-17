using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TaskCore : BaseDomain
    {
        private String project_id;

        public String Project_id
        {
            get { return project_id; }
            set { project_id = value; }
        }

        private long task_id;

        public long Task_id
        {
            get { return task_id; }
            set { task_id = value; }
        }
        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
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
        private String category;

        public String Category
        {
            get { return category; }
            set { category = value; }
        }
        private String priority;

        public String Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        private String report_to;

        public String Report_to
        {
            get { return report_to; }
            set { report_to = value; }
        }
        private String assigned_by;

        public String Assigned_by
        {
            get { return assigned_by; }
            set { assigned_by = value; }
        }
        private String assigned_to;

        public String Assigned_to
        {
            get { return assigned_to; }
            set { assigned_to = value; }
        }
        private Boolean completed;

        public Boolean Completed
        {
            get { return completed; }
            set { completed = value; }
        }
        private Boolean is_Assigned;

        public Boolean Is_Assigned
        {
            get { return is_Assigned; }
            set { is_Assigned = value; }
        }
    }
}
