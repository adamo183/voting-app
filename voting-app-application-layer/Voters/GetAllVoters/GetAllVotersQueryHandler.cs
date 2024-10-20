using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_domain_layer.Interfaces;

namespace voting_app_application_layer.Voters.GetAllVoters
{
    public class GetAllVotersQueryHandler : IRequestHandler<GetAllVotersQuery, List<VoterDto>>
    {
        private readonly IVoterRepository _voterRepository;
        public GetAllVotersQueryHandler(IVoterRepository voterRepository) 
        {
            _voterRepository = voterRepository;
        }

        public async Task<List<VoterDto>> Handle(GetAllVotersQuery request, CancellationToken cancellationToken)
        {
            var t = await _voterRepository.GetAllVoters();
            return t.Select(x => new VoterDto() { Id = x.Id, Name = x.Name, HasVoted = x.CandidateId != null }).ToList();
        }
    }
}
