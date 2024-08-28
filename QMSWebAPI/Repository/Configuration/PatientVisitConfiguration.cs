using QMSWebAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QMSWebAPI.Repository.Configuration
{
    public class PatientVisitConfiguration : IEntityTypeConfiguration<PatientVisit>
    {
        public void Configure(EntityTypeBuilder<PatientVisit> builder)
        {
            builder.HasKey(pv => new { pv.SectionId, pv.QueueId });
            builder.HasOne(pv => pv.Section)
                .WithMany()
                .HasForeignKey(pv => pv.SectionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
