using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Models;

namespace voting_app_domain_layer.Interfaces
{
    public interface ICandidateRepository
    {
        public Task<List<Candidate>> GetAllCandidates();
        public Task InsertNewCandidate(Candidate voterToInsert);
        public Task UpdateCandidate(Candidate voterToInsert);
    }
}
