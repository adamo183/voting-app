using MediatR;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using voting_app_application_layer.Voters.GetAllVoters;
using voting_app_domain_layer.Interfaces;
using voting_app_infrastructure_layer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllVotersQueryHandler).Assembly));
builder.Services.AddScoped<IVoterRepository, VoterRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
