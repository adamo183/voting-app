using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voting_app_application_layer.Candidates.InsertCandidate
{
    public class InsertNewCandidateCommand : IRequest
    {
        public InsertCandidateModel Model { get; set; }
        public InsertNewCandidateCommand(InsertCandidateModel model)
        {
            Model = model;
        }
    }
}
