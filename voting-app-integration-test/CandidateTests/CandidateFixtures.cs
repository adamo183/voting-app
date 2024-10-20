using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Models;

namespace voting_app_integration_test.CandidateTests
{
    public static class CandidateFixtures
    {
        public static List<Candidate> DefaultCandidates = new List<Candidate>()
        {
            new Candidate() { Name = "Cand1" },
            new Candidate() { Name = "Cand2" },
            new Candidate() { Name = "Cand3" },
            new Candidate() { Name = "Cand4" },
            new Candidate() { Name = "Cand5" }
        };
    }
}
