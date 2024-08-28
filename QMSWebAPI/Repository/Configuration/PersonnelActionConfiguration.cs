using QMSWebAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QMSWebAPI.Repository.Configuration
{
    public class PersonnelActionConfiguration : IEntityTypeConfiguration<PersonnelAction>
    {
        public void Configure(EntityTypeBuilder<PersonnelAction> builder)
        {
            builder.HasKey(e => new { e.SectionId, e.QueueId });
            builder.HasOne(pa => pa.Queue)
                .WithMany()
                .HasForeignKey(pa => pa.QueueId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(pa => pa.Section)
                .WithMany()
                .HasForeignKey(pa => pa.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
