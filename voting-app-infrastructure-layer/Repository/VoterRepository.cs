using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Interfaces;
using voting_app_domain_layer.Models;
using voting_app_infrastructure_layer.Context;

namespace voting_app_infrastructure_layer.Repository
{
    public class VoterRepository : IVoterRepository
    {
        public VoterRepository() 
        {
            using (var context = new ApiContext())
            {
                var authors = new List<Voter>
                {
                new Voter
                {
                    Name = "tet",
                },
                new Voter
                {
                    Name = "tetsada",
                },
                };
                context.Voters.AddRange(authors);
                context.SaveChanges();
            }
        }

        public List<Voter> GetAllVoters()
        {
            using (var context = new ApiContext())
            {
                var list = context.Voters.Include(x => x.Vote).ToList();
                return list;
            }
        }
    }
}
