using Microsoft.EntityFrameworkCore;
using PandapeInterview.Domain;

namespace PandapeInterview.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateExperiences> CandidateExperiences { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected ApplicationDbContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Candidate>()
        .HasKey(c => c.IdCandidate);


         modelBuilder.Entity<Candidate>()
        .HasMany(c => c.Experiences)  
        .WithOne(ce => ce.Candidates)  
        .HasForeignKey(ce => ce.IdCandidate);

        modelBuilder.Entity<CandidateExperiences>()
        .HasKey(ce => ce.IdCandidateExperience);

            base.OnModelCreating(modelBuilder);
        }
    }
}
