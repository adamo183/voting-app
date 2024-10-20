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
        public List<Voter> GetAllVoters();
    }
}
