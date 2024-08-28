using QMSWebAPI.Entities.Models;
using QMSWebAPI.Repository.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace QMSWebAPI.Repository
{
    public class RepositoryContext: IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new SectionConfiguration());
            //builder.ApplyConfiguration(new PatientVisitConfiguration());
            builder.ApplyConfiguration(new PersonnelActionConfiguration());
           
        }

        public DbSet<QueueModel> Queues { get; set; }
        public DbSet<Section> Sections { get; set; }
        //public DbSet<PatientVisit> PatientVisits { get; set; }
        public DbSet<PersonnelAction> PersonnelActions { get; set; }



        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is User)
                {
                    ((User)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((User)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entityEntry.Entity is Section)
                {
                    ((Section)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((Section)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entityEntry.Entity is QueueModel)
                {
                    ((QueueModel)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((QueueModel)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entityEntry.Entity is PatientVisit)
                {
                    ((PatientVisit)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((PatientVisit)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entityEntry.Entity is PersonnelAction)
                {
                    ((PersonnelAction)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((PersonnelAction)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
