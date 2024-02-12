using Microsoft.EntityFrameworkCore;
using Backend.Database.Models;

namespace Backend.Database
{
    public class NotifiedContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Company> Company { get; set; }

        public NotifiedContext(DbContextOptions<NotifiedContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyJob>()
                .HasKey(companyJob => new { companyJob.CompanyId, companyJob.JobId});
            modelBuilder.Entity<CompanyUser>()
                .HasKey(companyUser => new { companyUser.CompanyId, companyUser.UserId});
            modelBuilder.Entity<JobUser>()
                .HasKey(jobUser => new { jobUser.JobId, jobUser.UserId});
            
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Id).HasMethod("hash");
            modelBuilder.Entity<Job>()
                .HasIndex(job => job.CompanyId).HasMethod("btree");
            modelBuilder.Entity<CompanyUser>()
                .HasIndex(company_job => company_job.CompanyId).HasMethod("btree");
        }
    }
}
