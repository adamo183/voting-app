using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app_application_layer.Voters.GetAllVoters;

namespace voting_app_application_layer.Candidates.GetAllCandidates
{
    public class GetAllCandidatesQuery : IRequest<List<CandidatesDto>>
    {
    }
}
