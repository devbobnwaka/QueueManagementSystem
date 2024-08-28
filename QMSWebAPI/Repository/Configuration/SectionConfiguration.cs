using QMSWebAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QMSWebAPI.Repository.Configuration
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasData(
                new Section
                {
                    Id = 1,
                    Name = "Pharmacy",
                },
                new Section
                {
                    Id = 2,
                    Name = "Doctor"
                }
            );
        }
    }
}
