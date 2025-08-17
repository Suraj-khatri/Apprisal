using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class SubTaskCore : BaseDomain
    {
        private long subTask_Id;

        public long SubTask_Id
        {
            get { return subTask_Id; }
            set { subTask_Id = value; }
        }

        private long task_Id;

        public long Task_Id
        {
            get { return task_Id; }
            set { task_Id = value; }
        }
        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        private String start_Date;

        public String Start_Date
        {
            get { return start_Date; }
            set { start_Date = value; }
        }
        private String end_Date;

        public String End_Date
        {
            get { return end_Date; }
            set { end_Date = value; }
        }
        private String assigned_Date;

        public String Assigned_Date
        {
            get { return assigned_Date; }
            set { assigned_Date = value; }
        }
        private long assigned_By;

        public long Assigned_By
        {
            get { return assigned_By; }
            set { assigned_By = value; }
        }
        private long assigned_To;

        public long Assigned_To
        {
            get { return assigned_To; }
            set { assigned_To = value; }
        }
        private String status_Description;

        public String Status_Description
        {
            get { return status_Description; }
            set { status_Description = value; }
        }
    }
}
