using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TrainingListCore : BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private string trainingName;

        public string TrainingName
        {
            get { return trainingName; }
            set { trainingName = value; }
        }

        private string designedFor;

        public string DesignedFor
        {
            get { return designedFor; }
            set { designedFor = value; }
        }
        private string courseContents;

        public string CourseContents
        {
            get { return courseContents; }
            set { courseContents = value; }
        }


    }
}
