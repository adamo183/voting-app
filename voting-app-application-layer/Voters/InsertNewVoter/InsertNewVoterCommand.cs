using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace voting_app_application_layer.Voters.InsertNewVoter
{
    public class InsertNewVoterCommand : IRequest
    {
        public InsertNewVoterModel Model { get; set; }

        public InsertNewVoterCommand(InsertNewVoterModel model)
        {
            Model = model;
        }
    }
}
