using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting_app_domain_layer.Models
{
    public class Voter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Candidate Candidate {  get; set; }
        public int CandidateId { get; set; }
    }
}
