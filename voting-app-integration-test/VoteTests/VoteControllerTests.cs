using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voting_app.Controllers;
using voting_app_application_layer.Candidates.GetAllCandidates;
using voting_app_application_layer.Vote.VoteForCandidate;
using voting_app_domain_layer.Interfaces;
using voting_app_domain_layer.Models;
using voting_app_infrastructure_layer.Context;
using voting_app_infrastructure_layer.Repository;

namespace voting_app_integration_test.VoteTests
{
    public class VoteControllerTests
    {
        private readonly IServiceProvider _serviceProvider;

        public VoteControllerTests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase($"VoteTestDb{DateTime.Now.ToLongTimeString()}"));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllCandidatesQueryHandler).Assembly));
            services.AddScoped<IVoterRepository, VoterRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task AddVoteShouldUpdateVoterCandidateIdWhenVoterExists()
        {
            var dbContext = _serviceProvider.GetRequiredService<ApiContext>();
            dbContext.Voters.RemoveRange(dbContext.Voters);
            dbContext.Candidates.RemoveRange(dbContext.Candidates);
            await dbContext.SaveChangesAsync();

            var voter = new Voter { Id = 1, CandidateId = null, Name = "voter11" };
            var cand1 = new Candidate { Id = 1, Name = "cand11" };
            var cand2 = new Candidate { Id = 2, Name = "cand12" };
            dbContext.Voters.Add(voter);
            dbContext.Candidates.Add(cand1);
            dbContext.Candidates.Add(cand2);
            await dbContext.SaveChangesAsync();

            var mediator = _serviceProvider.GetRequiredService<IMediator>();
            var controller = new VoteController(mediator);

            var voterModel = new AddVoteDto { VoterId = 1, CandidateId = 2 };
            var result = await controller.AddVote(voterModel);

            Assert.IsType<OkResult>(result);

            var updatedVoter = await dbContext.Voters.FindAsync(1);
            Assert.Equal(2, updatedVoter.CandidateId);
        }

        [Fact]
        public async Task AddVoteShouldNotUpdateVoterWhenVoterDoesNotExist()
        {
            var dbContext = _serviceProvider.GetRequiredService<ApiContext>();
            dbContext.Voters.RemoveRange(dbContext.Voters);
            dbContext.Candidates.RemoveRange(dbContext.Candidates);
            await dbContext.SaveChangesAsync();

            var mediator = _serviceProvider.GetRequiredService<IMediator>();
            var controller = new VoteController(mediator);

            var voterModel = new AddVoteDto { VoterId = 99, CandidateId = 2 };

            var result = await controller.AddVote(voterModel);
            Assert.IsType<OkResult>(result);


            var voter = await dbContext.Voters.FindAsync(99);
            Assert.Null(voter);
        }
    }
}
