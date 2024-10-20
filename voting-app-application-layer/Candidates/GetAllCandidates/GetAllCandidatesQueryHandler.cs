using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_application_layer.Voters.GetAllVoters;
using voting_app_domain_layer.Interfaces;

namespace voting_app_application_layer.Candidates.GetAllCandidates
{
    public class GetAllCandidatesQueryHandler : IRequestHandler<GetAllCandidatesQuery, List<CandidatesDto>>
    {
        private readonly ICandidateRepository _candidateRepository;
        public GetAllCandidatesQueryHandler(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<List<CandidatesDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var t = await _candidateRepository.GetAllCandidates();
            return t.Select(x => new CandidatesDto() { Id = x.Id, Name = x.Name,  VotesCount = x.Voters.Count() }).ToList();
        }
    }
}
