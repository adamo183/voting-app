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
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApiContext _context;

        public CandidateRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Candidate>> GetAllCandidates()
        {

            return await _context.Candidates.Include(x => x.Voters).ToListAsync();

        }

        public async Task InsertNewCandidate(Candidate candicateToInsert)
        {
            _context.Candidates.Add(candicateToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCandidate(Candidate candidateToInsert)
        {
            _context.Candidates.Update(candidateToInsert);
            await _context.SaveChangesAsync();
        }
    }
}
