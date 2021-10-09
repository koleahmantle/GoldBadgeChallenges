using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims.Repo
{
    public class Claim
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string IncidentDate { get; set; }
        public string ClaimDate { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }
        public Claim(int id, string type, string description, double amount, string incidentDate, string claimDate, bool isValid)
        {
            Id = id;
            Type = type;
            Description = description;
            Amount = amount;
            IncidentDate = incidentDate;
            ClaimDate = claimDate;
            IsValid = isValid;
        }
    }
}
