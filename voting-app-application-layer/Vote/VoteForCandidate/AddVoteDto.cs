using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting_app_application_layer.Vote.VoteForCandidate
{
    public class AddVoteDto
    {
        public int CandidateId { get; set; }
        public int VoterId { get; set; }
    }
}
