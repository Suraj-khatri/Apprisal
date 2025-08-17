using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class TrainingProgramCore:BaseDomain
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private long branchId;

        public long BranchID
        {
            get { return branchId; }
            set { branchId = value; }
        }

        private string trainingId;

        public string TrainingId
        {
            get { return trainingId; }
            set { trainingId = value; }
        }
        private string trainingProgramTitle;

        public string TrainingProgramTitle
        {
            get { return trainingProgramTitle; }
            set { trainingProgramTitle = value; }
        }
        private string plannedStartDate;

        public string PlannedStartDate
        {
            get { return plannedStartDate; }
            set { plannedStartDate = value; }
        }
        private string actualStartDate;

        public string ActualStartDate
        {
            get { return actualStartDate; }
            set { actualStartDate = value; }
        }
        private string plannedEndDate;

        public string PlannedEndDate
        {
            get { return plannedEndDate; }
            set { plannedEndDate = value; }
        }
        private string actualEndDate;

        public string ActualEndDate
        {
            get { return actualEndDate; }
            set { actualEndDate = value; }
        }
        private string maximumCapacity;

        public string MaximumCapacity
        {
            get { return maximumCapacity; }
            set { maximumCapacity = value; }
        }
        private string venue;

        public string Venue
        {
            get { return venue; }
            set { venue = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private string numberOfDays;

        public string NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
        }
        private string totalHours;

        public string TotalHours
        {
            get { return totalHours; }
            set { totalHours = value; }
        }
        private string hoursEachDay;

        public string HoursEachDay
        {
            get { return hoursEachDay; }
            set { hoursEachDay = value; }
        }
        private string detailedCourseContents;

        public string DetailedCourseContents
        {
            get { return detailedCourseContents; }
            set { detailedCourseContents = value; }
        }
        private bool isAcive;

        public bool IsActive
        {
            get { return isAcive; }
            set { isAcive = value; }
        }
        private string usedCapacity;

        public string UsedCapacity
        {
            get { return usedCapacity; }
            set { usedCapacity = value; }
        }


    }
}
