using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Models;

namespace voting_app_domain_layer.Interfaces
{
    public interface IVoterRepository
    {
        public Task<List<Voter>> GetAllVoters();
        public Task<Voter> GetVoterById(int id);
        public Task InsertNewVoter(Voter voterToInsert);
        public Task UpdateVoter(Voter voterToInsert);
    }
}
