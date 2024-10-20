using Microsoft.EntityFrameworkCore;
using voting_app_domain_layer.Models;

namespace voting_app_infrastructure_layer.Context
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "VotingApp");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Voter>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Candidate>()
                .HasKey(ep => ep.Id);

            modelBuilder.Entity<Voter>()
                .HasOne(ep => ep.Candidate)
                .WithMany(p => p.Voters)
                .HasForeignKey(ep => ep.CandidateId);
        }
        public DbSet<Voter> Voters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
    }
}
