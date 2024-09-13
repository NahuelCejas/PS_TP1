using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Entities
{
    public class Job
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        // Foreign Keys
        public Guid ProjectID { get; set; }
        public int AssignedTo { get; set; }
        public int Status { get; set; }

        // Navigation Properties
        public Project Project { get; set; }
        public User User { get; set; }
        public JobStatus JobStatus { get; set; }
    }
}
            