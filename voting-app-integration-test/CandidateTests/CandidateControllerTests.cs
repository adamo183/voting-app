using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using voting_app_application_layer.Vote.VoteForCandidate;
using voting_app.Controllers;
using voting_app_domain_layer.Models;
using voting_app_infrastructure_layer.Context;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Routing.Matching;
using voting_app_application_layer.Candidates.GetAllCandidates;
using voting_app_domain_layer.Interfaces;
using voting_app_infrastructure_layer.Repository;
using Microsoft.AspNetCore.Mvc;
using voting_app_application_layer.Candidates.InsertCandidate;

namespace voting_app_integration_test.CandidateTests
{
    public class CandidateControllerTests
    {
        private readonly IServiceProvider _serviceProvider;

        public CandidateControllerTests()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase($"CandidateTestDb{DateTime.Now.ToShortDateString()}"));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllCandidatesQueryHandler).Assembly));
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task CheckIfGetAllCandidateControllerReturnAll()
        {
            var dbContext = _serviceProvider.GetRequiredService<ApiContext>();
            dbContext.Candidates.RemoveRange(dbContext.Candidates);
            await dbContext.SaveChangesAsync();

            dbContext.Candidates.AddRange(CandidateFixtures.DefaultCandidates);

            await dbContext.SaveChangesAsync();
            var mediator = _serviceProvider.GetRequiredService<IMediator>();

            var controller = new CandidateController(mediator);
            var result = await controller.GetAllCandidates();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedCandidates = Assert.IsAssignableFrom<List<CandidatesDto>>(okResult.Value);
            Assert.Equal(CandidateFixtures.DefaultCandidates.Count(), returnedCandidates.Count());
        }

        [Fact]
        public async Task CheckIfAddCAndidateControllerCorrectAddModel()
        {
            var candidateToAdd = new InsertCandidateModel()
            {
                Name = "NewCandidate"
            };

            var dbContext = _serviceProvider.GetRequiredService<ApiContext>();
            var mediator = _serviceProvider.GetRequiredService<IMediator>();

            dbContext.Candidates.RemoveRange(dbContext.Candidates);
            await dbContext.SaveChangesAsync();

            var controller = new CandidateController(mediator);
            var result = await controller.InsertNewVoter(candidateToAdd);
            Assert.IsType<CreatedResult>(result);
            Assert.Equal(1, dbContext.Candidates.Count());
            var element = dbContext.Candidates.FirstOrDefault();
            Assert.NotNull(element);
            Assert.Equal(element.Name, candidateToAdd.Name);
        }
    }
}