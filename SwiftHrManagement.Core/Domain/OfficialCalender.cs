using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwiftHrManagement.Core.Domain
{
    public class OfficialCalender : BaseDomain
    {
        private long id;      
        private String branchId;    
        private String title;    
        private String date;       
        private String nature;     
        private String description;     
        private string type;    
        private String venue;     
        private string remarks;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Nature
        {
            get { return nature; }
            set { nature = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Venue
        {
            get { return venue; }
            set { venue = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
    }
}
