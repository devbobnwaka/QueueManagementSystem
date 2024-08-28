using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QMSWebAPI.Repository.Configuration
{
    public class RoleConfiguration: IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Name = "Personnel",
                    NormalizedName = "PERSONNEL"
                },
                new IdentityRole
                {
                    Name = "IMT",
                    NormalizedName="IMT"
                }
             );
        }

        
    }
}
