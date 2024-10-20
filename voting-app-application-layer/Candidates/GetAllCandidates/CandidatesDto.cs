using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting_app_application_layer.Candidates.GetAllCandidates
{
    public class CandidatesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int VotesCount { get; set; }
    }
}
