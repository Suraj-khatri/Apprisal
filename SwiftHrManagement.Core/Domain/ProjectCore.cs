using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
   public class ProjectCore : BaseDomain
    {
        private long project_id;

        public long Project_id
        {
            get { return project_id; }
            set { project_id = value; }
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
        private String owner;

        public String Owner
        {
            get { return owner; }
            set { owner = value; }
        }
        private String prj_manager;

        public String Prj_manager
        {
            get { return prj_manager; }
            set { prj_manager = value; }
        }
        private string completed;

        public string Completed
        {
            get { return completed; }
            set { completed = value; }
        }
        private String task_Id;

        public String Task_Id
        {
            get { return task_Id; }
            set { task_Id = value; }
        }
        private String task_Title;

        public String Task_Title
        {
            get { return task_Title; }
            set { task_Title = value; }
        }
    }
}
