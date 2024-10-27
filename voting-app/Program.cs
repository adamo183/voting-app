using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using voting_app_application_layer.Voters.GetAllVoters;
using voting_app_domain_layer.Interfaces;
using voting_app_infrastructure_layer.Context;
using voting_app_infrastructure_layer.Middlewares;
using voting_app_infrastructure_layer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllVotersQueryHandler).Assembly));

builder.Services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase("voting-app-db"));
builder.Services.AddScoped<IVoterRepository, VoterRepository>();
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day) 
    .CreateLogger();

builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorLoggingMiddleware>();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Urls.Add($"http://*:{port}");

app.Run();
