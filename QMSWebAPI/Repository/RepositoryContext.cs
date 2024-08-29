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
                switch (entityEntry.Entity)
                {
                    case User user:
                    {
                        user.UpdatedAt = DateTime.UtcNow;
                        if (entityEntry.State == EntityState.Added)
                        {
                            user.CreatedAt = DateTime.UtcNow;
                        }

                        break;
                    }
                    case Section section:
                    {
                        section.UpdatedAt = DateTime.UtcNow;
                        if (entityEntry.State == EntityState.Added)
                        {
                            section.CreatedAt = DateTime.UtcNow;
                        }

                        break;
                    }
                    case QueueModel model:
                    {
                        model.UpdatedAt = DateTime.UtcNow;
                        if (entityEntry.State == EntityState.Added)
                        {
                            model.CreatedAt = DateTime.UtcNow;
                        }

                        break;
                    }
                    case PatientVisit visit:
                    {
                        visit.UpdatedAt = DateTime.UtcNow;
                        if (entityEntry.State == EntityState.Added)
                        {
                            visit.CreatedAt = DateTime.UtcNow;
                        }

                        break;
                    }
                    case PersonnelAction action:
                    {
                        action.UpdatedAt = DateTime.UtcNow;
                        if (entityEntry.State == EntityState.Added)
                        {
                            action.CreatedAt = DateTime.UtcNow;
                        }

                        break;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
