using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Models;

namespace voting_app_integration_test.VotersTests
{
    public static class VotersFixtures
    {
        public static List<Voter> DefaultVoters = new List<Voter>()
        {
            new Voter() { Name = "Voter1" },
            new Voter() { Name = "Voter2" },
            new Voter() { Name = "Voter3" },
            new Voter() { Name = "Voter4" },
            new Voter() { Name = "Voter5" }
        };
    }
}
