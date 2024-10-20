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
        private readonly ApiContext _context;

        public VoterRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<List<Voter>> GetAllVoters()
        {
            return await _context.Voters.Include(x => x.Candidate).ToListAsync();
        }

        public async Task InsertNewVoter(Voter voterToInsert)
        {
            _context.Voters.Add(voterToInsert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVoter(Voter voterToUpdate)
        {
            _context.Voters.Update(voterToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task<Voter> GetVoterById(int id)
        {
            return await _context.Voters.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
