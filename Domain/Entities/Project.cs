using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project
    {
        public Guid ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        // Foreign Key
        public int CampaignType { get; set; }
        public int ClientID { get; set; }

        // Navigation Properties
        public CampaignType CampaignTypes { get; set; }
        public Client Client { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Interaction> Interactions { get; set; }
    }
}
