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
using voting_app_application_layer.Candidates.InsertCandidate;
using voting_app_application_layer.Voters.GetAllVoters;
using voting_app_application_layer.Voters.InsertNewVoter;
using voting_app_domain_layer.Interfaces;
using voting_app_infrastructure_layer.Context;
using voting_app_infrastructure_layer.Repository;
using voting_app_integration_test.CandidateTests;

namespace voting_app_integration_test.VotersTests
{
    public class VotersControllerTests
    {
        private readonly IServiceProvider _serviceProvider;

        public VotersControllerTests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase($"VotersTestDb{DateTime.Now.ToLongTimeString()}"));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllCandidatesQueryHandler).Assembly));
            services.AddScoped<IVoterRepository, VoterRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task CheckIfGetAllVotersControllerReturnAll()
        {
            var dbContext = _serviceProvider.GetRequiredService<ApiContext>();
            dbContext.Voters.RemoveRange(dbContext.Voters);
            await dbContext.SaveChangesAsync();

            dbContext.Voters.AddRange(VotersFixtures.DefaultVoters);

            await dbContext.SaveChangesAsync();
            var mediator = _serviceProvider.GetRequiredService<IMediator>();

            var controller = new VotersController(mediator);
            var result = await controller.GetAllVoters();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedVoters = Assert.IsAssignableFrom<List<VoterDto>>(okResult.Value);
            Assert.Equal(VotersFixtures.DefaultVoters.Count(), returnedVoters.Count());
        }

        [Fact]
        public async Task CheckIfAddVoterControllerCorrectAddModel()
        {
            var voterToAdd = new InsertNewVoterModel()
            {
                Name = "NewVoter"
            };

            var dbContext = _serviceProvider.GetRequiredService<ApiContext>();
            dbContext.Voters.RemoveRange(dbContext.Voters);
            await dbContext.SaveChangesAsync();

            var mediator = _serviceProvider.GetRequiredService<IMediator>();
            var controller = new VotersController(mediator);

            var result = await controller.InsertNewVoter(voterToAdd);
            Assert.IsType<CreatedResult>(result);
            Assert.Equal(1, dbContext.Voters.Count());
            var element = dbContext.Voters.FirstOrDefault();
            Assert.NotNull(element);
            Assert.Equal(element.Name, voterToAdd.Name);
        }
    }
}
